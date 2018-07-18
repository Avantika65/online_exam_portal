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
public class FacultySVC
{
	// Add [WebGet] attribute to use HTTP GET

	[OperationContract]
    public string InsertFacultySubject(List< FacultyDM.FacultySubject> objFSM, Admin.AdministratorData.AuditDM audit)
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
        
            foreach(FacultyDM.FacultySubject FDM in objFSM)
            {
                objDB.CreateParameters(7);
                objDB.AddParameters(0, "ID", FDM.ID, DbType.Int32);
                objDB.AddParameters(1, "Instt_ID", FDM.Instt_ID, DbType.Int32);
                objDB.AddParameters(2, "CourseID", FDM.CourseID, DbType.Int32);
                objDB.AddParameters(3, "SubjectID", FDM.SubjectID, DbType.Int32);
                objDB.AddParameters(4, "FacultyID", FDM.FacultyID, DbType.Int32);
                objDB.AddParameters(5, "SessionID", FDM.SessionID, DbType.String);
                objDB.AddParameters(6, "flag", FDM.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Faculty_Subject");
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
            }
        
            objDB.Transaction.Commit();
          
                retv = "Record saved.";
            
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
    public string InsertFacultySchdule(FacultyDM.FacultySchdule objFCM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(8);
            objDB.AddParameters(0, "ID", objFCM.ID, DbType.Int32);
            objDB.AddParameters(1, "Instt_ID", objFCM.Instt_ID, DbType.Int32);
            objDB.AddParameters(2, "SessionID", objFCM.SessionID, DbType.String);
            objDB.AddParameters(3, "FacultyID", objFCM.FacultyID, DbType.Int32);
            objDB.AddParameters(4, "DayID", objFCM.DayID, DbType.Int32);
            objDB.AddParameters(5, "TimeFrom", objFCM.TimeFrom, DbType.String);
            objDB.AddParameters(6, "TimeTo", objFCM.TimeTo, DbType.String);
            objDB.AddParameters(7, "flag", objFCM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Faculty_Schdule_f");
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
            if (objFCM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFCM.Flag == "U")
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
    public class FillFacultySubject : List<FacultyDM.FillFacultySubject>
    {
         
    }
    public FillFacultySubject FillFacultySub(int InstituteID, string SessionID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
 
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillFacultySubject");
        FillFacultySubject listOfStudent = new FillFacultySubject();
        while (dr.Read())
        {
            var item = new FacultyDM.FillFacultySubject();
            item.FacultyID = Education.DataHelper.GetInt(dr, "FacultyID");
            item.CourseID = Education.DataHelper.GetInt(dr, "CourseID");
            item.Instt_ID = Education.DataHelper.GetInt(dr, "Instt_ID");
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
            item.FName = Education.DataHelper.GetString(dr, "FName");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfStudent;
    }


    [OperationContract]
    public string InsertFacultyAttendence(FacultyDM.FacultyAttendence objFAM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "ID", objFAM.ID, DbType.Int32);
            objDB.AddParameters(1, "InstituteID", objFAM.InstituteID, DbType.Int32);
            objDB.AddParameters(2, "SessionID", objFAM.SessionID, DbType.String);
            objDB.AddParameters(3, "FacultyID", objFAM.FacultyID, DbType.Int32);
            objDB.AddParameters(4, "DayID", objFAM.DayID, DbType.Int32);
            objDB.AddParameters(5, "AttDate", objFAM.AttDate, DbType.DateTime);
            objDB.AddParameters(6, "TimeFrom", objFAM.TimeFrom, DbType.String);
            objDB.AddParameters(7, "TimeTo", objFAM.TimeTo, DbType.String);
            objDB.AddParameters(8, "Status", objFAM.Status, DbType.String);
            objDB.AddParameters(9, "flag", objFAM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Faculty_Attendence_A");
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
            if (objFAM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFAM.Flag == "U")
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

    public class FillFacultyAtt : List<FacultyDM.FillFacultyDatewiseAttDM>
    {

    }
    public FillFacultyAtt FillFacultyAttendance(int InstituteID, int DepartmentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "DepartmentID", DepartmentID, DbType.Int32);
        objDB.AddParameters(2, "Flag", 1, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select facultyID,Salutation +' '+FirstName+' '+MiddleName +' '+LastName as FName,'False' as status from facultynew where departmentid=@DepartmentID");
        FillFacultyAtt listOfStudent = new FillFacultyAtt();
        while (dr.Read())
        {
            var item = new FacultyDM.FillFacultyDatewiseAttDM();
            item.FacultyID = Education.DataHelper.GetInt(dr, "FacultyID");
            item.FName = Education.DataHelper.GetString(dr, "FName");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfStudent;
    }
}
