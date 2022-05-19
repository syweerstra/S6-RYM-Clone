using ArtistService.Models;
using ArtistService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArtistService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistRepository artistRepository;

        public ArtistController(ILogger<ArtistController> logger, IArtistRepository repo)
        {
            _logger = logger;
            artistRepository = repo;
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        {
            if(id > 0)
            {
                var artist = artistRepository.GetByID(id);
                return artist;
            }

            return BadRequest();
        }
    }
}