using Microsoft.AspNetCore.Mvc;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Repositories;

namespace MusicService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    { 

        private readonly ILogger<MusicController> _logger;
        private readonly IAlbumRepository repository;

        public MusicController(ILogger<MusicController> logger, IAlbumRepository repo)
        {
            _logger = logger;
            repository = repo;
        }

        [HttpGet("{id}")]
        public Album GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Add(AddMusicDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var songs = new List<Song>();
            foreach (var songDTO in dto.Songs)
            {
                songs.Add(new Song()
                {
                    OrderNumber = songDTO.OrderNumber,
                    Name = songDTO.Name,
                    DurationInSeconds = songDTO.DurationInSeconds
                });
            }

            var album = new Album()
            {
                Name = dto.Name,
                Artist = new Artist() {Id = dto.ArtistID },
                ReleaseDate = dto.ReleaseDate,
                Types = dto.Types,
                Songs = songs
            };

            repository.Add(album);
            return Ok(album);
        }
    }
}