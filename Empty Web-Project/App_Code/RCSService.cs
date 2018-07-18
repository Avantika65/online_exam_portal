using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.ComponentModel;
using System.Configuration;
using System.Net.Mail;
using NewDAL;
//using DataAccLayer;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSS;
//using MSS1;
using System.Data;
using System.Runtime.Serialization;

[Serializable]
[DataContract]
public class Emp_Detatil
{
    [DataMember]
    public string Emp_Id { get; set; }

    [DataMember]
    public string Emp_Name { get; set; }

    [DataMember]
    public string Emp_Dept { get; set; }

    [DataMember]
    public string Status { get; set; }
    
}

[Serializable]
[DataContract]
public class Emp_Attend_Detatil
{
    [DataMember]
    public string Id { get; set; }

    [DataMember]
    public string SrNo { get; set; }

    [DataMember]
    public string Attend_Date { get; set; }

    [DataMember]
    public string InTime { get; set; }

    [DataMember]
    public string OutTime { get; set; }

    [DataMember]
    public string PresentStatus { get; set; }

    [DataMember]
    public string Worked_Hrs { get; set; }

    [DataMember]
    public string Remark { get; set; }
}
[Serializable]
[DataContract]
public class LeaveDM
{
    [DataMember]
    public int LeaveID { get; set; }
    [DataMember]
    public string Leavesname { get; set; }
}
[Serializable]
[DataContract]
public class FillEmployee
{
    [DataMember]
    public int EmpID { get; set; }
    [DataMember]
    public string Empname { get; set; }
    [DataMember]
    public string Lastname { get; set; }
    [DataMember]
    public DateTime JoinDate { get; set; }

    [DataMember]
    public string resDate { get; set; }
    [DataMember]
    public string a1 { get; set; }
    [DataMember]
    public string a2 { get; set; }
    [DataMember]
    public string a3 { get; set; }
    [DataMember]
    public string a4 { get; set; }
    [DataMember]
    public string a5 { get; set; }
    [DataMember]
    public string a6 { get; set; }
    [DataMember]
    public string a7 { get; set; }
    [DataMember]
    public string a8 { get; set; }
    [DataMember]
    public string a9 { get; set; }
    [DataMember]
    public string a10 { get; set; }
    [DataMember]
    public string a11 { get; set; }
    [DataMember]
    public string a12 { get; set; }
    [DataMember]
    public string a13 { get; set; }
    [DataMember]
    public string a14 { get; set; }
    [DataMember]
    public string a15 { get; set; }
    [DataMember]
    public string a16 { get; set; }
    [DataMember]
    public string a17 { get; set; }
    [DataMember]
    public string a18 { get; set; }
    [DataMember]
    public string a19 { get; set; }
    [DataMember]
    public string a20 { get; set; }
    [DataMember]
    public string a21 { get; set; }
    [DataMember]
    public string a22 { get; set; }
    [DataMember]
    public string a23 { get; set; }
    [DataMember]
    public string a24 { get; set; }
    [DataMember]
    public string a25 { get; set; }
    [DataMember]
    public string a26 { get; set; }
    [DataMember]
    public string a27 { get; set; }
    [DataMember]
    public string a28 { get; set; }
    [DataMember]
    public string a29 { get; set; }
    [DataMember]
    public string a30 { get; set; }
    [DataMember]
    public string a31 { get; set; }

}
[Serializable]
[DataContract]
public class Emp_Attend_DetatilDM
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string EmpId { get; set; }
    [DataMember]
    public DateTime Attend_Date { get; set; }
    [DataMember]
    public string PresentStatus { get; set; }
    [DataMember]
    public int AttMonth { get; set; }
    [DataMember]
    public int AttYear { get; set; }
    [DataMember]
    public int InstId { get; set; }
    [DataMember]
    public string sessionID { get; set; }
    [DataMember]
    public int EmpDesig { get; set; }
    [DataMember]
    public int EmpDept { get; set; }
    [DataMember]
    public int flag { get; set; }

}

