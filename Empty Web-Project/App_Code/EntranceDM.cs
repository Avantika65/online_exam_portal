using System;
using System.Runtime.Serialization;
using System.ServiceModel;


/// <summary>
/// Summary description for EntranceDM
/// </summary>
public class EntranceDM
{
    [Serializable]
    [DataContract]
	public class IssueForm
	{
        [DataMember]
        public int srno {get; set;}
		[DataMember]
        public int formsquantity {get;set;}
        [DataMember]
        public string issueto {get;set;}
        [DataMember]
        public string rateperform {get;set;}
        [DataMember]
        public DateTime issuedate {get;set;}
        [DataMember]
        public string Flag { get; set; }
	}
    [Serializable]
    [DataContract]
    public class SaleForm
    {
        [DataMember]
        public int saleID { get; set; }
        [DataMember]
        public int formsrno { get; set;}
        [DataMember]
        public DateTime issuedate { get; set; }
        [DataMember]
        public string fname { get; set; }
        [DataMember]
        public string mname { get; set; }
        [DataMember]
        public string lname { get; set; }
        [DataMember]
        public string contactno { get; set; }
        [DataMember]
        public string amount { get; set; }
        [DataMember]
        public int paymentmode { get; set; }
        [DataMember]
        public string issueto { get; set; }
        [DataMember]
        public int formsquantity { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]

    public class OfflineForm
    {
        [DataMember]
        public int offlineID {get; set;}

        [DataMember]
        public int formno { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string remark { get; set; }

        [DataMember]
        public string submitby { get; set; }

        [DataMember]
        public string Flag { get; set; }

    }

    [Serializable]
    [DataContract]

    public class OnlineForm
    {
        [DataMember]
        public int onlineID { get; set; }

        [DataMember]
        public int appearexam { get; set; }

        [DataMember]
        public DateTime examdate { get; set; }

        [DataMember]
        public string firstname { get; set; }

        [DataMember]
        public string middlename { get; set; }

        [DataMember]
        public string lastname { get; set; }

        [DataMember]
        public DateTime dateofbirth { get; set; }

        [DataMember]
        public string fathername { get; set; }

        [DataMember]
        public string cantactaddress { get; set; }

        [DataMember]
        public int city { get; set; }

        [DataMember]
        public string phoneno { get; set; }

        [DataMember]
        public string mobileno { get; set; }

        [DataMember]
        public string email { get; set; }
        
        [DataMember]
        public string chequeordraftno { get; set; }

        [DataMember]
        public int BankName { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string amount { get; set; }

        [DataMember]
        public string @onlineIDreturn { get; set; }


    }

    [Serializable]
    [DataContract]

    public class Online_Q
    {
        [DataMember]
        public int onlineID { get; set; }

        [DataMember]
        public int QID { get; set; }

        [DataMember]
        public string Qname { get; set; }

        [DataMember]
        public int TM { get; set; }

        [DataMember]
        public int MO { get; set; }

        [DataMember]
        public string DIV { get; set; }

        [DataMember]
        public string PER { get; set; }

        [DataMember]
        public int  ProfId { get; set; }

        

    }
    [Serializable]
    [DataContract]

    public class VerificationForm
    {
        [DataMember]
        public int onlineID { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string Paymentstatus { get; set; }

        [DataMember]
        public string remark { get; set; }

        [DataMember]
        public string remarkedby { get; set; }

        
    }

    [Serializable]
    [DataContract]

    public class SubjectForm
    {
        [DataMember]
        public int subID { get; set; }
       
        [DataMember]
        public string subname { get; set; }

        [DataMember]
        public string subcode { get; set; }

        [DataMember]
        public string Flag { get; set; }


    }

    [Serializable]
    [DataContract]

    public class ExamForm
    {
        [DataMember]
        public int ES_ID { get; set; }

        [DataMember]
        public string ExamSchdule { get; set; }

        
        [DataMember]
        public int  ExamID { get; set; }

        [DataMember]
        public DateTime examdate { get; set; }
        
        [DataMember]
        public string examtimefrom { get; set; }

        [DataMember]
        public string examtimeto { get; set; }

        [DataMember]
        public string ExamYear { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int ES_IDReturn { get; set; }


        [DataMember]
        public string Flag { get; set; }


    }

    [Serializable]
    [DataContract]

    public class ExamChild
    {
        [DataMember]
        public int ES_ID { get; set; }

        [DataMember]
        public int ExamID { get; set; }

        [DataMember]
        public int subID { get; set; }

        [DataMember]
        public DateTime examdate { get; set; }

        [DataMember]
        public string Flag { get; set; }
    }




    [Serializable]
    [DataContract]

    public class VenueForm
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string venueID { get; set; }
 
        [DataMember]
        public string venuename { get; set; }

        [DataMember]
        public string seatavailability { get; set; }

        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]

    public class EntranceRoomForm
    {
        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public string Roomno { get; set; }

        [DataMember]
        public int roomst { get; set; }

        [DataMember]
        public string venuename { get; set; }

        [DataMember]
        public string venuest { get; set; }

        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]

    public class ExamNameForm
    {
        [DataMember]
        public int ExamID { get; set; }

        [DataMember]
        public string examname { get; set; }

        [DataMember]
        public string examcode { get; set; }

        [DataMember]
        public string Flag { get; set; }

}

    [Serializable]
    [DataContract]

    public class EntranceSeat
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int Examname { get; set; }

        [DataMember]
        public string Examvenue { get; set; }

        [DataMember]
        public string Venuestr { get; set; }

        [DataMember]
        public string Roomno { get; set; }

        [DataMember]
        public string Roomstr { get; set; }

        [DataMember]
        public string Rowsno { get; set; }

        [DataMember]
        public string ColumnNo { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Timefrom { get; set; }

        [DataMember]
        public string Timeto { get; set; }

        [DataMember]
        public string ExamYear { get; set; }

        [DataMember]
        public string seatcode { get; set; }

        [DataMember]
        public string Flag { get; set; }


    }

      

    [Serializable]
    [DataContract]

    public class RollNoForm
    {
        [DataMember]
        public int onlineID { get; set; }

        [DataMember]
        public int ExamID { get; set; }

        [DataMember]
        public int Srollno { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Flag { get; set; }


    }

    [Serializable]
    [DataContract]

    public class AdmitCardForm
    {
        [DataMember]
        public int onlineID { get; set; }

        [DataMember]
        public int ExamID { get; set; }

        [DataMember]
        public int Srollno { get; set; }

        [DataMember]
        public int Dispatchno { get; set; }

        [DataMember]
        public string Flag { get; set; }


    }

    [Serializable]
    [DataContract]

    public class EN_SeatManagement
    {
        [DataMember]
        public int SeatMgmtID { get; set; }

        [DataMember]
        public string RollnoFrom { get; set; }

        [DataMember]
        public string RollnoTo { get; set; }

        [DataMember]
        public string SeatCode { get; set; }

        [DataMember]
        public string Flag { get; set; }


    }

}
