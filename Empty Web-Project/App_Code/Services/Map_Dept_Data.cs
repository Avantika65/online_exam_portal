using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Runtime.Serialization;
using   NewDAL;

/// <summary>
/// Summary description for Map_Dept_Data
/// </summary>

namespace HRM //HRDept
{
    [Serializable]
    [DataContract]
    public class Fee    //Map_Dept_Data
    {         
        [Serializable]
        [DataContract]
        public class WorkDayDM
        {
            [DataMember]
            public int yearID { get; set; }
            [DataMember]
            public string workDays { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int workdayID { get; set; }
            [DataMember]
            public DateTime frmdate { get; set; }
            [DataMember]
            public DateTime todate { get; set; }
            [DataMember]
            public DateTime cdate { get; set; }
            [DataMember]
            public int edate { get; set; }
            [DataMember]
            public int  mnth{ get; set; }
            [DataMember]
            public int  yr{ get; set; }
            [DataMember]
            public int deptID { get; set; }
            [DataMember]
            public string  UserID{ get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public string flag { get; set; }

            [DataMember]
            public string WeekId { get; set; }
        }

        [Serializable]
        [DataContract]
        public class EmpWage
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int empBasicId { get; set; }

            [DataMember]
            public int wageId { get; set; }

            [DataMember]
            public decimal wValue { get; set; }

            [DataMember]
            public string status { get; set; }
        }

        [Serializable]
        [DataContract]
        public class DesigChild
        {
            //[DataMember]
            //public int ID { get; set; }

            [DataMember]
            public int deptID { get; set; }

