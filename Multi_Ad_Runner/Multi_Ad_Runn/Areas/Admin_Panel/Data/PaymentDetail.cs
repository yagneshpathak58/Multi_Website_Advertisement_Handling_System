using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Data
{
    public class PaymentDetail
    {
        [Key]
        public int A_R_Id { get; set; }

        public int? U_Id { get; set; }

        public int? C_Id { get; set; }

        public string A_R_Duration { get; set; }

        public DateTime? A_R_Expire_Date { get; set; }

        public string A_R_Page { get; set; }

        public string A_R_Position { get; set; }

        public string A_R_Title { get; set; }

        public string A_R_ImageName { get; set; }

        public string A_R_ImagePath { get; set; }

        public string A_R_Status { get; set; }

        public DateTime? A_R_Date { get; set; }

        public List<SelectListItem> Category_Master { get; set; }

        public string U_Name { get; set; }

        public string U_Email { get; set; }

        public string U_Contact { get; set; }

        public string C_Name { get; set; }

        public string Ad_Page { get; set; }

        public string Ad_Position { get; set; }

        public string Ad_Price { get; set; }

        [Key]
        public int Bi_Id { get; set; }

        public int? B_Num { get; set; }

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

        [Key]
        public int Or_Id { get; set; }

        public string Or_Status { get; set; }

        public DateTime? Or_Date { get; set; }
    }
}