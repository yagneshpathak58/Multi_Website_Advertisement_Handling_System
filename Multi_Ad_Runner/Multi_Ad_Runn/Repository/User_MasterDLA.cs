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
    public class User_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public bool RegistrationUser(User_Master um)
        {
            int i;
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", um.U_Id);
            cmd.Parameters.AddWithValue("@uname", um.U_Name);
            cmd.Parameters.AddWithValue("@uemail", um.U_Email);
            cmd.Parameters.AddWithValue("@ucontact", um.U_Contact);
            cmd.Parameters.AddWithValue("@upassword", um.U_Password);
            cmd.Parameters.AddWithValue("@ustatus", "Active");
            cmd.Parameters.AddWithValue("@udate", System.DateTime.Now);
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

        public User_Master UserLogin(string Log_Email, string Log_Password)
        {
            //int i;
            User_Master um = new User_Master();
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uGetDetail"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@uemail", Log_Email);
            cmd.Parameters.AddWithValue("@upassword", Log_Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                um.U_Email = sdr["U_Email"].ToString();
                um.U_Name = sdr["U_Name"].ToString();
                um.U_Id = Convert.ToInt32(sdr["U_Id"]);
                return um;
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

        public bool ChekOldPass(string U_Password, int U_Id)
        {
            int i;
            User_Master um = new User_Master();
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "ucheckPassword"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@upassword", U_Password);
            cmd.Parameters.AddWithValue("@uid", U_Id);
            i =Convert.ToInt32( cmd.ExecuteScalar());
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
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uChangePassword"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", cp.U_Id);
            
            cmd.Parameters.AddWithValue("@upassword", cp.New_Password);
            
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

        public User_Master GetUserData( int U_Id)
        {

            User_Master um = new User_Master();
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uDisplayS"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", U_Id);
           
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

                um.U_Id = Convert.ToInt32(sdr["U_Id"]);
                um.U_Name = sdr["U_Name"].ToString();
                um.U_Email = sdr["U_Email"].ToString();

                um.U_Contact = sdr["U_Contact"].ToString();
               
                //pd.A_R_Title = sdr["A_R_Title"].ToString();
                //pd.A_R_Page = sdr["A_R_Page"].ToString();
                //pd.A_R_Position = sdr["A_R_Position"].ToString();
                //pd.A_R_Expire_Date = Convert.ToDateTime(sdr["A_R_Expire_Date"]);



                return um;
            }
            else
            {
                return null;
            }
        }

        public bool EditUserProfile(User_Master um)
        {
            int i;
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uUpdateProfile"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", um.U_Id);
            cmd.Parameters.AddWithValue("@uname", um.U_Name);
            cmd.Parameters.AddWithValue("@ucontact", um.U_Contact);
            
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

        public bool AddFeedback(Feedback_Master fm)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Feedback_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "fInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fid", fm.F_Id);
            cmd.Parameters.AddWithValue("@fname", fm.F_Name);
            cmd.Parameters.AddWithValue("@femail", fm.F_Email);
            cmd.Parameters.AddWithValue("@ftitle", fm.F_Title);
            cmd.Parameters.AddWithValue("@fmessage", fm.F_Message);
            cmd.Parameters.AddWithValue("@fstatus", "Active");
            cmd.Parameters.AddWithValue("@fdate", System.DateTime.Now);
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