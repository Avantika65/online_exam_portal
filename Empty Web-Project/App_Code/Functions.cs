using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public class Functions
{
    //public static string GetCategories(int PostID)
    //{
    //    Hashtable htCats = DBToys.Do.SimpleQuery("TermsTo INNER JOIN Terms ON TermsTo.TermID = Terms.TermID", "Where Terms.Type='category' AND ObjectID = " + PostID.ToString()
    //        , "", "Terms.*");
    //    if (htCats["Error"] == null || (htCats["Error"] as string) == "No Data")
    //    {
    //        string Cats = "";
    //        foreach (DataRow Row in (htCats["DataTable"] as DataTable).Rows)
    //            if (Convert.ToInt16(Blogsa.Settings["permalink"]) > 0)
    //                Cats += "<a href=\"" + GetPermalink("Category", Row["Code"].ToString(), Blogsa.UrlExtension) + "\">"
    //                    + Row["Name"].ToString() + "</a> ";
    //            else
    //                Cats += "<a href=\"?Category=" + Row["Code"] + "\">" + Row["Name"].ToString() + "</a> ";
    //        return Cats == "" ? Language.Get["NoCategory"] : Cats;
    //    }
    //    else
    //    {
    //        return htCats["Error"].ToString();
    //    }
    //}
    //public static string GetTags(int PostID)
    //{
    //    Hashtable htTags = DBToys.Do.SimpleQuery("TermsTo INNER JOIN Terms ON TermsTo.TermID = Terms.TermID", "Where Terms.Type='tag' AND ObjectID = " + PostID.ToString()
    //        , "", "Terms.*");
    //    if (htTags["Error"] == null || (htTags["Error"] as string) == "No Data")
    //    {
    //        string Tags = "";
    //        foreach (DataRow Row in (htTags["DataTable"] as DataTable).Rows)
    //            if (Convert.ToInt16(Blogsa.Settings["permalink"]) > 0)
    //                Tags += "<a href=\"" + GetPermalink("Tag", Row["Code"].ToString(), Blogsa.UrlExtension) + "\">" + Row["Name"].ToString() + "</a> ";
    //            else
    //                Tags += "<a href=\"Posts.aspx?Tag=" + Row["Code"].ToString() + "\">" + Row["Name"].ToString() + "</a> ";
    //        return Tags == "" ? Language.Get["NoTag"] : Tags;
    //    }
    //    else
    //    {
    //        return htTags["Error"].ToString();
    //    }
    //}
    //public static string GetTags(int PostID, bool withComma)
    //{
    //    Hashtable htTags = DBToys.Do.SimpleQuery("TermsTo INNER JOIN Terms ON TermsTo.TermID = Terms.TermID", "Where Terms.Type='tag' AND ObjectID = " + PostID.ToString()
    //        , "", "Terms.*");
    //    if (htTags["Error"] == null || (htTags["Error"] as string) == "No Data")
    //    {
    //        string Tags = "";
    //        int i = 0;
    //        foreach (DataRow Row in (htTags["DataTable"] as DataTable).Rows)
    //        {
    //            Tags += Row["Name"].ToString();
    //            if (i != (htTags["DataTable"] as DataTable).Rows.Count - 1)
    //                Tags += ",";
    //            i++;
    //        }
    //        return Tags;
    //    }
    //    else
    //    {
    //        return "";
    //    }
    //}
    //public static string GetCommentCount(int PostID)
    //{
    //    Hashtable htComments = DBToys.Do.SimpleQuery("Comments", "Where ABS(Approve) = 1 AND PostID = " + PostID.ToString()
    //        , "", "*");
    //    if (htComments["Error"] == null)
    //    {
    //        string returnValue = "";
    //        returnValue = htComments["DataCount"].ToString();
    //        return returnValue;
    //    }
    //    else
    //    {
    //        return "0";
    //    }
    //}
    //public static string GetUserName(int UserID)
    //{
    //    string Data = DBToys.Do.SimpleTextQuery("Users", "Where UserID=" + UserID, "", "Name");
    //    return Data;
    //}
    //public static string GetPostCount(int PostType)
    //{
    //    string Data = DBToys.Do.SimpleTextQuery("Posts", "Where State=1 AND Type=" + PostType, "", "Count(PostID) as [Count]");
    //    return Data;
    //}
    //public static string GetPostLinkedTitle(int PostID)
    //{
    //    Hashtable htPost = DBToys.Do.SimpleQuery("Posts", "Where PostID = " + PostID, "", "Top 1 *");
    //    if (htPost["Error"] == null || (htPost["Error"] as string) == "No Data")
    //    {
    //        string Posts = "";
    //        foreach (DataRow Row in (htPost["DataTable"] as DataTable).Rows)
    //        {
    //            Posts += "<a target=\"_blank\" href=\"../Posts.aspx?PostID=" + Row["PostID"] + "\">" + Row["Title"].ToString() + "</a> ";
    //        }
    //        return Posts;
    //    }
    //    else
    //    {
    //        return "";
    //    }
    //}
    //public static int GetPostCountForUserID(int UserID)
    //{
    //    Hashtable htComments = DBToys.Do.SimpleQuery("Posts", "Where State = 1 AND Type=0 AND UserID = " + UserID.ToString()
    //, "", "*");
    //    if (htComments["Error"] == null)
    //    {
    //        int returnValue = 0;
    //        returnValue = (int)htComments["DataCount"];
    //        return returnValue;
    //    }
    //    else
    //    {
    //        return 0;
    //    }
    //}
    //public static string GetCommentCount(string Approve)
    //{
    //    if (Approve != "")
    //    {
    //        Approve = "Where Approve = " + Approve;
    //    }
    //    string Data = DBToys.Do.SimpleTextQuery("Comments", Approve, "", "Count(CommentID) as [Count]");
    //    return Data;
    //}
    //public static string GetCommentCount(string Approve, int UserID)
    //{
    //    Approve = "Where Approve = Abs(" + Approve + ") AND UserID=" + UserID;
    //    string Data = DBToys.Do.SimpleTextQuery("Comments", Approve, "", "Count(CommentID) as [Count]");
    //    return Data;
    //}
    //public static string GetReadCount(int PostID)
    //{
    //    string Where = "";
    //    if (PostID != 0)
    //    {
    //        Where = "Where PostID = " + PostID;
    //    }
    //    string Data = DBToys.Do.SimpleTextQuery("Posts", Where, "", "SUM(ReadCount) as ReadCount");
    //    Data = Data == "" ? "0" : Data;
    //    return Data;
    //}
    public static string GetGravatar(string EMail)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        UTF8Encoding encoder = new UTF8Encoding();
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

        byte[] hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(EMail));

        StringBuilder sb = new StringBuilder(hashedBytes.Length * 2);
        for (int i = 0; i < hashedBytes.Length; i++)
        {
            sb.Append(hashedBytes[i].ToString("X2"));
        }
        string imageUrl = "http://www.gravatar.com/avatar.php?";
        short Size = 96;
        imageUrl += "gravatar_id=" + sb.ToString().ToLower();
        imageUrl += "&rating=G";
        imageUrl += "&size=" + Size.ToString();
        imageUrl += "&default=identicon";
        return imageUrl;
    }
