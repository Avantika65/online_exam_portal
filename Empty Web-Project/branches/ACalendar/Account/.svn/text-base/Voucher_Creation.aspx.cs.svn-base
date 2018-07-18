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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
public partial class Account_Voucher_Creation : System.Web.UI.Page
{
    DbFunctions objFunc = new DbFunctions();
    static int drsum;
    static int crsum;
    static Int16  rdbl;
    static string yr;
    //static int idd;

    protected void Page_Load(object sender, EventArgs e)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        if (!IsPostBack)
        {
            DateTime date = DateTime.Now;
            txtDate.Text = date.ToString("dd-MMM-yyyy");
            cmdsearch.Enabled = true;
            cmdsearch1.Enabled = true;
            lblref.Visible = false;
            txtref.Visible = false;
            drsum = 0;
            crsum = 0;  
        }
         txtNo.ReadOnly = true;
         
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
            if (rdbl == 0)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='1' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 1)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='8' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 2)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='14' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }

            else if (rdbl == 3)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='6' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 4)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='2' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 5)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='3' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
        }
        else
        {
            if (rdbl == 0)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='1' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 1)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='8' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 2)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='14' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }

            else if (rdbl == 3)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='6' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 4)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='2' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            else if (rdbl == 5)
            {
                sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype='3' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
            }
            
        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging & pageIndex == 0)
        {
            if (rdbl == 0)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='1' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            else if (rdbl == 1)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='8' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            else if (rdbl == 2)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='14' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }

            else if (rdbl == 3)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='6' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            else if (rdbl == 4)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='2' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            else if (rdbl == 5)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='3' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T="";
                if (rdbl == 0)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='1' and vname LIKE '%'";
                }
                else if (rdbl == 1)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='8' and vname LIKE '%'";
                }
                else if (rdbl == 2)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='14' and vname LIKE '%'";
                }

                else if (rdbl == 3)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='6' and vname LIKE '%'";
                }
                else if (rdbl == 4)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='2' and vname LIKE '%'";
                }
                else if (rdbl == 5)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='3' and vname LIKE '%'";
                }
                
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " vname,vid " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "select distinct vname,vid " + sqlFromAndWhere_T + " order by vname";
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
            if (rdbl == 0)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='1' and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
            else if (rdbl == 1)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='8' and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
            else if (rdbl == 2)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='14' and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            }

            else if (rdbl == 3)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='6' and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
            else if (rdbl == 4)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='2' and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
            else if (rdbl == 5)
            {
                sql = "SELECT COUNT(*) from Voucher_Type where vtype='3' and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
            
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T="";
                if (rdbl == 0)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='1' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                }
                else if (rdbl == 1)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='8' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                }
                else if (rdbl == 2)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='14' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                }

                else if (rdbl == 3)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='6' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                }
                else if (rdbl == 4)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='2' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                }
                else if (rdbl == 5)
                {
                     sqlFromAndWhere_T = "from Voucher_Type where vtype='3' and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                }
                
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " vname ,vid " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct vname,vid " + sqlFromAndWhere_T + "";
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
        string ug = GetParentL("16,17,18", "");
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
            {
                
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where  Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }
          
            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in (2,4,5,6,7,12,15,22,23,25,27,30,31) or primary_Group in (select group_id from groups ) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }
           
            
        }
        else
        {
            if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }

            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in (2,4,5,6,7,12,15,22,23,25,27,30,31) or primary_Group in (select group_id from groups) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }
            
           
        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }

            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (2,4,5,6,7,12,15,22,23,25,27,30,31) or primary_Group in (select group_id from groups) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            
            
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "";
                if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '%'";
                }

                else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
                {
                    sqlFromAndWhere_T = "from Ledger where   Under_Group in (2,4,5,6,7,12,15,22,23,25,27,30,31) or primary_Group in (select group_id from groups) and LedgerName LIKE '%'";
                }
               
                
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName,LedgerID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + "  order by LedgerName";
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
            if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + skeyword.Replace("'", "''") + "%'";
            }

            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (2,4,5,6,7,12,15,22,23,25,27,30,31) or primary_Group in (select group_id from groups) and LedgerName LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
           
            
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "";
                if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
                }

                else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (2,4,5,6,7,12,15,22,23,25,27,30,31) or primary_Group in (select group_id from groups) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
                }
               
                
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName ,LedgerID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + " ";
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
    public static string ug = "";
    public static string GetParentL(string group_id, string groupID)
    {
        string ugstore = group_id;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DbFunctions obj = new DbFunctions();
        DataTable dt = new DataTable();
        if (groupID == "")
        {
            dt = obj.FillDataTable("Select distinct group_id,under_group from groups where group_id in(" + group_id + ") or  under_group  in(" + group_id + ")");
        }
        else
        {
            dt = obj.FillDataTable("Select distinct under_group,group_id from groups where  under_group in(" + group_id + ") and under_group not in(" + group_id + ")");
        }
        if (dt.Rows.Count > 0)
        {
            
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                DataTable dt1 = new DataTable();
                //if (groupID == "")
                //{
                dt1 = obj.FillDataTable("Select distinct group_id from UnderGroupList where  pr in(" + dt.Rows[i].ItemArray[0].ToString() + ") ");
               // }
                //else
                //{
                //    dt1 = obj.FillDataTable("Select distinct group_id from groups where  under_group in(" + dt.Rows[i].ItemArray[1].ToString() + ")");
                //}
                int k;
                for (k = 0; k <= dt1.Rows.Count - 1; k++)
                {
                    if (groupID == "")
                    {
                        groupID = dt1.Rows[k].ItemArray[0].ToString();

                    }
                    else
                    {
                        groupID = groupID + "," + dt1.Rows[k].ItemArray[0].ToString();
                    }
                }
                if (groupID == "")
                {
                    if (dt.Rows[k].ItemArray[0].ToString() == "1")
                    {
                        groupID = dt.Rows[i].ItemArray[1].ToString();
                    }
                    else
                    {
                        groupID = dt.Rows[i].ItemArray[0].ToString();
                    }
                }
                else
                {
                    if (dt.Rows[i].ItemArray[0].ToString() == "1")
                    {
                        groupID = groupID + "," + dt.Rows[i].ItemArray[1].ToString();
                    }
                    else
                    {
                        groupID = groupID + "," + dt.Rows[i].ItemArray[0].ToString();
                    }
                }
            }
            ug = GetParentL(groupID, groupID);
            ug = groupID;
        }
        else
        {
            return groupID;
        }
        //objDB.DataReader = objDB.ExecuteReader(CommandType.Text, "select under_group from groups where group_id in(" + group_id + ")");

        return groupID;
    }
    [WebMethod()]
    public static string GetSuggestions3(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        cn.Open();
        string ug = GetParentL("16,17,18", "");
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            if (rdbl == 0)
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in ("+ ug +") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }
            else if ((rdbl == 1) || (rdbl == 2))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group not in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";

            }
            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in (4,5,6,7,12,15,22,23,25,27,30,31,41,54) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }


        }
        else
        {
            if (rdbl == 0)
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }
            else if ((rdbl == 1) || (rdbl == 2))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group not in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";

            }
            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where Under_Group in (4,5,6,7,12,15,22,23,25,27,30,31) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
            }


        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            if (rdbl == 0)
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }
            else if ((rdbl == 1) || (rdbl == 2))
            {
                sql = "Select COUNT(*)   from Ledger where Under_Group not in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";

            }
            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (4,5,6,7,12,15,22,23,25,27,30,31) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            }


            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "";
                if (rdbl == 0)
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '%'";
                }
                else if ((rdbl == 1) || (rdbl == 2))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group not in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";

                }
                else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (4,5,6,7,12,15,22,23,25,27,30,31) and LedgerName LIKE '%'";
                }


                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName,LedgerID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + "  order by LedgerName";
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
            if (rdbl == 0) 
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + skeyword.Replace("'", "''") + "%'";
            }
            else if ((rdbl == 1) || (rdbl == 2))
            {
                sql = "Select COUNT(*)  from Ledger where Under_Group not in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";

            }
            else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
            {
                sql = "SELECT COUNT(*) from Ledger where Under_Group in (4,5,6,7,12,15,22,23,25,27,30,31) and LedgerName LIKE '" + skeyword.Replace("'", "''") + "%'";
            }


            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "";
                if (rdbl == 0)
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
                }
                else if ((rdbl == 1) || (rdbl == 2))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group not in (" + ug + ") and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";

                }
                else if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
                {
                    sqlFromAndWhere_T = "from Ledger where Under_Group in (4,5,6,7,12,15,22,23,25,27,30,31) and LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
                }


                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName ,LedgerID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + " ";
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

    private DataTable Voucher
    {
        get
        {
            DataTable dt = (DataTable)ViewState["Vouc"];

            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("Sno", typeof(string)));
                dt.Columns.Add(new DataColumn("Pid", typeof(string)));
                dt.Columns.Add(new DataColumn("Part", typeof(string)));
                dt.Columns.Add(new DataColumn("PAmt", typeof(string)));
                dt.Columns.Add(new DataColumn("DrCr", typeof(string)));
                dt.Columns.Add(new DataColumn("GAmt", typeof(string)));
                dt.Columns.Add(new DataColumn("Tot", typeof(string)));
                dt.Columns.Add(new DataColumn("CR", typeof(string)));
                dt.Columns.Add(new DataColumn("Raccount", typeof(string)));
                Voucher = dt;
            }

            return dt;
        }
        set
        {
            ViewState["Vouc"] = value;
        }
    }

    private DataTable VoucherD
    {
        get
        {
            DataTable dt = (DataTable)ViewState["VoucD"];
            return dt;
        }
        set
        {
            ViewState["VoucD"] = value;
        }
    }

    private DataTable VoucherType
    {
        get
        {
            DataTable dt = (DataTable)ViewState["VoucType"];

            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("Sno", typeof(string)));
                dt.Columns.Add(new DataColumn("Pid", typeof(string)));
                dt.Columns.Add(new DataColumn("Part", typeof(string)));
                dt.Columns.Add(new DataColumn("PAmt", typeof(string)));
                dt.Columns.Add(new DataColumn("DrCr", typeof(string)));
                dt.Columns.Add(new DataColumn("Debit", typeof(string)));
                dt.Columns.Add(new DataColumn("Credit", typeof(string)));
                //dt.Columns.Add(new DataColumn("DrTot", typeof(string)));
                //dt.Columns.Add(new DataColumn("CrTot", typeof(string)));
                //dt.Rows.Add(new DataColumn("Credit", typeof(string)));
                VoucherType = dt;
            }

            return dt;
        }
        set
        {
            ViewState["VoucType"] = value;
        }
    }

    protected void optSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        rdbl =Int16.Parse(optSelect.SelectedValue);
        hdvoutype.Value = rdbl.ToString();
       
        if((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
        {
            lblacc.Visible = true;
            txtacc.Visible = true;
            lblcbal.Visible = true;
            lblcurrbal.Visible = true;
            lblCr.Visible = true;
            lblref.Visible = false;
            txtref.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            ddlTtype.Visible = true;

        }
        else
        {
            if (rdbl == 3)
            {
                lblref.Visible = false;
                txtref.Visible = false;
                rdblto.Items[0].Selected = true;
                txtdr.Enabled = true;
                txtcr.Enabled = false;
                ddlTtype.Visible = false;
                if (grdjour.Rows.Count <= 0)
                {         
                    rdblto.Items[1].Enabled = false;
                    txtcr.Enabled = false;
                }
            }
            else 
            {
                if (rdbl == 4)
                {
                    if (grdjour.Rows.Count <= 0)
                    {
                        rdblto.Items[0].Enabled = false;
                    }
                }
                else if(rdbl == 5)
                {
                    if (grdjour.Rows.Count <= 0)
                    {
                        rdblto.Items[1].Enabled = false;
                    }
                }
                lblref.Visible = true;
                txtref.Visible = true;
            }
            lblacc.Visible = false;
            txtacc.Visible = false;
            lblcbal.Visible = false;
            lblcurrbal.Visible = false;
            lblCr.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        //else if ((rdbl == 4) || (rdbl == 5))
        //{ 
        
        //}
       // lblacc.Visible = false;
       // txtacc.Visible = false;
        //lblcbal.Visible = false;
        //lblcurrbal.Visible = false;
       // lblCr.Visible = false;
    }
    private string  GetParent(string group_id,string groupID)
    {
        string parentid = "";
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        if (group_id == "1")
        {
            return groupID;
        }
        objDB.DataReader = objDB.ExecuteReader(CommandType.Text, "select under_group from groups where group_id='" + group_id + "'");
        while (objDB.DataReader.Read())
        {
            if (objDB.DataReader.GetValue(0).ToString() == "4")
            {
                parentid = "4";
                return parentid;
            }
            if (objDB.DataReader.GetValue(0).ToString() == "29")
            {
                parentid = "29";
                return parentid;
            }
            if (objDB.DataReader.GetValue(0).ToString() == "30")
            {
                parentid = "30";
                return parentid;
            }
            if (parentid == "")
            {
                
                parentid = GetParent(objDB.DataReader.GetValue(0).ToString(),group_id);
                if (parentid != "")
                {
                    return parentid;
                }
            }
        }
        return parentid;
    }
    private void Voucher_Tables()
    {
        if (grdcon.Rows.Count == 0)
        {
            objFunc.MsgBox1("No transaction found to save.", UpdatePanel1);
            return;
        }
        string vno = objFunc.Get_details("select max(voucherID)+1 from Voucher_Summary");
        if (vno == "")
        {
            vno = "0";
        }
        vno = (Convert.ToInt32(vno) + 1).ToString();
        AccountDAL objac = new AccountDAL();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        try
        {
            TextBox txttotaldr;
            TextBox txttotalcr;
            txttotaldr =(TextBox) grdcon.FooterRow.FindControl("txtTotalDR");
            txttotalcr =(TextBox) grdcon.FooterRow.FindControl("txtTotalCR");

            objac.ExecuteAccChild(Int32.Parse(vno),1, Int32.Parse(asmStudent0.SelectedValue),decimal.Parse( txttotaldr.Text) , Convert.ToDateTime(txtDate.Text), txtnarr.Text, Session["sesnid"].ToString(), Int32.Parse(Session["instid"].ToString()), "", "", "", "", "N", objDB);
            for (int i = 0; i <= grdcon.Rows.Count - 1; i++)
            {
                Label lblgamt;
                decimal cr = 0;
                decimal dr = 0;
                lblgamt = (Label)grdcon.Rows[i].FindControl("lblgamt");
                if (lblgamt.Text != "")
                {
                    dr = decimal.Parse(lblgamt.Text.ToString());
                }
                Label lblCamt;
                lblCamt = (Label)grdcon.Rows[i].FindControl("lblCamt");
                if (lblCamt.Text != "")
                {
                    cr = decimal.Parse(lblCamt.Text.ToString());
                }

                objac.ExecuteAccMaster(Int32.Parse(vno), Int32.Parse(vno), Int32.Parse(grdcon.DataKeys[i].Values[0].ToString()), dr, cr, Int32.Parse(grdcon.DataKeys[i].Values[1].ToString()), Convert.ToDateTime(txtDate.Text), txtnarr.Text, "", Int32.Parse(Session["instid"].ToString()), Session["sesnid"].ToString(), "Voucher", "Voucher", "N", objDB);
            }

            objDB.Transaction.Commit();
            objFunc.MsgBox1("Record Saved.", UpdatePanel1);
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            objFunc.MsgBox1(ex.Message.ToString(), UpdatePanel1);
        }
    }
    private void Voucher_Tablesold()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        DateTime dt = Convert.ToDateTime(txtDate.Text);
        string mnth = dt.ToString("MMM");
        string yr = dt.Year.ToString();

        objDB.BeginTransaction();
        try
        {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "vid", 0, DbType.Int32);
                objDB.AddParameters(1, "vtype", asmStudent0.SelectedValue, DbType.Int32);
                objDB.AddParameters(2, "vno", txtNo.Text, DbType.String);
                objDB.AddParameters(3, "account", Int32.Parse(asmStudent1.SelectedValue), DbType.Int32);
                objDB.AddParameters(4, "currbalnc", Double.Parse(lblcurrbal.Text), DbType.Double);
                objDB.AddParameters(5, "drcr", lblCr.Text, DbType.String);
                objDB.AddParameters(6, "vcdate", Convert.ToDateTime(txtDate.Text), DbType.DateTime);
                objDB.AddParameters(7, "vcmonth", mnth, DbType.String);
                objDB.AddParameters(8, "vcyear", yr, DbType.Int32);
                objDB.AddParameters(9, "tot", 0, DbType.Decimal);
                string type = "";
                if (optSelect.Items[0].Selected == true || optSelect.Items[2].Selected == true)
                {
                    type = "Dr";
                }
                else if (optSelect.Items[1].Selected == true)
                {
                    type = "Cr";
                }
                objDB.AddParameters(10, "type", type , DbType.String);
                objDB.AddParameters(11, "InstId", Convert.ToInt32(Session["instID"]), DbType.Int32);
                objDB.AddParameters(12, "SessionId", Session["sesnID"].ToString(), DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VCreation");
              
                int i;
                for (i = 0; i <= grdcon.Rows.Count - 1; i++)
                {
                    objDB.CreateParameters(18);
                    string part = ((System.Web.UI.WebControls.LinkButton)grdcon.Rows[i].FindControl("lnkpart")).Text;
                    string pid = ((System.Web.UI.WebControls.Label)grdcon.Rows[i].FindControl("lblpid")).Text;
                    string pamt = ((System.Web.UI.WebControls.Label)grdcon.Rows[i].FindControl("lblpamt")).Text;
                    string drcr = ((System.Web.UI.WebControls.Label)grdcon.Rows[i].FindControl("lbldrcr")).Text;
                    string gamt = ((System.Web.UI.WebControls.Label)grdcon.Rows[i].FindControl("lblgamt")).Text;
                    objDB.AddParameters(0, "vcid", 0, DbType.Int32);
                    objDB.AddParameters(1, "particulars", pid, DbType.String);
                    objDB.AddParameters(2, "pamt", Convert.ToDouble(pamt), DbType.Double);
                    objDB.AddParameters(3, "pdrcr", lblCrDr.Text, DbType.String);
                    objDB.AddParameters(4, "amt", Convert.ToDouble(gamt), DbType.Double);
                    objDB.AddParameters(5, "adrcr", drcr, DbType.String);
                    objDB.AddParameters(6, "billwise", hdParent.Value, DbType.Int32);
                    objDB.AddParameters(7, "vctdate", Convert.ToDateTime(txtDate.Text), DbType.DateTime);
                    objDB.AddParameters(8, "narration", txtnarr.Text, DbType.String);
                    if (optSelect.Items[0].Selected == true || optSelect.Items[2].Selected == true)
                    {
                        type = "Cr";
                    }
                    else if (optSelect.Items[1].Selected == true)
                    {
                        type = "Dr";
                    }
                    objDB.AddParameters(9, "type", type, DbType.String);
                    objDB.AddParameters(10, "vtype", asmStudent0.SelectedValue, DbType.Int32);
                    objDB.AddParameters(11, "vno", txtNo.Text, DbType.String);
                    objDB.AddParameters(12, "InstId", Convert.ToInt32(Session["instID"]), DbType.Int32);
                    objDB.AddParameters(13, "SessionId", Session["sesnID"].ToString(), DbType.String);
                    objDB.AddParameters(14, "refno", "", DbType.String);
                    objDB.AddParameters(15, "refmode", asmStudent0.SelectedValue, DbType.String);
                    objDB.AddParameters(16, "reftype", "Journal", DbType.String);
                    objDB.AddParameters(17, "refid", "", DbType.String);
                    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VTCreation");
                    GridView grv;
                    grv = (GridView)grdcon.Rows[i].FindControl("GridView1");
                    int k;
                    for (k = 0; k <= grv.Rows.Count - 1; k++)
                    {
                        objDB.CreateParameters(6);
                        objDB.AddParameters(0, "vcid", 0, DbType.Int32);
                        objDB.AddParameters(1, "part", grv.DataKeys[i].Value.ToString(), DbType.String);
                        objDB.AddParameters(2, "ref", grv.Rows[k].Cells[0].Text.ToString(), DbType.String);
                        objDB.AddParameters(3, "amt", Convert.ToDouble(grv.Rows[k].Cells[1].Text.ToString()), DbType.Double);
                        objDB.AddParameters(4, "drcr", grv.Rows[k].Cells[2].Text.ToString(), DbType.String);
                        objDB.AddParameters(5, "bdate", Convert.ToDateTime(txtDate.Text), DbType.DateTime);
                        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Billwise");
                    }
            }
                    objDB.Transaction.Commit();
                    objFunc.MsgBox("Record saved successfully.", this);
                    //idd = 0;
                    reset();
        }

        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            objFunc.MsgBox(ex.Message.ToString(), this);
        }
    }


    private void Journal_Table()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        //string qry = "select max(vid) from Vouc_Creation";
        //object vid;
        //vid = objDB.ExecuteScalar(CommandType.Text, qry);
        //if (vid == DBNull.Value)
        //{
        //    vid = 0;
        //}
        //int idd = Convert.ToInt32(vid) + 1;

        DateTime dt = Convert.ToDateTime(txtDate.Text);
        string mnth = dt.ToString("MMM");
        string yr = dt.Year.ToString();

        objDB.BeginTransaction();

        try
        {
            int i;
            for (i = 0; i <= grdjour.Rows.Count - 1; i++)
            {

                string part = ((System.Web.UI.WebControls.LinkButton)grdjour.Rows[i].FindControl("lnkpart")).Text;
                string pid = ((System.Web.UI.WebControls.Label)grdjour.Rows[i].FindControl("lbljpid")).Text;
                string pamt = ((System.Web.UI.WebControls.Label)grdjour.Rows[i].FindControl("lbljamt")).Text;
                string drcr = ((System.Web.UI.WebControls.Label)grdjour.Rows[i].FindControl("lbljdrcr")).Text;
                string debit = ((System.Web.UI.WebControls.Label)grdjour.Rows[i].FindControl("lbldr")).Text;
                string credit = ((System.Web.UI.WebControls.Label)grdjour.Rows[i].FindControl("lblcr")).Text;
                string var = "";
                string amt = "";
                if (credit == "")
                {
                    amt = debit;
                    var = "Dr";
                }
                else if (debit == "")
                {
                    amt = credit;
                    var = "Cr";
                }
                //string type = "";
                if (debit != "")
                {
                    objDB.CreateParameters(13);
                    objDB.AddParameters(0, "vid", 0, DbType.Int32);
                    objDB.AddParameters(1, "vtype", asmStudent0.SelectedValue, DbType.Int32);
                    objDB.AddParameters(2, "vno", txtNo.Text, DbType.String);
                    objDB.AddParameters(3, "account", Int32.Parse(pid), DbType.Int32);
                    objDB.AddParameters(4, "currbalnc", Double.Parse(pamt), DbType.Double);
                    objDB.AddParameters(5, "drcr", drcr, DbType.String);
                    objDB.AddParameters(6, "vcdate", Convert.ToDateTime(txtDate.Text), DbType.DateTime);
                    objDB.AddParameters(7, "vcmonth", mnth, DbType.String);
                    objDB.AddParameters(8, "vcyear", yr, DbType.Int32);
                    objDB.AddParameters(9, "tot", Convert.ToDouble(amt), DbType.Double);
                    objDB.AddParameters(10, "type", "Dr" , DbType.String );
                    objDB.AddParameters(11, "InstId", Convert.ToInt32(Session["instID"]), DbType.Int32);
                    objDB.AddParameters(12, "SessionId", Session["sesnID"].ToString(), DbType.String);
                   
                    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VCreation1");
                }

                else if (credit != "")
                {
                    objDB.CreateParameters(18);
                    objDB.AddParameters(0, "vcid", 0, DbType.Int32);
                    objDB.AddParameters(1, "particulars", pid, DbType.String);
                    objDB.AddParameters(2, "pamt", Convert.ToDouble(pamt), DbType.Double);
                    objDB.AddParameters(3, "pdrcr", drcr, DbType.String);
                    objDB.AddParameters(4, "amt", Convert.ToDouble(amt), DbType.Double);
                    objDB.AddParameters(5, "adrcr", var, DbType.String);
                    objDB.AddParameters(6, "billwise", 0, DbType.Int32);
                    objDB.AddParameters(7, "vctdate", Convert.ToDateTime(txtDate.Text), DbType.DateTime);
                    objDB.AddParameters(8, "narration", txtnarr.Text, DbType.String);
                    objDB.AddParameters(9, "type", "Cr", DbType.String);
                    objDB.AddParameters(10, "vtype", asmStudent0.SelectedValue, DbType.Int32);
                    objDB.AddParameters(11, "vno", txtNo.Text, DbType.String);
                    objDB.AddParameters(12, "InstId", Convert.ToInt32(Session["InstID"]), DbType.Int32);
                    objDB.AddParameters(13, "SessionId", Session["sesnID"].ToString(), DbType.String);
                    objDB.AddParameters(14, "refno", "", DbType.String);
                    objDB.AddParameters(15, "refmode", 0, DbType.String);
                    objDB.AddParameters(16, "reftype", "Journal", DbType.String);
                    objDB.AddParameters(17, "refid", "", DbType.String);
                    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VTCreation1");
                }
            }
            objDB.Transaction.Commit();
            objFunc.MsgBox("Record saved successfully.", this);
            reset();
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            objFunc.MsgBox(ex.Message.ToString(), this);
        }
    }



    

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
        {
            Voucher_Tables();
            //reset();
        }
        else if ((rdbl == 3)|| (rdbl == 4) || (rdbl == 5))
        {
            if (drsum != crsum)
            {
                objFunc.MsgBox("Debit and Credit amount should be equal", this);
                return;
            }
            else
            {
                Journal_Table();
                //reset();
            }
        }
        if (txtNo.Text != "1")
        {
            int vno = Convert.ToInt32(objFunc.FetchScalar("select max(voucherID) from Voucher_Summary"));
            vno = Convert.ToInt32(vno) + 1;
            txtNo.Text = "V" + "-" + yr + "" + vno;
        }
       
    }


    protected void cmdReset_Click(object sender, EventArgs e)
    {
        reset();
    }
    private void reset()
    {
         txtvtype.Text = String.Empty;
        txtacc.Text = String.Empty;
         lblcurrbal.Text = String.Empty;
        lblCrDr.Text = String.Empty;
        txtamt.Text = String.Empty;
        rdblto.SelectedIndex = 0;
        cmdSubmit.Enabled = false;
        Panel1.Visible = true;
        Panel2.Visible = false;
        Voucher.Clear();
        VoucherType.Clear();
        grdcon.DataSource = null;
        grdcon.DataBind();
        grdjour.DataSource = null;
        grdjour.DataBind();
        drsum = 0;
        crsum = 0;
    }

    protected void cmdsearch_Click(object sender, EventArgs e)
    {
        if (optSelect.SelectedValue == "")
        {
            objFunc.MsgBox("Select Option", this);
            reset();
            return;
        }
        string chkvoucheroption = objFunc.Get_details("select method from voucher_type where vid='" + asmStudent0.SelectedValue + "'");
        if (chkvoucheroption == "Automatic")
        {
            string voucherNo = objFunc.Get_details("select prefil from voucher_type where vid='" + asmStudent0.SelectedValue + "'");
            string vno = objFunc.Get_details("select max(voucherID)+1 from voucher_summary");
            if (vno == "")
            {
                vno = "0";
            }
            vno = (Convert.ToInt32(vno) + 1).ToString();
            txtNo.Text = voucherNo + vno;
        }
        else
        {
            DateTime date1 = DateTime.Now.Date;
            yr = date1.Year.ToString();
            string vno = objFunc.Get_details("select max(voucherID)+1 from voucher_summary");
            if (vno == "")
            {
                vno = "0";
            }
            vno = (Convert.ToInt32(vno) + 1).ToString();
            txtNo.Text = "V" + "-" + yr + "" + vno;
        }
        if (lbljsno.Text == "")
        {
            lbljsno.Text = "1";
        }
        else
        {
            lbljsno.Text = (VoucherType.Rows.Count + 1).ToString();
        }

        btnjadd.Enabled = true;
        drsum = 0;
        crsum = 0;
        string eachnarration = objFunc.Get_details("Select enarration from voucher_type where vid='" + asmStudent0.SelectedValue + "'");
        hdNarreach.Value = eachnarration;
        string Printafter = objFunc.Get_details("Select afterprint from voucher_type where vid='" + asmStudent0.SelectedValue + "'");
        hdPrint.Value = Printafter;
    }
    private void Accountsearch()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        string query = "select Opening_Blnc,Cr_Dr from ledger where LedgerID='" + asmStudent1.SelectedValue + "';select sum(AmountDR) as dr,sum(AmountCR) as cr from voucher_transaction where AccountID='" + asmStudent1.SelectedValue + "'";
        SqlDataReader  dr = null;
        dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, query);
        decimal opBal = 0;
        string mod = null;
        string retVal = null;
        if (dr.Read())
        {
            opBal = decimal.Parse(dr["Opening_Blnc"].ToString());
            mod = dr["Cr_Dr"].ToString();
            dr.NextResult();
            if (dr.Read())
            {
                decimal totDrAmt = opBal + decimal.Parse((dr["dr"] != DBNull.Value) ? dr["dr"].ToString() : "0");
                decimal totCrAmt = decimal.Parse((dr["cr"] != DBNull.Value) ? dr["cr"].ToString() : "0");
                
                if ((totDrAmt - totCrAmt) > 0)
                {
                    lblCr.Text = "Dr";
                    lblcurrbal.Text = (totDrAmt - totCrAmt).ToString();
                }
                else if ((totDrAmt - totCrAmt) < 0)
                {
                    lblCr.Text = "Cr";
                    lblcurrbal.Text = (totCrAmt - totDrAmt).ToString();
                }
                else
                {
                    lblCr.Text = mod;
                    lblcurrbal.Text = "0";
                }
            }
        }
    }
    protected void cmdsearch1_Click(object sender, EventArgs e)
    {
        Accountsearch();
        if ((rdbl == 0) || (rdbl == 1) || (rdbl == 2))
        {
            if (lblsno.Text == "")
            {
                lblsno.Text = "1";
            }
            else
            {
                lblsno.Text = (Voucher.Rows.Count + 1).ToString();
            }
            btnadd.Enabled = true;
        }
        
    }
    private void Particularsearch()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        string query = "select Opening_Blnc,Cr_Dr from ledger where LedgerID='" + asmStudent2.SelectedValue + "';select sum(AmountDR) as dr,sum(AmountCR) as cr from voucher_transaction where AccountID='" + asmStudent2.SelectedValue + "'";
        SqlDataReader dr = null;
        dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, query);
        decimal opBal = 0;
        string mod = null;
        string retVal = null;
        if (dr.Read())
        {
            opBal = decimal.Parse(dr["Opening_Blnc"].ToString());
            mod = dr["Cr_Dr"].ToString();
            dr.NextResult();
            if (dr.Read())
            {
                decimal totDrAmt = opBal + decimal.Parse((dr["dr"] != DBNull.Value) ? dr["dr"].ToString() : "0");
                decimal totCrAmt = decimal.Parse((dr["cr"] != DBNull.Value) ? dr["cr"].ToString() : "0");
                
                if ((totDrAmt - totCrAmt) > 0)
                {
                    lblCrDr.Text = "Dr";
                    lblCurrblnc.Text = (totDrAmt - totCrAmt).ToString();
                }
                else if ((totDrAmt - totCrAmt) < 0)
                {
                    lblCrDr.Text = "Cr";
                    lblCurrblnc.Text = (totCrAmt - totDrAmt).ToString();
                }
                else
                {
                    lblCurrblnc.Text = opBal.ToString();
                    lblCrDr.Text = mod;
                }
            }
        }
    }
    protected void cmdsearch2_Click(object sender, EventArgs e)
    {
        Particularsearch();
       
        
    }
    private void Journalsearch()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        string query = "select Opening_Blnc,Cr_Dr from ledger where LedgerID='" + asmStudent3.SelectedValue + "';select sum(AmountDR) as dr,sum(AmountCR) as cr from voucher_transaction where AccountID='" + asmStudent3.SelectedValue + "'";
        SqlDataReader dr = null;
        dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, query);
        decimal opBal = 0;
        string mod = null;
        string retVal = null;
        if (dr.Read())
        {
            opBal = decimal.Parse(dr["Opening_Blnc"].ToString());
            mod = dr["Cr_Dr"].ToString();
            dr.NextResult();
            if (dr.Read())
            {
                decimal totDrAmt = opBal + decimal.Parse((dr["dr"] != DBNull.Value) ? dr["dr"].ToString() : "0");
                decimal totCrAmt = decimal.Parse((dr["cr"] != DBNull.Value) ? dr["cr"].ToString() : "0");

                if ((totDrAmt - totCrAmt) > 0)
                {
                    lbljCrDr.Text = "Dr";
                    lbljCurrblnc.Text = (totDrAmt - totCrAmt).ToString();
                }
                else if ((totDrAmt - totCrAmt) < 0)
                {
                    lbljCrDr.Text = "Cr";
                    lbljCurrblnc.Text = (totCrAmt - totDrAmt).ToString();
                }
                else
                {
                    lbljCurrblnc.Text = opBal.ToString();
                    lbljCrDr.Text = mod;
                }
            }
        }
    }
    protected void cmdsearch3_Click(object sender, EventArgs e)
    {
        Journalsearch();
        return;
            btnjadd.Enabled = true;
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (asmStudent0.SelectedValue == "")
        {
            objFunc.MsgBox("Please enter Voucher Type.", this);
            return;
        }
        if (txtNo.Text == "")
        {
            objFunc.MsgBox("Please enter Voucher Number.", this);
            return;
        }
        if (txtDate.Text == "")
        {
            objFunc.MsgBox("Please enter Voucher Date.", this);
            return;
        }
        if (ddlTtype.SelectedIndex == 0)
        {
            objFunc.MsgBox("Please select account transaction type.", this);
            ddlTtype.Focus();
            return;
        }
        if (ddlTtype0.SelectedIndex == 0)
        {
            objFunc.MsgBox("Please select particular transaction type.", this);
            ddlTtype.Focus();
            return;
        }
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        if (txtpart.Text == String.Empty)
        {
            objFunc.MsgBox("Enter Particulars", this);
            return;
        }
        if(txtamt.Text==String.Empty)
        {
            objFunc.MsgBox("Enter Amount", this);
            return;
        }
        DataRow dr;
        int i;
        decimal total = decimal.Parse(txtamt.Text.ToString());
        for (i = 0; i <= Voucher.Rows.Count - 1; i++)
        {
            total += decimal.Parse(Voucher.Rows[i].ItemArray[5].ToString());
        }
        //decimal replacetext = 0;
        //if (optSelect.Items[1].Selected == true)
        //{
        //    replacetext = -decimal.Parse(txtamt.Text);
        //}
        //else
        //{
        //    replacetext = decimal.Parse(txtamt.Text);
        //}
        //lbltot.Text = total.ToString();
        dr = Voucher.NewRow();
        dr[0] = Voucher.Rows.Count + 1;
        dr[1] = asmStudent2.SelectedValue;
        dr[2] = txtpart.Text;
        decimal curB1 = 0;// decimal.Parse(lblCurrblnc.Text) - replacetext;
        string a="";
        if (rdbl == 0)
        {
            Contra(ref curB1, ref a);
        }
        if (rdbl == 1)
        {
            Payment(ref curB1, ref a);
        }
        if (rdbl == 2)
        {
            Receipt (ref curB1, ref a);
        }
        dr[3] = curB1.ToString().Replace("-","");
        dr[4] = a;
        if (ddlTtype0.SelectedItem.Text == "CR")
        {
            dr[7] = txtamt.Text;
        }
        else
        {
            dr[5] = txtamt.Text;
        }
        dr[6] = total.ToString();
        dr[8] = asmStudent1.SelectedValue;
        Voucher.Rows.Add(dr);
        dr = Voucher.NewRow();
        dr[0] = Voucher.Rows.Count + 1;
        dr[1] = asmStudent1.SelectedValue;
        dr[2] = txtacc.Text;
        dr[3] = lblcurrbal.Text.ToString().Replace("-", "");
        dr[4] = lblCr.Text;
        if (ddlTtype.SelectedItem.Text == "CR")
        {
            dr[7] = txtamt.Text;
        }
        else
        {
            dr[5] = txtamt.Text;
        }
        //dr[6] = total.ToString();
        dr[8] = asmStudent2.SelectedValue;
        Voucher.Rows.Add(dr);
        DataSet ds = new DataSet();
        string xmlFilePath = @MapPath(".") + "\\AccData\\BillWiseDetailRecord.xml";
        ds.ReadXml(xmlFilePath);
        VoucherD = ds.Tables[0];
        ViewState["VoucD"] = VoucherD;
        grdcon.DataSource = Voucher;
        grdcon.DataBind();
        lblsno.Text = Convert.ToString(Voucher.Rows.Count + 1);
        txtpart.Text = String.Empty;
        txtamt.Text = String.Empty;
        lblCurrblnc.Text = "";
        cmdSubmit.Enabled = true;
        hdParent.Value = "0";
        calculateDR();
    }
    private void calculateDR()
    {
        int i;
        decimal dr = 0;
        decimal cr = 0;
        for (i = 0; i <= grdcon.Rows.Count - 1; i++)
        {
            Label lblgamt;
            lblgamt = (Label)grdcon.Rows[i].FindControl("lblgamt");
            if (lblgamt.Text != "")
            {
                dr = dr + decimal.Parse(lblgamt.Text.ToString());
            }
            Label lblCamt;
            lblCamt = (Label)grdcon.Rows[i].FindControl("lblCamt");
            if (lblCamt.Text != "")
            {
                cr = cr + decimal.Parse(lblCamt.Text.ToString());
            }

        }
        TextBox txtDr;
        txtDr = (TextBox)grdcon.FooterRow.FindControl("txtTotalDr");
        txtDr.Text = dr.ToString();
        TextBox txtCr;
        txtCr = (TextBox)grdcon.FooterRow.FindControl("txtTotalCr");
        txtCr.Text = dr.ToString();
    }
    private void Contra(ref decimal curr2, ref  string cr2)
    {
        decimal curr1 = 0;
        decimal accountcurrent = 0;
        decimal particularcurrent = 0;
        if (lblCr.Text == "Cr")
        {
            accountcurrent = -decimal.Parse(lblcurrbal.Text.ToString());
        }
        else
        {
            accountcurrent = decimal.Parse(lblcurrbal.Text.ToString());
        }

        if (lblCrDr.Text == "Cr")
        {
            particularcurrent = -decimal.Parse(lblCurrblnc.Text.ToString());
        }
        else
        {
            particularcurrent = decimal.Parse(lblCurrblnc.Text.ToString());
        }
        curr1 = accountcurrent + decimal.Parse(txtamt.Text.ToString());
        
        if (curr1 < 0)
        {
            lblcurrbal.Text = curr1.ToString().Replace("-","");
            lblcurrbal.ForeColor = System.Drawing.Color.Red;
            lblCr.Text = "Cr";
            lblCr.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblcurrbal.CssClass = "rdgrow";
            lblCr.CssClass = "rdgrow";
            lblcurrbal.Text = curr1.ToString();
            lblCr.Text = "Dr";
        }
        curr2 = particularcurrent - decimal.Parse(txtamt.Text.ToString());
        if (curr2 < 0)
        {
           // lblCurrblnc.Text = curr2.ToString().Replace("-", "");
            cr2 = "Cr";
        }
        else
        {
            //lblCurrblnc.Text = curr2.ToString();
            cr2 = "Dr";
        }
     

    }
    private void Payment(ref decimal curr2, ref  string cr2)
    {
        decimal curr1 = 0;
        decimal accountcurrent = 0;
        decimal particularcurrent = 0;
        if (lblCr.Text == "Cr")
        {
            accountcurrent = -decimal.Parse(lblcurrbal.Text.ToString());
        }
        else
        {
            accountcurrent = decimal.Parse(lblcurrbal.Text.ToString());
        }

        if (lblCrDr.Text == "Cr")
        {
            particularcurrent = -decimal.Parse(lblCurrblnc.Text.ToString());
        }
        else
        {
            particularcurrent = decimal.Parse(lblCurrblnc.Text.ToString());
        }
        curr1 = accountcurrent - decimal.Parse(txtamt.Text.ToString());

        if (curr1 < 0)
        {
            lblcurrbal.Text = curr1.ToString().Replace("-", "");
            lblcurrbal.ForeColor = System.Drawing.Color.Red;
            lblCr.Text = "Cr";
            lblCr.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblcurrbal.CssClass = "rdgrow";
            lblCr.CssClass = "rdgrow";
            lblcurrbal.Text = curr1.ToString();
            lblCr.Text = "Dr";
        }
        curr2 = particularcurrent + decimal.Parse(txtamt.Text.ToString());
        if (curr2 < 0)
        {
            // lblCurrblnc.Text = curr2.ToString().Replace("-", "");
            cr2 = "Cr";
        }
        else
        {
            //lblCurrblnc.Text = curr2.ToString();
            cr2 = "Dr";
        }


    }
    private void Receipt(ref decimal curr2, ref  string cr2)
    {
        decimal curr1 = 0;
        decimal accountcurrent = 0;
        decimal particularcurrent = 0;
        if (lblCr.Text == "Cr")
        {
            accountcurrent = -decimal.Parse(lblcurrbal.Text.ToString());
        }
        else
        {
            accountcurrent = decimal.Parse(lblcurrbal.Text.ToString());
        }

        if (lblCrDr.Text == "Cr")
        {
            particularcurrent = -decimal.Parse(lblCurrblnc.Text.ToString());
        }
        else
        {
            particularcurrent = decimal.Parse(lblCurrblnc.Text.ToString());
        }
        curr1 = accountcurrent + decimal.Parse(txtamt.Text.ToString());

        if (curr1 < 0)
        {
            lblcurrbal.Text = curr1.ToString().Replace("-", "");
            lblcurrbal.ForeColor = System.Drawing.Color.Red;
            lblCr.Text = "Cr";
            lblCr.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblcurrbal.CssClass = "rdgrow";
            lblCr.CssClass = "rdgrow";
            lblcurrbal.Text = curr1.ToString();
            lblCr.Text = "Dr";
        }
        curr2 = particularcurrent - decimal.Parse(txtamt.Text.ToString());
        if (curr2 < 0)
        {
            // lblCurrblnc.Text = curr2.ToString().Replace("-", "");
            cr2 = "Cr";
        }
        else
        {
            //lblCurrblnc.Text = curr2.ToString();
            cr2 = "Dr";
        }


    }

    private void Journal(ref decimal curr1, ref  string cr1)
    {
        //decimal curr1 = 0;
        //decimal accountcurrent = 0;
        decimal particularcurrent = 0;
        //if (lblCr.Text == "Cr")
        //{
        //    accountcurrent = -decimal.Parse(lblcurrbal.Text.ToString());
        //}
        //else
        //{
        //    accountcurrent = decimal.Parse(lblcurrbal.Text.ToString());
        //}

        if (lbljCrDr.Text == "Cr")
        {
            particularcurrent = -decimal.Parse(lbljCurrblnc.Text.ToString());
        }
        else
        {
            particularcurrent = decimal.Parse(lbljCurrblnc.Text.ToString());
        }
        if (rdblto.Items[0].Selected == true)
        {
            curr1 = particularcurrent + decimal.Parse(txtdr.Text.ToString());
        }
        else
        {
            curr1 = particularcurrent - decimal.Parse(txtcr.Text.ToString());
        }

        if (curr1 < 0)
        {
            lblCurrblnc.Text = curr1.ToString().Replace("-", "");
            lblCurrblnc.ForeColor = System.Drawing.Color.Red;
            lblCr.Text = "Cr";
            cr1 = "Cr";
            lblCr.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblCurrblnc.CssClass = "rdgrow";
            lblCr.CssClass = "rdgrow";
            lblCurrblnc.Text = curr1.ToString();
            lblCr.Text = "Dr";
            cr1 = "Dr";
        }

        //if (rdblto.Items[0].Selected == true)
        //{
        //    curr2 = particularcurrent - decimal.Parse(txtdr.Text.ToString());
        //}
        //else
        //{
        //    curr2 = particularcurrent - decimal.Parse(txtcr.Text.ToString());
        //}
        //if (curr2 < 0)
        //{
        //    //lblCurrblnc.Text = curr2.ToString().Replace("-", "");
        //    cr2 = "Cr";
        //}
        //else
        //{
        //    //lblCurrblnc.Text = curr2.ToString();
        //    cr2 = "Dr";
        //}


    }

    protected void btnjadd_Click(object sender, EventArgs e)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        if (rdblto.SelectedValue == "")
        {
            objFunc.MsgBox("Select Transaction Type", this);
            return;
        }
        if (txtjpart.Text == String.Empty)
        {
            objFunc.MsgBox("Enter Particulars", this);
            return;
        }
        if ((rdblto.Items[0].Selected == true) && (txtdr.Text == String.Empty))
        {
            objFunc.MsgBox("Enter Debit Amount", this);
            return;
        }
        if ((rdblto.Items[1].Selected == true) && (txtcr.Text == String.Empty))
        {
            objFunc.MsgBox("Enter Credit Amount", this);
            return;
        }

        //int i;
        //decimal total = decimal.Parse(txtamt.Text.ToString());
        //for (i = 0; i <= Voucher.Rows.Count - 1; i++)
        //{
        //    total += decimal.Parse(Voucher.Rows[i].ItemArray[5].ToString());
        //}

        
        //lbltot.Text = total.ToString();

        DataRow jdr;
        jdr = VoucherType.NewRow();
        jdr[0] = VoucherType.Rows.Count + 1;
        jdr[1] = asmStudent3.SelectedValue;
        jdr[2] = txtjpart.Text;
        decimal curB1 = 0;// decimal.Parse(lblCurrblnc.Text) - replacetext;
        string a = "";
        //if ((rdbl == 3) || (rdbl == 4) || (rdbl == 5))
        if (rdbl == 3)
        {
            rdblto.Items[1].Enabled = true;
            //Journal(ref curB1, ref a);
        }
        if (rdbl == 4)
        {
            if (grdjour.Rows.Count == 0)
            {
                rdblto.Items[0].Enabled = true;
                rdblto.Items[1].Enabled = false;
            }
            else
            {
                rdblto.Items[0].Enabled = true;
                rdblto.Items[1].Enabled = true;
            }
            //Journal(ref curB1, ref a);
        }
        if (rdbl == 5)
        {
            if (grdjour.Rows.Count == 0)
            {
                rdblto.Items[0].Enabled = false;
                rdblto.Items[1].Enabled = true;
            }
            else
            {
                rdblto.Items[0].Enabled = true;
                rdblto.Items[1].Enabled = true;
            }
            //Journal(ref curB1, ref a);
        }
        Journal(ref curB1, ref a);
        jdr[3] = curB1.ToString().Replace("-", "");
        jdr[4] = a;
        //jdr[3] = lbljCurrblnc.Text;
        //jdr[4] = lbljCrDr.Text;
        if (rdblto.Items[0].Selected == true)
        {
            jdr[5] = txtdr.Text;
            jdr[6] = "";
        }
        else
        {
            jdr[5] = "";
            jdr[6] = txtcr.Text;
        }
        

        VoucherType.Rows.Add(jdr);
        grdjour.DataSource = VoucherType;
        grdjour.DataBind();

        //int drsum=0;
        //int crsum=0;
        if (rdblto.Items[0].Selected == true)
        {
            drsum = drsum + Convert.ToInt32(txtdr.Text);
            Label lbldr = (Label)grdjour.FooterRow.Cells[3].FindControl("lbldrsum");
            Label lblcr = (Label)grdjour.FooterRow.Cells[4].FindControl("lblcrsum");
            lbldr.Text = drsum.ToString();
            lblcr.Text = crsum.ToString();
        }
        else
        {
            crsum = crsum + Convert.ToInt32(txtcr.Text);
            Label lblcr = (Label)grdjour.FooterRow.Cells[4].FindControl("lblcrsum");
            Label lbldr = (Label)grdjour.FooterRow.Cells[3].FindControl("lbldrsum");
            lblcr.Text = crsum.ToString();
            lbldr.Text = drsum.ToString();
        }

        txtjpart.Text = String.Empty;
        txtdr.Text = String.Empty;
        txtcr.Text = String.Empty;
        cmdSubmit.Enabled = true;
        lbljCurrblnc.Text = String.Empty;
        lbljCrDr.Text = String.Empty;
    }

    protected void rdblto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblto.Items[0].Selected == true)
        {
            txtdr.Enabled = true;
            txtcr.Enabled = false;
            txtdr.Text = String.Empty;
            txtcr.Text = String.Empty;
        }
        else if (rdblto.Items[1].Selected == true)
        {
            txtdr.Enabled = false;
            txtcr.Enabled = true;
            txtdr.Text = String.Empty;
            txtcr.Text = String.Empty;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void grdcon_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["VoucD"];
            if (dt != null)
            {
                //GridView grd;
                //grd = (GridView)e.Row.FindControl("GridView1");
                //grd.DataSource = dt;
                //grd.DataBind();
            }
           // if ViewState["VoucD"]
        }
    }
    protected void grdcon_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string xmlFilePath = @MapPath(".") + "\\AccData\\BillWiseDetailRecord.xml";
            DataSet dt = new DataSet();
            dt.ReadXml(xmlFilePath);
          
            DataRow[] dr;
            dr = dt.Tables[0].Select("EntryDate='" + DateTime.Now.Date.ToString("dd-MMM-yyyy") + "' and ParticularID='" + grdcon.DataKeys[e.Row.RowIndex].Value.ToString()  + "'");

            DataTable dtt = new DataTable();
            int i;
            DataRow dr1;
            //dr1 =(DataRow[]) dr.Clone();
            for (i = 0; i <= dt.Tables[0].Columns.Count - 1; i++)
            {
                dtt.Columns.Add(dt.Tables[0].Columns[i].ColumnName.ToString());
            }
            // dt = dt.Tables[0].Select("EntryDate='08-Mar-2010'");
            for (i = 0; i <= dr.Length - 1; i++)
            {
                dr1 = dtt.NewRow();
                string s1 = dr[i][0].ToString();
                dr1[0] = s1.ToString();
                dr1[1] = dr[i][1].ToString();
                dr1[2] = dr[i][3].ToString();
                dr1[4] = dr[i][4].ToString();
                dr1[5] = dr[i][5].ToString();
                dtt.Rows.Add(dr1);

            }
            if (dtt != null)
            {
                GridView grd;
                grd = (GridView)e.Row.FindControl("GridView1");
                grd.DataSource = dtt;
                grd.DataBind();
            }
            // if ViewState["VoucD"]
        }
    }
    protected void cmdPrint_Click(object sender, EventArgs e)
    {
        int i;
        DataTable dtprint = new DataTable();
        dtprint.Columns.Add("VoucherNo");
        dtprint.Columns.Add("VoucherType");
        dtprint.Columns.Add("VoucherDate",typeof(DateAndTime));
        dtprint.Columns.Add("Particular");
        dtprint.Columns.Add("Credit",typeof(decimal));
        dtprint.Columns.Add("Debit", typeof(decimal));
        dtprint.Columns.Add("Narration");
        for (i = 0; i <= grdcon.Rows.Count - 1; i++)
        {
            DataRow dr = dtprint.NewRow();
            //txtName  lblgamt lblCamt
            LinkButton lnkpart;
            lnkpart = (LinkButton)grdcon.Rows[i].FindControl("lnkpart");
            Label lblgamt;
            lblgamt = (Label)grdcon.Rows[i].FindControl("lnkpart");
            Label lblCamt;
            lblCamt = (Label)grdcon.Rows[i].FindControl("lnkpart");
            dr[0] = txtNo.Text;
            dr[1] = txtvtype.Text;
            dr[2] = txtDate.Text;
            dr[3] = lnkpart.Text;
            dr[4]=lblCamt.Text;
            dr[5] = lblgamt.Text;
            dr[6] = txtnarr.Text;
            dtprint.Rows.Add(dr);
        }
        PrintVoucher prtv = new PrintVoucher();
        prtv.DataTable1.Merge(dtprint, true, MissingSchemaAction.Ignore);
        ReportDocument rpt1 = new ReportDocument();
        string SFileName = "CWFD";
        string spath = Server.MapPath("Pvoucher.rpt");//.Replace("Fee\\Fee\\", "Fee\\");
         rpt1.Load(spath);
        rpt1.SetDataSource(prtv);
        CrystalReportViewer1.ReportSource = rpt1;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
        ExportOptions exportOpts1 = rpt1.ExportOptions;
        rpt1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rpt1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        rpt1.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        ((DiskFileDestinationOptions)rpt1.ExportOptions.DestinationOptions).DiskFileName = spath + "StudentList.pdf";
        rpt1.Export();
        rpt1.Close();
        rpt1.Dispose();
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "StudentList.pdf");
            Response.WriteFile(spath + "StudentList.pdf");
            Response.Flush();
            Response.End();
            Response.Close();
        }
        File.Delete(Server.MapPath(SFileName + ".pdf"));
    }
}
