#region common Class definition

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;


/// <summary>
/// Summary description for Common
/// </summary>

public class Common
{
    private static SqlConnection con = null;
    
   // DataSet MyDs;
    
    public Common()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    #region Connection Definition
    private static SqlConnection createConnection()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        if (con == null)
            con = new SqlConnection(constr);
        if (con.State == ConnectionState.Closed)
            con.Open();
        return con;
    }
    public SqlConnection getcon()
    {
        SqlConnection retcon;

        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        retcon = new SqlConnection(constr);
        if (retcon.State == ConnectionState.Closed)
            retcon.Open();
        return retcon;

    }
    public SqlConnection getcon1()
    {
        SqlConnection retcon;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        retcon = new SqlConnection(constr);
        if (retcon.State == ConnectionState.Closed)
            retcon.Open();
        return retcon;

    }
    public void CloseCon(SqlConnection con)
    {

        if (con.State == ConnectionState.Open)
            con.Close();
        

    }

#endregion

    #region Datareader


    public SqlDataReader MyReader(string sql, SqlConnection con1)
    {
       
        //string constr = ConfigurationSettings.AppSettings["xboxdb"].ToString();
        //SqlConnection con1 = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(sql, con1);
        //if (con1.State == ConnectionState.Open)
        //    con1.Close();
        //con1.Open();
        SqlDataReader MyRd;
        MyRd = cmd.ExecuteReader();
        //CloseCon(con1);
        return MyRd;
        
    }

    public SqlDataReader MyReader_By_USP(string sql,SqlConnection con1)
    {
        ////SqlConnection con1 = getcon();
        SqlCommand cmd = new SqlCommand("USP_SELECT_TABLE", con1);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@P1", sql);
        
        //if (con1.State == ConnectionState.Open)
        //    con1.Close();
        //con1.Open();
        SqlDataReader MyRd;
        MyRd = cmd.ExecuteReader();
        //CloseCon(con1);
        return MyRd;
        
    }
    //public SqlDataReader MyReader_By_USP(string sql, out SqlConnection con)
    //{
    //    SqlConnection con1 = getcon();
    //    SqlCommand cmd = new SqlCommand("USP_SELECT_TABLE", con1);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@P1", sql);

    //    if (con1.State == ConnectionState.Open)
    //        con1.Close();
    //    con1.Open();
    //    MyRd = cmd.ExecuteReader();
    //    con = con1;
    //    return MyRd;
    //    con1.Close();
    //}
    
    #endregion

    #region Dataset

    // FILL DATASET BY STORED PROCEDURE

    public DataSet MyDataset_By_USP(string Sql, SqlConnection con1)
    {
        DataSet ds = new DataSet();
       // SqlConnection con1 = getcon();
        SqlCommand cmd = new SqlCommand("USP_SELECT_TABLE", con1);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@P1", Sql);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //if (con1.State == ConnectionState.Open)
        //    con1.Close();
        //con1.Open();
        da.Fill(ds);
        return ds;
        //con1.Close();
    }
    #region ResetGrid
    public void Fun_ResetGrid(GridView gv)
    {
        DataTable dt12 = new DataTable();
        gv.DataSource = dt12;
        gv.DataBind();
    }
    #endregion


    // FILL DATASET BY PASSING SQL

    public DataSet MyDataset(string Sql, SqlConnection con1)
    {
        DataSet ds = new DataSet();
        //string constr = ConfigurationSettings.AppSettings["xboxdb"].ToString();
        //SqlConnection con1 = new SqlConnection(constr);
        SqlDataAdapter da = new SqlDataAdapter(Sql, con1);
        //if (con1.State == ConnectionState.Open)
        //    con1.Close();
        //con1.Open();
        da.Fill(ds);
        return ds;
       // con1.Close();

    }

    #endregion

    #region FillDropDownList

    public void fillDDL(DropDownList ddl, string sql, string fdid, string fdesc)
    {
        SqlConnection con = getcon();  
        DataSet ds = MyDataset(sql,con);
        ddl.DataSource = ds;
        ddl.DataTextField = fdesc;
        ddl.DataValueField = fdid;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Please Select--", "0"));
        con.Close();
    }
    public void fillDDL_new(DropDownList ddl, string sql, string fdid, string fdesc)
    {
        SqlConnection con = getcon1();
        DataSet ds = MyDataset(sql, con);
        ddl.DataSource = ds;
        ddl.DataTextField = fdesc;
        ddl.DataValueField = fdid;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Please Select--", "0"));
        con.Close();
    }

    public void fillDDL_Shade(DropDownList ddl, string sql, string fdid, string fdesc)
    {
        SqlConnection con = getcon();
        DataSet ds = MyDataset(sql, con);
        ddl.DataSource = ds;
        ddl.DataTextField = fdesc;
        ddl.DataValueField = fdid;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Please Select--", "0"));
        ddl.Items.Insert(1, new ListItem("Planted", "-1"));
        ddl.Items.Insert(2, new ListItem("PATTERN", "-2"));
        con.Close();
    }
    public DataTable MyDatatable(string Sql, SqlConnection con1)
    {
        DataTable dt = new DataTable();
        //string constr = ConfigurationSettings.AppSettings["xboxdb"].ToString();
        //SqlConnection con1 = new SqlConnection(constr);
        SqlDataAdapter da = new SqlDataAdapter(Sql, con1);
        //if (con1.State == ConnectionState.Open)
        //    con1.Close();
        //con1.Open();
        da.Fill(dt);
        return dt;
        //con1.Close();

    }
    public void fillDDLNormal(DropDownList ddl, string sql, string fdid, string fdesc)
    {

        SqlConnection con = getcon();  
        DataSet ds = MyDataset(sql,con);
        ddl.DataSource = ds;
        ddl.DataTextField = fdesc;
        ddl.DataValueField = fdid;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Please Select--", "0"));
         con.Close ();  
    }

    //public void ConfirmMsg1(System.Web.UI.Page aspxPage, string strMessage)
    //{
    //    string alertScript = "<script language=JavaScript>";
    //    alertScript = alertScript + "var mesag='N';";
    //    alertScript = alertScript + "var TName='';";
    //    alertScript = alertScript + "mesag = confirm('" + strMessage + "');";
    //    alertScript = alertScript + "</script>";
    //    if (!aspxPage.IsClientScriptBlockRegistered("Confirm"))
    //        aspxPage.RegisterClientScriptBlock("Confirm", alertScript);
    //}

    public void fillDDL_By_USP(DropDownList ddl, string sql, string fdid, string fdesc)
    {

        SqlConnection con = getcon();  
        DataSet ds = MyDataset_By_USP(sql,con);
        ddl.DataSource = ds;
        ddl.DataTextField = fdesc;
        ddl.DataValueField = fdid;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Please Select--", "0"));
         con.Close();  
    }


    #endregion
       #region FillListBox
    public void fillListBox(ListBox lstbox, string sql, string fdid, string fdesc)
    {

        SqlConnection con = getcon();  
        DataSet ds = MyDataset(sql,con);
        lstbox.DataSource = ds;
        lstbox.DataTextField = fdesc;
        lstbox.DataValueField = fdid;
        lstbox.DataBind();
         con .Close ();  

    }
    #endregion
    #region FillCheckListBox
    public void fillcheckListBox(CheckBoxList lstbox, string sql, string fdid, string fdesc)
    {

        SqlConnection con = getcon();  
        DataSet ds = MyDataset(sql,con);
        lstbox.DataSource = ds;
        lstbox.DataTextField = fdesc;
        lstbox.DataValueField = fdid;
        lstbox.DataBind();
        con.Close();

    }
     #endregion


    #region FillGridView

    public void fillGridView(GridView gv,string Sql)
    {
        SqlConnection con = getcon();  
        DataSet ds =MyDataset(Sql,con);
        gv.DataSource = ds;
        gv.DataBind();
        con.Close();   
    }

    public void fillGridView_By_USP(GridView gv, string Sql)
    {
        SqlConnection con = getcon();  
        DataSet ds = MyDataset_By_USP(Sql,con);
        gv.DataSource = ds;
        gv.DataBind();
         con.Close ();  
        
    }

    public void fillDataGrid(DataGrid dg, string Sql)
    {
        SqlConnection con = getcon();  
        DataSet ds = MyDataset(Sql,con);
        int cnt = ds.Tables[0].Rows.Count;
        dg.Visible = true;
        if (cnt <= 0)
        {
            dg.Visible = false;
        }
        //dg.CurrentPageIndex = 0;
        dg.DataSource = ds;
        dg.DataBind();
         con .Close ();  
    }

    public void fillDataGrid_By_USP(DataGrid dg, string Sql)
    {
        SqlConnection con = getcon();  
        DataSet ds = MyDataset_By_USP(Sql,con);
        dg.DataSource = ds;
        dg.DataBind();
         con.Close ();  
        
    }

    #endregion

    #region utility functions (check duplicate, Get one Record)

    public bool chkdupl(string tbl, string fld, string txt)
    {
        int cnt;
        string sql = "select count(*) from " + tbl + " where " + fld + "='" + txt + "'";
        int i = 0;
        SqlConnection con = getcon();
        SqlDataReader rd = MyReader(sql,con);
        if (rd.Read())
        {
            cnt = Convert.ToInt32(rd[0].ToString());
            if (cnt >= 1)
            {
                con.Close();
                return true;
            }
        }
        con.Close();
        return false;
    }
    public bool chkdupl1(string sql)
    {
        int cnt;
       // string sql = "select count(*) from " + tbl + " where " + fld + "='" + txt + "'";
        int i = 0;
        SqlConnection con = getcon();
        SqlDataReader rd = MyReader(sql,con);
        if (rd.Read())
        {
            cnt = Convert.ToInt32(rd[0].ToString());
            if (cnt >= 1)
            {
                con.Close();
                return true;
            }
        }
        con.Close();
        return false;
    }
   
    public string getOneRecord(string sqlQry)
    {
        string rec = "";
        createConnection();
        SqlCommand cmd = new SqlCommand(sqlQry, con);
        if (cmd.ExecuteScalar() != null)
        {
           
            rec = cmd.ExecuteScalar().ToString();
          
        }
        if (con.State == ConnectionState.Open)
            con.Close();
        return rec;
        
    }
    public string getpermission(int userid,int pageid)
    {
        string rec = "";
        createConnection();
        string sqlQry = "select Permission from dbo.User_Permission_Retail where User_ID=" + userid + " and Function_ID="+pageid+"";
        SqlCommand cmd = new SqlCommand(sqlQry, con);
        if (cmd.ExecuteScalar() != null)
        {

            rec = cmd.ExecuteScalar().ToString();

        }
        if (con.State == ConnectionState.Open)
            con.Close();
        return rec;

    }

   public void MsgBox1(string msg, Page refP)
    {
        Label lbl = new Label();

        string lb = "window.alert('" + msg + "')";
        ScriptManager.RegisterClientScriptBlock(refP, this.GetType(), "UniqueKey", lb, true);
        refP.Controls.Add(lbl);
    }
    
