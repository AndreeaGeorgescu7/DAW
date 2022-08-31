using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.BridePackRepo
{
    public interface IBridePackRepo : IGenericRepo<BridePackage>
        {
            Task<List<BridePackage>> GetAllBridePackages();
        }
    
}
