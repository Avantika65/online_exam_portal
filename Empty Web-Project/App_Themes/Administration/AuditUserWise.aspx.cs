using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using NewDAL;
public partial class Administration_AuditUserWise : BaseClass
{
    DbFunctions objFun = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CheckAuthontication() != true)
        {
            Response.Redirect("../logout.aspx");
        }
        if (Context.Request.QueryString["title"] != null)
        {
            lbltitle.InnerText = Context.Request.QueryString["title"].ToString();
        }
        if (!IsPostBack)
        {
            ddlInstitute.Focus();
            objFun.FillInstitute(ddlInstitute, "---Select---");
            objFun.FillGridView(GridView1, "Select distinct Username from usercreation where instituteid='"+ Session["instid"].ToString() +"'");
        }
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex == 0)
        {
            objFun.MsgBox1("Please select Institute.", UpdatePanel1);
            return;
        }
        if (txtFrom.Text.Trim() == "")
        {
            objFun.MsgBox1("Please select From Date.", UpdatePanel1);
            return;
        }
        string action = "";
        if (chkAction.Items[4].Selected == true)
        {
            action = "'L','I','U','D','N'";
        }
        else
        {
            int i;
            for (i = 0; i <= 3; i++)
            {
                if (action == "")
                {
                    action = "'" + chkAction.Items[i].Value + "'";
                }
                else
                {
                    action = action + ",'" + chkAction.Items[i].Value + "'";
                }
            }
        }
        int j;
        string username = "";
        int chk = 0;
        for (j = 0; j <= GridView1.Rows.Count - 1; j++)
        {
            CheckBox chksel;
            chksel = (CheckBox)GridView1.Rows[j].FindControl("chkSelect");
            if (chksel.Checked == true)
            {
                if (username == "")
                {
                    username = "'" + GridView1.Rows[j].Cells[1].Text.ToString() +"'";
                }
                else
                {
                    username = username + ",'" + GridView1.Rows[j].Cells[1].Text.ToString() + "'";
                }
                chk = chk + 1;
            }
        }
        if (chk == 0)
        {
            objFun.MsgBox1("Please select atleast one user.", UpdatePanel1);
            return;
        }
        if (optType.Items[0].Selected == true)
        {
            ProcessWise(action, username);
            return;
        }
        if (optType.Items[1].Selected == true)
        {
            UserWise(action, username);
            return;
        }
        if (optType.Items[2].Selected == true)
        {
            ActionWise(action, username);
            return;
        }
        objFun.MsgBox1("Please select report type.", UpdatePanel1);
    }
    private void ProcessWise(string action,string username)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable drs = new DataTable();

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, "select * from audit_report where user_id in("+ username +") and instituteid='"+ ddlInstitute.SelectedValue +"' and action in("+ action +") and entry_Date between'"+ txtFrom.Text  +"' and '"+ txtTo.Text  +"'");

        if (dr.HasRows)
        {
            drs.Load(dr);
        }
        if (drs.Rows.Count == 0)
        {
            objFun.MsgBox1("No record found to print.", UpdatePanel1);
            return;
        }
        ReportDocument rpt1 = new ReportDocument();
        string spath = ""; //= Server.MapPath("Report\\CWFD.rpt").Replace("Fee\\Fee\\", "Fee\\");
        string spath1 = Server.MapPath("..\\Report\\");
        spath = Server.MapPath("..\\Report\\PWUReport.rpt");
        //  stredds.Tables["DataTable1"].Merge(drs, true, MissingSchemaAction.Ignore);
        rpt1.Load(spath);
        rpt1.SetDataSource(drs);
        CrystalReportViewer1.ReportSource = rpt1;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
        ExportOptions exportOpts1 = rpt1.ExportOptions;
        rpt1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rpt1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        rpt1.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        ((DiskFileDestinationOptions)rpt1.ExportOptions.DestinationOptions).DiskFileName = spath1 + "ProcessWise.pdf";

        //Session["instName"]
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["GroupHeaderSection4"].ReportObjects["GroupNameSemester1"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section5"].ReportObjects["Text27"]).Text = Session["instName"].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section5"].ReportObjects["Text29"]).Text = Session["U_Name"].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text1"]).Text = Session["instName"].ToString();

        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        // ((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        rpt1.Export();
        rpt1.Close();
        rpt1.Dispose();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "ProcessWise.pdf");
        Response.WriteFile(spath1 + "ProcessWise.pdf");
        Response.Flush();
        Response.End();
        File.Delete(Server.MapPath(spath1 + "ProcessWise.pdf"));
        Response.Close();
    }
    private void UserWise(string action, string username)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable drs = new DataTable();

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, "select * from audit_report where user_id in(" + username + ") and instituteid='" + ddlInstitute.SelectedValue + "' and action in(" + action + ") and entry_Date between'" + txtFrom.Text + "' and '" + txtTo.Text + "'");

        if (dr.HasRows)
        {
            drs.Load(dr);
        }
        if (drs.Rows.Count == 0)
        {
            objFun.MsgBox1("No record found to print.", UpdatePanel1);
            return;
        }
        ReportDocument rpt1 = new ReportDocument();
        string spath = ""; //= Server.MapPath("Report\\CWFD.rpt").Replace("Fee\\Fee\\", "Fee\\");
        string spath1 = Server.MapPath("..\\Report\\");
        spath = Server.MapPath("..\\Report\\UAWPReport.rpt");
        //  stredds.Tables["DataTable1"].Merge(drs, true, MissingSchemaAction.Ignore);
        rpt1.Load(spath);
        rpt1.SetDataSource(drs);
        CrystalReportViewer1.ReportSource = rpt1;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
        ExportOptions exportOpts1 = rpt1.ExportOptions;
        rpt1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rpt1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        rpt1.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        ((DiskFileDestinationOptions)rpt1.ExportOptions.DestinationOptions).DiskFileName = spath1 + "UserWise.pdf";

        //Session["instName"]
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["GroupHeaderSection4"].ReportObjects["GroupNameSemester1"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section5"].ReportObjects["Text27"]).Text = Session["instName"].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section5"].ReportObjects["Text29"]).Text = Session["U_Name"].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text1"]).Text = Session["instName"].ToString();

        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        // ((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        rpt1.Export();
        rpt1.Close();
        rpt1.Dispose();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "UserWise.pdf");
        Response.WriteFile(spath1 + "UserWise.pdf");
        Response.Flush();
        Response.End();
        File.Delete(Server.MapPath(spath1 + "UserWise.pdf"));
        Response.Close();
    }
    private void ActionWise(string action, string username)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable drs = new DataTable();

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, "select * from audit_report where user_id in(" + username + ") and instituteid='" + ddlInstitute.SelectedValue + "' and action in(" + action + ") and entry_Date between'" + txtFrom.Text + "' and '" + txtTo.Text + "'");

        if (dr.HasRows)
        {
            drs.Load(dr);
        }
        if (drs.Rows.Count == 0)
        {
            objFun.MsgBox1("No record found to print.", UpdatePanel1);
            return;
        }
        ReportDocument rpt1 = new ReportDocument();
        string spath = ""; //= Server.MapPath("Report\\CWFD.rpt").Replace("Fee\\Fee\\", "Fee\\");
        string spath1 = Server.MapPath("..\\Report\\");
        spath = Server.MapPath("..\\Report\\AUWReport.rpt");
        //  stredds.Tables["DataTable1"].Merge(drs, true, MissingSchemaAction.Ignore);
        rpt1.Load(spath);
        rpt1.SetDataSource(drs);
        CrystalReportViewer1.ReportSource = rpt1;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
        ExportOptions exportOpts1 = rpt1.ExportOptions;
        rpt1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rpt1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        rpt1.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        ((DiskFileDestinationOptions)rpt1.ExportOptions.DestinationOptions).DiskFileName = spath1 + "ActionWise.pdf";

        //Session["instName"]
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["GroupHeaderSection4"].ReportObjects["GroupNameSemester1"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section5"].ReportObjects["Text27"]).Text = Session["instName"].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section5"].ReportObjects["Text29"]).Text = Session["U_Name"].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text1"]).Text = Session["instName"].ToString();

        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        // ((CrystalDecisions.CrystalReports.Engine.TextObject)rpt1.ReportDefinition.Sections["Section1"].ReportObjects["Text8"]).Text = dtInst.Rows[0].ItemArray[0].ToString();
        rpt1.Export();
        rpt1.Close();
        rpt1.Dispose();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "ActionWise.pdf");
        Response.WriteFile(spath1 + "ActionWise.pdf");
        Response.Flush();
        Response.End();
        File.Delete(Server.MapPath(spath1 + "ActionWise.pdf"));
        Response.Close();
    }
    protected void chkAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkAction.Items[4].Selected == true)
        {
            chkAction.Items[0].Selected = true;
            chkAction.Items[1].Selected = true;
            chkAction.Items[2].Selected = true;
            chkAction.Items[3].Selected = true;
        }
        else if (chkAction.Items[4].Selected == false)
        {
            chkAction.Items[0].Selected = false;
            chkAction.Items[1].Selected = false;
            chkAction.Items[2].Selected = false;
            chkAction.Items[3].Selected = false;
        }
    }
}
