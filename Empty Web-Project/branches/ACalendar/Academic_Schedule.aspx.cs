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
using System.Drawing;
public partial class GatePass_Gate_Pass_Internal : BaseClass
{
    DbFunctions objFun = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Request.QueryString["title"] != null)
        {
            lbltitle.InnerText = Context.Request.QueryString["title"].ToString();
            txtUsrName.Text = Session["U_name"].ToString();
        }
        if (!IsPostBack)
        {
            ddlActivitytype.Enabled = false;
            btnDelete.Enabled = false;
            objFun.FillDropdownlist(ddlActivity, "Activity_Name", "Activity_ID", "select * from ActivityType_Master", "--Select--");
            objFun.FillDropdownlist(ddlActivitytype, "Activity_Type_Name", "Activity_ID", "select * from ActivityType_Master2", "--Select--");
            objFun.FillDropdownlist(ddlSubAct, "SubActivity", "ActivityID", "select * from ActivityType_Master3", "--Select--");
            objFun.FillDropdownlist(ddlSubActType, "SubActivityName", "SubActID", "select * from ActivityType_Master4", "--Select--");
            objFun.FillGridView(gvActivity, "SELECT * from Academic_Calendar_Entry_View ORDER BY ActivityTypeID");
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
            if (ddlSubAct.SelectedIndex == 0)
            {
                ddlSubAct.SelectedValue = "0";
            }
            if (ddlSubActType.SelectedIndex == 0)
            {
                ddlSubActType.SelectedValue = "0";
            }
            if (txtfrmDate.Text == "")
            {
                objFun.MsgBox1("Please Insert From Date..!!!", UpdatePanel1);
                return;
            }
            if (txttoDate.Text == "")
            {
                objFun.MsgBox1("Please Insert To Date..!!!", UpdatePanel1);
                return;
            }
            if (txtFromTime.Text == "")
            {
                objFun.MsgBox1("Please Insert From Time..!!!", UpdatePanel1);
                return;
            }
            if (txtToTime.Text == "")
            {
                objFun.MsgBox1("Please Insert To Time..!!!", UpdatePanel1);
                return;
            }

            objFun.ExecuteDML1("insert into Academic_Calendar_Entry values('" + ddlActivity.SelectedValue + "', '" + ddlActivitytype.SelectedValue + "','" + ddlSubAct.SelectedValue + "','" + ddlSubActType.SelectedValue + "','" + Convert.ToDateTime(txtfrmDate.Text).ToString("dd-MMM-yyyy") + "', '" + Convert.ToDateTime(txttoDate.Text).ToString("dd-MMM-yyyy") + "','" + txtFromTime.Text + "','" + txtToTime.Text + "', '" + txtempname.SelectedValue + "','" + txtEmpname2.SelectedValue + "','" + txtEmpname3.SelectedValue + "', '" + txtUsrName.Text + "','" + DateTime.Now.ToString("dd-MMM-yyyy") + "')");
            objFun.MsgBox1("Activity save Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "SELECT * from Academic_Calendar_Entry_View ORDER BY ActivityTypeID");
            btnReset_Click(sender, e);
        }
        else
        {
            objFun.ExecuteDML1("Update  Academic_Calendar_Entry set ActivityNameID = '" + ddlActivity.SelectedValue + "', ActivityTypeID = '" + ddlActivitytype.SelectedValue + "',SubActivityID = '" + ddlSubAct.SelectedValue + "',SubActivityTypeID = '" + ddlSubActType.SelectedValue + "', FromDate = '" + Convert.ToDateTime(txtfrmDate.Text).ToString("dd-MMM-yyyy") + "',ToDate = '" + Convert.ToDateTime(txttoDate.Text).ToString("dd-MMM-yyyy") + "', FromTime = '" + txtFromTime.Text + "', ToTime = '" + txtToTime.Text + "',ActivityHead='" + txtempname.SelectedValue + "',ActivityTypeHead='" + txtEmpname2.SelectedValue + "',SubActivityHead='"+ txtEmpname3.SelectedValue +"' where AcademicID = '" + HDActivity.Value + "'");
            objFun.MsgBox1("Activity Updated Successfully..!!", UpdatePanel1);
            objFun.FillGridView(gvActivity, "SELECT * from Academic_Calendar_Entry_View ORDER BY ActivityTypeID");
            btnReset_Click(sender, e);
           
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        objFun.ExecuteDML1("delete from Academic_Calendar_Entry where AcademicID = '" + HDActivity.Value + "'");
        objFun.MsgBox1("Activity Deleted Successfully..!!", UpdatePanel1);
        objFun.FillGridView(gvActivity, "SELECT * from Academic_Calendar_Entry_View ORDER BY ActivityTypeID");
        btnReset_Click(sender, e);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlActivity.SelectedIndex = 0;
        ddlActivitytype.SelectedIndex = 0;
        ddlSubAct.SelectedIndex = 0;
        btnActivity.Text = "Save";
        btnDelete.Enabled = false;
        txtActHead.Text = "";
        txtSubActHD.Text = "";
        txtSubTypHD.Text = "";
        ddlSubActType.SelectedIndex = 0;
        txtfrmDate.Text = "";
        txttoDate.Text = "";
        txtFromTime.Text = "";
        txtToTime.Text = "";

    }
    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        objFun.FillDropdownlist(ddlActivitytype, "Activity_Type_Name", "Activity_ID", "select * from ActivityType_Master2 where ActivityNameID = '" + ddlActivity.SelectedValue + "'", "--Select--");
        ddlActivitytype.Enabled = true;
    }
    protected void ddlActivitytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        objFun.FillDropdownlist(ddlSubAct, "SubActivity", "ActivityID", "select * from ActivityType_Master3 where ActivityTypeID = '" + ddlActivitytype.SelectedValue + "'", "--Select--");
        ddlSubAct.Enabled = true;
    }
    protected void ddlSubAct_SelectedIndexChanged(object sender, EventArgs e)
    {
        objFun.FillDropdownlist(ddlSubActType, "SubActivityName", "SubActID", "select * from ActivityType_Master4 where SubActivityID = '" + ddlSubAct.SelectedValue + "'", "--Select--");
    }
    protected void Chksub_CheckedChanged(object sender, EventArgs e)
    {
        if (Chksub.Checked == true)
        {
            ddlSubAct.Visible = true;
            lblSub.Visible = true;
            ChksubAct.Visible = true;
            txtSubActHD.Visible = true;
            lblSubActivity.Visible = true;
        }
        if (Chksub.Checked == false)
        {
            ddlSubAct.Visible = false;
            lblSub.Visible = false;
            ChksubAct.Visible = false;
            ddlSubActType.Visible = false;
            lblSubAct.Visible = false;
            ChksubAct.Checked = false;
            ddlSubActType.SelectedIndex = 0;
            ddlSubAct.SelectedIndex = 0;
            txtSubActHD.Visible = false;
            lblSubActivity.Visible = false;
            txtSubTypHD.Visible = false;
            lblSubActivityType.Visible = false;
        }
    }
    protected void ChksubAct_CheckedChanged(object sender, EventArgs e)
    {
        if (ChksubAct.Checked == true)
        {
            ddlSubActType.Visible = true;
            lblSubAct.Visible = true;
            txtSubTypHD.Visible = true;
            lblSubActivityType.Visible = true;
        }
        if (ChksubAct.Checked == false)
        {
            ddlSubActType.Visible = false;
            lblSubAct.Visible = false;
            ddlSubActType.SelectedIndex = 0;
            txtSubTypHD.Visible = false;
            lblSubActivityType.Visible = false;
        }
    }
    protected void LinkEdit_Click(object sender, EventArgs e)
    {
        LinkButton Lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)Lnkbtn.Parent.Parent;
        int index = row.RowIndex;
        HDActivity.Value = ((Label)gvActivity.Rows[index].FindControl("Label1")).Text;
        DataTable DT = new DataTable();
        DT = objFun.FillDataTable("select ActivityNameID, ActivityTypeID, SubActivityID, SubActivityTypeID, FromDate, ToDate, FromTime, ToTime,ActivityHead,ActivityTypeHead,SubActivityHead from Academic_Calendar_Entry where AcademicID = '" + HDActivity.Value + "'");
        ddlActivity.SelectedIndex = ddlActivity.Items.IndexOf(ddlActivity.Items.FindByValue(DT.Rows[0].ItemArray[0].ToString()));
        {
            objFun.FillDropdownlist(ddlActivitytype, "Activity_Type_Name", "Activity_ID", "select * from ActivityType_Master2 where ActivityNameID = '" + DT.Rows[0].ItemArray[0].ToString() + "'", "--Select--");
            ddlActivitytype.Enabled = true;
        }
        ddlActivitytype.SelectedIndex = ddlActivitytype.Items.IndexOf(ddlActivitytype.Items.FindByValue(DT.Rows[0].ItemArray[1].ToString()));
        {
            objFun.FillDropdownlist(ddlSubAct, "SubActivity", "ActivityID", "select * from ActivityType_Master3 where ActivityTypeID = '" + DT.Rows[0].ItemArray[1].ToString() + "'", "--Select--");
            ddlSubAct.Enabled = true;
        }
        ddlSubAct.SelectedIndex = ddlSubAct.Items.IndexOf(ddlSubAct.Items.FindByValue(DT.Rows[0].ItemArray[2].ToString()));
        {
            objFun.FillDropdownlist(ddlSubActType, "SubActivityName", "SubActID", "select * from ActivityType_Master4 where SubActivityID = '" + DT.Rows[0].ItemArray[2].ToString() + "'", "--Select--");
        }
        ddlSubActType.SelectedIndex = ddlSubActType.Items.IndexOf(ddlSubActType.Items.FindByValue(DT.Rows[0].ItemArray[3].ToString()));      
       
        txtfrmDate.Text = Convert.ToDateTime(DT.Rows[0].ItemArray[4].ToString()).ToString("dd-MMM-yyyy");
        txttoDate.Text = Convert.ToDateTime(DT.Rows[0].ItemArray[5].ToString()).ToString("dd-MMM-yyyy");
        txtFromTime.Text = DT.Rows[0].ItemArray[6].ToString();
        txtToTime.Text = DT.Rows[0].ItemArray[7].ToString();
        txtempname.SelectedValue = DT.Rows[0].ItemArray[8].ToString();
        txtActHead.Text = gvActivity.Rows[index].Cells[9].Text.Replace("&nbsp;", " ");
        txtEmpname2.SelectedValue = DT.Rows[0].ItemArray[9].ToString();
        txtSubActHD.Text = gvActivity.Rows[index].Cells[10].Text.Replace("&nbsp;", " ");
        if (txtSubActHD.Text != " ")
        {
            Chksub.Checked = true;
            lblSub.Visible = true;
            lblSubActivity.Visible = true;
            ddlSubAct.Visible = true;
            txtSubActHD.Visible = true;
        }
        else
        {
            Chksub.Checked = false;
            lblSub.Visible = false;
            lblSubActivity.Visible = false;
            ddlSubAct.Visible = false;
            txtSubActHD.Visible = false; 
        }
        txtEmpname3.SelectedValue = DT.Rows[0].ItemArray[10].ToString();
        txtSubTypHD.Text = gvActivity.Rows[index].Cells[11].Text.Replace("&nbsp;", " ");
        if (txtSubTypHD.Text != " ")
        {
            ChksubAct.Checked = true;
            ChksubAct.Visible = true;
            lblSubActivityType.Visible = true;
            lblSubAct.Visible = true;
            ddlSubActType.Visible = true;
            txtSubTypHD.Visible = true;
        }
        else 
        {
            ChksubAct.Checked = false;
            ChksubAct.Visible = false;
            lblSubActivityType.Visible = false;
            lblSubAct.Visible = false;
            ddlSubActType.Visible = false;
            txtSubTypHD.Visible = false;
        
        }
        btnActivity.Text = "Update";
        btnDelete.Enabled = true;
        ddlActivitytype.Enabled = true;
        ddlSubAct.Enabled = true;
      
        
    }
    private static System.Collections.Generic.List<AutoSuggestMenuItem> GetMenuItemsFromDataReader(SqlDataReader reader, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = new System.Collections.Generic.List<AutoSuggestMenuItem>();
        string city = null;
        string cityCode = null;
        string label = null;
        AutoSuggestMenuItem menuItem = default(AutoSuggestMenuItem);
        int rowIndex = 0;
        int startRowIndex = 0;
        int endRowIndex = 0;
        if (usePaging)
        {
            startRowIndex = pageIndex * pageSize;
            endRowIndex = startRowIndex + pageSize;
        }
        while (reader.Read())
        {
            if (usePaging)
            {
                if (rowIndex < startRowIndex)
                {
                    rowIndex = rowIndex + 1;
                    continue;
                    if (rowIndex >= endRowIndex)
                    {
                        break;
                    }
                }
            }
            city = reader.GetValue(0).ToString();
            cityCode = reader.GetValue(1).ToString();
            label = city;
            menuItem = new AutoSuggestMenuItem();
            menuItem.Label = label;
            menuItem.Value = cityCode;
            menuItems.Add(menuItem);
            rowIndex = rowIndex + 1;
        }
        return menuItems;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]

    public static string GetSuggestions(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);

        cn.Open();
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            {

                sql = "SELECT empName,empId from Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active' order by empName";

            }
            {
                sql = "SELECT empName, empId from Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active' order by empName";
            }

        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            sql = "SELECT COUNT(*) FROM   Employee_Master where empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "FROM   Employee_Master where empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " empName,empId " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "SELECT  empName,empId " + sqlFromAndWhere_T + " order by empName";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging && pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        if (usePaging && pageIndex != 0)
        {
            sql = "SELECT COUNT(*) FROM   Employee_Master where  empName LIKE '" + skeyword.Replace("'", "''") + "%' and Status='Active'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "FROM   Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'order by empName";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " empName,empId  " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "SELECT  empName,empId  " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging && pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        cn.Close();
        return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults));
    }
  
    private static System.Collections.Generic.List<AutoSuggestMenuItem> GetMenuItemsFromDataReader1(SqlDataReader reader, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = new System.Collections.Generic.List<AutoSuggestMenuItem>();
        string city = null;
        string cityCode = null;
        string label = null;
        AutoSuggestMenuItem menuItem = default(AutoSuggestMenuItem);
        int rowIndex = 0;
        int startRowIndex = 0;
        int endRowIndex = 0;
        if (usePaging)
        {
            startRowIndex = pageIndex * pageSize;
            endRowIndex = startRowIndex + pageSize;
        }
        while (reader.Read())
        {
            if (usePaging)
            {
                if (rowIndex < startRowIndex)
                {
                    rowIndex = rowIndex + 1;
                    continue;
                    if (rowIndex >= endRowIndex)
                    {
                        break;
                    }
                }
            }
            city = reader.GetValue(0).ToString();
            cityCode = reader.GetValue(1).ToString();
            label = city;
            menuItem = new AutoSuggestMenuItem();
            menuItem.Label = label;
            menuItem.Value = cityCode;
            menuItems.Add(menuItem);
            rowIndex = rowIndex + 1;
        }
        return menuItems;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]

    public static string GetSuggestions1(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems1 = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);

        cn.Open();
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            {

                sql = "SELECT empName,empId from Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active' order by empName";

            }
            {
                sql = "SELECT empName, empId from Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active' order by empName";
            }

        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader1 = cmd.ExecuteReader();
        menuItems1 = GetMenuItemsFromDataReader(reader1, usePaging, pageIndex, pageSize);
        reader1.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            sql = "SELECT COUNT(*) FROM   Employee_Master where empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "FROM   Employee_Master where empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " empName,empId " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "SELECT  empName,empId " + sqlFromAndWhere_T + " order by empName";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems1 = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging && pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        if (usePaging && pageIndex != 0)
        {
            sql = "SELECT COUNT(*) FROM   Employee_Master where  empName LIKE '" + skeyword.Replace("'", "''") + "%' and Status='Active'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "FROM   Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'order by empName";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " empName,empId  " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "SELECT  empName,empId  " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems1 = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging && pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        cn.Close();
        return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems1, totalResults));
    }
   
    private static System.Collections.Generic.List<AutoSuggestMenuItem> GetMenuItemsFromDataReader2(SqlDataReader reader, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = new System.Collections.Generic.List<AutoSuggestMenuItem>();
        string city = null;
        string cityCode = null;
        string label = null;
        AutoSuggestMenuItem menuItem = default(AutoSuggestMenuItem);
        int rowIndex = 0;
        int startRowIndex = 0;
        int endRowIndex = 0;
        if (usePaging)
        {
            startRowIndex = pageIndex * pageSize;
            endRowIndex = startRowIndex + pageSize;
        }
        while (reader.Read())
        {
            if (usePaging)
            {
                if (rowIndex < startRowIndex)
                {
                    rowIndex = rowIndex + 1;
                    continue;
                    if (rowIndex >= endRowIndex)
                    {
                        break;
                    }
                }
            }
            city = reader.GetValue(0).ToString();
            cityCode = reader.GetValue(1).ToString();
            label = city;
            menuItem = new AutoSuggestMenuItem();
            menuItem.Label = label;
            menuItem.Value = cityCode;
            menuItems.Add(menuItem);
            rowIndex = rowIndex + 1;
        }
        return menuItems;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]

    public static string GetSuggestions2(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems1 = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);

        cn.Open();
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            {

                sql = "SELECT empName,empId from Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active' order by empName";

            }
            {
                sql = "SELECT empName, empId from Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active' order by empName";
            }

        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader1 = cmd.ExecuteReader();
        menuItems1 = GetMenuItemsFromDataReader(reader1, usePaging, pageIndex, pageSize);
        reader1.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            sql = "SELECT COUNT(*) FROM   Employee_Master where empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "FROM   Employee_Master where empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " empName,empId " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "SELECT  empName,empId " + sqlFromAndWhere_T + " order by empName";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems1 = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging && pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        if (usePaging && pageIndex != 0)
        {
            sql = "SELECT COUNT(*) FROM   Employee_Master where  empName LIKE '" + skeyword.Replace("'", "''") + "%' and Status='Active'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "FROM   Employee_Master where  empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and Status='Active'order by empName";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " empName,empId  " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "SELECT  empName,empId  " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems1 = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging && pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        cn.Close();
        return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems1, totalResults));
    }    

    protected void txtfrmDate_TextChanged(object sender, EventArgs e)
    {
        DataTable DT1 = new DataTable();
        DT1 = objFun.FillDataTable("select AcademicID from Academic_Calendar_Entry where FromDate <= '" + Convert.ToDateTime(txtfrmDate.Text) + "' and ToDate >= '"+ Convert.ToDateTime(txtfrmDate.Text)+"'");
        if (DT1.Rows.Count > 0)
        {           
            this.ModalPopupExtender1.Show();        
        }     
       
    }
    protected void txttoDate_TextChanged(object sender, EventArgs e)
    {
        DataTable DT2 = new DataTable();
        DT2 = objFun.FillDataTable("select AcademicID from Academic_Calendar_Entry where ToDate = '" + Convert.ToDateTime(txttoDate.Text) + "'");
        if (DT2.Rows.Count > 0)
        {          
            this.ModalPopupExtender2.Show();
        }  
    }   
    protected void btnNo_Click(object sender, EventArgs e)
    {
        txtfrmDate.Text = "";
    }

  protected void  Button2_Click1(object sender, EventArgs e)
    {
     txttoDate.Text = "";
    }
}
