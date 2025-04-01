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
    public class Order_MasterDLA
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString);

        public List<PaymentDetail> GetAllOrder()
        {
            List<PaymentDetail> lcm = new List<PaymentDetail>();
            SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "orDisplay"));
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lcm.Add(new PaymentDetail
                {
                    Or_Id = Convert.ToInt32(dr["Or_Id"]),
                    B_Num = Convert.ToInt32(dr["B_Num"]),
                    U_Id = Convert.ToInt32(dr["U_Id"]),
                    C_Id = Convert.ToInt32(dr["C_Id"]),
                    A_R_Duration = Convert.ToString(dr["A_R_Duration"]),
                    A_R_Expire_Date = Convert.ToDateTime(dr["A_R_Expire_Date"]),
                    A_R_Page = Convert.ToString(dr["A_R_Page"]),
                    A_R_Position = Convert.ToString(dr["A_R_Position"]),
                    A_R_Title = Convert.ToString(dr["A_R_Title"]),
                    A_R_ImageName = Convert.ToString(dr["A_R_ImageName"]),
                    A_R_ImagePath = Convert.ToString(dr["A_R_ImagePath"]),
                    Ad_Price = Convert.ToString(dr["Ad_Price"]),
                    Or_Status = Convert.ToString(dr["Or_Status"]),
                    Or_Date = Convert.ToDateTime(dr["Or_Date"]),
                });
            }
            return lcm;
        }

        public PaymentDetail GetOrderBillDetail(int Bnum, int cid ,int uid)
        {
            PaymentDetail pd = new PaymentDetail();
            SqlCommand cmd = new SqlCommand("Order_MasterSP", con);
            cmd.Parameters.Add(new SqlParameter("@mode", "AdminOrderBillDetail"));
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@binum", Bnum);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@uid", uid);
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
                pd.Bi_IGST = sdr["Bi_IGST"].ToString();
                pd.Bi_Total_Price = sdr["Bi_Total_Price"].ToString();
                pd.Bi_Date = Convert.ToDateTime(sdr["Bi_Date"]);
                pd.C_Name = sdr["C_Name"].ToString();
                pd.U_Name = sdr["U_Name"].ToString();
                pd.U_Email = sdr["U_Email"].ToString();
                pd.U_Contact = sdr["U_Contact"].ToString();

                return pd;
            }
            else
            {
                return null;
            }
        }
    }
}