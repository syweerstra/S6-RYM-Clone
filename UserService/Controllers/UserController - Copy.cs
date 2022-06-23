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
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        public ActionResult<User> Get()
        {
            return Ok("COOL HIJ WERKT");
        }
    }
}