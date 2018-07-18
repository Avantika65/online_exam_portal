using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using NewDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class AdmininstratorSet
{
    DBManager objDB;
    [OperationContract]
    public List<Admin.AdministratorData.AppsettingDM > searchCustomers(string searchText)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        //objDB.CreateParameters(1);
        //objDB.AddParameters(0, "ID", Int32.Parse(searchText), DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from College where collegeid='" + searchText + "'");
        var listOfCustomerItems = new List<Admin.AdministratorData.AppsettingDM>();
        try
        {

            if (dr.Read())
            {
                var item = new Admin.AdministratorData.AppsettingDM();
                item.CollegeID = int.Parse(Education.DataHelper.GetString(dr, "CollegeID"));
                item.CollegeName = Education.DataHelper.GetString(dr, "CollegeName");
                item.ShortName = dr[2].ToString();
                item.Location = dr[3].ToString();
                item.Phone1 = dr[4].ToString();
                item.Phone2 = dr[5].ToString();
                item.Phone3 = dr[6].ToString();
                item.Fax = dr[7].ToString();
                item.Mobile = dr[8].ToString();
                item.EmailID1 = dr[9].ToString();
                item.Email2 = dr[10].ToString();
                item.Website = dr[11].ToString();
                item.Description = dr[12].ToString();
                if (dr[14] != System.DBNull.Value)
                {
                    item.InstLogo = (byte[])dr[14];
                }
                else
                {
                    item.InstLogo = null;
                }
                item.Acd_Session = dr[14].ToString();
                item.PrincipalName = dr[15].ToString();
                item.ProxyAddress = dr[16].ToString();
                item.ProxyUser = dr[17].ToString();
                item.ProxyPwd = dr[18].ToString();
                item.Salt = dr[19].ToString();
                item.IsMailActive = dr[20].ToString();
                item.IsLog = dr[21].ToString();

                listOfCustomerItems.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfCustomerItems;
    }

    [OperationContract]
    public List<Admin.AdministratorData.EgroupDM> SearchGroup(string ID)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        //objDB.CreateParameters(1);
        //objDB.AddParameters(0, "ID", Int32.Parse(searchText), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Egroup where EgroupID='" + ID + "'");
        var listOfCustomerItems = new List<Admin.AdministratorData.EgroupDM>();
        try
        {

            if (dr.Read())
            {
                var item = new Admin.AdministratorData.EgroupDM();
                item.EgroupID = int.Parse(dr[0].ToString());
                item.Egroupname = dr[1].ToString();
                listOfCustomerItems.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfCustomerItems;
    }

    [OperationContract]
    public List<Admin.AdministratorData.InstituteDM> SearchInstitute(string ID)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Institute where id_inst='" + ID + "'");
        var listOfCustomerItems = new List<Admin.AdministratorData.InstituteDM>();
        try
        {
            if (dr.Read())
            {
                var item = new Admin.AdministratorData.InstituteDM();
                item.id_inst = int.Parse(dr[0].ToString());
                item.INSTITUTE_NAME = dr[1].ToString();
                item.SHORT_NAME = dr[2].ToString();
                item.EgroupID = int.Parse(dr[3].ToString());
                listOfCustomerItems.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfCustomerItems;
    }

    [OperationContract]
    public string InsertGroup(Admin.AdministratorData.EgroupDM tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            string query="";
            if (tsv.flag == "N")
            {
                query = "insert into Egroup (EgroupName) values('" + tsv.Egroupname + "')";
            }
            else
            {
                query = "update Egroup set EgroupName='" + tsv.Egroupname + "' where egroupid='"+ tsv.EgroupID +"'";
            }
            objDB.ExecuteNonQuery(CommandType.Text, query);
            objDB.Transaction.Commit();
            if (tsv.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (tsv.flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv ="Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertCollege(Admin.AdministratorData.CollegeDM tsv,Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(24);
             objDB.AddParameters(0, "CollegeID", tsv.CollegeID, DbType.Int32);
            objDB.AddParameters(1, "CollegeName", tsv.CollegeName, DbType.String);
            objDB.AddParameters(2, "ShortName", tsv.ShortName, DbType.String);
            objDB.AddParameters(3, "Location", tsv.Location, DbType.String);
            objDB.AddParameters(4, "Phone1", tsv.Phone1, DbType.String);
            objDB.AddParameters(5, "Phone2", tsv.Phone2, DbType.String);
            objDB.AddParameters(6, "Phone3", tsv.Phone3, DbType.String);
            objDB.AddParameters(7, "Fax", tsv.Fax, DbType.String);
            objDB.AddParameters(8, "Mobile", tsv.Mobile, DbType.String);
            objDB.AddParameters(9, "EmailID1", tsv.EmailID1, DbType.String);
            objDB.AddParameters(10, "EmailID2", tsv.EmailID2, DbType.String);
            objDB.AddParameters(11, "WebSite", tsv.WebSite, DbType.String);
            objDB.AddParameters(12, "Description", tsv.Description, DbType.String);
            objDB.AddParameters(13, "InstLogo",  tsv.InstLogo , DbType.Binary);
            objDB.AddParameters(14, "IsMailActive", tsv.IsMailActive, DbType.String);
            objDB.AddParameters(15, "PrincipalName", tsv.PrincipalName, DbType.String);
            objDB.AddParameters(16, "Flag", tsv.flag, DbType.String);
            objDB.AddParameters(17, "Auto_PPSNO", tsv.Auto_PPSNO, DbType.String);
            objDB.AddParameters(18, "Auto_RECNO", tsv.Auto_RECNO, DbType.String);
            objDB.AddParameters(19, "InstituteType", tsv.Inst_Type, DbType.Int32);
            objDB.AddParameters(20, "InstituteNature", tsv.Inst_Nature, DbType.Int32);
            objDB.AddParameters(21, "AffiliationNo", tsv.Affiliation_No, DbType.String);
            objDB.AddParameters(22, "LandMark", tsv.LandMark, DbType.String);
            objDB.AddParameters(23, "CityOffice", tsv.CityOffice, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "CollegeSP");
            objDB.Command.Parameters.Clear();
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
     
            if (tsv.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (tsv.flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertInstitute( Admin.AdministratorData.InstituteDM  tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(5);
            objDB.AddParameters(0, "id_inst", tsv.id_inst, DbType.Int32);
            objDB.AddParameters(1, "EgroupID", tsv.EgroupID, DbType.String);
            objDB.AddParameters(2, "INSTITUTE_NAME", tsv.INSTITUTE_NAME, DbType.String);
            objDB.AddParameters(3, "SHORT_NAME", tsv.SHORT_NAME, DbType.String);
            objDB.AddParameters(4, "Flag", tsv.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_Institute");
            objDB.Transaction.Commit();
          
            if (f == "N")
            {
                retv = "0";
            }
            else if (f == "U")
            {
                retv = "0";
            }
            else
            {
                retv = "0";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "-1";
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertProxy(Admin.AdministratorData.CollegeDM tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(6);
            objDB.AddParameters(0, "CollegeID", tsv.CollegeID, DbType.Int32);
            objDB.AddParameters(1, "ProxyAddress", tsv.ProxyAddress, DbType.String);
            objDB.AddParameters(2, "ProxyUser", tsv.ProxyAddress, DbType.String);
            objDB.AddParameters(3, "ProxyPwd", tsv.ProxyPwd, DbType.String);
            objDB.AddParameters(4, "Salt", tsv.Salt, DbType.String);
            objDB.AddParameters(5, "Flag", tsv.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SUID_College");
            objDB.Transaction.Commit();
            if (tsv.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (tsv.flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertSession(Admin.AdministratorData.SessionDM tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(6);
            objDB.AddParameters(0, "sessionid", tsv.SessionID, DbType.Int32);
            objDB.AddParameters(1, "session", tsv.Session, DbType.String);
            objDB.AddParameters(2, "startdate", tsv.StartDate, DbType.String);
            objDB.AddParameters(3, "enddate", tsv.EndDate, DbType.String);
            objDB.AddParameters(4, "Active", tsv.Active, DbType.String);
            objDB.AddParameters(5, "Flag", tsv.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Session_Insert");
            objDB.Transaction.Commit();
            if (tsv.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (tsv.Flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public List<Admin.AdministratorData.SessionDM> SearchSession(string ID)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Session where sessionid='" + ID + "'");
        var listOfCustomerItems = new List<Admin.AdministratorData.SessionDM>();
        try
        {
            if (dr.Read())
            {
                var item = new Admin.AdministratorData.SessionDM();
                item.SessionID = int.Parse(dr[0].ToString());
                item.StartDate = Convert.ToDateTime(dr[1].ToString());
                item.EndDate = Convert.ToDateTime(dr[2].ToString());
                item.Active = dr[3].ToString();
                listOfCustomerItems.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfCustomerItems;
    }

    [OperationContract]
    public List<Admin.AdministratorData.YearSemDM> SearchYearSem(string ID)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Session where sessionid='" + ID + "'");
        var listOfCustomerItems = new List<Admin.AdministratorData.YearSemDM>();
        try
        {
            if (dr.Read())
            {
                var item = new Admin.AdministratorData.YearSemDM();
                //item.SessionID = int.Parse(dr[0].ToString());
                //item.StartDate = Convert.ToDateTime(dr[1].ToString());
                //item.EndDate = Convert.ToDateTime(dr[2].ToString());
                //item.Active = dr[3].ToString();
                //listOfCustomerItems.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfCustomerItems;
    }

    [OperationContract]
    public string InsertYearSem(List<Admin.AdministratorData.YearSemDM> tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (Admin.AdministratorData.YearSemDM ry in tsv)
            {
                objDB.CreateParameters(16);
                objDB.AddParameters(0, "CID", ry.CID, DbType.Int32);
                objDB.AddParameters(1, "CourseID", ry.CourseID, DbType.Int32);
                objDB.AddParameters(2, "CourseYear", ry.CourseYear , DbType.String);
                objDB.AddParameters(3, "SpecialisationID", ry.SpecialisationID, DbType.Int32);
                objDB.AddParameters(4, "Description", ry.Description, DbType.String);
                objDB.AddParameters(5, "inst_ID", ry.inst_ID, DbType.Int32);
                objDB.AddParameters(6, "SessionID", ry.SessionID, DbType.String);
                objDB.AddParameters(7, "startdate", ry.StartDate, DbType.DateTime);
                objDB.AddParameters(8, "enddate", ry.endDate, DbType.DateTime);
                objDB.AddParameters(9, "SessionName", ry.SessionName, DbType.String);
                objDB.AddParameters(10, "SessionYear", ry.sessionyear, DbType.String);
                objDB.AddParameters(11, "SemYear", ry.SemYear, DbType.Int32);
                objDB.AddParameters(12, "Active", ry.Active, DbType.String);
                objDB.AddParameters(13, "Batch", ry.Batch, DbType.String);
                objDB.AddParameters(14, "Flag", ry.flag, DbType.String);//@Year
                objDB.AddParameters(15, "Year", ry.Year, DbType.String);
                f = ry.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Semester_M_sp"); 
            }
            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string DeleteYearSem(string del)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.ExecuteNonQuery(CommandType.Text , "delete from Yearwisecourse where cid in("+ del +")");
            objDB.ExecuteNonQuery(CommandType.Text, "delete from sessiondates where semyear in(" + del + ")");
            objDB.Transaction.Commit();
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertLoginDetail( Admin.AdministratorData.LoginDM  tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
            objDB.AddParameters(1, "Login_Date", tsv.Login_Date, DbType.String);
            objDB.AddParameters(2, "Login_Time", tsv.Login_Time, DbType.String);
            objDB.AddParameters(3, "InstituteID", tsv.InstituteID, DbType.String);
            objDB.AddParameters(4, "SessionID", tsv.SessionID, DbType.String);
            objDB.AddParameters(5, "Logout_Time", tsv.Logout_Time, DbType.String);
            objDB.AddParameters(6, "Logout_Date", tsv.Logout_Date, DbType.String);
            objDB.AddParameters(7, "Is_Login", tsv.Is_Login, DbType.String);
            objDB.AddParameters(8, "Flag", tsv.Flag, DbType.String);
            objDB.AddParameters(9, "User_ID", tsv.User_ID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "LoginedUser_Insert");

            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {
            objDB.Command.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertCreateUser(Admin.AdministratorData.CreateUserDM tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(12);
            objDB.AddParameters(0, "UserID", tsv.UserID, DbType.Int32);
            objDB.AddParameters(1, "UserName", tsv.UserName, DbType.String);
            objDB.AddParameters(2, "Password", tsv.Password, DbType.String);
            objDB.AddParameters(3, "Salt", tsv.Salt, DbType.String);
            objDB.AddParameters(4, "InstituteID", tsv.InstituteID, DbType.Int32);
            objDB.AddParameters(5, "Active", tsv.Active, DbType.String);
            objDB.AddParameters(6, "UName", tsv.UName, DbType.String);
            objDB.AddParameters(7, "UEntDt", tsv.UEntDt, DbType.String);
            objDB.AddParameters(8, "Emp_id", tsv.Emp_id, DbType.Int32);
            objDB.AddParameters(9, "User_Type", tsv.User_Type, DbType.String);
            objDB.AddParameters(10, "Flag", tsv.Flag, DbType.String);
            objDB.AddParameters(11, "EmailID", tsv.EmailID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "UserCreation_Insert");
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (tsv.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (tsv.Flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }


    [OperationContract]
    public string InsertFormPermission(Admin.AdministratorData.FormPermissionDM tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "flag", tsv.Flag, DbType.String);
            objDB.AddParameters(1, "RetSuccess", tsv.RetSuccess, DbType.String);
            objDB.AddParameters(2, "fields", tsv.fields, DbType.String);
            objDB.AddParameters(3, "where", tsv.where, DbType.String);
            objDB.AddParameters(4, "InstId", tsv.InstId, DbType.Int32);
            objDB.AddParameters(5, "FieldId", tsv.FieldId, DbType.Int32);
            objDB.AddParameters(6, "FieldName", tsv.FieldName, DbType.String);
            objDB.AddParameters(7, "ValueField", tsv.ValueField, DbType.String);
            objDB.AddParameters(8, "TableName", tsv.TableName, DbType.String);
            objDB.AddParameters(9, "MenuId", tsv.MenuId, DbType.Int32);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "menuFieldStruct_Insert");
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");

            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertIDTemplate(Admin.AdministratorData.IDCardTemplateDM tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(6);
            objDB.AddParameters(0, "TemplateID", tsv.TemplateID, DbType.String);
            objDB.AddParameters(1, "CourseID", tsv.CourseID, DbType.String);
            objDB.AddParameters(2, "HeaderImage", tsv.HeaderImage, DbType.Binary);
            objDB.AddParameters(3, "Aus", tsv.Aus, DbType.Binary);
            objDB.AddParameters(4, "Desgin_String", tsv.Desgin_String, DbType.String);
            objDB.AddParameters(5, "Flag", tsv.Flag, DbType.String);


            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "IDCardTemplate_Insert");
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");

            objDB.Transaction.Commit();
            if (tsv.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (tsv.Flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    //3o-11-2011
    [OperationContract]
    public string InsertFloorMaster(Admin.AdministratorData.FloorMasterDM objFDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(5);
            objDB.AddParameters(0, "ifloorId", objFDM.ifloorId, DbType.Int32);
            objDB.AddParameters(1, "ifloorName", objFDM.ifloorName, DbType.String);
            objDB.AddParameters(2, "ifloorSName", objFDM.ifloorSName, DbType.String);
            objDB.AddParameters(3, "instituteId", objFDM.instituteId, DbType.Int32);
            objDB.AddParameters(4, "flag", objFDM.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FloorMasterInsert");
            objDB.Transaction.Commit();
            if (objFDM.flag == "I")
            {
                retv = "Record Saved.";
            }
            else if (objFDM.flag == "U")
            {
                retv = "Record Updated.";
            }
            else if (objFDM.flag == "D")
            {
                retv = "Record Deleted.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "-1";
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }


    public DataTable FillGrdFloor(int instituteId, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FloorSelect");
        return dt;
    }


    [OperationContract]
    public List<Admin.AdministratorData.FloorMasterUpdateDM> FillFloorDetails(int floorid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "floorid", floorid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FloorSelect");
        List<Admin.AdministratorData.FloorMasterUpdateDM> retItem = new List<Admin.AdministratorData.FloorMasterUpdateDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.FloorMasterUpdateDM();
            item.ifloorName = Education.DataHelper.GetString(dr, "ifloorName");
            item.ifloorSName = Education.DataHelper.GetString(dr, "ifloorSName");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }

    public DataTable FillGrdBlock(int instituteId, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BlockSelect");
        return dt;
    }


    //[OperationContract]
    //public List<Admin.AdministratorData.BlockMasterDM> FillGrdBlock(int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(1);
    //    //objDB.AddParameters(0, "blockid", blockid, DbType.Int32);
    //    objDB.AddParameters(0, "flag", flag, DbType.Int32);
    //    IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "BlockSelect");
    //    List<Admin.AdministratorData.BlockMasterDM> retItem = new List<Admin.AdministratorData.BlockMasterDM>();
    //    while (dr.Read())
    //    {
    //        var item = new Admin.AdministratorData.BlockMasterDM();
    //        item.iblockId = Education.DataHelper.GetInt(dr, "iblockId");
    //        item.iblockName = Education.DataHelper.GetString(dr, "iblockName");
    //        //item.instituteId = Education.DataHelper.GetInt(dr, "instituteId");
    //        retItem.Add(item);
    //    }
    //    objDB.Connection.Close();
    //    objDB.Dispose();
    //    return retItem;

    //}


    [OperationContract]
    public List<Admin.AdministratorData.BlockMasterUpdateDM> FillBlockDetails(int blockid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "blockid", blockid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "BlockSelect");
        List<Admin.AdministratorData.BlockMasterUpdateDM> retItem = new List<Admin.AdministratorData.BlockMasterUpdateDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.BlockMasterUpdateDM();
            item.iblockName = Education.DataHelper.GetString(dr, "iblockName");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }


    [OperationContract]
    public string InsertBlockMaster(Admin.AdministratorData.BlockMasterDM objFDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "iblockId", objFDM.iblockId, DbType.Int32);
            objDB.AddParameters(1, "iblockName", objFDM.iblockName, DbType.String);
            objDB.AddParameters(2, "instituteId", objFDM.instituteId, DbType.Int32);
            objDB.AddParameters(3, "flag", objFDM.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "BlockMasterInsert");
            objDB.Transaction.Commit();
            if (objFDM.flag == "I")
            {
                retv = "Record Saved.";
            }
            else if (objFDM.flag == "U")
            {
                retv = "Record Updated.";
            }
            else if (objFDM.flag == "D")
            {
                retv = "Record Deleted.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "-1";
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }


    public DataTable FillGrdRoom(int instituteId, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "RoomSelect");
        return dt;
    }


    [OperationContract]
    public List<Admin.AdministratorData.RoomMasterUpdateDM> FillRoomDetails(int roomid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "roomid", roomid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
        List<Admin.AdministratorData.RoomMasterUpdateDM> retItem = new List<Admin.AdministratorData.RoomMasterUpdateDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.RoomMasterUpdateDM();
            item.floorId = Education.DataHelper.GetInt(dr, "floorId");
            item.blockId = Education.DataHelper.GetInt(dr, "blockId");
            item.roomName = Education.DataHelper.GetString(dr, "roomName");
            item.roomNo = Education.DataHelper.GetString(dr, "roomNo");
            item.roomType = Education.DataHelper.GetString(dr, "roomType");
            item.roomCapacity = Education.DataHelper.GetInt(dr, "roomCapacity");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }


    [OperationContract]
    public string InsertRoomMaster(Admin.AdministratorData.RoomMasterDM objFDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "iroomId", objFDM.iroomId, DbType.Int32);
            objDB.AddParameters(1, "floorId", objFDM.floorId, DbType.Int32);
            objDB.AddParameters(2, "blockId", objFDM.blockId, DbType.Int32);
            objDB.AddParameters(3, "roomName", objFDM.roomName, DbType.String);
            objDB.AddParameters(4, "roomNo", objFDM.roomNo, DbType.String);
            objDB.AddParameters(5, "roomType", objFDM.roomType, DbType.String);
            objDB.AddParameters(6, "roomCapacity", objFDM.roomCapacity, DbType.Int32);
            objDB.AddParameters(7, "instituteId", objFDM.instituteId, DbType.Int32);
            objDB.AddParameters(8, "RoomPattern", objFDM.RoomPattern, DbType.String);
            objDB.AddParameters(9, "flag", objFDM.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "RoomMasterInsert");
            objDB.Transaction.Commit();
            if (objFDM.flag == "I")
            {
                retv = "Record Saved.";
            }
            else if (objFDM.flag == "U")
            {
                retv = "Record Updated.";
            }
            else if (objFDM.flag == "D")
            {
                retv = "Record Deleted.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "-1";
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }



    [OperationContract]
    public List<Admin.AdministratorData.FloorMasterDM> FillFloorName(int instituteId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        objDB.CreateParameters(2);
        //objDB.AddParameters(0, "roomid", roomid, DbType.Int32);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
        List<Admin.AdministratorData.FloorMasterDM> retItem = new List<Admin.AdministratorData.FloorMasterDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.FloorMasterDM();
            item.ifloorId = Education.DataHelper.GetInt(dr, "ifloorId");
            item.ifloorName = Education.DataHelper.GetString(dr, "ifloorName");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }


    [OperationContract]
    public List<Admin.AdministratorData.BlockMasterDM> FillBlockName(int instituteId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        objDB.CreateParameters(2);
        //objDB.AddParameters(0, "roomid", roomid, DbType.Int32);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
        List<Admin.AdministratorData.BlockMasterDM> retItem = new List<Admin.AdministratorData.BlockMasterDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.BlockMasterDM();
            item.iblockId = Education.DataHelper.GetInt(dr, "iblockId");
            item.iblockName = Education.DataHelper.GetString(dr, "iblockName");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }


    [OperationContract]
    public string InsertAssignRoom(List<Admin.AdministratorData.AssignRoomDM> objADM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (Admin.AdministratorData.AssignRoomDM ar in objADM)
            {
                if (ar.Flag == "I")
                {
                    objDB.CreateParameters(14);
                    objDB.AddParameters(0, "AssignRoomID", ar.AssignRoomID, DbType.Int32);
                    objDB.AddParameters(1, "CourseID", ar.CourseID, DbType.Int32);
                    objDB.AddParameters(2, "Session", ar.Session, DbType.String);
                    objDB.AddParameters(3, "FloorID", ar.FloorID, DbType.Int32);
                    objDB.AddParameters(4, "BlockID", ar.BlockID, DbType.Int32);
                    objDB.AddParameters(5, "RoomID", ar.RoomID, DbType.Int32);
                    objDB.AddParameters(6, "Year", ar.Year, DbType.Int32);
                    objDB.AddParameters(7, "Sid", ar.Sid, DbType.Int32);
                    objDB.AddParameters(8, "InstituteID", ar.InstituteID, DbType.Int32);
                    objDB.AddParameters(9, "iGroup", ar.iGroup, DbType.String);
                    objDB.AddParameters(10, "SpecializationID", ar.SpecializationID, DbType.Int32);
                    objDB.AddParameters(11, "Subjectid", ar.SubjectID, DbType.Int32);
                    objDB.AddParameters(12, "Flag", ar.Flag, DbType.String);
                    objDB.AddParameters(13, "StatusId", ar.StatusId, DbType.Int32);
                    retv = "Record Saved.";
                }

                if (ar.Flag == "U")
                {
                    objDB.CreateParameters(4);
                    objDB.AddParameters(0, "AssignRoomID", ar.AssignRoomID, DbType.Int32);
                    objDB.AddParameters(1, "RoomID", ar.RoomID, DbType.Int32);
                    objDB.AddParameters(2, "Subjectid", ar.SubjectID, DbType.Int32);
                    objDB.AddParameters(3, "Flag", ar.Flag, DbType.String);
                    retv = "Record Updated.";
                }
                if (ar.Flag == "D")
                {
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "AssignRoomID", ar.AssignRoomID, DbType.Int32);
                    objDB.AddParameters(1, "Flag", ar.Flag, DbType.String);
                    retv = "Record Deleted.";
                }

                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AssignRoomInsert");

            }
            objDB.Transaction.Commit();

        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "-1";
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    //[OperationContract]
    //public List<Admin.AdministratorData.FillAssignRoomDM> FillAssignRoom(int floorId, int blockId, int flag)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(3);
    //    objDB.AddParameters(0, "floorId", floorId, DbType.Int32);
    //    objDB.AddParameters(1, "blockId", blockId, DbType.Int32);
    //    objDB.AddParameters(2, "flag", flag, DbType.Int32);
    //    IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
    //    List<Admin.AdministratorData.FillAssignRoomDM> retItem = new List<Admin.AdministratorData.FillAssignRoomDM>();
    //    while (dr.Read())
    //    {
    //        var item = new Admin.AdministratorData.FillAssignRoomDM();
    //        item.iroomId = Education.DataHelper.GetInt(dr, "iroomId");
    //        item.roomName = Education.DataHelper.GetString(dr, "roomName");
    //        retItem.Add(item);
    //    }
    //    objDB.Connection.Close();
    //    objDB.Dispose();
    //    return retItem;

    //}


    [OperationContract]

    public List<Admin.AdministratorData.FillAssignRoomGrdDM> FillAssignRoomGrd(int instituteId, int AssignRoomID, int flag, string grp_id, string batch_name)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "AssignRoomID", AssignRoomID, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);//AssignRoomID
        objDB.AddParameters(3, "groupid", grp_id, DbType.Int32);

        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
        List<Admin.AdministratorData.FillAssignRoomGrdDM> retItem = new List<Admin.AdministratorData.FillAssignRoomGrdDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.FillAssignRoomGrdDM();
            item.AssignRoomID = Education.DataHelper.GetInt(dr, "AssignRoomID");
            item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
            item.roomName = Education.DataHelper.GetString(dr, "roomName");
            item.roomNo = Education.DataHelper.GetString(dr, "roomNo");
            item.BlockName = Education.DataHelper.GetString(dr, "BlockName");
            item.FloorName = Education.DataHelper.GetString(dr, "FloorName");
            item.YearSem = Education.DataHelper.GetString(dr, "YearSem");
            item.roomType = Education.DataHelper.GetString(dr, "roomType");
            item.Session = Education.DataHelper.GetString(dr, "Session");
            item.CourseID = Education.DataHelper.GetInt(dr, "CourseID");
            item.FloorID = Education.DataHelper.GetInt(dr, "FloorID");
            item.BlockID = Education.DataHelper.GetInt(dr, "BlockID");
            item.RoomID = Education.DataHelper.GetInt(dr, "RoomID");
            item.Sid = Education.DataHelper.GetInt(dr, "Sid");
            item.iGroup = Education.DataHelper.GetString(dr, "iGroup");
            item.SpecializationID = Education.DataHelper.GetInt(dr, "SpecializationID");
            item.Subjectid = Education.DataHelper.GetInt(dr, "Subjectid");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.Batch_Name = batch_name;
            item.cat_name = Education.DataHelper.GetString(dr, "SubjectCat_Name");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }

    [OperationContract]
    public List<Admin.AdministratorData.FillAssignRoomDM> FillAssignRoom(int floorId, int blockId, string roomType, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "floorId", floorId, DbType.Int32);
        objDB.AddParameters(1, "blockId", blockId, DbType.Int32);
        objDB.AddParameters(2, "roomType", roomType, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
        List<Admin.AdministratorData.FillAssignRoomDM> retItem = new List<Admin.AdministratorData.FillAssignRoomDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.FillAssignRoomDM();
            item.iroomId = Education.DataHelper.GetInt(dr, "iroomId");
            item.roomNo = Education.DataHelper.GetString(dr, "roomNo");
            //item.roomType = Education.DataHelper.GetString(dr, "roomType");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }


    [OperationContract]
    public List<Admin.AdministratorData.FillARoomGrdDM> FillARoomGrd(int floorId, int blockId, string roomtype, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "floorId", floorId, DbType.Int32);
        objDB.AddParameters(1, "blockId", blockId, DbType.Int32);
        objDB.AddParameters(2, "roomtype", roomtype, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "RoomSelect");
        List<Admin.AdministratorData.FillARoomGrdDM> retItem = new List<Admin.AdministratorData.FillARoomGrdDM>();
        while (dr.Read())
        {
            var item = new Admin.AdministratorData.FillARoomGrdDM();
            item.iroomId = Education.DataHelper.GetInt(dr, "iroomId");
            item.roomNo = Education.DataHelper.GetString(dr, "roomNo");
            item.roomType = Education.DataHelper.GetString(dr, "roomType");
            item.rType = Education.DataHelper.GetString(dr, "rType");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }


    public string InsertMultipleUserCreateUser(List<Admin.AdministratorData.CreateUserDM> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (Admin.AdministratorData.CreateUserDM tsv in objDM)
            {

                objDB.CreateParameters(12);
                objDB.AddParameters(0, "UserID", tsv.UserID, DbType.Int32);
                objDB.AddParameters(1, "UserName", tsv.UserName, DbType.String);
                objDB.AddParameters(2, "Password", tsv.Password, DbType.String);
                objDB.AddParameters(3, "Salt", tsv.Salt, DbType.String);
                objDB.AddParameters(4, "InstituteID", tsv.InstituteID, DbType.Int32);
                objDB.AddParameters(5, "Active", tsv.Active, DbType.String);
                objDB.AddParameters(6, "UName", tsv.UName, DbType.String);
                objDB.AddParameters(7, "UEntDt", tsv.UEntDt, DbType.String);
                objDB.AddParameters(8, "Emp_id", tsv.Emp_id, DbType.Int32);
                objDB.AddParameters(9, "User_Type", tsv.User_Type, DbType.String);
                objDB.AddParameters(10, "Flag", tsv.Flag, DbType.String);
                objDB.AddParameters(11, "EmailID", tsv.EmailID, DbType.String);
                retv = tsv.Flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "UserCreation_Insert");
            }
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (retv == "N")
            {
                retv = "Record saved.";
            }
            else if (retv == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        return retv;
    }

    public string InsertControlMaster(Admin.AdministratorData.AddcontrolDM objFDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(6);
            objDB.AddParameters(0, "ControlID", objFDM.ControlID, DbType.Int32);
            objDB.AddParameters(1, "ControlName", objFDM.ControlName, DbType.String);
            objDB.AddParameters(2, "Title", objFDM.Title, DbType.String);
            objDB.AddParameters(3, "ControlPath", objFDM.ControlPath, DbType.String);
            objDB.AddParameters(4, "instituteId", objFDM.instituteId, DbType.Int32);
            objDB.AddParameters(5, "flag", objFDM.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Control_masterInsert");
            objDB.Transaction.Commit();
            if (objFDM.flag == "I")
            {
                retv = "Record Saved.";
            }
            else if (objFDM.flag == "U")
            {
                retv = "Record Updated.";
            }
            else if (objFDM.flag == "D")
            {
                retv = "Record Deleted.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "-1";
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    public DataTable Fillcontrol(int @instituteId, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteId", instituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "controlselect");
        return dt;
    }

    [OperationContract]
    public string InsertStudentLoginDetail(Admin.AdministratorData.LoginDM tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
            objDB.AddParameters(1, "Login_Date", tsv.Login_Date, DbType.String);
            objDB.AddParameters(2, "Login_Time", tsv.Login_Time, DbType.String);
            objDB.AddParameters(3, "InstituteID", tsv.InstituteID, DbType.String);
            objDB.AddParameters(4, "Logout_Time", tsv.Logout_Time, DbType.String);
            objDB.AddParameters(5, "Logout_Date", tsv.Logout_Date, DbType.String);
            objDB.AddParameters(6, "Is_Login", tsv.Is_Login, DbType.String);
            objDB.AddParameters(7, "Flag", tsv.Flag, DbType.String);
            objDB.AddParameters(8, "User_ID", tsv.User_ID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Logined_Student_Insert");

            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {
            objDB.Command.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertLoginDetail1(Admin.AdministratorData.LoginDM tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(5);
            objDB.AddParameters(0, "InstituteID", tsv.InstituteID, DbType.String);
            objDB.AddParameters(1, "SessionID", tsv.SessionID, DbType.String);
            objDB.AddParameters(2, "User_ID", tsv.User_ID, DbType.String);
            objDB.AddParameters(3, "client_ip_ad", tsv.client_ip, DbType.String);
            objDB.AddParameters(4, "client_name", tsv.client_name, DbType.String);
            int Value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "LoginedUser_Insert1");
            objDB.Transaction.Commit();
            if (Value > 0)
            {
                retv = "Record saved.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {
            objDB.Command.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertLoginDetailAll(Admin.AdministratorData.LoginAll tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(14);
            objDB.AddParameters(0, "InstituteID", tsv.InstituteID, DbType.String);
            objDB.AddParameters(1, "SessionID", tsv.SessionID, DbType.String);
            objDB.AddParameters(2, "User_ID", tsv.User_ID, DbType.String);
            objDB.AddParameters(3, "client_ip_ad", tsv.client_ip, DbType.String);
            objDB.AddParameters(4, "client_name", tsv.client_name, DbType.String);
            objDB.AddParameters(5, "AttDay", tsv.Day, DbType.String);
            objDB.AddParameters(6, "AttMonth", tsv.month, DbType.String);
            objDB.AddParameters(7, "AttYear", tsv.year, DbType.String);
            objDB.AddParameters(8, "InTimeHr", tsv.IntimeHr, DbType.String);
            objDB.AddParameters(9, "InTimeMin", tsv.InTimeMin, DbType.String);
            objDB.AddParameters(10, "InTimeSec", tsv.IntimeSec, DbType.String);
            objDB.AddParameters(11, "OutTimeHr", tsv.outTimeHr, DbType.String);
            objDB.AddParameters(12, "OutTimeMin", tsv.outTimeMin, DbType.String);
            objDB.AddParameters(13, "OutTimeSec", tsv.OutTimeSec, DbType.String);
            int Value = objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Temp_Emp_Att");
            objDB.Transaction.Commit();
            if (Value > 0)
            {
                retv = "Record saved.";
            }

        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {
            objDB.Command.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retv;
    }
}