//    public static void GetWidgets(Page Pg)
//    {
//        try
//        {
//            //Widget Preview
//            if (HttpContext.Current.Request["widget"] != null)
//            {
//                using (PlaceHolder Ph = Pg.Master.FindControl("Default") as PlaceHolder)
//                {
//                    try
//                    {
//                        Ph.Controls.Add(Pg.LoadControl("~/Widgets/" + CreateCode(HttpContext.Current.Request["widget"]) + "/" + "Widget.ascx"));
//                    }
//                    catch (System.Exception ex)
//                    {
//                        LiteralControl lC = new LiteralControl();
//                        lC.Text = ex.Message;
//                        Ph.Controls.Add(lC);
//                    }


//                }
//            }
//        }
//        catch { }

//        Hashtable htAddons = DBToys.Do.SimpleQuery("Widgets", "Where Abs(Visible) = 1"
//, "Order By Sort", "*");
//        if (htAddons["Error"] == null)
//        {
//            foreach (DataRow Row in (htAddons["DataTable"] as DataTable).Rows)
//            {
//                try
//                {
//                    PlaceHolder Ph = Pg.Master.FindControl(Row["PlaceHolder"].ToString()) as PlaceHolder;
//                    try
//                    {
//                        if (Row["Type"].ToString() == "0")
//                        {
//                            if (Ph != null)
//                            {
//                                Ph.Controls.Add(Pg.LoadControl("~/Widgets/" + Row["FolderName"].ToString() + "/" + "Widget.ascx"));
//                            }
//                            else
//                            {
//                                Ph = Pg.Master.FindControl("Default") as PlaceHolder;
//                                Ph.Controls.Add(Pg.LoadControl("~/Widgets/" + Row["FolderName"].ToString() + "/" + "Widget.ascx"));
//                            }
//                        }
//                        else
//                        {
//                            LiteralControl lC = new LiteralControl();
//                            lC.Text += "<div class=\"widget\"><div class=\"title\"><span>"
//                                + Row["Title"].ToString() + "</span></div>";
//                            lC.Text += "<div class=\"content\"><span>" + Row["Description"].ToString() + "</span></div></div>";
//                            Ph.Controls.Add(lC);
//                        }
//                    }
//                    catch (System.Exception ex)
//                    {
//                        LiteralControl lC = new LiteralControl();
//                        lC.Text = ex.Message;
//                        Ph.Controls.Add(lC);
//                    }
//                }
//                catch { }

