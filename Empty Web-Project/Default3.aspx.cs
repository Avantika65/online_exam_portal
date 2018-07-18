using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        conn.Open();
        string checkUser = "select f_id from faculty_detail where email='" + id + "'";
        SqlCommand com = new SqlCommand(checkUser, conn);
        String temp =com.ExecuteScalar().ToString();
        /*SqlCommand com1 = new SqlCommand("select f- from UserDetails where EmailId='" + id + "'", conn);
        SqlCommand com2 = new SqlCommand("select LastName from UserDetails where EmailId='" + id + "'", conn);
        String FirstN=com1.ExecuteScalar().ToString();
        String LastN=com2.ExecuteScalar().ToString();*/
        conn.Close();
        VoteUpOff.Attributes["src"] = ResolveUrl("https://erp.psit.in/assets/img/Simages/"+temp+".jpg");
        //Label1.Text = "Name : "+FirstN+" "+LastN;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }
}