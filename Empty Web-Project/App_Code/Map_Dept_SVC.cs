using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using   NewDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for Map_Dept_SVC
/// </summary>
/// 

[ServiceContract(Namespace = "", CallbackContract = typeof(IFeeSVC), ConfigurationName = "Service")]
public interface IFeeSVC    //IMap_Dept_SVC
{
    [OperationContract(IsOneWay=false)]
    string insertChildDesig(HRM.Fee.DesigChild chDesig);

    [OperationContract(IsOneWay=false)]
    string insertChildJob(HRM.Fee.JobChild chJob);

    [OperationContract(IsOneWay = false)]
    string insertCountry(HRM.Fee.CountryDM objCoun);

    [OperationContract(IsOneWay = false)]
    string insertstate(HRM.Fee.StateDM objstat);

    [OperationContract(IsOneWay = false)]
    string insertcity(HRM.Fee.CityDM objCty);

    [OperationContract(IsOneWay = false)]
    string insertEprofile(HRM.Fee.EprofDM objProf);

    [OperationContract(IsOneWay = false)]
    string insertoffday(HRM.Fee.offdayDM objofday);

    [OperationContract(IsOneWay = false)]
    string insertdepartment(HRM.Fee.DepartmentDM objDept);

    [OperationContract(IsOneWay = false)]
    string insertDesignation(HRM.Fee.DesigntionDM objdesg);

    [OperationContract(IsOneWay = false)]
    string insertEmpJob(HRM.Fee.EmpNatureDM objEnat);

    [OperationContract(IsOneWay = false)]
    string insertexpertise(HRM.Fee.ExpertisDM objExprt);

    [OperationContract(IsOneWay = false)]
    string insertservice(HRM.Fee.ServiceDM objService);
    [OperationContract(IsOneWay=false)]
    string insertWorkDay(List< HRM.Fee.WorkDayDM> objWorkDay);

    [OperationContract(IsOneWay = false)]
    List<HRM.Fee.EmpWage> FillEmpWage(HRM.Fee.EmpWage objEmpWage);
    [OperationContract(IsOneWay = false)]
    string insertEmpPMode(List<HRM.Fee.EmpPayMode> ObjEmpPMode);
    [OperationContract]
    List<HRM.Fee.EmpPayMode> FillEmpMode(Int32 deptID,Int32 desigID);

    [OperationContract(IsOneWay = false)]
    string insertresignation(List<HRM.Fee.ResignDM> objResgn);
    [OperationContract(IsOneWay = false)]
    List<HRM.Fee.ResignDM> fillResgn(String flag, Int32 deptid, Int32 desigid, DateTime frmdate, DateTime todate);

