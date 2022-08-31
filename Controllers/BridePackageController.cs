using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Model.Entities.DataTransferObject.BridePackDTO;
using TestDAW1.Repositories.BridePackRepo;

namespace TestDAW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BridePackageController : ControllerBase
    {
        private readonly IBridePackRepo _repo;
        public BridePackageController(IBridePackRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBridePackages()
        {
            var hs = await _repo.GetAllBridePackages();
            var hsToReturn = new List<BridePackDTO>();
            foreach (var h in hs)
            {
                hsToReturn.Add(new BridePackDTO(h));
            }
            return Ok(hsToReturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBridePack(CreateBridePackDTO dto)
        {
            BridePackage newHairstylist = new BridePackage();

            newHairstylist.Name = dto.Name;
            newHairstylist.Price = dto.Price;
            newHairstylist.Time = dto.Time;


            _repo.Create(newHairstylist);

            ///pt a se face si in db nu doar in memorie
            await _repo.SaveAsync();


            return Ok(new BridePackDTO(newHairstylist));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBride(int id)
        {
            var hairstylist = await _repo.GetByIdAsync(id);

            if (hairstylist == null)
            {
                return NotFound("This Package does not exist!");
            }

            _repo.Delete(hairstylist);

            await _repo.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBridePackage(int id, BridePackage model)
        {
            var person = await _repo.GetByIdAsync(id);

            if (person == null)
            {
                return BadRequest($"The package with id {id} does not exist");
            }

            person.NumberOfServices = model.NumberOfServices;

            _repo.Update(person);

            await _repo.SaveAsync();

            return Ok();
        }
    }
}
