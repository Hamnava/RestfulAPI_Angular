using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.DataLayer.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
