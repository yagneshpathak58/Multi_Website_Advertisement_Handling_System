using Multi_Ad_Runn.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Multi_Ad_Runn.Repository
{
    public class Bill_MasterDLA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public bool AdRequest(Bill_Master bm)
        {

            int i;
            SqlCommand cmd = new SqlCommand("Bill_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "biInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@biid", bm.Bi_Id);
            cmd.Parameters.AddWithValue("@binum", bm.B_Num);
            cmd.Parameters.AddWithValue("@uid", bm.U_Id);
            cmd.Parameters.AddWithValue("@bipaymentmode", bm.Bi_Payment_Mode);
            cmd.Parameters.AddWithValue("@bipaymentid", bm.Bi_Payment_Id);
            cmd.Parameters.AddWithValue("@bisubammount", bm.Bi_SubAmmount);
            cmd.Parameters.AddWithValue("@bicgst", bm.Bi_CGst);
            cmd.Parameters.AddWithValue("@bisgst", bm.Bi_SGST);
            cmd.Parameters.AddWithValue("@biigst", bm.Bi_IGST);
            cmd.Parameters.AddWithValue("@bitotalprice", bm.Bi_Total_Price);
            cmd.Parameters.AddWithValue("@bistatus", "Active");
            cmd.Parameters.AddWithValue("@bidate", System.DateTime.Now);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}