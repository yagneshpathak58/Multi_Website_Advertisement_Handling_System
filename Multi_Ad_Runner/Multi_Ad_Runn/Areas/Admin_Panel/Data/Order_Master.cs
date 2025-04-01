namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Master
    {
        [Key]
        public int Or_Id { get; set; }

        public int? B_Num { get; set; }

        public int? U_Id { get; set; }

        public string Ad_Price { get; set; }

        public string Or_Status { get; set; }

        public DateTime? Or_Date { get; set; }
    }
}
