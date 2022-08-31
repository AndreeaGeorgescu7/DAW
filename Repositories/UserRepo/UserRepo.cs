using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Model;
using TestDAW1.Model.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
    

        public UserRepo(AppDbContext context) : base(context) { }
        public async Task<List<User>> GetAllUsers()
        {
            return await context2.Users.ToListAsync();
        }
        public async Task<User> GetByIdWithRoles(int id)
        {
            return await context2.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

   

    public async Task<User> GetUserByEmail(string email)
        {
            return await context2.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