            [DataMember]
            public string desigID { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class JobChild
        {
           
            [DataMember]
            public int desigID { get; set; }

            [DataMember]
            public string jobID { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class CountryDM
        {

            [DataMember]
            public int CountryId { get; set; }

            [DataMember]
            public string CountryName { get; set; }


            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class StateDM
        {
            [DataMember]
            public int StateId { get; set; }

            [DataMember]
            public int CountryId { get; set; }

            [DataMember]
            public string StateName { get; set; }


            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Flag { get; set; }

            [DataMember]
            public string CountryName { get; set; }

        }

        [Serializable]
        [DataContract]
        public class CityDM
        {
            [DataMember]
            public int StateID { get; set; }

            [DataMember]
            public int CityId { get; set; }

            [DataMember]
            public string CityName { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Flag { get; set; }

            [DataMember]
            public string statename { get; set; }

            [DataMember]
            public int Countryid { get; set; }

            [DataMember]
            public string CountryName { get; set; }

        }

        [Serializable]
        [DataContract]
        public class EprofDM
        {
            [DataMember]
            public int ProfId { get; set; }

            [DataMember]
            public string ProfName { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class offdayDM
        {
            [DataMember]
            public int offid { get; set; }

            [DataMember]
            public string title { get; set; }

            [DataMember]
            public DateTime date { get; set; }

            [DataMember]
            public string month { get; set; }

            [DataMember]
            public string year { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public int id { get; set; }

            [DataMember]
            public string flag { get; set; }

            [DataMember]
            public string SessionF { get; set; }
            [DataMember]
            public string Active { get; set; }
        }

        [Serializable]
        [DataContract]
        public class DepartmentDM
        {
            [DataMember]
            public int DepartmentID { get; set; }

            [DataMember]
            public string DepartmentName { get; set; }

            [DataMember]
            public string ShortName { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UName { get; set; }

            [DataMember]
            public DateTime UEntDt { get; set; }

            [DataMember]
            public DateTime validFrom { get; set; }

            [DataMember]
            public DateTime validTo { get; set; }

            [DataMember]
            public string flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class DesigntionDM
        {
            [DataMember]
            public int DesigId { get; set; }

            [DataMember]
            public string Designation { get; set; }

            [DataMember]
            public string ShortName { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public DateTime validFrom { get; set; }

            [DataMember]
            public DateTime validTo { get; set; }

            [DataMember]
            public string flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class EmpNatureDM
        {
            [DataMember]
            public int natureID { get; set; }

            [DataMember]
            public string nature { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public DateTime validFrom { get; set; }

            [DataMember]
            public DateTime validTo { get; set; }

            [DataMember]
            public string flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class ExpertisDM
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public string Expertise { get; set; }

            [DataMember]
            public DateTime wed { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class ServiceDM
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public string ServiceName { get; set; }

            [DataMember]
            public string ServShName { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }
 
            [DataMember]
            public string UserID {get; set;} 

            [DataMember]
            public DateTime UEDate {get; set;}

            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public DateTime WED { get; set; }
            [DataMember]
            public string SType { get; set; }
            [DataMember]
            public decimal Amt { get; set; }

            [DataMember]
            public int ServiceId { get; set; }
        }

        
        [Serializable]
        [DataContract]
        public class BasicSalDetail
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public int empId { get; set; }
            [DataMember]
            public DateTime WED { get; set; }
            [DataMember]
            public int deptId { get; set; }
            [DataMember]
            public int desigId { get; set; }
            [DataMember]
            public string payPeriod { get; set; }
            [DataMember]
            public int OTHour { get; set; }
            [DataMember]
            public int OTMin { get; set; }
            [DataMember]
            public int HDHour { get; set; }
            [DataMember]
            public int HDMin { get; set; }
            [DataMember]
            public int salGrade { get; set; }
            [DataMember]
            public int LTHour { get; set; }
            [DataMember]
            public int LTMin { get; set; }
            [DataMember]
            public string PfNo { get; set; }
            [DataMember]
            public string EsiNo { get; set; }
            [DataMember]
            public int EmpBId { get; set; }
            [DataMember]
            public double BasicSal { get; set; }
            [DataMember]
            public int  RAuthority { get; set; }
            [DataMember]
            public string  flag { get; set; }
            [DataMember]
            public int LAuthority { get; set; }
            [DataMember]
            public string HOD { get; set; }
            [DataMember]
            public string DGAppr { get; set; }
        }
        [Serializable]
        [DataContract]
        public class WageDetails
        {
            [DataMember]
            public int rowID { get; set; }
            [DataMember]
            public string wageID { get; set; }
            [DataMember]
            public string wageValue { get; set; }
            [DataMember]
            public string status { get; set; }
             [DataMember]
            public string chk { get; set; }
        }
        [Serializable]
        [DataContract]
        public class EmployeeDetail
        {            
            [DataMember]
            public Int32 EmployeeID { get; set; }
            [DataMember]
            public DateTime WEDDDate { get; set; }
            [DataMember]
            public Int32 candID { get; set; }
            [DataMember]
            public String empCode { get; set; }
            [DataMember]
            public String empName { get; set; }
            [DataMember]
            public String empType { get; set; }
            [DataMember]
            public String empCat { get; set; }
            [DataMember]
            public Int32 barID { get; set; }
            [DataMember]
            public String Gender { get; set; }
            [DataMember]
            public DateTime DOB { get; set; }
            [DataMember]
            public String CompanyName { get; set; }
            [DataMember]
            public Int32 DeptID { get; set; }
            [DataMember]
            public Int32 DesigID { get; set; }
            [DataMember]
            public String MarkOIdent { get; set; }
            [DataMember]
            public String MaritalStatus { get; set; }
            [DataMember]
            public String ModeAppl { get; set; }
            [DataMember]
            public String ReferedBy { get; set; }
            [DataMember]
            public String Religion { get; set; }
            [DataMember]
            public String Nationality { get; set; }
            [DataMember]
            public String NatureID { get; set; }
            [DataMember]
            public String WorkingExp { get; set; }
            [DataMember]
            public String SpouseName { get; set; }
            [DataMember]
            public String FatherName { get; set; }
            [DataMember]
            public String PermAdd { get; set; }
            [DataMember]
            public Int32 City { get; set; }
            [DataMember]
            public Int32 State { get; set; }
            [DataMember]
            public Int32 Country { get; set; }
            [DataMember]
            public String ZipCode { get; set; }
            [DataMember]
            public String PhoneNo { get; set; }
            [DataMember]
            public String EMail { get; set; }
            [DataMember]
            public String Mobile { get; set; }
            [DataMember]
            public String LocalAddress { get; set; }
            [DataMember]
            public Int32 LocalCity { get; set; }
            [DataMember]
            public Int32 LocalState { get; set; }
            [DataMember]
            public Int32 LocalCountry { get; set; }
            [DataMember]
            public String LocalZipCode { get; set; }
            [DataMember]
            public String LocalPhoneNo { get; set; }
            [DataMember]
            public String LocalEMail { get; set; }
            [DataMember]
            public String LocalMobile { get; set; }
            [DataMember]
            public DateTime JoiningDate { get; set; }
            [DataMember]
            public String BloodGroup { get; set; }
            [DataMember]
            public String BonusApplied { get; set; }
            [DataMember]
            public String OTApplied { get; set; }
            [DataMember]
            public String ODayApplied { get; set; }
            [DataMember]
            public String OffDay { get; set; }
            [DataMember]
            public Int32 ProfEdu { get; set; }
            [DataMember]
            public byte[] EmployeeImge { get; set; }
            [DataMember]
            public byte[] EmployeeSign { get; set; }
            [DataMember]
            public String LastName { get; set; }
            [DataMember]
            public Int32 RAuthority { get; set; }
            [DataMember]
            public String EmployeeTitle { get; set; }
            [DataMember]
            public Int32 ExpertID { get; set; }
            [DataMember]
            public Int32 InstID { get; set; }
            [DataMember]
            public string SesnID { get; set; }
            [DataMember]
            public string UserID { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public int InHr { get; set; }
            [DataMember]
            public int InMin { get; set; }
            [DataMember]
            public int OutHr { get; set; }
            [DataMember]
            public int InSec { get; set; }
            [DataMember]
            public int OutMin { get; set; }
            [DataMember]
            public int OutSec { get; set; }
            [DataMember]
            public DateTime  WEDTime { get; set; }
            [DataMember]
            public int TimeId { get; set; }
            [DataMember]
            public string Punch { get; set; }
            [DataMember]
            public string CardNo { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public string DGAppr { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]
            public string PanCard { get; set; }
            [DataMember]
            public DateTime  Resigndate { get; set; }
        }

        [Serializable]
        [DataContract]
        public class EmployeeService
        {
            [DataMember]
            public Int32 CID { get; set; }

            [DataMember]
            public Int32 ServiceId { get; set; }

            [DataMember]
            public String Status { get; set; }

            [DataMember]
            public String ServiceName { get; set; }

            [DataMember]
            public DateTime WED { get; set; }

            [DataMember]
            public Int32 EmployeeId { get; set; }

        }
        
        [Serializable]
        [DataContract]
        public class EmpPayMode
        {
            [DataMember]
            public int mId { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int desigId { get; set; }

            [DataMember]
            public int empId { get; set; }

            [DataMember]
            public string paymodeId { get; set; }

            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string empCode { get; set; }
            [DataMember]
            public string empName { get; set; }
            [DataMember]
            public DateTime WED { get; set; }
            [DataMember]
            public string AccNo { get; set; }
            [DataMember]
            public string typeAcc { get; set; }

        }

        [Serializable]
        [DataContract]
        public class ResignDM
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int EmpId { get; set; }

            [DataMember]
            public string Reason { get; set; }

            [DataMember]
            public DateTime Wed { get; set; }
            [DataMember]
            public string flag { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int desigid { get; set; }
            [DataMember]
            public DateTime cdate { get; set; }

            [DataMember]
            public string empCode { get; set; }
            [DataMember]
            public string empName { get; set; }
            [DataMember]
            public DateTime frmdate { get; set; }
            [DataMember]
            public DateTime todate { get; set; }
        }
        [Serializable]
        [DataContract]
        public class ProbationDM
        {
            [DataMember]
            public int deptid { get; set; }
            [DataMember]
            public int desigid { get; set; }
            [DataMember]
            public string empcode { get; set; }
            [DataMember]
            public int empid { get; set; }
            [DataMember]
            public string Fromdate { get; set; }
            [DataMember]
            public string todate { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string empname { get; set; }

        }

        public Fee()
        {
        }
    }
}
