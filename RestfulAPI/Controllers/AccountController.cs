using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Core.Interfaces;
using RestfulAPI.Core.ViewModel;
using RestfulAPI.DataLayer.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly IUserService _user;
        public AccountController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser(RegisterViewModel viewModel)
        {
            if (await _user.ExistUsername(viewModel.Username))
            {
                return BadRequest("Username is already taken!");
            }

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                FirstName = viewModel.Username,
                LastName = viewModel.Username + " last",
                Username = viewModel.Username.ToLower(),
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(viewModel.Password)),
                passwordSalt = hmac.Key
            };
            await _user.AddUser(user);

            return Ok(user);
        }

        
    }
}
