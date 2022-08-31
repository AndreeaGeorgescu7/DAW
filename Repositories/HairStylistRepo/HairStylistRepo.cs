using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDAW1.Data;
using TestDAW1.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.HairStylistRepo
{
    public class HairStylistRepo : GenericRepo<HairStylist>, IHairStylistRepo
    {
        public HairStylistRepo(Project_context context) : base(context)
        {
        }

       public async Task<List<HairStylist>> GetAllHairstylistWithAddressInBucharest()
        {
            //vede doar id si name , celelalte trb incluse manual
            return await _context.HairStylists.Include(hs=>hs.PersonalData).ToListAsync();
        }
        public async Task<HairStylist> GetByIdWithAddress(int id)
        {
            return await _context.HairStylists.Include(a => a.PersonalData).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<HairStylist> GetByName(string name)
        {
            return await _context.HairStylists.Where(hs => hs.Name.Equals(name)).FirstOrDefaultAsync();
        }

       
    }
}
