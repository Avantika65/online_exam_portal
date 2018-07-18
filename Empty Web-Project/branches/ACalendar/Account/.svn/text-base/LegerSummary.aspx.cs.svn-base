using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using MSS;
using System.Data.SqlClient;
using System.Web.Services;
using Microsoft.VisualBasic;
public partial class Account_LedgerSummary : System.Web.UI.Page
{
    DbFunctions objFun = new DbFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Context.Request.QueryString["title"] != null)
        {
            lbltitle.InnerText = Context.Request.QueryString["title"].ToString();
            if (!IsPostBack)
            {
                objFun.FillDropdownlist(ddlGroup, "group_name", "group_id", "select group_id,group_name from groups order by group_name", "---Select---");
                objFun.FillGridView(GridView1, "select LedgerID,LedgerName from Ledger order by LedgerName");
            }
        }
    }
    [WebMethod()]
    public static string GetSuggestions2(string skeyword, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = default(System.Collections.Generic.List<AutoSuggestMenuItem>);
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        cn.Open();
        string sql = null;
        if (usePaging)
        {
            int numItems = (pageIndex + 1) * pageSize;
            sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where  LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerNAme";
        }
        else
        {
            sql = "Select distinct top 10 LedgerName,LedgerID from Ledger where LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
        }
        if (sql == null)
            return "";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader reader = cmd.ExecuteReader();
        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);
        reader.Close();
        int totalResults = -1;
        if (usePaging & pageIndex == 0)
        {
            sql = "SELECT COUNT(*) from Ledger where   LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();


            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Ledger where LedgerName LIKE '%'";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName,LedgerID " + sqlFromAndWhere_T + " ";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + " order by LedgerName";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        if (usePaging & pageIndex != 0)
        {
            sql = "SELECT COUNT(*) from Ledger where  LedgerName LIKE '" + skeyword.Replace("'", "''") + "%'";
            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
            if (totalResults == 0)
            {
                string sqlFromAndWhere_T = "from Ledger where LedgerName LIKE '" + Strings.Trim(skeyword.Replace("'", "''")) + "%' order by LedgerName";
                string sql_T = null;
                if (usePaging)
                {
                    int numItems = (pageIndex + 1) * pageSize;
                    sql_T = "select distinct top " + numItems + " LedgerName ,LEdgerID " + sqlFromAndWhere_T + "";
                }
                else
                {
                    sql_T = "select distinct LedgerName,LedgerID " + sqlFromAndWhere_T + "";
                }
                SqlCommand cmd_T = new SqlCommand(sql_T, cn);
                SqlDataReader reader_T = cmd_T.ExecuteReader();
                menuItems = GetMenuItemsFromDataReader(reader_T, usePaging, pageIndex, pageSize);
                reader_T.Close();
                if (usePaging & pageIndex == 0)
                {
                    sql_T = "SELECT COUNT(*)" + sqlFromAndWhere_T;
                    cmd_T = new SqlCommand(sql_T, cn);
                    totalResults = (int)cmd_T.ExecuteScalar();
                }
            }
        }
        //////////////////////////////'''''''''''''''''' 
        cn.Close();
        return Strings.Trim(AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults));
    }
    private static System.Collections.Generic.List<AutoSuggestMenuItem> GetMenuItemsFromDataReader(SqlDataReader reader, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = new System.Collections.Generic.List<AutoSuggestMenuItem>();
        string city = null;
        string cityCode = null;
        string label = null;
        AutoSuggestMenuItem menuItem = default(AutoSuggestMenuItem);
        int rowIndex = 0;
        //Handle paging 
        int startRowIndex = 0;
        int endRowIndex = 0;
        if (usePaging)
        {
            startRowIndex = pageIndex * pageSize;
            endRowIndex = startRowIndex + pageSize;
        }
        while (reader.Read())
        {
            if (usePaging)
            {
                if (rowIndex < startRowIndex)
                {
                    rowIndex = rowIndex + 1;
                    continue;
                    if (rowIndex >= endRowIndex)
                    {
                        break; // TODO: might not be correct. Was : Exit While 
                    }
                }
            }
            city = reader.GetValue(0).ToString();
            cityCode = reader.GetValue(1).ToString();
            label = city;
            menuItem = new AutoSuggestMenuItem();
            menuItem.Label = label;
            menuItem.Value = cityCode;
            menuItems.Add(menuItem);
            rowIndex = rowIndex + 1;
        }
        return menuItems;
    }
    protected void cmdGet_Click(object sender, EventArgs e)
    {
      //  if (txtFYear.Text == "")
      //  {
      //      objFun.MsgBox1("Financial Year not found.", UpdatePanel1);
      //      return;
      //  }
      //  if (txtFrom.Text == "")
      //  {
      //      txtFrom.Focus();
      //      objFun.MsgBox1("Please enter From Date.", UpdatePanel1);
      //      return;
      //  }
      //  if (txtTo.Text == "")
      //  {
      //      txtTo.Focus();
      //      objFun.MsgBox1("Please enter To Date.", UpdatePanel1);
      //      return;
      //  }
      //  string groupid = "18";
      //  DataTable dt = new DataTable();
      //  DataTable dtall = new DataTable();
      //  dtall.Columns.Add("GroupID");
      //  dtall.Columns.Add("Groupname");
      //  dtall.Columns.Add("PG");
      //  dtall.Columns.Add("opbDr");
      //  dtall.Columns.Add("opnCr");
      //  dtall.Columns.Add("traDr");
      //  dtall.Columns.Add("traCr");
      //  dtall.Columns.Add("cloDr");
      //  dtall.Columns.Add("cloCr");
      //  dt = objFun.FillDataTable("Select distinct group_ID,group_name from groups where under_group='1' order by group_name ");
      //  foreach (DataRow dr in dt.Rows)
      //  {
      //      DataRow[] drch = dtall.Select("GroupID='" + dr[0] + "'");
      //      if (drch.Length == 0)
      //      {
      //          if (dr[0].ToString() == "2")
      //          {
      //              string a = "";
      //          }
      //          DataRow dra;
      //          dra = dtall.NewRow();
      //          dra[0] = dr[0].ToString();
      //          dra[1] = dr[1].ToString();
      //          dtall.Rows.Add(dra);
      //          groupid = dr[0].ToString();
      //          AddNodes(ref groupid, ref dtall, groupid);

      //      }
      //  }
      //  DataRow[] drcalculate;
      //  //========Claculate Opening CR DR========Summary
      //  int i, j;
      //  for (i = 0; i <= dt.Rows.Count-1; i++)
      //  {
      //      if (dt.Rows[i].ItemArray[0].ToString() == "18")
      //      {
      //          string aa = "";
      //      }
      //      drcalculate = dtall.Select("PG='" + dt.Rows[i].ItemArray[0].ToString() + "'");
      //      if (drcalculate.Length > 0)
      //      {
      //          decimal opcr = 0;
      //          decimal opdr = 0;
      //          decimal trcr = 0;
      //          decimal trdr = 0;
      //          decimal clcr = 0;
      //          decimal cldr = 0;
      //          if (calculateopening(dt.Rows[i].ItemArray[0].ToString()) >= 0)
      //          {
      //              opdr = opdr + calculateopening(dt.Rows[i].ItemArray[0].ToString());
      //          }
      //          else
      //          {
      //              opcr = (opcr + calculateopening(dt.Rows[i].ItemArray[0].ToString()));
      //          }
      //          trdr = trdr + calculatetransaction(dt.Rows[i].ItemArray[0].ToString(), "dr");
      //          trcr = trcr + calculatetransaction(dt.Rows[i].ItemArray[0].ToString(), "cr");
 
      //          for (j = 0; j <= drcalculate.Length - 1; j++)
      //          {
      //              decimal opcrL = 0;
      //              decimal opdrL = 0;
      //              decimal trcrL = 0;
      //              decimal trdrL = 0;
      //              decimal clcrL = 0;
      //              decimal cldrL = 0;
      //              if (calculateopening(drcalculate[j][0].ToString()) >= 0)
      //              {
      //                  opdr = opdr + calculateopening(drcalculate[j][0].ToString());
      //                  opdrL = opdrL + calculateopening(drcalculate[j][0].ToString());
      //              }
      //              else
      //              {
      //                  opcr = (opcr + calculateopening(drcalculate[j][0].ToString()));
      //                  opcrL = (opcrL  + calculateopening(drcalculate[j][0].ToString()));
      //              }
      //              trdr = trdr + calculatetransaction(drcalculate[j][0].ToString(),"dr");
      //              trcr = trcr + calculatetransaction(drcalculate[j][0].ToString(),"cr");
      //              trdrL = trdrL + calculatetransaction(drcalculate[j][0].ToString(), "dr");
      //              trcrL = trcrL + calculatetransaction(drcalculate[j][0].ToString(), "cr");
      //              DataRow[] drfillopbalI;
      //              drfillopbalI = dtall.Select("GroupID='" + drcalculate[j][0].ToString() + "'");
      //              drfillopbalI[0][3] = opdrL;
      //              drfillopbalI[0][4] = opcrL*-1;
      //              drfillopbalI[0][5] = trdrL;
      //              drfillopbalI[0][6] = trcrL*-1;
      //              clcrL = opdrL + opcrL + trdrL + trcrL;
      //              if (clcrL >= 0)
      //              {
      //                  drfillopbalI[0][7] = clcrL;
      //              }
      //              else
      //              {
      //                  drfillopbalI[0][8] = clcrL*-1;
      //              }
      //          }
      //          DataRow[] drfillopbal;
      //          drfillopbal = dtall.Select("GroupID='" + dt.Rows[i].ItemArray[0].ToString() + "'");
      //          drfillopbal[0][3] = opdr;
      //          drfillopbal[0][4] = opcr*-1;
      //          drfillopbal[0][5] = trdr;
      //          drfillopbal[0][6] = trcr*-1;
      //          clcr = opdr + opcr + trdr + trcr;
      //          if (clcr >= 0)
      //          {
      //              drfillopbal[0][7] = clcr;
      //          }
      //          else
      //          {
      //              drfillopbal[0][8] = clcr*-1;
      //          }
      //      }
      //      else
      //      {
      //          decimal opcr = 0;
      //          decimal opdr = 0;
      //          decimal trcr = 0;
      //          decimal trdr = 0;
      //          decimal clcr = 0;
      //          decimal cldr = 0;
      //          if (calculateopening(i.ToString()) >= 0)
      //          {
      //              opdr = opdr + calculateopening(dt.Rows[i].ItemArray[0].ToString());
      //          }
      //          else
      //          {
      //              opcr = (opcr + calculateopening(dt.Rows[i].ItemArray[0].ToString()));
      //          }
      //          trdr = trdr + calculatetransaction(dt.Rows[i].ItemArray[0].ToString(), "dr");
      //          trcr = (trcr + calculatetransaction(dt.Rows[i].ItemArray[0].ToString(), "cr"));
               
      //          DataRow[] drfillopbal;
      //          drfillopbal = dtall.Select("GroupID='" + dt.Rows[i].ItemArray[0].ToString() + "'");
      //          if (drfillopbal.Length != 0)
      //          {
      //              drfillopbal[0][3] = opdr;
      //              if (opcr > 0)
      //              {
      //                  drfillopbal[0][4] = opcr;
      //              }
      //              else
      //              {
      //                  drfillopbal[0][4] = opcr*-1;
      //              }
      //              drfillopbal[0][5] = trdr;
      //              drfillopbal[0][6] = trcr*-1;
      //              clcr = opdr + opcr + trdr + trcr;
      //              if (clcr >= 0)
      //              {
      //                  drfillopbal[0][7] = clcr;
      //              }
      //              else
      //              {
      //                  drfillopbal[0][8] = clcr * -1;
      //              }
      //          }
      //      }

      //  }
      ////  dtall.Rows.AsQueryable;
      //  gvVoucherlist.DataSource = dtall;
      //  gvVoucherlist.DataBind();
      ////  for(i=0;i<=gvVoucherlist.Rows.Count-1;i++)

      //  //=======================================
      //  //========Calculate CR DR Detail=========
 

      //  //=======================================
    }
    //private decimal calculateopening(string undergroup)
    //{
    //    string openingcr = objFun.Get_details("Select sum(Opening_Blnc) from ledger where Under_Group='" + undergroup + "' and Cr_Dr='Cr'");
    //    string openingdr = objFun.Get_details("Select sum(Opening_Blnc) from ledger where Under_Group='" + undergroup + "' and Cr_Dr='Dr'");
    //    decimal Dr = 0;
    //    decimal Cr = 0;
    //    decimal returnval = 0;
    //    if (openingcr != "")
    //    {
    //        Cr = decimal.Parse(openingcr);
    //    }
    //    if (openingdr != "")
    //    {
    //        Dr = decimal.Parse(openingdr);
    //    }
    //    returnval = Dr - Cr;
    //    return returnval;
    //}
    //private decimal calculatetransaction(string undergroup ,string cr)
    //{
    //    string openingcr = objFun.Get_details("select sum(AmountCR) from Voucher_Transaction where accountid in( Select ledgerid from ledger where Under_Group='" + undergroup + "') ");
    //    string openingdr = objFun.Get_details("select sum(AmountDR) from Voucher_Transaction where accountid in( Select ledgerid from ledger where Under_Group='" + undergroup + "') ");
    //    decimal Dr = 0;
    //    decimal Cr = 0;
    //    decimal returnval = 0;
    //    if (openingcr != "")
    //    {
    //        Cr = decimal.Parse(openingcr);
    //    }
    //    if (openingdr != "")
    //    {
    //        Dr = decimal.Parse(openingdr);
    //    }
    //    if (cr == "cr")
    //    {
    //        returnval = Cr*-1;
    //    }
    //    else
    //    {
    //        returnval = Dr;
    //    }
    //   // returnval = Dr - Cr;
    //    return returnval;
    //}
    //private decimal calculateopeningdetail(string LedgerID)
    //{
    //    string openingcr = objFun.Get_details("Select sum(Opening_Blnc) from ledger where LedgerID='" + LedgerID + "' and Cr_Dr='Cr'");
    //    string openingdr = objFun.Get_details("Select sum(Opening_Blnc) from ledger where LedgerID='" + LedgerID + "' and Cr_Dr='Dr'");
    //    decimal Dr = 0;
    //    decimal Cr = 0;
    //    decimal returnval = 0;
    //    if (openingcr != "")
    //    {
    //        Cr = decimal.Parse(openingcr);
    //    }
    //    if (openingdr != "")
    //    {
    //        Dr = decimal.Parse(openingdr);
    //    }
    //    returnval = Dr - Cr;
    //    return returnval;
    //}
    //private decimal calculatetransactiondetail(string LedgerID)
    //{
    //    string openingcr = objFun.Get_details("select sum(AmountCR) from Voucher_Transaction where accountid in(" + LedgerID + " ) ");
    //    string openingdr = objFun.Get_details("select sum(AmountDR) from Voucher_Transaction where accountid in(" + LedgerID + " ) ");
    //    decimal Dr = 0;
    //    decimal Cr = 0;
    //    decimal returnval = 0;
    //    if (openingcr != "")
    //    {
    //        Cr = decimal.Parse(openingcr);
    //    }
    //    if (openingdr != "")
    //    {
    //        Dr = decimal.Parse(openingdr);
    //    }
    //    returnval = Dr - Cr;
    //    return returnval;
    //}

    //private void AddNodes(ref string node, ref DataTable dtt, string mn)
    //{
    //    DataTable dt = new DataTable();
    //    DataTable dtLedger = new DataTable();
    //    dt = GetData(node);
    //    if (node == "18")
    //    {
    //        string aa = "";
    //    }
    //    dtLedger = GetChildData(node);
    //    string childnode = "";
    //    foreach (DataRow row in dt.Rows)
    //    {

    //        DataRow[] dr = dtt.Select("groupID='" + row[0] + "'");
    //        if (dr.Length == 0)
    //        {
    //            DataRow dra;
    //            dra = dtt.NewRow();
    //            dra[0] = row[0].ToString();
    //            dra[1] = "&nbsp;&nbsp;" + row[1].ToString();
    //            dra[2] = mn.ToString();
    //            dtt.Rows.Add(dra);
    //            node = row[0].ToString();
    //            dtt = RemoveDuplicateRows(dtt, "Groupid");
    //            foreach (DataRow rowL in dtLedger.Rows)
    //            {
    //                DataRow[] drL = dtt.Select("groupID='" + rowL[0] + "'");
    //                if (drL.Length == 0)
    //                {
    //                    DataRow draL;
    //                    draL = dtt.NewRow();
    //                    draL[0] = rowL[0].ToString();
    //                    draL[1] = "&nbsp;&nbsp;&nbsp;<span style='color:red'>*</span>&nbsp;" + rowL[1].ToString();
    //                    draL[2] = mn.ToString();
    //                    dtt.Rows.Add(draL);
    //                    childnode = rowL[0].ToString();
    //                    AddChildNodes(ref childnode, ref dtt, mn);
    //                }
    //            }
    //            AddNodes(ref node, ref dtt, mn);
    //        }
    //        else
    //        {
    //            dtt = RemoveDuplicateRows(dtt, "Groupid");
    //            foreach (DataRow rowL in dtLedger.Rows)
    //            {
    //                DataRow[] drL = dtt.Select("groupID='" + rowL[0] + "'");
    //                if (drL.Length == 0)
    //                {
    //                    DataRow draL;
    //                    draL = dtt.NewRow();
    //                    draL[0] = row[0].ToString();
    //                    draL[1] = "&nbsp;&nbsp;&nbsp;&nbsp;" + row[1].ToString();
    //                    draL[2] = mn.ToString();
    //                    dtt.Rows.Add(draL);
    //                    childnode = rowL[0].ToString();
    //                    AddChildNodes(ref childnode, ref dtt, mn);
    //                }
    //            }
    //        }
    //    }
    //    if (dt.Rows.Count  == 0 && dtLedger.Rows.Count > 0)
    //    {
    //        foreach (DataRow rowL in dtLedger.Rows)
    //        {
    //            DataRow[] drL = dtt.Select("groupID='" + rowL[0] + "'");
    //            dtt = RemoveDuplicateRows(dtt, "Groupid");
                
    //            if (drL.Length == 0)
    //            {
    //                DataRow draL;
    //                draL = dtt.NewRow();
    //                draL[0] = dtLedger.Rows[0].ItemArray[0].ToString();
    //                draL[1] = "&nbsp;&nbsp;&nbsp;<span style='color:red'>*</span>&nbsp;" + dtLedger.Rows[0].ItemArray[1].ToString();
    //                draL[2] = mn.ToString();
    //                dtt.Rows.Add(draL);
    //                childnode = dtLedger.Rows[0].ItemArray[0].ToString();
    //                AddChildNodes(ref childnode, ref dtt, mn);
    //            }
    //        }
    //    }
    //}
    //public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    //{
    //    Hashtable hTable = new Hashtable();
    //    ArrayList duplicateList = new ArrayList();

    //    //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
    //    //And add duplicate item value in arraylist.
    //    foreach (DataRow drow in dTable.Rows)
    //    {
    //        if (hTable.Contains(drow[colName]))
    //            duplicateList.Add(drow);
    //        else
    //            hTable.Add(drow[colName], string.Empty);
    //    }

    //    //Removing a list of duplicate items from datatable.
    //    foreach (DataRow dRow in duplicateList)
    //        dTable.Rows.Remove(dRow);

    //    //Datatable which contains unique records will be return as output.
    //    return dTable;
    //}
    //public DataTable GetData(string intPID)
    //{
    //    DataTable dt = new DataTable();
    //    dt = objFun.FillDataTable("Select group_ID,group_name from groups where under_group in(" + intPID + ")");
    //    return dt;
    //}
    //private void AddChildNodes(ref string node, ref DataTable dtt, string mn)
    //{
    //    DataTable dt = new DataTable();
    //    dt = GetData(node);
    //    foreach (DataRow row in dt.Rows)
    //    {

    //        DataRow[] dr = dtt.Select("groupID='" + row[0] + "'");
    //        if (dr.Length == 0)
    //        {
    //            DataRow dra;
    //            dra = dtt.NewRow();
    //            dra[0] = row[0].ToString();
    //            dra[1] = row[1].ToString();
    //            dra[2] = mn.ToString();
    //            dtt.Rows.Add(dra);
    //            node = row[0].ToString();
    //            AddChildNodes(ref node, ref dtt, mn);
    //        }

    //    }
    //}
    //public DataTable GetChildData(string intPID)
    //{
    //    DataTable dt = new DataTable();
    //    dt = objFun.FillDataTable("Select LedgerID,Ledgername,under_group from Ledger where under_group in(" + intPID + ")");
    //    return dt;
    //}
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        //if (txtFYear.Text == "")
        //{
        //    objFun.MsgBox1("Financial Year not found.", UpdatePanel1);
        //    return;
        //}
        //if (txtFrom.Text == "")
        //{
        //    txtFrom.Focus();
        //    objFun.MsgBox1("Please enter From Date.", UpdatePanel1);
        //    return;
        //}
        //if (txtTo.Text == "")
        //{
        //    txtTo.Focus();
        //    objFun.MsgBox1("Please enter To Date.", UpdatePanel1);
        //    return;
        //}
        //if (gvVoucherlist.Rows.Count == 0)
        //{
        //    txtFYear.Focus();
        //    objFun.MsgBox1("No record found to print.", UpdatePanel1);
        //    return;
        //}

        //ReportDocument rpt1 = new ReportDocument();
        //string spath = ""; //= Server.MapPath("Report\\CWFD.rpt").Replace("Fee\\Fee\\", "Fee\\");
        //string spath1 = Server.MapPath("..\\Report\\");
        //spath = Server.MapPath("..\\Report\\DaybookRpt.rpt"); //.Replace("Fee\\Fee\\", "Fee\\");
        //DayBookDS daybds = new DayBookDS();
        //daybds.Tables["daybookdt"].Merge(dt,false,MissingSchemaAction.Ignore);
        //rpt1.Load(spath);
        //rpt1.SetDataSource(daybds);
        //CrystalReportViewer1.ReportSource = rpt1;
        //CrystalReportViewer1.DataBind();
        //CrystalReportViewer1.RefreshReport();
        //ExportOptions exportOpts1 = rpt1.ExportOptions;
        //rpt1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //rpt1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //rpt1.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        //((DiskFileDestinationOptions)rpt1.ExportOptions.DestinationOptions).DiskFileName = spath1 + "aa.pdf";

        //rpt1.Export();
        //rpt1.Close();
        //rpt1.Dispose();
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Response.ContentType = "application/pdf";
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + "aa.pdf");
        //Response.WriteFile(spath1 + "aa.pdf");
        //Response.Flush();
        //Response.End();
        //File.Delete(Server.MapPath(spath1 + "aa.pdf"));
        //Response.Close();

    }
    //protected void gvVoucherlist_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {

    //        GridView oGridView = (GridView)sender;
    //        GridViewRow oGridViewRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    //        TableCell oTableCell0 = new TableCell();
    //        oTableCell0 = new TableCell();
    //        oTableCell0.CssClass = "exH";
    //        oTableCell0.Text = "Compusory Subject(s)";
    //        //oTableCell0.Attributes["style"] += "text-align:left;background-color:#33ccff;";
    //        oTableCell0.ColumnSpan = 8;
    //        oGridViewRow1.Cells.Add(oTableCell0);
    //       // oGridView.Controls[0].Controls.AddAt(0, oGridViewRow1);

    //        GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

    //        TableCell oTableCell = new TableCell();

    //        oTableCell.Text = "";
    //        oTableCell.ColumnSpan = 1;
    //        oTableCell.CssClass = "exH";
    //        oGridViewRow.Cells.Add(oTableCell);

    //        //oTableCell = new TableCell();
    //        //oTableCell.Text = "Subject";
    //        //oTableCell.CssClass = "exH";
    //        //oTableCell.ColumnSpan = 2;
    //        //oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Opening ";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);


    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Transaction";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Closing";
    //        oTableCell.CssClass = "";
    //        oTableCell.HorizontalAlign = HorizontalAlign.Center;
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
    //    }
    //}
    //protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        GridView oGridView = (GridView)sender;

    //        GridViewRow oGridViewRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    //        TableCell oTableCell0 = new TableCell();
    //        oTableCell0 = new TableCell();
    //        oTableCell0.Text = "Elective Subject(s)";
    //        oTableCell0.CssClass = "exH";
    //        //oTableCell0.SkinID = "S1";
    //        oTableCell0.ColumnSpan = 16;
    //        oGridViewRow1.Cells.Add(oTableCell0);
    //        oGridView.Controls[0].Controls.AddAt(0, oGridViewRow1);


    //        GridViewRow oGridViewRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
    //        TableCell oTableCell = new TableCell();

    //        oTableCell.Text = "";
    //        oTableCell.ColumnSpan = 2;
    //        oTableCell.CssClass = "exH";
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Subject";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Total Marks";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);


    //        oTableCell = new TableCell();
    //        oTableCell.Text = "External Marks";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Internal Marks";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 2;
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "";
    //        oTableCell.ColumnSpan = 1;
    //        oTableCell.CssClass = "exH";
    //        oGridViewRow.Cells.Add(oTableCell);

    //        oTableCell = new TableCell();
    //        oTableCell.Text = "Total Periods";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 3;
    //        oGridViewRow.Cells.Add(oTableCell);
    //        oTableCell = new TableCell();
    //        oTableCell.Text = "";
    //        oTableCell.CssClass = "exH";
    //        oTableCell.ColumnSpan = 1;
    //        oGridViewRow.Cells.Add(oTableCell);
    //        oTableCell = new TableCell();
    //        oTableCell.Text = "";
    //        oTableCell.CssClass = "exH"; //Attributes["style"] += "text-align:center;background-color:#33ccff;border-bottom-color:AliceBlue;";
    //        oTableCell.ColumnSpan = 1;
    //        oGridViewRow.Cells.Add(oTableCell);
    //        oGridView.Controls[0].Controls.AddAt(1, oGridViewRow);
    //    }
    //}
    //protected void gvVoucherlist_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (gvVoucherlist.DataKeys[e.Row.RowIndex].Value.ToString() != "")
    //        {
    //            e.Row.Cells[0].Text = "&nbsp;&nbsp;" + e.Row.Cells[0].Text;
    //        }
    //        else
    //        {
    //            //e.Row.BackColor = System.Drawing.Color.SlateGray;
    //             e.Row.Cells[0].ForeColor = System.Drawing.Color.Green;
    //             e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
    //             e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;
    //             e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
    //             e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
    //             e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
    //             e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                  
    //        }
    //    }
    //}
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = new Int32[0];
        GridView1.DataBind();
        objFun.FillGridView(GridView1, "select LedgerID,LedgerName from Ledger where under_group='" + ddlGroup.SelectedValue + "' order by LedgerName");
        if (GridView1.Rows.Count == 0)
        {
            objFun.MsgBox1("No ledger record found for group :-"+ ddlGroup.SelectedItem.Text, UpdatePanel1);
            ddlGroup.SelectedIndex = 0;
            objFun.FillGridView(GridView1, "select LedgerID,LedgerName from Ledger order by LedgerName");
            return;
        }
    }
}