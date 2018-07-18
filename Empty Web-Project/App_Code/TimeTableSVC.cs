﻿using System;
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
public class TimeTableSVC : Base
{

    [OperationContract(IsOneWay = false)]
    public string InsertPeriodTemplate(List<TimeTableDM.PeriodtemplateDM> objDM, Admin.AdministratorData.AuditDM audit)
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
            foreach (TimeTableDM.PeriodtemplateDM std in objDM)
            {
                objDB.CreateParameters(15);
                objDB.AddParameters(0, "flag", std.Flag, DbType.String);
                objDB.AddParameters(1, "Inst_Id", std.Inst_ID, DbType.String);
                objDB.AddParameters(2, "Session", std.Session, DbType.String);
                objDB.AddParameters(3, "TemplateID", std.TemplateID, DbType.Int32);
                objDB.AddParameters(4, "TempID", std.TempID, DbType.Int32);
                objDB.AddParameters(5, "Period", std.Period, DbType.Int32);
                objDB.AddParameters(6, "Time", std.Time, DbType.String);
                objDB.AddParameters(7, "Shortname", std.Shortname, DbType.String);
                objDB.AddParameters(8, "Duration", std.duration, DbType.String);
                objDB.AddParameters(9, "Courseid", std.Courseid, DbType.String);
                objDB.AddParameters(10, "Cp", std.CP, DbType.String);
                objDB.AddParameters(11, "TR", std.TR, DbType.String);
                objDB.AddParameters(12, "Proj", std.Proj, DbType.String);
                objDB.AddParameters(13, "Period_Type", std.Period_Type, DbType.String);
                objDB.AddParameters(14, "Period_TypeID", std.Period_TypeID, DbType.Int32);
                f = std.Flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "PeriodTemp_Insert");
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
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }
    public string DeletePeriodTemplate(TimeTableDM.PeriodtemplateDM objDl, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "flag", objDl.Flag, DbType.String);
            objDB.AddParameters(1, "Inst_Id", objDl.Inst_ID, DbType.String);
            objDB.AddParameters(2, "Session", objDl.Session, DbType.String);
            objDB.AddParameters(3, "TemplateID", objDl.TemplateID, DbType.Int32);
            f = objDl.Flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "PeriodTemp_Insert");

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
                retv = "Record Deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to Delete Record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }
    public string InsertPeriodTempChild(List<TimeTableDM.PeriodtempchildDM> objDMC, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDBC = new DBManager();
        objDBC.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDBC.DBManager(DataAccessLayer.DataProvider.SqlServer, objDBC.ConnectionString);
        objDBC.Open();
        objDBC.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (TimeTableDM.PeriodtempchildDM std in objDMC)
            {
                objDBC.CreateParameters(10);
                objDBC.AddParameters(0, "flag", std.Flag, DbType.String);
                objDBC.AddParameters(1, "Inst_Id", std.Inst_ID, DbType.Int32);
                objDBC.AddParameters(2, "Session", std.Session, DbType.String);
                objDBC.AddParameters(3, "TemplateID", std.TemplateID, DbType.Int32);
                objDBC.AddParameters(4, "ID", std.ID, DbType.Int32);
                objDBC.AddParameters(5, "Day", std.Day, DbType.String);
                objDBC.AddParameters(6, "Date", std.Date, DbType.DateTime);
                objDBC.AddParameters(7, "WeekID", std.WeekID, DbType.Int32);
                objDBC.AddParameters(8, "Courseid", std.Courseid, DbType.Int32);
                objDBC.AddParameters(9, "Semester", std.Semester, DbType.Int32);
                f = std.Flag;
                objDBC.ExecuteNonQuery(CommandType.StoredProcedure, "PeriodTempChild_Insert");
            }

            objDBC.CreateParameters(9);
            objDBC.AddParameters(0, "ID", 0, DbType.Int32);
            objDBC.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDBC.AddParameters(2, "Action", audit.Action, DbType.String);
            objDBC.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDBC.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDBC.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDBC.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDBC.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDBC.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDBC.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");

            objDBC.Transaction.Commit();
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
            objDBC.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDBC.Connection.Close();
            objDBC.Dispose();
        }
        return retv;
    }
    public string InsertPeriods(List<TimeTableDM.PeriodsDM> objDMC, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDBC = new DBManager();
        objDBC.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDBC.DBManager(DataAccessLayer.DataProvider.SqlServer, objDBC.ConnectionString);
        objDBC.Open();
        objDBC.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (TimeTableDM.PeriodsDM std in objDMC)
            {
                objDBC.CreateParameters(24);
                objDBC.AddParameters(0, "PeriodID", std.PeriodID, DbType.Int32);
                objDBC.AddParameters(1, "WeekID", std.WeekID, DbType.Int32);
                objDBC.AddParameters(2, "CourseID", std.CourseID, DbType.Int32);
                objDBC.AddParameters(3, "SubjectID", std.SubjectID, DbType.Int32);
                objDBC.AddParameters(4, "TopicID", std.TopicID, DbType.Int32);
                objDBC.AddParameters(5, "SubTopicID", std.SubTopicID, DbType.Int32);
                objDBC.AddParameters(6, "FacultyID", std.FacultyID, DbType.Int32);
                objDBC.AddParameters(7, "Semester", std.Semester, DbType.Int32);
                objDBC.AddParameters(8, "Hour", std.Hour, DbType.Int32);
                objDBC.AddParameters(9, "PeriodTime", std.PeriodTime, DbType.String);
                objDBC.AddParameters(10, "PeriodDate", std.PeriodDate, DbType.DateTime);
                objDBC.AddParameters(11, "PeriodType", std.PeriodType, DbType.String);
                objDBC.AddParameters(12, "Batch", std.Batch, DbType.String);
                objDBC.AddParameters(13, "Suspend", std.Suspend, DbType.String);
                objDBC.AddParameters(14, "SuspendReason", std.SuspendReason, DbType.String);
                objDBC.AddParameters(15, "InstituteID ", std.InstituteID, DbType.Int32);
                objDBC.AddParameters(16, "SessionID", std.SessionID, DbType.String);
                objDBC.AddParameters(17, "UName", std.UName, DbType.String);
                objDBC.AddParameters(18, "UEntDt", std.UEntDt, DbType.DateTime);
                objDBC.AddParameters(19, "venue", std.venue, DbType.Int32);
                objDBC.AddParameters(20, "Day", std.Day, DbType.String);
                objDBC.AddParameters(21, "PeriodName", std.PeriodName, DbType.String);
                objDBC.AddParameters(22, "Flag", std.Flag, DbType.Int32 );
                objDBC.AddParameters(23, "EnteredFrom", std.EnteredFrom, DbType.Int32);
                objDBC.ExecuteNonQuery(CommandType.StoredProcedure, "Periods_Insert");
            }

            objDBC.CreateParameters(9);
            objDBC.AddParameters(0, "ID", 0, DbType.Int32);
            objDBC.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDBC.AddParameters(2, "Action", audit.Action, DbType.String);
            objDBC.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDBC.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDBC.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDBC.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDBC.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDBC.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDBC.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");

            objDBC.Transaction.Commit();
            retv = "Record Inserted Successfully.";

        }
        catch (Exception ex)
        {
            objDBC.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDBC.Connection.Close();
            objDBC.Dispose();
        }
        return retv;
    }
    [OperationContract]
    public List<TimeTableDM.TemplateDM> FillTemplates(int RouteID, int MonthID, int Year)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "RouteID", RouteID, DbType.Int32);
        objDB.AddParameters(1, "MonthID", MonthID, DbType.Int32);
        objDB.AddParameters(2, "Year", Year, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Vehicle_Schedule_Chart");
        var listOfDate = new List<TimeTableDM.TemplateDM>();
        try
        {
            while (dr != null)
            {
                var item = new TimeTableDM.TemplateDM();
                item.Template_ID = Education.DataHelper.GetInt(dr, "Template_ID");
                item.Template_Name = Education.DataHelper.GetString(dr, "Template_Name");
                item.TShort_Name = Education.DataHelper.GetString(dr, "TShort_Name");
                item.Status = Education.DataHelper.GetString(dr, "Status");
                item.InstituteID = Education.DataHelper.GetInt(dr, "InstituteID");
                listOfDate.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfDate;
    }


    public string InsertPeriodMaster(TimeTableDM.PeriodMaster objPM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDBC = new DBManager();
        objDBC.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDBC.DBManager(DataAccessLayer.DataProvider.SqlServer, objDBC.ConnectionString);
        objDBC.Open();
        objDBC.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDBC.CreateParameters(6);
            objDBC.AddParameters(0, "PeriodID", objPM.PeriodID, DbType.Int32);
            objDBC.AddParameters(1, "Period_Type", objPM.Period_Type, DbType.String);
            objDBC.AddParameters(2, "Pshort_name", objPM.Pshort_name, DbType.String);
            objDBC.AddParameters(3, "Category", "0", DbType.String);
            objDBC.AddParameters(4, "Status", objPM.Status, DbType.Int32);
            objDBC.AddParameters(5, "Flag", objPM.Flag, DbType.String);
            objDBC.ExecuteNonQuery(CommandType.StoredProcedure, "PeriodMaster_insert");
            objDBC.CreateParameters(9);
            objDBC.AddParameters(0, "ID", 0, DbType.Int32);
            objDBC.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDBC.AddParameters(2, "Action", audit.Action, DbType.String);
            objDBC.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDBC.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDBC.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDBC.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDBC.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDBC.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDBC.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDBC.Transaction.Commit();

            if (objPM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objPM.Flag == "U")
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
            objDBC.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDBC.Connection.Close();
            objDBC.Dispose();
        }
        return retv;
    }
    [OperationContract]
    public List<SyllabusM.SyllabusMData> FillSubjectForTT(int InstituteID, int CourseID, int SemesterID, string sessionID, int specId, int subtype)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "sessionID", sessionID, DbType.String);
        objDB.AddParameters(4, "specId", specId, DbType.Int32);
        objDB.AddParameters(5, "subtype", subtype, DbType.Int32);
        //objDB.AddParameters(6, "subCat", subCat, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSubjectForTTable");

        var listOfDate = new List<SyllabusM.SyllabusMData>();
        while (dr.Read())
        {
            var item = new SyllabusM.SyllabusMData();
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }

    [OperationContract]
    public List<SyllabusM.SyllabusMData> FillSubjectForTT1(int InstituteID, int CourseID, int SemesterID, string sessionID, int specId, int subtype, int subCat)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "sessionID", sessionID, DbType.String);
        objDB.AddParameters(4, "specId", specId, DbType.Int32);
        objDB.AddParameters(5, "subtype", subtype, DbType.Int32);
        objDB.AddParameters(6, "subCat", subCat, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSubjectForTTable1");

        var listOfDate = new List<SyllabusM.SyllabusMData>();
        while (dr.Read())
        {
            var item = new SyllabusM.SyllabusMData();
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }

    [OperationContract]
    public List<SyllabusM.SyllabusMData> FillSubjectTopic(int InstituteID, int CourseID,int YearID, int SemesterID,int SubjectId, string sessionID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "YearID", YearID, DbType.Int32);
        objDB.AddParameters(4, "sessionID", sessionID, DbType.String);
        objDB.AddParameters(5, "SubjectID", SubjectId, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicForAttendance");

        var listOfDate = new List<SyllabusM.SyllabusMData>();
        while (dr.Read())
        {
            var item = new SyllabusM.SyllabusMData();
            item.TopicID = Education.DataHelper.GetInt(dr, "TopicID");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }    

  
    [OperationContract]
    public List<TimeTableDM.SessionDates> FillSessionDates(int courseid, int sid, string sessionyear)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "sid", sid, DbType.Int32);
        objDB.AddParameters(2, "sessionyear", sessionyear, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetsessionDatesForTTable");

        var listOfDate = new List<TimeTableDM.SessionDates>();
        while (dr.Read())
        {
            var item = new TimeTableDM.SessionDates();
            item.startdate = Education.DataHelper.GetDateTime(dr, "startdate");
            item.enddate = Education.DataHelper.GetDateTime(dr, "enddate");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }
    [OperationContract]
    public string InsertTemplateMaster(List<TimeTableDM.TemplateDM> objTDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string flag = "";
        try
        {
            foreach (TimeTableDM.TemplateDM tem in objTDM)
            {
                objDB.CreateParameters(6);
                objDB.AddParameters(0, "Template_ID", tem.Template_ID, DbType.Int32);
                objDB.AddParameters(1, "Template_Name", tem.Template_Name, DbType.String);
                objDB.AddParameters(2, "TShort_Name", tem.TShort_Name, DbType.String);
                objDB.AddParameters(3, "Status", tem.Status, DbType.String);
                objDB.AddParameters(4, "InstituteID", tem.InstituteID, DbType.Int32);
                objDB.AddParameters(5, "flag", tem.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Template_MasterInsert");
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

    [OperationContract]
    public string InsertHoliday(TimeTableDM.HolidayDM objTDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string flag = "";
        try
        {
            TimeSpan ts = Convert.ToDateTime(objTDM.ToDate)-Convert.ToDateTime(objTDM.Date);
            int diffindays = ts.Days + 1;
            if (diffindays > 0)
            {
                
                System.Array smid = objTDM.SemesterID.Split(',');
                System.Array specid = objTDM.specID.Split(',');
                for (int i = 0; i < smid.Length; i++)
                {
                    for (int s = 0; s < specid.Length; s++)
                    {
                        DateTime dt = objTDM.Date;
                        for (int k = 1; k <= diffindays; k++)
                        {
                            objDB.CreateParameters(17);
                            //LeaveName,Day,Month,Year,Date,Type,Description,instituteID,sessionID,YearID,SemesterID,Aflag
                            objDB.AddParameters(0, "LeaveID", objTDM.LeaveID, DbType.Int32);
                            objDB.AddParameters(1, "LeaveName", objTDM.LeaveName, DbType.String);
                            //objDB.AddParameters(2, "Day", objTDM.Day, DbType.String);
                            //objDB.AddParameters(3, "Month", objTDM.Month, DbType.String);
                            //objDB.AddParameters(4, "Year", objTDM.Year, DbType.String);
                            objDB.AddParameters(2, "Day", Convert.ToDateTime(dt).Day.ToString(), DbType.String);
                            objDB.AddParameters(3, "Month", Convert.ToDateTime(dt).Month.ToString(), DbType.String);
                            objDB.AddParameters(4, "Year", Convert.ToDateTime(dt).Year.ToString(), DbType.String);

                            objDB.AddParameters(5, "Date", dt, DbType.DateTime);
                            objDB.AddParameters(6, "Type", objTDM.Type, DbType.String);
                            objDB.AddParameters(7, "Description", objTDM.Description, DbType.String);
                            objDB.AddParameters(8, "instituteID", objTDM.instituteID, DbType.Int32);

                            objDB.AddParameters(9, "sessionID", objTDM.sessionID, DbType.String);
                            objDB.AddParameters(10, "YearID", smid.GetValue(i).ToString(), DbType.String);
                            objDB.AddParameters(11, "SemesterID", Int32.Parse(smid.GetValue(i).ToString()), DbType.Int32);
                            objDB.AddParameters(12, "Aflag", objTDM.Aflag, DbType.String);

                            objDB.AddParameters(13, "flag", objTDM.Flag, DbType.Int32);
                            //objDB.AddParameters(14, "DayName", objTDM.DayName, DbType.String);
                            objDB.AddParameters(14, "DayName", Convert.ToDateTime(dt).ToString("ddd"), DbType.String);
                            objDB.AddParameters(15, "courseID", objTDM.courseID, DbType.Int32);
                            objDB.AddParameters(16, "specID", Int32.Parse(specid.GetValue(s).ToString()), DbType.Int32);
                            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Holiday_Insert");

                            dt = dt.AddDays(1);
                        }//888
                    }
                }
            }
            else
            {
                System.Array smid = objTDM.SemesterID.Split(',');
                for (int i = 0; i < smid.Length; i++)
                {
                    objDB.CreateParameters(17);
                    //LeaveName,Day,Month,Year,Date,Type,Description,instituteID,sessionID,YearID,SemesterID,Aflag
                    objDB.AddParameters(0, "LeaveID", objTDM.LeaveID, DbType.Int32);
                    objDB.AddParameters(1, "LeaveName", objTDM.LeaveName, DbType.String);
                    //objDB.AddParameters(2, "Day", objTDM.Day, DbType.String);
                    //objDB.AddParameters(3, "Month", objTDM.Month, DbType.String);
                    //objDB.AddParameters(4, "Year", objTDM.Year, DbType.String);
                    objDB.AddParameters(2, "Day", Convert.ToDateTime(objTDM.Date).Day.ToString(), DbType.String);
                    objDB.AddParameters(3, "Month", Convert.ToDateTime(objTDM.Date).Month.ToString(), DbType.String);
                    objDB.AddParameters(4, "Year", Convert.ToDateTime(objTDM.Date).Year.ToString(), DbType.String);

                    objDB.AddParameters(5, "Date", objTDM.Date, DbType.DateTime);
                    objDB.AddParameters(6, "Type", objTDM.Type, DbType.String);
                    objDB.AddParameters(7, "Description", objTDM.Description, DbType.String);
                    objDB.AddParameters(8, "instituteID", objTDM.instituteID, DbType.Int32);

                    objDB.AddParameters(9, "sessionID", objTDM.sessionID, DbType.String);
                    objDB.AddParameters(10, "YearID", smid.GetValue(i).ToString(), DbType.String);
                    objDB.AddParameters(11, "SemesterID", Int32.Parse(smid.GetValue(i).ToString()), DbType.Int32);
                    objDB.AddParameters(12, "Aflag", objTDM.Aflag, DbType.String);

                    objDB.AddParameters(13, "flag", objTDM.Flag, DbType.Int32);
                    //objDB.AddParameters(14, "DayName", objTDM.DayName, DbType.String);
                    objDB.AddParameters(14, "DayName", Convert.ToDateTime(objTDM.Date).ToString("ddd"), DbType.String);
                    objDB.AddParameters(15, "courseID", objTDM.courseID, DbType.Int32);
                    objDB.AddParameters(16, "specID", objTDM.specID, DbType.Int32);
                    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Holiday_Insert");
                }
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

            if (objTDM.Flag == 1)
            {
                retv = "Record saved.";
            }
            else if (objTDM.Flag == 2)
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

    public class VenueCollection : List<TimeTableDM.VenuFillForTT>
    {
    }
    [OperationContract(IsOneWay = false)]
    public VenueCollection FillVenue(int courseId,int specId,int semId,int groupId,string session,int flag,string ptype)
    {
        VenueCollection vc = new VenueCollection();

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "courseId", courseId, DbType.Int32);
        objDB.AddParameters(1, "specId", specId, DbType.Int32);
        objDB.AddParameters(2, "semId", semId, DbType.Int32);
        objDB.AddParameters(3, "groupName", groupId, DbType.Int32);
        objDB.AddParameters(4, "session", session, DbType.String);
        objDB.AddParameters(5, "flag", flag, DbType.Int32);
        objDB.AddParameters(6, "ptype", ptype, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetVenueForTTable");
        while (dr.Read())
        {
            TimeTableDM.VenuFillForTT objDM = new TimeTableDM.VenuFillForTT();
            objDM.venue_id = Education.DataHelper.GetInt(dr, "RoomID");
            objDM.Venue_name = Education.DataHelper.GetString(dr, "roomNo");
            vc.Add(objDM);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return vc;
    }

    public FIllFacultyForTimeTable GetFac1(int InstituteID, int courseid, int specid, int semid, int groupid, int subjectid)
    {
        FIllFacultyForTimeTable WC = new FIllFacultyForTimeTable();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "specid", specid, DbType.Int32);
        objDB.AddParameters(3, "semid", semid, DbType.Int32);
        objDB.AddParameters(4, "groupid", groupid, DbType.Int32);
        objDB.AddParameters(5, "subjectid", subjectid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetFacultyDetailForTTable");
        while (dr.Read())
        {
            TimeTableDM.FacultyFill Fac = new TimeTableDM.FacultyFill();
            Fac.FacultyID = Education.DataHelper.GetInt(dr, "FacultyID");
            Fac.Name = Education.DataHelper.GetString(dr, "Name");
            WC.Add(Fac);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return WC;
    }
    //public VenueCollection FillVenue(int InstituteID)
    //{
    //    VenueCollection vc = new VenueCollection();

    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(1);
    //    objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
    //    IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetVenueForTTable");
    //    while (dr.Read())
    //    {
    //        TimeTableDM.VenuFillForTT objDM = new TimeTableDM.VenuFillForTT();
    //        objDM.venue_id = Education.DataHelper.GetInt(dr, "venue_id");
    //        objDM.Venue_name = Education.DataHelper.GetString(dr, "Venue_name");
    //        vc.Add(objDM);
    //    }
    //    objDB.Connection.Close();
    //    objDB.Dispose();
    //    return vc;
    //}

    public class HolidayCollection : List<TimeTableDM.HolidayDM>
    {
    }
    [OperationContract(IsOneWay = false)]
    public HolidayCollection FillHoliday(int InstituteID,string SessionID,Int32 LeaveID)
    {
        HolidayCollection vc = new HolidayCollection();

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(2, "LeaveID", LeaveID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillHoliday");
        while (dr.Read())
        {
            TimeTableDM.HolidayDM objDM = new TimeTableDM.HolidayDM ();
            objDM.LeaveID = Education.DataHelper.GetInt(dr, "LeaveID");
            objDM.LeaveName = Education.DataHelper.GetString(dr, "LeaveName");
            objDM.Type  = Education.DataHelper.GetString(dr, "Type");
            objDM.Date = Education.DataHelper.GetDateTime(dr, "Date");
            vc.Add(objDM);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return vc;
    }
    [OperationContract(IsOneWay = false)]
    public HolidayCollection FillHolidayByID(Int32 LeaveID)
    {
        HolidayCollection vc = new HolidayCollection();

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "InstituteID", 0, DbType.Int32);
        objDB.AddParameters(1, "SessionID", "", DbType.String);
        objDB.AddParameters(2, "LeaveID", LeaveID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetVenueForTTable");
        while (dr.Read())
        {
            TimeTableDM.HolidayDM objDM = new TimeTableDM.HolidayDM();
            objDM.LeaveID = Education.DataHelper.GetInt(dr, "LeaveID");
            objDM.LeaveName = Education.DataHelper.GetString(dr, "LeaveName");
            objDM.Type = Education.DataHelper.GetString(dr, "Type");
            objDM.Date = Education.DataHelper.GetDateTime(dr, "Date");
            vc.Add(objDM);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return vc;
    }


    [OperationContract]
    public List<TimeTableDM.FillWeekForPeriodTemplate> FillWeekForTemplate(int CourseID, int SemesterID, int WeekID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "WeekID", WeekID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillWeekForPeriodTemplate");
        var listOfDate = new List<TimeTableDM.FillWeekForPeriodTemplate>();
        while (dr.Read())
        {
            var item = new TimeTableDM.FillWeekForPeriodTemplate();
            item.WeekName = Education.DataHelper.GetString(dr, "WeekName");
            item.WeekDate = Education.DataHelper.GetDateTime(dr, "WeekDate");
            item.Day = Education.DataHelper.GetString(dr, "Day");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Template_Name = Education.DataHelper.GetString(dr, "Template_Name");
             listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }

}
public abstract class BaseEntity
{
}
public class BaseEntityCollection<T> : List<T> where T : BaseEntity
{
}
public class WeekCollection : BaseEntityCollection<TimeTableDM.WeekFill>
{
}
public class WeekDays : BaseEntityCollection<TimeTableDM.WeekDayFill>
{
}
public class FIllFacultyForTimeTable : BaseEntityCollection<TimeTableDM.FacultyFill>
{
}
public class WeekByIDS : Base
{
    public static WeekCollection GetWeek(int CourseID, int SemesterID, string Session, int FillBy)
    {
        return GetWeekBYIDs.GetWeek(CourseID, SemesterID, Session, FillBy);
    }
}
public class WeekDayIDS : Base
{
    public static WeekDays GetWeekDay(int CourseID, int SemesterID, string Session, int FillBy)
    {
        return GetWeekBYIDs.GetWeekDay(CourseID, SemesterID, Session, FillBy);
    }

}
public class TimeTableFaculty : Base
{
    public static FIllFacultyForTimeTable GetFac(int InstituteID)
    {
        return GetWeekBYIDs.GetFac(InstituteID);
    }

}
internal class GetWeekBYIDs : Base
{
    public static WeekCollection GetWeek(int CourseID, int SemesterID, string Session, int FillBy)
    {
        WeekCollection WC = new WeekCollection();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "Session", Session, DbType.String);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "FillBy", FillBy, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure,"FillWeek");

        while (dr.Read())
        {
            TimeTableDM.WeekFill week = new TimeTableDM.WeekFill();
            week.weekID = Education.DataHelper.GetInt(dr, "weekID");
            week.WeekName = Education.DataHelper.GetString(dr, "WeekName");
            WC.Add(week);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return WC;
    }
    public static WeekDays GetWeekDay(int CourseID, int SemesterID, string Session, int FillBy)
    {
        WeekDays WC = new WeekDays();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "Session", Session, DbType.String);
        objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(3, "FillBy", FillBy, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillWeek");
        while (dr.Read())
        {
            TimeTableDM.WeekDayFill week = new TimeTableDM.WeekDayFill();
            week.Date = Education.DataHelper.GetDateTime(dr, "Date");
            WC.Add(week);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return WC;
    }
    public static FIllFacultyForTimeTable GetFac(int InstituteID)
    {
        FIllFacultyForTimeTable WC = new FIllFacultyForTimeTable();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        //objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        //objDB.AddParameters(2, "specid", specid, DbType.Int32);
        //objDB.AddParameters(3, "semid", semid, DbType.Int32);
        //objDB.AddParameters(4, "groupid", groupid, DbType.Int32);
        //objDB.AddParameters(5, "subjectid", subjectid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetFacultyDetailForTTable");
        while (dr.Read())
        {
            TimeTableDM.FacultyFill Fac = new TimeTableDM.FacultyFill();
            Fac.FacultyID = Education.DataHelper.GetInt(dr, "FacultyID");
            Fac.Name = Education.DataHelper.GetString(dr, "Name");
            WC.Add(Fac);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return WC;
    }
}
public class Base : IDisposable
{
    private bool disposed = false;

    //Implement IDisposable.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Free other state (managed objects).
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
            disposed = true;
        }
    }

    // Use C# destructor syntax for finalization code.
    ~Base()
    {
        // Simply call Dispose(false).
        Dispose(false);
    }

    public class FillTempName : List<TimeTableDM.FillTempName>
    {

    }
    public FillTempName FillTemplate_Name()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();


        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fill_Template");
        FillTempName listOfTemplate = new FillTempName();
        while (dr.Read())
        {
            var item = new TimeTableDM.FillTempName();
            item.Template_ID = Education.DataHelper.GetInt(dr, "Template_ID");
            item.Template_Name = Education.DataHelper.GetString(dr, "Template_Name");

            listOfTemplate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfTemplate;
    }

    [OperationContract]
    public List<AttendenceDM.AttTopicsubtopic> FillPeriod_Type()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "fillPerodtemp");
        var listOfDate = new List<AttendenceDM.AttTopicsubtopic>();
        while (dr.Read())
        {
            var item = new AttendenceDM.AttTopicsubtopic();
            item.Type = Education.DataHelper.GetInt(dr, "Type");
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            listOfDate.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }





}

