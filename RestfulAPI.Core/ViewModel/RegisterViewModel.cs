using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.Core.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username should'nt be empty!!!")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is neccessary to be entered!!")]
        public string Password { get; set; }

    }
}
