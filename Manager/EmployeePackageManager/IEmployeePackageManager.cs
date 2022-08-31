using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;

namespace TestDAW1.Manager.EmployeePackageManager
{
    public interface IEmployeePackageManager
    {
       Task CreateEmployeeBridePackage(EmployeeBridePackage model);
        Task<int> DeleteEmployeeBridePackage(int id);
        Task<List<EmployeeBridePackage>> GetAll();
        Task UpdateEmployeeBridePackage(EmployeeBridePackage model);
        List<HairStylist> GetEmployees(int id);
    }
}
