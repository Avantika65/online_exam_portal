using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/// <summary>
/// Summary description for LeaveReqst
/// </summary>
public class LeaveReqst
{
	public LeaveReqst()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet CreateDsTable(ref DataSet dsTable)
    {

        dsTable = new DataSet();
        try
        {
            //SELECT     leaveFrom, leaveTo, noODays FROM         leave_Requisition
            //___________________________________
            dsTable.Tables.Add("leave_Req_Sub");
            dsTable.Tables["leave_Req_Sub"].Columns.Add(new DataColumn("ID", typeof(int)));
            dsTable.Tables["leave_Req_Sub"].Columns.Add(new DataColumn("leaveID", typeof(int)));
            dsTable.Tables["leave_Req_Sub"].Columns.Add(new DataColumn("leaveFrom", typeof(DateTime)));
            dsTable.Tables["leave_Req_Sub"].Columns.Add(new DataColumn("leaveTo", typeof(DateTime)));
            dsTable.Tables["leave_Req_Sub"].Columns.Add(new DataColumn("noODays", typeof(Decimal)));
            dsTable.Tables["leave_Req_Sub"].Columns.Add(new DataColumn("leaveName", typeof(String))); 
            //___________________________________

            dsTable.AcceptChanges();
        }
        catch
        {
        }
        finally
        {
        }
        return dsTable;
    }
}
