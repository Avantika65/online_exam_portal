﻿using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using NewDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class GatePassSVC
{
    // Add [WebGet] attribute to use HTTP GET
    DBManager objDB;
    [OperationContract]
    public string InsertGateMaster(GatePassDM.GateMasterDM objGDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "gateID", objGDM.gateID, DbType.Int32);
            objDB.AddParameters(1, "gname", objGDM.gname, DbType.String);
            objDB.AddParameters(2, "gtype", objGDM.gtype, DbType.String);
            objDB.AddParameters(3, "flag", objGDM.flag, DbType.String);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GateMasterInsert");

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
            if (objGDM.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objGDM.flag == "U")
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
    public string InsertGateAuthority(GatePassDM.GateAuthorityDM objADM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "Aperson", objADM.Aperson, DbType.String);
            objDB.AddParameters(1, "Designation", objADM.Designation, DbType.String);
            objDB.AddParameters(2, "AReporting", objADM.AReporting, DbType.String);
            objDB.AddParameters(3, "isauthority", objADM.isAuthority, DbType.String);
            objDB.AddParameters(4, "aid", objADM.aid, DbType.Int32);
            objDB.AddParameters(5, "flag", objADM.flag, DbType.String);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GateAuthorityInsert");

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
            if (objADM.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objADM.flag == "U")
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
        // Add more operations here and mark them with [OperationContract]
    

     }

    
    [OperationContract]
    public string InsertGateDestination(GatePassDM.DestinationMastDM objDDM, Admin.AdministratorData.AuditDM audit)

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
            objDB.AddParameters(0, "DID", objDDM.DID, DbType.Int32);
            objDB.AddParameters(1, "Destination", objDDM.Destination, DbType.String);
            objDB.AddParameters(2, "ShortName", objDDM.ShortName, DbType.String);
            objDB.AddParameters(3, "flag", objDDM.flag, DbType.String);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GateDestinationInsert");

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
            if (objDDM.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objDDM.flag == "U")
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
    public string InsertGateShiftDM(GatePassDM.GateShiftDM objSDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "SeqPerson", objSDM.SeqPerson, DbType.Int32);
            objDB.AddParameters(1, "GateNo", objSDM.GateNo, DbType.Int32);
            objDB.AddParameters(2, "FromDate", objSDM.FromDate, DbType.DateTime);
            objDB.AddParameters(3, "ToDate", objSDM.ToDate, DbType.DateTime);     
            objDB.AddParameters(4, "FromTime", objSDM.FromTime, DbType.String);
            objDB.AddParameters(5, "ToTime", objSDM.ToTime, DbType.String);
            objDB.AddParameters(6, "ShiftType", objSDM.ShiftType, DbType.String); 
            objDB.AddParameters(7, "shiftID", objSDM.shiftID, DbType.Int32); 
            objDB.AddParameters(8, "flag", objSDM.flag, DbType.String);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GateShiftInsert");

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
            if (objSDM.flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objSDM.flag == "U")
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
    public string InsertGatePassE(GatePassDM.GatePassEntryDM objGDM, GatePassDM.GatePassEntryChildDM objGDMC, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(38);
            objDB.AddParameters(0, "GPSID", objGDM.GPSID, DbType.Int32);
            objDB.AddParameters(1, "GPSNO", objGDM.GPSNO, DbType.String);
            objDB.AddParameters(2, "GPSDate", objGDM.GPSDate, DbType.DateTime);
            objDB.AddParameters(3, "GPSTime", objGDM.GPSTime, DbType.String);
            objDB.AddParameters(4, "EnteredBY", objGDM.EnteredBY, DbType.String);
            objDB.AddParameters(5, "PassType", objGDM.PassType, DbType.Int32);
            objDB.AddParameters(6, "Purpose", objGDM.Purpose, DbType.String);
            objDB.AddParameters(7, "FirstName", objGDM.FirstName, DbType.String);
            objDB.AddParameters(8, "MiddleName", objGDM.MiddleName, DbType.String);
            objDB.AddParameters(9, "LastName", objGDM.LastName, DbType.String);
            objDB.AddParameters(10, "ContactNo", objGDM.ContactNo, DbType.String);
            objDB.AddParameters(11, "Address", objGDM.Address, DbType.String);
            objDB.AddParameters(12, "City", objGDM.City, DbType.String);
            objDB.AddParameters(13, "GateID", objGDM.GateID, DbType.Int32);
            objDB.AddParameters(14, "VehicalNo", objGDM.VehicalNo, DbType.String);
            objDB.AddParameters(15, "VehicalType", objGDM.VehicalType, DbType.String);
            objDB.AddParameters(16, "Visit_Department", objGDM.Visit_Department, DbType.Int32);            
            objDB.AddParameters(17, "Visit_Purpose", objGDM.Visit_Purpose, DbType.String);
            objDB.AddParameters(18, "PersonTo_Meet", objGDM.PersonTo_Meet, DbType.String);
            objDB.AddParameters(19, "PassEntryFrom", objGDM.PassEntryFrom, DbType.String);
            objDB.AddParameters(20, "Status", objGDM.Status, DbType.String);
            objDB.AddParameters(21, "OutTime", objGDM.OutTime, DbType.String);
            objDB.AddParameters(22, "IsValidity", objGDM.IsValidity, DbType.Int32);
            objDB.AddParameters(23, "AppointmentID", objGDM.AppointmentID, DbType.Int32);
            objDB.AddParameters(24, "visitor_Photo", objGDM.visitor_Photo, DbType.Binary);
            objDB.AddParameters(25, "Carry_Item", objGDM.Carry_Item, DbType.String);
            objDB.AddParameters(26, "Remark", objGDM.Remark, DbType.String);
            objDB.AddParameters(27, "Flag", objGDM.Flag, DbType.String);
            objDB.AddParameters(28, "GatePID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);           
            objDB.AddParameters(29, "NOS", objGDM.NOS, DbType.Int32);
            objDB.AddParameters(30, "NOM", objGDM.NOM, DbType.Int32);
            objDB.AddParameters(31, "NOF", objGDM.NOF, DbType.Int32);
            objDB.AddParameters(32, "UEname", objGDM.UEname, DbType.String);
            objDB.AddParameters(33, "UEDate", objGDM.UEDate, DbType.DateTime);
            objDB.AddParameters(34, "State", objGDM.State, DbType.Int32);
            objDB.AddParameters(35, "Country", objGDM.Country, DbType.Int32);
            objDB.AddParameters(36, "Gender", objGDM.Gender, DbType.Int32);
            //objDB.AddParameters(36, "Gender", objGDM.Gender, DbType.Int32);
            objDB.AddParameters(37, "PersonTomeet_ID", objGDM.PersonTomeet_ID, DbType.Int32);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatePassEntry_Insert");
            //Int32 sid = 0;
            //if (objGDM.Flag == "U")
            //{
            //    sid = objGDM.GPSID;
            //}
            //else
            //{
            //    sid = Int32.Parse(objDB.Parameters[29].Value.ToString());
            //}

            objDB.CreateParameters(6);
            objDB.AddParameters(0, "GPSID", objGDMC.GPSID , DbType.Int32);
            objDB.AddParameters(1, "ValidFrom", objGDMC.ValidFrom, DbType.DateTime);
            objDB.AddParameters(2, "ValidTo", objGDMC.ValidTo, DbType.DateTime);
            objDB.AddParameters(3, "Satus", objGDMC.Satus, DbType.Int32);
            objDB.AddParameters(4, "IsExpired", objGDMC.IsExpired, DbType.Int32);
            objDB.AddParameters(5, "Flag", objGDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatePassEntryChild_Insert");
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
            if (objGDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objGDM.Flag == "U")
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
    public string InsertAppointMastDM(GatePassDM.GateAppointMastDM objAPDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "appID", objAPDM.appID, DbType.Int32);
            objDB.AddParameters(1, "Date", objAPDM.Date, DbType.DateTime);
            objDB.AddParameters(2, "Days", objAPDM.Day, DbType.String);
            objDB.AddParameters(3, "FirstN", objAPDM.FirstN, DbType.String);
            objDB.AddParameters(4, "MidN", objAPDM.MidN, DbType.String);
            objDB.AddParameters(5, "LastN", objAPDM.LastN, DbType.String);
            objDB.AddParameters(6, "appType", objAPDM.appType, DbType.String);
            objDB.AddParameters(7, "ContactNo", objAPDM.ContactNo, DbType.String);
            objDB.AddParameters(8, "Email", objAPDM.Email, DbType.String);
            objDB.AddParameters(9, "Address", objAPDM.Address, DbType.String);
            objDB.AddParameters(10, "FromTime", objAPDM.FromTime, DbType.String);
            objDB.AddParameters(11, "ToTime", objAPDM.ToTime, DbType.String);
            objDB.AddParameters(12, "isInform", objAPDM.isInform, DbType.String);
            objDB.AddParameters(13, "status", objAPDM.status, DbType.String);
            objDB.AddParameters(14, "fwdTo", objAPDM.fwdTo, DbType.String);
            objDB.AddParameters(15, "flag", objAPDM.flag, DbType.String);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GateAppointMastInsert");
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

            //if (objSDM.flag == "N")
            //{
            //    retv = "Record saved.";
            //}
            //else if (objSDM.flag == "U")
            //{
            //    retv = "Record Updated Successfully.";
            //}
            //else
            //{
            //    retv = "Record deleted Successfully.";
            //}

            if (objAPDM.flag == "N")
            {
                retv = "Appointment Record Saved.";
            }
            else if (objAPDM.flag == "U")
            {
                retv = "Record Updated Successfully.";
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
        return retv; ;
    }
    [OperationContract]
    public string InsertGatechkOut(GatePassDM.GatechkOutDM objCDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(8);
            objDB.AddParameters(0, "chkoutID", objCDM.chkoutID, DbType.Int32);
            objDB.AddParameters(1, "passID", objCDM.passID, DbType.Int32);
            objDB.AddParameters(2, "GateID", objCDM.GateID, DbType.Int32);
            objDB.AddParameters(3, "chkInDate", objCDM.chkIndate, DbType.DateTime);
            objDB.AddParameters(4, "chkOutDate", objCDM.chkOutdate, DbType.DateTime);
            objDB.AddParameters(5, "InTime", objCDM.InTime, DbType.String);
            objDB.AddParameters(6, "OutTime", objCDM.OutTime, DbType.String);
            objDB.AddParameters(7, "flag", objCDM.flag, DbType.String);
           

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatechkOutInsert");

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
            if (objCDM.flag == 1)
            {
                retv = "Record saved.";
            }
            else if (objCDM.flag == 2)
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
    public string InsertGatePassE(GatePassDM.GatePassVisitorDM objVDM, GatePassDM.GatePassVisitorChildDM objVDMC, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(36);
            objDB.AddParameters(0, "GPSID", objVDM.GPSID, DbType.Int32);
            objDB.AddParameters(1, "GPSNO", objVDM.GPSNO, DbType.String);
            objDB.AddParameters(2, "GPSDate", objVDM.GPSDate, DbType.DateTime);
            objDB.AddParameters(3, "GPSTime", objVDM.GPSTime, DbType.String);
            objDB.AddParameters(4, "EnteredBY", objVDM.EnteredBY, DbType.String);
            objDB.AddParameters(5, "PassType", objVDM.PassType, DbType.Int32);
            objDB.AddParameters(6, "Purpose", objVDM.Purpose, DbType.String);
            objDB.AddParameters(7, "FirstName", objVDM.FirstName, DbType.String);
            objDB.AddParameters(8, "MiddleName", objVDM.MiddleName, DbType.String);
            objDB.AddParameters(9, "LastName", objVDM.LastName, DbType.String);
            objDB.AddParameters(10, "ContactNo", objVDM.ContactNo, DbType.String);
            objDB.AddParameters(11, "Address", objVDM.Address, DbType.String);
            objDB.AddParameters(12, "City", objVDM.City, DbType.Int32);
            objDB.AddParameters(13, "GateID", objVDM.GateID, DbType.String);
            objDB.AddParameters(14, "VehicalNo", objVDM.VehicalNo, DbType.String);
            objDB.AddParameters(15, "VehicalType", objVDM.VehicalType, DbType.String);
            objDB.AddParameters(16, "Visit_Department", objVDM.Visit_Department, DbType.Int32);
            objDB.AddParameters(17, "DestinationID", objVDM.DestinationID, DbType.Int32);
            objDB.AddParameters(18, "Visit_Purpose", objVDM.Visit_Purpose, DbType.String);
            objDB.AddParameters(19, "PersonTo_Meet", objVDM.PersonTo_Meet, DbType.String);
            objDB.AddParameters(20, "PassEntryFrom", objVDM.PassEntryFrom, DbType.String);
            objDB.AddParameters(21, "Status", objVDM.Status, DbType.Int32);
            objDB.AddParameters(22, "OutTime", objVDM.OutTime, DbType.String);
            objDB.AddParameters(23, "IsValidity", objVDM.IsValidity, DbType.Int32);
            objDB.AddParameters(24, "AppointmentID", objVDM.AppointmentID, DbType.Int32);
            objDB.AddParameters(25, "visitor_Photo", objVDM.visitor_Photo, DbType.Binary);
            objDB.AddParameters(26, "Carry_Item", objVDM.
                Carry_Item, DbType.String);
            objDB.AddParameters(27, "Remark", objVDM.Remark, DbType.String);
            objDB.AddParameters(28, "Flag", objVDM.Flag, DbType.String);
            objDB.AddParameters(29, "GatePID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            objDB.AddParameters(30, "Photo", objVDM.Photo, DbType.Binary);
            objDB.AddParameters(31, "NOS", objVDM.NOS, DbType.Int32);
            objDB.AddParameters(32, "NOM", objVDM.NOM, DbType.Int32);
            objDB.AddParameters(33, "NOF", objVDM.NOF, DbType.Int32);
            objDB.AddParameters(34, "UEname", objVDM.UEname, DbType.String);
            objDB.AddParameters(35, "UEDate", objVDM.UEDate, DbType.DateTime);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatePassEntry_Insert");
            Int32 sid = Int32.Parse(objDB.Parameters[29].Value.ToString());
            if (objVDM.Flag == "U")
            {
                sid = objVDM.GPSID;
            }
            else
            {
                sid = Int32.Parse(objDB.Parameters[29].Value.ToString());
            }

            objDB.CreateParameters(8);
            objDB.AddParameters(0, "GPSID", sid, DbType.Int32);
            objDB.AddParameters(1, "ValidFrom", objVDMC.ValidFrom, DbType.DateTime);
            objDB.AddParameters(2, "ValidTo", objVDMC.ValidTo, DbType.DateTime);
            objDB.AddParameters(3, "AmountPay", objVDMC.AmountPay, DbType.String);
            objDB.AddParameters(4, "PayMode", objVDMC.PayMode, DbType.String);
            objDB.AddParameters(5, "Satus", objVDMC.Satus, DbType.Int32);
            objDB.AddParameters(6, "IsExpired", objVDMC.IsExpired, DbType.Int32);
            objDB.AddParameters(7, "Flag", objVDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatePassEntryChild_Insert");
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
            if (objVDM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objVDM.Flag == "U")
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
    public string InsertGPmovementDM(GatePassDM.GPmovementDM objMVDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "MVID",objMVDM.MVID  , DbType.Int32);
            objDB.AddParameters(1, "EmpID", objMVDM.EmpID, DbType.Int32);
            objDB.AddParameters(2, "GatePID", objMVDM.GatePID , DbType.Int32);
            objDB.AddParameters(3, "InDate",objMVDM.InDate , DbType.DateTime);
            objDB.AddParameters(4, "InTime", objMVDM.InTime, DbType.String);
            objDB.AddParameters(5, "OutTime", objMVDM.OutTime, DbType.String);
            objDB.AddParameters(6, "OutDate", objMVDM.OutDate , DbType.DateTime);
            objDB.AddParameters(7, "statusgp", objMVDM.Statusgp, DbType.Int16 );
            objDB.AddParameters(8, "flag", objMVDM.flag, DbType.Int16 );
            objDB.AddParameters(9, "entry_date",DateTime.Now.Date , DbType.DateTime);
            objDB.AddParameters(10, "Entry_Type", objMVDM.Entry_Type , DbType.Int16);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GPmovementInsert");

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
            if (objMVDM.flag == 1)
            {
                retv = "Record saved.";
            }
            else if (objMVDM.flag ==2)
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
    public List<GatePassDM.GPDutyShiftFill> FillDutyShift()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillDutyShift");
        var listOfDate = new List<GatePassDM.GPDutyShiftFill>();
        while (dr.Read())
        {
            var item = new GatePassDM.GPDutyShiftFill();
            item.ShiftID = Education.DataHelper.GetInt(dr, "ShiftID");
            item.APerson = Education.DataHelper.GetString(dr, "APerson");
            item.FromDate = Education.DataHelper.GetDateTime(dr, "FromDate");
            item.ToDate = Education.DataHelper.GetDateTime(dr, "ToDate");
            item.FromTime = Education.DataHelper.GetString(dr, "FromTime");
            item.ToTime = Education.DataHelper.GetString(dr, "ToTime");            
            item.SeqPerson = Education.DataHelper.GetString(dr, "SeqPerson");
            item.GateNo = Education.DataHelper.GetString(dr, "GateNo");     
          
           
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfDate;
    }

    [OperationContract]
    public List<GatePassDM.GPDutyShiftFill> FillDutyShiftByID(Int32 ShiftID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "ShiftID", ShiftID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillDutyShiftByID");
        var listOfDate = new List<GatePassDM.GPDutyShiftFill>();
        try
        {
            while (dr != null)
            {
                var item = new GatePassDM.GPDutyShiftFill();
                item.ShiftID = Education.DataHelper.GetInt(dr, "ShiftID");
                item.APerson = Education.DataHelper.GetString(dr, "APerson");
                item.FromDate = Education.DataHelper.GetDateTime(dr, "FromDate");
                item.ToDate = Education.DataHelper.GetDateTime(dr, "ToDate");
                item.FromTime = Education.DataHelper.GetString(dr, "FromTime");
                item.ToTime = Education.DataHelper.GetString(dr, "ToTime");
                item.SeqPerson = Education.DataHelper.GetString(dr, "SeqPerson");
                item.GateNo = Education.DataHelper.GetString(dr, "GateNo");
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

[OperationContract]
    public List<GatePassDM.GPAppontmentFill> FillAppointmentList(Int32 AppointmentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "AppointmentID", AppointmentID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillApointmentList");
        var listOfDate = new List<GatePassDM.GPAppontmentFill>();
        try
        {
            while (dr != null)
            {
                var item = new GatePassDM.GPAppontmentFill();
                item.appID = Education.DataHelper.GetInt(dr, "appID");
                item.Name = Education.DataHelper.GetString(dr, "Name");
                item.Date = Education.DataHelper.GetDateTime(dr, "Date");
                item.ContactNo = Education.DataHelper.GetString(dr, "ContactNo");
                item.FromTime = Education.DataHelper.GetString(dr, "FromTime");
                item.ToTime = Education.DataHelper.GetString(dr, "ToTime");
                item.status = Education.DataHelper.GetString(dr, "status");

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

    [OperationContract]
    public List<GatePassDM.GateAppointMastDM> FillAppointmentListByID(Int32 AppointmentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "AppointmentID", AppointmentID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillApointmentList");
        var listOfDate = new List<GatePassDM.GateAppointMastDM>();
        try
        {
            if (dr.Read())
            {
                var item = new GatePassDM.GateAppointMastDM();
                item.appID = Education.DataHelper.GetInt(dr, "appID");
                item.FirstN = Education.DataHelper.GetString(dr, "FirstN");
                item.MidN = Education.DataHelper.GetString(dr, "MidN");
                item.LastN = Education.DataHelper.GetString(dr, "LastN");
                item.Email = Education.DataHelper.GetString(dr, "Email");
                item.ContactNo = Education.DataHelper.GetString(dr, "ContactNo");
                item.Address = Education.DataHelper.GetString(dr, "Address");
                item.Date = Education.DataHelper.GetDateTime(dr, "Date");
                item.Day = Education.DataHelper.GetString(dr, "Days");
                item.FromTime = Education.DataHelper.GetString(dr, "FromTime");
                item.ToTime = Education.DataHelper.GetString(dr, "ToTime");
                item.status = Education.DataHelper.GetString(dr, "status");
                item.isInform = Education.DataHelper.GetString(dr, "isInform");
                item.fwdTo = Education.DataHelper.GetString(dr, "fwdTo");
                item.appType = Education.DataHelper.GetString(dr, "appType");
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
    [OperationContract(IsOneWay = false)]
    public string InsertEmployee(GatePassDM.EmployeeDM FacultyM, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(24);
            objDB.AddParameters(0, "EmployeeID", FacultyM.EmployeeID, DbType.Int32);
            objDB.AddParameters(1, "Salutation", FacultyM.Salutation, DbType.String);
            objDB.AddParameters(2, "FirstName", FacultyM.FirstName, DbType.String);
            objDB.AddParameters(3, "MiddleName", FacultyM.MiddleName, DbType.String);
            objDB.AddParameters(4, "LastName", FacultyM.LastName, DbType.String);
            objDB.AddParameters(5, "Password", FacultyM.Password, DbType.String);
            objDB.AddParameters(6, "DepartmentID", FacultyM.DepartmentID, DbType.Int32);
            objDB.AddParameters(7, "Designation", FacultyM.Designation, DbType.Int32);
            objDB.AddParameters(8, "BirthDate", FacultyM.BirthDate, DbType.DateTime);
            objDB.AddParameters(9, "Address", FacultyM.Address, DbType.String);
            objDB.AddParameters(10, "City", FacultyM.City, DbType.Int32);

            objDB.AddParameters(11, "State", FacultyM.State, DbType.Int32);
            objDB.AddParameters(12, "Country", FacultyM.Country, DbType.Int32);
            objDB.AddParameters(13, "EmailID", FacultyM.EmailID, DbType.String);
            objDB.AddParameters(14, "Phone", FacultyM.Phone, DbType.String);
            objDB.AddParameters(15, "Mobile", FacultyM.Mobile, DbType.String);
            objDB.AddParameters(16, "Active", FacultyM.Active, DbType.String);

            objDB.AddParameters(17, "Councellor", FacultyM.Councellor, DbType.String);
            objDB.AddParameters(18, "InstituteID", FacultyM.InstituteID, DbType.Int32);
            objDB.AddParameters(19, "SessionID", FacultyM.SessionID, DbType.String);
            objDB.AddParameters(20, "UName", FacultyM.UName, DbType.String);
            objDB.AddParameters(21, "UEntDt", FacultyM.UEntDt, DbType.DateTime);
            objDB.AddParameters(22, "Photo", FacultyM.Photo, DbType.Binary);
            objDB.AddParameters(23, "Flag", FacultyM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Employee_Insert");
            f = FacultyM.Flag;

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

    [OperationContract]
    public List<GatePassDM.SearchAppointment> FillAppointmentListForGP(Int32 AppointmentBY)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Appointment_By", AppointmentBY, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillApointmentList");
        var listOfDate = new List<GatePassDM.SearchAppointment>();
        try
        {
            while (dr != null)
            {
                var item = new GatePassDM.SearchAppointment();
                item.appID = Education.DataHelper.GetInt(dr, "appID");
                item.AW = Education.DataHelper.GetString(dr, "AW");
                item.AB = Education.DataHelper.GetString(dr, "AB");
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

 
    public class GetINOUTEmployee : GatePassDM.SearchEmployeeInOutEnrty
    {
    }
    public GetINOUTEmployee FillEmployeeInOut(int EmployeeID,DateTime CurrentDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "EmpID", EmployeeID, DbType.Int32);
        objDB.AddParameters(1, "CurrentDate", CurrentDate, DbType.DateTime);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetEmployeeInOutEntryByDate");
        var GetList = new GetINOUTEmployee();
        if (dr.Read())
        {
            GetList.EmpID = EmployeeID;
            GetList.InDate = Education.DataHelper.GetDateTime(dr, "InDate");
            GetList.OutDate = Education.DataHelper.GetDateTime(dr, "OutDate");
            GetList.InTime = Education.DataHelper.GetString(dr, "InTime");
            GetList.OutTime = Education.DataHelper.GetString(dr, "OutTime");
            GetList.MVID = Education.DataHelper.GetInt(dr, "MVID");
        }
        return GetList;
    }

    public class GetINOUTEmployeeByID :List< GatePassDM.SearchEmployeeInOutEnrty>
    {
    }
    public GetINOUTEmployeeByID FillEmployeeInOutBYID(int EmployeeID, DateTime CurrentDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "EmpID", EmployeeID, DbType.Int32);
        objDB.AddParameters(1, "CurrentDate", CurrentDate, DbType.DateTime);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetEmployeeInOutByID");
        var GetList = new GetINOUTEmployeeByID();
        while (dr.Read())
        {
            var item = new GatePassDM.SearchEmployeeInOutEnrty();
            item.EmpID = EmployeeID;
            item.InDate = Education.DataHelper.GetDateTime(dr, "InDate");
            item.OutDate = Education.DataHelper.GetDateTime(dr, "OutDate");
            item.InTime = Education.DataHelper.GetString(dr, "InTime");
            item.OutTime = Education.DataHelper.GetString(dr, "OutTime");
            item.MVID = Education.DataHelper.GetInt(dr, "MVID");
            GetList.Add(item);
        }
        return GetList;
    }
    public GetINOUTEmployeeByID FillEmployeeInOutForReport(int EmployeeID, DateTime CurrentDate,int Flag,int INOUT)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(4);
        objDB.AddParameters(0, "EmpID", EmployeeID, DbType.Int32);
        objDB.AddParameters(1, "CurrentDate", CurrentDate, DbType.DateTime);
        objDB.AddParameters(2, "Flag", Flag, DbType.Int32);
        objDB.AddParameters(3, "InOUT", INOUT, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetEmployeeInOutForReport");
        var GetList = new GetINOUTEmployeeByID();
        while (dr.Read())
        {
            var item = new GatePassDM.SearchEmployeeInOutEnrty();
            item.EmpID = EmployeeID;
            item.InDate = Education.DataHelper.GetDateTime(dr, "InDate");
            item.OutDate = Education.DataHelper.GetDateTime(dr, "OutDate");
            item.InTime = Education.DataHelper.GetString(dr, "InTime");
            item.OutTime = Education.DataHelper.GetString(dr, "OutTime");
            item.MVID = Education.DataHelper.GetInt(dr, "MVID");
            item.Ename = Education.DataHelper.GetString(dr, "Ename");
            GetList.Add(item);
        }
        return GetList;
    }
    public class GetAppointmentList : List<GatePassDM.GateAppointListDM>
    {
    }
    public GetAppointmentList FillAppointmentByDate( DateTime CurrentDate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "AppDate", CurrentDate, DbType.DateTime);

        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FillAppointmentListByDate");
        var GetList = new GetAppointmentList();
       while (dr.Read())
        {
            var item = new GatePassDM.GateAppointListDM();
            item.appID = Education.DataHelper.GetInt(dr, "appID");
            item.Name = Education.DataHelper.GetString(dr, "Name");
            item.FromTime = Education.DataHelper.GetString(dr, "FromTime");
            item.ToTime = Education.DataHelper.GetString(dr, "ToTime");
            item.status = Education.DataHelper.GetString(dr, "status");
            item.Date = CurrentDate;
            GetList.Add(item);
        }
        return GetList;
    }

    [OperationContract]
    public DataTable  FillAppointmentListByIDtodt(Int32 AppointmentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "AppointmentID", AppointmentID, DbType.Int32);
        DataTable dt = new DataTable();
      try
        {
          dt=  objDB.ExecuteTable(CommandType.StoredProcedure, "FillApointmentList");
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
      return dt;
    }
     
}