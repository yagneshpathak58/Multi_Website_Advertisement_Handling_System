namespace Multi_Ad_Runn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Ad_Request_Master
    {
        [Key]
        public int A_R_Id { get; set; }

        
        public int? U_Id { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int? C_Id { get; set; }

        [Required(ErrorMessage = "Please Select Duration")]
        public string A_R_Duration { get; set; }


        public DateTime? A_R_Expire_Date { get; set; }

        [Required(ErrorMessage = "Please Select Page")]
        public string A_R_Page { get; set; }

        [Required(ErrorMessage = "Please Select Position")]
        public string A_R_Position { get; set; }

        [Required(ErrorMessage = "Enter Ad Title")]
        public string A_R_Title { get; set; }

        [Required(ErrorMessage = "Please Select Image")]
        public string A_R_ImageName { get; set; }

        public string A_R_ImagePath { get; set; }

        public string A_R_Status { get; set; }

        public DateTime? A_R_Date { get; set; }

        public List<SelectListItem> Category_Master { get; set; }

        public string U_Name { get; set; }

        public string U_Email { get; set; }

        public string C_Name { get; set; }

        public string Ad_Page { get; set; }

        public string Ad_Position { get; set; }

        public string Ad_Price { get; set; }

    }
}
