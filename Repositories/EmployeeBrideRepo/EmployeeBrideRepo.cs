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

}
