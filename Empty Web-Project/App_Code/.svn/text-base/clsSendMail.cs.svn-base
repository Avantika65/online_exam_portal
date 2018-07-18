using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

/// <summary>
/// Summary description for clsSendMail
/// </summary>
public class clsSendMail
{
    private String SMTPServer = string.Empty;
    public clsSendMail()
    {
        SMTPServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();
    }

    public String getSMTPServerName()
    {
        return SMTPServer;
    }

    public bool SendMail(String strToUser, String strFromUser, String strSubject, String strMessage)
    {
        bool blnResult = true;
        MailMessage myMail = new MailMessage();
        SmtpClient objSMTP = new SmtpClient(SMTPServer);

        myMail.To.Add(strToUser);
        myMail.From = new MailAddress(strFromUser);
        myMail.Subject = strSubject;
        myMail.Body = strMessage;
        myMail.IsBodyHtml = true;

        try
        {
            //obClient.Send(myMail);
            objSMTP.Send(myMail);
            blnResult = true;
        }
        catch
        {
            blnResult = false;
        }

        return blnResult;
    }
}
