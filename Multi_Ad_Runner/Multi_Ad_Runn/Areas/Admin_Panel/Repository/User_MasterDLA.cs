using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Repository
{
    public class User_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public bool InsertUser(User_Master um)
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

        public List<User_Master> GetAllUser()
        {
            List<User_Master> lum = new List<User_Master>();
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "udDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lum.Add(new User_Master
                {
                    U_Id = Convert.ToInt32(dr["U_Id"]),
                    U_Name = Convert.ToString(dr["U_Name"]),
                    U_Email = Convert.ToString(dr["U_Email"]),
                    U_Contact = Convert.ToString(dr["U_Contact"]),
                    U_Password = Convert.ToString(dr["U_Password"]),
                    U_Status = Convert.ToString(dr["U_Status"]),
                    U_Date = Convert.ToDateTime(dr["U_Date"])
                });
            }
            return lum;
        }

        public User_Master GetSingleUser(int uid)
        {
            User_Master um = new User_Master();
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uDisplayS"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid",uid );
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                um.U_Id = Convert.ToInt32(sdr["U_Id"]);
                um.U_Name = sdr["U_Name"].ToString();
                um.U_Email = sdr["U_Email"].ToString();
                um.U_Contact = sdr["U_Contact"].ToString();
                um.U_Password = sdr["U_Password"].ToString();
                um.U_Status = sdr["U_Status"].ToString();
                um.U_Date = Convert.ToDateTime(sdr["U_Date"]);


                return um;
            }
            else
            {
                return null;
            }
        }

        public bool EditUser(User_Master um)
        {
            int i;
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uUpdate"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", um.U_Id);
            cmd.Parameters.AddWithValue("@uname", um.U_Name);
            cmd.Parameters.AddWithValue("@ucontact", um.U_Contact);
            cmd.Parameters.AddWithValue("@ustatus", um.U_Status);
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

        public bool DeleteUserDetail(int uid)
        {
            int i;
            SqlCommand cmd = new SqlCommand("User_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "uDelete"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", uid);
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

        public List<Feedback_Master> GetAllFeedback()
        {
            List<Feedback_Master> lum = new List<Feedback_Master>();
            SqlCommand cmd = new SqlCommand("Feedback_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "fDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lum.Add(new Feedback_Master
                {
                    F_Id = Convert.ToInt32(dr["F_Id"]),
                    F_Name = Convert.ToString(dr["F_Name"]),
                    F_Email = Convert.ToString(dr["F_Email"]),
                    F_Title = Convert.ToString(dr["F_Title"]),
                    F_Message = Convert.ToString(dr["F_Message"]),
                    F_Status = Convert.ToString(dr["F_Status"]),
                    F_Date = Convert.ToDateTime(dr["F_Date"])
                });
            }
            return lum;
        }
    }
}