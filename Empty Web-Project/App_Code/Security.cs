﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using NewDAL;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Security
{
    public class FillRoleGrd : List<SecurityDM.FillRoleDM>
    {
    }
    [OperationContract]
    public FillRoleGrd GetRoleGrd()
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text , "SELECT Rollid,Rollname,isactive  FROM CreateRoll");
        FillRoleGrd listOfStudent = new FillRoleGrd();
        while (dr.Read())
        {
            var item = new SecurityDM.FillRoleDM();
            item.RoleID = Education.DataHelper.GetInt(dr, "Rollid");
            item.RoleName = Education.DataHelper.GetString(dr, "Rollname");
            item.IsActive = Education.DataHelper.GetBoolean(dr, "IsActive");
            listOfStudent.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfStudent;
     
    }

     [OperationContract]
    public string  FindRoleByName(string RoleName)
     {
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         objDB.CreateParameters(1);
         objDB.AddParameters(0, "RoleName", RoleName, DbType.String);
         IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "select RollID from CreateRoll where  RollName=@RoleName");
         string retvalue = "";
         if (dr.Read())
         {
             retvalue = "Y";
         }
         else
         {
             retvalue = "N";
         }
         objDB.Connection.Close();
         objDB.Dispose();
         return retvalue;
     }

     [OperationContract]
     public List<SecurityDM.FillMenuIDDM> FillMenuIDAll()
     {
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.Text, "select id from menuStructure order by id");
         var ListItem = new List<SecurityDM.FillMenuIDDM>();
         while (dr.Read())
         {
             var item = new SecurityDM.FillMenuIDDM();
             item.MenuID = Education.DataHelper.GetInt(dr, "id");
             ListItem.Add(item);
         }
         objDB.Connection.Close();
         objDB.Dispose();
         return ListItem;
     }

     [OperationContract(IsOneWay = false)]
     public string InsertRole( SecurityDM.RoleDM  RoleDM, Admin.AdministratorData.AuditDM audit)
     {
         NewDAL.DBManager objDB = new DBManager();
         objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
         objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
         objDB.Open();
         objDB.BeginTransaction();
         string retv = "";
         int  f =0;
         try
         {

             objDB.CreateParameters(5);
             objDB.AddParameters(0, "RoleID", RoleDM.RoleID, DbType.Int32);
             objDB.AddParameters(1, "RoleName", RoleDM.RoleName, DbType.String);
             objDB.AddParameters(2, "IsActive", RoleDM.IsActive, DbType.String);
             objDB.AddParameters(3, "flag", RoleDM.Flag, DbType.Int32);
             objDB.AddParameters(4, "RoleIDreturn", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Createrole_Insert");
             Int32 Rid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
             if (RoleDM.Flag == 1)
             {
                 Rid = RoleDM.RoleID;
             }
             else
             {
                 Rid = Int32.Parse(objDB.Parameters[4].Value.ToString());
             }
             List<SecurityDM.FillMenuIDDM> FillMenuID = new List<SecurityDM.FillMenuIDDM>();
             FillMenuID = FillMenuIDAll();
             foreach (SecurityDM.FillMenuIDDM mID in FillMenuID)
             {
                 objDB.CreateParameters(7);
                 objDB.AddParameters(0, "RoleID", Rid, DbType.Int32);
                 objDB.AddParameters(1, "MenuID", mID.MenuID, DbType.Int32);
                 objDB.AddParameters(2, "permission", 0, DbType.Int32);
                 objDB.AddParameters(3, "insertOp", 0, DbType.Int32);
                 objDB.AddParameters(4, "updateOp", 0, DbType.Int32);
                 objDB.AddParameters(5, "deleteOp", 0, DbType.Int32);
                 objDB.AddParameters(6, "flag", RoleDM.Flag, DbType.String);
                 objDB.ExecuteNonQuery(CommandType.StoredProcedure, "menuPermissionSP");
             }
             f = RoleDM.Flag;
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
             if (f == 0)
             {
                 retv = "Record saved.";
             }
             else if (f == 1)
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
     public string InsertAssignRole(SecurityDM.AssignRoleDM RoleDM, Admin.AdministratorData.AuditDM audit)
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

             objDB.CreateParameters(11);
             objDB.AddParameters(0, "flag", RoleDM.flag, DbType.String);
             objDB.AddParameters(1, "id", RoleDM.id, DbType.Int32);
             objDB.AddParameters(2, "ARCID", RoleDM.ARCID, DbType.Int32);
             objDB.AddParameters(3, "roleID", RoleDM.roleID, DbType.Int32);
             objDB.AddParameters(4, "FieldId", RoleDM.FieldId, DbType.Int32);
             objDB.AddParameters(5, "FieldDataId", RoleDM.FieldDataId, DbType.String);
             objDB.AddParameters(6, "IndividualId", RoleDM.IndividualId, DbType.String);
             objDB.AddParameters(7, "instId", RoleDM.instId, DbType.Int32);
             objDB.AddParameters(8, "sessionId", RoleDM.sessionId, DbType.String);
             objDB.AddParameters(9, "FormId", RoleDM.FormId, DbType.String);
            // objDB.AddParameters(10, "flag_N", RoleDM.flag_N, DbType.String);
             objDB.AddParameters(10, "RetSuccess", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_AssignRole");

            // Rid = Int32.Parse(objDB.Parameters[11].Value.ToString());
      
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
             if (RoleDM.flag=="N")
             {
                 retv = "Record saved.";
             }
             else 
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
         return retv;
     }

     [OperationContract(IsOneWay = false)]
     public string InsertBulkAssignRole(List<SecurityDM.AssignRoleDM> RoleDM, Admin.AdministratorData.AuditDM audit)
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
             foreach (SecurityDM.AssignRoleDM tsv in RoleDM)
             {

                 objDB.CreateParameters(6);
                 objDB.AddParameters(0, "flag", tsv.flag, DbType.String);
                 objDB.AddParameters(1, "roleID", tsv.roleID, DbType.Int32);
                 objDB.AddParameters(2, "IndividualId", tsv.IndividualId, DbType.String);
                 objDB.AddParameters(3, "instId", tsv.instId, DbType.Int32);
                 objDB.AddParameters(4, "sessionId", tsv.sessionId, DbType.String);
                 objDB.AddParameters(5, "FormId", tsv.FormId, DbType.String);
                 retv = tsv.flag;
                 objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Insert_BulkAssignRole");
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
                 retv = "Record saved.";
             }
             else
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
         return retv;
     }
     [OperationContract(IsOneWay = false)]
     public string Insertformactivation(SecurityDM.FormActiDM RoleDM, Admin.AdministratorData.AuditDM audit)
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
             objDB.CreateParameters(14);
             objDB.AddParameters(0, "flag", RoleDM.flag, DbType.String);
             objDB.AddParameters(1, "id", RoleDM.id, DbType.Int32);
             objDB.AddParameters(2, "Inst_Id", RoleDM.Inst_Id, DbType.Int32);
             objDB.AddParameters(3, "SessionId", RoleDM.SessionId, DbType.String);
             objDB.AddParameters(4, "CourseId", RoleDM.CourseId, DbType.Int32);
             objDB.AddParameters(5, "splid", RoleDM.splid, DbType.Int32);
             objDB.AddParameters(6, "semid", RoleDM.semid, DbType.Int32);
             objDB.AddParameters(7, "FormId", RoleDM.FormId, DbType.Int32);
             objDB.AddParameters(8, "MoudleId", RoleDM.MoudleId, DbType.Int32);
             objDB.AddParameters(9, "Fromdate", RoleDM.Fromdate, DbType.DateTime);
             objDB.AddParameters(10, "Todate", RoleDM.Todate, DbType.DateTime);
             objDB.AddParameters(11, "Action", RoleDM.Action, DbType.Int32);
             objDB.AddParameters(12, "fromtime", RoleDM.fromtime, DbType.String);
             objDB.AddParameters(13, "totime", RoleDM.totime, DbType.String);
             objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertFormActivation");
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
             if (RoleDM.flag == "N")
             {
                 retv = "Record saved.";
             }
             else
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
         return retv;
     }
}
