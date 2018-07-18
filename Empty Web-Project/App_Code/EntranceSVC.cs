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
public class EntranceSVC
{
    //Add [WebGet] attribute to use HTTP GET
    
    [OperationContract]
    public string InsertIssueForm(EntranceDM.IssueForm objIFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "srno", objIFM.srno, DbType.Int32);
            objDB.AddParameters(1, "formsquantity", objIFM.formsquantity, DbType.Int32);
            objDB.AddParameters(2, "issueto", objIFM.issueto, DbType.String);
            objDB.AddParameters(3, "rateperform", objIFM.rateperform, DbType.String);
            objDB.AddParameters(4, "issuedate", objIFM.issuedate, DbType.DateTime);
            objDB.AddParameters(5, "flag", objIFM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Issueform_insert");
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
                retv = "Record saved.";
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
    public string InsertSaleForm(EntranceDM.SaleForm objSFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "saleID", objSFM.saleID, DbType.Int32);
            objDB.AddParameters(1, "formsrno", objSFM.formsrno, DbType.Int32);
            objDB.AddParameters(2, "issuedate", objSFM.issuedate, DbType.DateTime);
            objDB.AddParameters(3, "fname", objSFM.fname, DbType.String);
            objDB.AddParameters(4, "mname", objSFM.mname, DbType.String);
            objDB.AddParameters(5, "lname", objSFM.lname, DbType.String);
            objDB.AddParameters(6, "contactno", objSFM.contactno, DbType.String);
            objDB.AddParameters(7, "amount", objSFM.amount, DbType.String);
            objDB.AddParameters(8, "paymentmode", objSFM.paymentmode, DbType.Int32);
            objDB.AddParameters(9, "issueto", objSFM.issueto, DbType.String);
            objDB.AddParameters(10, "formsquantity", objSFM.formsquantity, DbType.Int32);
            objDB.AddParameters(11, "flag", objSFM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Saleform_insert");
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
            if (objSFM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objSFM.Flag == "U")
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
    public string InsertOfflineForm(EntranceDM.OfflineForm objOFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(7);
            objDB.AddParameters(0, "offlineID", objOFM.offlineID, DbType.Int32);
            objDB.AddParameters(1, "formno", objOFM.formno, DbType.Int32);
            objDB.AddParameters(2, "date", objOFM.date, DbType.DateTime);
            objDB.AddParameters(3, "status", objOFM.status, DbType.String);
            objDB.AddParameters(4, "remark", objOFM.remark, DbType.String);
            objDB.AddParameters(5, "submitby", objOFM.submitby, DbType.String);
            objDB.AddParameters(6, "flag", objOFM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "OfflineForm_insert");
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
            if (objOFM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objOFM.Flag == "U")
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
    public string InsertVerificationForm(EntranceDM.VerificationForm objVFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "onlineID", objVFM.onlineID, DbType.Int32);
            objDB.AddParameters(1, "status", objVFM.status, DbType.String);
            objDB.AddParameters(2, "Paymentstatus", objVFM.Paymentstatus, DbType.String);
            objDB.AddParameters(3, "remark", objVFM.remark, DbType.String);
            objDB.AddParameters(4, "remarkedby", objVFM.remarkedby, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VerificationForm_insert");

         
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
     public string InsertSubjectForm(EntranceDM.SubjectForm objSFM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "subID", objSFM.subID, DbType.Int32);
            objDB.AddParameters(1, "subname", objSFM.subname, DbType.String);
            objDB.AddParameters(2, "subcode", objSFM.subcode, DbType.String);
            objDB.AddParameters(3, "flag", objSFM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ExamSubject_insert");
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
            if (objSFM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objSFM.Flag == "U")
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
     public string InsertExamForm(EntranceDM.ExamForm objEFM,List<EntranceDM.ExamChild> objEFMC, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "ES_ID", objEFM.ES_ID, DbType.Int32);
             objDB.AddParameters(1, "ExamSchdule", objEFM.ExamSchdule, DbType.String);
             objDB.AddParameters(2, "ExamID", objEFM.ExamID, DbType.Int32);
             objDB.AddParameters(3, "examdate", objEFM.examdate, DbType.DateTime);
             objDB.AddParameters(4, "examtimefrom", objEFM.examtimefrom, DbType.String);
             objDB.AddParameters(5, "examtimeto", objEFM.examtimeto, DbType.String);
             objDB.AddParameters(6, "ExamYear", objEFM.ExamYear, DbType.String);
             objDB.AddParameters(7, "Status", objEFM.Status, DbType.Int32);
             objDB.AddParameters(8, "Flag", objEFM.Flag, DbType.String);
             objDB.AddParameters(9, "ES_IDReturn", "0", DbType.String, ParameterDirection.Output);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ExamForm_insert");
             
             Int32 ESID = 0;
             if (objEFM.Flag == "U")
             {
                 ESID = objEFM.ES_ID;
             }
             else
             {
                 ESID = Int32.Parse(objDB.Parameters[9].Value.ToString());
             }

             foreach (EntranceDM.ExamChild std in objEFMC)
             {
                 objDB.CreateParameters(5);
                 objDB.AddParameters(0, "ES_ID", ESID, DbType.Int32);
                 objDB.AddParameters(1, "ExamID", std.ExamID, DbType.Int32);
                 objDB.AddParameters(2, "subID", std.subID, DbType.Int32);
                 objDB.AddParameters(3, "examdate", std.examdate, DbType.DateTime);
                 objDB.AddParameters(4, "Flag", std.Flag, DbType.String);
                 objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ExamChild_insert");
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
             if (objEFM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objEFM.Flag == "U")
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
     public string InsertVenueForm(EntranceDM.VenueForm objVFM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "ID", objVFM.ID, DbType.Int32);
             objDB.AddParameters(1, "venuename", objVFM.venuename, DbType.String);
             objDB.AddParameters(2, "venueID", objVFM.venueID, DbType.String);
             objDB.AddParameters(3, "seatavailability", objVFM.seatavailability, DbType.String);
             objDB.AddParameters(4, "flag", objVFM.Flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "EntranceVenue_insert");
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
             if (objVFM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objVFM.Flag == "U")
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
     public string InsertEntranceRoomForm(EntranceDM.EntranceRoomForm objRFM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "RoomId", objRFM.RoomId, DbType.Int32);
             objDB.AddParameters(1, "Roomno", objRFM.Roomno, DbType.String);
             objDB.AddParameters(2, "roomst", objRFM.roomst, DbType.Int32);
             objDB.AddParameters(3, "venuename", objRFM.venuename, DbType.String);
             objDB.AddParameters(4, "venuest", objRFM.venuest, DbType.String);
             objDB.AddParameters(5, "flag", objRFM.Flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Entrance_Room_insert");
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
             if (objRFM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objRFM.Flag == "U")
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
     public string InsertExamNameForm(EntranceDM.ExamNameForm objENM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "ExamID", objENM.ExamID, DbType.Int32);
             objDB.AddParameters(1, "examname", objENM.examname, DbType.String);
             objDB.AddParameters(2, "examcode", objENM.examcode, DbType.String);
             objDB.AddParameters(3, "flag", objENM.Flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ExamName_insert");
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
             if (objENM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objENM.Flag == "U")
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
     public string InsertSeatingForm(EntranceDM.EntranceSeat objESM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "ID", objESM.ID, DbType.Int32);
             objDB.AddParameters(1, "Examname", objESM.Examname, DbType.Int32);
             objDB.AddParameters(2, "Examvenue", objESM.Examvenue, DbType.String);
             objDB.AddParameters(3, "Venuestr", objESM.Venuestr, DbType.String);
             objDB.AddParameters(4, "Roomno", objESM.Roomno, DbType.String);
             objDB.AddParameters(5, "Roomstr", objESM.Roomstr, DbType.String);
             objDB.AddParameters(6, "Rowsno", objESM.Rowsno, DbType.String);
             objDB.AddParameters(7, "ColumnNo", objESM.ColumnNo, DbType.String);
             objDB.AddParameters(8, "Date", objESM.Date, DbType.DateTime);
             objDB.AddParameters(9, "Timefrom", objESM.Timefrom, DbType.String);
             objDB.AddParameters(10, "Timeto", objESM.Timeto, DbType.String);
             objDB.AddParameters(11, "seatcode", objESM.seatcode,DbType.String);
             objDB.AddParameters(12, "ExamYear", objESM.ExamYear, DbType.String);
             objDB.AddParameters(13, "Flag", objESM.Flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "EntranceSeat_insert");
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
             if (objESM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objESM.Flag == "U")
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
     public string InsertRollNoForm(EntranceDM.RollNoForm objRNM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "onlineID", objRNM.onlineID, DbType.Int32);
             objDB.AddParameters(1, "ExamID", objRNM.ExamID, DbType.Int32);
             objDB.AddParameters(2, "Srollno", objRNM.Srollno, DbType.Int32);
             objDB.AddParameters(3, "Status", objRNM.Status, DbType.String);
             objDB.AddParameters(4, "Flag", objRNM.Flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "RollNo_insert");


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

             if (objRNM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objRNM.Flag == "U")
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
     public string InsertAdmitCardForm(EntranceDM.AdmitCardForm objACM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "onlineID", objACM.onlineID, DbType.Int32);
             objDB.AddParameters(1, "ExamID", objACM.ExamID, DbType.Int32);
             objDB.AddParameters(2, "Srollno", objACM.Srollno, DbType.Int32);
             objDB.AddParameters(3, "Dispatchno", objACM.Dispatchno, DbType.Int32);
             objDB.AddParameters(4, "Flag", objACM.Flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AdmitCard_insert");


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

             if (objACM.Flag == "N")
             {
                 retv = "Record saved.";
             }
             else if (objACM.Flag == "U")
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
    public string InsertSeatManagement(List<EntranceDM.EN_SeatManagement> objESM, Admin.AdministratorData.AuditDM audit)
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
            foreach (EntranceDM.EN_SeatManagement ESM in objESM)
            {
                objDB.CreateParameters(5);
                objDB.AddParameters(0, "SeatMgmtID", ESM.SeatMgmtID, DbType.Int32);
                objDB.AddParameters(1, "RollnoFrom", ESM.RollnoFrom, DbType.String);
                objDB.AddParameters(2, "RollnoTo", ESM.RollnoTo, DbType.String);
                objDB.AddParameters(3, "SeatCode", ESM.SeatCode, DbType.String);
                objDB.AddParameters(4, "Flag", ESM.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Seat_Management_Insert");

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
}