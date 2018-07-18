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

public partial class VoucherType : System.Web.UI.Page
{
    DbFunctions objFunc = new DbFunctions();
    static string tempvname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtsearch.Visible = false;
            lblsearch.Visible = false;
 
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
            sql = "Select distinct top 10 vname,vid from Voucher_Type where  vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
        }
        else
        {
            sql = "Select distinct top 10 vname,vid from Voucher_Type where vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            sql = "SELECT COUNT(*) from Voucher_Type where vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Voucher_Type where vname LIKE '%'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " vname,vid " + sqlFromAndWhere_T + " ";
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
        if (usePaging && pageIndex != 0)
        {
            sql = "SELECT COUNT(*) from Voucher_Type where vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Voucher_Type where vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " vname ,vid " + sqlFromAndWhere_T + "";
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
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype=vid and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
        }
        else
        {
            sql = "Select distinct top 10 vname,vid from Voucher_Type where vtype=vid and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
        }
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging && pageIndex == 0)
        {
            sql = "SELECT COUNT(*) from Voucher_Type where vtype=vid and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Voucher_Type where vtype=vid and vname LIKE '%'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " vname,vid " + sqlFromAndWhere_T + " and vtype=vid";
                }
                else
                {
                    sql_T = "select distinct vname,vid " + sqlFromAndWhere_T + " where vtype=vid order by vname";
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
            sql = "SELECT COUNT(*) from Voucher_Type where vtype=vid and vname LIKE '" + skeyword.Replace("'", "''") + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Voucher_Type where vtype=vid and vname LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by vname";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " vname ,vid " + sqlFromAndWhere_T + " and vtype=vid";
                }
                else
                {
                    sql_T = "select distinct vname,vid " + sqlFromAndWhere_T + " where vtype=vid";
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
        if (txtVTname.Text == "")
        {
            txtVTname.Focus();
            objFunc.MsgBox1("Enter Voucher Name.", UpdatePanel1);
            return;
        }
        if (txtvtype.Text == "")
        {
            txtvtype.Focus();
            objFunc.MsgBox1("Enter Voucher Type.", UpdatePanel1);
            return;
        }
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataSet ds = new DataSet();
        if (optSelect.Items[0].Selected == true)
        {
            ds = objDB.ExecuteDataSet(CommandType.Text, "select vname from Voucher_Type where vname='" + txtVTname.Text + "' and vtype='" + asmStudent1.SelectedValue + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                objFunc.MsgBox("Duplicate Entry", this);
                reset();
                return;
            }
        }
        else
        {
            //ds = objDB.ExecuteDataSet(CommandType.Text, "select vname from Voucher_Type where vname='" + txtVTname.Text + "' and vtype='" + hdType.Value + "'");
            if (tempvname != txtVTname.Text)
            {
                int Record_Found = Convert.ToInt16(objFunc.FetchScalar("select vid from Voucher_Type where vname='" + txtVTname.Text + "' and vtype='" + hdType.Value + "'"));
                if (Record_Found != 0)
                {
                    objFunc.MsgBox("Duplicate Entry", this);
                    reset();
                    return;
                }
            }
        }
            
        objDB.BeginTransaction();
        try
        {
            objDB.CreateParameters(14);
            string prefil = "";
            string prevent = "";
            string var="";

            if (optSelect.Items[0].Selected == true)
                {
                    var = asmStudent1.SelectedValue;
                }
                else if (optSelect.Items[2].Selected == true)
                {
                    var = hdType.Value;
                }
                //else if 
                //{
                //    var = "0";
                //}
               
                if (ddlvno.SelectedIndex == 1)
                {
                    prefil = optprefill.SelectedValue;
                }

                else
                {
                    prevent = optprefill.SelectedValue;
                }
        
                if (  hdType.Value == "0")
            {
                objDB.AddParameters(0, "vid", 0, DbType.Int32);
            }
            else
            {
             objDB.AddParameters(0, "vid",Int32.Parse( asmStudent0.SelectedValue) , DbType.Int32);
            }
                objDB.AddParameters(1, "vname", txtVTname.Text, DbType.String);
                objDB.AddParameters(2, "vtype", Int32.Parse(var), DbType.Int32);
                objDB.AddParameters(3, "abbr", txtAbbr.Text, DbType.String);
                objDB.AddParameters(4, "method", ddlvno.SelectedValue, DbType.String);
                objDB.AddParameters(5, "startno", Int32.Parse("1"), DbType.Int32);
                objDB.AddParameters(6, "nwidth", Int32.Parse("0"), DbType.Int32);
                objDB.AddParameters(7, "prefil", txtprefix.Text, DbType.String);
                objDB.AddParameters(8, "dprevent", prevent, DbType.String);
                objDB.AddParameters(9, "InstId", Convert.ToInt32(Session["instID"]), DbType.Int32);
                objDB.AddParameters(10, "SessionId", Session["sesnID"].ToString(), DbType.String);
                if (hdType.Value == "0")
                {
                    objDB.AddParameters(11, "flag", "N", DbType.String);
                }
                else
                {
                    objDB.AddParameters(11, "flag", "U", DbType.String);
                }
                int cnarration = 0;
                int AfterPrint = 0;
                if (chkNarr.Checked == true)
                {
                    cnarration = 1;
                }
                if (chkPrint.Checked == true)
                {
                    AfterPrint = 1;
                }
                objDB.AddParameters(12, "AfterPrint", AfterPrint, DbType.Int16);
                objDB.AddParameters(13, "cnarration", cnarration, DbType.Int16);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Voucher");
                objDB.Transaction.Commit();
                objFunc.MsgBox1("Record saved.", UpdatePanel1);
        }

          
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            objFunc.MsgBox(ex.Message.ToString(), this);
        }
    }
    


    protected void cmdReset_Click(object sender, EventArgs e)
    {
        reset();
    }

    private void reset()
    {
        hdType.Value = "0";
        optClear(optprefill);
        txtsearch.Text = String.Empty;
        txtVTname.Text = String.Empty;
        txtvtype.Text = String.Empty;
        txtAbbr.Text = String.Empty;
        ddlvno.SelectedIndex = 0;
        Label1.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        txtno.Visible = false;
        txtwidth.Visible = false;
        optprefill.Visible=false;
        txtno.Text = String.Empty;
        txtwidth.Text = String.Empty;
        Voucher.Clear();
        VoucherTable.Clear();
        txtprefix.Text = "";
        chkPrint.Checked = false;
        chkNarr.Checked = false;
    }


    protected void optSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        if (optSelect.Items[0].Selected == true)
        {
            reset();
            hdType.Value = "0";
 
            asmStudent0.Enabled = false;
            cmdsearch.Enabled = false;
            asmStudent1.Enabled = true;
            cmdsearch1.Enabled = true;
            txtsearch.Visible = false;
            lblsearch.Visible = false;
            reset();
           // btnadd.Enabled = false;
            txtvtype.ReadOnly = false;
            txtVTname.Focus();
        }

        else if (optSelect.Items[1].Selected == true)
        {
            reset();
             hdType.Value = "0";
            asmStudent1.Enabled = false;
            cmdsearch1.Enabled = false;
            asmStudent0.Enabled = true;
            cmdsearch.Enabled = true;
            txtsearch.Visible = true;
          
            //txtvtype.ReadOnly = true;
            txtsearch.Visible = true;
            lblsearch.Visible = true;
           // reset();
            txtsearch.Focus();
        }

        else if (optSelect.Items[2].Selected == true)
        {
            reset();
             hdType.Value = "1";
            asmStudent1.Enabled = false;
            cmdsearch1.Enabled = false;
            asmStudent0.Enabled = true;
            cmdsearch.Enabled = true;
            txtsearch.Visible = true;
            lblsearch.Visible = true;
            txtvtype.ReadOnly = true;
         //   reset();
            txtsearch.Focus();
        }
    }

    private void optClear(RadioButtonList opt)
    {
        int i;
        for (i = 0; i <= opt.Items.Count - 1; i++)
        {

            opt.Items[i].Selected = false;
        }
    }

    private void show()
    {
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        txtno.Visible = true;
        txtwidth.Visible = true;
        optprefill.Visible = true;
        Label1.Text = "Starting No.";
        Label2.Text = "Width of Numeric Part";
        Label3.Text = "Prefill with Zero";
    }


    protected void ddlvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlvno.SelectedValue == "Select")
        {
            objFunc.MsgBox("Please Select Method", this);
        }
        if ((optSelect.Items[0].Selected==true)&(asmStudent1.SelectedValue == ""))
        {
            objFunc.MsgBox("Invalid Voucher Type", this);
            //reset();
            return;
        }

        else if (ddlvno.SelectedIndex == 1)
        {
            show();
        }
        else if (ddlvno.SelectedIndex == 2)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            txtno.Visible = false;
            txtwidth.Visible = false;
            Label3.Visible = true;
            optprefill.Visible = true;
            Label3.Text = "Prevent Duplicates";
        }
        else if (ddlvno.SelectedIndex == 3)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            txtno.Visible = false;
            txtwidth.Visible = false;
            Label3.Visible = false;
            optprefill.Visible = false;
        }

       // btnadd.Enabled = true;
        cmdReset.Enabled = true;
    }

    //protected void btnadd_Click(object sender, EventArgs e)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();

    //    if ((txtrnfrm.Text == String.Empty) || (txtrnstart.Text == String.Empty) || (ddlrnpart.SelectedIndex == 0))
    //    {
    //        objFunc.MsgBox("Please Fill Restart Numbering Enries", this);
    //        return;
    //    }

    //    int i;         
    //        for (i = 0; i <= Voucher.Rows.Count - 1; i++)
    //        {
    //            string app = ((System.Web.UI.WebControls.Label)grdrestart.Rows[i].FindControl("lblapp")).Text;
    //            if (txtrnfrm.Text == app)
    //            {
    //                objFunc.MsgBox("Duplicate entry.", this);
    //                return;
    //            }
    //        }
    //    if(grdrestart.Rows.Count>0)
    //    {
    //     //Voucher.
    //    }
    //            DataRow dr;
    //            dr = Voucher.NewRow();
    //            dr[0] = txtrnfrm.Text;
    //            dr[1] = txtrnstart.Text;
    //            dr[2] = ddlrnpart.SelectedValue;
    //            Voucher.Rows.Add(dr);
    //            grdrestart.DataSource = Voucher;
    //            grdrestart.DataBind();
    //            grdrestart.Visible = true;

    //        if ((txtpdfrm.Text!=String.Empty)&&(ddlpdpart.SelectedValue!="Select"))
    //        {
    //            for (i = 0; i <= VoucherTable.Rows.Count - 1; i++)
    //            {
    //                string pdapp = ((System.Web.UI.WebControls.Label)grdprefix.Rows[i].FindControl("lblpdapp")).Text;
    //                if (txtpdfrm.Text == pdapp)
    //                {
    //                    objFunc.MsgBox("Duplicate entry.", this);
    //                    return;
    //                }
    //            }
    //                DataRow pdr;
    //                pdr = VoucherTable.NewRow();
    //                pdr[0] = txtpdfrm.Text;
    //                pdr[1] = ddlpdpart.SelectedValue;
    //                VoucherTable.Rows.Add(pdr);
    //                grdprefix.DataSource = VoucherTable;
    //                grdprefix.DataBind();
    //                grdprefix.Visible = true;
                
    //        }
         

    //        if ((grdrestart.Rows.Count > 0) || (grdprefix.Rows.Count > 0))
    //        {
    //            cmdSubmit.Enabled = true;
    //            cmdReset.Enabled = true;
    //        }
    //        txtrnfrm.Text = String.Empty;
    //        txtrnstart.Text = String.Empty;
    //        txtpdfrm.Text = String.Empty;
    //        ddlpdpart.SelectedIndex = 0;
    //        ddlrnpart.SelectedIndex = 0;
    //        //reset();
        
    //}


    private DataTable Voucher
    {
        get
        {
            DataTable dt = (DataTable)ViewState["Vouc"];

            if (dt == null)
            {
                dt = new DataTable();
                //dt.Columns.Add(new DataColumn("Id", typeof(string)));
                dt.Columns.Add(new DataColumn("RnAppFrom", typeof(string)));
                dt.Columns.Add(new DataColumn("RnStartNo", typeof(string)));
                dt.Columns.Add(new DataColumn("RnParticular", typeof(string)));
                Voucher = dt;
            }

            return dt;
        }
        set
        {
            ViewState["Vouc"] = value;
        }
    }


    private DataTable VoucherTable
    {
        get
        {
            DataTable dt = (DataTable)ViewState["Vouchr"];

            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("PdAppFrm", typeof(string)));
                dt.Columns.Add(new DataColumn("PdPart", typeof(string)));
                VoucherTable = dt;
            }

            return dt;
        }
        set
        {
            ViewState["Vouchr"] = value;
        }
    }

   

    protected void cmdsearch_Click(object sender, EventArgs e)
    {
        if (optSelect.SelectedValue == "")
        {
            objFunc.MsgBox("Select Option", this);
            return;
        }

        else
        {
            NewDAL.DBManager objDB = new DBManager();
            objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
            objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
            objDB.Open();
            DataTable dtvou = new DataTable();
            string qry = "select * from Voucher_Type where vid='" + asmStudent0.SelectedValue + "'";
            dtvou = objDB.ExecuteTable(CommandType.Text, qry);
            if (dtvou.Rows.Count > 0)
            {
                txtvtype.ReadOnly = true;
                show();

                txtVTname.Text = dtvou.Rows[0].ItemArray[1].ToString();
                string type;
                string str = (string)objDB.ExecuteScalar(CommandType.Text, "select vname from Voucher_Type where vid='" + dtvou.Rows[0].ItemArray[2].ToString() + "'");
                if (str == null)
                {
                    type = dtvou.Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    type = str;
                }
                txtvtype.Text = type;
                tempvname = dtvou.Rows[0].ItemArray[1].ToString(); ;
                hdType.Value = dtvou.Rows[0].ItemArray[2].ToString();
                txtAbbr.Text = dtvou.Rows[0].ItemArray[3].ToString();
                ddlvno.SelectedValue = dtvou.Rows[0].ItemArray[4].ToString();
                txtno.Text = dtvou.Rows[0].ItemArray[5].ToString();
                txtwidth.Text = dtvou.Rows[0].ItemArray[6].ToString();
                if (dtvou.Rows[0].ItemArray[9].ToString() == "1")
                {
                    chkNarr.Checked = true;
                }
                else
                {
                    chkNarr.Checked = false;
                }
                if (dtvou.Rows[0].ItemArray[15].ToString() == "1")
                {
                    chkPrint.Checked = true;
                }
                else
                {
                    chkPrint.Checked = false;
                }
                txtprefix.Text = dtvou.Rows[0].ItemArray[7].ToString();
              }
             if (optSelect.Items[1].Selected == true)
                {
                    //btnadd.Enabled = false;
                    cmdSubmit.Enabled = false;
                }
                else
                {
                   // btnadd.Enabled = true;
                    cmdSubmit.Enabled = true;
                    cmdReset.Enabled = true;
                }
                txtVTname.Focus();
            }
       

    }


    protected void cmdsearch1_Click(object sender, EventArgs e)
    {
        if (optSelect.SelectedValue == "")
        {
            objFunc.MsgBox("Select Option", this);
            reset();
            return;
        }

        else
        {
            NewDAL.DBManager objDB = new DBManager();
            objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
            objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
            objDB.Open();
            //asmStudent0.Visible = false;
            string qry = "select abbr from Voucher_Type where vname='" + txtvtype.Text + "'";
            object Strvname = objDB.ExecuteScalar(CommandType.Text, qry);
            string vname=string.Empty;
            if (optSelect.Items[0].Selected == true)
            {
                txtprefix.Text = Microsoft.VisualBasic.Strings.Left(txtvtype.Text.ToString(), 2);
            }
            if(Strvname!=null)
                 vname = Strvname.ToString();//objDB.ExecuteScalar(CommandType.Text, qry).ToString();

            txtAbbr.Text = vname;
            //btnadd.Enabled = true;
            return;

        }
    }

    private void frgrd()
    { 
    
    }

    private void fpgrd()
    { 
    
    }
    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShow.Checked == true)
        {
            objFunc.FillGridView(gvVouchertype, "select vid,vname as vn,abbr,prefil as np from voucher_type");
        }
        else
        {
            gvVouchertype.DataSource = new Int32[0];
            gvVouchertype.DataBind();
        }
    }
}
