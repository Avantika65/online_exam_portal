using System.Web.Mail;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mail;

/// <summary>
/// Summary description for sendingemail
/// </summary>
public class sendingemail
{
    public sendingemail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public static string SendMessege(string MessageBody, string MailTo, string MailFrom, string mailcc, string MailSubject, string mailbcc, string mailattach)
    {
        string result;
        MailMessage mail = new MailMessage();


        mail.To = MailTo;
        mail.From = MailFrom;
        mail.Cc = mailcc;
        mail.Bcc = mailbcc;

        mail.Subject = MailSubject;
        mail.Body = MessageBody;
       

        mail.BodyFormat = MailFormat.Text;
        if (mailattach != "")
        {
            mail.Attachments.Add(new MailAttachment(mailattach));
        }

        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "ashishkumar@mktsoftwares.com");
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "9450328332");
        SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["Message.SmtpServer"];


        try
        {

            SmtpMail.Send(mail);
            return result = "Mail Sent Successfully.";

        }
        catch (Exception ex)
        {
            return result = ex.Message.ToString();

        }

    }


}
