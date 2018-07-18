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
using NewDAL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using MSS;
using Microsoft.VisualBasic;
public partial class GatePass_Gate_Pass_Internal : BaseClass
{
    DbFunctions objFun = new DbFunctions();   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["title"] != null)
        {
           // lbltitle.InnerText = Context.Request.QueryString["title"].ToString();
        }
        if (!IsPostBack)
        {
            btnDelete.Enabled = false;
            objFun.FillDropdownlist(ddlActivity, "Activity_Name", "Activity_ID","select * from ActivityType_Master", "--Select--");
            objFun.FillGridView(gvActivity, "SELECT ActivityType_Master2.Activity_Type_Name, ActivityType_Master.Activity_Name, ActivityType_Master2.Activity_ID FROM ActivityType_Master INNER JOIN ActivityType_Master2 ON ActivityType_Master.Activity_ID = ActivityType_Master2.ActivityNameID Order By ActivityNameID");
        }
    }
    protected void btnActivity_Click(object sender, EventArgs e)
    {
        if (btnActivity.Text == "Save")
        {
            if (ddlActivity.SelectedIndex == 0)
            {
                objFun.MsgBox1("please Select Activity Name..!!", UpdatePanel1);
                return;
            }
            if (txtActivity.Text == "")
            {
                objFun.MsgBox1("Please Fill Type of Activity..!!", UpdatePanel1);
                return;
            }
            objFun.ExecuteDML1("insert into ActivityType_Master2 values('"+ ddlActivity.SelectedValue +"','" + txtActivity.Text + "')");
            objFun.MsgBox1("Activity save Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "SELECT ActivityType_Master2.Activity_Type_Name, ActivityType_Master.Activity_Name, ActivityType_Master2.Activity_ID FROM ActivityType_Master INNER JOIN ActivityType_Master2 ON ActivityType_Master.Activity_ID = ActivityType_Master2.ActivityNameID Order By ActivityNameID");
            txtActivity.Text = "";
        }
        else
        {
            objFun.ExecuteDML1("Update  ActivityType_Master2 set ActivityNameID = '" + ddlActivity.SelectedValue + "', Activity_Type_Name = '" + txtActivity.Text + "'  where Activity_ID = '" + HDActivity.Value + "'");
            objFun.MsgBox1("Activity Updated Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "SELECT ActivityType_Master2.Activity_Type_Name, ActivityType_Master.Activity_Name, ActivityType_Master2.Activity_ID FROM ActivityType_Master INNER JOIN ActivityType_Master2 ON ActivityType_Master.Activity_ID = ActivityType_Master2.ActivityNameID Order By ActivityNameID");
            btnReset_Click(sender, e);
           
        }
    }
   
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        objFun.ExecuteDML1("delete from ActivityType_Master2 where Activity_ID = '" + HDActivity.Value + "'");
        objFun.MsgBox1("Activity Deleted Successfully..!!", UpdatePanel1);
        objFun.FillGridView(gvActivity, "SELECT ActivityType_Master2.Activity_Type_Name, ActivityType_Master.Activity_Name, ActivityType_Master2.Activity_ID FROM ActivityType_Master INNER JOIN ActivityType_Master2 ON ActivityType_Master.Activity_ID = ActivityType_Master2.ActivityNameID Order By ActivityNameID");
        btnReset_Click(sender, e);
    }
    protected void LnkActivity_Click(object sender, EventArgs e)
    {
        LinkButton Lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)Lnkbtn.Parent.Parent;
        int index = row.RowIndex;
        HDActivity.Value = ((Label)gvActivity.Rows[index].FindControl("Label1")).Text;      
        DataTable DT = new DataTable();
        DT = objFun.FillDataTable("select ActivityNameID, Activity_Type_Name from ActivityType_Master2 where Activity_ID = '" + HDActivity.Value + "'");
        txtActivity.Text = DT.Rows[0].ItemArray[1].ToString();
        ddlActivity.SelectedIndex = ddlActivity.Items.IndexOf(ddlActivity.Items.FindByValue(DT.Rows[0].ItemArray[0].ToString()));
        btnActivity.Text = "Update";
        btnDelete.Enabled = true;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtActivity.Text = "";
        ddlActivity.SelectedIndex = 0;
        btnActivity.Text = "Save";
        btnDelete.Enabled = false;
    }
}
