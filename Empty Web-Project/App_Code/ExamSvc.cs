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
public class EXamSVC
{
    //Add [WebGet] attribute to use HTTP GET

    [OperationContract]
    public string InsertExamType(ExamDM.ExamTypeDM objIFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(20);
            objDB.AddParameters(0, "testtypeId", objIFM.itesttypeId, DbType.Int32);
            objDB.AddParameters(1, "sessionId", objIFM.sessionId, DbType.String);
            objDB.AddParameters(2, "Courseid", objIFM.Courseid, DbType.Int32);
            objDB.AddParameters(3, "testtypename", objIFM.testtypename, DbType.String);         
            objDB.AddParameters(4, "weightage", objIFM.weighatge, DbType.Int32);
            objDB.AddParameters(5, "status", objIFM.status, DbType.String);
            objDB.AddParameters(6, "nooftests", objIFM.nooftest, DbType.Int32);
            objDB.AddParameters(7, "bestcount", objIFM.bestcount, DbType.Int32);
            objDB.AddParameters(8, "periodno", objIFM.periodno, DbType.String);
            objDB.AddParameters(9, "quepapersubBdays", objIFM.Quessubday, DbType.Int32);
            objDB.AddParameters(10, "marksubAdays", objIFM.markssubday, DbType.Int32);
            objDB.AddParameters(11, "dayNoPriority", objIFM.daynopriority, DbType.String);
            objDB.AddParameters(12, "instituteId", objIFM.instituteid, DbType.Int32);
            objDB.AddParameters(13, "entryUser", objIFM.userid, DbType.Int32);
            objDB.AddParameters(14, "entrydate", objIFM.entrydate, DbType.DateTime);
            objDB.AddParameters(15, "ExamCategoryID", objIFM.examCat, DbType.Int32);
            objDB.AddParameters(16, "FacultyID", objIFM.FacultyID, DbType.Int32);
            objDB.AddParameters(17, "flag", objIFM.Flag, DbType.String);
            objDB.AddParameters(18, "SpclID", objIFM.SPCl, DbType.Int32);
            objDB.AddParameters(19, "SemID", objIFM.semID, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_ItestType");
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
            if (objIFM.Flag == "N")
            {
                retv = "Exam Parameter details submitted successfully..!!Please Move On Set Exam Master";
            }
            else if (objIFM.Flag == "U")
            {
                retv = "Exam Parameter details Updated Successfully.";
            }
            else
            {
                retv = "Exam Parameter details deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save Exam Parameter details :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertExamType1(ExamDM.ExamTypeDM objIFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(19);
            objDB.AddParameters(0, "testtypeId", objIFM.itesttypeId, DbType.Int32);
            objDB.AddParameters(1, "sessionId", objIFM.sessionId, DbType.String);
            objDB.AddParameters(2, "Courseid", objIFM.Courseid, DbType.Int32);
            objDB.AddParameters(3, "testtypename", objIFM.testtypename, DbType.String);
            objDB.AddParameters(4, "testduration", objIFM.testduration, DbType.Int32);
            objDB.AddParameters(5, "weightage", objIFM.weighatge, DbType.Int32);
            objDB.AddParameters(6, "status", objIFM.status, DbType.String);
            objDB.AddParameters(7, "nooftests", objIFM.nooftest, DbType.Int32);
            objDB.AddParameters(8, "bestcount", objIFM.bestcount, DbType.Int32);
            objDB.AddParameters(9, "periodno", objIFM.periodno, DbType.String);
            objDB.AddParameters(10, "quepapersubBdays", objIFM.Quessubday, DbType.Int32);
            objDB.AddParameters(11, "marksubAdays", objIFM.markssubday, DbType.Int32);
            objDB.AddParameters(12, "dayNoPriority", objIFM.daynopriority, DbType.String);
            objDB.AddParameters(13, "instituteId", objIFM.instituteid, DbType.Int32);
            objDB.AddParameters(14, "entryUser", objIFM.userid, DbType.Int32);
            objDB.AddParameters(15, "entrydate", objIFM.entrydate, DbType.DateTime);
            objDB.AddParameters(16, "ExamCategoryID", objIFM.examCat, DbType.Int32);
            objDB.AddParameters(17, "FacultyID", objIFM.FacultyID, DbType.Int32);
            objDB.AddParameters(18, "flag", objIFM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_ItestType");
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
            if (objIFM.Flag == "N")
            {
                retv = "Exam Parameter details submitted successfully..!!.";
            }
            else if (objIFM.Flag == "U")
            {
                retv = "Exam Parameter details Updated Successfully.";
            }
            else
            {
                retv = "Exam Parameter details deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save Exam Parameter details :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract]
    public string InsertOnlineForm(EntranceDM.OnlineForm objONFM, List<EntranceDM.Online_Q> objONQF, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(18);
            objDB.AddParameters(0, "onlineID", objONFM.onlineID, DbType.Int32);
            objDB.AddParameters(1, "appearexam", objONFM.appearexam, DbType.Int32);
            objDB.AddParameters(2, "examdate", objONFM.examdate, DbType.DateTime);
            objDB.AddParameters(3, "firstname", objONFM.firstname, DbType.String);
            objDB.AddParameters(4, "middlename", objONFM.middlename, DbType.String);
            objDB.AddParameters(5, "lastname", objONFM.lastname, DbType.String);
            objDB.AddParameters(6, "dateofbirth", objONFM.dateofbirth, DbType.DateTime);
            objDB.AddParameters(7, "fathername", objONFM.fathername, DbType.String);
            objDB.AddParameters(8, "cantactaddress", objONFM.cantactaddress, DbType.String);
            objDB.AddParameters(9, "city", objONFM.city, DbType.Int32);
            objDB.AddParameters(10, "phoneno", objONFM.phoneno, DbType.String);
            objDB.AddParameters(11, "mobileno", objONFM.mobileno, DbType.String);
            objDB.AddParameters(12, "email", objONFM.email, DbType.String);
            objDB.AddParameters(13, "BankName", objONFM.BankName, DbType.Int32);
            objDB.AddParameters(14, "chequeordraftno", objONFM.chequeordraftno, DbType.String);
            objDB.AddParameters(15, "date", objONFM.date, DbType.DateTime);
            objDB.AddParameters(16, "amount", objONFM.amount, DbType.String);
            objDB.AddParameters(17, "onlineIDreturn", "0", DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "OnlineForm_insert");

            Int32 onID = 0;
            onID = Int32.Parse(objDB.Parameters[17].Value.ToString());


            foreach (EntranceDM.Online_Q std in objONQF)
            {
                objDB.CreateParameters(6);
                objDB.AddParameters(0, "onlineID", onID, DbType.Int32);
                objDB.AddParameters(1, "QID", std.ProfId, DbType.Int32);
                objDB.AddParameters(2, "TM", std.TM, DbType.Int32);
                objDB.AddParameters(3, "MO", std.MO, DbType.Int32);
                objDB.AddParameters(4, "DIV", std.DIV, DbType.String);
                objDB.AddParameters(5, "PER", std.PER, DbType.String);
                //objDB.AddParameters(7, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Online_Q_insert");
            }

            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", "N", DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
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
    public string InsertTestMaster(ExamDM.ExamMasterDM objIFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(16);
            objDB.AddParameters(0, "testId", objIFM.testid, DbType.Int32);
            objDB.AddParameters(1, "testtypeId", objIFM.testtypeid, DbType.Int32);
            objDB.AddParameters(2, "testname", objIFM.testname, DbType.String);
            objDB.AddParameters(3, "mMarks", objIFM.maxmark, DbType.Int32);
            objDB.AddParameters(4, "isCompulsory", objIFM.iscompul, DbType.Int32);
            objDB.AddParameters(5, "fromdate", objIFM.fromdate, DbType.Int32);
            objDB.AddParameters(6, "todate", objIFM.todate, DbType.Int32);

            objDB.AddParameters(7, "flag", objIFM.Flag, DbType.String);
            objDB.AddParameters(8, "Semid", objIFM.Semid, DbType.Int32);
            objDB.AddParameters(9, "ExamCategoryid", objIFM.ExamCategoryid, DbType.Int32);
            objDB.AddParameters(10, "SpclID", objIFM.SpclID, DbType.Int32);
            objDB.AddParameters(11, "facultyID", objIFM.facultyID, DbType.Int32);
            objDB.AddParameters(12, "InstID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(13, "sessionID", audit.SessionID, DbType.String);
            objDB.AddParameters(14, "testduration", objIFM.testduration, DbType.Int32);
            objDB.AddParameters(15, "ratten", objIFM.Ratten, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_itestMaster");
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
            if (objIFM.Flag == "N")
            {
                retv = "Exam Details saved successfully..!!Please Move On Exam Scheduling";

            }
            else if (objIFM.Flag == "U")
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
    public string InsertTestSchedule(List<ExamDM.ExamScheduleDM> objDM, Admin.AdministratorData.AuditDM audit)
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
            foreach (ExamDM.ExamScheduleDM tsv in objDM)
            {
                objDB.CreateParameters(9);
                objDB.AddParameters(0, "testschId", tsv.testschid, DbType.Int32);
                objDB.AddParameters(1, "testId", tsv.testid, DbType.Int32);
                objDB.AddParameters(2, "subjectId", tsv.Subjectid, DbType.String);
                objDB.AddParameters(3, "testDate", tsv.testdate, DbType.String);
                objDB.AddParameters(4, "sessionId", tsv.sessionid, DbType.String);
                objDB.AddParameters(5, "courseId", tsv.courseid, DbType.Int32);
                objDB.AddParameters(6, "specid", tsv.specid, DbType.Int32);
                objDB.AddParameters(7, "semid", tsv.semid, DbType.Int32);
                objDB.AddParameters(8, "flag", tsv.Flag, DbType.String);
                retv = tsv.Flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_itestSchedule");
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
                retv = "Record Saved Successfully.";
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
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    public List<ExamDM.FillInternalMarksDM> FillStudentForMarksEntryByBatch(int InstituteID, int Course_ID, int SemesterID, string SessionID, int BatchID, int SplID, int SubjectID, int testid, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "BatchID", BatchID, DbType.Int32);
        objDB.AddParameters(4, "SplID", SplID, DbType.Int32);
        objDB.AddParameters(5, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(6, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(7, "testid", testid, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForIntmarksEntry");
        var listOfStudent = new List<ExamDM.FillInternalMarksDM>();
        while (dr.Read())
        {
            var item = new ExamDM.FillInternalMarksDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            // item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.marksObtained = Education.DataHelper.GetInt(dr, "marksObtained");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<ExamDM.FillInternalMarksDM> FillStudentForEditIntMark(int InstituteID, int Course_ID, int SemesterID, string SessionID, int BatchID, int SplID, int SubjectID, int testtypeid, int testid, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "BatchID", BatchID, DbType.Int32);
        objDB.AddParameters(4, "SplID", SplID, DbType.Int32);
        objDB.AddParameters(5, "testtypeid", testtypeid, DbType.Int32);
        objDB.AddParameters(6, "testid", testid, DbType.Int32);
        objDB.AddParameters(7, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(8, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForIntmarksEntry");
        var listOfStudent = new List<ExamDM.FillInternalMarksDM>();
        while (dr.Read())
        {
            var item = new ExamDM.FillInternalMarksDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            // item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.marksObtained = Education.DataHelper.GetDecimal(dr, "marksObtained");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.AttId = Education.DataHelper.GetInt(dr, "AttId");
            item.marksId = Education.DataHelper.GetInt(dr, "marksId");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    [OperationContract]
    public string InsertInternalMarks(List<ExamDM.FillInternalMarksDM> objADM, Admin.AdministratorData.AuditDM audit)
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
            foreach (ExamDM.FillInternalMarksDM BDM in objADM)
            {
                objDB.CreateParameters(17);
                objDB.AddParameters(0, "marksId", BDM.marksId, DbType.Int32);
                objDB.AddParameters(1, "testtypeid", BDM.testtypeid, DbType.Int32);
                objDB.AddParameters(2, "testid", BDM.testid, DbType.Int32);
                objDB.AddParameters(3, "sessionId", BDM.sessionid, DbType.String);
                objDB.AddParameters(4, "courseid", BDM.courseid, DbType.Int32);
                objDB.AddParameters(5, "SplId", BDM.specid, DbType.Int32);
                objDB.AddParameters(6, "semId", BDM.semid, DbType.Int32);
                objDB.AddParameters(7, "subjectId", BDM.Subjectid, DbType.Int32);
                objDB.AddParameters(8, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(9, "marksObtained", BDM.marksObtained, DbType.Decimal);
                objDB.AddParameters(10, "Batch_ID", BDM.Batchid, DbType.Int32);
                objDB.AddParameters(11, "Facultyid", BDM.Facultyid, DbType.Int32);
                objDB.AddParameters(12, "userid", BDM.userid, DbType.Int32);
                objDB.AddParameters(13, "Status", BDM.Status, DbType.String);
                objDB.AddParameters(14, "EntryDate", BDM.EntryDate, DbType.DateTime);
                objDB.AddParameters(15, "Flag", BDM.Flag, DbType.String);
                objDB.AddParameters(16, "attendance", BDM.attendance, DbType.String);
                f = BDM.Flag;

                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertInternalMarks");
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

            if (f == "N")
            {
                retv = "Record saved sucessfully.....";
            }
            else
            {
                retv = "Record updated sucessfully.....";
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
    public string InsertExamAttendanceRecords(List<ExamDM.FillInternalMarksDM> objPSF, Admin.AdministratorData.AuditDM audit)
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
            foreach (ExamDM.FillInternalMarksDM BDM in objPSF)
            {
                objDB.CreateParameters(17);
                objDB.AddParameters(0, "AttId", BDM.AttId, DbType.Int32);
                objDB.AddParameters(1, "Inst_Id", BDM.Inst_Id, DbType.Int32);
                objDB.AddParameters(2, "testtypeid", BDM.testtypeid, DbType.Int32);
                objDB.AddParameters(3, "testid", BDM.testid, DbType.Int32);
                objDB.AddParameters(4, "courseid", BDM.courseid, DbType.Int32);
                objDB.AddParameters(5, "splid", BDM.specid, DbType.Int32);
                objDB.AddParameters(6, "sessionid", BDM.sessionid, DbType.String);
                objDB.AddParameters(7, "semid", BDM.semid, DbType.Int32);
                objDB.AddParameters(8, "Batchid", BDM.Batchid, DbType.Int32);
                objDB.AddParameters(9, "Subjectid", BDM.Subjectid, DbType.Int32);
                objDB.AddParameters(10, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(11, "Present", BDM.Present, DbType.Int32);
                objDB.AddParameters(12, "Absent", BDM.Absent, DbType.Int32);
                objDB.AddParameters(13, "flag", BDM.Flag, DbType.String);
                objDB.AddParameters(14, "Conducteddate", BDM.Conducteddate, DbType.DateTime);
                objDB.AddParameters(15, "EntryDate", BDM.EntryDate, DbType.DateTime);
                objDB.AddParameters(16, "userid", BDM.userid, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertInternal_ExamAttData");
                f = BDM.Flag;
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
            if (f == "N")
            {
                retv = "Student Examination Attendance Submitted Successfully..!!.";
            }
            else if (f == "U")
            {
                retv = "Student Examination Attendance Updated Successfully..!!";
            }
            else
            {
                retv = "Student Examination Attendance Deleted Successfully..!!";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save Student Examination Attendance :-" + ex.Message.ToString();
        }
        return retv;
    }


    [OperationContract]
    public string InsertInternalSubjetGrouping(List<ExamDM.FillInternalMarksDM> objPSF, Admin.AdministratorData.AuditDM audit)
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
            foreach (ExamDM.FillInternalMarksDM BDM in objPSF)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "RecordId", BDM.RecordId, DbType.Int32);
                objDB.AddParameters(1, "EgroupId", BDM.EgroupId, DbType.Int32);
                objDB.AddParameters(2, "Subjectid", BDM.Subjectid, DbType.Int32);
                objDB.AddParameters(3, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(4, "SubCategoryID", BDM.SubCategoryID, DbType.Int32);
                objDB.AddParameters(5, "flag", BDM.Flag, DbType.String);
                objDB.AddParameters(6, "courseid", BDM.courseid, DbType.Int32);
                objDB.AddParameters(7, "semid", BDM.semid, DbType.Int32);
                objDB.AddParameters(8, "splid", BDM.specid, DbType.Int32);
                objDB.AddParameters(9, "instid", BDM.Inst_Id, DbType.Int32);
                objDB.AddParameters(10, "sessionid", BDM.sessionid, DbType.String);
                objDB.AddParameters(11, "userid", BDM.userid, DbType.Int32);
                objDB.AddParameters(12, "Entrydate", BDM.EntryDate, DbType.DateTime);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertElec_SubGroupData");
                f = BDM.Flag;
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
        return retv;
    }
    public List<ExamDM.FillInternalMarksDM> FillStudentForEnternalSubjectGrouping(int Course_ID, int SemesterID, string SessionID, int EgroupId, int Subject_Category_Id, int instid, int spclid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "EgroupId", EgroupId, DbType.Int32);
        objDB.AddParameters(4, "Subject_CategoryID", Subject_Category_Id, DbType.Int32);
        objDB.AddParameters(5, "spclID", spclid, DbType.Int32);
        objDB.AddParameters(6, "intid", instid, DbType.Int32);
       

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForIntGrouping");
        var listOfStudent = new List<ExamDM.FillInternalMarksDM>();
        while (dr.Read())
        {
            var item = new ExamDM.FillInternalMarksDM();
            item.RecordId = Education.DataHelper.GetInt(dr, "RecordId");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Group = Education.DataHelper.GetString(dr, "GroupName");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public string InsertTestSchedule1(ExamDM.ExamScheduleDM objDM, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(15);
            objDB.AddParameters(0, "testschId", objDM.testschid, DbType.Int32);
            objDB.AddParameters(1, "testId", objDM.testid, DbType.Int32);
            objDB.AddParameters(2, "subjectId", objDM.Subjectid, DbType.String);
            objDB.AddParameters(3, "testDate", objDM.testdate1, DbType.DateTime);
            objDB.AddParameters(4, "Unit_Name", objDM.Unit_Name, DbType.String);
            objDB.AddParameters(5, "Unit_Id", objDM.Unit_Id, DbType.String);
            objDB.AddParameters(6, "sessionId", objDM.sessionid, DbType.String);
            objDB.AddParameters(7, "courseId", objDM.courseid, DbType.Int32);
            objDB.AddParameters(8, "specid", objDM.specid, DbType.Int32);
            objDB.AddParameters(9, "semid", objDM.semid, DbType.Int32);
            objDB.AddParameters(10, "flag", objDM.Flag, DbType.String);
            objDB.AddParameters(11, "Remark", objDM.remark, DbType.String);
            objDB.AddParameters(12, "Status", objDM.Status, DbType.String);
            objDB.AddParameters(13, "TimeFrom", objDM.TimeFrom, DbType.String);
            objDB.AddParameters(14, "TimeTo", objDM.TimeTo, DbType.String);
           
            retv = objDM.Flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_itestSchedule_new");

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
                retv = "Test Date Scheduled Successfully..!!";
            }
            else if (retv == "U")
            {
                retv = "Test Date Updated Successfully..!!";
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
            
            if (dt.Rows.Count>0)
            {
                retv = dt.Rows[0]["Column1"].ToString();
                
            }


            
            objDB.Connection.Close();
            objDB.Dispose();
       
        return retv;
    }
    public string Activity_Schedule(ExamDM.ExamScheduleDM objDM)
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

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Activity_Schedule");

        DataTable dt = new DataTable();
        dt.Load(dr);

        if (dt.Rows.Count>0)
        {
            retv = dt.Rows[0]["Column1"].ToString();

        }



        objDB.Connection.Close();
        objDB.Dispose();

        return retv;
    }

    public DataTable classposition(int studId, int testid, int subjectid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        string retv = "";
        string f = "";


        objDB.CreateParameters(3);
        objDB.AddParameters(0, "StuId", studId, DbType.Int32);
        objDB.AddParameters(1, "subjectid", subjectid, DbType.Int32);
        objDB.AddParameters(2, "testid", testid, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "ClassPosition");

        DataTable dt = new DataTable();
        dt.Load(dr);

        objDB.Connection.Close();
        objDB.Dispose();

        return dt;
    }

    public DataTable Schedule_ExternalExam(ExamDM.ExamScheduleDM objDM)
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

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Schedule_ExternalExam");

        DataTable dt = new DataTable();
        dt.Load(dr);

        if (dt.Rows.Count > 0)
        {
            retv = dt.Rows[0]["subjectid"].ToString();

        }

        objDB.Connection.Close();
        objDB.Dispose();

        return dt;
    }

    public List<ExamDM.FillInternalMarksDM> FillStudentAddendanceByBatch(int InstituteID, int Course_ID, int SemesterID, string SessionID, string BatchID, int SplID, int SubjectID, int testid, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "BatchID", BatchID, DbType.String);
        objDB.AddParameters(4, "SplID", SplID, DbType.Int32);
        objDB.AddParameters(5, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(6, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(7, "testid", testid, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentIntMarksEntry");
        var listOfStudent = new List<ExamDM.FillInternalMarksDM>();
        while (dr.Read())
        {
            //Batch_ID
            var item = new ExamDM.FillInternalMarksDM();
            item.marksObtained = Education.DataHelper.GetDecimal(dr, "marksObtained");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.marksId = Education.DataHelper.GetInt(dr, "marksid");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Batchid = Convert.ToInt32(Education.DataHelper.GetString(dr, "batchid"));
            item.attendance = Education.DataHelper.GetString(dr, "atte");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }



    public List<ExamDM.FillInternalMarksDM> FillStudentForEditIntAttendance(int InstituteID, int Course_ID, int SemesterID, string SessionID, string BatchID, int SplID, int SubjectID, int testtypeid, int testid, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "BatchID", BatchID, DbType.String);
        objDB.AddParameters(4, "SplID", SplID, DbType.Int32);
        objDB.AddParameters(5, "testtypeid", testtypeid, DbType.Int32);
        objDB.AddParameters(6, "testid", testid, DbType.Int32);
        objDB.AddParameters(7, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(8, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentAttendance");
        var listOfStudent = new List<ExamDM.FillInternalMarksDM>();
        while (dr.Read())
        {
            var item = new ExamDM.FillInternalMarksDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            // item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.marksObtained = Education.DataHelper.GetDecimal(dr, "marksObtained");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.AttId = Education.DataHelper.GetInt(dr, "AttId");
            item.marksId = Education.DataHelper.GetInt(dr, "marksId");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }


}