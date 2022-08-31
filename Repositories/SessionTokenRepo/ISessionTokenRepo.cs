using System.Threading.Tasks;
using TestDAW1.Model;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.SessionTokenRepo
{
    public interface ISessionTokenRepo : IGenericRepo<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }
}
