using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Income_Tax_Details : System.Web.Services.WebService {

    DbFunctions dbfn = new DbFunctions();
    public Income_Tax_Details () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Get_Employee_name(string depid)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = " SELECT  ISNULL(Employee_Master.empName, '') + ' ' + ISNULL(Employee_Master.lastName, '') AS empname, Payroll_EmpBasicSal.basicSal, Payroll_EmpBasicSal.Mrk_Del,Convert(varchar(12), Employee_Master.joinDate)as joinDate, Employee_Master.empCode FROM Employee_Master INNER JOIN Payroll_EmpBasicSal ON Employee_Master.empId = Payroll_EmpBasicSal.empID WHERE (Employee_Master.Status = N'Active') AND (Payroll_EmpBasicSal.Mrk_Del = 'C') AND (Employee_Master.deptID = " + Convert.ToInt32(depid) + ") AND (Employee_Master.InstituteID = "+insti_id+") ORDER BY Employee_Master.empName for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_Investment_Details()
    {
        string empcode=Application["EmpCode"].ToString();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "SELECT invest_details_user.policyid,  invest_details_user.policynumber, invest_details_user.policyamount, Convert(varchar(12),invest_details_user.policystdate) as policystdate, Convert(varchar(12),invest_details_user.policyeddate) as policyeddate, invest_details_user.policypreminum, invest_details_user.preminumamount, invest_details_user.lstpremiumdate, invest_details_user.nxtpreminumdate, Invest_type.Invest_name FROM invest_details_user INNER JOIN Invest_type ON invest_details_user.invest_id = Invest_type.Invest_id WHERE (invest_details_user.empcode = '" + empcode + "') ORDER BY invest_details_user.policyid for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public int insert_Investment_Details(string invest_type,string invest_no,string invest_amount,string invest_st_date,string invest_ed_date,string premium_type,string premimum_amount,string premimum_lt_date,string premimum_nx_date)
    {
        string empcode = Application["EmpCode"].ToString();
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int value = dbfn.insert_Tax_details_employee(invest_type, invest_no, invest_amount, invest_st_date, invest_ed_date, premium_type, premimum_amount, premimum_lt_date, premimum_nx_date, empcode);
        return value;
    }

    [WebMethod]
    public string Get_Tax_Slap_Master() 
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "SELECT id, T_from, T_to,percentge,taxt_type FROM Tax_Slab_Master WHERE  (inst_id=" + insti_id + ") for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }

    [WebMethod]
    public string Get_Investment_Type_Master()
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "SELECT Invest_id, Invest_name, Status FROM Invest_type WHERE  (InstituteId=" + insti_id + ") for xml auto,elements";
        string value = dbfn.bindgrid_jdwise_ajax(str);
        return value;
    }
    
    [WebMethod]
    public int insert_Investment_Type_Master(string invest_name, string status)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int value = dbfn.insert_Investment_Type_Master(invest_name, status, insti_id);
        return value;
    }

    [WebMethod]
    public int insert_Tax_Slap_Master(string from, string to,string percentage,string taxt_type)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int value = dbfn.insert_Tax_Slap_Type_Master(from, to,Convert.ToInt32(percentage), insti_id, Convert.ToInt32(taxt_type));
        return value;
    }


    [WebMethod]
    public string Delete_Investment_Type_Master(string id)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from Invest_type where Invest_id=" + Convert.ToInt32(id) + "and InstituteId="+insti_id+"";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public string Delete_Tax_slap_Master(string id)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        string str = "delete from Tax_Slab_Master where id=" + Convert.ToInt32(id) + "and inst_id=" + insti_id + "";
        string value = dbfn.insert_holiday_non_teaching(str);
        return value;
    }

    [WebMethod]
    public int update_Investment_Type_Master(string invest_id,string invest_name, string status)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int value = dbfn.update_Investment_Type_Master(Convert.ToInt32(invest_id), invest_name, status, insti_id);
        return value;
    }

    [WebMethod]
    public int update_slap_Type_Master(string invest_id, string from, string to, string percentage,string tax_type)
    {
        int insti_id = Convert.ToInt32(Application["instID"].ToString());
        int value = dbfn.update_tax_slap_Master(Convert.ToInt32(invest_id), from, to,Convert.ToDecimal(percentage),insti_id,Convert.ToInt32(tax_type));
        return value;
    }


    
}
