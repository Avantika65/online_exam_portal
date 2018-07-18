using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
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
using System.Data.SqlClient;
using Saplin.Controls;

public partial class Try_GridView : System.Web.UI.Page
{
    DbFunctions objfun = new DbFunctions();
    string selectedname = "";
    private void BindGrid()
    {
        objfun.FillGridView(GridView1, "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master");
        DropDownCheckBoxes ddlName = (DropDownCheckBoxes)GridView1.HeaderRow.FindControl("ddlname");
        objfun.FillDropdownCheckboxIndex(ddlName, "Name", "empId", "select empName as Name,empId from Employee_Master ", "empName");
    }
    private void BindNameList(DropDownList ddlName)
    {
        String strConnString = System.Configuration.ConfigurationManager
        .ConnectionStrings["conString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand("select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master");
        cmd.Connection = con;
        con.Open();
        ddlName.DataSource = cmd.ExecuteReader();
        ddlName.DataTextField = "Name";
        ddlName.DataValueField = "Name";
        ddlName.DataBind();
        con.Close();
        ddlName.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
    }
    protected void NameChanged(object sender, EventArgs e)
    {
        DropDownList ddlName = (DropDownList)sender;
        ViewState["Filter"] = ddlName.SelectedValue;
        this.BindGrid();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Filter"] = "ALL";
            BindGrid();
        }
    }
    //protected void OnPaging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;


    //    this.BindGrid();
    //}
    protected void ddlname_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DropDownCheckBoxes ddlName = (DropDownCheckBoxes)GridView1.HeaderRow.FindControl("ddlname");
        string x = ddlName.SelectedValue;
        for (int i = 2; i < ddlName.Items.Count; i++)
        {

                if (ddlName.Items[i].Selected == true)
                {
                    if (selectedname == "")
                    {
                        selectedname = ddlName.Items[i].Value;
                    }
                    else
                    {
                        selectedname = selectedname + ',' + ddlName.Items[i].Value;
                    }

                }
                
                

        }
        if (ddlName.SelectedIndex == 0 && selectedname == "")
        {
            objfun.FillGridView(GridView1, "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master order by empName");
        }
        if (ddlName.SelectedIndex == 1 && selectedname == "")
        {
            objfun.FillGridView(GridView1, "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master order by empName desc");
        }
        if ((ddlName.SelectedIndex != 0 && ddlName.SelectedIndex != 1) && selectedname != "")
        {
            objfun.FillGridView(GridView1, "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master where empid in (" + selectedname + ")");
        }
        if (ddlName.SelectedIndex == 1 && selectedname != "")
        {
            objfun.FillGridView(GridView1, "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master where empid in (" + selectedname + ") order by empName desc");
        }
        if (ddlName.SelectedIndex == 0 && selectedname != "")
        {
            objfun.FillGridView(GridView1, "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master where empid in (" + selectedname + ") order by empName");
        }
        DropDownCheckBoxes ddlName1 = (DropDownCheckBoxes)GridView1.HeaderRow.FindControl("ddlname");
        objfun.FillDropdownCheckboxIndex(ddlName1, "Name", "empId", "select empName as Name,empId from Employee_Master ", "empName");
        for (int i = 0; i < ddlName1.Items.Count; i++)
        {
            if ( ddlName1.Items[i].Text==x)
            ddlName1.Items[i].Selected = true;
            
            string[] split = selectedname.Split(',');

            for (int j = 0; j < split.Length; j++)
            {
                if (ddlName1.Items[i].Value == split[j].ToString())
                {
                    ddlName1.Items[i].Selected = true;
                }

            }

        }

        //protected void ddlname_SelectedIndexChanged1(object sender, System.EventArgs e)
        //{
        //    string selectedname = "";
        //    for (int i = 0; i < ddlname.Items.Count; i++)
        //    {
        //        if (ddlname.Items[i].Selected == true)
        //        {
        //            if (selectedname == "")
        //            {
        //                selectedname = ddlname.Items[i].Value;
        //            }
        //            else
        //            {
        //                selectedname = selectedname + ',' + ddlname.Items[i].Value;
        //            }

        //        }

        //    }
        //}
    }
    protected void searchbox_TextChanged(object sender, System.EventArgs e)
    {
        TextBox searchbox = (TextBox)GridView1.HeaderRow.FindControl("searchbox");

       string searchtext = searchbox.Text;
       string sql = "select empName+'  '+lastName as Name,empCode,empType,dob from Employee_Master where empName like '" + searchtext + "%'  or empName like '%" + searchtext + "%' or empName like '%" + searchtext + "' order by empName";
       objfun.FillGridView(GridView1, sql);
       DropDownCheckBoxes ddlName1 = (DropDownCheckBoxes)GridView1.HeaderRow.FindControl("ddlname");
       objfun.FillDropdownCheckboxIndex(ddlName1, "Name", "Name", sql, "empName");
       
    }

}