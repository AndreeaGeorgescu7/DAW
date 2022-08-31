using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Data;
using TestDAW1.Entities;
using TestDAW1.Repositories.EmployeeBrideRepo;
using TestDAW1.Repositories.GenericRepo;

namespace TestDAW1.Repositories.BridePackRepo
{
    public class BridePackRepo : GenericRepo<BridePackage>, IBridePackRepo
        {


            public BridePackRepo(Project_context context) : base(context) { }

            public object BridePackages { get; internal set; }

            public async Task<List<BridePackage>> GetAllBridePackages()
            {
                return await _context.BridePackages.ToListAsync();
            }
        }
}
