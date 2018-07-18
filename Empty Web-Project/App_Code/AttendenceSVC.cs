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
public class AttendenceSVC
{
	// Add [WebGet] attribute to use HTTP GET
	[OperationContract]
    public string InsertPeriod_WiseB(List< AttendenceDM.Period_Attendence> objPSF, Admin.AdministratorData.AuditDM audit)
	{
		NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        int f = 0; 
        try
        {
            foreach (AttendenceDM.Period_Attendence BDM in objPSF)
            {
                objDB.CreateParameters(21);
                objDB.AddParameters(0, "ID", BDM.ID, DbType.Int32);
                objDB.AddParameters(1, "CourseID", BDM.CourseID, DbType.Int32);
                objDB.AddParameters(2, "YearID", BDM.YearID, DbType.Int32);
                objDB.AddParameters(3, "DateA", BDM.DateA, DbType.DateTime);
                objDB.AddParameters(4, "BatchID", BDM.BatchID, DbType.Int32);
                objDB.AddParameters(5, "Present", BDM.Present, DbType.Int32);
                objDB.AddParameters(6, "Absent", BDM.Absent, DbType.Int32);
                objDB.AddParameters(7, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(8, "Inst_ID", BDM.Inst_ID, DbType.Int32);
                objDB.AddParameters(9, "SessionID", BDM.SessionID, DbType.String);
                objDB.AddParameters(10, "periodname", BDM.periodname, DbType.String);
                objDB.AddParameters(11, "Remark", BDM.Remark, DbType.String);
                objDB.AddParameters(12, "WeekID", BDM.WeekID, DbType.Int32);
                objDB.AddParameters(13, "PeriodNo", BDM.PeriodNo, DbType.Int32);
                objDB.AddParameters(14, "flag", BDM.Flag, DbType.Int16);
                objDB.AddParameters(15, "TicketNo", BDM.TicketNo, DbType.String);
                objDB.AddParameters(16, "UName", BDM.UName, DbType.String);
                objDB.AddParameters(17, "UEDate", BDM.UEDate, DbType.DateTime);
                objDB.AddParameters(18, "ForwardTo", BDM.ForwardTo, DbType.Int32);
                objDB.AddParameters(19, "EnterForm", BDM.EnterForm, DbType.Int32);
                objDB.AddParameters(20, "Period_Type", BDM.Period_Type, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "PeriodWise_B");
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
            if (f == 1)
            {
                retv = "Record saved.";
            }
            else if (f == 2)
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
    [OperationContract]
    public string InsertAttendanceRecords(List<AttendenceDM.Period_Attendence> objPSF, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        int f = 0;
        try
        {
            foreach (AttendenceDM.Period_Attendence BDM in objPSF)
            {
                objDB.CreateParameters(32);
                objDB.AddParameters(0, "ID", BDM.ID, DbType.Int32);
                objDB.AddParameters(1, "CourseID", BDM.CourseID, DbType.Int32);
                objDB.AddParameters(2, "SpecID", BDM.SpecID, DbType.Int32);
                objDB.AddParameters(3, "YearID", BDM.YearID, DbType.Int32);
                objDB.AddParameters(4, "SubjectID", BDM.SubjectID, DbType.Int32);
                objDB.AddParameters(5, "TopicID", BDM.TopicID, DbType.Int32);
                objDB.AddParameters(6, "SubtopicID", BDM.SubTopicID, DbType.Int32);
                objDB.AddParameters(7, "Types", BDM.Types, DbType.String);
                objDB.AddParameters(8, "DateA", BDM.DateA, DbType.DateTime);
                objDB.AddParameters(9, "BatchID", BDM.BatchID, DbType.Int32);
                objDB.AddParameters(10, "Present", BDM.Present, DbType.Int32);
                objDB.AddParameters(11, "Absent", BDM.Absent, DbType.Int32);
                objDB.AddParameters(12, "NA", BDM.NA, DbType.Int32);
                objDB.AddParameters(13, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(14, "Inst_ID", BDM.Inst_ID, DbType.Int32);
                objDB.AddParameters(15, "SessionID", BDM.SessionID, DbType.String);
                objDB.AddParameters(16, "Class1", BDM.Class1, DbType.String);
                objDB.AddParameters(17, "periodName", BDM.periodname, DbType.String);
                objDB.AddParameters(18, "FacultyID", BDM.FacultyID, DbType.Int32);
                objDB.AddParameters(19, "VenueID", BDM.VenueID, DbType.Int32);
                objDB.AddParameters(20, "UName", BDM.UName, DbType.String);
                objDB.AddParameters(21, "UEDate", BDM.UEDate, DbType.DateTime);
                objDB.AddParameters(22, "TicketNo", BDM.TicketNo, DbType.String);
                objDB.AddParameters(23, "Remark", BDM.Remark, DbType.String);
                objDB.AddParameters(24, "WeekID", BDM.WeekID, DbType.Int32);    
                objDB.AddParameters(25, "PeriodNo", BDM.PeriodNo, DbType.Int32);
                objDB.AddParameters(26, "Period_Type", BDM.Period_Type, DbType.Int32);
                objDB.AddParameters(27, "ForwardTo", BDM.ForwardTo, DbType.Int32);
                objDB.AddParameters(28, "EnterForm", BDM.EnterForm, DbType.Int32);
                objDB.AddParameters(29, "Leave", BDM.Leave, DbType.Int32);
                objDB.AddParameters(30, "Hday", BDM.Hday, DbType.Int32);
                objDB.AddParameters(31, "flag", BDM.Flag, DbType.Int16);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_AttendanceData");
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
            if (f == 1)
            {
                retv = "Record saved.";
            }
            else if (f == 2)
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
    [OperationContract]
    public string InsertDailyAttRecords(List<AttendenceDM.Period_Attendence> objPSF, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        int f = 0;
        try
        {
            foreach (AttendenceDM.Period_Attendence BDM in objPSF)
            {
                objDB.CreateParameters(33);
                objDB.AddParameters(0, "ID", BDM.ID, DbType.Int32);
                objDB.AddParameters(1, "CourseID", BDM.CourseID, DbType.Int32);
                objDB.AddParameters(2, "SpecID", BDM.SpecID, DbType.Int32);
                objDB.AddParameters(3, "YearID", BDM.YearID, DbType.Int32);
                objDB.AddParameters(4, "SubjectID", BDM.SubjectID, DbType.Int32);
                objDB.AddParameters(5, "TopicID", BDM.TopicID, DbType.Int32);
                objDB.AddParameters(6, "SubtopicID", BDM.SubTopicID, DbType.Int32);
                objDB.AddParameters(7, "Types", BDM.Types, DbType.String);
                objDB.AddParameters(8, "DateA", BDM.DateA, DbType.DateTime);
                objDB.AddParameters(9, "BatchID", BDM.BatchID, DbType.Int32);
                objDB.AddParameters(10, "Present", BDM.Present, DbType.Int32);
                objDB.AddParameters(11, "Absent", BDM.Absent, DbType.Int32);
                objDB.AddParameters(12, "NA", BDM.NA, DbType.Int32);
                objDB.AddParameters(13, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(14, "Inst_ID", BDM.Inst_ID, DbType.Int32);
                objDB.AddParameters(15, "SessionID", BDM.SessionID, DbType.String);
                objDB.AddParameters(16, "Class1", BDM.Class1, DbType.String);
                objDB.AddParameters(17, "periodName", BDM.periodname, DbType.String);
                objDB.AddParameters(18, "FacultyID", BDM.FacultyID, DbType.Int32);
                objDB.AddParameters(19, "VenueID", BDM.VenueID, DbType.Int32);
                objDB.AddParameters(20, "UName", BDM.UName, DbType.String);
                objDB.AddParameters(21, "UEDate", BDM.UEDate, DbType.DateTime);
                objDB.AddParameters(22, "TicketNo", BDM.TicketNo, DbType.String);
                objDB.AddParameters(23, "Remark", BDM.Remark, DbType.String);
                objDB.AddParameters(24, "WeekID", BDM.WeekID, DbType.Int32);
                objDB.AddParameters(25, "PeriodNo", BDM.PeriodNo, DbType.Int32);
                objDB.AddParameters(26, "Period_Type", BDM.Period_Type, DbType.Int32);
                objDB.AddParameters(27, "ForwardTo", BDM.ForwardTo, DbType.Int32);
                objDB.AddParameters(28, "EnterForm", BDM.EnterForm, DbType.Int32);
                objDB.AddParameters(29, "Leave", BDM.Leave, DbType.Int32);
                objDB.AddParameters(30, "Hday", BDM.Hday, DbType.Int32);
                objDB.AddParameters(31, "flag", BDM.Flag, DbType.Int16);
                objDB.AddParameters(32, "EgroupId", BDM.EgroupId, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_DailyAttData");
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
            if (f == 1)
            {
                retv = "Record saved.";
            }
            else if (f == 2)
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
    [OperationContract]
    public string InsertBatchAssign(List<AttendenceDM.BatchAssignmentDM> objADM, Admin.AdministratorData.AuditDM audit)
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
            foreach (AttendenceDM.BatchAssignmentDM BDM in objADM)
            {
                objDB.CreateParameters(14);
                objDB.AddParameters(0, "RecordID", BDM.RecordID, DbType.Int32);
                objDB.AddParameters(1, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(2, "Course_ID", BDM.Course_ID, DbType.Int32);
                objDB.AddParameters(3, "YearID", BDM.YearID, DbType.Int32);
                objDB.AddParameters(4, "SplID", BDM.SplID, DbType.Int32);
                objDB.AddParameters(5, "BatchID", BDM.BatchID, DbType.Int32);
                objDB.AddParameters(6, "Assign_Date", BDM.Assign_Date, DbType.String);
                objDB.AddParameters(7, "InstituteID", BDM.InstituteID, DbType.Int32);
                objDB.AddParameters(8, "SessionID", BDM.SessionID, DbType.String);
                objDB.AddParameters(9, "Batch_Type", BDM.Batch_Type, DbType.String);
                objDB.AddParameters(10, "Semesterid", BDM.Semesterid, DbType.String);
                objDB.AddParameters(11, "UEdate", BDM.UEdate, DbType.String);
                objDB.AddParameters(12, "UName", BDM.UName, DbType.String);
                objDB.AddParameters(13, "Flag", BDM.Flag, DbType.String);

                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Attendance_BatchAssign_Insert");
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

    public List<AttendenceDM.BatchStudentSelectDM> FillStudent(int InstituteID, string SessionID, int Course_ID, int YearID, string SemesterID, string SplId)
    {
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
        objDB.AddParameters(5, "SplId", SplId, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentBatchAsign");
        var listOfStudent = new List<AttendenceDM.BatchStudentSelectDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.BatchStudentSelectDM();
            // item.ID_Student= Education.DataHelper.GetString(dr,"ID_Student");
            item.name = Education.DataHelper.GetString(dr, "name");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.URollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
    public class FillBatch : List<AttendenceDM.FillBatchDM>
    {
    }
    public class FillBatchStudent : List<AttendenceDM.FillBatchStudentDM>
    {
    }
    public List<AttendenceDM.FillBatchStudentDM> FillStudentForBatchEdit(int InstituteID, string SessionID, int Course_ID, int YearID, string SemesterID, string SplID, int batchID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(2, "Course_ID", Course_ID, DbType.Int32);
        objDB.AddParameters(3, "YearID", YearID, DbType.Int32);
        objDB.AddParameters(4, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(5, "SplID", SplID, DbType.String);
        objDB.AddParameters(6, "Flag", flag, DbType.Int32);
        objDB.AddParameters(7, "BatchID", batchID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentForBatchEdit");
        var listOfStudent = new List<AttendenceDM.FillBatchStudentDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillBatchStudentDM();
            item.RecordID = Education.DataHelper.GetInt(dr, "RecordID");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");//RegNo
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.URollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
    public List<AttendenceDM.FillBatchDM> FillBatchByInstituteID(int InstituteID, int Course_ID, int YearID, int SemesterID, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "Course_ID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "YearID", YearID, DbType.Int32);
        objDB.AddParameters(3, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetBatchByInstituteID");
        var listOfStudent = new List<AttendenceDM.FillBatchDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillBatchDM();
            item.Batch_ID = Education.DataHelper.GetInt(dr, "Batch_ID");
            item.Batch_name = Education.DataHelper.GetString(dr, "Batch_name");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
   
    public List<AttendenceDM.FillWeekForAttendanceDM> FillWeekForAttendance(int InstituteID, int Course_ID, int SemesterID, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillWeekForAttendance");
        var listOfStudent = new List<AttendenceDM.FillWeekForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillWeekForAttendanceDM();
            item.WeekID = Education.DataHelper.GetInt(dr, "WeekID");
            item.WeekName = Education.DataHelper.GetString(dr, "WeekName");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillPeriodForAttendanceDM> FillPeriodForAttendance(DateTime PeriodDate, int Semid, int Inst_ID, string Session, int Courseid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "PeriodDate", PeriodDate, DbType.DateTime);
        objDB.AddParameters(1, "semid", Semid, DbType.Int32 );
        objDB.AddParameters(2, "Inst_Id", Inst_ID , DbType.Int32);
        objDB.AddParameters(3, "Session", Session , DbType.String );
        objDB.AddParameters(4, "Courseid", Courseid , DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillPeriodForAttendance");
        var listOfStudent = new List<AttendenceDM.FillPeriodForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillPeriodForAttendanceDM();
            item.Period = Education.DataHelper.GetInt(dr, "Period");
            item.shortname = Education.DataHelper.GetString(dr, "shortname");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
    public List<AttendenceDM.FillBatchForAttendanceDM> FillBatchForAttendance(int InstituteID, int Course_ID, int YearID, int SemesterID, int BatchID, string SessionID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "Course_ID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "BatchID", BatchID, DbType.Int32);
        objDB.AddParameters(4, "SessionID", SessionID, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillBatchForAttendance");
        var listOfStudent = new List<AttendenceDM.FillBatchForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillBatchForAttendanceDM();
            item.Batch_ID = Education.DataHelper.GetInt(dr, "Batch_ID");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_name");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentForAttendanceForsubtopicwise(int Inst_Id, int Course_ID, int SemesterID, int Flag, string SessionID, DateTime DateA, int EnterForm,int subtopicid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "Inst_Id", Inst_Id, DbType.Int32);
        objDB.AddParameters(1, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(5, "DateA", DateA, DbType.DateTime);
        objDB.AddParameters(6, "EnterForm", EnterForm, DbType.Int32);
        objDB.AddParameters(7, "subtopicid", subtopicid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForAttendance");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentForAttendance(int Inst_Id, int Course_ID, int SemesterID, int Flag, string SessionID, DateTime DateA, int EnterForm)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "Inst_Id",Inst_Id, DbType.Int32);
        objDB.AddParameters(1, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(5, "DateA", DateA, DbType.DateTime);
        objDB.AddParameters(6, "EnterForm",EnterForm, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForAttendance");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
    public List<AttendenceDM.FillStudentForAttendanceDM>FillStudentForDailyAttEdit(int Inst_ID, int Course_ID, int SemesterID, int EnterForm, string SessionID, int BatchID, int Period_Type, DateTime DateA, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "Inst_ID", Inst_ID, DbType.Int32);
        objDB.AddParameters(1, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "EnterForm", EnterForm, DbType.Int32);
        objDB.AddParameters(4, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(5, "BatchID", BatchID, DbType.Int32);
        objDB.AddParameters(6, "period_Type",Period_Type, DbType.Int32);        
        objDB.AddParameters(7, "DateA", DateA, DbType.DateTime);
        objDB.AddParameters(8, "Flag", Flag, DbType.Int32);       
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForAttendance");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave  = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Remark = Education.DataHelper.GetString(dr,"Remark");  
  
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentForAttendanceByBatch(int InstituteID, int Course_ID, int Flag, int YearID, int SemesterID,  string SessionID, DateTime DateA, string BatchID, int SplID, int EnterForm, int SubjectID, int Period_Type,string class1)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(10);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(4, "DateA", DateA, DbType.DateTime);
        objDB.AddParameters(5, "BatchID", BatchID, DbType.String);
        objDB.AddParameters(6, "SplID", SplID, DbType.Int32);
        objDB.AddParameters(7, "SubjectID", EnterForm, DbType.Int32);
        objDB.AddParameters(8, "Period_Type", Period_Type, DbType.Int32);
        objDB.AddParameters(9, "class1", class1, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForAttendanceByBatch");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            // item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            item.ID = Education.DataHelper.GetInt(dr, "ID");
            item.BatchID = Education.DataHelper.GetInt(dr, "BatchID");
            item.EgroupId = Education.DataHelper.GetInt(dr, "EgroupId");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillStudentAttDailyDM> FillStudentForAttdaily(int InstituteID, string Session, int CourseCode, int YearID, string SemesterID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);

        objDB.AddParameters(1, "Session", Session, DbType.String);
        objDB.AddParameters(2, "CourseCode", CourseCode, DbType.Int32);
        objDB.AddParameters(3, "YearID", YearID, DbType.Int32);
        objDB.AddParameters(4, "SemesterID", SemesterID, DbType.String);
        objDB.AddParameters(5, "Flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentAttdaily");
        var listOfStudent = new List<AttendenceDM.FillStudentAttDailyDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentAttDailyDM();
            item.Sname = Education.DataHelper.GetString(dr, "Sname");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNO = Education.DataHelper.GetString(dr, "RollNO");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentForDailyAttendance(int InstituteID, int Course_ID, int YearID, int SemesterID, int Flag, string SessionID, DateTime DateA)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(4, "DateA", DateA, DbType.DateTime);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForAttendance");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillFacultyToForward> FillFacultyForForward(int InstituteID, int Course_ID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetFacultyToForward");
        var listOfStudent = new List<AttendenceDM.FillFacultyToForward>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillFacultyToForward();
            item.FacultyID = Education.DataHelper.GetInt(dr, "FacultyID");
            item.FName = Education.DataHelper.GetString(dr, "FName");
          
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    [OperationContract]
    public List<AttendenceDM.AttTopicsubtopic> FillAttTopic(int SubTopicID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SubTopicID", SubTopicID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicForAttSubtopic");
        var listOfDate = new List<AttendenceDM.AttTopicsubtopic>();
        while (dr.Read())
        {
            var item = new AttendenceDM.AttTopicsubtopic();
            item.TopicID = Education.DataHelper.GetInt(dr, "TopicID");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }
    [OperationContract]
    public List<AttendenceDM.AttTopicsubtopic>FillSubjectForAtt(int TopicID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "TopicID",TopicID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSubjectForAtt");

        var listOfDate = new List<AttendenceDM.AttTopicsubtopic>();
        while (dr.Read())
        {
            var item = new AttendenceDM.AttTopicsubtopic();
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }
    [OperationContract]
    public List<AttendenceDM.AttTopicsubtopic>FillAttType(int TopicID,int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "TopicID", TopicID, DbType.Int32);
        objDB.AddParameters(1, "flag",flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "AttPeriod_Type_Select");
        var listOfDate = new List<AttendenceDM.AttTopicsubtopic>();
        while (dr.Read())
        {
            var item = new AttendenceDM.AttTopicsubtopic();
            item.Type = Education.DataHelper.GetInt(dr, "Type");
            item.Period_Type= Education.DataHelper.GetString(dr, "Period_Type");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }
    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentForElectiveSubjectAtt(int InstituteID, string SessionID, int Course_ID, int SemesterID, int SubjectID, DateTime DateA, int EgroupId, int Period_Type, int Flag, string SubjectCode, string Class1, string egroup)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(11);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(4, "DateA", DateA, DbType.DateTime);
        objDB.AddParameters(5, "EgroupId", EgroupId, DbType.Int32);
        objDB.AddParameters(6, "Period_Type", Period_Type, DbType.Int32);
        objDB.AddParameters(7, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(8, "SubjectCode", SubjectCode, DbType.String);
        objDB.AddParameters(9, "Class1", Class1, DbType.String);
        objDB.AddParameters(10, "egroup", egroup, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForEleSubjectAtt");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.SplID = Education.DataHelper.GetInt(dr, "SplID");
            item.BatchID = Education.DataHelper.GetInt(dr, "BatchID");
            item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            item.ID = Education.DataHelper.GetInt(dr, "ID");
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }
    public string InsertotherAttRecords(List<AttendenceDM.Period_Attendence> objPSF, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        int f = 0;
        try
        {
            foreach (AttendenceDM.Period_Attendence BDM in objPSF)
            {
                objDB.CreateParameters(34);
                objDB.AddParameters(0, "ID", BDM.ID, DbType.Int32);
                objDB.AddParameters(1, "CourseID", BDM.CourseID, DbType.Int32);
                objDB.AddParameters(2, "SpecID", BDM.SpecID, DbType.Int32);
                objDB.AddParameters(3, "YearID", BDM.YearID, DbType.Int32);
                objDB.AddParameters(4, "SubjectID", BDM.SubjectID, DbType.Int32);
                objDB.AddParameters(5, "TopicID", BDM.TopicID, DbType.Int32);
                objDB.AddParameters(6, "SubtopicID", BDM.SubTopicID, DbType.Int32);
                objDB.AddParameters(7, "Types", BDM.Types, DbType.String);
                objDB.AddParameters(8, "DateA", BDM.DateA, DbType.DateTime);
                objDB.AddParameters(9, "BatchID", BDM.BatchID, DbType.Int32);
                objDB.AddParameters(10, "Present", BDM.Present, DbType.Int32);
                objDB.AddParameters(11, "Absent", BDM.Absent, DbType.Int32);
                objDB.AddParameters(12, "NA", BDM.NA, DbType.Int32);
                objDB.AddParameters(13, "StudentID", BDM.StudentID, DbType.Int32);
                objDB.AddParameters(14, "Inst_ID", BDM.Inst_ID, DbType.Int32);
                objDB.AddParameters(15, "SessionID", BDM.SessionID, DbType.String);
                objDB.AddParameters(16, "Class1", BDM.Class1, DbType.String);
                objDB.AddParameters(17, "periodName", BDM.periodname, DbType.String);
                objDB.AddParameters(18, "FacultyID", BDM.FacultyID, DbType.Int32);
                objDB.AddParameters(19, "VenueID", BDM.VenueID, DbType.Int32);
                objDB.AddParameters(20, "UName", BDM.UName, DbType.String);
                objDB.AddParameters(21, "UEDate", BDM.UEDate, DbType.DateTime);
                objDB.AddParameters(22, "TicketNo", BDM.TicketNo, DbType.String);
                objDB.AddParameters(23, "Remark", BDM.Remark, DbType.String);
                objDB.AddParameters(24, "WeekID", BDM.WeekID, DbType.Int32);
                objDB.AddParameters(25, "PeriodNo", BDM.PeriodNo, DbType.Int32);
                objDB.AddParameters(26, "Period_Type", BDM.Period_Type, DbType.Int32);
                objDB.AddParameters(27, "ForwardTo", BDM.ForwardTo, DbType.Int32);
                objDB.AddParameters(28, "EnterForm", BDM.EnterForm, DbType.Int32);
                objDB.AddParameters(29, "Leave", BDM.Leave, DbType.Int32);
                objDB.AddParameters(30, "Hday", BDM.Hday, DbType.Int32);
                objDB.AddParameters(31, "flag", BDM.Flag, DbType.Int16);
                objDB.AddParameters(32, "EgroupId", BDM.EgroupId, DbType.Int32);
                objDB.AddParameters(33, "DateEnd", BDM.DateEnd, DbType.DateTime);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_OtherAttData");
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
            if (f == 1)
            {
                retv = "Record saved.";
            }
            else if (f == 2)
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

    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentForElectiveAttendanceByBatch(int InstituteID, int Course_ID, int Flag, int YearID, int SemesterID, string SessionID, DateTime DateA, string BatchID, int SplID, int EnterForm, int SubjectID, int Period_Type, string class1)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(10);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(4, "DateA", DateA, DbType.DateTime);
        objDB.AddParameters(5, "BatchID", BatchID, DbType.String);
        objDB.AddParameters(6, "SplID", SplID, DbType.Int32);
        objDB.AddParameters(7, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(8, "Period_Type", Period_Type, DbType.Int32);
        objDB.AddParameters(9, "class1", class1, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentListForElectiveAttendanceByBatch");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            // item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            item.ID = Education.DataHelper.GetInt(dr, "ID");
            item.BatchID = Education.DataHelper.GetInt(dr, "BatchID");
            item.EgroupId = Education.DataHelper.GetInt(dr, "EgroupId");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillStudentForAttendanceDM> FillStudentInternalExamAttendanceByBatch(int InstituteID, int Course_ID, int semid, string SessionID, string BatchID, int SplID, int testid, int SubjectID, string date, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(10);
        objDB.AddParameters(0, "instituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", semid, DbType.Int32);
        objDB.AddParameters(3, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(4, "BatchID", BatchID, DbType.String);
        objDB.AddParameters(5, "SplId", SplID, DbType.String);
        objDB.AddParameters(6, "testid", testid, DbType.Int32);
        objDB.AddParameters(7, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(8, "DateA", date, DbType.DateTime);
        objDB.AddParameters(9, "Flag", flag, DbType.Int32);


        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentAttendance");
        var listOfStudent = new List<AttendenceDM.FillStudentForAttendanceDM>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAttendanceDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            // item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.Absent = Education.DataHelper.GetInt(dr, "Absent");
            item.Present = Education.DataHelper.GetInt(dr, "Present");
            item.OnLeave = Education.DataHelper.GetInt(dr, "OnLeave");
            item.OnHalfDay = Education.DataHelper.GetInt(dr, "OnHalfDay");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");
            item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
            item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
            item.ID = Education.DataHelper.GetInt(dr, "ID");
            item.BatchID = Education.DataHelper.GetInt(dr, "BatchID");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }

    public List<AttendenceDM.FillStudentForAssignmnet> FillStudentAssignmentMarksByBatch(int Course_ID, int semid, string SessionID, string BatchID, int SplID, int AssignID, int SubjectID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(8);
        objDB.AddParameters(0, "CourseID", Course_ID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", semid, DbType.Int32);
        objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(3, "BatchID", BatchID, DbType.String);
        objDB.AddParameters(4, "SplId", SplID, DbType.Int32);
        objDB.AddParameters(5, "assignmentID", AssignID, DbType.Int32);
        objDB.AddParameters(6, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(7, "Flag", flag, DbType.Int32);


        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentAssignmentMarksEntry");
        var listOfStudent = new List<AttendenceDM.FillStudentForAssignmnet>();
        while (dr.Read())
        {
            var item = new AttendenceDM.FillStudentForAssignmnet();
            item.marksid = Education.DataHelper.GetInt(dr, "marksId");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.Name = Education.DataHelper.GetString(dr, "StudentName");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            //item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");

            item.assignName = Education.DataHelper.GetString(dr, "Assignment_Name");
            item.assignID = Education.DataHelper.GetInt(dr, "Assignment_id");
            item.SubjectID = Education.DataHelper.GetInt(dr, "Subject_id");
            item.Con_id = Education.DataHelper.GetInt(dr, "Condition_id");
            item.Sub_date = Education.DataHelper.GetString(dr, "sub_date");
            item.marks_obt = Education.DataHelper.GetDecimal(dr, "marksObtained");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfStudent;
    }  
}
