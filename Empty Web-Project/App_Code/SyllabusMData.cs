using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for SyllabusMData
/// </summary>

namespace SyllabusM
{
   [ServiceContract(Namespace = "SyllabusM")]
    [Serializable]
    [DataContract]
    public class SyllabusMData
    {
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int Subject_Cat_ID { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Specilizationid { get; set; }
        [DataMember]
        public string Subjectcatagory { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int TopicID { get; set; }
        [DataMember]
        public string TopicName { get; set; }
        [DataMember]
        public string SubjectCode { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public int StudyHrs { get; set; }
        [DataMember]
        public string flag { get; set; }
        [DataMember]
        public int StudyHrsP { get; set; }
        [DataMember]
        public int Semester { get; set; }
        [DataMember]
        public int type { get; set; }
        [DataMember]
        public string day { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public string Facultyid { get; set; }
        [DataMember]
        public string Entrydate { get; set; }
        [DataMember]
        public string ApprovalStatus { get; set; }
        [DataMember]
        public string ApprovedBy { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public int Batchid { get; set; }
        [DataMember]
        public int PL { get; set; }
        [DataMember]
        public int PT { get; set; }
        [DataMember]
        public int PP { get; set; }
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public string subPriorityL { get; set; }
        [DataMember]
        public string subPriorityT { get; set; }
        [DataMember]
        public string subPriorityP { get; set; }
        [DataMember]
        public int subPriorId { get; set; }
        [DataMember]
        public string ActivityDate { get; set; }
        [DataMember]
        public int SubTopicId { get; set; }
        [DataMember]
        public int EmpId { get; set; }
        [DataMember]
        public int LectureType { get; set; }
        [DataMember]
        public int maxstudent { get; set; }
        [DataMember]
        public int PeriodID { get; set; }
        [DataMember]
        public string Period_Type { get; set; }
        public SyllabusMData()
        {
        }
    }

   [Serializable]
   [DataContract]
   public class SyllabusTypeMData
   {
       [DataMember]
       public int SubjectID { get; set; }
       [DataMember]
       public int type { get; set; }
       [DataMember]
       public int Hours { get; set; }
       [DataMember]
       public int Flag { get; set; }
       public SyllabusTypeMData()
       {
       }
   }

    [DataContract]
   public class TopicData
   {
       [DataMember]
       public int TopicID { get; set; }
       [DataMember]
       public int SubjectID { get; set; }
       [DataMember]
       public string TopicName { get; set; }
       [DataMember]
       public int StudyHrs { get; set; }
       [DataMember]
       public int Type { get; set; }
       [DataMember]
       public int flag { get; set; }
       [DataMember]
       public int InstituteID { get; set; }
       [DataMember]
       public int CourseID { get; set; }
       [DataMember]
       public int SubjectTypeID { get; set; }
       [DataMember]
       public bool Status { get; set; }
       [DataMember]
       public string Unitdis { get; set; }
       [DataMember]
       public string Unitobj { get; set; }
       [DataMember]
       public int Facultyid { get; set; }
       [DataMember]
       public int Semid { get; set; }
       [DataMember]
       public string  Sessionid { get; set; }
   }


    [DataContract]
    public class SubTopicData
    {
        [DataMember]
        public int Inst_id { get; set; }
        [DataMember]
        public string Sessionid { get; set; }
        [DataMember]
        public int Courseid { get; set; }
        [DataMember]
        public int Splid { get; set; }
        [DataMember]
        public int Semid { get; set; }
        [DataMember]
        public int SubTopicID { get; set; }
        [DataMember]
        public int TopicID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubTopicName { get; set; }
        [DataMember]
        public int hour { get; set; }
        [DataMember]
        public string flag { get; set; }
        [DataMember]
        public string Active { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public int FacultyId { get; set; }
        [DataMember]
        public string EDate { get; set; }
        [DataMember]
        public string ChapterPage { get; set; }
        [DataMember]
        public string Lecturedis { get; set; }
        [DataMember]
        public string PPTOHP { get; set; }
        [DataMember]
        public int Sitevisitid { get; set; }
        [DataMember]
        public int Labdemoid { get; set; }
        [DataMember]
        public int VideoLectureid { get; set; }
        [DataMember]
        public string OtherMetho { get; set; }
        [DataMember]
        public int TextBookid { get; set; }
        [DataMember]
        public int RefBookid { get; set; }
        [DataMember]
        public int Otherrefid { get; set; }
        [DataMember]
        public string Chapterpageref { get; set; }
        [DataMember]
        public string Otherrefremark { get; set; }

        [DataMember]
        public string RangeFrom { get; set; }
        [DataMember]
        public string RangeTo { get; set; }

    }
    [DataContract]
    public class SubjectChild_Data
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string SubjectID { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public int Subject_Cat { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public int YearID { get; set; }
        [DataMember]
        public int SemesterID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string Active { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public string UEntDt { get; set; }
        [DataMember]
        public int Specilizationid { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string Batch { get; set; }
    }
    [DataContract]
    public class SubjectSetting
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Inst_ID { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public string SubjectName { get; set;}        
        [DataMember]
        public string HavingPaper { get; set; }
        [DataMember]
        public string UseMarking { get; set; }
        [DataMember]
        public string MarkingScheme { get; set; }
        [DataMember]
        public int TotalMarks { get; set; }
        [DataMember]
        public int MinMarks { get; set; }
        [DataMember]
        public int MaxEx { get; set; }
        [DataMember]
        public int MinEx { get; set; }
        [DataMember]
        public int MaxInt { get; set; }
        [DataMember]
        public int MinInt { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [DataContract]
    public class SylTypeMaster
    {
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string Subject_Type { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string flag { get; set; }

    }

    [DataContract]
    public class BatchMaster
    {
        [DataMember]
        public int Batch_ID { get; set; }
        [DataMember]
        public string Batch_Name { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string Short_Name { get; set; }
        [DataMember]
        public int Semester { get; set; }
        [DataMember]
        public int SpecilizationID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int Subject_CategoryID { get; set; }
        [DataMember]
        public string flag { get; set; }

    }

    [DataContract]
    public class SubGroupMaster
    {
        [DataMember]
        public int Sub_Group_MasterID { get; set; }
        [DataMember]
        public string Institute { get; set; }
        [DataMember]
        public string Group_Name { get; set; }
        [DataMember]
        public string Short_Name { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string flag { get; set; }

    }

    [DataContract]
    public class SubGrouping
    {
        [DataMember]
        public int Sub_GroupingID { get; set; }
        [DataMember]
        public string Institute { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string S_Group { get; set; }
        [DataMember]
        public string Subject_Name { get; set; }
        [DataMember]
        public string flag { get; set; }

    }

    [Serializable]
    [DataContract]
    public class GetSubjectType
    {
        [DataMember]
        public int SubjectTypeID { get; set; }
        public GetSubjectType()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class SubjectGroups
    {
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int IsOptional { get; set; }
        [DataMember]
        public string  SubjectName { get; set; }
        [DataMember]
        public int TotalMarks { get; set; }
        [DataMember]
        public int MinMarks { get; set; }
        [DataMember]
        public int MaxEx { get; set; }
        [DataMember]
        public int MinEx { get; set; }
        [DataMember]
        public int MaxInt { get; set; }
        [DataMember]
        public int MinInt { get; set; }
        [DataMember]
        public decimal  Weight { get; set; }
        [DataMember]
        public int countable { get; set; }
        [DataMember]
        public string Subjectcode { get; set; }
        public SubjectGroups()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class PlannerDM
    {
        [DataMember]
        public int Subjectid { get; set; }
        [DataMember]
        public string  subject { get; set; }
        [DataMember]
        public int Theory { get; set; }
        [DataMember]
        public int Practical { get; set; }
        [DataMember]
        public decimal SSHours { get; set; }
        [DataMember]
        public decimal THours { get; set; }
        [DataMember]
        public decimal SSHP { get; set; }
        [DataMember]
        public decimal HAPD { get; set; }
        [DataMember]
        public decimal DW { get; set; }
        [DataMember]
        public decimal THW { get; set; }
        [DataMember]
        public decimal THSW { get; set; }
        [DataMember]
        public decimal HTP { get; set; }
        [DataMember]
        public decimal HPP { get; set; }
        [DataMember]
        public decimal HT { get; set; }
        [DataMember]
        public decimal HP { get; set; }
        public PlannerDM()
        {
        }
    }

    [Serializable]
    [DataContract]
    public class GetSubjectDM
    {
        [DataMember]
        public string SubjectID { get; set; }
        [DataMember]
        public string  SubjectName { get; set; }
        [DataMember]
        public int SubjectType { get; set; }
        public GetSubjectDM()
        {
        }
    }
    [Serializable]
    [DataContract]
    public class GetTopicDM
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
        public string TopicType { get; set; }
        [DataMember]
        public int Hour { get; set; }
        [DataMember]
        public Boolean Status { get; set; }
        [DataMember]
        public string Unitdis { get; set; }
        [DataMember]
        public string Unitobj { get; set; }
        [DataMember]
        public int Facultyid { get; set; }
        public GetTopicDM()
        {
        }
    }
    [DataContract]
    public class SubTopicDM
    {
        [DataMember]
        public int SubTopicID { get; set; }
        [DataMember]
        public int TopicID { get; set; }
        [DataMember]
        public int  SubjectID { get; set; }
        [DataMember]
        public string SubTopicName { get; set; }
        [DataMember]
        public int hour { get; set; }
        [DataMember]
        public string TopicName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public string Period_Type { get; set; }
 
    }

    [DataContract]
    public class Coursecoordinator
    {
        [DataMember]
        public int COID { get; set; }
        [DataMember]
        public int Inst_Id { get; set; }
        [DataMember]
        public string Sessionid { get; set; }
        [DataMember]
        public int Semid { get; set; }
        [DataMember]
        public int Courseid { get; set; }
        [DataMember]
        public int Facultyid { get; set; }
        [DataMember]
        public int Batch_Id { get; set; }
        [DataMember]
        public int splid { get; set; }
        [DataMember]
        public string Batch_name { get; set; }
        [DataMember]
        public string FacultyName { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string flag { get; set; }


    }
}