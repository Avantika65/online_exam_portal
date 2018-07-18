using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using NewDAL;
using MSS;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

public partial class quiz_upload : System.Web.UI.Page
{
    DbFunctions objFunc = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objFunc.FillDropdownlist(ddl_aoi, "specialization", "id", "select distinct id,specialization from faculty_registration", "---Select---");
            FillGrid1();
            fillgrd();
        }
    }
    public void FillGrid1()
    {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("Question");
            dt.Columns.Add("opt_a");
            dt.Columns.Add("opt_b");
            dt.Columns.Add("opt_c");
            dt.Columns.Add("opt_d");
            dt.Columns.Add("answer");
            dt.Rows.Add(0, "Enter Question", "Option A", "Option B", "Option ", "Option D", "Correct Option");
            dt.AcceptChanges();
            grd_insert.DataSource = dt;
            grd_insert.DataBind();
       
    }
    public void fillgrd()
    {
            DataTable dt = new DataTable();
            dt = objFunc.FillDataTable("Select * from quiz_question");
            if (dt.Rows.Count > 0)
            {
                grd_quiz.DataSource = dt;
                grd_quiz.DataBind();
            }
            else
            {
                grd_quiz.DataSource = null;
                grd_quiz.DataBind();
            }
    }
    protected void btn_create_Click(object sender, EventArgs e)
    {
        int fac = 185;
        string j1 = objFunc.Get_details("select count(*) from papers where f_id='" + fac + "' and area_of_intrst='" + ddl_aoi.SelectedValue + "'");
        int i1 = Convert.ToInt32(j1);
        if (i1 == 0)
        {
            int i = objFunc.ExecuteDML("insert into papers(f_id,area_of_intrst) values('" + fac + "','" + ddl_aoi.SelectedValue + "')");
            if (i == 1)
            {
                objFunc.MsgBox("Record Added Sucessfully...", this);
                grd_quiz.Visible = true;
            }
        }
    }
    protected void lb_add_Click(object sender, EventArgs e)
    {
        int fac = 185;
        string pi = objFunc.Get_details("select id from papers where f_id='" + fac + "' and area_of_intrst='" + ddl_aoi.SelectedValue + "'");
        int pi1 = Convert.ToInt32(pi);
        LinkButton lnk1 = (LinkButton)sender;
        GridViewRow grd1 = (GridViewRow)lnk1.NamingContainer;
        LinkButton addbutton = (LinkButton)grd_insert.Rows[grd1.RowIndex].FindControl("lb_add");
   
        string ch=addbutton.Text;
        string ID = grd_insert.DataKeys[grd1.RowIndex].Values[0].ToString();
        hdnID.Value = ID.ToString();
        Label lblID = (Label)grd_insert.FindControl("Label1");

        TextBox txtbox1 = (TextBox)grd_insert.Rows[grd1.RowIndex].FindControl("Question");
        TextBox txtbox2 = (TextBox)grd_insert.Rows[grd1.RowIndex].FindControl("opt_a");
        TextBox txtbox3 = (TextBox)grd_insert.Rows[grd1.RowIndex].FindControl("opt_b");
        TextBox txtbox4 = (TextBox)grd_insert.Rows[grd1.RowIndex].FindControl("opt_c");
        TextBox txtbox5 = (TextBox)grd_insert.Rows[grd1.RowIndex].FindControl("opt_d");
        TextBox txtbox6 = (TextBox)grd_insert.Rows[grd1.RowIndex].FindControl("answer");
        
        if (txtbox1.Text == "")
        {
            objFunc.MsgBox("Please enter Question...", this);
            return;
        }
        if (txtbox2.Text == "")
        {
            objFunc.MsgBox("Please enter option A...", this);
            return;
        }
        if (txtbox3.Text == "")
        {
            objFunc.MsgBox("Please enter option B...", this);
            return;
        }
        if (txtbox4.Text == "")
        {
            objFunc.MsgBox("Please enter option C...", this);
            return;
        }
        if (txtbox5.Text == "")
        {
            objFunc.MsgBox("Please enter option D...", this);
            return;
        }
        if (txtbox6.Text == "")
        {
            objFunc.MsgBox("Please enter answer...", this);
            return;
        }
        else
        {
            if (ch == "Add")
            {

                string CommandText = "INSERT INTO quiz_question (paper_id,question,opt_a,opt_b,opt_b,opt_c,opt_d,answer)values('" + pi1 + "','" + txtbox1.Text + "','" + txtbox2.Text + "','" + txtbox3.Text + "','" + txtbox4.Text + "','" + txtbox5.Text + "','" + txtbox6.Text + "')";
                objFunc.ExecuteDML(CommandText);
                fillgrd();
                FillGrid1();
                objFunc.MsgBox("Record Added Sucessfully...", this);
                return;
            }
            if (ch == "update")
            {
                string cmd = "UPDATE quiz_question SET question = '" + txtbox1.Text + "', opt_a= '" + txtbox2.Text + "', opt_b = '" + txtbox3.Text + "', opt_c= '" + txtbox4.Text + "', opt_d = '" + txtbox5.Text + "', answer= '" +  txtbox6.Text + "' WHERE id='" + pi1 + "'";
                objFunc.ExecuteDML(cmd);
                fillgrd();
                FillGrid1();
                objFunc.MsgBox("Record updated Sucessfully...", this);
                return;
            }
        }
    }

    protected void lb_edit_Click(object sender, EventArgs e)
    {
        
        LinkButton lnk = (LinkButton)sender;
        GridViewRow grd = (GridViewRow)lnk.NamingContainer;
        string ID = grd_quiz.DataKeys[grd.RowIndex].Values[0].ToString();
        hdnID.Value = ID.ToString();
        Label lblID = (Label)grd_insert.FindControl("Label2");

        Label lbl = grd_quiz.Rows[grd.RowIndex].FindControl("lbl_ques") as Label;
        TextBox txtbox1 = (TextBox)grd_insert.Rows[grd.RowIndex].FindControl("ques");
        string ques = lbl.Text;
        txtbox1.Text = ques;

        Label lbl1 = grd_quiz.Rows[grd.RowIndex].FindControl("lbl_a") as Label;
        TextBox txtbox2 = (TextBox)grd_insert.Rows[grd.RowIndex].FindControl("opt_a");
        string opta = lbl1.Text;
        txtbox2.Text = opta;

        Label lbl2 = grd_quiz.Rows[grd.RowIndex].FindControl("lbl_b") as Label;
        TextBox txtbox3 = (TextBox)grd_insert.Rows[grd.RowIndex].FindControl("opt_b");
        string optb = lbl2.Text;
        txtbox3.Text = optb;

        Label lbl3 = grd_quiz.Rows[grd.RowIndex].FindControl("lbl_c") as Label;
        TextBox txtbox4 = (TextBox)grd_insert.Rows[grd.RowIndex].FindControl("opt_c");
        string optc = lbl3.Text;
        txtbox4.Text = optc;

        Label lbl4 = grd_quiz.Rows[grd.RowIndex].FindControl("lbl_d") as Label;
        TextBox txtbox5 = (TextBox)grd_insert.Rows[grd.RowIndex].FindControl("opt_d");
        string optd = lbl4.Text;
        txtbox1.Text = optc;

        Label lbl5 = grd_quiz.Rows[grd.RowIndex].FindControl("lbl_ans") as Label;
        TextBox txtbox6 = (TextBox)grd_insert.Rows[grd.RowIndex].FindControl("answer");
        string ans = lbl5.Text;
        txtbox6.Text = ans;

        LinkButton addbutton = (LinkButton)grd_insert.Rows[grd.RowIndex].FindControl("lb_add");
        addbutton.Text = "update";
    }
    protected void lb_delete_Click(object sender, EventArgs e)
    {

        LinkButton lnk = (LinkButton)sender;
        GridViewRow grd = (GridViewRow)lnk.NamingContainer;
        string ID = grd_quiz.DataKeys[grd.RowIndex].Values[0].ToString();
        string delete = "delete FROM employeedet where id='" + ID + "'";
        int d = objFunc.ExecuteDML(delete);
        if (d > 0)
        {
            fillgrd();
            objFunc.MsgBox("Record Deleted Sucessfully...", this);
            return;
        }
    }
}