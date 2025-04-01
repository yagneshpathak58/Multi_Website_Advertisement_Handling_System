using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multi_Ad_Runn.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter Email")]
        public string Log_Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Log_Password { get; set; }

        [Required(ErrorMessage = "Select Role")]
        public string Log_Role { get; set; }
    }
}