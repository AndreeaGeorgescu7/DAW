using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDAW1.Data;
using TestDAW1.Entities;
using TestDAW1.Model;
using TestDAW1.Repositories.GenericRepo;
using static TestDAW1.Repositories.EmployeeBrideRepo.EmployeeBrideRepo;

namespace TestDAW1.Repositories.EmployeeBrideRepo
{
    public class EmployeeBrideRepo : GenericRepo<EmployeeBridePackage>, IEmployeeBrideRepo
    {

        private readonly Project_context _context;

        public EmployeeBrideRepo(Project_context context):base(context)
        {
           
        }

      /* public async Task Create(EmployeeBridePackage shoeOrder)
        {
            await _context.EmployeeBridePackages.AddAsync(shoeOrder);
            await _context.SaveChangesAsync();
        }*/

       /* public async Task Delete(EmployeeBridePackage shoeOrder)
        {
            _context.Remove(shoeOrder);
            await _context.SaveChangesAsync();
        }
     */
        public async Task<List<EmployeeBridePackage>> GetAllBrideEmp()
        {
           //List<EmployeeBridePackage> parts = new List<EmployeeBridePackage>();

            // Add parts to the list.
           // parts.Add(new EmployeeBridePackage() { BridePackageId =2, HairStylistId = 2 });
        
              var objs = await ( GetAll()).ToListAsync();
              var list = new List<EmployeeBridePackage>();
              foreach (var obj in objs)
              {
                  var model = new EmployeeBridePackage
                  {

                      HairStylistId = obj.HairStylistId,
                      BridePackageId = obj.BridePackageId,

                  };
                  list.Add(model);
              }
              return list;
         

        }
/*
        public async Task<IQueryable<EmployeeBridePackage>> GetAllQuery()
        {
            var query = _context.EmployeeBridePackages.AsQueryable();
            return query;
        }
        public IQueryable<EmployeeBridePackage> GetFullList()
        {
            var query = _context.EmployeeBridePackages.Include(x => x.HairStylist).AsQueryable();
            return query;
        }

        public async Task<EmployeeBridePackage> GetById(int id)
        {
            var shoeOrder = await _context.EmployeeBridePackages.FindAsync(id);
            return shoeOrder;
        }

        public async Task Update(EmployeeBridePackage shoeOrder)
        {
            _context.EmployeeBridePackages.Update(shoeOrder);
            await _context.SaveChangesAsync();
        }

        
   */ }
}
