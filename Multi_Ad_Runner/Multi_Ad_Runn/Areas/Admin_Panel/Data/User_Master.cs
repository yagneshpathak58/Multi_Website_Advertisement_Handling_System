namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Master
    {
        [Key]
        public int U_Id { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        public string U_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string U_Email { get; set; }

        [Required(ErrorMessage = "Please Enter Contact")]
        public string U_Contact { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string U_Password { get; set; }

        public string U_Status { get; set; }

        public DateTime? U_Date { get; set; }
    }
}
