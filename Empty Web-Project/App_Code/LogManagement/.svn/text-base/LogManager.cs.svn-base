using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EducationLogDBManager;
using EducationLog;

/// <summary>
/// Summary description for LogManager
/// </summary>
public class LogManager
{
    #region Methods
    /// <summary>
    /// Deletes a log item
    /// </summary>
    /// <param name="LogID">Log item identifier</param>
    public static void DeleteLog(int LogID)
    {
        LogDBManager.DeleteLog(LogID);
    }

    /// <summary>
    /// Clears a log
    /// </summary>
    public static void ClearLog()
    {
        LogDBManager.ClearLog();
    }

    /// <summary>
    /// Gets all log items
    /// </summary>
    /// <returns>Log item collection</returns>
    public static LogCollection GetAllLogs()
    {
        return LogDBManager.GetAllLogs();
    }

    /// <summary>
    /// Gets a log item
    /// </summary>
    /// <param name="LogID">Log item identifier</param>
    /// <returns>Log item</returns>
    public static Log GetByLogID(int LogID)
    {
        return LogDBManager.GetByLogID(LogID);
    }

    /// <summary>
    /// Inserts a log item
    /// </summary>
    /// <param name="LogType">Log item type</param>
    /// <param name="Message">The short message</param>
    /// <param name="Exception">The full exception</param>
    /// <returns>A log item</returns>
    public static Log InsertLog(LogTypeEnum LogType, string Message,string Exception)
    {
        int CustomerID = 0;
        //if (NopContext.Current.User != null)
        //    CustomerID = NopContext.Current.User.CustomerID;
        string IPAddress = HttpContext.Current.Request.UserHostAddress;
        string PageURL =  GetThisPageName();

        return InsertLog(LogType, 11, Message,Exception, IPAddress, CustomerID, PageURL);
    }
    public static string GetThisPageName()
    {
        string path =  ServerVariables("SCRIPT_NAME");
        if (path == null)
            path = string.Empty;
        return path;
    }
    public static string ServerVariables(string Name)
    {
        string tmpS = String.Empty;
        try
        {
            if (HttpContext.Current.Request.ServerVariables[Name] != null)
            {

                tmpS = HttpContext.Current.Request.ServerVariables[Name].ToString();

            }
        }
        catch
        {
            tmpS = String.Empty;
        }
        return tmpS;
    }
    /// <summary>
    /// Inserts a log item
    /// </summary>
    /// <param name="LogType">Log item type</param>
    /// <param name="Severity">The severity</param>
    /// <param name="Message">The short message</param>
    /// <param name="Exception">The full exception</param>
    /// <param name="IPAddress">The IP address</param>
    /// <param name="CustomerID">The customer identifier</param>
    /// <param name="PageURL">The page URL</param>
    /// <returns>Log item</returns>
    public static Log InsertLog(LogTypeEnum LogType, int Severity, string Message, string Exception, string IPAddress, int CustomerID, string PageURL)
    {
        if (IPAddress == null)
            IPAddress = string.Empty;
        return LogDBManager.InsertLog((int)LogType, Severity, Message, Exception, IPAddress, CustomerID, PageURL, DateTime.Now);
    }
    #endregion
}
