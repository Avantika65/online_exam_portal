using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;




public partial class NewFolder1_result : System.Web.UI.Page
{
    
    DbFunctions objFunc1 = new DbFunctions();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        DatabindGrid();
     }

    void DatabindGrid()
    {
        string sql = "  SELECT quiz_question.question, quiz_result.ans_attempt, quiz_question.answer FROM quiz_question JOIN quiz_result ON quiz_question.paper_id=quiz_result.paper_ID";
        objFunc1.FillGridView(GridView2, sql);
    }
}