using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestDAW1.Data;
using TestDAW1.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.HairServiceRepo
{
    public class HairServiceRepo : GenericRepo<HairService>, IHairServiceRepo
    {
        public HairServiceRepo(Project_context context) : base(context)
        {
        }


        public async Task<List<HairService>> GetAllHairServices()
        {
            //vede doar id si name , celelalte trb incluse manual

            //s ar putea lambda sa nu mearga
            return await _context.HairServices.Include(hs => hs.HairStylist).ToListAsync();
        }
        public async Task<HairService> GetDetailsById(int id)
        {
            return await _context.HairServices.Include(a => a.HairStylist).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<HairService> GetPriceByName(string name)
        {
            return await _context.HairServices.Where(hs => hs.Name.Equals(name)).FirstOrDefaultAsync();
        }

       /* public async Task<HairService> GetHairServicesUnder100()
        {

           
        }
       */


    }
}
