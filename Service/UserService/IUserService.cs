using System.Threading.Tasks;
using TestDAW1.Entities.DataTransferObject.UserDTO;

namespace TestDAW1.Service.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
