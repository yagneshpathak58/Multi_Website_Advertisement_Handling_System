using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Repository
{
    public class Bill_MasterDLA
    {

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public List<Bill_Master> GetAllBill()
        {
            List<Bill_Master> lcm = new List<Bill_Master>();
            SqlCommand cmd = new SqlCommand("Bill_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "biDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lcm.Add(new Bill_Master
                {
                    Bi_Id = Convert.ToInt32(dr["Bi_Id"]),
                    B_Num = Convert.ToInt32(dr["B_Num"]),
                    U_Id = Convert.ToInt32(dr["U_Id"]),
                    Bi_Location = Convert.ToString(dr["Bi_Location"]),
                    Bi_Payment_Mode = Convert.ToString(dr["Bi_Payment_Mode"]),
                    Bi_Payment_Id = Convert.ToInt32(dr["Bi_Payment_Id"]),
                    Bi_SubAmmount=Convert.ToString(dr["Bi_SubAmmount"]),
                    Bi_CGst=Convert.ToString(dr["Bi_CGst"]),
                    Bi_SGST=Convert.ToString(dr["Bi_SGST"]),
                    Bi_IGST=Convert.ToString(dr["Bi_IGST"]),
                    Bi_Total_Price=Convert.ToString(dr["Bi_Total_Price"]),
                    Bi_Status=Convert.ToString(dr["Bi_Status"]),
                    Bi_Date = Convert.ToDateTime(dr["Bi_Date"]),
                });
            }
            return lcm;
        }
    }
}