using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //sqlconnection
using System.Data; //dataset

namespace P_NW
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                //"Server="+@"localhost\sqlexpress;"+" database=Northwind;uid=sa;pwd=;";
                String cnstr = "Server=localhost\\sqlexpress; database=Northwind; uid=sa;pwd=;";
                cn.ConnectionString = cnstr;
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open) {
                    TextBox1.Text = "已連接" + cn.ConnectionString + Environment.NewLine ;
                }
                DataSet ds = new DataSet();
                //將不同資料表存入ds
                SqlDataAdapter daProducts = new SqlDataAdapter("SELECT * FROM Products",cn);
                daProducts.Fill(ds,"Products");
                SqlDataAdapter daOrders = new SqlDataAdapter("SELECT * FROM Orders", cn);
                daOrders.Fill(ds,"Orders");
                //由ds讀取不同資料表
                DataTable dtP, dtO;
                dtP = ds.Tables["Products"];//dtP = ds.Tables[0];
                dtO = ds.Tables["Orders"];
                GridView1.DataSource = dtP;
                GridView1.DataBind(); //呈現資料
            }
        }
    }
}