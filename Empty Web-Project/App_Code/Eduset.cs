using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Reflection;
using System.Security.Policy;
using System.Net;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class Eduset
{
    static Eduset() { }
    public static string Version
    {
        get { return "1.1"; }
    }
    private static string _LastVersion = null;
    public static string LastVersion
    {
        get
        {
            if (_LastVersion == null)
            {
                try
                {
                    using (WebClient Wc = new WebClient())
                    {
                        Wc.QueryString.Add("p", "checkversion");
                        Wc.QueryString.Add("code", "Eduset");
                        Wc.QueryString.Add("email", Eduset.Settings["smtp_email"].ToString());
                        Wc.QueryString.Add("host", HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath);
                        _LastVersion = Wc.DownloadString("http://www.blogsa.net/Services/VersionControl.ashx");
                    }
                }
                catch (System.Exception ex)
                {
                    _LastVersion = ex.Message;
                    _LastVersion = Language.Admin["VersionError"];
                }
            }
            return _LastVersion;
        }
    }


    public static BlogsaUser ActiveUser
    {
        get { return (BlogsaUser)HttpContext.Current.Session["ActiveUser"]; }
        set { HttpContext.Current.Session["ActiveUser"] = value; }
    }

    public static string Url
    {
        get
        {
            if (!Settings.Contains("blog_url"))
                ReadSettings();
            return Settings["blog_url"].ToString();
        }
    }
    public static string ThemeUrl
    {
        get { return Url + "Themes/" + ActiveTheme + "/"; }
    }

    private static Hashtable _Settings = null;
    public static Hashtable Settings
    {
        get
        {
            if (_Settings == null)
                ReadSettings();
            return _Settings;
        }
        set
        {
            _Settings = value;
        }
    }
    private static string _ActiveTheme = null;
    public static string ActiveTheme
    {
        get { return _ActiveTheme; }
        set { _ActiveTheme = value; }
    }

    public static string UrlExtension
    {
        get
        {
            Regex rx = new Regex(".([A-Z0-9a-z-]+)$");
            string strExpression = Eduset.Settings.ContainsKey("permaexpression") ? Eduset.Settings["permaexpression"].ToString() : string.Empty;
            Match matchExt = rx.Match(strExpression);
            if (rx.Match(strExpression).Success)
                return matchExt.Value;
            else
                return string.Empty;
        }
    }

    public static bool SetupControl
    {
        get
        {
            if (ConfigurationManager.AppSettings["Setup"] == "Ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // Settings Function
    public static void ReadSettings()
    {
        //try
        //{
        //    Eduset.Settings = new Hashtable();
        //    Eduset.Settings.Clear();
        //    Hashtable HT = DBToys.Do.SimpleQuery("Settings", "", "", "*");
        //    if (HT["Error"] == null)
        //    {
        //        DataTable DT = HT["DataTable"] as DataTable;
        //        foreach (DataRow Item in DT.Rows)
        //            if (!Settings.ContainsKey(Item["Name"].ToString()))
        //                Settings.Add(Item["Name"].ToString(), Item["Value"].ToString());
        //        GetLanguages((string)Settings["language"]);
        //    }
        //}
        //catch { }
    }
    // Language Files Function.
    public static void GetLanguages(string LanguageCode)
    {
        Language.Get = Functions.GetLanguageDictionary("Languages/" + Settings["language"] + ".xml");
    }
    // Language Admin Function
    public static void GetAdminLanguage(string LanguageCode)
    {
        Language.Admin = Functions.GetLanguageDictionary("Languages/" + Settings["language"] + ".admin.xml");
    }
}
