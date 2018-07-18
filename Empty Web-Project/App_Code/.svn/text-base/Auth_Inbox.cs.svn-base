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
/// Summary description for Auth_Inbox
/// </summary>
public class Auth_Inbox
{
	public Auth_Inbox()
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
            dsTable.Tables.Add("leave");
            dsTable.Tables["leave"].Columns.Add(new DataColumn("leaveID", typeof(int)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("leaveFrom", typeof(DateTime)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("leaveTo", typeof(DateTime)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("noODays", typeof(Decimal)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("leaveName", typeof(String)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("id", typeof(int)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("name", typeof(String)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("empID", typeof(int)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("applno", typeof(String)));
            dsTable.Tables["leave"].Columns.Add(new DataColumn("appDate", typeof(DateTime)));
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
