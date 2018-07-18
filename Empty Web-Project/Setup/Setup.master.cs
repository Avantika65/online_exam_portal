using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Setup_Setup : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["lang"]))
            Session["lang"] = Request["lang"];
        if (Session["lang"] == null)
        {
            string strSystemLang = Functions.GetSystemLanguage.Split('-').GetValue(0).ToString();
            Session["lang"] = strSystemLang != "" ? strSystemLang : "en";
        }
        Language.Setup = Functions.GetLanguageDictionary("Setup/Languages/" + Session["lang"].ToString() + ".xml");

        if (Eduset.SetupControl && !Request.Url.AbsoluteUri.Contains("/Setup/Default.aspx"))
        {
            Session["Step"] = "BeforeInstalled";
            Response.Redirect("Default.aspx");
        }
        else if (!string.IsNullOrEmpty(Request["Setup"]) && (string)Request["Setup"] == "OK")
            Session["Step"] = "Finish";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetLanguage();
    }
    private void GetLanguage()
    {
        ListItemCollection LIC = Functions.LanguagesByFolder("Setup/Languages/");
        foreach (ListItem item in LIC)
            ddLanguage.Items.Add(item);
        ddLanguage.SelectedValue = (string)Session["lang"];
    }

    protected void ddLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["lang"] = ((DropDownList)sender).SelectedValue;
        Language.Setup = Functions.GetLanguageDictionary("Setup/Languages/" + Session["lang"].ToString() + ".xml");
    }

    public static XmlNode CreateNode(XmlDocument XDoc, string NodeName)
    {
        XmlNode XNode = XDoc.CreateNode(XmlNodeType.Element, NodeName, "");
        return XNode;
    }
    public static XmlAttribute CreateAttribute(XmlDocument XDoc, string Name, string Value)
    {
        XmlAttribute XAttr = XDoc.CreateAttribute(Name);
        XAttr.Value = Value;
        return XAttr;
    }
    public static bool SaveWebConfig(string strConnectionString, string strProvider)
    {
        XmlDocument XDoc = new XmlDocument();
        XDoc.Load(HttpContext.Current.Server.MapPath("~/Web.config"));
        XmlNodeList nodeList = XDoc.SelectNodes("//appSettings");
        if (nodeList.Count == 1)
        {
            nodeList[0].RemoveAll();

            XmlNode XNode = CreateNode(XDoc, "add");
            XNode.Attributes.Append(CreateAttribute(XDoc, "key", "ConnectionString"));
            XNode.Attributes.Append(CreateAttribute(XDoc, "value", strConnectionString));
            nodeList[0].AppendChild(XNode);
            XNode = CreateNode(XDoc, "add");
            XNode.Attributes.Append(CreateAttribute(XDoc, "key", "Provider"));
            XNode.Attributes.Append(CreateAttribute(XDoc, "value", strProvider));
            nodeList[0].AppendChild(XNode);
            XNode = CreateNode(XDoc, "add");
            XNode.Attributes.Append(CreateAttribute(XDoc, "key", "Setup"));
            XNode.Attributes.Append(CreateAttribute(XDoc, "value", "Ok"));
            nodeList[0].AppendChild(XNode);
            XDoc.Save(HttpContext.Current.Server.MapPath("~/web.config"));
            return true;
        }
        else
        {
            return false;
        }
    }
}
