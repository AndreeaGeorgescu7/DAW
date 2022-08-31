using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Entities.DataTransferObject;
using TestDAW1.Repositories.HairStylistRepo;


namespace TestDAW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStylistController : ControllerBase
    {
        //adaugam repository
        private readonly IHairStylistRepo _repo;
        public HairStylistController(IHairStylistRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHairStylists()
        {
            var hs = await _repo.GetAllHairstylistWithAddressInBucharest();
            var hsToReturn = new List<HairStylistDTO>();
            foreach (var h in hs)
            {
                hsToReturn.Add(new HairStylistDTO(h));
            }
            return Ok(hsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllHairStylistsById(int id)
        {
            var hs = await _repo.GetByIdAsync(id);

            return Ok(new HairStylistDTO(hs));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHairstylist(int id)
        {
            var hairstylist = await _repo.GetByIdAsync(id);

            if (hairstylist == null)
            {
                return NotFound("Hairstylist does not exist!");
            }

            _repo.Delete(hairstylist);

            await _repo.SaveAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> CreateHairstylist(CreateHairStylistDTO dto)
        {
            HairStylist newHairstylist = new HairStylist();

            newHairstylist.Name = dto.Name;
            newHairstylist.PersonalData = dto.PersonalData;

            _repo.Create(newHairstylist);

            ///pt a se face si in db nu doar in memorie
            await _repo.SaveAsync();


            return Ok(new HairStylistDTO(newHairstylist));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPerson(int id,HairStylist model)
        {
            var person =await _repo.GetByIdAsync(id);

            if (person == null)
            {
                return BadRequest($"The person with id {id} does not exist");
            }

            person.Name = model.Name;

           _repo.Update(person);

            await _repo.SaveAsync();

            return Ok();
        }
    }
}
