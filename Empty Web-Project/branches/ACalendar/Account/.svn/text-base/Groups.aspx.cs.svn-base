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

public partial class Account_Groups : System.Web.UI.Page
{
    DbFunctions objF = new DbFunctions();
    DbFunctions objFunc = new DbFunctions();
    static string tempgrpname;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtGrName.Focus();
            
              
           
            Label2.Visible = false;
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
            sql = "Select distinct top 10 Group_Name,Group_ID from Groups where  Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by Group_Name";
        }
        else
        {
            sql = "Select distinct top 10 Group_Name,Group_ID from Groups where Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by Group_Name";
        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging & pageIndex == 0)
        {
            sql = "SELECT COUNT(*) from Groups where   Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Groups where Group_Name LIKE '%'";
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
            sql = "SELECT COUNT(*) from Groups where  Group_Name LIKE '" + skeyword.Replace("'", "''") + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Groups where Group_Name LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by Group_Name";
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
    
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        if (txtGrName.Text == "")
        {
            return;
        }
        if (asmStudent0.SelectedValue=="")
        {
            return;
        }
        if (asmStudent0.SelectedValue == "1")
        {
            if (ddlNature.SelectedValue == "0")
            {
                objF.MsgBox("Please select Nature of Group.", this);
                return;
            }

        }
        else
        {
            string nature = objF.Get_details("select GroupNature from Groups where group_id='" + asmStudent0.SelectedValue + "'");
            ddlNature.SelectedValue = nature;
        }
        string Primary_gr = objF.Get_details("select Primary_Group from Groups where group_id='" + asmStudent0.SelectedValue + "'");

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        //if (optSelect.Items[0].Selected == true)
        //{
            DataTable dt = objDB.ExecuteTable(CommandType.Text, "select Group_Name from Groups where Group_Name='" + txtGrName.Text.Trim() + "' and Under_Group='" + asmStudent0.SelectedValue + "'");
            if (optSelect.Items[0].Selected == true)
            {
                if (dt.Rows.Count > 0)
                {
                    objF.MsgBox("Duplicate entry.", this);
                    return;
                }
            }
            else
            {
                if (tempgrpname != txtGrName.Text)
                {
                    int Record_Found = Convert.ToInt16(objFunc.FetchScalar("select Group_ID from Groups where Group_Name='" + txtGrName.Text + "' and Under_Group='" + asmStudent0.SelectedValue + "'"));
                    if (Record_Found != 0)
                    {
                        objFunc.MsgBox("Duplicate Entry", this);
                        //reset();
                        return;
                    }
                }
            }
            
        //}
        objDB.BeginTransaction();
        try
        {
            objDB.CreateParameters(7);
            if (hdType.Value == "0")
            {
                objDB.AddParameters(0, "Group_ID", 0, DbType.Int32);
            }
            else
            {
                objDB.AddParameters(0, "Group_ID", Int32.Parse(asmStudent1.SelectedValue), DbType.Int32);
            }
            objDB.AddParameters(1, "Group_Name", txtGrName.Text, DbType.String);
            objDB.AddParameters(2, "Alias", txtAbr.Text, DbType.String);
            objDB.AddParameters(3, "Under_Group", Int32.Parse(asmStudent0.SelectedValue), DbType.Int32);
            objDB.AddParameters(4, "GroupNature", ddlNature.SelectedValue, DbType.String);
            if (Primary_gr == "1")
            {
                Primary_gr = asmStudent0.SelectedValue;
            }
            objDB.AddParameters(5, "Primary_Group", Int32.Parse(Primary_gr), DbType.Int32);
            if (hdType.Value == "0")
            {
                objDB.AddParameters(6, "flag", "N", DbType.String);//
            }
            else
            {
                objDB.AddParameters(6, "flag", "U", DbType.String);//
            }
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Groupsp");
            objDB.Transaction.Commit();
            objF.MsgBox("Record saved successfully.", this);
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            objF.MsgBox(ex.Message.ToString(), this);
        }
        cleardata();
        cmdSubmit.Enabled = false;
        
    }
    private void optValue(RadioButtonList opt)
    {
        int i;
        for (i = 0; i <= opt.Items.Count - 1; i++)
        {
        
            opt.Items[i].Selected = false;
        }
    }
    private void cleardata()
    {
        txtGrName.Text = "";
        txtAbr.Text = "";
       // txtMethod.Text = "";
        txtUnder.Text = "";
       // RefreshOpt(optSelect);
        txtSearch.Text = "";
        ddlNature.SelectedIndex = 0;
        //RefreshOpt(optCal);
        //RefreshOpt(optSubL);
        cmdSubmit.Enabled = false;
        
    }
    private void RefreshOpt(RadioButtonList opt)
    {
        int i;
        for (i = 0; i <= opt.Items.Count - 1; i++)
        {
            opt.Items[i].Selected = false;
        }
        opt.Items[1].Selected =true ;
    }

    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        if(optSelect.SelectedValue=="")
        {
            objF.MsgBox("Select Option",this);
            txtGrName.Text = String.Empty;
            txtAbr.Text = String.Empty;
            txtUnder.Text = String.Empty;
            return;
        }
        if (asmStudent0.SelectedValue == "1")
        {
            ddlNature.Enabled = true;
        }
        else
        {
            ddlNature.Enabled = false;
        }
        cmdSubmit.Enabled = true;
        cmdReset.Enabled = true;
    }
    protected void optSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        cleardata();
        if (optSelect.Items[0].Selected == true)
        {
             
            Label2.Visible = false;
            txtSearch.Visible = false;
            hdType.Value = "0";
            txtGrName.Focus();
        }
        else if (optSelect.Items[1].Selected == true)
        {
            Label2.Visible = true ;
            txtSearch.Visible = true ;
            txtSearch.Focus();
             
            hdType.Value = "0";
            //cmdSubmit.Enabled = false;
            //cmdReset.Enabled = false;
        }
        else if (optSelect.Items[2].Selected == true)
        {
            Label2.Visible = true ;
            txtSearch.Visible = true ;
            
            hdType.Value = "1";
            txtSearch.Focus();
            //cmdSubmit.Enabled = true;
            //cmdReset.Enabled = true;
        }
    }
    protected void cmdSearch1_Click(object sender, EventArgs e)
    {
        cleardata();
        if (optSelect.SelectedValue == "")
        {
            objF.MsgBox("Select Option", this);
            txtGrName.Text = String.Empty;
            txtAbr.Text = String.Empty;
            txtUnder.Text = String.Empty;
            return;
        }
        DataTable dt = new DataTable();
        if (asmStudent1.SelectedValue != "1")
        {
            NewDAL.DBManager objDB = new DBManager();
            objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
            objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
            objDB.Open();
            dt = objDB.ExecuteTable(CommandType.Text, "Select Group_Name,Alias,Under_Group,GroupNature from  Groups where Group_ID='" + asmStudent1.SelectedValue + "'");
            txtGrName.Text = dt.Rows[0].ItemArray[0].ToString();
            tempgrpname = dt.Rows[0].ItemArray[0].ToString();
            txtAbr.Text = dt.Rows[0].ItemArray[1].ToString();
            asmStudent0.SelectedValue = dt.Rows[0].ItemArray[2].ToString();

            txtUnder.Text = (string)objDB.ExecuteScalar(CommandType.Text, "Select Group_Name   from  Groups where Group_ID='" + dt.Rows[0].ItemArray[2].ToString() + "'");
            if (dt.Rows[0].ItemArray[2].ToString() == "1")
            {
                ddlNature.Enabled = true;
                string chkN = dt.Rows[0].ItemArray[3].ToString();
                if (chkN == "")
                {
                    chkN = "0";
                }
                else
                {
                    chkN = dt.Rows[0].ItemArray[3].ToString();
                }
                ddlNature.SelectedValue = chkN;
            }
            else
            {
                ddlNature.SelectedIndex = ddlNature.Items.Count - 1;
                ddlNature.Enabled = false;
            }

            if (optSelect.Items[1].Selected == true)
            {
                cmdSubmit.Enabled = false;
                 
            }
            else if (optSelect.Items[2].Selected == true)
            {
                cmdSubmit.Enabled = true;
                cmdReset.Enabled = true;
            }
        }
    }
    protected void cmdReset_Click(object sender, EventArgs e)
    {
        cleardata();
    }
}