//            }
//        }
//        else
//        {
//            try
//            {
//                Literal litError = new Literal();
//                litError.Text = (string)htAddons["Error"] == "No Data" ? "" : (string)htAddons["Error"];
//                PlaceHolder Ph = Pg.Master.FindControl("Default") as PlaceHolder;
//                Ph.Controls.Add(litError);
//            }
//            catch { }

//        }
//    }
    public static bool isNumeric(string value)
    {
        int result;
        return int.TryParse(value, out result);
    }
    public static bool isBool(object value)
    {
        bool result = false;
        if (value == null)
        {
            return result;
        }
        else
        {
            return bool.TryParse(value.ToString(), out result);
        }
    }
    public static string CreateCode(String input)
    {
        string[] pattern = new string[] { "[^a-zA-Z0-9-]", "-+" };
        string[] replacements = new string[] { "-", "-" };
        input = input.Trim();
        input = input.Replace("Ç", "C");
        input = input.Replace("ç", "c");
        input = input.Replace("Ğ", "G");
        input = input.Replace("ğ", "g");
        input = input.Replace("Ü", "U");
        input = input.Replace("ü", "u");
        input = input.Replace("Ş", "S");
        input = input.Replace("ş", "s");
        input = input.Replace("İ", "I");
        input = input.Replace("ı", "i");
        input = input.Replace("Ö", "O");
        input = input.Replace("ö", "o");
        for (int i = 0; i < pattern.Length; i++)
        {
            input = Regex.Replace(input, pattern[i], replacements[i]);
        }
        return input;
    }
    //public static string GetCode(int PostID)
    //{
    //    string _slug = DBToys.Do.SimpleTextQuery("Posts", "Where PostID = " + PostID.ToString(), "", "Code");
    //    return _slug;
    //}
    //public static string GetPageLinks(string StartTag, string inTag, string outTag, string EndTag, string Show)
    //{
    //    string strWhere = "Where " + Show + " AND State=1 AND Type=1";
    //    Hashtable Ht = DBToys.Do.SimpleQuery("Posts", strWhere, "Order By Code", "*");
    //    string strNav = "";
    //    if (Ht["Error"] == null)
    //    {
    //        DataTable Dt = Ht["DataTable"] as DataTable;
    //        foreach (DataRow Dr in Dt.Rows)
    //        {
    //            Post post = new Post();
    //            Post.FillPost(Dr, post);
    //            post.Link = Functions.GetLink(post);
    //            strNav += StartTag + "<a href=\"" + post.Link + "\">" + inTag + post.Title + outTag + "</a>" + EndTag;
    //        }
    //    }
    //    return strNav;
    //}
    //public static string GetPermalink(string contentType, string Code, string Extension)
    //{
    //    string strPerma = "";
    //    strPerma = Blogsa.Settings["blog_url"] + contentType + "/" + Code + Extension;
    //    return strPerma;
    //}
    //public static string GetLink(Post post)
    //{
    //    short sPermaValue = Convert.ToInt16(Blogsa.Settings["permalink"]);
    //    string strExpression = string.Empty;
    //    if (sPermaValue == 0)
    //        if (post.Type == 0)
    //            strExpression = "Posts.aspx?PostID=" + post.PostID;
    //        else if (post.Type == 1)
    //            strExpression = "Posts.aspx?Code=" + post.Code;
    //        else
    //            strExpression = "Posts.aspx?FileID=" + post.PostID;
    //    else
    //    {
    //        strExpression = Blogsa.Settings["permaexpression"].ToString();
    //        Dictionary<string, string> dicExpressions = new Dictionary<string, string>();
    //        dicExpressions.Add("{author}", post.UserName);
    //        dicExpressions.Add("{name}", post.Code);
    //        dicExpressions.Add("{year}", post.Date.Year.ToString());
    //        dicExpressions.Add("{month}", post.Date.Month.ToString("00"));
    //        dicExpressions.Add("{day}", post.Date.Day.ToString("00"));
    //        dicExpressions.Add("{id}", post.PostID.ToString());
    //        Regex rex = new Regex("({(.+?)})/");
    //        if (post.Type == 1)
    //        {
    //            strExpression = strExpression.Replace("{name}", post.Code);
    //            strExpression = strExpression.Replace("{id}", post.PostID.ToString());
    //            strExpression = rex.Replace(strExpression, "");
    //        }
    //        else
    //            foreach (string key in dicExpressions.Keys)
    //                strExpression = strExpression.Replace(key, dicExpressions[key]);
    //    }
    //    return Blogsa.Url + strExpression;
    //}
    //public static string GetLink(int iPostID)
    //{
    //    return GetLink(Post.GetPost(iPostID));
    //}
    public static void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page)
    {
        int pageIndex = gridView.PageIndex;
        int pageCount = gridView.PageCount;
        Control pagerControl = gvPagerRow.Controls[0].Controls[1];
        //HttpContext.Current.Response.Write(pagerControl.Controls.Count);
        //HttpContext.Current.Response.End();
        LinkButton btnFirst = (LinkButton)pagerControl.FindControl("btnFirst");
        LinkButton btnPrevious = (LinkButton)pagerControl.FindControl("btnPrevious");
        LinkButton btnNext = (LinkButton)pagerControl.FindControl("btnNext");
        LinkButton btnLast = (LinkButton)pagerControl.FindControl("btnLast");
        btnFirst.Enabled = btnPrevious.Enabled = (pageIndex != 0);
        btnNext.Enabled = btnLast.Enabled = (pageIndex < (pageCount - 1));
        DropDownList ddlPageSelector = (DropDownList)pagerControl.FindControl("ddlPageSelector");
        ddlPageSelector.Items.Clear();
        for (int i = 1; i <= gridView.PageCount; i++)
            ddlPageSelector.Items.Add(i.ToString());
        ddlPageSelector.SelectedIndex = pageIndex;
        ddlPageSelector.SelectedIndexChanged += delegate
        {
            gridView.PageIndex = ddlPageSelector.SelectedIndex;
        };
    }
    public static string GetMd5Hash(string value)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        StringBuilder sB = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sB.Append(data[i].ToString("x2"));
        }
        return sB.ToString();
    }
    public static StringDictionary GetLanguageDictionary(string strFile)
    {
        StringDictionary SD = new StringDictionary();
        try
        {
            DataSet DS = new DataSet();
            DS.ReadXml(HttpContext.Current.Server.MapPath("~/" + strFile));
            foreach (DataRow Dr in DS.Tables["word"].Rows)
            {
                string strKeyword = Dr["Keyword"].ToString();
                string strTranslate = Dr["Translate"].ToString();
                strTranslate = strTranslate == "!" ? Dr["word_Text"].ToString() : strTranslate;
                SD.Add(strKeyword, strTranslate);
            }
            DS = null;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
        }
        return SD;
    }
    public static ListItemCollection LanguagesByFolder(string strFolder)
    {
        return LanguagesByFolder(strFolder, null);
    }
    public static ListItemCollection LanguagesByFolder(string strFolder, string strFilter)
    {
        strFolder = HttpContext.Current.Server.MapPath("~/" + strFolder);
        ListItemCollection LIC = new ListItemCollection();
        DirectoryInfo DIF = new DirectoryInfo(strFolder);
        FileInfo[] FIN = DIF.GetFiles("*.xml");
        foreach (FileInfo item in FIN)
        {
            if (!string.IsNullOrEmpty(strFilter) && !item.Name.Contains(strFilter))
                continue;
            ListItem LI = new ListItem();
            XmlDocument XDoc = new XmlDocument();
            XDoc.Load(@item.FullName);
            string strLanguage = XDoc.SelectSingleNode("//language//lang").InnerText;
            LI.Text = strLanguage;
            LI.Value = item.Name.Split('.').GetValue(0).ToString();
            LIC.Add(LI);
        }
        return LIC;
    }
    public static string GetSystemLanguage
    {
        get
        {
            return System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag;
        }
    }
    public static string GetXmlSingleNodeValue(string XmlFile, string XmlPath)
    {
        try
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.Load(XmlFile);
            return XDoc.SelectSingleNode(XmlPath).InnerText;
        }
        catch
        {
            return "";
        }
    }
    public static string GetNowDate(string Mode, DateTime dT)
    {
        if (dT == null)
        {
            dT = DateTime.Now;
        }
        string NowDate = dT.ToString("yyyy-MM-dd HH:mm:ss");
        if (System.Configuration.ConfigurationManager.AppSettings["Provider"] == "System.Data.OleDb")
        {
            if (Mode == "update")
            {
                NowDate = dT.ToString("dd.MM.yyyy HH:mm:ss").Replace('.', '/');
            }
            else
            {
                NowDate = dT.ToString("MM.dd.yyyy HH:mm:ss").Replace('.', '/');
            }
        }
        return NowDate;
    }
    public static string GetPostState(string State, DateTime PublishDate)
    {
        if (PublishDate > DateTime.Now)
            return "<strong style=\"color:#E8A700\">" + Language.Admin["WaitingPost"] + "</strong>";
        else if (State == "0")
            return "<strong style=\"color:#808080\">" + Language.Admin["DraftedPost"] + "</strong>";
        else if (State == "1")
            return "<strong style=\"color:#006F9B\">" + Language.Admin["PublishedPost"] + "</strong>";
        else if (State == "2")
            return "<strong style=\"color:#FF3300\">" + Language.Admin["DeletedPost"] + "</strong>";
        else
            return "";
    }
    public static Char[] Chars = "abcdefghijklmnpqrstuvwxyz1234567890".ToCharArray();
    public static string GetRandomStr(int stringSize)
    {
        String returns = "";
        Random Rnd = new Random();
        for (int i = 0; i < stringSize; i++)
        {
            returns += Chars[Rnd.Next(Chars.Length)];
        }
        return returns;
    }
    public static bool CheckEmail(string strEmail)
    {
        Regex rex = new Regex("^[\\w\\.=-]+@[\\w\\.-]+\\.[\\w]{2,3}$");
        return rex.IsMatch(strEmail);
    }
    //public static bool SendMail(string strSubject, string strFrom, string strFromName, string strTo, string strToName, string strBody, bool bIsBodyHtml)
    //{
    //    try
    //    {
    //        Blogsa.ReadSettings();
    //        MailMessage message = new MailMessage();
    //        message.Subject = strSubject;
    //        message.From = new MailAddress(strFrom, strFromName);
    //        message.To.Add(new MailAddress(strTo, strTo));
    //        message.Body = strBody;
    //        message.IsBodyHtml = bIsBodyHtml;
    //        message.Priority = MailPriority.High;

    //        SmtpClient client = new SmtpClient(Blogsa.Settings["smtp_server"].ToString(), Convert.ToInt32(Blogsa.Settings["smtp_port"]));
    //        NetworkCredential SMTPUserInfo = new NetworkCredential(Blogsa.Settings["smtp_user"].ToString(), Blogsa.Settings["smtp_pass"].ToString());
    //        client.UseDefaultCredentials = false;
    //        client.Credentials = SMTPUserInfo;
    //        client.EnableSsl = Convert.ToBoolean(Blogsa.Settings["smtp_usessl"]);
    //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

    //        client.Send(message);
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    public static void AddHeader(Page page, string name, string content)
    {
        HtmlMeta metaTag = new HtmlMeta();
        HtmlGenericControl genericControl = new HtmlGenericControl();
        genericControl.InnerHtml = content;
        metaTag.Name = name;
        metaTag.Content = genericControl.InnerText;
        page.Header.Controls.Add(metaTag);
    }
}
