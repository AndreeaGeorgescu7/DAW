using System.Collections.Generic;
using TestDAW1.Entities;

namespace TestDAW1.Model.Entities.DataTransferObject.EmployeeBrideDTO
{
    public class EmployeeBrideDTO
    {
        public int HairStylistId { get; set; }

        public int BridePackageId { get; set; }
        public HairStylist HairStylist { get; set; }
        public BridePackage BridePackage { get; set; }

        public EmployeeBrideDTO(EmployeeBridePackage hairstylist)
        {
            this.HairStylistId = hairstylist.HairStylistId;
            this.BridePackageId = hairstylist.BridePackageId;
     
        }
    }
}
