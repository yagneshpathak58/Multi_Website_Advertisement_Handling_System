namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin_Master
    {
        [Key]
        public int A_Id { get; set; }

        public string A_Name { get; set; }

        public string A_Email { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        public string A_U_Name { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string A_Password { get; set; }

        public string A_Status { get; set; }

        public DateTime? A_Date { get; set; }
        public string A_New_Password { get; set; }
    }
}
