namespace TestDAW1.Entities
{
    public class PersonalData
    {
        public int Id { get; set; }
        public int HairStylistId { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        
        public HairStylist HairStylist { get; set; }


    }
}
