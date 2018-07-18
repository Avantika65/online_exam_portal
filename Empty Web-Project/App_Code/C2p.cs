using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using NewDAL;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;
using System.Web.Services;


/// <summary>
/// Summary description for C2p
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class C2p : System.Web.Services.WebService {

    DbFunctions objFunc = new DbFunctions();
    public C2p () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string Show_Job_details(string jd,string Job_ID)
    {

        string str = "select * from Stud_job_details_view where comp_id=" + jd + " and job_id=" + Job_ID + "  for xml auto,elements";
        string value = objFunc.bindgrid_jdwise_ajax(str);
        return value;

    }

    [WebMethod]
      public string Show_SelPross(int cid,int jobid)
      {
        //string value = "";
        string pross = "";
        DataTable dt = objFunc.FillDataTable("select * from Stud_job_details_view where comp_id=" + Convert.ToInt32(cid) + " and job_id=" + Convert.ToInt32(jobid) + "");
        for (int i = 0; i < dt.Rows.Count; i++)
       {
           
           string sel_id = dt.Rows[i]["sel_pross"].ToString();
           DataTable dt2 = objFunc.FillDataTable("select sel_process from selprocess_Details where id in(" + sel_id + ")");
           //pross = dt2.Rows[0]["sel_process"].ToString();
           for (int k = 0; k < dt2.Rows.Count; k++)
           {
             if (pross == "")
                 pross = dt2.Rows[k]["sel_process"].ToString();
            else
                 pross = pross + "," + dt2.Rows[k]["sel_process"].ToString();
           }
                 
           
      }
        return pross;
    }

    [WebMethod]
    public string Show_Join_loc(int cid, int jobid)
    {
        //string value = "";
        string pross = "";
        DataTable dt = objFunc.FillDataTable("select * from Stud_job_details_view where comp_id=" + Convert.ToInt32(cid) + " and job_id=" + Convert.ToInt32(jobid) + "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            string sel_id = dt.Rows[i]["join_loc"].ToString();
            if (sel_id != "")
            {
                DataTable dt2 = objFunc.FillDataTable("select CityName from City where CityId in(" + sel_id + ")");
                //pross = dt2.Rows[0]["sel_process"].ToString();
                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    if (pross == "")
                        pross = dt2.Rows[k]["CityName"].ToString();
                    else
                        pross = pross + "," + dt2.Rows[k]["CityName"].ToString();
                }
            }
            else
            {
                pross = dt.Rows[i]["other_Loc"].ToString();
            }


        }
        return pross;
    }

    [WebMethod]
    public int insertApply_detls(int aply,int J_Idd)
    {
        string st_name ="";
        int branch =0;
        int course =0;
        string batch ="";
        int sem = 0;
        int comp_id = 0;
        int job_id = 0;
        decimal ctOff = 0;
        int Jbak = 0;
        int Jgap = 0;
        int Jcoff = 0;
        string status = "";
        int Mmarks = 0;
        decimal Obt = 0.0m;
        
        int bak = Convert.ToInt32(objFunc.Get_details("select COUNT(StudentID) from ibackpaperDetails where StudentID=" + Application["uid"] + ""));
        int gap = Convert.ToInt32(objFunc.Get_details("select SUM(Gap) from StudentAcademicDetail where StudentID=" + Application["uid"] + ""));
        DataTable dt = objFunc.FillDataTable("select top 1 * from student_por_view where studentid=" + Application["uid"] + "");
        DataTable dt1 = objFunc.FillDataTable("select * from Stud_Aply_Cid_View where comp_id=" + Convert.ToInt32(aply) + " and job_id=" + J_Idd + "");
        int checkExist = Convert.ToInt32(objFunc.Get_details("select count(*) from iESEresult where studentId=" + Application["uid"] + ""));
        if (checkExist != 0)
        {
            DataTable dt2 = objFunc.FillDataTable("select SUM(isnull(MaxMrks,0)) as MaxMrks,SUM(isnull(MarksObtain,0)) as MarksObtain from iESEresult where studentId=" + Application["uid"] + "");
            if (dt2.Rows.Count > 0)
            {
                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    string de = dt2.Rows[k]["MarksObtain"].ToString();
                    Mmarks = Convert.ToInt32(dt2.Rows[k]["MaxMrks"].ToString());
                    Obt = Convert.ToDecimal(de);
                }
                ctOff = (Obt * 100) / Mmarks;
            }
        }
        else
        {
            ctOff = 0.00M;
        }
        DataTable DTmrk = objFunc.FillDataTable("select * from Job_Qualification_percentage where Job_id=" + J_Idd + "");

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                st_name = dt.Rows[i]["StudentName"].ToString();
                branch = Convert.ToInt32(dt.Rows[i]["Specialization"].ToString());
                course = Convert.ToInt32(dt.Rows[i]["CourseID"].ToString());
                batch = dt.Rows[i]["Batch"].ToString();
                sem = Convert.ToInt32(dt.Rows[i]["SemesterID"].ToString());
            }
        }

       

        //=================================================Job DEtail
        decimal J_Hig_S = Convert.ToDecimal(objFunc.Get_details("select (isnull(Cut_off,0)) from Job_Qualification_percentage where Job_id=" + J_Idd + " and Qualification_id='1'"));
        decimal J_InterM = Convert.ToDecimal(objFunc.Get_details("select (isnull(Cut_off,0))from Job_Qualification_percentage where Job_id=" + J_Idd + " and Qualification_id='2'"));
        decimal J_UG = Convert.ToDecimal(objFunc.Get_details("select (isnull(Cut_off,0)) from Job_Qualification_percentage where Job_id=" + J_Idd + " and Qualification_id='3'"));
        decimal J_PG = Convert.ToDecimal(objFunc.Get_details("select (isnull(Cut_off,0)) from Job_Qualification_percentage where Job_id=" + J_Idd + " and Qualification_id='4'"));
        //================================================STUD_Detail
        int count_S_High = 0;
        int count_S_InterM = 0;
        int Count_S_UG = 0;
        decimal S_High = 0.0M;
        decimal S_InterM = 0.0M;
        decimal S_UG = 0.0M;

        count_S_High = Convert.ToInt32(objFunc.Get_details("select count(*) from StudentAcademicDetail where StudentID=" + Application["uid"] + " and QualificationID='1'"));
        if (count_S_High > 0)
        {
          S_High = Convert.ToDecimal(objFunc.Get_details("select isnull(RankPercentage,0) from StudentAcademicDetail where StudentID=" + Application["uid"] + " and QualificationID='1'"));
        }

        count_S_InterM = Convert.ToInt32(objFunc.Get_details("select count(*) from StudentAcademicDetail where StudentID=" + Application["uid"] + " and QualificationID='2'"));
        if (count_S_InterM > 0)
        {
            S_InterM = Convert.ToDecimal(objFunc.Get_details("select isnull(RankPercentage,0) from StudentAcademicDetail where StudentID=" + Application["uid"] + " and QualificationID='2'"));
        }
        
        string nature = objFunc.Get_details("select CourseNature from course where CourseId=" + course + "");
        if (nature == "PG")
        {
            Count_S_UG = Convert.ToInt32(objFunc.Get_details("select count(*) from StudentAcademicDetail where StudentID=" + Application["uid"] + " and QualificationID='3'"));
            if (Count_S_UG > 0)
            {
                S_UG = Convert.ToDecimal(objFunc.Get_details("select isnull(RankPercentage,0) from StudentAcademicDetail where StudentID=" + Application["uid"] + " and QualificationID='3'"));
            }
        }
        else 
        {
            S_UG = ctOff;
        }
        decimal S_PG = ctOff;
        //===============================================================

        
        if (dt1.Rows.Count > 0)
        {
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                comp_id = Convert.ToInt32(dt1.Rows[j]["Comp_ID"].ToString());
                job_id = Convert.ToInt32(dt1.Rows[j]["job_id"].ToString());
                Jbak = Convert.ToInt32(dt1.Rows[j]["b_log"].ToString());
                Jgap = Convert.ToInt32(dt1.Rows[j]["e_gap"].ToString());
                //Jcoff = Convert.ToInt32(dt1.Rows[j]["cutt_off"].ToString());
            }
        }
        if (nature == "PG")
        {
            if (Jbak >= bak && Jgap >= gap && J_Hig_S <= S_High && J_InterM <= S_InterM && J_UG <= S_UG && J_PG <= S_PG)
            {
                status = "Applied";
            }
            else
            {
                status = "Waiting";
            }
        }
        else
        {
            if (Jbak >= bak && Jgap >= gap && J_Hig_S <= S_High && J_InterM <= S_InterM && J_UG <= S_UG)
            {
                status = "Applied";
            }
            else
            {
                status = "Waiting";
            }
        }

        string sjd = "insert into stud_applydetails (job_id, comp_id, stud_id, stud_name, branch_id, batch, Sem_ID, course_id, cut_off, backlog, status, edu_gap, session_id, inst_id) values (" + job_id + ", " + comp_id + "," + Application["uid"] + ", '" + st_name + "'," + branch + ",'" + batch + "'," + sem + "," + course + "," + ctOff + ", " + bak + ", '" + status + "'," + gap + ",'" + Application["sesnID"] + "'," + Application["instID"] + ")";
        int  value = objFunc.ExecuteDML(sjd);
        return value;
        
    }

    [WebMethod]
    public string Status(string sts,string JJ_ID)
    {
        string stts="";
        stts = objFunc.Get_details("select Permission from stud_applydetails where comp_id=" + Convert.ToInt32(sts) + " and job_id=" + Convert.ToInt32(JJ_ID) + " and stud_id=" + Application["uid"] + "");
        if (stts == "")
        {
            stts = objFunc.Get_details("select Status from stud_applydetails where comp_id=" + Convert.ToInt32(sts) + " and job_id=" + Convert.ToInt32(JJ_ID) + " and stud_id=" + Application["uid"] + "");
        }
        return stts;
        
    }

    [WebMethod]
    public string Show_SelStud_details(string jd,string SID,string JBID)
    {

        string str = "select * from Selected_Student_View where comp_id=" + jd + " and Stud_Id=" + SID + " and job_id=" + JBID + " for xml auto,elements";
        string value = objFunc.bindgrid_jdwise_ajax(str);
        return value;

    }


    [WebMethod]
    public string Bind_Qualification_Criteria(string jobID)
    {
        //string stdid = Application["uid"].ToString();
        //int batchid = Convert.ToInt32(Application["batchID"].ToString());
        DataTable dt = new DataTable();
        StringBuilder sb1 = new StringBuilder();
        dt = objFunc.FillDataTable("select * from Job_Eligble_Criteria_VW where Job_id='" + jobID + "' ORDER BY DisplayOrder DESC");
        if (dt.Rows.Count > 0)
        {

            sb1.Append("<table style='height:100%; border-radius:5px; width:100%;'>");
            sb1.Append("<tr style='background-color:#FBF5EF;'><td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; height:20px;'>Qualification</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; height:20px;'>Percentage Req.</td></tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //int subjectid = Convert.ToInt32(dt.Rows[i]["SubjectId"].ToString());
                //DataSet ds = objFunc.Student_Attendance(Convert.ToInt32(stdid), subjectid, Convert.ToInt32(semid), Convert.ToInt32(batchid), session);
                //string classposition = "", ClassAve = "";
                //foreach (DataRow row in ds.Tables[1].Rows)
                //{
                //    classposition = row["ronum"].ToString();
                //}
                //foreach (DataRow row in ds.Tables[2].Rows)
                //{
                //    ClassAve = row["classAve"].ToString();
                //}
                sb1.Append("<tr style='background-color:#FBF5EF;'><td style='text-align:center; color:black; font-size:11px;font-weight: bold;  line-height: 10pt;height:25px;'>" + dt.Rows[i]["ProfName"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold;  line-height: 10pt;height:25px;'>" + dt.Rows[i]["Cut_off"] + "</td></tr>");
            }
            sb1.Append("</table>");
        }
        return sb1.ToString();
    }



}
