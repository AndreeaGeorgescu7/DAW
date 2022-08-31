using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using TestDAW1.Repositories.RepoWrapper;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace TestDAW1.Helps
{
    public class SessionTokenVal
    {
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repo = context.HttpContext.RequestServices.GetRequiredService<IRepoWrapper>();

            if (context.Principal.HasClaim(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {

                var jti = context.Principal.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;

                var tokenInDb = await repo.SessionToken.GetByJTI(jti);
                if (tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }
            }

            context.Fail("");
        }
    }
}
