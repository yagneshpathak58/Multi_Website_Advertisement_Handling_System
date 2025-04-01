namespace Multi_Ad_Runn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Publisher_Master
    {
        [Key]
        public int Pu_Id { get; set; }

        [Required(ErrorMessage = "Select Category")]
        public int? C_Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Pu_Name { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Pu_Email { get; set; }

        [Required(ErrorMessage = "Enter Contact")]
        public string Pu_Contact { get; set; }

        
        public string Pu_Password { get; set; }

        [Required(ErrorMessage = "Enter Website")]
        public string Pu_WebSite { get; set; }

        public string Pu_Status { get; set; }

        public DateTime? Pu_Date { get; set; }

        public List<SelectListItem> Category_Master { get; set; }
    }
}
