namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category_Master
    {
        [Key]
        public int C_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category")]
        public string C_Name { get; set; }

        public string C_Des { get; set; }

        public string C_Status { get; set; }

        public DateTime? C_Date { get; set; }
    }
}
