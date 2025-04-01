using Multi_Ad_Runn.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Repository
{
    public class Publisher_MasterDLA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);
        public bool PublisherRequest(Publisher_Master pm)
        {
            Random random = new Random();
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", pm.Pu_Id);
            cmd.Parameters.AddWithValue("@cid", pm.C_Id);
            cmd.Parameters.AddWithValue("@puname", pm.Pu_Name);
            cmd.Parameters.AddWithValue("@puemail", pm.Pu_Email);
            cmd.Parameters.AddWithValue("@pucontact", pm.Pu_Contact);
            cmd.Parameters.AddWithValue("@pupassword", random.Next());
            cmd.Parameters.AddWithValue("@puwesite", pm.Pu_WebSite);
            cmd.Parameters.AddWithValue("@pustatus", "Requested");
            cmd.Parameters.AddWithValue("@pudate", System.DateTime.Now);
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

        public Publisher_Master PublisherLogin(string Log_Email,string Log_Password)
        {
            Publisher_Master pm = new Publisher_Master();
            //int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puGetDetail"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@puemail", Log_Email);
            cmd.Parameters.AddWithValue("@pupassword",Log_Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                pm.Pu_Email = sdr["Pu_Email"].ToString();
                pm.Pu_Name = sdr["Pu_Name"].ToString();
                pm.Pu_Id = Convert.ToInt32(sdr["Pu_Id"]);
                return pm;
            }
            else
            {
                return null;
            }
            //i = Convert.ToInt32(cmd.ExecuteScalar());
            //if (i >= 1)
            //{

            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool ChekOldPass(string Pu_Password, int Pu_Id)
        {
            int i;
            Publisher_Master pm = new Publisher_Master();
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "pucheckPassword"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pupassword", Pu_Password);
            cmd.Parameters.AddWithValue("@puid", Pu_Id);
            i = Convert.ToInt32(cmd.ExecuteScalar());
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

        public bool ChangePassword(Change_Password cp)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puChangePassword"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", cp.Pu_Id);

            cmd.Parameters.AddWithValue("@pupassword", cp.New_Password);

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

            //sortedlist sli = new sortedlist();
            //sli.add("@mode", "stinsert");
            //sli.add("@sname")
        }

        public Publisher_Master GetPublisherData(int Pu_Id)
        {

            Publisher_Master pm = new Publisher_Master();
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puSDisplay"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", Pu_Id);

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

                pm.Pu_Id = Convert.ToInt32(sdr["Pu_Id"]);
                pm.Pu_Name = sdr["Pu_Name"].ToString();
                pm.Pu_Email = sdr["Pu_Email"].ToString();
                pm.Pu_WebSite = sdr["Pu_WebSite"].ToString();
                pm.Pu_Contact = sdr["Pu_Contact"].ToString();

                //pd.A_R_Title = sdr["A_R_Title"].ToString();
                //pd.A_R_Page = sdr["A_R_Page"].ToString();
                //pd.A_R_Position = sdr["A_R_Position"].ToString();
                //pd.A_R_Expire_Date = Convert.ToDateTime(sdr["A_R_Expire_Date"]);



                return pm;
            }
            else
            {
                return null;
            }
        }

        public bool EditPublisherProfile(Publisher_Master pm)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puUpdateProfile"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", pm.Pu_Id);
            cmd.Parameters.AddWithValue("@puname", pm.Pu_Name);
            cmd.Parameters.AddWithValue("@pucontact", pm.Pu_Contact);
            cmd.Parameters.AddWithValue("@puwesite", pm.Pu_WebSite);
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

            //sortedlist sli = new sortedlist();
            //sli.add("@mode", "stinsert");
            //sli.add("@sname")
        }
    }
}