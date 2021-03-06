using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQLibrary.Models;
using UserService.DTOs;
using UserService.Repositories;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;
        private readonly ILogger<UserController> _logger;
        private readonly IPublishEndpoint publishEndpoint;

        public UserController(IUserRepository repo, ILogger<UserController> logger, IPublishEndpoint publishEndpoint)
        {
            this.repo = repo;
            _logger = logger;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet("{name}")]
        public ActionResult<User> Get(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return repo.GetByName(name);
            else
                return BadRequest();
        }

        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser()
        {
            bool parseSuccess = Guid.TryParse(HttpContext.Request.Headers["userId"], out Guid userID);

            if (parseSuccess)
            {
                User deletedUser = repo.DeleteUser(userID);

                publishEndpoint.Publish
                (
                    new UserDeletedMessage
                    (
                        userID,
                        deletedUser.Ratings.Select(r => r.AlbumID).ToList()
                    )
                );
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPost("rating")]
        public int GetRating(GetAlbumRatingDTO dto)
        {
            return repo.GetRating(dto.AlbumID, dto.UserID);
        }

        [HttpPost("rate")]
        public IActionResult Rate(RateDTO dto)
        {
           var userId = Guid.Parse(HttpContext.Request.Headers["userId"]);
          // var usaName = HttpContext.Request.Headers["Username"];

            Rating r = new()
            {
                AlbumID = dto.AlbumID,
                UserID = userId,
                ArtistID = dto.ArtistID,
                Date = DateTime.Now,
                AlbumCoverImageURL = dto.AlbumCoverImageURL,
                AlbumName = dto.AlbumName,
                ArtistName = dto.ArtistName,
                AlbumReleaseYear = dto.AlbumReleaseYear,
                RatingOutOfTen = dto.RatingOutOfTen
            };

            var success = repo.Rate(r);
            if (success)
            { 
                publishEndpoint.Publish(new AlbumRatedMessage() { UserID = userId, AlbumID = r.AlbumID, RatingOutOfTen = dto.RatingOutOfTen});
                return Ok(dto);
            }
            else
                return Problem();
        }

        [HttpDelete("rate")]
        public IActionResult DeleteRating(DeleteRatingDTO dto)
        {
            return null;
        }

    }
}