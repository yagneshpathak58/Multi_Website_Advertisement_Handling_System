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
    public class Ad_Request_MasterDLA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public bool AdRequest(Ad_Request_Master arm)
        {
            
            int i;
            SqlCommand cmd = new SqlCommand("Ad_Request_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "arInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@arid", arm.A_R_Id);
            cmd.Parameters.AddWithValue("@uid",arm.U_Id );
            cmd.Parameters.AddWithValue("@cid", arm.C_Id);
            cmd.Parameters.AddWithValue("@arduration", arm.A_R_Duration);
            cmd.Parameters.AddWithValue("@arexdate", arm.A_R_Expire_Date);
            cmd.Parameters.AddWithValue("@arpage", arm.A_R_Page);
            cmd.Parameters.AddWithValue("@arposition", arm.A_R_Position);
            cmd.Parameters.AddWithValue("@artitle", arm.A_R_Title);
            cmd.Parameters.AddWithValue("@arimagename", arm.A_R_ImageName);
            cmd.Parameters.AddWithValue("@arimagepath", arm.A_R_ImagePath);
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

        public Ad_Request_Master GetjoinSingle(int arid)
        {
            
            Ad_Request_Master arm = new Ad_Request_Master();
            SqlCommand cmd = new SqlCommand("Ad_Request_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "joinDisplayS"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", arid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                arm.A_R_Id = Convert.ToInt32(sdr["A_R_Id"]);
                arm.U_Id = Convert.ToInt32(sdr["A_R_Id"]);
                arm.C_Id = Convert.ToInt32(sdr["C_Id"]);
                arm.A_R_Duration = sdr["A_R_Duration"].ToString();
                arm.A_R_Expire_Date = Convert.ToDateTime(sdr["A_R_Expire_Date"]);
                arm.A_R_Page = sdr["A_R_Page"].ToString();
                arm.A_R_Position = sdr["A_R_Position"].ToString();
                arm.A_R_Title = sdr["A_R_Title"].ToString();
                arm.A_R_ImageName = sdr["A_R_ImageName"].ToString();
                arm.A_R_ImagePath = sdr["A_R_ImagePath"].ToString();
                arm.A_R_Status = sdr["A_R_Status"].ToString();
                arm.A_R_Date = Convert.ToDateTime(sdr["A_R_Date"]);
                arm.U_Name = sdr["U_Name"].ToString();
                arm.U_Email = sdr["U_Email"].ToString();
                arm.C_Name = sdr["C_Name"].ToString();
                arm.Ad_Page = sdr["Ad_Page"].ToString();
                arm.Ad_Position = sdr["Ad_Position"].ToString();
                arm.Ad_Price = sdr["Ad_Price"].ToString();

                
                    

                return arm;
                
            }
            else
            {
                return null;
            }
        }
    }
}