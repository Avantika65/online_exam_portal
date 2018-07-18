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
public class PortalSVC
{
	
	[OperationContract]
    public List<PortalDM.QualificationDetailDM> FillQulification(int StudentId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentId", StudentId, DbType.Int32);
        objDB.AddParameters(1, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        var listOfQualification = new List<PortalDM.QualificationDetailDM>();
        while (dr.Read())
        {
            var item = new PortalDM.QualificationDetailDM();
            item.ProfName = Education.DataHelper.GetString(dr, "ProfName");
            item.Passing_Year = Education.DataHelper.GetInt(dr, "Passing_Year");
            item.Division = Education.DataHelper.GetString(dr, "Division");
            item.Percentage = Education.DataHelper.GetString(dr, "Percentage");
            item.Board = Education.DataHelper.GetString(dr, "Board");
            listOfQualification.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfQualification;
    }

    [OperationContract]
    public List<PortalDM.StudentDocDetailDM>FillDocDetail(int StudentId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentId", StudentId, DbType.Int32);
        objDB.AddParameters(1, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        var listOfDocument = new List<PortalDM.StudentDocDetailDM>();
        while (dr.Read())
        {
            var item = new PortalDM.StudentDocDetailDM();
            item.Document_Name = Education.DataHelper.GetString(dr, "Document_Name");
            item.Passing_Year = Education.DataHelper.GetInt(dr, "Passing_Year");
            item.Is_Original = Education.DataHelper.GetBoolean(dr, "Is_Original");
            item.Is_Submitted = Education.DataHelper.GetBoolean(dr, "Is_Submitted");
            item.Issued_By = Education.DataHelper.GetString(dr, "Issued_By");
            item.DocSerial = Education.DataHelper.GetString(dr, "DocSerial");
            item.Verified_By = Education.DataHelper.GetString(dr, "Verified_By");
            
            listOfDocument.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDocument;
    }
    public List<PortalDM.FillSemester> FillSem(int instId, int StudentId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "instId", instId, DbType.Int32);
        objDB.AddParameters(1, "StudentId", StudentId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        var Sem = new List<PortalDM.FillSemester>();
        while (dr.Read())
        {
            var item = new PortalDM.FillSemester();
            item.SID = Education.DataHelper.GetInt(dr, "SID");
            item.CourseYear = Education.DataHelper.GetString(dr, "CourseYear");
            item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
            item.CourseId = Education.DataHelper.GetInt(dr, "CourseId");
            item.Type = Education.DataHelper.GetString(dr, "Type");
            item.Status = Education.DataHelper.GetString(dr, "Status");
            Sem.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return Sem;
    }
    [OperationContract]
    public List<PortalDM.FillfeeStucture >FillfeeStucture(int sid,int StudentId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "sid",sid, DbType.Int32);
        objDB.AddParameters(1, "StudentId", StudentId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        var FeeStructure = new List<PortalDM.FillfeeStucture>();
        while (dr.Read())
        {
            var item = new PortalDM.FillfeeStucture();
            item.FeeheadName = Education.DataHelper.GetString(dr, "FeeheadName");
            item.BreakoffTime = Education.DataHelper.GetString(dr, "BreakoffTime");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.TotalFeeAmount = Education.DataHelper.GetDecimal(dr, "TotalFeeAmount");
            FeeStructure.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return FeeStructure;
    }


    [OperationContract]
    public List<PortalDM.FillfeePaid> FillfeePaid(int sid, int StudentId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "StudentId", StudentId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        var FillfeePaid = new List<PortalDM.FillfeePaid>();
        while (dr.Read())
        {
            var item = new PortalDM.FillfeePaid();
            item.FeeheadName = Education.DataHelper.GetString(dr, "FeeheadName");
            item.BreakoffTime = Education.DataHelper.GetString(dr, "BreakoffTime");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.PaidAmount = Education.DataHelper.GetDecimal(dr, "PaidAmount");
            FillfeePaid.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return FillfeePaid;
    }


    [OperationContract]
    public List<PortalDM.FillfeeBal> FillfeeBal(int sid, int StudentId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "StudentId", StudentId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        var FillfeeBal = new List<PortalDM.FillfeeBal>();
        while (dr.Read())
        {
            var item = new PortalDM.FillfeeBal();
            item.FeeheadName = Education.DataHelper.GetString(dr, "FeeheadName");
            item.BreakoffTime = Education.DataHelper.GetString(dr, "BreakoffTime");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.BalAmount = Education.DataHelper.GetDecimal(dr, "BalAmount");
            FillfeeBal.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return FillfeeBal;
    }


    public class FillYearSem : List<PortalDM.YearSemDM>
    {
    }
    [OperationContract]
    public FillYearSem FillYrSem(int courseid, int instId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "instId", instId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillYearSem listOfYS = new FillYearSem();
        while (dr.Read())
        {
            var item = new PortalDM.YearSemDM();
            item.Yr = Education.DataHelper.GetString(dr, "Yr");
            item.SID = Education.DataHelper.GetInt(dr, "SID");
            listOfYS.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfYS;
    }


    public class FillStudentDetail : List<PortalDM.StudentDetailDM>
    {
    }
    [OperationContract]
    public FillStudentDetail FillStuDetail(int StudentID, int instId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "instId", instId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillStudentDetail listOfSD = new FillStudentDetail();
        while (dr.Read())
        {
            var item = new PortalDM.StudentDetailDM();
            item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
            item.MName = Education.DataHelper.GetString(dr, "MName");
            item.LName = Education.DataHelper.GetString(dr, "LName");
            item.FatherNamePrefix = Education.DataHelper.GetString(dr, "FatherNamePrefix");
            item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
            item.MotherNamePrefix = Education.DataHelper.GetString(dr, "MotherNamePrefix");
            item.MotherName = Education.DataHelper.GetString(dr, "MotherName");
            item.GuardianNamePrefix = Education.DataHelper.GetString(dr, "GuardianNamePrefix");
            item.GuardianName = Education.DataHelper.GetString(dr, "GuardianName");
            item.DOB = Education.DataHelper.GetString(dr, "DOB");
            item.EMail = Education.DataHelper.GetString(dr, "EMail");
            item.LMobileNo = Education.DataHelper.GetString(dr, "LMobileNo");
            item.CAdd1 = Education.DataHelper.GetString(dr, "CAdd1");
            item.CAdd2 = Education.DataHelper.GetString(dr, "CAdd2");
            item.CAdd3 = Education.DataHelper.GetString(dr, "CAdd3");
            item.PAdd1 = Education.DataHelper.GetString(dr, "PAdd1");
            item.PAdd2 = Education.DataHelper.GetString(dr, "PAdd2");
            item.PAdd3 = Education.DataHelper.GetString(dr, "PAdd3");
            item.LAdd1 = Education.DataHelper.GetString(dr, "LAdd1");
            item.LAdd2 = Education.DataHelper.GetString(dr, "LAdd2");
            item.LAdd3 = Education.DataHelper.GetString(dr, "LAdd3");
            //item.Flag = Education.DataHelper.GetInt(dr, "Flag");
            //item.SID = Education.DataHelper.GetInt(dr, "SID");
            listOfSD.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfSD;
    }



    public class FillOfficialDetail : List<PortalDM.OfficialDetailDM>
    {
    }
    [OperationContract]
    public FillOfficialDetail FillOfficialDtl(int StudentID, int instId, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "instId", instId, DbType.Int32);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillOfficialDetail listOfOD = new FillOfficialDetail();
        while (dr.Read())
        {
            var item = new PortalDM.OfficialDetailDM();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.RegistrationDate = Education.DataHelper.GetString(dr, "RegistrationDate");
            item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.EMail = Education.DataHelper.GetString(dr, "EMail");
            item.PMobileNo = Education.DataHelper.GetString(dr, "PMobileNo");
            item.BatchCode = Education.DataHelper.GetString(dr, "BatchCode");
            item.InstituteID = Education.DataHelper.GetInt(dr, "InstituteID");
            listOfOD.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfOD;
    }



    public class FillTopicList : List<PortalDM.TopicListDM>
    {
    }
    [OperationContract]
    public FillTopicList FillTopic(int courseId, int instId,int sid, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "courseId", courseId, DbType.Int32);
        objDB.AddParameters(1, "instId", instId, DbType.Int32);
        objDB.AddParameters(2, "sid", sid, DbType.Int32);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillTopicList listTopic = new FillTopicList();
        while (dr.Read())
        {
            var item = new PortalDM.TopicListDM();
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.SubjectCode = Education.DataHelper.GetString(dr, "SubjectCode");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.Subject_Type = Education.DataHelper.GetString(dr, "Subject_Type");
            item.Hour = Education.DataHelper.GetInt(dr, "Hour");
            item.PHours = Education.DataHelper.GetInt(dr, "PHours");
            listTopic.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listTopic;
    }


    public class FillSubTopicList : List<PortalDM.SubTopicListDM>
    {
    }
    [OperationContract]
    public FillSubTopicList FillSubTopic(int courseId, int instId,int sid, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "courseId", courseId, DbType.Int32);
        objDB.AddParameters(1, "instId", instId, DbType.Int32);
        objDB.AddParameters(2, "sid", sid, DbType.Int32);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillSubTopicList listSubTopic = new FillSubTopicList();
        while (dr.Read())
        {
            var item = new PortalDM.SubTopicListDM();
            item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
            item.SubjectCode = Education.DataHelper.GetString(dr, "SubjectCode");
            item.TopicName = Education.DataHelper.GetString(dr, "TopicName");
            item.SubTopicName = Education.DataHelper.GetString(dr, "SubTopicName");
            item.Subject_Type = Education.DataHelper.GetString(dr, "Subject_Type");
            item.Hour = Education.DataHelper.GetInt(dr, "Hour");
            //item.PHours = Education.DataHelper.GetInt(dr, "PHours");
            listSubTopic.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listSubTopic;
    }


    public class FillFeeNature : List<PortalDM.FeeNatureDM>
    {
    }
    [OperationContract]
    public FillFeeNature FeeNature(int sid, int studentid, int instId, string prno, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(2, "instId", instId, DbType.Int32);
        objDB.AddParameters(3, "prno", prno, DbType.String);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillFeeNature listFeeNature = new FillFeeNature();
        while (dr.Read())
        {
            var item = new PortalDM.FeeNatureDM();
            item.SName = Education.DataHelper.GetString(dr, "SName");
            item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
            item.StudentID = Education.DataHelper.GetString(dr, "StudentID");
            item.DocID = Education.DataHelper.GetInt(dr, "DocID");
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.Prno = Education.DataHelper.GetString(dr, "Prno");
            item.FeeID = Education.DataHelper.GetInt(dr, "FeeID");
            item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
            item.Nature = Education.DataHelper.GetString(dr, "Nature");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.Trans_Date = Education.DataHelper.GetDateTime(dr, "Trans_Date");
            item.sid = Education.DataHelper.GetInt(dr, "sid");
            item.FeeSubID = Education.DataHelper.GetInt(dr, "FeeSubID");
            item.InstId = Education.DataHelper.GetInt(dr, "InstId");

            listFeeNature.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listFeeNature;
    }



    public class FillFeePayMode : List<PortalDM.FeePayModeDM>
    {
    }
    [OperationContract]
    public FillFeePayMode FeePMode(int sid, int studentid, int instId, string prno, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(2, "instId", instId, DbType.Int32);
        objDB.AddParameters(3, "prno", prno, DbType.String);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillFeePayMode listFeePMode = new FillFeePayMode();
        while (dr.Read())
        {
            var item = new PortalDM.FeePayModeDM();
            item.PID = Education.DataHelper.GetInt(dr, "PID");
            item.PaymentMode = Education.DataHelper.GetString(dr, "PaymentMode");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.DDNO = Education.DataHelper.GetInt(dr, "DDNO");

            listFeePMode.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listFeePMode;
    }


    public class FillFeePrint : List<PortalDM.FeePrintDM>
    {
    }
    [OperationContract]
    public FillFeePrint FeePrint(int sid, int studentid, int instId,  int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(2, "instId", instId, DbType.Int32);
       // objDB.AddParameters(3, "prno", prno, DbType.String);
        objDB.AddParameters(3, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillFeePrint listFeeNature = new FillFeePrint();
        while (dr.Read())
        {
            var item = new PortalDM.FeePrintDM();
            item.SName = Education.DataHelper.GetString(dr, "SName");
            item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
            item.StudentID = Education.DataHelper.GetString(dr, "StudentID");
            item.DocID = Education.DataHelper.GetInt(dr, "DocID");
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.Prno = Education.DataHelper.GetString(dr, "Prno");
            item.FeeID = Education.DataHelper.GetInt(dr, "FeeID");
            item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
            item.Nature = Education.DataHelper.GetString(dr, "Nature");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.Trans_Date = Education.DataHelper.GetDateTime(dr, "Trans_Date");
            item.sid = Education.DataHelper.GetInt(dr, "sid");
            item.FeeSubID = Education.DataHelper.GetInt(dr, "FeeSubID");
            item.InstId = Education.DataHelper.GetInt(dr, "InstId");
            item.PID = Education.DataHelper.GetInt(dr, "PID");
            item.PaymentMode = Education.DataHelper.GetString(dr, "PaymentMode");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.DDNO = Education.DataHelper.GetInt(dr, "DDNO");
            item.Address = Education.DataHelper.GetString(dr, "Address");

            listFeeNature.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listFeeNature;
    }


    public class FillStudent : List<PortalDM.FeeStudentDM>
    {
    }
    [OperationContract]
    public FillStudent FeeStudent(int sid, int studentid, int instId, string prno, int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "sid", sid, DbType.Int32);
        objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(2, "instId", instId, DbType.Int32);
        objDB.AddParameters(3, "prno", prno, DbType.String);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentPortal_StudentDetail");
        FillStudent listFeeNature = new FillStudent();
        while (dr.Read())
        {
            var item = new PortalDM.FeeStudentDM();
            item.SName = Education.DataHelper.GetString(dr, "SName");
            item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
            item.StudentID = Education.DataHelper.GetString(dr, "StudentID");
            item.DocID = Education.DataHelper.GetInt(dr, "DocID");
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.Prno = Education.DataHelper.GetString(dr, "Prno");
            item.InstId = Education.DataHelper.GetInt(dr, "InstId");

            listFeeNature.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listFeeNature;
    }
}
