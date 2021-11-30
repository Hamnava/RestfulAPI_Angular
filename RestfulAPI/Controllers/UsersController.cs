using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Core.Interfaces;
using RestfulAPI.DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;
        public UsersController(IUserService user)
        {
            _user = user; 
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user =  await _user.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _user.GetById(id);
            return Ok(user);
        }
    }
}
