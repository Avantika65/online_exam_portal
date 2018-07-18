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
            ddlActivitytype.Enabled = false;
            btnDelete.Enabled = false;
            objFun.FillDropdownlist(ddlActivity, "Activity_Name", "Activity_ID","select * from ActivityType_Master", "--Select--");
            objFun.FillDropdownlist(ddlActivitytype, "Activity_Type_Name", "Activity_ID", "select * from ActivityType_Master2", "--Select--");
            objFun.FillGridView(gvActivity, "SELECT * from Activity_Type_Master_View ORDER BY ActivityNameID");
         }
    }
    protected void btnActivity_Click(object sender, EventArgs e)
    {
        if (btnActivity.Text == "Save")
        {
            if (ddlActivity.SelectedIndex == 0)
            {
                objFun.MsgBox1("Please Select Activity Name..!!!", UpdatePanel1);
                return;
            }           
            if (ddlActivitytype.SelectedIndex == 0)
            {
                objFun.MsgBox1("Please Select Type of Activity..!!!", UpdatePanel1);
                return;
            }
            if (subActivity.Text == "")
            {
                objFun.MsgBox1("Please Fill Sub Activity Name..!!!", UpdatePanel1);
                return;
            }
            objFun.ExecuteDML1("insert into ActivityType_Master3 values('" + ddlActivity.SelectedValue + "', '"+ ddlActivitytype.SelectedValue +"','" + subActivity.Text + "')");
            objFun.MsgBox1("Activity save Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "SELECT * from Activity_Type_Master_View ORDER BY ActivityNameID");
            subActivity.Text = "";
           
        }
        else
        {
            objFun.ExecuteDML1("Update  ActivityType_Master3 set ActivityNameID = '" + ddlActivity.SelectedValue + "', ActivityTypeID = '" + ddlActivitytype.SelectedValue + "', SubActivity = '"+ subActivity.Text +"'  where ActivityID = '" + HDActivity.Value + "'");
            objFun.MsgBox1("Activity Updated Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "SELECT * from Activity_Type_Master_View ORDER BY ActivityNameID");
            btnReset_Click(sender, e);
           
        }
    }
   
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        objFun.ExecuteDML1("delete from ActivityType_Master3 where ActivityID = '" + HDActivity.Value + "'");
        objFun.MsgBox1("Activity Deleted Successfully..!!", UpdatePanel1);
        objFun.FillGridView(gvActivity, "SELECT * from Activity_Type_Master_View ORDER BY ActivityNameID"); 
        btnReset_Click(sender, e);
    }   
    protected void btnReset_Click(object sender, EventArgs e)
    {
        subActivity.Text = "";
        ddlActivity.SelectedIndex = 0;
        ddlActivitytype.SelectedIndex = 0;
        btnActivity.Text = "Save";
        btnDelete.Enabled = false;
    }
    protected void LNKSubActivity_Click(object sender, EventArgs e)
    {
        LinkButton Lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)Lnkbtn.Parent.Parent;
        int index = row.RowIndex;
        HDActivity.Value = ((Label)gvActivity.Rows[index].FindControl("Label1")).Text;
        DataTable DT = new DataTable();
        DT = objFun.FillDataTable("select ActivityNameID, ActivityTypeID, SubActivity from ActivityType_Master3 where ActivityID = '" + HDActivity.Value + "'");
        subActivity.Text = DT.Rows[0].ItemArray[2].ToString();
        ddlActivitytype.SelectedIndex = ddlActivitytype.Items.IndexOf(ddlActivitytype.Items.FindByValue(DT.Rows[0].ItemArray[1].ToString()));
        ddlActivity.SelectedIndex = ddlActivity.Items.IndexOf(ddlActivity.Items.FindByValue(DT.Rows[0].ItemArray[0].ToString()));
        btnActivity.Text = "Update";
        btnDelete.Enabled = true;
        ddlActivitytype.Enabled = true;
    }
    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        objFun.FillDropdownlist(ddlActivitytype, "Activity_Type_Name", "Activity_ID", "select * from ActivityType_Master2 where ActivityNameID = '"+ ddlActivity.SelectedValue +"'", "--Select--");
        ddlActivitytype.Enabled = true;   
    }
}
