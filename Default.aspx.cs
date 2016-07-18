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
                DataSet ds = new DataSet();
                //將不同資料表存入ds
                ds = Fillds("SELECT * FROM Products",ds);
                ds = Fillds("SELECT * FROM Orders", ds);
                //由ds讀取不同資料表
                DataTable dtP, dtO;
                dtP = ds.Tables["Products"];//dtP = ds.Tables[0];
                dtO = ds.Tables["Orders"];
                //GridView1.DataSource = dtP;
                //GridView1.DataBind(); //呈現資料
                ShowDrop(dtP,DropDownList1);
            

        }
        private DataSet Fillds(String s,DataSet ds) {
            using (SqlConnection cn = new SqlConnection()) {
                //"Server="+@"localhost\sqlexpress;"+" database=Northwind;uid=sa;pwd=;";
                String cnstr = "Server=localhost\\sqlExpress;database=Northwind;uid=sa;pwd=;";
                cn.ConnectionString = cnstr;
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    TextBox1.Text = "已連接" + cn.ConnectionString + Environment.NewLine;
                }
                //DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(s,cn);
                da.Fill(ds);
                return ds;
            }
        }
        
        private void ShowDrop(DataTable dt, DropDownList dl) {
            dl.SelectedIndexChanged += DropListIndexChanged;
            foreach (DataColumn dc in dt.Columns) {
                dl.DataSource = dt;
                dl.DataValueField = "ProductID"; //dt.columns[0].ToString();
                dl.DataTextField = "ProductName";
            }
            dl.DataBind();
        }
        private void DropListIndexChanged(Object sender, EventArgs e) {
            using (SqlConnection cn = new SqlConnection()) {
                String cnstr = "Server=localhost\\Express;database=Northwind;uid=sa;pwd=;";
                cn.ConnectionString = cnstr;
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT UnitPrice FROM Products WHERE ProductsID="+DropDownList1.SelectedIndex);
                SqlDataReader dr = cmd.ExecuteReader();
                TextBox2.Text = dr[0].ToString();
            }

                
        }
    }
}