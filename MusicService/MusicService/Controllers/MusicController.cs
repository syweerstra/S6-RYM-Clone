using Microsoft.AspNetCore.Mvc;
using MusicService.Data;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Repositories;
using RabbitMQLibrary;

namespace MusicService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    { 

        private readonly ILogger<MusicController> _logger;
        private readonly IAlbumRepository repository;
        private readonly IImageStorage imageStorage;

        public MusicController(ILogger<MusicController> logger, IAlbumRepository repo, IImageStorage imageStorage)
        {
            _logger = logger;
            repository = repo;
            this.imageStorage = imageStorage;
            //   this.producer = producer;
        }

        [HttpGet("{id}")]
        public Album GetById(int id)
        {
            return repository.GetById(id);
        }

        [HttpPut("edit")]
        public IActionResult Edit()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Add([FromForm] AddMusicDTO dto)
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

            var imageUrl = imageStorage.UploadImage(57, dto.AlbumCoverImage);

            var album = new Album()
            {
                Name = dto.Name,
                Artist = new Artist() { Id = dto.ArtistID },
                AlbumCoverImageURL = imageUrl,
                ReleaseDate = dto.ReleaseDate,
                Types = dto.Types,
                Songs = songs,
                Descriptors = dto.Descriptors,
                Languages = dto.Languages
            };

            repository.Add(album);
            return Ok(album);
        }
    }
}