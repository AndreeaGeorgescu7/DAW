using System.Collections.Generic;

namespace TestDAW1.Entities.DataTransferObject
{
    public class HairServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
        public int HairStylistId { get; set; }
        public List<HairStylist> HairStylists { get; set; }
       

        public HairServiceDTO(HairService HairService)
        {
            this.Id = HairService.Id;
            this.Name = HairService.Name;
            this.Price = HairService.Price;
            this.HairStylistId = HairService.HairStylistId;
            this.HairStylists = new List<HairStylist>();
           
        }

    }
}
