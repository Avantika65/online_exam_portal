using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for AttendenceDM
/// </summary>
/// 

    public class AttendenceDM
    {
        [Serializable]
        [DataContract]
        public class Period_Attendence
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int SplID { get; set; }
            [DataMember]
            public int SpecID { get; set; }
            [DataMember]
            public int YearID { get; set; }
            [DataMember]
            public int SubjectID { get; set; }
            [DataMember]
            public int TopicID { get; set; }
            [DataMember]
            public int SubTopicID { get; set; }
            [DataMember]
            public string Types { get; set; }
            [DataMember]
            public DateTime DateA { get; set; }
            [DataMember]
            public int BatchID { get; set; }
            [DataMember]
            public int Present { get; set; }
            [DataMember]
            public int Absent { get; set; }
            [DataMember]
            public int NA { get; set; }
            [DataMember]
            public Int64 StudentID { get; set; }
            [DataMember]
            public int Inst_ID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string Class1 { get; set; }
            [DataMember]
            public string periodname { get; set; }
            [DataMember]
            public int FacultyID { get; set; }
            [DataMember]
            public int VenueID { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public DateTime UEDate { get; set; }
            [DataMember]
            public string TicketNo { get; set; }
            [DataMember]
            public string Remark { get; set; }
            [DataMember]
            public int WeekID { get; set; }
            [DataMember]
            public int PeriodNo { get; set; }
            [DataMember]
            public int Period_Type { get; set; }
            [DataMember]
            public int ForwardTo { get; set; }
            [DataMember]
            public int EnterForm { get; set; }
            [DataMember]
            public int Leave { get; set; }
            [DataMember]
            public int Hday { get; set; }
            [DataMember]
            public int EgroupId { get; set; }
            [DataMember]
            public int Flag { get; set; }
            [DataMember]
            public DateTime DateEnd { get; set; }
        }
        [Serializable]
        [DataContract]
        public class BatchAssignmentDM
        {
            [DataMember]
            public int RecordID { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public int Course_ID { get; set; }
            [DataMember]
            public int YearID { get; set; }
            [DataMember]
            public int SplID { get; set; }
            [DataMember]
            public int BatchID { get; set; }
            [DataMember]
            public DateTime Assign_Date { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public string Class { get; set; }
            [DataMember]
            public string Batch_Type { get; set; }
            [DataMember]
            public string Semesterid { get; set; }
            [DataMember]
            public DateTime UEdate { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public string Flag { get; set; }

        }
        [Serializable]
        [DataContract]
        public class BatchStudentSelectDM
        {
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string URollNo { get; set; }//UniversityRollNo

        }

        [Serializable]
        [DataContract]
        public class FillBatchDM
        {
            [DataMember]
            public int Batch_ID { get; set; }
            [DataMember]
            public string Batch_name { get; set; }

        }

        [Serializable]
        [DataContract]
        public class FillBatchStudentDM
        {
            [DataMember]
            public int RecordID { get; set; }
            [DataMember]
            public string StudentName { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string Batch_Name { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string URollNo { get; set; }

        }


        [Serializable]
        [DataContract]
        public class FillWeekForAttendanceDM
        {
            [DataMember]
            public int WeekID { get; set; }
            [DataMember]
            public string WeekName { get; set; }

        }

        [Serializable]
        [DataContract]
        public class FillPeriodForAttendanceDM
        {
            [DataMember]
            public int Period { get; set; }
            [DataMember]
            public string shortname { get; set; }

        }
        [Serializable]
        [DataContract]
        public class FillBatchForAttendanceDM
        {
            [DataMember]
            public int Batch_ID { get; set; }
            [DataMember]
            public string Batch_Name { get; set; }

        }

        [Serializable]
        [DataContract]
        public class FillStudentForAttendanceDM
        {
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public bool Status { get; set; }
            [DataMember]
            public int Absent { get; set; }
            [DataMember]
            public int Present { get; set; }
            [DataMember]
            public int OnLeave { get; set; }
            [DataMember]
            public int OnHalfDay { get; set; }
            [DataMember]
            public int SplID { get; set; }
            [DataMember]
            public int BatchID { get; set; }
            [DataMember]
            public int EgroupId { get; set; }
            [DataMember]
            public string Batch_Name { get; set; }
            [DataMember]
            public string Remark { get; set; }
            [DataMember]
            public string RegNo { get; set; }
            [DataMember]
            public string UniversityRollNo { get; set; }
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int SubjectID { get; set; }

        }
        [Serializable]
        [DataContract]
        public class FillStudentAttDailyDM
        {
            [DataMember]
            public string Sname { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string RollNO { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FillFacultyToForward
        {
            [DataMember]
            public int FacultyID { get; set; }
            [DataMember]
            public string FName { get; set; }
        }
      
        [Serializable]
        [DataContract]
        public class AttTopicsubtopic
        {
            [DataMember]
            public int SubjectID { get; set; }
            [DataMember]
            public string SubjectName { get; set; }
            [DataMember]
            public int TopicID { get; set; }
            [DataMember]
            public string TopicName { get; set; }
            [DataMember]
            public int SubTopicID { get; set; }
            [DataMember]
            public string SubTopicName { get; set; }
            [DataMember]
            public int Type { get; set; }
            [DataMember]
            public string Period_Type { get; set; }

            public AttTopicsubtopic()
            {
            }
        }

        [Serializable]
        [DataContract]
        public class FillStudentForAssignmnet
        {
            public decimal Link;
            [DataMember]
            public int marksid { get; set; }
            [DataMember]
            public int StudentID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string ID_Student { get; set; }
            [DataMember]
            public string RollNo { get; set; }
            [DataMember]
            public int BatchID { get; set; }
            [DataMember]
            public string Batch_Name { get; set; }
            [DataMember]
            public int assignID { get; set; }
            [DataMember]
            public string assignName { get; set; }
            [DataMember]
            public int SubjectID { get; set; }
            [DataMember]
            public int Con_id { get; set; }
            [DataMember]
            public string Sub_date { get; set; }
            [DataMember]
            public decimal marks_obt { get; set; }


            public decimal Mode { get; set; }
        }
    }

