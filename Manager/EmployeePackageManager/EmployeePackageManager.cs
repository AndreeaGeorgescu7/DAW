using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TestDAW1.Repositories.EmployeeBrideRepo;
using TestDAW1.Entities;
using System.Linq;

namespace TestDAW1.Manager.EmployeePackageManager
{
    public class EmployeePackageManager
    {
        private readonly IEmployeeBrideRepo _repo;

        public EmployeePackageManager(IEmployeeBrideRepo repo)
        {
            _repo = repo;
        }

      /*  public async Task CreateEmployeeBridePackage(EmployeeBridePackage model)
        {
            var eb = new EmployeeBridePackage()
            {
                HairStylistId= model.HairStylistId,
                BridePackageId= model.BridePackageId,
               
            };

            await _repo.Create(eb);
        }

        public async Task<int> DeleteEmployeeBridePackage(int id)
        {
            var shoeOrder = await _repo.GetById(id);
            if (shoeOrder == null)
            {
                return -1;
            }

            await _repo.Delete(shoeOrder);
            return 1;
        }

        public async Task<List<EmployeeBridePackage>> GetAll()
        {
            var shoeOrders = await _repo.GetAll();
            return shoeOrders;
        }

        public async Task UpdateEmployeeBridePackage(EmployeeBridePackage model)
        {
            var shoeOrder = await _repo.GetById(model.BridePackageId);
            if (shoeOrder == null)
            {
                throw new Exception();
            }

          
            await _repo.Update(shoeOrder);
        }

        public List<HairStylist> GetEmployees(int id)
        {
            var shoeOrders = _repo.GetFullList().Where(x => x.BridePackageId == id).Select(x => x.HairstylistId).ToList();
            if (shoeOrders == null)
                throw new Exception();
            return shoeOrders;

        }
    }*/
}
}
