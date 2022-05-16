using Microsoft.AspNetCore.Mvc;
using UserService.Repositories;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repo, ILogger<UserController> logger)
        {
            this.repo = repo;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if (id > 0)
                return repo.GetById(id);
            else
                return BadRequest();
        }

        [HttpPost("rate")]
        public IActionResult Rate()
        {

        }
    }
}