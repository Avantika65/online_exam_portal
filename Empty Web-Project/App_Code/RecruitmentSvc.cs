using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using   NewDAL;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RecruitmentSvc
/// </summary>
/// 
[ServiceContract(Namespace = "", CallbackContract = typeof(IRecruitmentSvc), ConfigurationName = "Service")]
public interface IRecruitmentSvc
{
    [OperationContract(IsOneWay = false)]
    string insertJobProfile(HRM.Recruitment.JobProfileDM objProfile);

    [OperationContract(IsOneWay = false)]
    string insertPanelMemb(HRM.Recruitment.PannelMemb objPanelMem); 

    [OperationContract (IsOneWay = false)]
    string  insertFeedback(HRM.Recruitment.FeedbackDM objFeedbk);

    [OperationContract(IsOneWay = false)]
    string insertCandidateResume(HRM.Recruitment.CandRecruitDM objCandRes);
    // [OperationContract(IsOneWay=false)]
    //string fillVac()
    //[OperationContract(IsOneWay=false)]
    //string insertVac(HRM.Recruitment.AddJobVac objVac);

    [OperationContract(IsOneWay = false)]
    string insertselectedcandidate(List<HRM.Recruitment.selctedcandDM> objslctcand);
    [OperationContract(IsOneWay = false)]
    List<HRM.Recruitment.selctedcandDM> fillslcsnd(Int32 catid, Int32 deptid, Int32 desigid, Int32 instituteid);
    
}

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
public class RecruitmentSvc : IRecruitmentSvc
{
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
    [OperationContract]
    public string insertJobProfile(HRM.Recruitment.JobProfileDM objProfile)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer,objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = string.Empty;
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "id",objProfile.id,DbType.Int32);
            objDB.AddParameters(1, "deptId", objProfile.deptId, DbType.Int32);
            objDB.AddParameters(2, "desigId", objProfile.desigId, DbType.Int32);
            objDB.AddParameters(3, "rdeptId", objProfile.rdeptId, DbType.Int32);
            objDB.AddParameters(4, "authority", objProfile.authority, DbType.Int32);
            objDB.AddParameters(5, "InstituteID", objProfile.InstituteID, DbType.Int32);
            objDB.AddParameters(6, "SessionID", objProfile.SessionID, DbType.String);
            objDB.AddParameters(7, "UserID", objProfile.UserID, DbType.String);
            objDB.AddParameters(8, "UEDate", objProfile.UEDate, DbType.DateTime);
            objDB.AddParameters(9, "flag", objProfile.flag, DbType.String);
            objDB.AddParameters(10, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_job_profile_M");
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            if (Retsuccess == "2")
            {
                retv = "Update successfuly.";
            }
            else if (Retsuccess == "3")
            {
                retv = "Delete successfully";
            }
            else if (Retsuccess == "4")
            {
                retv = "Record already exists.";
            }
            else if (Retsuccess == "5")
            {
                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
        }
        return retv;
    }
    [OperationContract]
    public string insertPanelMemb(HRM.Recruitment.PannelMemb objPanelMem)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = String.Empty;
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "id", objPanelMem.id, DbType.Int32);
            objDB.AddParameters(1, "deptId", objPanelMem.deptId, DbType.Int32);
            objDB.AddParameters(2, "jobId", objPanelMem.jobId, DbType.Int32);
            objDB.AddParameters(3, "jobTitle", objPanelMem.jobTitle, DbType.String);
            objDB.AddParameters(4, "mem_id", objPanelMem.mem_id, DbType.Int32);
            objDB.AddParameters(5, "InstituteID", objPanelMem.InstituteID, DbType.Int32);
            objDB.AddParameters(6, "SessionID", objPanelMem.SessionID, DbType.String);
            objDB.AddParameters(7, "UserID", objPanelMem.UserID, DbType.String);
            objDB.AddParameters(8, "UEDate", objPanelMem.UEDate, DbType.DateTime);
            objDB.AddParameters(9, "flag", objPanelMem.flag, DbType.String);
            objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Hr_Panel_Member");
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            if (Retsuccess == "2")
            {
                retv = "Update successfuly.";
            }
            else if (Retsuccess == "3")
            {
                retv = "Delete successfully";
            }
            else if (Retsuccess == "4")
            {
                retv = "Record already exists.";
            }
            else if (Retsuccess == "5")
            {
                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
        }
        return retv;

    }
    [OperationContract]
    public string insertFeedback(HRM.Recruitment.FeedbackDM objFeedbk)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer,objDB.ConnectionString);
        string retv =string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = string.Empty;
            objDB.CreateParameters(17);
            objDB.AddParameters(0, "id", objFeedbk.id, DbType.Int32);
            objDB.AddParameters(1, "candId", objFeedbk.candId, DbType.Int32);
            objDB.AddParameters(2, "deptID", objFeedbk.deptID, DbType.Int32);
            objDB.AddParameters(3, "desigID", objFeedbk.desigID, DbType.Int32);
            objDB.AddParameters(4, "intrvR", objFeedbk.intrvR, DbType.Int32);
            objDB.AddParameters(5, "feedbk", objFeedbk.feedbk, DbType.String);
            objDB.AddParameters(6, "plcmMem", objFeedbk.plcmMem, DbType.String);
            objDB.AddParameters(7, "Ondate", objFeedbk.Ondate, DbType.DateTime);
            objDB.AddParameters(8, "jobId", objFeedbk.jobId, DbType.Int32);
            objDB.AddParameters(9, "maxPoint", objFeedbk.maxPoint, DbType.Int32);
            objDB.AddParameters(10, "pointEarned", objFeedbk.pointEarned, DbType.Int32);
            objDB.AddParameters(11, "InstituteID", objFeedbk.InstituteID, DbType.Int32);
            objDB.AddParameters(12, "SessionID", objFeedbk.SessionID, DbType.String);
            objDB.AddParameters(13, "UserID", objFeedbk.UserID, DbType.String);
            objDB.AddParameters(14, "UEDate", objFeedbk.UEDate, DbType.DateTime);
            objDB.AddParameters(15, "flag", objFeedbk.flag, DbType.String);
            objDB.AddParameters(16, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Interv_Feedbk");         
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
            objDB.Transaction.Commit();//plcmMem
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            if (Retsuccess == "2")
            {
                retv = "Update successfuly.";
            }
            else if (Retsuccess == "3")
            {
                retv = "Delete successfully";
            }
            else if (Retsuccess == "4")
            {
                retv = "Record already exists.";
            }
            else if (Retsuccess == "5")
            {
                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to Save Record:";
            
        }
        return retv;

    }
    [OperationContract]
    public string insertIntervRound(HRM.Recruitment.IntrRoundDM objIntvRond)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer,objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = string.Empty;
            objDB.CreateParameters(13);
            objDB.AddParameters(0, "id", objIntvRond.id, DbType.Int32);
            objDB.AddParameters(1, "deptId", objIntvRond.deptId, DbType.Int32);
            objDB.AddParameters(2, "jobId", objIntvRond.jobId, DbType.Int32);
            objDB.AddParameters(3, "jobCode", objIntvRond.jobCode, DbType.String);
            objDB.AddParameters(4, "jobTitle", objIntvRond.jobTitle, DbType.String);
            objDB.AddParameters(5, "interv_R", objIntvRond.interv_R, DbType.String);
            objDB.AddParameters(6, "InstituteID", objIntvRond.InstituteID, DbType.Int32);
            objDB.AddParameters(7, "SessionID", objIntvRond.SessionID, DbType.String);
            objDB.AddParameters(8, "UserID", objIntvRond.UserID, DbType.String);
            objDB.AddParameters(9, "UEDate", objIntvRond.UEDate, DbType.DateTime);
            objDB.AddParameters(10, "maxPoint", objIntvRond.maxPoint, DbType.String);
            objDB.AddParameters(11, "flag", objIntvRond.flag, DbType.String);
            objDB.AddParameters(12, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_intervRound");
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            if (Retsuccess == "2")
            {
                retv = "Update successfuly.";
            }
            else if (Retsuccess == "3")
            {
                retv = "Delete successfully";
            }
            else if (Retsuccess == "4")
            {
                retv = "Record already exists.";
            }
            else if (Retsuccess == "5")
            {
                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
        }
        return retv;
    }
    [OperationContract]
    public string insertAddJobVac(HRM.Recruitment.AddJobVac objAddVac)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = string.Empty;
            objDB.CreateParameters(22);
            objDB.AddParameters(0, "jobId", objAddVac.jobId, DbType.Int32);
            objDB.AddParameters(1, "jobCode", objAddVac.jobCode, DbType.String);
            objDB.AddParameters(3, "title", objAddVac.title, DbType.Int32);
            objDB.AddParameters(4, "deptId", objAddVac.deptId, DbType.Int32);
            objDB.AddParameters(5, "desigId", objAddVac.desigId, DbType.Int32);
            //objDB.AddParameters(6, "payStruct", objAddVac.payStruct, DbType.Int32);
            //objDB.AddParameters(7, "minAge", objAddVac.minAge, DbType.Int32);
            objDB.AddParameters(8, "maxAge", objAddVac.maxAge, DbType.Int32);
            objDB.AddParameters(9, "tExpb", objAddVac.tExp, DbType.Decimal);
            objDB.AddParameters(10, "responsibility", objAddVac.responsibility, DbType.String);
            objDB.AddParameters(11, "tVacancy", objAddVac.tVacancy, DbType.Decimal);
            objDB.AddParameters(12, "aDate", objAddVac.aDate, DbType.DateTime);
            objDB.AddParameters(13, "lDate", objAddVac.lDate, DbType.DateTime);
            objDB.AddParameters(14, "qualId", objAddVac.qualId, DbType.String);
            objDB.AddParameters(15, "percentage", objAddVac.percentage, DbType.Decimal);
            objDB.AddParameters(16, "InstituteID", objAddVac.InstituteID, DbType.Int32);
            objDB.AddParameters(17, "SessionID", objAddVac.SessionID, DbType.String);
            objDB.AddParameters(18, "UserID", objAddVac.UserID, DbType.String);
            objDB.AddParameters(19, "UEDate", objAddVac.UEDate, DbType.DateTime);
            objDB.AddParameters(20, "flag", objAddVac.flag, DbType.String);
            objDB.AddParameters(21, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Add_vacancy");
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            if (Retsuccess == "2")
            {
                retv = "Update successfuly.";
            }
            else if (Retsuccess == "3")
            {
                retv = "Delete successfully";
            }
            else if (Retsuccess == "4")
            {
                retv = "Record already exists.";
            }
            else if (Retsuccess == "5")
            {
                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Record is not saved";
        }
        return retv;
    }
    [OperationContract]
    public string insertCandidateResume(HRM.Recruitment.CandRecruitDM objCandRes)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer,objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = string.Empty;
            objDB.CreateParameters(29);
            objDB.AddParameters(0, "candid", objCandRes.candid, DbType.Int32);
            objDB.AddParameters(1, "email", objCandRes.email, DbType.String);
            objDB.AddParameters(2, "fName", objCandRes.fName, DbType.String);
            objDB.AddParameters(3, "lName", objCandRes.lName, DbType.String);
            objDB.AddParameters(4, "ph", objCandRes.ph, DbType.String);
            objDB.AddParameters(5, "mob", objCandRes.mob, DbType.String);
            objDB.AddParameters(6, "cLoc", objCandRes.cLoc, DbType.Int32);
            objDB.AddParameters(7, "pLoc", objCandRes.pLoc, DbType.Int32);
            objDB.AddParameters(8, "exYear", objCandRes.exYear, DbType.Int32);
            objDB.AddParameters(9, "exMon", objCandRes.exMon, DbType.Int32);
            objDB.AddParameters(10, "nation", objCandRes.nation, DbType.String);
            objDB.AddParameters(11, "gender", objCandRes.gender, DbType.String);
            objDB.AddParameters(12, "skills", objCandRes.skills, DbType.String);
            objDB.AddParameters(13, "qualId", objCandRes.qualId, DbType.String);
            objDB.AddParameters(14, "yPass", objCandRes.yPass, DbType.Int32);
            objDB.AddParameters(15, "inst", objCandRes.inst, DbType.String);
            objDB.AddParameters(16, "resumeName", objCandRes.resumeName, DbType.String);
            objDB.AddParameters(17, "catId", objCandRes.catId, DbType.Int32);
            objDB.AddParameters(18, "_percent", objCandRes._percent, DbType.Decimal);
            objDB.AddParameters(19, "ref", objCandRes.refe, DbType.String);
            objDB.AddParameters(20, "InstituteID", objCandRes.InstituteID, DbType.Int32);
            objDB.AddParameters(21, "SessionID", objCandRes.SessionID, DbType.String);
            objDB.AddParameters(22, "UserID", objCandRes.UserID, DbType.String);
            objDB.AddParameters(23, "UEDate", objCandRes.UEDate, DbType.DateTime);
            objDB.AddParameters(24, "flag", objCandRes.flag, DbType.String);
            objDB.AddParameters(25, "ApplyDate", objCandRes.ApplyDate, DbType.DateTime);
            objDB.AddParameters(26, "CurrEmp", objCandRes.CurrEmp, DbType.String);
            objDB.AddParameters(27, "Designation", objCandRes.Designation, DbType.String);
            objDB.AddParameters(28, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Cand_Recruit");
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Yours registration is done Successfully ";
            }
            if (Retsuccess == "4")
            {
                retv = "You are already resgistered.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
            
        }
        return retv;

    }
    [OperationContract]
    public string insertselectedcandidate(List<HRM.Recruitment.selctedcandDM> objslctcand)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer,objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string Retsuccess = string.Empty;
            foreach (HRM.Recruitment.selctedcandDM objslcnd in objslctcand)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "id", objslcnd.id, DbType.Int32);
                objDB.AddParameters(1, "deptid", objslcnd.deptid, DbType.Int32);
                objDB.AddParameters(2, "desigid", objslcnd.desigid, DbType.Int32);
                objDB.AddParameters(3, "jobid", objslcnd.jobid, DbType.Int32);
                objDB.AddParameters(4, "jobtitle", objslcnd.jobtitle, DbType.String);
                objDB.AddParameters(5, "candid", objslcnd.candid, DbType.Int32);
                objDB.AddParameters(6, "payscale", objslcnd.payscale, DbType.String);
                objDB.AddParameters(7, "InstituteID", objslcnd.InstituteID, DbType.Int32);
                objDB.AddParameters(8, "SessionID", objslcnd.SessionID, DbType.String);
                objDB.AddParameters(9, "UserID", objslcnd.UserID, DbType.String);
                objDB.AddParameters(10, "UEDate", objslcnd.UEDate, DbType.DateTime);
                objDB.AddParameters(11, "flag", objslcnd.flag, DbType.String);
                objDB.AddParameters(12, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Hr_SelectedCand");
                Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
            }
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            if (Retsuccess == "2")
            {
                retv = "Update successfuly.";
            }
            else if (Retsuccess == "3")
            {
                retv = "Delete successfully";
            }
            else if (Retsuccess == "4")
            {
                retv = "Record already exists.";
            }
            else if (Retsuccess == "5")
            {
                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
            
        }
        return retv;
    }
    [OperationContract]
    public List<HRM.Recruitment.selctedcandDM> fillslcsnd(Int32 catid, Int32 deptid, Int32 desigid, Int32 instituteid)
    {
        var listitem = new List<HRM.Recruitment.selctedcandDM>();
        SqlConnection con = new SqlConnection(ReturnConString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@flag", "S");
        cmd.Parameters.AddWithValue("@catid",catid); 
        cmd.Parameters.AddWithValue("@deptid", deptid);
        cmd.Parameters.AddWithValue("@desigid", desigid);
        cmd.Parameters.AddWithValue("@instituteid", instituteid);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_Hr_SelectedCand";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var item = new HRM.Recruitment.selctedcandDM();
            item.name = dr["name"].ToString();
            item.candid = Int32.Parse(dr["candid"].ToString());
            item.payscale = dr["payscale"].ToString();
            listitem.Add(item);
        }
        dr.Dispose();
        dr.Close();
        return listitem;
    }
    public RecruitmentSvc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
