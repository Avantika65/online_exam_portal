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
namespace Academic
{

    
    [Serializable]
    [DataContract]
    public class AcademicData
    {
        [Serializable]
        [DataContract]
        public class DiscountAppliedFeeDM
        {
            [DataMember]
            public string FeeHeadName { get; set; }
            [DataMember]
            public int FeeID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class DiscountAppliedDM
        {
            [DataMember]
            public int DiscountID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public decimal AppliedAmount { get; set; }
            [DataMember]
            public DateTime AppliedDate { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class StudentReRegistration
        {
            [DataMember]
            public string CCategory { get; set; }
            [DataMember]
            public string sessionId { get; set; }
            [DataMember]
            public int courseId { get; set; }
            [DataMember]
            public int SpecializationId { get; set; }
            [DataMember]
            public int yearId { get; set; }
            [DataMember]
            public int sid { get; set; }
            [DataMember]
            public int studentId { get; set; }
            [DataMember]
            public string studentName { get; set; }
            [DataMember]
            public string ReStatus { get; set; }
            [DataMember]
            public string Ression { get; set; }

            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int Reyearid { get; set; }
            [DataMember]
            public int ReSid { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string Remarks { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public int SemesterID { get; set; }

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
            public int ExtensionNo { get; set; }
            [DataMember]
            public string ShortName { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }


        //[Serializable]
        //[DataContract]
        //public class WeekDM
        //{
        //    [DataMember]
        //    public int WeekID { get; set; }
        //    [DataMember]
        //    public int semid { get; set; }
        //    [DataMember]
        //    public int Inst_ID { get; set; }
        //}


        [Serializable]
        [DataContract]
        public class WeekDelDM
        {
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int semid { get; set; }
            [DataMember]
            public string SessionYr { get; set; }
            [DataMember]
            public int Inst_ID { get; set; }
        }

        [Serializable]
        [DataContract]
        public class CourseDelDM
        {
            [DataMember]
            public int CourseID { get; set; }  
        }
        [Serializable]
        [DataContract]
        public class CourseDM
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int CourseId { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string ShortName { get; set; }
            [DataMember]
            public string CourseNature { get; set; }
            [DataMember]
            public int CourseDuration { get; set; }
            [DataMember]
            public int SpecialisationID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public string Type { get; set; }
            [DataMember]
            public string DepartmentID { get; set; }
            [DataMember]
            public int NOS { get; set; }
            [DataMember]
            public int EXS { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string Flag { get; set; }
            [DataMember]
            public int Isgroup { get; set; }
            [DataMember]
            public int SpecilizationID { get; set; }
            [DataMember]
            public int Totalintake { get; set; }
            [DataMember]
            public string Batch { get; set; }
        }

        [Serializable]
        [DataContract]
        public class CourseChildDM
        {
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string CastCategory { get; set; }
            [DataMember]
            public int Max_Age { get; set; }
            [DataMember]
            public int Min_Age { get; set; }
            [DataMember]
            public int Min_Per { get; set; }
            [DataMember]
            public string  Flag { get; set; }
        }
        public class CourseDeptMapDM
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int DepartmentID { get; set; }
            [DataMember]
            public int Status { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int splid { get; set; }
            [DataMember]
            public string flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class WeekDM
        {
            [DataMember]
            public int WeekID { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndDate { get; set; }
            [DataMember]
            public string WeekName { get; set; }
            [DataMember]
            public string SessionYear { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public int Inst_ID { get; set; }
            [DataMember]
            public int CourseId { get; set; }
            [DataMember]
            public int semid { get; set; }
            [DataMember]
            public int YearID { get; set; }
            [DataMember]
            public int SplId { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FacultyDM
        {
            [DataMember]
            public int FacultyID { get; set; }
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
        public class StudentRegistrationDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string ProspectusDocID { get; set; }
            [DataMember]
            public string EnquiryDocID { get; set; }
            [DataMember]
            public string RegistrationNo { get; set; }
            [DataMember]
            public string RegistrationDate { get; set; }
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
            public decimal AnnualIncome { get; set; }
            [DataMember]
            public string UniversityCode { get; set; }
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
            public String flag { get; set; }
            [DataMember]
            public string @StudentIDreturn { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentRegistrationDetailDM
        {
            [DataMember]
            public int DocID { get; set; }
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
            public int SID { get; set; }
            [DataMember]
            public string YearID { get; set; }
            [DataMember]
            public string Session { get; set; }
            [DataMember]
            public int Inst_ID { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public decimal ODC_Charge { get; set; }
            [DataMember]
            public DateTime fromdate { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public int FeesubID { get; set; }
            [DataMember]
            public string CCategory { get; set; }
            [DataMember]
            public string Batch { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentStatusDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public string Session { get; set; }
            [DataMember]
            public string YearID { get; set; }
            [DataMember]
            public int SemesterID { get; set; }
            [DataMember]
            public string EnrollmentNo { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public int IsFeeDeposited { get; set; }
            [DataMember]
            public int IsFeePaid { get; set; }
            [DataMember]
            public int IsCardIssued { get; set; }
            [DataMember]
            public int IsCourseChange { get; set; }
            [DataMember]
            public string ExamRollNo { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string CCategory { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentPQuaificationDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int QualificationID { get; set; }
            [DataMember]
            public int Passing_Year { get; set; }
            [DataMember]
            public string Board { get; set; }
            [DataMember]
            public string Max_Mark { get; set; }
            [DataMember]
            public string Min_Mark { get; set; }
            [DataMember]
            public string Division { get; set; }
            [DataMember]
            public string SubjectID { get; set; }
           [DataMember]
            public string flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class StudentDocumentDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int DocumentID { get; set; }
            [DataMember]
            public int Passing_Year { get; set; }
            [DataMember]
            public string Is_Original { get; set; }
            [DataMember]
            public string Is_Submitted { get; set; }
            [DataMember]
            public string Issued_By { get; set; }
            [DataMember]
            public string Verified_By { get; set; }
            [DataMember]
            public string Remark { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string DocSerial { get; set; }
            [DataMember]
            public string Percentage { get; set; }
            [DataMember]
            public string Doc_Category { get; set; }
            [DataMember]
            public string Document_Name { get; set; }
            [DataMember]
            public string Doc_Serial { get; set; }
            [DataMember]
            public int PassingYr { get; set; }
        }

        [Serializable]
        [DataContract]
        public class SessionDateDM
        {
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndDate { get; set; }
        }
        [Serializable]
        [DataContract]
        public class GetMinimumAge
        {
            [DataMember]
            public int min_age { get; set; }
            [DataMember]
            public int Max_Age { get; set; }
            [DataMember]
            public int Min_Per { get; set; }
        }
        public class GetCity
        {
            [DataMember]
            public int CityID { get; set; }
            [DataMember]
            public string StateName { get; set; }
            [DataMember]
            public string CountryName { get; set; }
        }

        [Serializable]
        [DataContract]
        public class WeekGrd
        {
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string CourseYear { get; set; }
            [DataMember]
            public int CourseId { get; set; }
            [DataMember]
            public DateTime SStartDate { get; set; }
            [DataMember]
            public DateTime SEndDate { get; set; }
            [DataMember]
            public int semid { get; set; }
            [DataMember]
            public string SessionYear { get; set; }
            [DataMember]
            public int WeekID { get; set; }
            [DataMember]
            public string WeekName { get; set; }
            [DataMember]
            public DateTime WStartDate { get; set; }
            [DataMember]
            public DateTime WEndDate { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public string Shortname { get; set; }
            [DataMember]
            public int SplId { get; set; }
        }

        [Serializable]
        [DataContract]
        public class WeekUpdateDM
        {
            [DataMember]
            public int WeekID { get; set; }
            [DataMember]
            public string Active { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentP
        {
            [DataMember]
            public string SName { get; set; }
            [DataMember]
            public int StudentID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentPInsert
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public string SessionC { get; set; }
            [DataMember]
            public string SessionFrom { get; set; }
            [DataMember]
            public int YearFrom { get; set; }
            [DataMember]
            public int SemFrom { get; set; }
            [DataMember]
            public string SessionTo { get; set; }
            [DataMember]
            public int YearTo { get; set; }
            [DataMember]
            public int SemTo { get; set; }
            [DataMember]
            public string StatusU { get; set; }
            [DataMember]
            public string StatusI { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string CCategory { get; set; }
            [DataMember]
            public int GroupFrom { get; set; }
            [DataMember]
            public int GroupTo { get; set; }
            [DataMember]
            public string  UserEntryID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentPGrd
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string SName { get; set; }
            [DataMember]
            public string SessionFrom { get; set; }
            [DataMember]
            public string YrSemFrom { get; set; }
            [DataMember]
            public string SessionTo { get; set; }
            [DataMember]
            public string YrSemTo { get; set; }
        }
        [Serializable]
        [DataContract]
        public class AddressLabelPrintDM
        {
             [DataMember]
            public string Caddress { get; set; }
            [DataMember]
            public string CCity { get; set; }
            [DataMember]
            public string CState { get; set; }
            [DataMember]
            public string CCountry { get; set; }
            [DataMember]
            public string CPincode { get; set; }
            [DataMember]
            public string Fname { get; set; }
        }
        [Serializable]
        [DataContract]
        public class CharacterCertificateDM
        {
            [DataMember]
            public string Sname { get; set; }
            [DataMember]
            public string Fname { get; set; }
            [DataMember]
            public string DOB { get; set; }

        }


        [Serializable]
        [DataContract]
        public class StudentPromotionGrd
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
            [DataMember]
            public string FatherName { get; set; }
        }



        //[Serializable]
        //[DataContract]
        //public class StudentPromotionList
        //{
        //    [DataMember]
        //    public string SName { get; set; }
        //    [DataMember]
        //    public int StudentID { get; set; }
        //}


        [Serializable]
        [DataContract]
        public class StudentPromotionList
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }

        }


        [Serializable]
        [DataContract]
        public class StudentPromotionRegDetailDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public decimal TotalAmount { get; set; }
            [DataMember]
            public decimal PaidAmount { get; set; }
            [DataMember]
            public decimal BalanceAmount { get; set; }
            [DataMember]
            public int ReFund { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SemFrom { get; set; }
            [DataMember]
            public int SemTo { get; set; }
            [DataMember]
            public string SessionFrom { get; set; }
            [DataMember]
            public string SessionTo { get; set; }
            [DataMember]
            public string StatusU { get; set; }
            [DataMember]
            public string StatusI { get; set; }
            [DataMember]
            public int ODC { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime FromDate { get; set; }
            [DataMember]
            public int FeeSubID { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public decimal Discount { get; set; }
            [DataMember]
            public int YearTo { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public DateTime DueDate { get; set; }
            [DataMember]
            public int VNo { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }

        }
      
        public AcademicData()
        {
        }

        //[Serializable]
        //[DataContract]
        //public class StudentRegDetailDM
        //{
        //    [DataMember]
        //    public int StudentID { get; set; }
        //    [DataMember]
        //    public string StudentName { get; set; }
        //    [DataMember]
        //    public string FatherName { get; set; }
        //    [DataMember]
        //    public DateTime DateOfBirth { get; set; }
        //    [DataMember]
        //    public string ContactNo { get; set; }
        //    [DataMember]
        //    public string Category { get; set; }
        //    [DataMember]
        //    public string AdmissionSource { get; set; }
        //    [DataMember]
        //    public string AdmissionType { get; set; }
        //    [DataMember]
        //    public string HostelFacilityReq { get; set; }
        //    [DataMember]
        //    public string BusFacilityReq { get; set; }
        //    [DataMember]
        //    public string RegNo { get; set; }
        //    [DataMember]
        //    public string Diploma { get; set; }
        //    [DataMember]
        //    public int CourseID { get; set; }
        //    [DataMember]
        //    public string SessionID { get; set; }
        //    [DataMember]
        //    public int Sid { get; set; }
        //}


        [Serializable]
        [DataContract]
        public class GrdFeeDM
        {
            [DataMember]
            public int FeeDetailID { get; set; }
            [DataMember]
            public int courseFeeId { get; set; }
            [DataMember]
            public string FeeHeadCode { get; set; }
            [DataMember]
            public string FeeHeadName { get; set; }
            [DataMember]
            public decimal TotalAmount { get; set; }
            [DataMember]
            public string BreakoffTime { get; set; }
            [DataMember]
            public DateTime LastDate { get; set; }
            [DataMember]
            public string FeeClass { get; set; }
        }


        [Serializable]
        [DataContract]
        public class CheckIsAuto
        {
            //[DataMember]
            //public int IsPPSNOAuto { get; set; }
            [DataMember]
            public int IsRCNOAuto { get; set; }

        }

        [Serializable]
        [DataContract]
        public class StudentRegDetailTDM
        {
            [DataMember]
            public int StudentDetailID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public decimal TotalAmount { get; set; }
            [DataMember]
            public decimal PaidAmount { get; set; }
            [DataMember]
            public decimal BalanceAmount { get; set; }
            [DataMember]
            public int Refund { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public int ODC { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int FeeSubID { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int YearID { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public int VNo { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string DebitCredit { get; set; }
            [DataMember]
            public int Month { get; set; }
            [DataMember]
            public string Narration { get; set; }
        }


        [Serializable]
        [DataContract]
        public class FeePaymentTransDM
        {
            [DataMember]
            public int FeeTransID { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public int RCNO { get; set; }
            [DataMember]
            public string PrNo { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public decimal TotalAmount { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int sid { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime DueDate { get; set; }
            //[DataMember]
            //public DateTime EntryDate { get; set; }
            [DataMember]
            public int FeeSubID { get; set; }
            [DataMember]
            public DateTime TransDate { get; set; }
            [DataMember]
            public string TransactionState { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public DateTime UEntDate { get; set; }
            [DataMember]
            public int VNo { get; set; }
            [DataMember]
            public decimal TAmt { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public int AccountNoID { get; set; }
            [DataMember]
            public string Narration { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FeePaymentDetailDM
        {
            [DataMember]
            public int FeePayID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int PID { get; set; }
            [DataMember]
            public decimal PAmount { get; set; }
            [DataMember]
            public int DDNO { get; set; }
            [DataMember]
            public DateTime DateP { get; set; }
            [DataMember]
            public int BankID { get; set; }
            [DataMember]
            public int FeeSubID { get; set; }
            [DataMember]
            public int RCNO { get; set; }
            [DataMember]
            public string PrNo { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string TransactionState { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public DateTime UEntDate { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public int LastUsed { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public int AccountNoID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class AdvDepositeFee
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int AdvRcno { get; set; }
            [DataMember]
            public decimal DeductedAmt { get; set; }
            [DataMember]
            public string Paymode { get; set; }
            [DataMember]
            public DateTime TransDate { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public decimal BalanceAmt { get; set; }
            [DataMember]
            public int IsPaid { get; set; }
            [DataMember]
            public int StudentId { get; set; }

        }

        [Serializable]
        [DataContract]
        public class StudentNameRNo
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RollNo { get; set; }
        }



        [Serializable]
        [DataContract]
        public class StudentRollNoDM
        {
            [DataMember]
            public int RNID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public int MaxCount { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
            [DataMember]
            public string Flag { get; set; }
            [DataMember]
            public string U_Name { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }

            [DataMember]
            public int PrvRNID { get; set; }
            [DataMember]
            public string PrvSessionID { get; set; }
            [DataMember]
            public int PrvSid { get; set; }
            [DataMember]
            public string PrvRollNo { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentRegDetailDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public DateTime DateOfBirth { get; set; }
            [DataMember]
            public string ContactNo { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string AdmissionSource { get; set; }
            [DataMember]
            public string AdmissionType { get; set; }
            [DataMember]
            public string HostelFacilityReq { get; set; }
            [DataMember]
            public string BusFacilityReq { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string Diploma { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public DateTime RegDate { get; set; }
            [DataMember]
            public DateTime VerifyDate { get; set; }
            [DataMember]
            public string Specialization { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentNamePswdDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public int RNID { get; set; }
            [DataMember]
            public string SPassword { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentPasswordDM
        {
            [DataMember]
            public int PwdID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public string SPassword { get; set; }
            [DataMember]
            public string PStatus { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentVerifyDetailDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public DateTime DateOfBirth { get; set; }
            [DataMember]
            public string ContactNo { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string AdmissionSource { get; set; }
            [DataMember]
            public string AdmissionType { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public DateTime RegDate { get; set; }
            [DataMember]
            public string Specialization { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string YrSem { get; set; }
            [DataMember]
            public string ACTN_No { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int Courseid { get; set; }
            [DataMember]
            public string Batch { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentVerifyInsertDM
        {
            [DataMember]
            public int SDocID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public string AllotmentLetter { get; set; }
            [DataMember]
            public string PhotoAdmitCard { get; set; }
            [DataMember]
            public string SignatureAdmitCard { get; set; }
            [DataMember]
            public string ProofUPResident { get; set; }
            [DataMember]
            public string ProofCategory { get; set; }
            [DataMember]
            public string AcademicGap { get; set; }
            [DataMember]
            public string CertificateMedicalFitness { get; set; }
            [DataMember]
            public string ProofCounsellingFee { get; set; }
            [DataMember]
            public string ProofAdmissionFee { get; set; }
            [DataMember]
            public string MigrationForm { get; set; }
            [DataMember]
            public string SubCategory { get; set; }
            [DataMember]
            public string Eligibility { get; set; }
            [DataMember]
            public string HSProof { get; set; }
            [DataMember]
            public decimal HSPercentage { get; set; }
            [DataMember]
            public string INTProof { get; set; }
            [DataMember]
            public decimal INTPercentage { get; set; }
            [DataMember]
            public string DipProof { get; set; }
            [DataMember]
            public decimal DipPercentage { get; set; }
            [DataMember]
            public string GradProof { get; set; }
            [DataMember]
            public decimal GradPercentage { get; set; }
            [DataMember]
            public string MCAMathsProof { get; set; }
            [DataMember]
            public decimal MathsObtained { get; set; }
            [DataMember]
            public decimal PhysicsObtained { get; set; }
            [DataMember]
            public decimal ChemistryObtained { get; set; }
            [DataMember]
            public decimal EnglishObtained { get; set; }
            [DataMember]
            public decimal AggregatePCM { get; set; }
            [DataMember]
            public string AffidavitStudent { get; set; }
            [DataMember]
            public string AffidavitParent { get; set; }
            [DataMember]
            public string CharacterCeritificate { get; set; }
            [DataMember]
            public string ProofSubCategory { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentDetailCityDM
        {
            [DataMember]
            public string statename { get; set; }
            [DataMember]
            public string countryname { get; set; }
            [DataMember]
            public int stateid { get; set; }
            [DataMember]
            public int countryid { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentDetailEntryDM
        {
            [DataMember]
            public int StDetailID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Nationality { get; set; }
            [DataMember]
            public string BloodGroup { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string AlternateEmail { get; set; }
            [DataMember]
            public byte[] Photo { get; set; }
            [DataMember]
            public string CAddress { get; set; }
            [DataMember]
            public int CCityID { get; set; }
            [DataMember]
            public int CStateID { get; set; }
            [DataMember]
            public int CCountryID { get; set; }
            [DataMember]
            public int CZipCode { get; set; }
            [DataMember]
            public string PAddress { get; set; }
            [DataMember]
            public int PCityID { get; set; }
            [DataMember]
            public int PStateID { get; set; }
            [DataMember]
            public int PCountryID { get; set; }
            [DataMember]
            public int PZipCode { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]
            public string FatherContactNo { get; set; }
            [DataMember]
            public string LandlineNo { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
            [DataMember]
            public string Contact { get; set; }

            [DataMember]
            public string AlternateContact { get; set; }

            [DataMember]
            public string Specialization { get; set; }
            [DataMember]
            public DateTime DateOfBirth { get; set; }
            [DataMember]
            public string AdmissionSource { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string Hostel { get; set; }
            [DataMember]
            public string Bus { get; set; }
            [DataMember]
            public DateTime RegDate { get; set; }
            [DataMember]
            public DateTime PassOutDate { get; set; }
            [DataMember]
            public byte[] Signature { get; set; }
            [DataMember]
            public decimal EntranceScore { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentAcademicDetailDM
        {
            [DataMember]
            public int StuADetailID { get; set; }
            [DataMember]
            public int StuDetailID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int QualificationID { get; set; }
            [DataMember]
            public string QualificationDesc { get; set; }
            [DataMember]
            public string SchoolCollege { get; set; }
            [DataMember]
            public string FromYear { get; set; }
            [DataMember]
            public string ToYear { get; set; }
            [DataMember]
            public int Gap { get; set; }
            [DataMember]
            public decimal RankPercentage { get; set; }
            [DataMember]
            public string division { get; set; }
            [DataMember]
            public decimal TotalMarks { get; set; }
            [DataMember]
            public decimal MarksObtained { get; set; }
            [DataMember]
            public string Specialization { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string mode_of_marks { get; set; }            
            [DataMember]
            public string Mode { get; set; }
            [DataMember]
            public string Division { get; set; }
            [DataMember]
            public string Flag { get; set; }
            //[DataMember]
            //public string Flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentLanguageDM
        {
            [DataMember]
            public int LanguageID { get; set; }
            [DataMember]
            public int StuDetailID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Language { get; set; }
            [DataMember]
            public string LOptions { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentFamilyDetailDM
        {
            [DataMember]
            public int StuFDetailID { get; set; }
            [DataMember]
            public int StuDetailID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]

            public int FAge { get; set; }
            [DataMember]

            public string FatherOccupation { get; set; }
            [DataMember]
            public string FatherDesignation { get; set; }
            [DataMember]
            public string FatherDepartment { get; set; }
            [DataMember]
            public decimal FatherIncome { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]

            public int MAge { get; set; }
            [DataMember]

            public string MotherOccupation { get; set; }
            [DataMember]
            public string MotherDesignation { get; set; }
            [DataMember]
            public string MotherDepartment { get; set; }
            [DataMember]
            public decimal MotherIncome { get; set; }
            [DataMember]
            public string GuardianName { get; set; }
            [DataMember]

            public int GAge { get; set; }
            [DataMember]

            public string GuardianOccupation { get; set; }
            [DataMember]
            public string GuardianDesignation { get; set; }
            [DataMember]
            public string GuardianDepartment { get; set; }
            [DataMember]
            public decimal GuardianIncome { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class GrdDiscountDM
        {
            [DataMember]
            public int FeeDetailID { get; set; }
            [DataMember]
            public int courseId { get; set; }
            [DataMember]
            public string FeeHeadCode { get; set; }
            [DataMember]
            public string FeeHeadName { get; set; }
            [DataMember]
            public decimal TotalAmount { get; set; }
            [DataMember]
            public decimal BalanceAmount { get; set; }
            [DataMember]
            public string BreakoffTime { get; set; }
            [DataMember]
            public DateTime LastDate { get; set; }
            [DataMember]
            public string Approved { get; set; }
            [DataMember]
            public string DiscountAmt { get; set; }
            [DataMember]
            public string YearsNo { get; set; }
            [DataMember]
            public decimal Discount { get; set; }
            [DataMember]
            public decimal TAmt { get; set; }
            [DataMember]
            public int Sid { get; set; }
        }

        [Serializable]
        [DataContract]
        public class DiscountApprovalDM
        {
            [DataMember]
            public int DiscountID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public decimal DiscountAmt { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public int YearsNo { get; set; }
        }
        [Serializable]
        [DataContract]
        public class DiscountStudentListDM
        {
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string YearSem { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string AdmissionType { get; set; }
            [DataMember]
            public string ContactNo { get; set; }
            [DataMember]
            public string CategoryID { get; set; }
            [DataMember]
            public string AdmType { get; set; }
            [DataMember]
             public string Batch { get; set; }
        }
        [Serializable]
        [DataContract]
        public class FeedbackMDM
        {
            [DataMember]
            public int FeedbackID { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public int FeedbackParamID { get; set; }
            [DataMember]
            public int SubjectID { get; set; }
            [DataMember]
            public int SemID { get; set; }
            [DataMember]
            public int SubjectCat { get; set; }
            [DataMember]
            public int FacultyID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentFeedbackDM
        {
            [DataMember]
            public int SFeedbackID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public int SubjectID { get; set; }
            [DataMember]
            public int FacultyID { get; set; }
            [DataMember]
            public int FeedbackID { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public int FeedbackParamID { get; set; }
            [DataMember]
            public int FeedbackGradeID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string Remarks { get; set; }
            [DataMember]
            public int Semid { get; set; }
            [DataMember]
            public int Batchid { get; set; }
            [DataMember]
            public int Updatecount { get; set; }
            [DataMember]
            public string flag { get; set; }


        }

        [Serializable]
        [DataContract]
        public class OutsourceFeePaymentDM
        {
            [DataMember]
            public int OrgFeePayID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int Pid { get; set; }
            [DataMember]
            public string Organization { get; set; }
            [DataMember]
            public decimal PaidAmt { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public int DNo { get; set; }
            [DataMember]
            public DateTime DDate { get; set; }
            [DataMember]
            public int BankID { get; set; }
            [DataMember]
            public decimal OTotalAmt { get; set; }
            [DataMember]
            public decimal OPaidAmt { get; set; }
            [DataMember]
            public decimal OBalAmt { get; set; }
            [DataMember]
            public string AccountNo { get; set; }
            [DataMember]
            public string Narration { get; set; }
            [DataMember]
            public int FeeID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class OutsourceFeePayGrdDM
        {
            [DataMember]
            public int OrgFeePayID { get; set; }
            [DataMember]
            public string PaymentMode { get; set; }
            [DataMember]
            public string Organization { get; set; }
            [DataMember]
            public decimal PaidAmt { get; set; }
        }

        [Serializable]
        [DataContract]
        public class OutsourceFeeAmountDM
        {
            [DataMember]
            public int OrgFeePayID { get; set; }
            [DataMember]
            public decimal OBalamt { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentOutsourceGrdDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string CCategory { get; set; }
            [DataMember]
            public string RegNo { get; set; }
        }

        [Serializable]
        [DataContract]
        public class OutsourceFeeDistributionDM
        {
            [DataMember]
            public int OrgFeeDisID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public int OrgFeePayID { get; set; }
            [DataMember]
            public string Organization { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string SCategory { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public decimal DisAmt { get; set; }
            [DataMember]
            public decimal DisAmtPaid { get; set; }
            [DataMember]
            public decimal DisAmtBalance { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public int VNo { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public string PrNo { get; set; }
            [DataMember]
            public int Rcno { get; set; }
            [DataMember]
            public string Narration { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public string LastUsed { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class CastCategoryDM
        {
            [DataMember]
            public int CCategoryID { get; set; }
            [DataMember]
            public string CCategory { get; set; }
            [DataMember]
            public string CActive { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class AdmissionSourceDM
        {
            [DataMember]
            public int AdmSourceID { get; set; }
            [DataMember]
            public string AdmSource { get; set; }
            [DataMember]
            public string ASActive { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class AdmissionTypeDM
        {
            [DataMember]
            public int AdmTypeID { get; set; }
            [DataMember]
            public string AdmType { get; set; }
            [DataMember]
            public string ATActive { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentAdvacnceDM
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public decimal TotalAmt { get; set; }
            [DataMember]
            public decimal PaidAmt { get; set; }
            [DataMember]
            public decimal BalAmt { get; set; }
            [DataMember]
            public int IsPaid { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string Session { get; set; }
            [DataMember]
            public string PrnoID { get; set; }
            [DataMember]
            public int RcnoID { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public string Narration { get; set; }
            [DataMember]
            public int AccountNoID { get; set; }
            [DataMember]
            public int DDNO { get; set; }
            [DataMember]
            public DateTime DueDate { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class FeedbackMGrdDM
        {
            [DataMember]
            public int FeedbackID { get; set; }
            [DataMember]
            public string FeedbackType { get; set; }
            [DataMember]
            public string FeedbackParameter { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public int FeedbackParamID { get; set; }
        }
        [Serializable]
        [DataContract]
        public class FeedbackTypeMDM
        {
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public string FeedbackType { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class FeedbackGradeMDM
        {
            [DataMember]
            public int FeedbackGradeID { get; set; }
            [DataMember]
            public string FeedbackGrade { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string Weightage { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }
        [Serializable]
        [DataContract]
        public class FeedbackParameterMDM
        {
            [DataMember]
            public int FeedbackParamID { get; set; }
            [DataMember]
            public string FeedbackParameter { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class FeedbackScheduleDM
        {
            [DataMember]
            public int FeedbackScheduleID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public DateTime FromDate { get; set; }
            [DataMember]
            public DateTime ToDate { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public int Semid { get; set; }
            [DataMember]
            public int Batchid { get; set; }
            [DataMember]
            public int Courseid { get; set; }
            [DataMember]
            public int Subjectid { get; set; }
            [DataMember]
            public string SubjectName { get; set; }
            [DataMember]
            public string Flag { get; set; }
            [DataMember]
            public string FeedbackType { get; set; }
            [DataMember]
            public string Batch_Name { get; set; }
        }


        [Serializable]
        [DataContract]
        public class FeedbackScheduleGrdDM
        {
            [DataMember]
            public int FeedbackScheduleID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public DateTime FromDate { get; set; }
            [DataMember]
            public DateTime ToDate { get; set; }
            [DataMember]
            public string FeedbackType { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FeedbackMGrdDetailDM
        {
            //[DataMember]
            //public int FeedbackID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
        }
        [Serializable]
        [DataContract]
        public class StudentRegStatusDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int YearID { get; set; }
            [DataMember]
            public int SemesterID { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string CCategory { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string Flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class StudentFeedbackGrdDM
        {
            [DataMember]
            public int FeedbackID { get; set; }
            [DataMember]
            public int FeedbackTypeID { get; set; }
            [DataMember]
            public int FeedbackParamID { get; set; }
            [DataMember]
            public string FeedbackParameter { get; set; }
            [DataMember]
            public int SFeedbackID { get; set; }
            [DataMember]
            public int FeedbackGradeID { get; set; }
        }

        [Serializable]
        [DataContract]
        public class ExamStatusMDM
        {
            [DataMember]
            public int ExamStatusID { get; set; }
            [DataMember]
            public string ExamStatus { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class ExternalExamDetailDM
        {
            [DataMember]
            public int eseresultId { get; set; }
            [DataMember]
            public string sessionId { get; set; }
            [DataMember]
            public int courseId { get; set; }
            [DataMember]
            public int SpecializationId { get; set; }
            [DataMember]
            public int yearId { get; set; }
            [DataMember]
            public int sid { get; set; }
            [DataMember]
            public int studentId { get; set; }
            [DataMember]
            public string studentName { get; set; }
            [DataMember]
            public string status { get; set; }
            [DataMember]
            public int marksObtained { get; set; }
            [DataMember]
            public decimal percentage { get; set; }
            [DataMember]
            public int InstituteID { get; set; }

            [DataMember]
            public string Remarks { get; set; }
            [DataMember]
            public string Batch { get; set; }
        }

        [Serializable]
        [DataContract]
        public class BackPaperDetailDM
        {
            [DataMember]
            public int backpaperId { get; set; }
            [DataMember]
            public int eseresultId { get; set; }
            [DataMember]
            public int noofCP { get; set; }
            [DataMember]
            public string subjectId { get; set; }
            [DataMember]
            public string subjectCode { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class BackPaperGrdDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
            [DataMember]
            public int eseresultId { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentPromoteFeeDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string RegNo { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentUpdateDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string AdmissionSource { get; set; }
            [DataMember]
            public string AdmissionType { get; set; }
            [DataMember]
            public string HostelFacilityReq { get; set; }
            [DataMember]
            public string BusFacilityReq { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
        }
        [Serializable]
        [DataContract]
        public class StudentAcademicDetailSDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public DateTime DateOfBirth { get; set; }
            [DataMember]
            public string ContactNo { get; set; }
            [DataMember]
            public string Category { get; set; }
            [DataMember]
            public string AdmissionSource { get; set; }
            [DataMember]
            public string AdmissionType { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]
            public string Gender { get; set; }
            [DataMember]
            public DateTime RegDate { get; set; }
            [DataMember]
            public string Specialization { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string YrSem { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int Courseid { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
            [DataMember]
            public string HostelFacilityReq { get; set; }
            [DataMember]
            public string BusFacilityReq { get; set; }
            [DataMember]
            public string EntranceScore { get; set; }
            [DataMember]
            public string Batch { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentFeeUpdateDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string HostelFacilityReq { get; set; }
            [DataMember]
            public string BusFacilityReq { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
        }

        [Serializable]
        [DataContract]
        public class AccountMasterDM
        {
            [DataMember]
            public int AccountNoID { get; set; }
            [DataMember]
            public string AccountNo { get; set; }
            [DataMember]
            public int BankID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class AccountMasterGrdDM
        {
            [DataMember]
            public int AccountNoID { get; set; }
            [DataMember]
            public string AccountNo { get; set; }
            [DataMember]
            public string BankName { get; set; }
            [DataMember]
            public int BankID { get; set; }
        }

        [Serializable]
        [DataContract]
        public class StudentCourseChangeGrdDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string RegNo { get; set; }
        }


        [Serializable]
        [DataContract]
        public class StudentCourseChangeDM
        {
            [DataMember]
            public int CourseChangeID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int OldSpecializationID { get; set; }
            [DataMember]
            public int NewSpecializationID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
        }

        [Serializable]
        [DataContract]
        public class EmployeeNatureDM
        {
            [DataMember]
            public int natureID { get; set; }
            [DataMember]
            public string nature { get; set; }
        }

        [Serializable]
        [DataContract]
        public class EmpDeptDM
        {
            [DataMember]
            public int EmpDeptID { get; set; }
            [DataMember]
            public int NatureID { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public int DesignationID { get; set; }
            [DataMember]
            public int EmployeeID { get; set; }
            [DataMember]
            public int DepartmentID { get; set; }
            [DataMember]
            public string Action { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public DateTime EntryDate { get; set; }
            [DataMember]
            public string UserID { get; set; }
        }
        [Serializable]
        [DataContract]
        public class EmployeeDesignationDM
        {
            [DataMember]
            public int DesigId { get; set; }
            [DataMember]
            public string Designation { get; set; }
        }
        [Serializable]
        [DataContract]
        public class EmpDeptUpdateDM
        {
            [DataMember]
            public int EmpDeptID { get; set; }
        }

        [Serializable]
        [DataContract]
        public class VoucherDeletionGrd
        {
            [DataMember]
            public decimal TotalAmount { get; set; }
            [DataMember]
            public decimal PaidAmount { get; set; }
            [DataMember]
            public decimal BalanceAmount { get; set; }
        }


        [Serializable]
        [DataContract]
        public class DueVoucherDeleteDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class RecVoucherDeleteDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string VoucherNo { get; set; }
            [DataMember]
            public string PrNo { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public decimal PaidAmt { get; set; }
            //[DataMember]
            //public decimal BalAmt { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        
    

    }
    
}
