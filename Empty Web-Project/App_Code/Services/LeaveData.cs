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


/// <summary>
/// Summary description for LeaveData
/// </summary>
/// 
namespace HRM
{
    [Serializable]
    [DataContract]
    public class LeaveData
    {
        [Serializable]
        [DataContract]
        public class LeavTypDM
        {
            [DataMember]
            public int leaveID { get; set; }
            [DataMember]
            public string leaveType { get; set; }
            [DataMember]
            public string shName { get; set; }
            [DataMember]
            public decimal leave { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string UserID { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public string Type { get; set; }           
            [DataMember]
            public string Mode { get; set; }
            [DataMember]
            public int ContLeave { get; set; }
            [DataMember]
            public DateTime WEF_Date { get; set; }
            [DataMember]
            public string flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class AppliedLeaveDM
        {
            [DataMember]
            public DateTime Leav { get; set; }
            [DataMember]
            public string applID { get; set; }
            [DataMember]
            public string LN { get; set; }
            [DataMember]
            public string leaveTo { get; set; }
            [DataMember]
            public string leaveFrom { get; set; }
            [DataMember]
            public decimal noODays { get; set; }
            [DataMember]
            public string repA { get; set; }
            [DataMember]
            public string leavestatus { get; set; }
            [DataMember]
            public int regID { get; set; }
            [DataMember]
            public int leaveID { get; set; }
            [DataMember]
            public DateTime apprDate { get; set; }
            [DataMember]
            public string statusRA { get; set; }
            [DataMember]
            public string statusHA { get; set; }
            [DataMember]
            public DateTime apprFrom { get; set; }
            [DataMember]
            public DateTime apprTo { get; set; }
            [DataMember]
            public DateTime leavF { get; set; }
            [DataMember]
            public int empid { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }

        }
        [Serializable]
        [DataContract]
        public class CancelLeave
        {
            [DataMember]
            public string appNo { get; set; }
            [DataMember]
            public string leaveType { get; set; }
            [DataMember]
            public DateTime apprfrom{ get; set; }
            [DataMember]
            public DateTime apprTo { get; set; }
            [DataMember]
            public string dept_head_status { get; set; }
            [DataMember]
            public DateTime appDate { get; set; }
            [DataMember]
            public int empid { get; set; }

        }
        [Serializable]
        [DataContract]
        public class LeaveRequestDM
        {
            [DataMember]
            public int regID { get; set; }
            [DataMember]
            public string applID { get; set; }
            [DataMember]
            public int empID { get; set; }
            [DataMember]
            public string reason { get; set; }
            [DataMember]
            public int authorID { get; set; }
            [DataMember]
            public string substitute { get; set; }
            [DataMember]
            public string leavestatus { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string UserID { get; set; }
            public DateTime UEDate { get; set; }
            public int deptID { get; set; }
            public string repAuthStatus { get; set; }
            public string flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class LeaveRequestSubDM
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int regID { get; set; }
            [DataMember]
            public int leaveID { get; set; }
            [DataMember]
            public DateTime leaveFrom { get; set; }
            [DataMember]
            public DateTime leaveTo { get; set; }
            [DataMember]
            public decimal noODays { get; set; }
            [DataMember]
            public string leaveName { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string Details { get; set; }
        }

        [Serializable]
        [DataContract]
        public class DesigLeaveAssg
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int DesigID { get; set; }
            [DataMember]
            public DateTime  WEf_date { get; set; }
            [DataMember]
            public Decimal  TotalL { get; set; }
            [DataMember]
            public string  Status { get; set; }
         
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string UserID { get; set; }
            public DateTime UEDate { get; set; }
            public string flag { get; set; }
            [DataMember]
            public string Designation { get; set; }
            [DataMember]
            public string Nature { get; set; }
            [DataMember]
            public Int32  NatureId { get; set; }
            [DataMember]
            public Decimal EncLeave { get; set; }
            [DataMember]
            public decimal LPM { get; set; }
           
        }

        public class EmpLeaveAccount
        {
            [DataMember]
            public string ApplicationNo { get; set; }
            [DataMember]
            public string Leave { get; set; }

            [DataMember]
            public int LeaveId { get; set; }
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int EmpID { get; set; }
            [DataMember]
            public string EmpCode { get; set; }
            [DataMember]
            public DateTime Joindate { get; set; }
            [DataMember]
            public Decimal OpenLeave { get; set; }
            [DataMember]
            public Decimal TakenLeave { get; set; }
            [DataMember]
            public Decimal BalLeave { get; set; }
            [DataMember]
            public Decimal MedicalLeave { get; set; }
            [DataMember]
            public Decimal TakenLeave_ML { get; set; }
            [DataMember]
            public Decimal BalLeave_ML { get; set; }
            [DataMember]
            public Decimal TotalLeave { get; set; }
            [DataMember]
            public Decimal EarnLeave { get; set; }
            [DataMember]
            public Decimal BalLeave_EL { get; set; }
            [DataMember]
            public Decimal TakenLeave_EL { get; set; }
            [DataMember]
            public string Status { get; set; }
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
            [DataMember]
            public Decimal TotalNo_of_EncLeave { get; set; }
            [DataMember]
            public Decimal TotalLeaveTaken { get; set; }
            [DataMember]
            public Decimal Earn_EncashLeave { get; set; }
            [DataMember]
            public string EncLeaveStatus { get; set; }
            [DataMember]
            public DateTime SessionFromDate { get; set; }
            [DataMember]
            public DateTime SessionToDate { get; set; }
            [DataMember]
            public DateTime AccountFromDate { get; set; }
            [DataMember]
            public DateTime AccountToDate { get; set; }
            [DataMember]
            public decimal AdjustbleLeaaves { get; set; }
            [DataMember]
            public decimal MDays { get; set; }
            [DataMember]
            public string Modify { get; set; }


        }

        public class EmpLeaveRecord
        {
            [DataMember]
            public string LeaveName { get; set; }

            [DataMember]
            public string  LeaveId { get; set; }
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int EmpID { get; set; }
            [DataMember]
            public string EmpCode { get; set; }
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
              [DataMember]
            public DateTime  LStart_dt {get;set;}
              [DataMember]
			public decimal NoofL {get;set;}
              [DataMember]
			public DateTime LEnd_Dt {get;set;}
              [DataMember]
			public string 	Application_No {get;set;}
              [DataMember]
			public DateTime	Applied_Date {get;set;}
              [DataMember]
			public string 	LApprStatus {get;set;}
             
              [DataMember]
			public string 	ReasonofL {get;set;}
              [DataMember]
			public string 	LAuthorityId {get;set;}
              [DataMember]
			public string 	SubstituteId {get;set;}
              [DataMember]
			public string 	Doc_Submit {get;set;}
            [DataMember]
			public string 	Leave_Type {get;set;}
             [DataMember]
			public byte DocumentN {get;set;}
             [DataMember]
		    public string 	Status {get;set;}
             [DataMember]
			public int		CityId {get;set;}
             [DataMember]
			public int	StateId {get;set;}
             [DataMember]
			public int	CountryId {get;set;}
             [DataMember]
			public string 	DutyAddr {get;set;}
             [DataMember]
			public string 	IsCancelled {get;set;}
             [DataMember]
             public int DeptId { get; set; }
             [DataMember]
             public DateTime ApprFrom { get; set; }
             [DataMember]
             public DateTime ApprTo { get; set; }
             [DataMember]
             public decimal ApprDays { get; set; }
             [DataMember]
             public DateTime ApprRejDate { get; set; }
             [DataMember]
             public DateTime CancelDate { get; set; }
             [DataMember]
             public string ApprByHod { get; set; }
             [DataMember]
             public string ApprByP { get; set; }
             [DataMember]
             public string HFType { get; set; }

             [DataMember]
             public DateTime  Doc_Submitdt { get; set; }
            [DataMember]
             public string LeaveHead { get; set; }
        }

        public class EmpLeaveApprov
        {
            [DataMember]
            public int  Id  { get; set; }
            [DataMember]
            public int empId { get; set; }
            [DataMember]
            public string empcode { get; set; }
            [DataMember]
			public string Application_No  { get; set; }
            [DataMember]
			public int	Authority_Id  { get; set; }
            [DataMember]
			public string Authority_Empcode  { get; set; }
            [DataMember]
			public string Principal_empcode  { get; set; }
            [DataMember]
			public int	Principal_empid  { get; set; }
            [DataMember]
			public string LApprStatusByHod  { get; set; }
            [DataMember]
            public string LApprStatusByP { get; set; }
            [DataMember]
            public string Status { get; set; }
          
            [DataMember]
			public DateTime	LApprFDatebyHod  { get; set; }
            [DataMember]
			public DateTime	LApprTdatebyHod  { get; set; }
            [DataMember]
			public decimal LNoofDaysApprHod  { get; set; }
            [DataMember] 
			public DateTime	LApprFDatebyP  { get; set; }
            [DataMember]
			public DateTime	LApprTdatebyP  { get; set; }
            [DataMember]
			public decimal 	LNoofDaysApprP  { get; set; }
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
            [DataMember]
            public int DeptId { get; set; }
            [DataMember]
            public string ReasonByHod { get; set; }
            [DataMember]
            public string ReasonByP{ get; set; }
       


        }

        public class EmpLeaveRecordchld
        {
            [DataMember]
            public string LeaveName { get; set; }
            [DataMember]
            public string Application_Nochld { get; set; }
            [DataMember]
            public string LeaveHead { get; set; }
            [DataMember]
            public string  LeaveId { get; set; }
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int EmpID { get; set; }
            [DataMember]
            public string EmpCode { get; set; }
            [DataMember]
             public string flag { get; set; }
            [DataMember]
            public DateTime LeaveDate { get; set; }
            [DataMember]
            public string Application_No { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string UserID { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public string AuthorityId { get; set; }

            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public int DeptId { get; set; }
            [DataMember]
            public string LeaveType { get; set; }
            [DataMember]
            public string LWP { get; set; }
            [DataMember]
            public string HFType { get; set; }

        }

        public LeaveData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
