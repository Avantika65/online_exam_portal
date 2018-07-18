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
public partial class Account_DayBook : System.Web.UI.Page
{
    DbFunctions objFun = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["sesnid"] == null)
        {
            objFun.MsgBox1("Session Expired.", UpdatePanel1);
            return;
        }
        if (Context.Request.QueryString["title"] != null)
        {
            lbltitle.InnerText = Context.Request.QueryString["title"].ToString();
            txtFYear.Text = Session["sesnid"].ToString();
            System.Array arr;
            arr = Microsoft.VisualBasic.Strings.Split(Session["sesnid"].ToString(), "-", -1, 0);
            txtFrom.Text = "01-Apr-" + arr.GetValue(0).ToString();
            txtTo.Text = "31-Mar-" + arr.GetValue(1).ToString();
            txtFYear.Focus();
            optcrdr.Items[2].Selected = true;
        }
    }
    protected void cmdGet_Click(object sender, EventArgs e)
    {
        if (txtFYear.Text == "")
        {
            objFun.MsgBox1("Financial Year not found.", UpdatePanel1);
            return;
        }
        if (txtFrom.Text == "")
        {
            txtFrom.Focus();
            objFun.MsgBox1("Please enter From Date.", UpdatePanel1);
            return;
        }
        if (txtTo.Text == "")
        {
            txtTo.Focus();
            objFun.MsgBox1("Please enter To Date.", UpdatePanel1);
            return;
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(DateTime));
        dt.Columns.Add("vType");
        dt.Columns.Add("vno");
        dt.Columns.Add("Refno");
        dt.Columns.Add("Particulars");
        dt.Columns.Add("Debit");
        dt.Columns.Add("Credit");
        //DayVoucher
        DataTable fillvdetail = new DataTable();
        fillvdetail = objFun.FillDataTable("Select * from DayVoucher where instituteid='" + Session["instid"].ToString() + "' order by voucherid");
        int i;
        for (i = 0; i <= fillvdetail.Rows.Count - 1; i++)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
            dr[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
            dr[2] = fillvdetail.Rows[i].ItemArray[1].ToString();
            dr[3] = fillvdetail.Rows[i].ItemArray[8].ToString();
            dr[4] = fillvdetail.Rows[i].ItemArray[3].ToString();
            if (optcrdr.Items[2].Selected == true)
            {
                dr[5] = fillvdetail.Rows[i].ItemArray[4].ToString();
                dr[6] = fillvdetail.Rows[i].ItemArray[5].ToString();
            }
            else if (optcrdr.Items[0].Selected == true)
            {
                dr[5] = fillvdetail.Rows[i].ItemArray[4].ToString();
            }
            else
            {
                dr[6] = fillvdetail.Rows[i].ItemArray[5].ToString();
            }
            dt.Rows.Add(dr);
            //if Narration is Selected===
            if (CheckBoxList1.Items[0].Selected == true)
            {
                int countvF = (int)fillvdetail.Compute("count(voucherID)", "transid='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                int countvD = (int)dt.Compute("count(vno)", "vno='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                if (countvF == countvD)
                {
                    DataRow dr1;
                    dr1 = dt.NewRow();
                    dr1[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
                    dr1[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
                    // dr1[2] = fillvdetail.Rows[i].ItemArray[1].ToString();
                    dr1[4] = "Narration :- " + fillvdetail.Rows[i].ItemArray[6].ToString();
                    dt.Rows.Add(dr1);
                    if (CheckBoxList1.Items[1].Selected == true)
                    {
                        DataRow drC;
                        drC = dt.NewRow();
                        drC[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
                        drC[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
                        //drC[2] = fillvdetail.Rows[i].ItemArray[1].ToString();
                        drC[4] = "Cheque :- " + fillvdetail.Rows[i].ItemArray[6].ToString();
                        dt.Rows.Add(drC);
                    }
                }
            }
            if (CheckBoxList1.Items[0].Selected == false && CheckBoxList1.Items[1].Selected == true)
            {
                int countvF = (int)fillvdetail.Compute("count(voucherID)", "transid='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                int countvD = (int)dt.Compute("count(vno)", "vno='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                if (countvF == countvD)
                {
                    DataRow dr1;
                    dr1 = dt.NewRow();
                    dr1[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
                    dr1[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
                    dr1[4] = "Cheque :- " + fillvdetail.Rows[i].ItemArray[6].ToString();
                    dt.Rows.Add(dr1);
                }
            }
            //==========================
        }
        gvVoucherlist.DataSource = dt;
        gvVoucherlist.DataBind();
        for (i = 0; i <= gvVoucherlist.Rows.Count - 1; i++)
        {
            if (gvVoucherlist.Rows[i].Cells[4].Text.Contains("Narration") || gvVoucherlist.Rows[i].Cells[4].Text.Contains("Cheque"))
            {
                TextBox txtdr;
                txtdr =(TextBox) gvVoucherlist.Rows[i].FindControl("txtDr");
                TextBox txtcr;
                txtcr =(TextBox) gvVoucherlist.Rows[i].FindControl("txtCr");
                txtdr.Visible = false;
                txtcr.Visible = false;
            }
        }

    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        if (txtFYear.Text == "")
        {
            objFun.MsgBox1("Financial Year not found.", UpdatePanel1);
            return;
        }
        if (txtFrom.Text == "")
        {
            txtFrom.Focus();
            objFun.MsgBox1("Please enter From Date.", UpdatePanel1);
            return;
        }
        if (txtTo.Text == "")
        {
            txtTo.Focus();
            objFun.MsgBox1("Please enter To Date.", UpdatePanel1);
            return;
        }
        if (gvVoucherlist.Rows.Count == 0)
        {
            txtFYear.Focus();
            objFun.MsgBox1("No record found to print.", UpdatePanel1);
            return;
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("Date", typeof(DateTime));
        dt.Columns.Add("vType");
        dt.Columns.Add("vno");
        dt.Columns.Add("Refno");
        dt.Columns.Add("Particulars");
        dt.Columns.Add("Debit");
        dt.Columns.Add("Credit");
        //DayVoucher
        DataTable fillvdetail = new DataTable();
        fillvdetail = objFun.FillDataTable("Select * from DayVoucher where instituteid='" + Session["instid"].ToString() + "'");
        int i;
        for (i = 0; i <= fillvdetail.Rows.Count - 1; i++)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
            dr[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
            dr[2] = fillvdetail.Rows[i].ItemArray[1].ToString();
            dr[3] = fillvdetail.Rows[i].ItemArray[8].ToString();
            dr[4] = fillvdetail.Rows[i].ItemArray[3].ToString();
            if (optcrdr.Items[2].Selected == true)
            {
                dr[5] = fillvdetail.Rows[i].ItemArray[4].ToString();
                dr[6] = fillvdetail.Rows[i].ItemArray[5].ToString();
            }
            else if (optcrdr.Items[0].Selected == true)
            {
                dr[5] = fillvdetail.Rows[i].ItemArray[4].ToString();
            }
            else
            {
                dr[6] = fillvdetail.Rows[i].ItemArray[5].ToString();
            }
            dt.Rows.Add(dr);
            //if Narration is Selected===
            if (CheckBoxList1.Items[0].Selected == true)
            {
                int countvF = (int)fillvdetail.Compute("count(voucherID)", "transid='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                int countvD = (int)dt.Compute("count(vno)", "vno='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                if (countvF == countvD)
                {
                    DataRow dr1;
                    dr1 = dt.NewRow();
                    dr1[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
                    dr1[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
                    // dr1[2] = fillvdetail.Rows[i].ItemArray[1].ToString();
                    dr1[4] = "Narration :- " + fillvdetail.Rows[i].ItemArray[6].ToString();
                    dt.Rows.Add(dr1);
                    if (CheckBoxList1.Items[1].Selected == true)
                    {
                        DataRow drC;
                        drC = dt.NewRow();
                        drC[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
                        drC[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
                        //drC[2] = fillvdetail.Rows[i].ItemArray[1].ToString();
                        drC[4] = "Cheque :- " + fillvdetail.Rows[i].ItemArray[6].ToString();
                        dt.Rows.Add(drC);
                    }
                }
            }
            if (CheckBoxList1.Items[0].Selected == false && CheckBoxList1.Items[1].Selected == true)
            {
                int countvF = (int)fillvdetail.Compute("count(voucherID)", "transid='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                int countvD = (int)dt.Compute("count(vno)", "vno='" + fillvdetail.Rows[i].ItemArray[1].ToString() + "'");
                if (countvF == countvD)
                {
                    DataRow dr1;
                    dr1 = dt.NewRow();
                    dr1[0] = fillvdetail.Rows[i].ItemArray[0].ToString();
                    dr1[1] = fillvdetail.Rows[i].ItemArray[9].ToString();
                    dr1[4] = "Cheque :- " + fillvdetail.Rows[i].ItemArray[6].ToString();
                    dt.Rows.Add(dr1);
                }
            }
            //==========================
        }
        ReportDocument rpt1 = new ReportDocument();
        string spath = ""; //= Server.MapPath("Report\\CWFD.rpt").Replace("Fee\\Fee\\", "Fee\\");
        string spath1 = Server.MapPath("..\\Report\\");
        spath = Server.MapPath("..\\Report\\DaybookRpt.rpt"); //.Replace("Fee\\Fee\\", "Fee\\");
        DayBookDS daybds = new DayBookDS();
        daybds.Tables["daybookdt"].Merge(dt,false,MissingSchemaAction.Ignore);
        rpt1.Load(spath);
        rpt1.SetDataSource(daybds);
        CrystalReportViewer1.ReportSource = rpt1;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
        ExportOptions exportOpts1 = rpt1.ExportOptions;
        rpt1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        rpt1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        rpt1.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        ((DiskFileDestinationOptions)rpt1.ExportOptions.DestinationOptions).DiskFileName = spath1 + "aa.pdf";

        rpt1.Export();
        rpt1.Close();
        rpt1.Dispose();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + "aa.pdf");
        Response.WriteFile(spath1 + "aa.pdf");
        Response.Flush();
        Response.End();
        File.Delete(Server.MapPath(spath1 + "aa.pdf"));
        Response.Close();

    }
}
