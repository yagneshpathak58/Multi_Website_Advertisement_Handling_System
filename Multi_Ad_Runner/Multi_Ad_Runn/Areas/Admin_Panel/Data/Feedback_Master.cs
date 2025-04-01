namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedback_Master
    {
        [Key]
        public int F_Id { get; set; }

        public string F_Name { get; set; }

        public string F_Email { get; set; }

        public string F_Title { get; set; }

        public string F_Message { get; set; }

        public string F_Status { get; set; }

        public DateTime? F_Date { get; set; }
    }
}
