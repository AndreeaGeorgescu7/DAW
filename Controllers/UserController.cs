using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestDAW1.Repositories.RepoWrapper;

namespace TestDAW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepoWrapper _repo;

        public UserController(IRepoWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Authorize(Roles = "User")] //pt autentificare trb admin , user
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.User.GetAllUsers();

            return Ok(new { users });
        }
    }
  

}
