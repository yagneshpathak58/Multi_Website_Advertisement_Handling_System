using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multi_Ad_Runn.Models
{
    public class Change_Password
    {
        public int U_Id { get; set; }
        [Required(ErrorMessage = "Enter OldPassword")]
        public string U_Password { get; set; }

        [Required(ErrorMessage = "Enter New Password")]

        public string New_Password { get; set; }

        [Required(ErrorMessage = "Enter ConfirmPassword")]
        public string Confirm_Password { get; set; }

        
        public string U_Name { get; set; }

        public int Pu_Id { get; set; }
        [Required(ErrorMessage = "Enter OldPassword")]
        public string Pu_Password { get; set; }

    }
}