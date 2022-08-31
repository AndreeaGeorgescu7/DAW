using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TestDAW1.Entities.DataTransferObject.UserDTO;
using TestDAW1.Model.Constants;
using TestDAW1.Model;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System;
using System.Security.Claims;
using TestDAW1.Repositories.RepoWrapper;
using TestDAW1.Model.Entities;

namespace TestDAW1.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepoWrapper _repo;

        public UserService(
            UserManager<User> userManager,
            IRepoWrapper repository)
        {
            _userManager = userManager;
            _repo = repository;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.Email = dto.Email;
            registerUser.UserName = dto.Email;
            registerUser.FirstName = dto.FirstName;
            registerUser.LastName = dto.LastName;
          //  registerUser.UserRoles = (ICollection<UserRole>)dto.UserRoles;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.User);

                return true;
            }

            return false;
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                user = await _repo.User.GetByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                //jwt token id      //generally unique 
                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(" Custom Secret Key"));

               var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);
                
                return tokenHandler.WriteToken(token);

                //salvam tokenul userului in db
                 _repo.SessionToken.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repo.SaveAsync();

                
            }

            return "";
        }

        //functia de generare a token ului
        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
