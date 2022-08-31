using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TestDAW1.Model.Entities
{
    public class Role : IdentityRole<int>
    {
        //  public int RoleId1 { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
