using System.Collections.Generic;

namespace TestDAW1.Entities.DataTransferObject
{
    public class HairStylistDTO
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
    
        public PersonalData PersonalData { get; set; }
        public List<HairService> HairServices { get; set; }
        public List<EmployeeBridePackage> EmployeeBridePackages { get; set; }

        public HairStylistDTO(HairStylist hairstylist)
        {
            this.Id = hairstylist.Id;
            this.Name = hairstylist.Name;
            this.PersonalData = hairstylist.PersonalData;
            this.HairServices = new List<HairService>();
            this.EmployeeBridePackages = new List<EmployeeBridePackage>();
        }
    }
}
