using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.EmployeeBrideRepo
{
    public interface IEmployeeBrideRepo : IGenericRepo<EmployeeBridePackage>
    {

       Task<List<EmployeeBridePackage>> GetAllBrideEmp();
     
       //Task CreateEmployeeBride(EmployeeBridePackage shoeOrder);
      
        /*    Task<EmployeeBridePackage> GetById(int id);
*    Task Update(EmployeeBridePackage shoeOrder);
Task Delete(EmployeeBridePackage shoeOrder);
Task<IQueryable<EmployeeBridePackage>> GetAllQuery();
public IQueryable<EmployeeBridePackage> GetFullList();
*/
    }
}
