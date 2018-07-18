using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for PortalDM
/// </summary>
/// 

    public class PortalDM
    {
        [Serializable]
        [DataContract]
        public class QualificationDetailDM
        {
            [DataMember]
            public string ProfName { get; set; }
            [DataMember]
            public int Passing_Year { get; set; }
            [DataMember]
            public string Board { get; set; }
            [DataMember]
            public string Division { get; set; }
            [DataMember]
            public string  Percentage { get; set; }
           
        }
        [Serializable]
        [DataContract]
        public class StudentDocDetailDM
        {
            [DataMember]
            public string Document_Name { get; set; }
            [DataMember]
            public int Passing_Year { get; set; }
            [DataMember]
            public bool  Is_Original { get; set; }
            [DataMember]
            public bool Is_Submitted { get; set; }
            [DataMember]
            public string Issued_By { get; set; }
            [DataMember]
            public string Verified_By { get; set; }
            [DataMember]
            public string DocSerial { get; set; }

        }
        [Serializable]
        [DataContract]
        public class FillSemester
        {
            [DataMember]
            public string CourseYear  { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public int SID { get; set; }
            [DataMember]
            public int CourseId { get; set; }
            [DataMember]
            public string Type { get; set; }
            [DataMember]
            public string Status { get; set; }
        }
        [Serializable]
        [DataContract]
        public class FillfeeStucture
        {
            [DataMember]
            public string FeeheadName { get; set; }
            [DataMember]
            public string BreakoffTime { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public decimal TotalFeeAmount { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FillfeePaid
        {
            [DataMember]
            public string FeeheadName { get; set; }
            [DataMember]
            public string BreakoffTime { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public decimal PaidAmount { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FillfeeBal
        {
            [DataMember]
            public string FeeheadName { get; set; }
            [DataMember]
            public string BreakoffTime { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public decimal BalAmount { get; set; }
        }

        [Serializable]
        [DataContract]
        public class YearSemDM
        {
            [DataMember]
            public string Yr { get; set; }
            [DataMember]
            public int SID { get; set; }
        }


        //[Serializable]
        //[DataContract]
        //public class StudentDocDetailDM
        //{
        //    [DataMember]
        //    public string Document_Name { get; set; }
        //    [DataMember]
        //    public int Passing_Year { get; set; }
        //    [DataMember]
        //    public bool Is_Original { get; set; }
        //    [DataMember]
        //    public bool Is_Submitted { get; set; }
        //    [DataMember]
        //    public string Issued_By { get; set; }
        //    [DataMember]
        //    public string Verified_By { get; set; }
        //    [DataMember]
        //    public string DocSerial { get; set; }

        //}


        [Serializable]
        [DataContract]
        public class StudentDetailDM
        {
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public string MName { get; set; }
            [DataMember]
            public string LName { get; set; }
            [DataMember]
            public string FatherNamePrefix { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string MotherNamePrefix { get; set; }
            [DataMember]
            public string MotherName { get; set; }
            [DataMember]
            public string GuardianNamePrefix { get; set; }
            [DataMember]
            public string GuardianName { get; set; }
            [DataMember]
            public string DOB { get; set; }
            [DataMember]
            public string EMail { get; set; }
            [DataMember]
            public string LMobileNo { get; set; }
            [DataMember]
            public string CAdd1 { get; set; }
            [DataMember]
            public string CAdd2 { get; set; }
            [DataMember]
            public string CAdd3 { get; set; }
            [DataMember]
            public string PAdd1 { get; set; }
            [DataMember]
            public string PAdd2 { get; set; }
            [DataMember]
            public string PAdd3 { get; set; }
            [DataMember]
            public string LAdd1 { get; set; }
            [DataMember]
            public string LAdd2 { get; set; }
            [DataMember]
            public string LAdd3 { get; set; }
            //[DataMember]
            //public int Flag { get; set; }

        }

        [Serializable]
        [DataContract]
        public class OfficialDetailDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string RegistrationDate { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string EMail { get; set; }
            [DataMember]
            public string PMobileNo { get; set; }
            [DataMember]
            public string BatchCode { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
        }


        [Serializable]
        [DataContract]
        public class TopicListDM
        {
            [DataMember]
            public string SubjectName { get; set; }
            [DataMember]
            public string SubjectCode { get; set; }
            [DataMember]
            public string TopicName { get; set; }
            [DataMember]
            public string Subject_Type { get; set; }
            [DataMember]
            public int Hour { get; set; }
            [DataMember]
            public int PHours { get; set; }
        }

        [Serializable]
        [DataContract]
        public class SubTopicListDM
        {
            [DataMember]
            public string SubjectName { get; set; }
            [DataMember]
            public string SubjectCode { get; set; }
            [DataMember]
            public string TopicName { get; set; }
            [DataMember]
            public string SubTopicName { get; set; }
            [DataMember]
            public string Subject_Type { get; set; }
            [DataMember]
            public int Hour { get; set; }
            //[DataMember]
            //public int PHours { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FeeNatureDM
        {
            [DataMember]
            public string SName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string StudentID { get; set; }
            [DataMember]
            public int DocID { get; set; }
            [DataMember]
            public int RCNO { get; set; }
            [DataMember]
            public string Prno { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public string FeeHeadName { get; set; }
            [DataMember]
            public string Nature { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public DateTime Trans_Date { get; set; }
            [DataMember]
            public int sid { get; set; }
            [DataMember]
            public int FeeSubID { get; set; }
            [DataMember]
            public int InstId { get; set; }
        }


        [Serializable]
        [DataContract]
        public class FeePayModeDM
        {
            [DataMember]
            public int PID { get; set; }
            [DataMember]
            public string PaymentMode { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public int DDNO { get; set; }
            
        }


        [Serializable]
        [DataContract]
        public class FeePrintDM
        {
            [DataMember]
            public string SName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string StudentID { get; set; }
            [DataMember]
            public int DocID { get; set; }
            [DataMember]
            public int RCNO { get; set; }
            [DataMember]
            public string Prno { get; set; }
            [DataMember]
            public int FeeID { get; set; }
            [DataMember]
            public string FeeHeadName { get; set; }
            [DataMember]
            public string Nature { get; set; }
            [DataMember]
            public decimal Amt { get; set; }
            [DataMember]
            public DateTime Trans_Date { get; set; }
            [DataMember]
            public int sid { get; set; }
            [DataMember]
            public int FeeSubID { get; set; }
            [DataMember]
            public int InstId { get; set; }
            [DataMember]
            public int PID { get; set; }
            [DataMember]
            public string PaymentMode { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public int DDNO { get; set; }
            [DataMember]
            public string Address { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FeeStudentDM
        {
            [DataMember]
            public string SName { get; set; }
            [DataMember]
            public string FatherName { get; set; }
            [DataMember]
            public string StudentID { get; set; }
            [DataMember]
            public int DocID { get; set; }
            [DataMember]
            public int RCNO { get; set; }
            [DataMember]
            public string Prno { get; set; }
            [DataMember]
            public int InstId { get; set; }
        }

    }

