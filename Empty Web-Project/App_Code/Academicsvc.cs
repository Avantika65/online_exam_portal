using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using NewDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

[ServiceContract(Namespace = "",CallbackContract=typeof(IAcademic),ConfigurationName="Service")]
public interface IAcademic
{
    [OperationContract(IsOneWay=false)]
    string InsertDepartment(Academic.AcademicData.DepartmentDM ry);
    [OperationContract(IsOneWay = false)]
    string InsertCourse(Academic.AcademicData.CourseDM ry, Admin.AdministratorData.AuditDM audit);

}
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
public class Academicsvc : IAcademic
{
    [OperationContract(IsOneWay = false)]
     public string InsertDepartment(Academic.AcademicData.DepartmentDM ry)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(6);
            objDB.AddParameters(0, "DepartmentID", ry.DepartmentID, DbType.Int32);
            objDB.AddParameters(1, "DepartmentName", ry.DepartmentName, DbType.String);
            objDB.AddParameters(2, "ShortName", ry.ShortName, DbType.String);
            objDB.AddParameters(3, "Active", ry.Active, DbType.String);
            objDB.AddParameters(4, "InstituteID", ry.InstituteID, DbType.Int32);
            objDB.AddParameters(5, "flag", ry.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Department_Insert");
            objDB.Transaction.Commit();
            if (ry.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (ry.Flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record";
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertCourse(Academic.AcademicData.CourseDM ry, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        //string f = "";
        try
        {
            objDB.CreateParameters(14);
            objDB.AddParameters(0, "CourseId", ry.CourseId, DbType.Int32);
            objDB.AddParameters(1, "CourseName", ry.CourseName, DbType.String);
            objDB.AddParameters(2, "ShortName", ry.ShortName, DbType.String);
            objDB.AddParameters(3, "CourseNature", ry.CourseNature, DbType.String);
            objDB.AddParameters(4, "CourseDuration", ry.CourseDuration, DbType.Int32);
            //objDB.AddParameters(5, "SpecialisationID", ry.SpecialisationID, DbType.String);
            objDB.AddParameters(5, "InstituteID", ry.InstituteID, DbType.Int32);
            objDB.AddParameters(6, "Active", ry.Active, DbType.String);
            objDB.AddParameters(7, "Type", ry.Type, DbType.String);
            objDB.AddParameters(8, "DepartmentID", ry.DepartmentID, DbType.Int32);
            objDB.AddParameters(9, "flag", ry.Flag, DbType.String);
            objDB.AddParameters(10, "NOS", ry.NOS, DbType.Int32);
            objDB.AddParameters(11, "EXS", ry.EXS, DbType.Int32);
            objDB.AddParameters(12, "Category", ry.Category, DbType.String);
            objDB.AddParameters(13, "EGroupID", ry.Isgroup, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "CourseMaster");
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (ry.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (ry.Flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertCourseDel(Academic.AcademicData.CourseDelDM ry, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(1);
            objDB.AddParameters(0, "CourseID", ry.CourseID, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Course_Delete");

            //foreach (Academic.AcademicData.CourseChildDM chm in coursechild)
            //{
            //    objDB.CreateParameters(1);
            //    objDB.AddParameters(0, "CourseId", ry.CourseId, DbType.Int32);
            //    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "CourseChild");
            //}

            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();

            retv = "Record Deleted.";
        }

        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }


    [OperationContract(IsOneWay = false)]
    public string InsertWeekDel(Academic.AcademicData.WeekDelDM ry, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(4);
            objDB.AddParameters(0, "CourseID", ry.CourseID, DbType.Int32);
            objDB.AddParameters(1, "semid", ry.semid, DbType.Int32);
            objDB.AddParameters(2, "SessionYr", ry.SessionYr, DbType.String);
            objDB.AddParameters(3, "Inst_ID", ry.Inst_ID, DbType.Int32);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Week_Delete");

            //foreach (Academic.AcademicData.CourseChildDM chm in coursechild)
            //{
            //    objDB.CreateParameters(1);
            //    objDB.AddParameters(0, "CourseId", ry.CourseId, DbType.Int32);
            //    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "CourseChild");
            //}

            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();

            retv = "Record Deleted.";
        }

        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }


    [OperationContract(IsOneWay = false)]
    public string InsertCourseDept(List<Academic.AcademicData.CourseDeptMapDM> DeptM,  Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (Academic.AcademicData.CourseDeptMapDM ry in DeptM)
            {
                objDB.CreateParameters(7);
                objDB.AddParameters(0, "ID", ry.ID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", ry.InstituteID, DbType.String);
                objDB.AddParameters(2, "DepartmentID", ry.DepartmentID, DbType.String);
                objDB.AddParameters(3, "CourseID", ry.CourseID, DbType.String);
                objDB.AddParameters(4, "status", ry.Status, DbType.Int32);
                objDB.AddParameters(5, "splid", ry.splid,DbType.Int32);
                objDB.AddParameters(6, "flag", ry.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "DeptCoursMap_sp");
                f = ry.flag;
            }
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (f  == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertWeek(List<Academic.AcademicData.WeekDM> WeekM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            foreach (Academic.AcademicData.WeekDM ry in WeekM)
            {
                objDB.CreateParameters(12);
                objDB.AddParameters(0, "WeekID", ry.WeekID, DbType.Int32);
                objDB.AddParameters(1, "StartDate", ry.StartDate, DbType.DateTime);
                objDB.AddParameters(2, "EndDate", ry.EndDate, DbType.DateTime);
                objDB.AddParameters(3, "WeekName", ry.WeekName, DbType.String);
                objDB.AddParameters(4, "SessionYear", ry.SessionYear, DbType.String);
                objDB.AddParameters(5, "Active", ry.Active, DbType.String);
                objDB.AddParameters(6, "Inst_ID", ry.Inst_ID, DbType.Int32);
                objDB.AddParameters(7, "CourseId", ry.CourseId, DbType.Int32);
                objDB.AddParameters(8, "semid", ry.semid, DbType.Int32);
                objDB.AddParameters(9, "YearID", ry.YearID, DbType.Int32);
                objDB.AddParameters(10, "SplId", ry.SplId, DbType.Int32);
                objDB.AddParameters(11, "flag", ry.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Week_Insert");
                f = ry.Flag;
            }
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    [OperationContract(IsOneWay = false)]
    public string InsertFaculty( Academic.AcademicData.FacultyDM FacultyM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
         
                objDB.CreateParameters(24);
                objDB.AddParameters(0, "FacultyID", FacultyM.FacultyID, DbType.Int32);
                objDB.AddParameters(1, "Salutation", FacultyM.Salutation, DbType.String);
                objDB.AddParameters(2, "FirstName", FacultyM.FirstName, DbType.String);
                objDB.AddParameters(3, "MiddleName", FacultyM.MiddleName, DbType.String);
                objDB.AddParameters(4, "LastName", FacultyM.LastName, DbType.String);
                objDB.AddParameters(5, "Password", FacultyM.Password, DbType.String);
                objDB.AddParameters(6, "DepartmentID", FacultyM.DepartmentID, DbType.Int32);
                objDB.AddParameters(7, "Designation", FacultyM.Designation, DbType.Int32);
                objDB.AddParameters(8, "BirthDate", FacultyM.BirthDate, DbType.DateTime);
                objDB.AddParameters(9, "Address", FacultyM.Address, DbType.String);
                objDB.AddParameters(10, "City", FacultyM.City, DbType.Int32);

                objDB.AddParameters(11, "State", FacultyM.State, DbType.Int32);
                objDB.AddParameters(12, "Country", FacultyM.Country, DbType.Int32);
                objDB.AddParameters(13, "EmailID", FacultyM.EmailID, DbType.String);
                objDB.AddParameters(14, "Phone", FacultyM.Phone, DbType.String);
                objDB.AddParameters(15, "Mobile", FacultyM.Mobile, DbType.String);
                objDB.AddParameters(16, "Active", FacultyM.Active, DbType.String);

                objDB.AddParameters(17, "Councellor", FacultyM.Councellor, DbType.String);
                objDB.AddParameters(18, "InstituteID", FacultyM.InstituteID, DbType.Int32);
                objDB.AddParameters(19, "SessionID", FacultyM.SessionID, DbType.String);
                objDB.AddParameters(20, "UName", FacultyM.UName, DbType.String);
                objDB.AddParameters(21, "UEntDt", FacultyM.UEntDt, DbType.DateTime);
                objDB.AddParameters(22, "Photo", FacultyM.Photo, DbType.Binary);
                objDB.AddParameters(23, "Flag", FacultyM.Flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Faculty_Insert");
                f = FacultyM.Flag;
 
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }


    //[OperationContract(IsOneWay = false)]
    //public string InsertStudentDetail(Academic.AcademicData.StudentRegistrationDM StudentM, List<Academic.AcademicData.StudentRegistrationDetailDM> studentDM, Academic.AcademicData.StudentStatusDM objSM, List<Academic.AcademicData.StudentPQuaificationDM> SQDM, List<Academic.AcademicData.StudentDocumentDM> SDDM, Admin.AdministratorData.AuditDM audit)
    //{
    //    NewDAL.DBManager objDB = new DBManager();
    //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
    //    objDB.Open();
    //    objDB.BeginTransaction();
    //    string retv = "";
    //    string f = "";
    //    try
    //    {

    //        objDB.CreateParameters(69);
    //        objDB.AddParameters(0, "StudentID", StudentM.StudentID, DbType.Int32);
    //        objDB.AddParameters(1, "ProspectusDocID", StudentM.ProspectusDocID, DbType.String);
    //        objDB.AddParameters(2, "EnquiryDocID", StudentM.EnquiryDocID, DbType.String);
    //        objDB.AddParameters(3, "RegistrationNo", StudentM.RegistrationNo, DbType.String);
    //        objDB.AddParameters(4, "RegistrationDate", StudentM.RegistrationDate, DbType.String);
    //        objDB.AddParameters(5, "SessionCode", StudentM.SessionCode, DbType.String);
    //        objDB.AddParameters(6, "CourseCode", StudentM.CourseCode, DbType.String);
    //        objDB.AddParameters(7, "StudentNamePrefix", StudentM.StudentNamePrefix, DbType.String);
    //        objDB.AddParameters(8, "StudentName", StudentM.StudentName, DbType.String);
    //        objDB.AddParameters(9, "ID_Student", StudentM.ID_Student, DbType.String);
    //        objDB.AddParameters(10, "ImagePath", StudentM.ImagePath, DbType.Binary);
    //        objDB.AddParameters(11, "IdentityMark", StudentM.IdentityMark, DbType.String);
    //        objDB.AddParameters(12, "FatherNamePrefix", StudentM.FatherNamePrefix, DbType.String);
    //        objDB.AddParameters(13, "FatherName", StudentM.FatherName, DbType.String);
    //        objDB.AddParameters(14, "ParentOccCode", StudentM.ParentOccCode, DbType.String);
    //        objDB.AddParameters(15, "MotherNamePrefix", StudentM.MotherNamePrefix, DbType.String);
    //        objDB.AddParameters(16, "MotherName", StudentM.MotherName, DbType.String);
    //        objDB.AddParameters(17, "DOB", StudentM.DOB, DbType.String);
    //        objDB.AddParameters(18, "Category", StudentM.Category, DbType.String);
    //        objDB.AddParameters(19, "Sex", StudentM.Sex, DbType.String);
    //        objDB.AddParameters(20, "ReligionCode", StudentM.ReligionCode, DbType.String);
    //        objDB.AddParameters(21, "NationalityCode", StudentM.NationalityCode, DbType.String);
    //        objDB.AddParameters(22, "GuardianNamePrefix", StudentM.GuardianNamePrefix, DbType.String);
    //        objDB.AddParameters(23, "GuardianName", StudentM.GuardianName, DbType.String);
    //        objDB.AddParameters(24, "GuardianOccCode", StudentM.GuardianOccCode, DbType.String);
    //        objDB.AddParameters(25, "StudentRelation", StudentM.StudentRelation, DbType.String);
    //        objDB.AddParameters(26, "AnnualIncome", StudentM.AnnualIncome, DbType.Decimal);
    //        objDB.AddParameters(27, "UniversityCode", StudentM.UniversityCode, DbType.String);
    //        objDB.AddParameters(28, "DocumentCode", StudentM.DocumentCode, DbType.Int32);
    //        objDB.AddParameters(29, "LAdd1", StudentM.LAdd1, DbType.String);
    //        objDB.AddParameters(30, "LAdd2", StudentM.LAdd2, DbType.String);
    //        objDB.AddParameters(31, "LAdd3", StudentM.LAdd3, DbType.String);
    //        objDB.AddParameters(32, "LCityCode", StudentM.LCityCode, DbType.Int32);
    //        objDB.AddParameters(33, "LPinCode", StudentM.LPinCode, DbType.String);
    //        objDB.AddParameters(34, "LPhoneNo", StudentM.LPhoneNo, DbType.String);
    //        objDB.AddParameters(35, "LMobileNo", StudentM.LMobileNo, DbType.String);
    //        objDB.AddParameters(36, "EMail", StudentM.EMail, DbType.String);
    //        objDB.AddParameters(37, "PAdd1", StudentM.PAdd1, DbType.String);
    //        objDB.AddParameters(38, "PAdd2", StudentM.PAdd2, DbType.String);
    //        objDB.AddParameters(39, "PAdd3", StudentM.PAdd3, DbType.String);
    //        objDB.AddParameters(40, "PCityCode", StudentM.PCityCode, DbType.Int32);
    //        objDB.AddParameters(41, "PPinCode", StudentM.PPinCode, DbType.String);
    //        objDB.AddParameters(42, "PPhoneNo", StudentM.PPhoneNo, DbType.String);
    //        objDB.AddParameters(43, "PMobileNo", StudentM.PMobileNo, DbType.String);
    //        objDB.AddParameters(44, "CAdd1", StudentM.CAdd1, DbType.String);
    //        objDB.AddParameters(45, "CAdd2", StudentM.CAdd2, DbType.String);
    //        objDB.AddParameters(46, "CAdd3", StudentM.CAdd3, DbType.String);
    //        objDB.AddParameters(47, "CCityCode", StudentM.CCityCode, DbType.Int32);
    //        objDB.AddParameters(48, "CPinCode", StudentM.CPinCode, DbType.String);
    //        objDB.AddParameters(49, "CPhoneNo", StudentM.CPhoneNo, DbType.String);
    //        objDB.AddParameters(50, "CMobileNo", StudentM.CMobileNo, DbType.String);
    //        objDB.AddParameters(51, "ModeCode", StudentM.ModeCode, DbType.String);
    //        objDB.AddParameters(52, "BloodGroup", StudentM.BloodGroup, DbType.String);
    //        objDB.AddParameters(53, "UName", StudentM.UName, DbType.String);
    //        objDB.AddParameters(54, "UEntDt", StudentM.UEntDt, DbType.DateTime);
    //        objDB.AddParameters(55, "RollNo", StudentM.RollNo, DbType.String);
    //        objDB.AddParameters(56, "BatchCode", StudentM.BatchCode, DbType.String);
    //        objDB.AddParameters(57, "CourseDescCode", StudentM.CourseDescCode, DbType.String);
    //        objDB.AddParameters(58, "EnrollmentNo", StudentM.EnrollmentNo, DbType.String);
    //        objDB.AddParameters(59, "PassOutDate", StudentM.PassOutDate, DbType.String);
    //        objDB.AddParameters(60, "InstituteID", StudentM.InstituteID, DbType.Int32);
    //        objDB.AddParameters(61, "SessionID", StudentM.SessionID, DbType.String);
    //        objDB.AddParameters(62, "MName", StudentM.MName, DbType.String);
    //        objDB.AddParameters(63, "LName", StudentM.LName, DbType.String);
    //        objDB.AddParameters(64, "CCategory", StudentM.CCategory, DbType.String);
    //        objDB.AddParameters(65, "Status", StudentM.Status, DbType.String);
    //        objDB.AddParameters(66, "Barcode", StudentM.Barcode, DbType.String);
    //        objDB.AddParameters(67, "flag", StudentM.flag, DbType.String);
    //        objDB.AddParameters(68, "StudentIDreturn", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
    //        f = StudentM.flag;
    //        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Stu_Reg_Insert");
    //        Int32 sid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
    //        if (StudentM.flag == "U")
    //        {
    //            sid = StudentM.StudentID;
    //        }
    //        else
    //        {
    //            sid =  Int32.Parse(objDB.Parameters[68].Value.ToString());
    //        }
    //        if (StudentM.flag == "N")
    //        {
    //            objDB.CreateParameters(14);
    //            objDB.AddParameters(0, "StudentID", sid, DbType.Int32);
    //            objDB.AddParameters(1, "Batch", objSM.Batch, DbType.String);
    //            objDB.AddParameters(2, "Session", objSM.Session, DbType.String);
    //            objDB.AddParameters(3, "YearID", objSM.YearID, DbType.String);
    //            objDB.AddParameters(4, "SemesterID", objSM.SemesterID, DbType.Int32);
    //            objDB.AddParameters(5, "EnrollmentNo", objSM.EnrollmentNo, DbType.String);
    //            objDB.AddParameters(6, "RollNo", objSM.RollNo, DbType.String);
    //            objDB.AddParameters(7, "Status", objSM.Status, DbType.String);
    //            objDB.AddParameters(8, "IsFeeDeposited", objSM.IsFeeDeposited, DbType.Int32);
    //            objDB.AddParameters(9, "IsFeePaid", objSM.IsFeePaid, DbType.Int32);
    //            objDB.AddParameters(10, "IsCardIssued", objSM.IsCardIssued, DbType.Int32);
    //            objDB.AddParameters(11, "IsCourseChange", objSM.IsCourseChange, DbType.Int32);
    //            objDB.AddParameters(12, "ExamRollNo", objSM.ExamRollNo, DbType.Int32);
    //            objDB.AddParameters(13, "flag", objSM.flag, DbType.String);
    //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDetail_Insert");
    //        }
    //        foreach (Academic.AcademicData.StudentRegistrationDetailDM std in studentDM)
           
    //        {
    //            objDB.CreateParameters(22);
    //            objDB.AddParameters(0, "DocID", sid, DbType.Int32);
    //            objDB.AddParameters(1, "SrNo", std.SrNo, DbType.Int32);
    //            objDB.AddParameters(2, "FeeHeadCode", std.FeeHeadCode, DbType.String);
    //            objDB.AddParameters(3, "TotalFeeAmount", std.TotalFeeAmount, DbType.Decimal);
    //            objDB.AddParameters(4, "BreakoffTime", std.BreakoffTime, DbType.String);
    //            objDB.AddParameters(5, "Amount", std.Amount, DbType.Decimal);
    //            objDB.AddParameters(6, "UName", std.UName, DbType.String);
    //            objDB.AddParameters(7, "UEntDt", std.UEntDt, DbType.DateTime);
    //            objDB.AddParameters(8, "DueDate", std.DueDate, DbType.DateTime);
    //            objDB.AddParameters(9, "PaidAmount", std.PaidAmount, DbType.Decimal);
    //            objDB.AddParameters(10, "BalAmount", std.BalAmount, DbType.Decimal);
    //            objDB.AddParameters(11, "ReFund", std.ReFund, DbType.Decimal);
    //            objDB.AddParameters(12, "CourseID", std.CourseID, DbType.Int32);
    //            objDB.AddParameters(13, "SID", std.SID, DbType.Int32);
    //            objDB.AddParameters(14, "YearID", std.SID, DbType.String);
    //            objDB.AddParameters(15, "Session", std.Session, DbType.String);
    //            objDB.AddParameters(16, "Inst_ID", std.Inst_ID, DbType.Int32);
    //            objDB.AddParameters(17, "Status", std.Status, DbType.String);
    //            objDB.AddParameters(18, "ODC_Charge", std.ODC_Charge, DbType.Decimal);
    //            objDB.AddParameters(19, "fromdate", std.fromdate, DbType.DateTime);
    //            objDB.AddParameters(20, "flag", std.flag, DbType.String);
    //            objDB.AddParameters(21, "Feesubid", std.FeesubID, DbType.Int32);
    //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Stu_Reg_D_Insert");
    //        }
    //        foreach (Academic.AcademicData.StudentPQuaificationDM std in SQDM)
    //        {
    //            objDB.CreateParameters(8);
    //            objDB.AddParameters(0, "StudentID", sid, DbType.Int32);
    //            objDB.AddParameters(1, "QualificationID", std.QualificationID, DbType.Int32);
    //            objDB.AddParameters(2, "Passing_Year", std.Passing_Year, DbType.Int32);
    //            objDB.AddParameters(3, "Board", std.Board, DbType.String);
    //            objDB.AddParameters(4, "Max_Mark", std.Max_Mark, DbType.String);
    //            objDB.AddParameters(5, "Min_Mark", std.Min_Mark, DbType.String);
    //            objDB.AddParameters(6, "Division", std.Division, DbType.String);
    //            objDB.AddParameters(7, "flag", std.flag, DbType.String);
    //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentQ_Insert");
    //        }
    //        foreach (Academic.AcademicData.StudentDocumentDM std in SDDM)
    //        {
    //            objDB.CreateParameters(11);
    //            objDB.AddParameters(0, "StudentID", sid, DbType.Int32);
    //            objDB.AddParameters(1, "DocumentID", std.DocumentID, DbType.Int32);
    //            objDB.AddParameters(2, "Passing_Year", std.Passing_Year, DbType.Int32);
    //            objDB.AddParameters(3, "Is_Original", std.Is_Original, DbType.String);
    //            objDB.AddParameters(4, "Is_Submitted", std.Is_Submitted, DbType.String);
    //            objDB.AddParameters(5, "Issued_By", std.Issued_By, DbType.String);
    //            objDB.AddParameters(6, "Verified_By", std.Verified_By, DbType.String);
    //            objDB.AddParameters(7, "Remark", std.Remark, DbType.String);
    //            objDB.AddParameters(8, "DocSerial", std.DocSerial, DbType.String);
    //            objDB.AddParameters(9, "Percentage", std.Percentage, DbType.String);
    //            objDB.AddParameters(10, "flag", std.flag, DbType.String);
    //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDocument_Insert");
    //        }
    //        objDB.CreateParameters(9);
    //        objDB.AddParameters(0, "ID", 0, DbType.Int32);
    //        objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
    //        objDB.AddParameters(2, "Action", audit.Action, DbType.String);
    //        objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
    //        objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
    //        objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
    //        objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
    //        objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
    //        objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
    //        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");

            
    //        objDB.Transaction.Commit();
    //        if (f == "N")
    //        {
    //            retv = "Record saved.";
    //        }
    //        else if (f == "U")
    //        {
    //            retv = "Record Updated Successfully.";
    //        }
    //        else
    //        {
    //            retv = "Record deleted Successfully.";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        objDB.Transaction.Rollback();
    //        retv = "Unable to save record :-" + ex.Message.ToString();
    //    }
    //    finally
    //    {

    //        objDB.Connection.Close();
    //        objDB.Dispose();
    //    }
    //    return retv;
    //}


    [OperationContract(IsOneWay = false)]
    public string InsertStudentDetail(Academic.AcademicData.StudentRegistrationDM StudentM, List<Academic.AcademicData.StudentRegistrationDetailDM> studentDM, Academic.AcademicData.StudentStatusDM objSM, List<Academic.AcademicData.StudentPQuaificationDM> SQDM, List<Academic.AcademicData.StudentDocumentDM> SDDM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {

            objDB.CreateParameters(69);
            objDB.AddParameters(0, "StudentID", StudentM.StudentID, DbType.Int32);
            objDB.AddParameters(1, "ProspectusDocID", StudentM.ProspectusDocID, DbType.String);
            objDB.AddParameters(2, "EnquiryDocID", StudentM.EnquiryDocID, DbType.String);
            objDB.AddParameters(3, "RegistrationNo", StudentM.RegistrationNo, DbType.String);
            objDB.AddParameters(4, "RegistrationDate", StudentM.RegistrationDate, DbType.String);
            objDB.AddParameters(5, "SessionCode", StudentM.SessionCode, DbType.String);
            objDB.AddParameters(6, "CourseCode", StudentM.CourseCode, DbType.String);
            objDB.AddParameters(7, "StudentNamePrefix", StudentM.StudentNamePrefix, DbType.String);
            objDB.AddParameters(8, "StudentName", StudentM.StudentName, DbType.String);
            objDB.AddParameters(9, "ID_Student", StudentM.ID_Student, DbType.String);
            objDB.AddParameters(10, "ImagePath", StudentM.ImagePath, DbType.Binary);
            objDB.AddParameters(11, "IdentityMark", StudentM.IdentityMark, DbType.String);
            objDB.AddParameters(12, "FatherNamePrefix", StudentM.FatherNamePrefix, DbType.String);
            objDB.AddParameters(13, "FatherName", StudentM.FatherName, DbType.String);
            objDB.AddParameters(14, "ParentOccCode", StudentM.ParentOccCode, DbType.String);
            objDB.AddParameters(15, "MotherNamePrefix", StudentM.MotherNamePrefix, DbType.String);
            objDB.AddParameters(16, "MotherName", StudentM.MotherName, DbType.String);
            objDB.AddParameters(17, "DOB", StudentM.DOB, DbType.String);
            objDB.AddParameters(18, "Category", StudentM.Category, DbType.String);
            objDB.AddParameters(19, "Sex", StudentM.Sex, DbType.String);
            objDB.AddParameters(20, "ReligionCode", StudentM.ReligionCode, DbType.String);
            objDB.AddParameters(21, "NationalityCode", StudentM.NationalityCode, DbType.String);
            objDB.AddParameters(22, "GuardianNamePrefix", StudentM.GuardianNamePrefix, DbType.String);
            objDB.AddParameters(23, "GuardianName", StudentM.GuardianName, DbType.String);
            objDB.AddParameters(24, "GuardianOccCode", StudentM.GuardianOccCode, DbType.String);
            objDB.AddParameters(25, "StudentRelation", StudentM.StudentRelation, DbType.String);
            objDB.AddParameters(26, "AnnualIncome", StudentM.AnnualIncome, DbType.Decimal);
            objDB.AddParameters(27, "UniversityCode", StudentM.UniversityCode, DbType.String);
            objDB.AddParameters(28, "DocumentCode", StudentM.DocumentCode, DbType.Int32);
            objDB.AddParameters(29, "LAdd1", StudentM.LAdd1, DbType.String);
            objDB.AddParameters(30, "LAdd2", StudentM.LAdd2, DbType.String);
            objDB.AddParameters(31, "LAdd3", StudentM.LAdd3, DbType.String);
            objDB.AddParameters(32, "LCityCode", StudentM.LCityCode, DbType.Int32);
            objDB.AddParameters(33, "LPinCode", StudentM.LPinCode, DbType.String);
            objDB.AddParameters(34, "LPhoneNo", StudentM.LPhoneNo, DbType.String);
            objDB.AddParameters(35, "LMobileNo", StudentM.LMobileNo, DbType.String);
            objDB.AddParameters(36, "EMail", StudentM.EMail, DbType.String);
            objDB.AddParameters(37, "PAdd1", StudentM.PAdd1, DbType.String);
            objDB.AddParameters(38, "PAdd2", StudentM.PAdd2, DbType.String);
            objDB.AddParameters(39, "PAdd3", StudentM.PAdd3, DbType.String);
            objDB.AddParameters(40, "PCityCode", StudentM.PCityCode, DbType.Int32);
            objDB.AddParameters(41, "PPinCode", StudentM.PPinCode, DbType.String);
            objDB.AddParameters(42, "PPhoneNo", StudentM.PPhoneNo, DbType.String);
            objDB.AddParameters(43, "PMobileNo", StudentM.PMobileNo, DbType.String);
            objDB.AddParameters(44, "CAdd1", StudentM.CAdd1, DbType.String);
            objDB.AddParameters(45, "CAdd2", StudentM.CAdd2, DbType.String);
            objDB.AddParameters(46, "CAdd3", StudentM.CAdd3, DbType.String);
            objDB.AddParameters(47, "CCityCode", StudentM.CCityCode, DbType.Int32);
            objDB.AddParameters(48, "CPinCode", StudentM.CPinCode, DbType.String);
            objDB.AddParameters(49, "CPhoneNo", StudentM.CPhoneNo, DbType.String);
            objDB.AddParameters(50, "CMobileNo", StudentM.CMobileNo, DbType.String);
            objDB.AddParameters(51, "ModeCode", StudentM.ModeCode, DbType.String);
            objDB.AddParameters(52, "BloodGroup", StudentM.BloodGroup, DbType.String);
            objDB.AddParameters(53, "UName", StudentM.UName, DbType.String);
            objDB.AddParameters(54, "UEntDt", StudentM.UEntDt, DbType.DateTime);
            objDB.AddParameters(55, "RollNo", StudentM.RollNo, DbType.String);
            objDB.AddParameters(56, "BatchCode", StudentM.BatchCode, DbType.String);
            objDB.AddParameters(57, "CourseDescCode", StudentM.CourseDescCode, DbType.String);
            objDB.AddParameters(58, "EnrollmentNo", StudentM.EnrollmentNo, DbType.String);
            objDB.AddParameters(59, "PassOutDate", StudentM.PassOutDate, DbType.String);
            objDB.AddParameters(60, "InstituteID", StudentM.InstituteID, DbType.Int32);
            objDB.AddParameters(61, "SessionID", StudentM.SessionID, DbType.String);
            objDB.AddParameters(62, "MName", StudentM.MName, DbType.String);
            objDB.AddParameters(63, "LName", StudentM.LName, DbType.String);
            objDB.AddParameters(64, "CCategory", StudentM.CCategory, DbType.String);
            objDB.AddParameters(65, "Status", StudentM.Status, DbType.String);
            objDB.AddParameters(66, "Barcode", StudentM.Barcode, DbType.String);
            objDB.AddParameters(67, "flag", StudentM.flag, DbType.String);
            objDB.AddParameters(68, "StudentIDreturn", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
            f = StudentM.flag;
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Stu_Reg_Insert");
            Int32 sid = 0;// Int32.Parse(objDB.Parameters[68].Value.ToString());
            if (StudentM.flag == "U")
            {
                sid = StudentM.StudentID;
            }
            else
            {
                sid = Int32.Parse(objDB.Parameters[68].Value.ToString());
            }
            if (StudentM.flag == "N")
            {
                objDB.CreateParameters(16);
                objDB.AddParameters(0, "StudentID", sid, DbType.Int32);
                objDB.AddParameters(1, "Batch", objSM.Batch, DbType.String);
                objDB.AddParameters(2, "Session", objSM.Session, DbType.String);
                objDB.AddParameters(3, "YearID", objSM.YearID, DbType.String);
                objDB.AddParameters(4, "SemesterID", objSM.SemesterID, DbType.Int32);
                objDB.AddParameters(5, "EnrollmentNo", objSM.EnrollmentNo, DbType.String);
                objDB.AddParameters(6, "RollNo", objSM.RollNo, DbType.String);
                objDB.AddParameters(7, "Status", objSM.Status, DbType.String);
                objDB.AddParameters(8, "IsFeeDeposited", objSM.IsFeeDeposited, DbType.Int32);
                objDB.AddParameters(9, "IsFeePaid", objSM.IsFeePaid, DbType.Int32);
                objDB.AddParameters(10, "IsCardIssued", objSM.IsCardIssued, DbType.Int32);
                objDB.AddParameters(11, "IsCourseChange", objSM.IsCourseChange, DbType.Int32);
                objDB.AddParameters(12, "ExamRollNo", objSM.ExamRollNo, DbType.Int32);
                objDB.AddParameters(13, "flag", objSM.flag, DbType.String);
                objDB.AddParameters(14, "CourseID", objSM.CourseID, DbType.Int32);
                objDB.AddParameters(15, "CCategory", objSM.CCategory, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDetail_Insert");
            }
            foreach (Academic.AcademicData.StudentRegistrationDetailDM std in studentDM)
            {
                objDB.CreateParameters(24);
                objDB.AddParameters(0, "DocID", sid, DbType.Int32);
                objDB.AddParameters(1, "SrNo", std.SrNo, DbType.Int32);
                objDB.AddParameters(2, "FeeHeadCode", std.FeeHeadCode, DbType.String);
                objDB.AddParameters(3, "TotalFeeAmount", std.TotalFeeAmount, DbType.Decimal);
                objDB.AddParameters(4, "BreakoffTime", std.BreakoffTime, DbType.String);
                objDB.AddParameters(5, "Amount", std.Amount, DbType.Decimal);
                objDB.AddParameters(6, "UName", std.UName, DbType.String);
                objDB.AddParameters(7, "UEntDt", std.UEntDt, DbType.DateTime);
                objDB.AddParameters(8, "DueDate", std.DueDate, DbType.DateTime);
                objDB.AddParameters(9, "PaidAmount", std.PaidAmount, DbType.Decimal);
                objDB.AddParameters(10, "BalAmount", std.BalAmount, DbType.Decimal);
                objDB.AddParameters(11, "ReFund", std.ReFund, DbType.Decimal);
                objDB.AddParameters(12, "CourseID", std.CourseID, DbType.Int32);
                objDB.AddParameters(13, "SID", std.SID, DbType.Int32);
                objDB.AddParameters(14, "YearID", std.SID, DbType.String);
                objDB.AddParameters(15, "Session", std.Session, DbType.String);
                objDB.AddParameters(16, "Inst_ID", std.Inst_ID, DbType.Int32);
                objDB.AddParameters(17, "Status", std.Status, DbType.String);
                objDB.AddParameters(18, "ODC_Charge", std.ODC_Charge, DbType.Decimal);
                objDB.AddParameters(19, "fromdate", std.fromdate, DbType.DateTime);
                objDB.AddParameters(20, "flag", std.flag, DbType.String);
                objDB.AddParameters(21, "Feesubid", std.FeesubID, DbType.Int32);
                objDB.AddParameters(22, "CCategory", std.CCategory, DbType.String);
                objDB.AddParameters(23, "Batch", std.Batch, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Stu_Reg_D_Insert");
            }
            foreach (Academic.AcademicData.StudentPQuaificationDM std in SQDM)
            {
                objDB.CreateParameters(8);
                objDB.AddParameters(0, "StudentID", sid, DbType.Int32);
                objDB.AddParameters(1, "QualificationID", std.QualificationID, DbType.Int32);
                objDB.AddParameters(2, "Passing_Year", std.Passing_Year, DbType.Int32);
                objDB.AddParameters(3, "Board", std.Board, DbType.String);
                objDB.AddParameters(4, "Max_Mark", std.Max_Mark, DbType.String);
                objDB.AddParameters(5, "Min_Mark", std.Min_Mark, DbType.String);
                objDB.AddParameters(6, "Division", std.Division, DbType.String);
                objDB.AddParameters(7, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentQ_Insert");
            }
            foreach (Academic.AcademicData.StudentDocumentDM std in SDDM)
            {
                objDB.CreateParameters(11);
                objDB.AddParameters(0, "StudentID", sid, DbType.Int32);
                objDB.AddParameters(1, "DocumentID", std.DocumentID, DbType.Int32);
                objDB.AddParameters(2, "Passing_Year", std.Passing_Year, DbType.Int32);
                objDB.AddParameters(3, "Is_Original", std.Is_Original, DbType.String);
                objDB.AddParameters(4, "Is_Submitted", std.Is_Submitted, DbType.String);
                objDB.AddParameters(5, "Issued_By", std.Issued_By, DbType.String);
                objDB.AddParameters(6, "Verified_By", std.Verified_By, DbType.String);
                objDB.AddParameters(7, "Remark", std.Remark, DbType.String);
                objDB.AddParameters(8, "DocSerial", std.DocSerial, DbType.String);
                objDB.AddParameters(9, "Percentage", std.Percentage, DbType.String);
                objDB.AddParameters(10, "flag", std.flag, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDocument_Insert");
            }
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");


            objDB.Transaction.Commit();
            if (f == "N")
            {
                retv = "Record saved.";
            }
            else if (f == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

   [OperationContract]
    public Academic.AcademicData.SessionDateDM FillSessionDatesBySem(Int32 SemesterID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "SemesterID", SemesterID, DbType.Int32);
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetSessionDatesBySemesterID");
        var item = new Academic.AcademicData.SessionDateDM();
        if (dr.Read())
        {

            item.StartDate = Education.DataHelper.GetDateTime(dr, "StartDate");
            item.EndDate = Education.DataHelper.GetDateTime(dr, "EndDate");

        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        return item;
    }


   [OperationContract]
   public List<Academic.AcademicData.WeekGrd> FillWeekGrd(int InstituteID, string SessionYear, int CourseID, int splId, int SemId, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "SessionYear", SessionYear, DbType.String);
       objDB.AddParameters(2, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(3, "SplId", splId, DbType.Int32);
       objDB.AddParameters(4, "semid", SemId, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);

       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Week_Select");
       var listOfWeek = new List<Academic.AcademicData.WeekGrd>();
       try
       {
           while (dr.Read())
           {
               var item = new Academic.AcademicData.WeekGrd();
               item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
               item.CourseYear = Education.DataHelper.GetString(dr, "CourseYear");
               item.CourseId = Education.DataHelper.GetInt(dr, "CourseId");
               item.Shortname = Education.DataHelper.GetString(dr, "Shortname");
               item.SplId = Education.DataHelper.GetInt(dr, "SplId");
               item.SStartDate = Education.DataHelper.GetDateTime(dr, "SStartDate");
               item.SEndDate = Education.DataHelper.GetDateTime(dr, "SEndDate");
               item.semid = Education.DataHelper.GetInt(dr, "semid");
               item.SessionYear = Education.DataHelper.GetString(dr, "SessionYear");
               item.WeekID = Education.DataHelper.GetInt(dr, "WeekID");
               item.WeekName = Education.DataHelper.GetString(dr, "WeekName");
               item.WStartDate = Education.DataHelper.GetDateTime(dr, "WStartDate");
               item.WEndDate = Education.DataHelper.GetDateTime(dr, "WEndDate");
               item.Active = Education.DataHelper.GetString(dr, "Active");
               listOfWeek.Add(item);
           }
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return listOfWeek;


   }


   public class FillMinAge : List<Academic.AcademicData.GetMinimumAge>
   {
   }
   public FillMinAge GetAgeForAdmission(int courseID, string CCategory)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "courseID", courseID, DbType.Int32);
       objDB.AddParameters(1, "CCategory", CCategory, DbType.String);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetMinimumAgeForAdmission");
       var retval = new FillMinAge();
       if (dr.Read())
       {
           var item = new Academic.AcademicData.GetMinimumAge();
           item.min_age = Education.DataHelper.GetInt(dr, "min_age");
           item.Max_Age = Education.DataHelper.GetInt(dr, "Max_Age");
           retval.Add(item);
       }
       return retval;
   }
   public class FillCityByID : Academic.AcademicData.GetCity
   {
   }
   public FillCityByID GetCity(int cityID)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "CityID", cityID, DbType.Int32);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetCityDetailByID");
       var item = new FillCityByID();
       if (dr.Read())
       {
           item.CityID = Education.DataHelper.GetInt(dr, "CityID");
           item.CountryName = Education.DataHelper.GetString(dr, "CountryName");
           item.StateName = Education.DataHelper.GetString(dr, "StateName");
         }
       return item ;
   }

   public class FillStudentDoc : List<Academic.AcademicData.StudentDocumentDM>
   {
   }
   public FillStudentDoc GetStudentDoc(int studentID)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "studentID", studentID, DbType.Int32);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetDocumentDetailByStudentID");
       var FillSDoc = new FillStudentDoc();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentDocumentDM();
           item.DocumentID = Education.DataHelper.GetInt(dr, "DocumentID");
           item.PassingYr = Education.DataHelper.GetInt(dr, "Passing_Year");
           item.Is_Original = Education.DataHelper.GetString(dr, "Is_Original");
           item.Is_Submitted = Education.DataHelper.GetString(dr, "Is_Submitted");
           item.Issued_By = Education.DataHelper.GetString(dr, "Issued_By");
           item.Remark = Education.DataHelper.GetString(dr, "Remark");
           item.flag = Education.DataHelper.GetString(dr, "flag");
           item.Doc_Serial = Education.DataHelper.GetString(dr, "Doc_Serial");
           item.Percentage = Education.DataHelper.GetString(dr, "Percentage");
           item.Doc_Category = Education.DataHelper.GetString(dr, "Doc_Category");
           item.Document_Name = Education.DataHelper.GetString(dr, "Document_Name");
           FillSDoc.Add(item);
       }
       return FillSDoc;
   }
   
    //-------------------------------------------------------------------------------------------------

   public class FillStudentP : List<Academic.AcademicData.StudentP>
   {
   }
   [OperationContract]
   public FillStudentP FillStudentPChk(string Sessn, int sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "Session", Sessn, DbType.String);
       objDB.AddParameters(1, "SemesterID", sid, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);

       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Student_Promotion_Select");
       FillStudentP listOfStudent = new FillStudentP();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentP();
           item.SName = Education.DataHelper.GetString(dr, "SName");
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           listOfStudent.Add(item);
       }
       objDB.DataReader.Close();
       objDB.Connection.Close();
       objDB = null;
       return listOfStudent;
   }


   public class FillStudentPGrd : List<Academic.AcademicData.StudentPGrd>
   {
   }
   [OperationContract]
   public FillStudentPGrd FillStudentGrd(int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);

       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Student_Promotion_Select");
       //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
       FillStudentPGrd listOfStudent = new FillStudentPGrd();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentPGrd();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
           item.SName = Education.DataHelper.GetString(dr, "SName");
           item.SessionFrom = Education.DataHelper.GetString(dr, "SessionFrom");
           item.YrSemFrom = Education.DataHelper.GetString(dr, "YrSemFrom");
           item.SessionTo = Education.DataHelper.GetString(dr, "SessionTo");
           item.YrSemTo = Education.DataHelper.GetString(dr, "YrSemTo");
           listOfStudent.Add(item);
       }
       objDB.DataReader.Close();
       objDB.Connection.Close();
       objDB = null;
       return listOfStudent;
       //try
       //{
       //    while (dr != null)
       //    {
       //        var item = new Academic.AcademicData.StudentPGrd();
       //        item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
       //        item.IDStudent = Education.DataHelper.GetString(dr, "IDStudent");
       //        item.SName = Education.DataHelper.GetString(dr, "SName");
       //        item.Session = Education.DataHelper.GetString(dr, "Session");
       //        item.YrSem = Education.DataHelper.GetString(dr, "YrSem");
       //        listOfStudent.Add(item);
       //        listOfStudent.Add(item);
       //    }
       //}
       //finally
       //{
       //    objDB.Connection.Close();
       //    objDB.Dispose();
       //}
       //return listOfStudent;

   }

   public class FillAddressLabel : List<Academic.AcademicData.AddressLabelPrintDM>
   {
   }
   [OperationContract]
   public DataTable  FillAddressForLabelPrint(int flag,int StudentID,int LabelType,int CourseID)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       objDB.AddParameters(3, "LabelType", LabelType, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "AddressLabelPrinting");
       }
       finally
       {
           objDB.Connection.Close();
           objDB = null;
       }
       return dt;
    }

   //[OperationContract]
   //public string InsertStudentPromotion(List<Academic.AcademicData.StudentPInsert> objSP,List<Academic.AcademicData.StudentPromotionRegDetailDM> studentDM, Admin.AdministratorData.AuditDM audit)
   //{
   //    NewDAL.DBManager objDB = new DBManager();
   //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
   //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
   //    objDB.Open();
   //    objDB.BeginTransaction();
   //    string retv = "";
   //    string f = "";
   //    try
   //    {
   //        foreach (Academic.AcademicData.StudentPInsert sp in objSP)
   //        {

   //            objDB.CreateParameters(21);
   //            objDB.AddParameters(0, "ID", sp.ID, DbType.Int32);
   //            objDB.AddParameters(1, "InstituteID", sp.InstituteID, DbType.Int32);
   //            objDB.AddParameters(2, "StudentID", sp.StudentID, DbType.Int32);
   //            objDB.AddParameters(3, "CourseID", sp.CourseID, DbType.Int32);
   //            objDB.AddParameters(4, "Batch", sp.Batch, DbType.String);
   //            objDB.AddParameters(5, "SessionC", sp.SessionC, DbType.String);
   //            objDB.AddParameters(6, "SessionFrom", sp.SessionFrom, DbType.String);
   //            objDB.AddParameters(7, "YearFrom", sp.YearFrom, DbType.Int32);
   //            objDB.AddParameters(8, "SemFrom", sp.SemFrom, DbType.Int32);
   //            objDB.AddParameters(9, "SessionTo", sp.SessionTo, DbType.String);
   //            objDB.AddParameters(10, "YearTo", sp.YearTo, DbType.Int32);
   //            objDB.AddParameters(11, "SemTo", sp.SemTo, DbType.Int32);
   //            objDB.AddParameters(12, "StatusU", sp.StatusU, DbType.String);
   //            objDB.AddParameters(13, "StatusI", sp.StatusI, DbType.String);
   //            objDB.AddParameters(14, "EnrollmentNo", sp.EnrollmentNo, DbType.String);
   //            objDB.AddParameters(15, "RollNo", sp.RollNo, DbType.String);
   //            objDB.AddParameters(16, "IsFeeDeposited", sp.IsFeeDeposited, DbType.Int32);
   //            objDB.AddParameters(17, "IsFeePaid", sp.IsFeePaid, DbType.Int32);
   //            objDB.AddParameters(18, "IsCardIssued", sp.IsCardIssued, DbType.Int32);
   //            objDB.AddParameters(19, "IsCourseChange", sp.IsCourseChange, DbType.Int32);
   //            objDB.AddParameters(20, "ExamRollNo", sp.ExamRollNo, DbType.String);
   //            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Promotion_Insert");


   //            foreach (Academic.AcademicData.StudentPromotionRegDetailDM sreg in studentDM)
   //            {
   //                objDB.CreateParameters(23);
   //                objDB.AddParameters(0, "DocID", sreg.DocID, DbType.Int32);
   //                objDB.AddParameters(1, "SrNo", sreg.SrNo, DbType.Int32);
   //                objDB.AddParameters(2, "FeeHeadCode", sreg.FeeHeadCode, DbType.Int32);
   //                objDB.AddParameters(3, "TotalFeeAmount", sreg.TotalFeeAmount, DbType.Decimal);
   //                objDB.AddParameters(4, "BreakoffTime", sreg.BreakoffTime, DbType.String);
   //                objDB.AddParameters(5, "Amount", sreg.Amount, DbType.Decimal);
   //                objDB.AddParameters(6, "UName", sreg.UName, DbType.String);
   //                objDB.AddParameters(7, "UEntDt", sreg.UEntDt, DbType.DateTime);
   //                objDB.AddParameters(8, "DueDate", sreg.DueDate, DbType.DateTime);
   //                objDB.AddParameters(9, "PaidAmount", sreg.PaidAmount, DbType.Decimal);
   //                objDB.AddParameters(10, "BalAmount", sreg.BalAmount, DbType.Decimal);
   //                objDB.AddParameters(11, "ReFund", sreg.ReFund, DbType.Int32);
   //                objDB.AddParameters(12, "CourseID", sreg.CourseID, DbType.Int32);
   //                objDB.AddParameters(13, "SemFrom", sreg.SemFrom, DbType.Int32);
   //                objDB.AddParameters(14, "SemTo", sreg.SemTo, DbType.Int32);
   //                objDB.AddParameters(15, "SessionFrom", sreg.SessionFrom, DbType.String);
   //                objDB.AddParameters(16, "SessionTo", sreg.SessionTo, DbType.String);
   //                objDB.AddParameters(17, "Inst_ID", sreg.Inst_ID, DbType.Int32);
   //                objDB.AddParameters(18, "StatusU", sreg.StatusU, DbType.String);
   //                objDB.AddParameters(19, "StatusI", sreg.StatusI, DbType.String);
   //                objDB.AddParameters(20, "ODC_Charge", sreg.ODC_Charge, DbType.Decimal);
   //                objDB.AddParameters(21, "fromdate", sreg.fromdate, DbType.DateTime);
   //                objDB.AddParameters(22, "FeesubID", sreg.FeesubID, DbType.Int32);
   //                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Promotion_RegDetail");
   //            }

   //        }


   //        objDB.CreateParameters(9);
   //        objDB.AddParameters(0, "ID", 0, DbType.Int32);
   //        objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
   //        objDB.AddParameters(2, "Action", audit.Action, DbType.String);
   //        objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
   //        objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
   //        objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
   //        objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
   //        objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
   //        objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
   //        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
   //        objDB.Transaction.Commit();

   //        retv = "Record saved.";
   //    }
   //    catch (Exception ex)
   //    {
   //        objDB.Transaction.Rollback();
   //        retv = "Unable to save record :-" + ex.Message.ToString();
   //    }
   //    finally
   //    {

   //        objDB.Connection.Close();
   //        objDB.Dispose();
   //    }
   //    return retv;
   //}



   [OperationContract]
   public string InsertStudentPromotion(List<Academic.AcademicData.StudentPInsert> objSP, List<Academic.AcademicData.StudentPromotionRegDetailDM> studentDM, Admin.AdministratorData.AuditDM audit)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentPInsert sp in objSP)
           {
               objDB.CreateParameters(19);
               objDB.AddParameters(0, "ID", sp.ID, DbType.Int32);
               objDB.AddParameters(1, "InstituteID", sp.InstituteID, DbType.Int32);
               objDB.AddParameters(2, "StudentID", sp.StudentID, DbType.Int32);
               objDB.AddParameters(3, "CourseID", sp.CourseID, DbType.Int32);
               objDB.AddParameters(4, "Batch", sp.Batch, DbType.String);
               objDB.AddParameters(5, "SessionC", sp.SessionC, DbType.String);
               objDB.AddParameters(6, "SessionFrom", sp.SessionFrom, DbType.String);
               objDB.AddParameters(7, "YearFrom", sp.YearFrom, DbType.Int32);
               objDB.AddParameters(8, "SemFrom", sp.SemFrom, DbType.Int32);
               objDB.AddParameters(9, "SessionTo", sp.SessionTo, DbType.String);
               objDB.AddParameters(10, "YearTo", sp.YearTo, DbType.Int32);
               objDB.AddParameters(11, "SemTo", sp.SemTo, DbType.Int32);
               objDB.AddParameters(12, "StatusU", sp.StatusU, DbType.String);
               objDB.AddParameters(13, "StatusI", sp.StatusI, DbType.String);
               objDB.AddParameters(14, "RegNo", sp.RegNo, DbType.String);
               objDB.AddParameters(15, "CCategory", sp.CCategory, DbType.String);
               objDB.AddParameters(16, "GroupFrom", sp.GroupFrom, DbType.Int32);
               objDB.AddParameters(17, "GroupTo", sp.GroupTo, DbType.Int32);
               objDB.AddParameters(18, "UserEntryID", sp.UserEntryID, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentPromotionInsert");

               foreach (Academic.AcademicData.StudentPromotionRegDetailDM sreg in studentDM)
               {
                   objDB.CreateParameters(24);
                   objDB.AddParameters(0, "StudentID", sreg.StudentID, DbType.Int32);
                   objDB.AddParameters(1, "FeeID", sreg.FeeID, DbType.Int32);
                   objDB.AddParameters(2, "TotalAmount", sreg.TotalAmount, DbType.Decimal);
                   objDB.AddParameters(3, "PaidAmount", sreg.PaidAmount, DbType.Decimal);
                   objDB.AddParameters(4, "BalanceAmount", sreg.BalanceAmount, DbType.Decimal);
                   objDB.AddParameters(5, "ReFund", sreg.ReFund, DbType.Int32);
                   objDB.AddParameters(6, "CourseID", sreg.CourseID, DbType.Int32);
                   objDB.AddParameters(7, "SemFrom", sreg.SemFrom, DbType.Int32);
                   objDB.AddParameters(8, "SemTo", sreg.SemTo, DbType.Int32);
                   objDB.AddParameters(9, "SessionFrom", sreg.SessionFrom, DbType.String);
                   objDB.AddParameters(10, "SessionTo", sreg.SessionTo, DbType.String);
                   objDB.AddParameters(11, "StatusU", sreg.StatusU, DbType.String);
                   objDB.AddParameters(12, "StatusI", sreg.StatusI, DbType.String);
                   objDB.AddParameters(13, "ODC", sreg.ODC, DbType.Int32);
                   objDB.AddParameters(14, "InstituteID", sreg.InstituteID, DbType.Int32);
                   objDB.AddParameters(15, "FromDate", sreg.FromDate, DbType.DateTime);
                   objDB.AddParameters(16, "FeeSubID", sreg.FeeSubID, DbType.Int32);
                   objDB.AddParameters(17, "Batch", sreg.Batch, DbType.String);
                   objDB.AddParameters(18, "Discount", sreg.Discount, DbType.Decimal);
                   objDB.AddParameters(19, "YearTo", sreg.YearTo, DbType.Int32);
                   objDB.AddParameters(20, "VoucherNo", sreg.VoucherNo, DbType.String);
                   objDB.AddParameters(21, "DueDate", sreg.DueDate, DbType.DateTime);
                   objDB.AddParameters(22, "VNo", sreg.VNo, DbType.DateTime);
                   objDB.AddParameters(23, "EntryDate", sreg.EntryDate, DbType.DateTime);
                   objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentPromotionRegDetailInsert");
               }

           }


           objDB.CreateParameters(9);
           objDB.AddParameters(0, "ID", 0, DbType.Int32);
           objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
           objDB.AddParameters(2, "Action", audit.Action, DbType.String);
           objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
           objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
           objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
           objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
           objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
           objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
           objDB.Transaction.Commit();

           retv = "Students Promoted Successfully..!!";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }



   //public class FillStudentPromotionGrd : List<Academic.AcademicData.StudentPromotionGrd>
   //{
   //}
   //[OperationContract]
   //public FillStudentPromotionGrd FillStudentPrGrd(int flag)
   //{
   //    NewDAL.DBManager objDB = new DBManager();
   //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
   //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
   //    objDB.Open();
   //    objDB.CreateParameters(1);
   //    objDB.AddParameters(0, "flag", flag, DbType.Int32);

   //    IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Student_Promotion_Select");
   //    //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
   //    FillStudentPromotionGrd listOfStudent = new FillStudentPromotionGrd();
   //    while (dr.Read())
   //    {
   //        var item = new Academic.AcademicData.StudentPromotionGrd();
   //        item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
   //        item.ID_Student = Education.DataHelper.GetString(dr, "ID_Student");
   //        item.SName = Education.DataHelper.GetString(dr, "SName");
   //        item.SessionFrom = Education.DataHelper.GetString(dr, "SessionFrom");
   //        item.YrSemFrom = Education.DataHelper.GetString(dr, "YrSemFrom");
   //        item.SessionTo = Education.DataHelper.GetString(dr, "SessionTo");
   //        item.YrSemTo = Education.DataHelper.GetString(dr, "YrSemTo");
   //        listOfStudent.Add(item);
   //    }
   //    objDB.DataReader.Close();
   //    objDB.Connection.Close();
   //    objDB = null;
   //    return listOfStudent;
   //}



   public class FillStudentPromotionGrd : List<Academic.AcademicData.StudentPromotionGrd>
   {
   }
   [OperationContract]
   public FillStudentPromotionGrd FillStudentPrGrd(int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);

       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       //var listOfStudent = new List<Academic.AcademicData.StudentPGrd>();
       FillStudentPromotionGrd listOfStudent = new FillStudentPromotionGrd();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentPromotionGrd();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           listOfStudent.Add(item);
       }
       objDB.DataReader.Close();
       objDB.Connection.Close();
       objDB = null;
       return listOfStudent;
   }




   //public class FillStudentPromotionChk : List<Academic.AcademicData.StudentPromotionList>
   //{
   //}
   //[OperationContract]
   //public FillStudentPromotionChk FillStudentPListChk(string Sessn, int sid, int flag)
   //{
   //    NewDAL.DBManager objDB = new DBManager();
   //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
   //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
   //    objDB.Open();
   //    objDB.CreateParameters(3);
   //    objDB.AddParameters(0, "Session", Sessn, DbType.String);
   //    objDB.AddParameters(1, "SemesterID", sid, DbType.Int32);
   //    objDB.AddParameters(2, "flag", flag, DbType.Int32);

   //    IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Student_Promotion_Select");
   //    FillStudentPromotionChk listOfStudent = new FillStudentPromotionChk();
   //    while (dr.Read())
   //    {
   //        var item = new Academic.AcademicData.StudentPromotionList();
   //        item.SName = Education.DataHelper.GetString(dr, "SName");
   //        item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
   //        listOfStudent.Add(item);
   //    }
   //    objDB.DataReader.Close();
   //    objDB.Connection.Close();
   //    objDB = null;
   //    return listOfStudent;
   //}


   public class FillStudentPromotionChk : List<Academic.AcademicData.StudentPromotionList>
   {
   }
   [OperationContract]
   public FillStudentPromotionChk FillStudentPListChk(int instid, string Sessn, int sid, int yearid, int courseid, int specid, int groupid, int flag)
   {
           NewDAL.DBManager objDB = new DBManager();
           objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
           objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
           objDB.Open();
           objDB.CreateParameters(8);
           objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
           objDB.AddParameters(1, "SessionID", Sessn, DbType.String);
           objDB.AddParameters(2, "Sid", sid, DbType.Int32);
           objDB.AddParameters(3, "yearid", yearid, DbType.Int32);
           objDB.AddParameters(4, "CourseID", courseid, DbType.Int32);
           objDB.AddParameters(5, "Specialization", specid, DbType.Int32);          
           objDB.AddParameters(6, "groupID", groupid, DbType.Int32);
           objDB.AddParameters(7, "flag", flag, DbType.Int32);

           IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
           FillStudentPromotionChk listOfStudent = new FillStudentPromotionChk();
           while (dr.Read())
           {
               var item = new Academic.AcademicData.StudentPromotionList();
               item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
               item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
               item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
               item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
               item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
               item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
               listOfStudent.Add(item);
           }
           objDB.DataReader.Close();
           objDB.Connection.Close();
           objDB = null;
           return listOfStudent;
       }

       
  

   public DataTable FillStudentPromotionRegDetail(int Course, string Category, string Ccategory, string sid, string batch,int inst, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "CourseCode", Course, DbType.Int32);
       objDB.AddParameters(1, "Category", Category, DbType.String);
       objDB.AddParameters(2, "Ccategory", Ccategory, DbType.String);
       objDB.AddParameters(3, "cid", sid, DbType.String);
       objDB.AddParameters(4, "batch", batch, DbType.String);
       objDB.AddParameters(5, "InstituteID", inst, DbType.Int32);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Promotion_Select");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }



   public DataTable FillStudentPromotionReg(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "Student_Promotion_Select");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public string WeekUpdate(Academic.AcademicData.WeekUpdateDM objWk, Admin.AdministratorData.AuditDM audit)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       try
       {
           objDB.CreateParameters(2);
           objDB.AddParameters(0, "WeekID", objWk.WeekID, DbType.Int32);
           objDB.AddParameters(1, "Active", objWk.Active, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Week_Update");
           objDB.CreateParameters(9);
           objDB.AddParameters(0, "ID", 0, DbType.Int32);
           objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
           objDB.AddParameters(2, "Action", audit.Action, DbType.String);
           objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
           objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
           objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
           objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
           objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
           objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
           objDB.Transaction.Commit();
           //if (objFDM.Flag == 1)
           //{
           retv = "Record Saved.";

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   //[OperationContract]
   //public string StudentRegDetailInsert(Academic.AcademicData.StudentRegDetailDM StudentM)
   //{
   //    NewDAL.DBManager objDB = new DBManager();
   //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
   //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
   //    objDB.Open();
   //    objDB.BeginTransaction();
   //    string retv = "";
   //    string f = "";
   //    try
   //    {

   //        objDB.CreateParameters(17);
   //        objDB.AddParameters(0, "StudentID", StudentM.StudentID, DbType.Int32);
   //        objDB.AddParameters(1, "StudentName", StudentM.StudentName, DbType.String);
   //        objDB.AddParameters(2, "FatherName", StudentM.FatherName, DbType.String);
   //        objDB.AddParameters(3, "DateOfBirth", StudentM.DateOfBirth, DbType.DateTime);
   //        objDB.AddParameters(4, "ContactNo", StudentM.ContactNo, DbType.String);
   //        objDB.AddParameters(5, "Category", StudentM.Category, DbType.String);
   //        objDB.AddParameters(6, "AdmissionSource", StudentM.AdmissionSource, DbType.String);
   //        objDB.AddParameters(7, "AdmissionType", StudentM.AdmissionType, DbType.String);
   //        objDB.AddParameters(8, "HostelFacilityReq", StudentM.HostelFacilityReq, DbType.String);
   //        objDB.AddParameters(9, "BusFacilityReq", StudentM.BusFacilityReq, DbType.String);
   //        objDB.AddParameters(10, "RegNo", StudentM.RegNo, DbType.String);
   //        objDB.AddParameters(11, "Diploma", StudentM.Diploma, DbType.String);
   //        objDB.AddParameters(12, "CourseID", StudentM.CourseID, DbType.Int32);
   //        objDB.AddParameters(13, "SessionID", StudentM.SessionID, DbType.String);
   //        objDB.AddParameters(14, "Sid", StudentM.Sid, DbType.Int32);
   //        objDB.AddParameters(15, "StuID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
   //        objDB.AddParameters(16, "RegID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
   //        objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentRegDetail_Insert");

   //        objDB.Transaction.Commit();

   //        string r = objDB.Parameters[16].Value.ToString();
   //        retv = r;
   //    }
   //    catch (Exception ex)
   //    {
   //        objDB.Transaction.Rollback();
   //        retv = "Unable to save record :-" + ex.Message.ToString();
   //    }
   //    finally
   //    {
   //        objDB.Connection.Close();
   //        objDB.Dispose();
   //    }
   //    return retv;
   //}



   [OperationContract]
   public List<Academic.AcademicData.GrdFeeDM> FillGrdFee(int sid, int courseid, string sessionid, int instid, string studenttype, string categoryid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "sid", sid, DbType.Int32);
       objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(4, "StudentType", studenttype, DbType.String);
       objDB.AddParameters(5, "Category", categoryid, DbType.String);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.GrdFeeDM> retItem = new List<Academic.AcademicData.GrdFeeDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.GrdFeeDM();
           item.courseFeeId = Education.DataHelper.GetInt(dr, "courseFeeId");
           item.FeeDetailID = Education.DataHelper.GetInt(dr, "FeeDetailID");
           item.FeeHeadCode = Education.DataHelper.GetString(dr, "FeeHeadCode");
           item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
           item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
           item.BreakoffTime = Education.DataHelper.GetString(dr, "BreakoffTime");
           item.LastDate = Education.DataHelper.GetDateTime(dr, "LastDate");
           item.FeeClass = Education.DataHelper.GetString(dr, "FeeClass");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   public class CheckParameter : List<Academic.AcademicData.CheckIsAuto>
   {
   }
   [OperationContract]
   public CheckParameter ParameterCheck(int InstituteID, string SessionID)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "SessionID", SessionID, DbType.String);

       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "CheckParameter");
       CheckParameter listOfStudent = new CheckParameter();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.CheckIsAuto();
           //item.IsPPSNOAuto = Education.DataHelper.GetInt(dr, "Auto_PPSNO");
           item.IsRCNOAuto = Education.DataHelper.GetInt(dr, "Auto_RECNO");
           listOfStudent.Add(item);
       }
       objDB.DataReader.Close();
       objDB.Connection.Close();
       objDB.Dispose();

       return listOfStudent;
   }



   [OperationContract]
   public string StudentRegDetailTInsert(List<Academic.AcademicData.StudentRegDetailTDM> StudentM)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentRegDetailTDM stdt in StudentM)
           {
               //objDB.CreateParameters(19); 
               objDB.CreateParameters(22);
               objDB.AddParameters(0, "StudentDetailID", stdt.StudentDetailID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", stdt.StudentID, DbType.Int32);
               objDB.AddParameters(2, "FeeID", stdt.FeeID, DbType.Int32);
               objDB.AddParameters(3, "TotalAmount", stdt.TotalAmount, DbType.Decimal);
               objDB.AddParameters(4, "PaidAmount", stdt.PaidAmount, DbType.Decimal);
               objDB.AddParameters(5, "BalanceAmount", stdt.BalanceAmount, DbType.Decimal);
               objDB.AddParameters(6, "Refund", stdt.Refund, DbType.Int32);
               objDB.AddParameters(7, "Status", stdt.Status, DbType.String);
               objDB.AddParameters(8, "ODC", stdt.ODC, DbType.Int32);
               objDB.AddParameters(9, "InstituteID", stdt.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "FeeSubID", stdt.FeeSubID, DbType.Int32);
               objDB.AddParameters(11, "Batch", stdt.Batch, DbType.String);
               objDB.AddParameters(12, "SessionID", stdt.SessionID, DbType.String);
               objDB.AddParameters(13, "Sid", stdt.Sid, DbType.Int32);
               objDB.AddParameters(14, "CourseID", stdt.CourseID, DbType.Int32);
               objDB.AddParameters(15, "YearID", stdt.YearID, DbType.Int32);
               objDB.AddParameters(16, "VoucherNo", stdt.VoucherNo, DbType.String);
               objDB.AddParameters(17, "VNo", stdt.VNo, DbType.Int32);
               objDB.AddParameters(18, "EntryDate", stdt.EntryDate, DbType.DateTime);
               objDB.AddParameters(19, "DebitCredit", stdt.DebitCredit, DbType.String);
               objDB.AddParameters(20, "Month", stdt.Month, DbType.Int32);
               objDB.AddParameters(21, "Narration", stdt.Narration, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentRegDetail_InsertT");
           }

           objDB.Transaction.Commit();
           retv = "Record Saved";
           //string r = objDB.Parameters[16].Value.ToString();
           //retv = r;
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   public DataTable FillAdvAmt(int CourseID, int StudentID, int InstituteID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(2, "InstituteID", InstituteID, DbType.Int32);
       //objDB.AddParameters(3, "SessionID", Session, DbType.String);
       //objDB.AddParameters(3, "Pid", Pid, DbType.Int32);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
       DataTable dt = new DataTable();
       dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       return dt;
   }


   public DataTable FillDetailPGrd(int DocId, int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "StudentId", DocId, DbType.Int32);
       //objDB.AddParameters(1, "Session", Sessn, DbType.String);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }

       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }

       return dt;
   }

   public void FillDetailPrint(GridView grd, int DocId, string Sessn, int sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "StudentId", DocId, DbType.Int32);
       objDB.AddParameters(1, "SessionID", Sessn, DbType.String);
       objDB.AddParameters(2, "Sid", sid, DbType.Int32);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       try
       {


           if (dr != null)
           {
               grd.DataSource = dr;
               grd.DataBind();
           }
           else
           {
               grd.DataSource = null;
               grd.DataBind();
           }
       }
       finally
       {
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
   }


   public DataTable FillFeeDetailTable(int DocId, int InstID, string Sessn, int Sid, string studenttype, string Category, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       DataTable dt = new DataTable();
       try
       {
           objDB.CreateParameters(7);
           objDB.AddParameters(0, "StudentId", DocId, DbType.Int32);
           objDB.AddParameters(1, "instituteid", InstID, DbType.Int32);
           objDB.AddParameters(2, "sessionid", Sessn, DbType.String);
           objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
           objDB.AddParameters(4, "StudentType", studenttype, DbType.String);
           objDB.AddParameters(5, "Category", Category, DbType.String);
           objDB.AddParameters(6, "flag", flag, DbType.Int32);
           //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public string InsertFeeDeposition(List<Academic.AcademicData.FeePaymentTransDM> objFSDM, List<Academic.AcademicData.FeePaymentDetailDM> objFSC, List<Academic.AcademicData.StudentAdvacnceDM> objADF, Admin.AdministratorData.AuditDM audit)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.FeePaymentTransDM fd in objFSDM)
           {
               objDB.CreateParameters(25);
               objDB.AddParameters(0, "FeeTransID", fd.FeeTransID, DbType.Int32);
               objDB.AddParameters(1, "VoucherNo", fd.VoucherNo, DbType.String);
               objDB.AddParameters(2, "RCNO", fd.RCNO, DbType.Int32);
               objDB.AddParameters(3, "PrNo", fd.PrNo, DbType.String);
               objDB.AddParameters(4, "StudentID", fd.StudentID, DbType.Int32);
               objDB.AddParameters(5, "FeeID", fd.FeeID, DbType.Int32);
               objDB.AddParameters(6, "TotalAmount", fd.TotalAmount, DbType.Decimal);
               objDB.AddParameters(7, "SessionID", fd.SessionID, DbType.String);
               objDB.AddParameters(8, "sid", fd.sid, DbType.Int32);
               objDB.AddParameters(9, "InstituteID", fd.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "DueDate", fd.DueDate, DbType.DateTime);
               objDB.AddParameters(11, "FeeSubID", fd.FeeSubID, DbType.Int32);
               objDB.AddParameters(12, "TransDate", fd.TransDate, DbType.DateTime);
               objDB.AddParameters(13, "TransactionState", fd.TransactionState, DbType.String);
               objDB.AddParameters(14, "UName", fd.UName, DbType.String);
               objDB.AddParameters(15, "UEntDate", fd.UEntDate, DbType.DateTime);
               objDB.AddParameters(16, "VNo", fd.VNo, DbType.Int32);
               objDB.AddParameters(17, "TAmt", fd.TAmt, DbType.Decimal);
               objDB.AddParameters(18, "CourseID", fd.CourseID, DbType.Int32);
               objDB.AddParameters(19, "Status", fd.Status, DbType.String);
               objDB.AddParameters(20, "RcnoID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
               objDB.AddParameters(21, "PrnoID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
               objDB.AddParameters(22, "VoucNo", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
               objDB.AddParameters(23, "AccountNoID", fd.AccountNoID, DbType.Int32);
               objDB.AddParameters(24, "Narration", fd.Narration, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeePaymentTransInsert");
           }
           Int32 rcnoid = Int32.Parse(objDB.Parameters[20].Value.ToString());
           string prnoid = objDB.Parameters[21].Value.ToString();
           string vno = objDB.Parameters[22].Value.ToString();

           foreach (Academic.AcademicData.FeePaymentDetailDM ftd in objFSC)
           {
               objDB.CreateParameters(18);
               objDB.AddParameters(0, "FeePayID", ftd.FeePayID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", ftd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "PID", ftd.PID, DbType.Int32);
               objDB.AddParameters(3, "PAmount", ftd.PAmount, DbType.Decimal);
               objDB.AddParameters(4, "DDNO", ftd.DDNO, DbType.Int32);
               objDB.AddParameters(5, "DateP", ftd.DateP, DbType.DateTime);
               objDB.AddParameters(6, "BankID", ftd.BankID, DbType.Int32);
               objDB.AddParameters(7, "FeeSubID", ftd.FeeSubID, DbType.Int32);
               if (rcnoid == 0)
               {
                   objDB.AddParameters(8, "RCNO", ftd.RCNO, DbType.Int32);
               }
               else
               {
                   objDB.AddParameters(8, "RCNO", rcnoid, DbType.Int32);
               }
               if (prnoid == "0")
               {
                   objDB.AddParameters(9, "PrNo", ftd.PrNo, DbType.String);
               }
               else
               {
                   objDB.AddParameters(9, "PrNo", prnoid, DbType.String);
               }

               objDB.AddParameters(10, "InstituteID", ftd.InstituteID, DbType.Int32);
               objDB.AddParameters(11, "TransactionState", ftd.TransactionState, DbType.String);
               objDB.AddParameters(12, "UName", ftd.UName, DbType.String);
               objDB.AddParameters(13, "UEntDate", ftd.UEntDate, DbType.DateTime);
               objDB.AddParameters(14, "FeeID", ftd.FeeID, DbType.Int32);
               //objDB.AddParameters(15, "LastUsed", ftd.LastUsed, DbType.Int32);
               objDB.AddParameters(15, "LastUsed", rcnoid, DbType.Int32);
               if (vno == "0")
               {
                   objDB.AddParameters(16, "VoucherNo", ftd.VoucherNo, DbType.String);
               }
               else
               {
                   objDB.AddParameters(16, "VoucherNo", vno, DbType.String);
               }
               objDB.AddParameters(17, "AccountNoID", ftd.AccountNoID, DbType.Int32);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeePaymentDetailInsert");
           }


           foreach (Academic.AcademicData.StudentAdvacnceDM afd in objADF)
           {
               objDB.CreateParameters(20);
               objDB.AddParameters(0, "Id", afd.Id, DbType.Int32);
               objDB.AddParameters(1, "StudentID", afd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "CourseID", afd.CourseID, DbType.Int32);
               objDB.AddParameters(3, "TotalAmt", afd.TotalAmt, DbType.Decimal);
               objDB.AddParameters(4, "PaidAmt", afd.PaidAmt, DbType.Decimal);
               objDB.AddParameters(5, "BalAmt", afd.BalAmt, DbType.Decimal);
               objDB.AddParameters(6, "IsPaid", afd.IsPaid, DbType.Int32);
               objDB.AddParameters(7, "UName", afd.UName, DbType.String);
               objDB.AddParameters(8, "UEDate", afd.UEDate, DbType.DateTime);
               objDB.AddParameters(9, "InstituteID", afd.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "Session", afd.Session, DbType.String);
               if (rcnoid == 0)
               {
                   objDB.AddParameters(11, "PrnoID", afd.PrnoID, DbType.String);
               }
               else
               {
                   objDB.AddParameters(11, "PrnoID", prnoid, DbType.String);
               }
               if (prnoid == "0")
               {
                   objDB.AddParameters(12, "RcnoID", afd.RcnoID, DbType.Int32);
               }
               else
               {
                   objDB.AddParameters(12, "RcnoID", rcnoid, DbType.Int32);
               }
               //objDB.AddParameters(11, "PrnoID", prnoid, DbType.String);
               //objDB.AddParameters(12, "RcnoID", rcnoid, DbType.Int32);
               objDB.AddParameters(13, "FeeID", afd.FeeID, DbType.Int32);
               objDB.AddParameters(14, "Narration", afd.Narration, DbType.String);
               objDB.AddParameters(15, "AccountNoID", afd.AccountNoID, DbType.Int32);
               objDB.AddParameters(16, "DDNO", afd.DDNO, DbType.Int32);
               objDB.AddParameters(17, "DueDate", afd.DueDate, DbType.DateTime);
               objDB.AddParameters(18, "VoucherNo", afd.VoucherNo, DbType.String);
               objDB.AddParameters(19, "Flag", afd.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Advance_Insert");
           }

           objDB.Transaction.Commit();

           retv = "Record saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentNameRNo> FillStudentNameList(int InstituteID, int CourseID, string sessionid, int Sid, int Specialization, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(4, "Specialization", Specialization, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentNameRNo> retItem = new List<Academic.AcademicData.StudentNameRNo>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentNameRNo();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public string InsertStudentRollNo(List<Academic.AcademicData.StudentRollNoDM> objSRN)
   {
       DbFunctions objFunc = new DbFunctions();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentRollNoDM fd in objSRN)
           {

               objDB.CreateParameters(13);
               objDB.AddParameters(0, "RNID", fd.PrvRNID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", fd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "CourseID", fd.CourseID, DbType.Int32);
               objDB.AddParameters(3, "SessionID", fd.PrvSessionID, DbType.String);
               objDB.AddParameters(4, "Sid", fd.PrvSid, DbType.Int32);
               objDB.AddParameters(5, "InstituteID", fd.InstituteID, DbType.Int32);
               objDB.AddParameters(6, "RollNo", fd.PrvRollNo, DbType.String);
               objDB.AddParameters(7, "MaxCount", fd.MaxCount, DbType.Int32);
               objDB.AddParameters(8, "SpecializationID", fd.SpecializationID, DbType.Int32);
               objDB.AddParameters(9, "UniversityRollNo", fd.UniversityRollNo, DbType.String);
               objDB.AddParameters(10, "Flag", fd.Flag, DbType.String);
               objDB.AddParameters(11, "U_Name", fd.U_Name, DbType.String);
               objDB.AddParameters(12, "UEdate", fd.UEDate, DbType.Date);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentRollPrvNoInsert");

               objDB.CreateParameters(13);
               objDB.AddParameters(0, "RNID", fd.RNID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", fd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "CourseID", fd.CourseID, DbType.Int32);
               objDB.AddParameters(3, "SessionID", fd.SessionID, DbType.String);
               objDB.AddParameters(4, "Sid", fd.Sid, DbType.Int32);
               objDB.AddParameters(5, "InstituteID", fd.InstituteID, DbType.Int32);
               objDB.AddParameters(6, "RollNo", fd.RollNo, DbType.String);
               objDB.AddParameters(7, "MaxCount", fd.MaxCount, DbType.Int32);
               objDB.AddParameters(8, "SpecializationID", fd.SpecializationID, DbType.Int32);
               objDB.AddParameters(9, "UniversityRollNo", fd.UniversityRollNo, DbType.String);
               objDB.AddParameters(10, "Flag", fd.Flag, DbType.String);
               objDB.AddParameters(11, "U_Name", fd.U_Name, DbType.String);
               objDB.AddParameters(12, "UEdate", fd.UEDate, DbType.Date);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentRollNoInsert");


           }

           objDB.Transaction.Commit();
           retv = "Record Saved Successfully.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to Save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public string StudentRegDetailInsert(Academic.AcademicData.StudentRegDetailDM StudentM, Academic.AcademicData.StudentRegStatusDM StudentS)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {

           objDB.CreateParameters(25);
           objDB.AddParameters(0, "StudentID", StudentM.StudentID, DbType.Int32);
           objDB.AddParameters(1, "StudentName", StudentM.StudentName, DbType.String);
           objDB.AddParameters(2, "FatherName", StudentM.FatherName, DbType.String);
           objDB.AddParameters(3, "DateOfBirth", StudentM.DateOfBirth, DbType.DateTime);
           objDB.AddParameters(4, "ContactNo", StudentM.ContactNo, DbType.String);
           objDB.AddParameters(5, "Category", StudentM.Category, DbType.String);
           objDB.AddParameters(6, "AdmissionSource", StudentM.AdmissionSource, DbType.String);
           objDB.AddParameters(7, "AdmissionType", StudentM.AdmissionType, DbType.String);
           objDB.AddParameters(8, "HostelFacilityReq", StudentM.HostelFacilityReq, DbType.String);
           objDB.AddParameters(9, "BusFacilityReq", StudentM.BusFacilityReq, DbType.String);
           objDB.AddParameters(10, "RegNo", StudentM.RegNo, DbType.String);
           objDB.AddParameters(11, "Diploma", StudentM.Diploma, DbType.String);
           objDB.AddParameters(12, "CourseID", StudentM.CourseID, DbType.Int32);
           objDB.AddParameters(13, "SessionID", StudentM.SessionID, DbType.String);
           objDB.AddParameters(14, "Sid", StudentM.Sid, DbType.Int32);
           objDB.AddParameters(15, "InstituteID", StudentM.InstituteID, DbType.Int32);
           objDB.AddParameters(16, "MotherName", StudentM.MotherName, DbType.String);
           objDB.AddParameters(17, "Gender", StudentM.Gender, DbType.String);
           objDB.AddParameters(18, "Status", StudentM.Status, DbType.String);
           objDB.AddParameters(19, "RegDate", StudentM.RegDate, DbType.DateTime);
           objDB.AddParameters(20, "VerifyDate", StudentM.VerifyDate, DbType.DateTime);
           objDB.AddParameters(21, "Specialization", StudentM.Specialization, DbType.String);
           objDB.AddParameters(22, "Flag", StudentM.Flag, DbType.String);
           objDB.AddParameters(23, "StuID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
           objDB.AddParameters(24, "RegID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentRegDetail_Insert");

           int studentid = Convert.ToInt32(objDB.Parameters[23].Value.ToString());
           string r = objDB.Parameters[24].Value.ToString() + "-" + objDB.Parameters[23].Value.ToString();

           objDB.CreateParameters(11);
           objDB.AddParameters(0, "StudentID", studentid, DbType.Int32);
           objDB.AddParameters(1, "Batch", StudentS.Batch, DbType.String);
           objDB.AddParameters(2, "SessionID", StudentS.SessionID, DbType.String);
           objDB.AddParameters(3, "YearID", StudentS.YearID, DbType.String);
           objDB.AddParameters(4, "SemesterID", StudentS.SemesterID, DbType.Int32);
           objDB.AddParameters(5, "RegNo", StudentS.RegNo, DbType.String);
           objDB.AddParameters(6, "Status", StudentS.Status, DbType.String);
           objDB.AddParameters(7, "CourseID", StudentS.CourseID, DbType.Int32);
           objDB.AddParameters(8, "CCategory", StudentS.CCategory, DbType.String);
           objDB.AddParameters(9, "InstituteID", StudentS.InstituteID, DbType.Int32);
           objDB.AddParameters(10, "Flag", StudentS.Flag, DbType.String);
           //objDB.AddParameters(11, "RegID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentStatusInsert");

           objDB.Transaction.Commit();
           retv = r;
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract(IsOneWay = false)]
   public string InsertCoursespecilization(Academic.AcademicData.CourseDM ry, Admin.AdministratorData.AuditDM audit)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       //string f = "";
       try
       {
           objDB.CreateParameters(7);
           objDB.AddParameters(0, "ID", ry.ID, DbType.Int32);
           objDB.AddParameters(1, "CourseId", ry.CourseId, DbType.Int32);
           objDB.AddParameters(2, "SpecilizationID", ry.SpecialisationID, DbType.Int32);
           objDB.AddParameters(3, "Totalintake", ry.Totalintake, DbType.Int32);
           objDB.AddParameters(4, "Batch", ry.Batch, DbType.String);
           objDB.AddParameters(5, "InstituteID", ry.InstituteID, DbType.Int32);
           objDB.AddParameters(6, "flag", ry.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "CourseSpecilization");
           objDB.CreateParameters(9);
           objDB.AddParameters(0, "ID", 0, DbType.Int32);
           objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
           objDB.AddParameters(2, "Action", audit.Action, DbType.String);
           objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
           objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
           objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
           objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
           objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
           objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
           objDB.Transaction.Commit();
           if (ry.Flag == "N")
           {
               retv = "Record saved.";
           }
           else if (ry.Flag == "U")
           {
               retv = "Record Updated Successfully.";
           }
           else
           {
               retv = "Record deleted Successfully.";
           }
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentNamePswdDM> FillPswdStudentNameList(int InstituteID, int CourseID, string sessionid, int Sid, int specid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(4, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentNamePswdDM> retItem = new List<Academic.AcademicData.StudentNamePswdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentNamePswdDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.RNID = Education.DataHelper.GetInt(dr, "RNID");
           item.SPassword = Education.DataHelper.GetString(dr, "SPassword");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   public DataTable FillPswdStudentNameListT(int InstituteID, int CourseID, string sessionid, int Sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       DataTable dt = new DataTable();
       try
       {
           objDB.CreateParameters(5);
           objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
           objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
           objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
           objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
           objDB.AddParameters(4, "flag", flag, DbType.Int32);
           //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentVerifyDetailDM> FillVerifyStudentDetail(int InstituteID, int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentVerifyDetailDM> retItem = new List<Academic.AcademicData.StudentVerifyDetailDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentVerifyDetailDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.DateOfBirth = Education.DataHelper.GetDateTime(dr, "DateOfBirth");
           item.ContactNo = Education.DataHelper.GetString(dr, "ContactNo");
           item.Category = Education.DataHelper.GetString(dr, "Category");
           item.AdmissionSource = Education.DataHelper.GetString(dr, "AdmissionSource");
           item.AdmissionType = Education.DataHelper.GetString(dr, "AdmissionType");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
           item.MotherName = Education.DataHelper.GetString(dr, "MotherName");
           item.Gender = Education.DataHelper.GetString(dr, "Gender");
           item.RegDate = Education.DataHelper.GetDateTime(dr, "RegDate");
           item.Specialization = Education.DataHelper.GetString(dr, "Specialization");
           item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
           item.YrSem = Education.DataHelper.GetString(dr, "YrSem");
           item.ACTN_No = Education.DataHelper.GetString(dr, "ACTN_No");
           item.Sid = Education.DataHelper.GetInt(dr, "Sid");
           item.Courseid = Education.DataHelper.GetInt(dr, "Courseid");
           item.Batch = Education.DataHelper.GetString(dr, "Batch");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public string StudentVerifyInsert(Academic.AcademicData.StudentVerifyInsertDM StudentM)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {

           objDB.CreateParameters(37);
           objDB.AddParameters(0, "SDocID", StudentM.SDocID, DbType.Int32);
           objDB.AddParameters(1, "StudentID", StudentM.StudentID, DbType.Int32);
           objDB.AddParameters(2, "InstituteID", StudentM.InstituteID, DbType.Int32);
           objDB.AddParameters(3, "CourseID", StudentM.CourseID, DbType.Int32);
           objDB.AddParameters(4, "SessionID", StudentM.SessionID, DbType.String);
           objDB.AddParameters(5, "Sid", StudentM.Sid, DbType.Int32);
           objDB.AddParameters(6, "AllotmentLetter", StudentM.AllotmentLetter, DbType.String);
           objDB.AddParameters(7, "PhotoAdmitCard", StudentM.PhotoAdmitCard, DbType.String);
           objDB.AddParameters(8, "SignatureAdmitCard", StudentM.SignatureAdmitCard, DbType.String);
           objDB.AddParameters(9, "ProofUPResident", StudentM.ProofUPResident, DbType.String);
           objDB.AddParameters(10, "ProofCategory", StudentM.ProofCategory, DbType.String);
           objDB.AddParameters(11, "AcademicGap", StudentM.AcademicGap, DbType.String);
           objDB.AddParameters(12, "CertificateMedicalFitness", StudentM.CertificateMedicalFitness, DbType.String);
           objDB.AddParameters(13, "ProofCounsellingFee", StudentM.ProofCounsellingFee, DbType.String);
           objDB.AddParameters(14, "ProofAdmissionFee", StudentM.ProofAdmissionFee, DbType.String);
           objDB.AddParameters(15, "MigrationForm", StudentM.MigrationForm, DbType.String);
           objDB.AddParameters(16, "SubCategory", StudentM.SubCategory, DbType.String);
           objDB.AddParameters(17, "Eligibility", StudentM.Eligibility, DbType.String);
           objDB.AddParameters(18, "HSProof", StudentM.HSProof, DbType.String);
           objDB.AddParameters(19, "HSPercentage", StudentM.HSPercentage, DbType.Decimal);
           objDB.AddParameters(20, "INTProof", StudentM.HSProof, DbType.String);
           objDB.AddParameters(21, "INTPercentage", StudentM.INTPercentage, DbType.Decimal);
           objDB.AddParameters(22, "DipProof", StudentM.DipProof, DbType.String);
           objDB.AddParameters(23, "DipPercentage", StudentM.DipPercentage, DbType.Decimal);
           objDB.AddParameters(24, "GradProof", StudentM.GradProof, DbType.String);
           objDB.AddParameters(25, "GradPercentage", StudentM.GradPercentage, DbType.Decimal);
           objDB.AddParameters(26, "MCAMathsProof", StudentM.MCAMathsProof, DbType.String);
           objDB.AddParameters(27, "MathsObtained", StudentM.MathsObtained, DbType.Decimal);
           objDB.AddParameters(28, "PhysicsObtained", StudentM.PhysicsObtained, DbType.Decimal);
           objDB.AddParameters(29, "ChemistryObtained", StudentM.ChemistryObtained, DbType.Decimal);
           objDB.AddParameters(30, "EnglishObtained", StudentM.EnglishObtained, DbType.Decimal);
           objDB.AddParameters(31, "AggregatePCM", StudentM.AggregatePCM, DbType.Decimal);
           objDB.AddParameters(32, "AffidavitStudent", StudentM.AffidavitStudent, DbType.String);
           objDB.AddParameters(33, "AffidavitParent", StudentM.AffidavitParent, DbType.String);
           objDB.AddParameters(34, "CharacterCeritificate", StudentM.CharacterCeritificate, DbType.String);
           objDB.AddParameters(35, "ProofSubCategory", StudentM.ProofSubCategory, DbType.String);
           objDB.AddParameters(36, "Flag", StudentM.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDocumentDetailInsert");
           objDB.Transaction.Commit();
           retv = "Document details submitted successfully..!!";

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentDetailCityDM> FillStudentDetailCity(int cityid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "CityID", cityid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentDetailCityDM> retItem = new List<Academic.AcademicData.StudentDetailCityDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentDetailCityDM();
           item.statename = Education.DataHelper.GetString(dr, "statename");
           item.countryname = Education.DataHelper.GetString(dr, "countryname");
           item.stateid = Education.DataHelper.GetInt(dr, "stateid");
           item.countryid = Education.DataHelper.GetInt(dr, "countryid");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   public DataTable FillAcademicQualification(int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       DataTable dt = new DataTable();
       try
       {
           objDB.CreateParameters(1);
           objDB.AddParameters(0, "flag", flag, DbType.Int32);
           //SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public string StudentDetailEntryInsert(Academic.AcademicData.StudentDetailEntryDM StudentD, List<Academic.AcademicData.StudentAcademicDetailDM> StudentA, Academic.AcademicData.StudentFamilyDetailDM StudentF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {

           objDB.CreateParameters(39);
           objDB.AddParameters(0, "StDetailID", StudentD.StDetailID, DbType.Int32);
           objDB.AddParameters(1, "StudentID", StudentD.StudentID, DbType.Int32);
           objDB.AddParameters(2, "Nationality", StudentD.Nationality, DbType.String);
           objDB.AddParameters(3, "BloodGroup", StudentD.BloodGroup, DbType.String);
           objDB.AddParameters(4, "Email", StudentD.Email, DbType.String);
           objDB.AddParameters(5, "Photo", StudentD.Photo, DbType.Binary);
           objDB.AddParameters(6, "CAddress", StudentD.CAddress, DbType.String);
           objDB.AddParameters(7, "CCityID", StudentD.CCityID, DbType.Int32);
           objDB.AddParameters(8, "CStateID", StudentD.CStateID, DbType.Int32);
           objDB.AddParameters(9, "CCountryID", StudentD.CCountryID, DbType.Int32);
           objDB.AddParameters(10, "CZipCode", StudentD.CZipCode, DbType.Int32);
           objDB.AddParameters(11, "PAddress", StudentD.PAddress, DbType.String);
           objDB.AddParameters(12, "PCityID", StudentD.PCityID, DbType.Int32);
           objDB.AddParameters(13, "PStateID", StudentD.PStateID, DbType.Int32);
           objDB.AddParameters(14, "PCountryID", StudentD.PCountryID, DbType.Int32);
           objDB.AddParameters(15, "PZipCode", StudentD.PZipCode, DbType.Int32);
           objDB.AddParameters(16, "MotherName", StudentD.MotherName, DbType.String);
           objDB.AddParameters(17, "FatherContactNo", StudentD.FatherContactNo, DbType.String);
           objDB.AddParameters(18, "LandlineNo", StudentD.LandlineNo, DbType.String);
           objDB.AddParameters(19, "StudentName", StudentD.StudentName, DbType.String);
           objDB.AddParameters(20, "FatherName", StudentD.FatherName, DbType.String);
           objDB.AddParameters(21, "Contact", StudentD.Contact, DbType.String);//AlternateContact


           objDB.AddParameters(22, "RollNo", StudentD.RollNo, DbType.String);
           objDB.AddParameters(23, "UniversityRollNo", StudentD.UniversityRollNo, DbType.String);
           objDB.AddParameters(24, "Specialization", StudentD.Specialization, DbType.String);
           objDB.AddParameters(25, "DateOfBirth", StudentD.DateOfBirth, DbType.DateTime);
           objDB.AddParameters(26, "AdmissionSource", StudentD.AdmissionSource, DbType.String);
           objDB.AddParameters(27, "Gender", StudentD.Gender, DbType.String);
           objDB.AddParameters(28, "Category", StudentD.Category, DbType.String);
           objDB.AddParameters(29, "Hostel", StudentD.Hostel, DbType.String);
           objDB.AddParameters(30, "Bus", StudentD.Bus, DbType.String);
           objDB.AddParameters(31, "RegDate", StudentD.RegDate, DbType.DateTime);
           objDB.AddParameters(32, "PassOutDate", StudentD.PassOutDate, DbType.DateTime);
           objDB.AddParameters(33, "Signature", StudentD.Signature, DbType.Binary);
           objDB.AddParameters(34, "Flag", StudentD.Flag, DbType.String);

           objDB.AddParameters(35, "AlternateContact", StudentD.AlternateContact, DbType.String);
           objDB.AddParameters(36, "EntranceScore", StudentD.EntranceScore, DbType.Decimal);
           objDB.AddParameters(37, "StDetailIDD", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
           objDB.AddParameters(38, "AlternateEmail", StudentD.AlternateEmail, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDetailEntryInsert");

           int stid = Int32.Parse(objDB.Parameters[37].Value.ToString());

           foreach (Academic.AcademicData.StudentAcademicDetailDM sa in StudentA)
           {
               objDB.CreateParameters(17);
               objDB.AddParameters(0, "StuADetailID", sa.StuADetailID, DbType.Int32);
               if (stid != 0)
               {
                   objDB.AddParameters(1, "StuDetailID", stid, DbType.Int32);
               }
               else if (stid == 0)
               {
                   objDB.AddParameters(1, "StuDetailID", sa.StuDetailID, DbType.Int32);
               }
               objDB.AddParameters(2, "StudentID", sa.StudentID, DbType.Int32);
               objDB.AddParameters(3, "QualificationID", sa.QualificationID, DbType.Int32);
               objDB.AddParameters(4, "QualificationDesc", sa.QualificationDesc, DbType.String);
               objDB.AddParameters(5, "SchoolCollege", sa.SchoolCollege, DbType.String);
               objDB.AddParameters(6, "FromYear", sa.FromYear, DbType.String);
               objDB.AddParameters(7, "ToYear", sa.ToYear, DbType.String);
               //objDB.AddParameters(8, "RollNo", sa.RollNo, DbType.String);
               objDB.AddParameters(8, "Gap", sa.Gap, DbType.Int32);
               objDB.AddParameters(9, "RankPercentage", sa.RankPercentage, DbType.Decimal);
               objDB.AddParameters(10, "TotalMarks", sa.TotalMarks, DbType.Decimal);
               objDB.AddParameters(11, "MarksObtained", sa.MarksObtained, DbType.Decimal);
               objDB.AddParameters(12, "Specialization", sa.Specialization, DbType.String);
               objDB.AddParameters(13, "RollNo", sa.RollNo, DbType.String);
               objDB.AddParameters(14, "mode_of_marks", sa.mode_of_marks, DbType.String);
               objDB.AddParameters(15, "Flag", sa.Flag, DbType.String);
               objDB.AddParameters(16, "Division", sa.division, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentAcademicDetailInsert");
           }

           //foreach (Academic.AcademicData.StudentLanguageDM sl in StudentL)
           //{
           //    objDB.CreateParameters(5);
           //    objDB.AddParameters(0, "LanguageID", sl.LanguageID, DbType.Int32);
           //    objDB.AddParameters(1, "StuDetailID", stid, DbType.Int32);
           //    objDB.AddParameters(2, "StudentID", sl.StudentID, DbType.Int32);
           //    objDB.AddParameters(3, "Language", sl.Language, DbType.String);
           //    objDB.AddParameters(4, "LOptions", sl.LOptions, DbType.String);
           //    objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentLanguagesInsert");
           //}

           //foreach (Academic.AcademicData.StudentFamilyDetailDM sa in StudentF)
           //{
           objDB.CreateParameters(22);
           objDB.AddParameters(0, "StuFDetailID", StudentF.StuFDetailID, DbType.Int32);
           objDB.AddParameters(1, "StuDetailID", stid, DbType.Int32);
           objDB.AddParameters(2, "StudentID", StudentF.StudentID, DbType.Int32);
           objDB.AddParameters(3, "FatherName", StudentF.FatherName, DbType.String);
           objDB.AddParameters(4, "FatherOccupation", StudentF.FatherOccupation, DbType.String);
           objDB.AddParameters(5, "FatherDesignation", StudentF.FatherDesignation, DbType.String);
           objDB.AddParameters(6, "FatherDepartment", StudentF.FatherDepartment, DbType.String);
           objDB.AddParameters(7, "FatherIncome", StudentF.FatherIncome, DbType.Decimal);
           objDB.AddParameters(8, "MotherName", StudentF.MotherName, DbType.String);
           objDB.AddParameters(9, "MotherOccupation", StudentF.MotherOccupation, DbType.String);
           objDB.AddParameters(10, "MotherDesignation", StudentF.MotherDesignation, DbType.String);
           objDB.AddParameters(11, "MotherDepartment", StudentF.MotherDepartment, DbType.String);
           objDB.AddParameters(12, "MotherIncome", StudentF.MotherIncome, DbType.Decimal);
           objDB.AddParameters(13, "GuardianName", StudentF.GuardianName, DbType.String);
           objDB.AddParameters(14, "GuardianOccupation", StudentF.GuardianOccupation, DbType.String);
           objDB.AddParameters(15, "GuardianDesignation", StudentF.GuardianDesignation, DbType.String);
           objDB.AddParameters(16, "GuardianDepartment", StudentF.GuardianDepartment, DbType.String);
           objDB.AddParameters(17, "GuardianIncome", StudentF.GuardianIncome, DbType.Decimal);
           objDB.AddParameters(18, "Flag", StudentF.Flag, DbType.String);
           objDB.AddParameters(19, "FAge", StudentF.FAge, DbType.Int32);
           objDB.AddParameters(20, "MAge", StudentF.MAge, DbType.Int32);
           objDB.AddParameters(21, "GAge", StudentF.GAge, DbType.Int32);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentFamilyDetailInsert");
           //}

           objDB.Transaction.Commit();
           retv = "Record details updated successfully...!!";

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   public DataTable FillDetailRcpt(int flag, int StudentID)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       DataTable dt = new DataTable();
       //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }
   public DataTable FillDetailPrint(int flag, int StudentID)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       DataTable dt = new DataTable();
       //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Fee_Deposit_Select");
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");

       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public string InsertStudentPassword(List<Academic.AcademicData.StudentPasswordDM> objSP)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentPasswordDM sd in objSP)
           {
               objDB.CreateParameters(7);
               objDB.AddParameters(0, "PwdID", sd.PwdID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", sd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "SessionID", sd.SessionID, DbType.String);
               objDB.AddParameters(3, "InstituteID", sd.InstituteID, DbType.Int32);
               objDB.AddParameters(4, "UserName", sd.UserName, DbType.String);
               objDB.AddParameters(5, "SPassword", sd.SPassword, DbType.String);
               objDB.AddParameters(6, "PStatus", sd.PStatus, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentPasswordInsert");
           }

           objDB.Transaction.Commit();
           retv = "Record saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public string StudentDiscountApprovalInsert(List<Academic.AcademicData.DiscountApprovalDM> StudentD)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {

           foreach (Academic.AcademicData.DiscountApprovalDM da in StudentD)
           {
               objDB.CreateParameters(11);
               objDB.AddParameters(0, "DiscountID", da.DiscountID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", da.StudentID, DbType.Int32);
               objDB.AddParameters(2, "CourseID", da.CourseID, DbType.Int32);
               objDB.AddParameters(3, "Sid", da.Sid, DbType.Int32);
               objDB.AddParameters(4, "InstituteID", da.InstituteID, DbType.Int32);
               objDB.AddParameters(5, "SessionID", da.SessionID, DbType.String);
               objDB.AddParameters(6, "FeeID", da.FeeID, DbType.Int32);
               objDB.AddParameters(7, "DiscountAmt", da.DiscountAmt, DbType.Decimal);
               objDB.AddParameters(8, "EntryDate", da.EntryDate, DbType.DateTime);
               objDB.AddParameters(9, "YearsNo", da.YearsNo, DbType.Int32);
               objDB.AddParameters(10, "Ret", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentDiscountApprovalInsert");
           }

           if (objDB.Parameters[10].Value.ToString() == "0")
           {
               retv = "Record Not Saved because Discount Amount exceeds than Balance Amount";
           }
           else
           {
               objDB.Transaction.Commit();
               retv = "1";
           }

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }




   [OperationContract]
   public List<Academic.AcademicData.GrdDiscountDM> FillGrdDiscount(int sid, int courseid, string sessionid, int instid, string studenttype, int studentid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "sid", sid, DbType.Int32);
       objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(4, "StudentType", studenttype, DbType.String);
       objDB.AddParameters(5, "StudentID", studentid, DbType.Int32);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.GrdDiscountDM> retItem = new List<Academic.AcademicData.GrdDiscountDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.GrdDiscountDM();
           item.courseId = Education.DataHelper.GetInt(dr, "CourseID");
           item.FeeHeadCode = Education.DataHelper.GetString(dr, "FeeHeadCode");
           item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
           item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount"); 
           item.BalanceAmount = Education.DataHelper.GetDecimal(dr, "BalanceAmount");        
           item.Approved = Education.DataHelper.GetString(dr, "Approved");
           item.DiscountAmt = Education.DataHelper.GetString(dr, "DiscountAmt");           
           item.Discount = Education.DataHelper.GetDecimal(dr, "Discount");
           item.Sid = Education.DataHelper.GetInt(dr, "sid"); 
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public List<Academic.AcademicData.DiscountStudentListDM> FillStudentDiscountList(int studentid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentId", studentid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.DiscountStudentListDM> retItem = new List<Academic.AcademicData.DiscountStudentListDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.DiscountStudentListDM();
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.Category = Education.DataHelper.GetString(dr, "CCategory");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.CourseID = Education.DataHelper.GetInt(dr, "CourseID");
           item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
           item.YearSem = Education.DataHelper.GetString(dr, "YearSem");
           item.Sid = Education.DataHelper.GetInt(dr, "Sid");
           item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
           item.AdmissionType = Education.DataHelper.GetString(dr, "AdmissionType");
           item.ContactNo = Education.DataHelper.GetString(dr, "ContactNo");
           item.CategoryID = Education.DataHelper.GetString(dr, "Category");
           item.AdmType = Education.DataHelper.GetString(dr, "AdmType");
           item.Batch = Education.DataHelper.GetString(dr, "Batch");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }




   public DataTable FillDiscountYrSem(int flag, int courseid, int semid, string batch, int instituteid)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(5);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);       
       objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
       objDB.AddParameters(2, "instituteid", instituteid, DbType.Int32);
       objDB.AddParameters(3, "sid", semid, DbType.Int32);
       objDB.AddParameters(4, "batch", batch, DbType.String);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public string InsertFeedbackM(List<Academic.AcademicData.FeedbackMDM> objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.FeedbackMDM tsv in objF)
           {
               objDB.CreateParameters(12);
               objDB.AddParameters(0, "FeedbackID", tsv.FeedbackID, DbType.Int32);
               objDB.AddParameters(1, "FeedbackTypeID", tsv.FeedbackTypeID, DbType.Int32);
               objDB.AddParameters(2, "FeedbackParamID", tsv.FeedbackParamID, DbType.Int32);
               objDB.AddParameters(3, "SubjectID", tsv.SubjectID, DbType.Int32);
               objDB.AddParameters(4, "SemID", tsv.SemID, DbType.Int32);
               objDB.AddParameters(5, "SubjectCat", tsv.SubjectCat, DbType.Int32);
               objDB.AddParameters(6, "SessionID", tsv.SessionID, DbType.String);
               objDB.AddParameters(7, "CourseID", tsv.CourseID, DbType.Int32);
               objDB.AddParameters(8, "SpecializationID", tsv.SpecializationID, DbType.Int32);
               objDB.AddParameters(9, "InstituteID", tsv.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "EntryDate", tsv.EntryDate, DbType.DateTime);
               objDB.AddParameters(11, "Flag", tsv.Flag, DbType.String);
               retv = tsv.Flag;
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeedbackMInsert");
           }
           if (retv == "I")
           {
               retv = "Record saved.";
           }
           else
           {
               retv = "Record Updated.";
           }
           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }



   [OperationContract]
   public List<Academic.AcademicData.FeedbackMGrdDM> FillGrdFeedback(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.FeedbackMGrdDM> retItem = new List<Academic.AcademicData.FeedbackMGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.FeedbackMGrdDM();
           item.FeedbackID = Education.DataHelper.GetInt(dr, "FeedbackID");
           item.FeedbackType = Education.DataHelper.GetString(dr, "FeedbackType");
           item.FeedbackParameter = Education.DataHelper.GetString(dr, "FeedbackParameter");
           item.FeedbackParamID = Education.DataHelper.GetInt(dr, "FeedbackParamID");
           item.FeedbackTypeID = Education.DataHelper.GetInt(dr, "FeedbackTypeID");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   public DataTable FillFeedbackType(int flag, int instituteid, int feedbackid)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "instituteid", instituteid, DbType.Int32);
       objDB.AddParameters(2, "FeedbackID", feedbackid, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentFeedbackGrdDM> FillGrdSFeedback(int flag, int instid, int type, string sessnid, int courseid, int specid, int semid, int Subjectid)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(8);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(2, "FeedbackTypeID", type, DbType.Int32);
       objDB.AddParameters(3, "SessionID", sessnid, DbType.String);
       objDB.AddParameters(4, "CourseID", courseid, DbType.Int32);
       objDB.AddParameters(5, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(6, "sid", semid, DbType.Int32);
       objDB.AddParameters(7, "Subjectid", Subjectid, DbType.Int32);
       //IDataReader dr = objDB.ExecuteReader(CommandType.Text, "SELECT FeedbackM.FeedbackTypeID, FeedbackM.FeedbackID, FeedbackM.FeedbackParamID,FeedbackParameterM.FeedbackParameter FROM FeedbackM INNER JOIN FeedbackParameterM ON dbo.FeedbackM.FeedbackParamID = dbo.FeedbackParameterM.FeedbackParamID where FeedbackM.InstituteID=@instituteid and FeedbackM.FeedbackTypeID=@FeedbackTypeID and SessionID=@sessionid and CourseID=@courseid and SpecializationID=@Specialization");
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentFeedbackGrdDM> retItem = new List<Academic.AcademicData.StudentFeedbackGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentFeedbackGrdDM();
           item.FeedbackID = Education.DataHelper.GetInt(dr, "FeedbackID");
           item.FeedbackTypeID = Education.DataHelper.GetInt(dr, "FeedbackTypeID");
           item.FeedbackParamID = Education.DataHelper.GetInt(dr, "FeedbackParamID");
           item.FeedbackParameter = Education.DataHelper.GetString(dr, "FeedbackParameter");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }



   [OperationContract]
   public string InsertStudentFeedback(List<Academic.AcademicData.StudentFeedbackDM> objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       //string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentFeedbackDM fb in objF)
           {
               objDB.CreateParameters(19);
               objDB.AddParameters(0, "SFeedbackID", fb.SFeedbackID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", fb.StudentID, DbType.Int32);
               objDB.AddParameters(2, "UserName", fb.UserName, DbType.String);
               objDB.AddParameters(3, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.AddParameters(4, "SessionID", fb.SessionID, DbType.String);
               objDB.AddParameters(5, "CourseID", fb.CourseID, DbType.Int32);
               objDB.AddParameters(6, "SpecializationID", fb.SpecializationID, DbType.Int32);
               objDB.AddParameters(7, "SubjectID", fb.SubjectID, DbType.Int32);
               objDB.AddParameters(8, "FacultyID", fb.FacultyID, DbType.Int32);
               objDB.AddParameters(9, "FeedbackID", fb.FeedbackID, DbType.Int32);
               objDB.AddParameters(10, "FeedbackTypeID", fb.FeedbackTypeID, DbType.Int32);
               objDB.AddParameters(11, "FeedbackParamID", fb.FeedbackParamID, DbType.Int32);
               objDB.AddParameters(12, "FeedbackGradeID", fb.FeedbackGradeID, DbType.Int32);
               objDB.AddParameters(13, "EntryDate", fb.EntryDate, DbType.DateTime);
               objDB.AddParameters(14, "Remarks", fb.Remarks, DbType.String);
               objDB.AddParameters(15, "Semid", fb.Semid, DbType.String);
               objDB.AddParameters(16, "Batchid", fb.Batchid, DbType.String);
               objDB.AddParameters(17, "Updatecount", fb.Updatecount, DbType.String);
               objDB.AddParameters(18, "flag", fb.flag, DbType.String);
               retv = fb.flag;
               //objDB.AddParameters(14, "Ret", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentFeedbackInsert");
           }
           if (retv == "N")
           {
               retv = "Feedback saved.";
           }
           if (retv == "U")
           {
               retv = "Feedback Updated.";
           }

           objDB.Transaction.Commit();


           //if (objDB.Parameters[12].Value.ToString() == "1")
           //{
           //    retv = "Record Not Saved because Last date for Feedback exceeds";
           //}
           //else
           //{
           //    objDB.Transaction.Commit();
           //    retv = "Record saved.";
           //}

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public string InsertOutsourceFeePayment(Academic.AcademicData.OutsourceFeePaymentDM objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           //foreach (Academic.AcademicData.OutsourceFeePaymentDM fb in objF)
           //{
           objDB.CreateParameters(19);
           objDB.AddParameters(0, "OrgFeePayID", objF.OrgFeePayID, DbType.Int32);
           objDB.AddParameters(1, "InstituteID", objF.InstituteID, DbType.Int32);
           objDB.AddParameters(2, "SessionID", objF.SessionID, DbType.String);
           objDB.AddParameters(3, "CourseID", objF.CourseID, DbType.Int32);
           objDB.AddParameters(4, "SpecializationID", objF.SpecializationID, DbType.Int32);
           objDB.AddParameters(5, "Sid", objF.Sid, DbType.Int32);
           objDB.AddParameters(6, "Pid", objF.Pid, DbType.Int32);
           objDB.AddParameters(7, "Organization", objF.Organization, DbType.String);
           objDB.AddParameters(8, "PaidAmt", objF.PaidAmt, DbType.Decimal);
           objDB.AddParameters(9, "EntryDate", objF.EntryDate, DbType.DateTime);
           objDB.AddParameters(10, "DNo", objF.DNo, DbType.Int32);
           objDB.AddParameters(11, "DDate", objF.DDate, DbType.DateTime);
           objDB.AddParameters(12, "BankID", objF.BankID, DbType.Int32);
           objDB.AddParameters(13, "OTotalAmt", objF.OTotalAmt, DbType.Decimal);
           objDB.AddParameters(14, "OPaidAmt", objF.OPaidAmt, DbType.Decimal);
           objDB.AddParameters(15, "OBalAmt", objF.OBalAmt, DbType.Decimal);
           objDB.AddParameters(16, "AccountNo", objF.AccountNo, DbType.String);
           objDB.AddParameters(17, "Narration", objF.Narration, DbType.String);
           objDB.AddParameters(18, "FeeID", objF.FeeID, DbType.Int32);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "OutsourceFeePaymentInsert");
           //}

           objDB.Transaction.Commit();
           retv = "Record saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public List<Academic.AcademicData.OutsourceFeePayGrdDM> FillGrdOutsourceFeePay(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.OutsourceFeePayGrdDM> retItem = new List<Academic.AcademicData.OutsourceFeePayGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.OutsourceFeePayGrdDM();
           item.OrgFeePayID = Education.DataHelper.GetInt(dr, "OrgFeePayID");
           item.PaymentMode = Education.DataHelper.GetString(dr, "PaymentMode");
           item.Organization = Education.DataHelper.GetString(dr, "Organization");
           item.PaidAmt = Education.DataHelper.GetDecimal(dr, "PaidAmt");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public List<Academic.AcademicData.OutsourceFeeAmountDM> FillOutsourceAmount(int instid, string org, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "Organization", org, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.OutsourceFeeAmountDM> retItem = new List<Academic.AcademicData.OutsourceFeeAmountDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.OutsourceFeeAmountDM();
           item.OrgFeePayID = Education.DataHelper.GetInt(dr, "OrgFeePayID");
           item.OBalamt = Education.DataHelper.GetDecimal(dr, "OBalamt");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public List<Academic.AcademicData.StudentOutsourceGrdDM> FillStudentOutsourceGrd(int InstituteID, string sessionid, int CourseID, int Specialization, int Sid, string Category, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(2, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(3, "Specialization", Specialization, DbType.Int32);
       objDB.AddParameters(4, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(5, "Category", Category, DbType.String);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentOutsourceGrdDM> retItem = new List<Academic.AcademicData.StudentOutsourceGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentOutsourceGrdDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.CCategory = Education.DataHelper.GetString(dr, "CCategory");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public string InsertOutsourceFeeDistribution(List<Academic.AcademicData.OutsourceFeeDistributionDM> objF, List<Academic.AcademicData.StudentAdvacnceDM> objA)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.OutsourceFeeDistributionDM fb in objF)
           {
               if (fb.Flag == "I")
               {
                   objDB.CreateParameters(26);
                   objDB.AddParameters(0, "OrgFeeDisID", fb.OrgFeeDisID, DbType.Int32);
                   objDB.AddParameters(1, "InstituteID", fb.InstituteID, DbType.Int32);
                   objDB.AddParameters(2, "SessionID", fb.SessionID, DbType.String);
                   objDB.AddParameters(3, "CourseID", fb.CourseID, DbType.Int32);
                   objDB.AddParameters(4, "SpecializationID", fb.SpecializationID, DbType.Int32);
                   objDB.AddParameters(5, "Sid", fb.Sid, DbType.Int32);
                   objDB.AddParameters(6, "Category", fb.Category, DbType.String);
                   objDB.AddParameters(7, "OrgFeePayID", fb.OrgFeePayID, DbType.Int32);
                   objDB.AddParameters(8, "Organization", fb.Organization, DbType.String);
                   objDB.AddParameters(9, "StudentID", fb.StudentID, DbType.Int32);
                   objDB.AddParameters(10, "SCategory", fb.SCategory, DbType.String);
                   objDB.AddParameters(11, "RegNo", fb.RegNo, DbType.String);
                   objDB.AddParameters(12, "DisAmt", fb.DisAmt, DbType.Decimal);
                   objDB.AddParameters(13, "DisAmtPaid", fb.DisAmtPaid, DbType.Decimal);
                   objDB.AddParameters(14, "DisAmtBalance", fb.DisAmtBalance, DbType.Decimal);
                   objDB.AddParameters(15, "VoucherNo", fb.VoucherNo, DbType.String);
                   objDB.AddParameters(16, "VNo", fb.VNo, DbType.Int32);
                   objDB.AddParameters(17, "EntryDate", fb.EntryDate, DbType.DateTime);
                   objDB.AddParameters(18, "FeeID", fb.FeeID, DbType.Int32);
                   objDB.AddParameters(19, "PrNo", fb.PrNo, DbType.String);
                   objDB.AddParameters(20, "Rcno", fb.Rcno, DbType.Int32);
                   objDB.AddParameters(21, "Narration", fb.Narration, DbType.String);
                   objDB.AddParameters(22, "UName", fb.UName, DbType.String);
                   objDB.AddParameters(23, "LastUsed", fb.LastUsed, DbType.String);
                   objDB.AddParameters(24, "Flag", fb.Flag, DbType.String);
                   objDB.AddParameters(25, "Ret", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
               }
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "OutsourceFeeDistributionInsert");
           }


           foreach (Academic.AcademicData.StudentAdvacnceDM afd in objA)
           {
               objDB.CreateParameters(20);
               objDB.AddParameters(0, "Id", afd.Id, DbType.Int32);
               objDB.AddParameters(1, "StudentID", afd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "CourseID", afd.CourseID, DbType.Int32);
               objDB.AddParameters(3, "TotalAmt", afd.TotalAmt, DbType.Decimal);
               objDB.AddParameters(4, "PaidAmt", afd.PaidAmt, DbType.Decimal);
               objDB.AddParameters(5, "BalAmt", afd.BalAmt, DbType.Decimal);
               objDB.AddParameters(6, "IsPaid", afd.IsPaid, DbType.Int32);
               objDB.AddParameters(7, "UName", afd.UName, DbType.String);
               objDB.AddParameters(8, "UEDate", afd.UEDate, DbType.DateTime);
               objDB.AddParameters(9, "InstituteID", afd.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "Session", afd.Session, DbType.String);
               objDB.AddParameters(11, "PrnoID", afd.PrnoID, DbType.String);
               objDB.AddParameters(12, "RcnoID", afd.RcnoID, DbType.Int32);
               objDB.AddParameters(13, "FeeID", afd.FeeID, DbType.Int32);
               objDB.AddParameters(14, "Narration", afd.Narration, DbType.String);
               objDB.AddParameters(15, "AccountNoID", afd.AccountNoID, DbType.Int32);
               objDB.AddParameters(16, "DDNO", afd.DDNO, DbType.Int32);
               objDB.AddParameters(17, "DueDate", afd.DueDate, DbType.DateTime);
               objDB.AddParameters(18, "VoucherNo", String.Empty, DbType.String);
               objDB.AddParameters(19, "Flag", afd.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Student_Advance_Insert");
               //}
           }

           if (objDB.Parameters[16].Value.ToString() == "1")
           {
               retv = "Record Not Saved because Distributed Amount is exceeding than Total Amount";
           }
           else
           {
               objDB.Transaction.Commit();
               retv = "Record saved.";
           }
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   public DataTable FillDetailPrintF(int DocId, string Sessn, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       DataTable dt = new DataTable();
       try
       {
           objDB.CreateParameters(3);
           objDB.AddParameters(0, "StudentId", DocId, DbType.Int32);
           objDB.AddParameters(1, "SessionID", Sessn, DbType.String);
           objDB.AddParameters(2, "flag", flag, DbType.Int32);
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
       return dt;
   }

   public DataTable FillCategoryAdmission(int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public string InsertCastCategory(Academic.AcademicData.CastCategoryDM objC)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(4);
           objDB.AddParameters(0, "CCategoryID", objC.CCategoryID, DbType.Int32);
           objDB.AddParameters(1, "CCategory", objC.CCategory, DbType.String);
           objDB.AddParameters(2, "CActive", objC.CActive, DbType.String);
           objDB.AddParameters(3, "Flag", objC.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "CastCategoryInsert");

           objDB.Transaction.Commit();
           if (objC.Flag == "I")
           {
               retv = "Record Saved.";
           }
           else
           {
               retv = "Record Updated.";
           }
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public string InsertAdmissionSource(Academic.AcademicData.AdmissionSourceDM objA)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(4);
           objDB.AddParameters(0, "AdmSourceID", objA.AdmSourceID, DbType.Int32);
           objDB.AddParameters(1, "AdmSource", objA.AdmSource, DbType.String);
           objDB.AddParameters(2, "ASActive", objA.ASActive, DbType.String);
           objDB.AddParameters(3, "Flag", objA.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AdmissionSourceInsert");

           objDB.Transaction.Commit();
           if (objA.Flag == "I")
           {
               retv = "Record Saved.";
           }
           else
           {
               retv = "Record Updated.";
           }
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public string InsertAdmissionType(Academic.AcademicData.AdmissionTypeDM objA)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(4);
           objDB.AddParameters(0, "AdmTypeID", objA.AdmTypeID, DbType.Int32);
           objDB.AddParameters(1, "AdmType", objA.AdmType, DbType.String);
           objDB.AddParameters(2, "ATActive", objA.ATActive, DbType.String);
           objDB.AddParameters(3, "Flag", objA.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AdmissionTypeInsert");

           objDB.Transaction.Commit();
           if (objA.Flag == "I")
           {
               retv = "Record Saved.";
           }
           else
           {
               retv = "Record Updated.";
           }
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   public void FillCastCategory(DropDownList ddl, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "CCategory";
           ddl.DataValueField = "CCategoryID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }



   public void FillAdmissionType(DropDownList ddl, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "AdmType";
           ddl.DataValueField = "AdmTypeID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }

   public void FillAdmissionSource(DropDownList ddl, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "AdmSource";
           ddl.DataValueField = "AdmSourceID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }

   [OperationContract(IsOneWay = false)]
   public string InsertSubjectType(Academic.AcademicData.CourseDM ry, Admin.AdministratorData.AuditDM audit)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();

       string retv = "";
       try
       {
           objDB.CreateParameters(4);
           objDB.AddParameters(0, "SubjectCat_ID", ry.ID, DbType.Int32);
           objDB.AddParameters(1, "SubjectCat_Name", ry.CourseName, DbType.String);
           objDB.AddParameters(2, "InstituteID", ry.InstituteID, DbType.Int32);
           objDB.AddParameters(3, "flag", ry.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSubjectType");
           objDB.CreateParameters(9);
           objDB.AddParameters(0, "ID", 0, DbType.Int32);
           objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
           objDB.AddParameters(2, "Action", audit.Action, DbType.String);
           objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
           objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
           objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
           objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
           objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
           objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
           objDB.Transaction.Commit();
           if (ry.Flag == "N")
           {
               retv = "Record saved.";
           }
           else if (ry.Flag == "U")
           {
               retv = "Update successfuly.";
           }
           else if (ry.Flag == "N")
           {
               retv = "Delete successfully";
           }
           //else if (Retsuccess == "4")
           //{
           //    retv = "Record already exists.";
           //}
           else
           {
               retv = "Unable To Saved ";
           }

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   public void FillSubjectType(GridView grd, int InstituteID, string flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.String);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "InsertSubjectType");
       try
       {


           if (dr != null)
           {
               grd.DataSource = dr;
               grd.DataBind();
           }
           else
           {
               grd.DataSource = null;
               grd.DataBind();
           }
       }
       finally
       {
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
   }

   [OperationContract(IsOneWay = false)]
   public string InsertSespecilization(Academic.AcademicData.CourseDM ry, Admin.AdministratorData.AuditDM audit)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string Retsuccess = string.Empty;
       string retv = "";

       try
       {
           objDB.CreateParameters(6);
           objDB.AddParameters(0, "SpecilizationID", ry.ID, DbType.Int32);
           objDB.AddParameters(1, "SpecilisationName", ry.CourseName, DbType.String);
           objDB.AddParameters(2, "shortName", ry.ShortName, DbType.String);
           objDB.AddParameters(3, "InstituteID", ry.InstituteID, DbType.Int32);
           objDB.AddParameters(4, "flag", ry.Flag, DbType.String);
           objDB.AddParameters(5, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertSpecilization");

           // Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
           objDB.CreateParameters(9);
           objDB.AddParameters(0, "ID", 0, DbType.Int32);
           objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
           objDB.AddParameters(2, "Action", audit.Action, DbType.String);
           objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
           objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
           objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
           objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
           objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
           objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
           objDB.Transaction.Commit();
           if (ry.Flag == "N")
           {
               retv = "Record saved.";
           }
           else if (ry.Flag == "U")
           {
               retv = "Update successfuly.";
           }
           else if (ry.Flag == "N")
           {
               retv = "Delete successfully";
           }
           //else if (Retsuccess == "4")
           //{
           //    retv = "Record already exists.";
           //}
           else
           {
               retv = "Unable To Saved ";
           }

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   public void FillSplgrd(GridView grd, int InstituteID, string flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.String);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "InsertSpecilization");
       try
       {


           if (dr != null)
           {
               grd.DataSource = dr;
               grd.DataBind();
           }
           else
           {
               grd.DataSource = null;
               grd.DataBind();
           }
       }
       finally
       {
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
   }

   [OperationContract]
   public string InsertFeedbackTypeM(Academic.AcademicData.FeedbackTypeMDM objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           if (objF.Flag == "I")
           {
               objDB.CreateParameters(5);
               objDB.AddParameters(0, "FeedbackTypeID", objF.FeedbackTypeID, DbType.Int32);
               objDB.AddParameters(1, "FeedbackType", objF.FeedbackType, DbType.String);
               objDB.AddParameters(2, "InstituteID", objF.InstituteID, DbType.Int32);
               objDB.AddParameters(3, "EntryDate", objF.EntryDate, DbType.DateTime);
               objDB.AddParameters(4, "Flag", objF.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeedbackTypeMInsert");
               retv = "Record Saved.";
           }
           else
           {
               objDB.CreateParameters(4);
               objDB.AddParameters(0, "FeedbackTypeID", objF.FeedbackTypeID, DbType.Int32);
               objDB.AddParameters(1, "FeedbackType", objF.FeedbackType, DbType.String);
               objDB.AddParameters(2, "EntryDate", objF.EntryDate, DbType.DateTime);
               objDB.AddParameters(3, "Flag", objF.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeedbackTypeMInsert");
               retv = "Record Updated.";
           }
           //if (objF.Flag == "I")
           //{
           //    retv = "Record saved.";
           //}
           //else
           //{
           //    retv = "Record Updated.";
           //}

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.FeedbackTypeMDM> FillGrdFeedbackTypeGrd(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.FeedbackTypeMDM> retItem = new List<Academic.AcademicData.FeedbackTypeMDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.FeedbackTypeMDM();
           item.FeedbackTypeID = Education.DataHelper.GetInt(dr, "FeedbackTypeID");
           item.FeedbackType = Education.DataHelper.GetString(dr, "FeedbackType");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public string InsertFeedbackGradeM(Academic.AcademicData.FeedbackGradeMDM objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {

           objDB.CreateParameters(6);
           objDB.AddParameters(0, "FeedbackGradeID", objF.FeedbackGradeID, DbType.Int32);
           objDB.AddParameters(1, "FeedbackGrade", objF.FeedbackGrade, DbType.String);
           objDB.AddParameters(2, "InstituteID", objF.InstituteID, DbType.Int32);
           objDB.AddParameters(3, "EntryDate", objF.EntryDate, DbType.DateTime);
           objDB.AddParameters(4, "Flag", objF.Flag, DbType.String);
           objDB.AddParameters(5, "Weightage", objF.Weightage, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeedbackGradeMInsert");
           if (objF.Flag == "I")
           {
               retv = "Record Saved.";
           }
           else if (objF.Flag == "U")
           {
               retv = "Record Updated.";
           }

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract]
   public List<Academic.AcademicData.FeedbackGradeMDM> FillGrdFeedbackGradeGrd(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.FeedbackGradeMDM> retItem = new List<Academic.AcademicData.FeedbackGradeMDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.FeedbackGradeMDM();
           item.FeedbackGradeID = Education.DataHelper.GetInt(dr, "FeedbackGradeID");
           item.FeedbackGrade = Education.DataHelper.GetString(dr, "FeedbackGrade");
           item.Weightage = Education.DataHelper.GetString(dr, "Weightage");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   [OperationContract]
   public string InsertFeedbackParameterM(Academic.AcademicData.FeedbackParameterMDM objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(6);
           objDB.AddParameters(0, "FeedbackParamID", objF.FeedbackParamID, DbType.Int32);
           objDB.AddParameters(1, "FeedbackParameter", objF.FeedbackParameter, DbType.String);
           objDB.AddParameters(2, "InstituteID", objF.InstituteID, DbType.Int32);
           objDB.AddParameters(3, "EntryDate", objF.EntryDate, DbType.DateTime);
           objDB.AddParameters(4, "FeedbackTypeID", objF.FeedbackTypeID, DbType.Int32);
           objDB.AddParameters(5, "Flag", objF.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeedbackParameterMInsert");
           if (objF.Flag == "I")
           {
               retv = "Record Saved.";
           }
           else if (objF.Flag == "U")
           {
               retv = "Record Updated.";
           }

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract]
   public List<Academic.AcademicData.FeedbackParameterMDM> FillGrdFeedbackParamGrd(int instid, int FeedbackTypeID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       objDB.AddParameters(2, "FeedbackTypeID", FeedbackTypeID, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.FeedbackParameterMDM> retItem = new List<Academic.AcademicData.FeedbackParameterMDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.FeedbackParameterMDM();
           item.FeedbackParamID = Education.DataHelper.GetInt(dr, "FeedbackParamID");
           item.FeedbackParameter = Education.DataHelper.GetString(dr, "FeedbackParameter");
           item.FeedbackTypeID = Education.DataHelper.GetInt(dr, "FeedbackTypeID");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   [OperationContract]
   public string InsertFeedbackSchedule(List<Academic.AcademicData.FeedbackScheduleDM> objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.FeedbackScheduleDM tsv in objF)
           {

               objDB.CreateParameters(12);
               objDB.AddParameters(0, "FeedbackScheduleID", tsv.FeedbackScheduleID, DbType.Int32);
               objDB.AddParameters(1, "SessionID", tsv.SessionID, DbType.String);
               objDB.AddParameters(2, "FromDate", tsv.FromDate, DbType.DateTime);
               objDB.AddParameters(3, "ToDate", tsv.ToDate, DbType.DateTime);
               objDB.AddParameters(4, "FeedbackTypeID", tsv.FeedbackTypeID, DbType.Int32);
               objDB.AddParameters(5, "InstituteID", tsv.InstituteID, DbType.Int32);
               objDB.AddParameters(6, "EntryDate", tsv.EntryDate, DbType.DateTime);
               objDB.AddParameters(7, "Flag", tsv.Flag, DbType.String);
               objDB.AddParameters(8, "Semid", tsv.Semid, DbType.Int32);
               objDB.AddParameters(9, "Batchid", tsv.Batchid, DbType.Int32);
               objDB.AddParameters(10, "Courseid", tsv.Courseid, DbType.Int32);
               objDB.AddParameters(11, "Subjectid", tsv.Subjectid, DbType.Int32);
               retv = tsv.Flag;
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeedbackScheduleInsert");
           }
           if (retv == "I")
           {
               retv = "Record saved.";
           }
           else
           {
               retv = "Record Updated.";
           }

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract]
   public List<Academic.AcademicData.FeedbackScheduleDM> FillGrdFeedbackScheduleGrd(int Batchid, int flag, int Subjectid, int Semid)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "instituteid", Batchid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       objDB.AddParameters(2, "Specialization", Subjectid, DbType.Int32);
       objDB.AddParameters(3, "sid", Semid, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.FeedbackScheduleDM> retItem = new List<Academic.AcademicData.FeedbackScheduleDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.FeedbackScheduleDM();
           item.FeedbackScheduleID = Education.DataHelper.GetInt(dr, "FeedbackScheduleID");
           item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
           item.FromDate = Education.DataHelper.GetDateTime(dr, "FromDate");
           item.ToDate = Education.DataHelper.GetDateTime(dr, "ToDate");
           item.FeedbackType = Education.DataHelper.GetString(dr, "FeedbackType");
           item.FeedbackTypeID = Education.DataHelper.GetInt(dr, "FeedbackTypeID");
           item.Batchid = Education.DataHelper.GetInt(dr, "Batchid");
           item.Semid = Education.DataHelper.GetInt(dr, "Semid");
           item.Subjectid = Education.DataHelper.GetInt(dr, "Subjectid");
           item.SubjectName = Education.DataHelper.GetString(dr, "SubjectName");
           item.Batch_Name = Education.DataHelper.GetString(dr, "Batch_Name");

           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   public void FillFeedbackTypeDDL(DropDownList ddl, int flag, int instid, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "FeedbackType";
           ddl.DataValueField = "FeedbackTypeID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }
   public void FillFeedbackParameterDDL(DropDownList ddl, int flag, int instid, int ftypeid, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(2, "FeedbackType", ftypeid, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "FeedbackParameter";
           ddl.DataValueField = "FeedbackParamID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }
   public void FillFeedbackGradeDDL(DropDownList ddl, int flag, int instid, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "FeedbackGrade";
           ddl.DataValueField = "FeedbackGradeID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }
   public void FillFeedbackSubjectDDL(DropDownList ddl, int flag, int instid, int courseid, int specid, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(2, "CourseID", courseid, DbType.Int32);
       objDB.AddParameters(3, "Specialization", specid, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "SubjectCode";
           ddl.DataValueField = "SubjectID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }
   public void FillFeedbackFacultyDDL(DropDownList ddl, int flag, int instid, int subid, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(2, "SubjectID", subid, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "empName";
           ddl.DataValueField = "empId";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }
   [OperationContract]
   public List<Academic.AcademicData.FeedbackMGrdDetailDM> FillGrdFeedbackDetail(int instid, int feedbackid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "FeedbackID", feedbackid, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.FeedbackMGrdDetailDM> retItem = new List<Academic.AcademicData.FeedbackMGrdDetailDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.FeedbackMGrdDetailDM();
           //item.FeedbackID = Education.DataHelper.GetInt(dr, "FeedbackID");
           //item.FeedbackType = Education.DataHelper.GetInt(dr, "FeedbackTypeID");
           //item.FeedbackParameter = Education.DataHelper.GetInt(dr, "FeedbackParameter");
           item.CourseID = Education.DataHelper.GetInt(dr, "CourseID");
           item.SpecializationID = Education.DataHelper.GetInt(dr, "SpecializationID");
           item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public List<Academic.AcademicData.ExamStatusMDM> FillGrdExamStatusM(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.ExamStatusMDM> retItem = new List<Academic.AcademicData.ExamStatusMDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.ExamStatusMDM();
           item.ExamStatusID = Education.DataHelper.GetInt(dr, "ExamStatusID");
           item.ExamStatus = Education.DataHelper.GetString(dr, "ExamStatus");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public string InsertExamStatusM(Academic.AcademicData.ExamStatusMDM objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           if (objF.Flag == "I")
           {
               objDB.CreateParameters(5);
               objDB.AddParameters(0, "ExamStatusID", objF.ExamStatusID, DbType.Int32);
               objDB.AddParameters(1, "ExamStatus", objF.ExamStatus, DbType.String);
               objDB.AddParameters(2, "InstituteID", objF.InstituteID, DbType.Int32);
               objDB.AddParameters(3, "EntryDate", objF.EntryDate, DbType.DateTime);
               objDB.AddParameters(4, "Flag", objF.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ExamStatusMInsert");
               retv = "Record Saved.";
           }
           else
           {
               objDB.CreateParameters(4);
               objDB.AddParameters(0, "ExamStatusID", objF.ExamStatusID, DbType.Int32);
               objDB.AddParameters(1, "ExamStatus", objF.ExamStatus, DbType.String);
               objDB.AddParameters(2, "EntryDate", objF.EntryDate, DbType.DateTime);
               objDB.AddParameters(3, "Flag", objF.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ExamStatusMInsert");
               retv = "Record Updated.";
           }

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentPromotionList> FillGrdExternalExamDetail(int instid, string sessionid, int sid, int courseid, int specid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "SessionID", sessionid, DbType.String);
       objDB.AddParameters(2, "Sid", sid, DbType.Int32);
       objDB.AddParameters(3, "CourseID", courseid, DbType.Int32);
       objDB.AddParameters(4, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentPromotionList> retItem = new List<Academic.AcademicData.StudentPromotionList>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentPromotionList();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   public void FillExamStatus(DropDownList ddl, int instituteid, int flag)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.Command.Parameters.Clear();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instituteid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       try
       {
           if (dr != null)
           {
               ddl.DataSource = dr;
               ddl.DataTextField = "ExamStatus";
               ddl.DataValueField = "ExamStatusID";
               ddl.DataBind();
               //if (ZeroIndexVal != "")
               //{
               //    ddl.Items.Insert(0, ZeroIndexVal);
               //    ddl.Items[0].Value = "0";
               //}
               //else
               //{
               //    ddl.Items.Insert(0, ZeroIndexVal);
               //    ddl.Items[0].Value = "0";
               //}
           }
       }
       finally
       {
           dr.Close();
           dr.Dispose();
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }

   }


   [OperationContract]
   public string InsertExternalExamDetail(List<Academic.AcademicData.ExternalExamDetailDM> objF)
   {
       DbFunctions objFunc = new DbFunctions();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.ExternalExamDetailDM fb in objF)
           {

               objDB.CreateParameters(12);
               objDB.AddParameters(0, "eseresultId", fb.eseresultId, DbType.Int32);
               objDB.AddParameters(1, "sessionId", fb.sessionId, DbType.String);
               objDB.AddParameters(2, "courseId", fb.courseId, DbType.Int32);
               objDB.AddParameters(3, "SpecializationId", fb.SpecializationId, DbType.Int32);
               objDB.AddParameters(4, "yearId", fb.yearId, DbType.Int32);
               objDB.AddParameters(5, "sid", fb.sid, DbType.Int32);
               objDB.AddParameters(6, "studentId", fb.studentId, DbType.Int32);
               objDB.AddParameters(7, "studentName", fb.studentName, DbType.String);
               objDB.AddParameters(8, "status", fb.status, DbType.String);
               objDB.AddParameters(9, "marksObtained", fb.marksObtained, DbType.Int32);
               objDB.AddParameters(10, "percentage", fb.percentage, DbType.Decimal);
               objDB.AddParameters(11, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "iESEresultInsert");


           }

           retv = "External Exam Details Saved  Successfully.";
           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   public void FillBackPaperSubjectCBL(CheckBoxList cbl, int flag, int instid, int courseid, int specid, int sid)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(5);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(2, "CourseID", courseid, DbType.Int32);
       objDB.AddParameters(3, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(4, "Sid", sid, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           cbl.DataSource = dr;
           cbl.DataTextField = "SubjectCode";
           cbl.DataValueField = "SubjectID";
           cbl.DataBind();
       }
       objDB.Connection.Close();
       objDB.Dispose();
   }


   [OperationContract]
   public string InsertBackPaperDetail(List<Academic.AcademicData.BackPaperDetailDM> objF)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.BackPaperDetailDM fb in objF)
           {
               objDB.CreateParameters(6);
               objDB.AddParameters(0, "backpaperId", fb.backpaperId, DbType.Int32);
               objDB.AddParameters(1, "eseresultId", fb.eseresultId, DbType.Int32);
               objDB.AddParameters(2, "noofCP", fb.noofCP, DbType.Int32);
               objDB.AddParameters(3, "subjectId", fb.subjectId, DbType.String);
               objDB.AddParameters(4, "subjectCode", fb.subjectCode, DbType.String);
               objDB.AddParameters(5, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "ibackpaperDetailsInsert");
           }
           retv = "Record Saved.";

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.BackPaperGrdDM> FillGrdBackPaperGrd(int instid, string sessionid, int sid, int courseid, int specid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "SessionID", sessionid, DbType.String);
       objDB.AddParameters(2, "Sid", sid, DbType.Int32);
       objDB.AddParameters(3, "CourseID", courseid, DbType.Int32);
       objDB.AddParameters(4, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.BackPaperGrdDM> retItem = new List<Academic.AcademicData.BackPaperGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.BackPaperGrdDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
           item.eseresultId = Education.DataHelper.GetInt(dr, "eseresultId");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentDetailEntryDM> FillStudentDetailEntryAddress(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentId", StudentID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "Fill_Student_Detail_Entry");
       List<Academic.AcademicData.StudentDetailEntryDM> retItem = new List<Academic.AcademicData.StudentDetailEntryDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentDetailEntryDM();
           item.StDetailID = Education.DataHelper.GetInt(dr, "StDetailID");
           item.Nationality = Education.DataHelper.GetString(dr, "Nationality");
           item.BloodGroup = Education.DataHelper.GetString(dr, "BloodGroup");
           item.Email = Education.DataHelper.GetString(dr, "Email");
           item.AlternateEmail = Education.DataHelper.GetString(dr, "AlternateEmail");
           //item.Photo = Education.DataHelper.GetString(dr, "Photo");
           item.Photo = Education.DataHelper.GetBytes(dr, "Photo");
           item.CAddress = Education.DataHelper.GetString(dr, "CAddress");
           item.CCityID = Education.DataHelper.GetInt(dr, "CCityID");
           item.CStateID = Education.DataHelper.GetInt(dr, "CStateID");
           item.CCountryID = Education.DataHelper.GetInt(dr, "CCountryID");
           item.CZipCode = Education.DataHelper.GetInt(dr, "CZipCode");
           item.PAddress = Education.DataHelper.GetString(dr, "PAddress");
           item.PCityID = Education.DataHelper.GetInt(dr, "PCityID");
           item.PStateID = Education.DataHelper.GetInt(dr, "PStateID");
           item.PCountryID = Education.DataHelper.GetInt(dr, "PCountryID");
           item.PZipCode = Education.DataHelper.GetInt(dr, "PZipCode");
           item.MotherName = Education.DataHelper.GetString(dr, "MotherName");
           item.FatherContactNo = Education.DataHelper.GetString(dr, "FatherContactNo");
           item.LandlineNo = Education.DataHelper.GetString(dr, "LandlineNo");
           item.Signature = Education.DataHelper.GetBytes(dr, "Signature");
           item.AlternateContact = Education.DataHelper.GetString(dr, "AlternateContact");

           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   [OperationContract]
   public List<Academic.AcademicData.StudentAcademicDetailDM> FillStudentDetailEntryAcademic(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentAcademicDetailDM> retItem = new List<Academic.AcademicData.StudentAcademicDetailDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentAcademicDetailDM();
           item.StuADetailID = Education.DataHelper.GetInt(dr, "StuADetailID");
           item.StuDetailID = Education.DataHelper.GetInt(dr, "StuDetailID");
           item.QualificationID = Education.DataHelper.GetInt(dr, "QualificationID");
           item.QualificationDesc = Education.DataHelper.GetString(dr, "QualificationDesc");
           item.SchoolCollege = Education.DataHelper.GetString(dr, "SchoolCollege");
           item.FromYear = Education.DataHelper.GetString(dr, "FromYear");
           item.ToYear = Education.DataHelper.GetString(dr, "ToYear");
           item.Gap = Education.DataHelper.GetInt(dr, "Gap");
           item.RankPercentage = Education.DataHelper.GetDecimal(dr, "RankPercentage");
           item.TotalMarks = Education.DataHelper.GetDecimal(dr, "TotalMarks");
           item.MarksObtained = Education.DataHelper.GetDecimal(dr, "MarksObtained");
           item.Specialization = Education.DataHelper.GetString(dr, "Specialization");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.Mode = Education.DataHelper.GetString(dr, "mode_of_marks");
           item.Division = Education.DataHelper.GetString(dr, "Division");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   [OperationContract]
   public List<Academic.AcademicData.StudentFamilyDetailDM> FillStudentDetailEntryFamily(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentFamilyDetailDM> retItem = new List<Academic.AcademicData.StudentFamilyDetailDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentFamilyDetailDM();
           item.StuFDetailID = Education.DataHelper.GetInt(dr, "StuFDetailID");
           item.StuDetailID = Education.DataHelper.GetInt(dr, "StuDetailID");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");

           item.FAge = Convert.ToInt32(Education.DataHelper.GetString(dr, "FAge"));

           item.FatherOccupation = Education.DataHelper.GetString(dr, "FatherOccupation");
           item.FatherDesignation = Education.DataHelper.GetString(dr, "FatherDesignation");
           item.FatherDepartment = Education.DataHelper.GetString(dr, "FatherDepartment");
           item.FatherIncome = Education.DataHelper.GetDecimal(dr, "FatherIncome");
           item.MotherName = Education.DataHelper.GetString(dr, "MotherName");

           item.MAge = Convert.ToInt32(Education.DataHelper.GetString(dr, "MAge"));

           item.MotherOccupation = Education.DataHelper.GetString(dr, "MotherOccupation");
           item.MotherDesignation = Education.DataHelper.GetString(dr, "MotherDesignation");
           item.MotherDepartment = Education.DataHelper.GetString(dr, "MotherDepartment");
           item.MotherIncome = Education.DataHelper.GetDecimal(dr, "MotherIncome");
           item.GuardianName = Education.DataHelper.GetString(dr, "GuardianName");

           item.GAge = Convert.ToInt32(Education.DataHelper.GetString(dr, "GAge"));

           item.GuardianOccupation = Education.DataHelper.GetString(dr, "GuardianOccupation");
           item.GuardianDesignation = Education.DataHelper.GetString(dr, "GuardianDesignation");
           item.GuardianDepartment = Education.DataHelper.GetString(dr, "GuardianDepartment");
           item.GuardianIncome = Education.DataHelper.GetDecimal(dr, "GuardianIncome");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   public DataTable FillYearsem(string ctype, int courseid, string batchid, string sessnid, int instid)
   {


       NewDAL.DBManager objDB = new DBManager();

       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;

       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);

       objDB.Open();

       objDB.CreateParameters(5);

       objDB.AddParameters(0, "ctype", ctype, DbType.String);

       objDB.AddParameters(1, "courseid", courseid, DbType.Int32);

       objDB.AddParameters(2, "batch", batchid, DbType.String);

       objDB.AddParameters(3, "sessn", sessnid, DbType.String);

       objDB.AddParameters(4, "instid", instid, DbType.Int32);

       DataTable dt = new DataTable();
       //IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "GetYearSem");

       try
       {

           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "GetYearSem");

       }

       finally
       {

           objDB.Connection.Close();

           objDB.Dispose();

       }

       return dt;

   }

   [OperationContract]
   public List<Academic.AcademicData.StudentPromoteFeeDM> FillStudentNamePromoteFee(int InstituteID, int CourseID, string sessionid, int Sid, int Specialization, string admtype, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(4, "Specialization", Specialization, DbType.Int32);
       objDB.AddParameters(5, "StudentType", admtype, DbType.Int32);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentPromoteFeeDM> retItem = new List<Academic.AcademicData.StudentPromoteFeeDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentPromoteFeeDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public string StudentUpdateInsert(Academic.AcademicData.StudentUpdateDM Student)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(7);
           objDB.AddParameters(0, "StudentID", Student.StudentID, DbType.Int32);
           objDB.AddParameters(1, "Category", Student.Category, DbType.String);
           objDB.AddParameters(2, "AdmissionSource", Student.AdmissionSource, DbType.String);
           objDB.AddParameters(3, "AdmissionType", Student.AdmissionType, DbType.String);
           objDB.AddParameters(4, "HostelFacilityReq", Student.HostelFacilityReq, DbType.String);
           objDB.AddParameters(5, "BusFacilityReq", Student.BusFacilityReq, DbType.String);
           objDB.AddParameters(6, "InstituteID", Student.InstituteID, DbType.Int32);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentUpdate");

           objDB.Transaction.Commit();
           retv = "Student Record Updated";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentFeeUpdateDM> FillStudentFeeUpdate(int InstituteID, string sessionid, int CourseID, int Specialization, int Sid, string admtype, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(2, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(3, "Specialization", Specialization, DbType.Int32);
       objDB.AddParameters(4, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(5, "StudentType", admtype, DbType.Int32);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentFeeUpdateDM> retItem = new List<Academic.AcademicData.StudentFeeUpdateDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentFeeUpdateDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.HostelFacilityReq = Education.DataHelper.GetString(dr, "HostelFacilityReq");
           item.BusFacilityReq = Education.DataHelper.GetString(dr, "BusFacilityReq");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public DataTable FillGrdFeeUpdate(int sid, int courseid, string sessionid, int instid, string studenttype, string categoryid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "sid", sid, DbType.Int32);
       objDB.AddParameters(1, "courseid", courseid, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "instituteid", instid, DbType.Int32);
       objDB.AddParameters(4, "StudentType", studenttype, DbType.String);
       objDB.AddParameters(5, "Category", categoryid, DbType.String);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public string InsertAccountMaster(Academic.AcademicData.AccountMasterDM objAM)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(6);
           objDB.AddParameters(0, "AccountNoID", objAM.AccountNoID, DbType.Int32);
           objDB.AddParameters(1, "AccountNo", objAM.AccountNo, DbType.String);
           objDB.AddParameters(2, "BankID", objAM.BankID, DbType.Int32);
           objDB.AddParameters(3, "EntryDate", objAM.EntryDate, DbType.DateTime);
           objDB.AddParameters(4, "InstituteID", objAM.InstituteID, DbType.Int32);
           objDB.AddParameters(5, "flag", objAM.flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "AccountNoMInsert");
           objDB.Transaction.Commit();
           retv = "Record Saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public List<Academic.AcademicData.AccountMasterGrdDM> FillAccountMasterGrd(int InstituteID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.AccountMasterGrdDM> retItem = new List<Academic.AcademicData.AccountMasterGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.AccountMasterGrdDM();
           item.AccountNoID = Education.DataHelper.GetInt(dr, "AccountNoID");
           item.AccountNo = Education.DataHelper.GetString(dr, "AccountNo");
           item.BankName = Education.DataHelper.GetString(dr, "BankName");
           item.BankID = Education.DataHelper.GetInt(dr, "BankID");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   public void FillBank(DropDownList ddl, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(1);
       //objDB.AddParameters(0, "bankreq", bankreq, DbType.String);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "BankName";
           ddl.DataValueField = "BankID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }

   [OperationContract]
   public DataTable FillStudentOutsourceRpt(int InstituteID, string sessionid, int CourseID, int Specialization, int Sid, string Category, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(2, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(3, "Specialization", Specialization, DbType.Int32);
       objDB.AddParameters(4, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(5, "Category", Category, DbType.String);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       // dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }

       return dt;
   }



   public DataTable FillOutSourcePayReport(int InstituteID, string SessionID, int FeeID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
       objDB.AddParameters(2, "FeeID", FeeID, DbType.Int32);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   public DataTable FillStudentDetailReport(int InstituteID, string SessionID, int CourseID, int Specialization, int sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
       objDB.AddParameters(2, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(3, "Specialization", Specialization, DbType.Int32);
       objDB.AddParameters(4, "Sid", sid, DbType.Int32);
       //objDB.AddParameters(5, "Category", Category, DbType.Int32);
       //objDB.AddParameters(6, "StudentType", admtype, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentCourseChangeGrdDM> FillStudentCourseChangeList(int InstituteID, string sessionid, int CourseID, int specid, int Sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(2, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(3, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(4, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentCourseChangeGrdDM> retItem = new List<Academic.AcademicData.StudentCourseChangeGrdDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentCourseChangeGrdDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }



   [OperationContract]
   public string InsertStudentCourseChange(List<Academic.AcademicData.StudentCourseChangeDM> objAM)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentCourseChangeDM fb in objAM)
           {
               objDB.CreateParameters(9);
               objDB.AddParameters(0, "CourseChangeID", fb.CourseChangeID, DbType.Int32);
               objDB.AddParameters(1, "CourseID", fb.CourseID, DbType.Int32);
               objDB.AddParameters(2, "OldSpecializationID", fb.OldSpecializationID, DbType.Int32);
               objDB.AddParameters(3, "NewSpecializationID", fb.NewSpecializationID, DbType.Int32);
               objDB.AddParameters(4, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.AddParameters(5, "SessionID", fb.SessionID, DbType.String);
               objDB.AddParameters(6, "Sid", fb.Sid, DbType.Int32);
               objDB.AddParameters(7, "StudentID", fb.StudentID, DbType.Int32);
               objDB.AddParameters(8, "EntryDate", fb.EntryDate, DbType.DateTime);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentCourseChangeInsert");
           }
           objDB.Transaction.Commit();
           retv = "Record Saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   public DataTable FillStudentPromotionRegDetailP(int Course, string stype, string sessn, int sid, int inst, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "CourseID", Course, DbType.Int32);
       objDB.AddParameters(1, "StudentType", stype, DbType.String);
       objDB.AddParameters(2, "SessionID", sessn, DbType.String);
       objDB.AddParameters(3, "sid", sid, DbType.String);
       //objDB.AddParameters(3, "batch", batch, DbType.String);
       objDB.AddParameters(4, "InstituteID", inst, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   public void FillFeeVoucher(DropDownList ddl, int instid, int studentid, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       //objDB.AddParameters(0, "Sid", sid, DbType.Int32);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       //objDB.AddParameters(1, "CourseID", courseID, DbType.Int32);
       objDB.AddParameters(1, "studentid", studentid, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "VoucherNo";
           ddl.DataValueField = "VoucherNo";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }

   [OperationContract]
   public string OtherFeeDepositionInsert(List<Academic.AcademicData.StudentRegDetailTDM> StudentM, List<Academic.AcademicData.FeePaymentTransDM> objFSDM, List<Academic.AcademicData.FeePaymentDetailDM> objFSC)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.StudentRegDetailTDM stdt in StudentM)
           {
               //objDB.CreateParameters(16);
               objDB.CreateParameters(21);
               objDB.AddParameters(0, "StudentDetailID", stdt.StudentDetailID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", stdt.StudentID, DbType.Int32);
               objDB.AddParameters(2, "FeeID", stdt.FeeID, DbType.Int32);
               objDB.AddParameters(3, "TotalAmount", stdt.TotalAmount, DbType.Decimal);
               objDB.AddParameters(4, "PaidAmount", stdt.PaidAmount, DbType.Decimal);
               objDB.AddParameters(5, "BalanceAmount", stdt.BalanceAmount, DbType.Decimal);
               objDB.AddParameters(6, "Refund", stdt.Refund, DbType.Int32);
               objDB.AddParameters(7, "Status", stdt.Status, DbType.String);
               objDB.AddParameters(8, "ODC", stdt.ODC, DbType.Int32);
               objDB.AddParameters(9, "InstituteID", stdt.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "FeeSubID", stdt.FeeSubID, DbType.Int32);
               objDB.AddParameters(11, "Batch", stdt.Batch, DbType.String);
               objDB.AddParameters(12, "SessionID", stdt.SessionID, DbType.String);
               objDB.AddParameters(13, "Sid", stdt.Sid, DbType.Int32);
               objDB.AddParameters(14, "CourseID", stdt.CourseID, DbType.Int32);
               objDB.AddParameters(15, "YearID", stdt.YearID, DbType.Int32);
               objDB.AddParameters(16, "VoucherNo", stdt.VoucherNo, DbType.String);
               objDB.AddParameters(17, "VNo", stdt.VNo, DbType.Int32);
               objDB.AddParameters(18, "EntryDate", stdt.EntryDate, DbType.DateTime);
               objDB.AddParameters(19, "DebitCredit", stdt.DebitCredit, DbType.String);
               objDB.AddParameters(20, "Month", stdt.Month, DbType.Int32);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentRegDetail_InsertT");
           }

           foreach (Academic.AcademicData.FeePaymentTransDM fd in objFSDM)
           {
               objDB.CreateParameters(25);
               objDB.AddParameters(0, "FeeTransID", fd.FeeTransID, DbType.Int32);
               objDB.AddParameters(1, "VoucherNo", fd.VoucherNo, DbType.String);
               objDB.AddParameters(2, "RCNO", fd.RCNO, DbType.Int32);
               objDB.AddParameters(3, "PrNo", fd.PrNo, DbType.String);
               objDB.AddParameters(4, "StudentID", fd.StudentID, DbType.Int32);
               objDB.AddParameters(5, "FeeID", fd.FeeID, DbType.Int32);
               objDB.AddParameters(6, "TotalAmount", fd.TotalAmount, DbType.Decimal);
               objDB.AddParameters(7, "SessionID", fd.SessionID, DbType.String);
               objDB.AddParameters(8, "sid", fd.sid, DbType.Int32);
               objDB.AddParameters(9, "InstituteID", fd.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "DueDate", fd.DueDate, DbType.DateTime);
               objDB.AddParameters(11, "FeeSubID", fd.FeeSubID, DbType.Int32);
               objDB.AddParameters(12, "TransDate", fd.TransDate, DbType.DateTime);
               objDB.AddParameters(13, "TransactionState", fd.TransactionState, DbType.String);
               objDB.AddParameters(14, "UName", fd.UName, DbType.String);
               objDB.AddParameters(15, "UEntDate", fd.UEntDate, DbType.DateTime);
               objDB.AddParameters(16, "VNo", fd.VNo, DbType.Int32);
               objDB.AddParameters(17, "TAmt", fd.TAmt, DbType.Decimal);
               objDB.AddParameters(18, "CourseID", fd.CourseID, DbType.Int32);
               objDB.AddParameters(19, "Status", fd.Status, DbType.String);
               objDB.AddParameters(20, "RcnoID", "xxxxxxxxxx", DbType.Int32, ParameterDirection.Output);
               objDB.AddParameters(21, "PrnoID", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
               objDB.AddParameters(22, "VoucNo", "xxxxxxxxxx", DbType.String, ParameterDirection.Output);
               objDB.AddParameters(23, "AccountNoID", fd.AccountNoID, DbType.Int32);
               objDB.AddParameters(24, "Narration", fd.Narration, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeePaymentTransInsert");
           }
           Int32 rcnoid = Int32.Parse(objDB.Parameters[20].Value.ToString());
           string prnoid = objDB.Parameters[21].Value.ToString();
           string vno = objDB.Parameters[22].Value.ToString();

           foreach (Academic.AcademicData.FeePaymentDetailDM ftd in objFSC)
           {
               objDB.CreateParameters(18);
               objDB.AddParameters(0, "FeePayID", ftd.FeePayID, DbType.Int32);
               objDB.AddParameters(1, "StudentID", ftd.StudentID, DbType.Int32);
               objDB.AddParameters(2, "PID", ftd.PID, DbType.Int32);
               objDB.AddParameters(3, "PAmount", ftd.PAmount, DbType.Decimal);
               objDB.AddParameters(4, "DDNO", ftd.DDNO, DbType.Int32);
               objDB.AddParameters(5, "DateP", ftd.DateP, DbType.DateTime);
               objDB.AddParameters(6, "BankID", ftd.BankID, DbType.Int32);
               objDB.AddParameters(7, "FeeSubID", ftd.FeeSubID, DbType.Int32);
               objDB.AddParameters(8, "RCNO", rcnoid, DbType.Int32);
               objDB.AddParameters(9, "PrNo", prnoid, DbType.String);
               objDB.AddParameters(10, "InstituteID", ftd.InstituteID, DbType.Int32);
               objDB.AddParameters(11, "TransactionState", ftd.TransactionState, DbType.String);
               objDB.AddParameters(12, "UName", ftd.UName, DbType.String);
               objDB.AddParameters(13, "UEntDate", ftd.UEntDate, DbType.DateTime);
               objDB.AddParameters(14, "FeeID", ftd.FeeID, DbType.Int32);
               objDB.AddParameters(15, "LastUsed", ftd.LastUsed, DbType.Int32);
               objDB.AddParameters(16, "VoucherNo", vno, DbType.String);
               objDB.AddParameters(17, "AccountNoID", ftd.AccountNoID, DbType.Int32);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "FeePaymentDetailInsert");
           }

           objDB.Transaction.Commit();
           retv = "Record Saved";
           //string r = objDB.Parameters[16].Value.ToString();
           //retv = r;
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public DataTable FillMBAStudentReport(int InstituteID, int CourseID, string sessionid, int Sid, string @SubjectCat_Name, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(4, "SubjectCat_Name", SubjectCat_Name, DbType.String);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public List<Academic.AcademicData.EmployeeNatureDM> FillEmployeeNature(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       //objDB.AddParameters(1, "SessionID", sessnid, DbType.String);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       List<Academic.AcademicData.EmployeeNatureDM> retItem = new List<Academic.AcademicData.EmployeeNatureDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.EmployeeNatureDM();
           item.natureID = Education.DataHelper.GetInt(dr, "natureID");
           item.nature = Education.DataHelper.GetString(dr, "nature");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }


   //[OperationContract]
   //public List<Academic.AcademicData.EmpDeptDM> FillEmployeeDepartment(int instid, int flag)
   //{
   //    NewDAL.DBManager objDB = new DBManager();
   //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
   //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
   //    objDB.Open();
   //    objDB.CreateParameters(2);
   //    objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
   //    objDB.AddParameters(1, "flag", flag, DbType.Int32);
   //    IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
   //    List<Academic.AcademicData.EmpDeptDM> retItem = new List<Academic.AcademicData.EmpDeptDM>();
   //    while (dr.Read())
   //    {
   //        var item = new Academic.AcademicData.EmpDeptDM();
   //        item.DepartmentID = Education.DataHelper.GetInt(dr, "DepartmentID");
   //        item.DepartmentName = Education.DataHelper.GetString(dr, "DepartmentName");
   //        retItem.Add(item);
   //    }
   //    objDB.Connection.Close();
   //    objDB.Dispose();
   //    return retItem;
   //}


   [OperationContract]
   public DataTable FillEmployeeDepartment(int instid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillEmployeeDeptList(int instid, int natureid, int DesignationID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "NatureID", natureid, DbType.Int32);
       objDB.AddParameters(2, "DesignationID", DesignationID, DbType.Int32);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public string InsertEmpDept(List<Academic.AcademicData.EmpDeptDM> objCE)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.EmpDeptDM fb in objCE)
           {
               objDB.CreateParameters(10);
               objDB.AddParameters(0, "EmpDeptID", fb.EmpDeptID, DbType.Int32);
               //objDB.AddParameters(1, "SessionID", fb.SessionID, DbType.String);
               objDB.AddParameters(1, "NatureID", fb.NatureID, DbType.Int32);
               objDB.AddParameters(2, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.AddParameters(3, "DesignationID", fb.DesignationID, DbType.Int32);
               objDB.AddParameters(4, "EmployeeID", fb.EmployeeID, DbType.Int32);
               objDB.AddParameters(5, "DepartmentID", fb.DepartmentID, DbType.Int32);
               objDB.AddParameters(6, "Action", fb.Action, DbType.String);
               objDB.AddParameters(7, "Status", fb.Status, DbType.String);
               objDB.AddParameters(8, "EntryDate", fb.EntryDate, DbType.DateTime);
               objDB.AddParameters(9, "UserID", fb.UserID, DbType.String);

               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "EmployeeDepartmentInsert");
           }
           objDB.Transaction.Commit();
           retv = "Record Saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public List<Academic.AcademicData.EmployeeDesignationDM> FillEmpDeptDesignation(int instid, int natureID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "natureID", natureID, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       List<Academic.AcademicData.EmployeeDesignationDM> retItem = new List<Academic.AcademicData.EmployeeDesignationDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.EmployeeDesignationDM();
           item.DesigId = Education.DataHelper.GetInt(dr, "DesigId");
           item.Designation = Education.DataHelper.GetString(dr, "Designation");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   [OperationContract]
   public DataTable FillEmployeeDeptUpdateList(int instid, string action, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "Action", action, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillEmployeeUpdateDeptList(int instid, int EmployeeID, string Action, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "EmployeeID", EmployeeID, DbType.Int32);
       objDB.AddParameters(2, "Action", Action, DbType.String);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public string InsertEmpDeptUpdate(Academic.AcademicData.EmpDeptUpdateDM objED)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           objDB.CreateParameters(1);
           objDB.AddParameters(0, "EmpDeptID", objED.EmpDeptID, DbType.Int32);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "EmployeeDepartmentUpdate");
           objDB.Transaction.Commit();
           retv = "Record Updated.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract]
   public DataTable FillEmployeeDeptReport(int instid, string action, int natureid, int DesignationID, int employeeid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "Action", action, DbType.String);
       objDB.AddParameters(2, "NatureID", natureid, DbType.Int32);
       objDB.AddParameters(3, "DesignationID", DesignationID, DbType.Int32);
       objDB.AddParameters(4, "EmployeeID", employeeid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "EmployeeDepartmentSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillStudentLedgerList(int InstituteID, int CourseID, string sessionid, int SpecializationID, int studentid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "SpecializationID", SpecializationID, DbType.Int32);
       objDB.AddParameters(4, "StudentID", studentid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillStudentLedgerFeeHead(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillStudentLedgerSummary(int StudentID, string sessionid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "SessionID", sessionid, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillStudentLedgerPay(int StudentID, string prno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "PrNo", prno, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillGLReportGrd(int FeeID, DateTime FromDate, DateTime ToDate, int instituteID, string session, String flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(5);
       objDB.AddParameters(0, "FeeID", FeeID, DbType.Int32);
       objDB.AddParameters(1, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(2, "ToDate", ToDate, DbType.DateTime);
       objDB.AddParameters(3, "InstituteID", instituteID, DbType.Int32);
       objDB.AddParameters(4, "SessionID", session, DbType.String);

       DataTable dt = new DataTable();
       if (flag == "12")
       {
           try
           {
               dt = objDB.ExecuteTable(CommandType.StoredProcedure, "HeadWiseReport");
           }
           finally
           {
               objDB.Connection.Close();
               objDB.Dispose();
           }
       }
       else
       {
           try
           {
               dt = objDB.ExecuteTable(CommandType.StoredProcedure, "RefundAmt");
           }
           finally
           {
               objDB.Connection.Close();
               objDB.Dispose();
           }
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillGLReportGrd1(int FeeID,  string sessionid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "FeeID", FeeID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       objDB.AddParameters(2, "SessionID", sessionid, DbType.String);

       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillGLReportPMode(int StudentId, string voucherno, string prno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "StudentID", StudentId, DbType.Int32);
       objDB.AddParameters(1, "VoucherNo", voucherno, DbType.String);
       objDB.AddParameters(2, "PrNo", prno, DbType.String);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }



   public void FillGLFeeHead(DropDownList ddl, int instituteid, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", instituteid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           if (flag == 43)
           {
               ddl.DataTextField = "OutSourceOrg";
               ddl.DataValueField = "OutSourceOrgID";
           }
           else
           {
               ddl.DataTextField = "FeeHeadName";
               ddl.DataValueField = "FeeHeadId";
           }
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }


   [OperationContract]
   public DataTable FillGLReportFeeDue(int StudentId, string voucherno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "StudentID", StudentId, DbType.Int32);
       objDB.AddParameters(1, "VoucherNo", voucherno, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillGLReportCashRecpt(int feeid, int StudentId, string prno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "StudentID", StudentId, DbType.Int32);
       objDB.AddParameters(1, "FeeID", feeid, DbType.Int32);
       objDB.AddParameters(2, "PrNo", prno, DbType.String);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillGLReportCashRecptPMode(int StudentId, string prno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "StudentID", StudentId, DbType.Int32);
       objDB.AddParameters(1, "PrNo", prno, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillStudentLedgerTrans(int StudentID, string voucno, int feeid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "VoucherNo", voucno, DbType.String);
       objDB.AddParameters(2, "FeeID", feeid, DbType.Int32);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   public void FillAccountCashBank(DropDownList ddl, int flag, int instituteid, int bankid, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       //objDB.AddParameters(0, "bankreq", bankreq, DbType.String);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", instituteid, DbType.Int32);
       objDB.AddParameters(2, "BankID", bankid, DbType.Int32);
       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "AccountNo";
           ddl.DataValueField = "AccountNoID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }

   [OperationContract]
   public DataTable FillCashBankPrNo(int accountid, DateTime fromdate, DateTime todate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "AccountNoID", accountid, DbType.Int32);
       objDB.AddParameters(1, "FromDate", fromdate, DbType.Date);
       objDB.AddParameters(2, "ToDate", todate, DbType.Date);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillCashBankFeeHead(string PrNo, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "PrNo", PrNo, DbType.String);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }



   [OperationContract]
   public DataTable FillCashBankSummary(int accountid, DateTime FromDate, DateTime ToDate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "AccountNoID", accountid, DbType.Int32);
       objDB.AddParameters(2, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(3, "ToDate", ToDate, DbType.DateTime);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;

   }

   [OperationContract]
   public DataTable FillStudentRegAccess(string voucherno, int studentid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "VoucherNo", voucherno, DbType.String);
       objDB.AddParameters(1, "StudentID", studentid, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }


   [OperationContract]
   public DataTable FillStudentRegSummary(int studentid, string voucherno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "StudentID", studentid, DbType.Int32);
       objDB.AddParameters(1, "VoucherNo", voucherno, DbType.String);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   public DataTable FillFeePrintStudentDetail(int Rcno, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "Rcno", Rcno, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillCashBankOpeningBal(DateTime FromDate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }



   [OperationContract]
   public DataTable FillCashBankSummaryOpeningBal(int accountid, DateTime FromDate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "AccountNoID", accountid, DbType.Int32);
       objDB.AddParameters(2, "FromDate", FromDate, DbType.DateTime);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }
   [OperationContract]
   public DataTable FillCashBankSummaryAmt(int accountid, int FeeId, DateTime FromDate, DateTime ToDate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(5);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "AccountNoID", accountid, DbType.Int32);
       objDB.AddParameters(2, "FeeID", FeeId, DbType.Int32);
       objDB.AddParameters(3, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(4, "ToDate", ToDate, DbType.DateTime);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }
   [OperationContract]
   public DataTable FillStudentLedgerDetailSummaryList(int InstituteID, int CourseID, string sessionid, int SpecializationID, int Sid, string AdmSrc, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(7);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
       objDB.AddParameters(3, "SpecializationID", SpecializationID, DbType.Int32);
       objDB.AddParameters(4, "Sid", Sid, DbType.Int32);
       objDB.AddParameters(5, "AdmSrc", AdmSrc, DbType.String);
       objDB.AddParameters(6, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillStudentLedgerDetailSummaryAmt(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       //objDB.AddParameters(1, "EntryDate", EntryDate, DbType.DateTime);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   public void FillThirdPartyOrg(DropDownList ddl, int instituteid, int flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "InstituteID", instituteid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);

       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       if (dr.HasRows)
       {
           ddl.DataSource = dr;
           ddl.DataTextField = "OutSourceOrg";
           ddl.DataValueField = "OutSourceOrgID";
           ddl.DataBind();
           if (ZeroIndexVal != "")
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
           else
           {
               ddl.Items.Insert(0, ZeroIndexVal);
               ddl.Items[0].Value = "0";
           }
       }
       else
       {
           ddl.Items.Insert(0, ZeroIndexVal);
           ddl.Items[0].Value = "0";
       }
   }

   //public DataTable FillStudentLedgerDetailSummaryNewList(int InstituteID, int CourseID, string sessionid, int SpecializationID, int Sid, int CasteCategory, int AdmType, DateTime FromDate, DateTime ToDate, int flag)
   //{
   //    NewDAL.DBManager objDB = new DBManager();
   //    objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
   //    objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
   //    objDB.Open();
   //    objDB.CreateParameters(10);
   //    objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
   //    objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
   //    objDB.AddParameters(2, "sessionid", sessionid, DbType.String);
   //    objDB.AddParameters(3, "SpecializationID", SpecializationID, DbType.Int32);
   //    objDB.AddParameters(4, "Sid", Sid, DbType.Int32);
   //    objDB.AddParameters(5, "CasteCategory", CasteCategory, DbType.Int32);
   //    objDB.AddParameters(6, "AdmType", AdmType, DbType.Int32);
   //    objDB.AddParameters(7, "FromDate", FromDate, DbType.DateTime);
   //    objDB.AddParameters(8, "ToDate", ToDate, DbType.DateTime);
   //    objDB.AddParameters(9, "flag", flag, DbType.Int32);
   //    DataTable dt = new DataTable();
   //    try
   //    {
   //        dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
   //    }
   //    finally
   //    {
   //        objDB.Connection.Close();
   //        objDB.Dispose();
   //    }
   //    return dt;
   //}
   [OperationContract]
   public DataTable FillStudentLedgerDetailSummaryNewList(string qry, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "qry", qry, DbType.String);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           //dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
           dt = objDB.ExecuteTable(CommandType.Text, "select * from StudentSummaryReportNVW where ((Status = 'C')or(Status = 'Cancel')or(Status = 'E')or(Status = 'S')or(Status = 'F')) " + qry);
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentVerifyInsertDM> FillVerifyStudentDetailUpdate(int InstituteID, int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentVerifyInsertDM> retItem = new List<Academic.AcademicData.StudentVerifyInsertDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentVerifyInsertDM();
           item.SDocID = Education.DataHelper.GetInt(dr, "SDocID");
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.InstituteID = Education.DataHelper.GetInt(dr, "InstituteID");
           item.CourseID = Education.DataHelper.GetInt(dr, "CourseID");
           item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
           item.Sid = Education.DataHelper.GetInt(dr, "Sid");
           item.AllotmentLetter = Education.DataHelper.GetString(dr, "AllotmentLetter");
           item.PhotoAdmitCard = Education.DataHelper.GetString(dr, "PhotoAdmitCard");
           item.SignatureAdmitCard = Education.DataHelper.GetString(dr, "SignatureAdmitCard");
           item.ProofUPResident = Education.DataHelper.GetString(dr, "ProofUPResident");
           item.ProofCategory = Education.DataHelper.GetString(dr, "ProofCategory");
           item.AcademicGap = Education.DataHelper.GetString(dr, "AcademicGap");
           item.CertificateMedicalFitness = Education.DataHelper.GetString(dr, "CertificateMedicalFitness");
           item.ProofCounsellingFee = Education.DataHelper.GetString(dr, "ProofCounsellingFee");
           item.ProofAdmissionFee = Education.DataHelper.GetString(dr, "ProofAdmissionFee");
           item.MigrationForm = Education.DataHelper.GetString(dr, "MigrationForm");
           item.SubCategory = Education.DataHelper.GetString(dr, "SubCategory");
           item.Eligibility = Education.DataHelper.GetString(dr, "Eligibility");
           item.HSProof = Education.DataHelper.GetString(dr, "HSProof");
           item.HSPercentage = Education.DataHelper.GetDecimal(dr, "HSPercentage");
           item.INTProof = Education.DataHelper.GetString(dr, "INTProof");
           item.INTPercentage = Education.DataHelper.GetDecimal(dr, "INTPercentage");
           item.DipProof = Education.DataHelper.GetString(dr, "DipProof");
           item.DipPercentage = Education.DataHelper.GetDecimal(dr, "DipPercentage");
           item.GradProof = Education.DataHelper.GetString(dr, "GradProof");
           item.GradPercentage = Education.DataHelper.GetDecimal(dr, "GradPercentage");
           item.MCAMathsProof = Education.DataHelper.GetString(dr, "MCAMathsProof");
           item.MathsObtained = Education.DataHelper.GetDecimal(dr, "MathsObtained");
           item.PhysicsObtained = Education.DataHelper.GetDecimal(dr, "PhysicsObtained");
           item.ChemistryObtained = Education.DataHelper.GetDecimal(dr, "ChemistryObtained");
           item.EnglishObtained = Education.DataHelper.GetDecimal(dr, "EnglishObtained");
           item.AggregatePCM = Education.DataHelper.GetDecimal(dr, "AggregatePCM");
           item.AffidavitStudent = Education.DataHelper.GetString(dr, "AffidavitStudent");
           item.AffidavitParent = Education.DataHelper.GetString(dr, "AffidavitParent");
           item.CharacterCeritificate = Education.DataHelper.GetString(dr, "CharacterCeritificate");
           item.ProofSubCategory = Education.DataHelper.GetString(dr, "ProofSubCategory");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public string InsertStudentReRegistration(List<Academic.AcademicData.StudentReRegistration> objF)
   {
       DbFunctions objFunc = new DbFunctions();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       string status = string.Empty;
       try
       {
           foreach (Academic.AcademicData.StudentReRegistration fb in objF)
           {
               status = fb.ReStatus;
               objDB.CreateParameters(13);
               //   objDB.AddParameters(0, "eseresultId", fb.eseresultId, DbType.Int32);
               objDB.AddParameters(0, "sessionId", fb.sessionId, DbType.String);
               objDB.AddParameters(1, "courseId", fb.courseId, DbType.Int32);
               objDB.AddParameters(2, "SpecializationId", fb.SpecializationId, DbType.Int32);
               objDB.AddParameters(3, "yearId", fb.yearId, DbType.Int32);
               objDB.AddParameters(4, "sid", fb.sid, DbType.Int32);
               objDB.AddParameters(5, "studentId", fb.studentId, DbType.Int32);
               objDB.AddParameters(6, "studentName", fb.studentName, DbType.String);
               objDB.AddParameters(7, "ReStatus", fb.ReStatus, DbType.String);
               //    objDB.AddParameters(9, "marksObtained", fb.marksObtained, DbType.Int32);
               objDB.AddParameters(8, "Ression", fb.Ression, DbType.String);
               objDB.AddParameters(9, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "ReYearid", fb.Reyearid, DbType.Int32);
               objDB.AddParameters(11, "ReSid", fb.ReSid, DbType.Int32);
               objDB.AddParameters(12, "Remarks", fb.Remarks, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_Student_ReReg_Ex");

               objDB.CreateParameters(12);
               objDB.AddParameters(0, "StudentID", fb.studentId, DbType.Int32);
               objDB.AddParameters(1, "Batch", fb.Batch, DbType.String);
               objDB.AddParameters(2, "SessionID", fb.Ression, DbType.String);
               objDB.AddParameters(3, "YearID", fb.Reyearid, DbType.String);
               objDB.AddParameters(4, "SemesterID", fb.ReSid, DbType.Int32);
               objDB.AddParameters(5, "RegNo", fb.RegNo, DbType.String);
               objDB.AddParameters(6, "Status", "C", DbType.String);
               objDB.AddParameters(7, "CourseID", fb.courseId, DbType.Int32);
               objDB.AddParameters(8, "CCategory", fb.CCategory, DbType.String);
               objDB.AddParameters(9, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.AddParameters(10, "Flag", "I", DbType.String);
               objDB.AddParameters(11, "Result", fb.ReStatus , DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentStatusInsertReReg");

               objFunc.ExecuteDML("Update StudentDocumentDetail set SessionId='" + fb.Ression + "',Sid='" + fb.ReSid + "' where studentid='" + fb.studentId + "'");

           }
           retv = "Student " + status + " Registered Successfully.";

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   public void FillExamStatusStop(DropDownList ddl, int instituteid, string flag)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.Command.Parameters.Clear();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instituteid, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.String);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Sp_ExternalExamStatus_Stop");
       try
       {
           if (dr != null)
           {
               ddl.DataSource = dr;
               ddl.DataTextField = "ExamStatus";
               ddl.DataValueField = "ExamStatusID";
               ddl.DataBind();
               //if (ZeroIndexVal != "")
               //{
               //    ddl.Items.Insert(0, ZeroIndexVal);
               //    ddl.Items[0].Value = "0";
               //}
               //else
               //{
               //    ddl.Items.Insert(0, ZeroIndexVal);
               //    ddl.Items[0].Value = "0";
               //}
           }
       }
       finally
       {
           dr.Close();
           dr.Dispose();
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }

   }
   [OperationContract]
   public string InsertExternalExamDetailStop(List<Academic.AcademicData.ExternalExamDetailDM> objF)
   {
       DbFunctions objFunc = new DbFunctions();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       string f = "";
       try
       {
           foreach (Academic.AcademicData.ExternalExamDetailDM fb in objF)
           {
               objDB.CreateParameters(13);
               objDB.AddParameters(0, "eseresultId", fb.eseresultId, DbType.Int32);
               objDB.AddParameters(1, "sessionId", fb.sessionId, DbType.String);
               objDB.AddParameters(2, "courseId", fb.courseId, DbType.Int32);
               objDB.AddParameters(3, "SpecializationId", fb.SpecializationId, DbType.Int32);
               objDB.AddParameters(4, "yearId", fb.yearId, DbType.Int32);
               objDB.AddParameters(5, "sid", fb.sid, DbType.Int32);
               objDB.AddParameters(6, "studentId", fb.studentId, DbType.Int32);
               objDB.AddParameters(7, "studentName", fb.studentName, DbType.String);
               objDB.AddParameters(8, "status", fb.status, DbType.String);
               objDB.AddParameters(9, "marksObtained", fb.marksObtained, DbType.Int32);
               objDB.AddParameters(10, "percentage", fb.percentage, DbType.Decimal);
               objDB.AddParameters(11, "InstituteID", fb.InstituteID, DbType.Int32);
               objDB.AddParameters(12, "Remarks", fb.Remarks, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "iESEresultInsertStop");

           }

           retv = "Record Saved Successfully.";

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract]
   public List<Academic.AcademicData.StudentPromotionList> FillGrdExternalExamDetailStop(int instid, string sessionid, int sid, int courseid, int specid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(6);
       objDB.AddParameters(0, "InstituteID", instid, DbType.Int32);
       objDB.AddParameters(1, "SessionID", sessionid, DbType.String);
       objDB.AddParameters(2, "Sid", sid, DbType.Int32);
       objDB.AddParameters(3, "CourseID", courseid, DbType.Int32);
       objDB.AddParameters(4, "Specialization", specid, DbType.Int32);
       objDB.AddParameters(5, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "Sp_ExternalExamStatus_Stop");
       List<Academic.AcademicData.StudentPromotionList> retItem = new List<Academic.AcademicData.StudentPromotionList>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentPromotionList();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   public void FillYear(DropDownList ddl, int instituteid, int Flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.Command.Parameters.Clear();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "instituteid", instituteid, DbType.Int32);
       objDB.AddParameters(1, "Flag", Flag, DbType.Int32);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       try
       {
           if (dr != null)
           {
               ddl.DataSource = dr;
               ddl.DataTextField = "Year";
               ddl.DataValueField = "Year";
               ddl.DataBind();
               if (ZeroIndexVal != "")
               {
                   ddl.Items.Insert(0, ZeroIndexVal);
                   ddl.Items[0].Value = "0";
               }
               else
               {
                   ddl.Items.Insert(0, ZeroIndexVal);
                   ddl.Items[0].Value = "0";
               }
           }
       }
       finally
       {
           dr.Close();
           dr.Dispose();
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
   }

   [OperationContract]
   public DataTable FillHostelFeeReport(string qry, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "qry", qry, DbType.String);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           //dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
           dt = objDB.ExecuteTable(CommandType.Text, "select * from HostelFeeReport where " + qry);
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public List<Academic.AcademicData.StudentAcademicDetailSDM> FillVerifyStudentDetailSearch(int InstituteID, int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "StudentRegistrationSelect");
       List<Academic.AcademicData.StudentAcademicDetailSDM> retItem = new List<Academic.AcademicData.StudentAcademicDetailSDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.StudentAcademicDetailSDM();
           item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
           item.StudentName = Education.DataHelper.GetString(dr, "StudentName");
           item.FatherName = Education.DataHelper.GetString(dr, "FatherName");
           item.DateOfBirth = Education.DataHelper.GetDateTime(dr, "DateOfBirth");
           item.ContactNo = Education.DataHelper.GetString(dr, "ContactNo");
           item.Category = Education.DataHelper.GetString(dr, "Category");
           item.AdmissionSource = Education.DataHelper.GetString(dr, "AdmissionSource");
           item.AdmissionType = Education.DataHelper.GetString(dr, "AdmissionType");
           item.RegNo = Education.DataHelper.GetString(dr, "RegNo");
           item.SessionID = Education.DataHelper.GetString(dr, "SessionID");
           item.MotherName = Education.DataHelper.GetString(dr, "MotherName");
           item.Gender = Education.DataHelper.GetString(dr, "Gender");
           item.RegDate = Education.DataHelper.GetDateTime(dr, "RegDate");
           item.Specialization = Education.DataHelper.GetString(dr, "Specialization");
           item.CourseName = Education.DataHelper.GetString(dr, "CourseName");
           item.YrSem = Education.DataHelper.GetString(dr, "YrSem");
           item.Sid = Education.DataHelper.GetInt(dr, "Sid");
           item.Courseid = Education.DataHelper.GetInt(dr, "Courseid");
           item.RollNo = Education.DataHelper.GetString(dr, "RollNo");
           item.UniversityRollNo = Education.DataHelper.GetString(dr, "UniversityRollNo");
           item.HostelFacilityReq = Education.DataHelper.GetString(dr, "HostelFacilityReq");
           item.BusFacilityReq = Education.DataHelper.GetString(dr, "BusFacilityReq");
           item.EntranceScore = Education.DataHelper.GetString(dr, "EntranceScore");
           item.Batch = Education.DataHelper.GetString(dr, "Batch");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   public void FillVoucherDeletion(DropDownList ddl, int StudentID, int InstituteID, string vtype, int Flag, string ZeroIndexVal)
   {
       ddl.Items.Clear();
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.Command.Parameters.Clear();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(2, "VType", vtype, DbType.String);
       objDB.AddParameters(3, "Flag", Flag, DbType.Int32);
       IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       try
       {
           if (dr != null)
           {
               ddl.DataSource = dr;
               ddl.DataTextField = "VoucherNo";
               ddl.DataValueField = "VoucherNo";
               ddl.DataBind();
               if (ZeroIndexVal != "")
               {
                   ddl.Items.Insert(0, ZeroIndexVal);
                   ddl.Items[0].Value = "0";
               }
               else
               {
                   ddl.Items.Insert(0, ZeroIndexVal);
                   ddl.Items[0].Value = "0";
               }
           }
       }
       finally
       {
           dr.Close();
           dr.Dispose();
           objDB.DataReader.Close();
           objDB.DataReader.Dispose();
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
   }


   [OperationContract]
   public List<Academic.AcademicData.VoucherDeletionGrd> FillGrdVoucherDeletion(int InstituteID, int StudentID, string VoucherNo, string VType, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(5);
       objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
       objDB.AddParameters(1, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(2, "VoucherNo", VoucherNo, DbType.String);
       objDB.AddParameters(3, "VType", VType, DbType.String);
       objDB.AddParameters(4, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       List<Academic.AcademicData.VoucherDeletionGrd> retItem = new List<Academic.AcademicData.VoucherDeletionGrd>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.VoucherDeletionGrd();
           item.TotalAmount = Education.DataHelper.GetDecimal(dr, "TotalAmount");
           item.PaidAmount = Education.DataHelper.GetDecimal(dr, "PaidAmount");
           item.BalanceAmount = Education.DataHelper.GetDecimal(dr, "BalanceAmount");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }

   [OperationContract]
   public string DeleteDueVoucher(Academic.AcademicData.DueVoucherDeleteDM objVD)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       try
       {
           objDB.CreateParameters(3);
           objDB.AddParameters(0, "StudentID", objVD.StudentID, DbType.Int32);
           objDB.AddParameters(1, "VoucherNo", objVD.VoucherNo, DbType.String);
           objDB.AddParameters(2, "Flag", objVD.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherDeletion");
           objDB.Transaction.Commit();
           retv = "Record Saved.";
       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }


   [OperationContract]
   public string DeleteRecVoucher(List<Academic.AcademicData.RecVoucherDeleteDM> objVD)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       try
       {
           foreach (Academic.AcademicData.RecVoucherDeleteDM fb in objVD)
           {
               objDB.CreateParameters(6);
               objDB.AddParameters(0, "StudentID", fb.StudentID, DbType.Int32);
               objDB.AddParameters(1, "VoucherNo", fb.VoucherNo, DbType.String);
               objDB.AddParameters(2, "PrNo", fb.PrNo, DbType.String);
               objDB.AddParameters(3, "FeeID", fb.FeeID, DbType.Int32);
               objDB.AddParameters(4, "PaidAmt", fb.PaidAmt, DbType.Decimal);
               //objDB.AddParameters(5, "BalAmt", fb.BalAmt, DbType.Int32);
               objDB.AddParameters(5, "Flag", fb.Flag, DbType.String);
               objDB.ExecuteNonQuery(CommandType.StoredProcedure, "VoucherDeletionDelete");

           }

           retv = "Record Saved.";

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }

   [OperationContract]
   public DataTable FillStudentLedgerDetailSummaryAmtD(int StudentID, DateTime FrmDate, DateTime ToDate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(4);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "FromDate", FrmDate, DbType.DateTime);
       objDB.AddParameters(2, "ToDate", ToDate, DbType.DateTime);
       objDB.AddParameters(3, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }
   [OperationContract]
   public List<Academic.AcademicData.DiscountAppliedFeeDM> FillDiscountAppliedFee(int StudentID, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(2);
       objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
       objDB.AddParameters(1, "flag", flag, DbType.Int32);
       IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "FeeDepositionSelect");
       List<Academic.AcademicData.DiscountAppliedFeeDM> retItem = new List<Academic.AcademicData.DiscountAppliedFeeDM>();
       while (dr.Read())
       {
           var item = new Academic.AcademicData.DiscountAppliedFeeDM();
           item.FeeHeadName = Education.DataHelper.GetString(dr, "FeeHeadName");
           item.FeeID = Education.DataHelper.GetInt(dr, "FeeID");
           retItem.Add(item);
       }
       objDB.Connection.Close();
       objDB.Dispose();
       return retItem;
   }
   [OperationContract]
   public string DiscountAppliedInsert(Academic.AcademicData.DiscountAppliedDM objD)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.BeginTransaction();
       string retv = "";
       try
       {
           objDB.CreateParameters(8);
           objDB.AddParameters(0, "DiscountID", objD.DiscountID, DbType.Int32);
           objDB.AddParameters(1, "StudentID", objD.StudentID, DbType.Int32);
           objDB.AddParameters(2, "FeeID", objD.FeeID, DbType.Int32);
           objDB.AddParameters(3, "AppliedAmount", objD.AppliedAmount, DbType.Decimal);
           objDB.AddParameters(4, "AppliedDate", objD.AppliedDate, DbType.DateTime);
           //objDB.AddParameters(5, "Approval", objD.Approval, DbType.Int32);
           //objDB.AddParameters(6, "ApprovedAmount", objD.ApprovedAmount, DbType.Int32);
           //objDB.AddParameters(7, "ApprovalDate", objD.ApprovalDate, DbType.Int32);
           objDB.AddParameters(5, "InstituteID", objD.InstituteID, DbType.Int32);
           objDB.AddParameters(6, "UName", objD.UName, DbType.String);
           objDB.AddParameters(7, "Flag", objD.Flag, DbType.String);
           objDB.ExecuteNonQuery(CommandType.StoredProcedure, "DiscountInsert");

           retv = "Record Saved.";

           objDB.Transaction.Commit();

       }
       catch (Exception ex)
       {
           objDB.Transaction.Rollback();
           retv = "Unable to save record :-" + ex.Message.ToString();
       }
       finally
       {

           objDB.Connection.Close();
           objDB.Dispose();
       }
       return retv;
   }
   [OperationContract]
   public DataTable FillBankReconcillation(DateTime FromDate, DateTime ToDate, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(3);
       objDB.AddParameters(0, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(1, "ToDate", ToDate, DbType.DateTime);
       objDB.AddParameters(2, "flag", flag, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillCashBankSummaryAmtTS(int accountid, DateTime FromDate, DateTime ToDate, int FeeId, int CourseID, int Specialization, string SessionID, int Sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(9);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "AccountNoID", accountid, DbType.Int32);
       objDB.AddParameters(2, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(3, "ToDate", ToDate, DbType.DateTime);
       objDB.AddParameters(4, "FeeID", FeeId, DbType.Int32);
       objDB.AddParameters(5, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(6, "SpecializationID", Specialization, DbType.Int32);
       objDB.AddParameters(7, "SessionID", SessionID, DbType.String);
       objDB.AddParameters(8, "Sid", Sid, DbType.Int32);
       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   [OperationContract]
   public DataTable FillCashBankSummaryAmtTSS(int accountid, DateTime FromDate, DateTime ToDate, int studentid, int FeeId, int CourseID, int Specialization, string SessionID, int Sid, int flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       objDB.CreateParameters(10);
       objDB.AddParameters(0, "flag", flag, DbType.Int32);
       objDB.AddParameters(1, "AccountNoID", accountid, DbType.Int32);
       objDB.AddParameters(2, "FromDate", FromDate, DbType.DateTime);
       objDB.AddParameters(3, "ToDate", ToDate, DbType.DateTime);
       objDB.AddParameters(4, "StudentID", studentid, DbType.Int32);
       objDB.AddParameters(5, "FeeID", FeeId, DbType.Int32);
       objDB.AddParameters(6, "CourseID", CourseID, DbType.Int32);
       objDB.AddParameters(7, "SpecializationID", Specialization, DbType.Int32);
       objDB.AddParameters(8, "SessionID", SessionID, DbType.String);
       objDB.AddParameters(9, "Sid", Sid, DbType.Int32);

       DataTable dt = new DataTable();
       try
       {
           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "FeeDepositionSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Dispose();
       }
       return dt;
   }

   public DataTable ViewAlreadyGenratedPsw(int InstituteID, string SessionID, int CourseID, int sid, int Specialization, string flag)
   {
       NewDAL.DBManager objDB = new DBManager();
       objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
       objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
       objDB.Open();
       DataTable dt = new DataTable();
       try
       {
           objDB.CreateParameters(5);
           objDB.AddParameters(0, "InstituteID", InstituteID, DbType.Int32);
           objDB.AddParameters(1, "CourseID", CourseID, DbType.Int32);
           objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
           objDB.AddParameters(3, "sid", sid, DbType.Int32);
           objDB.AddParameters(4, "Specialization", Specialization, DbType.Int32);
           objDB.AddParameters(5, "flag", flag, DbType.Int32);

           dt = objDB.ExecuteTable(CommandType.StoredProcedure, "StudentRegistrationSelect");
       }
       finally
       {
           objDB.Connection.Close();
           objDB.Connection.Dispose();
           objDB.Dispose();
       }
       return dt;
   }

}
 
