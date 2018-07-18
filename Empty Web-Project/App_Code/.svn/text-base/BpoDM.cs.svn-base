using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for BpoDM
/// </summary>
public class BpoDM
{
	public BpoDM()
	{
	}

    [Serializable]
    [DataContract]
    public class FillBpoDM
    {
        [DataMember]
        public int RegNo { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string Forward_To { get; set; }
        [DataMember]
        public string DateApplied { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string Earlier_Ref { get; set; }
        [DataMember]
        public string Next_Date { get; set; }
        [DataMember]
        public string Ndate { get; set; }
        [DataMember]
        public string Pincode { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Timeapplied { get; set; }
        [DataMember]
        public string Course_Applied { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string Qualified_Exam { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string FP { get; set; }
        [DataMember]
        public string Mode_Info { get; set; }
        [DataMember]
        public string Mno { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public decimal totpercent { get; set; }
        [DataMember]
        public string allrank { get; set; }
        [DataMember]
        public string subrank { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string iseeking { get; set; }
        [DataMember]
        public string Tno { get; set; }
        [DataMember]
        public string StateId { get; set; }
        [DataMember]
        public string CityId { get; set; }
       
        
    }
    [Serializable]
    [DataContract]
    public class FillCityDM
    {
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string CityName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillStateDM
    {
        [DataMember]
        public int StateId { get; set; }
        [DataMember]
        public string StateName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillCountryDM
    {
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string CountryName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillOccupationDM
    {
        [DataMember]
        public int OccupationId { get; set; }
        [DataMember]
        public string OccupationName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillCollegeDM
    {
        [DataMember]
        public int collegeID { get; set; }
        [DataMember]
        public string ShortName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillCourseDM
    {
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string CourseName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillForwardDM
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string EName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillQualDM
    {
        [DataMember]
        public int ProfId { get; set; }
        [DataMember]
        public string ProfName { get; set; }
    }


    [Serializable]
    [DataContract]
    public class StudentEPassed
    {
        [DataMember]
        public string BPOID { get; set; }
        [DataMember]
        public string CouncellingID { get; set; }
        [DataMember]
        public string Exam_passed { get; set; }
        [DataMember]
        public string Subjects { get; set; }
        [DataMember]
        public string MaxMarks { get; set; }
        [DataMember]
        public string MinMarks { get; set; }
        [DataMember]
        public string Gross_Per { get; set; }
        [DataMember]
        public string Qual_year { get; set; }
        [DataMember]
        public string IsCalculated { get; set; }
        [DataMember]
        public DateTime UEndt { get; set; }
        [DataMember]
        public string Uentime { get; set; }
        [DataMember]
        public string U_name { get; set; }
        [DataMember]
        public string flag { get; set; }
    }


    [Serializable]
    [DataContract]
    public class BpoInsert
    {
        [DataMember]
        public int RegNo { get; set; }
        [DataMember]
        public string Fname { get; set; }
        [DataMember]
        public string Mname { get; set; }
        [DataMember]
        public string Lname { get; set; }
        [DataMember]
        public string Tno { get; set; }
        [DataMember]
        public string Mno { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Pincode { get; set; }
        [DataMember]
        public string DateApplied { get; set; }
        [DataMember]
        public string TimeApplied { get; set; }
        [DataMember]
        public string Course_applied { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string Qualified_Exam { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string Forward_To { get; set; }
        [DataMember]
        public string Next_Date { get; set; }
        [DataMember]
        public string Ndate { get; set; }
        [DataMember]
        public string Mode_Info { get; set; }
        [DataMember]
        public string Earlier_Ref { get; set; }
        [DataMember]
        public string flag { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public decimal totpercent { get; set; }
        [DataMember]
        public string allrank { get; set; }
        [DataMember]
        public string subrank { get; set; }
        [DataMember]
        public string iseeking { get; set; }
        [DataMember]
        public string session { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillProfileSubDM
    {
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string MM { get; set; }
        [DataMember]
        public string MO { get; set; }
        [DataMember]
        public string IsCalculated { get; set; }
        [DataMember]
        public string Gross_Per { get; set; }
        [DataMember]
        public string BPOID { get; set; }
          [DataMember]
        public string CouncellingID { get; set; }
          [DataMember]
          public string ProfileID { get; set; }
       
        
    }


    [Serializable]
    [DataContract]
    public class FillSubjectDM
    {
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string MM { get; set; }
        [DataMember]
        public string MO { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillPagingBpoVwDM
    {
        [DataMember]
        public int RegNo { get; set; }
        [DataMember]
        public string Forward_To { get; set; }
        [DataMember]
        public string DateApplied { get; set; }
        [DataMember]
        public string Earlier_Ref { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public string ForwardTo { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillDocumentDetailDM
    {
        [DataMember]
        public int DocumentID { get; set; }
        [DataMember]
        public int course { get; set; }
        [DataMember]
        public string Document_Name { get; set; }
        [DataMember]
        public string Doc_Code { get; set; }
        [DataMember]
        public string Doc_Purpose { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Doc_Category { get; set; }
        [DataMember]
        public string Doc_Level { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillFeeDetailDM
    {
        [DataMember]
        public int FeeHeadID { get; set; }
        [DataMember]
        public string FeeHeadName { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string breakOffTime { get; set; }
        [DataMember]
        public DateTime LastDate { get; set; }
        [DataMember]
        public int courseFeeid { get; set; }
        [DataMember]
        public string advance { get; set; }
        [DataMember]
        public int FeeDetailID { get; set; }
    }


   
    [Serializable]
    [DataContract]
    public class FillPagingBpoDM
    {
        [DataMember]
        public int RegNo { get; set; }
        [DataMember]
        public string Name { get; set; }
        //[DataMember]
        //public string Forward_To { get; set; }
        [DataMember]
        public string ForwardPerson { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string Earlier_Ref { get; set; }
        [DataMember]
        public DateTime DateApplied { get; set; }
        [DataMember]
        public string Next_Date { get; set; }
        [DataMember]
        public string Ndate { get; set; }
        [DataMember]
        public string Remark { get; set; }
    }


    [Serializable]
    [DataContract]
    public class StudentCouncDetailDM
    {
        [DataMember]
        public int CounsellingID { get; set; }
        [DataMember]
        public string ProspectusDocID { get; set; }
        [DataMember]
        public string EnquiryDocID { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public DateTime  CounsellingDate { get; set; }
        [DataMember]
        public string SessionCode { get; set; }
        [DataMember]
        public string CourseCode { get; set; }
        [DataMember]
        public string StudentNamePrefix { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ID_Student { get; set; }
        [DataMember]
        public byte[] ImagePath { get; set; }
        [DataMember]
        public string  IdentityMark { get; set; }
        [DataMember]
        public string FatherNamePrefix { get; set; }
        [DataMember]
        public string  FatherName { get; set; }
        [DataMember]
        public string ParentOccCode { get; set; }
        [DataMember]
        public string MotherNamePrefix { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string  Sex { get; set; }
        [DataMember]
        public string ReligionCode { get; set; }
        [DataMember]
        public string  NationalityCode { get; set; }
        [DataMember]
        public string  GuardianNamePrefix { get; set; }
        [DataMember]
        public string GuardianName { get; set; }
        [DataMember]
        public string  GuardianOccCode { get; set; }
        [DataMember]
        public string StudentRelation { get; set; }
        [DataMember]
        public decimal AnnualIncome { get; set; }
        [DataMember]
        public string  UniversityCode { get; set; }
        [DataMember]
        public string DocumentCode { get; set; }
        [DataMember]
        public string  LAdd1 { get; set; }
        [DataMember]
        public string  LAdd2 { get; set; }
        [DataMember]
        public string LAdd3 { get; set; }
        [DataMember]
        public int LCityCode { get; set; }
        [DataMember]
        public string LPinCode { get; set; }
        [DataMember]
        public string  LPhoneNo { get; set; }
        [DataMember]
        public string  LMobileNo { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string  PAdd1 { get; set; }
        [DataMember]
        public string PAdd2 { get; set; }
        [DataMember]
        public string PAdd3 { get; set; }
        [DataMember]
        public int  PCityCode { get; set; }
        [DataMember]
        public string PPinCode { get; set; }
        [DataMember]
        public string PPhoneNo { get; set; }
        [DataMember]
        public string PMobileNo { get; set; }
        [DataMember]
        public string CAdd1 { get; set; }
        [DataMember]
        public string CAdd2 { get; set; }
        [DataMember]
        public string CAdd3 { get; set; }
        [DataMember]
        public int CCityCode { get; set; }
        [DataMember]
        public string CPinCode { get; set; }
        [DataMember]
        public string CPhoneNo { get; set; }
        [DataMember]
        public string CMobileNo { get; set; }
        [DataMember]
        public string ModeCode { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime  UEntDt { get; set; }
        [DataMember]
        public string RollNo { get; set; }
        [DataMember]
        public string BatchCode { get; set; }
        [DataMember]
        public string  CourseDescCode { get; set; }
        [DataMember]
        public string EnrollmentNo { get; set; }
        [DataMember]
        public string PassOutDate { get; set; }
        [DataMember]
        public string InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string MName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string  CCategory { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Last_Qualification { get; set; }
        [DataMember]
        public string Total_Per { get; set; }
        [DataMember]
        public string Entrance_Qual { get; set; }
        [DataMember]
        public string Rank_Overall { get; set; }
        [DataMember]
        public string Rank_Category { get; set; }
        [DataMember]
        public string  ForwardTo_Ap { get; set; }
        [DataMember]
        public string ForwardTo_Dp { get; set; }
        [DataMember]
        public string Ap_Status { get; set; }
        [DataMember]
        public string DP_Status { get; set; }
        [DataMember]
        public string Coun_Comment { get; set; }
        [DataMember]
        public string CollegeID { get; set; }
        [DataMember]
        public string CouncellingDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class StudentDocForAP
    {
        [DataMember]
        public int DocumentID { get; set; }
        [DataMember]
        public string Is_original { get; set; }
        [DataMember]
        public string Is_Submitted { get; set; }
        [DataMember]
        public string Document_Name { get; set; }
        [DataMember]
        public string Doc_Serial { get; set; }
        [DataMember]
        public string PassingYr { get; set; }
        [DataMember]
        public string Total_Marks { get; set; }
        [DataMember]
        public string Percentage { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string BPOID { get; set; }
        [DataMember]
        public string CouncellingID { get; set; }
        [DataMember]
        public string Flag { get; set; }

    }

    [Serializable]
    [DataContract]
    public class StudentEqualificationForAP
    {
        [DataMember]
        public string IsCalculated { get; set; }
        [DataMember]
        public string Gross_Per { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string MO { get; set; }
        [DataMember]
        public string CouncellingID { get; set; }
        [DataMember]
        public string ProfileID { get; set; }
         [DataMember]
        public string Qual_Year { get; set; }
         [DataMember]
         public int ProfId { get; set; }
         [DataMember]
         public string BPOID { get; set; }  

    }

    [Serializable]
    [DataContract]
    public class StudentCouncellingMDM
    {
        [DataMember]
        public int CounsellingID { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public DateTime CounsellingDate { get; set; }
        [DataMember]
        public string SessionCode { get; set; }
        [DataMember]
        public string CourseCode { get; set; }
        [DataMember]
        public string StudentNamePrefix { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ID_Student { get; set; }
        [DataMember]
        public byte[] ImagePath { get; set; }
        [DataMember]
        public string IdentityMark { get; set; }
        [DataMember]
        public string FatherNamePrefix { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string ParentOccCode { get; set; }
        [DataMember]
        public string MotherNamePrefix { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public DateTime  DOB { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string ReligionCode { get; set; }
        [DataMember]
        public string NationalityCode { get; set; }
        [DataMember]
        public string GuardianNamePrefix { get; set; }
        [DataMember]
        public string GuardianName { get; set; }
        [DataMember]
        public string GuardianOccCode { get; set; }
        [DataMember]
        public string StudentRelation { get; set; }
        [DataMember]
        public decimal AnnualIncome { get; set; }
        [DataMember]
        public int DocumentCode { get; set; }
        [DataMember]
        public string LAdd1 { get; set; }
        [DataMember]
        public string LAdd2 { get; set; }
        [DataMember]
        public string LAdd3 { get; set; }
        [DataMember]
        public int LCityCode { get; set; }
        [DataMember]
        public string LPinCode { get; set; }
        [DataMember]
        public string LPhoneNo { get; set; }
        [DataMember]
        public string LMobileNo { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string PAdd1 { get; set; }
        [DataMember]
        public string PAdd2 { get; set; }
        [DataMember]
        public string PAdd3 { get; set; }
        [DataMember]
        public int PCityCode { get; set; }
        [DataMember]
        public string PPinCode { get; set; }
        [DataMember]
        public string PPhoneNo { get; set; }
        [DataMember]
        public string PMobileNo { get; set; }
        [DataMember]
        public string CAdd1 { get; set; }
        [DataMember]
        public string CAdd2 { get; set; }
        [DataMember]
        public string CAdd3 { get; set; }
        [DataMember]
        public int CCityCode { get; set; }
        [DataMember]
        public string CPinCode { get; set; }
        [DataMember]
        public string CPhoneNo { get; set; }
        [DataMember]
        public string CMobileNo { get; set; }
        [DataMember]
        public string ModeCode { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDt { get; set; }
        [DataMember]
        public string RollNo { get; set; }
        [DataMember]
        public string BatchCode { get; set; }
        [DataMember]
        public string CourseDescCode { get; set; }
        [DataMember]
        public string EnrollmentNo { get; set; }
        [DataMember]
        public string PassOutDate { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string MName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string CCategory { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public string Last_Qualification { get; set; }
        [DataMember]
        public string Total_Per { get; set; }
        [DataMember]
        public string Entrance_Qual { get; set; }
        [DataMember]
        public string Rank_Overall { get; set; }
        [DataMember]
        public string Rank_Category { get; set; }
        [DataMember]
        public string ForwardTo_Ap { get; set; }
        [DataMember]
        public string ForwardTo_Dp { get; set; }
        [DataMember]
        public string Ap_Status { get; set; }
        [DataMember]
        public string DP_Status { get; set; }
        [DataMember]
        public string Coun_Comment { get; set; }
        [DataMember]
        public string CollegeID { get; set; }
        [DataMember]
        public String flag { get; set; }
        [DataMember]
        public string @StudentIDreturn { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CouncellingDetailCDM
    {
        [DataMember]
        public int CouncellingID { get; set; }
        [DataMember]
        public int SrNo { get; set; }
        [DataMember]
        public string FeeHeadCode { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public string BreakoffTime { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDt { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalAmount { get; set; }
        [DataMember]
        public decimal ReFund { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public int Inst_ID { get; set; }
        [DataMember]
        public int FeeSubID { get; set; }
        [DataMember]
        public string flag { get; set; }
        [DataMember]
        public decimal Advance { get; set; }
        [DataMember]
        public int CollegeID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CouncellingStudentDocDM
    {
        [DataMember]
        public string CounsellingID { get; set; }
        [DataMember]
        public string BPOID { get; set; }
        [DataMember]
        public string StudentID { get; set; }
        [DataMember]
        public string DocumentID { get; set; }
        [DataMember]
        public string Doc_Serial { get; set; }
        [DataMember]
        public string PassingYr { get; set; }
        [DataMember]
        public string Total_Marks { get; set; }
        [DataMember]
        public string Percentage { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string InstituteID { get; set; }
        [DataMember]
        public string Is_original { get; set; }
        [DataMember]
        public string Is_Submitted { get; set; }
        [DataMember]
        public string Councelling_Time { get; set; }
        [DataMember]
        public string Counselling_Date { get; set; }
        [DataMember]
        public string flag { get; set; }
        
    }

    [Serializable]
    [DataContract]
    public class CouncellingExamPassedDM
    {
        [DataMember]
        public string BPOID { get; set; }
        [DataMember]
        public string CouncellingID { get; set; }
        [DataMember]
        public string Exam_passed { get; set; }
        [DataMember]
        public string Subjects { get; set; }
        [DataMember]
        public string MaxMarks { get; set; }
        [DataMember]
        public string MinMarks { get; set; }
        [DataMember]
        public string Gross_Per { get; set; }
        [DataMember]
        public string Qual_year { get; set; }
        [DataMember]
        public string IsCalculated { get; set; }
       [DataMember]
        public string flag { get; set; }
       [DataMember]
       public string UEndt { get; set; }
       [DataMember]
       public string  UeTime  { get; set; }
       [DataMember]
       public string U_Name { get; set; }
    }
    [Serializable]
    [DataContract]
    public class GetCouncellingID
    {
        [DataMember]
        public Int32 CouncellingID { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillFeeDetailForFeeDepositionDM
    {
        //
        [DataMember]
        public int FeeHeadID { get; set; }
        [DataMember]
        public int CouncellingID { get; set; }
        [DataMember]
        public string FeeHeadName { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalAmount { get; set; }
        [DataMember]
        public decimal CP { get; set; }
        [DataMember]
        public string breakOffTime { get; set; }
        [DataMember]
        public DateTime LastDate { get; set; }
        [DataMember]
        public int courseFeeid { get; set; }
        [DataMember]
        public string advance { get; set; }
        [DataMember]
        public int FeeDetailID { get; set; }
    }
    [Serializable]
    [DataContract]
    public class InsertStudentCouncelling_DetailDM
    {
        
        [DataMember]
        public string  CouncellingID { get; set; }
        [DataMember]
        public int SrNo { get; set; }
        [DataMember]
        public string FeeHeadCode { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public string BreakoffTime { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime  UEntDt { get; set; }
        [DataMember]
        public decimal DueDate { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public decimal BalAmount { get; set; }
        [DataMember]
        public decimal ReFund { get; set; }
        [DataMember]
        public decimal Advance { get; set; }
    }
    [Serializable]
    [DataContract]
    public class InsertStudentCouncellingDM
    {
        [DataMember]
        public int CouncellingID { get; set; }
        [DataMember]
        public string ProspectusDocID { get; set; }
        [DataMember]
        public string EnquiryDocID { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public string CounsellingDate { get; set; }
        [DataMember]
        public string SessionCode { get; set; }
        [DataMember]
        public string CourseCode { get; set; }
        [DataMember]
        public string StudentNamePrefix { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ID_Student { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public string IdentityMark { get; set; }
        [DataMember]
        public string FatherNamePrefix { get; set; }
         [DataMember]
        public string FatherName { get; set; }
        [DataMember]
         public string ParentOccCode { get; set; }
        [DataMember]
        public string MotherNamePrefix { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string ReligionCode { get; set; }
        [DataMember]
        public string NationalityCode { get; set; }
        [DataMember]
        public string GuardianNamePrefix { get; set; }
        [DataMember]
        public string GuardianName { get; set; }
        [DataMember]
        public string GuardianOccCode { get; set; }
        [DataMember]
        public string StudentRelation { get; set; }
        [DataMember]
        public string AnnualIncome { get; set; }
        [DataMember]
        public string UniversityCode { get; set; }
        [DataMember]
        public string DocumentCode { get; set; }
        [DataMember]
        public string LAdd1 { get; set; }
        [DataMember]
        public string LAdd2 { get; set; }
        [DataMember]
        public string LAdd3 { get; set; }
        [DataMember]
        public int LCityCode { get; set; }
        [DataMember]
        public string LPinCode { get; set; }
        [DataMember]
        public string LPhoneNo { get; set; }
        [DataMember]
        public string LMobileNo { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string PAdd1 { get; set; }
        [DataMember]
        public string PAdd2 { get; set; }
        [DataMember]
        public string PAdd3 { get; set; }
        [DataMember]
        public string PCityCode { get; set; }
        [DataMember]
        public string PPinCodee { get; set; }
        [DataMember]
        public string PPhoneNo { get; set; }
        [DataMember]
        public string PMobileNo { get; set; }
        [DataMember]
        public string CAdd1 { get; set; }
        [DataMember]
        public string CAdd2 { get; set; }
        [DataMember]
        public string CAdd3 { get; set; }
        [DataMember]
        public int CCityCode { get; set; }
         [DataMember]
        public string CPinCode { get; set; }
        [DataMember]
         public string CPhoneNo { get; set; }
        [DataMember]
        public string CMobileNo { get; set; }
        [DataMember]
        public string ModeCode { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public string UEntDt { get; set; }
        [DataMember]
        public string RollNo { get; set; }
        [DataMember]
        public string BatchCode { get; set; }
        [DataMember]
        public string CourseDescCode { get; set; }
        [DataMember]
        public string EnrollmentNo { get; set; }
        [DataMember]
        public string PassOutDate { get; set; }
        [DataMember]
        public string InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string MName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string CCategory { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Last_Qualification { get; set; }
        [DataMember]
        public string Total_Per { get; set; }
        [DataMember]
        public string Entrance_Qual { get; set; }
        [DataMember]
        public string Rank_Overall { get; set; }
        [DataMember]
        public string Rank_Category { get; set; }
        [DataMember]
        public string ForwardTo_Ap { get; set; }
        [DataMember]
        public decimal ForwardTo_Dp { get; set; }
        [DataMember]
        public string Ap_Status { get; set; }
        [DataMember]
        public string DP_Status { get; set; }
        [DataMember]
        public string Coun_Comment { get; set; }
        [DataMember]
        public string CollegeID { get; set; }
       
        
    
    }
    [Serializable]
    [DataContract]
    public class FillBpoDetailPGrdDM
    {
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public int PID { get; set; }
        [DataMember]
        public string PayM { get; set; }
        [DataMember]
        public decimal Amt { get; set; }
        [DataMember]
        public int DDNO { get; set; }
        [DataMember]
        public DateTime DateP { get; set; }
    }


    [Serializable]
    [DataContract]
    public class FillBpoPrintGrdDM
    {
        [DataMember]
        public int RCNO { get; set; }
        [DataMember]
        public string Prno { get; set; }
    }


    [Serializable]
    [DataContract]
    public class FillStudentIdDM
    {
        [DataMember]
        public int CounsellingID { get; set; }
        [DataMember]
        public string ID_Student { get; set; }
    }


    [Serializable]
    [DataContract]
    public class FeeTransDetailBpoDM
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
        //[DataMember]
        //public int Sid { get; set; }
        //[DataMember]
        //public int Year { get; set; }
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
    public class FeePayDetailBpoDM
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
        //[DataMember]
        //public int Sid { get; set; }
        //[DataMember]
        //public int Year { get; set; }
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
    public class FillPayModeDM
    {
        [DataMember]
        public int PMID { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
    }
    [Serializable]
    [DataContract]
    public class BPORegistrationDM
    {
        [DataMember]
        public int User_ID { get; set; }
        [DataMember]
        public string Email_ID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime Reg_Date { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]
        public string saltVC { get; set; }
        [DataMember]
        public string IsVerified { get; set; }
        [DataMember]
        public string Verification_Code { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string CityID { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Pincode { get; set; }
        [DataMember]
        public string Last_Exam { get; set; }
        [DataMember]
        public string Passing_Year { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string Security_Code { get; set; }
        [DataMember]
        public string Passoriginal { get; set; }
    }
    [Serializable]
    [DataContract]
    public class StudentADProcessingDM
    {
        [DataMember]
        public string AD_ID { get; set; }
        [DataMember]
        public string BPOID { get; set; }
        [DataMember]
        public string CounID { get; set; }
        [DataMember]
        public string Processing_Date { get; set; }
        [DataMember]
        public string Processing_Time { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public string ForwardBY { get; set; }
        [DataMember]
        public string ForwardTo { get; set; }
        [DataMember]       
        public string SessionID { get; set; }
        [DataMember]
        public string InstID { get; set; }
        [DataMember]
        public string UserID { get; set; }
        //[DataMember]
        //public string AP_Status { get; set; }
        [DataMember]
        public string DP_Status { get; set; }
        [DataMember]
        public string flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class VerifyChatUserDM
    {
        [DataMember]
        public string Email_ID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string VerificationCode { get; set; }
        [DataMember]
        public string IsVerified { get; set; }
        [DataMember]
        public string IsAuthenticated { get; set; }
        [DataMember]
        public string saltvc { get; set; }
    }
    [Serializable]
    [DataContract]
    public class StudentDDProcessingDM
    {
        [DataMember]
        public string DD_ID { get; set; }
        [DataMember]
        public string BPOID { get; set; }
        [DataMember]
        public string CounID { get; set; }
        [DataMember]
        public string Processing_Date { get; set; }
        [DataMember]
        public string Processing_Time { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public string ForwardBY { get; set; }
        [DataMember]
        public string ForwardTo { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string InstID { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class ChkEpassExistDM
    {
        [DataMember]
        public string IsExists { get; set; }
    }

}