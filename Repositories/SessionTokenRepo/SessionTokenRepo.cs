using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using System.Threading.Tasks;
using TestDAW1.Model;
using TestDAW1.Repositories.GenericRepo;
using SessionToken = TestDAW1.Model.SessionToken;

namespace TestDAW1.Repositories.SessionTokenRepo
{
    public class SessionTokenRepository : GenericRepo<SessionToken>, ISessionTokenRepo
    {
        public SessionTokenRepository(AppDbContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await context2.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
