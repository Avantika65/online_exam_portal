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
/// Summary description for Recruitment_data
/// </summary>
/// 
namespace HRM
{
    [Serializable]
    [DataContract]
    public class Recruitment
    {
        [Serializable]
        [DataContract]
        public class JobProfileDM
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int desigId { get; set; }

            [DataMember]
            public int rdeptId { get; set; }

            [DataMember]
            public int authority { get; set; }

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
            public string Auth { get; set; }

            [DataMember]
            public string rDept { get; set; }

            [DataMember]
            public string dept { get; set; }

            [DataMember]
            public string Designation { get; set; }
        }
        [Serializable]
        [DataContract]
        public class PannelMemb
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int jobId { get; set; }

            [DataMember]
            public string jobTitle { get; set; }

            [DataMember]
            public int mem_id { get; set; }

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
            public string DepartmentName { get; set; }

            [DataMember]
            public string jobCode { get; set; }

            [DataMember]
            public string memName { get; set; }

        }
        [Serializable]
        [DataContract]
        public class FeedbackDM
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int candId { get; set; }

            [DataMember]
            public int deptID { get; set; }

            [DataMember]
            public int desigID { get; set; }

            [DataMember]
            public int intrvR { get; set; }

            [DataMember]
            public string feedbk { get; set; }

            [DataMember]
            public string plcmMem { get; set; }

            [DataMember]
            public DateTime Ondate { get; set; }

            [DataMember]
            public int jobId { get; set; }

            [DataMember]
            public int maxPoint { get; set; }

            [DataMember]
            public int pointEarned { get; set; }

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
            public string Designation { get; set; }

            [DataMember]
            public string DepartmentName { get; set; }

            [DataMember]
            public string candName { get; set; }

            [DataMember]
            public string authority { get; set; }

            [DataMember]
            public string interv_R { get; set; }

            [DataMember]
            public int title { get; set; }

            [DataMember]
            public int memId { get; set; }

            [DataMember]
            public DateTime dateFrom { get; set; }

            [DataMember]
            public string intrvStatus { get; set; }

            [DataMember]
            public int idR { get; set; }


        }
        [Serializable]
        [DataContract]
        public class IntrRoundDM
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int jobId { get; set; }

            [DataMember]
            public string jobCode { get; set; }

            [DataMember]
            public string jobTitle { get; set; }

            [DataMember]
            public string interv_R { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public int maxPoint { get; set; }

            [DataMember]
            public string flag { get; set; }

            [DataMember]
            public string DepartmentName { get; set; }
        }
        [Serializable]
        [DataContract]
        public class AddJobVac
        {
            [DataMember]
            public int jobId { get; set; }

            [DataMember]
            public string jobCode { get; set; }

            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string title1 { get; set; }

            [DataMember]
            public string testName { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int desigId { get; set; }

            [DataMember]
            public string salFrom { get; set; }

            [DataMember]
            public string salTo { get; set; }
            [DataMember]
            public int MinAge { get; set; }

            [DataMember]
            public int maxAge { get; set; }

            [DataMember]
            public decimal tExp { get; set; }

            [DataMember]
            public decimal MaxExp { get; set; }

            [DataMember]
            public string responsibility { get; set; }

            [DataMember]
            public decimal tVacancy { get; set; }

            [DataMember]
            public DateTime aDate { get; set; }

            [DataMember]
            public DateTime lDate { get; set; }

            [DataMember]
            public string qualId { get; set; }

            [DataMember]
            public string Criteria { get; set; }

            [DataMember]
            public string SkillID { get; set; }

            [DataMember]
            public string TestId { get; set; }

            [DataMember]
            public string percentage { get; set; }

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
            //[DataMember]
            //public int sGrade{ get; set; }
            [DataMember]
            public string Designation { get; set; }
            [DataMember]
            public string DepartmentName { get; set; }
            [DataMember]
            public string salGrade { get; set; }
            [DataMember]
            public string approvby { get; set; }
        }

        [Serializable]
        [DataContract]
        public class CandRecruitDM
        {
            [DataMember]
            public int candid { get; set; }
            [DataMember]
            public string email { get; set; }
            [DataMember]
            public string fName { get; set; }
            [DataMember]
            public string lName { get; set; }
            [DataMember]
            public string ph { get; set; }
            [DataMember]
            public string mob { get; set; }
            [DataMember]
            public int cLoc { get; set; }
            [DataMember]
            public int pLoc { get; set; }
            [DataMember]
            public int exYear { get; set; }
            [DataMember]
            public int exMon { get; set; }
            [DataMember]
            public string nation { get; set; }
            [DataMember]
            public string gender { get; set; }
            [DataMember]
            public string skills { get; set; }
            [DataMember]
            public string qualId { get; set; }
            [DataMember]
            public int yPass { get; set; }
            [DataMember]
            public string inst { get; set; }
            [DataMember]
            public string status { get; set; }
            [DataMember]
            public string resumeName { get; set; }
            [DataMember]
            public int catId { get; set; }
            [DataMember]
            public decimal _percent { get; set; }
            [DataMember]
            public string refe { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string UserID { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public DateTime ApplyDate { get; set; }
            [DataMember]
            public string CurrEmp { get; set; }
            [DataMember]
            public string Designation { get; set; }
            [DataMember]
            public string flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class selctedcandDM
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public int deptid { get; set; }
            [DataMember]
            public int desigid { get; set; }
            [DataMember]
            public int jobid { get; set; }
            [DataMember]
            public string jobtitle { get; set; }
            [DataMember]
            public int candid { get; set; }
            [DataMember]
            public string payscale { get; set; }
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
            public int catid { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public int salFrom { get; set; }
        }
    }
}
public class Recruitment_data
{
    public Recruitment_data()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