# endregion

    #region Save & Delete Record

    public void SelRecDel(string str)
    {
        SqlConnection con1 = getcon();
        try
        {
            
            
            
            SqlCommand cmd = new SqlCommand(str, con1);
            cmd.ExecuteNonQuery();
            con1.Close();
        }
        catch (Exception ex)
        {
            con1.Close();
            return;

        }

    }
    //Retail_INS_DEL_SP
     public void SaveRec_By_USP_Int(string Sql, string action , string kfld, string kval, string tblname)
    {


        SqlConnection con = getcon();


        SqlCommand cmd = new SqlCommand("Retail_INS_DEL_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Declare parameters

            cmd.Parameters.Add("@ActFor", SqlDbType.Char, 1).Value = action;
            cmd.Parameters.Add("@Sql", SqlDbType.VarChar, 8000).Value = Sql;
            cmd.Parameters.Add("@KeyFld", SqlDbType.VarChar, 100).Value = kfld;
            cmd.Parameters.Add("@KeyValue", SqlDbType.VarChar, 100).Value = kval;
            cmd.Parameters.Add("@TblName", SqlDbType.VarChar, 100).Value = tblname;
            
            cmd.ExecuteNonQuery();
            con.Close();

        }
   

    #endregion

    public void SaveRec_By_USP(string Sql, string action , string kfld, string kval, string tblname)
    {


        SqlConnection con = getcon();


        SqlCommand cmd = new SqlCommand("USP_INS_DEL_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Declare parameters

            cmd.Parameters.Add("@ActFor", SqlDbType.Char, 1).Value = action;
            cmd.Parameters.Add("@Sql", SqlDbType.VarChar, 8000).Value = Sql;
            cmd.Parameters.Add("@KeyFld", SqlDbType.VarChar, 100).Value = kfld;
            cmd.Parameters.Add("@KeyValue", SqlDbType.VarChar, 100).Value = kval;
            cmd.Parameters.Add("@TblName", SqlDbType.VarChar, 100).Value = tblname;
            
            cmd.ExecuteNonQuery();
            con.Close();

        }
   

    #endregion

    #region Truncate temprorary table

    public void Truncate_tmp_tbl(string tblname)
    {
        SqlConnection con = getcon();
        SqlCommand cmd = new SqlCommand("truncate table " + tblname + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
    }


    public void Delete_tbl_With_Cond(string Qry)
    {
        SqlConnection con = getcon();
        SqlCommand cmd = new SqlCommand(Qry, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
     #endregion


    #region Saving Action Value

    public void GenAction(String ActDesc, DateTime ExeDt, DateTime ExeTm, string SelUsr_Id, string ActRel, string ActSt, string tblName, string Keyfld, string ActionTakenBy)
    {
        //*-----------------------------

        // ---- variable description
        // ----------------------------------------------------------------
        //  ActDesc         for showing description to action control
        //  ExeDt           for storing the expected execution date
        //  ExeTm           for storing the expected excution time 
        //  SelUsr_id       for storing the usrid-> who make the orders
        //  ActRel          for storing the action is related to i.e. order, supply, leave etc
        //  Refid           for stroing the value of order, supply, leave id 
        //  ActTakenByID    for storing the id of person who will take the action

        //------------------------------

        string EntDt = DateTime.Now.ToString();
        string RefId = Convert.ToString(getOneRecord("Select max(" + Keyfld + ") from " + tblName + ""));
        string sql = "";
        string ActCurrID = "";
        sql = "Insert into tblSCSFMS_Actions(ActionDesc,ExeDate,ExeTime,EntryDt,Usr_Id,ActionRel,RefID,ActionTakenByID,ActionStatus)values('"
            + ActDesc + "','" + ExeDt + "','" + ExeTm + "','" + EntDt + "'," + SelUsr_Id + ",'" + ActRel + "'," + RefId + "," + ActionTakenBy + ",'" + ActSt + "')";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();

        ActCurrID = Convert.ToString(getOneRecord("Select max(ActionID) from tblSCSFMS_Actions"));
        sql = "update " + tblName + " set ActionID=" + ActCurrID + " where " + Keyfld + "=" + RefId + " ";

        SqlCommand cmd1 = new SqlCommand(sql, con);
        if (con.State == ConnectionState.Open)
            con.Close();
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();


    }

    #endregion
    public void UpdateOperation(string sql)
    {

        SqlConnection con = getcon();

        SqlCommand cmd1 = new SqlCommand(sql, con);
        if (con.State == ConnectionState.Closed)
        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close();
    }


    
    public string MMDDYYtoYYMMDD(string DDMMYY)
    {
        string Month, Days, Year, YYMMDD1, DDMMYY1 = null;
        int index1, index2, index3 = 0;
        DDMMYY1 = DDMMYY;
        index1 = DDMMYY1.IndexOf("/");
        index2 = DDMMYY1.IndexOf("/", index1 + 1);
        index3 = index2;
        Days = DDMMYY1.Substring(0, index1);
        if (index1 == 1)
        {
            Days = "0" + Days;//Days = "0" + Days;
            index2 = index2 - 2;
        }
        else
            index2 = index2 - 3;

        Month = DDMMYY1.Substring(index1 + 1, index2);
        if ((index1 == 1 && index3 == 3) || (index1 == 2 && index3 == 4))
            Month = "0" + Month;
        Year = DDMMYY1.Substring(index3 + 1, 4);
        YYMMDD1 = Year + "/" + Month + "/" + Days;
        //DDMMYY1 = Days + Month + "/" + Year;
        return YYMMDD1;
    }

    public string MMDDYYtoDDMMYY(string MMDDYY)
    {
        string Month, Days, Year, DDMMYY1, MMDDYY1 = null;
        int index1, index2, index3 = 0;
        MMDDYY1 = MMDDYY;
        index1 = MMDDYY1.IndexOf("/");
        index2 = MMDDYY1.IndexOf("/", index1 + 1);
        index3 = index2;
        Month = MMDDYY1.Substring(0, index1);
        if (index1 == 1)
        {
            Month = "0" + Month;//Days = "0" + Days;
            index2 = index2 - 2;
        }
        else
            index2 = index2 - 3;

        Days = MMDDYY1.Substring(index1 + 1, index2);
        if ((index1 == 1 && index3 == 3) || (index1 == 2 && index3 == 4))
            Days = "0" + Days;
        Year = MMDDYY1.Substring(index3 + 1, 4);
        DDMMYY1 = Days + "/" + Month + "/" + Year;
        //DDMMYY1 = Days + Month + "/" + Year;
        return DDMMYY1;
    }
    public string MMDDYYtoMMDDYY(string MMDDYY)
    {
        string Month, Days, Year, DDMMYY1, MMDDYY1 = null;
        int index1, index2, index3 = 0;
        MMDDYY1 = MMDDYY;
        index1 = MMDDYY1.IndexOf("/");
        index2 = MMDDYY1.IndexOf("/", index1 + 1);
        index3 = index2;
        Month = MMDDYY1.Substring(0, index1);
        if (index1 == 1)
        {
            Month = "0" + Month;//Days = "0" + Days;
            index2 = index2 - 2;
        }
        else
            index2 = index2 - 3;

        Days = MMDDYY1.Substring(index1 + 1, index2);
        if ((index1 == 1 && index3 == 3) || (index1 == 2 && index3 == 4))
            Days = "0" + Days;
        Year = MMDDYY1.Substring(index3 + 1, 4);
        DDMMYY1 = Month + "/" + Days + "/" + Year;
        return DDMMYY1;

    }
    #region FillListBox by manish
    public void filllistbox(ListBox list, string sql, string flid, string flesc)
    {
        SqlConnection con = getcon();
        SqlDataReader reader = MyReader(sql, con);
        list.DataTextField = flesc;
        list.DataValueField = flid;
        list.DataSource = reader;
        list.DataBind();
        con.Close();
    }
    #endregion
    public string DDMMYYtoMMDDYY(string DDMMYY)
    {
        string Month, Days, Year, DDMMYY1, MMDDYY1 = null;
        int index1, index2, index3 = 0;
        DDMMYY1 = DDMMYY;
        index1 = DDMMYY1.IndexOf("/");
        index2 = DDMMYY1.IndexOf("/", index1 + 1);
        index3 = index2;
        Days = DDMMYY1.Substring(0, index1);

        if (index1 == 1)
        {
            Days = "0" + Days;//Month = "0" + Month;
            index2 = index2 - 2;
        }
        else
            index2 = index2 - 3;
        Month = DDMMYY1.Substring(index1 + 1, index2);
        if ((index1 == 1 && index3 == 3) || (index1 == 2 && index3 == 4))
            Month = "0" + Month;
        Year = DDMMYY1.Substring(index3 + 1, 4);
        MMDDYY1 = Month + "/" + Days + "/" + Year;
        return MMDDYY1;
    }
    

    #region Existance Of Data
    public bool IsExist(string strsql)
    {
        createConnection();
        SqlCommand mcmd = new SqlCommand(strsql, con);
        mcmd.CommandType = CommandType.Text;
        mcmd.CommandText = strsql;
        int intresult = (int)mcmd.ExecuteScalar();
        if (intresult > 0)
        {
            con.Close();
            return true;
        }

        else
        {
            con.Close();
            return false;
        }

    }
    #endregion


    #region Convert to Excel

    public void ConvertXL(string sql,HttpResponse Response)
    {
        SqlConnection con = getcon();  
        DataSet ds = new DataSet();
        ds = MyDataset_By_USP(sql,con);

        Response.Clear();
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        dg.DataSource = ds.Tables[0];
        int cnt = ds.Tables[0].Rows.Count;
        dg.DataBind();
        dg.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        ds.Dispose();
         con.Close ();  
    }

    public void ConvertXLByUSP(DataSet ds, HttpResponse Response)
    {

        Response.Clear();
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        dg.DataSource = ds.Tables[0];
        int cnt = ds.Tables[0].Rows.Count;
        dg.DataBind();
        dg.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        ds.Dispose();
    }

    #endregion






    public void MsgBox1(string p)
    {
        throw new NotImplementedException();
    }
}
