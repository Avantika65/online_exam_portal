using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
namespace Admin
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AdministratorData
    {
        [Serializable]
        [DataContract]
        public class AppsettingDM
        {
            [DataMember]
            public int CollegeID { get; set; }
            [DataMember]
            public string CollegeName { get; set; }
            [DataMember]
            public string ShortName { get; set; }
            [DataMember]
            public string Location { get; set; }
            [DataMember]
            public string Phone1 { get; set; }
            [DataMember]
            public string Phone2 { get; set; }
            [DataMember]
            public string Phone3 { get; set; }
            [DataMember]
            public string Fax { get; set; }
            [DataMember]
            public string Mobile { get; set; }
            [DataMember]
            public string EmailID1 { get; set; }
            [DataMember]
            public string Email2 { get; set; }
            [DataMember]
            public string Website { get; set; }
            [DataMember]
            public string Description { get; set; }
            [DataMember]
            public byte[]  InstLogo { get; set; }
            [DataMember]
            public string Acd_Session { get; set; }
            [DataMember]
            public string PrincipalName { get; set; }
            [DataMember]
            public string ProxyAddress { get; set; }
            [DataMember]
            public string ProxyUser { get; set; }
            [DataMember]
            public string ProxyPwd { get; set; }
            [DataMember]
            public string Salt { get; set; }
            [DataMember]
            public string IsMailActive { get; set; }
            [DataMember]
            public string IsLog { get; set; }
 
        }

        [Serializable]
        [DataContract]
        public class EgroupDM
        {
            [DataMember]
            public string Egroupname { get; set; }
            [DataMember]
            public int EgroupID { get; set; }
            [DataMember]
            public string flag { get; set; }
        }

        [DataContract]
        public class InstituteDM
        {
            [DataMember]
            public int id_inst { get; set; }
            [DataMember]
            public int EgroupID { get; set; }
            [DataMember]
            public string INSTITUTE_NAME { get; set; }
            [DataMember]
            public string SHORT_NAME { get; set; }
            [DataMember]
            public string flag { get; set; }
        }

        [DataContract]
        public class CollegeDM
        {
            [DataMember]
            public int CollegeID { get; set; }
            [DataMember]
            public string CollegeName { get; set; }
            [DataMember]
            public string ShortName { get; set; }
            [DataMember]
            public string Location { get; set; }
            [DataMember]
            public string Phone1 { get; set; }
            [DataMember]
            public string Phone2 { get; set; }
            [DataMember]
            public string Phone3 { get; set; }
            [DataMember]
            public string Fax { get; set; }
            [DataMember]
            public string Mobile { get; set; }
            [DataMember]
            public string EmailID1 { get; set; }
            [DataMember]
            public string EmailID2 { get; set; }
            [DataMember]
            public string WebSite { get; set; }
            [DataMember]
            public string Description { get; set; }
            [DataMember]
            public int Inst_Type { get; set; }
            [DataMember]
            public int Inst_Nature { get; set; }
            [DataMember]
            public string Affiliation_No { get; set; }
            [DataMember]
            public string LandMark { get; set; }
            [DataMember]
            public string CityOffice { get; set; }
            [DataMember]
            public byte[] InstLogo { get; set; }
            [DataMember]
            public string Acd_Session { get; set; }
            [DataMember]
            public string PrincipalName { get; set; }
            [DataMember]
            public string ProxyAddress { get; set; }
            [DataMember]
            public string ProxyUser { get; set; }
            [DataMember]
            public string ProxyPwd { get; set; }
            [DataMember]
            public string Salt { get; set; }
            [DataMember]
            public bool IsMailActive { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string Auto_PPSNO { get; set; }
            [DataMember]
            public string Auto_RECNO { get; set; }

        }

        [DataContract]
        public class SessionDM
        {
            [DataMember]
            public int SessionID { get; set; }
            [DataMember]
            public string Session { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndDate { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [DataContract]
        public class YearSemDM
        {
            [DataMember]
            public int CID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string CourseYear { get; set; }
            [DataMember]
            public int SpecialisationID { get; set; }
            [DataMember]
            public int Description { get; set; }
            [DataMember]
            public int inst_ID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime endDate { get; set; }
            [DataMember]
            public string SessionName { get; set; }
            [DataMember]
            public string sessionyear { get; set; }
            [DataMember]
            public string SemYear { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public string Batch { get; set; }
            [DataMember]
            public string flag { get; set; }
            [DataMember]
            public string Year { get; set; }
         }

        [DataContract]
        public class LoginDM
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Login_Date { get; set; }
            [DataMember]
            public string Login_Time { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember(IsRequired = false)]
            public string Logout_Time { get; set; }
            [DataMember(IsRequired = false)]
            public string Logout_Date { get; set; }
            [DataMember]
            public string Is_Login { get; set; }
            [DataMember]
            public string Flag { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string client_ip { get; set; }
            [DataMember]
            public string client_name { get; set; }
        }

        [DataContract]
        public class AuditDM
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Form_Name { get; set; }
            [DataMember]
            public string Action { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string Entry_Date { get; set; }
            [DataMember]
            public string Record_ID { get; set; }
            [DataMember]
            public string Entry_Time { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }

        }

        [DataContract]
        public class CreateUserDM
        {
            [DataMember]
            public int UserID { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public string Password { get; set; }
            [DataMember]
            public string Salt { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string Active { get; set; }
            [DataMember]
            public string UName { get; set; }
            [DataMember]
            public DateTime  UEntDt { get; set; }
            [DataMember]
            public int Emp_id { get; set; }
            [DataMember]
            public string User_Type { get; set; }
            [DataMember]
            public string Flag { get; set; }
            [DataMember]
            public string EmailID { get; set; }
        }

        [DataContract]
        public class FormPermissionDM
        {
            [DataMember]
            public int MenuId { get; set; }
            [DataMember]
            public string RetSuccess { get; set; }
            [DataMember]
            public string fields { get; set; }
            [DataMember]
            public string where { get; set; }
            [DataMember]
            public int InstId { get; set; }
            [DataMember]
            public int FieldId { get; set; }
            [DataMember]
            public string FieldName { get; set; }
            [DataMember]
            public string ValueField { get; set; }
            [DataMember]
            public string TableName { get; set; }
            [DataMember]
            public string User_Type { get; set; }
            [DataMember]
            public string Flag { get; set; }

        }

        [DataContract]
        public class IDCardTemplateDM
        {
            [DataMember]
            public int TemplateID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public byte[] HeaderImage { get; set; }
            [DataMember]
            public byte[] Aus { get; set; }
            [DataMember]
            public string Desgin_String { get; set; }
            [DataMember]
            public string Flag { get; set; }

        }
        [Serializable]
        [DataContract]
        public class CheckLoginDM
        {
            [DataMember]
            public int instId { get; set; }
            [DataMember]
            public string  username { get; set; }
            [DataMember]
            public string User { get; set; }
            [DataMember]
            public int IsNewLogin { get; set; }
            [DataMember]
            public int StudentId { get; set; }
            [DataMember]
            public int Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FloorMasterDM
        {
            [DataMember]
            public int ifloorId { get; set; }
            [DataMember]
            public string ifloorName { get; set; }
            [DataMember]
            public string ifloorSName { get; set; }
            [DataMember]
            public int instituteId { get; set; }
            [DataMember]
            public string flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class FloorMasterUpdateDM
        {
            [DataMember]
            public string ifloorName { get; set; }
            [DataMember]
            public string ifloorSName { get; set; }
            //[DataMember]
            //public int instituteId { get; set; }
        }

        [Serializable]
        [DataContract]
        public class BlockMasterUpdateDM
        {
            [DataMember]
            public string iblockName { get; set; }

        }

        [Serializable]
        [DataContract]
        public class BlockMasterDM
        {
            [DataMember]
            public int iblockId { get; set; }
            [DataMember]
            public string iblockName { get; set; }
            [DataMember]
            public int instituteId { get; set; }
            [DataMember]
            public string flag { get; set; }
        }


        [Serializable]
        [DataContract]
        public class RoomMasterUpdateDM
        {
            [DataMember]
            public int floorId { get; set; }
            [DataMember]
            public int blockId { get; set; }
            [DataMember]
            public string roomName { get; set; }
            [DataMember]
            public string roomNo { get; set; }
            [DataMember]
            public string roomType { get; set; }
            [DataMember]
            public int roomCapacity { get; set; }

        }

        [Serializable]
        [DataContract]
        public class RoomMasterDM
        {
            [DataMember]
            public int iroomId { get; set; }
            [DataMember]
            public int floorId { get; set; }
            [DataMember]
            public int blockId { get; set; }
            [DataMember]
            public string roomName { get; set; }
            [DataMember]
            public string roomNo { get; set; }
            [DataMember]
            public string roomType { get; set; }
            [DataMember]
            public int roomCapacity { get; set; }
            [DataMember]
            public int instituteId { get; set; }
             [DataMember]
            public string RoomPattern { get; set; }
            [DataMember]
            public string flag { get; set; }
        }

        //[Serializable]
        //[DataContract]
        //public class AssignRoomDM
        //{
        //    [DataMember]
        //    public int AssignRoomID { get; set; }
        //    [DataMember]
        //    public int CourseID { get; set; }
        //    [DataMember]
        //    public string Session { get; set; }
        //    [DataMember]
        //    public int FloorID { get; set; }
        //    [DataMember]
        //    public int BlockID { get; set; }
        //    [DataMember]
        //    public int RoomID { get; set; }
        //    [DataMember]
        //    public int Year { get; set; }
        //    [DataMember]
        //    public int Sid { get; set; }
        //    [DataMember]
        //    public int InstituteID { get; set; }
        //}

        //[Serializable]
        //[DataContract]
        //public class FillAssignRoomDM
        //{
        //    [DataMember]
        //    public int iroomId { get; set; }
        //    [DataMember]
        //    public string roomName { get; set; }
        //}

        [Serializable]
        [DataContract]
        public class FillAssignRoomGrdDM
        {
            [DataMember]
            public int AssignRoomID { get; set; }
            [DataMember]
            public string CourseName { get; set; }
            [DataMember]
            public string roomName { get; set; }
            [DataMember]
            public string roomNo { get; set; }
            [DataMember]
            public string BlockName { get; set; }
            [DataMember]
            public string FloorName { get; set; }
            [DataMember]
            public string YearSem { get; set; }
            [DataMember]
            public string roomType { get; set; }
            [DataMember]
            public string Session { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public int FloorID { get; set; }
            [DataMember]
            public int BlockID { get; set; }
            [DataMember]
            public int RoomID { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int Subjectid { get; set; }
            [DataMember]
            public string iGroup { get; set; }
            [DataMember]
            public string SubjectName { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public string Batch_Name { get; set; }
            [DataMember]
            public string cat_name { get; set; }
        }

        [Serializable]
        [DataContract]
        public class AssignRoomDM
        {
            [DataMember]
            public int AssignRoomID { get; set; }
            [DataMember]
            public int CourseID { get; set; }
            [DataMember]
            public string Session { get; set; }
            [DataMember]
            public int FloorID { get; set; }
            [DataMember]
            public int BlockID { get; set; }
            [DataMember]
            public int RoomID { get; set; }
            [DataMember]
            public int Year { get; set; }
            [DataMember]
            public int Sid { get; set; }
            [DataMember]
            public int StatusId { get; set; }

            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string iGroup { get; set; }
            [DataMember]
            public int SpecializationID { get; set; }
            [DataMember]
            public int SubjectID { get; set; }
            [DataMember]
            public string Flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FillAssignRoomDM
        {
            [DataMember]
            public int iroomId { get; set; }
            [DataMember]
            public string roomNo { get; set; }
            //[DataMember]
            //public string roomType { get; set; }
        }

        [Serializable]
        [DataContract]
        public class FillARoomGrdDM
        {
            [DataMember]
            public int iroomId { get; set; }
            [DataMember]
            public string rType { get; set; }
            [DataMember]
            public string roomType { get; set; }
            [DataMember]
            public string roomNo { get; set; }
        }
        [Serializable]
        [DataContract]
        public class AddcontrolDM
        {
            [DataMember]
            public int ControlID { get; set; }
            [DataMember]
            public string ControlName { get; set; }
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string ControlPath { get; set; }
            [DataMember]
            public int instituteId { get; set; }
            [DataMember]
            public string flag { get; set; }
        }

        [Serializable]
        [DataContract]
        public class LoginAll
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public string Login_Date { get; set; }
            [DataMember]
            public string Login_Time { get; set; }
            [DataMember]
            public int InstituteID { get; set; }
            [DataMember]
            public string SessionID { get; set; }
            [DataMember(IsRequired = false)]
            public string Logout_Time { get; set; }
            [DataMember(IsRequired = false)]
            public string Logout_Date { get; set; }
            [DataMember]
            public string Is_Login { get; set; }
            [DataMember]
            public string Flag { get; set; }
            [DataMember]
            public string User_ID { get; set; }
            [DataMember]
            public string client_ip { get; set; }
            [DataMember]
            public string client_name { get; set; }

            [DataMember]
            public string Day { get; set; }
            [DataMember]
            public string month { get; set; }
            [DataMember]
            public string year { get; set; }

            [DataMember]
            public string IntimeHr { get; set; }
            [DataMember]
            public string InTimeMin { get; set; }
            [DataMember]
            public string IntimeSec { get; set; }

            [DataMember]
            public string outTimeHr { get; set; }
            [DataMember]
            public string outTimeMin { get; set; }
            [DataMember]
            public string OutTimeSec { get; set; }
        }

    }

    
}
