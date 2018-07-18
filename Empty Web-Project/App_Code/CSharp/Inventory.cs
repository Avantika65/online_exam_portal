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
using System.Reflection;
/// <summary>
/// Summary description for Inventory
/// </summary>
public class Inventory : Invent_Data
{
    //protected string ReturnConString()
    //{
    //    return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //}
	public Inventory()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region Utility
    public void BindGridView<T>(List<T> source, GridView gridView) where T : new()
    {
        if (source.Count > 0)
        {
            gridView.DataSource = source;
            //gridView.DataKeyNames = new string[] { "ID" };
            gridView.DataBind();
            gridView.Enabled = true;
        }
        else
        {
            ShowNoResultFound<T>(source, gridView);
        }
    }
    private void ShowNoResultFound<T>(List<T> source, GridView gv) where T : new()
    {

        if (source == null)

            return;

        source.Add(new T());

        gv.DataSource = source;

        gv.DataBind();
        gv.Enabled = false;
        //gv.Rows[0].Controls.Clear();
        //gv.Rows[0].Cells.Clear();
        /*
        // Get the total number of columns in the GridView to know what the Column Span should be

        int columnsCount = gv.Columns.Count;

        gv.Rows[0].Cells.Clear();// clear all the cells in the row
        gv.Rows[0].Controls.Clear();
        gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell

        gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


        gv.Rows[0].Cells[0].CssClass = "EmptyDataRowStyle";

        //set No Results found to the new added cell

        gv.Rows[0].Cells[0].Text = "No result found....";//gv.EmptyDataText; // Use GridView's Empty Row message
        */
    }
    #endregion

    #region Purchase Order

    //.............................................Generate Order No......................................
    public void Gen_POrderNo(int InstId, ref string Order_No)
    {
        try
        {
            GenPOCode_(InstId, ref Order_No);
        }
        catch (Exception ex)
        {
            Order_No = "0";
        }
    }
    //-----------------------------------------Save Purchase Order---------------------------------------
    //public void POrder_Save(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note,Int32 CurrencyId,ref Int32 PId, ref string RetSuccess)
    //{
    //    try
    //    {
    //        PurOrderSave_(flag, InstId, POId, POCode, PODate, PO_Ref, Com_Manu_Ven_Id, Ship_Via, PMT_Type, Reference, PO_SubTotal, Discount_Perc, Shipping_Amt, Tax_Type, Tax_Amt, Tot_Payable_Amt, Balance_Amt, Paid_Amt, IsPaid, Status, IsArrived, Comment, Note, CurrencyId, ref PId, ref RetSuccess);
    //    }
    //    catch (Exception ex)
    //    { RetSuccess = "0"; }
    //}

