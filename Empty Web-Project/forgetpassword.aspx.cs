using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forgetpassword : System.Web.UI.Page
{
    DbFunctions ojfun = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsbmt_Click(object sender, EventArgs e)
    {
        string mail = txtmail.Text;
        String sql = "select email_id from student_detail where email_id='" + mail + "'";
        DataTable dt1 = new DataTable();
        dt1 = ojfun.FillDataTable(sql);
        if (dt1.Rows.Count == 0)
        {
            ojfun.MsgBox("E-Mail ID is not registered..", this);
        }
        else
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress("avantikanmaurya65@gmail.com");
                email.To.Add(mail);
                email.Subject = "Forgot Password";
                email.Body = "New Password is:";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("avantikanmaurya65", "$1ngleme");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(email);
                ojfun.MsgBox("Mail Sent", this);
            }
            catch (Exception ex)
            {
              
            }
        }

    }
}