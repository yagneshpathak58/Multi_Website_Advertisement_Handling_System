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
    public class Category_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        //Category Insert
        public bool InsertCatogery(Category_Master cm)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Category_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "cInsert"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cm.C_Id);
            cmd.Parameters.AddWithValue("@cname", cm.C_Name);
            cmd.Parameters.AddWithValue("@cdes", cm.C_Des);
            cmd.Parameters.AddWithValue("@cstatus", "Active");
            cmd.Parameters.AddWithValue("@cdate", System.DateTime.Now);
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
        public List<Category_Master> GetAllCategory()
        {
            List<Category_Master> lcm = new List<Category_Master>();
            SqlCommand cmd = new SqlCommand("Category_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "cDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lcm.Add(new Category_Master
                {
                    C_Id = Convert.ToInt32(dr[0]),
                    C_Name = Convert.ToString(dr[1]),
                    C_Des = Convert.ToString(dr[2]),
                    C_Status = Convert.ToString(dr[3]),
                    C_Date = Convert.ToDateTime(dr[4]),
                });
            }
            return lcm;
        }
        public bool EditCategory(Category_Master cm)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Category_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "cUpdate"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cm.C_Id);
            cmd.Parameters.AddWithValue("@cname", cm.C_Name);
            cmd.Parameters.AddWithValue("@cdes", cm.C_Des);
            cmd.Parameters.AddWithValue("@cstatus", cm.C_Status);
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
        public bool DeleteCategory(int cid)
        {
            int i;
            SqlCommand cmd = new SqlCommand("Category_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "cDelete"));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
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