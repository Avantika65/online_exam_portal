using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

public partial class sreport : System.Web.UI.Page
{
    SqlCommand com;
    SqlDataAdapter sqlda;
   SqlConnection con;
   static DataSet ds;
   static DataTable dt;
   static int r1;
   string str;
   static int r2;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        string mystring = ConfigurationManager.ConnectionStrings["FeesManagementConn"].ToString();
        con =new SqlConnection(mystring);
        con.Open();
        str = "select* from student_detail";
        com = new SqlCommand(str, con);
        sqlda= new SqlDataAdapter(com);
        ds = new DataSet();
        sqlda.Fill(ds, "student_detail");
        dt = ds.Tables["student_detail"]; 
        int rows = ds.Tables[0].Rows.Count;

        TextBox3.Text=(rows.ToString());

        

 

        TextBox1.Text = dt.Rows[0].ItemArray[2].ToString();
        TextBox2.Text = dt.Rows[0].ItemArray[12].ToString();
        TextBox4.Text = dt.Rows[0].ItemArray[3].ToString();
        con.Close();
  
    }
   
 
    
}