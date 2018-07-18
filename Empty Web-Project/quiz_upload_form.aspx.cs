using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class quiz_upload_form : System.Web.UI.Page
{
    DbFunctions objFunc = new DbFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objFunc.FillDropdownlist(ddl_aoi, "area_of_intrest", "id", "select id,area_of_intrest from papers", "---Select---");
        }
    }
    protected void ddl_aoi_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {

    }
    protected void Unnamed_Click1(object sender, EventArgs e)
    {

    }
    protected void btn_create_Click(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {

    }
}