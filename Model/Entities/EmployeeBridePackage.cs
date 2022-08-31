namespace TestDAW1.Entities
{
    public class EmployeeBridePackage
    {

        public int  HairStylistId { get; set; }

        public int BridePackageId { get; set; }
        public HairStylist HairStylist { get; set; }
        public BridePackage BridePackage { get; set; }


    }
}
