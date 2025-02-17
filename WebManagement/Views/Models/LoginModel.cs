using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebManagement.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Username.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }
    }
}
