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
using System.Web.UI.WebControls;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class FeeServices
{
    [OperationContract]
    public string InsertPaymentMode(FeesDM.PaymentModeData objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "PMID", objFDM.PMID, DbType.Int32);
            objDB.AddParameters(1, "PaymentMode", objFDM.PaymentMode, DbType.String);
            objDB.AddParameters(2, "ShortName", objFDM.Shortname, DbType.String);
            objDB.AddParameters(3, "Nature", objFDM.Nature, DbType.String);
            objDB.AddParameters(4, "IsPredefined", objFDM.IsPredefined, DbType.Int32);
            objDB.AddParameters(5, "BankRequired", objFDM.BankRequired, DbType.Int32);
            objDB.AddParameters(6, "DocRequired", objFDM.DocRequired, DbType.Int32);
            objDB.AddParameters(7, "flag", objFDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Paymentmode_insert");
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
            if (objFDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == "U")
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
    public string InsertBankDetail(FeesDM.BankDetailData objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "BankID", objFDM.BankID, DbType.Int32);
            objDB.AddParameters(1, "BankName", objFDM.BankName, DbType.String);
            objDB.AddParameters(2, "ShortName", objFDM.Shortname, DbType.String);
            objDB.AddParameters(3, "BankCode", objFDM.BankCode, DbType.String);
            objDB.AddParameters(4, "flag", objFDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "BankDetail_insert");
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
            if (objFDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == "U")
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
    public string InsertODCDetail(FeesDM.ODCChargeData objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "ODCID", objFDM.ODCID, DbType.Int32);
            objDB.AddParameters(1, "ODC_Name", objFDM.ODC_Name, DbType.String);
            objDB.AddParameters(2, "shortName", objFDM.Shortname, DbType.String);
            objDB.AddParameters(3, "Wef_Date", objFDM.Wef_Date, DbType.DateTime);
            objDB.AddParameters(4, "Day_Duration", objFDM.Day_Duration, DbType.Int32);
            objDB.AddParameters(5, "ODCAfterDay", objFDM.ODCAfterDay, DbType.Int32);
            objDB.AddParameters(6, "AmountAfterDue", objFDM.AmountAfterDue, DbType.Decimal);
            objDB.AddParameters(7, "Applicable_On", objFDM.Applicable_On, DbType.Int32);
            objDB.AddParameters(8, "Flag", objFDM.Flag, DbType.String);
            objDB.AddParameters(9, "LedgerID", objFDM.LegderID, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ODCcharge_Insert");
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
            if (objFDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == "U")
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
    public string InsertFeeHead(FeesDM.FeeHeadData objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "FeeHeadId", objFDM.FeeHeadId, DbType.Int32);
            objDB.AddParameters(1, "FeeHeadName", objFDM.FeeHeadName, DbType.String);
            objDB.AddParameters(2, "Shortname", objFDM.Shortname, DbType.String);
            objDB.AddParameters(3, "Nature", objFDM.Nature, DbType.String);
            objDB.AddParameters(4, "SubCategory", objFDM.SubCategory, DbType.String);
            objDB.AddParameters(5, "InstituteID", objFDM.InstituteID, DbType.Int32);
            objDB.AddParameters(6, "SessionID", objFDM.SessionID, DbType.String);
            objDB.AddParameters(7, "apply_head", objFDM.apply_head, DbType.Int32);
            objDB.AddParameters(8, "FeeOrder", objFDM.FeeOrder, DbType.Int32);
            objDB.AddParameters(9, "Flag", objFDM.Flag, DbType.String);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeeHead_Insert");
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
            if (objFDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == "U")
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
    //public class FeeHeadData
    //{
    //    [DataMember]
    //    public int FeeHeadId { get; set; }
    //    [DataMember]
    //    public string FeeHeadName { get; set; }
    //    [DataMember]
    //    public string Shortname { get; set; }
    //    [DataMember]
    //    public string Nature { get; set; }
    //    [DataMember]
    //    public string SubCategory { get; set; }
    //    [DataMember]
    //    public int InstituteID { get; set; }
    //    [DataMember]
    //    public string SessionID { get; set; }
    //    [DataMember]
    //    public int apply_head { get; set; }
    //    [DataMember]
    //    public int FeeOrder { get; set; }
    //    [DataMember]
    //    public string Flag { get; set; }


    //}

    [OperationContract]
    public List<FeesDM.Fee_Student> FillFeeStudent(string CourseID, string Batch, string Yearid, string Status)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "CourseID", Int32.Parse(CourseID), DbType.Int32);
        objDB.AddParameters(1, "Batch", Batch, DbType.String);
        objDB.AddParameters(2, "Status", Status, DbType.String);
        objDB.AddParameters(3, "YearID", Yearid, DbType.String);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Student");
        var listOfCustomerItems = new List<FeesDM.Fee_Student>();
        while (dr.Read())
        {
            var item = new FeesDM.Fee_Student();
            item.FeeHeadId = int.Parse(dr[0].ToString());
            item.FeeHeadName = dr[1].ToString();
            item.TotalAmount = decimal.Parse(dr[2].ToString());
            item.Amount = decimal.Parse(dr[3].ToString());
            item.BreakOffTime = dr[4].ToString();
            item.LastDate = DateTime.Parse(dr[5].ToString());
            item.courseFeeid = Int32.Parse(dr[6].ToString());
            item.sid = Int32.Parse(dr[12].ToString());
            item.FeeClass = dr[14].ToString();
            item.Shortname = dr[7].ToString();
            item.Session = dr[16].ToString();
            listOfCustomerItems.Add(item);

        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return listOfCustomerItems;
    }


    [OperationContract]
    public string InsertRCNO(FeesDM.RCNODM objRDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "rcnoid", objRDM.rcnoid, DbType.Int32);
            objDB.AddParameters(1, "instid", objRDM.instid, DbType.Int32);
            objDB.AddParameters(2, "coursid", objRDM.coursid, DbType.Int32);
            objDB.AddParameters(3, "sessnid", objRDM.sessnid, DbType.String);
            objDB.AddParameters(4, "prefix", objRDM.prefix, DbType.String);
            objDB.AddParameters(5, "startfrm", objRDM.startfrm, DbType.Int32);
            objDB.AddParameters(6, "upto", objRDM.upto, DbType.Int32);
            objDB.AddParameters(7, "lastused", objRDM.lastused, DbType.Int32);
            objDB.AddParameters(8, "status", objRDM.status, DbType.String);
            objDB.AddParameters(9, "flag", objRDM.flag, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "RCNO_Insert");
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
            if (objRDM.flag == 0)
            {
                retv = "Record saved.";
            }
            else if (objRDM.flag == 1)
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
    public string InsertRefund(FeesDM.FeeRefund objFR)
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
            //foreach (Academic.AcademicData.ExternalExamDetailDM fb in objF)
            //{
            objDB.CreateParameters(26);
            objDB.AddParameters(0, "RefundID", objFR.RefundID, DbType.Int32);
            objDB.AddParameters(1, "InstituteID", objFR.InstituteID, DbType.Int32);
            objDB.AddParameters(2, "Session", objFR.Session, DbType.String);
            objDB.AddParameters(3, "VoucherNo", objFR.VoucherNo, DbType.String);
            objDB.AddParameters(4, "CourseID", objFR.CourseID, DbType.Int32);
            objDB.AddParameters(5, "StudentID", objFR.StudentID, DbType.Int32);
            objDB.AddParameters(6, "PID", objFR.PID, DbType.Int32);
            objDB.AddParameters(7, "AccountNoID", objFR.AccountNoID, DbType.Int32);
            objDB.AddParameters(8, "TotalAmt", objFR.TotalAmt, DbType.Decimal);
            objDB.AddParameters(9, "PaidAmt", objFR.PaidAmt, DbType.Decimal);
            objDB.AddParameters(10, "BalAmt", objFR.BalAmt, DbType.Decimal);
            objDB.AddParameters(11, "BankID", objFR.BankID, DbType.Int32);
            objDB.AddParameters(12, "DDNo", objFR.DDNo, DbType.Int32);
            objDB.AddParameters(13, "DDate", objFR.DDate, DbType.DateTime);
            objDB.AddParameters(14, "UName", objFR.UName, DbType.String);
            objDB.AddParameters(15, "UEntDate", objFR.UEntDate, DbType.DateTime);
            objDB.AddParameters(16, "RefFeeID", objFR.RefFeeID, DbType.Int32);
            objDB.AddParameters(17, "FeeID", objFR.FeeID, DbType.Int32);
            objDB.AddParameters(18, "RCNO", objFR.RCNO, DbType.Int32);
            objDB.AddParameters(19, "PrNo", objFR.PrNo, DbType.String);
            objDB.AddParameters(20, "RefRCNO", objFR.RefRCNO, DbType.Int32);
            objDB.AddParameters(21, "RefPrNo", objFR.RefPrNo, DbType.String);
            objDB.AddParameters(22, "DueDate", objFR.DueDate, DbType.DateTime);
            objDB.AddParameters(23, "RefType", objFR.RefType, DbType.String);
            objDB.AddParameters(24, "Narration", objFR.Narration, DbType.String);
            objDB.AddParameters(25, "RefRetType", objFR.RefRetType, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Refund_Insert");


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
    public string InsertReceiptCancellation(FeesDM.ReceiptCancellation objRC, List<FeesDM.RCancelStudent> objFSC, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "RCancelID", objRC.RCancelID, DbType.Int32);
            objDB.AddParameters(1, "ReceiptNo", objRC.ReceiptNo, DbType.String);
            objDB.AddParameters(2, "StudentID", objRC.StudentID, DbType.Int32);
            objDB.AddParameters(3, "PPSNO", objRC.PPSNO, DbType.Int32);
            objDB.AddParameters(4, "YearID", objRC.YearID, DbType.String);
            objDB.AddParameters(5, "SemID", objRC.SemID, DbType.Int32);
            objDB.AddParameters(6, "AmtCancelled", objRC.AmtCancelled, DbType.Decimal);
            objDB.AddParameters(7, "UName", objRC.UName, DbType.String);
            objDB.AddParameters(8, "UEntDate", objRC.UEntDate, DbType.DateTime);
            objDB.AddParameters(9, "Session", objRC.Session, DbType.String);
            objDB.AddParameters(10, "InstituteId", objRC.InstituteId, DbType.Int32);
            objDB.AddParameters(11, "CCharge", objRC.CCharge, DbType.Decimal);
            objDB.AddParameters(12, "CDate", objRC.CDate, DbType.DateTime);
            objDB.AddParameters(13, "FTransDate", objRC.FTransDate, DbType.DateTime);
            objDB.AddParameters(14, "Pid", objRC.Pid, DbType.String);
            objDB.AddParameters(15, "DDNO", objRC.DDNO, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Receipt_Cancellation_Insert");

            foreach (FeesDM.RCancelStudent std in objFSC)
            {
                objDB.CreateParameters(5);
                objDB.AddParameters(0, "ReceiptNo", std.ReceiptNo, DbType.String);
                objDB.AddParameters(1, "StudentID", std.StudentID, DbType.Int32);
                objDB.AddParameters(2, "FeeID", std.FeeID, DbType.Decimal);
                objDB.AddParameters(3, "SemID", std.SemID, DbType.Int32);
                objDB.AddParameters(4, "PaidAmt", std.PaidAmt, DbType.Decimal);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "RCancel_StudentDetail");
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

            //if (objRDM.flag == 0)
            //{
            //    retv = "Record saved.";
            //}
            //else if (objRDM.flag == 1)
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
    public string InsertChequeDefaultEntry(FeesDM.ChequeDefaultEntryM objRC, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "DefaultID", objRC.DefaultID, DbType.Int32);
            objDB.AddParameters(1, "InstituteID", objRC.InstituteID, DbType.Int32);
            objDB.AddParameters(2, "SessionID", objRC.SessionID, DbType.String);
            objDB.AddParameters(3, "Trans_Date", objRC.Trans_Date, DbType.DateTime);
            objDB.AddParameters(4, "Doc_Type", objRC.Doc_Type, DbType.String);
            objDB.AddParameters(5, "Def_ChqNo", objRC.Def_ChqNo, DbType.Int32);
            objDB.AddParameters(6, "Def_ChqDate", objRC.Def_ChqDate, DbType.DateTime);
            objDB.AddParameters(7, "Def_ChqAmt", objRC.Def_ChqAmt, DbType.Decimal);
            objDB.AddParameters(8, "PPSNO", objRC.PPSNO, DbType.Int32);
            objDB.AddParameters(9, "StudentID", objRC.StudentID, DbType.Int32);
            objDB.AddParameters(10, "UName", objRC.UName, DbType.String);
            objDB.AddParameters(11, "UEntDate", objRC.UEntDate, DbType.DateTime);
            //objDB.AddParameters(12, "PaidAmt", objRC.PaidAmt, DbType.DateTime);
            //objDB.AddParameters(13, "BalAmt", objRC.BalAmt, DbType.String);
            //objDB.AddParameters(14, "IBank", objRC.IBank, DbType.Int32);
            //objDB.AddParameters(15, "New_ChqNo", objRC.New_ChqNo, DbType.DateTime);
            //objDB.AddParameters(16, "New_ChqDate", objRC.New_ChqDate, DbType.String);
            //objDB.AddParameters(17, "New_ChqAmt", objRC.New_ChqAmt, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Chq_Draft_Default_Insert");

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

            //if (objRDM.flag == 0)
            //{
            //    retv = "Record saved.";
            //}
            //else if (objRDM.flag == 1)
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
    public string InsertChangePayMode(List<FeesDM.ChangePayMode> objFSC, Admin.AdministratorData.AuditDM audit)
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
            foreach (FeesDM.ChangePayMode std in objFSC)
            {

                objDB.CreateParameters(17);
                objDB.AddParameters(0, "ModeID", std.ModeID, DbType.Int32);
                objDB.AddParameters(1, "ReceiptNo", std.ReceiptNo, DbType.String);
                objDB.AddParameters(2, "LastPMode", std.LastPMode, DbType.Int32);
                objDB.AddParameters(3, "CurrentPMode", std.CurrentPMode, DbType.Int32);
                objDB.AddParameters(4, "LastAmount", std.Amount, DbType.Decimal);
                objDB.AddParameters(5, "LastDNO", std.LastDNO, DbType.Int32);
                objDB.AddParameters(6, "LastDDate", std.LastDDate, DbType.DateTime);
                objDB.AddParameters(7, "CurrentDNO", std.CurrentDNO, DbType.Int32);
                objDB.AddParameters(8, "CurrentDDate", std.CurrentDDate, DbType.DateTime);
                objDB.AddParameters(9, "Amount", std.Amount, DbType.Decimal);
                objDB.AddParameters(10, "StudentID", std.StudentID, DbType.Int32);
                objDB.AddParameters(11, "SNo", std.SNo, DbType.Int32);
                objDB.AddParameters(12, "PayM", std.PayM, DbType.String);
                objDB.AddParameters(13, "PID", std.PID, DbType.Int32);
                objDB.AddParameters(14, "InstituteID", std.InstituteID, DbType.Int32);
                objDB.AddParameters(15, "SessionID", std.SessionID, DbType.String);
                objDB.AddParameters(16, "BankID", std.BankID, DbType.Int32);
                //objDB.AddParameters(13, "DDNO", std.DDNO, DbType.Int32);
                //objDB.AddParameters(14, "DateP", std.DateP, DbType.DateTime);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ChangePaymentMode_Insert");


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

            //if (objRDM.flag == 0)
            //{
            //    retv = "Record saved.";
            //}
            //else if (objRDM.flag == 1)
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


    //[OperationContract]
    //public string InsertChangePayModeN(List<FeesDM.ChangePayModeN> objFSC, Admin.AdministratorData.AuditDM audit)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.BeginTransaction();
    //    string retv = "";
    //    string f = "";
    //    try
    //    {
    //        foreach (FeesDM.ChangePayModeN std in objFSC)
    //        {
    //            objDB.CreateParameters(6);
    //            objDB.AddParameters(0, "SNo", std.SNo, DbType.Int32);
    //            objDB.AddParameters(1, "PRNO", std.PRNO, DbType.String);
    //            objDB.AddParameters(2, "PayM", std.PayM, DbType.String);
    //            objDB.AddParameters(3, "PID", std.PID, DbType.Int32);
    //            objDB.AddParameters(4, "DDNO", std.DDNO, DbType.Int32);
    //            objDB.AddParameters(5, "DateP", std.DateP, DbType.DateTime);
    //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ChangePaymentMode_Update");
    //        }

    //        objDB.CreateParameters(9);
    //        objDB.AddParameters(0, "ID", 0, DbType.Int32);
    //        objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
    //        objDB.AddParameters(2, "Action", audit.Action, DbType.String);
    //        objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
    //        objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
    //        objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
    //        objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
    //        objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
    //        objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
    //        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
    //        objDB.Transaction.Commit();

    //        retv = "Record saved.";

    //        //if (objRDM.flag == 0)
    //        //{
    //        //    retv = "Record saved.";
    //        //}
    //        //else if (objRDM.flag == 1)
    //        //{
    //        //    retv = "Record Updated Successfully.";
    //        //}
    //        //else
    //        //{
    //        //    retv = "Record deleted Successfully.";
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        objDB.Transaction.Rollback();
    //        retv = "Unable to save record :-" + ex.Message.ToString();
    //    }
    //    return retv;
    //}


    [OperationContract]
    public string InsertChequeDefaultNEntry(List<FeesDM.ChequeDefaultEntryC> objFSC, Admin.AdministratorData.AuditDM audit)
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

            foreach (FeesDM.ChequeDefaultEntryC std in objFSC)
            {
                objDB.CreateParameters(14);
                objDB.AddParameters(0, "DefID", std.DefID, DbType.Int32);
                //objDB.AddParameters(1, "DChqNo", std.DChqNo, DbType.Int32);
                objDB.AddParameters(1, "PMode", std.PMode, DbType.Int32);
                //objDB.AddParameters(3, "TotalAmt", std.TotalAmt, DbType.String);
                objDB.AddParameters(2, "PaidAmt", std.PaidAmt, DbType.Decimal);
                //objDB.AddParameters(5, "BalAmt", std.BalAmt, DbType.String);
                objDB.AddParameters(3, "IBank", std.IBank, DbType.Int32);
                objDB.AddParameters(4, "ChqNo", std.ChqNo, DbType.Int32);
                objDB.AddParameters(5, "ChqDate", std.ChqDate, DbType.DateTime);
                objDB.AddParameters(6, "ChqAmt", std.ChqAmt, DbType.Decimal);
                objDB.AddParameters(7, "ChqDDNo", std.ChqDDNo, DbType.Int32);
                objDB.AddParameters(8, "StudentID", std.StudentID, DbType.Int32);
                objDB.AddParameters(9, "UName", std.UName, DbType.String);
                objDB.AddParameters(10, "UEntDate", std.UEntDate, DbType.DateTime);
                objDB.AddParameters(11, "SessionID", std.SessionID, DbType.String);
                objDB.AddParameters(12, "InstituteID", std.InstituteID, DbType.Int32);
                objDB.AddParameters(14, "Status", std.Status, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Chq_Draft_DefaultN_Insert");
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

            //if (objRDM.flag == 0)
            //{
            //    retv = "Record saved.";
            //}
            //else if (objRDM.flag == 1)
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
    public string InsertFeeStruc(FeesDM.FeeStructMDM objFSDM, FeesDM.FeeStructCDM objFSC, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "courseFeeId", objFSDM.courseFeeId, DbType.Int32);
            objDB.AddParameters(1, "SessionCode", objFSDM.SessionCode, DbType.String);
            objDB.AddParameters(2, "CourseCode", objFSDM.CourseCode, DbType.String);
            objDB.AddParameters(3, "SpecialisationCode", objFSDM.SpecialisationCode, DbType.String);
            objDB.AddParameters(4, "FeeHeadCode", objFSDM.FeeHeadCode, DbType.String);
            objDB.AddParameters(5, "TotalAmount", objFSDM.TotalAmount, DbType.Decimal);
            objDB.AddParameters(6, "FeeClass", objFSDM.FeeClass, DbType.String);
            objDB.AddParameters(7, "Category", objFSDM.Category, DbType.String);
            objDB.AddParameters(8, "InstituteID", objFSDM.InstituteID, DbType.Int32);
            objDB.AddParameters(9, "SessionID", objFSDM.SessionID, DbType.String);
            objDB.AddParameters(10, "UName", objFSDM.UName, DbType.String);
            objDB.AddParameters(11, "UEntDt", objFSDM.UEntDt, DbType.DateTime);
            objDB.AddParameters(12, "CCategory", objFSDM.CCategory, DbType.String);
            objDB.AddParameters(13, "CID", objFSDM.CID, DbType.String);
            objDB.AddParameters(14, "yearid", objFSDM.yrid, DbType.String);
            objDB.AddParameters(15, "odc", objFSDM.odc, DbType.String);
            objDB.AddParameters(16, "batch", objFSDM.batch, DbType.String);
            objDB.AddParameters(17, "StudentType", objFSDM.StudentType, DbType.String);
            objDB.AddParameters(18, "flag", objFSDM.flag, DbType.String);
            objDB.AddParameters(19, "FeeIDreturn", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Struc_M_Insert");
            Int32 fid = 0;
            if (objFSDM.flag == "U")
            {
                fid = objFSDM.courseFeeId;
            }
            else
            {
                fid = Int32.Parse(objDB.Parameters[19].Value.ToString());
            }

            //foreach (FeesDM.FeeStructCDM std in objFSC)
            //{
            objDB.CreateParameters(7);
            objDB.AddParameters(0, "courseFeeId", fid, DbType.Int32);
            objDB.AddParameters(1, "srNo", objFSC.srNo, DbType.Int32);
            objDB.AddParameters(2, "BreakoffTime", objFSC.BreakoffTime, DbType.String);
            objDB.AddParameters(3, "Amount", objFSC.Amount, DbType.Decimal);
            objDB.AddParameters(4, "LastDate", objFSC.LastDate, DbType.DateTime);
            objDB.AddParameters(5, "DefaultHead", objFSC.DefaultHead, DbType.String);
            objDB.AddParameters(6, "flag", objFSC.flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Struc_C_Insert");
            //}

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
            if (objFSDM.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFSDM.flag == "U")
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
    public string InsertFeeDeposition(List<FeesDM.FeeTransDetail> objFSDM, List<FeesDM.FeePayDetail> objFSC, List<FeesDM.AdvDepositeFee> objADF, Admin.AdministratorData.AuditDM audit)
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
            foreach (FeesDM.FeeTransDetail fd in objFSDM)
            {
                objDB.CreateParameters(23);
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
                objDB.AddParameters(12, "SID", fd.Sid, DbType.Int32);
                objDB.AddParameters(13, "Year", fd.Year, DbType.Int32);
                objDB.AddParameters(14, "InstID", fd.InstId, DbType.Int32);
                objDB.AddParameters(15, "duedate", fd.duedate, DbType.DateTime);
                //objDB.AddParameters(16, "RCNOID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                objDB.AddParameters(16, "PaidAmount", fd.PaidAmount, DbType.Decimal);
                objDB.AddParameters(17, "BalAmount", fd.BalAmount, DbType.Decimal);
                objDB.AddParameters(18, "PrnoId", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
                objDB.AddParameters(19, "Used", fd.Used, DbType.String);
                objDB.AddParameters(20, "LastUsed", fd.LastUsed, DbType.String);
                objDB.AddParameters(21, "FeeSubId", fd.FeeSubId, DbType.Int32);
                objDB.AddParameters(22, "Trans_State", "T", DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Trans_Detail_Insert");
            }
            //Int32 rcnoid = 0;
            string prnoid = String.Empty;
            // rcnoid = Int32.Parse(objDB.Parameters[16].Value.ToString());
            prnoid = objDB.Parameters[18].Value.ToString();

            foreach (FeesDM.FeePayDetail ftd in objFSC)
            {
                objDB.CreateParameters(22);
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
                objDB.AddParameters(13, "SID", ftd.Sid, DbType.Int32);
                objDB.AddParameters(14, "Year", ftd.Year, DbType.Int32);
                objDB.AddParameters(15, "InstID", ftd.InstId, DbType.Int32);
                objDB.AddParameters(16, "BankID", ftd.BankID, DbType.Int32);
                objDB.AddParameters(17, "Used", ftd.Used, DbType.String);
                objDB.AddParameters(18, "LastUsed", ftd.LastUsed, DbType.String);
                objDB.AddParameters(19, "FeeId", ftd.FeeId, DbType.Int32);
                objDB.AddParameters(20, "FeeSubId", ftd.FeeSubId, DbType.Int32);
                objDB.AddParameters(21, "Trans_State", "T", DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_PayDetails_Insert");
            }


            foreach (FeesDM.AdvDepositeFee afd in objADF)
            {
                objDB.CreateParameters(12);
                objDB.AddParameters(0, "Id", 0, DbType.Int32);
                objDB.AddParameters(1, "Adv_Rcno", afd.Adv_Rcno, DbType.Int32);
                objDB.AddParameters(2, "Deducted_Amt", afd.Deducted_Amt, DbType.Decimal);
                objDB.AddParameters(3, "Paymode", afd.Paymode, DbType.String);
                objDB.AddParameters(4, "Trans_Date", afd.Trans_Date, DbType.DateTime);
                objDB.AddParameters(5, "UName", afd.UName, DbType.String);
                objDB.AddParameters(6, "UEDate", afd.UEDate, DbType.DateTime);
                objDB.AddParameters(7, "InstituteID", afd.InstituteID, DbType.Int32);
                objDB.AddParameters(8, "Session", afd.Session, DbType.String);
                objDB.AddParameters(9, "BalAmt", afd.BalAmt, DbType.Decimal);
                objDB.AddParameters(10, "IsPaid", afd.IsPaid, DbType.Int32);
                objDB.AddParameters(11, "StudentId", afd.StudentId, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AdvDepositeFee_Insert");
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
    public string InsertFeeDepositionODC(List<FeesDM.FeeTransDetail> objFSDM, List<FeesDM.FeePayDetail> objFSC, List<FeesDM.AdvDepositeFee> objADF, List<FeesDM.StudentODC> objFSDMO, List<FeesDM.StudentChild> objSC, List<FeesDM.StudentODCPMode> objFSCO, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        //int rcnoidd = 0;
        try
        {
            foreach (FeesDM.FeeTransDetail fd in objFSDM)
            {
                objDB.CreateParameters(23);
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
                objDB.AddParameters(12, "SID", fd.Sid, DbType.Int32);
                objDB.AddParameters(13, "Year", fd.Year, DbType.Int32);
                objDB.AddParameters(14, "InstID", fd.InstId, DbType.Int32);
                objDB.AddParameters(15, "duedate", fd.duedate, DbType.DateTime);
                //objDB.AddParameters(16, "RCNOID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                objDB.AddParameters(16, "PaidAmount", fd.PaidAmount, DbType.Decimal);
                objDB.AddParameters(17, "BalAmount", fd.BalAmount, DbType.Decimal);
                objDB.AddParameters(18, "PrnoId", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
                objDB.AddParameters(19, "Used", fd.Used, DbType.String);
                objDB.AddParameters(20, "LastUsed", fd.LastUsed, DbType.String);
                objDB.AddParameters(21, "FeeSubId", fd.FeeSubId, DbType.String);
                objDB.AddParameters(22, "Trans_State", "T", DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Trans_Detail_Insert");
            }
            Int32 rcnoid = 0;
            string prnoid = String.Empty;

            if (objFSDM.Count > 0)
            {
                //rcnoid = Int32.Parse(objDB.Parameters[16].Value.ToString());
                prnoid = objDB.Parameters[18].Value.ToString();
            }


            foreach (FeesDM.FeePayDetail ftd in objFSC)
            {
                objDB.CreateParameters(22);
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
                objDB.AddParameters(13, "SID", ftd.Sid, DbType.Int32);
                objDB.AddParameters(14, "Year", ftd.Year, DbType.Int32);
                objDB.AddParameters(15, "InstID", ftd.InstId, DbType.Int32);
                objDB.AddParameters(16, "BankID", ftd.BankID, DbType.Int32);
                objDB.AddParameters(17, "Used", ftd.Used, DbType.String);
                objDB.AddParameters(18, "LastUsed", ftd.LastUsed, DbType.String);
                objDB.AddParameters(19, "FeeId", ftd.FeeId, DbType.Int32);
                objDB.AddParameters(20, "FeeSubId", ftd.FeeSubId, DbType.Int32);
                objDB.AddParameters(21, "Trans_State", "T", DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_PayDetails_Insert");
            }


            foreach (FeesDM.AdvDepositeFee afd in objADF)
            {
                objDB.CreateParameters(12);
                objDB.AddParameters(0, "Id", 0, DbType.Int32);
                objDB.AddParameters(1, "Adv_Rcno", rcnoid, DbType.Int32);
                objDB.AddParameters(2, "Deducted_Amt", afd.Deducted_Amt, DbType.Decimal);
                objDB.AddParameters(3, "Paymode", afd.Paymode, DbType.String);
                objDB.AddParameters(4, "Trans_Date", afd.Trans_Date, DbType.DateTime);
                objDB.AddParameters(5, "UName", afd.UName, DbType.String);
                objDB.AddParameters(6, "UEDate", afd.UEDate, DbType.DateTime);
                objDB.AddParameters(7, "InstituteID", afd.InstituteID, DbType.Int32);
                objDB.AddParameters(8, "Session", afd.Session, DbType.String);
                objDB.AddParameters(9, "BalAmt", afd.BalAmt, DbType.Decimal);
                objDB.AddParameters(10, "IsPaid", afd.IsPaid, DbType.Int32);
                objDB.AddParameters(11, "StudentId", afd.StudentId, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AdvDepositeFee_Insert");
            }

            foreach (FeesDM.StudentODC ftdop in objFSDMO)
            {
                objDB.CreateParameters(19);
                objDB.AddParameters(0, "FeeOdcID", ftdop.FeeOdcID, DbType.Int32);
                objDB.AddParameters(1, "StudentID", ftdop.StudentID, DbType.Int32);
                objDB.AddParameters(2, "OdcID", ftdop.OdcID, DbType.Int32);
                objDB.AddParameters(3, "WefDate", ftdop.WefDate, DbType.DateTime);
                objDB.AddParameters(4, "FeeHeadID", ftdop.FeeHeadID, DbType.Int32);
                objDB.AddParameters(5, "TotalAmt", ftdop.TotalAmt, DbType.Decimal);
                objDB.AddParameters(6, "TotalPaid", ftdop.TotalPaid, DbType.Decimal);
                objDB.AddParameters(7, "TotalBal", ftdop.TotalBal, DbType.Decimal);
                objDB.AddParameters(8, "FromDate", ftdop.FromDate, DbType.DateTime);
                objDB.AddParameters(9, "ToDate", ftdop.ToDate, DbType.DateTime);
                objDB.AddParameters(10, "TotalDays", ftdop.TotalDays, DbType.Int32);
                //objDB.AddParameters(11, "Rcno", ftdop.Rcno, DbType.Int32);
                //objDB.AddParameters(12, "Prno", ftdop.Prno, DbType.String);
                objDB.AddParameters(11, "InstituteID", ftdop.InstituteID, DbType.Int32);
                objDB.AddParameters(12, "SessionID", ftdop.SessionID, DbType.String);
                objDB.AddParameters(13, "UName", ftdop.UName, DbType.String);
                objDB.AddParameters(14, "UEntDate", ftdop.UEntDate, DbType.DateTime);
                //objDB.AddParameters(17, "DueDate", ftdop.DueDate, DbType.DateTime);
                objDB.AddParameters(15, "Sid", ftdop.Sid, DbType.Int32);
                objDB.AddParameters(16, "flag", ftdop.flag, DbType.String);
                //objDB.AddParameters(17, "Fid", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                //objDB.AddParameters(18, "RcnoID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                objDB.AddParameters(17, "PayStatus", ftdop.PayStatus, DbType.String);
                objDB.AddParameters(18, "FeeSubID", ftdop.FeeSubID, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentFeeODC_Insert");
            }

            //int fid = Convert.ToInt32(objDB.Parameters[19].Value.ToString());
            //int rcno = Convert.ToInt32(objDB.Parameters[20].Value.ToString());
            //int fsubid = Convert.ToInt32(objDB.Parameters[23].Value.ToString());
            foreach (FeesDM.StudentChild ftsch in objSC)
            {
                objDB.CreateParameters(13);
                objDB.AddParameters(0, "ID", ftsch.ID, DbType.Int32);
                objDB.AddParameters(1, "FeeODCID", ftsch.FeeODCID, DbType.Int32);
                objDB.AddParameters(2, "PaidAMT", ftsch.PaidAMT, DbType.Decimal);
                objDB.AddParameters(3, "PMTDays", ftsch.PMTDays, DbType.Int32);
                objDB.AddParameters(4, "PayDate", ftsch.PayDate, DbType.DateTime);
                objDB.AddParameters(5, "PayCounter", ftsch.PayCounter, DbType.Int32);
                objDB.AddParameters(6, "StudentID", ftsch.StudentID, DbType.Int32);
                objDB.AddParameters(7, "Sid", ftsch.Sid, DbType.Int32);
                //objDB.AddParameters(8, "FeeID", fsubid, DbType.Int32);
                objDB.AddParameters(8, "FeeSubID", ftsch.FeeSubID, DbType.Int32);
                objDB.AddParameters(9, "Rcno", ftsch.Rcno, DbType.Int32);
                objDB.AddParameters(10, "Prno", ftsch.Prno, DbType.String);
                objDB.AddParameters(11, "InstituteID", ftsch.InstituteID, DbType.Int32);
                objDB.AddParameters(12, "RcnoID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "SFO_Child_Insert");
            }

            int rcnoidd = Convert.ToInt32(objDB.Parameters[12].Value.ToString());

            foreach (FeesDM.StudentODCPMode ftdo in objFSCO)
            {
                objDB.CreateParameters(11);
                objDB.AddParameters(0, "Rcno", rcnoidd, DbType.Int32);
                objDB.AddParameters(1, "Pid", ftdo.Pid, DbType.Int32);
                objDB.AddParameters(2, "DDNO", ftdo.DDNO, DbType.Int32);
                objDB.AddParameters(3, "DDate", ftdo.DDate, DbType.DateTime);
                objDB.AddParameters(4, "Amount", ftdo.Amount, DbType.Decimal);
                objDB.AddParameters(5, "BankID", ftdo.BankID, DbType.Int32);
                objDB.AddParameters(6, "StudentId", ftdo.StudentId, DbType.Int32);
                objDB.AddParameters(7, "InstituteID", ftdo.InstituteID, DbType.Int32);
                objDB.AddParameters(8, "SessionID", ftdo.SessionID, DbType.String);
                objDB.AddParameters(9, "UName", ftdo.UName, DbType.String);
                objDB.AddParameters(10, "UEntDate", ftdo.UEntDate, DbType.DateTime);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentFee_ODC_PMode_Insert");
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

            objDB.CreateParameters(1);
            objDB.AddParameters(0, "RCNOID", rcnoidd, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ID_Table_Update");

            //objDB.Command.Parameters.Clear();
            //objDB.ExecuteNonQuery(CommandType.Text, "update ID_Table set Counter='" + (rcnoidd + 1) + "' where Type='Odc' ");

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
    public string InsertFeeAdvance(List<FeesDM.Student_Advance> objSA, Admin.AdministratorData.AuditDM audit)
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
            foreach (FeesDM.Student_Advance fd in objSA)
            {
                objDB.CreateParameters(19);
                objDB.AddParameters(0, "Id", fd.Id, DbType.Int32);
                objDB.AddParameters(1, "StudentID", fd.StudentID, DbType.Int32);
                objDB.AddParameters(2, "CourseID", fd.CourseID, DbType.Int32);
                objDB.AddParameters(3, "Paymode", fd.Paymode, DbType.String);
                objDB.AddParameters(4, "TotalAmt", fd.TotalAmt, DbType.Decimal);
                objDB.AddParameters(5, "PaidAmt", fd.PaidAmt, DbType.Decimal);
                objDB.AddParameters(6, "BalAmt", fd.BalAmt, DbType.Decimal);
                objDB.AddParameters(7, "DDNo", fd.DDNo, DbType.Int32);
                objDB.AddParameters(8, "DDNoDate", fd.DDNoDate, DbType.DateTime);
                objDB.AddParameters(9, "IsPaid", fd.IsPaid, DbType.Int32);
                objDB.AddParameters(10, "Prno", fd.Prno, DbType.String);
                objDB.AddParameters(11, "Rcno", fd.Rcno, DbType.Int32);
                objDB.AddParameters(12, "Uname", fd.UName, DbType.String);
                objDB.AddParameters(13, "UEDate", fd.UEDate, DbType.DateTime);
                objDB.AddParameters(14, "InstituteID", fd.InstituteID, DbType.Int32);
                objDB.AddParameters(15, "Session", fd.Session, DbType.String);
                objDB.AddParameters(16, "Pid", fd.Pid, DbType.String);
                objDB.AddParameters(17, "RcnoID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
                objDB.AddParameters(18, "IType", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);

                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Advance_Insert");
            }

            int rcnoidd = Convert.ToInt32(objDB.Parameters[17].Value.ToString());
            string itype = objDB.Parameters[18].Value.ToString();

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

            objDB.CreateParameters(2);
            objDB.AddParameters(0, "RCNOID", rcnoidd, DbType.Int32);
            objDB.AddParameters(1, "IType", itype, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ID_Table_Update");

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
    public string InsertPpsno(FeesDM.PPSNO objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "ppsnoid", objFDM.ppsnoid, DbType.Int32);
            objDB.AddParameters(1, "instid", objFDM.instid, DbType.Int32);
            objDB.AddParameters(2, "sessnid", objFDM.sessnid, DbType.String);
            objDB.AddParameters(3, "startfrm", objFDM.startfrm, DbType.Int32);
            objDB.AddParameters(4, "upto", objFDM.upto, DbType.Int32);
            objDB.AddParameters(5, "used", objFDM.used, DbType.Int32);
            objDB.AddParameters(6, "flag", objFDM.Flag, DbType.String);
            objDB.AddParameters(7, "status", objFDM.Status, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "PPSNO_Insert");
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
            if (objFDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == "U")
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

    public class CheckParameter : List<FeesDM.CheckIsAuto>
    {
    }
    [OperationContract]
    public CheckParameter ParameterCheck(int InstituteID, string SessionID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "SessionID", SessionID, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "CheckParameter");
        CheckParameter listOfStudent = new CheckParameter();
        while (dr.Read())
        {
            var item = new FeesDM.CheckIsAuto();
            item.IsPPSNOAuto = Education.DataHelper.GetInt(dr, "Auto_PPSNO");
            item.IsRCNOAuto = Education.DataHelper.GetInt(dr, "Auto_RECNO");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();
 
        return listOfStudent;
    }

    public class Get_PPSNO : FeesDM.GetPPSNO
    {
    }
    [OperationContract]
    public Get_PPSNO PPSNO_Get(int InstituteID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetPPSNO");
        Get_PPSNO listOfStudent = new Get_PPSNO();
        if (dr.Read())
        {
            listOfStudent.PPSNO = Education.DataHelper.GetInt(dr, "PPSNO");
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();

        return listOfStudent;
    }


    public class Get_RCNO : FeesDM.GetRCNO
    {
    }
    [OperationContract]
    public Get_RCNO RCNO_Get(int InstituteID, string UseFor)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "UseFor", UseFor, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetRCNO");
        Get_RCNO listOfStudent = new Get_RCNO();
        if (dr.Read())
        {

            listOfStudent.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();

        return listOfStudent;
    }
    public class FillFeeAll : List<FeesDM.GetFeeAll>
    {
    }
    public FillFeeAll FeeAll_Get(int CourseID, string SemesterID, string CCategory, string Category)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "  SELECT DISTINCT FeeHead.FeeHeadId, FeeHead.FeeHeadName, master_courseFeeStruc.TotalAmount, Course.CourseId, master_courseFeeStruc.CID, master_courseFeeStruc.InstituteID, master_courseFeeStruc.SessionID, master_courseFeeDetail.BreakoffTime, master_courseFeeDetail.Amount, master_courseFeeDetail.LastDate, Course.ShortName+' ( '+ Semester_View.CourseYear+' ) '  as ShortName FROM  FeeHead INNER JOIN master_courseFeeStruc ON FeeHead.FeeHeadId = master_courseFeeStruc.FeeHeadCode INNER JOIN Course ON master_courseFeeStruc.CourseCode = Course.CourseId INNER JOIN  master_courseFeeDetail ON master_courseFeeStruc.courseFeeId = master_courseFeeDetail.courseFeeId INNER JOIN  Semester_View ON master_courseFeeStruc.CID = Semester_View.CID   where  Course.CourseId=" + CourseID + " and master_courseFeeStruc.CID in(" + SemesterID + ") order by master_courseFeeStruc.CID");
        FillFeeAll listOfStudent = new FillFeeAll();
        while (dr.Read())
        {
            var item = new FeesDM.GetFeeAll();
            item.FeeHeadId = Education.DataHelper.GetInt(dr, "FeeHeadId");
            item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
            item.Course = Education.DataHelper.GetInt(dr, "CourseId");
            item.SID = Education.DataHelper.GetString(dr, "CID");
            item.session = Education.DataHelper.GetString(dr, "SessionID");
            item.BreakoffTime = Education.DataHelper.GetString(dr, "BreakoffTime");
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
            item.Shortname = Education.DataHelper.GetString(dr, "ShortName");
            item.LastDate = Education.DataHelper.GetDateTime(dr, "LastDate");
            listOfStudent.Add(item);

        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();

        return listOfStudent;
    }
    public DataTable FeeAll_GetDt(int CourseID, string SemesterID, string CCategory, string Category)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.Text, "SELECT DISTINCT FeeHead.FeeHeadId, FeeHead.FeeHeadName, master_courseFeeDetail.Amount as TotalAmount, Course.CourseId as course, Semester_View.sid, master_courseFeeStruc.InstituteID, master_courseFeeStruc.SessionID as session, master_courseFeeDetail.BreakoffTime, master_courseFeeDetail.Amount, master_courseFeeDetail.LastDate, Course.ShortName+' ( '+ Semester_View.CourseYear+' ) '  as ShortName,master_courseFeeDetail.FeeDetailID,master_courseFeeStruc.courseFeeId FROM  FeeHead INNER JOIN master_courseFeeStruc ON FeeHead.FeeHeadId = master_courseFeeStruc.FeeHeadCode INNER JOIN Course ON master_courseFeeStruc.CourseCode = Course.CourseId INNER JOIN  master_courseFeeDetail ON master_courseFeeStruc.courseFeeId = master_courseFeeDetail.courseFeeId INNER JOIN  Semester_View ON master_courseFeeStruc.CID = Semester_View.SID   where  Course.CourseId=" + CourseID + " and master_courseFeeStruc.CID in(" + SemesterID + ") and master_courseFeeStruc.CID!='I' AND (dbo.master_courseFeeStruc.Ccategory = '" + CCategory + "') and ((dbo.master_courseFeeStruc.Category = '" + Category + "' OR master_courseFeeStruc.Category = 'All')) order by Semester_View.sid");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }
    public DataTable FeeAll_GetDtBySemester(int CourseID, string SemesterID, string CCategory, string Category)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.Text, "SELECT DISTINCT FeeHead.FeeHeadId, FeeHead.FeeHeadName,Student_Registration_Detail.TotalFeeAmount as TotalAmount, Student_Registration_Detail.CourseID  as Course, Student_Registration_Detail.SID,Student_Registration_Detail.Inst_ID as InstituteID , Student_Registration_Detail.Session, Student_Registration_Detail.BreakoffTime, Student_Registration_Detail.Amount, Student_Registration_Detail.DueDate as LastDate,Course.ShortName+' ( '+ Semester_View.CourseYear+' ) '  as ShortName FROM  Student_Registration_Detail INNER JOIN   FeeHead ON Student_Registration_Detail.FeeHeadCode = FeeHead.FeeHeadId INNER JOIN  Semester_View ON Student_Registration_Detail.CourseID = Semester_View.CID AND Student_Registration_Detail.SID = Semester_View.SID  INNER JOIN Course ON Semester_View.CourseID = dbo.Course.CourseId   where  Course.CourseId=" + CourseID + " and Semester_View.CourseID in(" + SemesterID + ") order by Semester_View.CourseID");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }

    public DataTable FeeRCancelStudent(string Prno, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Prno", Prno, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }

    public DataTable FeeChqDraftChk(string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }


    public class FillYearSem : List<FeesDM.YearSem>
    {
    }
    [OperationContract]
    public FillYearSem FillYrSem(string ctype, int courseid, string batchid, string sessnid, int instid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "ctype", ctype, DbType.String);
        objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
        objDB.AddParameters(2, "batch", batchid, DbType.String);
        objDB.AddParameters(3, "sessn", sessnid, DbType.String);
        objDB.AddParameters(4, "instid", instid, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem");
        FillYearSem listOfYS = new FillYearSem();
        while (dr.Read())
        {
            var item = new FeesDM.YearSem();
            item.Yr = Education.DataHelper.GetString(dr, "Yr");
            item.SID = Education.DataHelper.GetInt(dr, "SID");
            listOfYS.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return listOfYS;
    }

    public class FillPostDatedG : List<FeesDM.PostDatedGrd>
    {
    }
    [OperationContract]
    public FillPostDatedG FillPostDatedGrd(int instid, string sessn, int course, int sid, int studentid, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(6);
        objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "CourseCode", course, DbType.Int32);
        objDB.AddParameters(3, "sid", sid, DbType.Int32);
        objDB.AddParameters(4, "StudentID", studentid, DbType.Int32);
        objDB.AddParameters(5, "flag", flag, DbType.Int32);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Receipt_Cancellation_Select");
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillPostDatedG listOfStudent = new FillPostDatedG();
        while (dr.Read())
        {
            var item = new FeesDM.PostDatedGrd();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.SName = Education.DataHelper.GetString(dr, "SName");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return listOfStudent;

    }


    [OperationContract]
    public DataTable FillODC(int StudentID, int SemesterID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Get_OD_Detail");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;

    }

    [OperationContract]
    public DataTable FillODCForReport(int StudentID, int SemesterID, DateTime FDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(2, "FDate", FDate, DbType.DateTime);
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Get_OD_DetailForReport");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;

    }
    [OperationContract]
    public DataTable FillReceiptForReport(int SemesterID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SemesterID", SemesterID, DbType.Int32);
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Get_Receipt_DetailForReport");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;

    }
    [OperationContract]
    public DataTable FillReceiptStudentWise(int StudentID, int SemesterID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "SemesterID", SemesterID, DbType.Int32);
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Get_Receipt_StudentForReport");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;

    }
    [OperationContract]
    public FeesDM.GetChequeDetailDM FillChequeDetail(string ChequeNo)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "ChequeNo", ChequeNo, DbType.String);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "Get_ChequeDetail");
        var item = new FeesDM.GetChequeDetailDM();
        if (dr.Read())
        {
            item.ChequeNo = Education.DataHelper.GetString(dr, "DDNO");
            item.ChequeDate = Convert.ToDateTime(Education.DataHelper.GetDateTime(dr, "DateP").ToString("dd-MMM-yyyy"));
            item.ChequeAmount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.ChequeDetail = Education.DataHelper.GetString(dr, "StudentName") + "^" + Education.DataHelper.GetString(dr, "ID_Student") + "^" + Education.DataHelper.GetString(dr, "CourseName") + "^" + Education.DataHelper.GetString(dr, "Session");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.SemesterID = Education.DataHelper.GetInt(dr, "sid");
            if (Education.DataHelper.GetString(dr, "PayM").ToString().Contains("Cheque"))
            {
                item.DocType = "Cheque";
            }
            else
            {
                item.DocType = "Draft";
            }
        }
        objDB.Connection.Close();
        objDB.Dispose();
        if (item == null)
        {
            item.ChequeNo = "-1";
        }
        return item;

    }

    [OperationContract]
    public DataTable FillDueStudentWise(int SemesterID, DateTime dtFrom, DateTime dtTo)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "SemesterID", SemesterID, DbType.Int32);
        objDB.AddParameters(1, "FDueDate", dtFrom, DbType.DateTime);
        objDB.AddParameters(2, "TDueDate", dtTo, DbType.DateTime);
        DataTable dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Get_Fee_DueForReport");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;

    }

    [OperationContract]
    public string FeeDefaulterMaster_Insert(FeesDM.ChequeDefaulterMasterDM objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "DEMID", objFDM.DEMID, DbType.Int32);
            objDB.AddParameters(1, "Trans_Date", objFDM.Trans_Date, DbType.DateTime);
            objDB.AddParameters(2, "CHDDNo", objFDM.CHDDNo, DbType.Int32);
            objDB.AddParameters(3, "SubmittedBy", objFDM.SubmittedBy, DbType.Int32);
            objDB.AddParameters(4, "Status", objFDM.Status, DbType.Int32);
            objDB.AddParameters(5, "Remark", objFDM.Remark, DbType.String);
            objDB.AddParameters(6, "DocType", objFDM.DocType, DbType.Int32);
            objDB.AddParameters(7, "UsedIn", objFDM.UsedIn, DbType.String);
            objDB.AddParameters(8, "SemesterID", objFDM.SemesterID, DbType.Int32);
            objDB.AddParameters(9, "Flag", objFDM.Flag, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_DefaulterMaster_Insert");
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
            if (objFDM.Flag == 1)
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == 2)
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
    public string RefundApproval(FeesDM.RefundApproval objRA, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(2);
            objDB.AddParameters(0, "RefundID", objRA.RefundID, DbType.Int32);
            objDB.AddParameters(1, "Status", objRA.Status, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Refund_Approval");
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
            //if (objFDM.Flag == 1)
            //{
                retv = "Record Saved.";
           
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
    public List<FeesDM.FillChequeDefaulterDetail> FillChequeDefaulterDetail(int ChequeNo)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "InstituteID", ChequeNo, DbType.Int16);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "GetDefaulterList");
        List<FeesDM.FillChequeDefaulterDetail> retItem = new List<FeesDM.FillChequeDefaulterDetail>();
        while (dr.Read())
        {
            var item = new FeesDM.FillChequeDefaulterDetail();
            item.CHDDNo = Education.DataHelper.GetInt(dr, "CHDDNo");
            item.DateP = Education.DataHelper.GetNullableDateTime(dr, "DateP");
            item.DEMID = Education.DataHelper.GetInt(dr, "DEMID");
            item.Remark = Education.DataHelper.GetString(dr, "Remark");
            item.ChequeD_Date = Education.DataHelper.GetDateTime(dr, "ChequeD_Date");
            item.Status = Education.DataHelper.GetInt(dr, "Status");
            item.DocType = Education.DataHelper.GetString(dr, "PayM");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;

    }

    [OperationContract]
    public string FeeDefaulterChild_Insert(FeesDM.ChequeDefaulterChildDM objFDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "DEChildID", objFDM.DEMID, DbType.Int32);
            objDB.AddParameters(1, "DEMID", objFDM.DEMID, DbType.Int32);
            objDB.AddParameters(2, "New_ChequeDD", objFDM.New_ChequeDD, DbType.Int32);
            objDB.AddParameters(3, "ChequeD_Date", objFDM.ChequeD_Date, DbType.DateTime);
            objDB.AddParameters(4, "IssuedBy", objFDM.IssuedBy, DbType.Int32);
            objDB.AddParameters(5, "Amount", objFDM.Amount, DbType.Decimal);
            objDB.AddParameters(6, "Process_Charge", objFDM.Process_Charge, DbType.Decimal);
            objDB.AddParameters(7, "Status", objFDM.Status, DbType.Int32);
            objDB.AddParameters(8, "New_DocType", objFDM.New_DocType, DbType.Int32);
            objDB.AddParameters(9, "Flag", objFDM.Flag, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Defaulter_Child_Insert");
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
            if (objFDM.Flag == 1)
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == 2)
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
    public string FeeCancelReceipt_Insert(FeesDM.Fee_Cancel_MDM objFDM, List<FeesDM.Fee_Cancel_CDM> objFCDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "CRID", objFDM.CRID, DbType.Int32);
            objDB.AddParameters(1, "PRNO", objFDM.PRNO, DbType.String);
            objDB.AddParameters(2, "StudentID", objFDM.StudentID, DbType.Int32);
            objDB.AddParameters(3, "Cancel_Date", objFDM.Cancel_Date, DbType.DateTime);
            objDB.AddParameters(4, "Cancel_Amount", objFDM.Cancel_Amount, DbType.Decimal);
            objDB.AddParameters(5, "Cancel_Charge", objFDM.Cancel_Charge, DbType.Decimal);
            objDB.AddParameters(6, "UE_Date", objFDM.UE_Date, DbType.DateTime);
            objDB.AddParameters(7, "U_Name", objFDM.U_Name, DbType.String);
            objDB.AddParameters(8, "retCRID", "XXXXXXX", DbType.String, ParameterDirection.Output);
            Int32 sid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_CancelReceipt_M_Insert");
            sid = Int32.Parse(objDB.Parameters[8].Value.ToString());

            foreach (FeesDM.Fee_Cancel_CDM objI in objFCDM)
            {
                objDB.CreateParameters(5);
                objDB.AddParameters(0, "CRCID", objI.CRID, DbType.Int32);
                objDB.AddParameters(1, "CRID", sid, DbType.Int32);
                objDB.AddParameters(2, "StudentID", objI.StudentID, DbType.Int32);
                objDB.AddParameters(3, "FeeSubID", objI.FeeSubID, DbType.Int32);
                objDB.AddParameters(4, "RCNO", objI.RCNO, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Fee_Cancel_ChildInsert");
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
            if (objFDM.Flag == 1)
            {
                retv = "Record saved.";
            }
            else if (objFDM.Flag == 2)
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
    public FeesDM.FillFeeReceiptDM FillReceiptDetailByReceiptNo(string ReceiptNo)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "RCNO", ReceiptNo, DbType.String);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FillReceiptByRCNO");
        var item = new FeesDM.FillFeeReceiptDM();
        if (dr.Read())
        {
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.Trans_Date = Convert.ToDateTime(Education.DataHelper.GetDateTime(dr, "Trans_Date").ToString("dd-MMM-yyyy"));
            item.Amount = Education.DataHelper.GetDecimal(dr, "Amount");
            item.ReceiptDetail = Education.DataHelper.GetString(dr, "ReceiptDetail");
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.PaymentDetail = Education.DataHelper.GetString(dr, "PaymentDetail");
            item.PaidBy = Education.DataHelper.GetString(dr, "PaidBy");
            item.PaymentDetail = Education.DataHelper.GetString(dr, "PaymentDetail");
            item.PPSNO = Education.DataHelper.GetInt(dr, "PPSNO");
            item.PID = Education.DataHelper.GetString(dr, "PID");
            item.FID = Education.DataHelper.GetString(dr, "FID");
            item.SemesterID = Education.DataHelper.GetInt(dr, "SemesterID");
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return item;

    }

    [OperationContract]
    public List<FeesDM.FillCancelReceiptDM> FillCancelReceiptAll()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FillCancelReceiptAll");
        List<FeesDM.FillCancelReceiptDM> retDM = new List<FeesDM.FillCancelReceiptDM>();
        while (dr.Read())
        {
            var item = new FeesDM.FillCancelReceiptDM();
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.Cancel_Date = Convert.ToDateTime(Education.DataHelper.GetDateTime(dr, "Cancel_Date").ToString("dd-MMM-yyyy"));
            item.Amount = Education.DataHelper.GetDecimal(dr, "Cancel_Amount");
            item.Charges = Education.DataHelper.GetDecimal(dr, "Cancel_Charge");
            item.PPSNO = Education.DataHelper.GetInt(dr, "PPSNO");
            item.SubmittedBy = Education.DataHelper.GetString(dr, "Studentname");
            item.PRNO = Education.DataHelper.GetString(dr, "PRNO");
            retDM.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retDM;

    }

    [OperationContract]
    public DataTable FillAdvRGrd(int studentid, int coursid, string flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "StudentID", studentid, DbType.Int32);
        objDB.AddParameters(1, "CourseID", coursid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }

        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }

        return dt;
    }

    [OperationContract]
    public DataTable FillAdvRcpt(string prno, string flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "Prno", prno, DbType.String);
        objDB.AddParameters(1, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillDetailPGrd(int DocId, int instid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        //objDB.AddParameters(1, "Session", Sessn, DbType.String);
        objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }

        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }

        return dt;
    }

    public DataTable FillDetailODCPrintF(int DocId, string Sessn, int sid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "Session", Sessn, DbType.String);
        objDB.AddParameters(2, "Sid", sid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillDetailODCPrintC(int DocId, string Sessn, int sid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "DocId", DocId, DbType.Int32);
        objDB.AddParameters(1, "Session", Sessn, DbType.String);
        objDB.AddParameters(2, "Sid", sid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    //public DataTable FillDetailODCRcpt()
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    DataTable dt = new DataTable();
    //    //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
    //    try
    //    {


    //        dt = objDB.ExecuteTable(CommandType.Text, "(select * from ODC_PF)UNION(select * from ODC_PO)");

    //    }
    //    finally
    //    {
    //        objDB.Connection.Close();
    //        objDB.Dispose();
    //    }
    //    return dt;
    //}


    public DataTable FillDetailODCRcpt(string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "flag", flag, DbType.String);
        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillRefundApproval(int Refund,string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "RefundID", Refund, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.String);

        DataTable dt = new DataTable();
        //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }


    public DataTable FillFeeRefundGrdN(int inst, int cours, string sessn, int studentid, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "Instituteid", inst, DbType.Int32);
        objDB.AddParameters(1, "CourseID", cours, DbType.Int32);
        objDB.AddParameters(2, "Session", sessn, DbType.String);
        objDB.AddParameters(3, "DocId", studentid, DbType.Int32);
        objDB.AddParameters(4, "flag", flag, DbType.String);
        //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Fee_Deposit_Select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            //objDB = null;
        }
        return dt;
    }

    public class FillFeeNature : List<FeesDM.FeeNatureDM>
    {
    }
    [OperationContract]
    public FillFeeNature FillFeeNatureRpt(int instid, string sessn,int sid, string flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(1, "Session", sessn, DbType.String);
        objDB.AddParameters(2, "Sid", sid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.String);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
        //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
        FillFeeNature listFeeNature = new FillFeeNature();
        while (dr.Read())
        {
            var item = new FeesDM.FeeNatureDM();
            item.FeeHeadID = Education.DataHelper.GetInt(dr, "FeeHeadID");
            item.Nature = Education.DataHelper.GetString(dr, "Nature");
            listFeeNature.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB.Dispose();
        return listFeeNature;

    }


    public DataTable FillFeeStructureReport(string qry)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();

        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.Text, qry);
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }
    public void FillStudentID(DropDownList ddl, int instid, string sessn, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(1, "SessionID", sessn, DbType.String);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "RegNo";
            ddl.DataValueField = "StudentID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }


    //public void FillStudentID(DropDownList ddl, int sid, int instid, string sessn, int courseid, int specid, int flag, string ZeroIndexVal)
    //{
    //    ddl.Items.Clear();
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.CreateParameters(6);
    //    objDB.AddParameters(0, "Sid", sid, DbType.Int32);
    //    objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
    //    objDB.AddParameters(2, "SessionID", sessn, DbType.String);
    //    objDB.AddParameters(3, "CourseID", courseid, DbType.Int32);
    //    objDB.AddParameters(4, "SpecializationID", specid, DbType.Int32);
    //    objDB.AddParameters(5, "flag", flag, DbType.Int32);

    //    SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
    //    if (dr.HasRows)
    //    {
    //        ddl.DataSource = dr;
    //        ddl.DataTextField = "RegNo";
    //        ddl.DataValueField = "StudentID";
    //        ddl.DataBind();
    //        if (ZeroIndexVal != "")
    //        {
    //            ddl.Items.Insert(0, ZeroIndexVal);
    //            ddl.Items[0].Value = "0";
    //        }
    //        else
    //        {
    //            ddl.Items.Insert(0, ZeroIndexVal);
    //            ddl.Items[0].Value = "0";
    //        }
    //    }
    //    else
    //    {
    //        ddl.Items.Insert(0, ZeroIndexVal);
    //        ddl.Items[0].Value = "0";
    //    }
    //}

    public void FillFeeVoucher(DropDownList ddl, int instid, int studentid, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "VNo";
            ddl.DataValueField = "VoucherNo";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }

   
    public DataTable FillFeeDetailTable(int studentId, int InstID, string voucherno, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        try
        {
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "StudentID", studentId, DbType.Int32);
            objDB.AddParameters(1, "InstituteID", InstID, DbType.Int32);
            //objDB.AddParameters(2, "CourseID", courseid, DbType.Int32);
            //objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
            objDB.AddParameters(2, "VoucherNo", voucherno, DbType.String);
            objDB.AddParameters(3, "flag", flag, DbType.Int32);
            //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
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
    public List<FeesDM.FeeNatureDM> FillFeeHead(int instid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        List<FeesDM.FeeNatureDM> retItem = new List<FeesDM.FeeNatureDM>();
        while (dr.Read())
        {
            var item = new FeesDM.FeeNatureDM();
            item.FeeHeadID = Education.DataHelper.GetInt(dr, "FeeHeadID");
            item.Nature = Education.DataHelper.GetString(dr, "Nature");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }

    public void FillAccount(DropDownList ddl, int flag, int instituteid, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        //objDB.AddParameters(0, "bankreq", bankreq, DbType.String);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        objDB.AddParameters(1, "InstituteID", instituteid, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "AccountNo";
            ddl.DataValueField = "AccountNoID";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }

    [OperationContract]
    public DataTable FillOutStandingGrd(int StudentID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }
    public void FillFeeVoucherRefund(DropDownList ddl, int studentid, int instid, string RefType, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(2, "RefType", RefType, DbType.String);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");

        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "PrNo";
            ddl.DataValueField = "RCNO";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }
    [OperationContract]
    public List<FeesDM.RefundFeeDetail> FillRefundFeeDetail(int flag, int studentid, int RCNO, string reftype)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        objDB.AddParameters(1, "StudentID", studentid, DbType.Int32);
        objDB.AddParameters(2, "RCNO", RCNO, DbType.Int32);
        objDB.AddParameters(3, "RefType", reftype, DbType.String);
        //IDataReader dr = objDB.ExecuteReader(CommandType.Text, "SELECT FeedbackM.FeedbackTypeID, FeedbackM.FeedbackID, FeedbackM.FeedbackParamID,FeedbackParameterM.FeedbackParameter FROM FeedbackM INNER JOIN FeedbackParameterM ON dbo.FeedbackM.FeedbackParamID = dbo.FeedbackParameterM.FeedbackParamID where FeedbackM.InstituteID=@instituteid and FeedbackM.FeedbackTypeID=@FeedbackTypeID and SessionID=@sessionid and CourseID=@courseid and SpecializationID=@Specialization");
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        List<FeesDM.RefundFeeDetail> retItem = new List<FeesDM.RefundFeeDetail>();
        while (dr.Read())
        {
            var item = new FeesDM.RefundFeeDetail();
            item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
            item.RCNO = Education.DataHelper.GetInt(dr, "RCNO");
            item.FeeID = Education.DataHelper.GetInt(dr, "FeeID");
            item.FeeHead = Education.DataHelper.GetString(dr, "FeeHead");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }

    [OperationContract]
    public DataTable FillRefundAmt(int StudentID, int rcno, int feeid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "RCNO", rcno, DbType.Int32);
        objDB.AddParameters(2, "FeeID", feeid, DbType.Int32);
        objDB.AddParameters(3, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }

    public void FillFeeChequeNo(DropDownList ddl, int instid, int studentid, int flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
        objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
        objDB.AddParameters(2, "flag", flag, DbType.Int32);

        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        if (dr.HasRows)
        {
            ddl.DataSource = dr;
            ddl.DataTextField = "DDNO";
            ddl.DataValueField = "DDNO";
            ddl.DataBind();
            if (ZeroIndexVal != "")
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
            else
            {
                ddl.Items.Insert(0, ZeroIndexVal);
                ddl.Items[0].Value = "0";
            }
        }
        else
        {
            ddl.Items.Insert(0, ZeroIndexVal);
            ddl.Items[0].Value = "0";
        }
    }

    [OperationContract]
    public List<FeesDM.OutSourceFeeOrgMGrdDM> FillOutSourceFeeOrgMGrd(int instituteid, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "InstituteID", instituteid, DbType.Int32);
        objDB.AddParameters(1, "Flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        List<FeesDM.OutSourceFeeOrgMGrdDM> retItem = new List<FeesDM.OutSourceFeeOrgMGrdDM>();
        while (dr.Read())
        {
            var item = new FeesDM.OutSourceFeeOrgMGrdDM();
            item.OutSourceOrgID = Education.DataHelper.GetInt(dr, "OutSourceOrgID");
            item.OutSourceOrg = Education.DataHelper.GetString(dr, "OutSourceOrg");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }




    [OperationContract]
    public string OutSourceFeeOrgMInsert(FeesDM.OutSourceFeeOrgMDM objD)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(5);
            objDB.AddParameters(0, "OutSourceOrgID", objD.OutSourceOrgID, DbType.Int32);
            objDB.AddParameters(1, "OutSourceOrg", objD.OutSourceOrg, DbType.String);
            objDB.AddParameters(2, "EntryDate", objD.EntryDate, DbType.DateTime);
            objDB.AddParameters(3, "UName", objD.UName, DbType.String);
            objDB.AddParameters(4, "InstituteID", objD.InstituteID, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "OutSourceOrgMInsert");

            retv = "Record Saved.";

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
    public DataTable FillTransSummaryCourse(int flag, int accountid, DateTime frmdate, DateTime todate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        objDB.AddParameters(1, "accountnoid", accountid, DbType.Int32);
        objDB.AddParameters(2, "FromDate", frmdate, DbType.DateTime);
        objDB.AddParameters(3, "ToDate", todate, DbType.DateTime);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }
    [OperationContract]
    public DataTable FillTransSummaryStudent(int flag, int accountid, DateTime frmdate, DateTime todate, int FeeID, int CourseID, string SessionID, int SpecializationID, int Sid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "flag", flag, DbType.Int32);
        objDB.AddParameters(1, "accountnoid", accountid, DbType.Int32);
        objDB.AddParameters(2, "FromDate", frmdate, DbType.DateTime);
        objDB.AddParameters(3, "ToDate", todate, DbType.DateTime);
        objDB.AddParameters(4, "FeeID", FeeID, DbType.Int32);
        objDB.AddParameters(5, "CourseID", CourseID, DbType.Int32);
        objDB.AddParameters(6, "SessionID", SessionID, DbType.String);
        objDB.AddParameters(7, "SpecializationID", SpecializationID, DbType.Int32);
        objDB.AddParameters(8, "Sid", Sid, DbType.Int32);
        DataTable dt = new DataTable();
        try
        {
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return dt;
    }
    [OperationContract]
    public string HostelBusCancellationInsert(List<FeesDM.HostelBusCancelDetailDM> objDet, List<FeesDM.HostelBusCancelPaymentDM> objPay)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            foreach (FeesDM.HostelBusCancelDetailDM objD in objDet)
            {
                objDB.CreateParameters(9);
                objDB.AddParameters(0, "StudentID", objD.StudentID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", objD.InstituteID, DbType.Int32);
                objDB.AddParameters(2, "FeeID", objD.FeeID, DbType.Int32);
                objDB.AddParameters(3, "VoucherNo", objD.VoucherNo, DbType.String);
                objDB.AddParameters(4, "TotalAmount", objD.TotalAmount, DbType.Decimal);
                objDB.AddParameters(5, "PaidAmount", objD.PaidAmount, DbType.Decimal);
                objDB.AddParameters(6, "BalanceAmount", objD.BalanceAmount, DbType.Decimal);
                objDB.AddParameters(7, "Narration", objD.Narration, DbType.String);
                objDB.AddParameters(8, "Flag", objD.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "HostelBusCancelDetail");
            }
            foreach (FeesDM.HostelBusCancelPaymentDM objP in objPay)
            {
                objDB.CreateParameters(8);
                objDB.AddParameters(0, "StudentID", objP.StudentID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", objP.InstituteID, DbType.Int32);
                objDB.AddParameters(2, "FeeID", objP.FeeID, DbType.Int32);
                objDB.AddParameters(3, "VoucherNo", objP.VoucherNo, DbType.String);
                objDB.AddParameters(4, "TotalAmount", objP.TotalAmount, DbType.Decimal);
                //objDB.AddParameters(5, "PaidAmount", objP.PaidAmount, DbType.Decimal);
                //objDB.AddParameters(6, "BalanceAmount", objP.BalanceAmount, DbType.Decimal);
                objDB.AddParameters(5, "Narration", objP.Narration, DbType.String);
                objDB.AddParameters(6, "Prno", objP.Prno, DbType.String);
                objDB.AddParameters(7, "Flag", objP.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "HostelBusCancelPayment");
            }

            retv = "Record Saved.";

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
    public List<FeesDM.VoucherDeletionDueGrd> FillVoucherDeletionDue(int InstituteID, int StudentID, string VoucherNo, string VType, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(2, "VoucherNo", VoucherNo, DbType.String);
        objDB.AddParameters(3, "VType", VType, DbType.String);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        List<FeesDM.VoucherDeletionDueGrd> retItem = new List<FeesDM.VoucherDeletionDueGrd>();
        while (dr.Read())
        {
            var item = new FeesDM.VoucherDeletionDueGrd();
            item.VoucherNo = Education.DataHelper.GetString(dr, "VoucherNo");
            item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
            item.PaidAmount = Education.DataHelper.GetDecimal(dr, "PaidAmount");
            item.BalanceAmount = Education.DataHelper.GetDecimal(dr, "BalanceAmount");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }





    [OperationContract]
    public List<FeesDM.VoucherDeletionRecGrd> FillVoucherDeletionRec(int InstituteID, int StudentID, string VoucherNo, string VType, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(2, "VoucherNo", VoucherNo, DbType.String);
        objDB.AddParameters(3, "VType", VType, DbType.String);
        objDB.AddParameters(4, "flag", flag, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        List<FeesDM.VoucherDeletionRecGrd> retItem = new List<FeesDM.VoucherDeletionRecGrd>();
        while (dr.Read())
        {
            var item = new FeesDM.VoucherDeletionRecGrd();
            item.PrNo = Education.DataHelper.GetString(dr, "PrNo");
            item.RefPrNo = Education.DataHelper.GetString(dr, "RefPrNo");
            item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
            item.TAmt = Education.DataHelper.GetDecimal(dr, "TAmt");
            item.BalanceAmount = Education.DataHelper.GetDecimal(dr, "BalanceAmount");
            retItem.Add(item);
        }
        objDB.Connection.Close();
        objDB.Dispose();
        return retItem;
    }





    [OperationContract]
    public string DeleteDueVoucher(FeesDM.VoucherDueDeleteDM objVD)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            //foreach (FeesDM.VoucherDeleteDM fb in objVD)
            //{
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "StudentID", objVD.StudentID, DbType.Int32);
            objDB.AddParameters(1, "VoucherNo", objVD.VoucherNo, DbType.String);
            objDB.AddParameters(2, "Flag", objVD.Flag, DbType.String);
            objDB.AddParameters(3, "FlagT", objVD.FlagT, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherDeletionDel");
            //}

            retv = "Record Deleted.";

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
    public string DeleteRecVoucher(FeesDM.VoucherRecDeleteDM objVD)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            //foreach (FeesDM.VoucherDeleteDM fb in objVD)
            //{
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "StudentID", objVD.StudentID, DbType.Int32);
            objDB.AddParameters(1, "PrNo", objVD.PrNo, DbType.String);
            objDB.AddParameters(2, "PaidAmt", objVD.PaidAmt, DbType.Decimal);
            objDB.AddParameters(2, "FeeID", objVD.PaidAmt, DbType.Decimal);
            objDB.AddParameters(3, "FlagT", objVD.FlagT, DbType.String);
            //objDB.AddParameters(4, "Flag", objVD.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherDeletionDel");
            //}

            retv = "Record Deleted.";

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
    
    public void FillVoucherDeletion(DropDownList ddl, int StudentID, int InstituteID, string vtype, string rcno, int Flag, string ZeroIndexVal)
    {
        ddl.Items.Clear();
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.Command.Parameters.Clear();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
        objDB.AddParameters(2, "VType", vtype, DbType.String);
        objDB.AddParameters(3, "VoucherNo", rcno, DbType.String);
        objDB.AddParameters(4, "Flag", Flag, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
        try
        {
            if (dr != null)
            {
                ddl.DataSource = dr;
                ddl.DataTextField = "VoucherNo";
                ddl.DataValueField = "VoucherNo";
                ddl.DataBind();
                if (ZeroIndexVal != "")
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
                else
                {
                    ddl.Items.Insert(0, ZeroIndexVal);
                    ddl.Items[0].Value = "0";
                }
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.DataReader.Close();
            objDB.DataReader.Dispose();
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
    }




    [OperationContract]
    public string DeleteVoucher(FeesDM.VoucherDeleteDM objVD)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            //foreach (FeesDM.VoucherDeleteDM fb in objVD)
            //{
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "StudentID", objVD.StudentID, DbType.Int32);
            objDB.AddParameters(1, "VoucherNo", objVD.VoucherNo, DbType.String);
            objDB.AddParameters(2, "TotalAmount", objVD.TotalAmount, DbType.Decimal);
            objDB.AddParameters(3, "PaidAmount", objVD.PaidAmount, DbType.Decimal);
            objDB.AddParameters(4, "BalanceAmount", objVD.BalanceAmount, DbType.Decimal);
            objDB.AddParameters(5, "FeeID", objVD.FeeID, DbType.Int32);
            objDB.AddParameters(6, "PrNo", objVD.PrNo, DbType.String);
            objDB.AddParameters(7, "RefPrNo", objVD.RefPrNo, DbType.String);
            objDB.AddParameters(8, "FeeType", objVD.FeeType, DbType.String);
            objDB.AddParameters(9, "TPTransID", objVD.TPTransID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherDeletionInsert");
            //}

            retv = "Record Saved.";

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

}
