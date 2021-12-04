using RestfulAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetById(int id);
        Task<int> AddUser(AppUser user);
        Task<bool> ExistUsername(string username);
    }
}
