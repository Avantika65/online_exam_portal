using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    DbFunctions obj = new DbFunctions();
    Random rand=new Random();
    static int[] id = new int[10];
   // static int fid = "select f_id from ";
    static int c=0;
    static int w=0;
    static float percentage;
    static int attempt = 10;
    string[] r1 = new string[10];
    string[] o = new string[10];
    string strConnString = ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    string str;
    SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i=0; i<10; i++)
        {
            id[i]=rand.Next(1,200);
        } 
        lblques1.Text = obj.Get_details("select question from quiz_question where paper_id= '" + id[0] +"'" );
        RadioButton1.Text = obj.Get_details("select opt_a from quiz_question where paper_id='" + id[0] + "'");
        RadioButton2.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[0] + "'");
        RadioButton3.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[0] + "'");
        RadioButton4.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[0] + "'");

        lblques2.Text= obj.Get_details("select question from quiz_question where paper_id= '" + id[1]+ "'" );
        RadioButton5.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[1] + "'");
        RadioButton6.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[1] + "'");
        RadioButton7.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[1] + "'");
        RadioButton8.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[1] + "'");

        lblques3.Text = obj.Get_details("select question from quiz_question where paper_id= '" + id[2] + "'" );
        RadioButton9.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[2] + "'");
        RadioButton10.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[2] + "'");
        RadioButton11.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[2] + "'");
        RadioButton12.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[2] + "'");

        lblques4.Text = obj.Get_details("select question from quiz_question where paper_id= '" + id[3] +"'" );
        RadioButton13.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[3] + "'");
        RadioButton14.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[3] + "'");
        RadioButton15.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[3] + "'");
        RadioButton16.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[3] + "'");

        lblques5.Text = obj.Get_details("select question from quiz_question where paper_id='" + id[4] + "'");
        RadioButton17.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[4] + "'");
        RadioButton18.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[4] + "'");
        RadioButton19.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[4] + "'");
        RadioButton20.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[4] + "'");

        lblques6.Text = obj.Get_details("select question from quiz_question where paper_id='" + id[5] + "'");
        RadioButton21.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[5] + "'");
        RadioButton22.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[5] + "'");
        RadioButton23.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[5] + "'");
        RadioButton24.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[5] + "'");

        lblques7.Text = obj.Get_details("select question from quiz_question where paper_id='" + id[6] + "'");
        RadioButton25.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[6] + "'");
        RadioButton26.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[6] + "'");
        RadioButton27.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[6] + "'");
        RadioButton28.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[6] + "'");

        lblques8.Text = obj.Get_details("select question from quiz_question where paper_id='" + id[7] + "'");
        RadioButton29.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[7] + "'");
        RadioButton30.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[7] + "'");
        RadioButton31.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[7] + "'");
        RadioButton32.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[7] + "'");

        lblques9.Text = obj.Get_details("select question from quiz_question where paper_id='" + id[8] + "'");
        RadioButton33.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[8] + "'");
        RadioButton34.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[8] + "'");
        RadioButton35.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[8] + "'");
        RadioButton36.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[8] + "'");

        lblques9.Text = obj.Get_details("select question from quiz_question where paper_id='" + id[9] + "'");
        RadioButton37.Text = obj.Get_details("select opt_a from quiz_question where paper_id= '" + id[9] + "'");
        RadioButton38.Text = obj.Get_details("select opt_b from quiz_question where paper_id= '" + id[9] + "'");
        RadioButton39.Text = obj.Get_details("select opt_c from quiz_question where paper_id= '" + id[9] + "'");
        RadioButton40.Text = obj.Get_details("select opt_d from quiz_question where paper_id= '" + id[9] + "'");
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        o[0] = RadioButton1.Checked ? RadioButton1.Text : (RadioButton2.Checked ? RadioButton2.Text : (RadioButton3.Checked ? RadioButton3.Text : RadioButton4.Checked ? RadioButton4.Text : null));
        o[1] = RadioButton5.Checked ? RadioButton5.Text : (RadioButton6.Checked ? RadioButton6.Text : (RadioButton7.Checked ? RadioButton7.Text : RadioButton8.Checked ? RadioButton8.Text : null));
        o[3] = RadioButton9.Checked ? RadioButton9.Text : (RadioButton10.Checked ? RadioButton10.Text : (RadioButton11.Checked ? RadioButton11.Text : RadioButton12.Checked ? RadioButton12.Text : null));
        o[4] = RadioButton13.Checked ? RadioButton13.Text : (RadioButton14.Checked ? RadioButton14.Text : (RadioButton15.Checked ? RadioButton15.Text : RadioButton16.Checked ? RadioButton16.Text : null));
        o[5] = RadioButton17.Checked ? RadioButton17.Text : (RadioButton18.Checked ? RadioButton18.Text : (RadioButton19.Checked ? RadioButton19.Text : RadioButton20.Checked ? RadioButton20.Text : null));
        o[6] = RadioButton21.Checked ? RadioButton21.Text : (RadioButton22.Checked ? RadioButton22.Text : (RadioButton23.Checked ? RadioButton23.Text : RadioButton24.Checked ? RadioButton24.Text : null));
        o[7] = RadioButton25.Checked ? RadioButton25.Text : (RadioButton26.Checked ? RadioButton26.Text : (RadioButton27.Checked ? RadioButton27.Text : RadioButton28.Checked ? RadioButton28.Text : null));
        o[8] = RadioButton29.Checked ? RadioButton29.Text : (RadioButton30.Checked ? RadioButton30.Text : (RadioButton31.Checked ? RadioButton31.Text : RadioButton32.Checked ? RadioButton32.Text : null));
        o[9] = RadioButton33.Checked ? RadioButton33.Text : (RadioButton34.Checked ? RadioButton34.Text : (RadioButton35.Checked ? RadioButton36.Text : RadioButton36.Checked ? RadioButton36.Text : null));
        o[10] = RadioButton37.Checked ? RadioButton37.Text : (RadioButton38.Checked ? RadioButton38.Text : (RadioButton39.Checked ? RadioButton39.Text : RadioButton40.Checked ? RadioButton40.Text : null));

        for (int i = 0; i < 10; i++)
        {
            r1[i] = obj.Get_details("select answer from quiz_question where paper_id='" + id[i] + "'");
            if (o[i] == r1[i])
            {
                c++;
            }
            else if (o[i] == null)
            {
                attempt--;
            }
            else
            {
                w++;
            }


        }
        percentage = (c / 10) * 100;
        Response.Redirect("sreport.aspx?QUESTION ATTEMPT='" + attempt +"' &CORRECT QUESTION='" + c +"' &WRONG QUESTION='" + w +"'");
    }
}