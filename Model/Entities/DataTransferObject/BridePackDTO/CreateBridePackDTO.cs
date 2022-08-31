using System.Collections.Generic;
using TestDAW1.Entities;

namespace TestDAW1.Model.Entities.DataTransferObject.BridePackDTO
{
    public class CreateBridePackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public float Time { get; set; }

        public int NumberOfServices { get; set; }
        public List<EmployeeBridePackage> EmployeeBridePackages { get; set; }
    }
}
