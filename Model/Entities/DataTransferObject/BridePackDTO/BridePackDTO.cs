using System.Collections.Generic;
using TestDAW1.Entities;

namespace TestDAW1.Model.Entities.DataTransferObject.BridePackDTO
{
    public class BridePackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public float Time { get; set; }

        public int NumberOfServices { get; set; }
        public List<EmployeeBridePackage> EmployeeBridePackages { get; set; }
        public BridePackDTO(BridePackage hairstylist)
        {
            this.Id = hairstylist.Id;
            this.Name = hairstylist.Name;
            this.Price = hairstylist.Price;
            this.Time = hairstylist.Time;
            this.NumberOfServices = hairstylist.NumberOfServices;

            this.EmployeeBridePackages = new List<EmployeeBridePackage>();
        }
    }
}
