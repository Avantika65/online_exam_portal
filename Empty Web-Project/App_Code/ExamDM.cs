using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for EntranceDM
/// </summary>
public class ExamDM
{
    [Serializable]
    [DataContract]
	public class ExamTypeDM
	{
        [DataMember]
        public int itesttypeId {get; set;}
		[DataMember]
        public string sessionId {get;set;}
        [DataMember]
        public int SPCl { get; set; }
        [DataMember]
        public int semID { get; set; }
        [DataMember]
        public int examCat { get; set; }
        [DataMember]
        public string testtypename {get;set;}
        [DataMember]
        public string FacultyID { get; set; }
        [DataMember]
        public int Courseid {get;set;}
        [DataMember]
        public int testduration { get; set; }
        [DataMember]
        public int weighatge { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public int nooftest  { get; set; }
        [DataMember]
        public int bestcount { get; set; }
        [DataMember]
        public string periodno { get; set; }
        [DataMember]
        public int Quessubday { get; set; }
        [DataMember]
        public int markssubday { get; set; }
        [DataMember]
        public string daynopriority { get; set; }
        [DataMember]
        public int instituteid { get; set; }
        [DataMember]
        public int userid { get; set; }
        [DataMember]
        public string entrydate { get; set; }
        [DataMember]
        public string Flag { get; set; }

	}
    [Serializable]
    [DataContract]
    public class ExamMasterDM
    {
        [DataMember]
        public int testid { get; set; }
        [DataMember]
        public int ExamCategoryid { get; set; }
        [DataMember]
        public int testtypeid { get; set; }
        [DataMember]
        public string testname { get; set; }
        [DataMember]
        public int maxmark { get; set; }
        [DataMember]
        public int Ratten { get; set; }
        [DataMember]
        public int testduration { get; set; }
        [DataMember]
        public int iscompul { get; set; }
        [DataMember]
        public int fromdate { get; set; }
        [DataMember]
        public int todate { get; set; }
        [DataMember]
        public int bestcount { get; set; }
        [DataMember]
        public int facultyID { get; set; }
        [DataMember]
        public int coursecompT { get; set; }
        [DataMember]
        public int Semid { get; set; }
        [DataMember]
        public int SpclID { get; set; }
        [DataMember]
        public string Flag { get; set; }

    }

    [Serializable]
    [DataContract]
    public class ExamScheduleDM
    {
        [DataMember]
        public int testschid { get; set; }
        [DataMember]
        public int testid { get; set; }
        [DataMember]
        public int Subjectid { get; set; }
        [DataMember]
        public string SchDate { get; set; }
        [DataMember]
        public string sessionid { get; set; }
        [DataMember]
        public string testdate { get; set; }
        [DataMember]
        public DateTime testdate1 { get; set; }
        [DataMember]
        public int semid { get; set; }
        [DataMember]
        public int courseid { get; set; }
        [DataMember]
        public int specid { get; set; }
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string remark { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TimeFrom { get; set; }
        [DataMember]
        public string TimeTo { get; set; }
        [DataMember]
        public string Unit_Name { get; set; }
        [DataMember]
        public string Unit_Id { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FillInternalMarksDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int marksId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ID_Student { get; set; }
        [DataMember]
        public int testtypeid { get; set; }
        [DataMember]
        public int Batchid { get; set; }
        [DataMember]
        public  string attendance { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string Att_Status { get; set; }
        [DataMember]        
        public string RollNo { get; set; }
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public decimal marksObtained { get; set; }
        [DataMember]
        public string Batch_Name { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string RegNo { get; set; }
        [DataMember]
        public int testid { get; set; }
        [DataMember]
        public int Subjectid { get; set; }
        [DataMember]
        public int SubCategoryID { get; set; }
        [DataMember]
        public string sessionid { get; set; }
        [DataMember]
        public int semid { get; set; }
        [DataMember]
        public int courseid { get; set; }
        [DataMember]
        public int specid { get; set; }       
        [DataMember]
        public string Flag { get; set; }
        [DataMember]
        public string UniversityRollNo { get; set; }
        [DataMember]
        public DateTime Conducteddate { get; set; }
        [DataMember]
        public DateTime EntryDate { get; set; }
        [DataMember]
        public int userid { get; set; }
        [DataMember]
        public int Facultyid { get; set; }

        //---------------------------------------------------------
        [DataMember]
        public int AttId { get; set; }
        [DataMember]
        public int Present { get; set; }
        [DataMember]
        public int Absent { get; set; }
        [DataMember]
        public int Inst_Id { get; set; }

        //---------------------------------------------------------
        [DataMember]
        public int EgroupId { get; set; }
        [DataMember]
        public int GroupName { get; set; }
        [DataMember]
        public int RecordId { get; set; }



    }
  
}
