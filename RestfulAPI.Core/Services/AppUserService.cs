using RestfulAPI.Core.Interfaces;
using RestfulAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulAPI.DataLayer.Context;
using ApplicationContext = RestfulAPI.DataLayer.Context.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace RestfulAPI.Core.Services
{
    public class AppUserService : IUserService
    {
        private readonly ApplicationContext _context;
        public AppUserService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
