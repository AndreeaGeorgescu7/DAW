using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.HairStylistRepo
{
    public interface IHairStylistRepo: IGenericRepo<HairStylist> 
    {
        Task<HairStylist> GetByName(string name);
        Task<List<HairStylist>> GetAllHairstylistWithAddressInBucharest();
       Task<HairStylist> GetByIdWithAddress(int id);

    }
}
