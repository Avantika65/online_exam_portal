using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//namespace OnLineTest
/// <summary>
/// Summary description for DBConnection
/// </summary>
public class DbConnection:Base 
{
    public SqlConnection con;
	public DbConnection()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        //con = new SqlConnection("Data Source=.;Initial Catalog=FeesManagement;UID=sa;Pwd=;Integrated Security=False;");
	}
    ~DbConnection()
    {
        this.Dispose();
    }
     
}
namespace DataAccLayer
{
    /// <summary>
    /// Summary description for DbFunctions
    /// </summary>
    public class DbConnection
    {
        public SqlConnection con;
        public string ConnectionString;
        public DbConnection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(ConnectionString);// new SqlConnection("Data Source=.;Initial Catalog=Library;UID=sa;Pwd=;Integrated Security=False;");
        }
    }
    public class DbFunctions
    {
        DbConnection objCon;

        SqlCommand com;
        SqlDataAdapter da;
        public SqlDataReader dr;
        DataSet ds;
        public DbFunctions()
        {
            objCon = new DbConnection();
        }

        public string ValidateUserLogin(string sql)
        {
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            string UserName = com.ExecuteScalar().ToString();
            com.Connection.Close();
            return UserName;
        }
        public void controlButton(Button cmdI, Button cmdU, string perm)
        {
            char[] separator = new char[] { '|' };
            string[] arr = perm.Split(separator);
            if (cmdI.Text.ToLower() != "update")
            {
                cmdI.Enabled = (arr[0].ToString() == "1" ? true : false);
            }
            else
            {
                cmdI.Enabled = (arr[1].ToString() == "1" ? true : false);
            }
            //cmdD.Enabled = (arr[2].ToString() == "1" ? true : false);
            arr = null;
        }
        public string viewAllow(string uid)
        {
            string retView = "";
            string sqlstr = "select deptID,CourseID,yearsemID,subjectID,topicID,subtopicID from Assignrolechild where assignroleid='" + uid + "'"; //(select id from Assignroles where individualid='" + uid + "')";
            com = new SqlCommand(sqlstr, objCon.con);
            com.Connection.Open();
            SqlDataReader sdr = null;
            sdr = com.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                retView = sdr[0].ToString() + "|" + sdr[1].ToString() + "|" + sdr[2].ToString() + "|" + sdr[3].ToString() + "|" + sdr[4].ToString() + "|" + sdr[5].ToString();

            }
            //colValue = com.ExecuteScalar();
            com.Connection.Close();
            return retView;
        }

        public object FetchScalar(string sql)
        {
            object colValue = "";
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            colValue = com.ExecuteScalar();
            com.Connection.Close();
            return colValue;
        }

        public void FetchRecordsByTable(DataTable dTable, string sql)
        {
            da = new SqlDataAdapter(sql, objCon.con);
            da.Fill(dTable);
        }

        public SqlDataReader FetchRecordsByDataReader(SqlDataReader dr, string sql)
        {
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            dr = com.ExecuteReader();
            dr.Close();
            com.Dispose();
            objCon.con.Close();
            objCon.con.Dispose();
            return dr;
        }

        public void CloseConnection()
        {
            objCon.con.Close();
            objCon.con.Dispose();
        }
        public SqlDataReader FetchRecordsByDataReader(string sql)
        {
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            dr = com.ExecuteReader();
            com.Dispose();
            objCon.con.Close();
            objCon.con.Dispose();
            return dr;
        }

        public void CloseConnections()
        {
            dr.Close();
            com.Connection.Close();
        }
        public int ExecuteDML(string sql)
        {
            int rowInserted = 0;
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            rowInserted = com.ExecuteNonQuery();
            com.Connection.Close();
            return rowInserted;
        }
        //public string ExecuteScaler(string sql)
        //{
        //    string var = string.Empty;

        //    com = new SqlCommand(sql, objCon.con);
        //    com.Connection.Open();
        //    var = com.ExecuteNonQuery();
        //    com.Connection.Close();
        //    return var;
        //}
        public void FillGridVIew(DataGrid grd, string sql)
        {
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                grd.DataSource = dr;
                grd.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                grd.DataSource = dt;
                grd.DataBind();
                dt.Dispose();
            }
            CloseConnection();
        }
        public void FillGridView(GridView dg, string sql)
        {
            DataTable dt = new DataTable();

            FetchRecordsByTable(dt, sql);
            dg.DataSource = dt;
            dg.DataBind();
        }

        public Int16 GetRowCount(string sql)
        {
            Int16 rowCount = 0;
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            object objVal = com.ExecuteScalar();
            //Session["test"] = objVal;
            if (objVal.ToString().Trim().Equals("NULL"))
                rowCount = 0;
            else
                rowCount = Convert.ToInt16(objVal);
            com.Connection.Close();
            return rowCount;
        }

        public void FillDropdownlist(DropDownList ddl, string TextFieldName, string ValueFieldName, string sql, string ZeroIndexVal)
        {
            ddl.Items.Clear();
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = TextFieldName;
                ddl.DataValueField = ValueFieldName;
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.DataSource = dr;
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            //ddl.Items.Add("--Select--");
            CloseConnection();
        }

        public void FillListBox(ListBox ddl, string TextFieldName, string ValueFieldName, string sql, string ZeroIndexVal)
        {
            ddl.Items.Clear();
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = TextFieldName;
                ddl.DataValueField = ValueFieldName;
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.DataSource = dr;
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }

            com.Connection.Close();
        }

        public void FillCheckboxlist(CheckBoxList chk, string TextFieldName, string ValueFieldName, string sql)
        {
            chk.Items.Clear();
            com = new SqlCommand(sql, objCon.con);
            com.Connection.Open();
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                chk.DataSource = dr;
                chk.DataTextField = TextFieldName;
                chk.DataValueField = ValueFieldName;
                chk.DataBind();

            }
            dr.Close();
            com.Connection.Close();
            com.Connection.Dispose();
            com.Dispose();
            CloseConnection();
        }
        public void FillGridVIew(GridView grd, string sql)
        {
            da = new SqlDataAdapter(sql, objCon.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds.Tables[0];
                grd.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                grd.DataSource = dt;
                grd.DataBind();
                dt.Dispose();
            }
        }

        public void FillGrid(DataGrid dg, string sql)
        {
            da = new SqlDataAdapter(sql, objCon.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dg.DataSource = ds;
                dg.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                dg.DataSource = ds;
                dg.DataBind();

                int columnCount = dg.Items[0].Cells.Count;
                dg.Items[0].Cells.Clear();

                dg.Items[0].Cells.Add(new TableCell());
                dg.Items[0].Cells[0].ColumnSpan = columnCount;
                dg.Items[0].Cells[0].Text = "No Records Found";

                //dg.Items[0].Cells[0].CssClass = "TextField"; 
                dg.Items[0].Cells[0].BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }
        public DataTable FillDataTable(string sql)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(sql, objCon.con);

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }

            }
            catch { }
            finally { ds.Dispose(); }
            return dt;

        }
        //public void FillDataTable(string sql, ref DataTable dtRec)
        //{
        //    //DataTable dt = new DataTable();
        //    com = new SqlCommand(sql, objCon.con);

        //    //---------------------
        //    //DataTable dt = new DataTable();
        //    //com.CommandText = sql;
        //    com.CommandTimeout = 320;
        //    com.CommandType = CommandType.Text;
        //    com.Connection = objCon.con;

        //    try
        //    {
        //        com.Connection.Open();
        //        da = new SqlDataAdapter(com);

        //        da.Fill(dtRec);
        //    }
        //    catch { }
        //    finally { }

        //}
        //public DataTable FillDataTable1(string sql)
        //{
        //    DataTable dt;// = new DataTable();
        //    da = new SqlDataAdapter(sql, objCon.con);
        //    da.Fill(dt);

        //    return dt;
        //}
        public DataSet FillDataSet(DataSet ds, string sql)
        {
            da = new SqlDataAdapter(sql, objCon.con);
            da.Fill(ds);
            da.Dispose();

            return ds;
        }

        public string Get_details(string sql)
        {
            da = new SqlDataAdapter(sql, objCon.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string retval = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                retval = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                retval = "";
            }
            return retval;
        }
        public Int32 GenerateID(string strTablename, string strFldname)
        {
            com = new SqlCommand();
            com.Connection = objCon.con;
            com.Connection.Open();

            com.CommandText = "select coalesce(max(" + strFldname + "),'0',max(" + strFldname + ")) from " + strTablename;
            int ID = Convert.ToInt32(com.ExecuteScalar()) + 1;
            com.Connection.Close();
            return ID;
        }
        //public string GenerateID(string strTablename, string strFldname)
        //{
        //    com = new SqlCommand();
        //    com.Connection = objCon.con;
        //    com.Connection.Open();

        //    com.CommandText = "select coalesce(max(" + strFldname + "),'0',max(" + strFldname + ")) from " + strTablename;
        //    int ID = Convert.ToInt32(com.ExecuteScalar()) + 1;
        //    com.Connection.Close();
        //    string strID = string.Empty;
        //    if (ID < 10)
        //    {
        //        strID = "0" + ID.ToString();
        //    }
        //    else
        //    {
        //        strID = ID.ToString();
        //    }
        //    return strID;
        //}
        public string GenerateIDByCodition(string strTablename, string strFldname, string InstId)
        {
            com = new SqlCommand();
            com.Connection = objCon.con;
            com.Connection.Open();

            com.CommandText = "select coalesce(max(" + strFldname + "),'0',max(" + strFldname + ")) from " + strTablename + " where InstituteID=" + InstId;
            int ID = Convert.ToInt32(com.ExecuteScalar()) + 1;
            com.Connection.Close();
            string strID = string.Empty;
            if (ID < 10)
            {
                strID = "0" + ID.ToString();
            }
            else
            {
                strID = ID.ToString();
            }
            return strID;
        }


    }
}
