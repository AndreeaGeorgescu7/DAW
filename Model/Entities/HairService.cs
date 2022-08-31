namespace TestDAW1.Entities
{
    public class HairService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

       public int HairStylistId { get; set; }
        public HairStylist HairStylist { get; set; }
    }
}
