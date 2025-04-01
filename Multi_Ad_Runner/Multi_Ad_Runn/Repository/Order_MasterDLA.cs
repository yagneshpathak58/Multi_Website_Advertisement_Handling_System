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
    public class Order_MasterDLA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public bool AdRequest(Order_Master om)
        {

            int i;
            SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "orInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orid", om.Or_Id);
            cmd.Parameters.AddWithValue("@binum", om.B_Num);
            cmd.Parameters.AddWithValue("@arid", om.A_R_Id);
            cmd.Parameters.AddWithValue("@adid", om.Ad_Id);
            cmd.Parameters.AddWithValue("@uid", om.U_Id);
            cmd.Parameters.AddWithValue("@adprice", om.Ad_Price);
            cmd.Parameters.AddWithValue("@orstatus", "Active");
            cmd.Parameters.AddWithValue("@ordate", System.DateTime.Now);
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

        //public PaymentDetails GetOrder(int? U_Id)
        //{

        //    PaymentDetails pd = new PaymentDetails();
        //    SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
        //    cmd.Parameters.Add(new SqlParameter("@mode", "orUDisplay"));
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@uid", U_Id);

        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.Read())
        //    {
        //        pd.Or_Id = Convert.ToInt32(sdr["Or_Id"]);
        //        pd.B_Num = Convert.ToInt32(sdr["B_Num"]);
        //        pd.U_Id = Convert.ToInt32(sdr["U_Id"]);
        //        pd.Ad_Price=sdr["Ad_Price"].ToString();
        //        pd.Or_Status = sdr["Or_Status"].ToString();
        //        pd.Or_Date =Convert.ToDateTime( sdr["Or_Date"]);
        //        //pd.Bi_Id = Convert.ToInt32(sdr["Bi_Id"]);
        //        //pd.Bi_Location=sdr["Bi_Location"].ToString() ;
        //        //pd.Bi_Payment_Mode = sdr["Bi_Payment_Mode"].ToString();
        //        //pd.Bi_Payment_Id = Convert.ToInt32(sdr[""]);
        //        //pd.Bi_SubAmmount = sdr["Bi_SubAmmount"].ToString();
        //        //pd.Bi_CGst = sdr["Bi_CGst"].ToString();
        //        //pd.Bi_SGST = sdr["Bi_SGST"].ToString();
        //        //pd.Bi_IGST = sdr["Bi_IGST"].ToString();
        //        //pd.Bi_Total_Price = sdr["Bi_Total_Price"].ToString();
        //        //pd.Bi_Status = sdr["Bi_Status"].ToString();
        //        //pd.Bi_Date = Convert.ToDateTime(sdr["Bi_Date"]);
        //        //pd.A_R_Title = sdr["A_R_Title"].ToString();
        //        //pd.A_R_Page = sdr["A_R_Page"].ToString();
        //        //pd.A_R_Position = sdr["A_R_Position"].ToString();
        //        //pd.A_R_Expire_Date = Convert.ToDateTime(sdr["A_R_Expire_Date"]);



        //        return pd;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public List<PaymentDetails> GetOrder(int? U_Id)
        {
            List<PaymentDetails> lcm = new List<PaymentDetails>();
            SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "orUDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", U_Id);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lcm.Add(new PaymentDetails
                {
                    
                    Or_Id = Convert.ToInt32(dr["Or_Id"]),
                    B_Num = Convert.ToInt32(dr["B_Num"]),
                    U_Id = Convert.ToInt32(dr["U_Id"]),
                    C_Id = Convert.ToInt32(dr["C_Id"]),
                    A_R_Duration = Convert.ToString(dr["A_R_Duration"]),
                    A_R_Expire_Date = Convert.ToDateTime(dr["A_R_Expire_Date"]),
                    A_R_Page = Convert.ToString(dr["Ad_Price"]),
                    A_R_Position = Convert.ToString(dr["A_R_Position"]),
                    A_R_Title = Convert.ToString(dr["A_R_Title"]),
                    A_R_ImageName = Convert.ToString(dr["A_R_ImageName"]),
                    A_R_ImagePath=Convert.ToString(dr["A_R_ImagePath"]),
                    Ad_Price =Convert.ToString(dr["Ad_Price"]),
                    Or_Status = Convert.ToString(dr["Or_Status"]),
                    Or_Date = Convert.ToDateTime(dr["Or_Date"]),
                    
                    


                });
            }
            return lcm;
        }

        public PaymentDetails GetOrderBillDetail(int Bnum , int cid)
        {
            PaymentDetails pd = new PaymentDetails();
            SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "OrderBillDetail"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@binum", Bnum);
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                pd.B_Num = Convert.ToInt32(sdr["B_Num"]);
                pd.C_Id = Convert.ToInt32(sdr["C_Id"]);
                pd.A_R_Title = sdr["A_R_Title"].ToString();
                pd.A_R_Page = sdr["A_R_Page"].ToString();
                pd.A_R_Position = sdr["A_R_Position"].ToString();
                pd.A_R_Duration = sdr["A_R_Duration"].ToString();
                pd.A_R_Expire_Date = Convert.ToDateTime(sdr["A_R_Expire_Date"]);
                pd.A_R_ImageName = sdr["A_R_ImageName"].ToString();
                pd.A_R_ImagePath = sdr["A_R_ImagePath"].ToString();
                pd.Bi_Id = Convert.ToInt32(sdr["Bi_Id"]);
                pd.Bi_Location = sdr["Bi_Location"].ToString();
                pd.Bi_Payment_Mode = sdr["Bi_Payment_Mode"].ToString();
                pd.Bi_Payment_Id = Convert.ToInt32(sdr["Bi_Payment_Id"]);
                pd.Bi_SubAmmount = sdr["Bi_SubAmmount"].ToString();
                pd.Bi_CGst = sdr["Bi_CGst"].ToString();
                pd.Bi_SGST = sdr["Bi_SGST"].ToString();
                pd.Bi_IGST=sdr["Bi_IGST"].ToString() ;
                pd.Bi_Total_Price = sdr["Bi_Total_Price"].ToString();
                pd.Bi_Date = Convert.ToDateTime(sdr["Bi_Date"]);
                pd.C_Name = sdr["C_Name"].ToString();
                return pd;
            }
            else
            {
                return null;
            }
        }
    }
}