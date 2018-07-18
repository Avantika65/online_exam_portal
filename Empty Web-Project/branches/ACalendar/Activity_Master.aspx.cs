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
        //    lbltitle.InnerText = Context.Request.QueryString["title"].ToString();
        }
        if (!IsPostBack)
        {
            objFun.FillGridView(gvActivity, "Select * from ActivityType_Master");
        }
    }
    protected void btnActivity_Click(object sender, EventArgs e)
    {
        if (btnActivity.Text == "Save")
        {
            if (txtActivity.Text == "")
            {
                objFun.MsgBox1("Please Fill Name of Activity..!!", UpdatePanel1);
            }
            objFun.ExecuteDML1("insert into ActivityType_Master values('" + txtActivity.Text + "')");
            objFun.MsgBox1("Activity save Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "Select * from ActivityType_Master");
            txtActivity.Text = "";
        }
        else
        {
            objFun.ExecuteDML1("Update  ActivityType_Master set Activity_Name = '" + txtActivity.Text + "' where Activity_ID = " + HDActivity.Value + "");
            objFun.MsgBox1("Activity Updated Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "Select * from ActivityType_Master");
            txtActivity.Text = "";
            btnActivity.Text = "Save";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
   {
        LinkButton Lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)Lnkbtn.Parent.Parent;
        int index = row.RowIndex;
        Label lbl;
        lbl = (Label)gvActivity.Rows[index].FindControl("Label1");
        HDActivity.Value = lbl.Text;
        DataTable DT = new DataTable();
        DT = objFun.FillDataTable("select Activity_Name from ActivityType_Master where Activity_ID = " + HDActivity.Value + "");
        txtActivity.Text = DT.Rows[0].ItemArray[0].ToString();
        btnActivity.Text = "Update";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        objFun.ExecuteDML1("delete from ActivityType_Master where Activity_ID = '" + HDActivity.Value + "' ");
        objFun.MsgBox1("Activity Deleted Successfully..!!", UpdatePanel1);
        objFun.FillGridView(gvActivity, "Select * from ActivityType_Master");
        txtActivity.Text = "";
        btnActivity.Text = "Save";
    }
}
