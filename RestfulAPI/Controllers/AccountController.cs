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
        private readonly ITokenuser _tokenuser;
        public AccountController(IUserService user, ITokenuser token)
        {
            _user = user;
            _tokenuser = token;
        }
        /********* Regisete part *******/
        [HttpPost("register")]
        public async Task<ActionResult<UserViewModel>> AddUser(RegisterViewModel viewModel)
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

            return new UserViewModel
            {
                Username = viewModel.Username,
                Token = _tokenuser.CreateToken(user)
            };
        }

        /********* Login part *********/
        [HttpPost("Login")]
        public async Task<ActionResult<UserViewModel>> Login(LoginViewModel viewModel)
        {
            var User =await _user.ExistUser(viewModel.Username);
            if (User == null) return Unauthorized("Notfound username");

            using var hmac = new HMACSHA512(User.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(viewModel.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != User.passwordHash[i])
                {
                    return Unauthorized("Invalid password!!!");
                }
            }
            return new UserViewModel
            {
                Username = viewModel.Username,
                Token = _tokenuser.CreateToken(User)
            };

        }
        
    }
}
