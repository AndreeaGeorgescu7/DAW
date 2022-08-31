using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using System.Threading.Tasks;
using TestDAW1.Model;
using TestDAW1.Repositories;
using TestDAW1.Repositories.SessionTokenRepo;

namespace TestDAW1.Repositories.RepoWrapper
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly AppDbContext _context;
        private IUserRepo _user;
        private ISessionTokenRepo _sessionTk;
        public RepoWrapper(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepo User
        {
            get
            {
                if (_user == null) _user = new UserRepo(_context);
                return _user;
            }
        }
        public ISessionTokenRepo SessionToken
        {
            get
            {
                if (_sessionTk == null) _sessionTk = new SessionTokenRepository(_context);
                return _sessionTk;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
