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
using System.IO;
using NewDAL;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;


/// <summary>
/// Summary description for DbFunctions
/// </summary>
public class DbFunctions : Base
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
    ~DbFunctions()
    {
        base.Dispose();
        // this.Dispose();
    }
    public string decrypt(string val, string seed)
    {
        byte[] KEY_64 = Convert.FromBase64String(seed);
        byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        byte[] buffer = Convert.FromBase64String(val);
        MemoryStream ms = new MemoryStream(buffer);
        CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
        StreamReader sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }
    public string ValidateUserLogin(string sql)
    {
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        string UserName = com.ExecuteScalar().ToString();
        com.Connection.Close();
        return UserName;
    }
    public byte[] CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return buff;
    }
    public string encrypt(string Text, byte[] Key)
    {
        byte[] KEY_64 = null;
        KEY_64 = Key;
        byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        if (Text != string.Empty)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(Text);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }
        else
        {
            return "";

        }
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


    public void controlPerm(Button cmdI, Button cmdU, Button cmdD, string perm)
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
        cmdD.Enabled = (arr[2].ToString() == "1" ? true : false);
        arr = null;
    }

    public string viewAllow(string uid)
    {
        string retView = "";

        string sqlstr = "select * from AssignRoleChild where assignroleid='" + uid + "'"; //(select id from Assignroles where individualid='" + uid + "')";

        com = new SqlCommand(sqlstr, objCon.con);
        com.Connection.Open();
        SqlDataReader sdr = null;
        sdr = com.ExecuteReader();

        if (sdr.HasRows)
        {
            sdr.Read();
            retView = sdr[0].ToString() + "|" + sdr[1].ToString() + "|" + sdr[2].ToString() + "|" + sdr[3].ToString();// +"|" + sdr[4].ToString() + "|" + sdr[5].ToString();

        }
        //colValue = com.ExecuteScalar();
        sdr.Close();
        sdr.Dispose();

        com.Connection.Close();
        return retView;
    }

    public object FetchScalar(string sql)
    {
        object colValue = "";
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
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
        com.Connection.Close();
        return dr;
    }

    public void CloseConnection()
    {
        //  com.Connection.Close();
    }
    public SqlDataReader FetchRecordsByDataReader(string sql)
    {
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        dr = com.ExecuteReader();
        return dr;
    }

    public void CloseConnections()
    {
        dr.Close();
        com.Connection.Close();
    }
    public void ExecuteDML1(string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }

        com = new SqlCommand(sql, objCon.con);
        com.CommandTimeout = 300;
        com.Connection.Open();
        com.ExecuteNonQuery();
        com.Connection.Close();

    }

    public int ExecuteDML2(string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        int rowInserted = 0;
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        rowInserted = com.ExecuteNonQuery();
        com.Connection.Close();
        return rowInserted;

    }

    public int ExecuteDML(string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        int rowInserted = 0;
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        rowInserted = com.ExecuteNonQuery();
        com.Connection.Close();
        return rowInserted;
    }

    public void FillGridVIew(DataGrid grd, string sql)
    {
        //com = new SqlCommand(sql, objCon.con);
        //com.Connection.Open();
        //dr = com.ExecuteReader();
        da = new SqlDataAdapter(sql, objCon.con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = ds;
            grd.DataBind();
        }
        //if (dr.HasRows)
        //{
        //    grd.DataSource = dr;
        //    grd.DataBind();
        //}
        else
        {
            DataTable dt = new DataTable();
            grd.DataSource = dt;
            grd.DataBind();
            dt.Dispose();
        }
        //com.Connection.Close();
    }
    public void FillGridView(GridView grd, string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        da = new SqlDataAdapter(sql, objCon.con);
        DataSet ds = new DataSet();
        try
        {
            da.SelectCommand.CommandTimeout = 1000;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds;
                grd.DataBind();
            }
        }
        finally
        {
            ds.Dispose();
            objCon.con.Close();
            //objCon.con.Dispose();
            //objCon.Dispose();
        }
        //  CloseConnection();
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
    public void FillDestination(DropDownList ddl)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillDesitination");
        try
        {

            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "Destination";
                ddl.DataValueField = "DID";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");

            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void Fillsession(DropDownList ddl, string instituteid, string batchid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "batchid", batchid, DbType.String);
        objDB.AddParameters(1, "instituteid", Int32.Parse("3"), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSession");
        try
        {
            if (dr != null)
            {

                ddl.DataSource = dr;
                ddl.DataTextField = "sessionyear";
                ddl.DataValueField = "sessionyear";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }

            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void Fillsession(DropDownList ddl, string instituteid, string batchid, string ZeroIndexVal, MasterDataDataContext msd)
    {
        ddl.Items.Clear();
        var course = from c in msd.GetSession(batchid, Int32.Parse(instituteid))
                     select c;

        ddl.DataSource = course.ToList();
        ddl.DataTextField = "sessionyear";
        ddl.DataValueField = "sessionyear";
        ddl.DataBind();
        if (ZeroIndexVal != "")
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }

    }
    public void FillSubject(GridView gv, string instituteid, string Courseid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectList");
        try
        {
            if (dr.Read())
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void FillSubjectlist(GridView gv, string instituteid, string Courseid, string spelid, string Semester)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        objDB.AddParameters(2, "SpecilisationID", Int32.Parse(spelid), DbType.Int32);
        objDB.AddParameters(3, "Semester", Int32.Parse(Semester), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectList");
        try
        {
            if (dr.HasRows)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void FillSubject(GridView gv, string SubjectID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SubjectID", Int32.Parse(SubjectID), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopic");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void FillFacultyGV(GridView gv, string instituteID, string DepartmentID, string FacultyID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "instituteID", Int32.Parse(instituteID), DbType.Int32);
        objDB.AddParameters(1, "DepartmentID", Int32.Parse(DepartmentID), DbType.Int32);
        objDB.AddParameters(2, "FacultyID", Int32.Parse(FacultyID), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetFacultyDetail");
        try
        {
            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void FillSubjectddl(DropDownList ddl, string instituteid, string Courseid)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectList");
        try
        {




            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "SubjectName";
                ddl.DataValueField = "SubjectID";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    public void FillDepartment(DropDownList ddl, string instituteid)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillDepartment");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "DepartmentName";
                ddl.DataValueField = "DepartmentID";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    public void FillDesignation(DropDownList ddl, string instituteid)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillDesignation");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "Designation";
                ddl.DataValueField = "DesigId";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    public DataTable ViewAlreadyGenratedPsw(int InstituteID, string SessionID, int CourseID, int sid, int Specialization, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        try
        {
            objDB.CreateParameters(6);
            objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
            objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
            objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
            objDB.AddParameters(3, "sid", sid, DbType.Int32);
            objDB.AddParameters(4, "Specialization", Specialization, DbType.Int32);
            objDB.AddParameters(5, "flag", flag, DbType.Int32);

            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FindStudent(string InstituteID, string SessionID, int StudentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(InstituteID), DbType.Int32);
        objDB.AddParameters(1, "Session", SessionID, DbType.String);
        objDB.AddParameters(2, "StudentID", StudentID, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FindStudent");
        return dt;
    }
    public void FillCity(DropDownList ddl)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillCity");
        try
        {

            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "CityName";
                ddl.DataValueField = "CityId";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    public void FillCity(DropDownList ddl, MasterDataDataContext msd)
    {
        ddl.Items.Clear();

        var course = from c in msd.FillCity()
                     select c;

        ddl.DataSource = course.ToList();
        ddl.DataTextField = "CityName";
        ddl.DataValueField = "CityId";
        ddl.DataBind();
        ddl.Items.Insert(0, "---Select---");
        ddl.Items[0].Value = "0";

    }
    public void FillState(DropDownList ddl)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillState");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "statename";
                ddl.DataValueField = "stateid";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }
    public void FillCountry(DropDownList ddl)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillCountry");
        try
        {

            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "CountryName";
                ddl.DataValueField = "CountryId";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }
    public void FillTopicddlBySubjectID(DropDownList ddl, string subjectID)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "subjectID", Int32.Parse(subjectID), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicBySubjectID");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "TopicName";
                ddl.DataValueField = "TopicID";
                ddl.DataBind();
                ddl.Items.Insert(0, "---Select---");
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Add("---Select---");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }
    public void FillSubTopicGV(GridView gv, string Courseid, string SubjecID, string TopicID, string subTopicID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        objDB.AddParameters(1, "TopicID", Int32.Parse(TopicID), DbType.Int32);
        objDB.AddParameters(2, "SubjectID", Int32.Parse(SubjecID), DbType.Int32);
        objDB.AddParameters(3, "SubTopicID", Int32.Parse(subTopicID), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicByCondition");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }
    public void FillCourseWithChildGV(GridView gv, string Courseid, string InstituteID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(InstituteID), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "CourseWithChild");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    //-------------------------------------------------------------------------------------------------------------------

    public void FillCourseStudentBatch(GridView gv, string Courseid, string InstituteID, string SpecilizationID, string Semester, string Session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(InstituteID), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        objDB.AddParameters(2, "SpecilizationID", Int32.Parse(SpecilizationID), DbType.Int32);
        objDB.AddParameters(3, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(4, "Session", Session, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCourseStudentBatch");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }


    public void FillCoursespecilization(GridView gv, string Courseid, string InstituteID, string SpecilizationID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(InstituteID), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        objDB.AddParameters(2, "SpecilizationID", Int32.Parse(SpecilizationID), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCourseSpecilization");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }



    public void FillForSubjectImportGV(GridView gv, string CourseID, string YearID, string SemesterID, string SessionID, string Batch, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(1, "YearID", Int32.Parse(YearID), DbType.Int32);
        objDB.AddParameters(2, "SemesterID", Int32.Parse(SemesterID), DbType.Int32);
        objDB.AddParameters(3, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(4, "Batch", Batch, DbType.String);
        objDB.AddParameters(5, "flag", flag, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetImport_Subject");
        if (dr.Read())
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }
    //--------------------------Fill subject from subject Master---------------------------------------
    public void FillSubjectFromMasterGV(GridView gv, string CourseID, string splid, string Semester, string inst_ID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(1, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(2, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(3, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSubjectFormMaster");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }
    //-----------------------------------------------------------------------------------------------------

    public void FillSubjectlistforFaculty(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListforFaculty");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }
    //-------------------------------------------------------------------------------------------------
    public void FillSubjectlistHODApproval(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string Batch_ID, string empid, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "Batch_ID", Int32.Parse(Batch_ID), DbType.Int32);
        objDB.AddParameters(6, "empid", Int32.Parse(empid), DbType.Int32);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListforHODapproval");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }
    //--------------------------------------------------------------------------------------------------
    public void FillYear(DropDownList ddl, string courseid, string batchid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CourseID", Int32.Parse(courseid), DbType.Int32);
        objDB.AddParameters(1, "Batch", batchid, DbType.String);
        objDB.AddParameters(2, "type", "Y", DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYear");
        try
        {
            if (dr.HasRows)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "yr";
                ddl.DataValueField = "yearid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }
    //public void FillYear(DropDownList ddl, string courseid, string batchid, string ZeroIndexVal, MasterDataDataContext msd)
    //{
    //    ddl.Items.Clear();

    //    var course = from c in msd.GetYear(Int32.Parse(courseid), batchid, "y")
    //                 select c;

    //    ddl.DataSource = course.ToList();
    //    ddl.DataTextField = "yr";
    //    ddl.DataValueField = "yearid";
    //    ddl.DataBind();
    //    if (ZeroIndexVal != "")
    //    {
    //        ddl.Items.Insert(0, ZeroIndexVal);
    //        ddl.Items[0].Value = "0";
    //    }
    //    else
    //    {
    //        ddl.Items.Insert(0, ZeroIndexVal);
    //        ddl.Items[0].Value = "0";
    //    }

    //}
    public void FillYearByBatch(DropDownList ddl, string courseid, string batchid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseID", Int32.Parse(courseid), DbType.Int32);
        objDB.AddParameters(1, "Batch", batchid, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearByBatch");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "yr";
                ddl.DataValueField = "yearid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }

    public void FillSubjects(DropDownList ddl, int instid, string sessionid, int facultyid, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "InstiId", instid, DbType.Int32);
        objDB.AddParameters(1, "SessionId", sessionid, DbType.String);
        objDB.AddParameters(2, "Facultid", facultyid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Bind_Subjects_Semester_Faculty_Wise");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "SubjectName";
                ddl.DataValueField = "SubjectID";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }

    //public void FillYearByBatch(DropDownList ddl, string courseid, string batchid, string ZeroIndexVal)
    //{
    //    ddl.Items.Clear();
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(2);
    //    objDB.AddParameters(0, "CourseID", Int32.Parse(courseid), DbType.Int32);
    //    objDB.AddParameters(1, "Batch", batchid, DbType.String);
    //    SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearByBatch");
    //    if (dr.HasRows)
    //    {
    //        ddl.DataSource = dr;
    //        ddl.DataTextField = "yr";
    //        ddl.DataValueField = "yearid";
    //        ddl.DataBind();
    //        if (ZeroIndexVal != "")
    //        {
    //            ddl.Items.Insert(0, ZeroIndexVal);
    //            ddl.Items[0].Value = "0";
    //        }
    //        else
    //        {
    //            ddl.Items.Insert(0, ZeroIndexVal);
    //            ddl.Items[0].Value = "0";
    //        }
    //    }
    //    else
    //    {
    //        ddl.Items.Insert(0, ZeroIndexVal);
    //        ddl.Items[0].Value = "0";
    //    }
    //}
    public void FillSemester(DropDownList ddl, string courseid, string SemesterID, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CourseID", Int32.Parse(courseid), DbType.Int32);
        objDB.AddParameters(1, "Batch", SemesterID, DbType.String);
        objDB.AddParameters(2, "type", "Y", DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "Semestern";
                ddl.DataValueField = "Semesterid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillSemester(DropDownList ddl, string courseid, string SemesterID, string ZeroIndexVal, MasterDataDataContext msd)
    {
        ddl.Items.Clear();

        var course = from c in msd.GetSemester(Int32.Parse(courseid), SemesterID, Convert.ToChar(1))
                     select c;

        ddl.DataSource = course.ToList();
        ddl.DataTextField = "Semestern";
        ddl.DataValueField = "Semesterid";
        ddl.DataBind();
        if (ZeroIndexVal != "")
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }

    }
    public void FillBatch(DropDownList ddl, string institute, string courseid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(institute), DbType.Int32);
        objDB.AddParameters(1, "courseid", Int32.Parse(courseid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCourseBatch");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "Batch";
                ddl.DataValueField = "Batch";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }
    public void FillBatchChk(CheckBoxList chk, string institute, string courseid, string ZeroIndexVal)
    {
        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(institute), DbType.Int32);
        objDB.AddParameters(1, "courseid", Int32.Parse(courseid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCourseBatch");
        try
        {


            if (dr != null)
            {
                chk.DataSource = dr;
                chk.DataTextField = "Batchcode";
                chk.DataValueField = "Batchcode";
                chk.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }

    public void FillBatch(DropDownList ddl, string instituteid, string courseid, string ZeroIndexVal, MasterDataDataContext msd)
    {
        ddl.Items.Clear();
        var course = from c in msd.GetCourseBatch(Int32.Parse(instituteid), Int32.Parse(courseid))
                     select c;

        ddl.DataSource = course.ToList();
        ddl.DataTextField = "Batchcode";
        ddl.DataValueField = "Batchcode";
        ddl.DataBind();
        if (ZeroIndexVal != "")
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }

    }
    public void FillInstitute(DropDownList ddl, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetInstitute");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "collegename";
                ddl.DataValueField = "Collegeid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }

    public void FillCourse(DropDownList ddl, string instituteid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCourse");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "coursename";
                ddl.DataValueField = "courseid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }
    public void FillWeek(DropDownList ddl, string instituteid, string sessionyear, string courseid, string splid, string semid, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "instituteid", instituteid, DbType.Int32);
        objDB.AddParameters(1, "SessionYear", sessionyear, DbType.String);
        objDB.AddParameters(2, "CourseID", courseid, DbType.Int32);
        objDB.AddParameters(3, "SplId", splid, DbType.Int32);
        objDB.AddParameters(4, "semid", semid, DbType.Int32);
        objDB.AddParameters(5, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Week_Select");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "weekname";
                ddl.DataValueField = "weekdate";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }
    public void FillSpecilization(DropDownList ddl, string instituteid, string courseid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(courseid), DbType.Int32);
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GetSpecilization");
        try
        {
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "shortName";
                ddl.DataValueField = "SpecilizationID";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {           
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }

    public void FillCourse(DropDownList ddl, string instituteid, string ZeroIndexVal, MasterDataDataContext msd)
    {
        ddl.Items.Clear();
        var course = from c in msd.GetCourse(Int32.Parse(instituteid))
                     select c;

        ddl.DataSource = course.ToList();
        ddl.DataTextField = "coursename";
        ddl.DataValueField = "courseid";
        ddl.DataBind();
        if (ZeroIndexVal != "")
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }

    }

    public int ExecuteDML_Excel(string sql)
    {
        objCon.con.Open();
        int rowInserted = 0;
        SqlCommand Excel = new SqlCommand(sql, objCon.con);
        Excel.CommandTimeout = 0;
        rowInserted = Excel.ExecuteNonQuery();
        objCon.con.Close();
        return rowInserted;
    }

    public void FillDropdownlist(DropDownList ddl, string TextFieldName, string ValueFieldName, string sql, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        dr = com.ExecuteReader();
        try
        {
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
                // ddl.DataSource = dr;
                // ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }

        finally
        {
            dr.Close();
            dr.Dispose();
            com.Connection.Close();
            //objCon.con.Dispose();
        }
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

    public void FillCBL(CheckBoxList chk, string ctype, int courseid, string batchid, string sessnid, int instid)
    {

        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "ctype", ctype, DbType.String);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "batch", batchid, DbType.String);
        objDB.AddParameters(3, "sessn", sessnid, DbType.String);
        objDB.AddParameters(4, "instid", instid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem");
        try
        {
            if (dr != null)
            {
                chk.DataSource = dr;
                chk.DataTextField = "yr";
                chk.DataValueField = "sid";
                chk.DataBind();

            }
        }
        finally
        {
            dr.Close();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
        }
    }

    public void FillCheckboxlist(CheckBoxList chk, string TextFieldName, string ValueFieldName, string sql)
    {
        chk.Items.Clear();

        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        dr = com.ExecuteReader();
        try
        {
            if (dr.HasRows)
            {
                chk.DataSource = dr;
                chk.DataTextField = TextFieldName;
                chk.DataValueField = ValueFieldName;
                chk.DataBind();

            }
        }
        finally
        {
            dr.Close();
            com.Connection.Close();
            objCon.con.Dispose();
        }

    }
    public void FillRadiolist(RadioButtonList chk, string TextFieldName, string ValueFieldName, string sql)
    {
        if (chk.Items.Count >= 0)
        {
            chk.Items.Clear();
        }
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();

        }

        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        dr = com.ExecuteReader();

        if (dr.HasRows)
        {
            dr.GetString(0);
            chk.DataSource = dr;
            chk.DataTextField = TextFieldName;
            chk.DataValueField = ValueFieldName;
            chk.DataBind();

        }
        com.Connection.Close();
    }
    public void FillGridVIew(GridView grd, string sql)
    {
        objCon.con.Open();
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
        CloseConnection();
    }
    public void FillGridVIew1(GridView grd, string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
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
        CloseConnection();
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
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        da = new SqlDataAdapter(sql, objCon.con);
        try
        {
            da.Fill(dt);
        }
        finally
        {
            da.Dispose();
            objCon.con.Close();
            objCon.con.Dispose();
        }
        //     CloseConnection();
        return dt;
    }
    //public DataTable FillDataTable1(string sql)
    //{
    //    DataTable dt;// = new DataTable();
    //    da = new SqlDataAdapter(sql, objCon.con);
    //    da.Fill(dt);

    //    return dt;
    //}
    public void FillDataSet(DataSet ds, string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        da = new SqlDataAdapter(sql, objCon.con);
        da.Fill(ds);
        da.Dispose();
        objCon.con.Close();
        objCon.con.Dispose();
    }
    public void FillDataSet1(DataSet ds, string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        SqlDataAdapter daa = new SqlDataAdapter(sql, objCon.con);
        daa.Fill(ds);
        daa.Dispose();
        objCon.con.Close();
        objCon.con.Dispose();
    }
    public string Get_details(string sql)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string detail = String.Empty;
        try
        {
            SqlConnection con = new SqlConnection(objDB.ConnectionString);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            if (ad.SelectCommand.ExecuteScalar() != null)
            {
                detail = ad.SelectCommand.ExecuteScalar().ToString();
            }
            ad.Dispose();
            con.Close();
            con.Dispose();
        }
        finally
        {
            //  objDB.DataReader.Close();
            //    objDB.DataReader.Dispose();
            objDB.Connection.Close();
            //objDB.Connection.Dispose();
            //objDB.Dispose();
        }
        return detail;

    }


    public string Get_detailsAll(string sql)
    {
        string retval = "";
        SqlDataAdapter ad = new SqlDataAdapter();
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        SqlCommand cmd = new SqlCommand(sql, objCon.con);
        ad.SelectCommand = cmd;
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (retval == "")
                {
                    retval = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
                else
                {
                    retval = retval + "^" + ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
            }

        }
        //while (reader.Read())
        //{


        //}
        //reader.Close();
        return retval;
    }
    public string Get_detailsAllC(string sql, string Opr)
    {
        string retval = "";
        SqlDataAdapter ad = new SqlDataAdapter();
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        SqlCommand cmd = new SqlCommand(sql, objCon.con);
        ad.SelectCommand = cmd;
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (retval == "")
                {
                    retval = "'" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                }
                else
                {
                    retval = retval + Opr.ToString() + "'" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";
                }
            }

        }
        //while (reader.Read())
        //{


        //}
        //reader.Close();
        return retval;
    }
    public string Get_detailsAll(string sql, string Opr)
    {
        string retval = "";
        SqlDataAdapter ad = new SqlDataAdapter();
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        SqlCommand cmd = new SqlCommand(sql, objCon.con);
        ad.SelectCommand = cmd;
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (retval == "")
                {
                    retval = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
                else
                {
                    retval = retval + Opr.ToString() + ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
            }

        }
        //while (reader.Read())
        //{


        //}
        //reader.Close();
        return retval;
    }
    public Int32 GenerateID1(string strTablename, string strFldname)
    {
        com = new SqlCommand();
        com.Connection = objCon.con;
        com.Connection.Open();

        com.CommandText = "select coalesce(max(" + strFldname + "),'0',max(" + strFldname + ")) from " + strTablename;
        int ID = Convert.ToInt32(com.ExecuteScalar()) + 1;
        com.Connection.Close();

        return ID;
    }
    public string Get_detailsAllvalues(string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        string retval = "";
        SqlDataAdapter ad = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(sql, objCon.con);
        ad.SelectCommand = cmd;
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (retval == "")
                {
                    retval = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
                else
                {
                    retval = retval + "," + ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
            }

        }
        //while (reader.Read())
        //{


        //}
        //reader.Close();
        return retval;
    }
    public string GenerateID(string strTablename, string strFldname)
    {
        com = new SqlCommand();
        com.Connection = objCon.con;
        com.Connection.Open();

        com.CommandText = "select coalesce(max(" + strFldname + "),'0',max(" + strFldname + ")) from " + strTablename;
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
    public void MsgBox(string msg, Page refP)
    {
        Label lbl = new Label();
        string lb = "window.alert('" + msg + "')";
        ScriptManager.RegisterClientScriptBlock(refP, GetType(), "UniqueKey", lb, true);
        //ScriptManager.RegisterClientScriptBlock(refP, refP.GetType, "UniqueKey", lb, True)
        refP.Controls.Add(lbl);
    }
    public void MsgBox1(string msg, UpdatePanel refP)
    {
        string lb = "window.alert('" + HttpContext.Current.Server.HtmlEncode(msg) + "');";
        ScriptManager.RegisterClientScriptBlock(refP, GetType(), "UniqueKey", lb, true);
    }

    public void FillDataSet(DataTable dataTable, string p)
    {
        throw new NotImplementedException();
    }

    //public string SelectInsideTrans(string str)
    //{
    //    string retstr = "";
    //    SqlDataAdapter adapter = new SqlDataAdapter();
    //    SqlCommand command = new SqlCommand(str, objCon.con);
    //    adapter.SelectCommand = command;
    //    DataSet ds = new DataSet();
    //    adapter.Fill(ds);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        retstr = ds.Tables[0].Rows[0].ItemArray[0].ToString();
    //    }
    //    else
    //    {
    //        retstr = "1";
    //    }
    //    return retstr;
    //}
    public void Gen_Id(string src, string inst_id, ref string Res, ref int cp)
    {

        try
        {
            com = new SqlCommand();
            com.Connection = objCon.con;
            com.Connection.Open();


            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Hsp_Gen_ID";
            com.Parameters.AddWithValue("@Source", src);
            com.Parameters.AddWithValue("@instid", Int32.Parse(inst_id));


            com.Parameters.Add("@Res", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            com.Parameters.Add("@Cp", DbType.Int32).Direction = ParameterDirection.Output;

            com.ExecuteNonQuery();

            Res = com.Parameters["@Res"].Value.ToString();

            cp = Int32.Parse(com.Parameters["@Cp"].Value.ToString());


            com.Parameters.Clear();
        }
        catch { }
        finally
        {
            com.Connection.Close();
        }
        // return Result;
    }

    public void FillRcnoGrd(GridView grd, int inst, int cours, string sessn, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "instid", inst, DbType.Int32);
        objDB.AddParameters(1, "coursid", cours, DbType.Int32);
        objDB.AddParameters(2, "sessnid", sessn, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "RCNO_select");
        try
        {


            if (dr != null)
            {
                grd.DataSource = dr;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }
    public void FillPPSNOGrd(GridView grd, int inst, string sessn, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "instid", inst, DbType.Int32);
        objDB.AddParameters(1, "sessnid", sessn, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "PPSNO_View");
        try
        {


            if (dr != null)
            {
                grd.DataSource = dr;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }


    public void FillFeeDetailGrd(GridView grd, int DocId, int InstID, string Sessn, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(2, "Session", Sessn, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {


            if (dr != null)
            {
                grd.DataSource = dr;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }

    //public void FillDetailPGrd(GridView grd, int DocId, string Sessn, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(3);
    //    objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
    //    objDB.AddParameters(1, "Session", Sessn, DbType.String);
    //    objDB.AddParameters(2, "flag", flag, DbType.Int32);
    //    IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    try
    //    {


    //        if (dr != null)
    //        {
    //            grd.DataSource = dr;
    //            grd.DataBind();
    //        }
    //        else
    //        {
    //            grd.DataSource = null;
    //            grd.DataBind();
    //        }
    //    }
    //    finally
    //    {
    //        objDB.DataReader.Close();
    //        objDB.Connection.Close();
    //        objDB.Dispose();
    //    }
    //}


    //public DataTable FillDetailPGrd(int DocId, int instid, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(3);
    //    objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
    //    //objDB.AddParameters(1, "Session", Sessn, DbType.String);
    //    objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
    //    objDB.AddParameters(2, "flag", flag, DbType.Int32);
    //    //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    return dt;
    //}


    public void FillDetailPrint(GridView grd, int DocId, string Sessn, int sid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "Session", Sessn, DbType.String);
        objDB.AddParameters(2, "Sid", sid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {


            if (dr != null)
            {
                grd.DataSource = dr;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }


    //public DataTable FillDetailODCPrintF(int DocId, string Sessn, int sid, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(4);
    //    objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
    //    objDB.AddParameters(1, "Session", Sessn, DbType.String);
    //    objDB.AddParameters(2, "Sid", sid, DbType.Int32);
    //    objDB.AddParameters(3, "flag", flag, DbType.Int32);
    //    DataTable dt = new DataTable();
    //    //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    try
    //    {
    //        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    }
    //    finally
    //    {
    //        objDB.Connection.Close();
    //        objDB.Dispose();
    //    }
    //    return dt;
    //}

    //public DataTable FillDetailODCPrintC(int DocId, string Sessn, int sid, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(4);
    //    objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
    //    objDB.AddParameters(1, "Session", Sessn, DbType.String);
    //    objDB.AddParameters(2, "Sid", sid, DbType.Int32);
    //    objDB.AddParameters(3, "flag", flag, DbType.Int32);
    //    DataTable dt = new DataTable();
    //    //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    try
    //    {


    //        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");

    //    }
    //    finally
    //    {
    //        objDB.Connection.Close();
    //        objDB.Dispose();
    //    }
    //    return dt;
    //}


    public DataTable FillDetailODCPrint(string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.String);
        //objDB.AddParameters(1, "Session", Sessn, DbType.String);
        //objDB.AddParameters(2, "Sid", sid, DbType.Int32);
        //objDB.AddParameters(3, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
            //dt = objDB.ExecuteTable(CommandType.Text, "(Select * from View_F)Union(Select * from View_O)");

        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }




    public DataTable FillFeeDetailTable(int DocId, int InstID, string Sessn, int Sid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        try
        {
            objDB.CreateParameters(5);
            objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
            objDB.AddParameters(1, "InstID", InstID, DbType.Int32);
            objDB.AddParameters(2, "Session", Sessn, DbType.String);
            objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
            objDB.AddParameters(4, "flag", flag, DbType.Int32);
            //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillRecptCancelDetail(string PrNo, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "PrNo", PrNo, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillRecptCancelDetailAll(string PrNo, int instid, string sessnid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "PrNo", PrNo, DbType.String);
        objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(2, "Session", sessnid, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillChqDefaultEntry(int DDNO, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "DDNO", DDNO, DbType.Int32);
        //objDB.AddParameters(1, "PayM", PayM, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    //public string FillChqDetail(int DDNO, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(2);
    //    objDB.AddParameters(0, "DDNO", DDNO, DbType.Int32);
    //    objDB.AddParameters(1, "flag", flag, DbType.Int32);
    //    //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
    //    return dt;
    //}


    public DataTable FillFeeAdv(int StudentID, int InstituteID, string Session, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(2, "Session", Session, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }


    public DataTable FillAdvAmt(int CourseID, int StudentID, int InstituteID, string Session, int Pid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(2, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(3, "Session", Session, DbType.String);
        objDB.AddParameters(4, "Pid", Pid, DbType.Int32);
        objDB.AddParameters(5, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }


    public DataTable OdcM(int odcid, int feeid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "ODCID", odcid, DbType.Int32);
        objDB.AddParameters(1, "FeeHeadId", feeid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }


    public DataTable OdcAmt(int odcid, int stuid, int fee, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "ODCID", odcid, DbType.Int32);
        objDB.AddParameters(1, "StudentID", stuid, DbType.Int32);
        objDB.AddParameters(2, "FeeHeadId", fee, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }


    //public DataTable FillYrSem(int courseid, string sessnid, int instid, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(4);
    //    objDB.AddParameters(0, "CourseID", courseid, DbType.Int32);
    //    objDB.AddParameters(1, "Session", sessnid, DbType.String);
    //    objDB.AddParameters(2, "InstituteID", instid, DbType.Int32);
    //    objDB.AddParameters(3, "flag", flag, DbType.Int32);
    //    SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeReport_Select");
    //    return dt;
    //}

    public void FillYrSem(DropDownList ddl, int courseid, string sessnid, int instid, int flag, string ZeroIndexVal)
    {

        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "CourseID", courseid, DbType.Int32);
        objDB.AddParameters(1, "Session", sessnid, DbType.String);
        objDB.AddParameters(2, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeReport_Select");
        try
        {


            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "yr";
                ddl.DataValueField = "sid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void Fillgvexam(GridView gv, int ExamID, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "ExamID", ExamID, DbType.Int32);
        objDB.AddParameters(1, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Entrance_Exam_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }


    public void FillRoomstr(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_RoomMaster_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillVenue(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_ExamVenue_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillExamname(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "ExamName_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillSubjectName(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_ExamSubject_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillgvIssue(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_Issue_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillgvSale(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_Sale_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillgvOfffline(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_Offline_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillgvSeat(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "En_Seat_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    public void FillgvPeriod(GridView gv, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Period_Type_Select");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }


    public void FillYearsem(DropDownList ddl, string ctype, int courseid, string batchid, string sessnid, int instid, string ZeroIndexVal)
    {

        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "ctype", ctype, DbType.String);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "batch", batchid, DbType.String);
        objDB.AddParameters(3, "sessn", sessnid, DbType.String);
        objDB.AddParameters(4, "instid", instid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "yr";
                ddl.DataValueField = "sid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }


    public DataTable FillSessionWiseRpt(int courseid, string batch, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "batch", batch, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }


    public DataTable FillSessionWiseRptStF(int courseid, int docid, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "docid", docid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }


    public DataTable FillSessionWiseRptRD(int docid, string sessn, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "docid", docid, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }


    public DataTable FillAllSessionRpt(int courseid, string batch, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "batch", batch, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }


    public DataTable FillAllSessionRptTemp(int courseid, int docid, int sid, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "docid", docid, DbType.Int32);
        objDB.AddParameters(2, "sid", sid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        if (dt.Rows.Count > 0)
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        }
        return dt;
    }
    public void FillFeeRptChk(CheckBoxList chk, int courseid, int instid, int flag)
    {

        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CourseID", courseid, DbType.Int32);
        objDB.AddParameters(1, "instid", instid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeReport_Select");
        if (dr.HasRows)
        {
            chk.DataSource = dr;
            chk.DataTextField = "FeeHeadName";
            chk.DataValueField = "FeeHeadId";
            chk.DataBind();

        }
    }

    public void FillFeeRptChkSessn(CheckBoxList chk, int flag)
    {

        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeReport_Select");
        if (dr.HasRows)
        {
            chk.DataSource = dr;
            chk.DataTextField = "Session";
            chk.DataValueField = "SessionID";
            chk.DataBind();

        }

    }


    public void FillFeeRptChkFee(CheckBoxList chk, int course, int flag)
    {

        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        objDB.AddParameters(1, "CourseID", course, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeReport_Select");
        if (dr.HasRows)
        {
            chk.DataSource = dr;
            chk.DataTextField = "FeeHeadName";
            chk.DataValueField = "FeeHeadID";
            chk.DataBind();

        }

    }


    public void FillFeeHead(DropDownList ddl, string instid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "instID", Int32.Parse(instid), DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetFeeHead");

        if (dr != null)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "FeeHeadName";
            ddl.DataValueField = "FeeHeadID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }


    public void FillPayMode(DropDownList ddl, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "PaymentMode";
            ddl.DataValueField = "PMID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }

    public void FillIBank(DropDownList ddl, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        //objDB.AddParameters(0, "bankreq", bankreq, DbType.String);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "BankName";
            ddl.DataValueField = "BankID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }


    public void FillStudentID(DropDownList ddl, int sid, int instid, string sessn, string status, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "instid", instid, DbType.Int32);
        objDB.AddParameters(2, "session", sessn, DbType.String);
        objDB.AddParameters(3, "status", status, DbType.String);
        //objDB.AddParameters(4, "CourseID", courseid, DbType.String);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "ID_Student";
            ddl.DataValueField = "StudentID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }

    public void FillStudentID1(DropDownList ddl, string yrid, int instid, string sessn, string status, int courseid, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "yearid", yrid, DbType.String);
        objDB.AddParameters(1, "instid", instid, DbType.Int32);
        objDB.AddParameters(2, "session", sessn, DbType.String);
        objDB.AddParameters(3, "status", status, DbType.String);
        objDB.AddParameters(4, "CourseID", courseid, DbType.Int32);
        objDB.AddParameters(5, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "ID_Student";
            ddl.DataValueField = "StudentID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }


    public void FillFeeStrucGrd(GridView grd, int inst, string cours, string sessn, string ctype, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "CourseCode", cours, DbType.String);
        objDB.AddParameters(2, "Session", sessn, DbType.String);
        objDB.AddParameters(3, "Ctype", ctype, DbType.String);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Struc_Select");
        if (dr.HasRows)
        {
            grd.DataSource = dr;
            grd.DataBind();
        }
        else
        {
            grd.DataSource = null;
            grd.DataBind();
        }
    }


    public void FillFeeRpt(GridView grd, string status, string sessn, int instid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Status", status, DbType.String);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeReport_Select");
        if (dr.HasRows)
        {
            grd.DataSource = dr;
            grd.DataBind();
        }
        else
        {
            grd.DataSource = null;
            grd.DataBind();
        }
    }


    public void FillRecptCancel(GridView grd, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        if (dr.HasRows)
        {
            grd.DataSource = dr;
            grd.DataBind();
        }
        else
        {
            grd.DataSource = null;
            grd.DataBind();
        }
    }


    //public void FillFeeRefundGrd(GridView grd, int inst, int cours, string sessn, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(4);
    //    objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
    //    objDB.AddParameters(1, "CourseID", cours, DbType.String);
    //    objDB.AddParameters(2, "Session", sessn, DbType.String);
    //    objDB.AddParameters(3, "flag", flag, DbType.String);
    //    SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    if (dr.HasRows)
    //    {
    //        grd.DataSource = dr;
    //        grd.DataBind();
    //    }
    //    else
    //    {
    //        grd.DataSource = null;
    //        grd.DataBind();
    //    }
    //}

    public DataTable FillFeeRefundGrd(int inst, int studentid, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "StudentID", studentid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
        return dt;
    }


    public DataTable FillPeriodWisePreFee(DateTime Fdate, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Fdate", Fdate, DbType.DateTime);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }


    public DataTable FillPeriodWiseCurrFee(DateTime Fdate, DateTime Tdate, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "Fdate", Fdate, DbType.DateTime);
        objDB.AddParameters(1, "Tdate", Tdate, DbType.DateTime);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }


    public DataTable FillPeriodWisePay(DateTime Fdate, DateTime Tdate, int course, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Fdate", Fdate, DbType.DateTime);
        objDB.AddParameters(1, "Tdate", Tdate, DbType.DateTime);
        objDB.AddParameters(2, "courseid", course, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SessionWiseRpt_Select");
        return dt;
    }

    public DataTable FillReceiptCancel(int inst, string sessn, int course, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "CourseCode", course, DbType.Int32);
        //objDB.AddParameters(3, "BatchCode", batch, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillReceiptCancelB(int inst, string sessn, int course, string batch, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "CourseCode", course, DbType.Int32);
        objDB.AddParameters(3, "BatchCode", batch, DbType.String);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillReceiptCancelSt(int inst, string sessn, int course, string batch, int studentID, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "CourseCode", course, DbType.Int32);
        objDB.AddParameters(3, "BatchCode", batch, DbType.String);
        objDB.AddParameters(4, "StudentID", studentID, DbType.Int32);
        objDB.AddParameters(5, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }


    public DataTable FillChqDefault(int inst, string sessn, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillChqDefaultSt(int inst, string sessn, int studentID, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "InstituteID", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(1, "StudentID", studentID, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }


    //public DataTable FillFeeRefundGrdSt(int inst, int cours, string sessn, int studentid, int flag)
    //{

    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(5);
    //    objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
    //    objDB.AddParameters(1, "CourseID", cours, DbType.Int32);
    //    objDB.AddParameters(2, "Session", sessn, DbType.String);
    //    objDB.AddParameters(3, "StudentID", studentid, DbType.Int32);
    //    objDB.AddParameters(4, "flag", flag, DbType.String);
    //    //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    return dt;
    //}



    public DataTable FillFeeRefundGrdB(int inst, int cours, string sessn, string batch, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "CourseID", cours, DbType.Int32);
        objDB.AddParameters(2, "Session", sessn, DbType.String);
        objDB.AddParameters(3, "batch", batch, DbType.String);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }

    public DataTable FillFeeRefundGrdP(int inst, int cours, string sessn, int pid, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "CourseID", cours, DbType.Int32);
        objDB.AddParameters(2, "Session", sessn, DbType.String);
        objDB.AddParameters(3, "Pid", pid, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }

    public DataTable FillFeeRefundGrdS(int inst, int cours, string sessn, int studentid, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "CourseID", cours, DbType.Int32);
        objDB.AddParameters(2, "Session", sessn, DbType.String);
        objDB.AddParameters(3, "StudentID", studentid, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        return dt;
    }



    public DataTable FillChangePayMode(string prno, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "PrNo", prno, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);

        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillChangePMode(int inst, string sessn, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }

    public DataTable FillChangePModeR(int inst, string sessn, string receipt, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "InstituteID", inst, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "PrNo", receipt, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        return dt;
    }


    public string GetYearForSem(int sid, string CourseYear, int courseid, string batchid, string sessnid, int instid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "CourseYear", CourseYear, DbType.String); //
        objDB.AddParameters(2, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(3, "batch", batchid, DbType.String); //
        //objDB.AddParameters(4, "sessionyear", sessnid, DbType.String); //
        objDB.AddParameters(4, "session", sessnid, DbType.String); //
        objDB.AddParameters(5, "instituteid", instid, DbType.Int32);
        objDB.AddParameters(6, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Struc_Select");
        //SqlDataAdapter ad = new SqlDataAdapter();
        //SqlCommand cmd;
        //cmd = new SqlCommand(sql, objCon.con);
        //ad.SelectCommand = cmd;
        //DataSet ds = new DataSet();
        //ad.Fill(ds);
        string retval = "";
        if (dr.HasRows)
        {
            retval = dr.ToString();
        }
        else
        {
            retval = "";
        }
        return retval;

    }


    public object ODCID(int feeid, int course, int inst, string sessn, int cid, string yr, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "FeeHeadId", feeid, DbType.Int32);
        objDB.AddParameters(1, "CourseID", course, DbType.Int32);
        objDB.AddParameters(2, "InstituteID", inst, DbType.Int32);
        objDB.AddParameters(3, "Session", sessn, DbType.String);
        objDB.AddParameters(4, "cid", cid, DbType.Int32);
        objDB.AddParameters(5, "yearid", yr, DbType.String);
        objDB.AddParameters(6, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");

        object retval;
        retval = objDB.ExecuteScalar(CommandType.StoredProcedure, "Fee_Deposit_Select");
        //if (dr.HasRows)
        //{
        //    retval = dr;
        //}
        //else
        //{
        //    retval = 0;
        //}
        return retval;

    }


    public void FillFeeRptGrdStd(GridView grd, int InstituteID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        if (dr.HasRows)
        {
            grd.DataSource = dr;
            grd.DataBind();
        }
        else
        {
            grd.DataSource = null;
            grd.DataBind();
        }
    }


    public void FillTopicType(DropDownList ddl, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Topic_Planner_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "Period_Type";
            ddl.DataValueField = "PeriodID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }


    public void FillTPBatch(DropDownList ddl, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Topic_Planner_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "Batch_Name";
            ddl.DataValueField = "Batch_ID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }
    public void FillTPBatch1(DropDownList ddl, int flag, int Instid, int courseid, string session, int Semester, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        objDB.AddParameters(1, "Instituteid", Instid, DbType.Int32);
        objDB.AddParameters(2, "Courseid", courseid, DbType.Int32);
        objDB.AddParameters(3, "Session", session, DbType.String);
        objDB.AddParameters(4, "Semesterid", Semester, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Topic_Planner_Select");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "Batch_Name";
            ddl.DataValueField = "Batch_ID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }
    public void FillStudentBatchType(DropDownList ddl, int InstituteID, string SessionID, int Course_ID, int YearID, string SemesterID, int Flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(2, "Course_ID", Course_ID, DbType.Int32);
        objDB.AddParameters(3, "YearID", YearID, DbType.Int32);
        objDB.AddParameters(4, "SemesterID", SemesterID, DbType.String);
        objDB.AddParameters(5, "Flag", Flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SelectStuBatchType");
        try
        {
            if (dr.HasRows)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "Period_Type";
                ddl.DataValueField = "PeriodID";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
        }
    }

    public void ResetControlValues(Control parent)
    {

        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetControlValues(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        if ((((TextBox)c).ID).ToLower() != "txtexrate")
                        {
                            ((TextBox)c).Text = "";
                        }
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)c).ClearSelection();
                        break;
                    //case "System.Web.UI.WebControls.GridView":                        
                    //for (int i = 0; i < ((GridView)c).Rows.Count; i++)
                    //{
                    //    ((GridView)c).DeleteRow(i);
                    //}
                    // break;
                    //case "System.Web.UI.WebControls.RadioButton":
                    //    ((RadioButton)c).Checked = false;
                    //    break;

                }
            }
        }
    }

    public String GetListBoxSelectedItem(ListBox LSTBox)
    {
        StringBuilder RepeatedShift = new StringBuilder();
        String Value = string.Empty;
        for (int i = 0; i < LSTBox.Items.Count; i++)
        {
            if (LSTBox.Items[i].Selected == true)
            {
                RepeatedShift.Append(LSTBox.Items[i].Value + ",");
            }
        }
        if (RepeatedShift.ToString() != string.Empty)
            Value = RepeatedShift.ToString().Remove(RepeatedShift.ToString().LastIndexOf(',')).ToString();

        return Value;
        //return RepeatedShift.ToString().Remove(RepeatedShift.ToString().LastIndexOf(','));
    }




    public String GetListBoxSelectedItem_Def(ListBox LSTBox)
    {
        StringBuilder RepeatedShift = new StringBuilder();
        String Value = string.Empty;
        for (int i = 0; i < LSTBox.Items.Count; i++)
        {
            if (LSTBox.Items[i].Text != "Select Forms")
            {
                RepeatedShift.Append(LSTBox.Items[i].Value + ",");
            }

        }
        if (RepeatedShift.ToString() != string.Empty)
            Value = RepeatedShift.ToString().Remove(RepeatedShift.ToString().LastIndexOf(',')).ToString();

        return Value;
        //return RepeatedShift.ToString().Remove(RepeatedShift.ToString().LastIndexOf(','));
    }

    //public DataTable FillAdv_R(int docid, int coursid, int flag)
    //{

    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(3);
    //    objDB.AddParameters(0, "studentid", docid, DbType.Int32);
    //    objDB.AddParameters(1, "CourseID", coursid, DbType.Int32);
    //    objDB.AddParameters(2, "flag", flag, DbType.Int32);
    //    //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    return dt;
    //}


    //public DataTable FillAdvRGrd(int studentid,int coursid, string flag)
    //{

    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(3);
    //    objDB.AddParameters(0, "StudentID", studentid, DbType.Int32);
    //    objDB.AddParameters(1, "CourseID", coursid, DbType.Int32);       
    //    objDB.AddParameters(2, "flag", flag, DbType.String);
    //    //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    return dt;
    //}


    //public DataTable FillAdvRcpt(string prno)
    //{

    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(1);
    //    objDB.AddParameters(0, "Prno", prno, DbType.String);
    //    //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    DataTable dt = new DataTable();
    //    dt = objDB.ExecuteTable(CommandType.Text, "select * from Adv_Rcpt_Vw where Prno='"+prno+"'");
    //    return dt;
    //}

    //public string GetListBoxSelectedItem(ListBox LSTFormFieldData)
    //{
    //    throw new NotImplementedException();
    //}
    public DataTable FillSubjectListforstudyload(string inst_ID, string session, string CourseID, string splid, string Semester)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SubjectListforstudyload");
        return dt;
    }
    public DataTable FillExistSubjectListforstudyload(string inst_ID, string session, string CourseID, string splid, string Semester)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "ExistSubjectstudyloadlist");
        return dt;
    }

    public void FillSubjectlistforFacultyChoice(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string batch, string empid, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "batch", batch, DbType.String);
        objDB.AddParameters(6, "empid", Int32.Parse(empid), DbType.Int32);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SubjectListforFacultyChoice");
        if (dt.Rows.Count > 0)
        {
            gv.DataSource = dt;
            gv.DataBind();
        }

    }
    public void FillSubjectlistteacherPriority(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string Batch_ID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "SessionID", session, DbType.String);
        objDB.AddParameters(2, "courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "specId", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "semId", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "groupId", Int32.Parse(Batch_ID), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Subject_List_Teacher_Priority");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }

    public void FillSubjectlistforStudentChoice(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string StudentId, string SubjectCat)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "StudentId", StudentId, DbType.String);
        objDB.AddParameters(6, "SubjectCat", SubjectCat, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListforStudentChoice");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }

    public DataTable FillElectiveCategoryforStudentChoice(string inst_ID, string session, string CourseID, string splid, string Semester, string flag, int studentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "studentid", studentID, DbType.Int32);
        objDB.AddParameters(6, "Flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FillElectiveCategoryforStudentChoice");
        return dt;
    }


    public string Get_detailsAllRem_D(string sql)
    {
        string retval = "";
        SqlDataAdapter ad = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand(sql, objCon.con);
        ad.SelectCommand = cmd;
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (retval == "")
                {
                    retval = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
                else
                {
                    retval = retval + "^" + ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
            }

        }
        //while (reader.Read())
        //{


        //}
        //reader.Close();
        return retval;
    }

    public DataTable FillAdvAmtF(int StudentID, int InstituteID, string Session, int Pid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        //objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(2, "Session", Session, DbType.String);
        objDB.AddParameters(3, "Pid", Pid, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
        return dt;
    }

    public void FillElectiveSubjectGroup(GridView gv, string Courseid, string InstituteID, string Semester, string Session, string SubjectId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Inst_Id", Int32.Parse(InstituteID), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(Courseid), DbType.Int32);
        objDB.AddParameters(2, "SemId", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(3, "SessionId", Session, DbType.String);
        objDB.AddParameters(4, "SubjectId", Int32.Parse(SubjectId), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetElectiveSubjectgroup");
        try
        {


            if (dr != null)
            {
                gv.DataSource = dr;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = new Int32[0];
                gv.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public DataTable FillAvaliableSeatsforOptionalSubject(string inst_ID, string session, string CourseID, string splid, string Semester, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EleSubListforAvaliableSeats");
        return dt;

    }
    public void FillSubjectlistforMBAStudentChoice(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string StudentId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "StudentId", StudentId, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListMbaStudentChoice");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }

    public void FillElectiveSubjectFromMaster(GridView gv, string CourseID, string splid, string Semester, string inst_ID, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(1, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(2, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(3, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetElectiveSubjectFormMaster");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }

    public void MergeRows(GridView gridView, int coloum)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];

            for (int i = 0; i < coloum; i++)
            {
                if (row.Cells[i].Text == previousRow.Cells[i].Text)
                {
                    row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 : previousRow.Cells[i].RowSpan + 1;
                    previousRow.Cells[i].Visible = false;
                }
            }
        }
    }
    public void FillSubjectlistforLT(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string batch, string empid, string PeriodID, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "batch", Int32.Parse(batch), DbType.Int32);
        objDB.AddParameters(6, "empid", Int32.Parse(empid), DbType.Int32);
        objDB.AddParameters(7, "PeriodID", Int32.Parse(PeriodID), DbType.Int32);
        objDB.AddParameters(8, "flag", flag, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListforFacultyChoice");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }



    //---------------------------------------
    public void FillSubjectlistLT(GridView gv, string inst_ID, string session, string CourseID, string splid, string Semester, string Batch_ID, string empid, string PeriodID, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "Batch_ID", Int32.Parse(Batch_ID), DbType.Int32);
        objDB.AddParameters(6, "empid", Int32.Parse(empid), DbType.Int32);
        objDB.AddParameters(7, "PeriodID", Int32.Parse(PeriodID), DbType.Int32);
        objDB.AddParameters(8, "flag", flag, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListforHODapproval");
        if (dr.HasRows)
        {
            gv.DataSource = dr;
            gv.DataBind();
        }
        else
        {
            gv.DataSource = new Int32[0];
            gv.DataBind();
        }
    }
    public void FillYearsemchkboxlist(CheckBoxList ddl, string ctype, int courseid, string batchid, string sessnid, int instid)
    {

        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "ctype", ctype, DbType.String);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "batch", batchid, DbType.String);
        objDB.AddParameters(3, "sessn", sessnid, DbType.String);
        objDB.AddParameters(4, "instid", instid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "yr";
                ddl.DataValueField = "sid";
                ddl.DataBind();
                //if (ZeroIndexVal != "")
                //{
                //    ddl.Items.Insert(0, ZeroIndexVal);
                //    ddl.Items[0].Value = "0";
                //}
                //else
                //{
                //    ddl.Items.Insert(0, ZeroIndexVal);
                //    ddl.Items[0].Value = "0";
                //}
            }
            //else
            //{
            //    ddl.Items.Insert(0, ZeroIndexVal);
            //    ddl.Items[0].Value = "0";
            //}
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }
    public DataTable Ashish(string flag, Int32 StudentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SP_ashish");
        return dt;
    }
    public string ExecuteNaveen(string sql)
    {
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        string rowInserted = "";
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        rowInserted = com.ExecuteScalar().ToString();
        com.Connection.Close();
        return rowInserted;
    }
    public DataTable FillDepartmentIssue(int Indent_Code, string Prod_Name, string UserName, decimal Qty, decimal IssueQty, int InstID, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "Indent_Code", Indent_Code, DbType.Int32);
        objDB.AddParameters(1, "Prod_Name", Prod_Name, DbType.String);
        objDB.AddParameters(2, "UserName", UserName, DbType.String);
        objDB.AddParameters(3, "Qty", Qty, DbType.Decimal);
        objDB.AddParameters(4, "IssueQty", IssueQty, DbType.Decimal);
        objDB.AddParameters(5, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(6, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "DepartmentIssue_select");
        return dt;
    }
    public DataTable Ashish1(string flag, Int32 StudentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SP_ashish");
        return dt;
    }
    # region Facculty_Dashboard

    public string xmlFileCreator(StringWriter sw)
    {
        XPathDocument xpathDoc = new XPathDocument(new StringReader(sw.ToString()));
        XPathNavigator xpathNav = xpathDoc.CreateNavigator();
        XPathNodeIterator xpathNodeIter = xpathNav.Select("/MyRoot");
        XPathDocument xpath = new XPathDocument(new StringReader(sw.ToString()));
        XslCompiledTransform transformToNode = new XslCompiledTransform();
        transformToNode.Load(new XPathDocument(HttpContext.Current.Server.MapPath("~/XSLTFile.xslt")).CreateNavigator(), new XsltSettings(), new XmlUrlResolver());
        XsltArgumentList xslArgs = new XsltArgumentList();
        xslArgs.AddParam("item_id", "", "");
        MemoryStream nodeMemoryStream = new MemoryStream();
        XmlTextWriter nodeTextWriter = new XmlTextWriter(nodeMemoryStream, Encoding.UTF8);
        nodeTextWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
        transformToNode.Transform(xpath, xslArgs, nodeTextWriter);
        nodeTextWriter.Flush();
        nodeMemoryStream.Position = 0;
        StreamReader nodeStreamReader = new StreamReader(nodeMemoryStream);
        return nodeStreamReader.ReadToEnd();
    }

    public string bindgrid_jdwise_ajax(string str)
    {

        StringWriter sw = new StringWriter();
        XmlTextWriter tw = new XmlTextWriter(sw);
        tw.WriteStartElement("MyRoot");
        com = new SqlCommand(str, objCon.con);
        com.Connection.Open();
        XmlReader reader = com.ExecuteXmlReader();
        tw.WriteNode(reader, true);
        reader.Close();
        tw.WriteEndElement();
        com.Connection.Close();
        string st = xmlFileCreator(sw);
        return st;

    }


    public DataTable Fill_Faculty_Dashboard_Data(int emp_id, string SessionID, int inst_id, string from_date, string to_date, string daytype, int semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "faculityid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "fromdate", from_date, DbType.Date);
        objDB.AddParameters(2, "todate", to_date, DbType.Date);
        objDB.AddParameters(3, "daytype", daytype, DbType.String);
        objDB.AddParameters(4, "SessionId", SessionID, DbType.String);
        objDB.AddParameters(5, "InstId", inst_id, DbType.Int32);
        objDB.AddParameters(6, "Semid", semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_att_faculity");
        return dt;
    }

    public DataTable Fill_HOD_Dashboard_Data(int emp_id, string SessionID, int inst_id, string from_date, string to_date, string daytype)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "faculityid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "fromdate", from_date, DbType.Date);
        objDB.AddParameters(2, "todate", to_date, DbType.Date);
        objDB.AddParameters(3, "daytype", daytype, DbType.String);
        objDB.AddParameters(4, "SessionId", SessionID, DbType.String);
        objDB.AddParameters(5, "InstId", inst_id, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_att_Hod");
        return dt;
    }

    public DataTable Fill_Faculty_Dashboard_Data_course(int emp_id, string SessionID, int inst_id, string from_date, string to_date, string daytype, int semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "faculityid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "fromdate", from_date, DbType.Date);
        objDB.AddParameters(2, "todate", to_date, DbType.Date);
        objDB.AddParameters(3, "daytype", daytype, DbType.String);
        objDB.AddParameters(4, "SessionId", SessionID, DbType.String);
        objDB.AddParameters(5, "InstId", inst_id, DbType.Int32);
        objDB.AddParameters(6, "Semid", semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_faculty_wise_course_completion_percentage");
        return dt;
    }

    public string bind_holiday_non_teaching(string uid)
    {
        string retView = "";
        com = new SqlCommand(uid, objCon.con);
        com.Connection.Open();
        SqlDataReader sdr = null;
        sdr = com.ExecuteReader();
        if (sdr.HasRows)
        {
            sdr.Read();
            retView = sdr[0].ToString();
        }
        sdr.Close();
        sdr.Dispose();
        com.Connection.Close();
        return retView;
    }

    public string insert_holiday_non_teaching(string uid)
    {
        string retView = "";
        com = new SqlCommand(uid, objCon.con);
        com.Connection.Open();
        int val = com.ExecuteNonQuery();
        if (val > 0)
            retView = val.ToString();
        else
            retView = "0";
        com.Connection.Close();
        return retView;
    }


    public DataTable Fill_Faculty_subject_wise_details_report(int emp_id, string SessionID, int inst_id, string from_date, string to_date, int CourseId, string splization, int BachId, int Semester, string subject)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(10);
        objDB.AddParameters(0, "faculty", emp_id, DbType.Int32);
        objDB.AddParameters(1, "insti_id", inst_id, DbType.Int32);
        objDB.AddParameters(2, "Session", SessionID, DbType.String);
        objDB.AddParameters(3, "CourseId", CourseId, DbType.Int32);
        objDB.AddParameters(4, "splization", splization, DbType.String);
        objDB.AddParameters(5, "BachId", BachId, DbType.Int32);
        objDB.AddParameters(6, "Semester", Semester, DbType.Int32);
        objDB.AddParameters(7, "fromdate", from_date, DbType.Date);
        objDB.AddParameters(8, "todate", to_date, DbType.Date);
        objDB.AddParameters(9, "Subject", Convert.ToInt32(subject), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_details_report");
        return dt;
    }

   

    public DataTable Fill_Faculty_course_wise_details_report(int emp_id, string SessionID, int inst_id, string from_date, string to_date, int subject, int semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "faculityid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "fromdate", from_date, DbType.Date);
        objDB.AddParameters(2, "todate", to_date, DbType.Date);
        objDB.AddParameters(3, "SessionId", SessionID, DbType.String);
        objDB.AddParameters(4, "InstId", inst_id, DbType.Int32);
        objDB.AddParameters(5, "SubjectID", subject, DbType.Int32);
        objDB.AddParameters(6, "semid", semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_faculty_wise_course_completion_percentage_report");
        return dt;
    }



    public DataTable get_student_attendance_details_popup(string subjectid, string instituteid, string sessionid, string empid, string courseid, string semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "faculty", Convert.ToInt32(empid), DbType.Int32);
        objDB.AddParameters(1, "insti_id", Convert.ToInt32(instituteid), DbType.Int32);
        objDB.AddParameters(2, "Session", sessionid, DbType.String);
        objDB.AddParameters(3, "CourseId", Convert.ToInt32(courseid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Convert.ToInt32(semid), DbType.Int32);
        objDB.AddParameters(5, "Subject_code", Convert.ToInt32(subjectid), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_details_popup");
        return dt;
    }

    public DataTable get_student_examination_attendance_details_popup(string subjectid, string instituteid, string sessionid, string empid, string courseid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sujectid", Convert.ToInt32(subjectid), DbType.Int32);
        objDB.AddParameters(1, "instiid", Convert.ToInt32(instituteid), DbType.Int32);
        objDB.AddParameters(2, "session", sessionid, DbType.String);
        objDB.AddParameters(3, "empid", Convert.ToInt32(empid), DbType.Int32);
        objDB.AddParameters(4, "courseid", Convert.ToInt32(courseid), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_attendance_popup");
        return dt;
    }


    public DataTable get_student_examination_exam_details_popup(string subjectid, string instituteid, string sessionid, string empid, string courseid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sujectid", Convert.ToInt32(subjectid), DbType.Int32);
        objDB.AddParameters(1, "instiid", Convert.ToInt32(instituteid), DbType.Int32);
        objDB.AddParameters(2, "session", sessionid, DbType.String);
        objDB.AddParameters(3, "empid", Convert.ToInt32(empid), DbType.Int32);
        objDB.AddParameters(4, "courseid", Convert.ToInt32(courseid), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_exam_popup");
        return dt;
    }

    public string Get_details_fac(string sql)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string detail = String.Empty;
        try
        {
            SqlConnection con = new SqlConnection(objDB.ConnectionString);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            if (ad.SelectCommand.ExecuteScalar() != null)
            {
                detail = ad.SelectCommand.ExecuteScalar().ToString();
            }
            ad.Dispose();
            con.Close();
            con.Dispose();
        }
        finally
        {
            //  objDB.DataReader.Close();
            //    objDB.DataReader.Dispose();
            objDB.Connection.Close();
            //objDB.Connection.Dispose();
            //objDB.Dispose();
        }
        if (detail == "")
        {
            detail = "0.0";
        }
        return detail;

    }

    public void FillAcademicDept_Details(DropDownList ddl)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(0);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "get_Academic_dept_for_ddl");
        try
        {
            if (dr != null)
            {

                ddl.DataSource = dr;
                ddl.DataTextField = "DeptName";
                ddl.DataValueField = "DeptId";
                ddl.DataBind();


            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }


    public void FillFacult_Details(DropDownList ddl, int deptid, int empid, int Flag)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "dept_id", deptid, DbType.Int32);
        objDB.AddParameters(1, "empid", empid, DbType.Int32);
        objDB.AddParameters(2, "flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "get_faculty_details_for_ddl");
        try
        {
            if (dr != null)
            {

                ddl.DataSource = dr;
                ddl.DataTextField = "empName";
                ddl.DataValueField = "empId";
                ddl.DataBind();


            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }

    public void Fill__ExamsType_Faculty_Wise(DropDownList ddl, int instid, int empid, string session, int semid)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "instid", instid, DbType.Int32);
        objDB.AddParameters(1, "empid", empid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        objDB.AddParameters(3, "semid", semid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "get_exams_facultywise_for_ddl");
        try
        {
            if (dr != null)
            {

                ddl.DataSource = dr;
                ddl.DataTextField = "testName";
                ddl.DataValueField = "testid";
                ddl.DataBind();
                if (ddl.Items.Count <= 0)
                {
                    ddl.Items.Insert(0, "Not Found");
                    ddl.Items[0].Value = "0";
                }

            }

            else
            {
                ddl.Items.Insert(0, "Not Found");
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }


    public void FillCourse_faculty(DropDownList ddl, string instituteid, int emp_id, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Empid", emp_id, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCourse_faculty");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "coursename";
                ddl.DataValueField = "courseid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }

    public void FillYearsem_faculty(DropDownList ddl, string ctype, int courseid, string batchid, string sessnid, int instid, int empid, string ZeroIndexVal)
    {

        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "ctype", ctype, DbType.String);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "batch", batchid, DbType.String);
        objDB.AddParameters(3, "sessn", sessnid, DbType.String);
        objDB.AddParameters(4, "instid", instid, DbType.Int32);
        objDB.AddParameters(5, "empid", empid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem_faculty");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "yr";
                ddl.DataValueField = "sid";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void FillSpecilization_faculty(DropDownList ddl, string instituteid, string courseid, int emp_id, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(courseid), DbType.Int32);
        objDB.AddParameters(2, "empid", emp_id, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSpecilization_faculty");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "shortName";
                ddl.DataValueField = "SpecilizationID";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }

    public DataTable Fill_Faculty_Dashboard_Data_Examination(int emp_id, string SessionID, int inst_id, int semID, string from_date, string to_date, string daytype, int testid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "faculityid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "fromdate", from_date, DbType.Date);
        objDB.AddParameters(2, "todate", to_date, DbType.Date);
        objDB.AddParameters(3, "daytype", daytype, DbType.String);
        objDB.AddParameters(4, "SessionId", SessionID, DbType.String);
        objDB.AddParameters(5, "InstId", inst_id, DbType.Int32);
        objDB.AddParameters(6, "semID", semID, DbType.Int32);
        objDB.AddParameters(7, "testid", testid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_student_subject_wise_marks_faculity");
        return dt;
    }

    public DataTable Select_faculty_dashboard_student_marks(int emp_id, string SessionID, int inst_id, int sem, int subject, int testid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "faculty", emp_id, DbType.Int32);
        objDB.AddParameters(1, "subject", subject, DbType.Int32);
        objDB.AddParameters(2, "sem", sem, DbType.Int32);
        objDB.AddParameters(3, "insti", inst_id, DbType.Int32);
        objDB.AddParameters(4, "session", SessionID, DbType.String);
        objDB.AddParameters(5, "testid", testid, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Select_faculty_dashboard_student_marks_sub_by");
        return dt;
    }

    public void FillSemester_for_faculty_dashboard(DropDownList ddl, int instituteid, int emp_id, string session)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "Facultyid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "Instiid", instituteid, DbType.Int32);
        objDB.AddParameters(2, "Session", session, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Get_semester_for_faculty_dashboard");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "SemesterName";
                ddl.DataValueField = "SemesterId";
                ddl.DataBind();

            }

        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public void Fillsubject_for_faculty_exam_dashboard(DropDownList ddl, int instituteid, int emp_id, string session, int semid, int testid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "faculty", emp_id, DbType.Int32);
        objDB.AddParameters(1, "sem", semid, DbType.Int32);
        objDB.AddParameters(2, "instiid", instituteid, DbType.Int32);
        objDB.AddParameters(3, "sessionid", session, DbType.String);
        objDB.AddParameters(4, "testid", testid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "get_subject_details_faculty_dashboard");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "SubjectName";
                ddl.DataValueField = "subjectId";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }
    }

    public DataTable Get_details_Datatable(string sql)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        SqlConnection con = new SqlConnection(objDB.ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        try
        {
            objDB.Connection.Close();
            dt.Load(dr);
        }
        finally
        {
            objDB.Connection.Close();
        }
        return dt;

    }

    public DataTable Select_faculty_dashboard_Profile(int emp_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Empid", emp_id, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Select_Employee_Profile_Details");
        return dt;
    }

    public int bind_attendance_data_for_leave_details(string query)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        int detail = 0;
        try
        {
            SqlConnection con = new SqlConnection(objDB.ConnectionString);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            if (ad.SelectCommand.ExecuteScalar() != null)
            {
                detail = Convert.ToInt32(ad.SelectCommand.ExecuteScalar());
            }
            ad.Dispose();
            con.Close();
            con.Dispose();
        }
        finally
        {
            objDB.Connection.Close();
        }

        return detail;

    }

    public int get_card_number_of_employee(string query)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        int detail = 0;
        try
        {
            SqlConnection con = new SqlConnection(objDB.ConnectionString);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            if (ad.SelectCommand.ExecuteScalar() != null)
            {
                detail = Convert.ToInt32(ad.SelectCommand.ExecuteScalar());
            }
            ad.Dispose();
            con.Close();
            con.Dispose();
        }
        finally
        {
            objDB.Connection.Close();
        }

        return detail;

    }

    public DataTable select_employee__attendance_details_dashboard(int emp_id, string SessionID, int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "empid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "session", SessionID, DbType.String);
        objDB.AddParameters(2, "instid", inst_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_employee_leave_details_for_val");
        return dt;
    }

    public DataTable select_employee__attendance_details_dashboard1(int emp_id, string SessionID, int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "empid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "session", SessionID, DbType.String);
        objDB.AddParameters(2, "instid", inst_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_employee_leave_details");
        return dt;
    }


    public DataTable bind_student_overall_performance(int emp_id, string SessionID, int inst_id, int next)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Facultid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "Next", next, DbType.Int32);
        objDB.AddParameters(2, "InstiId", inst_id, DbType.Int32);
        objDB.AddParameters(3, "SessionId", SessionID, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_over_all_performance");
        return dt;
    }

    public DataSet bind_student_overall_performance_single(int studid, int next, int empid, string session, int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sudentId", studid, DbType.Int32);
        objDB.AddParameters(1, "Next", next, DbType.Int32);
        objDB.AddParameters(2, "Facultid", empid, DbType.Int32);
        objDB.AddParameters(3, "SessionId", session, DbType.String);
        objDB.AddParameters(4, "InstiId", instiid, DbType.Int32);
        DataSet ds = new DataSet();
      //  ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Bind_over_all_performance_single");
        return ds;
    }

    public DataTable bind_student_overall_performance_single_Trimester(int studid, int next, int empid, string session, int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sudentId", studid, DbType.Int32);
        objDB.AddParameters(1, "Next", next, DbType.Int32);
        objDB.AddParameters(2, "Facultid", empid, DbType.Int32);
        objDB.AddParameters(3, "SessionId", session, DbType.String);
        objDB.AddParameters(4, "InstiId", instiid, DbType.Int32);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_over_all_performance_single_Semesterwise");
        return ds;
    }

    
         public DataTable bind_student_overall_performance_single_Subjectwise(int studid, int empid, string session, int instiid,int semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sudentId", studid, DbType.Int32);
        objDB.AddParameters(1, "Facultid", empid, DbType.Int32);
        objDB.AddParameters(2, "SessionId", session, DbType.String);
        objDB.AddParameters(3, "InstiId", instiid, DbType.Int32);
        objDB.AddParameters(4, "Semester_ID", semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_over_all_performance_single_Subject");
        return dt;
    }

    public DataTable bind_student_overall_performance_single_Monthwise(int studid, int empid, string session, int instiid, int semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sudentId", studid, DbType.Int32);
        objDB.AddParameters(1, "Facultid", empid, DbType.Int32);
        objDB.AddParameters(2, "SessionId", session, DbType.String);
        objDB.AddParameters(3, "InstiId", instiid, DbType.Int32);
        objDB.AddParameters(4, "Semester_ID", semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_over_all_performance_single_Month");
        return dt;
    }



    public DataTable bind_leave_details_single(int empid, int instiid, string session, string leaveid, string leavetype, string status)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "insti", instiid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        objDB.AddParameters(3, "leavetype", leaveid, DbType.String);
        objDB.AddParameters(4, "leave_type_val", leavetype, DbType.String);
        objDB.AddParameters(5, "Status", status, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_employee_leave_details_single");
        return ds;
    }

    public DataTable bind_employee_salary_details_for_ht(int empid, int instiid, string session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "instid", instiid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_employee_salary_for_hr");
        return ds;
    }

    public DataTable Bind_Course_Subject_Faculty_Wise(int InstID, string session, int Facultyid, int courseID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Facultid", Facultyid, DbType.Int32);
        objDB.AddParameters(1, "SessionId", session, DbType.String);
        objDB.AddParameters(2, "InstiId", InstID, DbType.Int32);
        objDB.AddParameters(3, "CourseId", courseID, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_Course_Semester_Faculty_Wise");
        return dt;
    }

    # endregion

    public void ChkSpecilization(CheckBoxList ddl, string instituteid, string courseid)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", Int32.Parse(instituteid), DbType.Int32);
        objDB.AddParameters(1, "Courseid", Int32.Parse(courseid), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSpecilization");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "shortName";
                ddl.DataValueField = "SpecilizationID";
                ddl.DataBind();

            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }

    public DateTime getdatevalue(string datevalue)
    {
        string[] date1 = datevalue.Split('-');
        string date2 = date1[1] + "-" + date1[0] + "-" + date1[2];
        DateTime datevalue1 = Convert.ToDateTime(date2);
        return datevalue1;
    }

    public void FillStudent_Record_Fee_NotDeposited(GridView grd, int inst, string sessn)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", inst, DbType.Int32);
        objDB.AddParameters(1, "SessionID", sessn, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Sp_Student_List_Not_deposite_fee");
        try
        {


            if (dr != null)
            {
                grd.DataSource = dr;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }

    }

    public int Save_Employee_Timing_Details(int empid, DateTime WEDTime, int inhour, int inminute, int insec, int outhour, int outmin, int outsec, string punch)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "EmpId", empid, DbType.Int32);
        objDB.AddParameters(1, "WED", WEDTime, DbType.DateTime);
        objDB.AddParameters(2, "InHr", inhour, DbType.Int32);
        objDB.AddParameters(3, "InMin", inminute, DbType.Int32);
        objDB.AddParameters(4, "InSec", insec, DbType.Int32);
        objDB.AddParameters(5, "OutHr", outhour, DbType.Int32);
        objDB.AddParameters(6, "OutMin", outmin, DbType.Int32);
        objDB.AddParameters(7, "OutSec", outsec, DbType.Int32);
        objDB.AddParameters(8, "Punch", punch, DbType.String);
        int value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Employee_Timing_Details");
        return value;
    }



    public int Save_Employee_Basic_Salary(int RowId, Int32 Employee_id, DateTime WithEffectDate, Int32 DeptID, Int32 DesigID, String PayPeriod, Decimal BasicSalary, Int32 OverTimeHour, Int32 OverTimeMinute, Int32 HalfDayHour, Int32 HalfDayMinute, Int32 SalaryGrade, Int32 LateHour, Int32 LateMin, String PfNo, String EsiNo, Int32 RAuthority, Int32 LAuthority, String HOD, String Dg)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(20);
        objDB.AddParameters(0, "id", RowId, DbType.Int32);
        objDB.AddParameters(1, "empId", Employee_id, DbType.Int32);
        objDB.AddParameters(2, "WED", WithEffectDate, DbType.Date);
        objDB.AddParameters(3, "deptID", DeptID, DbType.Int32);
        objDB.AddParameters(4, "desigID", DesigID, DbType.Int32);
        objDB.AddParameters(5, "payPeriod", PayPeriod, DbType.String);
        objDB.AddParameters(6, "basicSal", BasicSalary, DbType.Double);
        objDB.AddParameters(7, "overTimehour", OverTimeHour, DbType.Int32);
        objDB.AddParameters(8, "overTimeminute", OverTimeMinute, DbType.Int32);
        objDB.AddParameters(9, "halfDayhour", HalfDayHour, DbType.Int32);
        objDB.AddParameters(10, "halfDayminute", HalfDayMinute, DbType.Int32);
        objDB.AddParameters(11, "salGrade", SalaryGrade, DbType.Int32);
        objDB.AddParameters(12, "lateHour", LateHour, DbType.Int32);
        objDB.AddParameters(13, "lateMin", LateMin, DbType.Int32);
        objDB.AddParameters(14, "pfNo", PfNo, DbType.String);
        objDB.AddParameters(15, "esiNo", EsiNo, DbType.String);
        objDB.AddParameters(16, "RAuthority", RAuthority, DbType.Int32);
        objDB.AddParameters(17, "LAuthority", LAuthority, DbType.Int32);
        objDB.AddParameters(18, "HOD", HOD, DbType.String);
        objDB.AddParameters(19, "DG", Dg, DbType.String);
        int value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Payroll_EmpBasicSal");
        return value;
    }
    public int insert_recrutment_detail(int deptId, int desigId, int rdeptId, int authority, int insti_id, string session_id, string UserID)
    {
        int ret;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "deptId", deptId, DbType.Int32);
        objDB.AddParameters(1, "desigId", desigId, DbType.Int32);
        objDB.AddParameters(2, "rdeptId", rdeptId, DbType.Int32);
        objDB.AddParameters(3, "authority", authority, DbType.Int32);
        objDB.AddParameters(4, "InstituteID", insti_id, DbType.Int32);
        objDB.AddParameters(5, "SessionID", session_id, DbType.String);
        objDB.AddParameters(6, "UserID", UserID, DbType.String);
        ret = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SP_job_profile_M");
        return ret;
    }

    public int insert_Add_Panel_Members()
    {
        int ret;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        ret = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SP_New_Panel_Member_Details");
        return ret;

    }


    public int Insert_Add_Vacancy(int jobid, string code, string title, Int32 deptId, Int32 desigId, Int32 salfrom, Int32 salTO, Int32 maxAge, string responsibility, string minExp, string maxExp, Decimal Vacancy, DateTime StartDate, DateTime EndDate, Int32 qualId, Decimal percentage, string status, Int32 SkillID, Int32 TestID, Int32 insti_id, string session_id, string UserID)
    {
        int ret;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(22);
        objDB.AddParameters(0, "jobid", jobid, DbType.Int32);
        objDB.AddParameters(1, "code", code, DbType.String);
        objDB.AddParameters(2, "title", title, DbType.String);
        objDB.AddParameters(3, "deptId", deptId, DbType.Int32);
        objDB.AddParameters(4, "desigId", desigId, DbType.Int32);
        objDB.AddParameters(5, "salfrom", salfrom, DbType.Int32);
        objDB.AddParameters(6, "salTO", salTO, DbType.Int32);
        objDB.AddParameters(7, "maxAge", maxAge, DbType.Int32);
        objDB.AddParameters(8, "responsibility", responsibility, DbType.String);
        objDB.AddParameters(9, "minExp", minExp, DbType.String);
        objDB.AddParameters(10, "maxExp", maxExp, DbType.String);
        objDB.AddParameters(11, "tVacancy", Vacancy, DbType.Decimal);
        objDB.AddParameters(12, "aDate", StartDate, DbType.DateTime);
        objDB.AddParameters(13, "lDate", EndDate, DbType.DateTime);
        objDB.AddParameters(14, "qualId", qualId, DbType.Int32);
        objDB.AddParameters(15, "percentage", percentage, DbType.Decimal);
        objDB.AddParameters(16, "status", status, DbType.String);
        objDB.AddParameters(17, "SkillID", SkillID, DbType.Int32);
        objDB.AddParameters(18, "TestID", TestID, DbType.Int32);
        objDB.AddParameters(19, "insti_id", insti_id, DbType.Int32);
        objDB.AddParameters(20, "session_id", session_id, DbType.String);
        objDB.AddParameters(21, "UserID", UserID, DbType.String);
        ret = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Add_vacancy");
        return ret;

    }



    public string Insert_employee_details_final(string emptype, string password, string salt, string mode_application, string joiningdate, string empid, string confirmation, string reference, int insti, string session, string name, int nature, int deptid, int desig, int rauthority)
    {
        string value = "";
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(15);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "password", password, DbType.String);
        objDB.AddParameters(2, "salt", salt, DbType.String);
        objDB.AddParameters(3, "insti", insti, DbType.Int32);
        objDB.AddParameters(4, "session", session, DbType.String);
        objDB.AddParameters(5, "name", name, DbType.String);
        objDB.AddParameters(6, "apmode", mode_application, DbType.String);
        objDB.AddParameters(7, "reference", reference, DbType.String);
        objDB.AddParameters(8, "joindate", joiningdate, DbType.DateTime);
        objDB.AddParameters(9, "regidate", confirmation, DbType.DateTime);
        objDB.AddParameters(10, "emptype", emptype, DbType.String);
        objDB.AddParameters(11, "nature", nature, DbType.Int32);
        objDB.AddParameters(12, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(13, "desig", desig, DbType.Int32);
        objDB.AddParameters(14, "rauthority", rauthority, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Employee_detail_final");
        if (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                value = dr.GetString(0);
            }
        }
        return value;
    }

    public string Insert_employee_address_details(int empid, string paddress, int pcountry, int pstate, int pcity, string pzipcode, string pphone, string pemail, string pmobile, string llocalAdd, int lcountry, int lstate, int lcity, string lzipcode, string lphone, string lemail, string lmobile, string same_as_per)
    {
        string value = "";
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(18);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "paddress", paddress, DbType.String);
        objDB.AddParameters(2, "pcountry", pcountry, DbType.Int32);
        objDB.AddParameters(3, "pstate", pstate, DbType.Int32);
        objDB.AddParameters(4, "pcity", pcity, DbType.Int32);
        objDB.AddParameters(5, "pzipcode", pzipcode, DbType.String);
        objDB.AddParameters(6, "pphone", pphone, DbType.String);
        objDB.AddParameters(7, "pemail", pemail, DbType.String);
        objDB.AddParameters(8, "pmobile", pmobile, DbType.String);
        objDB.AddParameters(9, "laddress", llocalAdd, DbType.String);
        objDB.AddParameters(10, "lcountry", lcountry, DbType.Int32);
        objDB.AddParameters(11, "lstate", lstate, DbType.Int32);
        objDB.AddParameters(12, "lcity", lcity, DbType.Int32);
        objDB.AddParameters(13, "lzipcode", lzipcode, DbType.String);
        objDB.AddParameters(14, "lphone", lphone, DbType.String);
        objDB.AddParameters(15, "lemail", lemail, DbType.String);
        objDB.AddParameters(16, "lmobile", lmobile, DbType.String);
        objDB.AddParameters(17, "same_as_per", same_as_per, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Insert_employee_address_details");
        if (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                value = dr.GetString(0);
            }
        }
        return value;
    }


    public string insert_Employee_Details_exeperience(int empid, string keyskill, string profile, int industry_id, int function_id, string resume_path, string exe_year, string exe_month)
    {
        string value = "";
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "keyskill", keyskill, DbType.String);
        objDB.AddParameters(2, "profile", profile, DbType.String);
        objDB.AddParameters(3, "industry_id", industry_id, DbType.Int32);
        objDB.AddParameters(4, "function_id", function_id, DbType.Int32);
        objDB.AddParameters(5, "resume_path", resume_path, DbType.String);
        objDB.AddParameters(6, "exe_year", exe_year, DbType.String);
        objDB.AddParameters(7, "exe_month", exe_month, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "inser_employee_experience_details");
        if (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                value = dr.GetString(0);
            }
        }
        return value;
    }

    public string insert_Employee_Details_academic(int empid, string wed, string course, string university, int year, decimal marks, string grade, string image, string qualification)
    {
        string value = "";
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "wed", wed, DbType.DateTime);
        objDB.AddParameters(2, "course", course, DbType.String);
        objDB.AddParameters(3, "university", university, DbType.String);
        objDB.AddParameters(4, "year", year, DbType.Int32);
        objDB.AddParameters(5, "marks", marks, DbType.Decimal);
        objDB.AddParameters(6, "grade", grade, DbType.String);
        objDB.AddParameters(7, "image_doc", image, DbType.String);
        objDB.AddParameters(8, "qulification", qualification, DbType.String);
        //objDB.AddParameters(9, "offerletterid", offerId, DbType.String);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Inser_employee_academic_details");
        if (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                value = dr.GetString(0);
            }
        }
        return value;
    }


    public int update_Employee_Details_personal(int empid, string bloodgp, string FatherNm, string DOB, string Sex, string Religion, string MartStatus, string Nationality, string Spousenm, string mother, string pan)
    {
        int value = 0;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(11);
        objDB.AddParameters(0, "empid", empid, DbType.Int32);
        objDB.AddParameters(1, "bloodgp", bloodgp, DbType.String);
        objDB.AddParameters(2, "dob", DOB, DbType.DateTime);
        objDB.AddParameters(3, "fathernm", FatherNm, DbType.String);
        objDB.AddParameters(4, "gender", Sex, DbType.String);
        objDB.AddParameters(5, "religion", Religion, DbType.String);
        objDB.AddParameters(6, "marstatus", MartStatus, DbType.String);
        objDB.AddParameters(7, "national", Nationality, DbType.String);
        objDB.AddParameters(8, "suposenm", Spousenm, DbType.String);
        objDB.AddParameters(9, "mother", mother, DbType.String);
        objDB.AddParameters(10, "pan", pan, DbType.String);
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "insert_employee_details_second");
        return value;
    }

    public int insert_employee_value_first(string Session, string gensession, int insti, string emp_firstname, string emp_last_name, string mobile, string email, string title, string category, byte[] photo, byte[] sign, string offerId)
    {
        int value = 0;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(12);
        objDB.AddParameters(0, "insti", insti, DbType.Int32);
        objDB.AddParameters(1, "session", Session, DbType.String);
        objDB.AddParameters(2, "gensession", gensession, DbType.String);
        objDB.AddParameters(3, "empfirst", emp_firstname, DbType.String);
        objDB.AddParameters(4, "emplast", emp_last_name, DbType.String);
        objDB.AddParameters(5, "mobile", mobile, DbType.String);
        objDB.AddParameters(6, "email", email, DbType.String);
        objDB.AddParameters(7, "title", title, DbType.String);
        objDB.AddParameters(8, "category", category, DbType.String);
        objDB.AddParameters(9, "photo", photo, DbType.Binary);
        objDB.AddParameters(10, "sign", sign, DbType.Binary);
        objDB.AddParameters(11, "offerletterid", offerId, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "insert_employee_details_first");
        if (dr.Read())
        {
            if (!dr.IsDBNull(0))
            {
                value = dr.GetInt32(0);
            }
        }
        return value;
    }



    public DataTable bind_Employee_Leave_Notifications_single(int instiid, string session, string empcode)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "empcode", empcode, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "get_notification_leave_details_single");
        return ds;
    }


    public int insert_Tax_details_employee(string invest_type, string invest_no, string invest_amount, string invest_st_date, string invest_ed_date, string premium_type, string premimum_amount, string premimum_lt_date, string premimum_nx_date, string empcode)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(10);
        objDB.AddParameters(0, "invest_id", Convert.ToInt32(invest_type), DbType.Int32);
        objDB.AddParameters(1, "policy_no", invest_no, DbType.String);
        objDB.AddParameters(2, "policy_amount", Convert.ToDecimal(invest_amount), DbType.Decimal);
        objDB.AddParameters(3, "policy_st_date", invest_st_date, DbType.String);
        objDB.AddParameters(4, "policy_ed_date", invest_ed_date, DbType.String);
        objDB.AddParameters(5, "policy_premium", premium_type, DbType.String);
        objDB.AddParameters(6, "premium_amount", Convert.ToDecimal(invest_amount), DbType.Decimal);
        objDB.AddParameters(7, "lst_premiumdate", premimum_lt_date, DbType.String);
        objDB.AddParameters(8, "nxt_premiumdate", premimum_nx_date, DbType.String);
        objDB.AddParameters(9, "empcode", empcode, DbType.String);
        DataTable dt = new DataTable();
        int value = 0;
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "insert_investment_details");
        return value;
    }


    public int insert_Investment_Type_Master(string invest_name, string status, int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InvestName", invest_name, DbType.String);
        objDB.AddParameters(1, "Status", status, DbType.String);
        objDB.AddParameters(2, "InstiId", instiid, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_Invest_Type_Master");
        return value;
    }


    public int insert_Tax_Slap_Type_Master(string from, string to, decimal percentage, int instiid, int tax_type)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "from", from, DbType.String);
        objDB.AddParameters(1, "to", to, DbType.String);
        objDB.AddParameters(2, "percentage", percentage, DbType.Decimal);
        objDB.AddParameters(3, "instiid", instiid, DbType.Int32);
        objDB.AddParameters(4, "tax_type", tax_type, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_tax_slap_Master");
        return value;
    }



    public int update_Investment_Type_Master(int investid, string invest_name, string status, int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "Investid", investid, DbType.Int32);
        objDB.AddParameters(1, "InvestName", invest_name, DbType.String);
        objDB.AddParameters(2, "Status", status, DbType.String);
        objDB.AddParameters(3, "InstiId", instiid, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "update_Invest_Type_Master");
        return value;
    }

    public int get_find_employee_salary_grid(int instiid, int year, int empid, int monthid, string monthname, int empbasicid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "instiid", instiid, DbType.Int32);
        objDB.AddParameters(1, "empid", empid, DbType.Int32);
        objDB.AddParameters(2, "monthnm ", monthname, DbType.String);
        objDB.AddParameters(3, "mothid", monthid, DbType.Int32);
        objDB.AddParameters(4, "year", year, DbType.Int32);
        objDB.AddParameters(5, "basicid", empbasicid, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = Convert.ToInt32(objDB.ExecuteScalar(CommandType.StoredProcedure, "Payroll_Salary_Hr_wage"));
        return value;
    }



    public int get_find_employee_salary_grid_dept(int instiid, int year, int monthid, string monthname, int deptid, int desig)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "instiid", instiid, DbType.Int32);
        objDB.AddParameters(1, "monthnm", monthname, DbType.String);
        objDB.AddParameters(2, "mothid ", monthid, DbType.Int32);
        objDB.AddParameters(3, "year", year, DbType.Int32);
        objDB.AddParameters(4, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(5, "desigid", desig, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = Convert.ToInt32(objDB.ExecuteScalar(CommandType.StoredProcedure, "Payroll_Salary_Hr_wage_emp"));
        return value;
    }


    public DataTable bind_atteandance_details_value_for_department(string session, int instiid, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(1, "insti", instiid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_attendance_Data_bind");
        return ds;
    }


    public DataTable bind_employee_current_month_salary(int empid, int intid, string session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "Empid", empid, DbType.Int32);
        objDB.AddParameters(1, "insti", intid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_employee_current_month_salary");
        return ds;
    }


    public DataTable bind_employee_details_value_for_department(string session, int instiid, int deptid, string emptype)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(1, "insti", instiid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        objDB.AddParameters(3, "reporttype", emptype, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "get_employee_department_wise");
        return ds;
    }

    public DataTable bind_Employee_Leave_Notifications(int instiid, string session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "get_notification_leave_details");
        return ds;
    }


    public DataSet bind_Employee_Present_Details(int instiid, string fromdate, string todate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "fromdate", fromdate, DbType.String);
        objDB.AddParameters(2, "todate", todate, DbType.String);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details");
        return ds;
    }


    public DataSet bind_Employee_Present_Details_value_new(int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details_valuenew");
        return ds;
    }

    //public DataTable bind_employee_salary_details_for_ht(int empid, int instiid, string session)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(3);
    //    objDB.AddParameters(0, "empid", empid, DbType.Int32);
    //    objDB.AddParameters(1, "instid", instiid, DbType.Int32);
    //    objDB.AddParameters(2, "session", session, DbType.String);
    //    DataTable ds = new DataTable();
    //    ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_employee_salary_for_hr");
    //    return ds;
    //}

    public DataTable bind_employee_salary_details(int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_employee_salary_details");
        return ds;
    }

    public DataTable bind_hr_dashboard_for_employe(string session, int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "session", session, DbType.String);
        objDB.AddParameters(1, "instiid", instiid, DbType.Int32);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_department_wise_dashbord");
        return ds;
    }

    public DataTable bind_leave_details_value_for_department(string session, int instiid, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(1, "instiid", instiid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "employee_leave_details_for_hr");
        return ds;
    }
    public DataSet bind_notifhication_hr_details_department(string SessionID, int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "insti", inst_id, DbType.Int32);
        objDB.AddParameters(1, "session", SessionID, DbType.String);
        DataSet dt = new DataSet();
        dt = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details_department");
        return dt;
    }
    public DataTable bind_notifhication_value_for_department(int instiid, string session, int empid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "empid", empid, DbType.Int32);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_notifhication_hr_dashboard");
        return ds;
    }

    public DataTable bind_notifhication_value_DeptWise(int instiid, string session, int empid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "empid", empid, DbType.Int32);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "bind_notifhication_hr_dashboard_deptWise");
        return ds;
    }


    public DataTable bind_salary_details_value_for_department(string session, int instiid, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(1, "insti", instiid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_Salary_details");
        return ds;
    }

    public DataTable Employee_leave_details_month_by(int emp_id, string SessionID, int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "empid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "session", SessionID, DbType.String);
        objDB.AddParameters(2, "instid", inst_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_leave_details_month_by");
        return dt;
    }

    public DataTable Employee_Leave_full_details(int emp_id, string SessionID, int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "empid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "session", SessionID, DbType.String);
        objDB.AddParameters(2, "insti", inst_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_Leave_full_details");
        return dt;
    }


    public DataTable Employee_Leave_full_Summary(int emp_id, string SessionID, int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "deptid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "session", SessionID, DbType.String);
        objDB.AddParameters(2, "insti", inst_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_Leave_full_Summary");
        return dt;
    }

    public string get_employee_code_one_by_one(int next, int instiid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Next", next, DbType.Int32);
        objDB.AddParameters(1, "InstiId", instiid, DbType.Int32);
        string ds = "";
        ds = objDB.ExecuteScalar(CommandType.StoredProcedure, "get_empid_one_by_one").ToString();
        return ds;

    }


    public int fill_intrnlExam_student_attendance(string flag, int facultyid, int subjectid, string att_date, string entrydate, string session_id, int inst_id)
    {
        int retSuccess;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "facultyid", facultyid, DbType.Int32);
        objDB.AddParameters(1, "subjectid", subjectid, DbType.String);
        objDB.AddParameters(2, "att_date", att_date, DbType.DateTime);
        objDB.AddParameters(3, "entry_date", entrydate, DbType.DateTime);
        objDB.AddParameters(4, "session_id", session_id, DbType.String);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(6, "IsSuccess", 0, DbType.String, ParameterDirection.Output);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "fill_internlExam_Student_attendnace");
        return retSuccess = Int32.Parse(objDB.Parameters[6].Value.ToString());
    }

    public DataTable fill_intrnlExam_student_attendance1(string flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);

        objDB.AddParameters(0, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_internalExam_Student_Late_Attendnace_Details_");
        return dt;
    }


    public int update_tax_slap_Master(int investid, string from, string to, decimal percentage, int instid, int tax_type)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "id", investid, DbType.Int32);
        objDB.AddParameters(1, "from", from, DbType.String);
        objDB.AddParameters(2, "to", to, DbType.String);
        objDB.AddParameters(3, "percentage", percentage, DbType.Decimal);
        objDB.AddParameters(4, "instiid", instid, DbType.Int32);
        objDB.AddParameters(5, "tax_type", tax_type, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Update_Tax_Slap_Master");
        return value;
    }



    public int get_find_employee_grid(int instiid, int year, int deptid, int desigid, string fromdate, string todate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "instiid", instiid, DbType.Int32);
        objDB.AddParameters(1, "year", year, DbType.Int32);
        objDB.AddParameters(2, "fromdate", fromdate, DbType.Date);
        objDB.AddParameters(3, "todate", todate, DbType.Date);
        objDB.AddParameters(4, "deptid", deptid, DbType.Int32);
        objDB.AddParameters(5, "desigid", desigid, DbType.Int32);
        DataTable dt = new DataTable();
        int value = 0;
        value = Convert.ToInt32(objDB.ExecuteScalar(CommandType.StoredProcedure, "Get_Employee_Payroll_salary_details"));
        return value;
    }

    public DataTable Get_Tax_details_employee(decimal gross_salary, int age)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "anullsal", gross_salary, DbType.Decimal);
        objDB.AddParameters(1, "age", age, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Tax_slap_details_user");
        return dt;
    }

    public DataTable bind_student_overall_performance_single(int studid, string sessionid, int semesterid, int batchid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "sudentId", studid, DbType.Int32);
        objDB.AddParameters(1, "sessionid", sessionid, DbType.String);
        objDB.AddParameters(2, "SemesterID", semesterid, DbType.Int32);
        objDB.AddParameters(3, "batchid", batchid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_over_all_performance_single1");
        //dt = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Bind_over_all_performance_single");

        return dt;
    }

    public DataSet Student_Attendance(int studid, int subjectid, int yearid, int batchid, string sessionid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "student_Id", studid, DbType.Int32);
        objDB.AddParameters(1, "subjectid", subjectid, DbType.Int32);
        objDB.AddParameters(2, "yearid", yearid, DbType.Int32);
        objDB.AddParameters(3, "batchid", batchid, DbType.Int32);
        objDB.AddParameters(4, "sesionid", sessionid, DbType.String);

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Sp_ClassPosition_attendance");
        //dt = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Bind_over_all_performance_single");
        return ds;
    }

    public DataTable FillStudent_Record_NotUpdated(int inst)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "InstituteID", inst, DbType.Int32);
        DataTable Dt = new DataTable();
        Dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Sp_Student_Not_updated");
        return Dt;
    }

    public void FillCheckList(CheckBoxList ddl, string TextFieldName, string ValueFieldName, string sql, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        con.Open();
        SqlCommand com;
        SqlDataReader dr;
        com = new SqlCommand(sql, con);
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

        con.Close();
    }


    public DataSet Student_Average(int PapersetId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string retv = "";
        string f = "";


        objDB.CreateParameters(1);
        objDB.AddParameters(0, "PaperSet_id", PapersetId, DbType.Int32);

        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "ClassAverage");



        return ds;
    }

    //............Student Portal Methods.....//

    public DataTable Fill_Studnetmarks_detail(string studentid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Studentnid", studentid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_Studentmarks_Performance");
        return dt;
    }


    public DataTable Fill_StudnetAttendance_detail(int studentid, string courseID, string semester, string sessionId, int insId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Studentnid", studentid, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", semester, DbType.Int32);
        objDB.AddParameters(2, "courseID", courseID, DbType.Int32);
        objDB.AddParameters(3, "sessionID", sessionId, DbType.String);
        objDB.AddParameters(4, "instId", insId, DbType.Int32);


        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_StudentAttendance_Performance");
        return dt;
    }

    public DataTable Bind_VideoRef_TopicWise(int courseID, int SplID, int SemID, int SubID, int Inst_Id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();

        objDB.CreateParameters(7);
        objDB.AddParameters(0, "Courseid", courseID, DbType.Int32);
        objDB.AddParameters(1, "Semid", SemID, DbType.Int32);
        objDB.AddParameters(2, "splid", SplID, DbType.Int32);
        objDB.AddParameters(3, "SubID", SubID, DbType.Int32);
        objDB.AddParameters(4, "Inst_Id", Inst_Id, DbType.Int32);
        objDB.AddParameters(5, "Facultyid", 0, DbType.Int32);
        objDB.AddParameters(6, "Flag", "S", DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_VedioRef_Topic_Wise");
        return dt;
    }

    public DataTable StudnetSubjectMarks_anlysis(string student_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);

        objDB.AddParameters(0, "Studentnid", student_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_StudentSubjectmarks_analysis");
        return dt;
    }

    public DataTable Studnetmarks_detail(int subjectid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);

        objDB.AddParameters(0, "subject_id", subjectid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_Studentmarks_detail");
        return dt;
    }

    public DataTable Fill_Studnetmarks_Analysis(string studentid, int subjectid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Studentnid", studentid, DbType.Int32);
        objDB.AddParameters(1, "subject_id", subjectid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_Studentmarks_Analysis");
        return dt;
    }

    public void FillDdl_NOzeroIndex(DropDownList ddl, string TextFieldName, string ValueFieldName, string sql)
    {
        ddl.Items.Clear();
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }
        com = new SqlCommand(sql, objCon.con);
        com.Connection.Open();
        dr = com.ExecuteReader();
        try
        {
            if (dr.HasRows)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = TextFieldName;
                ddl.DataValueField = ValueFieldName;
                ddl.DataBind();

            }
            else
            {
                // ddl.DataSource = dr;
                // ddl.DataBind();

            }
        }

        finally
        {
            dr.Close();
            dr.Dispose();
            com.Connection.Close();
            //objCon.con.Dispose();
        }
    }

    public DataTable Assign_Notification(string sessionid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);

        objDB.AddParameters(0, "Sessionid", sessionid, DbType.String);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Assign_Notification");
        return dt;
    }
    public DataTable Get_Ass_detail1(int instID,string Faculty,string sessionid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);

        objDB.AddParameters(0, "instid", instID, DbType.Int32);
        objDB.AddParameters(1, "facultyid", Faculty, DbType.String);
        objDB.AddParameters(2, "Session", sessionid, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Assignment_Detail");
        return dt;
    }
    public DataTable Get_Ass_detailSubjectWise(int instID, string Faculty, string sessionid,string SubjectId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);

        objDB.AddParameters(0, "instid", instID, DbType.Int32);
        objDB.AddParameters(1, "facultyid", Faculty, DbType.String);
        objDB.AddParameters(2, "Session", sessionid, DbType.String);
        objDB.AddParameters(3, "SubjectId", SubjectId, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Assignment_Detail_SubjectWise");
        return dt;
    }
    public DataTable Get_Ass_detailStudentWise(int instID, string Faculty, string sessionid, string SubjectId,string AssignmentId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);

        objDB.AddParameters(0, "instid", instID, DbType.Int32);
        objDB.AddParameters(1, "facultyid", Faculty, DbType.String);
        objDB.AddParameters(2, "Session", sessionid, DbType.String);
        objDB.AddParameters(3, "SubjectId", SubjectId, DbType.String);
        objDB.AddParameters(4, "AssignmentId", AssignmentId, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Assignment_Detail_StudentWise");
        return dt;
    }

    public DataTable Show_Assign(string sessionid, int stu_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);

        objDB.AddParameters(0, "Sessionid", sessionid, DbType.String);
        objDB.AddParameters(1, "stud_id", stu_id, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Show_Assignmnet");
        return dt;

    }
    public void FillApporalAuthority(RadioButtonList chk, string institute)
    {
        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "instituteid", Int32.Parse(institute), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "ApporalAuthority");
        try
        {


            if (dr != null)
            {
                chk.DataSource = dr;
                chk.DataTextField = "Designation";
                chk.DataValueField = "empId";
                chk.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }

    public void FillApporalAuthorities(CheckBoxList chk, string institute)
    {
        chk.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "instituteid", Int32.Parse(institute), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "ApporalAuthority");
        try
        {


            if (dr != null)
            {
                chk.DataSource = dr;
                chk.DataTextField = "Designation";
                chk.DataValueField = "empId";
                chk.DataBind();
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Dispose();
        }

    }

    public DataTable getEmployeeTotalTAxdetails(string session, int instid, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "session", session, DbType.String);
        objDB.AddParameters(1, "instid", instid, DbType.Int32);
        objDB.AddParameters(2, "deptid", deptid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GET_Employee_Tax_details");
        return dt;
    }

    public DataTable getEmployeeTotalTAxdetails_report(string session, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "session", session, DbType.String);
        objDB.AddParameters(1, "instid", instid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GET_Employee_Tax_details_report");
        return dt;
    }


    public DataTable getEmployeeTotalPFdetails_report(string session, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "session", session, DbType.String);
        objDB.AddParameters(1, "instiid", instid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GET_Employee_PF_Details_report");
        return dt;
    }

    public DataTable getEmployeeTotalPFdetails(string session, int instid, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "session", session, DbType.String);
        objDB.AddParameters(1, "instiid", instid, DbType.Int32);
        objDB.AddParameters(2, "deptid", deptid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GET_Employee_PF_Details");
        return dt;
    }

    public DataTable 
        Bind_Student_Dulicate_RollNo(int studentID,int SubjectID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "studentid", studentID, DbType.Int32);
        objDB.AddParameters(1, "subject_id", SubjectID, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_Student_Dulicate_RollNo");
        return dt;
    }


    public int fill_intrnlExam_student_Exammarks(string flag, int facultyid, int subjectid, string att_date, string entrydate, string session_id, int inst_id)
    {
        int retSuccess;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "facultyid", facultyid, DbType.Int32);
        objDB.AddParameters(1, "subjectid", subjectid, DbType.String);
        objDB.AddParameters(2, "att_date", att_date, DbType.DateTime);
        objDB.AddParameters(3, "entry_date", entrydate, DbType.DateTime);
        objDB.AddParameters(4, "session_id", session_id, DbType.String);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(6, "IsSuccess", 0, DbType.String, ParameterDirection.Output);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "fill_internlExam_Student_Marks");
        return retSuccess = Int32.Parse(objDB.Parameters[6].Value.ToString());
    }

    public int ExecuteDelete(string sql)
    {
        int result = 1;
        if (objCon.con.State == ConnectionState.Closed)
        {
            objCon = new DbConnection();
        }

        com = new SqlCommand(sql, objCon.con);
        com.CommandTimeout = 300;
        com.Connection.Open();
        com.ExecuteNonQuery();
        com.Connection.Close();
        return result;
    }

    public DataSet Seating_Pattern(string batch_id, string testdate, string fromtime, string totime, int sub_cat, string sub_id, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string retv = "";
        string f = "";

        objDB.CreateParameters(7);
        objDB.AddParameters(0, "batch_id", batch_id, DbType.String);
        objDB.AddParameters(1, "date", testdate, DbType.String);
        objDB.AddParameters(2, "fromtime", fromtime, DbType.String);
        objDB.AddParameters(3, "Totime", totime, DbType.String);
        objDB.AddParameters(4, "subcat", sub_cat, DbType.Int32);
        objDB.AddParameters(5, "sub_id", sub_id, DbType.String);
        objDB.AddParameters(6, "flag", flag, DbType.Int32);

        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Seating_procedure");

        return ds;
    }

    public DataTable Fill_Placement_industryWise(String Session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SessionID", Session, DbType.String);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_PlacementIndustry");
        return dt;
    }

    public DataTable Fill_Placement_Course_Wise(String Session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SessionID", Session, DbType.String);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_Placement_CourseWise");
        return dt;
    }

    public string Schedule_Test(ExamDM.ExamScheduleDM objDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string retv = "";
        string f = "";


        objDB.CreateParameters(7);
        objDB.AddParameters(0, "semid", objDM.semid, DbType.Int32);
        objDB.AddParameters(1, "spclID", objDM.specid, DbType.Int32);
        objDB.AddParameters(2, "courseID", objDM.courseid, DbType.Int32);
        objDB.AddParameters(3, "session", objDM.sessionid, DbType.String);
        objDB.AddParameters(4, "date", objDM.SchDate, DbType.String);
        objDB.AddParameters(5, "From_Time", objDM.TimeFrom, DbType.String);
        objDB.AddParameters(6, "To_Time", objDM.TimeTo, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Schedule_Test");

        DataTable dt = new DataTable();
        dt.Load(dr);

        if (dt.Rows.Count > 0)
        {
            retv = dt.Rows[0]["Column1"].ToString();

        }



        objDB.Connection.Close();
        objDB.Dispose();

        return retv;
    }

    public DataSet Getvaluefromdata(int start, int max, string sortColumn, string sortOrder, string cond, int inst, int userid)
    {
        string Cond_SQL = string.Empty;
        if (max == 0)
        {
            max = 10;
        }

        if (string.IsNullOrEmpty(sortColumn))
        {
            sortColumn = "ID";
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            sortOrder = "DESC";
        }
        if (cond != string.Empty)
        {
            Cond_SQL = cond;
            if (cond == "A")
            {
                Cond_SQL = "True";
            }
            if (cond == "NA")
            {
                Cond_SQL = "False";
            }
        }
        else
        {
            cond = "Al";
        }
        int rval = 0;
        SqlCommand com1 = null;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        {
            con.Open();
            com1 = new SqlCommand("select deptid from iemployeeusers_vw where userid=" + userid, con);
            object retdid = com1.ExecuteScalar();
            rval = retdid != null ? int.Parse(retdid.ToString()) : 0;
            con.Close();
        }
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string retv = "";
        string f = "";
        DataSet ds = new DataSet();

        objDB.CreateParameters(5);
        objDB.AddParameters(0, "flag", cond, DbType.String);
        objDB.AddParameters(1, "start", start, DbType.Int32);
        objDB.AddParameters(2, "max", max, DbType.Int32);
        objDB.AddParameters(3, "Condition", Cond_SQL, DbType.String);
        objDB.AddParameters(4, "InstId", inst, DbType.Int32);
        objDB.AddParameters(5, "deptid", rval, DbType.Int32);
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "SP_Indent_Boxadm");
        return ds;

    }

    public DataSet GetIndentDeptWise(int start, int max, string sortColumn, string sortOrder, string cond, int inst, int userid, string deptid)
    {
        string Cond_SQL = string.Empty;
        if (max == 0)
        {
            max = 10;
        }

        if (string.IsNullOrEmpty(sortColumn))
        {
            sortColumn = "ID";
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            sortOrder = "DESC";
        }
        if (cond != string.Empty)
        {
            Cond_SQL = cond;
            if (cond == "A")
            {
                Cond_SQL = "True";
            }
            if (cond == "NA")
            {
                Cond_SQL = "False";
            }
        }
        else
        {
            cond = "Al";
        }

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string retv = "";
        string f = "";
        DataSet ds = new DataSet();

        objDB.CreateParameters(6);
        objDB.AddParameters(0, "flag", cond, DbType.String);
        objDB.AddParameters(1, "start", start, DbType.Int32);
        objDB.AddParameters(2, "max", max, DbType.Int32);
        objDB.AddParameters(3, "Condition", Cond_SQL, DbType.String);
        objDB.AddParameters(4, "InstId", inst, DbType.Int32);
        objDB.AddParameters(5, "deptid", deptid, DbType.String);
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "SP_Indent_Box_DeptWise");
        return ds;

    }

    public int fill_student_attendance(string flag, int facultyid, int subjectid, string att_date, string entrydate, string session_id, int inst_id)
    {
        int retSuccess;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "facultyid", facultyid, DbType.Int32);
        objDB.AddParameters(1, "subjectid", subjectid, DbType.String);
        objDB.AddParameters(2, "att_date", att_date, DbType.DateTime);
        objDB.AddParameters(3, "entry_date", entrydate, DbType.DateTime);
        objDB.AddParameters(4, "session_id", session_id, DbType.String);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(6, "IsSuccess", 0, DbType.String, ParameterDirection.Output);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "fill_Student_attendnace");
        return retSuccess = Int32.Parse(objDB.Parameters[6].Value.ToString());
    }

    public DataTable Bind_GridView(string Session_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Session_id", Session_id, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "show_faculty_late_log");
        return dt;
    }

    public DataTable fill_student_attendance1(string flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);

        objDB.AddParameters(0, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_Student_Late_Attendnace_Details_");
        return dt;
    }

    public DataTable StudentDetail(string SelectedColumn, int Course, int Spec, string Batch, int YearSem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "SelctedColumns", SelectedColumn, DbType.String);
        objDB.AddParameters(1, "CourseID", Course, DbType.Int32);
        objDB.AddParameters(2, "SpecID", Spec, DbType.Int32);
        objDB.AddParameters(3, "BatchID", Batch, DbType.String);
        objDB.AddParameters(4, "SemID", YearSem, DbType.Int32);      
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_detail_Report_m");
        return dt;
    }

    public DataTable StudentCompleteDetailReport(string SelectedColumn, string sessionid, string yearid, int instid, string condition)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "SelctedColumns", SelectedColumn, DbType.String);
        objDB.AddParameters(1, "sessionid", sessionid, DbType.String);
        objDB.AddParameters(2, "yearid", yearid, DbType.String);
        objDB.AddParameters(3, "instid", instid, DbType.Int32);
        objDB.AddParameters(4, "condition", condition, DbType.String);

        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_detail_Report_m");
        return dt;
    }

    public DataTable Student_Bal_Fee_Detail(string SelectedColumn, int Course, int Spec, string Batch, int YearSem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "SelctedColumns", SelectedColumn, DbType.String);
        objDB.AddParameters(1, "CourseID", Course, DbType.Int32);
        objDB.AddParameters(2, "SpecID", Spec, DbType.Int32);
        objDB.AddParameters(3, "BatchID", Batch, DbType.String);
        objDB.AddParameters(4, "SemID", YearSem, DbType.Int32);

        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Bal_Fee_Detail_Report");
        return dt;
    }

    public DataTable VisitedCompany_Record(int course, string Session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseID", course, DbType.Int32);
        objDB.AddParameters(1, "Session", Session, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Placement_visited_company_Report");
        return ds;
    }

    public DataTable Selected_Rejected_Student_Placement_Record(int instid, string Condition)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instid", instid, DbType.Int32);
        objDB.AddParameters(1, "Condition", Condition, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Selected_Rejected_Student_Placement_Record");
        return ds;
    }

    public void FillDropdownCheckbox(Saplin.Controls.DropDownCheckBoxes ddlsel_pross, string textField, string valuefield, string sql, string p_4)
    {
        try
        {
            
            DbConnection objCon = new DbConnection();
            DataSet ds = new DataSet();

            string cmdstr = sql;

            SqlDataAdapter adp = new SqlDataAdapter(cmdstr, objCon.con);

            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsel_pross.DataSource = ds.Tables[0];
                ddlsel_pross.DataTextField = textField;
                ddlsel_pross.DataValueField = valuefield;
                ddlsel_pross.DataBind();
            }
        }
        catch (Exception e)
        {
        }
    }
    public void FillDropdownCheckboxIndex(Saplin.Controls.DropDownCheckBoxes ddlsel_pross, string textField, string valuefield, string sql, string p_4)
    {
        try
        {
            ddlsel_pross.Items.Clear();
            DbConnection objCon = new DbConnection();
            DataSet ds = new DataSet();

            string cmdstr = sql;

            SqlDataAdapter adp = new SqlDataAdapter(cmdstr, objCon.con);

            adp.Fill(ds);
            
            
                ddlsel_pross.Items.Add("A To Z");
                ddlsel_pross.Items.Add("Z to A");

            
            
            if (ds.Tables[0].Rows.Count > 1)
            {
                ddlsel_pross.DataSource = ds.Tables[0];
                ddlsel_pross.DataTextField = textField;
                ddlsel_pross.DataValueField = valuefield;
                ddlsel_pross.DataBind();
            }
        }
        catch (Exception e)
        {
        }
    }

    public DataTable Placement_Record(int course, string Batch)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseID", course, DbType.Int32);
        objDB.AddParameters(1, "BatchID", Batch, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Placement_Summary_Report");
        return ds;
    }

    public DataTable Placement_Record_View(int course, string Batch)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseID", course, DbType.Int32);
        objDB.AddParameters(1, "BatchID", Batch, DbType.String);
        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Placement_Summary_Report_view");
        return ds;
    }


    public DataTable VerticalWisePlacement(int Course, string Batch)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseID", Course, DbType.Int32);
        objDB.AddParameters(1, "BatchID", Batch, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Company_Type_Placement_Details");
        return dt;
    }

    public DataTable GetSunday(DateTime Sdate, DateTime EDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "startDate", Sdate, DbType.DateTime);
        objDB.AddParameters(1, "endDate", EDate, DbType.DateTime);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SundayForAllYears");
        return dt;
    }

    public DataTable fillWage(int Grade, int instID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "ID", instID, DbType.Int32);//ID as InstituteID
        objDB.AddParameters(1, "flag", "S", DbType.String);
        objDB.AddParameters(2, "empBasicId", Grade, DbType.Int32);//empBasicId as GradeID
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SP_EmpWage");
        //dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SundayForAllYears");
        return dt;
    }

    public DataTable CreateLecturePlan(int Course, int yearid, string sessionid, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "courseid", Course, DbType.Int32);
        objDB.AddParameters(1, "yearid", yearid, DbType.Int32);
        objDB.AddParameters(2, "sessionId", sessionid, DbType.String);
        objDB.AddParameters(3, "instid", instid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "CreateLecturePlan");
        return dt;
    }

    public DataTable FillDashboardGrid(int InstId, string Flag, string Course)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", InstId, DbType.Int32);
        objDB.AddParameters(1, "Status", Flag, DbType.String);
        objDB.AddParameters(2, "Course", Course, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "DetailedDashboard");

        return dt;
    }

    public DataTable Dashboard_Notification(int EmpID, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Empid", EmpID, DbType.Int32);
        objDB.AddParameters(1, "InstID", instid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Dashboard_Notification");
        DataTable dt = new DataTable();
        dt = ds.Tables[1];
        return dt;
    }

    public DataTable Dashboard_Message(int EmpID, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Empid", EmpID, DbType.Int32);
        objDB.AddParameters(1, "InstID", instid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Dashboard_Notification");
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        return dt;
    }

    public DataTable NatureWiseBalLeave(string Year, int Month)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Session", Year, DbType.String);
        objDB.AddParameters(1, "Month", Month, DbType.Int32);


        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_Leave_MonthWise");
        return dt;
    }

    public DataTable GenerateLecturePlan(int Course, int yearid, string sessionid, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "courseid", Course, DbType.Int32);
        objDB.AddParameters(1, "yearid", yearid, DbType.Int32);
        objDB.AddParameters(2, "sessionId", sessionid, DbType.String);
        objDB.AddParameters(3, "instid", instid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Generate_LecturePlan");
        return dt;
    }

    public DataTable InsertpageURL(string pageURL, string pageTitle, int userid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);

        objDB.AddParameters(0, "pageURL", pageURL, DbType.String);
        objDB.AddParameters(1, "pageTitle", pageTitle, DbType.String);
        objDB.AddParameters(2, "userid", userid, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Insert_Select_pageURL");
        return dt;
    }

    public void deletetabfromtable(int pageid, int userid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);

        objDB.AddParameters(0, "pageid", pageid, DbType.Int32);
        objDB.AddParameters(1, "userid", userid, DbType.Int32);
       
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Delete_Select_Tabs_forUser");
        
    }
    public DataTable Check_Faculty(int semid, int spclid, int courseid, string session_id, string from_time, string To_time, int faculty_id, string day, int period)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "semid", semid, DbType.Int32);
        objDB.AddParameters(2, "session", session_id, DbType.String);
        objDB.AddParameters(3, "spclID", spclid, DbType.Int32);
        objDB.AddParameters(4, "From_Time", from_time, DbType.String);
        objDB.AddParameters(5, "To_Time", To_time, DbType.String);
        objDB.AddParameters(6, "faculty_Id", faculty_id, DbType.Int32);
        objDB.AddParameters(7, "dayno", day, DbType.String);
        objDB.AddParameters(8, "period", period, DbType.Int32);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "check_faculty");
        return dt;
    }
    public int Approve_ActivityR_Lecture(string flag, int facultyid, int subjectid, string att_date, string entrydate, string session_id, int inst_id)
    {
        int retSuccess;
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "facultyid", facultyid, DbType.Int32);
        objDB.AddParameters(1, "subjectid", subjectid, DbType.String);
        objDB.AddParameters(2, "att_date", att_date, DbType.DateTime);
        objDB.AddParameters(3, "entry_date", entrydate, DbType.DateTime);
        objDB.AddParameters(4, "session_id", session_id, DbType.String);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(5, "inst_id", inst_id, DbType.Int32);
        objDB.AddParameters(6, "IsSuccess", 0, DbType.String, ParameterDirection.Output);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Approve_ActivityReg_Lecture");
        return retSuccess = Int32.Parse(objDB.Parameters[6].Value.ToString());
    }
    public DataTable FillSubjectlistforFacultyChoice1(string inst_ID, string session, string CourseID, string splid, string Semester, string batch, string empid, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "InstituteID", Int32.Parse(inst_ID), DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "Courseid", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(3, "SpecilisationID", Int32.Parse(splid), DbType.Int32);
        objDB.AddParameters(4, "Semester", Int32.Parse(Semester), DbType.Int32);
        objDB.AddParameters(5, "batch", batch, DbType.String);
        objDB.AddParameters(6, "empid", Int32.Parse(empid), DbType.Int32);
        objDB.AddParameters(7, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "SubjectListforFacultyChoice");
        return dt;

    }
    public DataTable bind_Employee_InOUT_Time(int instiid, int EmpID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "EmpID", EmpID, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Sp_Login_Inout_time");
        return dt;
    }

    public DataTable GetServerTime()
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(0);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Server_Date_Time");
        return dt;
    }

    public object EmpCR(int MAxid, int Empid, int MonthName, int Year, decimal Days, DateTime CRDate, DateTime ModifyDate, string Reason, int instid, int UserID, string Session, DateTime UserEntryDate, string Status, string Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(14);
        objDB.AddParameters(0, "MAxid", MAxid, DbType.Int32);
        objDB.AddParameters(1, "Empid", Empid, DbType.Int32);
        objDB.AddParameters(2, "MonthName", MonthName, DbType.Int32);
        objDB.AddParameters(3, "Year", Year, DbType.Int32);
        objDB.AddParameters(4, "Days", Days, DbType.Decimal);
        objDB.AddParameters(5, "CRDate", CRDate, DbType.DateTime);
        objDB.AddParameters(6, "ModifyDate", ModifyDate, DbType.DateTime);
        objDB.AddParameters(7, "Reason", Reason, DbType.String);
        objDB.AddParameters(8, "instid", instid, DbType.Int32);
        objDB.AddParameters(9, "UserID", UserID, DbType.Int32);
        objDB.AddParameters(10, "Session", Session, DbType.String);
        objDB.AddParameters(11, "UserEntryDate", UserEntryDate, DbType.DateTime);
        objDB.AddParameters(12, "Status", Status, DbType.String);
        objDB.AddParameters(13, "Flag", Flag, DbType.String);
        object retval;
        retval = objDB.ExecuteScalar(CommandType.StoredProcedure, "EmployeeCRInsert");
        return retval;
    }

    public DataTable Student_Dashboard_Notification(int EmpID, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Empid", EmpID, DbType.Int32);
        objDB.AddParameters(1, "InstID", instid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "student_Dashboard_Notification");
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        return dt;
    }

    public DataTable View_CoursePlan_Notification(int EmpID, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "empid", EmpID, DbType.Int32);

        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "View_CoursePlan_Notification");
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        return dt;
    }

    public DataTable BindTimeTable_Calender(int Empid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "empid", Empid, DbType.Int32);

        DataTable ds = new DataTable();
        ds = objDB.ExecuteTable(CommandType.StoredProcedure, "BindTimeTable_Calender");
        return ds;
    }

    public DataTable Employee_timming_detail_Export(int instid, string orderby)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "insti", instid, DbType.Int32);
        objDB.AddParameters(1, "orderby", orderby, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Employee_timming_detail_Export");
        return dt;
    }

    public DataSet bind_Employee_Present_Details_with_empid(int instiid, string fromdate, string todate, int empid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "fromdate", fromdate, DbType.String);
        objDB.AddParameters(2, "todate", todate, DbType.String);
        objDB.AddParameters(3, "empid1", empid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details_with_empid");
        return ds;
    }

    
    public DataSet bind_Employee_Present_Details_value_new_with_empid(int instiid, int empid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "empid1", empid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details_valuenew_with_empid");
        return ds;
    }
    public DataSet bind_Employee_Present_Details_with_deptid(int instiid, string fromdate, string todate, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "fromdate", fromdate, DbType.String);
        objDB.AddParameters(2, "todate", todate, DbType.String);
        objDB.AddParameters(3, "depid1", deptid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details_with_depid");
        return ds;
    }

    public DataSet bind_Employee_Present_Details_value_new_with_deptid(int instiid, int deptid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "insti", instiid, DbType.Int32);
        objDB.AddParameters(1, "deptid", deptid, DbType.Int32);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "bind_notifhication_hr_details_valuenew_with_deptid");
        return ds;
    }

    public DataTable EmpShortDayAttendance(DateTime ToDate, DateTime FromDate, int instID, int Empid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "TDate", ToDate, DbType.DateTime);
        objDB.AddParameters(1, "FDate", FromDate, DbType.DateTime);
        objDB.AddParameters(2, "InstID", instID, DbType.Int32);
        objDB.AddParameters(3, "empID", Empid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "empShortLeave_Calculation");
        return dt;
    }

    public DataTable GetStudentPersonalDetails(int studentid,int instID,int Semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(1, "instID", instID, DbType.Int32);
        objDB.AddParameters(2, "SemID", Semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GetStudentPersonalDetails");
        return dt;
    }

    public DataTable Fill_Faculty_Dashboard_Data_course1(int emp_id, string SessionID, int inst_id, int semid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "faculityid", emp_id, DbType.Int32);
        objDB.AddParameters(1, "SessionId", SessionID, DbType.String);
        objDB.AddParameters(2, "InstId", inst_id, DbType.Int32);
        objDB.AddParameters(3, "Semid", semid, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "sp_faculty_wise_course_completion_percentage1");
        return dt;
    }

    public DataTable EmpAttDetail(string Empid, DateTime date)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "empid", Empid, DbType.String);
        objDB.AddParameters(1, "wed", date, DbType.Date);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmpAttDetail");
        return dt;
    }

    public int update_Employee_Timming(string sessId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "@Sessionid", sessId, DbType.String);

        DataTable dt = new DataTable();
        int value = 0;
        value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Update_Employee_Timming");
        return value;
    }

    public DataTable StudentCount(string Condition)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Condition", Condition, DbType.String);

        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Count_Branch_CastCategoryWise_Report");
        return dt;
    }

    public DataTable MonthWiseEmployeeAttendanceDetails(int instid, string TDate, string FDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstID", instid, DbType.Int32);
        objDB.AddParameters(1, "TDate", FDate, DbType.String);
        objDB.AddParameters(2, "FDate", TDate, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "MonthWiseEmployeeAttendanceDetails");
        return dt;
    }

    public DataTable Employee_MIS_AttendanceDetails(int instid, string TDate, string FDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstID", instid, DbType.Int32);
        objDB.AddParameters(1, "TDate", FDate, DbType.String);
        objDB.AddParameters(2, "FDate", TDate, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "MonthWiseEmployee_MIS_Details");
        return dt;
    }

    public DataTable EmployeeWiseAttendanceDetails(int instid, string TDate, string FDate, int employeeID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "InstID", instid, DbType.Int32);
        objDB.AddParameters(1, "TDate", FDate, DbType.String);
        objDB.AddParameters(2, "FDate", TDate, DbType.String);
        objDB.AddParameters(3, "EmployeeID", employeeID, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmployeeWiseAttendanceDetails");
        return dt;
    }

    public DataTable EmpPunchCount(int instid, string TDate, string FDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstID", instid, DbType.Int32);
        objDB.AddParameters(1, "TDate", FDate, DbType.String);
        objDB.AddParameters(2, "FDate", TDate, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Emp_Punch_Count_Detail_Report");
        return dt;
    }

    public DataSet SIPReportFill(int instid,string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);        
        objDB.AddParameters(0, "InstID", instid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.String);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Student_SIP");
        return ds;
    }

    public DataSet SIPReportFillByFilter(int instid, string batch,string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "batch", batch, DbType.String);
        objDB.AddParameters(1, "InstID", instid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.String);
        DataSet ds = new DataSet();
        ds = objDB.ExecuteDataSet(CommandType.StoredProcedure, "Student_SIP");
        return ds;
    }

    public DataTable CR_Leave_Detail(string Condition)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Condition", Condition, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "CR_Leave_Detail");
        return dt;
    }

    public DataTable FillMailServerCredentials(int inst_id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "inst_id", inst_id, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GetMailServerCredentials");
        return dt;
    }

    public DataTable GetUserPassword(string UserName)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "UserName", UserName, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Pwd_Recovery");
        return dt;
    }


    public DataTable uploadedDocument(string course, string spl, string sem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "course", course, DbType.String);
        objDB.AddParameters(1, "spl", spl, DbType.String);
        objDB.AddParameters(2, "sem", sem, DbType.String);        
        DataTable dt = new DataTable();
       
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Uploded_Document_Report");
           

        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable Temp_EmpAtt(string Day, string Month, string Year)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);

        objDB.AddParameters(0, "Day", Day, DbType.Int32);
        objDB.AddParameters(1, "month", Month, DbType.Int32);
        objDB.AddParameters(2, "year", Year, DbType.Int32);
        // IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_Att_Temp_Attendance");
        return dt;
    }

}



