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
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using   NewDAL;
using System.Collections.Generic;


/// <summary>
/// Summary description for PayrollSvc
/// </summary>
[ServiceContract(Namespace = "", CallbackContract = typeof(IPayrollSvc), ConfigurationName = "Service")]
public interface IPayrollSvc
{
    [OperationContract(IsOneWay = false)]
    string insertWType(HRM.PayRollDM.WageType wType);

    [OperationContract(IsOneWay = false)]
    string insertWMap(HRM.PayRollDM.WageMap wMap);

    [OperationContract(IsOneWay = false)]
    string insertsession(HRM.PayRollDM.Sesssion objSeson);

    [OperationContract(IsOneWay=false)]
    string insertWorkDay(HRM.PayRollDM.WorkDay objWDay);
}
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
public class PayrollSvc : IPayrollSvc
{
    public string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }

    [OperationContract]
    public string insertWType(HRM.PayRollDM.WageType wType)
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

            objDB.CreateParameters(13);
            //objDB.AddParameters(0, "Id", chDesig.ID, DbType.Int32);
            objDB.AddParameters(0, "id", wType.id, DbType.Int32);
            objDB.AddParameters(1, "Allow_Deduct", wType.Allow_Deduct, DbType.String);
            objDB.AddParameters(2, "Wage_Type", wType.Wage_Type, DbType.String);
            objDB.AddParameters(3, "Type_", wType.Type_, DbType.String);
            objDB.AddParameters(4, "Taxable", wType.Taxable, DbType.String);
            objDB.AddParameters(5, "Prop", wType.Prop, DbType.String);
            objDB.AddParameters(6, "InstituteID", wType.InstituteID, DbType.Int32);
            objDB.AddParameters(7, "SessionID", wType.SessionID, DbType.String);
            objDB.AddParameters(8, "UserID", wType.UserID, DbType.String);
            objDB.AddParameters(9, "UEDate", wType.UEDate, DbType.Date);
            objDB.AddParameters(10, "flag", wType.Flag, DbType.String);
            objDB.AddParameters(11, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.AddParameters(12, "wed", wType.wed, DbType.Date);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "sp_Payroll_WageType");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            objDB.Transaction.Commit();

            if (RetSuccess == "1")
            {
                retv = "Wage Type Saved Successfully.";
            }
            else if (RetSuccess == "2")
            {
                retv = "Wage Type Updated Successfully.";
            }
            else if (RetSuccess == "3")
            {
                retv = "Wage Type Deleted Successfully.";
            }
            else if (RetSuccess == "4")
            {
                retv = "Wage Type Already Exists.";
            }
            else if (RetSuccess == "5")
            {
                retv = "Wage Type in Use.can not be update.";
            }
            else if (RetSuccess == "6")
            {
                retv = "Wage Type in Use.can not be delete.";
            }

            //if (RetSuccess == "0")
            //{
            //    if (wType.Flag == "N")
            //    {
            //        //objDB.Transaction.Rollback();
            //        retv = "Record not saved.";
            //    }
            //    if (wType.Flag == "D" )
            //    {
            //        //objDB.Transaction.Rollback();
            //        retv = "This Wage Type Can not be Delete.";
            //    }
            //    if (wType.Flag == "U")
            //    {
            //        retv = "This Wage Type Can not be Update";
            //    }
            //    //objFunc.MsgBox("Record  saved.", this);
            //}
            //else if (RetSuccess == "2")
            //{
            //    if (wType.Flag == "U")
            //    {
            //        //objDB.Transaction.Commit();
            //        retv = "Record Update.";
            //    }
            //}
            //else if (RetSuccess == "1")
            //{
            //    //if (wType.Flag == "N")
            //    if (wType.Flag == "N")
            //    {
            //        //objDB.Transaction.Commit();
            //        retv = "Record saved.";

            //    }
            //    // if (wType.Flag == "D")
            //    if (wType.Flag == "D")
            //    {
            //        //objDB.Transaction.Commit();
            //        retv = "Record Deleted.";
            //    }
            //    if (wType.Flag == "U")
            //    {
            //        //objDB.Transaction.Commit();
            //        retv = "Record Update.";
            //    }
            //    //objFunc.MsgBox("Record saved successfully.", this);
            //}
         
            //else if (RetSuccess == "3")
            //{
            //    // if (wType.Flag == "D")
            //    if (wType.Flag == "D")
            //    {
            //        retv = "Record Deleted.";
            //    }
            //}
          
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            //retv = "Unable to save record " + ex.Message.ToString();
        }
        return retv;
    }

    [OperationContract]
    public string insertWMap(HRM.PayRollDM.WageMap wMap)
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
            objDB.Command.Parameters.Clear();
            objDB.CreateParameters(10);
            //objDB.AddParameters(0, "id", wMap.id, DbType.Int32);
            objDB.AddParameters(0, "gradeID", wMap.gradeID, DbType.String);
            objDB.AddParameters(1, "wageID", wMap.wageID, DbType.String);
            objDB.AddParameters(2, "wageValue", wMap.wageValue, DbType.String);
            objDB.AddParameters(3, "InstituteID", wMap.InstituteID, DbType.Int32);
            objDB.AddParameters(4, "SessionID", wMap.SessionID, DbType.String);
            objDB.AddParameters(5, "UserID", wMap.UserID, DbType.String);
            objDB.AddParameters(6, "UEDate", wMap.UEDate, DbType.Date);
            objDB.AddParameters(7, "flag", wMap.Flag, DbType.String);
            objDB.AddParameters(8, "wedate", wMap.wedate, DbType.Date);
            objDB.AddParameters(9, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_PayWageMap");
            RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

            //objDB.Transaction.Commit();
            //if (RetSuccess == "0")
            //{
            //    if (wMap.Flag == "N")
            //    {
            //        objDB.Transaction.Rollback();
            //        retv = "Record not saved.";
            //    }
            //    if (wMap.Flag == "D")
            //    {
            //        objDB.Transaction.Rollback();
            //        retv = "Can not Delete.";
            //    }
            //    //objFunc.MsgBox("Record  saved.", this);
            //}
            //else if (RetSuccess == "2")
            //{
            //    if (wMap.Flag == "U")
            //    {
            //        objDB.Transaction.Commit();
            //        retv = "Record Update.";
            //    }
            //}
            //else if (RetSuccess == "1")
            //{                
            //    if (wMap.Flag == "N")
            //    {
            //        objDB.Transaction.Commit();
            //        retv = "Record saved.";
            //    }                
            //}
            //else if (RetSuccess == "2")
            //{
            //    objDB.Transaction.Commit();
            //    retv = "Record Updated.";                
            //}
            //else if (RetSuccess == "3")
            //{
            //    objDB.Transaction.Commit();
            //    retv = "Record Deleted.";
            //}      

           

            if (RetSuccess == "1")
            {
                    objDB.Transaction.Commit();
                    retv = "Wage Mapping Saved Successfully.";
           }
            else if (RetSuccess == "2")
            {
                objDB.Transaction.Commit();
                retv = "Wage Mapping Updated Successfully.";
            }
            else if (RetSuccess == "3")
            {
                objDB.Transaction.Commit();
                retv = "Wage Mapping Deleted Successfully.";
            }
            else if (RetSuccess == "4")
            {
                objDB.Transaction.Commit();
                retv = "Wage Mapping Saved Successfully.";
            }
            else if (RetSuccess == "5")
            {
                objDB.Transaction.Commit();
                retv = "Wage Mapping can not be update.";
            }


        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
          
        }
        return retv;

    }

    [OperationContract]
    public string insertWorkDay(HRM.PayRollDM.WorkDay objWDay)
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
            objDB.CreateParameters(16);
            objDB.AddParameters(0, "id", objWDay.id, DbType.Int32);
            //objDB.AddParameters(1, "mmonth", objWDay.mmonth, DbType.String);
            objDB.AddParameters(1, "yearID", objWDay.yearID, DbType.Int32);
            objDB.AddParameters(2, "workDays", objWDay.workDays, DbType.String);
            objDB.AddParameters(3, "InstituteID", objWDay.InstituteID, DbType.Int32);
            objDB.AddParameters(4, "workdayid", objWDay.workdayid, DbType.Int32);
            objDB.AddParameters(5, "frmdate", objWDay.frmdate, DbType.DateTime);
            objDB.AddParameters(6, "todate", objWDay.todate, DbType.DateTime);
            objDB.AddParameters(7, "cdate", objWDay.cdate, DbType.DateTime);
            objDB.AddParameters(8, "edate", objWDay.edate, DbType.Int32);
            objDB.AddParameters(9, "mnth", objWDay.mnth, DbType.Int32);
            objDB.AddParameters(10, "yr", objWDay.yr, DbType.Int32);
            objDB.AddParameters(11, "flag", objWDay.flag, DbType.String);
            objDB.AddParameters(12, "deptID", objWDay.deptID, DbType.Int32);
            objDB.AddParameters(13, "UserID", objWDay.UserID, DbType.String);
            objDB.AddParameters(14, "UEDate", objWDay.UEDate, DbType.DateTime);
            objDB.AddParameters(15, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_PayWorkDay");
            Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
            objDB.Transaction.Commit();
            if (Retsuccess == "1")
            {
                retv = "Record saved.";
            }
            else if (Retsuccess == "2")
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
    public List<HRM.PayRollDM.WorkDay> FillWorkDay(Int32 InstituteID)
    {
        SqlCommand com = null;
        DataTable dt = new DataTable();
        var listitem = new List<HRM.PayRollDM.WorkDay>();
        SqlConnection cnx = new SqlConnection(ReturnConString());
        com = new SqlCommand();
        SqlDataReader dr;
        cnx.Open();
        com.Connection = cnx;
        com.Parameters.AddWithValue("@flag", "S");
        com.Parameters.AddWithValue("@InstituteID", InstituteID);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_PayWorkDay";
        dr = com.ExecuteReader();
        while (dr.Read())
        {
            // var item = HRM.PayRoll.WorkingDay();

            var item = new HRM.PayRollDM.WorkDay();
            item.id = Int32.Parse(dr["id"].ToString());
            item.yearID = Int32.Parse(dr["yearID"].ToString());
            item.workDays = dr["workDays"].ToString();
            item.InstituteID = Int32.Parse(dr["InstituteID"].ToString());
            item.workdayid = Int32.Parse(dr["workdayID"].ToString());
            item.frmdate = Convert.ToDateTime(dr["frmdate"]);
            item.todate = Convert.ToDateTime(dr["todate"]);
            item.cdate = Convert.ToDateTime(dr["cdate"]);
            item.edate = Int32.Parse(dr["edate"].ToString());
            item.mnth = Int32.Parse(dr["mnth"].ToString());
            item.yr = Int32.Parse(dr["yr"].ToString());
            item.deptID = Int32.Parse(dr["deptID"].ToString());
            item.SessionF = dr["SessionF"].ToString();
            listitem.Add(item);

        }
        dr.Close();
        dr.Dispose();
        return listitem;

    }

    [OperationBehavior]
    public string insertsession(HRM.PayRollDM.Sesssion objSeson)
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
            objDB.AddParameters(0, "Id", objSeson.Id, DbType.Int32);
            objDB.AddParameters(1, "SessionF", objSeson.SessionF, DbType.String);
            objDB.AddParameters(2, "StartDate", objSeson.StartDate, DbType.DateTime);
            objDB.AddParameters(3, "EndDate", objSeson.EndDate, DbType.DateTime);
            objDB.AddParameters(4, "InstituteID", objSeson.InstituteID, DbType.Int32);
            objDB.AddParameters(5, "Active", objSeson.Active, DbType.String);
            objDB.AddParameters(6, "UserID", objSeson.UserID, DbType.String);
            objDB.AddParameters(7, "UEDate", objSeson.UEDate, DbType.DateTime);
            objDB.AddParameters(8, "SessionID", objSeson.SessionID, DbType.String);
            objDB.AddParameters(9, "flag", objSeson.flag, DbType.String);
            objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
            objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Payroll_Session");
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
    
    public PayrollSvc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   
}