    //--------------------------------------------------------------------------------------------------------
    public void POrder_Save(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, ref Int32 PId, ref string RetSuccess, Decimal Excise_Duty, String Type_C_V, Decimal CstVat, Int32 SiteID, SqlCommand com)
    {
        PurOrderSave_(flag, InstId, POId, POCode, PODate, PO_Ref, Com_Manu_Ven_Id, Ship_Via, PMT_Type, Reference, PO_SubTotal, Discount_Perc, Shipping_Amt, Tax_Type, Tax_Amt, Tot_Payable_Amt, Balance_Amt, Paid_Amt, IsPaid, Status, IsArrived, Comment, Note, CurrencyId, ref PId, ref RetSuccess, Excise_Duty, Type_C_V, CstVat, SiteID, com);
    }
    //-----------------------------------------------------------------------------------------
    public void POrder_Save(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, ref Int32 PId, ref string RetSuccess, Decimal Excise_Duty, String Type_C_V, Decimal CstVat, Int32 SiteID,Int32 UserId, String TermsCondition, Int32 UID, String Session, SqlCommand com)
    {
        PurOrderSave_(flag, InstId, POId, POCode, PODate, PO_Ref, Com_Manu_Ven_Id, Ship_Via, PMT_Type, Reference, PO_SubTotal, Discount_Perc, Shipping_Amt, Tax_Type, Tax_Amt, Tot_Payable_Amt, Balance_Amt, Paid_Amt, IsPaid, Status, IsArrived, Comment, Note, CurrencyId, ref PId, ref RetSuccess, Excise_Duty, Type_C_V, CstVat, SiteID, UserId, TermsCondition, UID, Session, com);
    }   
    //-----------------------------------------Save Purchase Order---------------------------------------
    public void POChlidSave(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, ref string RetSuccess, SqlCommand com)
    {
        PurOrderChildSave_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, ref RetSuccess, com);
    }
    #endregion

    #region Receive Items
    public void Receive_Save(String flag, Int32 ID, String Pmt_Type, String Invoice_No, String Receipt_No, Decimal Discount_Perc, Decimal Discount_Amt, DateTime Recv_Date, Decimal Tax_Percent, Decimal Subtotal, Decimal Shipping_Chrgs, Decimal Tax_Amount, Decimal Total_Payable, Decimal Paid_Amt, Decimal Bal_Amt, String Notes, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, Int32 InstID, ref Int32 _ID, ref string RetSuccess)
    {
        ReceiveMasterSave_(flag, ID, Pmt_Type, Invoice_No, Receipt_No, Discount_Perc, Discount_Amt, Recv_Date, Tax_Percent, Subtotal, Shipping_Chrgs, Tax_Amount, Total_Payable, Paid_Amt, Bal_Amt, Notes, Currency, EX_Rate, Session, UID, InstID, ref _ID, ref RetSuccess);
    }
    public void Receive_Child(Int32 Recev_Mst_Id, Int32 PO_ID, Int32 ChallanID, Int32 Product_ID, Decimal Quantity, Decimal Prc_Per_Qty, Decimal Tot_Price, Int32 Location, Int32 InstID, Int32 ChallanChildID, ref string RetSuccess)
    {
        ReceiveChildSave_(Recev_Mst_Id, PO_ID, ChallanID, Product_ID, Quantity, Prc_Per_Qty, Tot_Price, Location, InstID, ChallanChildID, ref RetSuccess);
    }
    public void Receive_Save(String flag, Int32 ID, Int32 POId, String Pmt_Type, String Invoice_No, String Receipt_No, Decimal Discount_Perc, Decimal Discount_Amt, DateTime Recv_Date, Decimal Tax_Percent, Decimal Subtotal, Decimal Shipping_Chrgs, Decimal Tax_Amount, Decimal Total_Payable, Decimal Paid_Amt, Decimal Bal_Amt, String Notes, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, Int32 InstID, ref Int32 _ID, ref string RetSuccess, SqlCommand com)
    {
        ReceiveMasterSave_(flag, ID, POId, Pmt_Type, Invoice_No, Receipt_No, Discount_Perc, Discount_Amt, Recv_Date, Tax_Percent, Subtotal, Shipping_Chrgs, Tax_Amount, Total_Payable, Paid_Amt, Bal_Amt, Notes, Currency, EX_Rate, Session, UID, InstID, ref _ID, ref RetSuccess, com);
    }
    public void Receive_Save(String flag, Int32 ID, Int32 POId, String Pmt_Type, String Invoice_No, String Receipt_No, Decimal Discount_Perc, Decimal Discount_Amt, DateTime Recv_Date, Decimal Tax_Percent, Decimal Subtotal, Decimal Shipping_Chrgs, Decimal Tax_Amount, Decimal Total_Payable, Decimal Paid_Amt, Decimal Bal_Amt, String Notes, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, Int32 InstID, ref Int32 _ID, Boolean Is_Paid, ref string RetSuccess, SqlCommand com)
    {
        ReceiveMasterSave_(flag, ID, POId, Pmt_Type, Invoice_No, Receipt_No, Discount_Perc, Discount_Amt, Recv_Date, Tax_Percent, Subtotal, Shipping_Chrgs, Tax_Amount, Total_Payable, Paid_Amt, Bal_Amt, Notes, Currency, EX_Rate, Session, UID, InstID, ref _ID, Is_Paid, ref RetSuccess, com);
    }
    public void Receive_Child(Int32 Recev_Mst_Id, Int32 PO_ID, Int32 ChallanID, Int32 Ctrl_Id, Decimal Quantity, Decimal Prc_Per_Qty, Decimal Tot_Price, Int32 Location, Int32 InstID, Int32 ChallanChildID, Int32 Unit_Id, ref string RetSuccess, SqlCommand com)
    {
        ReceiveChildSave_(Recev_Mst_Id, PO_ID, ChallanID, Ctrl_Id, Quantity, Prc_Per_Qty, Tot_Price, Location, InstID, ChallanChildID, Unit_Id, ref RetSuccess, com);
    }
    public void FetchCatalog(String Fields, String Where, ref DBManager ObjDAL)
    {
        FetchCatalogue_(Fields, Where, ref ObjDAL);
    }
    public void Receive_Invoice_Up(String flag, Int32 ID, Int32 InstID, String Invoice_No, ref String RetSuccess, SqlCommand Com)
    {
        Receive_Invoice_Up_(flag, ID, InstID, Invoice_No, ref RetSuccess, Com);
    }
    
    #endregion

    #region Currency Master
    public void Currency_Save(String flag, Int32 InstID, Int32 CurrencyCode, String CurrencyName, String ShortName, Decimal GocRate, Decimal BankRate, DateTime EffectiveDate, Boolean SetDefault, ref string RetSuccess)
    {
        CurrencySave_(flag, InstID, CurrencyCode, CurrencyName, ShortName, GocRate, BankRate, EffectiveDate, SetDefault, ref RetSuccess);
    }
    public void Currency_Delete(String flag, Int32 currencycode, Int32 InstID, ref string RetSuccess)
    {
        CurrencyDelete_(flag, currencycode, InstID, ref RetSuccess);
    }
     //--------------Select Currency Details---------------------
    public void Select_Currency(String flag, Int32 InstId, Int32 CurncyID, ref DBManager ObjDal)
    {
        Select_Currency_(flag, InstId, CurncyID, ref ObjDal);
    }
    #endregion

    #region Payment Process
    ////.............................................Generate Document No for Payment Process......................................
    public void Gen_DocNo(int InstId, ref string Doc_No)
    {
        try
        {
            GenDocNo_(InstId, ref Doc_No);
        }
        catch (Exception ex)
        { Doc_No = "0"; }
    }

    ////................................Bill sent to account............................................................................................

    public void BillToAccount(string flag, int InstId, int Id, string Receipt_No, string Order_No, string Inv_Relation, int Inv_Relation_Id, DateTime Pmt_Date, string Doc_No, string Pmt_Type, Decimal InvoiceAmt, Decimal Dmgd_Qty_Amt, Decimal PayableAmt, ref string RetSuccess)
    {
        try
        {
            BillToAccount_(flag, InstId, Id, Receipt_No, Order_No, Inv_Relation, Inv_Relation_Id, Pmt_Date, Doc_No, Pmt_Type, InvoiceAmt, Dmgd_Qty_Amt, PayableAmt, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    public void PmtStatus(string flag, int InstId, int Id, int Invoice_Id, string Pmt_Status, string Pmt_Type, string Draft_Chq_No, string Draft_Chq_Date, DateTime Pmt_Date,Decimal Pay_Amt, ref string RetSuccess)
    {
        try
        {
            PmtStatus_(flag, InstId, Id, Invoice_Id, Pmt_Status, Pmt_Type, Draft_Chq_No, Draft_Chq_Date, Pmt_Date, Pay_Amt, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    public void Payment(string flag, int InstId, int Id, int Invoice_Id, string Draft_Chq_No, string Draft_Chq_Date, DateTime Pmt_Date, decimal Pay_Amt, string Pay_Bank, ref string RetSuccess)
    {
        try
        {
            Payment_(flag, InstId, Id, Invoice_Id, Draft_Chq_No, Draft_Chq_Date, Pmt_Date, Pay_Amt, Pay_Bank, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    //---------------------Modified By Mohd Danish Ansari On 22-Feb-2011------------------------//
    public void Select_PO_Basis_(String flag, Int32 InstID, Int32 POID, DBManager ObjDAL)
    {
        SelectPOBasis_(flag, InstID, POID, ObjDAL);
    }

    public void SelectRPTBasis(String flag, Int32 InstID, Int32 RecvID, DBManager ObjDAL)
    {
        Select_RPT_RECS_(flag, InstID, RecvID, ObjDAL);
    }

    public void SelectRPT_Basis(String flag, Int32 InstID, Int32 RecvID, DBManager ObjDAL)
    {
        Select_RPT_RECS(flag, InstID, RecvID, ObjDAL);
    }

    public void Fill_Item_Grid(String flag, Int32 InstID, Int32 RecvID, ref DataTable DtItmGrd, DBManager ObjDAL)
    {
        FillItemGrid_(flag, InstID, RecvID, ref DtItmGrd, ObjDAL);
    }

    public void Save_Item_Wise_AMT(String flag, Int32 PaymentID, Int32 InvoiceID, Decimal PayableAmt, Decimal PaidAmt, String BillNo, String Pmt_Type, String Draft_Chq_No, String Draft_Chq_Date, Boolean Is_Dmgd_Adj, Decimal Dmgd_Amt, Int32 UserID, Int32 InstID, Int32 SupplierID, Int32 POID, Boolean Clearence, ref String RetSuccess)
    {
        Save_Item_Wise_AMT_(flag, PaymentID, InvoiceID, PayableAmt, PaidAmt, BillNo, Pmt_Type, Draft_Chq_No, Draft_Chq_Date, Is_Dmgd_Adj, Dmgd_Amt, UserID, InstID, SupplierID, POID, Clearence, ref RetSuccess);
    }

    public void GenBillNo(Int32 InstID, String prefixtag, ref String BillNo)
    {
        GenBillNo_(InstID, prefixtag, ref BillNo);
    }
    //------------------------------------------------------------------------------------------//
    #endregion

    #region Generating Receipt No
    public void Gen_Receipt_No(Int32 InstID, String prefixtag, ref string Ref_No)
    {
        try 
        {
            GenReceiptNo_(InstID, prefixtag, ref Ref_No);
        }
        catch (Exception ex)
        {
            Ref_No = "0";
        }
    }
    public void Gen_Receipt_No(Int32 InstID, String prefixtag, ref string Ref_No, SqlCommand com)
    {
        GenReceiptNo_(InstID, prefixtag, ref Ref_No, com);
    }
    #endregion

    #region Client Registration
    //-----------------------------------------Save Client Registration---------------------------------------
    public void ClientRegs_Save(String flag, Int32 InstId, Int32 Id, String Client_Id, String first_name, String middle_name, String last_name, String Bill_house_no, String Bill_city, String Bill_state, String Bill_pincode, String Bill_country, String Ship_house_no, String Ship_city, String Ship_state, String Ship_pincode, String Ship_country, String phone1, String phone2, String email1, String email2, Int32 department, String Release_No, String Account_No, String Credit_Limit, Decimal Current_Balance, String status, String remarks, byte[] image, Int32 PurchaseGrp, ref string RetSuccess)
    {
         ClientRegSave_(flag, InstId, Id, Client_Id, first_name, middle_name, last_name, Bill_house_no, Bill_city, Bill_state, Bill_pincode, Bill_country, Ship_house_no, Ship_city, Ship_state, Ship_pincode, Ship_country, phone1, phone2, email1, email2, department, Release_No, Account_No, Credit_Limit, Current_Balance, status, remarks, ((byte[])(image)), PurchaseGrp, ref RetSuccess);
    }
     //-----------------Select Client Detail--------------------
    public void ClientRegs_Select(String flag, Int32 InstId, Int32 Id, ref DBManager ObjDAL)
    {
        ClientRegs_Select_(flag, InstId, Id, ref ObjDAL);
    }
    #endregion

    #region Update Client Id
    public void Update_Client_Id(String flag, int InstId, String Old_Client_Id, String New_Client_Id, ref String RetSuccess)
    {
         UpdateClientID_(flag, InstId, Old_Client_Id, New_Client_Id, ref RetSuccess);       
    }
    //-----------------Select Client for Id Updation--------------------
    public void ClientId_Srch(String flag, Int32 InstId, String Client_Id, ref DBManager ObjDAL)
    {
        ClientId_Srch_(flag, InstId, Client_Id, ref ObjDAL);
    }
    #endregion

    #region Cataloguing
    public void Catalogue_Save(String flag, Int32 ID, Int32 PO_ID, Int32 Rec_Mst_ID, Int32 Ctrl_Id, String Batch_No, String Serial_No, Int32 Location, String Var_Year, String Short_Name, Int32 InstID, Decimal Quantity, Int32 Unit_Id, ref string RetSuccess)
    {
        CatalogueSave_(flag, ID, PO_ID, Rec_Mst_ID, Ctrl_Id, Batch_No, Serial_No, Location, Var_Year, Short_Name, InstID, Quantity, Unit_Id, ref RetSuccess);
    }

    public void Catalogue_Save(String flag, Int32 ID, Int32 PO_ID, Int32 Rec_Mst_ID, Int32 Ctrl_Id, String Batch_No, String Serial_No, Int32 Location, String Var_Year, String Short_Name, Int32 InstID, Decimal Quantity, Int32 Unit_Id, ref string RetSuccess, SqlCommand com)
    {
        CatalogueSave_(flag, ID, PO_ID, Rec_Mst_ID, Ctrl_Id, Batch_No, Serial_No, Location, Var_Year, Short_Name, InstID, Quantity, Unit_Id, ref RetSuccess, com);
    }
    #endregion

    #region City
    public void City_Save(String flag, Int32 CityId, String CityName, Int32 StateId, String UName, DateTime UEntDt, ref string RetSuccess)
    {
        try
        {
            CitySave(flag, CityId, CityName, StateId, UName, UEntDt, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public void City_Delete(string flag, int cityid, ref string RetSuccess)
    {
        try
        {
            CityDelete_(flag, cityid, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public DataTable City_Grd_Fill(DBManager ObjDAL)
    {
        DataTable dtCity = new DataTable();
        string Query = "SELECT Country.CountryName,State.StateName,Country.CountryId,City.CityName,CityId FROM Country,State,City where State.CountryId=Country.CountryId and City.StateId=State.StateId GROUP BY Country.CountryName,State.StateName,Country.CountryId,City.CityName,CityId ORDER BY Country.CountryId";
        CityGrdFill(Query, ref dtCity, ObjDAL);
        return dtCity;
    }
    //-----------------Fill City Grid---------------------
    public void CityGrdFill(String flag, ref DBManager ObjDAL)
    {
        CityGrdFill_(flag,ref ObjDAL);
    }
    public void City_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        CitySelect_(flag, Fields, Where, ref ObjDAL);
    }
    #endregion

    #region State
    public void State_Save(String flag, Int32 StateId, Int32 CountryID, String StateName, String UName, DateTime UEntDt, ref string RetSuccess)
    {
        try
        {
            StateSave_(flag, StateId, CountryID, StateName, UName, UEntDt, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public void State_Delete(string flag, int stateID, ref string RetSuccess)
    {
        try
        {
            StateDelete_(flag, stateID, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public DataTable State_Grd_Fill(DBManager ObjDAL)
    {
        DataTable dtState = new DataTable();
        string Query = "SELECT Country.CountryName,State.StateName,StateID FROM Country,State where State.CountryId=Country.CountryId  GROUP BY Country.CountryName,State.StateName,StateID ORDER BY State.StateID";
        StateGrdFill_(Query, ref dtState, ObjDAL);
        return dtState;
    }
    //-----------Fill State Grid--------------------------------------
    public void StateGrdFill(String flag, ref DBManager ObjDAL)
    {
        StateGrdFill_(flag, ref ObjDAL);
    }
    //----------------------------------------------------------------
    public void State_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        StateSelect_(flag, Fields, Where, ref ObjDAL);
    }
    #endregion

    #region Country

    public void Country_Save(String flag, Int32 CountryID, String CountryName, String UName, DateTime UEntDt, ref string RetSuccess)
    {
        try
        {
            CountrySave(flag, CountryID, CountryName, UName, UEntDt, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    public DataTable Country_Grd_Fill(DBManager ObjDAL)
    {
        DataTable DtCntry = new DataTable();
        string Query = "SELECT Country.CountryID, Country.CountryName FROM Country ORDER BY Country.CountryID";
        CountryGrdFill(Query, ref DtCntry, ObjDAL);
        return DtCntry;
    }
    //-------------Fill Country Grid----------------------------------
    public void CountryGrdFill(String flag, ref DBManager ObjDAL)
    {
        CountryGrdFill_(flag, ref ObjDAL);
    }
    //----------------------------------------------------------------
    public void Country_Delete(string flag, int CountrtyID, ref string RetSuccess)
    {
        try
        {
            CountryDelete(flag, CountrtyID, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    public void Country_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        CountrySelect(flag, Fields, Where, ref ObjDAL);
    }
    #endregion

    #region Institute
    public void Institute_Save(String flag, Int32 id_inst, String INSTITUTE_NAME, String SHORT_NAME, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        Institute_Save_(flag, id_inst, INSTITUTE_NAME, SHORT_NAME, SessionID, UserID, UEDate, ref RetSuccess);
    }
    public void Organisation_Delete(String flag, Int32 id_inst, ref string RetSuccess)
    {
        Organisation_Delete_(flag, id_inst, ref RetSuccess);
    }
    //-------------Fill Organization Grid----------------------------------
    public void OrgGrdFill(String flag, ref DBManager ObjDAL)
    {
        OrgGrdFill_(flag, ref ObjDAL);
    }
    //----------------------------------------------------------------
    #endregion

    #region Address Relation
    public void Vendor_Save(String flag, Int32 id_vendor, String vendor_code, String vendor_name, String house_no, String mailingAdd, String city, String state, String pincode, String country, String contact_no, String fax, String email, String web_address, Int32 InstId, String SessionID, String UserID, DateTime UEDate, String Notes, byte[] image, String AddRelation, String country_mailing, String state_mailing, String city_mailing, String pincode_mailing, String PAN_No, ref string RetSuccess)
    {
        VendorSave_(flag, id_vendor, vendor_code, vendor_name, house_no, mailingAdd, city, state, pincode, country, contact_no, fax, email, web_address, InstId, SessionID, UserID, UEDate, Notes, ((byte[])(image)), AddRelation, country_mailing,state_mailing,city_mailing,pincode_mailing,PAN_No, ref RetSuccess);
    }
    public void Vendor_Delete(String flag, Int32 InstID, Int32 id_vendor, ref string RetSuccess)
    {
        VendorDelete_(flag, InstID, id_vendor, ref RetSuccess);
    }
    //--------Select Supplier Detail-----------------
    public void Select_Supplr(String flag, Int32 InstId, Int32 SupplrID, ref DBManager ObjDal)
    {
        Select_Supplr_(flag, InstId, SupplrID, ref ObjDal);
    }
    #endregion

    #region Product Type
    public void Type_Save(String flag, Int32 ID, String Name, String Short_Name, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            ProdTypeSave_(flag, ID, Name, Short_Name, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public void Type_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            ProdTypeDelete_(flag, ID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public DataTable Prod_Type_Grd(Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtType = new DataTable();
        string Query = "SELECT ID,Name,Short_Name FROM Product_Type WHERE InstID = '" + InstID + "'";
        ProdTypeGrdFill_(Query, ref dtType, ObjDAL);
        return dtType;
    }
    public void Prod_Type_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ProdTypeSelect_(flag, Fields, Where, ref ObjDAL);
    }
    #endregion

    #region Product Category
    public void Category_Save(String flag, Int32 ID, Int32 Prod_Type, String Name, String Short_Name, Int32 InstID, ref string RetSuccess)
    {
        try
        { 
            ProdCatSave_(flag, ID, Prod_Type, Name, Short_Name, InstID, ref RetSuccess); 
        }
        catch (Exception ex)
        { 
            RetSuccess = "0"; 
        }
    }
    public void Category_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            ProdCatDelete_(flag, ID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public DataTable Prod_Cat_Grd_Fill(string Condition, DBManager ObjDAL)
    {
        DataTable dtCat = new DataTable();       
        ProdCatGrdFill_(Condition, ref dtCat, ObjDAL);
        return dtCat;
    }
    public string get_record(string quary)
    {
        string rec = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand(quary, con);
        if (cmd.ExecuteScalar() != null)
        {
            rec = cmd.ExecuteScalar().ToString();           
        }
        if (con.State == ConnectionState.Open)
            con.Close();
        return rec;   
    }
    public string autogen(string quary)
    {
        string rec = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        con.Open();
        string st = "select cast((isnull(max(ID),0 ) +1) as nvarchar) FROM " + quary;
        SqlCommand cmd = new SqlCommand(st, con);
        if (cmd.ExecuteScalar() != null)
        {
            rec = cmd.ExecuteScalar().ToString();
        }
        if (con.State == ConnectionState.Open)
            con.Close();
        return rec;
    }
    public DataTable IssueLimit_Dept_Grd_Fill(Int32 DeptID, Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtCat = new DataTable();
        string Query = "SELECT * FROM Vw_IssueLimitDept WHERE DeptId='" + DeptID + "' and InstID = '" + InstID + "' Order By Prod_Name";
        ProdCatGrdFill_(Query, ref dtCat, ObjDAL);
        return dtCat;
    }
    public DataTable ScrapDept_Grd_Fill(Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtCat = new DataTable();
        string Query = "SELECT * FROM Vw_ScrapDepartment WHERE InstID = '" + InstID + "' Order By Prod_Name";
        ProdCatGrdFill_(Query, ref dtCat, ObjDAL);
        return dtCat;
    }
    public void Prod_Cat_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ProdCatSelect_(flag, Fields, Where, ref ObjDAL);
    }
   
    public void IssueLimit_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            IssueLimitDelete_(flag, ID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void ScrapDept_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            ScrapDeptDelete_(flag, ID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    #endregion
    #region Product Composition
    public void Composition_Save(String flag, Int32 ID, Int32 Prod_Type, Int32 Prod_Cat, String Composition, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            ProdCompSave_(flag, ID, Prod_Type, Prod_Cat, Composition, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Composition_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            ProdComDelete_(flag, ID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public DataTable Prod_Comp_Grd_Fill(string condition, DBManager ObjDAL)
    {
        DataTable dtProdComp = new DataTable();
        ProdCompGrdFill_(condition, ref dtProdComp, ObjDAL);
        return dtProdComp;
    }
    public void Prod_Comp_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ProdCompSelect_(flag, Fields, Where, ref ObjDAL);
    }
    #endregion

    #region Store Location
    public void Store_Save(String flag, Int32 ID, String Build_S_Name, String Floor, String Room_No, String Almirah_No, Int32 InstID, Int32 WarehouseID, ref string RetSuccess)
    {
        try
        {
            StoreLocSave_(flag, ID, Build_S_Name, Floor, Room_No, Almirah_No, InstID, WarehouseID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Store_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            StoreLocDelete_(flag, ID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public DataTable StoreLoc_Grd_Fill(Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtStore = new DataTable();
        StoreLocGrdFill_("F", InstID, ref dtStore, ObjDAL);
        return dtStore;
    }
    public void StoreLoc_Select(String flag, Int32 ID, Int32 InstID, ref DBManager ObjDAL)
    {
        StoreLocSelect_(flag, ID, InstID, ref ObjDAL);
    }
    #endregion

    #region Tax Master
    public void Tax_Save(String flag, Int32 ID, Decimal VAT, Decimal SAT, Boolean IS_VAT, Boolean IS_SAT, DateTime Start_Date, Int32 InstID, ref string RetSuccess)
    {
        TaxSave_(flag, ID, VAT, SAT, IS_VAT, IS_SAT, Start_Date, InstID, ref RetSuccess);
    }
    public void Tax_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        TaxDelete_(flag, ID, InstID, ref RetSuccess);
    }
     //-------------Fill Tax master Grid----------------------------------
    public void TaxGrdFill(String flag, Int32 InstID, ref DBManager ObjDAL)
    {
        TaxGrdFill_(flag, InstID, ref ObjDAL);
    }
    #endregion

    #region Product Name
    public void Prod_Name_Save(String flag, Int32 ID, String Prod_Code, String Prod_Name, String Short_Name, Int32 Prod_Type, Int32 Prod_Cat, Int32 Composition, Decimal List_Price, Decimal Cost_Price, Int32 Stock_Bal, String Prod_Desc, String Pur_Ord_Desc, Decimal Tax_Invoice, Decimal Tax_Pur_Ord, Boolean Non_Stock, Int32 Store_Loc, Int32 Sales_Pr_Opt, Decimal Sales_Pr_Val, Decimal Min_Qty, Decimal Max_Qty, Decimal Target_Qty, Boolean Is_Vat, Boolean Is_Sat, Int32 Unit_Id, Boolean Is_Batch, Int32 InstID, ref string RetSuccess)
    {
        ProdSave_(flag, ID, Prod_Code, Prod_Name, Short_Name, Prod_Type, Prod_Cat, Composition, List_Price, Cost_Price, Stock_Bal, Prod_Desc, Pur_Ord_Desc, Tax_Invoice, Tax_Pur_Ord, Non_Stock, Store_Loc, Sales_Pr_Opt, Sales_Pr_Val, Min_Qty, Max_Qty, Target_Qty, Is_Vat, Is_Sat, Unit_Id, Is_Batch, InstID, ref RetSuccess);
    }
    public void Prod_Name_Save(String flag, Int32 ID, String Prod_Code, String Prod_Name, String Short_Name, Int32 Prod_Type, Int32 Prod_Cat, Int32 Composition, Decimal List_Price, Decimal Cost_Price, Int32 Stock_Bal, String Prod_Desc, String Pur_Ord_Desc, Decimal Tax_Invoice, Decimal Tax_Pur_Ord, Boolean Non_Stock, Int32 Store_Loc, Int32 Sales_Pr_Opt, Decimal Sales_Pr_Val, Decimal Min_Qty, Decimal Max_Qty, Decimal Target_Qty, Boolean Is_Vat, Boolean Is_Sat, Int32 Unit_Id, Boolean Is_Batch, Boolean Is_Barcode, String StorageLoc, Int32 InstID, Int32 CtrlIDUP, String Weight, Int32 Medi_id, ref int Ctrl_Id, ref string RetSuccess, SqlCommand com)
    {
        ProdSave_(flag, ID, Prod_Code, Prod_Name, Short_Name, Prod_Type, Prod_Cat, Composition, List_Price, Cost_Price, Stock_Bal, Prod_Desc, Pur_Ord_Desc, Tax_Invoice, Tax_Pur_Ord, Non_Stock, Store_Loc, Sales_Pr_Opt, Sales_Pr_Val, Min_Qty, Max_Qty, Target_Qty, Is_Vat, Is_Sat, Unit_Id, Is_Batch, Is_Barcode, StorageLoc, InstID, CtrlIDUP, Weight, Medi_id,  ref Ctrl_Id, ref RetSuccess, com);
    }
    public void Prod_Name_Save(String flag, Int32 ID, String Prod_Code, String Prod_Name, String Short_Name, Int32 Prod_Type, Int32 Prod_Cat, Int32 Composition, Decimal List_Price, Decimal Cost_Price, Int32 Stock_Bal, String Prod_Desc, String Pur_Ord_Desc, Decimal Tax_Invoice, Decimal Tax_Pur_Ord, Boolean Non_Stock, Int32 Store_Loc, Int32 Sales_Pr_Opt, Decimal Sales_Pr_Val, Decimal Min_Qty, Decimal Max_Qty, Decimal Target_Qty, Boolean Is_Vat, Boolean Is_Sat, Int32 Unit_Id, Boolean Is_Batch, Boolean Is_Barcode, String StorageLoc, Int32 InstID, Int32 CtrlIDUP, String Weight, Int32 Medi_id, Boolean IsNonConsumable, ref int Ctrl_Id, ref string RetSuccess, SqlCommand com)
    {
        ProdSave_(flag, ID, Prod_Code, Prod_Name, Short_Name, Prod_Type, Prod_Cat, Composition, List_Price, Cost_Price, Stock_Bal, Prod_Desc, Pur_Ord_Desc, Tax_Invoice, Tax_Pur_Ord, Non_Stock, Store_Loc, Sales_Pr_Opt, Sales_Pr_Val, Min_Qty, Max_Qty, Target_Qty, Is_Vat, Is_Sat, Unit_Id, Is_Batch, Is_Barcode, StorageLoc, InstID, CtrlIDUP, Weight, Medi_id, IsNonConsumable, ref Ctrl_Id, ref RetSuccess, com);
    }
    public void Prod_Name_Delete(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        ProdDelete_(flag, ID, InstID, ref RetSuccess);
    }
    public void Prod_Name_Select(Int32 Ctrl_Id, Int32 InstID, ref DBManager Objdal)
    {
        ProdNameSelect_(Ctrl_Id, InstID, ref Objdal);
    }
    public void Prod_Name_Update(String flag, Decimal Max_Qty, Decimal Min_Qty, Decimal Target_Qty, Int32 UnitID, Int32 Ctrl_Id, Int32 Store_Loc, Int32 InstID, ref string RetSuccess)
    {
        ProdNameUpdate_(flag, Max_Qty, Min_Qty, Target_Qty, UnitID, Ctrl_Id, Store_Loc, InstID, ref RetSuccess);
    }
    public void Prod_Name_Qty_Select(String flag, Int32 Ctrl_Id, Int32 Store_Loc, Int32 InstID, ref DBManager ObjDal)
    {
        ProdNameQtySelect_(flag, Ctrl_Id, Store_Loc, InstID, ref ObjDal);
    }
    //-------------Get Location---------------------------
    public void Get_ProdLoc(Int32 Ctrl_Id, Int32 InstID, ref DataTable dtLoc)
    {
        Get_ProdLoc_(Ctrl_Id, InstID, ref dtLoc);
    }
    #endregion

    #region Indent
    //.............................................Generate Indent Code......................................
    public void Gen_IndentCode(int InstId, ref string IndentCode)
    {
        try
        {
            GenIndentCODE_(InstId, ref IndentCode);
        }
        catch (Exception ex)
        {
            IndentCode = "0";
        }
    }
    //................................Save Dept Scrap ............................................................................................

    public void ScrapDept_Save(string flag, int InstId, int ID, DateTime EntryDate, string ScrapCode, int Ctrl_Id, Decimal Qty, Int32 UserId, Int32 DeptId, Int32 Unit_Id, string Remark, string Status1, ref string RetSuccess)
    {
        ScrapDeptSave_(flag, InstId, ID, EntryDate, ScrapCode, Ctrl_Id, Qty, UserId, DeptId, Unit_Id, Remark, Status1, ref RetSuccess);
    }
    //................................Save Issue Limit ............................................................................................

    public void IssueLimit_Save(string flag, int InstId, int ID, DateTime EntryDate, DateTime ToDate, int Ctrl_Id, Decimal Limit_Qty, Int32 UserId, Int32 DeptId, Int32 Unit_Id, string Remark, ref string RetSuccess)
    {
        IssueLimitSave_(flag, InstId, ID, EntryDate, ToDate, Ctrl_Id, Limit_Qty, UserId, DeptId, Unit_Id, Remark, ref RetSuccess);
    }
    //................................Save Indent ............................................................................................

    public void Indent_Save(string flag, int InstId, int ID, int IndentId, String Indent_Code, int Ctrl_Id, Decimal Qty, String Warehouse, DateTime ExpectedDate, Int32 UserID, Int32 Dept, Int32 Unit_Id, string SessionID, Int32 Site_Mst_Id, string purpose, ref string RetSuccess)
    {
        IndentSave_(flag, InstId, ID, IndentId, Indent_Code, Ctrl_Id, Qty, Warehouse, ExpectedDate, UserID, Dept, Unit_Id, SessionID, Site_Mst_Id, purpose, ref RetSuccess);
    }

    ////................................Update Indent ............................................................................................

    public void Indent_Update(int InstId, int ID, Decimal Qty,Int32 Unit_Id, Boolean ApprovalStatus, String IndentStatus, String Indent_Transfer, String IndentNote, String Req_Note,String Warehouse, ref string RetSuccess)
    {
        try
        {
            IndentUpdate_(InstId, ID, Qty, Unit_Id, ApprovalStatus, IndentStatus, Indent_Transfer, IndentNote, Req_Note, Warehouse, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    //................................Fill Location ............................................................................................

    public void Fill_Loc(int InstId, int Ctrl_Id, GridView GrdLoc)
    {
        IndentFillLOC_(InstId, Ctrl_Id, GrdLoc);
    }
    #endregion

    #region Material Issue
    //.............................................Generate Issue No.......................................
    public void Gen_MatIssueNo(int InstId, ref string Issue_No)
    {
        Gen_MatIssueNo_(InstId, ref  Issue_No);
    }

    //................................Save Material Issue ............................................................................................

    public void MatIssue_Save(string flag, int InstId, int Id, String Issue_No, DateTime Issue_Date, DateTime Due_Date, String IssueStoreLoc, String RecvStoreLoc, String IssuedTo, String IssuedBy, Int32 IndentId, String Issue_Type, int Ctrl_Id, Decimal Issue_Qty, Boolean IsReturnable, Int32 UOM, String Description, String Contractor, String Supervisor, ref Int32 IssueId, Int32 SiteID, ref string RetSuccess)
    {
        MatIssue_Save_(flag, InstId, Id, Issue_No, Issue_Date, Due_Date, IssueStoreLoc, RecvStoreLoc, IssuedTo, IssuedBy, IndentId, Issue_Type, Ctrl_Id, Issue_Qty, IsReturnable, UOM, Description, Contractor, Supervisor, ref IssueId, SiteID, ref RetSuccess);
    }

    //................................Save Material Issue Into Child table............................................................................................

    public void MatIssueChild_Save(int InstId, int Id, Int32 IssueId, Int32 Store_Loc, String Loc_Type, Decimal Qty, Int32 Unit_Id, String Issue_Type, Int32 Ctrl_Id, Int32 IndentId, ref string RetSuccess)
    {
        MatIssueChild_Save_(InstId, Id, IssueId, Store_Loc, Loc_Type, Qty, Unit_Id, Issue_Type, Ctrl_Id, IndentId, ref RetSuccess);
    }
    //--------------------------------Check Issued Quantity-------------------------------------
    public void MatIssue_QtyCheck(int InstId, int Id, Decimal IQty, Int32 IUnit, String Issue_Type, ref String IndntQty, ref string IndntUOM, ref string RetSuccess)
    {
        MatIssue_QtyCheck_(InstId, Id, IQty, IUnit, Issue_Type, ref IndntQty, ref IndntUOM, ref RetSuccess);
    }
    //--------------------------------Check Issued Quantity-------------------------------------
    public void Check_StockBal(String flag, int InstId, int Ctrl_Id, Int32 Issue_Loc, Decimal Qty, Int32 Unit, ref String Stock_Bal, ref string StockUnit, ref string RetSuccess)
    {
        Check_StockBal_(flag, InstId, Ctrl_Id, Issue_Loc, Qty, Unit, ref Stock_Bal, ref StockUnit, ref RetSuccess);
    }
    //---------------Get Issuable Items-------------------------------------------
    public void Get_IssuableItems(String flag, Int32 InstID, Int32 UserId, ref DBManager ObjDAL)
    {
        Get_IssuableItems_(flag, InstID, UserId, ref ObjDAL);
    }
    #endregion

    #region Warehouse
    public void Warehouse_Save(String flag, Int32 ID, String Name, String Short_Name, String Address, String BuildingName, String BuildShName, Int32 InstId, ref string RetSuccess)
    {
        try
        {
            WarehouseSave_(flag, ID, Name, Short_Name, Address, BuildingName, BuildShName, InstId, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Warehouse_Delete(Int32 ID, Int32 InstId, ref string RetSuccess)
    {
        try
        {
            WarehouseDelete_(ID, InstId, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Warehouse_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        WarehouseSelect_(flag, Fields, Where, ref ObjDAL);
    }
    public DataTable Warehouse_Grd_Fill(Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtWarehouse = new DataTable();
        string SQL = "SELECT ID,Name,Short_Name FROM [Warehouse] WHERE InstID = '" + InstID + "'";
        WarehouseGrdFill_(SQL, ref dtWarehouse, ObjDAL);
        return dtWarehouse;
    }
    //---------------Fill Warehouse Grid---------------------------
    public void WarehouseGrdFill(String flag, Int32 InstID, ref DBManager ObjDAL)
    {
        WarehouseGrdFill_(flag, InstID, ref ObjDAL);
    }
    #endregion

    #region Purchase Request
    public void Purchase_Req_Save(string flag, Int32 ID, Int32 IndentID, String PRNo, DateTime CurrentDate, Int32 UID, String Session, Int32 InstID, String IndentType, ref Int32 Ret_ID_, ref string RetSuccess)
    {
        try
        {
            PurchaseReqSave_(flag, ID, IndentID, PRNo, CurrentDate, UID, Session, InstID, IndentType, ref Ret_ID_, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }

    public void Pur_Req_Child_Save(String flag_, Int32 PR_Mst_Id, Int32 IndentID, Int32 Ctrl_Id, Decimal Qty, DateTime DeliveryDate, Int32 Requester, Int32 Dept, Int32 Warehouse, Int32 Store, Boolean Is_Approved, Int32 InstID, Int32 ID, String IndentType, Int32 Unit_Id, ref string RetSuccess)
    {
        try
        {
            PurReqChildSave_(flag_, PR_Mst_Id, IndentID, Ctrl_Id, Qty, DeliveryDate, Requester, Dept, Warehouse, Store, Is_Approved, InstID, ID, IndentType, Unit_Id, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }

    public DataTable FillProdDetails(String flag, Int32 IndentID, Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtProd_ = new DataTable();
        FillProdDetails_(flag, IndentID, InstID, ref dtProd_, ObjDAL);
        return dtProd_;
    }
    public void FillProdDetails(String flag, Int32 IndentID, Int32 InstID, ref DBManager ObjDAL)
    {
        FillProdDetails_(flag, IndentID, InstID, ref ObjDAL);
    }

    public void FetchDtlsIndentID(String flag, Int32 Ctrl_ID, Int32 IndentID, Int32 InstID, ref DBManager ObjDAL)
    {
        FetchDtlsIndentID_(flag, Ctrl_ID, IndentID, InstID, ref ObjDAL);
    }
    #endregion

    #region Generating PR No
    public void Gen_PR_No(Int32 InstID, String prefixtag, ref string PRNo)
    {
        Gen_PR_No_(InstID, prefixtag, ref PRNo);
    }
    #endregion

    #region Material Return
    public void Mat_Return(int InstId, int Id, Int32 Ctrl_Id, Decimal ReturnQty, String RecvStoreLoc, String ReturnedBy, ref string RetSuccess)
    {
        try
        {
            Mat_Return_(InstId, Id, Ctrl_Id, ReturnQty, RecvStoreLoc, ReturnedBy, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    //---------------------------------Material Receive Child ----------------------------
    public void MatChild_Return(int InstId, Int32 IssueId, Int32 Ctrl_Id, Decimal Qty, Int32 RecvStoreLoc, Int32 Unit_Id, ref string RetSuccess)
    {
        try
        {
            MatChild_Return_(InstId, IssueId, Ctrl_Id, Qty, RecvStoreLoc, Unit_Id, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    #endregion

    #region Receive Location
    public DataTable Recv_Loc(int InstId, int IssueId)
    {
        DataTable dtLoc_ = new DataTable();
        Recv_Loc_(InstId, IssueId, ref dtLoc_);
        return dtLoc_;
    }
    #endregion

    #region Material Reservation
    public bool Mat_Reservation(string flag, int InstId, int Id, int Client_Id, int Ctrl_Id, Decimal Qty, String ReservedBy, Int32 Unit_Id, ref int RetSuccess)
    {
        bool IsReserve = true;
        Mat_Reservation_(flag, InstId, Id, Client_Id, Ctrl_Id, Qty, ReservedBy, Unit_Id, ref RetSuccess, ref IsReserve);
        return IsReserve;
    }

    public void Reset_RsrvPriority(int InstId, int Client_Id, int ProductId,ref int ResClientId, ref String RetSuccess)
    {
        try
        {
            Reset_RsrvPriority_(InstId, Client_Id, ProductId, ref ResClientId, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }

    #endregion

    #region Storing Vendor Details
    public void Vendor_Dtls_Save(String flag, Int32 ID, Int32 PRId, Int32 Ctrl_Id, String SupplierId, Int32 IndentID, Int32 UID, String SessionID, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            Vendor_Dtls_Save_(flag, ID, PRId, Ctrl_Id, SupplierId, IndentID, UID, SessionID, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    #endregion

    #region Generating RFQNo
    public void Gen_RFQNo(Int32 InstID, String prefixtag, ref string RFQNo)
    {
        try 
        {
            GenRFQNo_(InstID, prefixtag, ref RFQNo);
        }
        catch (Exception ex)
        { RFQNo = "0"; }
    }
    public void Gen_RFQNo(Int32 InstID, String prefixtag, ref string RFQNo, DBManager ObjDAL)
    {
        try
        {
            GenRFQNo_(InstID, prefixtag, ref RFQNo, ObjDAL);
        }
        catch (Exception ex)
        { RFQNo = "0"; }
    }
    #endregion

    #region RFQ
    public void RFQ_Mst_Save(String flag, Int32 ID, DateTime RFQDate, DateTime RFQDeadline, DateTime DeliveryDate, String RFQNo, DateTime PODeadline, Int32 UID, String Session, String TermsCondition, Int32 InstID, ref Int32 RFQMstID, ref string RetSuccess)
    {
        try
        {
            RFQMasterSave_(flag, ID, RFQDate, RFQDeadline, DeliveryDate, RFQNo, PODeadline, UID, Session, TermsCondition, InstID, ref RFQMstID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void RFQ_Mst_Save(String flag, Int32 ID, DateTime RFQDate, DateTime RFQDeadline, DateTime DeliveryDate, String RFQNo, DateTime PODeadline, Int32 UID, String Session, String TermsCondition, Int32 InstID, ref Int32 RFQMstID, ref string RetSuccess, DBManager ObjDAL)
    {
        try
        {
            RFQMasterSave_(flag, ID, RFQDate, RFQDeadline, DeliveryDate, RFQNo, PODeadline, UID, Session, TermsCondition, InstID, ref RFQMstID, ref RetSuccess, ObjDAL);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void RFQ_Child_Save(String flag, Int32 RFQId, Int32 PRId, Decimal Qty, Int32 SupplierID, Decimal Tax, Decimal Discount, Decimal Price, Decimal Excise_Duty, Decimal Frieght, Decimal Insurance, String PaymentTerms, String DeliveryTerms, String Other, Int32 UID, String Session, Int32 InstID,Int32 Unit_Id, ref string RetSuccess)
    {
        try
        {
            RFQChildSave_(flag, RFQId, PRId, Qty, SupplierID, Tax, Discount, Price, Excise_Duty, Frieght, Insurance, PaymentTerms, DeliveryTerms, Other, UID, Session, InstID, Unit_Id, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    #endregion

    #region RFQ Sorting
    public void RFQ_Sorting(Int32 RFQId, Int32 SupplierID, Int32 PRId, Decimal Tax, Decimal Price, Decimal Excise_Duty, Decimal Frieght, Decimal Insurance, String PaymentTerms, String DeliveryTerms, String Other, Decimal Discount, DateTime Delivery_Date, String DelMode, Int32 InstID, Decimal CstVat, ref string RetSuccess)
    {
        RFQSorting_(RFQId, SupplierID, PRId, Tax, Price, Excise_Duty, Frieght, Insurance, PaymentTerms, DeliveryTerms, Other, Discount, Delivery_Date, DelMode, InstID, CstVat, ref RetSuccess);
    }
    //--------------------RFQ Sorting---------------------------------------------------------------

    public void RFQ_FinalSorting(Int32 RFQId, Int32 SupplierID, Int32 PRId, String Remark, Int32 InstID, ref string RetSuccess)
    {
        RFQSorting_(RFQId, SupplierID, PRId, Remark, InstID, ref RetSuccess);
    }
    //---------------------------------New Function for RFQ Sorting----------------------------------
    public void RFQSorting(DataMember.RFQ_Sorting ObjRFQ, ref String RetSuccess,DBManager ObjDal)
    {
        RFQ_Sorting_(ObjRFQ.flag, ObjRFQ.RFQID, ObjRFQ.SupplierID, ObjRFQ.Remark, ObjRFQ.InstId, ref RetSuccess, ObjDal);
    }
    #endregion

    #region File Save
    public void File_Save(Int32 RFQNo, Int32 SupplierID, String FileName, String FileType, Int32 InstID)
    {
        RFQFileSave_(RFQNo, SupplierID, FileName, FileType, InstID);
    }

    #endregion

    #region Challan Entry
    public void Challan_Mst_Save(String flag, Int32 ID, String Challan_NO, Decimal Tax_Per, Decimal Disc_Per, Decimal Subtotal, Decimal TaxAmt, Decimal DiscAmt, Decimal Shipping, Decimal Total_Payable, Decimal PaidAmt, Decimal BalanceAmt, DateTime ChallanDate, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, String ReceiptNo, Int32 InstID, ref Int32 ChallanIDRet, ref string RetSuccess)
    {
        ChallanMasterSave_(flag, ID, Challan_NO, Tax_Per, Disc_Per, Subtotal, TaxAmt, DiscAmt, Shipping, Total_Payable, PaidAmt, BalanceAmt, ChallanDate, Currency, EX_Rate, Session, UID, ReceiptNo, InstID, ref ChallanIDRet, ref RetSuccess);
    }
    public void Challan_Mst_Save(String flag, Int32 ID, String Challan_NO, Decimal Tax_Per, Decimal Disc_Per, Decimal Subtotal, Decimal TaxAmt, Decimal DiscAmt, Decimal Shipping, Decimal Total_Payable, Decimal PaidAmt, Decimal BalanceAmt, DateTime ChallanDate, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, String ReceiptNo, Int32 InstID, ref Int32 ChallanIDRet, ref string RetSuccess, String VehicleType, String VehicleNo, string invoice, SqlCommand com)
    {
        ChallanMasterSave_(flag, ID, Challan_NO, Tax_Per, Disc_Per, Subtotal, TaxAmt, DiscAmt, Shipping, Total_Payable, PaidAmt, BalanceAmt, ChallanDate, Currency, EX_Rate, Session, UID, ReceiptNo, InstID, ref ChallanIDRet, ref RetSuccess, VehicleType, VehicleNo, invoice, com);
    }
    public void Challan_Child_Save(String flag, Int32 ID, Int32 ChallanID, Int32 POId, Int32 Ctrl_Id, Decimal Qty, Decimal Price_Per_Qty, Decimal Amt, String Session, Int32 UID, Int32 InstID, Int32 PO_ChildID, Int32 Unit_Id, Boolean IsDamaged, Decimal DamagedQty, ref string RetSuccess)
    {
        ChallanChildSave_(flag, ID, ChallanID, POId, Ctrl_Id, Qty, Price_Per_Qty, Amt, Session, UID, InstID, PO_ChildID, Unit_Id, IsDamaged, DamagedQty, ref RetSuccess);
    }
    public void Challan_Child_Save(String flag, Int32 ID, Int32 ChallanID, Int32 POId, Int32 Ctrl_Id, Decimal Qty, Decimal Price_Per_Qty, Decimal Amt, String Session, Int32 UID, Int32 InstID, Int32 PO_ChildID, Int32 Unit_Id, Boolean IsDamaged, Decimal DamagedQty, ref string RetSuccess, Decimal TotalAmt, Boolean Is_Returnable, SqlCommand com)
    {
        ChallanChildSave_(flag, ID, ChallanID, POId, Ctrl_Id, Qty, Price_Per_Qty, Amt, Session, UID, InstID, PO_ChildID, Unit_Id, IsDamaged, DamagedQty, ref RetSuccess, TotalAmt, Is_Returnable, com);
    }
    public void Challan_File_Save(String flag, Int32 ChallanID, String FileName, String FileType, Int32 InstID)
    {
        Challan_File_Save_(flag, ChallanID, FileName, FileType, InstID);
    }
    public void Fill_Challan_Grid(String flag, Int32 ChallanID, Int32 InstID, ref DataTable dt, DBManager ObjDAL)
    {
        Fill_Challan_Grid_(flag, ChallanID, InstID, ref dt, ObjDAL);
    }
    public void View_PO_Details(String flag, Int32 POID, Int32 InstID, ref DataTable DT, DBManager ObjDAL)
    {
        View_PO_Details_(flag, POID, InstID, ref DT, ObjDAL);
    }
    #endregion

    #region Sorted Supplier
    public void Sort_Supplier(int InstId, int RFQId, int PRID,String SortedBy, String TextField, String ValueField, CheckBoxList ChkSupplier)
    {
        FillSupplier_(InstId, RFQId, PRID, SortedBy, TextField, ValueField, ChkSupplier);
    }
    #endregion

    #region Create Client Login
    public void Create_ClientLogin(int InstId, Int32 Id, String Pwd, String Salt, ref String RetSuccess)
    {
        try
        {
            Create_ClientLogin_(InstId, Id, Pwd, Salt, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    #endregion

    #region UOM
    public void UOM_Save(String flag, Int32 InstId, Int32 Id, String UOM_Name, String Short_Name, Int32 Primary_Unit, Decimal ConvrsionFactor, Int32 DecimalPlaces, ref string RetSuccess)
    {
        try
        {
            UnitSave_(flag, InstId, Id, UOM_Name, Short_Name, Primary_Unit, ConvrsionFactor, DecimalPlaces, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void UOM_Delete(Int32 InstId, Int32 Id, ref string RetSuccess)
    {
        try 
        {
            UnitDelete_(InstId, Id, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }

    public void UOM_Validate(Int32 InstId,Int32 Id, Int32 Primary_Unit, ref string RetSuccess)
    {
        try
        {
            UnitValidate_(InstId, Id, Primary_Unit, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }    

    //------------------------------Unit Convertion----------------------------------------
    public String Qty_Convertion(Int32 InstId, Int32 FromUnit, Int32 ToUnit, string Qty)
    {
        QtyConversion_(InstId, FromUnit, ToUnit, ref Qty);
        return Qty;       
    }    
    #endregion

    #region RFQ Box
    public DataTable RFQBox(DataTable dtRfq)
    {
        RFQBox_(ref dtRfq);
        return dtRfq;
    }
    
    public DataTable RFQSupplierDetails(Int32 RFQId, Int32 InstID, DataTable DTSuppRFQ)
    {
        RFQSupplierDetails_(RFQId, InstID, ref DTSuppRFQ);
        return DTSuppRFQ;
    }
    #endregion

    #region User Creation
    public void UserCreation_Save(String flag, Int32 InstId, Int32 UserId, String UserName, String Password, String Salt, Int32 InstituteID, Boolean Active, String UName, DateTime UEntDt, Int32 Emp_id, String User_Type, ref string RetSuccess)
    {
        try
        {
            UserCreation_Save_(flag, InstId, UserId, UserName, Password, Salt, InstituteID, Active, UName, UEntDt, Emp_id, User_Type, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void UserCreation_Delete( Int32 UserId, Int32 InstID, ref string RetSuccess)
    {
        try
        {
            UserCreation_Delete_(UserId, InstID, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    #endregion

    #region Vendor Code,Manufacturer Code, Company Code
    //.............................................Generate Vendor Code......................................
    public void Gen_VndrCode(int InstId, ref string VndrCode)
    {
        Gen_VndrCode_(InstId, ref VndrCode);
    }

    //.............................................Generate Manufacturer Code......................................
    public void Gen_ManuCode(int InstId, ref string ManuCode)
    {
        Gen_ManuCode_(InstId, ref ManuCode);
    }
    //.............................................Generate Company Code......................................
    public void Gen_CompCode(int InstId, ref string CompCode)
    {
        Gen_CompCode_(InstId, ref CompCode);
    }
    #endregion

    #region PrefixID
    public void PrefixSave(String flag, Int32 ID, String prefixtag, String prefixsting, Int32 maxid, Boolean Is_Active, Int32 InstId, ref string RetSuccess)
    {
        try
        {
            PrefixSave_(flag, ID, prefixtag, prefixsting, maxid, Is_Active, InstId, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public DataTable PrefixSelect(String fields, String where, DBManager ObjDAL)
    {
        DataTable dtPrefix = new DataTable();
        PrefixSelect_(fields, where, ObjDAL, ref dtPrefix);
        return dtPrefix;
    }
    public void PrefixSelect(String fields, String where, ref DBManager ObjDAL)
    {
        PrefixSelect_(fields, where, ref ObjDAL);
    }
    #endregion

    #region Get Unit
    public void Get_Units(int InstId, int UnitId, String TextField, String ValueField, DropDownList DDLID)
    {
        GetUnit_(InstId, UnitId, TextField, ValueField, DDLID);
    }
    #endregion

    #region Inventory Settings
    public void InvntSet_Save(String flag, Int32 ID, Int32 IndntPndDays, Int32 IssWtDays, Int32 ResWtDays, String BdgtAlloctWise, Int32 PmtDecPlaces, Int32 PrcDPlaces, Int32 QtyDPlaces, Int32 InstID, String POPerm_Users, ref string RetSuccess)
    {
        InvntSet_Save_(flag, ID, IndntPndDays, IssWtDays, ResWtDays, BdgtAlloctWise, PmtDecPlaces, PrcDPlaces, QtyDPlaces, InstID, POPerm_Users, ref RetSuccess);
    }
    public void InvntSet_Save(String flag, Int32 ID, Int32 IndntPndDays, Int32 IssWtDays, Int32 ResWtDays, String BdgtAlloctWise, Int32 PmtDecPlaces, Int32 PrcDPlaces, Int32 QtyDPlaces, Int32 InstID, ref string RetSuccess, DBManager ObjDAL)
    {
        try
        {
            InvntSet_Save_(flag, ID, IndntPndDays, IssWtDays, ResWtDays, BdgtAlloctWise, PmtDecPlaces, PrcDPlaces, QtyDPlaces, InstID, ref RetSuccess, ObjDAL);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void InvntSet_Select(String fields, String Where, ref DBManager ObjDAL)
    {
        base.InvntSet_Select_(fields, Where, ref ObjDAL);
    }
    //------------Fill Users In CheckBoxList-------------------------------
    public void InvntSet_FillUsers(String flag, Int32 InstID, Int32 RoleId, ref DBManager ObjDAL)
    {
        base.InvntSet_FillUsers_(flag, InstID, RoleId, ref ObjDAL);
    }
    #endregion

    #region Generating CTRLID
    public void Gen_CtrlID(String ProdCode, Int32 InstID, ref int CtrlID, SqlCommand com)
    {
        try
        {
            GenCtrlID_(ProdCode, InstID, ref CtrlID, com);
        }
        catch (Exception ex)
        {
            CtrlID = 0;
        }
    }
    #endregion

    #region Filling Location On Receving
    public DataTable Fill_Loc_Recev(Int32 CtrlID, Int32 InstID)
    {

        DataTable dtLoc_ = new DataTable();
        Fill_Loc_Recev_(CtrlID, InstID, ref dtLoc_);
        return dtLoc_;
    }
    #endregion

    #region Cataloguing Through Receving
    public void Cataloguing_Items(Int32 Rec_Mst_ID, Int32 Ctrl_Id, Int32 POID, Int32 UnitID, Decimal Qty, String BatchNo, String SerialNo, Int32 LocationID, String Year, Int32 InstID, ref string RetSuccess, SqlCommand com)
    {
        Catalogue_Save("N", 0, POID, Rec_Mst_ID, Ctrl_Id, BatchNo, SerialNo, LocationID, Year, string.Empty, InstID, Qty, UnitID, ref RetSuccess, com);
    }
    #endregion

    #region MultiProduct Indent
    //-----------------------------------Select Scrap Product Detail-----------------------------------
    public DataTable Get_ProdDetailScrapDept(Int32 InstID, int ID)
    {
        DataTable dtProd_ = new DataTable();
        Get_ProdDetailScrapDept_(InstID, ID, ref dtProd_);
        return dtProd_;
    }
    public DataTable Get_ProdDetailScrap(Int32 InstID, int CtrlID)
    {
        DataTable dtProd_ = new DataTable();
        Get_ProdDetailScrap_(InstID, CtrlID, ref dtProd_);
        return dtProd_;
    }
    //-----------------------------------Select Issue Product Detail-----------------------------------
    public DataTable Get_ProdDetailIssue(Int32 InstID, int CtrlID)
    {
        DataTable dtProd_ = new DataTable();
        Get_ProdDetailIssue_(InstID, CtrlID, ref dtProd_);
        return dtProd_;
    }
    //-----------------------------------Select Product Detail-----------------------------------
    public DataTable Get_ProdDetails(Int32 InstID, int CtrlID)
    {
        DataTable dtProd_ = new DataTable();
        Get_ProdDetails_(InstID, CtrlID, ref dtProd_);
        return dtProd_;
    }
    //-----------------------------------Fill Indent Detail in Grid-----------------------------------
    public DataTable Fill_Indent(Int32 InstID)
    {
        DataTable dtIndent_ = new DataTable();
        Fill_Indent_(InstID, ref dtIndent_);
        return dtIndent_;
    }
    //-----------------------------------Fill Indent Detail in Grid-----------------------------------
    public DataTable Get_IndentDetail(Int32 InstID,Int32 Id)
    {
        DataTable dtProdIndent_ = new DataTable();
        Get_IndentDetail_(InstID, Id, ref dtProdIndent_);
        return dtProdIndent_;
    }
    public DataTable Get_IssueDetail(Int32 InstID, Int32 Id)
    {
        DataTable dtProdIndent_ = new DataTable();
        Get_IssueLimitDetail_(InstID, Id, ref dtProdIndent_);
        return dtProdIndent_;
    }
    #endregion

    #region Direct Purchase Order
    public void POrder_Save(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, DateTime POExpctDate, ref Int32 PId, ref string RetSuccess, SqlCommand com)
    {
        try
        {
            DirectPOSave_(flag, InstId, POId, POCode, PODate, PO_Ref, Com_Manu_Ven_Id, Ship_Via, PMT_Type, Reference, PO_SubTotal, Discount_Perc, Shipping_Amt, Tax_Type, Tax_Amt, Tot_Payable_Amt, Balance_Amt, Paid_Amt, IsPaid, Status, IsArrived, Comment, Note, CurrencyId, POExpctDate, ref PId, ref RetSuccess, com);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    public void Gen_POrderNo(int InstId, ref string Order_No, SqlCommand com)
    {
        GenPONo_(InstId, ref Order_No, com);
    }
    public void POChlid_Save(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, ref string RetSuccess, SqlCommand com)
    {
        POChildSave_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, Deliv_Terms, Pmt_Terms, Other_Levies, CtrlID, DelMode, DelDate, ref RetSuccess, com);
    }
    //--------------------------------------------
    public void POChlid_Save(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, SqlCommand com)
    {
        POChildSave_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, Deliv_Terms, Pmt_Terms, Other_Levies, CtrlID, DelMode, DelDate, BalQty, ref RetSuccess, com);
    }
    //----------------------------------------------------
    public void POChlid_Save(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess,Int32 UserId, SqlCommand com)
    {
        POChildSave_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, Deliv_Terms, Pmt_Terms, Other_Levies, CtrlID, DelMode, DelDate, BalQty, ref RetSuccess, UserId, com);
    }
    //------------New PO Chlid Save Function(Add Discount Condition)----------------------------------------
    public void POChlidnaveen_Save(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, Int32 UserId,Boolean IsDisc_Perc, String Maker, SqlCommand com)
    {
        POChildSavenaveen_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, Deliv_Terms, Pmt_Terms, Other_Levies, CtrlID, DelMode, DelDate, BalQty, ref RetSuccess, UserId, IsDisc_Perc, Maker, com);
    }
    public void POChlid_Save(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, Int32 UserId, Boolean IsDisc_Perc, SqlCommand com)
    {
        POChildSave_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, Deliv_Terms, Pmt_Terms, Other_Levies, CtrlID, DelMode, DelDate, BalQty, ref RetSuccess, UserId, IsDisc_Perc, com);
    }
    //---------------------------------------------
    public DataTable DirectPO_Select(String flag, Int32 POID, Int32 InstID, DBManager ObjDAL)
    {
        DataTable dtProdDtls = new DataTable();
        DirectPO_Select_(flag, POID, InstID, ObjDAL, ref dtProdDtls);
        return dtProdDtls;
    }
    public void DirectPO_Select(String flag, Int32 POID, Int32 CtrlID, Int32 InstID, ref DBManager ObjDAL)
    {
        DirectPO_Select_(flag, POID, CtrlID, InstID, ref ObjDAL);
    }
    #endregion

    #region Setting Decimal Precision 
    public void Set_Dec_Places(String flag, ref Decimal Value, Int32 InstID)
    {
        Set_Dec_Places_(flag, ref Value, InstID);
    }
    public void Set_Dec_Places(String flag, ref Int32 RetResult, Int32 InstID)
    {
        Set_Dec_Places_(flag, ref RetResult, InstID);
    }
    #endregion

    #region Store Suppliers Detail
    //--------------------------Fill Supplier Grid------------------------
    public DataTable Get_SplrDetails(Int32 InstID, int SupplierId)
    {
        DataTable dtSupplier_ = new DataTable();
        Get_SplrDetails_(InstID, SupplierId, ref dtSupplier_);
        return dtSupplier_;
    }

    #endregion

    #region Fill ListBox in case of RFQ Creation
    public void FillCheckboxlist_SP(CheckBoxList chk, string TextFieldName, string ValueFieldName, string flag, Int32 VndrDtlsID)
    {
        FillCheckboxlist(chk, TextFieldName, ValueFieldName, flag, VndrDtlsID);
    }
    #endregion

    #region Filling Suppliers incase of Update
    public DataTable Fill_Supplier(int InstId, int PRID, int Ctrl_Id, int IndentID, ref DataTable dtSupp_)
    {
        DataTable dtSupp = new DataTable();
        Fill_Supp("G", InstId, PRID, Ctrl_Id, IndentID, ref dtSupp);
        return dtSupp;
    }
    public DataTable Fill_Supplier(int InstId, int PRID, int Ctrl_Id,  ref DataTable dtSupp_)
    {

        DataTable dtSupp = new DataTable();
        Fill_Supp("G", InstId, PRID, Ctrl_Id, ref dtSupp);
        return dtSupp;
    }
    #endregion

    #region Filling PR Details incase of Update
    public DataTable Fill_PRDtls(int InstId, int PR_Mst_Id)
    {

        DataTable dtPR = new DataTable();
        Fill_PRDtls_("S", InstId, PR_Mst_Id, ref dtPR);
        return dtPR;
    }
    public void PR_Del( Int32 InstId, Int32 PR_Mst_Id,  ref string RetSuccess)
    {
        try
        {
            PR_Del_("D", InstId, PR_Mst_Id, ref RetSuccess);
        }
        catch (Exception ex)
        {
            RetSuccess = "0";
        }
    }
    #endregion

    #region RFQ Search & Update
    public DataTable Fill_RFQDtls(String flag,int InstId, int RFQId)
    {
        DataTable dtRFQ = new DataTable();
        Fill_RFQDtls_(flag, InstId, RFQId, ref dtRFQ);
        return dtRFQ;
    }    
    //----------------------------------------------------------------------
    public void Fill_RFQDtls(String flag, int InstId, int RFQId, ref List<DataMember.RFQ_Arrival> RFQItems)
    {
        NewDAL.DBManager ObjDAL = ReturnDALConString();
        Fill_RFQDtls_(flag, InstId, RFQId, ref ObjDAL);
        while (ObjDAL.DataReader.Read())
        {
            Decimal Qty = 0;
            var RFQ_Items = new DataMember.RFQ_Arrival();
            RFQ_Items.ID = Int32.Parse(ObjDAL.DataReader["ID"].ToString());
            RFQ_Items.PRID = Int32.Parse(ObjDAL.DataReader["PRID"].ToString());
            RFQ_Items.RFQID = Int32.Parse(ObjDAL.DataReader["RFQID"].ToString());
            RFQ_Items.SupplierID = Int32.Parse(ObjDAL.DataReader["SupplierID"].ToString());
            Qty = Decimal.Parse(ObjDAL.DataReader["Qty"].ToString());
            Set_Dec_Places_("Q", ref Qty, InstId, "Q");
            RFQ_Items.qty = Qty;
            RFQ_Items.prod_name = ObjDAL.DataReader["Prod_Name"].ToString();
            RFQ_Items.AddRelation = ObjDAL.DataReader["AddRelation"].ToString();
            RFQ_Items.SupplierName = ObjDAL.DataReader["vendor_name"].ToString();
            RFQ_Items.Tax = Decimal.Parse(ObjDAL.DataReader["Tax"].ToString());
            RFQ_Items.Discount = Decimal.Parse(ObjDAL.DataReader["Discount"].ToString());
            RFQ_Items.Excise_Duty = Decimal.Parse(ObjDAL.DataReader["Excise_Duty"].ToString());
            RFQ_Items.Frieght = Decimal.Parse(ObjDAL.DataReader["Frieght"].ToString());
            RFQ_Items.Insurance = Decimal.Parse(ObjDAL.DataReader["Insurance"].ToString());
            RFQ_Items.DeliveryTerms = ObjDAL.DataReader["DeliveryTerms"].ToString();
            RFQ_Items.Other = ObjDAL.DataReader["Other"].ToString();
            RFQ_Items.Price = Decimal.Parse(ObjDAL.DataReader["Price"].ToString());
            RFQ_Items.DeliveryDate = DateTime.Parse(ObjDAL.DataReader["DeliveryDate"].ToString());
            RFQ_Items.Unit_Id = Int32.Parse(ObjDAL.DataReader["Unit_Id"].ToString());
            RFQ_Items.UOM_Name = ObjDAL.DataReader["UOM_Name"].ToString();
            RFQItems.Add(RFQ_Items);
        }
        ObjDAL.Close();
        ObjDAL.Dispose();
    }
    //---------------Fill Sort RFQ Details--------------------------------------------
    public void Fill_SortRFQDtls(String flag, int InstId, int RFQId,String SortedBy, ref List<DataMember.RFQ_Sorting> RFQItems)
    {
        NewDAL.DBManager ObjDAL = ReturnDALConString();
        Fill_SortRFQDtls_(flag, InstId, RFQId, SortedBy, ref ObjDAL);        
        while (ObjDAL.DataReader.Read())
        {
            var RFQ_Items = new DataMember.RFQ_Sorting();
            RFQ_Items.RFQID = Int32.Parse(ObjDAL.DataReader["RFQID"].ToString());
            RFQ_Items.SupplierID = Int32.Parse(ObjDAL.DataReader["SupplierID"].ToString());            
            RFQ_Items.SupplierName = ObjDAL.DataReader["vendor_name"].ToString();
            RFQ_Items.Total_PayAmt = Decimal.Parse(ObjDAL.DataReader["Total_PayAmt"].ToString());
            RFQ_Items.DeliveryDate = DateTime.Parse(ObjDAL.DataReader["DelDate"].ToString());
            RFQ_Items.Is_Sorted = Boolean.Parse(ObjDAL.DataReader["is_Sorted"].ToString());
            RFQ_Items.Remark = ObjDAL.DataReader["Remark"].ToString();
            RFQItems.Add(RFQ_Items);
        }
        ObjDAL.Close();
        ObjDAL.Dispose();
    }
    //---------------Fill Sort RFQ Detailed Chart--------------------------------------------
    public void Fill_SortRFQChart(String flag, int InstId, int RFQId, String SortedBy, ref List<DataMember.RFQ_Sorting> RFQItems)
    {
        NewDAL.DBManager ObjDAL = ReturnDALConString();
        Fill_SortRFQDtls_(flag, InstId, RFQId, SortedBy, ref ObjDAL);
        
        while (ObjDAL.DataReader.Read())
        {
            var RFQ_Items = new DataMember.RFQ_Sorting();
            RFQ_Items.RFQID = Int32.Parse(ObjDAL.DataReader["RFQID"].ToString());
            RFQ_Items.SupplierID = Int32.Parse(ObjDAL.DataReader["SupplierID"].ToString());
            RFQ_Items.SupplierName = ObjDAL.DataReader["vendor_name"].ToString();
            RFQ_Items.Total_PayAmt = Decimal.Parse(ObjDAL.DataReader["Total_PayAmt"].ToString());
            RFQ_Items.DeliveryDate = DateTime.Parse(ObjDAL.DataReader["DelDate"].ToString());
            RFQ_Items.Price = Decimal.Parse(ObjDAL.DataReader["Price"].ToString());
            RFQ_Items.ExciseDuty = Decimal.Parse(ObjDAL.DataReader["ExciseDuty"].ToString());
            RFQ_Items.CstVat = Decimal.Parse(ObjDAL.DataReader["CstVat"].ToString());
            RFQ_Items.Shipping = Decimal.Parse(ObjDAL.DataReader["Shipping"].ToString());
            RFQ_Items.DelTerms = ObjDAL.DataReader["DelTerms"].ToString();
            RFQ_Items.PmtTerms = ObjDAL.DataReader["PmtTerms"].ToString();
            RFQItems.Add(RFQ_Items);
        }
        ObjDAL.Command.Parameters.Clear();
        ObjDAL.Close();
        ObjDAL.Dispose();
    }
    //--------------------------------------------------------------------------------
    public void Fill_RFQDtls(String flag, int InstId, int RFQId, ref DBManager ObjDAL)
    {
        Fill_RFQDtls_(flag, InstId, RFQId, ref ObjDAL);
    }
    //---------------------------------------------------------------------------------
    public void Fill_RFQDtls(String flag, int InstId, int RFQId, ref List<DataMember.RFQ_Arrival> RFQItems,DBManager ObjDAL)
    {
        Fill_RFQDtls_(flag, InstId, RFQId, ref ObjDAL);

        while (ObjDAL.DataReader.Read())
        {
            var RFQ_Items = new DataMember.RFQ_Arrival();
            RFQ_Items.RFQID = Int32.Parse(ObjDAL.DataReader["RFQID"].ToString());
            RFQ_Items.SupplierID = Int32.Parse(ObjDAL.DataReader["SupplierID"].ToString());
            RFQ_Items.SupplierName = ObjDAL.DataReader["SupplierName"].ToString();
            RFQ_Items.DeliveryMode = ObjDAL.DataReader["DelMode"].ToString();
            RFQ_Items.DeliveryDate = DateTime.Parse(ObjDAL.DataReader["DelDate"].ToString());
            RFQ_Items.Excise_Duty = Decimal.Parse(ObjDAL.DataReader["ExciseDuty"].ToString());
            RFQ_Items.CstVat = Decimal.Parse(ObjDAL.DataReader["CstVat"].ToString());
            RFQ_Items.Frieght = Decimal.Parse(ObjDAL.DataReader["Shipping"].ToString());
            RFQ_Items.DeliveryTerms = ObjDAL.DataReader["DelTerms"].ToString();
            RFQ_Items.PaymentTerms = ObjDAL.DataReader["PmtTerms"].ToString();
            RFQ_Items.Other = ObjDAL.DataReader["OtherTerms"].ToString();
            
            RFQItems.Add(RFQ_Items);
        }
    }
    //---------------------------------------------------------------------------------
    public void RFQArrvl_Update(Int32 RFQID, Int32 PRID, Int32 InstId, ref string RetSuccess)
    {
        RFQArrvl_Update_("A", RFQID, PRID, InstId, ref RetSuccess);
    }
    //---------------------------------------------------------------------------------
    public void RFQArrvl_Update(String flag, Int32 InstId,Int32 RFQID, Int32 SupplierID,  ref string RetSuccess, DBManager ObjDal)
    {
        RFQArrvl_Update_(flag, InstId, RFQID, SupplierID, ref RetSuccess, ObjDal);
    }
    //---------------------------------------------------------------------------------
    public void Get_OthSuppDtls_(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, ref DBManager ObjDAL)
    {
        GetOthSuppDtls_(flag, InstId, RFQID, SupplierID, ref ObjDAL);
    }
    public void Get_OthSuppDtls_(String flag, Int32 RFQID, Int32 SupplierID, ref DataTable dt, DBManager ObjDAL)
    {
        GetOthSuppDtls_(flag, RFQID, SupplierID, ref dt, ObjDAL);
    }
    //-------------------Get Items Details of a RFQ---------------------------------
    public void GetItmDtls(String flag,Int32 InstId, Int32 RFQID, ref DBManager ObjDAL)
    {
        GetItmDtls_(flag, InstId, RFQID, ref ObjDAL);
    }
    //---------------------------------------------------------------------------------
    public void GetItmDtls(String flag, int InstId, int RFQId, ref List<DataMember.RFQ_Arrival> RFQItems, DBManager ObjDAL)
    {
        GetItmDtls_(flag, InstId, RFQId, ref ObjDAL);

        while (ObjDAL.DataReader.Read())
        {
            var RFQ_Items = new DataMember.RFQ_Arrival();
            RFQ_Items.RFQID = Int32.Parse(ObjDAL.DataReader["RFQID"].ToString());
            RFQ_Items.SupplierID = Int32.Parse(ObjDAL.DataReader["SupplierID"].ToString());
            RFQ_Items.PRID = Int32.Parse(ObjDAL.DataReader["PRID"].ToString());
            RFQ_Items.Price = Decimal.Parse(ObjDAL.DataReader["Price"].ToString());           
            RFQ_Items.Tax = Decimal.Parse(ObjDAL.DataReader["Tax"].ToString());
            RFQ_Items.Discount = Decimal.Parse(ObjDAL.DataReader["Discount"].ToString());
            RFQ_Items.Insurance = Decimal.Parse(ObjDAL.DataReader["Insurance"].ToString());
            RFQ_Items.qty = Decimal.Parse(ObjDAL.DataReader["Qty"].ToString());
            RFQ_Items.UOM_Name = ObjDAL.DataReader["UOM_Name"].ToString();
            RFQ_Items.IsDisc_Perc = Boolean.Parse(ObjDAL.DataReader["IsDisc_Perc"].ToString());
            RFQItems.Add(RFQ_Items);
        }
    }
    //---------------------------------------------------------------------------------
    #endregion

    #region Damaged Goods Management
    public DataTable Fill_Prod_Details_Grid(String flag, Int32 ID, DBManager ObjDAL, Int32 InstID)
    {
        DataTable dtProd_ = new DataTable();
        FillProdDetailsGrid_(flag, ID, ref dtProd_, ObjDAL, InstID);
        return dtProd_;
    }

    public void DamagedQtyAmt(String flag, Int32 RecvMstID, Int32 InstID, DBManager ObjDAL)
    {
        Damaged_Qty_Amt_(flag, RecvMstID, InstID, ObjDAL); 
    }
    #endregion

    #region Search & Update Purchase Order
    public DataTable Fill_PODtls(String flag, int InstId, int POId)
    {
        DataTable dtPO = new DataTable();
        Fill_PODtls_(flag, InstId, POId, ref dtPO);
        return dtPO;
    }

    #endregion

    #region Search & Update Challan Entry
    public DataTable Fill_ChallanDtls(String flag, int InstId, int Id)
    {
        DataTable dtChallan = new DataTable();
        Fill_ChallanDtls_(flag, InstId, Id, ref dtChallan);
        return dtChallan;
    }
    #endregion

    #region Search & Fill Cataloguing Detail
    public DataTable Fill_CatlgDtls(String flag, int InstId, int Id,int Ctrl_Id,int Location)
    {
        DataTable dtCatlg = new DataTable();
        Fill_CatlgDtls_(flag, InstId, Id, Ctrl_Id, Location, ref dtCatlg);
        return dtCatlg;
    }
    #endregion

    #region Check Budget Balance of a Institute
    public DataTable Fill_BgtBal(String flag, int InstId)
    {
        DataTable dtBgt = new DataTable();
        Fill_BgtBal_(flag, InstId, ref dtBgt);
        return dtBgt;
    }

    #endregion

    #region Department
    public void DeptMstSave(String flag, Int32 Table_Id, Int32 DepartmentID, String DepartmentName, String Shortname, String Mark_Del, Int32 InstituteID, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        DeptMstSave_(flag, Table_Id, DepartmentID, DepartmentName, Shortname, Mark_Del, InstituteID, SessionID, UserID, UEDate, ref RetSuccess);
    }

    public void FillDeptGrid(String flag, Int32 InstituteID, ref DataTable dtDept)
    {
        FillDeptGrid_(flag, InstituteID, ref dtDept);
    }

    public void DeptMstDelete(String flag, Int32 DepartmentId, Int32 InstituteID, ref string RetSuccess)
    {
        DeptMstDelete_(flag, DepartmentId, InstituteID, ref RetSuccess);
    }
    #endregion

    #region Saving Records in PO Creation Table
    public void PO_Create_Save_(String flag, Int32 POID, String FileName, String FileType, Int32 InstID)
    {
        PO_Create_Save(flag, POID, FileName, FileType, InstID);
    }
    public void Fill_Grid_File_PO(String flag, Int32 POID, Int32 InstID, ref DataTable dtFile)
    {
        Fill_Grid_File_PO_(flag, POID, InstID, ref dtFile);
    }
    #endregion

    #region Stock Reports
    public void Fill_Stock_Dtls(String Query, ref DataTable dt)
    {
        Fill_Stock_Dtls_(Query, ref dt);
    }
    #endregion

    #region Getting College Details For Reports
    public void Get_Collg_Dtls(Int32 InstID, ref DBManager ObjDAL)
    {
        Get_Collg_Dtls_(InstID, ref ObjDAL);
    }
    #endregion

    #region Direct PO Through Indent
    public void FillProdDetailsPO(String flag, Int32 IndentID, Int32 InstID, ref DBManager ObjDAL)
    {
        FillProdDetails_PO_(flag, IndentID, InstID, ref ObjDAL);
    }
    #endregion

    #region Site Master
    public void Site_Master_Save(String flag, Int32 ID, String SiteName, String Address, String ContactPerson, String ContactNo, Int32 InstID, ref String RetSuccess)
    {
        Site_Master_Save_(flag, ID, SiteName, Address, ContactPerson, ContactNo, InstID, ref RetSuccess);
    }
    public void FillGrid_(String flag, Int32 InstID, ref DataTable dt)
    {
        FillGrid(flag, InstID, ref dt);
    }
    public void Site_Delete(String flag, Int32 ID, Int32 InstID, ref String RetSuccess)
    {
        Site_Delete_(flag, ID, InstID, ref RetSuccess);
    }
    #endregion

    #region Saving Records in Mat_Issue_File Table
    public void MatIssueFile_Save(String flag, String Issue_No, String FileName, String FileType, Int32 InstID)
    {
        MatIssueFile_Save_(flag, Issue_No, FileName, FileType, InstID);
    }
    public void Fill_Grid_File_Issue(String flag, String Issue_No, Int32 InstID, ref DataTable dtFile)
    {
        Fill_Grid_File_Issue_(flag, Issue_No, InstID, ref dtFile);
    }
    #endregion

    #region Saving Records in Indent_Files Table
    public void IndentFile_Save(String flag, Int32 IndentId, String FileName, String FileType, Int32 InstID)
    {
        IndentFile_Save_(flag, IndentId, FileName, FileType, InstID);
    }
    public void Fill_Grid_File_Indent(String flag, Int32 IndentId, Int32 InstID, ref DataTable dtFile)
    {
        Fill_Grid_File_Indent_(flag, IndentId, InstID, ref dtFile);
    }
    #endregion

    #region Fill Product Detail of same Indent
    public void FillIndentProd(String flag, Int32 Id, Int32 InstID, ref DataTable dtProd)
    {
        FillIndentProd_(flag, Id, InstID, ref dtProd);
    }
    #endregion

    #region Saving Records in Indent_Files Table
    public void MatRecvFile_Save(String flag, Int32 Id, String FileName, String FileType, Int32 InstID)
    {
        MatRecvFile_Save_(flag, Id, FileName, FileType, InstID);
    }
    public void Fill_Grid_File_MatRecv(String flag, Int32 Id, Int32 InstID, ref DataTable dtFile)
    {
        Fill_Grid_File_MatRecv_(flag, Id, InstID, ref dtFile);
    }
    #endregion

    #region Direct PO Updating
    public void Direc_PO_Select(String flag, Int32 POID, Int32 InstID, ref DBManager ObjDAL)
    {
        Direc_PO_Select_(flag, POID, InstID, ref ObjDAL);
    }
    public void Direct_PO_Update(String flag, Int32 POID, Int32 InstID, Decimal ShippingAmt, String Comment, Decimal ExciseDuty, String Type_C_V, Decimal CstVat, Int32 SiteID, Boolean Status, ref String RetSuccess, SqlCommand com)
    {
        Direct_PO_Update_(flag, POID, InstID, ShippingAmt, Comment, ExciseDuty, Type_C_V, CstVat, SiteID, Status, ref RetSuccess, com);
    }
    //-----------------------------------------------------
    public void Direct_PO_Update(String flag, Int32 POID, Int32 InstID, Decimal ShippingAmt, String Comment, Decimal ExciseDuty, String Type_C_V, Decimal CstVat, Int32 SiteID, Boolean Status, ref String RetSuccess, Int32 UserId, String TermsCondition, Decimal Tot_Payable_Amt, SqlCommand com)
    {
        Direct_PO_Update_(flag, POID, InstID, ShippingAmt, Comment, ExciseDuty, Type_C_V, CstVat, SiteID, Status, ref RetSuccess, UserId, TermsCondition, Tot_Payable_Amt, com);
    }
    #endregion

    #region Check PO is Approved or not
    public void POChk_Apprv(String flag, Int32 POId, Int32 InstID, ref DataTable dtPO)
    {
        POChk_Apprv_(flag, POId, InstID, ref dtPO);
    }
    #endregion

    #region Search PO 
    public void SearchPO(String flag, String Condition, ref DataTable dtPO)
    {
        SearchPO_(flag, Condition, ref dtPO);
    }

    public void FillPOItem_Detail(String flag, Int32 POId,Int32 InstId, ref DataTable dtPO)
    {
        FillPOItem_Detail_(flag, POId, InstId, ref dtPO);
    }
    #endregion

    #region PO Write Off Searching
    public void POWriteOffSearch(String flag, String Condition, ref DataTable dt, DBManager ObjDAL)
    {
        POWriteOffSearch_(flag, Condition, ref dt, ObjDAL);
    }
    public void Fill_Detail(String flag, Int32 POCId, Int32 InstId, ref DataTable dtPO)
    {
        FillPO_Detail_(flag, POCId, InstId, ref dtPO);
    }
    public void POUpdate(String flag, Int32 POID, Int32 InstID, Boolean WriteOFF, ref String RetSuccess)
    {
        POUpdate_(flag, POID, InstID, WriteOFF, ref RetSuccess);
    }
    #endregion

    #region Update Budget & Client Balance
    public void Update_Bal(String flag, Int32 POID, Int32 InstID,  Int32 UserId, ref String RetSuccess, SqlCommand com)
    {
        Update_Bal_(flag, POID, InstID,  UserId,ref RetSuccess,  com);
    }
    #endregion

    #region Generate Member Id
    public void Gen_MemId(Int32 InstId, ref String MemberId)
    {
        Gen_MemId_(InstId, ref MemberId);
    }
    #endregion

    #region Cash Purchase File Save
    public void Cash_Pur_File_Save(Int32 POID, Int32 Recev_Mst_ID, String FileName, String FileType, Int32 InstID)
    {
        Cash_Pur_File_Save_(POID, Recev_Mst_ID, FileName, FileType, InstID);
    }
    public void Fill_Grid_CP_File(Int32 POID, Int32 Recev_Mst_ID, Int32 InstID, ref DataTable dt)
    {
        Fill_Grid_CP_File_(POID, Recev_Mst_ID, InstID, ref dt);
    }
    #endregion

    #region Purchase Group
    public void PurchaseGrSave(String flag, Int32 ID, String Mem_Gr_Name, String Mem_Sh_Name, Boolean IsTimeLimit, DateTime FrmDate, DateTime ToDate, Decimal SPOAmt, Decimal MPOAmt, Decimal CSPOAmt, Decimal CMPOAmt, Int32 UID, String Session, Int32 InstID, ref String RetSuccess)
    {
        PurchaseGrSave_(flag, ID, Mem_Gr_Name, Mem_Sh_Name, IsTimeLimit, FrmDate, ToDate, SPOAmt, MPOAmt, CSPOAmt, CMPOAmt, UID, Session, InstID, ref RetSuccess);
    }

    public void PurchaseGrSelect(String flag, Int32 InstID, String fields, String Where, ref DataTable dtPGrp)
    {
        PurchaseGrSelect_(flag, InstID ,fields, Where, ref dtPGrp);
    }

    public void PurchaseGrDel(String flag, Int32 ID, Int32 InstID, ref String RetSuccess)
    {
        PurchaseGrDel_(flag, ID, InstID, ref RetSuccess);
    }
    #endregion

    public void IndentIssue_Limit(String flag, Int32 Ctrl_Id, Int32 DeptId, Int32 InstId, DateTime IndentDate, Decimal Qty, Int32 Unit_Id, ref String IsSuccess)
    {
        IndentIssueLimit_(flag, Ctrl_Id, DeptId, InstId, IndentDate, Qty, Unit_Id, ref IsSuccess);
    }

    #region Check Purchasing Group Limitations
    public String PurchaseGrLimit(String flag, String POType, Int32 UserId, Int32 InstId, DateTime PODate, Decimal TotalPOAmt,Int32 POID, ref String IsSuccess)
    {
        String RetMsg = string.Empty, ValidRange=string.Empty;
        PurchaseGrLimit_(flag,POType, UserId, InstId, PODate, TotalPOAmt, POID, ref IsSuccess, ref ValidRange);
        if (IsSuccess == "T")
        {
            RetMsg = "PO Can not be created at this date.Valid Range:" + ValidRange;
        }
        Int32 RetResult = 0;
        Set_Dec_Places("P", ref RetResult, InstId);
        if (IsSuccess == "S")
        {           
            RetMsg = "Total PO amount can not exceed the Single PO purchase group limit(" + Decimal.Parse(ValidRange).ToString("F" + RetResult) + ")";
        }
        if (IsSuccess == "M")
        {
            RetMsg = "Total PO amount can not exceed this User Balance(" + Decimal.Parse(ValidRange).ToString("F" + RetResult) + ")";
        }
        if (IsSuccess == "C")
        {
            RetMsg = "Total PO amount can not exceed the Single Cash Purchase group limit(" + Decimal.Parse(ValidRange).ToString("F" + RetResult) + ")";
        }
        if (IsSuccess == "P")
        {
            RetMsg = "Total PO amount can not exceed the Mutiple Cash Purchase Balance(" + Decimal.Parse(ValidRange).ToString("F" + RetResult) + ")";
        }
        return RetMsg;
    }
    #endregion

    #region Item Return
    public void Item_Return_Save(String flag, Int32 ChallanID, Int32 ChallanChldID, Int32 Ctrl_ID, Decimal Qty, Int32 UnitID, DateTime ReturnDate, String MRC, Int32 UID, String Session, Int32 InstID, Int32 StoreID, String Note, String VehicleNo, String VehicleType, ref String RetSuccess)
    {
        Item_Return_Save_(flag, ChallanID, ChallanChldID, Ctrl_ID, Qty, UnitID, ReturnDate, MRC, UID, Session, InstID, StoreID, Note, VehicleNo, VehicleType, ref RetSuccess);
    }
    public void Fill_Returnable_Itm(String flag, Int32 ChallanID, Int32 InstID, ref DBManager ObjDAL)
    {
        Fill_Returnable_Itm_(flag, ChallanID, InstID, ref ObjDAL);
    }
    public void Gen_MRC_(Int32 InstID, String prefixtag, ref string MRC)
    {
        Gen_MRC(InstID, prefixtag, ref MRC);
    }
    public void Fill_Location(Int32 CtrlID, Int32 InstID, ref DataTable dtLoc_)
    {
        Fill_Location_(CtrlID, InstID, ref dtLoc_);
    }
    public void MatRetFile_Save(String flag, String MRC, String FileName, String FileType, Int32 InstID)
    {
        MatRetFile_Save_(flag, MRC, FileName, FileType, InstID);
    }
    public void FillGrid_FileItmRet(String flag, String MRC, Int32 InstID, ref DataTable dtFile)
    {
        FillGrid_FileItmRet_(flag, MRC, InstID, ref  dtFile);
    }
    #endregion

    #region GateEntry
    public void GetMrc_Dtls_(String flag, String MRC, Int32 InstID, ref DBManager ObjDAL)
    {
        GetMrcDtls(flag, MRC, InstID, ref ObjDAL);
    }
    public void Gate_EntrySave(String flag, String ItemsID, Int32 InstID, ref String RetSuccess)
    {
        Gate_Entry_Save_(flag, ItemsID, InstID, ref RetSuccess);
    }
    #endregion

    #region Checking PO Permission To User
    public void ChkPoPerm_(Int32 UserID, String PageName, ref String RetResult, SqlConnection con)
    {
        ChkPoPerm(UserID, PageName, ref RetResult, con);
    }
    #endregion

    #region Getting Pending PO Details
    public void Get_PendingPO(Int32 UserID, Int32 InstID, ref List<DataMember.PendingPO> GetPendingPO)
    {
        Get_Pending_PO_(UserID, InstID, ref GetPendingPO);
    }   
    #endregion

    #region Get Dept Indent Regs
    public void DeptIndent_Regs(String flag, Int32 InstID, String Condition, ref DataTable dt)
    {
        DeptIndent_Regs_(flag, InstID, Condition, ref dt);
    }
    #endregion


    #region Drug_Store

    public void Drug_Store_Save(String flag, String DrugSt_ID, String DrugSt_Name, String DrugSt_Short_Name, int Floor, String Address, String BuildingName, String BuildShName, Int32 St_Typ, String Mrk_Del, String Owner, String License_No, Int32 InstituteID, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        try
        {
            Drug_StoreSave_(flag, DrugSt_ID, DrugSt_Name, DrugSt_Short_Name, Floor, Address, BuildingName, BuildShName, St_Typ, Mrk_Del, Owner, License_No, InstituteID, SessionID, UserID, UEDate, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Drug_StoreChld_Save(String flag, String DrugSt_ID, String Mrk_Del, String User, String User_Nm, int Bill_Chrg_Id, Int32 InstituteID, String SessionID, String UserID, DateTime UEDate, int St_Type, ref string RetSuccess)
    {
        try
        {
            Drug_StoreChldSave_(flag, DrugSt_ID, Mrk_Del, User, User_Nm, Bill_Chrg_Id, InstituteID, SessionID, UserID, UEDate, St_Type, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Drug_Store_Delete(Int32 DrugSt_ID, Int32 InstituteID, ref string RetSuccess)
    {
        try
        {
            Drug_StoreDelete_(DrugSt_ID, InstituteID, ref RetSuccess);
        }
        catch (Exception ex)
        { RetSuccess = "0"; }
    }
    public void Drug_Store_Select(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        Drug_StoreSelect_(flag, Fields, Where, ref ObjDAL);
    }
    public DataTable Drug_Store_Grd_Fill(Int32 InstituteID, DBManager ObjDAL)
    {
        DataTable drugst_dt = new DataTable();
        string SQL = "SELECT DrugSt_ID,DrugSt_Name,DrugSt_Short_Name FROM [Hsp_Drug_Store] WHERE InstituteID = '" + InstituteID + "'";
        Drug_StoreGrdFill_(SQL, ref drugst_dt, ObjDAL);
        return drugst_dt;
    }

    public void Drug_StoreDtl(DBManager ObjDAL, string Query)
    {
        Drug_Store_FeeSelect(ref ObjDAL, Query);
    }
    #endregion

    #region Drug Sell Detail
    public void Pt_Dtl_Grid(DBManager ObjDAL, ref DataTable Pt_Dtl, string Query)
    {

        Pt_DtlGrid(ObjDAL, ref Pt_Dtl, Query);
    }
    public void Details(DBManager ObjDAL, string Query)
    {
        Details_(ref ObjDAL, Query);
    }

    public void DrugSell_OthSave(String flag, int Id, String F_Name, String M_Name, String L_Name, String Customer_Id, String FF_Name, String FL_Name, String Gender, String Age, DateTime DOB, int Country, int State, int City, String S_no, String Telephone, String District, int instituteId, String SessionID, String UserID, DateTime UEDate, String Mrk_Del, String Bill_Id, ref string RetSuccess)
    {

        DrugSell_Dtl_Oth_Save(flag, Id, F_Name, M_Name, L_Name, Customer_Id, FF_Name, FL_Name, Gender, Age, DOB, Country, State, City, S_no, Telephone, District, instituteId, SessionID, UserID, UEDate, Mrk_Del, Bill_Id, ref RetSuccess);

    }

    public void DrugSellSave(String flag, int ID, String Drug_St_Id, int Prod_Id, String Prod_Code, String Reg_Id, String Patient_Id, String Customer_Id, decimal Qty, decimal Price, String Bill_Id, String Mrk_Del, int instituteId, String SessionID, String UserID, DateTime UEDate, decimal Stoc_Bal, int Refund, String Old_Bl_No, decimal Unit_Price, decimal Ref_Amt, int St_Typ, ref string RetSuccess)
    {

        DrugSell_Save(flag, ID, Drug_St_Id, Prod_Id, Prod_Code, Reg_Id, Patient_Id, Customer_Id, Qty, Price, Bill_Id, Mrk_Del, instituteId, SessionID, UserID, UEDate, Stoc_Bal, Refund, Old_Bl_No, Unit_Price, Ref_Amt, St_Typ, ref RetSuccess);

    }
    public void Pt_MedUPD(String flag, String Bill_Id, decimal Adj_Amt, String Is_Clear, int instituteId, ref string RetSuccess)
    {

        Pt_Med_UPD(flag, Bill_Id, Adj_Amt, Is_Clear, instituteId, ref RetSuccess);

    }

    public void Pt_Med_BllSave(String flag, int ID, String Bill_Id, String Reg_Id, String Patient_Id, String Customer_Id, int Is_Pt, decimal Bill_Amt, DateTime Bl_Dt_Tm, decimal Tax, decimal Service_chrg, int instituteId, String SessionID, String UserID, DateTime UEDate, decimal Paid_Amt, int Rt_Id, int Cp, String Drug_St_Id, int St_Typ, String Orig_Bill_No, decimal Tot_Ref_Amt, int Refund, int Pay_Mode, int Cr_Room, decimal Bal_Amt, String Mrk_Del, String Is_Clear, decimal Return_Amt, decimal Tot_Bill_Amt, decimal Tot_Bill_Paid, ref string RetSuccess)
    {

        Pt_Med_Bll_Save(flag, ID, Bill_Id, Reg_Id, Patient_Id, Customer_Id, Is_Pt, Bill_Amt, Bl_Dt_Tm, Tax, Service_chrg, instituteId, SessionID, UserID, UEDate, Paid_Amt, Rt_Id, Cp, Drug_St_Id, St_Typ, Orig_Bill_No, Tot_Ref_Amt, Refund, Pay_Mode, Cr_Room, Bal_Amt, Mrk_Del, Is_Clear, Return_Amt, Tot_Bill_Amt, Tot_Bill_Paid, ref RetSuccess);

    }
    public void Pay_RecSave(String flag, int PayR_ID, String Rpt_No, DateTime Pay_D, String Pay_T, int Pay_M, decimal Amt_P, String Reg_Id, String Patient_Id, String Customer_Id, String Amt_Flag, String Mrk_Del, int instituteId, String SessionID, String UserID, DateTime UEDate, int Rt_Id, ref string RetSuccess)
    {

        Pay_Rec_Save(flag, PayR_ID, Rpt_No, Pay_D, Pay_T, Pay_M, Amt_P, Reg_Id, Patient_Id, Customer_Id, Amt_Flag, Mrk_Del, instituteId, SessionID, UserID, UEDate, Rt_Id, ref RetSuccess);

    }

    public void Drug_Bill_StatusSave(String flag, int ID, String Drug_St_Id, int St_Typ, String Reg_Id, String Patient_Id, String Customer_Id, int Rt_Id, String Bill_Id, decimal Bill_Amt, decimal Paid_Amt, decimal Bal_Amt, String Bill_Status, decimal Ref_Amt, String Old_Bl_No, int Is_Pt, int Refund, String Mrk_Del, int instituteId, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {

        Drug_Bill_Status_Save(flag, ID, Drug_St_Id, St_Typ, Reg_Id, Patient_Id, Customer_Id, Rt_Id, Bill_Id, Bill_Amt, Paid_Amt, Bal_Amt, Bill_Status, Ref_Amt, Old_Bl_No, Is_Pt, Refund, Mrk_Del, instituteId, SessionID, UserID, UEDate, ref RetSuccess);

    }

    #endregion

    #region DrugMst
    public void Drug_Mst_Save(string flag, Int32 Drug_Id, string Drug_Nm, string Drug_Desc, Int32 InstituteID, string SessionID, string UserID, ref string RetSuccess)
    {

        DrugMst_Save(flag, Drug_Id, Drug_Nm, Drug_Desc, InstituteID, SessionID, UserID, ref RetSuccess);

    }


    public void Drug_Mst_Select(string sql_qry, ref DBManager ObjDAL)
    {
        Drug_MstSelect(sql_qry, ref ObjDAL);
    }



    #endregion

    #region Refund_Medi
    public void Reg_Mst_Select(string sql_qry, ref DBManager ObjDAL)
    {
        Reg_MstSelect(sql_qry, ref ObjDAL);
    }
    public void grd_Fill_Select(string sql_qry, DBManager ObjDAL, ref DataSet dtType)
    {
        grd_Mst_FillGrd(sql_qry, ref dtType, ObjDAL);

    }
    public void grd_Filldt_Select(string sql_qry, DBManager ObjDAL, ref DataTable dtType)
    {
        grd_Mst_Filldt(sql_qry, ref dtType, ObjDAL);

    }
    public void Ref_Adj_Dtl(String flag, int Table_Id, int Adj_Id, String Reg_Id, String Patient_Id, String Customer_Id, String Adjed_Bl_Id, String Adjing_Bl_Id, decimal Adj_Amt, int instituteId, String SessionID, String UserID, DateTime UEDate, decimal Return_Amt, int Is_Pt, String Drug_St_Id, int St_Typ, int Refund, ref string RetSuccess)
    {

        Ref_AdjDtl(flag, Table_Id, Adj_Id, Reg_Id, Patient_Id, Customer_Id, Adjed_Bl_Id, Adjing_Bl_Id, Adj_Amt, instituteId, SessionID, UserID, UEDate, Return_Amt, Is_Pt, Drug_St_Id, St_Typ, Refund, ref  RetSuccess);

    }
    public void Drg_No_Dues(String flag, String Reg_Id, String Patient_Id, String Customer_Id, int instituteId, String SessionID, String UserID, DateTime UEDate, String Drug_St_Id, int St_Typ, int Rt_Id, ref string RetSuccess)
    {

        Drg_NoDues(flag, Reg_Id, Patient_Id, Customer_Id, instituteId, SessionID, UserID, UEDate, Drug_St_Id, St_Typ, Rt_Id, ref  RetSuccess);

    }
    #endregion

    #region CompMst
    public void Comp_Mst_Save(string flag, Int32 comp_id, string comp_name, string drugs, Int32 comp_detail_id, Int32 InstituteID, string SessionID, string UserID, ref string RetSuccess)
    {

        CompMst_Save(flag, comp_id, comp_name, drugs, comp_detail_id, InstituteID, SessionID, UserID, ref RetSuccess);

    }
    public void Comp_Mst_Dup(string sql_qry, ref DBManager ObjDAL)
    {
        Comp_MstDup(sql_qry, ref ObjDAL);
    }
    public void Comp_Mst_Select(string sql_qry, ref DBManager ObjDAL)
    {
        Comp_MstSelect(sql_qry, ref ObjDAL);
    }

    #endregion

    #region Prod_Mst
    public void Prod_Mst_Save(string flag, Int32 Medi_Id, string Medi_Nm, string Medi_Comp, string Mrk_Del, Int32 InstituteID, string SessionID, string UserID, Int32 Prod_Typ_Id, Int32 Prod_Cat_Id, Int32 Table_id, ref string RetSuccess)
    {
        ProdMst_Save(flag, Medi_Id, Medi_Nm, Medi_Comp, Mrk_Del, InstituteID, SessionID, UserID, Prod_Typ_Id, Prod_Cat_Id, Table_id, ref RetSuccess);
    }

    public void Prod_Mst_Select(string sql_qry, ref DBManager ObjDAL)
    {
        Prod_MstSelect(sql_qry, ref ObjDAL);
    }


    #endregion

    #region IMT
    public List<DataMember.IMT> IMT_FillGrid_(DataMember.IMT ObjIMT)
    { 
        //NewDAL.DBManager ObjDb = null;
        var ListItems = new List<DataMember.IMT>();
       
        ObjDb=IMT_FillGrid(ObjIMT.flag,ObjIMT.FromStore,ObjIMT.InstId);
        while (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.IMT();
            Item.Ctrl_Id =Int32.Parse(ObjDb.DataReader["Ctrl_Id"].ToString()==string.Empty?"0":ObjDb.DataReader["Ctrl_Id"].ToString());
            Item.Prod_Code = ObjDb.DataReader["Prod_Code"].ToString();
            Item.Prod_Name = ObjDb.DataReader["Prod_Name"].ToString();
            Item.Stock_Bal =Decimal.Parse(ObjDb.DataReader["Stock_Bal"].ToString()==string.Empty?"0":ObjDb.DataReader["Stock_Bal"].ToString());
            Item.UOM_Name = ObjDb.DataReader["UOM_Name"].ToString();
            Item.UnitId = Int32.Parse(ObjDb.DataReader["Unit_Id"].ToString()==string.Empty?"0":ObjDb.DataReader["Unit_Id"].ToString());
            ListItems.Add(Item);
        }
        return ListItems;
    }
    public String Gen_IMT_No(Int32 InstId,DBManager ObjDal)
    {
        String IMT_No = string.Empty;
       IMT_No= Gen_IMT_No_(InstId, IMT_No, ObjDal);
        return IMT_No;
    }
    public String IMT_Save_Mst(DataMember.IMT ObjIMT,ref Int32 IMT_Mst_Id, DBManager ObjDal)
    {
        String RetSuccess = string.Empty;
        IMT_Save_Mst_(ObjIMT.flag, ObjIMT.Id, ObjIMT.InstId, ObjIMT.IMT_No, ObjIMT.IMT_Date, ObjIMT.FromOrg, ObjIMT.ToOrg, ObjIMT.FromStore, ObjIMT.ToStore, ObjIMT.UserId, ref IMT_Mst_Id, ref RetSuccess, ObjDal);
        return RetSuccess;
    }
    public String IMT_Save_Child(DataMember.IMT ObjIMT, Int32 IMT_Mst_Id, DBManager ObjDal)
    {
        String RetSuccess = string.Empty;
        IMT_Save_Child_(ObjIMT.flag, IMT_Mst_Id,ObjIMT.InstId, ObjIMT.Ctrl_Id, ObjIMT.IMT_Qty, ObjIMT.UnitId, ObjIMT.FromOrg, ObjIMT.ToOrg, ObjIMT.FromStore, ObjIMT.ToStore, ref RetSuccess, ObjDal);
        return RetSuccess;
    }
    #endregion

    #region RFQ Report
    public void GetRfqDtls(Int32 RFQId, Int32 InstID, Int32 SupplierID, DBManager ObjDAL, ref DataTable DT)
    {
        GetRfqDtls_(RFQId, InstID, SupplierID, ObjDAL, ref DT);
    }
    #endregion

    #region RFQ Arrival Entry
    //-------------Save RFQ Item Detail-------------------------------
    public void RFQArvl_ItemSave(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, Int32 PRID, Decimal Price, Decimal Tax, Decimal Discount, Decimal Insurance, Boolean IsDisc_Perc, ref String RetSuccess, DBManager ObjDb)
    {
        RFQArvl_ItemSave_(flag, InstId, RFQID, SupplierID, PRID, Price, Tax, Discount, Insurance,IsDisc_Perc, ref RetSuccess, ObjDb);
    }
    //-------------Save RFQ Supplier Detail-------------------------------
    public void RFQArvl_SuppSave(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, String DeliveryMode, DateTime Delivery_Date, Decimal Excise_Duty, Decimal CstVat, Decimal Frieght, String DeliveryTerms, String PaymentTerms, String Other, ref String RetSuccess, NewDAL.DBManager ObjDb)
    {
        RFQArvl_SuppSave_(flag, InstId, RFQID, SupplierID, DeliveryMode, Delivery_Date, Excise_Duty, CstVat, Frieght, DeliveryTerms, PaymentTerms, Other, ref RetSuccess, ObjDb);
    }
    #endregion

    #region Get All Arrived Suppliers
    public void Get_ArvdSupp(String flag, Int32 InstId, String Condition, ref List<DataMember.RFQ_Sorting> ListItems)
    {
        ObjDb = ReturnDALConString();
        Get_ArvdSupp_(flag, InstId, Condition, ref ObjDb);
        while (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.RFQ_Sorting();
            Item.RFQID = Int32.Parse(ObjDb.DataReader["RFQID"].ToString() == string.Empty ? "0" : ObjDb.DataReader["RFQID"].ToString());
            Item.RFQNo = ObjDb.DataReader["RFQNo"].ToString();
            ListItems.Add(Item);
        }
        ObjDb.Command.Parameters.Clear();
        ObjDb.Close();
        ObjDb.Dispose();
    }
    #endregion

    #region PO Through RFQ
    //------------------Get Items Details of a RFQ for PO--------------------------
    public void GetItmDtls_PO(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, ref List<DataMember.RFQ_PO> ListItems)
    {
        ObjDb = ReturnDALConString();
        Int32 DecPlaces = 0;
        Set_Dec_Places("Q", ref DecPlaces, InstId);
        GetItmDtls_PO_(flag, InstId, RFQID, SupplierID, ref ObjDb);
        if(ObjDb.DataReader.NextResult())        
        while (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.RFQ_PO();
            Item.RFQChildID = Int32.Parse(ObjDb.DataReader["ID"].ToString() == string.Empty ? "0" : ObjDb.DataReader["ID"].ToString());
            Item.CtrlID = Int32.Parse(ObjDb.DataReader["Ctrl_Id"].ToString());
            Item.Prod_Name = ObjDb.DataReader["Prod_Name"].ToString();
            Item.Quantity = Decimal.Parse(Decimal.Parse(ObjDb.DataReader["Qty"].ToString()).ToString("F" + DecPlaces));
            Item.Unit_Id = Int32.Parse(ObjDb.DataReader["Unit_Id"].ToString());
            Item.UOM_Name = ObjDb.DataReader["UOM_Name"].ToString();
            Item.Price = Decimal.Parse(ObjDb.DataReader["Price"].ToString());
            Item.Tax = Decimal.Parse(ObjDb.DataReader["Tax"].ToString());
            Item.Discount = Decimal.Parse(ObjDb.DataReader["Discount"].ToString());
            Item.Insurance = Decimal.Parse(ObjDb.DataReader["Insurance"].ToString());
            Item.TotalPrice = Decimal.Parse(ObjDb.DataReader["PayableAmt"].ToString());
            Item.Excise_Duty = Decimal.Parse(ObjDb.DataReader["ExciseDuty"].ToString());
            Item.CstVat = Decimal.Parse(ObjDb.DataReader["CstVat"].ToString());
            Item.Frieght = Decimal.Parse(ObjDb.DataReader["Shipping"].ToString());
            Item.DeliveryDate = DateTime.Parse(ObjDb.DataReader["DelDate"].ToString());
            Item.DeliveryMode = ObjDb.DataReader["DelMode"].ToString();
            Item.DeliveryTerms = ObjDb.DataReader["DelTerms"].ToString();
            Item.PaymentTerms = ObjDb.DataReader["PmtTerms"].ToString();
            Item.Other = ObjDb.DataReader["OtherTerms"].ToString();
            Item.IsDisc_Perc = Boolean.Parse(ObjDb.DataReader["IsDisc_Perc"].ToString());
            Item.Disc_Perc = ObjDb.DataReader["Disc_Perc"].ToString();
            Item.Disc_Amt = Decimal.Parse(ObjDb.DataReader["Disc_Amt"].ToString());
            ListItems.Add(Item);
        }
        ObjDb.Command.Parameters.Clear();
        ObjDb.Close();
        ObjDb.Dispose();
    }
    //------------------Get Items Details on PO Search--------------------------
    public void GetDtls_POSrch(String flag, Int32 InstId, Int32 POID, ref List<DataMember.RFQ_PO> ListItems)
    {
        ObjDb = ReturnDALConString();
        Int32 DecPlaces = 0;
        Set_Dec_Places("Q", ref DecPlaces, InstId);
        GetDtls_POSrch_(flag, InstId, POID, ref ObjDb);
        if (ObjDb.DataReader.NextResult())
            while (ObjDb.DataReader.Read())
            {
                var Item = new DataMember.RFQ_PO();
                Item.RFQChildID = Int32.Parse(ObjDb.DataReader["ID"].ToString() == string.Empty ? "0" : ObjDb.DataReader["ID"].ToString());
                Item.POID = Int32.Parse(ObjDb.DataReader["POID"].ToString());
                Item.CtrlID = Int32.Parse(ObjDb.DataReader["Ctrl_Id"].ToString());
                Item.Prod_Name = ObjDb.DataReader["Prod_Name"].ToString();
                Item.Quantity = Decimal.Parse(Decimal.Parse(ObjDb.DataReader["Quantity"].ToString()).ToString("F" + DecPlaces));
                Item.Unit_Id = Int32.Parse(ObjDb.DataReader["Unit_Id"].ToString());
                Item.UOM_Name = ObjDb.DataReader["UOM_Name"].ToString();
                Item.Price = Decimal.Parse(ObjDb.DataReader["Price_Total"].ToString());
                Item.Tax = Decimal.Parse(ObjDb.DataReader["Tax"].ToString());
                Item.Discount = Decimal.Parse(ObjDb.DataReader["Discount"].ToString());
                Item.Insurance = Decimal.Parse(ObjDb.DataReader["Insurance"].ToString());
                Item.TotalPrice = Decimal.Parse(ObjDb.DataReader["PayableAmt"].ToString());
                Item.Excise_Duty = Decimal.Parse(ObjDb.DataReader["Excise_Duty"].ToString());
                Item.CstVat = Decimal.Parse(ObjDb.DataReader["CstVat"].ToString());
                Item.Frieght = Decimal.Parse(ObjDb.DataReader["Frieght"].ToString());
                Item.DeliveryDate = DateTime.Parse(ObjDb.DataReader["DeliveryDate"].ToString());
                Item.DeliveryMode = ObjDb.DataReader["DeliveryMode"].ToString();
                Item.DeliveryTerms = ObjDb.DataReader["Deliv_Terms"].ToString();
                Item.PaymentTerms = ObjDb.DataReader["Pmt_Terms"].ToString();
                Item.Other = ObjDb.DataReader["Other_Levies"].ToString();
                Item.SupplierID = Int32.Parse(ObjDb.DataReader["SupplierID"].ToString());
                Item.SupplierName = ObjDb.DataReader["vendor_name"].ToString();
                Item.CurrencyId = Int32.Parse(ObjDb.DataReader["CurrencyId"].ToString());
                Item.BankRate = Decimal.Parse(ObjDb.DataReader["BankRate"].ToString());
                Item.POCode = ObjDb.DataReader["POCode"].ToString();
                Item.PODate = DateTime.Parse(ObjDb.DataReader["PODate"].ToString());
                Item.RFQNo = ObjDb.DataReader["RFQNo"].ToString();
                Item.RFQID = Int32.Parse(ObjDb.DataReader["RFQID"].ToString());
                Item.Status = Boolean.Parse(ObjDb.DataReader["Status"].ToString());
                Item.TermsConds = ObjDb.DataReader["TermsCondition"].ToString();
                Item.SiteName = ObjDb.DataReader["SiteName"].ToString();
                Item.SiteID = Int32.Parse(ObjDb.DataReader["SiteID"].ToString());
                Item.Comment = ObjDb.DataReader["Comment"].ToString();
                Item.IsDisc_Perc = Boolean.Parse(ObjDb.DataReader["IsDisc_Perc"].ToString());
                Item.Disc_Perc = ObjDb.DataReader["Disc_Perc"].ToString();
                Item.Disc_Amt = Decimal.Parse(ObjDb.DataReader["Disc_Amt"].ToString());
                ListItems.Add(Item);
            }
        ObjDb.Command.Parameters.Clear();
        ObjDb.Close();
        ObjDb.Dispose();
    }
    //-------------------------Save RFQ PO Master--------------------------------------------
    public void RFQ_POSave(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, Decimal Shipping_Amt, Decimal Tot_Payable_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, ref Int32 PId, ref string RetSuccess, Decimal Excise_Duty, String Type_C_V, Decimal CstVat, Int32 SiteID, Int32 UserId, String TermsCondition, String Session,Int32 SupplierID, DBManager ObjDAL)
    {
        RFQ_POSave_(flag, InstId, POId, POCode, PODate, Shipping_Amt, Tot_Payable_Amt, Paid_Amt, IsPaid, Status, IsArrived, Comment, Note, CurrencyId, ref  PId, ref  RetSuccess, Excise_Duty, Type_C_V, CstVat, SiteID, UserId, TermsCondition, Session, SupplierID, ObjDAL);
    }
    //-------------------------Save RFQ PO Child----------------------------------------------
    public void RFQ_POChildSave(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, Int32 UserId,Boolean IsDisc_Perc, NewDAL.DBManager ObjDAL)
    {
        RFQ_POChildSave_(flag, InstId, POId, RFQChild_Id, Quantity, Price_Per_Unit, Price_Total, Tax_Amt, Discount, Frieght, Insurance, Excise_Duty, Price_Tax_Total, Unit_Id, Deliv_Terms, Pmt_Terms, Other_Levies, CtrlID, DelMode, DelDate, BalQty, ref  RetSuccess, UserId, IsDisc_Perc, ObjDAL);
    }
    //------------------Get Items Details of a RFQ for PO--------------------------
    public void Fill_POFileGrid(String flag, Int32 InstId, Int32 POID, ref List<DataMember.RFQ_PO> ListItems)
    {
        ObjDb = ReturnDALConString();
        Fill_POFileGrid_(flag, InstId, POID, ref ObjDb);
        while (ObjDb.DataReader.Read())
        {
            var Item = new DataMember.RFQ_PO();
            Item.SupplierName = ObjDb.DataReader["vendor_name"].ToString();
            Item.POCode = ObjDb.DataReader["POCode"].ToString();
            Item.FileName = ObjDb.DataReader["FileName"].ToString();
            Item.FileType = ObjDb.DataReader["FileType"].ToString();
            ListItems.Add(Item);
        }
        ObjDb.Command.Parameters.Clear();
        ObjDb.Close();
        ObjDb.Dispose();
    }
    #endregion
    #region  Update Client Status
    public void Update_ClientStatus(String flag, Int32 InstID, String Status,String Condition,ref String RetSuccess, DBManager ObjDAL)
    {
        base.Update_ClientStatus_(flag, InstID, Status, Condition, ref RetSuccess, ObjDAL);

    }
    #endregion

    #region Fill Grid
    public void Fill_Grid<T>(List<T> ListName, String SP_Name, String flag, Int32 InstId, String Condition, GridView GrdVwId, DBManager ObjDAL) where T : new()
    {        
        Fill_Grid_(SP_Name, flag, InstId, Condition, ref ObjDAL);
        //Type type = typeof(T);
        //while (ObjDAL.DataReader.Read())
        //{
        //    T item = (T)Activator.CreateInstance(type);
            
        //    // Get all the properties of the type
        //    PropertyInfo[] properties = ((Type)item.GetType()).GetProperties();

        //    for (int j = 0; j < ObjDAL.DataReader.FieldCount; j++)
        //    {
        //        for (int k = 0; k < properties.Length; k++)
        //        {
        //            if (ObjDAL.DataReader.GetName(j) == properties[k].Name)
        //            {
        //                properties[j].SetValue(item, ObjDAL.DataReader[j], null);
        //            }
        //        }
        //    }
        //    ListName.Add(item);
        //}
       // ListName = (List<T>)((SqlDataReader)ObjDAL.DataReader).Cast<T>();
        BindGridView<T>(ListName, GrdVwId);        
    }
    #endregion

    #region Get Unit,File Name incase of Direct PO
    //--------------Get Unit,File Name incase of Direct PO-------------------
    public void Get_DPOInfo(String flag, Int32 POID, Int32 InstID, ref String Result)
    {
        Get_DPOInfo_(flag, POID, InstID, ref Result);
    }
    //--------------Get Unit,File Name incase of Direct PO-------------------
    public void Get_DPOUnitRate(String flag, Int32 POID, Int32 InstID, ref String UnitId,ref String Rate)
    {
        base.Get_DPOUnitRate_(flag, POID, InstID, ref UnitId,ref Rate);
    }
    #endregion

    #region Stock Detail Report
    public void Get_StockDtlRpt(String flag, Int32 InstID, String Fields, String Condition, ref DBManager ObjDal)
    {
        Get_StockDtlRpt_(flag, InstID, Fields, Condition, ref ObjDal);
    }
    #endregion

    public DataTable FillEnquiryReport(int CategoryID, int CompositionID, int TypeID, int InstID, int flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        try
        {
            objDB.CreateParameters(5);
            //objDB.AddParameters(0, "ID", ID, DbType.Int32);
            objDB.AddParameters(0, "CategoryID", CategoryID, DbType.Int32);
            objDB.AddParameters(1, "CompositionID", CompositionID, DbType.Int32);
            objDB.AddParameters(2, "TypeID", TypeID, DbType.Int32);
            objDB.AddParameters(3, "InstID", InstID, DbType.Int32);
            objDB.AddParameters(4, "flag", flag, DbType.Int32);
            dt = objDB.ExecuteTable(CommandType.StoredProcedure, "enquiry_select");
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillEnquiry(string qry)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        try
        {
            objDB.CreateParameters(1);
            objDB.AddParameters(0, "qry", qry, DbType.String);
            //objDB.AddParameters(1, "flag", flag, DbType.Int32);
            dt = objDB.ExecuteTable(CommandType.Text, "select Prod_Name,Name,Category,Composition from StockDetail_VW " + qry);
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Connection.Dispose();
            objDB.Dispose();
        }
        return dt;
    }

    public DataTable FillInventoryProduct(int Prod_Code, string Prod_Name, decimal IssueQty, DateTime FromDate, DateTime ToDate, int InstID, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "Prod_Code", Prod_Code, DbType.Int32);
        objDB.AddParameters(1, "Prod_Name", Prod_Name, DbType.String);
        objDB.AddParameters(2, "IssueQty", IssueQty, DbType.Decimal);
        objDB.AddParameters(3, "FromDate", FromDate, DbType.DateTime);
        objDB.AddParameters(4, "ToDate", ToDate, DbType.DateTime);
        objDB.AddParameters(5, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(6, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "stock_select");
        return dt;
    }

    public DataTable FillDepartmentIssue(int Indent_Code, string Prod_Name, string UserName, decimal Qty, decimal IssueQty, int InstID, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(7);
        objDB.AddParameters(0, "Indent_Code", Indent_Code, DbType.Int32);
        objDB.AddParameters(1, "Prod_Name", Prod_Name, DbType.String);
        objDB.AddParameters(2, "UserName", UserName, DbType.String);
        objDB.AddParameters(3, "Qty", Qty, DbType.Decimal);
        objDB.AddParameters(4, "IssueQty", IssueQty, DbType.Decimal);
        objDB.AddParameters(5, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(6, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "DepartmentIssue_select");
        return dt;
    }
    public DataTable FillDepartment(int Indent_Code, string Prod_Name, string UserName, decimal Qty, decimal IssueQty, DateTime FromDate, DateTime ToDate, int InstID, int flag)
    {

        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(9);
        objDB.AddParameters(0, "Indent_Code", Indent_Code, DbType.Int32);
        objDB.AddParameters(1, "Prod_Name", Prod_Name, DbType.String);
        objDB.AddParameters(2, "UserName", UserName, DbType.String);
        objDB.AddParameters(3, "Qty", Qty, DbType.Decimal);
        objDB.AddParameters(4, "IssueQty", IssueQty, DbType.Decimal);
        objDB.AddParameters(5, "FromDate", FromDate, DbType.DateTime);
        objDB.AddParameters(6, "ToDate", ToDate, DbType.DateTime);
        objDB.AddParameters(7, "InstID", InstID, DbType.Int32);
        objDB.AddParameters(8, "flag", flag, DbType.Int32);
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "DepartmentIssue_select");
        return dt;
    }

}
