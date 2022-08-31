using System.Collections.Generic;

namespace TestDAW1.Entities
{
    public class BridePackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public float Time { get; set; }

        public int NumberOfServices { get; set; }
        public ICollection<EmployeeBridePackage> EmployeeBridePackages { get; set; }
    }
}