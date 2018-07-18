using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for FacultyDM
/// </summary>
public class FacultyDM
{
    [Serializable]
    [DataContract]
    public class FacultySubject
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Instt_ID { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int FacultyID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class FillFacultySubject
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Instt_ID { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int FacultyID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string CourseName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class FacultySchdule
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Instt_ID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public int FacultyID { get; set; }
        [DataMember]
        public int DayID { get; set; }
        [DataMember]
        public string TimeFrom { get; set; }
        [DataMember]
        public string TimeTo { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FacultyAttendence
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public int FacultyID { get; set; }
        [DataMember]
        public int DayID { get; set; }
        [DataMember]
        public DateTime AttDate { get; set; }
        [DataMember]
        public string TimeFrom { get; set; }
        [DataMember]
        public string TimeTo { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillFacultyDatewiseAttDM
    {
        [DataMember]
        public int FacultyID { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public Boolean  Status { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }
}
