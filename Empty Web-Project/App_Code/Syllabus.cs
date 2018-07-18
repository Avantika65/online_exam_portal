using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using NewDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using NewDAL;
using System.Web.UI.WebControls;
[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Syllabus
{
    DBManager objDB;
    [OperationContract]
    public string InsertSubject(SyllabusM.SyllabusMData tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string sid = "";
        string retv = "";
        try
        {
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "SubjectID",  tsv.SubjectID , DbType.Int32);
            objDB.AddParameters(1, "SubjectCode", tsv.SubjectCode, DbType.String);
            objDB.AddParameters(2, "SubjectName", tsv.SubjectName, DbType.String);
            objDB.AddParameters(3, "SubjectCat", tsv.Subjectcatagory, DbType.String);
            objDB.AddParameters(4, "SubjectType", tsv.type, DbType.String);
            objDB.AddParameters(5, "InstituteID",  tsv.InstituteID , DbType.Int32);
            objDB.AddParameters(6, "CourseID",  tsv.CourseID , DbType.Int32);
            objDB.AddParameters(7, "SpecilisationID", tsv.Specilizationid, DbType.String);
            objDB.AddParameters(8, "Semester", tsv.Semester, DbType.String);
            objDB.AddParameters(9, "Session", tsv.Session, DbType.String);
            objDB.AddParameters(10, "flag", tsv.flag, DbType.String );   
            
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SubjectSP");
            objDB.Transaction.Commit();
            if (tsv.flag == "N")
            {
                retv =  "Record saved.";
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
        catch(Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" +ex.Message.ToString();
        }
        return retv;
    }

    [OperationContract]
    public List<SyllabusM.SyllabusMData> searchCustomers(string searchText)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "ID", Int32.Parse(searchText), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "SubjectListByID");
        var listOfCustomerItems = new List<SyllabusM.SyllabusMData>();
        if (dr.Read())
        {
            var item = new SyllabusM.SyllabusMData();
            item.SubjectID = int.Parse(dr[0].ToString());
            item.SubjectName = dr[1].ToString();
            item.SubjectCode = dr[2].ToString();
            item.StudyHrs =Int32.Parse( dr[3].ToString());
            item.StudyHrsP = Int32.Parse(dr[4].ToString());
            item.type = Int32.Parse(dr[5].ToString());
            item.InstituteID =Int32.Parse( dr[6].ToString());
            item.CourseID =Int32.Parse( dr[7].ToString());
           listOfCustomerItems.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfCustomerItems;
    }

    [OperationContract]
    public string InsertTopic(SyllabusM.TopicData tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "TopicID", tsv.TopicID, DbType.Int32);
            objDB.AddParameters(1, "SubjectID", tsv.SubjectID, DbType.Int32);
            objDB.AddParameters(2, "TopicName", tsv.TopicName, DbType.String);
            objDB.AddParameters(3, "Hour", tsv.StudyHrs, DbType.Int32);
            objDB.AddParameters(4, "flag", tsv.flag, DbType.Int32);
            objDB.AddParameters(5, "Unitdis", tsv.Unitdis, DbType.String);
            objDB.AddParameters(6, "Unitobj", tsv.Unitobj, DbType.String);
            objDB.AddParameters(7, "Facultyid", tsv.Facultyid, DbType.Int32);
            objDB.AddParameters(8, "Status", tsv.Status, DbType.Boolean);
            objDB.AddParameters(9, "TopicIDreturn", "0", DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Topic_Insert");
            //-----------------------------------------------------------------------
            //Int32 onID = 0;
            //onID = Int32.Parse(objDB.Parameters[9].Value.ToString());
            //foreach (SyllabusM.TopicData std in topicobje)
            //{
            //    objDB.CreateParameters(3);
            //    objDB.AddParameters(0, "Topicid", onID, DbType.Int32);
            //    objDB.AddParameters(1, "Unitobj", std.Unitobj, DbType.String);
            //    objDB.AddParameters(2, "flag", std.flag, DbType.Int32);
            //    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "UnitObjinsert");
            //}

            //---------------------------------------------------------------------------------
            objDB.Transaction.Commit();
            if (tsv.flag == 1)
            {
                retv = "**Unit details saved successfully..!!";
            }
            else if (tsv.flag == 2)
            {
                retv = "**Unit details Updated successfully..!!";
            }
            else
            {
                retv = "**Unit detauils deleted successfully.";
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
    public List<SyllabusM.TopicData> searchTopic(string searchText)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "ID", Int32.Parse(searchText), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopic");
        var listOfCustomerItems = new List<SyllabusM.TopicData>();
        if (dr.Read())
        {
            var item = new SyllabusM.TopicData();
            item.TopicID = int.Parse(dr[0].ToString());
            item.SubjectID =  int.Parse(dr[1].ToString());
            item.TopicName = dr[2].ToString();
            item.StudyHrs= Int32.Parse(dr[3].ToString());
           listOfCustomerItems.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfCustomerItems;
    }

    [OperationContract]
    public List<SyllabusM.TopicData> searchTopicByID(string searchText)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "ID", Int32.Parse(searchText), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicBYID");
        var listOfCustomerItems = new List<SyllabusM.TopicData>();
        if (dr.Read())
        {
            var item = new SyllabusM.TopicData();
            item.TopicID = int.Parse(dr[0].ToString());
            item.SubjectID =  int.Parse(dr[1].ToString());
            item.TopicName = dr[2].ToString();
            item.StudyHrs = Int32.Parse(dr[3].ToString());
            item.InstituteID = Int32.Parse(dr[4].ToString());
            item.CourseID = Int32.Parse(dr[5].ToString());
            item.Type = Int32.Parse(dr[6].ToString());
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            listOfCustomerItems.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfCustomerItems;
    }

    [OperationContract]
    public string InsertSubTopic(SyllabusM.SubTopicData tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(15);

            objDB.AddParameters(0, "Inst_id", tsv.Inst_id, DbType.Int32);
            objDB.AddParameters(1, "Sessionid", tsv.Sessionid, DbType.String);
            objDB.AddParameters(2, "Courseid", tsv.Courseid, DbType.Int32);
            objDB.AddParameters(3, "Splid", tsv.Splid, DbType.Int32);
            objDB.AddParameters(4, "Semid", tsv.Semid, DbType.Int32);
            objDB.AddParameters(5, "subTopicID", tsv.SubTopicID, DbType.Int32);
            objDB.AddParameters(6, "SubjectID", tsv.SubjectID, DbType.Int32);
            objDB.AddParameters(7, "TopicID", tsv.TopicID, DbType.Int32);
            objDB.AddParameters(8, "SubTopicName", tsv.SubTopicName, DbType.String);
            objDB.AddParameters(9, "Hour", tsv.hour, DbType.Int32);
            objDB.AddParameters(10, "FacultyId", tsv.FacultyId, DbType.Int32);
            objDB.AddParameters(11, "EDate ", tsv.EDate, DbType.String);
            objDB.AddParameters(12, "flag", tsv.flag, DbType.String);
            objDB.AddParameters(13, "RangeFrom", tsv.RangeFrom, DbType.String);
            objDB.AddParameters(14, "RangeTo", tsv.RangeTo, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "subTopicSP");
            objDB.Transaction.Commit();
            if (tsv.flag == "N")
            {
                retv = "**Chapter/Topic detail added successfully..!!";
            }
            else if (tsv.flag == "U")
            {
                retv = "**Chapter/Topic detail Updated Successfully..!!";
            }
            else
            {
                retv = "**Chapter/Topic detail deleted Successfully..!!";
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
    public List<SyllabusM.SubTopicData> searchSubTopicByID(string CourseID, string TopicID, string SubjectID, string subtopicID)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "CourseID", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(1, "TopicID", Int32.Parse(TopicID), DbType.Int32);
        objDB.AddParameters(2, "SubjectID", Int32.Parse(SubjectID), DbType.Int32);
        objDB.AddParameters(3, "subtopicID", Int32.Parse(subtopicID), DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicByCondition");
        var listOfCustomerItems = new List<SyllabusM.SubTopicData>();
        if (dr.Read())
        {
            var item = new SyllabusM.SubTopicData();
            item.TopicID = int.Parse(dr[0].ToString());
            item.SubjectID = int.Parse(dr[1].ToString());
            item.SubTopicName = dr[6].ToString();
            item.SubTopicID = int.Parse(dr[5].ToString());
            item.hour = Int32.Parse(dr[7].ToString());
            item.InstituteID = Int32.Parse(dr[3].ToString());
            item.CourseID = Int32.Parse(dr[4].ToString());
            item.Type = dr["type"].ToString();
            item.Active = dr[9].ToString();
            listOfCustomerItems.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfCustomerItems;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertSubjectChild(List<SyllabusM.SubjectChild_Data> objDM, Admin.AdministratorData.AuditDM audit)
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
            foreach (SyllabusM.SubjectChild_Data std in objDM)
            {
                objDB.CreateParameters(15);
                objDB.AddParameters(0, "ID", std.ID, DbType.Int32);
                objDB.AddParameters(1, "SubjectID", std.SubjectID, DbType.String);
                objDB.AddParameters(2, "Type", std.Type  , DbType.Int32);
                objDB.AddParameters(3, "CourseID", std.CourseID, DbType.Int32);
                objDB.AddParameters(4, "YearID", std.YearID, DbType.Int32);
                objDB.AddParameters(5, "SemesterID", std.SemesterID, DbType.Int32);
                objDB.AddParameters(6, "InstituteID", std.InstituteID, DbType.Int32);
                objDB.AddParameters(7, "SessionID", std.SessionID, DbType.String);
                objDB.AddParameters(8, "Active", std.Active, DbType.String);
                objDB.AddParameters(9, "UName", std.UName, DbType.String);
                objDB.AddParameters(10, "UEntDt", std.UEntDt, DbType.String);
                objDB.AddParameters(11, "Batch", std.Batch, DbType.String);
                objDB.AddParameters(12, "Specilizationid", std.Specilizationid, DbType.Int32);
                objDB.AddParameters(13, "Subject_Cat", std.Subject_Cat, DbType.Int32);
                objDB.AddParameters(14, "flag", std.Flag, DbType.String);                
                f = std.Flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Subject_Child");
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
    [OperationContract]
    public string InsertSubjectSetting(SyllabusM.SubjectSetting tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(14);
            objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
            objDB.AddParameters(1, "Inst_ID", tsv.Inst_ID, DbType.Int32);
            objDB.AddParameters(2, "CourseID", tsv.CourseID, DbType.Int32);
            objDB.AddParameters(3, "SubjectName", tsv.SubjectName, DbType.String);
            objDB.AddParameters(4, "HavingPaper", tsv.HavingPaper, DbType.String);
            objDB.AddParameters(5, "UseMarking", tsv.UseMarking, DbType.String);
            objDB.AddParameters(6, "MarkingScheme", tsv.MarkingScheme, DbType.String);
            objDB.AddParameters(7, "TotalMarks", tsv.TotalMarks, DbType.Int32);
            objDB.AddParameters(8, "MinMarks", tsv.MinMarks, DbType.Int32);
            objDB.AddParameters(9, "MaxEx", tsv.MaxEx, DbType.Int32);
            objDB.AddParameters(10, "MinEx", tsv.MinEx, DbType.Int32);
            objDB.AddParameters(11, "MaxInt", tsv.MaxInt, DbType.Int32);
            objDB.AddParameters(12, "MinInt", tsv.MinInt, DbType.Int32);
            objDB.AddParameters(13, "Flag", tsv.Flag, DbType.String);
            retv = tsv.Flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_SubjectSetting");
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
        return retv;
    }

    public string InsertSubjectType(SyllabusM.SylTypeMaster tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        //try
        //{
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "TypeID", tsv.TypeID, DbType.Int32);
            objDB.AddParameters(1, "Subject_Type", tsv.Subject_Type, DbType.String);
            objDB.AddParameters(2, "Code", tsv.Code, DbType.String);            
            objDB.AddParameters(3, "flag", tsv.flag, DbType.String);
            retv = tsv.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure,"Syllabus_Type_Master_insert");
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
        //}
        //catch (Exception ex)
        //{
        //    objDB.Transaction.Rollback();
        //    retv = "Unable to save record :-" + ex.Message.ToString();
        //}
        return retv;
    }

    public string InsertBatchMaster(SyllabusM.BatchMaster tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "Batch_ID", tsv.Batch_ID, DbType.Int32);
            objDB.AddParameters(1, "Batch_Name", tsv.Batch_Name, DbType.String);
            objDB.AddParameters(2, "InstituteID", tsv.InstituteID, DbType.Int32);
            objDB.AddParameters(3, "Session", tsv.Session, DbType.String);
            objDB.AddParameters(4, "CourseId", tsv.CourseId, DbType.Int32);
            objDB.AddParameters(5, "Short_Name", tsv.Short_Name, DbType.String);
            objDB.AddParameters(6, "Semester", tsv.Semester, DbType.Int32);
            objDB.AddParameters(7, "SpecilizationID", tsv.SpecilizationID, DbType.Int32);
            objDB.AddParameters(8, "flag", tsv.flag, DbType.String);
            retv = tsv.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Syllabus_Batch_Master_insert");
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
        return retv;
    }
    public string InsertFacultySubjectChoice(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {

                objDB.CreateParameters(13);
                objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "CourseID", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Specilizationid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "SemesterId", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "Batch_ID", tsv.Batchid, DbType.Int32);
                objDB.AddParameters(7, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(8, "Priority", tsv.Priority, DbType.String);
                objDB.AddParameters(9, "FacultyId", tsv.Facultyid, DbType.String);
                objDB.AddParameters(10, "EDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(11, "ApprovalStatus", tsv.ApprovalStatus, DbType.String);
                objDB.AddParameters(12, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FacultyChoiceInsert");
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
        return retv;
    }

    public string InsertSubjectLoadEvaluation(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {

                objDB.CreateParameters(14);
                objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "CourseID", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Specilizationid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "SemesterId", tsv.Semester, DbType.String);
                //objDB.AddParameters(6, "Batch_ID", tsv.Batchid, DbType.Int32);
                objDB.AddParameters(6, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(7, "PL", tsv.PL, DbType.Int32);
                objDB.AddParameters(8, "PT", tsv.PT, DbType.Int32);
                objDB.AddParameters(9, "PP", tsv.PP, DbType.Int32);
                objDB.AddParameters(10, "Total", tsv.Total, DbType.Int32);
                objDB.AddParameters(11, "UserID", tsv.Facultyid, DbType.String);
                objDB.AddParameters(12, "Entrydate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(13, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SubjectStudyLoadInsert");
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
        return retv;
    }

    public string SubGroupMaster(SyllabusM.SubGroupMaster tsv, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "Sub_Group_MasterID", tsv.Sub_Group_MasterID, DbType.Int32);
            objDB.AddParameters(1, "Institute", tsv.Institute, DbType.String);
            objDB.AddParameters(2, "Group_Name", tsv.Group_Name, DbType.String);
            objDB.AddParameters(3, "Short_Name", tsv.Short_Name, DbType.String);
            objDB.AddParameters(4, "Session", tsv.Session, DbType.String);
            objDB.AddParameters(5, "flag", tsv.flag, DbType.String);
            retv = tsv.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Syllabus_Sub_Group_Master_insert");
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
        return retv;
    }


    public string SubGrouping(SyllabusM.SubGrouping tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(8);
            objDB.AddParameters(0, "Sub_GroupingID", tsv.Sub_GroupingID, DbType.Int32);
            objDB.AddParameters(1, "Institute", tsv.Institute, DbType.String);
            objDB.AddParameters(2, "Session", tsv.Session, DbType.String);
            objDB.AddParameters(3, "Course", tsv.Course, DbType.String);
            objDB.AddParameters(4, "Type", tsv.Type, DbType.String);
            objDB.AddParameters(5, "S_Group", tsv.S_Group, DbType.String);
            objDB.AddParameters(6, "Subject_Name", tsv.Subject_Name, DbType.String);
            objDB.AddParameters(7, "flag", tsv.flag, DbType.String);
            retv = tsv.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Syllabus_Subject_Grouping_insert");
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
        return retv;
    }

    public SyllabusM.GetSubjectType FillSubjectTypeForAttendance(int SubjectID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SubjectID", SubjectID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSubjectTypeBySubjectID");
        var FillSubjectList = new SyllabusM.GetSubjectType();
        try
        {
            if (dr.Read())
            {
                FillSubjectList.SubjectTypeID = Education.DataHelper.GetInt(dr, "type");
            }

        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
     
        }
        return FillSubjectList;
    }

    public SyllabusM.SubjectGroups FillSubjectForGrouping(int SubjectID, int Option)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(1, "Option", Option, DbType.Int32);
       IDataReader dr=objDB.ExecuteReader (CommandType.StoredProcedure, "FillSubjectGroupDetail");
       var item = new SyllabusM.SubjectGroups();
        if (dr.Read())
        {
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.GroupID = Education.DataHelper.GetInt(dr, "GroupID");
            item.IsOptional = Education.DataHelper.GetInt(dr, "IsOptional");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.TotalMarks = Education.DataHelper.GetInt(dr, "TotalMarks");
            item.MinMarks = Education.DataHelper.GetInt(dr, "MinMarks");
            item.MaxEx = Education.DataHelper.GetInt(dr, "MaxEx");
            item.MinEx = Education.DataHelper.GetInt(dr, "MinEx");
            item.MaxInt = Education.DataHelper.GetInt(dr, "MaxInt");
            item.MinInt = Education.DataHelper.GetInt(dr, "MinInt");
            item.Weight = Education.DataHelper.GetDecimal(dr, "Weight");
            item.countable = Education.DataHelper.GetInt(dr, "countable");
            item.Subjectcode = Education.DataHelper.GetString(dr, "Subjectcode");   
        }
        return item;
    }

    public DataTable  FillSubjectForGroupingBySemID(int SemesterID, int Option)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(1, "Option", Option, DbType.Int32);
        DataTable dt = new DataTable();
        dt=objDB.ExecuteTable (CommandType.StoredProcedure, "FillSubjectGroupDetailBySemID");
        return dt;
 
    }

    [OperationContract]
    public List<SyllabusM.PlannerDM>  GetPlannerDetail(int CourseID,int SemesterID,string Session,int dayinaweek,int dailyhours)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
           objDB.CreateParameters(5);
           objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
           objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
           objDB.AddParameters(2, "Session", Session, DbType.String);
           objDB.AddParameters(3, "dayinaweek", dayinaweek, DbType.Int32);
           objDB.AddParameters(4, "dailyhours", dailyhours, DbType.Int32);
 
           IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Get_Subject_Detail");
            List<SyllabusM.PlannerDM> retitem = new List<SyllabusM.PlannerDM>();
            while (dr.Read())
            {
                var item = new SyllabusM.PlannerDM();
                item.Subjectid = Education.DataHelper.GetInt(dr, "subjectid");
                item.subject = Education.DataHelper.GetString(dr, "subject");
                item.Theory = Education.DataHelper.GetInt(dr, "Theory");
                item.Practical = Education.DataHelper.GetInt(dr, "Practical");
                item.SSHours = Education.DataHelper.GetDecimal(dr, "SSHours");
                item.THours = Education.DataHelper.GetDecimal(dr, "THours");
                item.SSHP = Education.DataHelper.GetDecimal(dr, "SSHP");
                item.HAPD = Education.DataHelper.GetDecimal(dr, "HAPD");
                item.DW = Education.DataHelper.GetDecimal(dr, "DW");
                item.THW = Education.DataHelper.GetDecimal(dr, "THW");
                item.THSW = Education.DataHelper.GetDecimal(dr, "THSW");
                item.HTP = Education.DataHelper.GetDecimal(dr, "HTP");
                item.HPP = Education.DataHelper.GetDecimal(dr, "HPP");
                item.HT = Education.DataHelper.GetDecimal(dr, "HT");
                item.HP = Education.DataHelper.GetDecimal(dr, "HP");
                retitem.Add(item);
            }
        return retitem;
    }

    [OperationContract(IsOneWay=true)]
    public List<SyllabusM.GetSubjectDM > GetSubjectList(int CourseID,   string Session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "Session", Session, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text,  "select cast(subjectid as nvarchar)+'^'+cast(type as nvarchar)  as subjectid,subjectname+'('+Subject_Type +')' as subjectname from SubjectListForTopic where courseid=@CourseID  and sessionid=@session order by subjectname");
        List<SyllabusM.GetSubjectDM> retitem = new List<SyllabusM.GetSubjectDM>();
        while (dr.Read())
        {
            var item = new SyllabusM.GetSubjectDM();
            item.SubjectID = Education.DataHelper.GetString(dr, "subjectid");
            item.SubjectName = Education.DataHelper.GetString(dr, "subjectname");
            retitem.Add(item);
        }
        dr.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return retitem;
    }
    [OperationContract(IsOneWay = true)]
    public List<SyllabusM.GetSubjectDM> GetSubjectList1(int CourseID, string Session,int Inst_Id)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "Session", Session, DbType.String);
        objDB.AddParameters(2, "Inst_Id", Inst_Id, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "select distinct cast(subjectid as nvarchar)+'^'+cast(type as nvarchar)  as subjectid,subjectname+'('+Subject_Type +')' as subjectname from SubjectListForTopic where courseid=@CourseID  and sessionid=@session and InstituteID=@Inst_Id order by subjectname");
        List<SyllabusM.GetSubjectDM> retitem = new List<SyllabusM.GetSubjectDM>();
        while (dr.Read())
        {
            var item = new SyllabusM.GetSubjectDM();
            item.SubjectID = Education.DataHelper.GetString(dr, "subjectid");
            item.SubjectName = Education.DataHelper.GetString(dr, "subjectname");
            retitem.Add(item);
        }
        dr.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return retitem;
    }

    [OperationContract]
    public List<SyllabusM.GetTopicDM> GetTopicBysubjectID(int SubjectID, int Facultyid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(1, "Facultyid", Facultyid, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicBySubjectIDNew");
        List<SyllabusM.GetTopicDM> retitem = new List<SyllabusM.GetTopicDM>();
        while (dr.Read())
        {
            var item = new SyllabusM.GetTopicDM();
            item.SubjectID = Education.DataHelper.GetInt(dr, "subjectid");
            item.SubjectName = Education.DataHelper.GetString(dr, "subjectname");
            item.TopicID = Education.DataHelper.GetInt(dr, "TopicID");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.Hour = Education.DataHelper.GetInt(dr, "hour");
            item.Status = Education.DataHelper.GetBoolean(dr, "Status");
            item.Unitdis = Education.DataHelper.GetString(dr, "Unitdis");
            item.Unitobj = Education.DataHelper.GetString(dr, "Unitobj");
            item.Facultyid = Education.DataHelper.GetInt(dr, "Facultyid");

            retitem.Add(item);
        }
        return retitem;
    }
    [OperationContract]
    public List<SyllabusM.SubTopicData> GetSubTopicByTopicID(int TopicID, string Subjectid, string FacultyId)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Courseid", 0, DbType.Int32);
        objDB.AddParameters(1, "TopicID", TopicID, DbType.Int32);
        objDB.AddParameters(2, "SubjectID", Subjectid, DbType.Int32);
        objDB.AddParameters(3, "SubTopicID", 0, DbType.Int32);
        objDB.AddParameters(4, "FacultyId", FacultyId, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetTopicByCondition");
        List<SyllabusM.SubTopicData> retitem = new List<SyllabusM.SubTopicData>();
        while (dr.Read())
        {
            var item = new SyllabusM.SubTopicData();
            item.SubjectID = Education.DataHelper.GetInt(dr, "subjectid");
            //  item.SubjectName = Education.DataHelper.GetString(dr, "subjectname");
            item.TopicID = Education.DataHelper.GetInt(dr, "TopicID");
            //  item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.SubTopicID = Education.DataHelper.GetInt(dr, "SubTopicID");
            item.SubTopicName = Education.DataHelper.GetString(dr, "SubTopicName");
            item.ChapterPage = Education.DataHelper.GetString(dr, "ChapterPage");
            item.Lecturedis = Education.DataHelper.GetString(dr, "Lecturedis");
            item.PPTOHP = Education.DataHelper.GetString(dr, "PPTOHP");
            item.Sitevisitid = Education.DataHelper.GetInt(dr, "Sitevisitid");
            item.Labdemoid = Education.DataHelper.GetInt(dr, "Labdemoid");
            item.VideoLectureid = Education.DataHelper.GetInt(dr, "VideoLectureid");
            item.OtherMetho = Education.DataHelper.GetString(dr, "OtherMetho");
            item.TextBookid = Education.DataHelper.GetInt(dr, "TextBookid");
            item.RefBookid = Education.DataHelper.GetInt(dr, "RefBookid");
            item.Otherrefid = Education.DataHelper.GetInt(dr, "Otherrefid");
            item.hour = Education.DataHelper.GetInt(dr, "hour");
            item.Chapterpageref = Education.DataHelper.GetString(dr, "Chapterpageref");
            item.Otherrefremark = Education.DataHelper.GetString(dr, "Otherrefremark");
            // item.hour = Education.DataHelper.GetInt(dr, "hour");
            retitem.Add(item);
        }
        return retitem;
    }


    [OperationContract]
    public List<SyllabusM.SubTopicDM> GetSubTopicAll(int SubjectID,int TypeID,int top)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(1, "SubjectTypeID", TypeID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "select top(" + top + ")subtopicid,subtopicname,hour,topicid,cast(subjectid as nvarchar) as subjectid,Period_Type,cast( type  as int) as type from Topic_Subtopic_Subject where subjectid=@subjectid and SubjectTypeID=@SubjectTypeID");
        List<SyllabusM.SubTopicDM> retitem = new List<SyllabusM.SubTopicDM>();
        while (dr.Read())
        {
            var item = new SyllabusM.SubTopicDM();
            item.SubTopicID = Education.DataHelper.GetInt(dr, "SubTopicID");
            item.SubTopicName = Education.DataHelper.GetString(dr, "SubTopicName");
            item.TopicID = Education.DataHelper.GetInt(dr, "TopicID");
            item.SubTopicID = Education.DataHelper.GetInt(dr, "SubTopicID");
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.hour = Education.DataHelper.GetInt(dr, "hour");
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            item.Type = Education.DataHelper.GetInt(dr, "Type");
            retitem.Add(item);
        }
        return retitem;
    }

    [OperationContract]
    public  SyllabusM.SubTopicDM GetSubTopicAllByID(int SubtopicID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "ID", SubtopicID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "TT_GetAllForPlannerByID");
        var item = new SyllabusM.SubTopicDM();
        if (dr.Read())
        {
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            item.Type = Education.DataHelper.GetInt(dr, "Type");
        }
        return item;
    }
    [OperationContract]
    public SyllabusM.SubTopicDM GetTopicAllByID(int topicID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "ID", topicID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "TT_GetAllForPlannerByID");
        var item = new SyllabusM.SubTopicDM();
        if (dr.Read())
        {
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            item.Type = Education.DataHelper.GetInt(dr, "Type");
        }
        return item;
    }
    [OperationContract]
    public List<SyllabusM.SubTopicDM> GetTopicAll(int SubjectID, int TypeID, int top)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(1, "SubjectTypeID", TypeID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "select top(" + top + ")hour,topicid,topicname,Period_Type,cast( type  as int) as type,cast(subjectid as nvarchar)as subjectid,SubjectName from TT_Topic_Subject where subjectid=@subjectid and SubjectTypeID=@SubjectTypeID");
        //Topic_Subtopic_Subject
        List<SyllabusM.SubTopicDM> retitem = new List<SyllabusM.SubTopicDM>();
        while (dr.Read())
        {
            var item = new SyllabusM.SubTopicDM();
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.TopicID = Education.DataHelper.GetInt(dr, "TopicID");
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.hour = Education.DataHelper.GetInt(dr, "hour");
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            item.Type = Education.DataHelper.GetInt(dr, "Type");
            retitem.Add(item);
        }
        return retitem;
    }
    [OperationContract]
    public List<SyllabusM.SubTopicDM> GetSubjectAll(int SubjectID, int TypeID, int top)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "SubjectID", SubjectID, DbType.Int32);
        objDB.AddParameters(1, "SubjectTypeID", TypeID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "select top(" + top + ")hour,cast(subjectid as nvarchar) as Subjectid,Period_Type,cast( type  as int) as type,SubjectName from Topic_Subtopic_Subject where subjectid=@subjectid and SubjectTypeID=@SubjectTypeID");//TT_Topic_Subject
        //Topic_Subtopic_Subject
        List<SyllabusM.SubTopicDM> retitem = new List<SyllabusM.SubTopicDM>();
        while (dr.Read())
        {
            var item = new SyllabusM.SubTopicDM();
            item.SubjectID = Education.DataHelper.GetInt(dr, "SubjectID");
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.hour = Education.DataHelper.GetInt(dr, "hour");
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            item.Type = Education.DataHelper.GetInt(dr, "Type");
            retitem.Add(item);
        }
        return retitem;
    }
    [OperationContract]
    public SyllabusM.SubTopicDM GetSubjectAllByID(int SubjectId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "ID", SubjectId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "TT_GetAllForPlannerByID");
        var item = new SyllabusM.SubTopicDM();
        if (dr.Read())
        {
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");        
            item.Period_Type = Education.DataHelper.GetString(dr, "Period_Type");
            item.Type = Education.DataHelper.GetInt(dr, "Type");
        }
        return item;
    }

    public string InsertStudentSubjectChoice(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {
                objDB.CreateParameters(14);
                objDB.AddParameters(0, "Ch_id", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "Courseid", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Splid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "Semesterid", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(7, "Subject_Category_ID", tsv.Subject_Cat_ID, DbType.Int32);
                objDB.AddParameters(8, "StudentID", tsv.Facultyid, DbType.String);
                objDB.AddParameters(9, "EntryDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(10, "ApprovedBy", tsv.ApprovedBy, DbType.String);
                objDB.AddParameters(11, "Status", tsv.ApprovalStatus, DbType.String);
                objDB.AddParameters(12, "Priority", tsv.Priority, DbType.Int32);
                objDB.AddParameters(13, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentSubjectChoiceInsert");
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
        return retv;
    }


    public string InsertFacultySubjectApproval(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {

                objDB.CreateParameters(14);
                objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);

                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "CourseID", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Specilizationid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "SemesterId", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "Batch_ID", tsv.Batchid, DbType.Int32);
                objDB.AddParameters(7, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(8, "Priority", tsv.Priority, DbType.String);
                // objDB.AddParameters(9, "FacultyId", tsv.Facultyid, DbType.String);
                // objDB.AddParameters(10, "EDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(9, "ApprovalStatus", tsv.ApprovalStatus, DbType.String);
                objDB.AddParameters(10, "ApprovedBy", tsv.ApprovedBy, DbType.String);
                objDB.AddParameters(11, "Remark", tsv.Remark, DbType.String);
                objDB.AddParameters(12, "ApprovalDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(13, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FacultySubjectApprovalInsert");
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
        return retv;
    }
    public string InsertFacultySubjectpriority(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {

                objDB.CreateParameters(13);
                objDB.AddParameters(0, "subPriorId", tsv.subPriorId, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "courseID", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "specId", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "semId", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "groupId", tsv.Batchid, DbType.Int32);
                objDB.AddParameters(7, "subjectId", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(8, "subPriorityL", tsv.subPriorityL, DbType.String);
                objDB.AddParameters(9, "subPriorityT", tsv.subPriorityT, DbType.String);
                objDB.AddParameters(10, "subPriorityP", tsv.subPriorityP, DbType.String);
                objDB.AddParameters(11, "flag", tsv.flag, DbType.String);
                objDB.AddParameters(12, "day", tsv.day, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FacultySubjectPrioriytInsert");
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
        return retv;
    }
    public string InsertFacultyActivity(SyllabusM.SyllabusMData tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(14);
            objDB.AddParameters(0, "Aid", tsv.ID, DbType.Int32);
            objDB.AddParameters(1, "InstituteId", tsv.InstituteID, DbType.Int32);
            objDB.AddParameters(2, "SessionId", tsv.Session, DbType.String);
            objDB.AddParameters(3, "CourseId", tsv.CourseID, DbType.Int32);
            objDB.AddParameters(4, "SplId", tsv.Specilizationid, DbType.Int32);
            objDB.AddParameters(5, "SemesterId", tsv.Semester, DbType.Int32);
            objDB.AddParameters(6, "SubjectID", tsv.SubjectID, DbType.Int32);
            objDB.AddParameters(7, "TopicID", tsv.TopicID, DbType.Int32);
            objDB.AddParameters(8, "SubTopicId", tsv.SubTopicId, DbType.Int32);
            objDB.AddParameters(9, "EmpId", tsv.EmpId, DbType.Int32);
            objDB.AddParameters(10, "ActivityDate", tsv.ActivityDate, DbType.String);
            objDB.AddParameters(11, "Entrydate", tsv.Entrydate, DbType.String);
            objDB.AddParameters(12, "LectureType", tsv.LectureType, DbType.Int32);
            objDB.AddParameters(13, "flag", tsv.flag, DbType.String);
            retv = tsv.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertActivityRegister");
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
        return retv;
    }

    public string InsertMBAStudentSubjectChoice(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {
                objDB.CreateParameters(12);
                objDB.AddParameters(0, "Ch_id", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "Courseid", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Splid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "Semesterid", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "SubjectCat_ID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(7, "StudentID", tsv.Facultyid, DbType.String);
                objDB.AddParameters(8, "EntryDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(9, "ApprovedBy", tsv.ApprovedBy, DbType.String);
                objDB.AddParameters(10, "Status", tsv.ApprovalStatus, DbType.String);
                objDB.AddParameters(11, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertMBA_Student_SubjectChoice");
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
        return retv;
    }


    public string InsertElectiveSubjectGroup(SyllabusM.BatchMaster tsv, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "EgroupId", tsv.Batch_ID, DbType.Int32);
            objDB.AddParameters(1, "Groupname", tsv.Batch_Name, DbType.String);
            objDB.AddParameters(2, "Inst_Id", tsv.InstituteID, DbType.Int32);
            objDB.AddParameters(3, "SessionId", tsv.Session, DbType.String);
            objDB.AddParameters(4, "CourseId", tsv.CourseId, DbType.Int32);
            objDB.AddParameters(5, "SemId", tsv.Semester, DbType.Int32);
            objDB.AddParameters(6, "SplID", tsv.SpecilizationID, DbType.Int32);
            objDB.AddParameters(7, "SubjectID", tsv.SubjectID, DbType.Int32);
            objDB.AddParameters(8, "Subject_CategoryID", tsv.Subject_CategoryID, DbType.Int32);
            objDB.AddParameters(9, "flag", tsv.flag, DbType.String);
            retv = tsv.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Elective_Subject_Group_Insert");
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
        return retv;
    }

    public string InsertElectiveSubjectSeatAva(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {
                objDB.CreateParameters(9);
                objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "Inst_Id", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionId", tsv.Session, DbType.String);
                objDB.AddParameters(3, "Courseid", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Splid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "Semid", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(7, "maxstudent", tsv.maxstudent, DbType.Int32);
                objDB.AddParameters(8, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ElectiveSubjectSeatsInsert");
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
        return retv;
    }

    public string InsertFacultyFacultylocking(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {

                objDB.CreateParameters(16);
                objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "CourseID", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Specilizationid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "SemesterId", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "Batch_ID", tsv.Batchid, DbType.Int32);
                objDB.AddParameters(7, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(8, "Priority", tsv.Priority, DbType.String);
                objDB.AddParameters(9, "FacultyId", tsv.Facultyid, DbType.String);
                objDB.AddParameters(10, "EDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(11, "ApprovalStatus", tsv.ApprovalStatus, DbType.String);
                objDB.AddParameters(12, "ApprovedBy", tsv.ApprovedBy, DbType.String);
                objDB.AddParameters(13, "ApprovalDate", tsv.ActivityDate, DbType.String);
                objDB.AddParameters(14, "Remark", tsv.Remark, DbType.String);
                objDB.AddParameters(15, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FacultySubjectLockingInsert");
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
        return retv;
    }

    public string InsertlockLT(List<SyllabusM.SyllabusMData> objDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();

        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (SyllabusM.SyllabusMData tsv in objDM)
            {

                objDB.CreateParameters(17);
                objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", tsv.InstituteID, DbType.String);
                objDB.AddParameters(2, "SessionID", tsv.Session, DbType.String);
                objDB.AddParameters(3, "CourseID", tsv.CourseID, DbType.Int32);
                objDB.AddParameters(4, "Specilizationid", tsv.Specilizationid, DbType.Int32);
                objDB.AddParameters(5, "SemesterId", tsv.Semester, DbType.String);
                objDB.AddParameters(6, "Batch_ID", tsv.Batchid, DbType.Int32);
                objDB.AddParameters(7, "SubjectID", tsv.SubjectID, DbType.Int32);
                objDB.AddParameters(8, "Priority", tsv.Priority, DbType.String);
                objDB.AddParameters(9, "FacultyId", tsv.Facultyid, DbType.String);
                objDB.AddParameters(10, "EDate", tsv.Entrydate, DbType.String);
                objDB.AddParameters(11, "ApprovalStatus", tsv.ApprovalStatus, DbType.String);
                objDB.AddParameters(12, "ApprovedBy", tsv.ApprovedBy, DbType.String);
                objDB.AddParameters(13, "ApprovalDate", tsv.ActivityDate, DbType.String);
                objDB.AddParameters(14, "Remark", tsv.Remark, DbType.String);
                objDB.AddParameters(15, "PeriodID", tsv.PeriodID, DbType.Int32);
                objDB.AddParameters(16, "flag", tsv.flag, DbType.String);
                retv = tsv.flag;
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FacultySubjectLockingInsertLT");
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
        return retv;
    }

    public string CourseCoordinator(SyllabusM.Coursecoordinator tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";

        try
        {
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "COID", tsv.COID, DbType.Int32);
            objDB.AddParameters(1, "Inst_Id", tsv.Inst_Id, DbType.Int32);
            objDB.AddParameters(2, "Sessionid", tsv.Sessionid, DbType.String);
            objDB.AddParameters(3, "Courseid", tsv.Courseid, DbType.Int32);
            objDB.AddParameters(4, "Semid", tsv.Semid, DbType.String);
            objDB.AddParameters(5, "splid", tsv.splid, DbType.Int32);
            objDB.AddParameters(6, "Batch_Id", tsv.Batch_Id, DbType.Int32);
            objDB.AddParameters(7, "Facultyid", tsv.Facultyid, DbType.Int32);
            objDB.AddParameters(8, "flag", tsv.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertCourseCoordinator");
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
        return retv;
    }

    public DataTable Bind_VideoRef_TopicWise(int courseID, int SplID, int SemID, int SubID, int Inst_Id, int Facultyid, string Flag)
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
            objDB.AddParameters(5, "Facultyid", Facultyid, DbType.Int32);
            objDB.AddParameters(6, "Flag", Flag, DbType.String);
            DataTable dt = new DataTable();
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bind_VedioRef_Topic_Wise");          
            return dt;
    }

}
