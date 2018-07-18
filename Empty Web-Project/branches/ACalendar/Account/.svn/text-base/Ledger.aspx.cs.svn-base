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
using MSS;
using System.Data.OleDb;
using System.Web.Services;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using NewDAL;
using System.Data.SqlClient;

public partial class Account_Ledger : System.Web.UI.Page
{
    DbFunctions objFunc = new DbFunctions();
    public static string opt = "M";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["U_Name"] == null)
        {
            Response.Redirect("~/LogIn_Home.aspx");
            return;
        }
        if (!IsPostBack)
        {
            this.hdcontp.Value = Request.QueryString["p"];
            this.hduid.Value = Request.QueryString["uid"];
            RdbStEmp.Enabled = false;
            opt = "M";
            txtLname.Visible = false;
            txtMname.Visible = true;
            Label1.Visible = false;
            txtSearch.Visible = false;

        }

    }
    [WebMethod()]
    public static string GetSuggestions(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        cn.Open();
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            sql = "Select distinct top 10 Group_Name,Group_ID from Groups where group_id not in(1) and Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by Group_Name";
        }
        else
        {
            sql = "Select distinct top 10 Group_Name,Group_ID from Groups where group_id not in(1) and Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by Group_Name";
        }
        if (sql == null)
            return "";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging & pageIndex == 0)
        {
            sql = "SELECT COUNT(*) from Groups where  group_id not in(1) and Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Groups where group_id not in(1) and Group_Name LIKE '%'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " Group_Name,Group_ID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct Group_Name,Group_ID " + sqlFromAndWhere_T + " order by Group_Name";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        if (usePaging & pageIndex != 0)
        {
            sql = "SELECT COUNT(*) from Groups where group_id not in(1) and Group_Name LIKE '" + skeyword.Replace("'", "''") + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Groups where group_id not in(1) and Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by Group_Name";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " Group_Name ,Group_ID " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "select distinct Group_Name,Group_ID " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        cn.Close();
        return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults));
    }
    [WebMethod()]
    public static string GetSuggestions1(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        cn.Open();
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where  LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerNAme";
        }
        else
        {
            sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
        }
        if (sql == null)
            return "";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging & pageIndex == 0)
        {
            sql = "SELECT COUNT(*) from Ledger where   LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Ledger where LedgerName LIKE '%'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName,LedgerID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + " order by LedgerName";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        if (usePaging & pageIndex != 0)
        {
            sql = "SELECT COUNT(*) from Ledger where  LedgerName LIKE '" + skeyword.Replace("'", "''") + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Ledger where LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName ,LEdgerID " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        cn.Close();
        return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults));
    }

    private static System.Collections.Generic.List<AutoSuggestMenuItem> GetMenuItemsFromDataReader(SqlDataReader reader, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = new System.Collections.Generic.List<AutoSuggestMenuItem>();
        string city = null;
        string cityCode = null;
        string label = null;
        AutoSuggestMenuItem menuItem = default(AutoSuggestMenuItem);
        int rowIndex = 0;
        //Handle paging 
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
                        break; // TODO: might not be correct. Was : Exit While 
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

    protected void optSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        RdbStEmp.Items[3].Selected = true;
        if (optSelect.Items[0].Selected == true)
        {
            cmdReset_Click(sender, e);
            cmdSubmit.Enabled = true;
             Label1.Visible = false;
            txtSearch.Visible = false;
            hdType.Value = "0";
            RdbStEmp.Enabled = true;
            RdbStEmp.Focus();
        }

        else if (optSelect.Items[1].Selected == true)
        {
            cmdReset_Click(sender, e);
            cmdSubmit.Enabled = false;
            hdType.Value = "0";
             Label1.Visible = true;
            txtSearch.Visible = true;
            RdbStEmp.Enabled = false;
            txtSearch.Focus();
        }

        else if (optSelect.Items[2].Selected == true)
        {
            cmdReset_Click(sender, e);
            cmdSubmit.Enabled = true;
             Label1.Visible = true;
            txtSearch.Visible = true;
            hdType.Value = "1";
            RdbStEmp.Enabled = false;
            txtSearch.Focus();


        }
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        objDB.BeginTransaction();

        String Ledger_Name = String.Empty;
        String Ledger_N = String.Empty;
        objDB.CreateParameters(18);
        string ledgerName = "";
        if (opt == "M" || opt == "")
        {
            ledgerName = txtMname.Text.Trim();
        }
        else
        {
            ledgerName = txtLname.Text.Trim();
        }
        if (ledgerName.Trim() == String.Empty)
        {
            objFunc.MsgBox("Please enter Ledger name.", this);
            return;
        }
        if (hdType.Value == "0")
        {
            Ledger_Name = objFunc.Get_details("Select LedgerID from Ledger where LedgerName='" + ledgerName.Trim() + "'");
            LedgerID();
            if (txtAbr.Text != "")
            {
                Ledger_N = objFunc.Get_details("Select LedgerID from Ledger where Alias='" + txtAbr.Text.ToString().Trim() + "'");
            }
        }
        if (Ledger_Name.ToString() != String.Empty || Ledger_N.ToString() != String.Empty)
        {
            objFunc.MsgBox("Already Exits", this);
            return;

        }
        if (txtUnder.Text == String.Empty)
        {
            objFunc.MsgBox("Select Under Group Name.", this);
            return;
        }
        if (hdType.Value == "0")
            objDB.AddParameters(0, "LedgerID", Int32.Parse(hdLedger_id.Value), DbType.Int32);
        else
            objDB.AddParameters(0, "LedgerID", Int32.Parse(asmStudent1.SelectedValue.Replace(",", "")), DbType.Int32);
        objDB.AddParameters(1, "LedgerName", ledgerName, DbType.String);
        objDB.AddParameters(2, "Alias", txtAbr.Text.ToString(), DbType.String);
        objDB.AddParameters(3, "Under_Group", Int32.Parse(asmStudent0.SelectedValue.Replace(",", "").Trim()), DbType.Int32);
        //if (txtOpBal.Text.ToString() == String.Empty)
        //    objDB.AddParameters(4, "Opening_Blnc", 0.000, DbType.Decimal);
        //else
        objDB.AddParameters(4, "Opening_Blnc", Convert.ToDecimal(txtOpBal.Text.ToString()), DbType.Decimal);
        objDB.AddParameters(5, "Cr_Dr", optCr.SelectedValue.ToString(), DbType.String);
        objDB.AddParameters(6, "Date", Convert.ToDateTime("1-Apr-2009"), DbType.DateTime);
        objDB.AddParameters(7, "Name", txtName.Text.ToString(), DbType.String);
        objDB.AddParameters(8, "Address", txtAdd.Text.ToString(), DbType.String);
        objDB.AddParameters(9, "Incom_Tax_No", txtITN.Text.ToString(), DbType.String);
        objDB.AddParameters(10, "Sale_Tax", txtSTN.Text.ToString(), DbType.String);
        objDB.AddParameters(11, "State", txtState.Text.ToString(), DbType.String);
        objDB.AddParameters(12, "Pincode", txtPinCode.Text.ToString(), DbType.String);
        objDB.AddParameters(13, "AccountNo", txtPinCode.Text.ToString(), DbType.String);
        if (RdbStEmp.Items[0].Selected == true)
            objDB.AddParameters(14, "Type", "S", DbType.String);
        else if (RdbStEmp.Items[1].Selected == true)
            objDB.AddParameters(14, "Type", "E", DbType.String);
        else
            objDB.AddParameters(14, "Type", "-", DbType.String);
        objDB.AddParameters(15, "Inst_ID", Int32.Parse(Session["instID"].ToString()), DbType.Int32);
        if (RdbStEmp.Items[0].Selected == true || RdbStEmp.Items[1].Selected == true)
            objDB.AddParameters(16, "emp_Stu_id", Int32.Parse(asmStudent2.SelectedValue), DbType.Int32);
        else
            objDB.AddParameters(16, "emp_Stu_id", 0, DbType.Int32);
        if (hdType.Value == "0")
        {
            objDB.AddParameters(17, "flag", "N", DbType.String);
        }
        else if (hdType.Value == "1")
        {
            objDB.AddParameters(17, "flag", "U", DbType.String);
        }
         

        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Ledger");
        objDB.Transaction.Commit();
        objFunc.MsgBox("Record saved successfully.", this);

        objDB.Close();
        Reset();
        hdType.Value = "0";
    }
    private void LedgerID()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        string D;
        Int32 Ledg_ID = 0;
        D = objFunc.Get_details("select Max(LedgerID) from Ledger");
        if (D == "")
        {
            Ledg_ID = 1;
        }
        else
        {
            Ledg_ID = Int32.Parse(D) + 1;
        }
        hdLedger_id.Value = Ledg_ID.ToString();
        objDB.Connection.Close();
    }
    public void Reset()
    {
        txtAbr.Text = String.Empty;
        txtAdd.Text = String.Empty;
        txtITN.Text = String.Empty;
        txtLname.Text = String.Empty;
        txtName.Text = String.Empty;
        txtOpBal.Text = "0.00";
        txtPinCode.Text = String.Empty;
        txtState.Text = String.Empty;
        txtSTN.Text = String.Empty;
        txtUnder.Text = String.Empty;
         opt = String.Empty;
        RdbStEmp.Items[0].Selected = false;
        RdbStEmp.Items[1].Selected = false;
        txtSearch.Text = String.Empty;

        optCr.Items[0].Selected = false;
        optCr.Items[1].Selected = false;
        Label1.Visible = false;
        txtSearch.Visible = false;
        lblGrpNature.Text = String.Empty;
        txtAccNo.Text = String.Empty;
        txtMname.Text = string.Empty;
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void cmdsearch_Click(object sender, EventArgs e)
    {
        if (opt == "S")
        {
            return;
        }

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.Text, "select * from Ledger where LedgerID='" + asmStudent1.SelectedValue.Replace(",", "").Trim() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            //for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            //{
            txtLname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtMname.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtAbr.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            asmStudent0.SelectedValue = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtOpBal.Text = decimal.Parse(ds.Tables[0].Rows[0].ItemArray[4].ToString()).ToString("00.00").ToString();
            if (ds.Tables[0].Rows[0].ItemArray[5].ToString().Trim() == "Cr")
            {
                optCr.Items[0].Selected = true;
                optCr.Items[1].Selected = false;
            }
            else
            {
                optCr.Items[0].Selected = false;
                optCr.Items[1].Selected = true;
            }
            txtName.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txtAdd.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            txtITN.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            txtSTN.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            txtState.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            txtPinCode.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            txtAccNo.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            DataSet ds1 = new DataSet();
            if (ds.Tables[0].Rows[0].ItemArray[14].ToString() == "S")
            {
                RdbStEmp.Items[0].Selected = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[14].ToString() == "E")
            {
                RdbStEmp.Items[1].Selected = true;
            }
            if (ds.Tables[0].Rows[0].ItemArray[14].ToString() == "-")
            {
                RdbStEmp.Items[3].Selected = true;
            }
            ds1 = objDB.ExecuteDataSet(CommandType.Text, "select Group_Name,undergroupname from UnderGroupList where Group_ID='" + asmStudent0.SelectedValue + "'");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtUnder.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                lblGrpNature.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            // }
            if (optSelect.Items[1].Selected == true)
            {
                cmdSubmit.Enabled = false;

            }
        }
        else
        {
            objFunc.MsgBox("No Record Found.", this);

        }
    }
    [WebMethod()]
    public static string GetSuggestions2(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        cn.Open();
        string sql = null;
        if (opt.ToString() == "M")
        {
            return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, 0));

        }
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            if (opt.ToString() == "S")
                sql = "Select distinct top 10 StudentName+ ''+MName+' '+ Lname as Name,StudentID from Student_Registration where  StudentName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'order by Name";
            else if (opt.ToString() == "E")
                sql = "Select distinct top 10 empName+ ''+lastName as Name,empId from employee_master where  empname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'order by Name";

        }
        else
        {
            if (opt.ToString() == "S")
                sql = "Select distinct top 10 StudentName+ ''+MName+' '+ Lname as Name,StudentID from Student_Registration StudentName Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'order by Name";
            else if (opt.ToString() == "E")
                sql = "Select distinct top 10 empName+ ''+lastName as Name,empId from employee_master where  empname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'order by Name";
        }

        SqlCommand cmd = new SqlCommand(sql, cn);
        if (sql == null)
            return "";
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            if (opt.ToString() == "S")
                sql = "SELECT COUNT(*) from Student_Registration where   StudentName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'";
            else if (opt.ToString() == "E")
                sql = "SELECT COUNT(*) from employee_master where   empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "";
                if (opt.ToString() == "S")
                    sqlFromAndWhere_T = "from Student_Registration where StudentName LIKE '%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'";
                else if (opt.ToString() == "E")
                    sqlFromAndWhere_T = "from employee_master where empName LIKE '%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    if (opt.ToString() == "S")
                        sql_T = "select distinct top " + numItems + " StudentName+ ''+MName+' '+ Lname as Name,StudentID " + sqlFromAndWhere_T + " ";
                    else if (opt.ToString() == "E")
                        sql_T = "select distinct top " + numItems + " empName+ ''+lastName as Name,empID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    if (opt.ToString() == "S")
                        sql_T = "select distinct StudentName+ ''+MName+' '+ Lname as Name,StudentID " + sqlFromAndWhere_T + " order by Name";
                    else if (opt.ToString() == "E")
                        sql_T = "select distinct empName+ ''+lastName as Name,empID " + sqlFromAndWhere_T + " order by Name";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
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
            if (opt.ToString() == "S")
                sql = "SELECT COUNT(*) from Student_Registration where  StudentName LIKE '" + skeyword.Replace("'", "''") + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'";
            else if (opt.ToString() == "E")
                sql = "SELECT COUNT(*) from employee_master where  empName LIKE '" + skeyword.Replace("'", "''") + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "";
                if (opt.ToString() == "S")
                    sqlFromAndWhere_T = "from Student_Registration where   StudentName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "' order by Name";
                else if (opt.ToString() == "E")
                    sqlFromAndWhere_T = "from employee_master where   empName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' and InstituteID='" + HttpContext.Current.Session["instID"].ToString() + "' order by Name";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    if (opt.ToString() == "S")
                        sql_T = "select distinct top " + numItems + " StudentName+ ''+MName+' '+ Lname as Name ,StudentID " + sqlFromAndWhere_T + "";
                    else if (opt.ToString() == "E")
                        sql_T = "select distinct top " + numItems + " empName+ ''+lastName as Name ,empID " + sqlFromAndWhere_T + "";
                }
                else
                {
                    if (opt.ToString() == "S")
                        sql_T = "select distinct StudentName+ ''+MName+' '+ Lname as Name,StudentID " + sqlFromAndWhere_T + "";
                    else if (opt.ToString() == "E")
                        sql_T = "select distinct empName+ ''+LastName as Name,empID " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
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

    protected void RdbStEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        opt = "";
        if (RdbStEmp.Items[0].Selected == true)
        {
            opt = "S";
            txtLname.Visible = true;
            txtMname.Visible = false;
        }
        else if (RdbStEmp.Items[1].Selected == true)
        {
            opt = "E";
            txtMname.Visible = false;
            txtLname.Visible = true;
        }
        else if (RdbStEmp.Items[3].Selected == true)
        {
            txtLname.Visible = false;
            txtMname.Visible = true;
            opt = "M";
        }
    }
    protected void cmdsearch1_Click(object sender, EventArgs e)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.Text, "select Group_Name,undergroupname from UnderGroupList where Group_ID='" + asmStudent0.SelectedValue.Replace(",", "").Trim() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGrpNature.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
        objDB.Close();
    }
}
