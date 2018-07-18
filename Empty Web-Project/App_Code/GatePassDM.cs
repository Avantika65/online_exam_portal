using System;
using System.Runtime.Serialization;
using System.ServiceModel;
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



/// <summary>
/// Summary description for GatePassDM
/// </summary>
public class GatePassDM
{
    [Serializable]
    [DataContract]
    public class GateMasterDM
    {
        [DataMember]
        public int gateID { get; set; }
        [DataMember]
        public string gname { get; set; }
        [DataMember]
        public string gtype { get; set; }
        [DataMember]
        public string flag { get; set; }
        //
        // TODO: Add constructor logic here
        //
    }

    [Serializable]
    [DataContract]
    public class GateAuthorityDM
    {
        [DataMember]
        public string Aperson { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string AReporting { get; set; }
        [DataMember]
        public string isAuthority { get; set; }
        [DataMember]
        public int aid { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GateShiftDM
    {

        [DataMember]
        public string SeqPerson { get; set; }
        [DataMember]
        public string GateNo { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public string ShiftType { get; set; }
        [DataMember]
        public int shiftID { get; set; }
        [DataMember]
        public string flag { get; set; }
    }


    [Serializable]
    [DataContract]
    public class DestinationMastDM
    {
        [DataMember]
        public int DID { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GatePassEntryDM
    {
        [DataMember]
        public int GPSID { get; set; }
        [DataMember]
        public string GPSNO { get; set; }
        [DataMember]
        public DateTime GPSDate { get; set; }
        [DataMember]
        public string GPSTime { get; set; }
        [DataMember]
        public string EnteredBY { get; set; }
        [DataMember]
        public int PassType { get; set; }
        [DataMember]
        public string Purpose { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int GateID { get; set; }
        [DataMember]
        public string VehicalNo { get; set; }
        [DataMember]
        public string VehicalType { get; set; }
        [DataMember]
        public string Visit_Department { get; set; }
        [DataMember]
        public int DestinationID { get; set; }
        [DataMember]
        public string Visit_Purpose { get; set; }
        [DataMember]
        public string PersonTo_Meet { get; set; }
        [DataMember]
        public string PassEntryFrom { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public string OutTime { get; set; }
        [DataMember]
        public int IsValidity { get; set; }
        [DataMember]
        public int AppointmentID { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public byte[] visitor_Photo { get; set; }
        [DataMember]
        public string Carry_Item { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string GatePID { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public int NOS { get; set; }
        [DataMember]
        public int NOM { get; set; }
        [DataMember]
        public int NOF { get; set; }
        [DataMember]
        public string UEname { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int Country { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public int PersonTomeet_ID { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GatePassEntryChildDM
    {
        [DataMember]
        public int GPSID { get; set; }
        [DataMember]
        public DateTime ValidFrom { get; set; }
        [DataMember]
        public DateTime ValidTo { get; set; }
        [DataMember]
        public string AmountPay { get; set; }
        [DataMember]
        public string PayMode { get; set; }
        [DataMember]
        public int Satus { get; set; }
        [DataMember]
        public int IsExpired { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GateAppointMastDM
    {
        [DataMember]
        public int appID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Day  { get; set; }
        [DataMember]
        public string FirstN { get; set; }
        [DataMember]
        public string MidN { get; set; }
        [DataMember]
        public string LastN { get; set; }
        [DataMember]
        public string appType { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public string isInform { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string fwdTo { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GateAppointListDM
    {
        [DataMember]
        public int appID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public string status { get; set; }

    }
    [Serializable]
    [DataContract]
    public class GatePassVisitorDM
    {
        [DataMember]
        public int GPSID { get; set; }
        [DataMember]
        public string GPSNO { get; set; }
        [DataMember]
        public DateTime GPSDate { get; set; }
        [DataMember]
        public string GPSTime { get; set; }
        [DataMember]
        public string EnteredBY { get; set; }
        [DataMember]
        public int PassType { get; set; }
        [DataMember]
        public string Purpose { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int GateID { get; set; }
        [DataMember]
        public string VehicalNo { get; set; }
        [DataMember]
        public string VehicalType { get; set; }
        [DataMember]
        public int Visit_Department { get; set; }
        [DataMember]
        public int DestinationID { get; set; }
        [DataMember]
        public string Visit_Purpose { get; set; }
        [DataMember]
        public string PersonTo_Meet { get; set; }
        [DataMember]
        public string PassEntryFrom { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string OutTime { get; set; }
        [DataMember]
        public int IsValidity { get; set; }
        [DataMember]
        public int AppointmentID { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public byte[] visitor_Photo { get; set; }
        [DataMember]
        public string Carry_Item { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string GatePID { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public int NOS { get; set; }
        [DataMember]
        public int NOM { get; set; }
        [DataMember]
        public int NOF { get; set; }
        [DataMember]
        public string UEname { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GatePassVisitorChildDM
    {
        [DataMember]
        public int GPSID { get; set; }
        [DataMember]
        public DateTime ValidFrom { get; set; }
        [DataMember]
        public DateTime ValidTo { get; set; }
        [DataMember]
        public string AmountPay { get; set; }
        [DataMember]
        public string PayMode { get; set; }
        [DataMember]
        public int Satus { get; set; }
        [DataMember]
        public int IsExpired { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GatechkOutDM
    {
        [DataMember]
        public int chkoutID { get; set; }
        [DataMember]
        public int passID { get; set; }
        [DataMember]
        public int GateID { get; set; }
        [DataMember]
        public DateTime chkIndate { get; set; }
        [DataMember]
        public DateTime chkOutdate { get; set; }
        [DataMember]
        public string OutTime { get; set; }
        [DataMember]
        public string InTime { get; set; }
        [DataMember]
        public int Statusgp { get; set; }
        [DataMember]
        public int flag { get; set; }
        [DataMember]
        public int Entry_Type { get; set; }
        [DataMember]
        public DateTime Entry_Date { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GPmovementDM
    {

        [DataMember]
        public int MVID { get; set; }
        [DataMember]
        public int GatePID { get; set; }
        [DataMember]
        public int EmpID { get; set; }
        [DataMember]
        public string Ename { get; set; }
        [DataMember]
        public DateTime InDate { get; set; }
        [DataMember]
        public string InTime { get; set; }
        [DataMember]
        public string OutTime { get; set; }
        [DataMember]
        public DateTime OutDate { get; set; }
        [DataMember]
        public int Statusgp { get; set; }
        [DataMember]
        public int flag { get; set; }
        [DataMember]
        public int Entry_Type { get; set; }
        [DataMember]
        public DateTime Entry_Date { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GPDutyShiftFill
    {
        [DataMember]
        public int ShiftID { get; set; }
        [DataMember]
        public string APerson { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public string SeqPerson { get; set; }//GateNo
        [DataMember]
        public string GateNo { get; set; }
    }

  [Serializable]
    [DataContract]
    public class GPAppontmentFill
    {
        [DataMember]
        public int appID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string status { get; set; }  
        [DataMember]
        public string ContactNo { get; set; }
    }

    [Serializable]
    [DataContract]
    public class EmployeeDM
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int Country { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Active { get; set; }
        [DataMember]
        public string Councellor { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDt { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
    }

    [Serializable]
    [DataContract]
    public class SearchAppointment
    {
        [DataMember]
        public int appID { get; set; }
        [DataMember]
        public string AB { get; set; }
        [DataMember]
        public string AW { get; set; }
    }
    [Serializable]
    [DataContract]
    public class SearchEmployeeInOutEnrty
    {
        [DataMember]
        public int MVID { get; set; }
        [DataMember]
        public int EmpID { get; set; }
        [DataMember]
        public DateTime InDate { get; set; }
        [DataMember]
        public string InTime { get; set; }
        [DataMember]
        public DateTime OutDate { get; set; }
        [DataMember]
        public string OutTime { get; set; }//MVID
        [DataMember]
        public string Ename { get; set; }//MVID
    }
    public GatePassDM()
    {
    }
}





