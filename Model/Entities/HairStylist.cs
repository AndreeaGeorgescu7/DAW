using System.Collections.Generic;

namespace TestDAW1.Entities
{
    public class HairStylist
    { ///Mappare entitate din dot net in db
       //one to many cu hair services
        //tools ->package man console-> Add-Migration / Update-Database
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection <HairService> HairServices { get; set; }
        /// <summary>
        /// one to one
        /// </summary>
        
        public PersonalData PersonalData { get; set; }

        ///many to many
        public ICollection <EmployeeBridePackage> EmployeeBridePackages { get; set; }

    }
}
