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
/// <summary>
/// Summary description for AccountDAL
/// </summary>
public class AccountDAL
{
    public string ExecuteAccMaster(Int32 VoucherID, Int32 TransID, Int32 AccountID, decimal AmountDR, decimal AmountCR, Int32 RaccountID, DateTime VoucherDate, string Inarration, string Nature, Int32 InstituteID, string Session, string ReferenceID, string ReferenceTYpe, string flag,NewDAL.DBManager objDB)
    {
        string ret = "";
        
        try
        {
            objDB.CreateParameters(14);
            objDB.AddParameters(0, "VoucherID", VoucherID, DbType.Int32);
            objDB.AddParameters(1, "TransID", TransID, DbType.Int32);
            objDB.AddParameters(2, "AccountID", AccountID, DbType.Int32);
            objDB.AddParameters(3, "AmountDR", AmountDR, DbType.Decimal);
            objDB.AddParameters(4, "AmountCR", AmountCR, DbType.Decimal);
            objDB.AddParameters(5, "RaccountID", RaccountID, DbType.Int32);
            objDB.AddParameters(6, "VoucherDate", VoucherDate, DbType.DateTime);
            objDB.AddParameters(7, "Inarration", Inarration, DbType.String);
            objDB.AddParameters(8, "Nature", Nature, DbType.String);
            objDB.AddParameters(9, "InstituteID", InstituteID, DbType.Int32);
            objDB.AddParameters(10, "Session", Session, DbType.String);
            objDB.AddParameters(11, "ReferenceID", ReferenceID, DbType.String);
            objDB.AddParameters(12, "ReferenceTYpe", ReferenceTYpe, DbType.String);
            objDB.AddParameters(13, "flag", flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherTrans");
           
            ret = "1";
        }
        catch (Exception ex)
        {
           
            ret = "0";
        }
        return ret;
    }
    public string ExecuteAccChild(Int32 VoucherID, Int32 VoucherNo, Int32 VoucherType, decimal AmountTotal, DateTime VoucherDate, string Cnarration, string Session, Int32 InstituteID, string ReferenceID, string ReferenceType, string VoucherMonth, string VoucherYear, string flag, NewDAL.DBManager objDB)
    {
        string ret = "";
       try
        {
            objDB.CreateParameters(13);
            objDB.AddParameters(0, "VoucherID", VoucherID, DbType.Int32);
            objDB.AddParameters(1, "VoucherNo", VoucherNo, DbType.Int32);
            objDB.AddParameters(2, "VoucherType", VoucherType, DbType.Int32);
            objDB.AddParameters(3, "AmountTotal", AmountTotal, DbType.Decimal);
            objDB.AddParameters(4, "VoucherDate", VoucherDate, DbType.DateTime);
            objDB.AddParameters(5, "Cnarration", Cnarration, DbType.String);
            objDB.AddParameters(6, "Session", Session, DbType.String);
            objDB.AddParameters(7, "InstituteID", InstituteID, DbType.Int32);
            objDB.AddParameters(8, "ReferenceID", ReferenceID, DbType.String);
            objDB.AddParameters(9, "ReferenceType", ReferenceType, DbType.String);
            objDB.AddParameters(10, "VoucherMonth", VoucherMonth, DbType.String);
            objDB.AddParameters(11, "VoucherYear", VoucherYear, DbType.String);
            objDB.AddParameters(12, "flag", flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherSummary");
            ret = "1";
        }
        catch (Exception ex)
        {
           
            ret = "0";
        }
        return ret;
    }
}
