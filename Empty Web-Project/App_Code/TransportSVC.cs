﻿using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Data;
using NewDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class TransportSVC
{
    [OperationContract(IsOneWay = false)]
    public string InsertRouteMaster(TransportDM.RouteMasterDM RouteDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "RouteID", RouteDM.RouteID, DbType.Int32);
            objDB.AddParameters(1, "Route_Name", RouteDM.Route_Name, DbType.String);
            objDB.AddParameters(2, "Short_Name", RouteDM.Short_Name, DbType.String);
            objDB.AddParameters(3, "UEDate", RouteDM.UEDate, DbType.DateTime);
            objDB.AddParameters(4, "U_Name", RouteDM.UEtime, DbType.String);
            objDB.AddParameters(5, "flag", RouteDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Route_Master_insert");
            f = RouteDM.Flag;
            objDB.CreateParameters(9);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
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
    public string InsertRouteMaster(TransportDM.TransportSectionDM RouteDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "SectionID", RouteDM.SectionID, DbType.Int32);
            objDB.AddParameters(1, "Section_Name", RouteDM.Short_Name, DbType.String);
            objDB.AddParameters(2, "Short_Name", RouteDM.Short_Name, DbType.String);
            objDB.AddParameters(3, "Status", RouteDM.Status, DbType.Int32);
            objDB.AddParameters(4, "UEDate", RouteDM.UEDate, DbType.DateTime);
            objDB.AddParameters(5, "U_Name", RouteDM.U_Name, DbType.String);
            objDB.AddParameters(6, "Flag", RouteDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Section_insert");
            f = RouteDM.Flag;
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

    DBManager objDB;
    [OperationContract]
    public List<TransportDM.RouteMasterDM > FillRoutes(string searchText)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.Text, "Select RouteID,Route_Name from Route_Master");
        var listOfCustomerItems = new List<TransportDM.RouteMasterDM >();
        if (dr.Read())
        {
            var item = new TransportDM.RouteMasterDM();
            item.RouteID= int.Parse(dr[0].ToString());
            item.Route_Name = dr[1].ToString();
            listOfCustomerItems.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return listOfCustomerItems;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertRouteSequence(TransportDM.RouteSequenceMDM RoutesequenceMDM,List< TransportDM.RouteSequenceCDM> RoutesequenceCDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "SeqID", RoutesequenceMDM.SeqID, DbType.Int32);
            objDB.AddParameters(1, "Seq_Code", RoutesequenceMDM.Seq_Code, DbType.String);
            objDB.AddParameters(2, "Fair_Charges", RoutesequenceMDM.Fair_Charges, DbType.Decimal);
            objDB.AddParameters(3, "Section_ID", RoutesequenceMDM.Section_ID, DbType.Int32);
            objDB.AddParameters(8, "Vehical_ID", RoutesequenceMDM.Vehical_ID, DbType.Int32);
            objDB.AddParameters(4, "UEDate", RoutesequenceMDM.UEDate, DbType.DateTime);
            objDB.AddParameters(5, "U_Name", RoutesequenceMDM.U_Name, DbType.String);
            objDB.AddParameters(6, "Flag", RoutesequenceMDM.Flag, DbType.Int32);
            objDB.AddParameters(7, "retSeqID",0, DbType.Int32,ParameterDirection.Output );
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_RouteSeq_Master_Insert");
            Int32 sid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
            if (RoutesequenceMDM.Flag == 1)
            {
                sid = RoutesequenceMDM.SeqID;
            }
            else
            {
                sid = Int32.Parse(objDB.Parameters[7].Value.ToString());
            }
            foreach (TransportDM.RouteSequenceCDM std in RoutesequenceCDM)
            {
                objDB.CreateParameters(5);
                objDB.AddParameters(0, "SeqID", sid, DbType.Int32);
                objDB.AddParameters(1, "RouteID", std.RouteID, DbType.Int32);
                objDB.AddParameters(2, "Seq_No", std.Seq_No, DbType.Int32);
                objDB.AddParameters(3, "Distance", std.Distance, DbType.Int32);
                objDB.AddParameters(4, "Flag", std.Flag, DbType.Int32);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_RouteSeq_Child_Insert");

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
            if (RoutesequenceMDM.Flag == 1)
            {
                retv = "Record saved.";
            }
            else if (RoutesequenceMDM.Flag == 0)
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
    public string InsertDriverMaster(TransportDM.DriverMasterDM DriverDM, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "Driver_ID", DriverDM.Driver_ID, DbType.Int32);
            objDB.AddParameters(1, "F_Name", DriverDM.F_Name, DbType.String);
            objDB.AddParameters(2, "M_Name", DriverDM.M_Name, DbType.String);
            objDB.AddParameters(3, "L_Name", DriverDM.L_Name, DbType.String);
            objDB.AddParameters(4, "Dob", DriverDM.DOB, DbType.DateTime);
            objDB.AddParameters(5, "Doj", DriverDM.DOJ, DbType.DateTime);
            objDB.AddParameters(6, "Licence_Num", DriverDM.Licence_Num, DbType.Int32);
            objDB.AddParameters(7, "Licence_Valid", DriverDM.Licence_Valid, DbType.DateTime);
            objDB.AddParameters(8, "Contact_Num", DriverDM.Contact_Num, DbType.String);
            objDB.AddParameters(9, "UEDate", DriverDM.UEDate, DbType.DateTime);
            objDB.AddParameters(10, "U_Name", DriverDM.U_Name, DbType.String);
            objDB.AddParameters(11, "Photo", DriverDM.Photo, DbType.Binary);
            objDB.AddParameters(12, "flag", DriverDM.Flag, DbType.Int32);
            objDB.AddParameters(13, "Section_ID", DriverDM.Section_ID, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Driver_Master_insert");
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
            if (DriverDM.Flag == 0)
            {
                retv = "Record saved.";
            }
            else if (DriverDM.Flag == 1)
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
    public DataTable SelectDriverByID(string Driver_ID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Driver_ID", Int32.Parse(Driver_ID), DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GetTranportDriverByDriverID");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertVehicalRegistrationMaster(TransportDM.VehicalRegistrationDM VehicalRegistration, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(21);
            objDB.AddParameters(0, "Vehical_ID", VehicalRegistration.Vehical_ID, DbType.Int32);
            objDB.AddParameters(1, "Vehical_No", VehicalRegistration.Vehical_No, DbType.String);
            objDB.AddParameters(2, "Vehical_Class", VehicalRegistration.Vehical_Class, DbType.String);
            objDB.AddParameters(3, "Chassis_No", VehicalRegistration.Chassis_No, DbType.String);
            objDB.AddParameters(4, "Engine_No", VehicalRegistration.Engine_No, DbType.String);
            objDB.AddParameters(5, "Makers_Name", VehicalRegistration.Makers_Name, DbType.String);
            objDB.AddParameters(6, "Registration_Date", VehicalRegistration.Registration_Date, DbType.DateTime);
            objDB.AddParameters(7, "Manufacture_Year", VehicalRegistration.Manufacture_Year, DbType.Int32);
            objDB.AddParameters(8, "Color", VehicalRegistration.Color, DbType.String);
            objDB.AddParameters(9, "Hourse_Power", VehicalRegistration.Hourse_Power, DbType.String);
            objDB.AddParameters(10, "Fuel_Used", VehicalRegistration.Fuel_Used, DbType.String);
            objDB.AddParameters(11, "Capacity", VehicalRegistration.Capacity, DbType.Int32);
            objDB.AddParameters(12, "Owner_Name", VehicalRegistration.Owner_Name, DbType.String);
            objDB.AddParameters(13, "Address", VehicalRegistration.Address, DbType.String);
            objDB.AddParameters(14, "Contact_No", VehicalRegistration.Contact_No, DbType.String);
            objDB.AddParameters(15, "Policy_No", VehicalRegistration.Policy_No, DbType.String);
            objDB.AddParameters(16, "Valid_From", VehicalRegistration.Valid_From, DbType.DateTime);
            objDB.AddParameters(17, "Valid_To", VehicalRegistration.Valid_To, DbType.DateTime);
            objDB.AddParameters(18, "UEDate", VehicalRegistration.UEDate, DbType.DateTime);
            objDB.AddParameters(19, "U_Name", VehicalRegistration.U_Name, DbType.String);
            objDB.AddParameters(20, "Flag", VehicalRegistration.Flag, DbType.Int32);
            objDB.AddParameters(21, "Section_ID", VehicalRegistration.Section_ID, DbType.Int32);
            objDB.AddParameters(22, "Reg_Type", VehicalRegistration.Reg_Type, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehical_Registration_Insert");
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
            if (VehicalRegistration.Flag == 0)
            {
                retv = "Record saved.";
            }
            else if (VehicalRegistration.Flag == 1)
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
    public VehicalCollection FillVehicalRegistrationALL()
    {
        VehicalCollection vc = new VehicalCollection();

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Transport_Vechical_Registration");
        try
        {
            while (dr != null && dr.Read())
            {
                TransportDM.VehicalRegistrationDM objDM = new TransportDM.VehicalRegistrationDM();
                objDM.Vehical_ID = Education.DataHelper.GetInt(dr, "Vehical_ID");
                objDM.Vehical_No = Education.DataHelper.GetString(dr, "Vehical_No");
                objDM.Vehical_Class = Education.DataHelper.GetString(dr, "Vehical_Class");
               objDM.Chassis_No = Education.DataHelper.GetString(dr, "Chassis_No");
                objDM.Engine_No = Education.DataHelper.GetString(dr, "Engine_No");
                objDM.Makers_Name = Education.DataHelper.GetString(dr, "Makers_Name");
                objDM.Registration_Date = Education.DataHelper.GetDateTime(dr, "Registration_Date");
                objDM.Manufacture_Year = Education.DataHelper.GetInt(dr, "Manufacture_Year");
                objDM.Color = Education.DataHelper.GetString(dr, "Color");
                objDM.Hourse_Power = Education.DataHelper.GetString(dr, "Hourse_Power");
                objDM.Fuel_Used = Education.DataHelper.GetString(dr, "Fuel_Used");
                objDM.Capacity = Education.DataHelper.GetInt(dr, "Capacity");
                objDM.Owner_Name = Education.DataHelper.GetString(dr, "Owner_Name");
                objDM.Address = Education.DataHelper.GetString(dr, "Address");
                objDM.Contact_No = Education.DataHelper.GetString(dr, "Contact_No");
                objDM.Policy_No = Education.DataHelper.GetString(dr, "Policy_No");
                objDM.Valid_From = Education.DataHelper.GetDateTime(dr, "Valid_From");
                objDM.Valid_To = Education.DataHelper.GetDateTime(dr, "Valid_To");
                vc.Add(objDM);

            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return vc;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertRemark(TransportDM.RemarkMDM RDM, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(3);
            objDB.AddParameters(0, "RemarkID", RDM.RemarkID, DbType.Int32);
            objDB.AddParameters(1, "Remark", RDM.Remark, DbType.String);
            objDB.AddParameters(2, "flag", RDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatePass_Remark_insert");
            f = RDM.Flag;
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


    public class VehicalCollection : List<TransportDM.VehicalRegistrationDM>
    {
    }
    [OperationContract(IsOneWay = false)]
    public FillVehicle FillVehicalRegistration()
    {
        FillVehicle vc = new FillVehicle();

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "Select * from Transport_Vechical_Registration");
        try
        {
            while (dr != null)
            {
                TransportDM.VehicleNoFill objDM = new TransportDM.VehicleNoFill();
                objDM.Vehical_ID = Education.DataHelper.GetInt(dr, "Vehical_ID");
                objDM.Vehical_No = Education.DataHelper.GetString(dr, "Vehical_No");
                vc.Add(objDM);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        
        return vc;
    }
    public class FillVehicle : List<TransportDM.VehicleNoFill>
    {
    }

   
    [OperationContract(IsOneWay = false)]
    public string InsertVehicleSchedule(TransportDM.VehicleScheduleDMM VCDM, List<TransportDM.VehicleScheduleDMC> VCDMC, Admin.AdministratorData.AuditDM audit)
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
            objDB.AddParameters(0, "Schedule_ID", VCDM.Schedule_ID, DbType.Int32);
            objDB.AddParameters(1, "Route_ID", VCDM.Route_ID, DbType.Int32);
            objDB.AddParameters(2, "Vehicel_ID", VCDM.Vehicel_ID, DbType.Int32);
            objDB.AddParameters(3, "MonthID", VCDM.MonthID, DbType.Int32);
            objDB.AddParameters(4, "Syear", VCDM.Syear, DbType.Int32);
            objDB.AddParameters(5, "Default_Time_Hr", VCDM.Default_Time_Hr, DbType.Int32);
            objDB.AddParameters(6, "Default_Time_Min", VCDM.Default_Time_Min, DbType.Int32);
            objDB.AddParameters(7, "Default_Time_TT", VCDM.Default_Time_TT, DbType.String);
            objDB.AddParameters(8, "ReSch_Duration", VCDM.ReSch_Duration, DbType.Int32);
            objDB.AddParameters(9, "ReSch_Time", VCDM.ReSch_Time, DbType.Int32);
            objDB.AddParameters(10, "Status", VCDM.Status, DbType.String);
            objDB.AddParameters(11, "U_Name", VCDM.U_Name, DbType.String);
            objDB.AddParameters(12, "UE_Date", VCDM.UE_Date, DbType.DateTime);
            objDB.AddParameters(13, "flag", VCDM.Flag, DbType.String);
            objDB.AddParameters(14, "retSchedule_ID","VVVVVVVV", DbType.String,ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_Schedule_M_Insert");
            Int32 sid = 0; 
            if (VCDM.Flag != "N")
            {
                sid = VCDM.Schedule_ID;
            }
            else
            {
                sid = Int32.Parse(objDB.Parameters[14].Value.ToString());
            }
            foreach (TransportDM.VehicleScheduleDMC std in VCDMC)
            {
                objDB.CreateParameters(6);
                objDB.AddParameters(0, "Schedule_ID", sid, DbType.Int32);
                objDB.AddParameters(1, "SDate", std.SDate, DbType.DateTime);
                objDB.AddParameters(2, "SDay", std.SDay, DbType.String);
                objDB.AddParameters(3, "S_Time_Hr", std.S_Time, DbType.String);
                objDB.AddParameters(4, "Status", std.Status, DbType.String);
                objDB.AddParameters(5, "flag", std.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_Schedule_C_Insert");

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
    [OperationContract]
    public List<TransportDM.VehicleScheduleChartDate> searchDate(int RouteID,int MonthID,int Year)
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

        var listOfDate = new List<TransportDM.VehicleScheduleChartDate>();
        try
        {
            while (dr != null)
            {
                var item = new TransportDM.VehicleScheduleChartDate();
                item.ScheduleDate = Education.DataHelper.GetDateTime(dr, "SDate");
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
    public List<TransportDM.VehicleScheduleChartTime> searchTime(int RouteID, int MonthID, int Year)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "RouteID", RouteID, DbType.Int32);
        objDB.AddParameters(1, "MonthID", MonthID, DbType.Int32);
        objDB.AddParameters(2, "Year", Year, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Vehicle_Schedule_Time");

        var listOfDate = new List<TransportDM.VehicleScheduleChartTime>();
        try
        {
            while (dr != null)
            {
                var item = new TransportDM.VehicleScheduleChartTime();
                item.ScheduleTime = Education.DataHelper.GetString(dr, "S_Time_Hr");
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
    public List<TransportDM.VehicleScheduleList> FillScheduleVehicle(int RouteID, int MonthID, int Year,DateTime dtschedule,string scheduletime)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(5);
        objDB.AddParameters(0, "RouteID", RouteID, DbType.Int32);
        objDB.AddParameters(1, "MonthID", MonthID, DbType.Int32);
        objDB.AddParameters(2, "Year", Year, DbType.Int32);
        objDB.AddParameters(3, "Sdate", dtschedule, DbType.DateTime);
        objDB.AddParameters(4, "Time", scheduletime, DbType.String);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Vehicle_Schedule_All");
        var listOfSchedule = new List<TransportDM.VehicleScheduleList>();
        try
        {
            while (dr != null)
            {
                var item = new TransportDM.VehicleScheduleList();
                item.VehicleNo = Education.DataHelper.GetString(dr, "Vehical_No");
                listOfSchedule.Add(item);
            }
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return listOfSchedule;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertRemark(TransportDM.ManufactureMasterDM RDM, Admin.AdministratorData.AuditDM audit)
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

        objDB.CreateParameters(3);
        objDB.AddParameters(0, "ManufactureID", RDM.ManufactureID, DbType.Int32);
        objDB.AddParameters(1, "Manufacture_Name", RDM.Manufacture_Name, DbType.String);
        objDB.AddParameters(2, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Manufacture_Master_insert");
        f = RDM.flag;
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
    public string InsertVendor(TransportDM.VendorMasterDM RDM, Admin.AdministratorData.AuditDM audit)
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
        objDB.AddParameters(0, "VendorID", RDM.VendorID, DbType.Int32);
        objDB.AddParameters(1, "Vendor_Name", RDM.Vendor_Name, DbType.String);
        objDB.AddParameters(2, "Address", RDM.Address, DbType.String);
        objDB.AddParameters(3, "Contact_Num", RDM.Contact_Num, DbType.String);
        objDB.AddParameters(4, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vendor_Master_insert");
        f = RDM.flag;
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
    public string InsertManufacture(TransportDM.ManufactureMasterDM RDM, Admin.AdministratorData.AuditDM audit)
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

        objDB.CreateParameters(3);
        objDB.AddParameters(0, "ManufactureID", RDM.ManufactureID, DbType.Int32);
        objDB.AddParameters(1, "Manufacture_Name", RDM.Manufacture_Name, DbType.String);        
        objDB.AddParameters(2, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Manufacture_Master_insert");
        f = RDM.flag;
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
    public string InsertFuelType(TransportDM.FuelTypeDM RDM, Admin.AdministratorData.AuditDM audit)
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
        objDB.AddParameters(0, "FuelID", RDM.FuelID, DbType.Int32);
        objDB.AddParameters(1, "Fuel_Type", RDM.Fuel_Type, DbType.String);
        objDB.AddParameters(2, "Short_Name", RDM.Short_Name, DbType.String);
        objDB.AddParameters(3, "Measuring_Unit", RDM.Measuring_Unit, DbType.String);
        objDB.AddParameters(4, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_FuelType_insert");
        f = RDM.flag;
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
    public string InsertFuelcharge(TransportDM.FuelChargeDM RDM, Admin.AdministratorData.AuditDM audit)
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
        objDB.AddParameters(0, "TypeID", RDM.TypeID, DbType.Int32);
        objDB.AddParameters(1, "Type", RDM.Type, DbType.String);
        objDB.AddParameters(2, "Charge", RDM.Charge, DbType.String);
        objDB.AddParameters(3, "Wef_Date", RDM.Wef_Date, DbType.DateTime);
        objDB.AddParameters(4, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_FuelCharge_insert");
        f = RDM.flag;
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
    public string PartListMaster(TransportDM.PartListMasterDM RDM, Admin.AdministratorData.AuditDM audit)
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
        objDB.AddParameters(0, "PartID", RDM.PartID, DbType.Int32);
        objDB.AddParameters(1, "Part_Name", RDM.Part_Name, DbType.String);
        objDB.AddParameters(2, "Vendor", RDM.Vendor, DbType.String);
        objDB.AddParameters(3, "Manufacturer", RDM.Manufacturer, DbType.String);
        objDB.AddParameters(4, "Cost", RDM.Cost, DbType.String);
        objDB.AddParameters(5, "Remark", RDM.Remark, DbType.String);
        objDB.AddParameters(6, "Wef_Date", RDM.Wef_Date, DbType.DateTime);
        objDB.AddParameters(7, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_PartListMaster_insert");
        f = RDM.flag;
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
    public string ServiceListMaster(TransportDM.ServiceListMasterDM RDM, Admin.AdministratorData.AuditDM audit)
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
        objDB.AddParameters(0, "SreviceID", RDM.SreviceID, DbType.Int32);
        objDB.AddParameters(1, "Service_Name", RDM.Service_Name, DbType.String);
        objDB.AddParameters(2, "Frequency", RDM.Frequency, DbType.String);
        objDB.AddParameters(3, "Frequency_Type", RDM.Frequency_Type, DbType.String);
        objDB.AddParameters(4, "Frequency_Date", RDM.Frequency_Date, DbType.DateTime);
        objDB.AddParameters(5, "Frequency_Limit", RDM.Frequency_Limit, DbType.String);        
        objDB.AddParameters(6, "flag", RDM.flag, DbType.String);
        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_ServiceListMaster_insert");
        f = RDM.flag;
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
   /*  [OperationContract(IsOneWay = false)]
   public string InsertRemark(TransportDM.RemarkMDM RDM, Admin.AdministratorData.AuditDM audit)
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

            objDB.CreateParameters(3);
            objDB.AddParameters(0, "RemarkID", RDM.RemarkID, DbType.Int32);
            objDB.AddParameters(1, "Remark", RDM.Remark, DbType.String);
            objDB.AddParameters(2, "flag", RDM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "GatePass_Remark_insert");
            f = RDM.Flag;
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
    }*/
     //[OperationContract(IsOneWay = false)]
     //public string InsertVehicleBuspass(TransportDM.VehicleBuspassDM BPDM,TransportDM.VehicleBuspasschildDM BPCDM, Admin.AdministratorData.AuditDM audit)
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

     //        objDB.CreateParameters(11);
     //        objDB.AddParameters(0, "BPassID", BPDM.BPassID, DbType.Int32);
     //        objDB.AddParameters(1, "pass_Num", BPDM.Pass_Num, DbType.Int32);
     //        objDB.AddParameters(2, "PIssueTo",BPDM.PIssueTo, DbType.String);
     //        objDB.AddParameters(3, "MemberName", BPDM.MemberName, DbType.String);
     //        objDB.AddParameters(4, "BPDate",BPDM.BPDate, DbType.DateTime);
     //        objDB.AddParameters(5,"BPTime",BPDM.BPTime, DbType.String);
     //        objDB.AddParameters(6,"Route_Path",BPDM.Route_Path, DbType.String);
     //        objDB.AddParameters(7, "Vehical_ID", BPDM.Vehical_ID, DbType.Int32);
     //        objDB.AddParameters(8,"Vehicle_Num",BPDM.Vehicle_Num, DbType.String);
     //        objDB.AddParameters(9,"flag",BPDM.flag, DbType.String);
     //        objDB.AddParameters(10,"BPID","xxxxxxxxxx",DbType.Int32,ParameterDirection.Output);
     //        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_BuspassInsert");
     //        f = BPDM.flag;
     //        Int32 BPassID = 0;
     //        //string prnoid = String.Empty;
     //        BPassID = Int32.Parse(objDB.Parameters[1].Value.ToString());

     //       // foreach (TransportDM.VehicleBuspasschildDM bpc in BPCDM)
     //       // {
     //            objDB.CreateParameters(7);
     //            objDB.AddParameters(0, "BPCHID", BPCDM.BPCHID, DbType.Int32);
     //            objDB.AddParameters(1, "BPassID", BPassID, DbType.Int32);
     //            objDB.AddParameters(2, "Valid_From", BPCDM.Valid_From, DbType.DateTime);
     //            objDB.AddParameters(3, "Valid_To", BPCDM.Valid_To, DbType.DateTime);
     //            objDB.AddParameters(4, "Charges", BPCDM.Charges, DbType.Decimal);
     //            objDB.AddParameters(5, "Total_Charges", BPCDM.Total_Charge, DbType.Decimal);
     //            objDB.AddParameters(6, "flag", BPCDM.flag, DbType.String);
     //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_BuspassChildInsert");
     //            objDB.CreateParameters(9);
     //        //}
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


     //        if (f == "N")
     //        {
     //            retv = "Record saved.";
     //        }
     //        else if (f == "U")
     //        {
     //            retv = "Record Updated Successfully.";
     //        }
     //        else
     //        {
     //            retv = "Record deleted Successfully.";
     //        }
     //    }
     //    catch (Exception ex)
     //    {
     //        objDB.Transaction.Rollback();
     //        retv = "Unable to save record :-" + ex.Message.ToString();
     //    }
     //    finally
     //    {

     //        objDB.Connection.Close();
     //        objDB.Dispose();
     //    }
     //    return retv;
     //}
     [OperationContract(IsOneWay = false)]
     public string InsertVehicleStandPass(TransportDM.VehicleStandPassDM SPDM, TransportDM.VehicleStandPassChildDM SPCDM, Admin.AdministratorData.AuditDM audit)
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
             objDB.AddParameters(0, "VehicleID",SPDM.VehicleID , DbType.Int32);
             objDB.AddParameters(1, "Vehicle_Num",SPDM.Vehicle_Num, DbType.Int32);
             objDB.AddParameters(2, "Registered_Name", SPDM.Registered_Name, DbType.String);
             objDB.AddParameters(3, "Contact_Num", SPDM.Contact_Num, DbType.String);
             objDB.AddParameters(4, "Charges", SPDM.Charges, DbType.String);
             objDB.AddParameters(5, "Valid_from",SPDM.Valid_from, DbType.DateTime);
             objDB.AddParameters(6, "Valid_to",SPDM.Valid_to, DbType.String);
             objDB.AddParameters(7, "Expired", SPDM.Expired, DbType.String);
             objDB.AddParameters(8, "Cancelled", SPDM.Cencelled, DbType.String);
             objDB.AddParameters(9, "Renew", SPDM.Renew, DbType.String);
             objDB.AddParameters(10, "Total_amount",SPDM.Total_amount, DbType.String);
             objDB.AddParameters(11, "Pay_mode", SPDM.Pay_mode, DbType.String);
             //objDB.AddParameters(8, "UEDate", BPDM.flag, DbType.String);
             //objDB.AddParameters(9, "BPID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);

             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_StandPassInsert");
             f = SPDM.flag;
             Int32 VehicleID = 0;
             //string prnoid = String.Empty;
             VehicleID = Int32.Parse(objDB.Parameters[0].Value.ToString());

             // foreach (TransportDM.VehicleBuspasschildDM bpc in BPCDM)
             // {

             objDB.CreateParameters(8);
             objDB.AddParameters(0, "VSPCID",SPCDM.VSPCID, DbType.Int32);
             objDB.AddParameters(1, "VehicleID",SPCDM.VehicleID, DbType.Int32);
             objDB.AddParameters(2, "VehicleNo", SPCDM.VehicleNo, DbType.String);
             objDB.AddParameters(3, "FromDate",SPCDM.FromDate , DbType.DateTime);
             objDB.AddParameters(4, "ToDate",SPCDM.ToDate , DbType.DateTime);
             objDB.AddParameters(5, "TotalCharges",SPCDM.TotalCharges , DbType.Decimal);
             objDB.AddParameters(6, "Charges",SPCDM.Charges , DbType.Decimal);
             objDB.AddParameters(7, "flag",SPCDM.flag, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Transport_Vehicle_StandPassChildInsert");
             objDB.CreateParameters(9);
             //}
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

     public DataTable FillTransportStReport(int CourseID, int InstituteID, int SemesterID, int flag)
     {
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         DataTable dt = new DataTable();
         try
         {
             objDB.CreateParameters(4);
             objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
             objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
             objDB.AddParameters(2, "SemesterID", SemesterID, DbType.Int32);
             objDB.AddParameters(3, "flag", flag, DbType.Int32);
             dt = objDB.ExecuteTable(CommandType.Text, "select StudentName,RollNo,RegNo,CourseName,feeName,YrSem from StReport_vw where CourseId='" + CourseID + "' and InstituteID='" + InstituteID + "' and SemesterID ='" + SemesterID + "'");
             //dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StReport_select");
         }
         finally
         {
             objDB.Connection.Close();
             objDB.Connection.Dispose();
             objDB.Dispose();
         }
         return dt;
     }
     public DataTable FillTransportEmpReport(int SeqID, int Vehical_ID, int RouteID, int flag)
     {
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         DataTable dt = new DataTable();
         try
         {
             objDB.CreateParameters(4);
             //objDB.AddParameters(0, "StudentName", StudentName, DbType.String);
             objDB.AddParameters(0, "SeqID", SeqID, DbType.Int32);
             objDB.AddParameters(1, "Vehical_ID", Vehical_ID, DbType.Int32);
             objDB.AddParameters(2, "RouteID", RouteID, DbType.Int32);
             //objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
             objDB.AddParameters(3, "flag", flag, DbType.Int32);
             dt = objDB.ExecuteTable(CommandType.StoredProcedure, "emp_select");
         }
         finally
         {
             objDB.Connection.Close();
             objDB.Connection.Dispose();
             objDB.Dispose();
         }
         return dt;
     }
     public DataTable FillTransportBusAllot(int InstituteID, int Vehical_ID, int flag)
     {
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         DataTable dt = new DataTable();
         try
         {
             objDB.CreateParameters(3);
             //objDB.AddParameters(0, "StudentName", StudentName, DbType.String);
             //objDB.AddParameters(1, "Route_Name", Route_Name, DbType.String);
             objDB.AddParameters(0, "Vehical_ID", Vehical_ID, DbType.Int32);
             objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
             objDB.AddParameters(2, "flag", flag, DbType.Int32);
             dt = objDB.ExecuteTable(CommandType.StoredProcedure, "BusAllot_select");
         }
         finally
         {
             objDB.Connection.Close();
             objDB.Connection.Dispose();
             objDB.Dispose();
         }
         return dt;
     }
     public void FillYear(DropDownList ddl, string inst_id, int flag, string ZeroIndexVal)
     {
         ddl.Items.Clear();
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         objDB.CreateParameters(2);
         objDB.AddParameters(0, "InstituteID", inst_id, DbType.String);
         //objDB.AddParameters(1, "SessionID", sessn, DbType.String);
         objDB.AddParameters(1, "flag", flag, DbType.Int32);

         SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "bus_select");
         if (dr.HasRows)
         {
             ddl.DataSource = dr;
             ddl.DataTextField = "YEAR";
             ddl.DataValueField = "YEAR";
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
}
