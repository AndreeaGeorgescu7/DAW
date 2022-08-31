using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Entities.DataTransferObject;
using TestDAW1.Repositories.HairServiceRepo;

namespace TestDAW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairServiceController : ControllerBase
    {
        //adaugam repository
        private readonly IHairServiceRepo _repo;
        public HairServiceController(IHairServiceRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHairServices()
        {
            var hs = await _repo.GetAllHairServices();
            var hsToReturn = new List<HairServiceDTO>();
            foreach (var h in hs)
            {
                hsToReturn.Add(new HairServiceDTO(h));
            }
            return Ok(hsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var hs = await _repo.GetByIdAsync(id);

            return Ok(new HairServiceDTO(hs));
        }
        //GET PRICE BY NAME

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHairService(int id)
        {
            var HairService = await _repo.GetByIdAsync(id);

            if (HairService == null)
            {
                return NotFound("HairService does not exist!");
            }

            _repo.Delete(HairService);

            await _repo.SaveAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> CreateHairService(CreateHairServiceDTO dto)
        {
            HairService newHairService = new HairService();

            newHairService.Name = dto.Name;
            newHairService.Price = dto.Price;
            newHairService.HairStylistId = dto.HairStylistId;

            _repo.Create(newHairService);

            ///pt a se face si in db nu doar in memorie
            await _repo.SaveAsync();


            return Ok(new HairServiceDTO(newHairService));
        }

    }
}
