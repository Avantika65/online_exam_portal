using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Saplin.Controls;
public partial class Try_resultpublish : System.Web.UI.Page
{
    DbFunctions objfun = new DbFunctions();
    DbFunctions objFunc = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("../error_404_2.html");
            return;
        }
        if (Session["instID"].ToString() == null)
        {
            Response.Redirect("../error_404_2.html");
        }
        if (Session["sesnID"].ToString() == null)
        {
            Response.Redirect("../error_404_2.html");
        }
        if (!IsPostBack)
        {
            this.ddlspl.Items.Add("---Select---");
            ddltremester.Items.Add("---Select---");
            objFunc.FillCourse(ddlCourse, Session["instID"].ToString(), "---Select---");
            ddlCourse.Focus();
        }
        Gvresult.Visible = false;
        imgnodata.Visible = true;
    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex != 0)
        {
            objFunc.FillSpecilization(ddlspl, Session["instID"].ToString(), ddlCourse.SelectedValue, "--Select--");
            string ctype = objFunc.Get_details("select type from Course where courseid='" + ddlCourse.SelectedValue + "'");
            //if (ctype == "Both")
            //{
            //    lblY.Text = "Year-Sem";
            //}
            //else if (ctype == "Year")
            //{
            //    lblY.Text = "Year";
            //}
            //else if (ctype == "Semester")
            //{
            //    lblY.Text = "Semester";
            //}

            //else if (ctype == "Trimester")
            //{
            //    lblY.Text = "Year-Trimester";
            //}
            objFunc.FillYearsem(ddltremester, ctype, Convert.ToInt32(ddlCourse.SelectedValue), "0", this.Session["SesnID"].ToString(), Convert.ToInt32(Session["instID"].ToString()), "---Select---");

            if (ddltremester.Items.Count == 1)
            {
                objFunc.MsgBox("Year or semester not found for selected course and session.", this);
                return;
            }
        }
        else
        {
            ddlspl.Items.Clear();
            ddltremester.Items.Clear();
            this.ddlspl.Items.Add("---Select---");
            ddltremester.Items.Add("---Select---");
        }
        ddlCourse.Focus();
    }
    private void BindGrid()
    {
        objfun.FillGridView(Gvresult, "SELECT DISTINCT iESEresult.SubjectId, Subject_Mast.SubjectName+' ('+Subject_Mast.SubjectCode+')' as Subject FROM  iESEresult INNER JOIN Subject_Mast ON iESEresult.SubjectId = Subject_Mast.SubjectID WHERE(iESEresult.courseId = '" + ddlCourse.SelectedValue + "') AND (iESEresult.yearId = '" + ddltremester.SelectedValue + "') AND (iESEresult.SpecializationId='" + ddlspl.SelectedValue + "')AND (iESEresult.InstituteID = '" + Session["instID"].ToString() + "') AND (iESEresult.sessionId= '" + Session["sesnID"].ToString() + "') AND iESEresult.SubjectId NOT IN (Select SubjectId from resultrecord)");
    }
    protected void ddltremester_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlCourse.SelectedValue == "")
        {
            objFunc.MsgBox("Please select Course...", this);
            return;
        }
        if (ddlspl.SelectedValue == "")
        {
            objFunc.MsgBox("Please select Specilization...", this);
            return;
        }
        DataTable dt = new DataTable();
        dt = objfun.FillDataTable("SELECT DISTINCT iESEresult.SubjectId, Subject_Mast.SubjectName+' ('+Subject_Mast.SubjectCode+')' as Subject FROM  iESEresult INNER JOIN Subject_Mast ON iESEresult.SubjectId = Subject_Mast.SubjectID WHERE(iESEresult.courseId = '" + ddlCourse.SelectedValue + "') AND (iESEresult.yearId = '" + ddltremester.SelectedValue + "') AND (iESEresult.SpecializationId='" + ddlspl.SelectedValue + "') AND (iESEresult.InstituteID = '" + Session["instID"].ToString() + "') AND (iESEresult.sessionId= '" + Session["sesnID"].ToString() + "') AND iESEresult.SubjectId NOT IN (Select SubjectId from resultrecord)");
        if (dt.Rows.Count == 0)
        {
            Gvresult.Visible = false;
            imgnodata.Visible = true;
        }
        if (dt.Rows.Count > 0)
        {
            Gvresult.Visible = true;
            imgnodata.Visible = false;
        }
        BindGrid();
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        ddlCourse.SelectedIndex = 0;
        ddlspl.SelectedIndex = 0;
        ddltremester.SelectedIndex = 0;

        Gvresult.Visible = false;
        imgnodata.Visible = true;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        for (int i = 0; i <Gvresult.Rows.Count; i++)
        {
            CheckBox chkrslt = (CheckBox)Gvresult.Rows[i].FindControl("ChkResult");
            string check;
            string dtky = Gvresult.DataKeys[i].Value.ToString();
            

            if (chkrslt.Checked == true)
            {
                check = "Yes";
                string sql = "INSERT INTO resultrecord(Course,Specialisation,Trimester,InstituteID,Session,UserEntryID,UserEntryDate,SubjectId,ResultStatus) VALUES('" + ddlCourse.SelectedValue + "','" + ddlspl.SelectedValue + "','" + ddltremester.SelectedValue + "','" + Session["instID"].ToString() + "','" + Session["sesnID"].ToString() + "','" + Session["UID"].ToString() + "','" + DateTime.Now + "','" + dtky + "','" + check + "');";
                objfun.ExecuteDML(sql);
                objfun.ExecuteDML("Select Subject_Mast.SubjectName+' ('+Subject_Mast.SubjectCode+')' as Subject FROM  iESEresult INNER JOIN Subject_Mast ON iESEresult.SubjectId = Subject_Mast.SubjectID WHERE iESEresult.SubjectId=dtky  ");
               
                }
            
            
        }
        DataTable dt1 = new DataTable();
        dt1 = objfun.FillDataTable("SELECT DISTINCT iESEresult.SubjectId, Subject_Mast.SubjectName+' ('+Subject_Mast.SubjectCode+')' as Subject FROM  iESEresult INNER JOIN Subject_Mast ON iESEresult.SubjectId = Subject_Mast.SubjectID WHERE(iESEresult.courseId = '" + ddlCourse.SelectedValue + "') AND (iESEresult.yearId = '" + ddltremester.SelectedValue + "') AND (iESEresult.SpecializationId='" + ddlspl.SelectedValue + "') AND (iESEresult.InstituteID = '" + Session["instID"].ToString() + "') AND (iESEresult.sessionId= '" + Session["sesnID"].ToString() + "') AND iESEresult.SubjectId NOT IN (Select SubjectId from resultrecord)");
        if (dt1.Rows.Count == 0)
        {
            Gvresult.Visible = false;
            imgnodata.Visible = true;
        }
        if (dt1.Rows.Count > 0)
        {
            Gvresult.Visible = true;
            imgnodata.Visible = false;
        }
        BindGrid();

        if (Gvresult.Rows.Count!=0)
        {
           
        }
    }
}