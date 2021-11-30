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
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _user.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<AppUser> GetUser(int id)
        {
            return await _user.GetById(id);
        }
    }
}
