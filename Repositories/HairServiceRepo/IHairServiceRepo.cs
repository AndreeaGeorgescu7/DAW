using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.HairServiceRepo
{
   
    public interface IHairServiceRepo : IGenericRepo<HairService>
    {
        Task<HairService> GetPriceByName(string name);
        Task<List<HairService>> GetAllHairServices();

        Task<HairService> GetDetailsById(int id);
      //  Task<HairService> GetHairServicesUnder100();

    }
}
