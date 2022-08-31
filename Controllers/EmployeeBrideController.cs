using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Data;
using TestDAW1.Entities;
using TestDAW1.Entities.DataTransferObject;
using TestDAW1.Manager.EmployeePackageManager;
using TestDAW1.Model.Entities.DataTransferObject.EmployeeBrideDTO;
using TestDAW1.Repositories.EmployeeBrideRepo;

namespace TestDAW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBrideController : ControllerBase
    {
        private readonly IEmployeeBrideRepo _repo;

        public EmployeeBrideController(IEmployeeBrideRepo repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBrideApp()
        {
            var hs = await _repo.GetAllBrideEmp();
            var hsToReturn = new List<EmployeeBrideDTO> ();
            foreach (var h in hs)
            {
                hsToReturn.Add(new EmployeeBrideDTO(h));
            }
            return Ok(hsToReturn);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployeeBride(CreateEmployeeBrideDTO model)
        {
            EmployeeBridePackage employeebride = new EmployeeBridePackage()
            {
                HairStylistId = model.HairStylistId,
                BridePackageId = model.BridePackageId

            };
             _repo.Create(employeebride);

             await _repo.SaveAsync();

             return Ok(new EmployeeBrideDTO(employeebride));
           // return Ok();
          
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPerson(int id, EmployeeBridePackage model)
        {
           /* var person = await _repo.GetById(id);

            if (person == null)
            {
                return BadRequest($"The person with id {id} does not exist");
            }

            person.HairStylistId = model.HairStylistId;

            _repo.UpdateEmployeeBridePackage(person);

           // await _repo.SaveAsync();*/

            return Ok();
        }
       
    }
}

