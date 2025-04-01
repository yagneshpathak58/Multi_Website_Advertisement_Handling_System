namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Master
    {
        [Key]
        public int Bi_Id { get; set; }

        public int? B_Num { get; set; }

        public int? U_Id { get; set; }

        public string Bi_Location { get; set; }

        public string Bi_Payment_Mode { get; set; }

        public int? Bi_Payment_Id { get; set; }

        public string Bi_SubAmmount { get; set; }

        public string Bi_CGst { get; set; }

        public string Bi_SGST { get; set; }

        public string Bi_IGST { get; set; }

        public string Bi_Total_Price { get; set; }

        public string Bi_Status { get; set; }

        public DateTime Bi_Date { get; set; }
    }
}
