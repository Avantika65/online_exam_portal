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
using System.Collections.Generic;

/// <summary>
/// Summary description for DataMember
/// </summary>


namespace DataMember
{
    public abstract class BaseEntity
    {
    }

    [Serializable]
    [DataContract]
    public class Product: BaseEntity
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Product_Name { get; set; }

        [DataMember]
        public string Requester { get; set; }

        [DataMember]
        public Decimal Quantity { get; set; }

        [DataMember]
        public String Date { get; set; }

        [DataMember]
        public Boolean Is_Read { get; set; }

        [DataMember]
        public String Status { get; set; }

        [DataMember]
        public int IndentId { get; set; }

    }

    [Serializable]
    [DataContract]
    public class PendingPO
    {
        //[DataMember]
        //public Int32 POID { get; set; }

        [DataMember]
        public String POCode { get; set; }

        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public String Supplier { get; set; }

        [DataMember]
        public String FileName { get; set; }

        [DataMember]
        public String FileType { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RFQDetails : BaseEntity
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public String RFQNo { get; set; }

        [DataMember]
        public String RFQDate { get; set; }

        [DataMember]
        public String Supplier { get; set; }

        [DataMember]
        public String Filename { get; set; }

        [DataMember]
        public String Filetype { get; set; }

        [DataMember]
        public int SupplierID { get; set; }
    }
    
    [Serializable]
    [DataContract]
    public class PagedResult<T> where T : BaseEntity
    {
        public int Total;
        public List<T> Rows;
    }

    #region Inter Material Transfer
    [Serializable]
    [DataContract]
    public class IMT
    {
        [DataMember]
        public String flag { get; set; }

        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String IMT_No { get; set; }

        [DataMember]
        public DateTime IMT_Date { get; set; }

        [DataMember]
        public Int32 FromOrg { get; set; }

        [DataMember]
        public Int32 ToOrg { get; set; }

        [DataMember]
        public Int32 FromStore { get; set; }

        [DataMember]
        public Int32 ToStore { get; set; }

        [DataMember]
        public Int32 UserId { get; set; }

        [DataMember]
        public Int32 InstId { get; set; }

        [DataMember]
        public Int32 Ctrl_Id { get; set; }

        [DataMember]
        public Decimal IMT_Qty { get; set; }

        [DataMember]
        public Int32 UnitId { get; set; }
              
        [DataMember]
        public String RetSuccess { get; set; }

        [DataMember]
        public String Prod_Code { get; set; }

        [DataMember]
        public String Prod_Name { get; set; }

        [DataMember]
        public Decimal Stock_Bal { get; set; }

        [DataMember]
        public String UOM_Name { get; set; }
    }
    #endregion


    #region RFQ Arrival Entry
    [Serializable]
    [DataContract]
    public class RFQ_Arrival
    {
        [DataMember]
        public String flag { get; set; }

        [DataMember]
        public Int32 InstId { get; set; }

        [DataMember]
        public Int32 ID { get; set; }

        [DataMember]
        public Int32 PRID { get; set; }

        [DataMember]
        public Int32 RFQID { get; set; }

        [DataMember]
        public Int32 SupplierID { get; set; }

        [DataMember]
        public String prod_name { get; set; }

        [DataMember]
        public Decimal qty { get; set; }

        [DataMember]
        public String AddRelation { get; set; }

        [DataMember]
        public String SupplierName { get; set; }

        [DataMember]
        public Decimal Price { get; set; }

        [DataMember]
        public Decimal Tax { get; set; }

        [DataMember]
        public Decimal Excise_Duty { get; set; }

        [DataMember]
        public String Other { get; set; }

        [DataMember]
        public Decimal Frieght { get; set; }

        [DataMember]
        public Decimal Insurance { get; set; }

        [DataMember]
        public String PaymentTerms { get; set; }

        [DataMember]
        public String DeliveryTerms { get; set; }

        [DataMember]
        public Decimal Discount { get; set; }

        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public String UOM_Name { get; set; }

        [DataMember]
        public Int32 Unit_Id { get; set; }

        [DataMember]
        public String DeliveryMode { get; set; }

        [DataMember]
        public Decimal CstVat { get; set; }

        [DataMember]
        public Boolean IsDisc_Perc { get; set; }
    }
    #endregion

    #region RFQ Sorting
    [Serializable]
    [DataContract]
    public class RFQ_Sorting
    {
        [DataMember]
        public String flag { get; set; }

        [DataMember]
        public Int32 InstId { get; set; }

        [DataMember]
        public Int32 RFQID { get; set; }

        [DataMember]
        public Int32 SupplierID { get; set; }              
       
        [DataMember]
        public String SupplierName { get; set; }

        [DataMember]
        public Decimal Total_PayAmt { get; set; }
                
        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public String Remark { get; set; }

        [DataMember]
        public Decimal Price { get; set; }

        [DataMember]
        public Decimal ExciseDuty { get; set; }

        [DataMember]
        public Decimal CstVat { get; set; }

        [DataMember]
        public Decimal Shipping { get; set; }

        [DataMember]
        public String DelTerms { get; set; }

        [DataMember]
        public String PmtTerms { get; set; }

        [DataMember]
        public String RFQNo { get; set; }

        [DataMember]
        public Boolean Is_Sorted { get; set; }           
    }
    #endregion

    #region RFQ Purchase Order
    [Serializable]
    [DataContract]
    public class RFQ_PO
    {
        [DataMember]
        public String flag { get; set; }

        [DataMember]
        public Int32 InstId { get; set; }

        [DataMember]
        public Int32 POID { get; set; }

        [DataMember]
        public Int32 POCID { get; set; }

        [DataMember]
        public Int32 RFQChildID { get; set; }

        [DataMember]
        public String POCode { get; set; }

        [DataMember]
        public DateTime PODate { get; set; }

        [DataMember]
        public Int32 SupplierID { get; set; }

        [DataMember]
        public Decimal Quantity { get; set; }

        [DataMember]
        public String SupplierName { get; set; }

        [DataMember]
        public Decimal Price { get; set; }

        [DataMember]
        public Decimal Tax { get; set; }

        [DataMember]
        public Decimal Excise_Duty { get; set; }

        [DataMember]
        public String Other { get; set; }

        [DataMember]
        public Decimal Frieght { get; set; }

        [DataMember]
        public Decimal Insurance { get; set; }

        [DataMember]
        public String PaymentTerms { get; set; }

        [DataMember]
        public String DeliveryTerms { get; set; }

        [DataMember]
        public Decimal Discount { get; set; }

        [DataMember]
        public DateTime DeliveryDate { get; set; }

        [DataMember]
        public String UOM_Name { get; set; }

        [DataMember]
        public Int32 Unit_Id { get; set; }

        [DataMember]
        public String DeliveryMode { get; set; }

        [DataMember]
        public Decimal CstVat { get; set; }

        [DataMember]
        public Decimal TotalPrice { get; set; }

        [DataMember]
        public Int32 CtrlID { get; set; }

        [DataMember]
        public String Prod_Name { get; set; }

        [DataMember]
        public Int32 CurrencyId { get; set; }

        [DataMember]
        public Decimal BankRate { get; set; }

        [DataMember]
        public String RFQNo { get; set; }

        [DataMember]
        public Int32 RFQID { get; set; }

        [DataMember]
        public Boolean Status { get; set; }

        [DataMember]
        public String TermsConds { get; set; }

        [DataMember]
        public String SiteName { get; set; }

        [DataMember]
        public Int32 SiteID { get; set; }

        [DataMember]
        public String Comment { get; set; }

        [DataMember]
        public String FileName { get; set; }

        [DataMember]
        public String FileType { get; set; }

        [DataMember]
        public Boolean IsDisc_Perc { get; set; }

        [DataMember]
        public Decimal Disc_Amt { get; set; }

        [DataMember]
        public String Disc_Perc { get; set; }
    }
    #endregion

    #region Budget
    [Serializable]
    [DataContract]
    public class Budget
    {
        [DataMember]
        public String flag { get; set; }

        [DataMember]
        public int Budget_Id { get; set; }

        [DataMember]
        public String Budget_name { get; set; }

        [DataMember]
        public DateTime Applied_date { get; set; }

        [DataMember]
        public Decimal Applied_Amt { get; set; }

        [DataMember]
        public String Budget_For { get; set; }

        [DataMember]
        public Int32 Budget_For_Id { get; set; }

        [DataMember]
        public Decimal Allocated_Amt { get; set; }

        [DataMember]
        public Int32 Ledger_Id { get; set; }

        [DataMember]
        public String Applied_Doc_Name { get; set; }

        [DataMember]
        public String FType { get; set; }

        [DataMember]
        public String FileName { get; set; }

        [DataMember]
        public Decimal Sanction_Amt { get; set; }

        [DataMember]
        public DateTime Sanction_Date { get; set; }

        [DataMember]
        public String sanctioned_Doc_name { get; set; }

        [DataMember]
        public Int32 Fund_Source_Id { get; set; }

        [DataMember]
        public String Sanction_Number { get; set; }

        [DataMember]
        public Decimal Balance { get; set; }
    }
    #endregion
}
