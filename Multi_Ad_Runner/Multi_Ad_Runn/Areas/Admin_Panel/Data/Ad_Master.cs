namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Ad_Master
    {
        [Key]
        public int Ad_Id { get; set; }

        [Required(ErrorMessage = "Please Select Position")]
        public string Ad_Position { get; set; }

        [Required(ErrorMessage = "Please Select Page")]
        public string Ad_Page { get; set; }

        
        public string Ad_Des { get; set; }

        [Required(ErrorMessage = "Please Enter Price")]
        public string Ad_Price { get; set; }

        public string Ad_Status { get; set; }

        public DateTime? Ad_Date { get; set; }


    }
}
