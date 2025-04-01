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
    public class Admin_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public Admin_Master AdminLogin(Admin_Master am)
        {
            //int i;
            SqlCommand cmd = new SqlCommand("Admin_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode","adGetDetail"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@auname", am.A_U_Name);
            cmd.Parameters.AddWithValue("@apassword", am.A_Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                am.A_Email = sdr["A_Email"].ToString();
                am.A_Name = sdr["A_Name"].ToString();
                am.A_Id = Convert.ToInt32(sdr["A_Id"]);
                return am;
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
        public bool ChekOldPass(string A_Password, int A_ID)
        {
            int i;
            Admin_Master um = new Admin_Master();
            SqlCommand cmd = new SqlCommand("Admin_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adcheckPassword"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@apassword", A_Password);
            cmd.Parameters.AddWithValue("@aid", A_ID);
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
            SqlCommand cmd = new SqlCommand("Admin_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adChangePassword"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@aid", cp.A_ID);

            cmd.Parameters.AddWithValue("@apassword", cp.New_Password);

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

        public int CountUser()
        {
            int i;
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adUserCount"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
           return i;    
            
        }

        public int CountFeedback()
        {
            int i;
            SqlCommand cmd = new SqlCommand("Feedback_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adFeedbackCount"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;

        }

        public int CountAdRequest()
        {
            int i;
            SqlCommand cmd = new SqlCommand("Ad_Request_MasterSp", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adAdCount"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;

        }

        public int CountPublisher()
        {
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adPublisherCount"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;

        }
    }
}