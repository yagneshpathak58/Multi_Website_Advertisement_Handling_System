namespace Multi_Ad_Runn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ad_Master
    {
        [Key]
        public int Ad_Id { get; set; }

        public string Ad_Position { get; set; }

        public string Ad_Page { get; set; }

        public string Ad_Des { get; set; }

        public string Ad_Price { get; set; }

        public string Ad_Status { get; set; }

        public DateTime? Ad_Date { get; set; }
    }
}
