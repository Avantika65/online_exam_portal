﻿using System;
using System.Runtime.Serialization;
using System.ServiceModel;


public class FeesDM
{
    [Serializable]
    [DataContract]
    public class PaymentModeData
    {
        [DataMember]
        public int PMID { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public string Nature { get; set; }
        [DataMember]
        public int IsPredefined { get; set; }
        [DataMember]
        public int BankRequired { get; set; }
        [DataMember]
        public int DocRequired { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BankDetailData
    {
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public string BankCode { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ODCChargeData
    {
        [DataMember]
        public int ODCID { get; set; }
        [DataMember]
        public string ODC_Name { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public DateTime Wef_Date { get; set; }
        [DataMember]
        public int Day_Duration { get; set; }
        [DataMember]
        public int ODCAfterDay { get; set; }
        [DataMember]
        public int AmountAfterDue { get; set; }
        [DataMember]
        public int Applicable_On { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public int LegderID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FeeHeadData
    {
        [DataMember]
        public int FeeHeadId { get; set; }
        [DataMember]
        public string FeeHeadName { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public string Nature { get; set; }
        [DataMember]
        public string SubCategory { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public int apply_head { get; set; }
        [DataMember]
        public int FeeOrder { get; set; }
        [DataMember]
        public string Flag { get; set; }


    }

    [Serializable]
    [DataContract]
    public class Fee_Student
    {
        [DataMember]
        public int FeeHeadId { get; set; }
        [DataMember]
        public string FeeHeadName { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string BreakOffTime { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public DateTime LastDate { get; set; }
        [DataMember]
        public int courseFeeid { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public int sid { get; set; }
        [DataMember]
        public string FeeClass { get; set; }
        [DataMember]
        public string Session { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RCNODM
    {
        [DataMember]
        public int rcnoid { get; set; }
        [DataMember]
        public int instid { get; set; }
        [DataMember]
        public int coursid { get; set; }
        [DataMember]
        public string sessnid { get; set; }
        [DataMember]
        public string prefix { get; set; }
        [DataMember]
        public int startfrm { get; set; }
        [DataMember]
        public int upto { get; set; }
        [DataMember]
        public int lastused { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public int flag { get; set; }

    }

    [Serializable]
    [DataContract]
    public class FeeStructMDM
    {
        [DataMember]
        public int courseFeeId { get; set; }
        [DataMember]
        public string SessionCode { get; set; }
        [DataMember]
        public string CourseCode { get; set; }
        [DataMember]
        public string SpecialisationCode { get; set; }
        [DataMember]
        public string FeeHeadCode { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public string FeeClass { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDt { get; set; }
        [DataMember]
        public string CCategory { get; set; }
        [DataMember]
        public string CID { get; set; }
        [DataMember]
        public string yrid { get; set; }
        [DataMember]
        public string odc { get; set; }
        [DataMember]
        public string batch { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public string flag { get; set; }
        [DataMember]
        public string FeeIDreturn { get; set; }

    }

    [Serializable]
    [DataContract]
    public class FeeStructCDM
    {
        [DataMember]
        public int courseFeeId { get; set; }
        [DataMember]
        public int srNo { get; set; }
        [DataMember]
        public string BreakoffTime { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public DateTime LastDate { get; set; }
        [DataMember]
        public string DefaultHead { get; set; }
        [DataMember]
        public string flag { get; set; }

    }

    [Serializable]
    [DataContract]
    public class FeeTransDetail
    {
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public DateTime Trans_Date { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string PrNo { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string Uname { get; set; }
        [DataMember]
        public DateTime Entry_Date { get; set; }
        [DataMember]
        public int Ppsno { get; set; }
        [DataMember]
        public int Sid { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int InstId { get; set; }
        [DataMember]
        public DateTime duedate { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalAmount { get; set; }
        [DataMember]
        public string PrnoId { get; set; }
        [DataMember]
        public string Used { get; set; }
        [DataMember]
        public string LastUsed { get; set; }
        [DataMember]
        public int FeeSubId { get; set; }
        [DataMember]
        public string Trans_State { get; set; }
        //[DataMember]
        //public int LastUsed { get; set; }

    }

    [Serializable]
    [DataContract]
    public class FeePayDetail
    {
        [DataMember]
        public int SNo { get; set; }
        [DataMember]
        public int DocID { get; set; }
        [DataMember]
        public string PayM { get; set; }
        [DataMember]
        public float Amt { get; set; }
        [DataMember]
        public int DDNO { get; set; }
        [DataMember]
        public DateTime DateP { get; set; }
        [DataMember]
        public int PID { get; set; }
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public string PrNo { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string Uname { get; set; }
        [DataMember]
        public DateTime Entry_Date { get; set; }
        [DataMember]
        public int Ppsno { get; set; }
        [DataMember]
        public int Sid { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public int InstId { get; set; }
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public string Used { get; set; }
        [DataMember]
        public string LastUsed { get; set; }
        [DataMember]
        public int FeeId { get; set; }
        [DataMember]
        public int FeeSubId { get; set; }
        [DataMember]
        public string Trans_State { get; set; }
    }


    [Serializable]
    [DataContract]
    public class Student_Advance
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public string Paymode { get; set; }
        [DataMember]
        public decimal TotalAmt { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        [DataMember]
        public decimal BalAmt { get; set; }
        [DataMember]
        public int DDNo { get; set; }
        [DataMember]
        public DateTime DDNoDate { get; set; }
        [DataMember]
        public int IsPaid { get; set; }
        [DataMember]
        public string Prno { get; set; }
        [DataMember]
        public int Rcno { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public int Pid { get; set; }
        [DataMember]
        public int RcnoID { get; set; }
        [DataMember]
        public int IType { get; set; }

    }


    [Serializable]
    [DataContract]
    public class AdvDepositeFee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Adv_Rcno { get; set; }
        [DataMember]
        public decimal Deducted_Amt { get; set; }
        [DataMember]
        public string Paymode { get; set; }
        [DataMember]
        public DateTime Trans_Date { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public decimal BalAmt { get; set; }
        [DataMember]
        public int IsPaid { get; set; }
        [DataMember]
        public int StudentId { get; set; }

    }


    [Serializable]
    [DataContract]
    public class FeeRefund
    {
        [DataMember]
        public int RefundID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int PID { get; set; }
        [DataMember]
        public int AccountNoID { get; set; }
        [DataMember]
        public decimal TotalAmt { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        [DataMember]
        public decimal BalAmt { get; set; }
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public int DDNo { get; set; }
        [DataMember]
        public DateTime DDate { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }
        [DataMember]
        public int RefFeeID { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public string PrNo { get; set; }
        [DataMember]
        public int RefRCNO { get; set; }
        [DataMember]
        public string RefPrNo { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public string RefType { get; set; }
        [DataMember]
        public string Narration { get; set; }
        [DataMember]
        public string RefRetType { get; set; }
    }


    [Serializable]
    [DataContract]
    public class ReceiptCancellation
    {
        [DataMember]
        public int RCancelID { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int PPSNO { get; set; }
        [DataMember]
        public string YearID { get; set; }
        [DataMember]
        public int SemID { get; set; }
        [DataMember]
        public decimal AmtCancelled { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public int InstituteId { get; set; }
        [DataMember]
        public decimal CCharge { get; set; }
        [DataMember]
        public DateTime CDate { get; set; }
        [DataMember]
        public DateTime FTransDate { get; set; }
        [DataMember]
        public string Pid { get; set; }
        [DataMember]
        public string DDNO { get; set; }

    }


    [Serializable]
    [DataContract]
    public class RCancelStudent
    {
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public int SemID { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        //[DataMember]
        //public decimal BalAmt { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ChequeDefaultEntryM
    {
        [DataMember]
        public int DefaultID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public DateTime Trans_Date { get; set; }
        [DataMember]
        public string Doc_Type { get; set; }
        [DataMember]
        public int Def_ChqNo { get; set; }
        [DataMember]
        public DateTime Def_ChqDate { get; set; }
        [DataMember]
        public decimal Def_ChqAmt { get; set; }
        [DataMember]
        public int PPSNO { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }

    }

    [Serializable]
    [DataContract]
    public class ChequeDefaultEntryC
    {
        [DataMember]
        public int DefID { get; set; }
        [DataMember]
        public int PMode { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        [DataMember]
        public int IBank { get; set; }
        [DataMember]
        public int ChqNo { get; set; }
        [DataMember]
        public DateTime ChqDate { get; set; }
        [DataMember]
        public decimal ChqAmt { get; set; }
        [DataMember]
        public int ChqDDNo { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public int Status { get; set; }
    }


    [Serializable]
    [DataContract]
    public class StudentODC
    {
        [DataMember]
        public int FeeOdcID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int OdcID { get; set; }
        [DataMember]
        public DateTime WefDate { get; set; }
        [DataMember]
        public int FeeHeadID { get; set; }
        [DataMember]
        public decimal TotalAmt { get; set; }
        [DataMember]
        public decimal TotalPaid { get; set; }
        [DataMember]
        public decimal TotalBal { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public int TotalDays { get; set; }
        //[DataMember]
        //public int Rcno { get; set; }
        //[DataMember]
        //public string Prno { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }
        //[DataMember]
        //public DateTime DueDate { get; set; }
        [DataMember]
        public int Sid { get; set; }
        [DataMember]
        public String flag { get; set; }
        //[DataMember]
        //public int Fid { get; set; }
        //[DataMember]
        //public int RcnoID { get; set; }
        [DataMember]
        public string PayStatus { get; set; }
        [DataMember]
        public int FeeSubID { get; set; }
        //[DataMember]
        //public int FSubID { get; set; }
    }


    [Serializable]
    [DataContract]
    public class StudentODCPMode
    {
        [DataMember]
        public int Rcno { get; set; }
        [DataMember]
        public string Prno { get; set; }
        [DataMember]
        public int Pid { get; set; }
        [DataMember]
        public int DDNO { get; set; }
        [DataMember]
        public DateTime DDate { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ChangePayMode
    {
        [DataMember]
        public int ModeID { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public int LastPMode { get; set; }
        [DataMember]
        public int CurrentPMode { get; set; }
        [DataMember]
        public int LastAmount { get; set; }
        [DataMember]
        public int LastDNO { get; set; }
        [DataMember]
        public DateTime LastDDate { get; set; }
        [DataMember]
        public int CurrentDNO { get; set; }
        [DataMember]
        public DateTime CurrentDDate { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int SNo { get; set; }
        [DataMember]
        public string PayM { get; set; }
        [DataMember]
        public int PID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public int BankID { get; set; }
    }


    //[Serializable]
    //[DataContract]
    //public class ChangePayModeN
    //{
    //    [DataMember]
    //    public int SNo { get; set; }
    //    [DataMember]
    //    public string PRNO { get; set; }
    //    [DataMember]
    //    public string PayM { get; set; }
    //    [DataMember]
    //    public int PID { get; set; }
    //    [DataMember]
    //    public int DDNO { get; set; }
    //    [DataMember]
    //    public DateTime DateP { get; set; }
    //}


    [Serializable]
    [DataContract]
    public class PPSNO
    {

        [DataMember]
        public int ppsnoid { get; set; }
        [DataMember]
        public int instid { get; set; }
        [DataMember]
        public string sessnid { get; set; }
        [DataMember]
        public int startfrm { get; set; }
        [DataMember]
        public int upto { get; set; }
        [DataMember]
        public int used { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
    [Serializable]
    [DataContract]
    public class CheckIsAuto
    {
        [DataMember]
        public int IsPPSNOAuto { get; set; }
        [DataMember]
        public int IsRCNOAuto { get; set; }

    }
    [Serializable]
    [DataContract]
    public class GetPPSNO
    {
        [DataMember]
        public int PPSNO { get; set; }

    }

    [Serializable]
    [DataContract]
    public class GetRCNO
    {
        [DataMember]
        public int RCNO { get; set; }

    }

    [Serializable]
    [DataContract]
    public class GetFeeAll
    {
        [DataMember]
        public int FeeHeadId { get; set; }
        [DataMember]
        public string FeeHeadName { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string BreakoffTime { get; set; }
        [DataMember]
        public DateTime LastDate { get; set; }
        [DataMember]
        public int courseFeeId { get; set; }
        [DataMember]
        public int Course { get; set; }
        [DataMember]
        public string Shortname { get; set; }
        [DataMember]
        public string SID { get; set; }
        [DataMember]
        public string session { get; set; }

    }

    [Serializable]
    [DataContract]
    public class YearSem
    {
        [DataMember]
        public string Yr { get; set; }
        [DataMember]
        public int SID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class PostDatedGrd
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string SName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillODCChargeData
    {
        [DataMember]
        public int ODCID { get; set; }
        [DataMember]
        public string DueDate { get; set; }
        [DataMember]
        public string FeeHeadName { get; set; }
        [DataMember]
        public DateTime Wef_Date { get; set; }
        [DataMember]
        public int FeeSubID { get; set; }
        [DataMember]
        public int ODC_Name { get; set; }
        [DataMember]
        public int OD_Days { get; set; }
        [DataMember]
        public int ODC_Formula { get; set; }
        [DataMember]
        public string Fine { get; set; }
        [DataMember]
        public int LegderID { get; set; }
    }


    [Serializable]
    [DataContract]
    public class StudentChild
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int FeeODCID { get; set; }
        [DataMember]
        public decimal PaidAMT { get; set; }
        [DataMember]
        public int PMTDays { get; set; }
        [DataMember]
        public DateTime PayDate { get; set; }
        [DataMember]
        public int PayCounter { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int Sid { get; set; }
        //[DataMember]
        //public int FeeID { get; set; }
        [DataMember]
        public int FeeSubID { get; set; }
        [DataMember]
        public int Rcno { get; set; }
        [DataMember]
        public string Prno { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public int RcnoID { get; set; }
    }


    [Serializable]
    [DataContract]
    public class GetChequeDetailDM
    {
        [DataMember]
        public string ChequeNo { get; set; }
        [DataMember]
        public string DocType { get; set; }
        [DataMember]
        public DateTime ChequeDate { get; set; }
        [DataMember]
        public decimal ChequeAmount { get; set; }
        [DataMember]
        public string ChequeDetail { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int SemesterID { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ChequeDefaulterMasterDM
    {
        [DataMember]
        public int DEMID { get; set; }
        [DataMember]
        public int CHDDNo { get; set; }
        [DataMember]
        public DateTime Trans_Date { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int SubmittedBy { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int DocType { get; set; }
        [DataMember]
        public string UsedIn { get; set; }
        [DataMember]
        public int Flag { get; set; }
        [DataMember]
        public int SemesterID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillChequeDefaulterDetail
    {
        [DataMember]
        public int DEMID { get; set; }
        [DataMember]
        public int CHDDNo { get; set; }
        [DataMember]
        public DateTime Trans_Date { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string DocType { get; set; }
        [DataMember]
        public DateTime? DateP { get; set; }
        [DataMember]
        public DateTime ChequeD_Date { get; set; }

    }

    [Serializable]
    [DataContract]
    public class ChequeDefaulterChildDM
    {
        [DataMember]
        public int DEChildID { get; set; }
        [DataMember]
        public int DEMID { get; set; }
        [DataMember]
        public int New_ChequeDD { get; set; }
        [DataMember]
        public DateTime ChequeD_Date { get; set; }
        [DataMember]
        public int IssuedBy { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public decimal Process_Charge { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int New_DocType { get; set; }
        [DataMember]
        public int Flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Fee_Cancel_MDM
    {
        [DataMember]
        public int CRID { get; set; }
        [DataMember]
        public string PRNO { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public DateTime Cancel_Date { get; set; }
        [DataMember]
        public decimal Cancel_Amount { get; set; }
        [DataMember]
        public decimal Cancel_Charge { get; set; }
        [DataMember]
        public DateTime UE_Date { get; set; }
        [DataMember]
        public string U_Name { get; set; }
        [DataMember]
        public int Flag { get; set; }
        [DataMember]
        public string retCRID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Fee_Cancel_CDM
    {
        [DataMember]
        public int CRCID { get; set; }
        [DataMember]
        public int CRID { get; set; }
        [DataMember]
        public int FeeSubID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string RCNO { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillFeeReceiptDM
    {
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string ReceiptDetail { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public DateTime Trans_Date { get; set; }
        [DataMember]
        public string PaymentDetail { get; set; }
        [DataMember]
        public int PPSNO { get; set; }
        [DataMember]
        public string PaidBy { get; set; }
        [DataMember]
        public string PID { get; set; }
        [DataMember]
        public string FID { get; set; }
        [DataMember]
        public int SemesterID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillCancelReceiptDM
    {
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public string PRNO { get; set; }
        [DataMember]
        public int PPSNO { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public DateTime Cancel_Date { get; set; }
        [DataMember]
        public decimal Charges { get; set; }
        [DataMember]
        public string SubmittedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RefundApproval
    {
        [DataMember]
        public int RefundID { get; set; }
        [DataMember]
        public int Status { get; set; }
    }


    [Serializable]
    [DataContract]
    public class FeeNatureDM
    {
        [DataMember]
        public int FeeHeadID { get; set; }
        [DataMember]
        public string Nature { get; set; }
    }

    public FeesDM()
    {
    }

    [Serializable]
    [DataContract]
    public class RefundFeeDetail
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public string FeeHead { get; set; }
        [DataMember]
        public decimal Amount { get; set; }

    }
    [Serializable]
    [DataContract]
    public class OutSourceFeeOrgMGrdDM
    {
        [DataMember]
        public int OutSourceOrgID { get; set; }
        [DataMember]
        public string OutSourceOrg { get; set; }
    }


    [Serializable]
    [DataContract]
    public class OutSourceFeeOrgMDM
    {
        [DataMember]
        public int OutSourceOrgID { get; set; }
        [DataMember]
        public string OutSourceOrg { get; set; }
        [DataMember]
        public DateTime EntryDate { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
    }
    [Serializable]
    [DataContract]
    public class HostelBusCancelDetailDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalanceAmount { get; set; }
        [DataMember]
        public string Narration { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class HostelBusCancelPaymentDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        //[DataMember]
        //public decimal PaidAmount { get; set; }
        //[DataMember]
        //public decimal BalanceAmount { get; set; }
        [DataMember]
        public string Narration { get; set; }
        [DataMember]
        public string Prno { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class VoucherDeletionDueGrd
    {
        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalanceAmount { get; set; }
    }




    [Serializable]
    [DataContract]
    public class VoucherDeletionRecGrd
    {
        [DataMember]
        public string PrNo { get; set; }
        [DataMember]
        public string RefPrNo { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal TAmt { get; set; }
        [DataMember]
        public decimal BalanceAmount { get; set; }
    }




    [Serializable]
    [DataContract]
    public class VoucherDueDeleteDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string FlagT { get; set; }
    }



    [Serializable]
    [DataContract]
    public class VoucherRecDeleteDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string PrNo { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        [DataMember]
        public string FlagT { get; set; }
        //[DataMember]
        //public string Flag { get; set; }

    }



    [Serializable]
    [DataContract]
    public class VoucherDeleteDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalanceAmount { get; set; }
        [DataMember]
        public int FeeID { get; set; }       
        [DataMember]
        public string PrNo { get; set; }
        [DataMember]
        public string RefPrNo { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public string TPTransID { get; set; }
    }
}
