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
    public class Ad_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public bool InsertAd(Ad_Master am)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Ad_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adid", am.Ad_Id);
            cmd.Parameters.AddWithValue("@adposition", am.Ad_Position);
            cmd.Parameters.AddWithValue("@adpage", am.Ad_Page);
            cmd.Parameters.AddWithValue("@addes", am.Ad_Des);
            cmd.Parameters.AddWithValue("@adprice", am.Ad_Price);
            cmd.Parameters.AddWithValue("@adstatus", "Active");
            cmd.Parameters.AddWithValue("@addate", System.DateTime.Now);
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

        public List<Ad_Master> GetAllAd()
        {
            List<Ad_Master> lam = new List<Ad_Master>();
            SqlCommand cmd = new SqlCommand("Ad_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lam.Add(new Ad_Master
                {
                    Ad_Id = Convert.ToInt32(dr["Ad_Id"]),
                    Ad_Position = Convert.ToString(dr["Ad_Position"]),
                    Ad_Page = Convert.ToString(dr["Ad_Page"]),
                    Ad_Des = Convert.ToString(dr["Ad_Des"]),
                    Ad_Price = Convert.ToString(dr["Ad_Price"]),
                    Ad_Status = Convert.ToString(dr["Ad_Status"]),
                    Ad_Date = Convert.ToDateTime(dr["Ad_Date"])
                });
            }
            return lam;
        }

        public Ad_Master GetSingleAd(int adid)
        {
            Ad_Master am = new Ad_Master();
            SqlCommand cmd = new SqlCommand("Ad_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adDisplayS"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adid", adid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                am.Ad_Id = Convert.ToInt32(sdr["Ad_Id"]);
                am.Ad_Position = sdr["Ad_Position"].ToString();
                am.Ad_Page = sdr["Ad_Page"].ToString();
                am.Ad_Des = sdr["Ad_Des"].ToString();
                am.Ad_Price = sdr["Ad_Price"].ToString();
                am.Ad_Status = sdr["Ad_Status"].ToString();
                am.Ad_Date = Convert.ToDateTime(sdr["Ad_Date"]);


                return am;
            }
            else
            {
                return null;
            }
        }

        public bool EditAd(Ad_Master am)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Ad_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adUpdate"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adid", am.Ad_Id);
            cmd.Parameters.AddWithValue("@adposition", am.Ad_Position);
            cmd.Parameters.AddWithValue("@adpage", am.Ad_Page);
            cmd.Parameters.AddWithValue("@addes", am.Ad_Des);
            cmd.Parameters.AddWithValue("@adprice", am.Ad_Price);
            cmd.Parameters.AddWithValue("@adstatus", am.Ad_Status);

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


        public bool DeleteAdDetail(int adid)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Ad_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "adDelete"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adid", adid);
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