using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewFolder1_Default : System.Web.UI.Page
{
    DbFunctions objFunc1 = new DbFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        DatabindGrid();
    }
    void DatabindGrid()
    {
        string sql = "    SELECT quiz_question.paper_id, quiz_result.date, quiz_result.quiz_correct ,quiz_result.quiz_wrong,quiz_result.percentage FROM quiz_question JOIN quiz_result ON quiz_question.paper_id=quiz_result.paper_id";
        objFunc1.FillGridView(GridView2, sql);
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}