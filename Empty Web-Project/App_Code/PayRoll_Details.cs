using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for PayRoll_Details
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class PayRoll_Details : System.Web.Services.WebService {

    DbFunctions objFun = new DbFunctions();
    public PayRoll_Details () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string Attendance_Page_Load_details()
    {
        string userid = Application["uid"].ToString();
        string p = Application["p"].ToString();
        string session1 = Application["Session"].ToString();
        string Instiid=Application["InstiId"].ToString();
        string s = session1.Substring(0, 4);
        string NonTeachingDate = session1.Substring(5, 4);
        string MName = string.Empty;
        string Year = string.Empty;
        string AFromDate = string.Empty;
        string AToDate = string.Empty;
        MName = objFun.Get_details("Select Top 1 Mname from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + NonTeachingDate + "' Order By MName Desc");
        if (string.IsNullOrEmpty(MName))
        {
            MName = objFun.Get_details("Select Top 1 Mname from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + s + "' Order By MName Desc");
            Year = s;
            if (int.Parse(MName) == 12)
            {
                AFromDate = new DateTime(int.Parse(NonTeachingDate), 1, 1).ToString();
                AToDate = new DateTime(int.Parse(NonTeachingDate), 1, 0x1f).ToShortDateString();
                Year = NonTeachingDate;
            }
            else
            {
                AFromDate = new DateTime(int.Parse(s), int.Parse(MName) + 1, 1).ToString();
                AToDate = new DateTime(int.Parse(s), int.Parse(MName) + 1, DateTime.DaysInMonth(int.Parse(s), int.Parse(MName) + 1)).ToShortDateString();
            }
        }
        else
        {
            Year = NonTeachingDate;
        }
        return session1 + "&" + MName+"&"+AFromDate+"&"+AToDate+"&"+Year;
    }


    [WebMethod]
    public string Salary_Page_Load_details()
    {
        string userid = Application["uid"].ToString();
        string p = Application["p"].ToString();
        string session1 = Application["Session"].ToString();
        string Instiid = Application["InstiId"].ToString();
        string s = session1.Substring(0, 4);
        string str2 =session1.Substring(5, 4);
        string MName = string.Empty;
        string Year = string.Empty;
        string AFromDate = string.Empty;
        string AToDate = string.Empty;
        MName = objFun.Get_details("Select Top 1 Mname from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + str2 + "' Order By MName Desc");
        if (string.IsNullOrEmpty(MName))
        {
            MName = objFun.Get_details("Select Top 1 Mname from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + s + "' Order By MName Desc");
            Year = s;
            if (int.Parse(MName) == 12)
            {
                AFromDate = new DateTime(int.Parse(str2), 1, 1).ToString();
                AToDate = new DateTime(int.Parse(str2), 1, 0x1f).ToShortDateString();
                Year = str2;
            }
            else
            {
                AFromDate = new DateTime(int.Parse(s), int.Parse(MName) + 1, 1).ToString();
                AToDate = new DateTime(int.Parse(s), int.Parse(MName) + 1, DateTime.DaysInMonth(int.Parse(s), int.Parse(MName) + 1)).ToShortDateString();
            }
        }
        else
        {
            Year = str2;
        }
        return session1 + "&" + MName + "&" + AFromDate + "&" + AToDate + "&" + Year;
    }


    [WebMethod]
    public string Get_ddl_month_value(string year)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "SELECT Id, MonthN FROM Month_Name where Id in (Select MName from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + year + "') and id not in (1,2,3) for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_ddl_month_value1(string year)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "SELECT Id, MonthN FROM Month_Name where Id in (Select MName from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + year + "') and id not in (4,5,6,7,8,9,10,11,12)  for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_ddl_month_value2(string year)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "SELECT Id, MonthN FROM Month_Name where Id in (1)  for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }


    [WebMethod]
    public string Get_ddl_month_value3(string year)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "SELECT Id, MonthN FROM Month_Name where Id='"+year+"'  for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_Search_Grid(string year, string month,string date,string empid,string monthtxt,string deptid,string desigid)
    {
        string Instiid = Application["InstiId"].ToString();

        string str = "SELECT Payroll_Attendance.AttID, Payroll_Attendance.dept_id, Payroll_Attendance.MName, Payroll_Attendance.SessionN, Payroll_Attendance.Working, Payroll_Attendance.Curr_D, Payroll_Attendance.empID, Payroll_Attendance.Prs, Payroll_Attendance.Abs, Payroll_Attendance.Sunday, Payroll_Attendance.Holiday, Payroll_Attendance.OPenL, Payroll_Attendance.Wp, Payroll_Attendance.FullL, Payroll_Attendance.HBL, Payroll_Attendance.HAL, Payroll_Attendance.Miss, Payroll_Attendance.SLM, Payroll_Attendance.SLE, Payroll_Attendance.LWApp, Payroll_Attendance.DrL, Payroll_Attendance.LWP, Payroll_Attendance.CrL, Payroll_Attendance.BalL, Payroll_Attendance.PaidDays, Payroll_Attendance.yearN, Payroll_Attendance.InstituteID, Payroll_Attendance.SessionID, Payroll_Attendance.UserID, Payroll_Attendance.UEDate, Payroll_Attendance.LateHour, Payroll_Attendance.LateMin, isnull(Employee_Master.empName,'')+' '+isnull(Employee_Master.lastName,'') as empname, Employee_Master.empCode FROM Payroll_Attendance INNER JOIN Employee_Master ON Payroll_Attendance.empID = Employee_Master.empId WHERE (Payroll_Attendance.empID = '" + empid + "') AND (Payroll_Attendance.InstituteID = '" + Instiid + "') AND (Payroll_Attendance.yearN = '" + year + "') AND (Payroll_Attendance.MName = '" + monthtxt + "')  for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }


    [WebMethod]
    public string Get_Search_Grid1(string year, string month, string date, string empid, string monthtxt, string deptid, string desigid)
    {
        string Instiid = Application["InstiId"].ToString();
        string str1 = "";
        string value = "";
        if (deptid != "0")
        {
            if (string.IsNullOrEmpty(str1))
            {
                str1 = "Payroll_EmpBasicSal.deptID='" + deptid + "'";
            }
            else
            {
                str1 = str1 + "and Payroll_EmpBasicSal.deptID='" + deptid + "'";
            }
        }
        if (desigid != "0")
        {
            if (string.IsNullOrEmpty(str1))
            {
                str1 = "Payroll_EmpBasicSal.desigID='" + desigid + "'";
            }
            else
            {
                str1 = str1 + " and Payroll_EmpBasicSal.desigID='" + desigid + "' ";
            }
        }
        if (!string.IsNullOrEmpty(str1))
        {
            string str = "SELECT distinct  Payroll_Attendance.AttID, Payroll_Attendance.dept_id, Payroll_Attendance.MName, Payroll_Attendance.SessionN, Payroll_Attendance.Working,Payroll_Attendance.Curr_D, Payroll_Attendance.empID, Payroll_Attendance.Prs, Payroll_Attendance.Abs, Payroll_Attendance.Sunday, Payroll_Attendance.Holiday, Payroll_Attendance.OPenL, Payroll_Attendance.Wp, Payroll_Attendance.FullL, Payroll_Attendance.HBL, Payroll_Attendance.HAL, Payroll_Attendance.Miss, Payroll_Attendance.SLM, Payroll_Attendance.SLE, Payroll_Attendance.LWApp, Payroll_Attendance.DrL, Payroll_Attendance.LWP, Payroll_Attendance.CrL, Payroll_Attendance.BalL, Payroll_Attendance.PaidDays, Payroll_Attendance.yearN, Payroll_Attendance.InstituteID, Payroll_Attendance.SessionID, Payroll_Attendance.UserID, Payroll_Attendance.UEDate, Payroll_Attendance.LateHour, Payroll_Attendance.LateMin, ISNULL(Employee_Master.empName, '') + ' ' + ISNULL(Employee_Master.lastName, '') AS empname, Employee_Master.empCode FROM Payroll_Attendance INNER JOIN  Employee_Master ON Payroll_Attendance.empID = Employee_Master.empId INNER JOIN Payroll_EmpBasicSal ON Payroll_Attendance.empID = Payroll_EmpBasicSal.empID WHERE  (Payroll_Attendance.InstituteID = '" + Instiid + "') AND (Payroll_Attendance.yearN = '" + year + "')  and "+str1+" AND (Payroll_Attendance.MName = '" + monthtxt + "')  for xml auto,elements";
            value = objFun.bindgrid_jdwise_ajax(str);
        }
        return value;
    }


    [WebMethod]
    public string Get_Search_employee_grid1(string year, string month, string date, string empid, string deptid, string desigid)
    {
        string Instiid = Application["InstiId"].ToString();
        string str1 = "";
        string value = "";
        if (deptid != "0")
        {

            if (string.IsNullOrEmpty(str1))
            {
                str1 = "Payroll_EmpBasicSal.deptID='" + deptid + "'";
            }
            else
            {
                str1 = str1 + "and Payroll_EmpBasicSal.deptID='" + deptid + "'";
            }
        }
        if (desigid != "0")
        {
            if (string.IsNullOrEmpty(str1))
            {
                str1 = "Payroll_EmpBasicSal.desigID='" + desigid + "'";
            }
            else
            {
                str1 = str1 + " and Payroll_EmpBasicSal.desigID='" + desigid + "' ";
            }
        }
        if (!string.IsNullOrEmpty(str1))
        {
            string str = "SELECT distinct Employee_Master.empId, Employee_Master.empCode, Employee_Master.empName + ' ' + Employee_Master.lastName AS empName,Employee_Master.CardNo,Payroll_EmpBasicSal.DeptId,Payroll_EmpBasicSal.id FROM         Employee_Master LEFT OUTER JOIN EmpPayMode ON Employee_Master.empId = EmpPayMode.empId LEFT OUTER JOIN Payroll_EmpBasicSal ON Employee_Master.empId = Payroll_EmpBasicSal.empID  where (Employee_Master.resdate is null or (month(Employee_Master.resdate)>=" + Convert.ToInt32(month) + " and year(Employee_Master.resdate)>='" + year + "')) and " + str1 + " and Payroll_EmpBasicSal.wed <='" + date + "' and Payroll_EmpBasicSal.Mrk_Del='C' and Employee_Master.Status='Active'  and Employee_Master.InstituteId='" + Instiid + "' order by empname  for xml auto,elements";
            value = objFun.bindgrid_jdwise_ajax(str);
        }
        return value;
    }


    [WebMethod]
    public string Get_Search_employee_grid(string year, string month, string date, string empid)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "SELECT distinct Employee_Master.empId, Employee_Master.empCode, Employee_Master.empName + ' ' + Employee_Master.lastName AS empName,Employee_Master.CardNo,Payroll_EmpBasicSal.DeptId,Payroll_EmpBasicSal.id FROM         Employee_Master LEFT OUTER JOIN EmpPayMode ON Employee_Master.empId = EmpPayMode.empId LEFT OUTER JOIN Payroll_EmpBasicSal ON Employee_Master.empId = Payroll_EmpBasicSal.empID  where (Employee_Master.resdate is null or (month(Employee_Master.resdate)>=" + Convert.ToInt32(month) + " and year(Employee_Master.resdate)>='" + Convert.ToInt32(year) + "'))  and Payroll_EmpBasicSal.wed <='" + date + "' and Payroll_EmpBasicSal.Mrk_Del='C' and Employee_Master.Status='Active' and Employee_Master.Empid='" + empid + "' and Employee_Master.InstituteId='" + Instiid + "' order by empname for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_session_details_value(string year, string month, string date, string empid)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "SELECT distinct Employee_Master.empId, Employee_Master.empCode, Employee_Master.empName + ' ' + Employee_Master.lastName AS empName,Employee_Master.CardNo,Payroll_EmpBasicSal.DeptId,Payroll_EmpBasicSal.id FROM         Employee_Master LEFT OUTER JOIN EmpPayMode ON Employee_Master.empId = EmpPayMode.empId LEFT OUTER JOIN Payroll_EmpBasicSal ON Employee_Master.empId = Payroll_EmpBasicSal.empID  where (Employee_Master.resdate is null or (month(Employee_Master.resdate)>=" + Convert.ToInt32(month) + " and year(Employee_Master.resdate)>='" + Convert.ToInt32(year) + "'))  and Payroll_EmpBasicSal.wed <='" + date + "' and Payroll_EmpBasicSal.Mrk_Del='C' and Employee_Master.Status='Active' and Employee_Master.Empid='" + empid + "' and Employee_Master.InstituteId='" + Instiid + "' order by empname for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_Search_employee_grid_month(string year, string month)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "Select  Mname from PayRoll_SalaryProcessMonth where InstituteId='" + Instiid + "' and YearN='" + year + "' and MName='" + month + "' ";
        string value = objFun.Get_details(str);
        return value;
    }

    [WebMethod]
    public string ddl_bind_desig(string deptid)
    {
        string Instiid = Application["InstiId"].ToString();
        string str = "select DesigId ,Designation from master_Desig where InstituteID='" + Instiid + "' and DesigId in( SELECT DesigID from Child_Desig where deptID='" + deptid + "' )  order by Designation for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string bind_grid_find(string year,string deptid, string desigid, string fromdate, string todate)
    {
        string Instiid = Application["InstiId"].ToString();
        int value1 = objFun.get_find_employee_grid(Convert.ToInt32(Instiid), Convert.ToInt32(year), Convert.ToInt32(deptid), Convert.ToInt32(desigid), fromdate, todate);
        string str = "select * from Temp_Employee_Payroll_attendance for xml auto,elements";
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string BindEmployee_grid_search_new(string empname,string depid,string desigid)
    {
        string str = "";
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        if (depid != "0" && desigid != "0")
        {
            str = "select (EmpName)+' '+isnull(lastname,'')as empname,empcode,empid  from employee_master where empname like '" + empname + "%' and InstituteID=" + insti_id + " and Status='Active' and deptID=" + Convert.ToInt32(depid) + " and desigID="+Convert.ToInt32(desigid)+" order by empname for xml auto,elements";
        }
        if (depid != "0" && desigid == "0")
        {
            str = "select (EmpName)+' '+isnull(lastname,'')as empname,empcode,empid  from employee_master where empname like '" + empname + "%' and InstituteID=" + insti_id + " and Status='Active' and deptID=" + Convert.ToInt32(depid) + " order by empname for xml auto,elements";
        }
        if (depid == "0" && desigid == "0")
        {
            str = "select (EmpName)+' '+isnull(lastname,'')as empname,empcode,empid  from employee_master where empname like '" + empname + "%' and InstituteID=" + insti_id + " and Status='Active' order by empname for xml auto,elements";
        }
        string value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_Search_employee_Salary_grid(string year, string month,string monthname, string empid)
    {
        string Instiid = Application["InstiId"].ToString();
        string empbasicid = objFun.Get_details("SELECT  max(Payroll_EmpBasicSal.id) AS EmpBasicID FROM Payroll_EmpBasicSal,Employee_Master where Employee_Master.empId = Payroll_EmpBasicSal.empID  and (Employee_Master.resdate is null or (month(Employee_Master.resdate)>=" + month + " and year(Employee_Master.resdate)>='" + year + "'))   and Payroll_EmpBasicSal.Mrk_Del='C' and Payroll_EmpBasicSal.empId='" + empid + "'");
        string value = "";
        int value1 = objFun.get_find_employee_salary_grid(Convert.ToInt32(Instiid),Convert.ToInt32(year),Convert.ToInt32(empid),Convert.ToInt32(month),monthname,Convert.ToInt32(empbasicid));
        string str = "Select * from Temp_Employee_Wage_type_Salary  for xml auto,elements";
        value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_Search_employee_Salary_grid_emp(string year, string month, string monthname, string deptid,string desig)
    {
        string Instiid = Application["InstiId"].ToString();
        string value = "";
        int value1 = objFun.get_find_employee_salary_grid_dept(Convert.ToInt32(Instiid), Convert.ToInt32(year), Convert.ToInt32(month), monthname, Convert.ToInt32(deptid), Convert.ToInt32(desig));
        string str = "SELECT [empid],[empcode],[empname],[AdditionalAllowance],[Advance],[ArrearsExtras],[Basic],[Conveyance],[DA],[DARDeduction],[ESI],[ExtraAllw],[ExtraDeduct],[Hostel],[HRA],[Insurance],[LateHoursDeduction],[MealVoucher],[Other],[Othersadvance],[PF],[Phone],[ProfessionalDevelopment] ,[SpecialAllowance],[TDS],[VARIABLEPERFORMANCEINCENTIVE],[Mothname],[Mothid],[Year],isnull([basicid],0)as [basicid],[instiid],[MedicalAllowance],[SalesIncentives],isnull([MainId],0)as [MainId],isnull([TotA],0)as [TotA],isnull([Totd],0)as [Totd],isnull([Totv],0) as [Totv],isnull([Netsal],0)as [Netsal],isnull([Atten],0)as [Atten],isnull([PayMode],'') as [PayMode] FROM [Temp_Employee_Wage_type_Salary] order by empid for xml auto,elements";
        value = objFun.bindgrid_jdwise_ajax(str);
        return value;
    }




    

}