/// <summary>
/// Summary description for RCSService
/// </summary>
[WebService(Namespace = "")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class RCSService : System.Web.Services.WebService
{
    //DBManager objDB;
    public RCSService()
    {
    }
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
    /// <summary>
    /// Check IsSession Expired
    /// </summary>
    /// <returns></returns>
    [WebMethod(EnableSession = true), ScriptMethod]
    public bool IsSessionExp()
    {
        bool flag = true;
        if (Session["InstId"] == null)
            flag = false;
        else if (Session["InstId"].ToString() == "")
            flag = false;

        return flag;
    }
    
    [WebMethod(EnableSession = true), ScriptMethod]
    public String GetServerTime()
    {
        string Hours = System.DateTime.Now.Hour.ToString();
        string Minutes = System.DateTime.Now.Minute.ToString();

        string CurrentTime = ((Int32.Parse(Hours) > 12) ? Int32.Parse(Hours) - 12 : Int32.Parse(Hours)) + ((Int32.Parse(Minutes) < 10) ? ":0" : ":") + Int32.Parse(Minutes) + ((Int32.Parse(Hours) > 12) ? " PM" : " AM");

        return CurrentTime;
    }

    #region Attendance

    [WebMethod(EnableSession = true), ScriptMethod]
    public List<Emp_Attend_Detatil> Get_Emp_Attendance(long Attend_Id)
    {
        SqlCommand com = null;
        var Emp_Atd_Dtl = new List<Emp_Attend_Detatil>();
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                SqlDataReader dr;
                cnx.Open();
                com.Connection = cnx;

                com.Parameters.AddWithValue("@flag", "S");
                com.Parameters.AddWithValue("@Id", Attend_Id);
                com.Parameters.AddWithValue("@Instid", Int32.Parse(Session["instID"].ToString()));

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[SUID_GetAllAttendance]";

               dr= com.ExecuteReader();
               while (dr.Read())
               {
                   var item = new Emp_Attend_Detatil();

                   item.Id = dr["Id"].ToString();
                   item.SrNo = dr["SrNo"].ToString();
                   item.Attend_Date = Convert.ToDateTime(dr["Attend_Date"].ToString()).ToString("dd-MMM-yyyy");
                   item.InTime = dr["InTime"].ToString();
                   item.OutTime = dr["OutTime"].ToString();
                   item.PresentStatus = dr["AttendStatus"].ToString();
                   item.Worked_Hrs = dr["Worked_Hrs"].ToString();
                   item.Remark = dr["Remark"].ToString();

                   Emp_Atd_Dtl.Add(item);

               } dr.Close(); dr.Dispose();


            }
            catch {}
            finally { com.Parameters.Clear(); }

            return Emp_Atd_Dtl;
        }
        
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public Int32 Delete_Emp_Attend(long Attend_Id)
    {
        SqlCommand com = null;
        Int32 RetFlag = 1;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
               
                cnx.Open();
                com.Connection = cnx;

                com.Parameters.AddWithValue("@flag", "D");
                com.Parameters.AddWithValue("@Id", Attend_Id);
                com.Parameters.AddWithValue("@Instid", Int32.Parse(Session["instID"].ToString()));

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[SUID_GetAllAttendance]";

                com.ExecuteNonQuery();

            }
            catch { RetFlag = 0; }
            finally { com.Parameters.Clear(); }
            
        }
        return RetFlag;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public List<Emp_Detatil> Online_Emp_Attendance(String Emp_Code)
    {
        SqlCommand cmd = null;
        String Issuccess = string.Empty;
        String Msg = string.Empty;
        var Emp_Dtl = new List<Emp_Detatil>();
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                cmd = new SqlCommand();

                cnx.Open();
                cmd.Connection = cnx;

                DateTime Attend_DateTime = DateTime.Now;

                Save_Attendance("O", Int32.Parse(Session["instID"].ToString()), Session["U_Name"].ToString(), 0, Attend_DateTime,Emp_Code, 0, ref Issuccess, cmd);

                if ((Issuccess == "1") || (Issuccess == "2"))
                    Emp_Dtl = Employee_Dtl(Emp_Code,Issuccess, Int32.Parse(Session["instID"].ToString()));
                else
                    Emp_Dtl = null;

            }
            catch { Msg = "Error!"; }
            finally { cmd.Dispose(); }
        }
        return Emp_Dtl;

    }

    private List<Emp_Detatil> Employee_Dtl(String Emp_Code,String Status, Int32 InstId)
    {
        var Emp_Dtl = new List<Emp_Detatil>();
        SqlCommand cmd = null;
        SqlDataReader Dr;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                String Query = "Select EmpCode,(EmpName+' '+LastName) as Name,DepartmentName from Employee_Master,Department Where DepartmentId=DeptId and EmpCode='" + Emp_Code + "' and Employee_Master.InstituteId='" + InstId + "' and Department.InstituteId='" + InstId + "'";
                cmd = new SqlCommand();

                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandText = Query;
                cmd.CommandType = CommandType.Text;

                Dr = cmd.ExecuteReader();

                if (Dr.Read())
                {
                    var item = new Emp_Detatil();

                    item.Emp_Id = Dr["EmpCode"].ToString();
                    item.Emp_Name = Dr["Name"].ToString();
                    item.Emp_Dept = Dr["DepartmentName"].ToString();
                    item.Status = (Status == "1" ? "In Time:" : "Out Time:") + GetServerTime();
                    Emp_Dtl.Add(item);
                }
                Dr.Close();
            }
            catch { }
            finally { cmd.Dispose(); }

            return Emp_Dtl;
        }
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public String  save_emp_Attendance(string Atten_Status, long Attend_Id, DateTime Attend_DateTime)
    {
        SqlCommand cmd = null;
        String Issuccess = string.Empty;
        String Msg = string.Empty;

       

        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {                
                cmd = new SqlCommand();

                cnx.Open();
                cmd.Connection = cnx;
                Save_Attendance(Atten_Status, Int32.Parse(Session["instID"].ToString()), Session["U_Name"].ToString(), Attend_Id, Attend_DateTime,"0", 0, ref Issuccess, cmd);

                if (Issuccess == "0")
                    Msg = "Failed!";
                else if (Issuccess == "1")
                    Msg = "In Success";
                else if (Issuccess == "2")
                    Msg = "Out Success";
                else
                    Msg = "Error!";

            }
            catch { Msg = "Error!"; }
            finally { cmd.Dispose(); }
        }
        return Msg;

    }
    
   
    private void Save_Attendance(String flag, Int32 InstID, String UserId, long Atd_Id, DateTime Attendance_DateTime, String Emp_Id, Int32 Allot_Id, ref string RetSuccess, SqlCommand com)
    {
        try
        {
            //objDB.CreateParameters(12);
            //------------------------------------------------------------
            com.Parameters.AddWithValue("@flag", flag);
            com.Parameters.AddWithValue("@RetSuccess", DbType.String).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("@fields", null);
            com.Parameters.AddWithValue("@where",null);

            com.Parameters.AddWithValue("@InstID", InstID);
            com.Parameters.AddWithValue("@SessionId", null);
            com.Parameters.AddWithValue("@UserId", UserId);
            com.Parameters.AddWithValue("@UEDate", DateTime.Now.Date.ToShortDateString());

            com.Parameters.AddWithValue("@Id", Atd_Id);
            com.Parameters.AddWithValue("@Date_Time", Attendance_DateTime);
            com.Parameters.AddWithValue("@Emp_Id", Emp_Id);
            com.Parameters.AddWithValue("@Allot_Id", Allot_Id);

            com.CommandType = CommandType.StoredProcedure;

            com.CommandText = "[SUID_ShiftAttendance]";
            com.ExecuteNonQuery();

            RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();
            //------------------------------------------------------------
            /*
            objDB.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
            objDB.AddParameters(1, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
            objDB.AddParameters(2, "fields", null, DbType.String, ParameterDirection.Input);
            objDB.AddParameters(3, "where", null, DbType.String, ParameterDirection.Input);
            objDB.AddParameters(4, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
            objDB.AddParameters(5, "SessionId", null, DbType.String, ParameterDirection.Input);
            objDB.AddParameters(6, "UserId", UserId, DbType.String, ParameterDirection.Input);
            objDB.AddParameters(7, "UEDate", DateTime.Now.Date.ToShortDateString(), DbType.DateTime, ParameterDirection.Input);

            objDB.AddParameters(8, "Id", Atd_Id, DbType.Int64, ParameterDirection.Input);
            objDB.AddParameters(9, "Date_Time", Attendance_DateTime, DbType.DateTime, ParameterDirection.Input);
            objDB.AddParameters(10, "Emp_Id", Emp_Id, DbType.Int32, ParameterDirection.Input);
            objDB.AddParameters(11, "Allot_Id", Allot_Id, DbType.Int32, ParameterDirection.Input);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "[SUID_ShiftAttendance]");

            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
            */
        }
        catch { RetSuccess = "0"; }
        finally { com.Parameters.Clear(); }
    }
    #endregion

    #region Schedule Non-Schedulled Attendance

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Schedule_Non_Schld_Atd(Int32 Atd_Id, Int32 Shift_Id)
    {
        SqlCommand com = null;
        String RetSuccess = string.Empty;
        String Msg = string.Empty;

        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();

                cnx.Open();
                com.Connection = cnx;


                com.Parameters.AddWithValue("@RetSuccess", DbType.String).Direction = ParameterDirection.Output;

                com.Parameters.AddWithValue("@SessionId", Session["sesnID"].ToString());
                com.Parameters.AddWithValue("@UserId", Session["U_Name"].ToString());
                com.Parameters.AddWithValue("@UEDate", DateTime.Now.Date.ToShortDateString());

                com.Parameters.AddWithValue("@Attend_Id", Atd_Id);
                com.Parameters.AddWithValue("@Shift_Id", Shift_Id);
                com.Parameters.AddWithValue("@Instid", Int32.Parse(Session["instID"].ToString()));

                com.CommandType = CommandType.StoredProcedure;

                com.CommandText = "[SUID_NonSchedulledAttend]";
                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();

                if (RetSuccess == "0")
                    RetSuccess = "Error!";
                else if (RetSuccess == "1")
                    RetSuccess = "Success";
                else if (RetSuccess == "2")
                    RetSuccess = "Invalid Shift";
                else
                    RetSuccess = "Error!";

            }
            catch { RetSuccess = "Error!"; }
            finally { com.Parameters.Clear(); }

        }
        return RetSuccess;
    }
    #endregion

    #region Back Attendance

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Back_Attendance(long Attend_Id,String AttendStatus,String Time,String Remark)
    {
        SqlCommand com = null;
        String RetSuccess = string.Empty;
        String Msg = string.Empty;

        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();

                cnx.Open();
                com.Connection = cnx;


                com.Parameters.AddWithValue("@RetSuccess", DbType.String).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("@Instid", Int32.Parse(Session["instID"].ToString()));

                com.Parameters.AddWithValue("@Id", Attend_Id);
                com.Parameters.AddWithValue("@flag", AttendStatus);
                com.Parameters.AddWithValue("@Time", Time);

                com.Parameters.AddWithValue("@Remark", Remark);
               

                com.CommandType = CommandType.StoredProcedure;

                com.CommandText = "[SUID_ShiftBackAttend]";
                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();

                if (RetSuccess == "0")
                    RetSuccess = "Error!";
                else if (RetSuccess == "1")
                    RetSuccess = "Success";
                else if (RetSuccess == "2")
                    RetSuccess = "Out Time must be greater than In Time";                
                else
                    RetSuccess = "Error!";

            }
            catch { RetSuccess = "Error!"; }
            finally { com.Parameters.Clear(); }

        }
        return RetSuccess;
    }
    #endregion

    #region AutoSuggestMenu
    [WebMethod, ScriptMethod]//For Static Query
    public string GetSuggestions(string keyword, bool usePaging, int pageIndex, int pageSize, bool useFlexibleQuery, string TableName, string TableTextField, string TableValueField, string TableCondition)
    {
        List<AutoSuggestMenuItem> menuItems;

        //string filePath = HttpContext.Current.Server.MapPath("App_Data/AutoSuggestMenuDemo.mdb");
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection cn = new SqlConnection(connString);

        //May need to repeat the following 3 times
        //Instead just save it to variable
        string sqlFromAndWhere = " From menustructure,menupermission where (menustructure.parentid is not null and menustructure.href is not null and menupermission.menuid=menustructure.id and menupermission.permission=1 and menupermission.roleid='6') and title LIKE '" + keyword.Replace("'", "''").Trim() + "%'";
        string sql;
        if (usePaging)
        {
            //Select only menu items up to specified page
            //In Sql Server use ROW_NUMBER to only get the values for current page
            int numItems = (pageIndex + 1) * pageSize;
            sql = "SELECT TOP " + numItems + " title,href " +
                        sqlFromAndWhere +
                        " ORDER BY title";
        }
        else
        {
            sql = " SELECT title,href " + sqlFromAndWhere + " ORDER BY title";
        }


        SqlCommand cmd = new SqlCommand(sql, cn);
        cn.Open();

        //I use datareader because it is usually much faster then dataSet
        //But cached DataSet may also work
        SqlDataReader reader = cmd.ExecuteReader();

        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);

        reader.Close();


        //When using paging need to get totalResults
        int totalResults = -1;
        if (usePaging && (pageIndex == 0))
        {
            //Only do it when page index is 0
            sql = "SELECT COUNT(*)" +
                        sqlFromAndWhere;

            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
        }


        cn.Close();
        return AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults);
    }
    [WebMethod(EnableSession = true), ScriptMethod]//For Flexible and Dynamic Query
    public string GetDBFlexSuggestions_INV(string keyword, bool usePaging, int pageIndex, int pageSize, bool useFlexibleQuery, string TableName, string TableTextField, string TableValueField, string TableCondition)
    {
        string distinctvar = string.Empty;

        List<AutoSuggestMenuItem> menuItems;

        SqlConnection cn = new SqlConnection(ReturnConString());
        string sqlFromAndWhere = string.Empty;
        //May need to repeat the following 3 times
        //Instead just save it to variable
        if (TableCondition != string.Empty)
        {
            sqlFromAndWhere = " From " + TableName + " where " + TableTextField + " LIKE '" + keyword.Replace("'", "''").Trim() + "%' and InstId='" + Session["InstId"].ToString() + "' and " + TableCondition;
        }
        else
        {
            sqlFromAndWhere = " From " + TableName + " where " + TableTextField + " LIKE '" + keyword.Replace("'", "''").Trim() + "%' and InstId='" + Session["InstId"].ToString() + "'";
        }
        string sql;
        if (usePaging)
        {
            //Select only menu items up to specified page
            //In Sql Server use ROW_NUMBER to only get the values for current page
            int numItems = (pageIndex + 1) * pageSize;
            sql = "SELECT distinct TOP " + numItems + " " + TableTextField + ", " + TableValueField +
                        sqlFromAndWhere +
                        " ORDER BY " + TableTextField;
        }
        else
        {
            sql = " SELECT distinct " + TableTextField + ", " + TableValueField + " " + sqlFromAndWhere + " ORDER BY " + TableTextField;
        }


        SqlCommand cmd = new SqlCommand(sql, cn);
        cn.Open();

        //I use datareader because it is usually much faster then dataSet
        //But cached DataSet may also work
        SqlDataReader reader = cmd.ExecuteReader();

        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);

        reader.Close();


        //When using paging need to get totalResults
        int totalResults = -1;
        if (usePaging && (pageIndex == 0))
        {
            //Only do it when page index is 0
            sql = "SELECT COUNT(*)" +
                        sqlFromAndWhere;

            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
        }


        cn.Close();
        return AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults);
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
    #endregion

    [Serializable]
    [DataContract]
    public class Favorite
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string FavUrl { get; set; }
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public List<Favorite> Favorite_Images()
    {
        var listOfAddressItems = new List<Favorite>();
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand();

                cnx.Open();
                com.Connection = cnx;
                com.CommandText = "Select MenuFavorite.Id,(Href+'?p='+cast(InsertOp as nvarchar)+'|'+cast(UpdateOP as nvarchar)+'|'+cast(DeleteOP as nvarchar)+'&title='+Title+'&cas_id='+cast(Cas_id as nvarchar)+'&fid='+cast(MenuFavorite.MenuID as nvarchar)) as FavURL "+
                                    " from MenuFavorite,MenuStructure,MenuPermission "+
                                    " Where MenuStructure.ID=MenuFavorite.MenuID and "+
	                                " MenuPermission.Menuid=MenuStructure.ID and "+
	                                " MenuPermission.Permission='1' and "+
                                    " MenuFavorite.RoleID='" + Session["roleid"].ToString() + "'";
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    var item = new Favorite();

                    item.Id = dr["Id"].ToString();
                    item.FavUrl = dr["FavURL"].ToString();

                    listOfAddressItems.Add(item);
                }

            }
            catch { }
            finally { com.Dispose(); cnx.Close(); cnx.Dispose(); }
        }
        return listOfAddressItems;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Check_Quantity(Int32 Prod_Id,String Qntity)
    {      
        String Result = string.Empty;
        try
        {
            int MaxQty = 0, MinQty = 0;
            if (Qntity == string.Empty)
            {
                Qntity = "0";
            }
            int Qty = Int32.Parse(Qntity);
            SqlCommand com = null, SelectCom = null; ;
                com = new SqlCommand();
                SqlConnection cn = new SqlConnection(ReturnConString());
                cn.Open();
                com.Connection = cn;
                com.CommandText = "Select Min_Qty,Max_Qty,Target_Qty From Prod_Manager Where Prod_Manager.ID=" + Prod_Id + " and Prod_Manager.InstId=" + Session["InstId"].ToString();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MaxQty = Int32.Parse(dr["Max_Qty"].ToString());
                    MinQty = Int32.Parse(dr["Min_Qty"].ToString());

                    dr.Close();
                }
                SelectCom = new SqlCommand();
                SelectCom.Connection = cn;
                SelectCom.CommandText = "Select Sum(Quantity) from POChild where Product_Id=" + Prod_Id + " and InstId=" + Session["InstId"].ToString();
                int POQty = Int32.Parse(SelectCom.ExecuteScalar().ToString() == string.Empty ? "0" : SelectCom.ExecuteScalar().ToString());
                if (POQty >= MinQty)
                {
                    MinQty = 1;
                }
            if (Qty < MinQty )
                {
                    Result = "Min";
                }
                else if(Qty > (MaxQty-POQty))
                {
                    Result = "Max";
                }
                else
                    Result = string.Empty;

                cn.Close();
                cn.Dispose();
           
        }
        catch
        {
        }
        finally
        {
          
        }
        return Result;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Check_Amt(String POAmt)
    {
        String Result = string.Empty;
        try
        {
            Decimal Amt = Decimal.Parse(POAmt == string.Empty ? "0" : POAmt);
            Decimal Blnc_Amt = 0;          
            SqlCommand com = null;
            com = new SqlCommand();
            SqlConnection cn = new SqlConnection(ReturnConString());
            cn.Open();
            com.Connection = cn;
            com.CommandText = "Select Balance_Amt,Expenditure_Amt,Exp_Pending_Amt From Bgt_Balance_Exp Where InstId=" + Session["InstId"].ToString();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Blnc_Amt = Decimal.Parse(dr["Balance_Amt"].ToString()) - Decimal.Parse(dr["Exp_Pending_Amt"].ToString());
               
                dr.Close();
            }
            if (Amt > Blnc_Amt)
            {
                Result = "PO amount can not exceed the balance of Inst i.e.:" + Blnc_Amt;
            }           
            else
                Result = string.Empty;

            cn.Close();
            cn.Dispose();

        }
        catch
        {
        }
        finally
        {

        }
        return Result;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Chk_IndentQty(Int32 IndentId, String Qntity)
    {
        String Result = string.Empty;
        try
        {
            Decimal StockBlnc = 0, IssueReq_Qty = 0;
            if (Qntity == string.Empty)
            {
                Qntity = "0";
            }
            Decimal Qty = Decimal.Parse(Qntity);
            SqlCommand com = null, SelectCom = null; ;
            com = new SqlCommand();
            SqlConnection cn = new SqlConnection(ReturnConString());
            cn.Open();
            com.Connection = cn;
            com.Parameters.AddWithValue("IndentId", IndentId);
            com.Parameters.AddWithValue("InstID", Int32.Parse(Session["instId"].ToString()));
            com.CommandText = "Select sum(Stock_Bal) as Stock_Bal From Prod_Manager,Indent Where Prod_Manager.Ctrl_Id=Indent.Ctrl_Id and Prod_Manager.InstId=Indent.InstId  and Indent.ID=@IndentId and Prod_Manager.InstId=@InstID";
           
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                StockBlnc = Decimal.Parse(dr["Stock_Bal"].ToString());
                //IssueReq_Qty = Decimal.Parse(dr["Issue_Req_Qty"].ToString());

                dr.Close();
            }
            Decimal IndentQty = StockBlnc;// -IssueReq_Qty;
            if (Qty > IndentQty)
            {
                Result =  IndentQty.ToString();
            }
            else
                Result = string.Empty;

            cn.Close();
            cn.Dispose();

        }
        catch
        {
        }
        finally
        {

        }
        return Result;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Chk_DlvryDate(Int32 RFQId,String Vndr_DlvrDate)
    {
        String Result = string.Empty;
        try
        {
            DateTime Client_Date=DateTime.Now, Vndr_Date;
            if (Vndr_DlvrDate == string.Empty)
            {
                Result = "Enter Delivery Date";
               
            }
            else
            {
                Vndr_Date = DateTime.Parse(Vndr_DlvrDate);
            
                SqlCommand com = null ;
                com = new SqlCommand();
                SqlConnection cn = new SqlConnection(ReturnConString());
                cn.Open();
                com.Connection = cn;
                com.Parameters.AddWithValue("RFQId", RFQId);
                com.Parameters.AddWithValue("InstID", Int32.Parse(Session["instId"].ToString()));
                com.CommandText = "Select Delivery_Date From RFQ_Mst,College Where RFQ_Mst.ID=@RFQId and RFQ_Mst.InstId=College.CollegeId  and RFQ_Mst.InstId=@InstID";
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    Client_Date = DateTime.Parse(dr["Delivery_Date"].ToString());
                   
                    dr.Close();
                }

                if (Vndr_Date > Client_Date)
                {
                    Result = "Delivery date should be less than the delivery date assigned by client i.e.:" + Client_Date.ToString("dd-MMM-yyyy");
                }
                else
                    Result = string.Empty;

                cn.Close();
                cn.Dispose();
            }          
        }
        catch
        {
        }
        finally
        {

        }
        return Result;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public String Gen_ProdCode(String flag, String Prod_Type, String Prod_Cat, String Prod_Comp)
    {
        String Prod_Code = string.Empty;
        try
        {
            String MaxId = "0";
            SqlCommand com = null;
            com = new SqlCommand();
            SqlConnection cn = new SqlConnection(ReturnConString());
            cn.Open();
            com.Connection = cn;
            if (Prod_Type == string.Empty)
            {
                Prod_Type = "0";
            }
            if (Prod_Cat == string.Empty)
            {
                Prod_Cat = "0";
            }
            //if (Prod_Comp == string.Empty)
            //{
            //    Prod_Comp = "0";
            //}
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", Int32.Parse(Session["instId"].ToString()));
            com.Parameters.AddWithValue("Prod_Type", Prod_Type);
            com.Parameters.AddWithValue("Prod_Cat", Prod_Cat);
            com.Parameters.AddWithValue("Prod_Comp", Prod_Comp);

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_ProdCode";
            MaxId = com.ExecuteScalar().ToString();
            Prod_Code = Prod_Type + Prod_Cat + Prod_Comp + MaxId;

            com.Parameters.Clear();
            com.Dispose();

            return Prod_Code;

            cn.Close();
            cn.Dispose();

        }
        catch
        {
        }
        finally
        {

        }
        return Prod_Code;
    }
    //--------------------------Getting Exchange Rate From Currency Master------------------------
    //-------------------Created BY: Mohd Danish Ansari ON 3-FEB-2011-----------------------------
    [WebMethod(EnableSession = true), ScriptMethod]
    public String Ex_Rate(Int32 CurrencyID)
    {
        string ExRate_ = string.Empty;
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            try
            {
                con.Open();
                com = new SqlCommand();
                com.Connection = con;
                com.Parameters.AddWithValue("currencyID", CurrencyID);
                com.Parameters.AddWithValue("InstID", Int32.Parse(Session["instId"].ToString()));
                com.Parameters.AddWithValue("exRate", ExRate_).Direction = ParameterDirection.Output;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Get_Exc_Rate";
                ExRate_ = com.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();
                con.Close(); 
                con.Dispose();
            }
        }
        return ExRate_;
    }
    //------------------------Getting Pending PO Details-----------------------//
    //------------Created By: Mohd Danish Ansari As on 27-May-2011-------------//
    [WebMethod(EnableSession = true), ScriptMethod]
    public List<DataMember.PendingPO>GetPendingPO()
    {
        Inventory ObjINV = new Inventory();
        var ListItems = new List<DataMember.PendingPO>();
        ObjINV.Get_PendingPO(Int32.Parse(Session["uid"].ToString()), Int32.Parse(Session["instId"].ToString()), ref ListItems);        
        return ListItems;
    }
    //-------------------------------------------------------------------------//
    [WebMethod(EnableSession = true), ScriptMethod]
    public List<LeaveDM> Get_LeaveDetail()
    {
        SqlCommand com = null;
        var LeaveList = new List<LeaveDM>();
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                SqlDataReader dr;
                cnx.Open();
                com.Connection = cnx;

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[FillLeaveDetail]";

                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var item = new LeaveDM();
                    item.LeaveID = Convert.ToInt32(dr["leaveid"].ToString());
                    item.Leavesname = dr["shname"].ToString();
                    LeaveList.Add(item);

                } dr.Close(); dr.Dispose();


            }
            catch { }
            finally { com.Parameters.Clear(); }

            return LeaveList;
        }

    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public List<FillEmployee> Get_Employee(int InstituteID, int DeptID, int DesgID, string date, int month, int year, string flag)
    {
        SqlCommand com = null;
        var EmpList = new List<FillEmployee>();
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                SqlDataReader dr;
                cnx.Open();
                com.Connection = cnx;
                com.Parameters.AddWithValue("@InstituteID", InstituteID);
                com.Parameters.AddWithValue("@deptId", DeptID);
                com.Parameters.AddWithValue("@desigId", DesgID);
                com.Parameters.AddWithValue("@date", date);
                com.Parameters.AddWithValue("@month", month);
                com.Parameters.AddWithValue("@year", year);
                com.Parameters.AddWithValue("@flag", flag);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[FillEmployee]";

                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var item = new FillEmployee();
                    item.EmpID = Convert.ToInt32(dr["EmpID"].ToString());
                    item.Empname = dr["empName"].ToString();
                    item.JoinDate = Convert.ToDateTime(dr["joinDate"].ToString());
                    item.resDate = dr["resDate"].ToString();
                    //resDate
                    #region MyRegion
                    //item.a1 = dr["a1"].ToString();
                    //item.a2 = dr["a2"].ToString();
                    //item.a3 = dr["a3"].ToString();
                    //item.a4 = dr["a4"].ToString();
                    //item.a5 = dr["a5"].ToString();
                    //item.a6 = dr["a6"].ToString();
                    //item.a7 = dr["a7"].ToString();
                    //item.a8 = dr["a8"].ToString();
                    //item.a9 = dr["a9"].ToString();
                    //item.a10 = dr["a10"].ToString();
                    //item.a11= dr["a11"].ToString();
                    //item.a12= dr["a12"].ToString();
                    //item.a13 = dr["a13"].ToString();
                    //item.a14 = dr["a14"].ToString();
                    //item.a15 = dr["a15"].ToString();
                    //item.a16 = dr["a16"].ToString();
                    //item.a17 = dr["a17"].ToString();
                    //item.a18 = dr["a18"].ToString();
                    //item.a19 = dr["a19"].ToString();
                    //item.a20 = dr["a20"].ToString();
                    //item.a21 = dr["a21"].ToString();
                    //item.a22 = dr["a22"].ToString();
                    //item.a23 = dr["a23"].ToString();
                    //item.a24 = dr["a24"].ToString();
                    //item.a25 = dr["a25"].ToString();
                    //item.a26 = dr["a26"].ToString();
                    //item.a27 = dr["a27"].ToString();
                    //item.a28 = dr["a28"].ToString();
                    //item.a29 = dr["a29"].ToString();
                    //item.a30 = dr["a30"].ToString();
                    //item.a31 = dr["a31"].ToString(); 
                    #endregion
                    EmpList.Add(item);

                }
                dr.Close();
                dr.Dispose();
            }
            catch { }
            finally { com.Parameters.Clear(); }

            return EmpList;
        }

    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public DataTable Get_EmployeeDt(int InstituteID, int DeptID, int DesgID)
    {
        SqlCommand com = null;

        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            DataTable dt = new DataTable();
            try
            {
                com = new SqlCommand();
                SqlDataReader dr;
                cnx.Open();
                com.Connection = cnx;

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[FillEmployee]";

                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dt.Load(dr);

                    } dr.Close(); dr.Dispose();
                }

            }
            catch { }
            finally { com.Parameters.Clear(); }

            return dt;
        }
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public string InsertEmp_Attend_Detatil(List<Emp_Attend_DetatilDM> objPSF)
    {
        HRM.Attendance.EmpAttendance objEmpAtd = new HRM.Attendance.EmpAttendance();
        return objEmpAtd.InsertEmp_Attend_Detatil(objPSF);
    }
}

