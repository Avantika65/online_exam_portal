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
using NewDAL;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
/// <summary>
/// Summary description for Budget
/// </summary>
public class Budget : Invent_Data
{
    //protected string ReturnConString()
    //{
    //    return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //}
	public Budget()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region Budget Master
    //-----------------------------------------Save Budget---------------------------------------
    public void Budget_Save(String flag, Int32 InstId, Int32 Budget_Id, String Budget_name, Int32 Ledger_Id, DateTime Applied_date, Decimal Applied_Amt, String Applied_Doc_Name, String Applied_Doc_Id, String Budget_For, Int32 Budget_For_Id, String Session, Boolean IsScheduled, Int32 User_id, ref string RetSuccess)
    {
        try
        {
            BudgetSave_(flag, InstId, Budget_Id, Budget_name, Ledger_Id, Applied_date, Applied_Amt, Applied_Doc_Name, Applied_Doc_Id, Budget_For, Budget_For_Id, Session, IsScheduled, User_id, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    public void Budget_Delete(string flag, int InstId, int Budget_Id, ref string RetSuccess)
    {
        try
        {
            BudgetDelete_(flag, InstId, Budget_Id, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    #endregion

    #region Budget Allocation & sanction
    //----------------------------------Budget Allocation-----------------------------------

    public void Budget_Allocation(String flag, Int32 InstId, Int32 Budget_Id, Int32 Ledger_Id, Decimal Allocated_Amt, Int32 Budget_For_Id, ref string RetSuccess)
    {
        try
        {
            BudgetAllocaSave_(flag, InstId, Budget_Id, Ledger_Id, Allocated_Amt, Budget_For_Id, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    //----------------------------------Budget Sanction Process-----------------------------------

    public void Budget_Sanction(String flag, Int32 InstId, Int32 Budget_Id, Int32 Ledger_Id, String Sanction_Number, DateTime Sanction_Date, Decimal Sanction_Amt, Int32 Fund_Source_Id, String Sanctioned_Doc_Name, String Sanctioned_Doc_Id, ref string RetSuccess)
    {
        try
        {
            BudgetSanctionSave_(flag, InstId, Budget_Id, Ledger_Id, Sanction_Number, Sanction_Date, Sanction_Amt, Fund_Source_Id, Sanctioned_Doc_Name, Sanctioned_Doc_Id, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    #endregion

    #region Budget Release

    //-----------------------------------------Save Budget Release Process---------------------------------------
    public void Budget_Release(String flag, Int32 InstId, Int32 Release_Id, Int32 Budget_Id, String Doc_No, DateTime Doc_Date, Decimal Release_Amt, String Release_Mode, String Cheq_DD_No, String Cheq_DD_Date, String Bank, String Deposited_In,Int32 UserId, ref string RetSuccess)
    {
        try
        {
            BudgetReleaseSave_(flag, InstId, Release_Id, Budget_Id, Doc_No, Doc_Date, Release_Amt, Release_Mode, Cheq_DD_No, Cheq_DD_Date, Bank, Deposited_In, UserId, ref RetSuccess);
        }
        catch (Exception)
        { RetSuccess = "0"; }
    }
    #endregion

    #region Departmentwise Budget Release

    //-----------------------------------------Save Budget Release Process---------------------------------------
    public void DeptBudget_Release(String flag, Int32 InstId, Int32 Id, Int32 DeptId, String Doc_No,  Decimal Release_Amt,DateTime Release_Date, String Release_Mode, String Cheq_DD_No, String Cheq_DD_Date, String Bank, String Deposited_In, Int32 UserId, ref string RetSuccess)
    {
        try
        {
            DeptBudgetReleaseSave_(flag, InstId, Id, DeptId, Doc_No, Release_Amt, Release_Date, Release_Mode, Cheq_DD_No, Cheq_DD_Date, Bank, Deposited_In, UserId, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void DeptBudget_Delete(int InstId, int Id, ref string RetSuccess)
    {
        try
        {
            DeptBudgetDelete_(InstId, Id, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    #endregion

    #region Budget Allocation Select Process
    //------------------Budget Allocation Select Process--------------------------
    public void BdgtAllc_Select(String flag, Int32 InstID, Int32 Budget_Id, ref List<DataMember.Budget> BdgtListItms,DBManager ObjDb)
    {
        BdgtAllc_Select_(flag, InstID, Budget_Id, ref ObjDb);
        if (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.Budget();
            Item.Applied_Amt = Decimal.Parse(ObjDb.DataReader["Applied_Amt"].ToString());
            Item.Allocated_Amt = Decimal.Parse(ObjDb.DataReader["Allocated_Amt"].ToString());
            Item.Budget_For = ObjDb.DataReader["Budget_For"].ToString();
            Item.Budget_For_Id = Int32.Parse(ObjDb.DataReader["Budget_For_Id"].ToString());
            Item.Ledger_Id = Int32.Parse(ObjDb.DataReader["Ledger_Id"].ToString());
            BdgtListItms.Add(Item);
        }
        ObjDb.DataReader.Close();
        ObjDb.Command.Parameters.Clear();       
    }
    #endregion
    #region Budget Allocation Select Process
    //------------------Budget Master Select Process--------------------------
    public void BdgtMst_FillGrid(String flag, Int32 InstID, Int32 Budget_Id, ref List<DataMember.Budget> BdgtListItms, DBManager ObjDb)
    {
        BdgtAllc_Select_(flag, InstID, Budget_Id, ref ObjDb);
        while (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.Budget();
            Item.Budget_Id = Int32.Parse(ObjDb.DataReader["Budget_Id"].ToString());
            Item.Budget_name = ObjDb.DataReader["Budget_name"].ToString();
            Item.Applied_date = DateTime.Parse(ObjDb.DataReader["Applied_date"].ToString());
            Item.Applied_Amt = Decimal.Parse(ObjDb.DataReader["Applied_Amt"].ToString());
            Item.FileName = ObjDb.DataReader["FileName"].ToString();
            Item.Applied_Doc_Name = ObjDb.DataReader["Applied_Doc_Name"].ToString();
            Item.FType = ObjDb.DataReader["FType"].ToString();
            BdgtListItms.Add(Item);
        }
        ObjDb.DataReader.Close();
        ObjDb.Command.Parameters.Clear();
    }
    public void BdgtMst_Select(String flag, Int32 InstID, Int32 Budget_Id, ref List<DataMember.Budget> BdgtListItms, DBManager ObjDb)
    {
        BdgtAllc_Select_(flag, InstID, Budget_Id, ref ObjDb);
        if (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.Budget();
            Item.Budget_Id = Int32.Parse(ObjDb.DataReader["Budget_Id"].ToString());
            Item.Budget_name = ObjDb.DataReader["Budget_name"].ToString();
            Item.Applied_date = DateTime.Parse(ObjDb.DataReader["Applied_date"].ToString());
            Item.Applied_Amt = Decimal.Parse(ObjDb.DataReader["Applied_Amt"].ToString());
            Item.Budget_For = ObjDb.DataReader["Budget_For"].ToString();
            Item.Ledger_Id = Int32.Parse(ObjDb.DataReader["Ledger_Id"].ToString());
            Item.FileName = ObjDb.DataReader["Applied_Doc_Id"].ToString();
            Item.Applied_Doc_Name = ObjDb.DataReader["Applied_Doc_Name"].ToString();
            BdgtListItms.Add(Item);
        }
        ObjDb.DataReader.Close();
        ObjDb.Command.Parameters.Clear();
    }
    #endregion
    #region Budget Sanction Select Process
    //-----------------Select data on Budget DDL selection on Budget Sanction form
    public void BdgtSanc_SelectB(String flag, Int32 InstID, Int32 Budget_Id, ref List<DataMember.Budget> BdgtListItms, DBManager ObjDb)
    {
        BdgtAllc_Select_(flag, InstID, Budget_Id, ref ObjDb);
        if (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.Budget();
            Item.Applied_Amt = Decimal.Parse(ObjDb.DataReader["Applied_Amt"].ToString());
            Item.Allocated_Amt = Decimal.Parse(ObjDb.DataReader["Allocated_Amt"].ToString());
            Item.Ledger_Id = Int32.Parse(ObjDb.DataReader["Ledger_Id"].ToString());
            BdgtListItms.Add(Item);
        }
        ObjDb.DataReader.Close();
        ObjDb.Command.Parameters.Clear();
    }
    //------------------Budget Sanction Fill Grid--------------------------
    public void BdgtSanc_FillGrid(String flag, Int32 InstID, Int32 Budget_Id, ref List<DataMember.Budget> BdgtListItms, DBManager ObjDb)
    {
        BdgtAllc_Select_(flag, InstID, Budget_Id, ref ObjDb);
        while (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.Budget();
            Item.Budget_Id = Int32.Parse(ObjDb.DataReader["Budget_Id"].ToString());
            Item.Budget_name = ObjDb.DataReader["Budget_name"].ToString();
            Item.Sanction_Date = DateTime.Parse(ObjDb.DataReader["Sanction_Date"].ToString());
            Item.Sanction_Amt = Decimal.Parse(ObjDb.DataReader["Sanction_Amt"].ToString());
            Item.FileName = ObjDb.DataReader["FileName"].ToString();
            Item.sanctioned_Doc_name = ObjDb.DataReader["sanctioned_Doc_name"].ToString();
            Item.FType = ObjDb.DataReader["FType"].ToString();
            BdgtListItms.Add(Item);
        }
        ObjDb.DataReader.Close();
        ObjDb.Command.Parameters.Clear();
    }
    //-----------------Select data on GridRow selection on Budget Sanction form
    public void BdgtSanc_SelectG(String flag, Int32 InstID, Int32 Budget_Id, ref List<DataMember.Budget> BdgtListItms, DBManager ObjDb)
    {
        BdgtAllc_Select_(flag, InstID, Budget_Id, ref ObjDb);
        if (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.Budget();
            Item.Budget_Id = Int32.Parse(ObjDb.DataReader["Budget_Id"].ToString());
            Item.Budget_name = ObjDb.DataReader["Budget_name"].ToString();
            Item.Applied_Amt = Decimal.Parse(ObjDb.DataReader["Applied_Amt"].ToString());
            Item.Allocated_Amt = Decimal.Parse(ObjDb.DataReader["Allocated_Amt"].ToString());
            Item.Ledger_Id = Int32.Parse(ObjDb.DataReader["Ledger_Id"].ToString());
            Item.Sanction_Date = DateTime.Parse(ObjDb.DataReader["Sanction_Date"].ToString());
            Item.Sanction_Amt = Decimal.Parse(ObjDb.DataReader["Sanction_Amt"].ToString());
            Item.FileName = ObjDb.DataReader["Sanctioned_Doc_Id"].ToString();
            Item.sanctioned_Doc_name = ObjDb.DataReader["sanctioned_Doc_name"].ToString();
            Item.Fund_Source_Id = Int32.Parse(ObjDb.DataReader["Fund_Source_Id"].ToString());
            Item.Balance = Decimal.Parse(ObjDb.DataReader["Balance"].ToString());
            Item.Sanction_Number = ObjDb.DataReader["Sanction_Number"].ToString();
            BdgtListItms.Add(Item);
        }
        ObjDb.DataReader.Close();
        ObjDb.Command.Parameters.Clear();
    }
    #endregion

    #region Budget Release Select Process
    //-----------------Select data on GridRow selection on Budget Sanction form
    public void BdgtRls_Select(String flag, Int32 InstID, Int32 Budget_Id, ref DBManager ObjDb)
    {
        BdgtRls_Select_(flag, InstID, Budget_Id, ref ObjDb);
    }
    #endregion
}
