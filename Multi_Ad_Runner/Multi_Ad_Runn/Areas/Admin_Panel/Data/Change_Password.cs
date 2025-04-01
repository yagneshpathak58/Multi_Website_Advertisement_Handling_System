using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    public class Change_Password
    {
        public int A_ID { get; set; }

        [Required(ErrorMessage = "Enter Old Password")]
        public string A_Password { get; set; }
        [Required(ErrorMessage = "New Password Is Require")]
        public string New_Password { get; set; }
        [Required(ErrorMessage = "Enter Confirm Password")]
        public string Confirm_Password { get; set; }
    }
}