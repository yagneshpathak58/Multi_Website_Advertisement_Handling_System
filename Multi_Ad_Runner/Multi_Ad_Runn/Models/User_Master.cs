namespace Multi_Ad_Runn.Models
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

        [Required(ErrorMessage = "Enter Name")]
        public string U_Name { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string U_Email { get; set; }

        [Required(ErrorMessage = "Enter Contact")]
        public string U_Contact { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string U_Password { get; set; }

        public string U_Status { get; set; }

        public DateTime? U_Date { get; set; }
    }
}
