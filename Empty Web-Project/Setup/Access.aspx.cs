using System;
using System.Data;
using System.IO;
using System.Data.OleDb;

public partial class Setup_Access : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        HideDivs();
        switch ((string)Session["AccessStep"]) {
            case "0": divSetup.Visible = true; break;
            default: divSetup.Visible = true; break;
        }
    }
    private void HideDivs() {
        divSetup.Visible = false;
        divError.Visible = false;
    }

    public void CreateXML(string ConnectionString) {
        Setup_Setup.SaveWebConfig(ConnectionString, "System.Data.OleDb");
    }

    protected void btnCancel_Click(object sender, EventArgs e) {
        string strLang = Session["lang"].ToString();
        Session.Abandon();
        Response.Redirect("Default.aspx?lang=" + strLang);
    }
    protected void btnInstall_Click(object sender, EventArgs e) {
        string ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\{0}.mdb;",
                txtDatabaseName.Text);
        OleDbConnection OConn = new OleDbConnection(ConnectionString);
        StreamReader Sr = new StreamReader(Server.MapPath("~/Setup/Scripts/Access.sql"));
        try {
            File.Copy(Server.MapPath("~/Setup/Scripts/Blogsa.mdb"), Server.MapPath(string.Format("~/App_Data/{0}.mdb", txtDatabaseName.Text)));

            //Update WebSite Url
            string strUrl = Request.Url.AbsoluteUri.Substring(0
                , Request.Url.AbsoluteUri.IndexOf(Request.Url.AbsolutePath) + (Request.ApplicationPath.Equals("/") ? 0 : Request.ApplicationPath.Length)) + "/";


            OConn.Open();
            while (!Sr.EndOfStream) {
                //Create DB
                string Commands = Sr.ReadLine().ToString();
                Commands = Commands.Replace("{0}", strUrl).Replace("{1}", Session["lang"].ToString());
                Commands = Commands.Replace("{post-title}", Language.Setup["{post-title}"]);
                Commands = Commands.Replace("{post-code}", Language.Setup["{post-code}"]);
                Commands = Commands.Replace("{post-content}", Language.Setup["{post-content}"]);
                Commands = Commands.Replace("{page-title}", Language.Setup["{page-title}"]);
                Commands = Commands.Replace("{page-code}", Language.Setup["{page-code}"]);
                Commands = Commands.Replace("{page-content}", Language.Setup["{page-content}"]);
                Commands = Commands.Replace("{category-title}", Language.Setup["{category-title}"]);
                Commands = Commands.Replace("{category-code}", Language.Setup["{category-code}"]);
                Commands = Commands.Replace("{tag-title}", Language.Setup["{tag-title}"]);
                Commands = Commands.Replace("{tag-code}", Language.Setup["{tag-code}"]);
                Commands = Commands.Replace("{setting-blogname}", Language.Setup["{setting-blogname}"]);
                Commands = Commands.Replace("{setting-blogdescription}", Language.Setup["{setting-blogdescription}"]);
                Commands = Commands.Replace("{widget-feeder}", Language.Setup["{widget-feeder}"]);
                Commands = Commands.Replace("{widget-pages}", Language.Setup["{widget-pages}"]);
                Commands = Commands.Replace("{widget-categories}", Language.Setup["{widget-categories}"]);
                Commands = Commands.Replace("{widget-recentpost}", Language.Setup["{widget-recentpost}"]);
                Commands = Commands.Replace("{widget-recentcomment}", Language.Setup["{widget-recentcomment}"]);
                Commands = Commands.Replace("{widget-links}", Language.Setup["{widget-links}"]);
                OleDbCommand OComm = new OleDbCommand(Commands, OConn);
                OComm.ExecuteNonQuery();
                OComm.Dispose();
            }

            Sr.Close();
            CreateXML(ConnectionString);
            string strLang = Session["lang"].ToString();
            Response.Redirect("Default.aspx?Setup=OK&lang=" + strLang);
        } catch (Exception ex) {
            divError.Visible = true;
            lblError.Text = ex.Message;
            if (OConn.State == ConnectionState.Open) {
                OConn.Close();
            }
            File.Delete(Server.MapPath("~/App_Data/" + txtDatabaseName.Text));
        } finally {
            if (OConn.State == ConnectionState.Open) {
                OConn.Close();
            }
            Sr.Close();
        }
    }
}
