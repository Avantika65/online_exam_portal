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
namespace ESData
{

    [Serializable]
    [DataContract]
    public class PostDCheque
    {
        [DataMember]
        public Int32 PD_StudentID { get; set; }
        [DataMember]
        public string PD_Curr_Sess { get; set; }
        [DataMember]
        public int PD_InstituteID { get; set; }
        [DataMember]
        public string PD_ChequeNo { get; set; }
        [DataMember]
        public DateTime PD_Cheque_Date { get; set; }
        [DataMember]
        public string PD_Cheque_Session { get; set; }
        [DataMember]
        public double PD_Cheque_Amt { get; set; }
        [DataMember]
        public string PD_U_Name { get; set; }
        [DataMember]
        public DateTime PD_Entry_Date { get; set; }
        public PostDCheque()
        {
        }
    }
}
