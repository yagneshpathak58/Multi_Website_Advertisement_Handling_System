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
    public class PaymentDetailsDLA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public PaymentDetails GetData( int? C_Id,int? U_Id ,string Ad_Price)
        {
            
            PaymentDetails pd = new PaymentDetails();
            SqlCommand cmd = new SqlCommand("Ad_Request_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "joinDisplayS"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", U_Id);
            cmd.Parameters.AddWithValue("@adprice", Ad_Price);
            cmd.Parameters.AddWithValue("@cid", C_Id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                
                pd.U_Id = Convert.ToInt32(sdr["U_Id"]);
                pd.U_Name = sdr["U_Name"].ToString();
                pd.U_Email = sdr["U_Email"].ToString();
                pd.C_Id = Convert.ToInt32(sdr["C_Id"]);
                pd.U_Contact = sdr["U_Contact"].ToString();
                pd.Ad_Price = sdr["Ad_Price"].ToString();
                pd.C_Name = sdr["C_Name"].ToString();
                //pd.A_R_Title = sdr["A_R_Title"].ToString();
                //pd.A_R_Page = sdr["A_R_Page"].ToString();
                //pd.A_R_Position = sdr["A_R_Position"].ToString();
                //pd.A_R_Expire_Date = Convert.ToDateTime(sdr["A_R_Expire_Date"]);



                return pd;
            }
            else
            {
                return null;
            }
        }

        public PaymentDetails GetPrice(string A_R_Page, string A_R_Position)
        {

            PaymentDetails pd = new PaymentDetails();
            SqlCommand cmd = new SqlCommand("Ad_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adPrice"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adpage", A_R_Page);
            cmd.Parameters.AddWithValue("@adposition", A_R_Position);
            
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

                pd.Ad_Price = sdr["Ad_Price"].ToString();
                pd.Ad_Page = sdr["Ad_Page"].ToString();
                pd.Ad_Position = sdr["Ad_Position"].ToString();
                



                return pd;
            }
            else
            {
                return null;
            }
        }

        public bool AdRequest(PaymentDetails pd)
        {

            int i;
            SqlCommand cmd = new SqlCommand("Ad_Request_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "arInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@arid", pd.A_R_Id);
            cmd.Parameters.AddWithValue("@uid", pd.U_Id);
            cmd.Parameters.AddWithValue("@cid", pd.C_Id);
            cmd.Parameters.AddWithValue("@arduration", pd.A_R_Duration);
            cmd.Parameters.AddWithValue("@arexdate", pd.A_R_Expire_Date);
            cmd.Parameters.AddWithValue("@arpage", pd.A_R_Page);
            cmd.Parameters.AddWithValue("@arposition", pd.A_R_Position);
            cmd.Parameters.AddWithValue("@artitle", pd.A_R_Title);
            cmd.Parameters.AddWithValue("@arimagename", pd.A_R_ImageName);
            cmd.Parameters.AddWithValue("@arimagepath", pd.A_R_ImagePath);
            cmd.Parameters.AddWithValue("@arstatus", "Active");
            cmd.Parameters.AddWithValue("@ardate", System.DateTime.Now);
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

        public bool AddBill(PaymentDetails pd)
        {
            Random r = new Random();
            int i;
            SqlCommand cmd = new SqlCommand("Bill_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "biInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@biid", pd.Bi_Id);
            cmd.Parameters.AddWithValue("@binum", pd.B_Num);
            cmd.Parameters.AddWithValue("@uid", pd.U_Id);
            cmd.Parameters.AddWithValue("@bilocation", pd.Bi_Location);
            cmd.Parameters.AddWithValue("@bipaymentmode", pd.Bi_Payment_Mode);
            cmd.Parameters.AddWithValue("@bipaymentid", r.Next());
            cmd.Parameters.AddWithValue("@bisubammount", pd.Bi_SubAmmount);
            cmd.Parameters.AddWithValue("@bicgst", pd.Bi_CGst);
            cmd.Parameters.AddWithValue("@bisgst", pd.Bi_SGST);
            cmd.Parameters.AddWithValue("@biigst", pd.Bi_IGST);
            cmd.Parameters.AddWithValue("@bitotalprice", pd.Bi_Total_Price);
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

        public bool AddOrder(PaymentDetails pd)
        {

            int i;
            SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "orInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orid", pd.Or_Id);
            cmd.Parameters.AddWithValue("@binum", pd.B_Num);
            cmd.Parameters.AddWithValue("@uid", pd.U_Id);
            cmd.Parameters.AddWithValue("@cid", pd.C_Id);
            cmd.Parameters.AddWithValue("@arduration", pd.A_R_Duration);
            cmd.Parameters.AddWithValue("@arexdate", pd.A_R_Expire_Date);
            cmd.Parameters.AddWithValue("@arpage", pd.A_R_Page);
            cmd.Parameters.AddWithValue("@arposition", pd.A_R_Position);
            cmd.Parameters.AddWithValue("@artitle", pd.A_R_Title);
            cmd.Parameters.AddWithValue("@arimagename", pd.A_R_ImageName);
            cmd.Parameters.AddWithValue("@arimagepath", pd.A_R_ImagePath);
            cmd.Parameters.AddWithValue("@adprice", pd.Ad_Price);
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

        public bool CheckBnum(int? B_Num)
        {
            int i;
            PaymentDetails pd = new PaymentDetails();
            SqlCommand cmd = new SqlCommand("Bill_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "biCheck"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@binum", B_Num);
            i= cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
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