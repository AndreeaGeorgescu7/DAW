using System.Threading.Tasks;
using TestDAW1.Repositories;
using TestDAW1.Repositories.SessionTokenRepo;

namespace TestDAW1.Repositories.RepoWrapper
{
    public interface IRepoWrapper
    {
        IUserRepo User { get; }
        ISessionTokenRepo SessionToken { get; }
        Task SaveAsync();
    }
}
