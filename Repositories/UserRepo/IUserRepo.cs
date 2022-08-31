using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Model.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
