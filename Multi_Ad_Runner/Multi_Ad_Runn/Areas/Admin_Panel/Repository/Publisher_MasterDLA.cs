using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Repository
{
    public class Publisher_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        //private static List<SelectListItem> BindCategory()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    string constr = ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        string query = " SELECT * FROM Category_Master";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    items.Add(new SelectListItem
        //                    {
        //                        Text = sdr["C_Name"].ToString(),
        //                        Value = sdr["C_Id"].ToString()
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }

        //    return items;
        //}

        public bool InsertPublisher(Publisher_Master pm)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", pm.Pu_Id);
            cmd.Parameters.AddWithValue("@cid", pm.C_Id);
            cmd.Parameters.AddWithValue("@puname", pm.Pu_Name);
            cmd.Parameters.AddWithValue("@puemail", pm.Pu_Email);
            cmd.Parameters.AddWithValue("@pucontact", pm.Pu_Contact);
            cmd.Parameters.AddWithValue("@pupassword", pm.Pu_Password);
            cmd.Parameters.AddWithValue("@puwesite", pm.Pu_WebSite);
            cmd.Parameters.AddWithValue("@pustatus", "Active");
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

        public List<Publisher_Master> GetAllPublisher()
        {
            List<Publisher_Master> lpm = new List<Publisher_Master>();
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "pudDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lpm.Add(new Publisher_Master
                {
                    Pu_Id = Convert.ToInt32(dr["Pu_Id"]),
                    C_Id = Convert.ToInt32(dr["C_Id"]),
                    Pu_Name = Convert.ToString(dr["Pu_Name"]),
                    Pu_Email = Convert.ToString(dr["Pu_Email"]),
                    Pu_Contact = Convert.ToString(dr["Pu_Contact"]),
                    Pu_Password = Convert.ToString(dr["Pu_Password"]),
                    Pu_WebSite = Convert.ToString(dr["Pu_WebSite"]),
                    Pu_Status = Convert.ToString(dr["Pu_Status"]),
                    Pu_Date = Convert.ToDateTime(dr["Pu_Date"])
                });
            }
            return lpm;
        }

        public Publisher_Master GetSinglePublisher(int puid)
        {
            Publisher_Master pm = new Publisher_Master();
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puDisplayS"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", puid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                pm.Pu_Id = Convert.ToInt32(sdr["Pu_Id"]);
                pm.C_Id = Convert.ToInt32(sdr["C_Id"]);
                pm.Pu_Name = sdr["Pu_Name"].ToString();
                pm.Pu_Email = sdr["Pu_Email"].ToString();
                pm.Pu_Contact = sdr["Pu_Contact"].ToString();
                pm.Pu_Password = sdr["Pu_Password"].ToString();
                pm.Pu_WebSite = sdr["Pu_WebSite"].ToString();
                pm.Pu_Status = sdr["Pu_Status"].ToString();
                pm.Pu_Date = Convert.ToDateTime(sdr["Pu_Date"]);


                return pm;
            }
            else
            {
                return null;
            }
        }

        public bool EditPublisher(Publisher_Master pm)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puUpdate"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", pm.Pu_Id);
            cmd.Parameters.AddWithValue("@cid", pm.C_Id);
            cmd.Parameters.AddWithValue("@puname", pm.Pu_Name);
            cmd.Parameters.AddWithValue("@pucontact", pm.Pu_Contact);
            cmd.Parameters.AddWithValue("@puwesite", pm.Pu_WebSite);
            cmd.Parameters.AddWithValue("@pustatus", pm.Pu_Status);
            
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

        public bool DeletePublisherDetail(int puid)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Publisher_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "puDelete"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@puid", puid);
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