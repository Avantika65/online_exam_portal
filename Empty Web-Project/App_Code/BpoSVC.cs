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
using System.Net.Mail;
using System.Net.Sockets;
[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

public class BpoSVC 
{
    public class FillCourse : List<BpoDM.FillCourseDM>
    {
    }
    [OperationContract]
    public FillCourse FillCourseDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillCourse listCourse = new FillCourse();
        while (dr.Read())
        {
            var item = new BpoDM.FillCourseDM();
            item.CourseId = Education.DataHelper.GetInt(dr, "CourseId");
            item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
            listCourse.Add(item);
        }
        objDB.DataReader.Close();
        objDB.DataReader.Dispose();
        objDB.Connection.Close();
        objDB.Connection.Dispose();
        objDB.Close();
        return listCourse;
    }


    public class FillCity : List<BpoDM.FillCityDM>
    {
    }
    [OperationContract]
    public FillCity FillCityDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillCity listCity = new FillCity();
        while (dr.Read())
        {
            var item = new BpoDM.FillCityDM();
            item.CityId = Education.DataHelper.GetInt(dr, "CityId");
            item.CityName = Education.DataHelper.GetString(dr, "CityName");
            listCity.Add(item);
        }
        objDB.DataReader.Close();
        objDB.DataReader.Dispose();
        objDB.Connection.Close();
        objDB.Connection.Dispose();
        objDB.Close();
        return listCity;
    }


    public class FillState : List<BpoDM.FillStateDM>
    {
    }
    [OperationContract]
    public FillState FillStateDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillState listState = new FillState();
        while (dr.Read())
        {
            var item = new BpoDM.FillStateDM();
            item.StateId = Education.DataHelper.GetInt(dr, "StateId");
            item.StateName = Education.DataHelper.GetString(dr, "StateName");
            listState.Add(item);
        }
        objDB.DataReader.Close();
        objDB.DataReader.Dispose();
        objDB.Connection.Close();
        objDB.Connection.Dispose();
         return listState;
    }


    public class FillCountry : List<BpoDM.FillCountryDM>
    {
    }
    [OperationContract]
    public FillCountry FillCountryDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillCountry listCountry = new FillCountry();
        while (dr.Read())
        {
            var item = new BpoDM.FillCountryDM();
            item.CountryId = Education.DataHelper.GetInt(dr, "CountryId");
            item.CountryName = Education.DataHelper.GetString(dr, "CountryName");
            listCountry.Add(item);
        }
        objDB.DataReader.Close();
        objDB.DataReader.Dispose();
        objDB.Connection.Close();
        objDB.Connection.Dispose();
        return listCountry;
    }


    public class FillCollege : List<BpoDM.FillCollegeDM>
    {
    }
    [OperationContract]
    public FillCollege FillCollegeDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillCollege listCollege = new FillCollege();
        while (dr.Read())
        {
            var item = new BpoDM.FillCollegeDM();
            item.collegeID = Education.DataHelper.GetInt(dr, "collegeID");
            item.ShortName = Education.DataHelper.GetString(dr, "ShortName");
            listCollege.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listCollege;
    }

    public class FillPagingBpoGV : List<BpoDM.FillPagingBpoDM>
    {
    }
    [OperationContract]
    public FillPagingBpoGV FillPagingBpo(string uname, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "uname", uname, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillPagingBpoGV listBpo = new FillPagingBpoGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillPagingBpoDM();
            item.RegNo = Education.DataHelper.GetInt(dr, "RegNo");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.ForwardPerson = Education.DataHelper.GetString(dr, "ForwardPerson");
            item.Course = Education.DataHelper.GetString(dr, "Course");
            item.Earlier_Ref = Education.DataHelper.GetString(dr, "Earlier_Ref");
            item.DateApplied = Education.DataHelper.GetDateTime(dr, "DateApplied");
            //item.DateApplied = Education.DataHelper.GetString(dr, "DateApplied");
            item.Next_Date = Education.DataHelper.GetString(dr, "Next_Date");
            item.Ndate = Education.DataHelper.GetString(dr, "Ndate");
            item.Remark = Education.DataHelper.GetString(dr, "Remark");
            listBpo.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listBpo;
    }

    public class FillOccupation : List<BpoDM.FillOccupationDM>
    {
    }
    [OperationContract]
    public FillOccupation FillOccupationDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillOccupation listOcc = new FillOccupation();
        while (dr.Read())
        {
            var item = new BpoDM.FillOccupationDM();
            item.OccupationId = Education.DataHelper.GetInt(dr, "OccupationId");
            item.OccupationName = Education.DataHelper.GetString(dr, "OccupationName");
            listOcc.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOcc;
    }


    public class FillFroward : List<BpoDM.FillForwardDM>
    {
    }
    [OperationContract]
    public FillFroward FillForwardDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillFroward listForward = new FillFroward();
        while (dr.Read())
        {
            var item = new BpoDM.FillForwardDM();
            item.EmployeeID = Education.DataHelper.GetInt(dr, "EmployeeID");
            item.EName = Education.DataHelper.GetString(dr, "EName");
            listForward.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listForward;
    }


    public class FillQualification : List<BpoDM.FillQualDM>
    {
    }
    [OperationContract]
    public FillQualification FillQualDDL(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        //objDB.AddParameters(0, "uname", uname, DbType.String);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        FillQualification listQual = new FillQualification();
        while (dr.Read())
        {
            var item = new BpoDM.FillQualDM();
            item.ProfId = Education.DataHelper.GetInt(dr, "ProfId");
            item.ProfName = Education.DataHelper.GetString(dr, "ProfName");
            listQual.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listQual;
    }


    public DataTable FillDsBpoVw(string uname, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "uname", uname, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillBpoDetail(string regno, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "regno", regno, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillDocument(int CounsellingID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CounsellingID", CounsellingID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillDocumentNot(int courseid, string documentid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "documentid", documentid, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillStudentEcVw(int CounsellingID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CounsellingID", CounsellingID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillStudentCounsel(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillDemandFeeNotice(string id_student, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "id_student", id_student, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillDocumentMaster(int courseid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        //objDB.AddParameters(0, "Doc_Purpose", Doc_Purpose, DbType.String);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillCourseFeeStruc(int courseid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        //objDB.AddParameters(0, "Doc_Purpose", Doc_Purpose, DbType.String);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillStudentEP(string bpoid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "bpoid", bpoid, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillImgT(string memID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "memID", memID, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillStudentEcDt(string gen, string bpoid, string ProfId,int CounsellingID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "gen", gen, DbType.String);
        objDB.AddParameters(1, "bpoid", bpoid, DbType.String);
        objDB.AddParameters(2, "ProfId", ProfId, DbType.String);
        objDB.AddParameters(3, "CounsellingID", CounsellingID, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillProfileSubjectDt(string gen, string bpoid, string ProfId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "gen", gen, DbType.String);
        objDB.AddParameters(1, "bpoid", bpoid, DbType.String);
        objDB.AddParameters(2, "ProfId", ProfId, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillStudentEPassed(string bpoid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "bpoid", bpoid, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }



    public class FillProfileSubject : List<BpoDM.FillProfileSubDM>
    {
    }
    [OperationContract]
    public FillProfileSubject FillProfileSub(string ProfId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "ProfId", ProfId, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillProfileSubject listProfile = new FillProfileSubject();
        while (dr.Read())
        {
            var item = new BpoDM.FillProfileSubDM();
            item.Subject = Education.DataHelper.GetString(dr, "Subject");
            item.MM = Education.DataHelper.GetString(dr, "MM");
            item.MO = Education.DataHelper.GetString(dr, "MO");
            item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
            item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
            item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
            item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
            item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
            listProfile.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listProfile;
    }


    public class FillSubjectGV : List<BpoDM.FillSubjectDM>
    {
    }
    [OperationContract]
    public FillSubjectGV FillSubject(string ProfId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "ProfId", ProfId, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillSubjectGV listSubject = new FillSubjectGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillSubjectDM();
            item.Subject = Education.DataHelper.GetString(dr, "Subject");
            item.MM = Education.DataHelper.GetString(dr, "MM");
            item.MO = Education.DataHelper.GetString(dr, "MO");
            listSubject.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listSubject;
    }


    public class FillFeeDetailPGV : List<BpoDM.FillFeeDetailDM>
    {
    }
    [OperationContract]
    public FillFeeDetailPGV FillFeeDetailP(int Courseid,string Category)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Courseid", Courseid, DbType.Int32);
        objDB.AddParameters(1, "Category", Category, DbType.String);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentFee_BPO");
        FillFeeDetailPGV listDetail = new FillFeeDetailPGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillFeeDetailDM();
            item.FeeHeadID = Education.DataHelper.GetInt(dr, "FeeHeadID");
            item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
            item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.breakOffTime = Education.DataHelper.GetString(dr, "breakOffTime");
            item.LastDate = Education.DataHelper.GetDateTime(dr, "LastDate");
            item.courseFeeid = Education.DataHelper.GetInt(dr, "courseFeeid");
            item.advance = Education.DataHelper.GetString(dr, "advance");
            item.FeeDetailID = Education.DataHelper.GetInt (dr, "FeeDetailID");
            listDetail.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listDetail;
    }

    [OperationContract]
    public FillFeeDetailPGV FillFeeDetailP(int Courseid, string Category, FillFeeDetailPGV objList)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Courseid", Courseid, DbType.Int32);
        objDB.AddParameters(1, "Category", Category, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentFee_BPO");
       while (dr.Read())
        {
            var item = new BpoDM.FillFeeDetailDM();
            item.FeeHeadID = Education.DataHelper.GetInt(dr, "FeeHeadID");
            item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
            item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.breakOffTime = Education.DataHelper.GetString(dr, "breakOffTime");
            item.LastDate = Education.DataHelper.GetDateTime(dr, "LastDate");
            item.courseFeeid = Education.DataHelper.GetInt(dr, "courseFeeid");
            item.advance = Education.DataHelper.GetString(dr, "advance");
            item.FeeDetailID = Education.DataHelper.GetInt(dr, "FeeDetailID");
            objList.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return objList;
    }

    [OperationContract]
    public FillFeeDetailPGV FillFeeDetailP(int CouncellingID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "CouncellingID", CouncellingID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentFeeApplied_BPO");
        FillFeeDetailPGV listDetail = new FillFeeDetailPGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillFeeDetailDM();
            item.FeeHeadID = Education.DataHelper.GetInt(dr, "FeeHeadID");
            item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
            item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.breakOffTime = Education.DataHelper.GetString(dr, "breakOffTime");
            item.LastDate = Education.DataHelper.GetDateTime(dr, "LastDate");
            item.courseFeeid = Education.DataHelper.GetInt(dr, "courseFeeid");
            item.advance = Education.DataHelper.GetString(dr, "advance");
            item.FeeDetailID = Education.DataHelper.GetInt(dr, "FeeDetailID");
            listDetail.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listDetail;
    }  


    public class FillPagingBpoVwGV : List<BpoDM.FillPagingBpoVwDM>
    {
    }
    [OperationContract]
    public FillPagingBpoVwGV FillPagingBpoVw(string Uname, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Uname", Uname, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillPagingBpoVwGV listPaging = new FillPagingBpoVwGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillPagingBpoVwDM();
            item.RegNo = Education.DataHelper.GetInt (dr, "RegNo");
            item.Forward_To = Education.DataHelper.GetString(dr, "Forward_To");
            item.DateApplied = Education.DataHelper.GetString(dr, "DateApplied");
            item.Earlier_Ref = Education.DataHelper.GetString(dr, "Earlier_Ref");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.Course = Education.DataHelper.GetString(dr, "Course");
            item.UName = Education.DataHelper.GetString(dr, "UName");
            item.ForwardTo = Education.DataHelper.GetString(dr, "ForwardTo");
            listPaging.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listPaging;
    }

    [OperationContract]
    public FillPagingBpoVwGV FillPagingBpoVwForDocProcessing(string Query)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, Query);
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillPagingBpoVwGV listPaging = new FillPagingBpoVwGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillPagingBpoVwDM();
            item.RegNo = Education.DataHelper.GetInt(dr, "RegNo");
            item.Forward_To = Education.DataHelper.GetString(dr, "Forward_To");
            item.DateApplied = Education.DataHelper.GetString(dr, "DateApplied");
            item.Earlier_Ref = Education.DataHelper.GetString(dr, "Earlier_Ref");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.Course = Education.DataHelper.GetString(dr, "Course");
            item.UName = Education.DataHelper.GetString(dr, "UName");
            listPaging.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listPaging;
    }

    //[OperationContract]
    //public FillPagingBpoVwGV FillPagingGridStudentAdp()
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(1);       
    //    objDB.AddParameters(1, "flag", 17, DbType.Int32);
    //    IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
    //    FillPagingBpoVwGV listPaging = new FillPagingBpoVwGV();
    //    while (dr.Read())
    //    {
    //        var item = new BpoDM.FillPagingBpoVwDM();
    //        item.RegNo = Education.DataHelper.GetInt(dr, "RegNo");
    //        item.Forward_To = Education.DataHelper.GetString(dr, "Forward_To");
    //        item.DateApplied = Education.DataHelper.GetString(dr, "DateApplied");
    //        item.Earlier_Ref = Education.DataHelper.GetString(dr, "Earlier_Ref");
    //        item.Name = Education.DataHelper.GetString(dr, "Name");
    //        item.Course = Education.DataHelper.GetString(dr, "Course");
    //        item.UName = Education.DataHelper.GetString(dr, "UName");
    //        listPaging.Add(item);
    //    }
    //    objDB.DataReader.Close();
    //    objDB.Connection.Close();
    //    objDB = null;
    //    return listPaging;
    //}


    public class FillFeeDetailGV : List<BpoDM.FillDocumentDetailDM>
    {
    }
    [OperationContract]
    public FillFeeDetailGV FillFeeDetail(int courseid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillFeeDetailGV listDetail = new FillFeeDetailGV();
        while (dr.Read())
        {
            var item = new BpoDM.FillDocumentDetailDM();
            item.DocumentID = Education.DataHelper.GetInt(dr, "DocumentID");
            item.course = Education.DataHelper.GetInt(dr, "course");
            item.Document_Name = Education.DataHelper.GetString(dr, "Document_Name");
            item.Doc_Code = Education.DataHelper.GetString(dr, "Doc_Code");
            item.Doc_Purpose = Education.DataHelper.GetString(dr, "Doc_Purpose");
            item.Status = Education.DataHelper.GetString(dr, "Status");
            item.Doc_Category = Education.DataHelper.GetString(dr, "Doc_Category");
            item.Doc_Level = Education.DataHelper.GetString(dr, "Doc_Level");
            listDetail.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listDetail;
    }


    [OperationContract]
    public string InsertStudentEPassed(List<BpoDM.StudentEPassed> objSEP, BpoDM.BpoInsert objBI , Admin.AdministratorData.AuditDM audit)
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
            foreach (BpoDM.StudentEPassed std in objSEP)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "BPOID", std.BPOID, DbType.String);
                objDB.AddParameters(1, "CouncellingID", std.CouncellingID, DbType.String);
                objDB.AddParameters(2, "Exam_passed", std.Exam_passed, DbType.String);
                objDB.AddParameters(3, "Subjects", std.Subjects, DbType.String);
                objDB.AddParameters(4, "MaxMarks", std.MaxMarks, DbType.String);
                objDB.AddParameters(5, "MinMarks", std.MinMarks, DbType.String);
                objDB.AddParameters(6, "Gross_Per", std.Gross_Per, DbType.String);
                objDB.AddParameters(7, "Qual_year", std.Qual_year, DbType.String);
                objDB.AddParameters(8, "IsCalculated", std.IsCalculated, DbType.String);
                objDB.AddParameters(9, "UEndt", std.UEndt, DbType.DateTime);
                objDB.AddParameters(10, "Uentime", std.Uentime, DbType.String);
                objDB.AddParameters(11, "U_name", std.U_name, DbType.String);
                objDB.AddParameters(12, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentEpassedBPO_Insert");
            }


            objDB.CreateParameters(31);
            objDB.AddParameters(0, "RegNo", objBI.RegNo, DbType.Int32);
            objDB.AddParameters(1, "Fname", objBI.Fname, DbType.String);
            objDB.AddParameters(2, "Mname", objBI.Mname, DbType.String);
            objDB.AddParameters(3, "Lname", objBI.Lname, DbType.String);
            objDB.AddParameters(4, "Tno", objBI.Tno, DbType.String);
            objDB.AddParameters(5, "Mno", objBI.Mno, DbType.String);
            objDB.AddParameters(6, "Email", objBI.Email, DbType.String);
            objDB.AddParameters(7, "Address", objBI.Address, DbType.String);
            objDB.AddParameters(8, "City", objBI.City, DbType.String);
            objDB.AddParameters(9, "State", objBI.State, DbType.String);
            objDB.AddParameters(10, "Pincode", objBI.Pincode, DbType.String);
            objDB.AddParameters(11, "DateApplied", objBI.DateApplied, DbType.String);
            objDB.AddParameters(12, "TimeApplied", objBI.TimeApplied, DbType.String);
            objDB.AddParameters(13, "Course_applied", objBI.Course_applied, DbType.String);
            objDB.AddParameters(14, "Qualification", objBI.Qualification, DbType.String);
            objDB.AddParameters(15, "Qualified_Exam", objBI.Qualified_Exam, DbType.String);
            objDB.AddParameters(16, "Remark", objBI.Remark, DbType.String);
            objDB.AddParameters(17, "Forward_To", objBI.Forward_To, DbType.String);
            objDB.AddParameters(18, "Next_Date", objBI.Next_Date, DbType.String);
            objDB.AddParameters(19, "Ndate", objBI.Ndate, DbType.String);
            objDB.AddParameters(20, "Mode_Info", objBI.Mode_Info, DbType.String);
            objDB.AddParameters(21, "Earlier_Ref", objBI.Earlier_Ref, DbType.String);
            objDB.AddParameters(22, "flag", objBI.flag, DbType.String);
            objDB.AddParameters(23, "UName", objBI.UName, DbType.String);
            objDB.AddParameters(24, "gender", objBI.gender, DbType.String);
            objDB.AddParameters(25, "category", objBI.category, DbType.String);
            objDB.AddParameters(26, "totpercent", objBI.totpercent, DbType.Decimal);
            objDB.AddParameters(27, "allrank", objBI.allrank, DbType.Int32);
            objDB.AddParameters(28, "subrank", objBI.subrank, DbType.Int32);
            objDB.AddParameters(29, "iseeking", objBI.iseeking, DbType.String);
            objDB.AddParameters(30, "session", objBI.session, DbType.String);

            //objDB.AddParameters(30, "IsCalculated", objBI.IsCalculated, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "BPO_Insert");


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
            //if (objFDM.Flag == "N")
            //{
                retv = "Record saved.";
            //}
            //else if (objFDM.Flag == "U")
            //{
            //    retv = "Record Updated Successfully.";
            //}
            //else
            //{
            //    retv = "Record deleted Successfully.";
            //}
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
    public string InsertBpoInsert(BpoDM.BpoInsert objBI, Admin.AdministratorData.AuditDM audit)
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
                objDB.CreateParameters(31);
                objDB.AddParameters(0, "RegNo", objBI.RegNo, DbType.Int32);
                objDB.AddParameters(1, "Fname", objBI.Fname, DbType.String);
                objDB.AddParameters(2, "Mname", objBI.Mname, DbType.String);
                objDB.AddParameters(3, "Lname", objBI.Lname, DbType.String);
                objDB.AddParameters(4, "Tno", objBI.Tno, DbType.String);
                objDB.AddParameters(5, "Mno", objBI.Mno, DbType.String);
                objDB.AddParameters(6, "Email", objBI.Email, DbType.String);
                objDB.AddParameters(7, "Address", objBI.Address, DbType.String);
                objDB.AddParameters(8, "City", objBI.City, DbType.String);
                objDB.AddParameters(9, "State", objBI.State, DbType.String);
                objDB.AddParameters(10, "Pincode", objBI.Pincode, DbType.String);
                objDB.AddParameters(11, "DateApplied", objBI.DateApplied, DbType.String);
                objDB.AddParameters(12, "TimeApplied", objBI.TimeApplied, DbType.String);
                objDB.AddParameters(13, "Course_applied", objBI.Course_applied, DbType.String);
                objDB.AddParameters(14, "Qualification", objBI.Qualification, DbType.String);
                objDB.AddParameters(15, "Qualified_Exam", objBI.Qualified_Exam, DbType.String);
                objDB.AddParameters(16, "Remark", objBI.Remark, DbType.String);
                objDB.AddParameters(17, "Forward_To", objBI.Forward_To, DbType.String);
                objDB.AddParameters(18, "Next_Date", objBI.Next_Date, DbType.String);
                objDB.AddParameters(19, "Ndate", objBI.Ndate, DbType.String);
                objDB.AddParameters(20, "Mode_Info", objBI.Mode_Info, DbType.String);
                objDB.AddParameters(21, "Earlier_Ref", objBI.Earlier_Ref, DbType.String);
                objDB.AddParameters(22, "flag", objBI.flag, DbType.String);
                objDB.AddParameters(23, "UName", objBI.UName, DbType.String);
                objDB.AddParameters(24, "gender", objBI.gender, DbType.String);
                objDB.AddParameters(25, "category", objBI.category, DbType.String);
                objDB.AddParameters(26, "totpercent", objBI.totpercent, DbType.String);
                objDB.AddParameters(27, "allrank", objBI.allrank, DbType.String);
                objDB.AddParameters(28, "subrank", objBI.subrank, DbType.String);
                objDB.AddParameters(29, "iseeking", objBI.iseeking, DbType.String);
                objDB.AddParameters(30, "session", objBI.session, DbType.String);
           
                //objDB.AddParameters(30, "IsCalculated", objBI.IsCalculated, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "BPO_Insert");

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
            //if (objFDM.Flag == "N")
            //{
            retv = "Record saved.";
            //}
            //else if (objFDM.Flag == "U")
            //{
            //    retv = "Record Updated Successfully.";
            //}
            //else
            //{
            //    retv = "Record deleted Successfully.";
            //}
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
    public BpoDM.StudentCouncDetailDM GetStudentByCouncellingID(int CouncellingID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CounsellingID", CouncellingID, DbType.Int32 );
        objDB.AddParameters(1, "flag", 17, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        var item = new BpoDM.StudentCouncDetailDM();
        try
        {
            if (dr.Read())
            {
                item.CounsellingID = Education.DataHelper.GetInt(dr, "CounsellingID");
                item.Category = Education.DataHelper.GetString(dr, "Category");
                item.CollegeID = Education.DataHelper.GetString(dr, "CollegeID");
                item.FatherNamePrefix = Education.DataHelper.GetString(dr, "FatherNamePrefix");
                item.ReligionCode = Education.DataHelper.GetString(dr, "ReligionCode");
                item.NationalityCode = Education.DataHelper.GetString(dr, "NationalityCode");
                item.Sex = Education.DataHelper.GetString(dr, "Sex");
                item.StudentNamePrefix = Education.DataHelper.GetString(dr, "StudentNamePrefix");
                item.ParentOccCode = Education.DataHelper.GetString(dr, "ParentOccCode");
                item.CCategory = Education.DataHelper.GetString(dr, "CCategory");
                item.InstituteID = Education.DataHelper.GetString(dr, "InstituteID");
                item.CourseCode = Education.DataHelper.GetString(dr, "CourseCode");
                item.PCityCode = Education.DataHelper.GetInt(dr, "PCityCode");
                item.CCityCode = Education.DataHelper.GetInt(dr, "CCityCode");
                item.LCityCode = Education.DataHelper.GetInt(dr, "LCityCode");
                item.MotherName = Education.DataHelper.GetString(dr, "MotherName");
                item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
                item.MName = Education.DataHelper.GetString(dr, "MName");
                item.LName = Education.DataHelper.GetString(dr, "LName");
                item.PAdd1 = Education.DataHelper.GetString(dr, "PAdd1");
                item.PAdd2 = Education.DataHelper.GetString(dr, "PAdd2");
                item.PAdd3 = Education.DataHelper.GetString(dr, "PAdd3");
                item.PMobileNo = Education.DataHelper.GetString(dr, "PMobileNo");
                item.PPhoneNo = Education.DataHelper.GetString(dr, "PPhoneNo");
                item.PPinCode = Education.DataHelper.GetString(dr, "PPinCode");

                item.CouncellingDate = Education.DataHelper.GetString(dr, "CounsellingDate");
                item.StudentRelation = Education.DataHelper.GetString(dr, "StudentRelation");
                item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
                item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
                item.AnnualIncome = Education.DataHelper.GetDecimal(dr, "AnnualIncome");
                item.CAdd1 = Education.DataHelper.GetString(dr, "CAdd1");
                item.CAdd2 = Education.DataHelper.GetString(dr, "CAdd2");
                item.CAdd3 = Education.DataHelper.GetString(dr, "CAdd3");
                item.CMobileNo = Education.DataHelper.GetString(dr, "CMobileNo");
                item.CPhoneNo = Education.DataHelper.GetString(dr, "CPhoneNo");
                item.CPinCode = Education.DataHelper.GetString(dr, "CPinCode");
                item.DOB = Education.DataHelper.GetString(dr, "DOB");
                item.EMail = Education.DataHelper.GetString(dr, "EMail");
                item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
                item.GuardianName = Education.DataHelper.GetString(dr, "GuardianName");
                item.LAdd1 = Education.DataHelper.GetString(dr, "LAdd1");
                item.LAdd2 = Education.DataHelper.GetString(dr, "LAdd2");
                item.LAdd3 = Education.DataHelper.GetString(dr, "LAdd3");
                item.LMobileNo = Education.DataHelper.GetString(dr, "LMobileNo");
                item.LPhoneNo = Education.DataHelper.GetString(dr, "LPhoneNo");
                item.LPinCode = Education.DataHelper.GetString(dr, "LPinCode");
                item.IdentityMark = Education.DataHelper.GetString(dr, "IdentityMark");
                item.ForwardTo_Dp = Education.DataHelper.GetString(dr, "ForwardTo_Dp");
                item.ForwardTo_Ap = Education.DataHelper.GetString(dr, "ForwardTo_Ap");
                item.Last_Qualification = Education.DataHelper.GetString(dr, "Last_Qualification");
                item.Rank_Category = Education.DataHelper.GetString(dr, "Rank_Category");
                item.Rank_Overall = Education.DataHelper.GetString(dr, "Rank_Overall");
                item.Total_Per = Education.DataHelper.GetString(dr, "Total_Per");
                item.Entrance_Qual = Education.DataHelper.GetString(dr, "Entrance_Qual");
                item.RegistrationNo = Education.DataHelper.GetString(dr, "RegistrationNo");
                item.ImagePath = Education.DataHelper.GetBytes(dr, "ImagePath");//Coun_Comment
                item.Coun_Comment = Education.DataHelper.GetString(dr, "Coun_Comment");
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return item;
    }

    [OperationContract]
    public BpoDM.StudentCouncDetailDM GetStudentByCouncellingIDForDprocessing(int CouncellingID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CounsellingID", CouncellingID, DbType.Int32);
        objDB.AddParameters(1, "flag", 17, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        var item = new BpoDM.StudentCouncDetailDM();
        if (dr.Read())
        {
            item.CounsellingID = Education.DataHelper.GetInt(dr, "CounsellingID");
            item.Category = Education.DataHelper.GetString(dr, "Category");
            item.CollegeID = Education.DataHelper.GetString(dr, "CollegeID");
            item.FatherNamePrefix = Education.DataHelper.GetString(dr, "FatherNamePrefix");
            item.ReligionCode = Education.DataHelper.GetString(dr, "ReligionCode");
            item.NationalityCode = Education.DataHelper.GetString(dr, "NationalityCode");
            item.Sex = Education.DataHelper.GetString(dr, "Sex");
            item.StudentNamePrefix = Education.DataHelper.GetString(dr, "StudentNamePrefix");
            item.ParentOccCode = Education.DataHelper.GetString(dr, "ParentOccCode");
            item.CCategory = Education.DataHelper.GetString(dr, "CCategory");
            item.InstituteID = Education.DataHelper.GetString(dr, "InstituteID");
            item.CourseCode = Education.DataHelper.GetString(dr, "CourseCode");
            item.PCityCode = Education.DataHelper.GetInt(dr, "PCityCode");
            item.CCityCode = Education.DataHelper.GetInt(dr, "CCityCode");
            item.LCityCode = Education.DataHelper.GetInt(dr, "LCityCode");
            item.MotherName = Education.DataHelper.GetString(dr, "MotherName");
            item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
            item.MName = Education.DataHelper.GetString(dr, "MName");
            item.LName = Education.DataHelper.GetString(dr, "LName");
            item.PAdd1 = Education.DataHelper.GetString(dr, "PAdd1");
            item.PAdd2 = Education.DataHelper.GetString(dr, "PAdd2");
            item.PAdd3 = Education.DataHelper.GetString(dr, "PAdd3");
            item.PMobileNo = Education.DataHelper.GetString(dr, "PMobileNo");
            item.PPhoneNo = Education.DataHelper.GetString(dr, "PPhoneNo");
            item.PPinCode = Education.DataHelper.GetString(dr, "PPinCode");

            item.CouncellingDate = Education.DataHelper.GetString(dr, "CounsellingDate");
            item.StudentRelation = Education.DataHelper.GetString(dr, "StudentRelation");
            item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            item.AnnualIncome = Education.DataHelper.GetDecimal(dr, "AnnualIncome");
            item.CAdd1 = Education.DataHelper.GetString(dr, "CAdd1");
            item.CAdd2 = Education.DataHelper.GetString(dr, "CAdd2");
            item.CAdd3 = Education.DataHelper.GetString(dr, "CAdd3");
            item.CMobileNo = Education.DataHelper.GetString(dr, "CMobileNo");
            item.CPhoneNo = Education.DataHelper.GetString(dr, "CPhoneNo");
            item.CPinCode = Education.DataHelper.GetString(dr, "CPinCode");
            item.DOB = Education.DataHelper.GetString(dr, "DOB");
            item.EMail = Education.DataHelper.GetString(dr, "EMail");
            item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
            item.GuardianName = Education.DataHelper.GetString(dr, "GuardianName");
            item.LAdd1 = Education.DataHelper.GetString(dr, "LAdd1");
            item.LAdd2 = Education.DataHelper.GetString(dr, "LAdd2");
            item.LAdd3 = Education.DataHelper.GetString(dr, "LAdd3");
            item.LMobileNo = Education.DataHelper.GetString(dr, "LMobileNo");
            item.LPhoneNo = Education.DataHelper.GetString(dr, "LPhoneNo");
            item.LPinCode = Education.DataHelper.GetString(dr, "LPinCode");
            item.IdentityMark = Education.DataHelper.GetString(dr, "IdentityMark");
            item.ForwardTo_Dp = Education.DataHelper.GetString(dr, "ForwardTo_Dp");
            item.ForwardTo_Ap = Education.DataHelper.GetString(dr, "ForwardTo_Ap");
            item.Last_Qualification = Education.DataHelper.GetString(dr, "Last_Qualification");
            item.Rank_Category = Education.DataHelper.GetString(dr, "Rank_Category");
            item.Rank_Overall = Education.DataHelper.GetString(dr, "Rank_Overall");
            item.Total_Per = Education.DataHelper.GetString(dr, "Total_Per");
            item.Entrance_Qual = Education.DataHelper.GetString(dr, "Entrance_Qual");
            item.RegistrationNo = Education.DataHelper.GetString(dr, "RegistrationNo");
            item.ImagePath = Education.DataHelper.GetBytes(dr, "ImagePath");//Coun_Comment
            item.Coun_Comment = Education.DataHelper.GetString(dr, "Coun_Comment");
        }
        return item;
    }
  [OperationContract]
    public List<BpoDM.FillBpoDM>FillBpoDetail(int regno, string Session, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);        
        objDB.AddParameters(0, "regno", regno, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        objDB.AddParameters(2, "session",Session, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select");
        var listOfDocument = new List<BpoDM.FillBpoDM>();
        while (dr.Read())
        {
          
            var item = new BpoDM.FillBpoDM();
            item.name = Education.DataHelper.GetString(dr, "name");
            item.Tno = Education.DataHelper.GetString(dr, "Tno");
            item.Mno = Education.DataHelper.GetString(dr, "Mno");
            item.Address   = Education.DataHelper.GetString(dr, "Address");
            item.City  = Education.DataHelper.GetString(dr, "City");
            item.Pincode  = Education.DataHelper.GetString(dr, "Pincode");
            item.StateName = Education.DataHelper.GetString(dr, "StateName");
            item.Course_Applied = Education.DataHelper.GetString(dr, "Course_Applied");            
            item.DateApplied = Education.DataHelper.GetString(dr, "DateApplied");
            item.Email = Education.DataHelper.GetString(dr, "Email");
            item.Qualification = Education.DataHelper.GetString(dr, "Qualification");
            item.Qualified_Exam = Education.DataHelper.GetString(dr, "Qualified_Exam");
            item.Remark = Education.DataHelper.GetString(dr, "Remark");
            item.Forward_To = Education.DataHelper.GetString(dr, "Forward_To");
            item.Next_Date = Education.DataHelper.GetString(dr, "Next_Date");
            item.Ndate = Education.DataHelper.GetString(dr, "Ndate");
            item.gender = Education.DataHelper.GetString(dr, "gender");
            item.Mode_Info = Education.DataHelper.GetString(dr, "Mode_Info");
            item.category = Education.DataHelper.GetString(dr, "category");
            item.RegNo = Education.DataHelper.GetInt(dr, "RegNo");
            item.iseeking = Education.DataHelper.GetString(dr, "iseeking");
            item.Earlier_Ref = Education.DataHelper.GetString(dr, "Earlier_Ref");
            item.StateId = Education.DataHelper.GetString(dr, "StateId");
            item.allrank = Education.DataHelper.GetString(dr, "allrank");
            item.subrank = Education.DataHelper.GetString(dr, "subrank");
            item.totpercent = Education.DataHelper.GetDecimal(dr, "totpercent");
            item.CityId = Education.DataHelper.GetString(dr, "CityId");  
            
            listOfDocument.Add(item);
        }
        dr.Close();
        dr.Dispose();
        objDB.Connection.Close();
        return listOfDocument;
    }

    [OperationContract]
    public List< BpoDM.StudentDocForAP> FillStudentDocByCouncellingID(string CouncellingID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "CouncellingID", CouncellingID, DbType.String );
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentDoc_Councelling");
        var retitem = new List<BpoDM.StudentDocForAP>();
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentDocForAP();
                item.Doc_Serial = Education.DataHelper.GetString(dr, "Doc_Serial");
                item.Document_Name = Education.DataHelper.GetString(dr, "Document_Name");
                item.DocumentID = Education.DataHelper.GetInt(dr, "DocumentID");
                item.Flag = Education.DataHelper.GetString(dr, "Flag");
                item.Is_original = Education.DataHelper.GetString(dr, "Is_original");
                item.Is_Submitted = Education.DataHelper.GetString(dr, "Is_Submitted");
                item.PassingYr = Education.DataHelper.GetString(dr, "PassingYr");
                item.Percentage = Education.DataHelper.GetString(dr, "Percentage");
                item.Remark = Education.DataHelper.GetString(dr, "Remark");
                item.Total_Marks = Education.DataHelper.GetString(dr, "Total_Marks");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract]
    public List<BpoDM.StudentDocForAP> FillStudentDocNSByCouncellingID(string Query, List<BpoDM.StudentDocForAP> retitem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text ,Query  );
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentDocForAP();
                item.Doc_Serial = Education.DataHelper.GetString(dr, "Doc_Serial");
                item.Document_Name = Education.DataHelper.GetString(dr, "Document_Name");
                item.DocumentID = Education.DataHelper.GetInt(dr, "DocumentID");
                item.Flag = Education.DataHelper.GetString(dr, "Flag");
                item.Is_original = Education.DataHelper.GetString(dr, "Is_original");
                item.Is_Submitted = Education.DataHelper.GetString(dr, "Is_Submitted");
                item.PassingYr = Education.DataHelper.GetString(dr, "PassingYr");
                item.Percentage = Education.DataHelper.GetString(dr, "Percentage");
                item.Remark = Education.DataHelper.GetString(dr, "Remark");
                item.Total_Marks = Education.DataHelper.GetString(dr, "Total_Marks");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract]
    public List<BpoDM.StudentEqualificationForAP> FillStudentEQualification(string CouncellingID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "CouncellingID", CouncellingID, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentEqualification");
        var retitem = new List<BpoDM.StudentEqualificationForAP>();
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentEqualificationForAP();
                item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
                item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
                item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Subject = Education.DataHelper.GetString(dr, "Subject");
                item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }



    [OperationContract]
    public List<BpoDM.StudentEqualificationForAP> FillStudentEQualificationAP(int CouncellingID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "CouncellingID", CouncellingID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillStudentEqualificationAP");
        var retitem = new List<BpoDM.StudentEqualificationForAP>();
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentEqualificationForAP();
                item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
                item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
                item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Subject = Education.DataHelper.GetString(dr, "Subject");
                item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }


    [OperationContract]
    public List<BpoDM.StudentEqualificationForAP> FillStudentEQualificationNS(string Query, List<BpoDM.StudentEqualificationForAP> retitem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, Query);
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentEqualificationForAP();
                item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
                item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
                item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Subject = Education.DataHelper.GetString(dr, "Subject");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract]
    public BpoDM.BpoInsert  GetBPODetailByBPOID(int BPOID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "RegNo", BPOID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text , "select * from bpo_vw where regno=@regno");
        var item = new BpoDM.BpoInsert();
        try
        {
            if (dr.Read())
            {
                item.Remark = Education.DataHelper.GetString(dr, "Remark");
                item.Fname = Education.DataHelper.GetString(dr, "Fname");
                item.Mname = Education.DataHelper.GetString(dr, "Mname");
                item.Lname = Education.DataHelper.GetString(dr, "Lname");
                item.Tno = Education.DataHelper.GetString(dr, "Tno");
                item.Mno = Education.DataHelper.GetString(dr, "Mno");
                item.Address = Education.DataHelper.GetString(dr, "Address");
                item.Pincode = Education.DataHelper.GetString(dr, "Pincode");
                item.City = Education.DataHelper.GetString(dr, "Cityid");
                item.State = Education.DataHelper.GetString(dr, "StateId");
                item.Course_applied = Education.DataHelper.GetString(dr, "Course_applied");
                item.Qualification = Education.DataHelper.GetString(dr, "Qualification");
                item.Qualified_Exam = Education.DataHelper.GetString(dr, "Qualified_Exam");
                item.gender = Education.DataHelper.GetString(dr, "gender");
                item.category = Education.DataHelper.GetString(dr, "category");
                item.totpercent = Education.DataHelper.GetDecimal(dr, "totpercent");
                item.allrank = Education.DataHelper.GetString(dr, "allrank");
                item.subrank = Education.DataHelper.GetString(dr, "subrank");
                item.Earlier_Ref = Education.DataHelper.GetString(dr, "Earlier_Ref");
                item.Email = Education.DataHelper.GetString(dr, "Email");
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return item;
    }

    [OperationContract]
    public List<BpoDM.StudentEqualificationForAP> FillStudentEPByBPOID(string BPOID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "BPOID", BPOID, DbType.String);
       // IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Student_EP_vw where bpoid=@BPOID");
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select Gross_per,IsCalculated,MO,Subject,cast(Profid as nvarchar)as ProfileID,CouncellingID,BPOID from Student_EP_vw where bpoid='"+ BPOID +"'");
        var retitem = new List<BpoDM.StudentEqualificationForAP>();
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentEqualificationForAP();
                //item.Subject = Education.DataHelper.GetString(dr, "Subject");
                //item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
                item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
                item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Subject = Education.DataHelper.GetString(dr, "Subject");
                item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }
    [OperationContract]
    public List<BpoDM.StudentEqualificationForAP> FillStudentEPByBPOIDNS(string Query, List<BpoDM.StudentEqualificationForAP> retitem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, Query);
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentEqualificationForAP();
                item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
                item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
                item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Subject = Education.DataHelper.GetString(dr, "Subject");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertStudentCouncellingDetail(BpoDM.StudentCouncellingMDM StudentM, List<BpoDM.CouncellingDetailCDM> studentDM,  List<BpoDM.CouncellingExamPassedDM> SQDM, List<BpoDM.CouncellingStudentDocDM> SDDM, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(78);
            objDB.AddParameters(0, "CounsellingID", StudentM.CounsellingID, DbType.Int32);
            objDB.AddParameters(1, "RegistrationNo", StudentM.RegistrationNo, DbType.String);
            objDB.AddParameters(2, "CounsellingDate", StudentM.CounsellingDate, DbType.String);
            objDB.AddParameters(3, "SessionCode", StudentM.SessionCode, DbType.String);
            objDB.AddParameters(4, "CourseCode", StudentM.CourseCode, DbType.String);
            objDB.AddParameters(5, "StudentNamePrefix", StudentM.StudentNamePrefix, DbType.String);
            objDB.AddParameters(6, "StudentName", StudentM.StudentName, DbType.String);
            objDB.AddParameters(7, "ID_Student", StudentM.ID_Student, DbType.String);
            objDB.AddParameters(8, "ImagePath", StudentM.ImagePath, DbType.Binary);
            objDB.AddParameters(9, "IdentityMark", StudentM.IdentityMark, DbType.String);
            objDB.AddParameters(10, "FatherNamePrefix", StudentM.FatherNamePrefix, DbType.String);
            objDB.AddParameters(11, "FatherName", StudentM.FatherName, DbType.String);
            objDB.AddParameters(12, "ParentOccCode", StudentM.ParentOccCode, DbType.String);
            objDB.AddParameters(13, "MotherNamePrefix", StudentM.MotherNamePrefix, DbType.String);
            objDB.AddParameters(14, "MotherName", StudentM.MotherName, DbType.String);
            objDB.AddParameters(15, "DOB", StudentM.DOB, DbType.String);
            objDB.AddParameters(16, "Category", StudentM.Category, DbType.String);
            objDB.AddParameters(17, "Sex", StudentM.Sex, DbType.String);
            objDB.AddParameters(18, "ReligionCode", StudentM.ReligionCode, DbType.String);
            objDB.AddParameters(19, "NationalityCode", StudentM.NationalityCode, DbType.String);
            objDB.AddParameters(20, "GuardianNamePrefix", StudentM.GuardianNamePrefix, DbType.String);
            objDB.AddParameters(21, "GuardianName", StudentM.GuardianName, DbType.String);
            objDB.AddParameters(22, "GuardianOccCode", StudentM.GuardianOccCode, DbType.String);
            objDB.AddParameters(23, "StudentRelation", StudentM.StudentRelation, DbType.String);
            objDB.AddParameters(24, "AnnualIncome", StudentM.AnnualIncome, DbType.Decimal);
            objDB.AddParameters(25, "DocumentCode", StudentM.DocumentCode, DbType.Int32);
            objDB.AddParameters(26, "LAdd1", StudentM.LAdd1, DbType.String);
            objDB.AddParameters(27, "LAdd2", StudentM.LAdd2, DbType.String);
            objDB.AddParameters(28, "LAdd3", StudentM.LAdd3, DbType.String);
            objDB.AddParameters(29, "LCityCode", StudentM.LCityCode, DbType.Int32);
            objDB.AddParameters(30, "LPinCode", StudentM.LPinCode, DbType.String);
            objDB.AddParameters(31, "LPhoneNo", StudentM.LPhoneNo, DbType.String);
            objDB.AddParameters(32, "LMobileNo", StudentM.LMobileNo, DbType.String);
            objDB.AddParameters(33, "EMail", StudentM.EMail, DbType.String);
            objDB.AddParameters(34, "PAdd1", StudentM.PAdd1, DbType.String);
            objDB.AddParameters(35, "PAdd2", StudentM.PAdd2, DbType.String);
            objDB.AddParameters(36, "PAdd3", StudentM.PAdd3, DbType.String);
            objDB.AddParameters(37, "PCityCode", StudentM.PCityCode, DbType.Int32);
            objDB.AddParameters(38, "PPinCode", StudentM.PPinCode, DbType.String);
            objDB.AddParameters(39, "PPhoneNo", StudentM.PPhoneNo, DbType.String);
            objDB.AddParameters(40, "PMobileNo", StudentM.PMobileNo, DbType.String);
            objDB.AddParameters(41, "CAdd1", StudentM.CAdd1, DbType.String);
            objDB.AddParameters(42, "CAdd2", StudentM.CAdd2, DbType.String);
            objDB.AddParameters(43, "CAdd3", StudentM.CAdd3, DbType.String);
            objDB.AddParameters(44, "CCityCode", StudentM.CCityCode, DbType.Int32);
            objDB.AddParameters(45, "CPinCode", StudentM.CPinCode, DbType.String);
            objDB.AddParameters(46, "CPhoneNo", StudentM.CPhoneNo, DbType.String);
            objDB.AddParameters(47, "CMobileNo", StudentM.CMobileNo, DbType.String);
            objDB.AddParameters(48, "ModeCode", StudentM.ModeCode, DbType.String);
            objDB.AddParameters(49, "BloodGroup", StudentM.BloodGroup, DbType.String);
            objDB.AddParameters(50, "UName", StudentM.UName, DbType.String);
            objDB.AddParameters(51, "UEntDt", StudentM.UEntDt, DbType.DateTime);
            objDB.AddParameters(52, "RollNo", StudentM.RollNo, DbType.String);
            objDB.AddParameters(53, "BatchCode", StudentM.BatchCode, DbType.String);
            objDB.AddParameters(54, "CourseDescCode", StudentM.CourseDescCode, DbType.String);
            objDB.AddParameters(55, "EnrollmentNo", StudentM.EnrollmentNo, DbType.String);
            objDB.AddParameters(56, "PassOutDate", StudentM.PassOutDate, DbType.String);
            objDB.AddParameters(57, "InstituteID", StudentM.InstituteID, DbType.Int32);
            objDB.AddParameters(58, "SessionID", StudentM.SessionID, DbType.String);
            objDB.AddParameters(59, "MName", StudentM.MName, DbType.String);
            objDB.AddParameters(60, "LName", StudentM.LName, DbType.String);
            objDB.AddParameters(61, "CCategory", StudentM.CCategory, DbType.String);
            objDB.AddParameters(62, "Status", StudentM.Status, DbType.String);
            objDB.AddParameters(63, "Barcode", StudentM.Barcode, DbType.String);
            objDB.AddParameters(64, "Last_Qualification", StudentM.Last_Qualification, DbType.String);
            objDB.AddParameters(65, "Total_Per", StudentM.Total_Per, DbType.String);
            objDB.AddParameters(66, "Entrance_Qual", StudentM.Entrance_Qual, DbType.String);
            objDB.AddParameters(67, "Rank_Overall", StudentM.Rank_Overall, DbType.String);
            objDB.AddParameters(68, "Rank_Category", StudentM.Rank_Category, DbType.String);
            objDB.AddParameters(69, "ForwardTo_Ap", StudentM.ForwardTo_Ap, DbType.String);
            objDB.AddParameters(70, "ForwardTo_Dp", StudentM.ForwardTo_Dp, DbType.String);
            objDB.AddParameters(71, "Ap_Status", StudentM.Ap_Status, DbType.String);
            objDB.AddParameters(72, "DP_Status", StudentM.DP_Status, DbType.String);
            objDB.AddParameters(73, "Coun_Comment", StudentM.Coun_Comment, DbType.String);
            objDB.AddParameters(74, "CollegeID", StudentM.CollegeID, DbType.String);
            //objDB.AddParameters(75, "CouncellingID", StudentM.CouncellingID, DbType.String);

            objDB.AddParameters(75, "flag", StudentM.flag, DbType.String);
            objDB.AddParameters(76, "StudentIDreturn", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            objDB.AddParameters(77, "StudentCode", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            f = StudentM.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Councelling_Insert");
            Int32 sid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
            string scode = "";
            if (StudentM.flag == "U")
            {
                sid =Convert.ToInt32(StudentM.CounsellingID);
                scode = StudentM.RegistrationNo;
            }
            else
            {
                sid = Convert.ToInt32(StudentM.CounsellingID);
                scode = StudentM.RegistrationNo;
                    //objDB.Parameters[77].Value.ToString();
            }
        foreach (BpoDM.CouncellingDetailCDM  std in studentDM)
            {
                objDB.CreateParameters(18);
                objDB.AddParameters(0, "CouncellingID",std.CouncellingID, DbType.Int32);
                objDB.AddParameters(1, "SrNo", std.SrNo, DbType.Int32);
                objDB.AddParameters(2, "FeeHeadCode", std.FeeHeadCode, DbType.String);
                objDB.AddParameters(3, "TotalFeeAmount", std.TotalFeeAmount, DbType.Decimal);
                objDB.AddParameters(4, "BreakoffTime", std.BreakoffTime, DbType.String);
                objDB.AddParameters(5, "Amount", std.Amount, DbType.Decimal);
                objDB.AddParameters(6, "UName", std.UName, DbType.String);
                objDB.AddParameters(7, "UEntDt", std.UEntDt, DbType.DateTime);
                objDB.AddParameters(8, "DueDate", std.DueDate, DbType.DateTime);
                objDB.AddParameters(9, "PaidAmount", std.PaidAmount, DbType.Decimal);
                objDB.AddParameters(10, "BalAmount", std.BalAmount, DbType.Decimal);
                objDB.AddParameters(11, "ReFund", std.ReFund, DbType.Decimal);
                objDB.AddParameters(12, "Advance", std.Advance , DbType.Decimal);
                objDB.AddParameters(13, "CourseID", std.CourseID, DbType.Int32);
                objDB.AddParameters(14, "Session", std.Session, DbType.String);
                objDB.AddParameters(15, "Inst_ID", std.Inst_ID, DbType.Int32);
                objDB.AddParameters(16, "FeeSubID",std.FeeSubID, DbType.Int32);
                objDB.AddParameters(17, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Councelling_Detail_Insert");
            }
            foreach (BpoDM.CouncellingExamPassedDM std in SQDM)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "BPOID",std.BPOID, DbType.String);
                objDB.AddParameters(1, "CouncellingID", std.CouncellingID, DbType.String);
                objDB.AddParameters(2, "Exam_passed", std.Exam_passed , DbType.String);
                objDB.AddParameters(3, "Subjects", std.Subjects , DbType.String);
                objDB.AddParameters(4, "MaxMarks", std.MaxMarks, DbType.String);
                objDB.AddParameters(5, "MinMarks", std.MinMarks, DbType.String);
                objDB.AddParameters(6, "Gross_Per", std.Gross_Per, DbType.String);
                objDB.AddParameters(7, "Qual_year", std.Qual_year, DbType.String);//
                objDB.AddParameters(8, "IsCalculated", std.IsCalculated, DbType.String);
                objDB.AddParameters(9, "UEndt", std.UEndt, DbType.DateTime);
                objDB.AddParameters(10, "Uentime", std.UeTime, DbType.String);
                objDB.AddParameters(11, "U_name", std.U_Name, DbType.String);
                objDB.AddParameters(12, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_E_Passed_Insert");
            }
            foreach (BpoDM.CouncellingStudentDocDM std in SDDM)
            {
                objDB.CreateParameters(16);
                objDB.AddParameters(0, "CounsellingID",std.CounsellingID, DbType.String);
                objDB.AddParameters(1, "BPOID", std.BPOID, DbType.String);
                objDB.AddParameters(2, "StudentID", std.StudentID, DbType.String);
                objDB.AddParameters(3, "DocumentID", std.DocumentID, DbType.String);
                objDB.AddParameters(4, "Doc_Serial", std.Doc_Serial, DbType.String);
                objDB.AddParameters(5, "PassingYr", std.PassingYr, DbType.String);
                objDB.AddParameters(6, "Total_Marks", std.Total_Marks, DbType.String);
                objDB.AddParameters(7, "Percentage", std.Percentage, DbType.String);
                objDB.AddParameters(8, "Remark", std.Remark, DbType.String);
                objDB.AddParameters(9, "SessionID", std.SessionID, DbType.String);
                objDB.AddParameters(10, "InstituteID", std.InstituteID, DbType.String);
                objDB.AddParameters(11, "Is_original", std.Is_original, DbType.String);
                objDB.AddParameters(12, "Is_Submitted", std.Is_Submitted, DbType.String);
                objDB.AddParameters(13, "Councelling_Time", std.Councelling_Time, DbType.String);
                objDB.AddParameters(14, "Counselling_Date", std.Counselling_Date, DbType.String);
                objDB.AddParameters(15, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Documents_Insert");
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
    [OperationContract(IsOneWay = false)]
    public string InsertStudentADProcessingDetail(BpoDM.StudentCouncellingMDM StudentM, List<BpoDM.CouncellingDetailCDM> studentDM, List<BpoDM.CouncellingExamPassedDM> SQDM, List<BpoDM.CouncellingStudentDocDM> SDDM,BpoDM.StudentADProcessingDM  StudentADPM, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(78);
            objDB.AddParameters(0, "CounsellingID", StudentM.CounsellingID, DbType.Int32);
            objDB.AddParameters(1, "RegistrationNo", StudentM.RegistrationNo, DbType.String);
            objDB.AddParameters(2, "CounsellingDate", StudentM.CounsellingDate, DbType.DateTime);
            objDB.AddParameters(3, "SessionCode", StudentM.SessionCode, DbType.String);
            objDB.AddParameters(4, "CourseCode", StudentM.CourseCode, DbType.String);
            objDB.AddParameters(5, "StudentNamePrefix", StudentM.StudentNamePrefix, DbType.String);
            objDB.AddParameters(6, "StudentName", StudentM.StudentName, DbType.String);
            objDB.AddParameters(7, "ID_Student", StudentM.ID_Student, DbType.String);
            objDB.AddParameters(8, "ImagePath", StudentM.ImagePath, DbType.Binary);
            objDB.AddParameters(9, "IdentityMark", StudentM.IdentityMark, DbType.String);
            objDB.AddParameters(10, "FatherNamePrefix", StudentM.FatherNamePrefix, DbType.String);
            objDB.AddParameters(11, "FatherName", StudentM.FatherName, DbType.String);
            objDB.AddParameters(12, "ParentOccCode", StudentM.ParentOccCode, DbType.String);
            objDB.AddParameters(13, "MotherNamePrefix", StudentM.MotherNamePrefix, DbType.String);
            objDB.AddParameters(14, "MotherName", StudentM.MotherName, DbType.String);
            objDB.AddParameters(15, "DOB", StudentM.DOB, DbType.String);
            objDB.AddParameters(16, "Category", StudentM.Category, DbType.String);
            objDB.AddParameters(17, "Sex", StudentM.Sex, DbType.String);
            objDB.AddParameters(18, "ReligionCode", StudentM.ReligionCode, DbType.String);
            objDB.AddParameters(19, "NationalityCode", StudentM.NationalityCode, DbType.String);
            objDB.AddParameters(20, "GuardianNamePrefix", StudentM.GuardianNamePrefix, DbType.String);
            objDB.AddParameters(21, "GuardianName", StudentM.GuardianName, DbType.String);
            objDB.AddParameters(22, "GuardianOccCode", StudentM.GuardianOccCode, DbType.String);
            objDB.AddParameters(23, "StudentRelation", StudentM.StudentRelation, DbType.String);
            objDB.AddParameters(24, "AnnualIncome", StudentM.AnnualIncome, DbType.Decimal);
            objDB.AddParameters(25, "DocumentCode", StudentM.DocumentCode, DbType.Int32);
            objDB.AddParameters(26, "LAdd1", StudentM.LAdd1, DbType.String);
            objDB.AddParameters(27, "LAdd2", StudentM.LAdd2, DbType.String);
            objDB.AddParameters(28, "LAdd3", StudentM.LAdd3, DbType.String);
            objDB.AddParameters(29, "LCityCode", StudentM.LCityCode, DbType.Int32);
            objDB.AddParameters(30, "LPinCode", StudentM.LPinCode, DbType.String);
            objDB.AddParameters(31, "LPhoneNo", StudentM.LPhoneNo, DbType.String);
            objDB.AddParameters(32, "LMobileNo", StudentM.LMobileNo, DbType.String);
            objDB.AddParameters(33, "EMail", StudentM.EMail, DbType.String);
            objDB.AddParameters(34, "PAdd1", StudentM.PAdd1, DbType.String);
            objDB.AddParameters(35, "PAdd2", StudentM.PAdd2, DbType.String);
            objDB.AddParameters(36, "PAdd3", StudentM.PAdd3, DbType.String);
            objDB.AddParameters(37, "PCityCode", StudentM.PCityCode, DbType.Int32);
            objDB.AddParameters(38, "PPinCode", StudentM.PPinCode, DbType.String);
            objDB.AddParameters(39, "PPhoneNo", StudentM.PPhoneNo, DbType.String);
            objDB.AddParameters(40, "PMobileNo", StudentM.PMobileNo, DbType.String);
            objDB.AddParameters(41, "CAdd1", StudentM.CAdd1, DbType.String);
            objDB.AddParameters(42, "CAdd2", StudentM.CAdd2, DbType.String);
            objDB.AddParameters(43, "CAdd3", StudentM.CAdd3, DbType.String);
            objDB.AddParameters(44, "CCityCode", StudentM.CCityCode, DbType.Int32);
            objDB.AddParameters(45, "CPinCode", StudentM.CPinCode, DbType.String);
            objDB.AddParameters(46, "CPhoneNo", StudentM.CPhoneNo, DbType.String);
            objDB.AddParameters(47, "CMobileNo", StudentM.CMobileNo, DbType.String);
            objDB.AddParameters(48, "ModeCode", StudentM.ModeCode, DbType.String);
            objDB.AddParameters(49, "BloodGroup", StudentM.BloodGroup, DbType.String);
            objDB.AddParameters(50, "UName", StudentM.UName, DbType.String);
            objDB.AddParameters(51, "UEntDt", StudentM.UEntDt, DbType.DateTime);
            objDB.AddParameters(52, "RollNo", StudentM.RollNo, DbType.String);
            objDB.AddParameters(53, "BatchCode", StudentM.BatchCode, DbType.String);
            objDB.AddParameters(54, "CourseDescCode", StudentM.CourseDescCode, DbType.String);
            objDB.AddParameters(55, "EnrollmentNo", StudentM.EnrollmentNo, DbType.String);
            objDB.AddParameters(56, "PassOutDate", StudentM.PassOutDate, DbType.String);
            objDB.AddParameters(57, "InstituteID", StudentM.InstituteID, DbType.Int32);
            objDB.AddParameters(58, "SessionID", StudentM.SessionID, DbType.String);
            objDB.AddParameters(59, "MName", StudentM.MName, DbType.String);
            objDB.AddParameters(60, "LName", StudentM.LName, DbType.String);
            objDB.AddParameters(61, "CCategory", StudentM.CCategory, DbType.String);
            objDB.AddParameters(62, "Status", StudentM.Status, DbType.String);
            objDB.AddParameters(63, "Barcode", StudentM.Barcode, DbType.String);
            objDB.AddParameters(64, "Last_Qualification", StudentM.Last_Qualification, DbType.String);
            objDB.AddParameters(65, "Total_Per", StudentM.Total_Per, DbType.String);
            objDB.AddParameters(66, "Entrance_Qual", StudentM.Entrance_Qual, DbType.String);
            objDB.AddParameters(67, "Rank_Overall", StudentM.Rank_Overall, DbType.String);
            objDB.AddParameters(68, "Rank_Category", StudentM.Rank_Category, DbType.String);
            objDB.AddParameters(69, "ForwardTo_Ap", StudentM.ForwardTo_Ap, DbType.String);
            objDB.AddParameters(70, "ForwardTo_Dp", StudentM.ForwardTo_Dp, DbType.String);
            objDB.AddParameters(71, "Ap_Status", StudentM.Ap_Status, DbType.String);
            objDB.AddParameters(72, "DP_Status", StudentM.DP_Status, DbType.String);
            objDB.AddParameters(73, "Coun_Comment", StudentM.Coun_Comment, DbType.String);
            objDB.AddParameters(74, "CollegeID", StudentM.CollegeID, DbType.String);       

            objDB.AddParameters(75, "flag", StudentM.flag, DbType.String);
            objDB.AddParameters(76, "StudentIDreturn", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            objDB.AddParameters(77, "StudentCode", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            f = StudentM.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_CouncellingAP_Insert");
            Int32 sid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
            string scode = "";
            if (StudentM.flag == "U")
            {
                sid = Convert.ToInt32(StudentM.CounsellingID);
                scode = StudentM.RegistrationNo;
            }
            else
            {
                sid = Convert.ToInt32(StudentM.CounsellingID);
                scode = StudentM.RegistrationNo;
                //objDB.Parameters[77].Value.ToString();
            }
            foreach (BpoDM.CouncellingDetailCDM std in studentDM)
            {
                objDB.CreateParameters(18);
                objDB.AddParameters(0, "CouncellingID", std.CouncellingID, DbType.Int32);
                objDB.AddParameters(1, "SrNo", std.SrNo, DbType.Int32);
                objDB.AddParameters(2, "FeeHeadCode", std.FeeHeadCode, DbType.String);
                objDB.AddParameters(3, "TotalFeeAmount", std.TotalFeeAmount, DbType.Decimal);
                objDB.AddParameters(4, "BreakoffTime", std.BreakoffTime, DbType.String);
                objDB.AddParameters(5, "Amount", std.Amount, DbType.Decimal);
                objDB.AddParameters(6, "UName", std.UName, DbType.String);
                objDB.AddParameters(7, "UEntDt", std.UEntDt, DbType.DateTime);
                objDB.AddParameters(8, "DueDate", std.DueDate, DbType.DateTime);
                objDB.AddParameters(9, "PaidAmount", std.PaidAmount, DbType.Decimal);
                objDB.AddParameters(10, "BalAmount", std.BalAmount, DbType.Decimal);
                objDB.AddParameters(11, "ReFund", std.ReFund, DbType.Decimal);
                objDB.AddParameters(12, "Advance", std.Advance, DbType.Decimal);
                objDB.AddParameters(13, "CourseID", std.CourseID, DbType.Int32);
                objDB.AddParameters(14, "Session", std.Session, DbType.String);
                objDB.AddParameters(15, "Inst_ID", std.Inst_ID, DbType.Int32);
                objDB.AddParameters(16, "FeeSubID", std.FeeSubID, DbType.Int32);
                objDB.AddParameters(17, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Councelling_Detail_Insert");
            }
            //------------student -------------
            foreach (BpoDM.CouncellingExamPassedDM std in SQDM)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "BPOID",std.BPOID,  DbType.String);
                objDB.AddParameters(1, "CouncellingID", std.CouncellingID, DbType.String);
                objDB.AddParameters(2, "Exam_passed", std.Exam_passed, DbType.String);
                objDB.AddParameters(3, "Subjects", std.Subjects, DbType.String);
                objDB.AddParameters(4, "MaxMarks", std.MaxMarks, DbType.String);
                objDB.AddParameters(5, "MinMarks", std.MinMarks, DbType.String);
                objDB.AddParameters(6, "Gross_Per", std.Gross_Per, DbType.String);
                objDB.AddParameters(7, "Qual_year", std.Qual_year, DbType.String);//
                objDB.AddParameters(8, "IsCalculated", std.IsCalculated, DbType.String);
                objDB.AddParameters(9, "UEndt", std.UEndt, DbType.DateTime);
                objDB.AddParameters(10, "Uentime", std.UeTime, DbType.String);
                objDB.AddParameters(11, "U_name", std.U_Name, DbType.String);
                objDB.AddParameters(12, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_E_Passed_Insert");
            }

            //------------StudentDocuments Insert-------------
            foreach (BpoDM.CouncellingStudentDocDM std in SDDM)
            {
                objDB.CreateParameters(16);
                objDB.AddParameters(0, "CounsellingID", scode, DbType.String);
                objDB.AddParameters(1, "BPOID", std.BPOID, DbType.String);
                objDB.AddParameters(2, "StudentID", std.StudentID, DbType.String);
                objDB.AddParameters(3, "DocumentID", std.DocumentID, DbType.String);
                objDB.AddParameters(4, "Doc_Serial", std.Doc_Serial, DbType.String);
                objDB.AddParameters(5, "PassingYr", std.PassingYr, DbType.String);
                objDB.AddParameters(6, "Total_Marks", std.Total_Marks, DbType.String);
                objDB.AddParameters(7, "Percentage", std.Percentage, DbType.String);
                objDB.AddParameters(8, "Remark", std.Remark, DbType.String);
                objDB.AddParameters(9, "SessionID", std.SessionID, DbType.String);
                objDB.AddParameters(10, "InstituteID", std.InstituteID, DbType.String);
                objDB.AddParameters(11, "Is_original", std.Is_original, DbType.String);
                objDB.AddParameters(12, "Is_Submitted", std.Is_Submitted, DbType.String);
                objDB.AddParameters(13, "Councelling_Time", std.Councelling_Time, DbType.String);
                objDB.AddParameters(14, "Counselling_Date", std.Counselling_Date, DbType.String);
                objDB.AddParameters(15, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Documents_Insert");
            }
            //------------student Ad Processing-------------
            objDB.CreateParameters(13);
            objDB.AddParameters(0, "AD_ID", StudentADPM.AD_ID, DbType.String);
            objDB.AddParameters(1, "BPOID", StudentADPM.BPOID, DbType.String);
            objDB.AddParameters(2, "CounID", StudentADPM.CounID, DbType.String);
            objDB.AddParameters(3, "Processing_Date", StudentADPM.Processing_Date, DbType.String);
            objDB.AddParameters(4, "Processing_Time", StudentADPM.Processing_Time, DbType.String);
            objDB.AddParameters(5, "Comments", StudentADPM.Comments, DbType.String);
            objDB.AddParameters(6, "ForwardBY", StudentADPM.ForwardBY, DbType.String);
            objDB.AddParameters(7, "ForwardTo", StudentADPM.ForwardTo, DbType.String);
            objDB.AddParameters(8, "SessionID", StudentADPM.SessionID, DbType.String);
            objDB.AddParameters(9, "InstID", StudentADPM.InstID, DbType.String);
            objDB.AddParameters(10, "UserID", StudentADPM.UserID, DbType.String);
            //objDB.AddParameters(11, "AP_Status", StudentADPM.AP_Status, DbType.String);
            objDB.AddParameters(11, "DP_Status", StudentADPM.DP_Status, DbType.String);
            objDB.AddParameters(12, "flag", StudentADPM.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_AdProcessing_Insert");
            //------------audit-------------
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
            if ((f == "N")||(f=="A"))
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
    public BpoDM.GetCouncellingID GetStudentCouncellingID()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var objID = new BpoDM.GetCouncellingID();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetStudentCouncellingID");
        try
        {
            if (dr.Read())
            {
                objID.CouncellingID = Education.DataHelper.GetInt(dr, "ID");
            }
        }
            finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return objID;
    }
    [OperationContract]
    public DataTable  FillFeeDetailForDepositionBPO(int CourseID, int CouncellingID,string Session)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(1, "CouncellingID", CouncellingID, DbType.Int32);
        objDB.AddParameters(2, "SessionID", Session, DbType.String);
        List<BpoDM.FillFeeDetailForFeeDepositionDM> retitem = new List<BpoDM.FillFeeDetailForFeeDepositionDM>();
        DataTable dt = new DataTable();
        try
        {
             dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FillFeeForDeposition_BPO");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return dt;
    }
   [OperationContract]
    public DataTable FillBpoFeeDetail(string CounsellingID, int courseid, string session, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "CounsellingID", CounsellingID, DbType.String);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "session", session, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.String);
        //List<BpoDM.FillFeeDetailForFeeDepositionDM> retitem = new List<BpoDM.FillFeeDetailForFeeDepositionDM>();
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select_F");
        objDB.Dispose();
        return dt;
    }


    public class FillBpoDetailPGrd : List<BpoDM.FillBpoDetailPGrdDM>
    {
    }
    [OperationContract]
    public FillBpoDetailPGrd FillBDetailPGrd(int DocId, int instid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select_F");
        FillBpoDetailPGrd listBpo = new FillBpoDetailPGrd();
        while (dr.Read())
        {
            var item = new BpoDM.FillBpoDetailPGrdDM();
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.PID = Education.DataHelper.GetInt(dr, "PID");
            item.PayM = Education.DataHelper.GetString(dr, "PayM");
            item.Amt = Education.DataHelper.GetDecimal(dr, "Amt");
            item.DDNO = Education.DataHelper.GetInt(dr, "DDNO");
            item.DateP = Education.DataHelper.GetDateTime(dr, "DateP");
            listBpo.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listBpo;
    }



    public class FillBpoPrintGrd : List<BpoDM.FillBpoPrintGrdDM>
    {
    }
    [OperationContract]
    public FillBpoPrintGrd FillBPrintGrd(int DocId, string Sessn,  int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "session", Sessn, DbType.String);
        //objDB.AddParameters(2, "sid", sid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select_F");
        FillBpoPrintGrd listBpo = new FillBpoPrintGrd();
        while (dr.Read())
        {
            var item = new BpoDM.FillBpoPrintGrdDM();
            item.RCNO = Education.DataHelper.GetInt (dr, "RCNO");
            item.Prno  = Education.DataHelper.GetString(dr, "prno");
            listBpo.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listBpo;
    }


    public DataTable FillFeeDetailTable(int DocId, int InstID, string Sessn, int Sid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(2, "Session", Sessn, DbType.String);
        objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select_F");
        return dt;
    }


    public class FillStudentID : List<BpoDM.FillStudentIdDM>
    {
    }
    [OperationContract]
    public FillStudentID FillStudent(int courseid,  string session, string status, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "courseid", courseid, DbType.Int32);
        //objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "session", session, DbType.String);
        objDB.AddParameters(2, "status", status, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select_F");
        FillStudentID listStudent = new FillStudentID();
        while (dr.Read())
        {
            var item = new BpoDM.FillStudentIdDM();
            item.CounsellingID = Education.DataHelper.GetInt(dr, "CounsellingID");
            item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
            listStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listStudent;
    }



    [OperationContract]
    public string InsertFeeDepositionBpo(List<BpoDM.FeeTransDetailBpoDM> objFSDM, List<BpoDM.FeePayDetailBpoDM> objFSC, Admin.AdministratorData.AuditDM audit)
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
            foreach (BpoDM.FeeTransDetailBpoDM fd in objFSDM)
            {
                objDB.CreateParameters(21);
                objDB.AddParameters(0, "RCNO", fd.RCNO, DbType.Int32);
                objDB.AddParameters(1, "StudentID", fd.StudentID, DbType.Int32);
                objDB.AddParameters(2, "FeeID", fd.FeeID, DbType.Int32);
                objDB.AddParameters(3, "Amount", fd.Amount, DbType.Decimal);
                objDB.AddParameters(4, "Trans_Date", fd.Trans_Date, DbType.DateTime);
                objDB.AddParameters(5, "FromDate", fd.FromDate, DbType.DateTime);
                objDB.AddParameters(6, "ToDate", fd.ToDate, DbType.DateTime);
                objDB.AddParameters(7, "PrNo", fd.PrNo, DbType.String);
                objDB.AddParameters(8, "Session", fd.Session, DbType.String);
                objDB.AddParameters(9, "Uname", fd.Uname, DbType.String);
                objDB.AddParameters(10, "Entry_Date", fd.Entry_Date, DbType.DateTime);
                objDB.AddParameters(11, "Ppsno", fd.Ppsno, DbType.Int32);
                //objDB.AddParameters(12, "SID", fd.Sid, DbType.Int32);
                //objDB.AddParameters(13, "Year", fd.Year, DbType.Int32);
                objDB.AddParameters(12, "InstID", fd.InstId, DbType.Int32);
                objDB.AddParameters(13, "duedate", fd.duedate, DbType.DateTime);
                //objDB.AddParameters(16, "RCNOID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                objDB.AddParameters(14, "PaidAmount", fd.PaidAmount, DbType.Decimal);
                objDB.AddParameters(15, "BalAmount", fd.BalAmount, DbType.Decimal);
                objDB.AddParameters(16, "PrnoId", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
                objDB.AddParameters(17, "Used", fd.Used, DbType.String);
                objDB.AddParameters(18, "LastUsed", fd.LastUsed, DbType.String);
                objDB.AddParameters(19, "FeeSubId", fd.FeeSubId, DbType.Int32);
                objDB.AddParameters(20, "Trans_State", "T", DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Trans_Detail_Insert_Bpo");
            }
            //Int32 rcnoid = 0;
            string prnoid = String.Empty;
            // rcnoid = Int32.Parse(objDB.Parameters[16].Value.ToString());
            prnoid = objDB.Parameters[16].Value.ToString();

            foreach (BpoDM.FeePayDetailBpoDM ftd in objFSC)
            {
                objDB.CreateParameters(20);
                objDB.AddParameters(0, "SNo", 0, DbType.Int32);
                objDB.AddParameters(1, "DocID", ftd.DocID, DbType.Int32);
                objDB.AddParameters(2, "PayM", ftd.PayM, DbType.String);
                objDB.AddParameters(3, "Amt", ftd.Amt, DbType.Decimal);
                objDB.AddParameters(4, "DDNO", ftd.DDNO, DbType.Int32);
                objDB.AddParameters(5, "DateP", ftd.DateP, DbType.DateTime);
                objDB.AddParameters(6, "PID", ftd.PID, DbType.Int32);
                objDB.AddParameters(7, "RCNO", ftd.RCNO, DbType.Int32);
                objDB.AddParameters(8, "PrNo", prnoid, DbType.String);
                objDB.AddParameters(9, "Session", ftd.Session, DbType.String);
                objDB.AddParameters(10, "Uname", ftd.Uname, DbType.String);
                objDB.AddParameters(11, "Entry_Date", ftd.Entry_Date, DbType.DateTime);
                objDB.AddParameters(12, "Ppsno", ftd.Ppsno, DbType.Int32);
                //objDB.AddParameters(13, "SID", ftd.Sid, DbType.Int32);
                //objDB.AddParameters(14, "Year", ftd.Year, DbType.Int32);
                objDB.AddParameters(13, "InstID", ftd.InstId, DbType.Int32);
                objDB.AddParameters(14, "BankID", ftd.BankID, DbType.Int32);
                objDB.AddParameters(15, "Used", ftd.Used, DbType.String);
                objDB.AddParameters(16, "LastUsed", ftd.LastUsed, DbType.String);
                objDB.AddParameters(17, "FeeId", ftd.FeeId, DbType.Int32);
                objDB.AddParameters(18, "FeeSubId", ftd.FeeSubId, DbType.Int32);
                objDB.AddParameters(19, "Trans_State", "T", DbType.String);
                
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_PayDetails_Insert_Bpo");
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


    public class FillPayMode : List<BpoDM.FillPayModeDM>
    {
    }
    [OperationContract]
    public FillPayMode FillPMode(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Select_F");
        FillPayMode listPMode = new FillPayMode();
        while (dr.Read())
        {
            var item = new BpoDM.FillPayModeDM();
            item.PMID = Education.DataHelper.GetInt(dr, "PMID");
            item.PaymentMode = Education.DataHelper.GetString(dr, "PaymentMode");
            listPMode.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listPMode;
    }



    public DataTable FillBpoReceipt(int DocId, int InstID, string Sessn, int Sid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(2, "Session", Sessn, DbType.String);
        objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select_F");
        return dt;
    }

    public DataTable FillBpoReceiptFill(string CounsellingID, string RecNo, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "CounsellingRecptID", CounsellingID, DbType.String);
        objDB.AddParameters(1, "RecNo", RecNo, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select_F");
        return dt;
    }


    public DataTable FillDetaiBpoPrint(int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Get_Receipt_Detail");
        return dt;
    }


    public DataTable FillDetailBpoRcpt(string Prno, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "PrNo", Prno, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BPO_Select_F");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }
    [OperationContract]
    public DataTable FillBPOReport(string qry)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        //objDB.CreateParameters(1);
        //objDB.AddParameters(0, "qry",dt, DbType.String);
        // List<BpoDM.FillBpoDM> retitem = new List<BpoDM.FillBpoDM>();
        DataTable dt = objDB.ExecuteTable(CommandType.Text, qry);
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }

    [OperationContract]
    public DataTable FillCONSELReport(string qy)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        //objDB.CreateParameters(1);
        //objDB.AddParameters(0, "qry",dt, DbType.String);
        // List<BpoDM.FillBpoDM> retitem = new List<BpoDM.FillBpoDM>();
        DataTable dt = objDB.ExecuteTable(CommandType.Text, qy);
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }
    [OperationContract]
    public List<BpoDM.StudentEqualificationForAP> FillStudentEQualificationForDocProcessing(string Query, List<BpoDM.StudentEqualificationForAP> retitem)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, Query);
        try
        {
            while (dr.Read())
            {
                var item = new BpoDM.StudentEqualificationForAP();
                item.Gross_Per = Education.DataHelper.GetString(dr, "Gross_Per");
                item.IsCalculated = Education.DataHelper.GetString(dr, "IsCalculated");
                item.MO = Education.DataHelper.GetString(dr, "MO");
                item.Subject = Education.DataHelper.GetString(dr, "Subject");
                item.CouncellingID = Education.DataHelper.GetString(dr, "CouncellingID");
                item.ProfileID = Education.DataHelper.GetString(dr, "ProfileID");
                item.Qual_Year = Education.DataHelper.GetString(dr, "Qual_Year");
                item.BPOID = Education.DataHelper.GetString(dr, "BPOID");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            objDB.DataReader.Close();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
        }
        return retitem;
    }
    [OperationContract(IsOneWay = false)]
    public string InsertStudentDetailFromDocumentProcessing(BpoDM.StudentCouncellingMDM StudentM, List<BpoDM.CouncellingExamPassedDM> SQDM, List<BpoDM.CouncellingStudentDocDM> SDDM, BpoDM.StudentDDProcessingDM StdentDP, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "U";
        try
        {
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "ImagePath", StudentM.ImagePath, DbType.Binary);
            objDB.AddParameters(1, "DP_Status", "Y", DbType.String);
            objDB.AddParameters(2, "ID_Student", StudentM.ID_Student, DbType.String);
            objDB.AddParameters(3, "flag", StudentM.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentCoun_Docprocessing_Insert");

            foreach (BpoDM.CouncellingExamPassedDM std in SQDM)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "BPOID", std.BPOID, DbType.String);
                objDB.AddParameters(1, "CouncellingID", std.CouncellingID, DbType.String);
                objDB.AddParameters(2, "Exam_passed", std.Exam_passed, DbType.String);
                objDB.AddParameters(3, "Subjects", std.Subjects, DbType.String);
                objDB.AddParameters(4, "MaxMarks", std.MaxMarks, DbType.String);
                objDB.AddParameters(5, "MinMarks", std.MinMarks, DbType.String);
                objDB.AddParameters(6, "Gross_Per", std.Gross_Per, DbType.String);
                objDB.AddParameters(7, "Qual_year", std.Qual_year, DbType.String);//
                objDB.AddParameters(8, "IsCalculated", std.IsCalculated, DbType.String);
                objDB.AddParameters(9, "UEndt", std.UEndt, DbType.DateTime);
                objDB.AddParameters(10, "Uentime", std.UeTime, DbType.String);
                objDB.AddParameters(11, "U_name", std.U_Name, DbType.String);
                objDB.AddParameters(12, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_E_Passed_Insert");
            }
            //-------------------Student documents Insert--------------
            foreach (BpoDM.CouncellingStudentDocDM std in SDDM)
            {
                objDB.CreateParameters(16);
                objDB.AddParameters(0, "CounsellingID", std.CounsellingID, DbType.String);
                objDB.AddParameters(1, "BPOID", std.BPOID, DbType.String);
                objDB.AddParameters(2, "StudentID", std.StudentID, DbType.String);
                objDB.AddParameters(3, "DocumentID", std.DocumentID, DbType.String);
                objDB.AddParameters(4, "Doc_Serial", std.Doc_Serial, DbType.String);
                objDB.AddParameters(5, "PassingYr", std.PassingYr, DbType.String);
                objDB.AddParameters(6, "Total_Marks", std.Total_Marks, DbType.String);
                objDB.AddParameters(7, "Percentage", std.Percentage, DbType.String);
                objDB.AddParameters(8, "Remark", std.Remark, DbType.String);
                objDB.AddParameters(9, "SessionID", std.SessionID, DbType.String);
                objDB.AddParameters(10, "InstituteID", std.InstituteID, DbType.String);
                objDB.AddParameters(11, "Is_original", std.Is_original, DbType.String);
                objDB.AddParameters(12, "Is_Submitted", std.Is_Submitted, DbType.String);
                objDB.AddParameters(13, "Councelling_Time", std.Councelling_Time, DbType.String);
                objDB.AddParameters(14, "Counselling_Date", std.Counselling_Date, DbType.String);
                objDB.AddParameters(15, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Documents_Insert");
            }
            //------------student_DDProcessing-------------
            objDB.CreateParameters(12);
            objDB.AddParameters(0, "DD_ID", 0, DbType.String);
            objDB.AddParameters(1, "BPOID", StdentDP.BPOID, DbType.String);
            objDB.AddParameters(2, "CounID", StdentDP.CounID, DbType.String);
            objDB.AddParameters(3, "Processing_Date", StdentDP.Processing_Date, DbType.String);
            objDB.AddParameters(4, "Processing_Time", StdentDP.Processing_Time, DbType.String);
            objDB.AddParameters(5, "Comments", StdentDP.Comments, DbType.String);
            objDB.AddParameters(6, "ForwardBY", StdentDP.ForwardBY, DbType.String);
            objDB.AddParameters(7, "ForwardTo", StdentDP.ForwardTo, DbType.String);
            objDB.AddParameters(8, "SessionID", StdentDP.SessionID, DbType.String);
            objDB.AddParameters(9, "InstID", StdentDP.InstID, DbType.String);
            objDB.AddParameters(10, "UserID", StdentDP.UserID, DbType.String);
            objDB.AddParameters(11, "flag", StdentDP.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_DDProcessing_Insert");
            //----------------------Audit Insert-------------------------------------
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
                retv = "Record saved with Councelling No :-" + StdentDP.CounID;
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully for Councelling No :-" + StdentDP.CounID;
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
    public BpoDM.BPORegistrationDM GetBPOrRegisteredUser(string EmailID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Email_ID", EmailID, DbType.String);
        DataTable dt = new DataTable();
        var item = new BpoDM.BPORegistrationDM();
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "CheckBPORegisteredUser");
        if (dr.Read())
        {
            item.Email_ID = Education.DataHelper.GetString(dr, "Email_ID");
        }
        dr.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return item;
    }

    [OperationContract]
    public BpoDM.VerifyChatUserDM VerifyChatUser(string EmailID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Email_ID", EmailID, DbType.String);
        var item = new BpoDM.VerifyChatUserDM();
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "BPO_Verify_ChatUser");
        if (dr.Read())
        {
            DbFunctions objdb = new DbFunctions();
            item.Email_ID = Education.DataHelper.GetString(dr, "Email_ID");
            item.Password = objdb.decrypt(dr["password"].ToString(), dr["saltvc"].ToString());
            item.IsAuthenticated = Education.DataHelper.GetString(dr, "IsAuthenticated");
            item.IsVerified = Education.DataHelper.GetString(dr, "IsVerified");
            item.VerificationCode = Education.DataHelper.GetString(dr, "VerificationCode");
            item.saltvc = Education.DataHelper.GetString(dr, "saltvc");
        }
        dr.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return item;
    }

    [OperationContract]
    public string ChangeChatUserStatus(string EmailID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Email_ID", EmailID, DbType.String);
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "BPO_ChangeChatUserStatus");
            objDB.Transaction.Commit();
            retv = "Your email has been Verified.";
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Error Your email has been not Verified due to :-" + ex.Message.ToString();
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }

        return retv;
    }
    [OperationContract(IsOneWay = false)]
    public string InsertBPORegistrationDM(BpoDM.BPORegistrationDM StudentM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = StudentM.Flag;
        try
        {

            objDB.CreateParameters(21);
            objDB.AddParameters(0, "User_ID", StudentM.User_ID, DbType.String);
            objDB.AddParameters(1, "Email_ID", StudentM.Email_ID, DbType.String);
            objDB.AddParameters(2, "FirstName", StudentM.FirstName, DbType.String);
            objDB.AddParameters(3, "MiddleName", StudentM.MiddleName, DbType.String);
            objDB.AddParameters(4, "LastName", StudentM.LastName, DbType.String);
            objDB.AddParameters(5, "MobileNo", StudentM.MobileNo, DbType.String);
            objDB.AddParameters(6, "Address", StudentM.Address, DbType.String);
            objDB.AddParameters(7, "CityID", StudentM.CityID, DbType.String);
            objDB.AddParameters(8, "State", StudentM.State, DbType.String);
            objDB.AddParameters(9, "Country", StudentM.Country, DbType.String);
            objDB.AddParameters(10, "Pincode", StudentM.Pincode, DbType.String);
            objDB.AddParameters(11, "Last_Exam", StudentM.Last_Exam, DbType.String);
            objDB.AddParameters(12, "Passing_Year", StudentM.Passing_Year, DbType.String);
            objDB.AddParameters(13, "Password", StudentM.Password, DbType.String);
            objDB.AddParameters(14, "Reg_Date", StudentM.Reg_Date, DbType.DateTime);
            objDB.AddParameters(15, "IPAddress", StudentM.IPAddress, DbType.String);
            objDB.AddParameters(16, "saltVC", StudentM.saltVC, DbType.String);
            objDB.AddParameters(17, "IsVerified", StudentM.IsVerified, DbType.String);
            objDB.AddParameters(18, "Verification_Code", StudentM.Verification_Code, DbType.String);
            objDB.AddParameters(19, "Security_Code", StudentM.Security_Code, DbType.String);
            objDB.AddParameters(20, "flag", StudentM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "BPO_UserRegistration_Insert");
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
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("jitendra.parihar@rcsglobal.co.in", "rcsglobal.co.in");
            smtpClient.Host = "rcsglobal.co.in";
            message.From = fromAddress;
            smtpClient.Port = 25;
            message.Subject = "User registration confirmation for chat with RAMA GROUP Executives or counsellor";
            message.IsBodyHtml = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("jitendra.parihar@rcsglobal.co.in", "rcs1234");
            smtpClient.UseDefaultCredentials = false;
            message.To.Add(StudentM.Email_ID);
            string name = "";
            DbFunctions objFun = new DbFunctions();
            name = StudentM.FirstName + " " + StudentM.MiddleName + " " + StudentM.LastName;//+
            message.Body = "Dear User," + "<br/>" + "Your Username is  : " + StudentM.Email_ID + "<br/> Your Password is : " + StudentM.Passoriginal.ToString() + "<br/>Your Verification Code is :" + StudentM.Verification_Code + " and Security Code is :" + StudentM.Security_Code + "  <br /> <a href='http://172.168.1.88/bpolive/Livechat><span style='color:Navy'>http://172.168.1.88/bpolive/Livechat</span></a> ";
            smtpClient.Credentials = basicAuthenticationInfo;
          //  smtpClient.Send(message);
            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Verification mail has been sent to your mail id.";
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
    public BpoDM.BPORegistrationDM GetBPOrRegisteredUserProfile(string EmailID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Email_ID", EmailID, DbType.String);
        DataTable dt = new DataTable();
        var item = new BpoDM.BPORegistrationDM();
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "CheckBPORegisteredUserProfile");
        if (dr.Read())
        {
            item.Email_ID = Education.DataHelper.GetString(dr, "Email_ID");
            item.FirstName = Education.DataHelper.GetString(dr, "FirstName");
            item.MiddleName = Education.DataHelper.GetString(dr, "MiddleName");
            item.LastName = Education.DataHelper.GetString(dr, "LastName");
            item.Address = Education.DataHelper.GetString(dr, "Address");
            item.CityID = Education.DataHelper.GetString(dr, "CityID");
            item.Country = Education.DataHelper.GetString(dr, "Country");
            item.IPAddress = Education.DataHelper.GetString(dr, "IPAddress");
            item.IsVerified = Education.DataHelper.GetString(dr, "IsVerified");
            item.Last_Exam = Education.DataHelper.GetString(dr, "Last_Exam");
            item.MobileNo = Education.DataHelper.GetString(dr, "MobileNo");
            item.Passing_Year = Education.DataHelper.GetString(dr, "Passing_Year");
            item.Pincode = Education.DataHelper.GetString(dr, "Pincode");
            item.Reg_Date = Education.DataHelper.GetDateTime(dr, "Reg_Date");
            item.saltVC = Education.DataHelper.GetString(dr, "saltVC");
            item.Security_Code = Education.DataHelper.GetString(dr, "Security_Code");
            item.State = Education.DataHelper.GetString(dr, "State");
            item.User_ID = Education.DataHelper.GetInt(dr, "User_ID");
            item.Verification_Code = Education.DataHelper.GetString(dr, "Verification_Code");
        }
        dr.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return item;
    }

    [OperationContract]
    public BpoDM.ChkEpassExistDM FillStudentEPassedToCouncelling(string ProfileID, string BPOID, string CouncellingID,string Subjects)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "ProfileID", ProfileID, DbType.String);
        objDB.AddParameters(1, "BPOID", BPOID, DbType.String);
        objDB.AddParameters(2, "CouncellingID", CouncellingID, DbType.String);
        objDB.AddParameters(3, "Subjects", Subjects, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "CheckExitEPassFromCouncelling");
        var item = new BpoDM.ChkEpassExistDM();
        try
        {
            if (dr.Read())
            {
                item.IsExists = Education.DataHelper.GetString(dr, "CouncellingID");
            }
        }
        finally
        {
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
        }
        return item;
    }


    public DataTable FillAvailableCourse(int InstituteId, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteId", InstituteId, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bpo_Report_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillAvailableStudent(int CourseCode, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "CourseCode", CourseCode, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bpo_Report_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillRegisteredStudent(string Course, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Course", Course, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Bpo_Report_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }
}
