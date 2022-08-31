using TestDAW1.Model.Entities;

namespace TestDAW1.Entities.DataTransferObject.UserDTO
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRole UserRoles { get; set; }
    }
}
