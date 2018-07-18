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
/// Summary description for PayRoll
/// </summary>      
namespace HRM
{
    [Serializable]
    [DataContract]
    public class PayRollDM
    {
        [Serializable]
        [DataContract]
        public class WageMap
        {
            //[DataMember]
            //public int id { get; set; }

            [DataMember]
            public int gradeID {get; set;}

            [DataMember]
            public string wageID { get; set; }

            [DataMember]
            public string wageValue { get; set; }

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

            [DataMember]
            public DateTime wedate { get; set; }

        }
        [Serializable]
        [DataContract]
        public class WageType
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public string Allow_Deduct { get; set; }

            [DataMember]
            public string Wage_Type { get; set; }

            [DataMember]
            public string Type_{ get; set; }

            [DataMember]
            public string Taxable { get; set; }

            [DataMember]
            public string Prop { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

           [DataMember]
            public string UserID { get; set; }

           [DataMember]
           public DateTime UEDate { get; set; }

           [DataMember]
           public string   Flag{ get; set; }

           [DataMember]
           public DateTime wed { get; set; }


            
        }

        [Serializable]
        [DataContract]
        public class Sesssion
        {
            [DataMember]
            public int Id { get; set; }

            [DataMember]
            public string SessionF { get; set; }

            [DataMember]
            public DateTime StartDate { get; set; }

            [DataMember]
            public DateTime EndDate { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string Active { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class WorkDay
        {
            [DataMember]
            public Int32 id { get; set; }

            //[DataMember]
            //public string mmonth { get; set; }

            [DataMember]
            public Int32 yearID{get; set; }

            [DataMember]
            public string workDays { get; set; }

            [DataMember]
            public Int32 InstituteID { get; set; }

            [DataMember]
            public Int32 workdayid {get; set; }

            [DataMember]
            public DateTime frmdate { get; set; }

            [DataMember]
            public DateTime todate { get; set; }

            [DataMember]
            public DateTime DateTime { get; set; }

            [DataMember]
            public DateTime cdate { get; set; }
            [DataMember]
            public Int32 edate { get; set; }
            [DataMember]
            public Int32 mnth {get; set; }

            [DataMember]
            public Int32 yr { get; set; }

            [DataMember]
            public string flag {get; set; }

            [DataMember]
            public Int32 deptID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate {get; set; }
            [DataMember]
            public string SessionF { get; set; }

        }

        [Serializable]
        [DataContract]
        public class AppraisalReq
        {
             [DataMember]
            public int  ARid {get; set; }
          [DataMember]
            public int  Empid {get; set; }
              [DataMember]
            public string   Empcode {get; set; }
              [DataMember]
            public int  DeptId {get; set; }
              [DataMember]
            public int  RepAuthority {get; set; }
              [DataMember]
            public double  TI {get; set; }
              [DataMember]
            public double  TE1 {get; set; }
              [DataMember]
            public double  TE2 {get; set; }
              [DataMember]
            public string  OddSem {get; set; }
              [DataMember]
            public string  EvenSem {get; set; }
              [DataMember]
            public string  AR {get; set; }
              [DataMember]
            public DateTime   AppliedDt {get; set; }
              [DataMember]
            public int  InstituteID {get; set; }
              [DataMember]
            public string   SessionId {get; set; }
              [DataMember]
            public string   UserID {get; set; }
              [DataMember]
              public DateTime   UEDate { get; set; }
              [DataMember]
              public string flag { get; set; }
		
        }

        [Serializable]
        [DataContract]
        public class AppraisalHOD
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int ARid { get; set; }
            [DataMember]
            public int DeptId { get; set; }
            [DataMember]
            public int RepAuthority { get; set; }
           
            
            [DataMember]
            public decimal  AcadPerform { get; set; }
            [DataMember]
            public decimal  MainofSub { get; set; }
          
          
            [DataMember]
            public decimal  MainofStuRec { get; set; }
            [DataMember]
            public decimal  Compile { get; set; }
            [DataMember]
            public decimal  PartCollAct { get; set; }
            [DataMember]
            public decimal  TotalPer { get; set; }
            [DataMember]
            public string  Status { get; set; }
            [DataMember]
            public string   Approve { get; set; }
            [DataMember]
            public DateTime ApprDt { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionId { get; set; }
            [DataMember]
            public string UserID { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string Remark { get; set; }

        }
        [Serializable]
        [DataContract]
        public class MAXDA
        {
            [DataMember]
            public Int32 id { get; set; }
  
            [DataMember]
            public DateTime  wed { get; set; }

            [DataMember]
            public int  NatureId { get; set; }

            [DataMember]
            public Int32 InstituteID { get; set; }

            [DataMember]
            public double  MaxDA { get; set; }

            [DataMember]
            public string  SessionID { get; set; }

            [DataMember]
            public string UserID {get;set;}

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string flag { get; set; }
        }

        public PayRollDM()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
