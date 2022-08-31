using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TestDAW1.Model.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        // public int UserId1 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        /*string Email { get; set; }
        string Password { get; set; }*/

        public virtual ICollection<UserRole> UserRoles { get; set; }
       // public string RefreshToken { get; set; }
    }
}