    [OperationContract(IsOneWay = false)]
    List<HRM.Fee.ProbationDM> fillProbation(String flag,Int32 deptid, Int32 desigid);
    [OperationContract(IsOneWay = false)]
    string insertProbation(List<HRM.Fee.ProbationDM> objProbtion);
}

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
[ServiceBehavior (ConcurrencyMode=ConcurrencyMode.Multiple)]
public class FeeSVC:IFeeSVC //Map_Dept_SVC :IFeeSVC
{
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
    [OperationContract]
    public List<HRM.Fee.EmpPayMode> FillEmpMode(Int32 deptID,Int32 desigID)
    {
        SqlCommand com = null;
        //DataTable dt = new DataTable();
        var ListItem = new List<HRM.Fee.EmpPayMode>();
        SqlConnection cnx = new SqlConnection(ReturnConString());
        com = new SqlCommand();
        SqlDataReader dr;
        cnx.Open();
        com.Connection = cnx;
        com.Parameters.AddWithValue("@flag", "S");
        com.Parameters.AddWithValue("@deptId", deptID);
        com.Parameters.AddWithValue("@desigId", desigID);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[spEmpPayMode]";
        dr = com.ExecuteReader();
        while (dr.Read())
        {
            var Item = new HRM.Fee.EmpPayMode();
            //var Item1 = new HRM.Fee.Resign();
            //Item.mId = Int32.Parse(dr["mId"].ToString()); 
            //Item.deptId = Int32.Parse(dr["deptId"].ToString());
            //Item.desigId = Int32.Parse(dr["desigId"].ToString());
            Item.empId = Int32.Parse(dr["empId"].ToString());
            Item.paymodeId = dr["paymodeId"].ToString();
            Item.empCode = dr["empCode"].ToString();
            Item.empName = dr["empName"].ToString();
            if(dr["WED"].ToString()!=string.Empty)
            Item.WED = Convert.ToDateTime(dr["WED"].ToString());
            Item.AccNo = dr["AccNo"].ToString();
            Item.typeAcc = dr["typeAcc"].ToString();
            ListItem.Add(Item);

        } dr.Close(); dr.Dispose();
        //base.Fill_Prod_Grid_(ObjSuppData.flag, ObjSuppData.PRID, ObjSuppData.InstID, ref dt);
        
        return ListItem;
    }    
    [OperationContract]
    public List<HRM.Fee.ResignDM> fillResgn(String flag, Int32 deptid, Int32 desigid, DateTime frmdate, DateTime todate)
    {        
        var listitem = new List<HRM.Fee.ResignDM>();
        SqlConnection con = new SqlConnection(ReturnConString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@flag",flag);
        cmd.Parameters.AddWithValue("@deptId", deptid);
        cmd.Parameters.AddWithValue("@desigId", desigid);
        if(flag=="R")
        {
            cmd.Parameters.AddWithValue("@frmdate", frmdate);
            cmd.Parameters.AddWithValue("@todate", todate);
        } 
       
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_MasterResign";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var Item = new HRM.Fee.ResignDM();
            //var item = new HRM.Fee.Resign();
            Item.empCode = dr["empcode"].ToString();
            Item.empName = dr["empName"].ToString();
            Item.EmpId = Int32.Parse(dr["empid"].ToString());
            Item.deptId = Int32.Parse(dr["deptid"].ToString());
            Item.desigid = Int32.Parse(dr["desigID"].ToString());
            Item.Reason = dr["Reason"].ToString();
            if (dr["wed"].ToString() != string.Empty)
            Item.Wed = Convert.ToDateTime(dr["wed"].ToString());           
            listitem.Add(Item);
        }
        dr.Close();
        dr.Dispose();
        return listitem;
    }
    [OperationContract]
    public List<HRM.Fee.ProbationDM> fillProbation(String flag, Int32 deptid, Int32 desigid)
    {
        var listitem = new List<HRM.Fee.ProbationDM>();
        SqlConnection con = new SqlConnection(ReturnConString());
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@flag", flag);
        cmd.Parameters.AddWithValue("@deptid",deptid);
        cmd.Parameters.AddWithValue("@desigid",desigid);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Sp_Master_EmpProbation";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var item = new HRM.Fee.ProbationDM();
            item.deptid = Int32.Parse(dr["deptid"].ToString());
            item.desigid = Int32.Parse(dr["desigid"].ToString());
            item.empid = Int32.Parse(dr["empid"].ToString());
            item.empcode = dr["empcode"].ToString();
            item.empname = dr["empname"].ToString();
            if(flag=="E")
            {
            if (dr["Fromdate"].ToString() != string.Empty)
                item.Fromdate = dr["Fromdate"].ToString();// Convert.ToDateTime(dr["Fromdate"].ToString());
            if (dr["Todate"].ToString() != string.Empty)
                item.todate = dr["Todate"].ToString();// Convert.ToDateTime(dr["Todate"].ToString());
            }
            else if(flag=="S")
            {
                item.Fromdate = string.Empty;
                item.todate = string.Empty;
            }
            listitem.Add(item);
        }
        dr.Close();
        dr.Dispose();
        return listitem;
    }
    
    [OperationContract]
    public string insertWorkDay(List<HRM.Fee.WorkDayDM> objWorkDay)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retStr = string.Empty;
        string RetSuccess = string.Empty;
        Boolean SuccessFlag = true;

        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            foreach (HRM.Fee.WorkDayDM ObjItems in objWorkDay)
            {
                //base.Vendor_Dtls_Save(ObjItems.flag, ObjItems.ID, ObjItems.PRID, ObjItems.Ctrl_Id, ObjItems.SupplierId, ObjItems.IndentID, ObjItems.UID, ObjItems.SessionID, ObjItems.InstID, ref RetSuccess);
                objDB.Command.Parameters.Clear();
                objDB.CreateParameters(15);
                objDB.AddParameters(0, "yearID", ObjItems.yearID, DbType.Int32);
                objDB.AddParameters(1, "workDays", ObjItems.workDays, DbType.String);
                objDB.AddParameters(2, "InstituteID", ObjItems.InstituteID, DbType.Int32);
                objDB.AddParameters(3, "workdayID", ObjItems.workdayID, DbType.Int32);
                objDB.AddParameters(4, "frmdate", ObjItems.frmdate, DbType.DateTime);
                objDB.AddParameters(5, "todate", ObjItems.todate, DbType.DateTime);
                objDB.AddParameters(6, "cdate", ObjItems.cdate, DbType.DateTime);
                objDB.AddParameters(7, "edate", ObjItems.edate, DbType.Int32);
                objDB.AddParameters(8, "mnth", ObjItems.mnth, DbType.Int32);
                objDB.AddParameters(9, "yr", ObjItems.yr, DbType.Int32);
                objDB.AddParameters(10, "deptID", ObjItems.deptID, DbType.Int32);
                objDB.AddParameters(11, "UserID", ObjItems.UserID, DbType.String);
                objDB.AddParameters(12, "UEDate", ObjItems.UEDate, DbType.DateTime);
                objDB.AddParameters(13, "flag", ObjItems.flag, DbType.String);

                objDB.AddParameters(14, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_PayWorkDay");
                RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

                if (RetSuccess != "1")
                {
                    SuccessFlag = false;
                }
            }
            objDB.Transaction.Commit();
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retStr = "Unable to save record ";
        }
        finally
        {
            if (SuccessFlag == true)
            {
                retStr = "Payment Mode Saved Successfully";
            }
            else
            {
                retStr = "Payment Not Saved";
            }
        }
        return retStr;
    }
    [OperationContract]
    public string insertEmpPMode(List<HRM.Fee.EmpPayMode> ObjEmpPMode)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retStr = string.Empty;
        string RetSuccess = string.Empty;
        Boolean SuccessFlag = true;

        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            foreach (HRM.Fee.EmpPayMode ObjItems in ObjEmpPMode)
            {
                //base.Vendor_Dtls_Save(ObjItems.flag, ObjItems.ID, ObjItems.PRID, ObjItems.Ctrl_Id, ObjItems.SupplierId, ObjItems.IndentID, ObjItems.UID, ObjItems.SessionID, ObjItems.InstID, ref RetSuccess);
                objDB.Command.Parameters.Clear();
                objDB.CreateParameters(10);
                objDB.AddParameters(0, "mId", ObjItems.mId, DbType.Int32);
                objDB.AddParameters(1, "deptId", ObjItems.deptId, DbType.Int32);
                objDB.AddParameters(2, "desigId", ObjItems.desigId, DbType.Int32);
                objDB.AddParameters(3, "empId", ObjItems.empId, DbType.Int32);
                objDB.AddParameters(4, "paymodeId", ObjItems.paymodeId, DbType.String);
                objDB.AddParameters(5, "flag", ObjItems.flag, DbType.String);
                objDB.AddParameters(6, "WED", ObjItems.WED, DbType.DateTime);
                objDB.AddParameters(7, "AccNo", ObjItems.AccNo, DbType.String);
                objDB.AddParameters(8, "typeAcc", ObjItems.typeAcc, DbType.String);
                objDB.AddParameters(9, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spEmpPayMode");
                RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

                if (RetSuccess != "1")
                {
                    SuccessFlag = false;
                }
            }
            objDB.Transaction.Commit();
            if (SuccessFlag == true)
            {
                retStr = "Record Saved";
            }
            else
            {
                retStr = "Record Not Saved";
            }

        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retStr = "Unable to save record ";
        }
        finally
        {
            objDB.Connection.Close();
        }
        return retStr;
    }
    [OperationContract]
    public string insertresignation(List<HRM.Fee.ResignDM> objResgn)
    {
          NewDAL.DBManager objDb = new DBManager();
        objDb.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDb.DBManager(DataAccessLayer.DataProvider.SqlServer, objDb.ConnectionString);
        string retstr = string.Empty;
        string Retsuccess = string.Empty;
        Boolean successFlag = true;
        try
        {
            objDb.Open();
            objDb.BeginTransaction();
            foreach (HRM.Fee.ResignDM objItems in objResgn)
            {
                objDb.Command.Parameters.Clear();
                objDb.CreateParameters(9);
                objDb.AddParameters(0, "Id", objItems.id, DbType.Int32);
                objDb.AddParameters(1, "EmpId", objItems.EmpId, DbType.Int32);
                objDb.AddParameters(2, "Reason", objItems.Reason, DbType.String);
                objDb.AddParameters(3, "wed", objItems.Wed, DbType.DateTime);
                objDb.AddParameters(4, "flag", objItems.flag, DbType.String);
                objDb.AddParameters(5, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                objDb.AddParameters(6, "deptId", objItems.deptId, DbType.Int32);
                objDb.AddParameters(7, "desigid", objItems.desigid, DbType.Int32);
                objDb.AddParameters(8, "cdate", DateTime.Today.Date, DbType.DateTime);
                objDb.ExecuteNonQueryHR(CommandType.StoredProcedure, "sp_MasterResign");
                Retsuccess = ((System.Data.SqlClient.SqlCommand)objDb.Command).Parameters["@Retsuccess"].Value.ToString();
                if (Retsuccess == "1")
                {
                    retstr = "Record saved.";
                }
                if (Retsuccess == "2")
                {
                    retstr = "Update successfuly.";
                }
                else if (Retsuccess == "3")
                {
                    retstr = "Delete successfully";
                }

                else if (Retsuccess == "4")
                {
                    retstr = "Record already exists.";
                }
                else if (Retsuccess == "5")
                {
                    retstr = "Record in  used.";
                }
            }
            objDb.Transaction.Commit();
            

            
        }
        catch (Exception ex)
        {
            objDb.Transaction.Rollback();
            retstr = "Unable to save record ";
           
        }
        finally
        {
            objDb.Connection.Close();
        }
        return retstr;

    }
    [OperationContract]
    public string insertProbation(List<HRM.Fee.ProbationDM> objProbtion)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer,objDB.ConnectionString);
        string retstr = string.Empty;
        string Retsuccess = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            foreach (HRM.Fee.ProbationDM objitems in objProbtion)
            {
                objDB.Command.Parameters.Clear();
                objDB.CreateParameters(7);
                objDB.AddParameters(0, "deptid", objitems.deptid, DbType.Int32);
                objDB.AddParameters(1, "desigid", objitems.desigid, DbType.Int32);
                objDB.AddParameters(2, "empid", objitems.empid, DbType.Int32);
                objDB.AddParameters(3, "fromdate", objitems.Fromdate, DbType.DateTime);
                objDB.AddParameters(4, "todate", objitems.todate, DbType.DateTime);
                objDB.AddParameters(5, "flag", objitems.flag, DbType.String);
                objDB.AddParameters(6, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "Sp_Master_EmpProbation");
                Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                if (Retsuccess == "1")
                {
                    retstr = "Record saved.";
                }
                if (Retsuccess == "2")
                {
                    retstr = "Update successfuly.";
                }
                else if (Retsuccess == "3")
                {
                    retstr = "Delete successfully";
                }
                else if (Retsuccess == "6")
                {
                    retstr = "Record can not be inserted,already exists.";
                }
                else if (Retsuccess == "5")
                {
                    retstr = "Record in  used.";
                }
            }
            objDB.Transaction.Commit();
        }
        catch (Exception ex)
        {
            
             objDB.Transaction.Rollback();
            retstr = "Unable to save record ";
        }
        return retstr;

    }

    [OperationContract]
    public List<HRM.Fee.EmpWage> FillEmpWage(HRM.Fee.EmpWage objEmpWage)
    {
        SqlCommand com = null;
        var Emp_Atd_Dtl = new List<Emp_Attend_Detatil>();

        var ListItem = new List<HRM.Fee.EmpWage>();
        //using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        //{
        //    try
        //    {
        //        com = new SqlCommand();
        //        SqlDataReader dr;
        //        cnx.Open();
        //        com.Connection = cnx;

        //        com.Parameters.AddWithValue("@flag", "S");
        //        com.Parameters.AddWithValue("@Id", Attend_Id);
        //        com.Parameters.AddWithValue("@Instid", Int32.Parse(Session["instID"].ToString()));

        //        com.CommandType = CommandType.StoredProcedure;
        //        com.CommandText = "[SUID_GetAllAttendance]";

        //        dr = com.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            var item = new Emp_Attend_Detatil();

        //            item.Id = dr["Id"].ToString();
        //            item.SrNo = dr["SrNo"].ToString();
        //            item.Attend_Date = Convert.ToDateTime(dr["Attend_Date"].ToString()).ToString("dd-MMM-yyyy");
        //            item.InTime = dr["InTime"].ToString();
        //            item.OutTime = dr["OutTime"].ToString();
        //            item.PresentStatus = dr["AttendStatus"].ToString();
        //            item.Worked_Hrs = dr["Worked_Hrs"].ToString();
        //            item.Remark = dr["Remark"].ToString();

        //            Emp_Atd_Dtl.Add(item);

        //        } dr.Close(); dr.Dispose();


        //    }
        //    catch { }
        //    finally { com.Parameters.Clear(); }

        //    //return Emp_Atd_Dtl;
        //    return ListItem;

        //}
        //base.Get_Units(ObjUnitDDL.InstID, ObjUnitDDL.Unit_Id, ref dt);
        //foreach (DataRow dr in dt.Rows)
        //{
        //    var Item = new InventoryService.PurchaseReqMember.PurReqData();
        //    Item.UOM_name = dr["UOMShort"].ToString();
        //    Item.Unit_Id = Int32.Parse(dr["UOMID"].ToString());
        //    ListItem.Add(Item);
        //}
        return ListItem;
    }

    [OperationContract]
    public string insertChildDesig(HRM.Fee.DesigChild chDesig)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string RetSuccess = string.Empty;

            objDB.CreateParameters(8);
            //objDB.AddParameters(0, "Id", chDesig.ID, DbType.Int32);
            objDB.AddParameters(0, "deptID", chDesig.deptID, DbType.String);
            objDB.AddParameters(1, "desigID", chDesig.desigID, DbType.String);
            objDB.AddParameters(2, "InstituteID", chDesig.InstituteID, DbType.Int32);
            objDB.AddParameters(3, "SessionID", chDesig.SessionID, DbType.String);
            objDB.AddParameters(4, "UserID", chDesig.UserID, DbType.String);
            objDB.AddParameters(5, "UEDate", chDesig.UEDate, DbType.Date);
            objDB.AddParameters(6, "flag", chDesig.Flag, DbType.String);
            objDB.AddParameters(7, "RetSuccess", 0, DbType.String, ParameterDirection.Output);

            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Child_Desig");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            //objDB.Transaction.Commit();
            if (RetSuccess == "0")
            {
                if (chDesig.Flag == "N")
                {
                    objDB.Transaction.Rollback();
                    retv = "Record not saved.";
                }
                if (chDesig.Flag == "D")
                {
                    objDB.Transaction.Rollback();
                    retv = "Can not Update.";
                }
                //objFunc.MsgBox("Record  saved.", this);
            }
            else if (RetSuccess == "1")
            {
                if (chDesig.Flag == "N")
                {
                    objDB.Transaction.Commit();
                    retv = "Record saved.";
                }
                if (chDesig.Flag == "D")
                {
                    objDB.Transaction.Commit();
                    retv = "Record Update.";
                }
                //objFunc.MsgBox("Record saved successfully.", this);
            }
            else if (RetSuccess == "2")
            {
                objDB.Transaction.Rollback();
                retv = "Record already exist.";
            }
            else if (RetSuccess == "3")
            {
                if (chDesig.Flag == "D")
                {
                    objDB.Transaction.Rollback();
                    retv = "Record in Use.";
                }                
            }
            else if (RetSuccess == "4")
            {
                if (chDesig.Flag == "D")
                {
                    objDB.Transaction.Rollback();
                    retv = "Record not exists.";
                }
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record " ;
        }
        return retv;
    }
    [OperationContract]
    public string insertChildJob(HRM.Fee.JobChild chJob)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string RetSuccess = string.Empty;

            objDB.CreateParameters(8);
            //objDB.AddParameters(0, "Id", chJob.ID, DbType.Int32);
            objDB.AddParameters(0, "desigID", chJob.desigID, DbType.String);
            objDB.AddParameters(1, "jobID", chJob.jobID, DbType.String);
            objDB.AddParameters(2, "InstituteID", chJob.InstituteID, DbType.Int32);
            objDB.AddParameters(3, "SessionID", chJob.SessionID, DbType.String);
            objDB.AddParameters(4, "UserID", chJob.UserID, DbType.String);
            objDB.AddParameters(5, "UEDate", chJob.UEDate, DbType.Date);
            objDB.AddParameters(6, "flag", chJob.Flag, DbType.String);
            objDB.AddParameters(7, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
            
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Child_Job");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            objDB.Transaction.Commit();
            if (RetSuccess == "0")
            {
                if (chJob.Flag == "N")
                {
                    retv = "Record not saved.";
                }
                if (chJob.Flag == "D")
                {
                    retv = "Can not Update.";
                }
                //objFunc.MsgBox("Record  saved.", this);
            }
            if (RetSuccess == "2")
            {
                if (chJob.Flag == "N")
                {
                    retv = "Record already exists.";
                }
                if (chJob.Flag == "D")
                {
                    retv = "Can not Update.";
                }
                //objFunc.MsgBox("Record  saved.", this);
            }
            else if (RetSuccess == "1")
            {
                if (chJob.Flag == "N")
                {
                    retv = "Record saved.";
                }
                if (chJob.Flag == "D")
                {
                    retv = "Record Updated.";
                }
                //objFunc.MsgBox("Record saved successfully.", this);
            }
            else if (RetSuccess == "3")
            {
                if (chJob.Flag == "D")
                {
                    retv = "Record in Use.";
                }
                //if (chJob.Flag == "D")
                //{
                //    retv = "Record Deleted.";
                //}
                //objFunc.MsgBox("Record saved successfully.", this);
            }
            else if (RetSuccess == "4")
            {
                if (chJob.Flag == "D")
                {
                    retv = "Record not exists.";
                }
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
    public string insertCountry(HRM.Fee.CountryDM objCoun)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string RetSuccess = string.Empty;
            objDB.CreateParameters(7);
            //objDB.AddParameters(0, "Id", chJob.ID, DbType.Int32);
            objDB.AddParameters(0, "CountryId", objCoun.CountryId, DbType.Int32);
            objDB.AddParameters(1, "CountryName", objCoun.CountryName, DbType.String);
            // objDB.AddParameters(2, "InstituteID", objCoun.InstituteID, DbType.Int32);
            objDB.AddParameters(2, "SessionID", objCoun.SessionID, DbType.String);
            objDB.AddParameters(3, "UserID", objCoun.UserID, DbType.String);
            objDB.AddParameters(4, "UEDate", objCoun.UEDate, DbType.Date);
            objDB.AddParameters(5, "flag", objCoun.Flag, DbType.String);
            objDB.AddParameters(6, "RetSuccess", 0, DbType.String, ParameterDirection.Output);

            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spCountry");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            objDB.Transaction.Commit();
            if (RetSuccess == "1")
            {

                retv = "Record saved.";
            }


            if (RetSuccess == "2")
            {


                retv = "Update successfuly.";


            }
            else if (RetSuccess == "3")
            {
                retv = "Delete successfully";
            }

            else if (RetSuccess == "4")
            {

                retv = "Record already exists.";

            }
            else if (RetSuccess == "5")
            {

                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record ";
        }
        return retv;
    }
    [OperationContract]
    public string insertstate(HRM.Fee.StateDM objstat)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string RetSuccess = string.Empty;
            objDB.CreateParameters(8);
            //objDB.AddParameters(0, "Id", chJob.ID, DbType.Int32);
            objDB.AddParameters(0, "CountryId", objstat.CountryId, DbType.Int32);
            objDB.AddParameters(1, "StateId", objstat.StateId, DbType.Int32);
            objDB.AddParameters(2, "StateName", objstat.StateName, DbType.String);
            objDB.AddParameters(3, "SessionID", objstat.SessionID, DbType.String);
            objDB.AddParameters(4, "UserID", objstat.UserID, DbType.String);
            objDB.AddParameters(5, "UEDate", objstat.UEDate, DbType.Date);
            objDB.AddParameters(6, "flag", objstat.Flag, DbType.String);
            objDB.AddParameters(7, "RetSuccess", 0, DbType.String, ParameterDirection.Output);

            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spState");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            objDB.Transaction.Commit();
            if (RetSuccess == "1")
            {

                retv = "Record saved.";
            }


            if (RetSuccess == "2")
            {


                retv = "Update successfuly.";


            }
            else if (RetSuccess == "3")
            {
                retv = "Delete successfully";
            }

            else if (RetSuccess == "4")
            {

                retv = "Record already exists.";

            }
            else if (RetSuccess == "5")
            {

                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-";
        }
        return retv;


    }
    [OperationContract]
    public string insertcity(HRM.Fee.CityDM objCty)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string RetSuccess = string.Empty;
            objDB.CreateParameters(8);
            //objDB.AddParameters(0, "Id", chJob.ID, DbType.Int32);
            objDB.AddParameters(0, "StateId", objCty.StateID, DbType.Int32);
            objDB.AddParameters(1, "CityId", objCty.CityId, DbType.Int32);
            objDB.AddParameters(2, "CityName", objCty.CityName, DbType.String);
            objDB.AddParameters(3, "SessionID", objCty.SessionID, DbType.String);
            objDB.AddParameters(4, "UserID", objCty.UserID, DbType.String);
            objDB.AddParameters(5, "UEDate", objCty.UEDate, DbType.Date);
            objDB.AddParameters(6, "flag", objCty.Flag, DbType.String);
            objDB.AddParameters(7, "RetSuccess", 0, DbType.String, ParameterDirection.Output);

            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spCity");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            objDB.Transaction.Commit();
            if (RetSuccess == "1")
            {

                retv = "Record saved.";
            }


            if (RetSuccess == "2")
            {

                retv = "Update successfuly.";


            }
            else if (RetSuccess == "3")
            {
                retv = "Delete successfully";
            }

            else if (RetSuccess == "4")
            {

                retv = "Record already exists.";

            }
            else if (RetSuccess == "5")
            {

                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-";
        }
        return retv;

    }
    [OperationContract]
    public string insertEprofile(HRM.Fee.EprofDM objProf)
    {
          NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        string retv = string.Empty;
        try
        {
            objDB.Open();
            objDB.BeginTransaction();
            string RetSuccess = string.Empty;
            objDB.CreateParameters(8);
            // objDB.AddParameters(0, "StateId", objCty.StateID, DbType.Int32);
            objDB.AddParameters(0, "ProfId", objProf.ProfId, DbType.Int32);
            objDB.AddParameters(1, "ProfName", objProf.ProfName, DbType.String);
            objDB.AddParameters(2, "InstituteID", objProf.InstituteID, DbType.Int32);
            objDB.AddParameters(3, "SessionID", objProf.SessionID, DbType.String);
            objDB.AddParameters(4, "UserID", objProf.UserID, DbType.String);
            objDB.AddParameters(5, "UEDate", objProf.UEDate, DbType.Date);
            objDB.AddParameters(6, "flag", objProf.Flag, DbType.String);
            objDB.AddParameters(7, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Educ_Prof");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            objDB.Transaction.Commit();
            if (RetSuccess == "1")
            {

                retv = "Record saved.";
            }


            if (RetSuccess == "2")
            {

                retv = "Update successfuly.";


            }
            else if (RetSuccess == "3")
            {
                retv = "Delete successfully";
            }

            else if (RetSuccess == "4")
            {

                retv = "Record already exists.";

            }
            else if (RetSuccess == "5")
            {

                retv = "Record in  used.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record.";
        }
        return retv;

    }
    [OperationContract]
    public string insertoffday(HRM.Fee.offdayDM objofday)
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
            objDB.CreateParameters(12);
            objDB.AddParameters(0, "offid", objofday.offid, DbType.Int32);
            objDB.AddParameters(1, "title", objofday.title, DbType.String);
            objDB.AddParameters(2, "date", objofday.date, DbType.DateTime);
            objDB.AddParameters(3, "month", objofday.month, DbType.String);
            objDB.AddParameters(4, "year", objofday.year, DbType.String);
            objDB.AddParameters(5, "InstituteID", objofday.InstituteID, DbType.Int32);
            objDB.AddParameters(6, "SessionID", objofday.SessionID, DbType.String);
            objDB.AddParameters(7, "UserID", objofday.UserID, DbType.String);
            objDB.AddParameters(8, "UEDate", objofday.UEDate, DbType.DateTime);
            objDB.AddParameters(9, "flag", objofday.flag, DbType.String);
            objDB.AddParameters(10, "id", objofday.id, DbType.Int32);
            objDB.AddParameters(11, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_HR_AddOffDays");
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
            retv = "Unable to save record.";
        }
        return retv;

    }

    [OperationContract]
    public string insertdepartment(HRM.Fee.DepartmentDM objDept)
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
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "DepartmentID", objDept.DepartmentID, DbType.Int32);
            objDB.AddParameters(1, "DepartmentName", objDept.DepartmentName, DbType.String);
            objDB.AddParameters(2, "ShortName", objDept.ShortName, DbType.String);
            objDB.AddParameters(3, "InstituteID", objDept.InstituteID, DbType.Int32);
            objDB.AddParameters(4, "SessionID", objDept.SessionID, DbType.String);
            objDB.AddParameters(5, "UName", objDept.UName, DbType.String);
            objDB.AddParameters(6, "UEntDt", objDept.UEntDt, DbType.DateTime);
            objDB.AddParameters(7, "validFrom", objDept.validFrom, DbType.DateTime);
            objDB.AddParameters(8, "validTo", objDept.validTo, DbType.DateTime);
            objDB.AddParameters(9, "flag", objDept.flag, DbType.String);
            objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Department");
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
            else if (Retsuccess == "0")
            {
                retv = "record can not be updated";
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
    public string insertDesignation(HRM.Fee.DesigntionDM objdesg)
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
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "DesigId", objdesg.DesigId, DbType.Int32);
            objDB.AddParameters(1, "Designation", objdesg.Designation, DbType.String);
            objDB.AddParameters(2, "ShortName", objdesg.ShortName, DbType.String);
            objDB.AddParameters(3, "InstituteID", objdesg.InstituteID, DbType.Int32);
            objDB.AddParameters(4, "SessionID", objdesg.SessionID, DbType.String);
            objDB.AddParameters(5, "UserID", objdesg.UserID, DbType.String);
            //objDB.AddParameters(6, "UserID", objdesg.UserID, DbType.String);
            objDB.AddParameters(6, "UEDate", objdesg.UEDate, DbType.DateTime);
            objDB.AddParameters(7, "validFrom", objdesg.validFrom, DbType.DateTime);
            objDB.AddParameters(8, "validTo", objdesg.validTo, DbType.DateTime);
            objDB.AddParameters(9, "flag", objdesg.flag, DbType.String);
            objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Desig");
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
            else if (Retsuccess == "0")
            {
                retv = "Record can not be updated";
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
    public string insertEmpJob(HRM.Fee.EmpNatureDM objEnat)
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
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "natureID", objEnat.natureID, DbType.Int32);
            objDB.AddParameters(1, "nature", objEnat.nature, DbType.String);
            objDB.AddParameters(2, "InstituteID", objEnat.InstituteID, DbType.Int32);
            objDB.AddParameters(3, "SessionID", objEnat.SessionID, DbType.String);
            objDB.AddParameters(4, "UserID", objEnat.UserID, DbType.String);
            objDB.AddParameters(5, "UEDate", objEnat.UEDate, DbType.DateTime);
            objDB.AddParameters(6, "validFrom", objEnat.validFrom, DbType.DateTime);
            objDB.AddParameters(7, "validTo", objEnat.validTo, DbType.DateTime);
            objDB.AddParameters(8, "flag", objEnat.flag, DbType.String);
            objDB.AddParameters(9, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Master_Emp_Nature]");
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
            else if (Retsuccess == "0")
            {
                retv = "Record can not be updated";
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
    public string insertexpertise(HRM.Fee.ExpertisDM objExprt)
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
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "id", objExprt.id, DbType.Int32);
            objDB.AddParameters(1, "Expertise", objExprt.Expertise, DbType.String);
            objDB.AddParameters(2, "wed", objExprt.wed, DbType.DateTime);
            objDB.AddParameters(3, "InstituteID", objExprt.InstituteID, DbType.Int32);
            objDB.AddParameters(4, "SessionID", objExprt.SessionID, DbType.String);
            objDB.AddParameters(5, "UserID", objExprt.UserID, DbType.String);
            objDB.AddParameters(6, "UEDate", objExprt.UEDate, DbType.DateTime);
            objDB.AddParameters(7, "flag", objExprt.flag, DbType.String);
            objDB.AddParameters(8, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spExpertise");
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
            else if (Retsuccess == "0")
            {
                retv = "Record can not be updated";
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
    public string insertservice(HRM.Fee.ServiceDM objService)
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
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "id", objService.id, DbType.Int32);
            objDB.AddParameters(1, "ServiceName", objService.ServiceName, DbType.String);
            objDB.AddParameters(2, "ServShName", objService.ServShName, DbType.String);
            objDB.AddParameters(3, "InstituteID", objService.InstituteID, DbType.Int32);
            objDB.AddParameters(4, "SessionID", objService.SessionID, DbType.String);
            objDB.AddParameters(5, "UserID", objService.UserID, DbType.String);
            objDB.AddParameters(6, "UEDate", objService.UEDate, DbType.DateTime);
            objDB.AddParameters(7, "flag", objService.flag, DbType.String);
            objDB.AddParameters(8, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spService");
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
            else if (Retsuccess == "0")
            {
                retv = "Record can not be updated";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
        }
        return retv; 
    }

    public FeeSVC() //Map_Dept_SVC()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
