using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.ComponentModel;
using System.Security.Cryptography;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class Calender_details : System.Web.Services.WebService
{
    DbFunctions dbfn = new DbFunctions();
    EXamSVC sv = new EXamSVC();
    public Calender_details()
    {
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string hodiday_details_show(string month, string day, string year)
    {
        string session_id = Application["SessionID"].ToString();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int empid = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "Select LeaveName from nonteachingday where day='" + day + "' and month='" + month + "' and year='" + year + "' and sessionID='" + session_id + "' and  instituteID=" + insti_id + "";
        string value = dbfn.bind_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string todo_details_show(string tododate)
    {
        string session_id = Application["SessionID"].ToString();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int empid = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "Select TodoName from ToDoList where empid=" + empid + " and  instituteID=" + insti_id + " and EntryDate='" + tododate + "'";
        string value = dbfn.bind_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string inser_hodiday_details_show(string TodoName, string EntryDate, string TodoDate)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "INSERT INTO [ToDoList]([TodoName],[EntryDate],[InstituteID],[TodoDate],[Status],[empid],[CompletionDate])VALUES('" + TodoName + "','" + EntryDate + "'," + insti_id + ",'" + TodoDate + "','Y'," + faculty_id + ",'" + TodoDate + "')";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string get_Student_attendance_details_show(string subjectid, string instituteid, string sessionid, string empid, string courseid, string semid,string value)
    {
        DataTable dt = new DataTable();
        StringBuilder sb1 = new StringBuilder();
        dt = dbfn.get_student_attendance_details_popup(subjectid, instituteid, sessionid, empid, courseid,semid);
        sb1.Append("<table style='height:135px; border-radius:5px; width:100%;'>");
        sb1.Append("<tr style='background-color:#0489B1;'><td colspan=3 style='text-align:left; color:white; font-size:11px; border: 0px solid white;'> Faculty : " + dt.Rows[0]["FacultyName"] + "</td> <td colspan=3 style='text-align:right; color:white; font-size:11px; border: 0px solid white;'>Course: " + dt.Rows[0]["CourseName"] + "</td></tr>");
        sb1.Append("<tr style='background-color:#0489B1;'><td colspan=2 style='text-align:left; color:white; font-size:11px; border: 0px solid white;'> Suject Name : " + dt.Rows[0]["SubjectName"] + "</td> <td colspan=3 style='text-align:right; color:white; font-size:11px; border: 0px solid white;'>Percentage: " + value + "</td></tr>");
        sb1.Append("<tr style='background-color:#0489B1;'><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>RollNo</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Student Name</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Total Class</th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Present</th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Percentage</th></td></tr>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb1.Append("<tr style='background-color:white;'><td style='text-align:center; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["RollNo"] + "</td><td style='text-align:left; color:#5E87B0; font-size:11px; border: 1px solid #507AA4; line-height: 10pt;'>" + dt.Rows[i]["StudentName"] + "</td></td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["TotalClass"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["Present"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["Percentage"] + "</td></tr>");
        }
        sb1.Append("</table>");
        return sb1.ToString();
    }

    [WebMethod]
    public string get_Student_examination_attendance_details_show(string subjectid, string instituteid, string sessionid, string empid, string courseid,string value1)
    {
        DataTable dt = new DataTable();
        StringBuilder sb1 = new StringBuilder();
        dt = dbfn.get_student_examination_attendance_details_popup(subjectid, instituteid, sessionid, empid, courseid);
        sb1.Append("<table style='height:135px; border-radius:5px; width:100%;'>");
        sb1.Append("<tr style='background-color:#0489B1;'><td colspan=3 style='text-align:left; color:white; font-size:11px;border: 0px solid white;'> Faculty : " + dt.Rows[0]["FacultyName"] + "</td> <td colspan=3 style='text-align:right; color:white; font-size:11px;  border: 0px solid white'>Course: " + dt.Rows[0]["CourseName"] + "</td></tr>");
        sb1.Append("<tr style='background-color:#0489B1;'><td colspan=3 style='text-align:left; color:white; font-size:11px; border: 0px solid white'> Suject Name : " + dt.Rows[0]["SubjectName"] + "</td> <td colspan=3 style='text-align:right; color:white; font-size:11px; border: 0px solid white'>Percentage: " + value1 + "</td></tr>");
        sb1.Append("<tr style='background-color:#0489B1;'><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>RollNo</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Student Name</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Total Class</th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Present</th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Percentage</th></tr>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb1.Append("<tr style='background-color:white; '><td style='text-align:center; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["RollNo"] + "</td><td style='text-align:left; color:#5E87B0; font-size:11px; border: 1px solid #507AA4; line-height: 10pt;'>" + dt.Rows[i]["StudentName"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["TotalClass"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["Present"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["Percentage"] + "</td></tr>");
        }

        sb1.Append("</table>");
        return sb1.ToString();
    }

    [WebMethod]
    public string get_Student_examination_exam_details_show(string subjectid, string instituteid, string sessionid, string empid, string courseid,string value1)
    {
        DataTable dt = new DataTable();
        StringBuilder sb1 = new StringBuilder();
        dt = dbfn.get_student_examination_exam_details_popup(subjectid, instituteid, sessionid, empid, courseid);
        sb1.Append("<table style='height:135px; border-radius:5px; width:100%;'>");
        sb1.Append("<tr style='background-color:#0489B1;'><td colspan=3 style='text-align:left; color:white; font-size:11px; border: 0px solid white;'> Faculty : " + dt.Rows[0]["FacultyName"] + "</td> <td colspan=3 style='text-align:right; color:white; font-size:11px; border: 0px solid white;'>Course: " + dt.Rows[0]["CourseName"] + "</td></tr>");
        sb1.Append("<tr style='background-color:#0489B1;'><td colspan=2 style='text-align:left; color:white; font-size:11px; border: 0px solid white;'> Suject Name : " + dt.Rows[0]["SubjectName"] + "</td> <td colspan=1 style='text-align:right; color:white; font-size:11px; border: 0px solid white;'>Percentage: " + value1 + "</td> <td colspan=2 style='text-align:right; color:white; font-size:11px; border: 0px solid white;'>Batch Name: " + dt.Rows[0]["batch_name"] + "</td> </tr>");
        sb1.Append("<tr style='background-color:#0489B1;'><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>RollNo</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Student Name</th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Marks </th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Marks Obtained</th> <th style='text-align:Center; color:white; font-size:11px; border: 1px solid white;'>Test Name</th></tr>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb1.Append("<tr style='background-color:white;'><td style='text-align:center; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["RollNo"] + "</td><td style='text-align:left; color:#5E87B0; font-size:11px; border: 1px solid #507AA4; line-height: 10pt;'>" + dt.Rows[i]["StudentName"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["mMarks"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["marksObtained"] + "</td><td style='text-align:right; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["Test_Name"] + "</td></tr>");
        }
        sb1.Append("</table>");
        return sb1.ToString();
    }

    [WebMethod]
    public string BindTopic_value(string subjectid)
    {
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "select TopicName,TopicId from Topic_Mast where SubjectId='" + subjectid + "' and FacultyId=" + Convert.ToInt32(faculty_id) + " order by topicid for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bindgroup_value(string groupid)
    {
        string str = "";
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        if (groupid == "1")
        {
            str = "SELECT distinct (empName+' '+isnull(lastName,''))as empname, empId FROM Employee_Master  WHERE  ( empId <> " + faculty_id + ") and deptID=(Select deptid from Employee_Master where empId=" + faculty_id + ") order by empname for xml auto,elements";
        }
        else
        {
            str = "SELECT    distinct Batch_Master.Batch_Name, FacultySubjectChoice.Batch_ID FROM FacultySubjectChoice INNER JOIN Batch_Master ON FacultySubjectChoice.Batch_ID = Batch_Master.Batch_ID WHERE     (FacultySubjectChoice.FacultyId = " + faculty_id + ") order by Batch_Name for xml auto,elements";
        }
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string inser_share_group_details_show(string groptype, string groupdetails, string value1)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "INSERT INTO Share_details_group([share_type],[facultyid_from],[batch_id],[outmsg],[share_out_date],[facultid_for_send],[instituteID])VALUES('" + Convert.ToInt32(groptype) + "',";
           
        if(groptype=="1")
           {
               str = str+" "+faculty_id+",NULL,'"+value1+"',getdate(),"+Convert.ToInt32(groupdetails)+","+insti_id+")";
           }
        if(groptype=="2")
         {
               str = str+" "+faculty_id+","+Convert.ToInt32(groupdetails)+",'"+value1+"',getdate(),NULL,"+insti_id+")";
         }
        string value = dbfn.insert_holiday_non_teaching(str);
        StringBuilder sb = new StringBuilder();
        if (Convert.ToInt32(value) > 0)
        {
            string str2 = "SELECT     Share_details_group.outmsg, CAST(Share_details_group.share_out_date as varchar)  share_out_date, isnull(Share_details_group.facultid_for_send,0) as facultid_for_send, Share_details_group.facultyid_from, isnull(Share_details_group.batch_id,0)as batch_id, Share_details_group.share_type, Employee_Master.empName, Batch_Master.Batch_Name, Employee_Master_1.empName AS empname1 FROM   Share_details_group INNER JOIN Employee_Master ON Share_details_group.facultyid_from = Employee_Master.empId LEFT OUTER JOIN Employee_Master AS Employee_Master_1 ON Share_details_group.facultid_for_send = Employee_Master_1.empId LEFT OUTER JOIN Batch_Master ON Share_details_group.batch_id = Batch_Master.Batch_ID WHERE(Share_details_group.facultyid_from = " + faculty_id + ") AND (Share_details_group.instituteID = " + insti_id + ") OR (Share_details_group.facultid_for_send = " + faculty_id + ") ORDER BY id asc";
            DataTable dt = new DataTable();
            dt = dbfn.Get_details_Datatable(str2);
            if (dt.Rows.Count > 0)
            {
                sb.Append("<table style='width:100%;' cellpadding=0  cellspacing=0>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["facultid_for_send"]) != 0 && Convert.ToInt32(dt.Rows[i]["facultyid_from"]) == faculty_id)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style='width:50%; text-Align:left;'><div style=' width:100%; font-size:11px; border: thin outset #C0C0C0;-webkit-box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.4); -moz-box-shadow: 0px 1px 6px rgba(23, 69, 88, .5); -webkit-border-radius: 12px; -moz-border-radius: 7px;  border-radius: 7px; background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, white), color-stop(15%, white), color-stop(100%, #D7E9F5)); background: -moz-linear-gradient(top, white 0%, white 55%, #D5E4F3 130%); '> <font color='#0174DF' size='1pt'>" + dt.Rows[i]["empName"] + "-->></font> <font color='#610B0B' size='1pt'>" + dt.Rows[i]["empname1"] + "</font>  <br /> <font color='Black' size='2pt'>" + dt.Rows[i]["outmsg"] + "</font><br/> <font color='#610B0B' size='1'>" + dt.Rows[i]["share_out_date"] + "</font></div><br/></td><td style='width:50%; font-size:11px; text-Align:Right;'></td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dt.Rows[i]["facultid_for_send"]) == faculty_id)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style='width:50%; text-Align:left;'></td><td style='width:50%; font-size:11px; text-Align:Right;'><div style=' width:100%; font-size:11px; border: thin outset #C0C0C0;-webkit-box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.4); -moz-box-shadow: 0px 1px 6px rgba(23, 69, 88, .5); -webkit-border-radius: 12px; -moz-border-radius: 7px;  border-radius: 7px; background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, white), color-stop(15%, white), color-stop(100%, #D7E9F5)); background: -moz-linear-gradient(top, white 0%, white 55%, #D5E4F3 130%); '> <font color='#610B0B' size='1pt'>" + dt.Rows[i]["empName"] + "-->></font>  <font color='#0174DF' size='1pt'>" + dt.Rows[i]["empname1"] + "</font>  <br />  <font color='Black' size='2pt'>" + dt.Rows[i]["outmsg"] + "</font><br/> <font color='#610B0B' size='1'>" + dt.Rows[i]["share_out_date"] + "</font></div><br/></td>");
                        sb.Append("</tr>");
                    }

                    if (Convert.ToInt32(dt.Rows[i]["facultyid_from"]) == faculty_id && Convert.ToInt32(dt.Rows[i]["batch_id"]) != 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style='width:50%; text-Align:left;'><div style='width:100%; font-size:11px; border: thin outset #C0C0C0;-webkit-box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.4); -moz-box-shadow: 0px 1px 6px rgba(23, 69, 88, .5); -webkit-border-radius: 12px; -moz-border-radius: 7px;  border-radius: 7px; background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, white), color-stop(15%, white), color-stop(100%, #D7E9F5)); background: -moz-linear-gradient(top, white 0%, white 55%, #D5E4F3 130%); '> <font color='#0174DF' size='1pt'>" + dt.Rows[i]["empName"] + "-->></font> <font color='#610B0B' size='1pt'>" + dt.Rows[i]["Batch_Name"] + " </font> <br />  <font color='Black' size='2pt'>" + dt.Rows[i]["outmsg"] + "</font><br/> <font color='#610B0B' size='1'>" + dt.Rows[i]["share_out_date"] + "</font></div><br/></td><td style='width:50%; font-size:11px; text-Align:Right;'></td>");
                        sb.Append("</tr>");
                    }
                }
                sb.Append("</table>");
            }
        }
        return sb.ToString(); ;
    }

    [WebMethod]
    public string Bindshare_value_onload()
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string str2 = "SELECT     Share_details_group.outmsg, CAST(Share_details_group.share_out_date as varchar)  share_out_date, isnull(Share_details_group.facultid_for_send,0) as facultid_for_send, Share_details_group.facultyid_from, isnull(Share_details_group.batch_id,0)as batch_id, Share_details_group.share_type, Employee_Master.empName, Batch_Master.Batch_Name, Employee_Master_1.empName AS empname1 FROM   Share_details_group INNER JOIN Employee_Master ON Share_details_group.facultyid_from = Employee_Master.empId LEFT OUTER JOIN Employee_Master AS Employee_Master_1 ON Share_details_group.facultid_for_send = Employee_Master_1.empId LEFT OUTER JOIN Batch_Master ON Share_details_group.batch_id = Batch_Master.Batch_ID WHERE(Share_details_group.facultyid_from = " + faculty_id + ") AND (Share_details_group.instituteID = " + insti_id + ") OR (Share_details_group.facultid_for_send = " + faculty_id + ") ORDER BY id asc";
        DataTable dt = new DataTable();
        StringBuilder sb = new StringBuilder();
        dt = dbfn.Get_details_Datatable(str2);
        if (dt.Rows.Count > 0)
        {
            sb.Append("<table style='width:100%;' cellpadding=0  cellspacing=0>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (Convert.ToInt32(dt.Rows[i]["facultid_for_send"]) != 0 && Convert.ToInt32(dt.Rows[i]["facultyid_from"]) == faculty_id)
                {
                    sb.Append("<tr>");
                    sb.Append("<td style='width:50%; text-Align:left;'><div style=' width:100%; font-size:11px; border: thin outset #C0C0C0;-webkit-box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.4); -moz-box-shadow: 0px 1px 6px rgba(23, 69, 88, .5); -webkit-border-radius: 12px; -moz-border-radius: 7px;  border-radius: 7px; background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, white), color-stop(15%, white), color-stop(100%, #D7E9F5)); background: -moz-linear-gradient(top, white 0%, white 55%, #D5E4F3 130%); '> <font color='#0174DF' size='1pt'>" + dt.Rows[i]["empName"] + "-->></font> <font color='#610B0B' size='1pt'>" + dt.Rows[i]["empname1"] + "</font>  <br /> <font color='Black' size='2pt'>" + dt.Rows[i]["outmsg"] + "</font><br/> <font color='#610B0B' size='1'>" + dt.Rows[i]["share_out_date"] + "</font></div><br/></td><td style='width:50%; font-size:11px; text-Align:Right;'></td>");
                    sb.Append("</tr>");
                }
                if (Convert.ToInt32(dt.Rows[i]["facultid_for_send"]) == faculty_id)
                {
                    sb.Append("<tr>");
                    sb.Append("<td style='width:50%; text-Align:left;'></td><td style='width:50%; font-size:11px; text-Align:Right;'><div style=' width:100%; font-size:11px; border: thin outset #C0C0C0;-webkit-box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.4); -moz-box-shadow: 0px 1px 6px rgba(23, 69, 88, .5); -webkit-border-radius: 12px; -moz-border-radius: 7px;  border-radius: 7px; background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, white), color-stop(15%, white), color-stop(100%, #D7E9F5)); background: -moz-linear-gradient(top, white 0%, white 55%, #D5E4F3 130%); '> <font color='#610B0B' size='1pt'>" + dt.Rows[i]["empName"] + "-->></font>  <font color='#0174DF' size='1pt'>" + dt.Rows[i]["empname1"] + "</font>  <br />  <font color='Black' size='2pt'>" + dt.Rows[i]["outmsg"] + "</font><br/> <font color='#610B0B' size='1'>" + dt.Rows[i]["share_out_date"] + "</font></div><br/></td>");
                    sb.Append("</tr>");
                }

                if (Convert.ToInt32(dt.Rows[i]["facultyid_from"]) == faculty_id && Convert.ToInt32(dt.Rows[i]["batch_id"]) != 0)
                {
                    sb.Append("<tr>");
                    sb.Append("<td style='width:50%; text-Align:left;'><div style='width:100%; font-size:11px; border: thin outset #C0C0C0;-webkit-box-shadow: 0px 0px 12px rgba(0, 0, 0, 0.4); -moz-box-shadow: 0px 1px 6px rgba(23, 69, 88, .5); -webkit-border-radius: 12px; -moz-border-radius: 7px;  border-radius: 7px; background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, white), color-stop(15%, white), color-stop(100%, #D7E9F5)); background: -moz-linear-gradient(top, white 0%, white 55%, #D5E4F3 130%); '> <font color='#0174DF' size='1pt'>" + dt.Rows[i]["empName"] + "-->></font> <font color='#610B0B' size='1pt'>" + dt.Rows[i]["Batch_Name"] + " </font> <br />  <font color='Black' size='2pt'>" + dt.Rows[i]["outmsg"] + "</font><br/> <font color='#610B0B' size='1'>" + dt.Rows[i]["share_out_date"] + "</font></div><br/></td><td style='width:50%; font-size:11px; text-Align:Right;'></td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
        }
        return sb.ToString();
    }

    [WebMethod]
    public string BindSubTopic_value(string subjectid, string topicid)
    { 
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string session_id = Application["SessionID"].ToString();
        string str = "select SubTopicName,SubTopicID from SubTopicMaster where  SubjectID=" + subjectid + " and FacultyId=" +Convert.ToInt32(faculty_id)+ " and Sessionid='" + session_id + "' and TopicId=" +Convert.ToInt32(topicid) + "  for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string bind_attendace_data()
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int empid = Convert.ToInt32(Application["emp_id"].ToString());
        string str1 = "SELECT CardNo FROM  Employee_Master WHERE (empId = "+empid+")";
        int card_no = dbfn.get_card_number_of_employee(str1);
        int number_of_present = 0;
        int number_of_weekof = 0;
        int number_of_holiday = 0;
        int number_of_leave = 0;
        string[] months={"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
        StringBuilder sb=new StringBuilder();
     
            sb.Append ("<table style='border: 1px groove #C0C0C0;' cellpadding=0  cellspacing=0>");
            sb.Append ("<tr>");
            sb.Append ( "<th style='font-size:11px; background-color:#F5DA81;border: 1px solid #507AA4; width:2%;text-align:center;'>M/D</th>");
            for (var i = 1; i <= 31; i++) {
            sb.Append ("<th style='font-size:11px; background-color:#F6E3CE;border: 1px solid #507AA4; width:2%; text-align:center;'>" + i + "</th>");
            }
            sb.Append ("</tr>");
            for (var k = 0; k < months.Length; k++) {
               sb.Append ("<tr>");
               sb.Append ("<td style='font-size:13px; background-color:#FE9A2E;color:blue; border: 1px groove #507AA4; text-align:center;'>" + months[k].Substring(0,3) + "</td>");
      
           for (var j = 1; j <= 31; j++) {
           string str = "select COUNT(*) from AttendanceData where Enrollno="+card_no+" and VYear="+Convert.ToInt32(DateTime.Now.Year)+" and VMonth="+Convert.ToInt32(k+1)+" and Vday="+Convert.ToInt32(j)+"";
           int value = dbfn.bind_attendance_data_for_leave_details(str);
           if (value > 0)
           {
               sb.Append("<td style='background-color:green;border: 1px solid #507AA4; width:2%;'></td>");
               number_of_present = number_of_present + 1;
           }
           else
           {
               if ((k + 1) <= DateTime.Now.Month)
               {
                   string str2 = "SELECT  COUNT(*) from  NonTeachingDay where Year=" + Convert.ToInt32(DateTime.Now.Year) + " and Month= " + Convert.ToInt32(k + 1) + " and Day='" + Convert.ToInt32(j) + "' and LeaveName='Sunday'";
                   int value1 = dbfn.bind_attendance_data_for_leave_details(str2);
                   if (value1 > 0)
                   {
                       sb.Append("<td style='background-color:#01A9DB; border: 1px solid #507AA4; width:2%;  cursor:pointer;' title='Sunday'></td>");
                       number_of_weekof = number_of_weekof + 1;
                   }
                   else
                   {
                      string str3 = "SELECT  COUNT(*)  from  NonTeachingDay where Year=" + Convert.ToInt32(DateTime.Now.Year) + " and Month= " + Convert.ToInt32(k + 1) + " and Day='" + Convert.ToInt32(j) + "' and LeaveName<>'Sunday'";
                      int value2 = dbfn.bind_attendance_data_for_leave_details(str3);
                     
                      if (value2 > 0)
                       {
                           string str10 = "SELECT  LeaveName from  NonTeachingDay where Year=" + Convert.ToInt32(DateTime.Now.Year) + " and Month= " + Convert.ToInt32(k + 1) + " and Day='" + Convert.ToInt32(j) + "' and LeaveName<>'Sunday'";
                           DataTable value5 = dbfn.Get_details_Datatable(str10);
                           if (value5.Rows.Count > 0)
                           {
                               sb.Append("<td style='background-color:orange;border: 1px solid #507AA4; width:2%; cursor:pointer;' title='" + value5.Rows[0]["LeaveName"].ToString() + "'></td>");
                               number_of_holiday = number_of_holiday + 1;
                           }
                           else
                           {
                               sb.Append("<td style='background-color:orange;border: 1px solid #507AA4; width:2%;  cursor:pointer;' title=''></td>");
                               number_of_holiday = number_of_holiday + 1;
                           }
                       }
                       else
                       {
                           string str4 = "SELECT COUNT(*)  FROM  Emp_Leave_Record_dtls where  EmpId=" + empid + " and month(LStart_dt)=" + Convert.ToInt32(k + 1) + " and YEAR(LStart_dt)=" + Convert.ToInt32(DateTime.Now.Year) + " and Day(LStart_dt)=" + Convert.ToInt32(j) + "";
                           int value3 = dbfn.bind_attendance_data_for_leave_details(str4);
                           if (value3 > 0)
                           {
                               sb.Append("<td style='background-color:blue;border: 1px solid #507AA4; width:2%;'></td>");
                               number_of_leave = number_of_leave + 1;
                           }
                           else
                           {
                                   sb.Append("<td style='background-color:red;border: 1px solid #507AA4; width:2%;'></td>");
                           }
                       }
                   }
               }
               else
               {
                       sb.Append("<td style='background-color:white;border: 1px solid #507AA4; width:2%;'></td>");
               }
           }
        }
       sb.Append ("</tr>");
    }
    sb.Append ("</table>");
    sb.Append("<div style='width:100%;'>");
    sb.Append("<table style='width:100%;'>");
    sb.Append("<tr>");
    sb.Append("<td colspan=5>");
    sb.Append("</br>");
    sb.Append("</td>");
    sb.Append("</tr>");
    sb.Append("<tr>");
    sb.Append("<td style='color:black; font-size:9pt; width:10%; '>&nbsp; </br></td>");
    sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/blue1.png' style='width:20px; height:20px;' /> Number of Leave : " + number_of_leave + "</td>");
    sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/green1.png' style='width:20px; height:20px;' /> Number of Present : " + number_of_present + "</td>");
    sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/cyan1.png' style='width:20px; height:20px;' />Number of WeeklyOff : " + number_of_weekof + "</td>");
    sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/orange1.png' style='width:20px; height:20px;' />Number of Holiday : " + number_of_holiday + "</td>");
    sb.Append("</tr>");
    sb.Append("</table>");
    sb.Append("</div>");

     return sb.ToString();
    }


    [WebMethod]
    public string bind_single_leave_details(string leaveid,string leavetype,string status)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string session_id = Application["SessionID"].ToString();
        DataTable dt = dbfn.bind_leave_details_single(faculty_id, insti_id, session_id, leaveid, leavetype, status);
        StringBuilder sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            sb.Append("<div style='width:100%; height:30px;'>");
            sb.Append("<table style='width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td  style='text-align:right; color:white; font-size:15px; border:0px solid white;'> <img src='../images/close.png' onclick='close_popup();' style='cursor:pointer;'/></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</div>");
            sb.Append("<div style='width:100%; height:240px; overflow:auto; float:left;'>");
            sb.Append("<table style='border-radius:5px; width:100%;' cellpadding=0  cellspacing=0>");
            sb.Append("<tr style='background-color:#0489B1;'>");
            sb.Append("<td colspan=3 style='text-align:Center; color:white; font-size:15px; border: 0px solid white;'>Employee Leave Details</td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:#0489B1;'>");
            sb.Append("<td style='text-align:left; color:white; font-size:11px; border: 0px solid white;'>Employee Id: " + dt.Rows[0]["userid"].ToString().ToUpper() + "</td><td style='text-align:Center; color:white; font-size:11px; border: 0px solid white;'>Employee Code: " + dt.Rows[0]["empcode"].ToString().ToUpper() + "</td><td style='text-align:Right; color:white; font-size:11px; border: 0px solid white; padding-right:10px;'>Session: " + dt.Rows[0]["sessionid"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:#0489B1;'>");
            sb.Append("<td style='text-align:left; color:white; font-size:11px; border: 0px solid white;'>Leave Id: " + dt.Rows[0]["leaveid"].ToString().ToUpper() + "</td><td style='text-align:Center; color:white; font-size:11px; border: 0px solid white;'>Leave Type: " + dt.Rows[0]["leave_type"].ToString().ToUpper() + "</td><td style='text-align:Right; color:white; font-size:11px; border: 0px solid white; padding-right:10px;'>Status: " + dt.Rows[0]["status"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:#0489B1;'>");
            sb.Append("<th style='text-align:Center; color:white; font-size:11px; border: 1px solid white; height:30px;'>Application No</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white; height:30px;'>Leave Date</th><th style='text-align:Center; color:white; font-size:11px; border: 1px solid white; '>Reason</th>");
            sb.Append("</tr>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<tr style='background-color:white;'>");
                sb.Append("<td style='text-align:center; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["Application_No"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["LeaveDate"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:#5E87B0; font-size:11px; border: 1px solid #507AA4;'>" + dt.Rows[i]["ReasonofL"].ToString() + "</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("</div>");

        }
        else
        {
            sb.Append("0");
        }
        return sb.ToString();
      
    }

    [WebMethod]
    public string Bind_search_Records(string SarchRecord)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string chk = String.Empty;
        string str = "";
        if (SarchRecord != "")
        {
            str = SarchRecord.Substring(0, 1);

            char charNoVar = Convert.ToChar(str);
            if (Char.IsDigit(charNoVar))
            {
                chk = "&";
            }
            else if (Char.IsLetter(charNoVar))
            {
                chk = "*";
            }
            else if (Char.IsWhiteSpace(charNoVar))
            {
                chk = "*";
            }
        }
        
        string Searched_Record = "";

        if (chk == "*")
        {
            Searched_Record = "select StudentName +' - '+ FatherName +' ['+ RegNo +'] ' as TextName, studentID as TextID  from StudentReg as TableName where StudentName like '" + SarchRecord + "%' and InstituteID=" + insti_id + " order by StudentName for xml auto,elements";

        }

        else if (chk == "&")
        {
            Searched_Record = "select UniversityRollNo as TextName, studentID as TextID  from StudentRollNo as TableName where UniversityRollNo like '" + SarchRecord + "%' and InstituteID=" + insti_id + " order by UniversityRollNo for xml auto,elements";

        }

        else
        {
            Searched_Record = "select StudentName +'-'+ FatherName +'['+ RegNo +']' as TextName, studentID as TextID  from StudentReg as TableName where StudentName like '" + SarchRecord + "%' and InstituteID=" + insti_id + " order by StudentName for xml auto,elements";

        }
        
        string value = dbfn.bindgrid_jdwise_ajax(Searched_Record);
        return value;
    }


    [WebMethod]
    public string bind_attendace_data_emp(string empid)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str1 = "SELECT CardNo FROM  Employee_Master WHERE (empId = " + empid + ")";
        string strr1 = "Select joinDate from Employee_Master where (empid=" + empid + ")";
        int card_no = dbfn.get_card_number_of_employee(str1);
        
        DateTime joindate = Convert.ToDateTime(dbfn.Get_details(strr1));
        int number_of_present = 0;
        int number_of_weekof = 0;
        int number_of_holiday = 0;
        int number_of_leave = 0;
        int number_of_Absent = 0;
        int number_of_MultipleEvent = 0;
        int daysinmonth = 0;
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        StringBuilder sb = new StringBuilder();

        sb.Append("<table style='border: 1px groove #C0C0C0;' cellpadding=0  cellspacing=0>");
        sb.Append("<tr>");
        sb.Append("<th style='font-size:11px; background-color:#F5DA81;border: 1px solid #507AA4; width:2%;text-align:center;'>M/D</th>");

        for (var i = 1; i <= 31; i++)
        {
            sb.Append("<th style='font-size:11px; background-color:#F6E3CE;border: 1px solid #507AA4; width:2%; text-align:center;'>" + i + "</th>");
        }
        sb.Append("</tr>");
        for (var k = 0; k < months.Length; k++)
        {
            sb.Append("<tr>");
            sb.Append("<td style='font-size:13px; background-color:#FE9A2E;color:blue; border: 1px groove #507AA4; text-align:center;'>" + months[k].Substring(0, 3) + "</td>");
            daysinmonth = DateTime.DaysInMonth(DateTime.Now.Year, k + 1);
            for (var j = 1; j <= daysinmonth; j++)
            {

                string str = "select COUNT(*) from AttendanceData where Enrollno=" + card_no + " and VYear=" + Convert.ToInt32(DateTime.Now.Year) + " and VMonth=" + Convert.ToInt32(k + 1) + " and Vday=" + Convert.ToInt32(j) + "";
                int value = dbfn.bind_attendance_data_for_leave_details(str);
                if (value > 0)
                {
                    sb.Append("<td style='background-color:green;border: 1px solid #507AA4; width:2%;'></td>");
                    number_of_present = number_of_present + 1;
                }
                else
                {

                    if ((k + 1) <= DateTime.Now.Month)
                    {
                        //string str2 = "SELECT  COUNT(*) from  NonTeachingDay where Year='" + Convert.ToInt32(DateTime.Now.Year) + "' and Month= '" + Convert.ToInt32(k + 1) + "' and Day='" + Convert.ToInt32(j) + "' and LeaveName='Sunday'";
                        //int value1 = dbfn.bind_attendance_data_for_leave_details(str2);
                        DateTime FulDate = Convert.ToDateTime(Convert.ToInt32(k + 1) + "-" + Convert.ToInt32(DateTime.Now.Year) + "-" + Convert.ToInt32(j));
                        string Day = FulDate.DayOfWeek.ToString();
                        string OfDay = "Select offDay from Employee_Master where  EmpId=" + empid + "";
                        string DayName = dbfn.Get_details(OfDay);
                        if (Day == DayName)
                        {
                            sb.Append("<td style='background-color:#01A9DB; border: 1px solid #507AA4; width:2%;  cursor:pointer;' title='" + DayName + "'></td>");
                            number_of_weekof = number_of_weekof + 1;
                        }
                        else
                        {
                            string str3 = "SELECT  COUNT(*)  from  NonTeachingDay where Year= '" + Convert.ToInt32(DateTime.Now.Year) + "' and Month= '" + Convert.ToInt32(k + 1) + "' and Day= '" + Convert.ToInt32(j) + "'  and LeaveName<>'Sunday'";
                            int value2 = dbfn.bind_attendance_data_for_leave_details(str3);

                            if (value2 > 0)
                            {
                                string str10 = "SELECT  LeaveName from  NonTeachingDay where Year= '" + Convert.ToInt32(DateTime.Now.Year) + "' and Month= '" + Convert.ToInt32(k + 1) + "' and Day= '" + Convert.ToInt32(j) + "' and LeaveName<>'Sunday'";
                                DataTable value5 = dbfn.Get_details_Datatable(str10);
                                if (value5.Rows.Count > 0)
                                {
                                    sb.Append("<td style='background-color:orange;border: 1px solid #507AA4; width:2%; cursor:pointer;' title='" + value5.Rows[0]["LeaveName"].ToString() + "'></td>");
                                    number_of_holiday = number_of_holiday + 1;
                                }
                                else
                                {
                                    sb.Append("<td style='background-color:orange;border: 1px solid #507AA4; width:2%;  cursor:pointer;' title=''></td>");
                                    number_of_holiday = number_of_holiday + 1;
                                }
                            }
                            else
                            {
                                //string str4 = "SELECT COUNT(*)  FROM  Emp_Leave_Record_dtls where  EmpId=" + empid + " and month(LStart_dt)=" + Convert.ToInt32(k + 1) + " and YEAR(LStart_dt)=" + Convert.ToInt32(DateTime.Now.Year) + " and Day(LStart_dt)=" + Convert.ToInt32(j) + "";
                                string str4 = "SELECT COUNT(*)  FROM  Emp_Leave_Record_dtls where  EmpId=" + empid + " and (" + Convert.ToInt32(k + 1) + " between month(LStart_dt) and month(LEnd_Dt)) and YEAR(LStart_dt) = " + Convert.ToInt32(DateTime.Now.Year) + " and (" + Convert.ToInt32(j) + " between Day(LStart_dt) and Day(LEnd_Dt))";                                 
                                    int value3 = dbfn.bind_attendance_data_for_leave_details(str4);
                                if (value3 > 0)
                                {
                                    sb.Append("<td style='background-color:blue;border: 1px solid #507AA4; width:2%;'></td>");
                                    number_of_leave = number_of_leave + 1;
                                }
                                else
                                {

                                    string valued = Convert.ToString(k + 1) + "-" + Convert.ToString(j) + "-" + Convert.ToString(DateTime.Now.Year);
                                    if (Convert.ToDateTime(valued) <= DateTime.Today)
                                    {
                                        if (joindate > Convert.ToDateTime(valued))
                                        {
                                            sb.Append("<td style='background-color:Gray;border: 1px solid #507AA4; width:2%;'></td>");
                                        }
                                        else
                                        {
                                            sb.Append("<td style='background-color:red;border: 1px solid #507AA4; width:2%;'></td>");
                                            number_of_Absent = number_of_Absent + 1;
                                        }
                                    }
                                    else
                                    {
                                        sb.Append("<td style='background-color:white;border: 1px solid #507AA4; width:2%;'></td>");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                        sb.Append("<td style='background-color:white;border: 1px solid #507AA4; width:2%;'></td>");
                    }
                }
            }
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        sb.Append("<div style='width:100%;'>");
        sb.Append("<table style='width:100%;'>");
        sb.Append("<tr>");
        sb.Append("<td colspan=5>");
        sb.Append("</br>");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style='color:black; font-size:9pt; width:10%; '>&nbsp; </br></td>");
        sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/blue1.png' style='width:20px; height:20px;' /> Number of Leave : " + number_of_leave + "</td>");
        sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/red1.png' style='width:20px; height:20px;'/> Number of Absent : " + number_of_Absent + "</td>");

        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style='color:black; font-size:9pt; width:10%; '>&nbsp; </br></td>");
        sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/green1.png' style='width:20px; height:20px;' /> Number of Present : " + number_of_present + "</td>");
        sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/cyan1.png' style='width:20px; height:20px;' />Number of WeeklyOff : " + number_of_weekof + "</td>");

        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style='color:black; font-size:9pt; width:10%; '>&nbsp; </br></td>");
        sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/orange1.png' style='width:20px; height:20px;' />Number of Holiday : " + number_of_holiday + "</td>");
        sb.Append("<td style='color:black; font-size:9pt;'><img src='../images/yellow1.png' style='width:20px; height:20px;'/> Number of Multiple Event : " + number_of_MultipleEvent + "</td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        sb.Append("</div>");

        return sb.ToString();
    }






    [WebMethod]
    public string bind_Employee_Leave_Notifications_single(string empcode)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string str = "SELECT     Emp_Leave_Record_dtlschld.EmpCode,CONVERT(varchar(12),Emp_Leave_Record_dtlschld.LeaveDate,106)as LeaveDate, Emp_Leave_Record_dtlschld.Application_No, Emp_Leave_Record_dtlschld.LeaveId, Emp_Leave_Record_dtlschld.Leave_Type, Emp_Leave_Record_dtlschld.AuthorityId, Emp_Leave_Record_dtlschld.LeaveHead, ISNULL(Employee_Master.empName, N'') + ' ' + ISNULL(Employee_Master.lastName, N'') AS empname, Department.DepartmentName, Emp_Leave_Record_dtlschld.SessionId,(Case Emp_Leave_Record_dtlschld.Status when 'Forward' then 'Pending' when 'Applied' then 'Pending' when '-' then 'Pending' end) as Status FROM         Emp_Leave_Record_dtlschld INNER JOIN Employee_Master ON Emp_Leave_Record_dtlschld.EmpId = Employee_Master.empId INNER JOIN Department ON Employee_Master.deptID = Department.DepartmentID WHERE     (Emp_Leave_Record_dtlschld.EmpCode ='" + empcode + "') AND (Emp_Leave_Record_dtlschld.InstituteId = " + insti_id + ") AND (Emp_Leave_Record_dtlschld.SessionId = '" + session_id + "') AND Emp_Leave_Record_dtlschld.Status in('Forward','-','Applied') union SELECT     Emp_Leave_Record_dtlschldSpLeave.EmpCode,CONVERT(varchar(12), Emp_Leave_Record_dtlschldSpLeave.LeaveDate,106)as LeaveDate, Emp_Leave_Record_dtlschldSpLeave.Application_No, Emp_Leave_Record_dtlschldSpLeave.LeaveId, Emp_Leave_Record_dtlschldSpLeave.Leave_Type, Emp_Leave_Record_dtlschldSpLeave.AuthorityId, Emp_Leave_Record_dtlschldSpLeave.LeaveHead, ISNULL(Employee_Master.empName, N'') + ' ' + ISNULL(Employee_Master.lastName, N'') AS empname, Department.DepartmentName, Emp_Leave_Record_dtlschldSpLeave.SessionId, (Case Emp_Leave_Record_dtlschldSpLeave.Status when 'Forward' then 'Pending' when 'Applied' then 'Pending'  when '-' then 'Pending' end) as Status FROM         Emp_Leave_Record_dtlschldSpLeave INNER JOIN Employee_Master ON Emp_Leave_Record_dtlschldSpLeave.EmpId = Employee_Master.empId INNER JOIN Department ON Employee_Master.deptID = Department.DepartmentID WHERE     (Emp_Leave_Record_dtlschldSpLeave.EmpCode = '" + empcode + "') AND (Emp_Leave_Record_dtlschldSpLeave.InstituteId = " + insti_id + ") AND Emp_Leave_Record_dtlschldSpLeave.Status in('Forward','-','Applied') and (Emp_Leave_Record_dtlschldSpLeave.SessionId = '" + session_id + "')for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;

    }

    [WebMethod]
    public string update_leave_deails(string[] empcode, string[] leavedate, string[] leavetype)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string session_id = Application["SessionID"].ToString();
        string str = "";
        string strval = "";
        string str1 = "";
        for (int i = 0; i < empcode.Length; i++)
        {
            if (empcode[i] != null)
            {
                string empcodeval = "";
                string date_value;
                string leavevalue = "";
                string leavetype1 = "";
                empcodeval = empcode[i];
                date_value = Convert.ToDateTime(leavedate[i]).ToString("yyyy-MM-dd");
                leavetype1 = leavetype[i];
                if (leavetype1 != "CR")
                {
                    leavevalue = leavetype1;
                }
                else
                {
                    leavevalue = leavetype1;
                }
                if (leavevalue.ToUpper() == ("Casual Leave").ToUpper())
                {
                    str = "update Emp_Leave_Record_dtlschld set Status='Leave' where EmpCode='" + empcodeval + "' and Leaveid='" + leavevalue + "'and LeaveDate='" + date_value + "'";
                    str1 = "update Emp_Leave_Record_dtls set LApprStatus='Leave' where EmpCode='" + empcodeval + "' and LeaveId='" + leavevalue + "' and LStart_dt='" + date_value + "'";
                }
                else
                {
                    str = "update Emp_Leave_Record_dtlschldSpLeave set Status='Leave' where EmpCode='" + empcodeval + "' and Leaveid='" + leavevalue + "'and LeaveDate='" + date_value + "'";
                    str1 = "update Emp_Leave_Record_dtls set LApprStatus='Leave' where EmpCode='" + empcodeval + "' and LeaveId='" + leavevalue + "' and LStart_dt='" + date_value + "'";
                }
                string value = "";
                string value1 = dbfn.insert_holiday_non_teaching(str1);

                value = dbfn.insert_holiday_non_teaching(str);


                if (value != "0")
                {
                    strval = empcodeval;
                }
                else
                {
                    strval = "0";
                }
            }
        }

        return strval;

    }


    //[WebMethod]
    //public string update_leave_deails(string[] empcode, string[] leavedate, string[] leavetype)
    //{
    //    int insti_id = Convert.ToInt32(Application["instID"].ToString());
    //    int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
    //    string session_id = Application["SessionID"].ToString();
    //    string str = "";
    //    string strval = "";
    //    for (int i = 0; i < empcode.Length; i++)
    //    {
    //        if (empcode[i] != null)
    //        {
    //            string empcodeval = "";
    //            string date_value;
    //            string leavevalue = "";
    //            string leavetype1 = "";
    //            empcodeval = empcode[i];
    //            date_value = Convert.ToDateTime(leavedate[i]).ToString("yyyy-MM-dd");
    //            leavetype1 = leavetype[i];
    //            if (leavetype1 != "CR")
    //            {
    //                leavevalue = leavetype1;
    //            }
    //            else
    //            {
    //                leavevalue = leavetype1;
    //            }
    //            if (leavevalue.ToUpper() == ("Casual Leave").ToUpper())
    //            {
    //                str = "update Emp_Leave_Record_dtlschld set Status='Leave' where EmpCode='" + empcodeval + "' and Leaveid='" + leavevalue + "'and LeaveDate='" + date_value + "'";
    //            }
    //            else
    //            {
    //                str = "update Emp_Leave_Record_dtlschldSpLeave set Status='Leave' where EmpCode='" + empcodeval + "' and Leaveid='" + leavevalue + "'and LeaveDate='" + date_value + "'";
    //            }

    //            string value = dbfn.insert_holiday_non_teaching(str);

    //            if (value != "0")
    //            {
    //                strval = empcodeval;
    //            }
    //            else
    //            {
    //                strval = "0";
    //            }
    //        }
    //    }

    //    return strval;

    //}

    [WebMethod]
    public string update_leave_reject_deails(string[] empcode, string[] leavedate, string[] leavetype, string reject_reason)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string session_id = Application["SessionID"].ToString();
        string str = "";
        string strval = "";
        string str1 = "";


        for (int i = 0; i < empcode.Length; i++)
        {
            if (empcode[i] != null)
            {
                string empcodeval = "";
                string date_value;
                string leavevalue = "";
                string leavetype1 = "";
                empcodeval = empcode[i];
                date_value = Convert.ToDateTime(leavedate[i]).ToString("yyyy-MM-dd");
                leavetype1 = leavetype[i];
                if (leavetype1 != "CR")
                {
                    leavevalue = leavetype1;
                }
                else
                {
                    leavevalue = leavetype1;
                }
                if (leavevalue.ToUpper() == ("Casual Leave").ToUpper())
                {
                    str = "update Emp_Leave_Record_dtlschld set Status='Reject',Reject_reasion='" + reject_reason + "' where EmpCode='" + empcodeval + "' and Leaveid='" + leavevalue + "'and LeaveDate='" + date_value + "'";
                    str1 = "update Emp_Leave_Record_dtls set LApprStatus='Reject' where EmpCode='" + empcodeval + "' and LeaveId='" + leavevalue + "' and LStart_dt='" + date_value + "'";
                }
                else
                {
                    str = "update Emp_Leave_Record_dtlschldSpLeave set Status='Reject',Reject_reasion='" + reject_reason + "' where EmpCode='" + empcodeval + "' and Leaveid='" + leavevalue + "'and LeaveDate='" + date_value + "'";
                    str1 = "update Emp_Leave_Record_dtls set LApprStatus='Reject' where EmpCode='" + empcodeval + "' and LeaveId='" + leavevalue + "' and LStart_dt='" + date_value + "'";
                }
                string value = "";
                string value1 = dbfn.insert_holiday_non_teaching(str1);

                value = dbfn.insert_holiday_non_teaching(str);


                if (value != "0")
                {
                    strval = empcodeval;
                }
                else
                {
                    strval = "0";
                }
            }
        }

        return strval;
    }



    [WebMethod]
    public string bind_Employee_Salary_Details_single()
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        DataTable dt = dbfn.bind_employee_salary_details_for_ht(faculty_id, insti_id, session_id);
        StringBuilder sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            sb.Append("<div style='width:100%; height:30px;'>");
            sb.Append("<table style='width:100%;'>");
            sb.Append("<tr>");
            sb.Append("<td  style='text-align:right; color:white; font-size:15px; border:0px solid white;'> <img src='../images/close.png' onclick='close_popup_notification_sal();' style='cursor:pointer;'/></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</div>");
            sb.Append("<div style='width:100%; height:180px; overflow:auto; float:left; vertical-align:top; border-radius:8px;'>");
            sb.Append("<table style='border-radius:5px; width:98%;' cellpadding=0  cellspacing=0>");
            sb.Append("<tr style='background-color:white;'>");
            sb.Append("<td colspan=8 style='text-align:Center; color:Black; font-size:15px; border: 0px solid white;'>Employee Salary Details</td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:white;'>");
            sb.Append("<td colspan=8 style='text-align:Center; color:white; font-size:15px; border: 0px solid white;'><br/></td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:white;'>");
            sb.Append("<td style='text-align:left; color:black; font-size:11px; border: 0px solid white;' colspan=3>Employee Code: " + dt.Rows[0]["EmpCode"].ToString().ToUpper() + "</td><td style='text-align:Center; color:black; font-size:11px; border: 0px solid white;' colspan=3>Department: " + dt.Rows[0]["DepartmentName"].ToString().ToUpper() + "</td><td style='text-align:Right; color:black; font-size:11px; border: 0px solid white; padding-right:10px;' colspan=2>Session: " + dt.Rows[0]["SessionId"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:white;'>");
            sb.Append("<td colspan=8><br/></td>");
            sb.Append("</tr>");
            sb.Append("<tr style='background-color:#cccccc;'>");
            sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; height:30px;'>ID</th><th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; height:30px;'>Month</th><th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; '>Working</th><th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; '>Attendance</th> <th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; height:30px;'>Availed leave</th><th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; '>Net Salary</th><th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; '>Deduction</th><th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; '>Payable</th>");
            sb.Append("</tr>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<tr style='background-color:white;'>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:11%;'>" + dt.Rows[i]["MainId"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:11%;'>" + dt.Rows[i]["Mname"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:11%;'>" + dt.Rows[i]["Working"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:11%;'>" + dt.Rows[i]["Atten"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:11%;'>" + dt.Rows[i]["Total_Leave"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:17%;'>" + dt.Rows[i]["TotA"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:11%;'>" + dt.Rows[i]["TotD"].ToString() + "</td>");
                sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; height:30px; width:17%;'>" + dt.Rows[i]["Netsal"].ToString() + "</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("</div>");
        }
        else
        {
            sb.Append("0");
        }
        return sb.ToString();
    }

    [WebMethod]
    public string BindState_value(string countryid)
    {
        string str = "Select StateName, StateId from State where CountryId=" + Convert.ToInt32(countryid) + " order by StateName for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string BindDegination_value(string nature, string dept)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "Select * from  master_Desig where InstituteID=" + insti_id + " and Nature='" + nature + "' and DesigId in (SELECT DesigID from Child_Desig where deptID='" + dept + "' and InstituteId=" + insti_id + ") order by Designation for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bindcity_value(string stateid)
    {
        string str = "Select CityName, CityId from City where StateID=" + Convert.ToInt32(stateid) + " order by cityName for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }


    [WebMethod]
    public string Bindfunation_value(string industry)
    {
        string str = "SELECT  funcation_name, function_id FROM funcational_Details WHERE (status = 'Y') AND (industry_id = " + Convert.ToInt32(industry) + ") order by function_id for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }


    [WebMethod(EnableSession = true)]
    public int Insert_Employee_Details(string emp_firstname, string emp_last_name, string mobile, string email, string title, string category,string offerId)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string session_value = HttpContext.Current.Session.SessionID;
        byte[] photo = { 1, 1, 0, 0, 1, 0, 0, 0 };
        byte[] sign = { 1, 1, 0, 0, 1, 0, 0, 0 };
        if (Application["StudentPhoto"] == null)
        {
            byte[] imgbin = { 1, 1, 0, 0, 1, 0, 0, 0 };
            photo = imgbin;
        }
        else
        {
            photo = (byte[])Application["StudentPhoto"];
        }
        if (Application["StudentSign"] == null)
        {
            byte[] signbin = { 1, 1, 0, 0, 1, 0, 0, 0 };
            sign = signbin;
        }
        else
        {
            sign = (byte[])Application["StudentSign"];
        }

        int value = dbfn.insert_employee_value_first(session_id, session_value, insti_id, emp_firstname, emp_last_name, mobile, email, title, category, photo, sign,offerId);
        return value;
    }



    [WebMethod]
    public string Insert_Employee_academic_Details(string empid, string wed, string course, string university, string year, string marks, string grade, string image, string qualification)
    {
        string value = dbfn.insert_Employee_Details_academic(Convert.ToInt32(empid), wed, course, university, Convert.ToInt32(year), Convert.ToDecimal(marks), grade, image, qualification);
        return value;
    }

    [WebMethod]
    public int update_Employee_Details_personal(string empid, string bloodgp, string FatherNm, string DOB, string Sex, string Religion, string MartStatus, string Nationality, string Spousenm, string Mother, string pan)
    {
        int value = dbfn.update_Employee_Details_personal(Convert.ToInt32(empid), bloodgp, FatherNm, DOB, Sex, Religion, MartStatus, Nationality, Spousenm, Mother, pan);
        return value;
    }

    [WebMethod]
    public string insert_emloyee_nominee_details(string empid, string nomineename, string nomineerelation, string address, string dob, string bankname, string accountnumber, string ifsccode)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "INSERT INTO [Employee_Nominee_Details]([Empid],[NomineeName],[NomineeRelation],[Address],[Dob],[BankName],[AccountNo],IFSCCode,UEdate,InstituteId)VALUES(" + Convert.ToInt32(empid) + ",'" + nomineename + "','" + nomineerelation + "','" + address + "','" + Convert.ToDateTime(dob).ToString("yyyy-MM-dd") + "','" + bankname + "','" + accountnumber + "','" + ifsccode + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "'," + insti_id + ")";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string insert_emloyee_bank_details(string empid, string bankname, string branchname, string ifsccode, string accountnumber)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "INSERT INTO [Employee_Bank_details]([Empid],[BankName],[BranchName],[IFSCCode],[AcountNumber],[UEDate],[InstituteId])VALUES(" + Convert.ToInt32(empid) + ",'" + bankname + "','" + branchname + "','" + ifsccode + "','" + accountnumber + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "'," + insti_id + ")";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string BindEmployee_grid_search(string empname)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "select (EmpName)+' '+isnull(lastname,'')as empname,empcode,empid  from employee_master where empname like '" + empname + "%' and InstituteID=" + insti_id + " and Status='Active' order by empname for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }


    [WebMethod]
    public string Bindcontrol_profile(string empid)
    {
        string str = "SELECT     ISNULL(Temp_Employee_Details_Entry.empName, '') + ' ' + ISNULL(Temp_Employee_Details_Entry.lastName, '') AS empname,  Temp_Employee_Details_Entry.empType, Temp_Employee_Details_Entry.empCat, Temp_Employee_Details_Entry.sex, CONVERT(varchar(12), Temp_Employee_Details_Entry.dob) AS dob, Temp_Employee_Details_Entry.compName, Temp_Employee_Details_Entry.deptID, Temp_Employee_Details_Entry.desigID, Temp_Employee_Details_Entry.markOIdent, Temp_Employee_Details_Entry.meritalStatus,  Temp_Employee_Details_Entry.modeAppl, Temp_Employee_Details_Entry.referedby, Temp_Employee_Details_Entry.religion, Temp_Employee_Details_Entry.nationality, Temp_Employee_Details_Entry.natureID, Temp_Employee_Details_Entry.workExp, Temp_Employee_Details_Entry.spouseName, Temp_Employee_Details_Entry.fatherName, Temp_Employee_Details_Entry.permAdd,  Temp_Employee_Details_Entry.zipcode, Temp_Employee_Details_Entry.phone, Temp_Employee_Details_Entry.email, Temp_Employee_Details_Entry.mobile,Temp_Employee_Details_Entry.joinDate, Temp_Employee_Details_Entry.bloodGroup, Temp_Employee_Details_Entry.RAuthority, Temp_Employee_Details_Entry.titleEmp, Temp_Employee_Details_Entry.ResDate, Temp_Employee_Details_Entry.WedDate, Temp_Employee_Details_Entry.EMPCode, Temp_Employee_Details_Entry.Empid, Temp_Employee_Details_Entry.academic_record, Temp_Employee_Details_Entry.pEmail, Temp_Employee_Details_Entry.pMobile, Temp_Employee_Details_Entry.same_as_per,  temp_employee_exeperience.key_skill, temp_employee_exeperience.profile_hd, temp_employee_exeperience.resume_path, temp_employee_exeperience.exe_year, temp_employee_exeperience.exe_month, temp_employee_exeperience.entry_date, temp_employee_exeperience.srno, Country.CountryName, State.StateName,  City.CityName, funcational_Details.funcation_name, Industry_Details.Industry_name FROM         Temp_Employee_Details_Entry INNER JOIN temp_employee_exeperience ON Temp_Employee_Details_Entry.Empid = temp_employee_exeperience.empid INNER JOIN Country ON Temp_Employee_Details_Entry.country = Country.CountryId INNER JOIN State ON Country.CountryId = State.CountryId AND Temp_Employee_Details_Entry.state = State.StateId INNER JOIN City ON State.StateId = City.StateID AND Temp_Employee_Details_Entry.city = City.CityId INNER JOIN Industry_Details ON temp_employee_exeperience.industry_id = Industry_Details.Industry_id INNER JOIN funcational_Details ON Industry_Details.Industry_id = funcational_Details.industry_id AND temp_employee_exeperience.function_id = funcational_Details.function_id where Temp_Employee_Details_Entry.Empid=" + Convert.ToInt32(empid) + " for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bindcontrol_academic(string empid)
    {
        string str = "SELECT   top(1)  empid, srno, Convert(varchar(12),wed) as wed, course, year, university, grade, marks, image_doc, qulification FROM temp_employee_academic_details where empid=" + Convert.ToInt32(empid) + " order by srno for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bindcontrol_address(string addres_value, string empid)
    {
        string str = "";
        if (addres_value == "P")
        {
            str = "SELECT     Temp_Employee_Details_Entry.permAdd, Country.CountryName, State.StateName, City.CityName, Temp_Employee_Details_Entry.zipcode,Temp_Employee_Details_Entry.pEmail, Temp_Employee_Details_Entry.pMobile, Temp_Employee_Details_Entry.phone FROM         Temp_Employee_Details_Entry INNER JOIN Country ON Temp_Employee_Details_Entry.country = Country.CountryId INNER JOIN State ON Country.CountryId = State.CountryId AND Temp_Employee_Details_Entry.state = State.StateId INNER JOIN City ON State.StateId = City.StateID AND Temp_Employee_Details_Entry.city = City.CityId where Temp_Employee_Details_Entry.empid=" + Convert.ToInt32(empid) + " for xml auto,elements";
        }
        else
        {
            str = "SELECT     Temp_Employee_Details_Entry.localAdd as permAdd, Country.CountryName, State.StateName, City.CityName, Temp_Employee_Details_Entry.lzipcode as zipcode, Temp_Employee_Details_Entry.lEmail as pEmail, Temp_Employee_Details_Entry.lMobile as pMobile, Temp_Employee_Details_Entry.lphone as phone FROM Temp_Employee_Details_Entry INNER JOIN Country ON Temp_Employee_Details_Entry.lcountry = Country.CountryId INNER JOIN State ON Country.CountryId = State.CountryId AND Temp_Employee_Details_Entry.lstate = State.StateId INNER JOIN City ON State.StateId = City.StateID AND Temp_Employee_Details_Entry.lcity = City.CityId where Temp_Employee_Details_Entry.empid=" + Convert.ToInt32(empid) + " for xml auto,elements";
        }
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }


    [WebMethod]
    public string Get_Employee_academic_Details(string empid)
    {
        DataTable dt = new DataTable();
        string str = "select srno,wed,course,university,year,marks,grade,image_doc,qulification from temp_employee_academic_details where empid=" + Convert.ToInt32(empid) + " order by srno";
        dt = dbfn.Get_details_Datatable(str);
        StringBuilder sb = new StringBuilder();
        sb.Append("<table style='width:100%;'>");
        sb.Append("<tr>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>ID</th>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>Qualification</th>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>Stream</th>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>Year of Passing</th>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>Board</th>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>Percentage</th>");
        sb.Append("<th style='text-align:Center; color:brown; font-size:11px; border: 1px solid #e8e8e8; background-color:#cccccc; height:30px;'>Grade</th>");
        sb.Append("</tr>");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append("<tr>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:10%;'>" + dt.Rows[i]["srno"].ToString() + "</td>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:20%;'>" + dt.Rows[i]["qulification"].ToString() + "</td>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:20%;'>" + dt.Rows[i]["course"].ToString() + "</td>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:10%;'>" + dt.Rows[i]["year"].ToString() + "</td>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:20%;'>" + dt.Rows[i]["university"].ToString() + "</td>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:10%;'>" + dt.Rows[i]["marks"].ToString() + "</td>");
            sb.Append("<td style='text-align:center; color:black; font-size:11px; border: 1px solid #cccccc; background-color:white;  height:30px; width:10%;'>" + dt.Rows[i]["grade"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        return sb.ToString();
    }
    [WebMethod]
    public string update_Employee_academic_save(string empid)
    {
        string str = "update Temp_Employee_Details_Entry set academic_record='Y' where empid=" + Convert.ToInt32(empid) + "";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string insert_Employee_Details_exeperience(string empid, string keyskill, string profile, string industry_id, string function_id, string resume_path, string exe_year, string exe_month)
    {
        string value = dbfn.insert_Employee_Details_exeperience(Convert.ToInt32(empid), keyskill, profile, Convert.ToInt32(industry_id), Convert.ToInt32(function_id), resume_path, exe_year, exe_month);
        return value;
    }

    [WebMethod]
    public string Insert_employee_address_details(string empid, string paddress, string pcountry, string pstate, string pcity, string pzipcode, string pphone, string pemail, string pmobile, string llocalAdd, string lcountry, string lstate, string lcity, string lzipcode, string lphone, string lemail, string lmobile, string same_as_per)
    {
        string value = dbfn.Insert_employee_address_details(Convert.ToInt32(empid), paddress, Convert.ToInt32(pcountry), Convert.ToInt32(pstate), Convert.ToInt32(pcity), pzipcode, pphone, pemail, pmobile, llocalAdd, Convert.ToInt32(lcountry), Convert.ToInt32(lstate), Convert.ToInt32(lcity), lzipcode, lphone, lemail, lmobile, same_as_per);
        return value;
    }
    public byte[] CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return buff;
    }

    public string encrypt(string val, byte[] seed)
    {
        byte[] KEY_64 = null;
        KEY_64 = seed;
        byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        if (val != string.Empty)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(val);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }
        else
        {
            return "";

        }
    }


    [WebMethod]
    public string Insert_employee_details_final(string emptype, string mode_application, string joiningdate, string empid, string confirmation, string reference, string name, string nature, string deptid, string desig, string rauthority)
    {
        string flag1 = "";
        byte[] salt = null;
        salt = CreateSalt(8);
        string strSalt = Convert.ToBase64String(salt);
        string strPassword = null;
        TextBox str = new TextBox();
        str.Text = "123";
        strPassword = encrypt(str.Text, salt);
        strPassword = strPassword.Replace("'", "''");
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string value = dbfn.Insert_employee_details_final(emptype, strPassword, strSalt, mode_application, joiningdate, empid, confirmation, reference, insti_id, session_id, name, Convert.ToInt32(nature), Convert.ToInt32(deptid), Convert.ToInt32(desig), Convert.ToInt32(rauthority));
        return value;
    }
    public void isnert_leave_details(string joiningdate, int empid, string empcode, string Nature)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string UserID = Application["U_Name"].ToString();
        DateTime StartSession = Convert.ToDateTime(dbfn.Get_details("Select StartDate from Session where  Session='" + Session["sesnId"].ToString() + "'"));
        DateTime EndSession = Convert.ToDateTime(dbfn.Get_details("Select EndDate from Session where  Session='" + Session["sesnId"].ToString() + "'"));
        int Joiningyear = DateTime.Parse(joiningdate).Year;
        int JoiningMonth = DateTime.Parse(joiningdate).Month;
        int SessionLastMonth = EndSession.Month;
        int Months = 0;
        if (Joiningyear > StartSession.Year)
        {

            for (int l = JoiningMonth; l < SessionLastMonth; l++)
            {
                Months = Months + 1;
            }

        }
        else
        {
            for (int l = JoiningMonth; l < 12; l++)
            {
                Months = Months + 1;
            }
            for (int l1 = 0; l1 < SessionLastMonth; l1++)
            {
                Months = Months + 1;
            }
        }

        Months = Months + 1;



        int id = Convert.ToInt32("0");
        int EmpID = empid;
        string EmpCode = empcode;
        DateTime Joindate = DateTime.Parse(joiningdate);
        DateTime SessionFromDate = StartSession;
        DateTime SessionToDate = EndSession;
        DateTime AccountFromDate = DateTime.Parse(joiningdate);
        DateTime AccountToDate = new DateTime(DateTime.Parse(joiningdate).Year, DateTime.Parse(joiningdate).Month, DateTime.DaysInMonth(DateTime.Parse(joiningdate).Year, DateTime.Parse(joiningdate).Month));
        int JoiningDay = DateTime.Parse(joiningdate).Day;

        decimal LPM1 = 0;
        decimal LPM2 = 0;
        decimal TotalL1 = 0;
        decimal TotalL2 = 0;
        decimal EncLeave1 = 0;
        decimal EncLeave2 = 0;
        decimal TotalLeave = 0;
        decimal TotalNo_of_EncLeave = 0;
        if (Nature == "1")
        {
            LPM1 = 3;
            TotalL1 = 36;
            EncLeave1 = 24;
        }
        else
        {
            LPM2 = 2;
            TotalL2 = 24;
            EncLeave1 = 24;
        }

        if (Months >= 2)
        {
            if (JoiningDay <= 10 && JoiningDay >= 1)
            {
                if (Nature == "1")
                {
                    TotalLeave = (Months - 2) * LPM1 + 2;
                    TotalNo_of_EncLeave = 2 * (Months);
                }
                else
                {
                    TotalLeave = (Months - 2) * LPM1 + 2;
                    TotalNo_of_EncLeave = 1 * (Months);
                }
            }

              ///------------------------------------------------------------------------------------------------------------------------------------------------------
            else if (JoiningDay <= 20 && JoiningDay >= 11)
            {
                if (Nature == "1")
                {

                    TotalLeave = (Months - 2) * LPM1 + 1;
                    TotalNo_of_EncLeave = 2 * (Months);
                }
                else
                {
                    TotalLeave = (Months - 2) * LPM2 + 1;
                    TotalNo_of_EncLeave = 1 * (Months);
                }
            }

                ///-----------------------------------------------------------------------------------------------------------------------------------------------------
            else if (JoiningDay <= 31 && JoiningDay >= 21)
            {
                if (Nature == "1")
                {
                    TotalLeave = (Months - 2) * LPM1;
                    TotalNo_of_EncLeave = 2 * (Months);
                }
                else
                {
                    TotalLeave = (Months - 2) * LPM2;
                    TotalNo_of_EncLeave = 1 * (Months);
                }
            }
        }
        else
        {
            if (Nature == "1")
            {
                TotalLeave = 0;
                TotalNo_of_EncLeave = 2 * (Months);
            }
            else
            {
                TotalLeave = 0;
                TotalNo_of_EncLeave = 1 * (Months);
            }

        }

        decimal EarnLeave = 0;
        decimal OpenLeave = 0;
        decimal TakenLeave = 0.0M;
        decimal BalLeave = TotalLeave;
        int InstituteID = insti_id;
        string SessionID = session_id.ToString();
        DateTime UEDate = DateTime.Today.Date;
        string Status = "A";
        string EncLeaveStatus = "-";
        string ApplicationNo = "-";
        decimal Earn_EncashLeave = 0;
        decimal AdjustbleLeaaves = 0;




    }

    [WebMethod]
    public int Insert_Books_Details_For_Reference(string courseid, string splid, string semid, string subid, string instid, string sessionid, string facultyid, string book_type, string book_Auther, string Book_Title, string Book_Edtion, string Book_Pub_Year, string Book_Publication, string Other_Ref)
    {
        int value = 0;
        value = dbfn.ExecuteDML("exec InsertBookMaster 0, " + int.Parse(instid) + ",'" + sessionid + "'," + int.Parse(courseid) + "," + int.Parse(splid) + "," + int.Parse(semid) + "," + int.Parse(subid) + ",'" + book_type + "','" + book_Auther + "','" + Book_Title + "','" + Book_Edtion + "','" + Book_Pub_Year + "','" + Book_Publication + "','0'," + facultyid + ",'T'");
        return value;
    }

    [WebMethod]
    public int Add_Vacancy(string title, string deptId, string desigId, string salfrom, string salTO, string maxAge, string responsibility, string minExp, string maxExp, string Vacancy, string StartDate, string EndDate, string qualId, string percentage, string status, string Keyskill, string Testname)
    {
        int value = 0;
        string code;
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string UserID = Application["U_Name"].ToString();
        string jobid = dbfn.Get_details("select isNull (MAX(jobid),0)+1 from Add_vacancy");
        DataTable dt = dbfn.FillDataTable("select Department.ShortName,master_Desig.ShortName as desig from Department,master_Desig where Department.DepartmentID=" + deptId + " and master_Desig.DesigId=" + desigId + " ");

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            string dept = dt.Rows[i]["ShortName"].ToString();
            string desig = dt.Rows[i]["desig"].ToString();
            code = Convert.ToString(dept + "-" + desig + "-" + (Convert.ToInt32(jobid)));
            value = dbfn.Insert_Add_Vacancy(Convert.ToInt32(jobid), code, title, Convert.ToInt32(deptId), Convert.ToInt32(desigId), Convert.ToInt32(salfrom), Convert.ToInt32(salTO), Convert.ToInt32(maxAge), responsibility, minExp, maxExp, Convert.ToDecimal(Vacancy), Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate), Convert.ToInt32(qualId), Convert.ToDecimal(percentage), "Active", Convert.ToInt32(Keyskill), Convert.ToInt32(Testname), insti_id, session_id, UserID);

        }
        return value;
    }


    [WebMethod]
    public string Bind_Designation_value(string ddlDept)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "select DesigId ,Designation from master_Desig where InstituteID='" + insti_id + "' and DesigId in( SELECT DesigID from Child_Desig where deptID='" + Convert.ToInt32(ddlDept) + "' )  order by Designation  for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bind_Employee_Salary_Details_view(string session, string year, string month, string deptid, string desig, string empid)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "";
        if (desig != "0" && deptid != "0" && empid != "0")
        {
            str = "SELECT PaySalaryDet_C.EmpCode, ISNULL(Employee_Master.empName, '') + ' ' + ISNULL(Employee_Master.lastName, '') AS empname, PaySalaryDet_C.BasicSal,PaySalaryDet_C.NetSal, PaySalaryDet_C.L_ded, PaySalaryDet_C.TotA, isnull(PaySalaryDet_C.Reason,'') as Reason, PaySalaryDet_C.Mname, PaySalaryDet_C.MainID, isnull(PaySalaryDet_C.holdRej,'') as holdRej, PaySalaryDet_C.TotD, PaySalaryDet_C.TotV, PaySalaryDet_C.Sanccode, PaySalaryDet_C.Atten FROM PaySalaryDet_C INNER JOIN Employee_Master ON PaySalaryDet_C.Empid = Employee_Master.empId INNER JOIN PaySalaryDet ON PaySalaryDet_C.MainID = PaySalaryDet.MainID WHERE (PaySalaryDet.InstituteID = " + insti_id + ") AND (PaySalaryDet.SessionID ='" + session + "') AND (PaySalaryDet_C.Mname = '" + month + "') AND (Employee_Master.deptID = " + Convert.ToInt32(deptid) + ") AND (Employee_Master.desigID = " + Convert.ToInt32(desig) + ") AND (PaySalaryDet_C.EmpCode = " + Convert.ToInt32(empid) + ")  for xml auto,elements";
        }
        if (desig != "0" && deptid != "0" && empid == "0")
        {
            str = "SELECT PaySalaryDet_C.EmpCode, ISNULL(Employee_Master.empName, '') + ' ' + ISNULL(Employee_Master.lastName, '') AS empname, PaySalaryDet_C.BasicSal,PaySalaryDet_C.NetSal, PaySalaryDet_C.L_ded, PaySalaryDet_C.TotA, isnull(PaySalaryDet_C.Reason,'') as Reason, PaySalaryDet_C.Mname, PaySalaryDet_C.MainID, isnull(PaySalaryDet_C.holdRej,'') as holdRej, PaySalaryDet_C.TotD, PaySalaryDet_C.TotV, PaySalaryDet_C.Sanccode, PaySalaryDet_C.Atten FROM PaySalaryDet_C INNER JOIN Employee_Master ON PaySalaryDet_C.Empid = Employee_Master.empId INNER JOIN PaySalaryDet ON PaySalaryDet_C.MainID = PaySalaryDet.MainID WHERE (PaySalaryDet.InstituteID = " + insti_id + ") AND (PaySalaryDet.SessionID ='" + session + "') AND (PaySalaryDet_C.Mname = '" + month + "') AND (Employee_Master.deptID = " + Convert.ToInt32(deptid) + ") AND (Employee_Master.desigID = " + Convert.ToInt32(desig) + ") for xml auto,elements";
        }
        if (desig == "0" && deptid != "0" && empid == "0")
        {
            str = "SELECT PaySalaryDet_C.EmpCode, ISNULL(Employee_Master.empName, '') + ' ' + ISNULL(Employee_Master.lastName, '') AS empname, PaySalaryDet_C.BasicSal,PaySalaryDet_C.NetSal, PaySalaryDet_C.L_ded, PaySalaryDet_C.TotA, isnull(PaySalaryDet_C.Reason,'') as Reason, PaySalaryDet_C.Mname, PaySalaryDet_C.MainID, isnull(PaySalaryDet_C.holdRej,'') as holdRej, PaySalaryDet_C.TotD, PaySalaryDet_C.TotV, PaySalaryDet_C.Sanccode, PaySalaryDet_C.Atten FROM PaySalaryDet_C INNER JOIN Employee_Master ON PaySalaryDet_C.Empid = Employee_Master.empId INNER JOIN PaySalaryDet ON PaySalaryDet_C.MainID = PaySalaryDet.MainID WHERE (PaySalaryDet.InstituteID = " + insti_id + ") AND (PaySalaryDet.SessionID ='" + session + "') AND (PaySalaryDet_C.Mname = '" + month + "') AND (Employee_Master.deptID = " + Convert.ToInt32(deptid) + ") for xml auto,elements";
        }
        if (desig == "0" && deptid == "0" && empid == "0")
        {
            str = "SELECT PaySalaryDet_C.EmpCode, ISNULL(Employee_Master.empName, '') + ' ' + ISNULL(Employee_Master.lastName, '') AS empname, PaySalaryDet_C.BasicSal,PaySalaryDet_C.NetSal, PaySalaryDet_C.L_ded, PaySalaryDet_C.TotA, isnull(PaySalaryDet_C.Reason,'') as Reason, PaySalaryDet_C.Mname, PaySalaryDet_C.MainID,isnull(PaySalaryDet_C.holdRej,'') as holdRej, PaySalaryDet_C.TotD, PaySalaryDet_C.TotV, PaySalaryDet_C.Sanccode, PaySalaryDet_C.Atten FROM PaySalaryDet_C INNER JOIN Employee_Master ON PaySalaryDet_C.Empid = Employee_Master.empId INNER JOIN PaySalaryDet ON PaySalaryDet_C.MainID = PaySalaryDet.MainID WHERE (PaySalaryDet.InstituteID = " + insti_id + ") AND (PaySalaryDet.SessionID ='" + session + "') AND (PaySalaryDet_C.Mname = '" + month + "')  for xml auto,elements";
        }
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    //[WebMethod]
    //public string Bind_Vacancy(string Profile)
    //{
    //    string detail = "SELECT * from Add_Vacancy_New_View where Id ='" + Convert.ToInt32(Profile) + "'for xml auto,elements";
    //    string value = dbfn.bindgrid_jdwise_ajax(detail);
    //    return value;
    //}

    [WebMethod]
    public string Insert_EmpWalkin_Details(string jobId, string Firstname, string lastname, string DOB, string fatherName, string Religion, string gender, string Exp, string Qualification, string desig, string depart, string Ofmarks, string Email, string Address, string Mobileno)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        int UsedId = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "Insert into Emp_WalkIn3 (jobId,Firstname,lastname,DOB,fatherName,Religion,gender,Exp,Qualification,desig,depart,Email,Ofmarks,Address,Mobileno,InstID,SessionID,UserID) values ('" + Convert.ToInt32(jobId) + "','" + Firstname + "','" + lastname + "','" + Convert.ToDateTime(DOB) + "','" + fatherName + "','" + Religion + "','" + gender + "','" + Convert.ToInt32(Exp) + "','" + Convert.ToInt32(Qualification) + "','" + Convert.ToInt32(desig) + "','" + Convert.ToInt32(depart) + "','" + Email + "','" + Convert.ToDecimal(Ofmarks) + "','" + Address + "','" + Mobileno + "','" + insti_id + "','" + session_id + "','" + UsedId + "') ";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;

    }

    //[WebMethod]
    //public string Bind_Emp_Walk_In_Details(string ddlDept1, string ddlDesig1)
    //{
    //    string detail = "SELECT * from EmpFilterView where depart='" + Convert.ToInt32(ddlDept1) + "' and desig='" + Convert.ToInt32(ddlDesig1) + "'  for xml auto,elements";
    //    string value = dbfn.bindgrid_jdwise_ajax(detail);
    //    return value;
    //}

    [WebMethod]
    public string Bind_Emp_Walk_In_Details()
    {
        string detail = "SELECT * from EmpFilterView for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }



    [WebMethod]
    public string Bind_Details()
    {
        string detail = "SELECT job_prifile_M.id, Department_1.DepartmentName AS Department, Department.DepartmentName AS Recruting_Department, master_Desig.Designation,Employee_Master.empName AS Recruting_Authority FROM job_prifile_M INNER JOIN Department AS Department_1 ON job_prifile_M.deptId = Department_1.DepartmentID INNER JOIN Department ON job_prifile_M.rdeptId = Department.DepartmentID INNER JOIN master_Desig ON job_prifile_M.desigId = master_Desig.DesigId INNER JOIN Employee_Master ON job_prifile_M.authority = Employee_Master.empId for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }

    [WebMethod]
    public string Bind_Panel_Details()
    {
        string detail = "select title,empName,Designation from Hr_Panel_member_view for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }

    [WebMethod]
    public int Add_Value_Member()
    {
        int Value = dbfn.insert_Add_Panel_Members();
        return Value;
    }

    [WebMethod]
    public string Insert_Placement_Agency(string AgencyName, string AgencyAdd, string CountryId, string StateId, string CityId, string Zipcode, string ContactPersonName, string Email, string PhoneNumber, string MobileNumber, string MediaTypeId)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        int UsedId = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "INSERT INTO Placement_Agency (AgencyName,AgencyAdd,CountryId,StateId,CityId,Zipcode,ContactPersonName,Email,PhoneNumber,MobileNumber,MediaTypeId,SessionId,InstId,UserEntryDate,UserEntryId)VALUES('" + AgencyName + "','" + AgencyAdd + "','" + Convert.ToInt32(CountryId) + "','" + Convert.ToInt32(StateId) + "','" + Convert.ToInt32(CityId) + "','" + Convert.ToInt32(Zipcode) + "','" + ContactPersonName + "','" + Email + "','" + PhoneNumber + "','" + MobileNumber + "','" + Convert.ToInt32(MediaTypeId) + "','" + session_id + "'," + insti_id + ",'" + DateTime.Now + "','" + UsedId + "')";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;

    }
    [WebMethod]
    public string Bind_All_Placement()
    {
        string detail = "SELECT Placement_Agency.id,State.StateName,Media_Type.MediaName,Country.CountryName,City.CityName,Placement_Agency.AgencyName,Placement_Agency.AgencyAdd,Placement_Agency.ContactPersonName,Placement_Agency.Email,Placement_Agency.PhoneNumber FROM Placement_Agency INNER JOIN State ON Placement_Agency.StateId =State.StateId INNER JOIN Media_Type ON Placement_Agency.MediaTypeId =Media_Type.id INNER JOIN City ON Placement_Agency.CityId =City.CityId INNER JOIN Country ON Placement_Agency.CountryId =Country.CountryId for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }

    [WebMethod]
    public string Bind_Qualification_value(string jobid)
    {
        //int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "select qualId ,ProfName from Qualification_View where jobId=" + Convert.ToInt32(jobid) + "  for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Delete_Agency(string id)
    {
        //int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from Placement_Agency where id='" + id + "'";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string Insert_KeySkill(string KeySkill)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        int UsedId = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "Insert into RecruiterSkill_name (KeySkill,InsiId,SessionID,UserID,entryDate) values ('" + KeySkill + "','" + insti_id + "','" + session_id + "','" + UsedId + "','" + DateTime.Now.Date + "') ";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }


    [WebMethod]
    public string Bind_Skill_Details()
    {
        string detail = "select ID,KeySkill from RecruiterSkill_name for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }


    [WebMethod]
    public string Bind_Vacancy(string Profile)
    {
        string detail = "SELECT * from Add_Vacancy_New_View where Id ='" + Convert.ToInt32(Profile) + "'for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }

    [WebMethod]
    public string insert_intrview_round(string iRound, string Point, string Dep, string title)
    {
        //string jcde = "dd";
        string Jcode = dbfn.Get_details("select jobCode from Add_vacancy where jobId=" + Convert.ToInt32(title) + "");
        string Jtittle = dbfn.Get_details("select title from Add_vacancy where jobId=" + Convert.ToInt32(title) + "");
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int faculty_id = Convert.ToInt32(Application["emp_id"].ToString());
        string session_id = Application["SessionID"].ToString();
        string str = "insert into intervRound (deptId,jobId,jobCode,jobTitle,interv_R,InstituteID,SessionID,UserID,UEDate,maxPoint) values (" + Convert.ToInt32(Dep) + "," + Convert.ToInt32(title) + ",'" + Jcode + "','" + Jtittle + "','" + iRound + "'," + insti_id + ",'" + session_id + "'," + faculty_id + ",'" + DateTime.Now + "'," + Convert.ToInt32(Point) + ")";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public int Insert_Recructing_Authority_Master(string deptId, string desigId, string rdeptId, string authority)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string UserID = Application["U_Name"].ToString();
        int value = dbfn.insert_recrutment_detail(Convert.ToInt32(deptId), Convert.ToInt32(desigId), Convert.ToInt32(rdeptId), Convert.ToInt32(authority), insti_id, session_id, UserID);
        return value;
    }

    [WebMethod]
    public string Bind_Vacancy_Details()
    {
        string detail = "SELECT Add_vacancy.jobCode,Add_vacancy.title,master_Desig.Designation,Department.DepartmentName,Payroll_SalGrade.salFrom AS Salary_From,Payroll_SalGrade.salTO AS Salary_To,Add_vacancy.tExp AS Min_Exper,Add_vacancy.responsibility,Add_vacancy.tVacancy,Add_vacancy.aDate,Add_vacancy.lDate,Add_vacancy.percentage FROM Add_vacancy INNER JOIN Department ON Add_vacancy.deptId =Department.DepartmentID INNER JOIN master_Desig ON Add_vacancy.desigId =master_Desig.DesigId INNER JOIN Payroll_SalGrade ON Add_vacancy.salfrom =Payroll_SalGrade.id AND Add_vacancy.salTO =Payroll_SalGrade.id for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }

    [WebMethod]
    public string Delete_Skill(string id)
    {
        //int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from RecruiterSkill_name where ID='" + id + "'";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string Delete_R_Athority(string id)
    {
        //int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from job_prifile_M where id='" + id + "'";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string Delete_TEST(string id)
    {
        //int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from RecruiterTestSeries1 where id='" + id + "'";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }


    [WebMethod]
    public string Delete_Vacancy(string id)
    {
        //int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from Add_vacancy where jobCode='" + id + "'";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }


    [WebMethod]
    public string InsertPanelMember_Temp(string JobProfileId, string PanelMemberId)
    {

        string str = "INSERT INTO temp_Panel_Member(JobProfileId,PanelMemberId)VALUES('" + Convert.ToInt32(JobProfileId) + "','" + Convert.ToInt32(PanelMemberId) + "')";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string GetPanel_Member(string Profile)
    {
        string detail = "select title,empName from temp_panel_member_view where JobProfileId=" + Convert.ToInt32(Profile) + " for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }

    [WebMethod]
    public string Insert_Test_Name(string TestName)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        string UserID = Application["U_Name"].ToString();
        string str = "INSERT INTO RecruiterTestSeries1 (TestName,InstId,SessionId,UserId,EnrtyDate)VALUES('" + TestName + "'," + insti_id + ",'" + session_id + "','3','" + DateTime.Now + "')";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string Bind_Test_Name()
    {
        string detail = "select id, TestName,SessionId,InstId from RecruiterTestSeries1 for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;
    }


    [WebMethod]
    public string insert_employee_basic_Salary(string Employee_id, string WithEffectDate, string DeptID, string DesigID, string PayPeriod, string BasicSalary, string OverTimeHour, string OverTimeMinute, string HalfDayHour, string HalfDayMinute, string SalaryGrade, string LateHour, string LateMin, string PfNo, string EsiNo, string RAuthority, string LAuthority, string HOD, string dg)
    {
        string id = string.Empty;
        id = dbfn.Get_details("SELECT   ISNULL(MAX(id) + 1, 1) AS idd from Payroll_EmpBasicSal");
        int value = dbfn.Save_Employee_Basic_Salary(Convert.ToInt32(id), Convert.ToInt32(Employee_id), Convert.ToDateTime(WithEffectDate), Convert.ToInt32(DeptID), Convert.ToInt32(DesigID), PayPeriod, Convert.ToDecimal(BasicSalary), Convert.ToInt32(OverTimeHour), Convert.ToInt32(OverTimeMinute), Convert.ToInt32(HalfDayHour), Convert.ToInt32(HalfDayMinute), Convert.ToInt32(SalaryGrade), Convert.ToInt32(LateHour), Convert.ToInt32(LateMin), PfNo, EsiNo, Convert.ToInt32(RAuthority), Convert.ToInt32(LAuthority), HOD, dg);
        return value.ToString();
    }


    [WebMethod]
    public string insert_employee_Timing_details(string Employee_id, string WithEffectDate, string inhour, string inminute, string insec, string outhour, string outmin, string outsec, string punch)
    {
        int value = dbfn.Save_Employee_Timing_Details(Convert.ToInt32(Employee_id), Convert.ToDateTime(WithEffectDate), Convert.ToInt32(inhour), Convert.ToInt32(inminute), Convert.ToInt32(insec), Convert.ToInt32(outhour), Convert.ToInt32(outmin), Convert.ToInt32(insec), punch);
        return value.ToString();
    }




    [WebMethod]
    public string Bind_InterView_Details()
    {
        string detail = "select jobId,jobCode,jobTitle,DepartmentName,interv_R,maxPoint from View_interView for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;

    }


    [WebMethod]
    public string Delete_InterView(string jobid)
    {
        string str = "delete from intervRound where jobId=" + Convert.ToInt32(jobid) + "";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }



    [WebMethod]
    public string Bind_Semester(string session)
    {
        string course = Application["courseid"].ToString();
        string batch = Application["batch"].ToString();

        string str = "select SID,CourseYear from Semester_View where SessionYear='" + session + "' and CourseID=" + course + " and Batch='" + batch + "' for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bind_SemesterGrid(string session, string semid)
    {
        string stdid = Application["uid"].ToString();
        int batchid = Convert.ToInt32(Application["batchID"].ToString());
        DataTable dt = new DataTable();
        StringBuilder sb1 = new StringBuilder();
        dt = dbfn.bind_student_overall_performance_single(Convert.ToInt32(stdid), session, Convert.ToInt32(semid), batchid);
        if (dt.Rows.Count > 0)
        {

            sb1.Append("<table style='height:100%; border-radius:5px; width:100%;'>");
            sb1.Append("<tr style='background-color:#D2D2D2;'><td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'> Subject Name</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Total Lecture</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Attend Lecture</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Percentage</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Class Average</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px; display:none;'>Class Position</td><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Remark</td></tr>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int subjectid = Convert.ToInt32(dt.Rows[i]["SubjectId"].ToString());
                DataSet ds = dbfn.Student_Attendance(Convert.ToInt32(stdid), subjectid, Convert.ToInt32(semid), Convert.ToInt32(batchid), session);
                string classposition = "", ClassAve = "", Remark = "", ColorCode = "";
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Remark = row["Remark"].ToString();
                    if (row["ColorCode"].ToString() == "1")
                    {
                        ColorCode = "green";
                    }

                    else
                    {
                        ColorCode = "red";
                    }

                }

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    classposition = row["ronum"].ToString();
                }
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    ClassAve = row["classAve"].ToString();
                }
                sb1.Append("<tr style='background-color:white;'><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["SubjectName"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["Tol1"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["pre1"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["Percentage1"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + ClassAve + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px; display:none;'>" + classposition + "</td><td style='text-align:center; color:"+ColorCode+"; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + Remark + "</td></tr>");
            }
            sb1.Append("</table>");
        }
        return sb1.ToString();
    }

    //[WebMethod]
    //public string Insert_employee_salary_details_final(string emptype, string mode_application, string joiningdate, string empid, string confirmation, string reference, string name, string nature, string deptid, string desig, string rauthority)
    //{

    //    int insti_id = Convert.ToInt32(Application["instID"].ToString());
    //    string session_id = Application["SessionID"].ToString();
    //    string value = dbfn.Insert_employee_details_final(emptype, strPassword, strSalt, mode_application, joiningdate, empid, confirmation, reference, insti_id, session_id, name, Convert.ToInt32(nature), Convert.ToInt32(deptid), Convert.ToInt32(desig), Convert.ToInt32(rauthority));
    //    return value;
    //}

    //.............Student Portal Methods......//


    [WebMethod]
    public string hodiday_detail(string year)
    {
        string session_id = Application["SessionID"].ToString();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int empid = Convert.ToInt32(Application["emp_id"].ToString());
        string CurrentYear = year.ToString();
        string str = "Select DAY,MONTH,year,LeaveName from nonteachingday where year='" + CurrentYear + "' for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Activity_detail(string year)
    {
        string session_id = Application["SessionID"].ToString();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int empid = Convert.ToInt32(Application["emp_id"].ToString());
        string str = "select DAY(testDate) as DAY,MONTH(testdate) as MONTH,testname+' ('+subjectcode+')' as LeaveName from Exam_scheduling_view for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Bind_grid(string testid)
    {
        string stu_Id = Application["uid"].ToString();
        StringBuilder sb1 = new StringBuilder();
        DataTable st = new DataTable();
        DataTable dt = dbfn.FillDataTable("select * from student_marksdetail_view where studentid=" + stu_Id + " and testid=" + testid + "");
        sb1.Append("<table style='border-radius:5px; width:100%;'>");

        string testid1 = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int subjectid = Convert.ToInt32(dt.Rows[i]["subjectid"].ToString());
            st = sv.classposition(Convert.ToInt32(stu_Id), Convert.ToInt32(testid), subjectid);
            decimal total_Marks = Convert.ToDecimal (dbfn.Get_details("select SUM(marksObtained)as marksobt from Student_MarksDetail_View where subjectid=" + subjectid + " and testid=" + testid + " "));
            decimal total_Stu = Convert.ToDecimal(dbfn.Get_details("select count(studentId) as totalStu from Student_MarksDetail_View where subjectid=" + subjectid + " and testid=" + testid + " "));
            string class_average = (decimal.Round((total_Marks / total_Stu), 2, MidpointRounding.AwayFromZero)).ToString(); 
            string name = dbfn.Get_details("select StudentName  from Student_MarksDetail_View  where marksObtained in(select MAX(marksObtained)from Student_MarksDetail_View where subjectId=" + subjectid + " and testid=" + testid + ")");
            if (testid != testid1)
            {
                testid1 = testid;
                sb1.Append("<tr style='background-color:white;'><td colspan='7' style='text-align:left; color:black; font-size:15px;font-family:Arial Black;font-weight: bold; border: 1px solid Silver;height:30px'>" + dt.Rows[i]["testName"] + "</td></tr>");
                sb1.Append("<tr style='background-color:#D2D2D2;'><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Subject Name</td><td style='text-align:center; color:#9F0000; font-size:12px;height:20px;font-weight: bold; border: 1px solid Silver;'>Max Marks</td><td style='text-align:center;font-weight: bold; color:#9F0000;height:20px; font-size:12px; border: 1px solid Silver;'>Marks Obtained</td><td style='text-align:center;font-weight: bold; color:#9F0000; font-size:12px; border: 1px solid Silver;height:20px;'>Class Average</td><td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Position in Class</td> <td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Maximum Marks Obtained By</td></tr>");

            }
            sb1.Append("<tr style='background-color:white;'><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["SubjectName"] + "</td></td><td style='text-align:center; height:25px;color:black;font-weight: bold; font-size:11px; border: 1px solid Silver;'>" + dt.Rows[i]["mMarks"] + "</td><td style='text-align:center; color:black;font-weight: bold; font-size:11px; border: 1px solid Silver;height:25px;'>" + dt.Rows[i]["marksObtained"] + "</td><td style='text-align:center; color:black;font-weight: bold; font-size:11px; border: 1px solid Silver;height:25px;'>" + class_average + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid Silver;height:25px;'>" + st.Rows[0]["ronum"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid Silver;height:25px;'>" + name + "</td></tr>");

        }
        //string value = dbfn.bindgrid_jdwise_ajax(str);
        sb1.Append("</table>");
        return sb1.ToString();
    }

    [WebMethod]
    public string Bind_grid1(string subjectid)
    {
        string stu_Id = Application["uid"].ToString();
        StringBuilder sb1 = new StringBuilder();
        DataTable st = new DataTable();
        DataTable dt = dbfn.FillDataTable("select * from student_marksdetail_view where studentid=" + stu_Id + " and subjectid=" + subjectid + "");
        sb1.Append("<table style='height:100%; border-radius:5px; width:100%;'>");
        //sb1.Append("<tr style='background-color:#0489B1;'><td  style='text-align:center; color:white; font-size:15px; border: 1px solid white;'> ExamName</td> <td style='text-align:center; color:white; font-size:15px; border: 1px solid white;'>SubjectName</td><td style='text-align:center; color:white; font-size:15px; border: 1px solid white;'>Max Marks</td><td style='text-align:center; color:white; font-size:15px; border: 1px solid white;'>Marks Obtain</td><td style='text-align:center; color:white; font-size:15px; border: 1px solid white;'>Class Average</td><td style='text-align:center; color:white; font-size:15px; border: 1px solid white;'>Class Position</td> <td style='text-align:center; color:white; font-size:15px; border: 1px solid white;'>MaxObtainStudentName</td></tr>");
        string subjectid1 = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int testid = Convert.ToInt32(dt.Rows[i]["testid"].ToString());
            st = sv.classposition(Convert.ToInt32(stu_Id), testid, Convert.ToInt32(subjectid));
            decimal total_Marks = Convert.ToDecimal(dbfn.Get_details("select SUM(marksObtained)as marksobt from Student_MarksDetail_View where subjectid=" + subjectid + " and testid=" + testid + " "));
            decimal total_Stu = Convert.ToDecimal(dbfn.Get_details("select count(studentId) as totalStu from Student_MarksDetail_View where subjectid=" + subjectid + " and testid=" + testid + " "));
            string class_average = (decimal.Round((total_Marks / total_Stu), 2, MidpointRounding.AwayFromZero)).ToString();
            string name = dbfn.Get_details("select StudentName  from Student_MarksDetail_View  where marksObtained in(select MAX(marksObtained)from Student_MarksDetail_View where subjectId=" + subjectid + " and testid=" + testid + ")");
            if (subjectid != subjectid1)
            {
                subjectid1 = subjectid;
                sb1.Append("<tr style='background-color:white;'><td colspan='7' style='text-align:left; color:black; font-size:15px;font-family:Arial Black;font-weight: bold; border: 1px solid Silver;height:30px'>" + dt.Rows[i]["subjectname"] + "</td></tr>");
                sb1.Append("<tr style='background-color:#D2D2D2;'><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>ExamName</td><td style='text-align:center; color:#9F0000; font-size:12px;height:20px;font-weight: bold; border: 1px solid Silver;'>Max Marks</td><td style='text-align:center;font-weight: bold; color:#9F0000;height:20px; font-size:12px; border: 1px solid Silver;'>Marks Obtained</td><td style='text-align:center;font-weight: bold; color:#9F0000; font-size:12px; border: 1px solid Silver;height:20px;'>Class Average</td><td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Position in Class</td> <td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Maximum Marks Obtained By</td></tr>");

            }
            sb1.Append("<tr style='background-color:white;'><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["testName"] + "</td></td><td style='text-align:center; height:25px;color:black;font-weight: bold; font-size:11px; border: 1px solid Silver;'>" + dt.Rows[i]["mMarks"] + "</td><td style='text-align:center; color:black;font-weight: bold; font-size:11px; border: 1px solid Silver;height:25px;'>" + dt.Rows[i]["marksObtained"] + "</td><td style='text-align:center; color:black;font-weight: bold; font-size:11px; border: 1px solid Silver;height:25px;'>" + class_average + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid Silver;height:25px;'>" + st.Rows[0]["ronum"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid Silver;height:25px;'>" + name + "</td></tr>");

        }
        //string value = dbfn.bindgrid_jdwise_ajax(str);
        sb1.Append("</table>");
        return sb1.ToString();
    }

    [WebMethod]
    public string Bind_Alldata(string testid, string subjectid)
    {
        string testid1 = "";
        Boolean data = true;
        DataTable dt = new DataTable();
        string stu_Id = Application["uid"].ToString();
        StringBuilder sb1 = new StringBuilder();
        DataTable st = new DataTable();
        if (testid != "0" && subjectid != "0")
        {
            dt = dbfn.FillDataTable("select * from student_marksdetail_view where studentid=" + stu_Id + " and testid=" + testid + " and subjectid=" + subjectid + "");
        }
        else
        {
            data = false;
            dt = dbfn.FillDataTable("select * from student_marksdetail_view where studentid=" + stu_Id + "");
        }
        if (dt.Rows.Count > 0)
        {
            sb1.Append("<table style='height:100%; border-radius:5px; width:100%;'>");




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (data == false)
                {
                    subjectid = dt.Rows[i]["subjectid"].ToString();
                    testid = dt.Rows[i]["testid"].ToString();
                }
                st = sv.classposition(Convert.ToInt32(stu_Id), Convert.ToInt32(testid), Convert.ToInt32(subjectid));
                decimal total_Marks = Convert.ToDecimal (dbfn.Get_details("select SUM(marksObtained)as marksobt from Student_MarksDetail_View where subjectid=" + subjectid + " and testid=" + testid + " "));
                decimal total_Stu = Convert.ToDecimal(dbfn.Get_details("select count(studentId) as totalStu from Student_MarksDetail_View where subjectid=" + subjectid + " and testid=" + testid + " "));
                string class_average = (decimal.Round((total_Marks / total_Stu), 2, MidpointRounding.AwayFromZero)).ToString();
                string name = dbfn.Get_details("select StudentName  from Student_MarksDetail_View  where marksObtained in(select MAX(marksObtained)from Student_MarksDetail_View where subjectId=" + subjectid + " and testid=" + testid + ")");
                if (testid != testid1)
                {
                    testid1 = testid;
                    sb1.Append("<tr style='background-color:white;'><td colspan='7' style='text-align:left; color:black; font-size:15px;font-family:Arial Black;font-weight: bold; border: 1px solid Silver;height:30px'>" + dt.Rows[i]["testName"] + "</td></tr>");
                    sb1.Append("<tr style='background-color:#D2D2D2;'><td  style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Subject Name</td><td style='text-align:center; color:#9F0000; font-size:12px;height:20px;font-weight: bold; border: 1px solid Silver;'>Max Marks</td><td style='text-align:center;font-weight: bold; color:#9F0000;height:20px; font-size:12px; border: 1px solid Silver;'>Marks Obtain</td><td style='text-align:center;font-weight: bold; color:#9F0000; font-size:12px; border: 1px solid Silver;height:20px;'>Class Average</td><td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>Class Position</td> <td style='text-align:center; color:#9F0000; font-size:12px;font-weight: bold; border: 1px solid Silver;height:20px;'>MaxMarksObtainStudentName</td></tr>");
                }

                sb1.Append("<tr style='background-color:white;'><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["SubjectName"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["mMarks"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + dt.Rows[i]["marksObtained"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + class_average + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + st.Rows[0]["ronum"] + "</td><td style='text-align:center; color:black; font-size:11px;font-weight: bold; border: 1px solid silver; line-height: 10pt;height:25px;'>" + name + "</td></tr>");

            }
            //string value = dbfn.bindgrid_jdwise_ajax(str);
            sb1.Append("</table>");
        }
        return sb1.ToString();
    }

    [WebMethod]
    public void insert_Value(string ruleid, string rule, string type, string action)
    {

        int uid = Convert.ToInt32(Application["uid"].ToString());
        int instid = Convert.ToInt32(Application["instid"].ToString());
        string session = Application["Sessn"].ToString();



        dbfn.ExecuteDML1("insert into Terms_Condition(Rule_id,Rule_name,Condition_Name,Condition_Action,Creation_Date,Session_id,Inst_id,user_id)values(" + ruleid + ",'" + rule + "','" + type + "','" + action + "','20-feb-2015','" + session + "'," + instid + "," + uid + ")");

    }

    [WebMethod]
    public string Get_Value()
    {
        string detail = "select MAX(rule_id) rule_id from Terms_Condition for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(detail);
        return value;

    }

    [WebMethod]
    public string Get_ID(string val, string subid)
    {
        string detail = dbfn.Get_details("Select Result from iESEresult where studentId=" + val + " and Result=6 and subjectid not in(" + subid + ")");
        return detail;

    }

    [WebMethod]
    public void insert_Rule(string rule)
    {

        int uid = Convert.ToInt32(Application["uid"].ToString());
        int instid = Convert.ToInt32(Application["instid"].ToString());
        string session = Application["Sessn"].ToString();

        dbfn.ExecuteDML1("insert into Rule_master(Rule_Name,Creation_date,session_id,inst_id,user_id)values('" + rule + "','" + DateTime.Now + "','" + session + "'," + instid + "," + uid + ")");



    }

    [WebMethod]
    public void insert_Condition(string type, string action)
    {
        int uid = Convert.ToInt32(Application["uid"].ToString());
        int instid = Convert.ToInt32(Application["instid"].ToString());
        string session = Application["Sessn"].ToString();

        string ruleid = dbfn.Get_details("select max(Rule_id) from Rule_master where user_id=" + uid + " ");
        dbfn.ExecuteDML1("insert into Terms_Condition(Rule_id,Condition_Name,Condition_Action,Creation_Date,Session_id,Inst_id,user_id)values(" + ruleid + ",'" + type + "','" + action + "','" + DateTime.Now + "','" + session + "'," + instid + "," + uid + ")");



    }

    [WebMethod]
    public string insert_period_aval(string btn, string i, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10)
    {

        int value = 0;
        string courseid = Application["couid"].ToString();
        string specid = Application["specid"].ToString();
        string semid = Application["semid"].ToString();
        string instid = Application["instid"].ToString();
        string sessionid = Application["sesn"].ToString();

        string year = dbfn.Get_details("select distinct year from Semester_View where CourseID=" + courseid + " and SID=" + semid + "");
        if (btn == "1")
        {
            value = dbfn.ExecuteDelete("insert into iperiodAvail values(1,'" + i + "','" + p1 + "','" + p2 + "','" + p3 + "','" + p4 + "','" + p5 + "','" + p6 + "','" + p7 + "','" + p8 + "','" + p9 + "','" + p10 + "','" + courseid + "','" + specid + "'," + year + ",'" + semid + "','" + sessionid + "'," + instid + ",'')");
        }
        else
        {
            value = dbfn.ExecuteDelete("update iperiodAvail set ipavail='1',dayNo='" + i + "',p1='" + p1 + "',p2='" + p2 + "',p3='" + p3 + "',p4='" + p4 + "',p5='" + p5 + "',p6='" + p6 + "',p7='" + p7 + "',p8='" + p8 + "',p9='" + p9 + "',p10='" + p10 + "',courseId='" + courseid + "',specId='" + specid + "',yearId=" + year + ",semId='" + semid + "',SessionID='" + sessionid + "',instid=" + instid + " where dayNo='" + i + "' and semid=" + semid + " and yearid=" + year + " and specid=" + specid + " ");

        }
        // int value = objDB.ExecuteNonQuery(CommandType.Text, str);
        return i;
    }

    [WebMethod (EnableSession=true)]
    public string CreateTabs(string strpath, string pageTitle, int ScreenHeight)
    {
       
        int userid = int.Parse(Session["uid"].ToString());
        DataTable dt = new DataTable();
        string Html = "";
        string html1 = "";
        dt = dbfn.InsertpageURL(strpath, pageTitle, userid);
        if (dt.Rows.Count > 0)
        { 
          for(int i=0; i<=dt.Rows.Count-1; i++)
          {
              Html = Html + "<li id= Tab" + i + " style='display:block;' class='" + dt.Rows[i]["ActiveTab"].ToString() + "'>" + "<img style='margin-top:11px; padding-left:7px; cursor:pointer; position: absolute !important;z-index: 99999 !important;' onclick=CloseTab('iframe" + i + "','Tab" + i + "'," + dt.Rows[i]["PageID"].ToString() + "," + dt.Rows[i]["UserID"].ToString() + ") alt='close' title='close' src='images/close.png'/><a href='#box_tab" + i + "' data-toggle= 'tab'><span class='hidden-inline-mobile'>" + dt.Rows[i]["PageTitle"].ToString() + "</span></a></li>";
              html1 = html1 + "<div class='tab-pane fade in " + dt.Rows[i]["ActiveTab"].ToString() + "' id='box_tab" + i + "'>" + "<iframe id='iframe" + i + "' frameborder='0' style='width:100%; display:block; min-height:" + ScreenHeight + "px; position:relative;' " + "src='" + dt.Rows[i]["Page_url"].ToString().Replace(" ", "&nbsp;").Replace("../", "") + "'></iframe></div>";
          }

          Html = "<ul class='nav nav-tabs'>" + Html + "</ul><div class='tab-content'>"+"" + html1 + "</div>";
        }

        return Html;
    }

    [WebMethod]
    public void CloseTab(int pageid, int userid)
    {      
        dbfn.deletetabfromtable(pageid, userid);        
    }

   
    [WebMethod]
    public string hodiday_detail_Calendar_Employee()
    {
        DataTable dt = new DataTable();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "SELECT LeaveID, LeaveName, Date FROM NonTeachingDay where instituteID=" + insti_id + "";
        dt = dbfn.FillDataTable(str);
        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{id:" + dt.Rows[i]["LeaveID"].ToString() + ",cid:3,title:'" + dt.Rows[i]["LeaveName"] + "',start:new Date('" + dt.Rows[i]["Date"] + "'),end:new Date('" + dt.Rows[i]["Date"] + "'),ad:true},");
            }
        }
        sb = sb.Remove(sb.Length - 1, 1);
        sb1.Append("var today = new Date().clearTime(); var eventList= {evts:[" + sb.ToString() + "]};");
        string strv = sb1.ToString();
        return strv.ToString();
    }

    [WebMethod]
    public string insert_holiday_in_database(string startdate, string enddate, string title, string leavetype)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string session_id = Application["SessionID"].ToString();
        int year = Convert.ToDateTime(startdate).Year;
        int month = Convert.ToDateTime(startdate).Month;
        int day = Convert.ToDateTime(startdate).Day;
        string daynm = Convert.ToDateTime(startdate).DayOfWeek.ToString();
        string insert = "insert into NonTeachingDay(LeaveName,Day,DayName,Month,Year,Date,Type,instituteID,sessionID)values('" + title + "','" + day.ToString() + "','" + daynm + "','" + month + "','" + year + "','" + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + "','" + leavetype + "'," + insti_id + ",'" + session_id + "')";
        int value = dbfn.ExecuteDML(insert);
        string result = "";
        if (value > 0)
        {
            result = "true";
        }
        else
        {
            result = "false";
        }

        return result;
    }

    [WebMethod]
    public void Employee_read_Status()
    {
        string uid = Application["Empid"].ToString();
       
        string str = "update Notification set Read_status='true' where Emp_Id=" + uid + "";
        string value = dbfn.insert_holiday_non_teaching(str);
    }
}
