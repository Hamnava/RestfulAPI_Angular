using RestfulAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.Core.Interfaces
{
    public interface ITokenuser
    {
        string CreateToken(AppUser user);
        
    }
}
