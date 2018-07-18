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
/// Summary description for PlcmData
/// </summary>
/// 

namespace HRM
{
    [Serializable]
    [DataContract]
    public class PlcmData
    {
        [Serializable]
        [DataContract]
        public class Invitation
        {

        }
        [Serializable]
        [DataContract]
        public class CompDetail
        {
            [DataMember]
            public int compId { get; set; }

            [DataMember]
            public string comName { get; set; }

            [DataMember]
            public string director { get; set; }

            [DataMember]
            public int city { get; set; }

            [DataMember]
            public string website { get; set; }

            [DataMember]
            public string mobile { get; set; }

            [DataMember]
            public string address { get; set; }

            [DataMember]
            public string description { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string status { get; set; }

            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public int  CountryId { get; set; }
            [DataMember]
            public int StateId { get; set; }
            [DataMember]
            public string CPer { get; set; }
            [DataMember]
            public string CPerDsg { get; set; }
            [DataMember]
            public int Type_Id { get; set; }
        }
        [Serializable]
        [DataContract]
        public class PlcmMemb
        {
            [DataMember]
            public int memId { get; set; }

            [DataMember]
            public int stuId { get; set; }

            [DataMember]
            public int empId { get; set; }

            [DataMember]
            public int deptId { get; set; }

            [DataMember]
            public int courseId { get; set; }

            [DataMember]
            public int semID { get; set; }

            [DataMember]
            public string  position { get; set; }

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
            public string opt { get; set; }
        }
        [Serializable]
        [DataContract]
        public class visitcomp
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int compId { get; set; }

            [DataMember]
            public string v_Person { get; set; }

            [DataMember]
            public string contact { get; set; }

            [DataMember]
            public string email { get; set; }

            [DataMember]
            public string website { get; set; }

            [DataMember]
            public DateTime v_Date { get; set; }

            [DataMember]
            public string v_time { get; set; }

            [DataMember]
            public string timespan { get; set; }

            [DataMember]
            public string Venue { get; set; }

            [DataMember]
            public string iRounds { get; set; }

            [DataMember]
            public int vacancy { get; set; }

            [DataMember]
            public string gap { get; set; }

            [DataMember]
            public string post { get; set; }

            [DataMember]
            public string technology { get; set; }

            [DataMember]
            public string package { get; set; }

            [DataMember]
            public int allPerc { get; set; }

            [DataMember]
            public string gender { get; set; }

            [DataMember]
            public int age { get; set; }

            [DataMember]
            public int backlog { get; set; }

            [DataMember]
            public string courseID { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string Semester { get; set; }

            [DataMember]
            public string flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class plcmIntrnd
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int compId { get; set; }

            [DataMember]
            public string interv_R { get; set; }

            [DataMember]
            public string roundNo { get; set; }

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
            public int  Plcm_V_Id { get; set; }
            [DataMember]
          public   string flag1 { get; set; }
        }
        [Serializable]
        [DataContract]
        public class PlcmofCamp
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public int compID { get; set; }

            [DataMember]
            public int studID { get; set; }

            [DataMember]
            public string pkg { get; set; }

            [DataMember]
            public DateTime plcmDate { get; set; }

            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string SessionID { get; set; }

            [DataMember]
            public string UserID { get; set; }

            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public string status { get; set; }

            [DataMember]
            public string flag { get; set; }

            [DataMember]
            public string comName { get; set; }

            [DataMember]
            public string website { get; set; }

            [DataMember]
            public string mobile { get; set; }
        }       
        public PlcmData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}