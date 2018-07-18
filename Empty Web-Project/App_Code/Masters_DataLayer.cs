using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRM
{
    namespace Masters
    {
    /// <summary>
    /// Summary description for Masters_DataLayer
    /// </summary>
        public abstract class Masters_DataLayer : IDisposable
        {
            protected string ReturnConString()
            {
                return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
            }

            protected   NewDAL.DBManager objDB = null;
            private   NewDAL.DBManager OpenDALConnection()
            {
                objDB = new   NewDAL.DBManager();
                //objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
                objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
                objDB.Open();

                return objDB;
            }
            #region Expertise Master
            protected string Save_Expertise(HRM.Fee.ExpertisDM insrtExprt)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(9);
                    objDB.AddParameters(0, "id", insrtExprt.id, DbType.Int32);
                    objDB.AddParameters(1, "Expertise", insrtExprt.Expertise, DbType.String);
                    objDB.AddParameters(2, "wed", insrtExprt.wed, DbType.DateTime);
                    objDB.AddParameters(3, "InstituteID", insrtExprt.InstituteID, DbType.Int32);
                    objDB.AddParameters(4, "SessionID", insrtExprt.SessionID, DbType.String);
                    objDB.AddParameters(5, "UserID", insrtExprt.UserID, DbType.String);
                    objDB.AddParameters(6, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(7, "flag", insrtExprt.flag, DbType.String);
                    objDB.AddParameters(8, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spExpertise");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record.";
                }
                return retv;

            }
            protected List<HRM.Fee.ExpertisDM> fillExpert(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.ExpertisDM> objExprt = new List<Fee.ExpertisDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "spExpertise");
                    HRM.Fee.ExpertisDM itemF = null;
                    while (objDB.DataReader.Read())
                    {
                        itemF = new HRM.Fee.ExpertisDM();
                        itemF.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        itemF.Expertise = objDB.DataReader["Expertise"].ToString();
                        itemF.wed = Convert.ToDateTime(objDB.DataReader["wed"].ToString());
                        objExprt.Add(itemF);
                    }
                }
                catch
                {}
                finally { objDB.Command.Parameters.Clear(); }
                return objExprt;
            }
            #endregion
            #region Department
            protected string Save_Department(HRM.Fee.DepartmentDM objDept)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(11);
                    objDB.AddParameters(0, "DepartmentID", objDept.DepartmentID, DbType.Int32);
                    objDB.AddParameters(1, "DepartmentName", objDept.DepartmentName, DbType.String);
                    objDB.AddParameters(2, "ShortName", objDept.ShortName, DbType.String);
                    objDB.AddParameters(3, "InstituteID", objDept.InstituteID, DbType.Int32);
                    objDB.AddParameters(4, "SessionID", objDept.SessionID, DbType.String);
                    objDB.AddParameters(5, "UName", objDept.UName, DbType.String);
                    objDB.AddParameters(6, "UEntDt", objDept.UEntDt, DbType.DateTime);
                    objDB.AddParameters(7, "validFrom", objDept.validFrom, DbType.DateTime);
                    objDB.AddParameters(8, "validTo", objDept.validTo, DbType.DateTime);
                    objDB.AddParameters(9, "flag", objDept.flag, DbType.String);
                    objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Department");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Department already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                    else if (Retsuccess == "0")
                    {
                        retv = "record can not be updated";
                    }
                    else if (Retsuccess == "6")
                    {
                        retv = "Short Name already exists.";
                    }
                    else if (Retsuccess == "7")
                    {
                        retv = "From Date can not be update until Any employee will be in this department.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record";
                }
                return retv;
            }
            protected List<HRM.Fee.DepartmentDM> fillDepartment(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.DepartmentDM> objDept = new List<Fee.DepartmentDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0,"flag", flag,DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Department");
                    HRM.Fee.DepartmentDM item = null;
                    while (objDB.DataReader.Read())
                    {
                        item = new HRM.Fee.DepartmentDM();
                        item.DepartmentID = Int32.Parse(objDB.DataReader["DepartmentID"].ToString());
                        item.DepartmentName = objDB.DataReader["DepartmentName"].ToString();
                        item.ShortName = objDB.DataReader["ShortName"].ToString();
                        item.validFrom = Convert.ToDateTime(objDB.DataReader["validFrom"].ToString());
                        item.validTo = Convert.ToDateTime(objDB.DataReader["validTo"].ToString());
                        objDept.Add(item);
                    }
                }
                catch (Exception)
                { objDB.Command.Parameters.Clear(); }
                return objDept;
            }
            #endregion
            #region Designation
            protected string Save_Designation(HRM.Fee.DesigntionDM objdesg)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(11);
                    objDB.AddParameters(0, "DesigId", objdesg.DesigId, DbType.Int32);
                    objDB.AddParameters(1, "Designation", objdesg.Designation, DbType.String);
                    objDB.AddParameters(2, "ShortName", objdesg.ShortName, DbType.String);
                    objDB.AddParameters(3, "InstituteID", objdesg.InstituteID, DbType.Int32);
                    objDB.AddParameters(4, "SessionID", objdesg.SessionID, DbType.String);
                    objDB.AddParameters(5, "UserID", objdesg.UserID, DbType.String);
                    objDB.AddParameters(6, "UEDate", objdesg.UEDate, DbType.DateTime);
                    objDB.AddParameters(7, "validFrom", objdesg.validFrom, DbType.DateTime);
                    objDB.AddParameters(8, "validTo", objdesg.validTo, DbType.DateTime);
                    objDB.AddParameters(9, "flag", objdesg.flag, DbType.String);
                    objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Desig");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }                    
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                    else if (Retsuccess == "0")
                    {
                        retv = "Record can not be updated";
                    }
                }
                catch (Exception ex)
                {

                    objDB.Transaction.Rollback();
                    retv = "Unable to save record";
                }
                return retv;

            }
            protected List<HRM.Fee.DesigntionDM> fillDesignation(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.DesigntionDM> listDesig = new List<Fee.DesigntionDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", flag, DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Master_Desig");
                    HRM.Fee.DesigntionDM item;
                    while (objDB.DataReader.Read())
                    {
                        item = new  HRM.Fee.DesigntionDM();
                        item.Designation = objDB.DataReader["Designation"].ToString();
                        item.ShortName = objDB.DataReader["ShortName"].ToString();
                        item.validFrom =Convert.ToDateTime( objDB.DataReader["validFrom"].ToString());
                        item.validTo = Convert.ToDateTime(objDB.DataReader["validTo"].ToString());
                        item.DesigId =Int32.Parse(objDB.DataReader["DesigId"].ToString());
                        listDesig.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    objDB.Command.Parameters.Clear();
                }
                finally
                {
                }
                return listDesig;
            }
            #endregion
            #region Working Days
            protected string Save_WorkDays(List<HRM.Fee.WorkDayDM> objWorkDay)
            {
                //  NewDAL.DBManager objDB = new DBManager();
                //objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
                //objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
                string retStr = string.Empty;
                string RetSuccess = string.Empty;
                Boolean SuccessFlag = true;

                try
                {
                    objDB = OpenDALConnection();
                    //objDB.Open();
                    objDB.BeginTransaction();
                    foreach (HRM.Fee.WorkDayDM ObjItems in objWorkDay)
                    {
                        //base.Vendor_Dtls_Save(ObjItems.flag, ObjItems.ID, ObjItems.PRID, ObjItems.Ctrl_Id, ObjItems.SupplierId, ObjItems.IndentID, ObjItems.UID, ObjItems.SessionID, ObjItems.InstID, ref RetSuccess);
                        objDB.Command.Parameters.Clear();
                        objDB.CreateParameters(15);
                        objDB.AddParameters(0, "yearID", ObjItems.yearID, DbType.Int32);
                        objDB.AddParameters(1, "workDays", ObjItems.workDays, DbType.String);
                        objDB.AddParameters(2, "InstituteID", ObjItems.InstituteID, DbType.Int32);
                        objDB.AddParameters(3, "workdayID", ObjItems.workdayID, DbType.Int32);
                        objDB.AddParameters(4, "frmdate", ObjItems.frmdate, DbType.DateTime);
                        objDB.AddParameters(5, "todate", ObjItems.todate, DbType.DateTime);
                        objDB.AddParameters(6, "cdate", ObjItems.cdate, DbType.DateTime);
                        objDB.AddParameters(7, "edate", ObjItems.edate, DbType.Int32);
                        objDB.AddParameters(8, "mnth", ObjItems.mnth, DbType.Int32);
                        objDB.AddParameters(9, "yr", ObjItems.yr, DbType.Int32);
                        objDB.AddParameters(10, "deptID", ObjItems.deptID, DbType.Int32);
                        objDB.AddParameters(11, "UserID", ObjItems.UserID, DbType.String);
                        objDB.AddParameters(12, "UEDate", ObjItems.UEDate, DbType.DateTime);
                        objDB.AddParameters(13, "flag", ObjItems.flag, DbType.String);
                        objDB.AddParameters(14, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                        objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_PayWorkDay");
                        RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();

                        if (RetSuccess != "1")
                        {
                            SuccessFlag = false;
                        }
                    }
                    objDB.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retStr = "Unable to save record ";
                }
                finally
                {
                    if (SuccessFlag == true)
                    {
                        retStr = "Record Saved";
                    }
                    else
                    {
                        retStr = "Record Not Saved";
                    }
                }
                return retStr;
            }

            protected List<HRM.PayRollDM.WorkDay> FillWorkDay(Int32 InstituteID)
            {
                SqlCommand com = null;
                DataTable dt = new DataTable();
                var listitem = new List<HRM.PayRollDM.WorkDay>();
                SqlConnection cnx = new SqlConnection(ReturnConString());
                com = new SqlCommand();
                SqlDataReader dr;
                cnx.Open();
                com.Connection = cnx;
                com.Parameters.AddWithValue("@flag", "S");
                com.Parameters.AddWithValue("@InstituteID", InstituteID);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_PayWorkDay";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    // var item = HRM.PayRoll.WorkingDay();

                    var item = new HRM.PayRollDM.WorkDay();
                    item.id = Int32.Parse(dr["id"].ToString());
                    item.yearID = Int32.Parse(dr["yearID"].ToString());
                    item.workDays = dr["workDays"].ToString();
                    item.InstituteID = Int32.Parse(dr["InstituteID"].ToString());
                    item.workdayid = Int32.Parse(dr["workdayID"].ToString());
                    item.frmdate = Convert.ToDateTime(dr["frmdate"]);
                    item.todate = Convert.ToDateTime(dr["todate"]);
                    item.cdate = Convert.ToDateTime(dr["cdate"]);
                    item.edate = Int32.Parse(dr["edate"].ToString());
                    item.mnth = Int32.Parse(dr["mnth"].ToString());
                    item.yr = Int32.Parse(dr["yr"].ToString());
                    item.deptID = Int32.Parse(dr["deptID"].ToString());
                    item.SessionF = dr["SessionF"].ToString();
                    listitem.Add(item);

                }
                dr.Close();
                dr.Dispose();
                return listitem;

            }
            
            #endregion                     
            #region  Employee Detail Master
            protected Boolean Save_Employee_Detail(String Flag, Int32 InstID, String SessionID, String UserID, Int32 EmpId, Int32 candID, String empCode, String empName, String empType, String empCat, Int32 barID, String Gender, DateTime DOB, String CompanyName, Int32 DeptID, Int32 DesigID, String MarkOIdent, String MaritalStatus, String ModeAppl, String ReferedBy, String Religion, String Nationality, String NatureID, String WorkingExp, String SpouseName, String FatherName, String PermAdd, Int32 City, Int32 State, Int32 Country, String ZipCode, String PhoneNo, String EMail, String Mobile, String LocalAddress, Int32 LocalCity, Int32 LocalState, Int32 LocalCountry, String LocalZipCode, String LocalPhoneNo, String LocalEMail, String LocalMobile, DateTime JoiningDate, String BloodGroup, String BonusApplied, String OTApplied, String ODayApplied, String OffDay, Int32 ProfEdu, byte[] EmployeeImge, byte[] EmployeeSign, String LastName, Int32 RAuthority, String EmployeeTitle, Int32 ExpertID,   NewDAL.DBManager objDB, ref Int32 EmployeeID)
            {
                Boolean IsSaved = false;
                try
                {
                    objDB.BeginTransaction();
                    objDB.CreateParameters(57);

                    objDB.AddParameters(0, "empId", EmpId, DbType.Int32);
                    objDB.AddParameters(1, "candID", candID, DbType.Int32);
                    objDB.AddParameters(2, "empCode", empCode, DbType.String);
                    objDB.AddParameters(3, "empName", empName, DbType.String);
                    objDB.AddParameters(4, "empType", empType, DbType.String);
                    objDB.AddParameters(5, "empCat", empCat, DbType.String);
                    objDB.AddParameters(6, "barID", barID, DbType.Int32);
                    objDB.AddParameters(7, "sex", Gender, DbType.String);
                    objDB.AddParameters(8, "dob", DOB, DbType.DateTime);
                    objDB.AddParameters(9, "compName", CompanyName, DbType.String);
                    objDB.AddParameters(10, "deptID", DeptID, DbType.Int32);
                    objDB.AddParameters(11, "desigID", DesigID, DbType.Int32);
                    objDB.AddParameters(12, "markOIdent", MarkOIdent, DbType.String);
                    objDB.AddParameters(13, "meritalStatus", MaritalStatus, DbType.String);
                    objDB.AddParameters(14, "modeAppl", ModeAppl, DbType.String);
                    objDB.AddParameters(15, "referedby", ReferedBy, DbType.String);
                    objDB.AddParameters(16, "religion", Religion, DbType.String);
                    objDB.AddParameters(17, "nationality", Nationality, DbType.String);
                    objDB.AddParameters(18, "NatureID", NatureID, DbType.String);
                    objDB.AddParameters(19, "workExp", WorkingExp, DbType.String);
                    objDB.AddParameters(20, "spouseName", SpouseName, DbType.String);
                    objDB.AddParameters(21, "fatherName", FatherName, DbType.String);
                    objDB.AddParameters(22, "permAdd", PermAdd, DbType.String);
                    objDB.AddParameters(23, "city", City, DbType.Int32);
                    objDB.AddParameters(24, "state", State, DbType.Int32);
                    objDB.AddParameters(25, "country", Country, DbType.Int32);
                    objDB.AddParameters(26, "zipcode", ZipCode, DbType.String);
                    objDB.AddParameters(27, "phone", PhoneNo, DbType.String);
                    objDB.AddParameters(28, "email", EMail, DbType.String);
                    objDB.AddParameters(29, "mobile", Mobile, DbType.String);
                    objDB.AddParameters(30, "localAdd", LocalAddress, DbType.String);
                    objDB.AddParameters(31, "lCity", LocalCity, DbType.Int32);
                    objDB.AddParameters(32, "lState", LocalState, DbType.Int32);
                    objDB.AddParameters(33, "lCountry", LocalCountry, DbType.Int32);
                    objDB.AddParameters(34, "lZipcode", LocalZipCode, DbType.String);
                    objDB.AddParameters(35, "lPhone", LocalPhoneNo, DbType.String);
                    objDB.AddParameters(36, "lEmail", LocalEMail, DbType.String);
                    objDB.AddParameters(37, "lMobile", LocalMobile, DbType.String);
                    objDB.AddParameters(38, "joinDate", JoiningDate, DbType.DateTime);
                    objDB.AddParameters(39, "bloodGroup", BloodGroup, DbType.String);
                    objDB.AddParameters(40, "bonusApp", BonusApplied, DbType.String);
                    objDB.AddParameters(41, "OTApp", OTApplied, DbType.String);
                    objDB.AddParameters(42, "ODayApp", ODayApplied, DbType.String);
                    objDB.AddParameters(43, "offDay", OffDay, DbType.String);
                    objDB.AddParameters(44, "educProf", ProfEdu, DbType.Int32);
                    objDB.AddParameters(45, "InstituteID", InstID, DbType.Int32);
                    objDB.AddParameters(46, "SessionID", SessionID, DbType.String);
                    objDB.AddParameters(47, "UserID", UserID, DbType.String);
                    objDB.AddParameters(48, "UEDate", DateTime.Today.Date, DbType.Date);
                    objDB.AddParameters(49, "image", EmployeeImge, DbType.Binary);
                    objDB.AddParameters(50, "sign", EmployeeSign, DbType.Binary);
                    objDB.AddParameters(51, "lastName", LastName, DbType.String);
                    objDB.AddParameters(52, "flag", Flag, DbType.String);
                    objDB.AddParameters(53, "RAuthority", RAuthority, DbType.Int32);
                    objDB.AddParameters(54, "titleEmp", EmployeeTitle, DbType.String);
                    objDB.AddParameters(55, "ExpertID", ExpertID, DbType.Int32);
                    objDB.AddParameters(56, "EmployeeID", EmployeeID, DbType.Int32, ParameterDirection.Output);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Employee");

                    ((SqlCommand)objDB.Command).Parameters["@EmployeeID"].Size = 25;
                    Int32 EmployeeId = Int32.Parse(((SqlCommand)objDB.Command).Parameters["@EmployeeID"].Value.ToString());
                    IsSaved = true;
                }
                catch (Exception ex) { }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return IsSaved;
            }
            protected Boolean Save_Employee_Detail(HRM.Fee.EmployeeDetail EmpDetail,   NewDAL.DBManager objDB, ref Int32 EmployeeID)
            {
                Boolean IsSaved = false;
                try
                {
                    objDB.BeginTransaction();
                    objDB.CreateParameters(63);

                    objDB.AddParameters(0, "empId", EmpDetail.EmployeeID, DbType.Int32);
                    objDB.AddParameters(1, "candID", EmpDetail.candID, DbType.Int32);
                    objDB.AddParameters(2, "empCode", EmpDetail.empCode, DbType.String);
                    objDB.AddParameters(3, "empName", EmpDetail.empName, DbType.String);
                    objDB.AddParameters(4, "empType", EmpDetail.empType, DbType.String);
                    objDB.AddParameters(5, "empCat", EmpDetail.empCat, DbType.String);
                    objDB.AddParameters(6, "barID", EmpDetail.barID, DbType.Int32);
                    objDB.AddParameters(7, "sex", EmpDetail.Gender, DbType.String);
                    objDB.AddParameters(8, "dob", EmpDetail.DOB, DbType.DateTime);
                    objDB.AddParameters(9, "compName", EmpDetail.CompanyName, DbType.String);
                    objDB.AddParameters(10, "deptID", EmpDetail.DeptID, DbType.Int32);
                    objDB.AddParameters(11, "desigID", EmpDetail.DesigID, DbType.Int32);
                    objDB.AddParameters(12, "markOIdent", EmpDetail.MarkOIdent, DbType.String);
                    objDB.AddParameters(13, "meritalStatus", EmpDetail.MaritalStatus, DbType.String);
                    objDB.AddParameters(14, "modeAppl", EmpDetail.ModeAppl, DbType.String);
                    objDB.AddParameters(15, "referedby", EmpDetail.ReferedBy, DbType.String);
                    objDB.AddParameters(16, "religion", EmpDetail.Religion, DbType.String);
                    objDB.AddParameters(17, "nationality", EmpDetail.Nationality, DbType.String);
                    objDB.AddParameters(18, "NatureID", EmpDetail.NatureID, DbType.String);
                    objDB.AddParameters(19, "workExp", EmpDetail.WorkingExp, DbType.String);
                    objDB.AddParameters(20, "spouseName", EmpDetail.SpouseName, DbType.String);
                    objDB.AddParameters(21, "fatherName", EmpDetail.FatherName, DbType.String);
                    objDB.AddParameters(22, "permAdd", EmpDetail.PermAdd, DbType.String);
                    objDB.AddParameters(23, "city", EmpDetail.City, DbType.Int32);
                    objDB.AddParameters(24, "state", EmpDetail.State, DbType.Int32);
                    objDB.AddParameters(25, "country", EmpDetail.Country, DbType.Int32);
                    objDB.AddParameters(26, "zipcode", EmpDetail.ZipCode, DbType.String);
                    objDB.AddParameters(27, "phone", EmpDetail.PhoneNo, DbType.String);
                    objDB.AddParameters(28, "email", EmpDetail.EMail, DbType.String);
                    objDB.AddParameters(29, "mobile", EmpDetail.Mobile, DbType.String);
                    objDB.AddParameters(30, "localAdd", EmpDetail.LocalAddress, DbType.String);
                    objDB.AddParameters(31, "lCity", EmpDetail.LocalCity, DbType.Int32);
                    objDB.AddParameters(32, "lState", EmpDetail.LocalState, DbType.Int32);
                    objDB.AddParameters(33, "lCountry", EmpDetail.LocalCountry, DbType.Int32);
                    objDB.AddParameters(34, "lZipcode", EmpDetail.LocalZipCode, DbType.String);
                    objDB.AddParameters(35, "lPhone", EmpDetail.LocalPhoneNo, DbType.String);
                    objDB.AddParameters(36, "lEmail", EmpDetail.LocalEMail, DbType.String);
                    objDB.AddParameters(37, "lMobile", EmpDetail.LocalMobile, DbType.String);
                    objDB.AddParameters(38, "joinDate", EmpDetail.JoiningDate, DbType.DateTime);
                    objDB.AddParameters(39, "bloodGroup", EmpDetail.BloodGroup, DbType.String);
                    objDB.AddParameters(40, "bonusApp", EmpDetail.BonusApplied, DbType.String);
                    objDB.AddParameters(41, "OTApp", EmpDetail.OTApplied, DbType.String);
                    objDB.AddParameters(42, "ODayApp", EmpDetail.ODayApplied, DbType.String);
                    objDB.AddParameters(43, "offDay", EmpDetail.OffDay, DbType.String);
                    objDB.AddParameters(44, "educProf", EmpDetail.ProfEdu, DbType.Int32);
                    objDB.AddParameters(45, "InstituteID", EmpDetail.InstID, DbType.Int32);
                    objDB.AddParameters(46, "SessionID", EmpDetail.SesnID, DbType.String);
                    objDB.AddParameters(47, "UserID", EmpDetail.UserID, DbType.String);
                    objDB.AddParameters(48, "UEDate", DateTime.Today.Date, DbType.Date);
                    objDB.AddParameters(49, "image", EmpDetail.EmployeeImge, DbType.Binary);
                    objDB.AddParameters(50, "sign", EmpDetail.EmployeeSign, DbType.Binary);
                    objDB.AddParameters(51, "lastName", EmpDetail.LastName, DbType.String);
                    objDB.AddParameters(52, "flag", EmpDetail.flag, DbType.String);
                    objDB.AddParameters(53, "RAuthority", EmpDetail.RAuthority, DbType.Int32);
                    objDB.AddParameters(54, "titleEmp", EmpDetail.EmployeeTitle, DbType.String);
                    objDB.AddParameters(55, "ExpertID", EmpDetail.ExpertID, DbType.Int32);
                    objDB.AddParameters(56, "EmployeeID", EmpDetail.EmployeeID, DbType.Int32, ParameterDirection.Output);
                    objDB.AddParameters(57, "WEDDate", EmpDetail.WEDDDate, DbType.DateTime);
                    objDB.AddParameters(58, "CardNo", EmpDetail.CardNo, DbType.String);
                    objDB.AddParameters(59, "Status", EmpDetail.Status, DbType.String);
                    objDB.AddParameters(60, "DGAppr", EmpDetail.DGAppr, DbType.String);
                    objDB.AddParameters(61, "MotherName", EmpDetail.MotherName, DbType.String);
                    objDB.AddParameters(62, "PanCard", EmpDetail.PanCard, DbType.String);                  
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Employee");
                    ((SqlCommand)objDB.Command).Parameters["@EmployeeID"].Size = 25;
                    EmployeeID = Int32.Parse(((SqlCommand)objDB.Command).Parameters["@EmployeeID"].Value.ToString());
                    IsSaved = true;//EmployeeId
                }
                catch (Exception ex) 
                {
                 
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return IsSaved;
            }
            protected void Save_Employee_Basic_Salary(Int32 RowId, Int32 Employee_id, DateTime WithEffectDate, Int32 DeptID, Int32 DesigID, String PayPeriod, Decimal BasicSalary, Int32 OverTimeHour, Int32 OverTimeMinute, Int32 HalfDayHour, Int32 HalfDayMinute, Int32 SalaryGrade, Int32 LateHour, Int32 LateMin,   NewDAL.DBManager objDB)
            {
                try
                {
                    objDB.CreateParameters(14);

                    objDB.AddParameters(0, "id", RowId, DbType.Int32);
                    objDB.AddParameters(1, "empId", Employee_id, DbType.Int32);
                    objDB.AddParameters(2, "WED", WithEffectDate, DbType.Date);

                    objDB.AddParameters(3, "deptID", DeptID, DbType.Int32);
                    objDB.AddParameters(4, "desigID", DesigID, DbType.Int32);
                    objDB.AddParameters(5, "payPeriod", PayPeriod, DbType.String);

                    objDB.AddParameters(6, "basicSal", 0, DbType.Decimal);
                    objDB.AddParameters(7, "overTimehour", OverTimeHour, DbType.Int32);
                    objDB.AddParameters(8, "overTimeminute", OverTimeMinute, DbType.Int32);

                    objDB.AddParameters(9, "halfDayhour", HalfDayHour, DbType.Int32);
                    objDB.AddParameters(10, "halfDayminute", HalfDayMinute, DbType.Int32);
                    objDB.AddParameters(11, "salGrade", SalaryGrade, DbType.Int32);

                    objDB.AddParameters(12, "lateHour", LateHour, DbType.Int32);
                    objDB.AddParameters(13, "lateMin", LateMin, DbType.Int32);


                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Payroll_EmpBasicSal");
                    objDB.Command.Parameters.Clear();
                }
                catch (Exception ex) 
                {
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
            }
            protected void Save_Employee_Basic_Salary(HRM.Fee.BasicSalDetail BasicDetail,   NewDAL.DBManager objDB)
            {
                //try
                //{
                    objDB.CreateParameters(21);

                    objDB.AddParameters(0, "id", BasicDetail.id, DbType.Int32);
                    objDB.AddParameters(1, "empId", BasicDetail.empId, DbType.Int32);
                    objDB.AddParameters(2, "WED", BasicDetail.WED, DbType.Date);

                    objDB.AddParameters(3, "deptID", BasicDetail.deptId, DbType.Int32);
                    objDB.AddParameters(4, "desigID", BasicDetail.desigId, DbType.Int32);
                    objDB.AddParameters(5, "payPeriod", BasicDetail.payPeriod, DbType.String);

                    objDB.AddParameters(6, "basicSal",BasicDetail.BasicSal, DbType.Double);
                    objDB.AddParameters(7, "overTimehour", BasicDetail.OTHour, DbType.Int32);
                    objDB.AddParameters(8, "overTimeminute", BasicDetail.OTMin, DbType.Int32);

                    objDB.AddParameters(9, "halfDayhour", BasicDetail.HDHour, DbType.Int32);
                    objDB.AddParameters(10, "halfDayminute", BasicDetail.HDMin, DbType.Int32);
                    objDB.AddParameters(11, "salGrade", BasicDetail.salGrade, DbType.Int32);

                    objDB.AddParameters(12, "lateHour", BasicDetail.LTHour, DbType.Int32);
                    objDB.AddParameters(13, "lateMin", BasicDetail.LTMin, DbType.Int32);

                    objDB.AddParameters(14, "pfNo", BasicDetail.PfNo, DbType.String);
                    objDB.AddParameters(15, "esiNo", BasicDetail.EsiNo, DbType.String);
                    objDB.AddParameters(16, "RAuthority", BasicDetail.RAuthority, DbType.Int32);
                    objDB.AddParameters(17, "flag", BasicDetail.flag, DbType.String);
                    objDB.AddParameters(18, "RetSuccess", 0, DbType.Int32, ParameterDirection.Output);
                    objDB.AddParameters(19, "LAuthority", BasicDetail.LAuthority, DbType.Int32);
                    objDB.AddParameters(20, "HOD", BasicDetail.HOD, DbType.String);
                    //objDB.AddParameters(21, "DGAppr", BasicDetail.DGAppr, DbType.String);
                  
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Payroll_EmpBasicSal");
                    objDB.Command.Parameters.Clear();
               // }
                //catch (Exception ex) 
                //{
                //}
                //finally
                //{
                //    objDB.Command.Parameters.Clear();
                //}
            }
            protected void Save_Employee_wages(Int32 FBasic, String wageID, String wValue, String Status,   NewDAL.DBManager objDB, ref String RetSuccess)
            {
                try
                {
                    objDB.CreateParameters(6);
                    objDB.AddParameters(0, "empBasicId", FBasic, DbType.Int32);
                    objDB.AddParameters(1, "wageID", wageID, DbType.String);
                    objDB.AddParameters(2, "wValue", wValue, DbType.String);
                    objDB.AddParameters(3, "status", Status, DbType.String);
                    objDB.AddParameters(4, "flag", "N", DbType.String);
                    objDB.AddParameters(5, "RetSuccess", 0, DbType.String, ParameterDirection.Output);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_EmpWage");
                    RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
            }
            protected void Save_Employee_wages(HRM.Fee.WageDetails wageDetails,   NewDAL.DBManager objDB, ref String RetSuccess)
            {
                try
                {
                    objDB.CreateParameters(7);
                    objDB.AddParameters(0, "empBasicId", wageDetails.rowID, DbType.Int32);
                    objDB.AddParameters(1, "wageID", wageDetails.wageID, DbType.String);
                    objDB.AddParameters(2, "wValue", wageDetails.wageValue, DbType.String);
                    objDB.AddParameters(3, "status", wageDetails.status, DbType.String);
                    objDB.AddParameters(4, "flag", "N", DbType.String);
                    objDB.AddParameters(5, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(6, "chk", wageDetails.chk , DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_EmpWage");
                    RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
            }
            protected void Save_Employee_Services(Int32 EmployeeId, Int32 ServiceID, String Status, DateTime WED,   NewDAL.DBManager objDB, ref String Retsuccess)
            {
                //try
                //{
                    objDB.CreateParameters(6);

                    objDB.AddParameters(0, "empid", EmployeeId, DbType.Int32);
                    objDB.AddParameters(1, "servId", ServiceID, DbType.Int32);
                    objDB.AddParameters(2, "status", Status, DbType.String);
                    objDB.AddParameters(3, "wed", WED, DbType.DateTime);
                    objDB.AddParameters(4, "cdate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(5, "RetSuccess", 0, DbType.String, ParameterDirection.Output);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spChildEmpMaster");

                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                //}
                //catch (Exception ex) 
                //{
                //    Retsuccess = "0";
                //}
                //finally
                //{
                //    objDB.Command.Parameters.Clear();
                //}
            }
            protected HRM.Fee.EmployeeDetail Get_Employee_Detail(Int32 EmployeeId)
            {
                HRM.Fee.EmployeeDetail EmpDtl = null;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);

                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "empId", EmployeeId, DbType.Int32);

                    objDB.ExecuteReader(CommandType.StoredProcedure, "[SP_Master_Employee]");

                    //HRM.Fee.EmployeeDetail EmpDtl = null;

                    if (objDB.DataReader.Read())
                    {
                        EmpDtl = new Fee.EmployeeDetail();

                        EmpDtl.EmployeeID = Int32.Parse(objDB.DataReader["empId"].ToString());
                        EmpDtl.barID = Int32.Parse(objDB.DataReader["barID"].ToString());
                        EmpDtl.BloodGroup = objDB.DataReader["bloodGroup"].ToString();
                        EmpDtl.BonusApplied = objDB.DataReader["bonusApp"].ToString();
                        EmpDtl.candID = Int32.Parse(objDB.DataReader["candID"].ToString());
                        EmpDtl.City = Int32.Parse(objDB.DataReader["city"].ToString());
                        EmpDtl.CompanyName = objDB.DataReader["compName"].ToString();
                        EmpDtl.Country = Int32.Parse(objDB.DataReader["Country"].ToString());
                        EmpDtl.DeptID = Int32.Parse(objDB.DataReader["deptID"].ToString());
                        EmpDtl.DesigID = Int32.Parse(objDB.DataReader["desigID"].ToString());
                        EmpDtl.DOB = Convert.ToDateTime(objDB.DataReader["dob"].ToString());
                        EmpDtl.EMail = objDB.DataReader["email"].ToString();
                        EmpDtl.empCat = objDB.DataReader["empCat"].ToString();
                        EmpDtl.empCode = objDB.DataReader["empCode"].ToString();
                        EmpDtl.empName = objDB.DataReader["empName"].ToString();
                        EmpDtl.empType = objDB.DataReader["empType"].ToString();
                        EmpDtl.ExpertID = Int32.Parse(objDB.DataReader["ExpertID"].ToString());
                        EmpDtl.FatherName = objDB.DataReader["fatherName"].ToString();                     
                        EmpDtl.Gender = objDB.DataReader["sex"].ToString();
                        EmpDtl.JoiningDate = Convert.ToDateTime(objDB.DataReader["joinDate"].ToString());
                        EmpDtl.LastName = objDB.DataReader["LastName"].ToString();
                        EmpDtl.LocalAddress = objDB.DataReader["localAdd"].ToString();
                        EmpDtl.LocalCity = Int32.Parse(objDB.DataReader["lCity"].ToString());
                        EmpDtl.LocalCountry = Int32.Parse(objDB.DataReader["lCountry"].ToString());
                        EmpDtl.LocalEMail = objDB.DataReader["lEmail"].ToString();
                        EmpDtl.LocalMobile = objDB.DataReader["lMobile"].ToString();
                        EmpDtl.LocalPhoneNo = objDB.DataReader["lPhone"].ToString();
                        EmpDtl.LocalState = Int32.Parse(objDB.DataReader["lState"].ToString());
                        EmpDtl.LocalZipCode = objDB.DataReader["lZipcode"].ToString();
                        EmpDtl.MaritalStatus = objDB.DataReader["meritalStatus"].ToString();
                        EmpDtl.MarkOIdent = objDB.DataReader["markOIdent"].ToString();
                        EmpDtl.Mobile = objDB.DataReader["mobile"].ToString();
                        EmpDtl.ModeAppl = objDB.DataReader["modeAppl"].ToString();
                        EmpDtl.Nationality = objDB.DataReader["nationality"].ToString();
                        EmpDtl.NatureID = objDB.DataReader["natureID"].ToString();
                        EmpDtl.ODayApplied = objDB.DataReader["ODayApp"].ToString();
                        EmpDtl.OffDay = objDB.DataReader["offDay"].ToString();
                        EmpDtl.OTApplied = objDB.DataReader["OTApp"].ToString();
                        EmpDtl.City = Int32.Parse(objDB.DataReader["city"].ToString());
                        EmpDtl.Country = Int32.Parse(objDB.DataReader["country"].ToString());
                        EmpDtl.PermAdd = objDB.DataReader["permAdd"].ToString();
                        EmpDtl.PhoneNo = objDB.DataReader["phone"].ToString();
                        EmpDtl.ProfEdu = Int32.Parse(objDB.DataReader["educProf"].ToString());
                        EmpDtl.RAuthority = Int32.Parse(objDB.DataReader["RAuthority"].ToString());
                        EmpDtl.EmployeeTitle = objDB.DataReader["titleEmp"].ToString();
                        EmpDtl.ReferedBy = objDB.DataReader["referedby"].ToString();
                        EmpDtl.Religion = objDB.DataReader["religion"].ToString();
                        EmpDtl.SpouseName = objDB.DataReader["spouseName"].ToString();
                        EmpDtl.State = Int32.Parse(objDB.DataReader["state"].ToString());
                        EmpDtl.WorkingExp = objDB.DataReader["workExp"].ToString();
                        EmpDtl.ZipCode = objDB.DataReader["zipcode"].ToString();
                        EmpDtl.WEDDDate = Convert.ToDateTime(objDB.DataReader["WedDate"].ToString());
                        EmpDtl.CardNo = objDB.DataReader["CardNo"].ToString();
                        EmpDtl.Status = objDB.DataReader["Status"].ToString();
                        EmpDtl.DGAppr = objDB.DataReader["DGAppr"].ToString();
                        if (objDB.DataReader["ResDate"].ToString() != "")
                        {
                            EmpDtl.Resigndate = Convert.ToDateTime(objDB.DataReader["ResDate"].ToString());
                        }
                        EmpDtl.EmployeeImge = (byte[])objDB.DataReader["image"];
                        EmpDtl.EmployeeSign = (byte[])objDB.DataReader["sign"];
                     
                    }
                }
                catch
                {

                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return EmpDtl;
            }
            protected List<HRM.Fee.EmployeeService> Get_Employee_Services(Int32 EmployeeId)
            {
                List<HRM.Fee.EmployeeService> EmployeeServices = new List<HRM.Fee.EmployeeService>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);

                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "empid", EmployeeId, DbType.Int32);

                    objDB.ExecuteReader(CommandType.StoredProcedure, "[spChildEmpMaster]");

                    HRM.Fee.EmployeeService EmpService = null;

                    while (objDB.DataReader.Read())
                    {
                        EmpService = new Fee.EmployeeService();

                        EmpService.CID = Int32.Parse(objDB.DataReader["cid"].ToString());
                        EmpService.EmployeeId = Int32.Parse(objDB.DataReader["empid"].ToString());
                        EmpService.ServiceId = Int32.Parse(objDB.DataReader["servId"].ToString());
                        EmpService.ServiceName = objDB.DataReader["ServiceName"].ToString();
                        EmpService.Status = objDB.DataReader["status"].ToString();
                        EmpService.WED = Convert.ToDateTime(objDB.DataReader["wed"].ToString());

                        EmployeeServices.Add(EmpService);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return EmployeeServices;
            }
            protected void Save_Employee_Timing_Details(HRM.Fee.EmployeeDetail EmployeeDetail, NewDAL.DBManager objDB)
            {
                //try
                //{
                    objDB.CreateParameters(12);

                    objDB.AddParameters(0, "id", EmployeeDetail.TimeId, DbType.Int32);
                    objDB.AddParameters(1, "empId", EmployeeDetail.EmployeeID, DbType.Int32);
                    objDB.AddParameters(2, "WED", EmployeeDetail.WEDTime, DbType.Date);

                    objDB.AddParameters(3, "InHr", EmployeeDetail.InHr, DbType.Int32);
                    objDB.AddParameters(4, "InMin", EmployeeDetail.InMin, DbType.String);

                    objDB.AddParameters(5, "InSec",EmployeeDetail.InSec  , DbType.Decimal);
                    objDB.AddParameters(6, "OutHr", EmployeeDetail.OutHr, DbType.Int32);
                    objDB.AddParameters(7, "OutMin", EmployeeDetail.OutMin, DbType.Int32);

                    objDB.AddParameters(8, "OutSec", EmployeeDetail.OutSec, DbType.Int32);
                    objDB.AddParameters(9, "flag", EmployeeDetail.flag, DbType.String);
                    objDB.AddParameters(10, "RetSuccess",0, DbType.Int32, ParameterDirection.Output);
                    objDB.AddParameters(11, "Punch", EmployeeDetail.Punch, DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Employee_Timing_Details]");
                    objDB.Command.Parameters.Clear();
                //}
                //catch (Exception ex)
                //{
                //}
                //finally
                //{
                //    objDB.Command.Parameters.Clear();
                //}
            }
         
         
            #endregion

            #region Country Master

            protected string Save_Country(HRM.Fee.CountryDM Country)
            {
                objDB = OpenDALConnection();
                string Retsuccess = string.Empty;
                string retv = string.Empty;
                try
                {
                    objDB.CreateParameters(7);
                    objDB.AddParameters(0, "CountryId", Country.CountryId, DbType.String);
                    objDB.AddParameters(1, "CountryName", Country.CountryName, DbType.String);
                    objDB.AddParameters(2, "SessionID", Country.SessionID, DbType.String);
                    objDB.AddParameters(3, "UserID", Country.UserID, DbType.String);
                    objDB.AddParameters(4, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(5, "Flag", Country.Flag, DbType.String);
                    objDB.AddParameters(6, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spCountry");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch { }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return retv;
            }
            protected List<HRM.Fee.CountryDM> FillGrid(string flag)
            {
                List<HRM.Fee.CountryDM> objCountry = new List<Fee.CountryDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(1);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "spCountry");
                    HRM.Fee.CountryDM item = null;
                    while (objDB.DataReader.Read())
                    {
                        item = new Fee.CountryDM();
                        item.CountryId = Int32.Parse(objDB.DataReader["CountryId"].ToString());
                        item.CountryName = objDB.DataReader["CountryName"].ToString();
                        objCountry.Add(item);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return objCountry;

            } 
            
            #endregion
           
            #region State Master        
           
            protected string Save_State(HRM.Fee.StateDM State)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(8);
                    objDB.AddParameters(0, "CountryId", State.CountryId, DbType.Int32);
                    objDB.AddParameters(1, "StateId", State.StateId, DbType.Int32);
                    objDB.AddParameters(2, "StateName", State.StateName, DbType.String);
                    objDB.AddParameters(3, "SessionID", State.SessionID, DbType.String);
                    objDB.AddParameters(4, "UserID", State.UserID, DbType.String);
                    objDB.AddParameters(5, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(6, "Flag", State.Flag, DbType.String);
                    objDB.AddParameters(7, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spState");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record:";
                }
                return retv;
            }
            protected List<HRM.Fee.StateDM> fillState(string flag)
            {
                List<HRM.Fee.StateDM> objstate = new List<Fee.StateDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(1);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "spState");
                    HRM.Fee.StateDM item = null;
                    while (objDB.DataReader.Read())
                    {
                        item = new Fee.StateDM();
                        item.CountryId = Int32.Parse(objDB.DataReader["CountryId"].ToString());
                        item.StateId = Int32.Parse(objDB.DataReader["StateId"].ToString());
                        item.StateName = objDB.DataReader["StateName"].ToString();
                        item.CountryName = objDB.DataReader["CountryName"].ToString();
                        objstate.Add(item);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); } 
              return objstate;
            }
            #endregion

            #region City Master
            
            protected string Save_City(HRM.Fee.CityDM InsrtCity)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(8);
                    objDB.AddParameters(0, "StateID", InsrtCity.StateID, DbType.Int32);
                    objDB.AddParameters(1, "CityId", InsrtCity.CityId, DbType.Int32);
                    objDB.AddParameters(2, "CityName", InsrtCity.CityName, DbType.String);
                    objDB.AddParameters(3, "SessionID", InsrtCity.SessionID, DbType.String);
                    objDB.AddParameters(4, "UserID", InsrtCity.UserID, DbType.String);
                    objDB.AddParameters(5, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(6, "Flag", InsrtCity.Flag, DbType.String);
                    objDB.AddParameters(7, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spCity");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record:";
                }
                return retv;
            }
            protected List<HRM.Fee.CityDM> FillCity(string flag)
            {
                List<HRM.Fee.CityDM> objCity = new List<Fee.CityDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(1);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "spCity");
                    HRM.Fee.CityDM itemf = null;
                    while (objDB.DataReader.Read())
                    {
                        itemf = new Fee.CityDM();
                        itemf.CityId = Int32.Parse(objDB.DataReader["CityId"].ToString());
                        itemf.CityName = objDB.DataReader["CityName"].ToString();
                        itemf.StateID = Int32.Parse(objDB.DataReader["StateID"].ToString());
                        itemf.statename = objDB.DataReader["statename"].ToString();
                        itemf.Countryid = Int32.Parse(objDB.DataReader["Countryid"].ToString());
                        itemf.CountryName = objDB.DataReader["CountryName"].ToString();
                        objCity.Add(itemf);
                    }
                }
                catch
                {
                }
                finally { objDB.Command.Parameters.Clear(); }
                return objCity;
            } 
            
            #endregion

            #region Education Profile Master
            
            protected string Save_EducProfile(HRM.Fee.EprofDM insrtEprof)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(8);
                    objDB.AddParameters(0, "ProfId", insrtEprof.ProfId, DbType.Int32);
                    objDB.AddParameters(1, "ProfName", insrtEprof.ProfName, DbType.String);
                    objDB.AddParameters(2, "InstituteID", insrtEprof.InstituteID, DbType.Int32);
                    objDB.AddParameters(3, "SessionID", insrtEprof.SessionID, DbType.String);
                    objDB.AddParameters(4, "UserID", insrtEprof.UserID, DbType.String);
                    objDB.AddParameters(5, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(6, "Flag", insrtEprof.Flag, DbType.String);
                    objDB.AddParameters(7, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Educ_Prof");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record:";

                }
                return retv;

            }
            protected List<HRM.Fee.EprofDM> fillEduProfile(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.EprofDM> objProfile = new List<Fee.EprofDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Master_Educ_Prof");
                    HRM.Fee.EprofDM itemF = null;
                    while (objDB.DataReader.Read())
                    {
                        itemF = new Fee.EprofDM();
                        itemF.ProfId = Int32.Parse(objDB.DataReader["ProfId"].ToString());
                        itemF.ProfName = objDB.DataReader["ProfName"].ToString();
                        objProfile.Add(itemF);
                    }
                }
                catch
                {
                }
                finally { objDB.Command.Parameters.Clear(); }
                return objProfile;
            } 
            
            #endregion

            #region OffDay Master

            protected string Save_Offday(HRM.Fee.offdayDM insrtOffday)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(13);
                    objDB.AddParameters(0, "offid", insrtOffday.offid, DbType.Int32);
                    objDB.AddParameters(1, "title", insrtOffday.title, DbType.String);
                    objDB.AddParameters(2, "date", insrtOffday.date, DbType.DateTime);
                    objDB.AddParameters(3, "month", insrtOffday.month, DbType.String);
                    objDB.AddParameters(4, "year", insrtOffday.year, DbType.String);
                    objDB.AddParameters(5, "InstituteID", insrtOffday.InstituteID, DbType.Int32);
                    objDB.AddParameters(6, "SessionID", insrtOffday.SessionID, DbType.String);
                    objDB.AddParameters(7, "UserID", insrtOffday.UserID, DbType.String);
                    objDB.AddParameters(8, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(9, "flag", insrtOffday.flag, DbType.String);
                    objDB.AddParameters(10, "id", insrtOffday.id, DbType.Int32);
                    objDB.AddParameters(11, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(12, "Active", insrtOffday.Active, DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_HR_AddOffDays");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {

                        retv = "Holiday  Saved Successfully.";
                    }
                    if (Retsuccess == "2")
                    {

                        retv = "Holiday Record Updated successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Holiday Record Deleted successfully";
                    }

                    else if (Retsuccess == "4")
                    {

                        retv = "Holiday Name Already Exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Holiday Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record.";
                }
                return retv;

            }
            protected List<HRM.Fee.offdayDM> fillOffday(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.offdayDM> objOffDay = new List<Fee.offdayDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_HR_AddOffDays");
                    HRM.Fee.offdayDM itemF = null;
                    while (objDB.DataReader.Read())
                    {
                        itemF = new Fee.offdayDM();
                        itemF.offid = Int32.Parse(objDB.DataReader["offid"].ToString());
                        itemF.title = objDB.DataReader["title"].ToString();
                        itemF.date = Convert.ToDateTime(objDB.DataReader["date"]);
                        itemF.month = objDB.DataReader["month"].ToString();
                        itemF.year = objDB.DataReader["year"].ToString();
                        itemF.SessionF = objDB.DataReader["SessionF"].ToString();
                        itemF.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        itemF.Active = objDB.DataReader["Active"].ToString();
                        objOffDay.Add(itemF);
                    }
                }
                catch
                {

                }
                finally { objDB.Command.Parameters.Clear(); }
                return objOffDay;
            } 

            #endregion

            #region Services Master

            protected string Save_Services(HRM.Fee.ServiceDM InsrtServ)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(9);
                    objDB.AddParameters(0, "id", InsrtServ.id, DbType.Int32);
                    objDB.AddParameters(1, "ServiceName", InsrtServ.ServiceName, DbType.String);
                    objDB.AddParameters(2, "ServShName", InsrtServ.ServShName, DbType.String);
                    objDB.AddParameters(3, "InstituteID", InsrtServ.InstituteID, DbType.Int32);
                    objDB.AddParameters(4, "SessionID", InsrtServ.SessionID, DbType.String);
                    objDB.AddParameters(5, "UserID", InsrtServ.UserID, DbType.String);
                    objDB.AddParameters(6, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(7, "flag", InsrtServ.flag, DbType.String);
                    objDB.AddParameters(8, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                  //  objDB.AddParameters(9, "WED", InsrtServ.WED, DbType.String);
                    //objDB.AddParameters(10, "SType", InsrtServ.SType, DbType.String);
                    //objDB.AddParameters(11, "Amt", InsrtServ.Amt, DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "spService");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Service Name already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                    else if (Retsuccess == "6")
                    {
                        retv = "Service Short Name already exists.";
                    }
                }
                catch (Exception)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record:";
                }
                finally { objDB.Command.Parameters.Clear(); }
                return retv;
            }

            protected string Save_Services_Details(HRM.Fee.ServiceDM InsrtServ)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(11);
                    objDB.AddParameters(0, "id", InsrtServ.id, DbType.Int32);
                    objDB.AddParameters(1, "ServiceId", InsrtServ.ServiceId, DbType.String);
                    objDB.AddParameters(2, "InstituteID", InsrtServ.InstituteID, DbType.Int32);
                    objDB.AddParameters(3, "SessionID", InsrtServ.SessionID, DbType.String);
                    objDB.AddParameters(4, "UserID", InsrtServ.UserID, DbType.String);
                    objDB.AddParameters(5, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(6, "flag", InsrtServ.flag, DbType.String);
                    objDB.AddParameters(7, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(8, "WED", InsrtServ.WED, DbType.String);
                    objDB.AddParameters(9, "SType", InsrtServ.SType, DbType.String);
                    objDB.AddParameters(10, "Amt", InsrtServ.Amt, DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[sp_ServiceDetailsMaster]");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Service Details Saved Successfully.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Service Details Updated successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Service Details Deleted successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Service Name already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Service in  used.";
                    }
                    else if (Retsuccess == "6")
                    {
                        retv = "Service Short Name already exists.";
                    }
                }
                catch (Exception)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record:";
                }
                finally { objDB.Command.Parameters.Clear(); }
                return retv;
            }

            protected List<HRM.Fee.ServiceDM> fillServices(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.ServiceDM> objServices = new List<Fee.ServiceDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "spService");
                    HRM.Fee.ServiceDM itemF = null;
                    while (objDB.DataReader.Read())
                    {
                        itemF = new HRM.Fee.ServiceDM();
                        itemF.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        itemF.ServiceName = objDB.DataReader["ServiceName"].ToString();
                        itemF.ServShName = objDB.DataReader["ServShName"].ToString();
                        objServices.Add(itemF);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return objServices;
            }

            #endregion

            #region Master Employee Nature
            protected string Save_EmpNAture(HRM.Fee.EmpNatureDM InsrtEmpNature)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(10);
                    objDB.AddParameters(0, "natureID", InsrtEmpNature.natureID, DbType.Int32);
                    objDB.AddParameters(1, "nature", InsrtEmpNature.nature, DbType.String);
                    objDB.AddParameters(2, "InstituteID", InsrtEmpNature.InstituteID, DbType.Int32);
                    objDB.AddParameters(3, "SessionID", InsrtEmpNature.SessionID, DbType.String);
                    objDB.AddParameters(4, "UserID", InsrtEmpNature.UserID, DbType.String);
                    objDB.AddParameters(5, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(6, "flag", InsrtEmpNature.flag, DbType.String);
                    objDB.AddParameters(7, "validFrom", InsrtEmpNature.validFrom, DbType.DateTime);
                    objDB.AddParameters(8, "validTo", InsrtEmpNature.validTo, DbType.DateTime);
                    objDB.AddParameters(9, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_Emp_Nature");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save Record";
                }
                finally { objDB.Command.Parameters.Clear(); }
                return retv;
            }
            protected List<HRM.Fee.EmpNatureDM> FillEmpNature(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.EmpNatureDM> objEmpNature = new List<Fee.EmpNatureDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Master_Emp_Nature");
                    HRM.Fee.EmpNatureDM ItemF = null;
                    while (objDB.DataReader.Read())
                    {
                        ItemF = new Fee.EmpNatureDM();
                        ItemF.natureID = Int32.Parse(objDB.DataReader["natureID"].ToString());
                        ItemF.nature = objDB.DataReader["nature"].ToString();
                        ItemF.validFrom = Convert.ToDateTime(objDB.DataReader["validFrom"].ToString());
                        ItemF.validTo = Convert.ToDateTime(objDB.DataReader["validTo"].ToString());
                        objEmpNature.Add(ItemF);
                    }
                }
                catch
                { }
                finally { objDB.Command.Parameters.Clear(); }
                return objEmpNature;

            }
            
            #endregion
            #region IDisposable Members

            public void Dispose()
            {
                objDB.Dispose();
            }

            #endregion
        }
    }
    namespace Recruit
    {
        public abstract class Recruit_DataLayer : IDisposable
        {
            protected   NewDAL.DBManager objDB = null;
            private   NewDAL.DBManager OpenDALConnection()
            {
                objDB = new   NewDAL.DBManager();
                //objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
                objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
                objDB.Open();

                return objDB;
            }

            protected string Save_PanelMemb(HRM.Recruitment.PannelMemb objPanelMem)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string Retsuccess = String.Empty;
                    objDB.CreateParameters(11);
                    objDB.AddParameters(0, "id", objPanelMem.id, DbType.Int32);
                    objDB.AddParameters(1, "deptId", objPanelMem.deptId, DbType.Int32);
                    objDB.AddParameters(2, "jobId", objPanelMem.jobId, DbType.Int32);
                    objDB.AddParameters(3, "jobTitle", objPanelMem.jobTitle, DbType.String);
                    objDB.AddParameters(4, "mem_id", objPanelMem.mem_id, DbType.Int32);
                    objDB.AddParameters(5, "InstituteID", objPanelMem.InstituteID, DbType.Int32);
                    objDB.AddParameters(6, "SessionID", objPanelMem.SessionID, DbType.String);
                    objDB.AddParameters(7, "UserID", objPanelMem.UserID, DbType.String);
                    objDB.AddParameters(8, "UEDate", objPanelMem.UEDate, DbType.DateTime);
                    objDB.AddParameters(9, "flag", objPanelMem.flag, DbType.String);
                    objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Hr_Panel_Member");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record";
                }
                return retv;
            }
            protected List<HRM.Recruitment.PannelMemb> fillPanelMem(string flag, Int32 InstituteID)
            {
                List<HRM.Recruitment.PannelMemb> listPanelMem = new List<Recruitment.PannelMemb>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", flag, DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Hr_Panel_Member");
                    HRM.Recruitment.PannelMemb item = null;
                    while (objDB.DataReader.Read())
                    {
                        item = new HRM.Recruitment.PannelMemb();
                        item.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        item.deptId = Int32.Parse(objDB.DataReader["deptId"].ToString());
                        item.jobId = Int32.Parse(objDB.DataReader["jobId"].ToString());
                        item.jobTitle = objDB.DataReader["jobTitle"].ToString();
                        item.mem_id = Int32.Parse(objDB.DataReader["mem_id"].ToString());
                        item.memName = objDB.DataReader["memName"].ToString();
                        item.DepartmentName = objDB.DataReader["DepartmentName"].ToString();
                        item.jobCode = objDB.DataReader["jobCode"].ToString();
                        listPanelMem.Add(item);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return listPanelMem;
            }
            //protected List<HRM.Recruitment.CandRecruitDM> fillCandVacancy(flag,DateTime date, 
            protected string Save_Vacancy(HRM.Recruitment.AddJobVac objAddVac)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(29);
                    objDB.AddParameters(0, "jobId", objAddVac.jobId, DbType.Int32);
                    objDB.AddParameters(1, "jobCode", objAddVac.jobCode, DbType.String);
                    objDB.AddParameters(2, "title", objAddVac.title, DbType.String);
                    objDB.AddParameters(3, "deptId", objAddVac.deptId, DbType.Int32);
                    objDB.AddParameters(4, "desigId", objAddVac.desigId, DbType.Int32);
                    objDB.AddParameters(5, "salfrom", objAddVac.salFrom, DbType.String);
                    objDB.AddParameters(6, "salTo", objAddVac.salTo, DbType.String);
                    objDB.AddParameters(7, "maxAge", objAddVac.maxAge, DbType.Int32);
                    objDB.AddParameters(8, "tExp", objAddVac.tExp, DbType.Decimal);
                    objDB.AddParameters(9, "FromExp", objAddVac.MaxExp, DbType.Decimal);
                    objDB.AddParameters(10, "responsibility", objAddVac.responsibility, DbType.String);
                    objDB.AddParameters(11, "tVacancy", objAddVac.tVacancy, DbType.Decimal);
                    objDB.AddParameters(12, "aDate", objAddVac.aDate, DbType.DateTime);
                    objDB.AddParameters(13, "lDate", objAddVac.lDate, DbType.DateTime);
                    objDB.AddParameters(14, "qualId", objAddVac.qualId, DbType.String);
                    objDB.AddParameters(15, "SkillID", objAddVac.SkillID, DbType.String);
                    objDB.AddParameters(16, "TestID", objAddVac.TestId, DbType.String);
                    objDB.AddParameters(17, "Criteria", objAddVac.Criteria, DbType.String);
                    objDB.AddParameters(18, "percentage", objAddVac.percentage, DbType.String);
                    objDB.AddParameters(19, "InstituteID", objAddVac.InstituteID, DbType.Int32);
                    objDB.AddParameters(20, "SessionID", objAddVac.SessionID, DbType.String);
                    objDB.AddParameters(21, "UserID", objAddVac.UserID, DbType.String);
                    objDB.AddParameters(22, "UEDate", objAddVac.UEDate, DbType.DateTime);
                    objDB.AddParameters(23, "TestName", objAddVac.testName, DbType.String);
                    objDB.AddParameters(24, "SalGrade", objAddVac.salGrade, DbType.String);
                    objDB.AddParameters(25, "approveby", objAddVac.approvby, DbType.String);
                    objDB.AddParameters(26, "flag", objAddVac.flag, DbType.String);
                    objDB.AddParameters(27, "Retsuccess", "0", DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(28, "MinAge", objAddVac.MinAge, DbType.Int32);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Add_vacancy");

                    Retsuccess = objDB.Command.Parameters["@Retsuccess"].ToString();
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Record is not saved";
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return retv;
            }


            protected string Save_JobProfile(HRM.Recruitment.JobProfileDM InsrtJobProf)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(11);
                    objDB.AddParameters(0, "id", InsrtJobProf.id, DbType.Int32);
                    objDB.AddParameters(1, "deptId", InsrtJobProf.deptId, DbType.Int32);
                    objDB.AddParameters(2, "desigId", InsrtJobProf.desigId, DbType.Int32);
                    objDB.AddParameters(3, "rdeptId", InsrtJobProf.rdeptId, DbType.Int32);
                    objDB.AddParameters(4, "authority", InsrtJobProf.authority, DbType.Int32);
                    objDB.AddParameters(5, "InstituteID", InsrtJobProf.InstituteID, DbType.Int32);
                    objDB.AddParameters(6, "SessionID", InsrtJobProf.SessionID, DbType.String);
                    objDB.AddParameters(7, "UserID", InsrtJobProf.UserID, DbType.String);
                    objDB.AddParameters(8, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(9, "flag", InsrtJobProf.flag, DbType.String);
                    objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_job_profile_M");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record is saved.";
                    }
                    else if (Retsuccess == "2")
                    {
                        retv = "Update Successfully.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete Successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "record is in use";
                    }
                }
                catch
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record";
                }
                finally { objDB.Command.Parameters.Clear(); }
                return retv;
            }
            protected List<HRM.Recruitment.JobProfileDM> fillJobProfile(string flag, Int32 InstituteID)
            {
                List<HRM.Recruitment.JobProfileDM> ObjFill = new List<Recruitment.JobProfileDM>();

                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_job_profile_M");
                    HRM.Recruitment.JobProfileDM itemF = null;

                    while (objDB.DataReader.Read())
                    {
                        itemF = new Recruitment.JobProfileDM();
                        itemF.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        itemF.deptId = Int32.Parse(objDB.DataReader["deptId"].ToString());
                        itemF.desigId = Int32.Parse(objDB.DataReader["desigId"].ToString());
                        itemF.rdeptId = Int32.Parse(objDB.DataReader["rdeptId"].ToString());
                        itemF.authority = Int32.Parse(objDB.DataReader["authority"].ToString());
                        itemF.Auth = objDB.DataReader["Auth"].ToString();
                        itemF.rDept = objDB.DataReader["rDept"].ToString();
                        itemF.dept = objDB.DataReader["dept"].ToString();
                        itemF.Designation = objDB.DataReader["Designation"].ToString();
                        ObjFill.Add(itemF);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return ObjFill;
            }
            #region Interview Round
            protected string Save_IntrvRound(HRM.Recruitment.IntrRoundDM insrtIntrvRnd)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(13);
                    objDB.AddParameters(0, "id", insrtIntrvRnd.id, DbType.Int32);
                    objDB.AddParameters(1, "deptId", insrtIntrvRnd.deptId, DbType.Int32);
                    objDB.AddParameters(2, "jobId", insrtIntrvRnd.jobId, DbType.Int32);
                    objDB.AddParameters(3, "jobCode", insrtIntrvRnd.jobCode, DbType.String);
                    objDB.AddParameters(4, "jobTitle", insrtIntrvRnd.jobTitle, DbType.String);
                    objDB.AddParameters(5, "interv_R", insrtIntrvRnd.interv_R, DbType.String);
                    objDB.AddParameters(6, "InstituteID", insrtIntrvRnd.InstituteID, DbType.Int32);
                    objDB.AddParameters(7, "SessionID", insrtIntrvRnd.SessionID, DbType.String);
                    objDB.AddParameters(8, "UserID", insrtIntrvRnd.UserID, DbType.String);
                    objDB.AddParameters(9, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(10, "flag", insrtIntrvRnd.flag, DbType.String);
                    objDB.AddParameters(11, "maxPoint", insrtIntrvRnd.maxPoint, DbType.Int32);
                    objDB.AddParameters(12, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_intervRound");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    else if (Retsuccess == "2")
                    {
                        retv = "Update Successfully.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete Successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "record is in use";
                    }
                }
                catch (Exception)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record.";
                }
                finally { objDB.Command.Parameters.Clear(); }
                return retv;
            }
            protected List<HRM.Recruitment.IntrRoundDM> Fill_IntrvRnd(string flag, string SessionID, Int32 InstituteID)
            {
                List<HRM.Recruitment.IntrRoundDM> ObjFill = new List<Recruitment.IntrRoundDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(3);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "SessionID", SessionID, DbType.String);
                    objDB.AddParameters(2, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_intervRound");
                    HRM.Recruitment.IntrRoundDM itemF = null;
                    while (objDB.DataReader.Read())
                    {
                        itemF = new Recruitment.IntrRoundDM();
                        itemF.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        itemF.deptId = Int32.Parse(objDB.DataReader["deptId"].ToString());
                        itemF.jobId = Int32.Parse(objDB.DataReader["jobId"].ToString());
                        itemF.jobCode = objDB.DataReader["jobCode"].ToString();
                        itemF.jobTitle = objDB.DataReader["jobTitle"].ToString();
                        itemF.interv_R = objDB.DataReader["interv_R"].ToString();
                        itemF.maxPoint = Int32.Parse(objDB.DataReader["maxPoint"].ToString());
                        itemF.DepartmentName = objDB.DataReader["DepartmentName"].ToString();
                        ObjFill.Add(itemF);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return ObjFill;
            }
            #endregion
            #region Feed Back

            protected string Save_Feedback(HRM.Recruitment.FeedbackDM InsrtFdbk)
            {
                objDB = OpenDALConnection();
                string retv = string.Empty;
                try
                {
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(17);
                    objDB.AddParameters(0, "id", InsrtFdbk.id, DbType.Int32);
                    objDB.AddParameters(1, "candId", InsrtFdbk.candId, DbType.Int32);
                    objDB.AddParameters(2, "deptID", InsrtFdbk.deptID, DbType.Int32);
                    objDB.AddParameters(3, "desigID", InsrtFdbk.desigID, DbType.Int32);
                    objDB.AddParameters(4, "intrvR", InsrtFdbk.intrvR, DbType.Int32);
                    objDB.AddParameters(5, "feedbk", InsrtFdbk.feedbk, DbType.String);
                    objDB.AddParameters(6, "plcmMem", InsrtFdbk.plcmMem, DbType.String);
                    objDB.AddParameters(7, "Ondate", InsrtFdbk.Ondate, DbType.DateTime);
                    objDB.AddParameters(8, "jobId", InsrtFdbk.jobId, DbType.Int32);
                    objDB.AddParameters(9, "maxPoint", InsrtFdbk.maxPoint, DbType.Int32);
                    objDB.AddParameters(10, "pointEarned", InsrtFdbk.pointEarned, DbType.Int32);
                    objDB.AddParameters(11, "InstituteID", InsrtFdbk.InstituteID, DbType.Int32);
                    objDB.AddParameters(12, "SessionID", InsrtFdbk.SessionID, DbType.String);
                    objDB.AddParameters(13, "UserID", InsrtFdbk.UserID, DbType.String);
                    objDB.AddParameters(14, "UEDate", DateTime.Today.Date, DbType.DateTime);
                    objDB.AddParameters(15, "flag", InsrtFdbk.flag, DbType.String);
                    objDB.AddParameters(16, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Interv_Feedbk");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();//plcmMem
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record.";
                }
                finally { objDB.Command.Parameters.Clear(); }
                return retv;
            }
            protected List<HRM.Recruitment.FeedbackDM> Fill_FeedBK(string flag)
            {
                List<HRM.Recruitment.FeedbackDM> ObjFill = new List<Recruitment.FeedbackDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(1);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Interv_Feedbk");
                    HRM.Recruitment.FeedbackDM itemF = null;
                    while (objDB.DataReader.Read())
                    {
                        itemF = new Recruitment.FeedbackDM();
                        itemF.id = Int32.Parse(objDB.DataReader["id"].ToString());
                        itemF.maxPoint = Int32.Parse(objDB.DataReader["maxPoint"].ToString());
                        itemF.pointEarned = Int32.Parse(objDB.DataReader["pointEarned"].ToString());
                        itemF.candId = Int32.Parse(objDB.DataReader["candId"].ToString());
                        itemF.deptID = Int32.Parse(objDB.DataReader["deptID"].ToString());
                        itemF.desigID = Int32.Parse(objDB.DataReader["desigID"].ToString());
                        itemF.intrvR = Int32.Parse(objDB.DataReader["intrvR"].ToString());
                        itemF.feedbk = objDB.DataReader["feedbk"].ToString();
                        itemF.Designation = objDB.DataReader["Designation"].ToString();
                        itemF.DepartmentName = objDB.DataReader["DepartmentName"].ToString();
                        itemF.candName = objDB.DataReader["candName"].ToString();
                        itemF.authority = objDB.DataReader["authority"].ToString();
                        itemF.interv_R = objDB.DataReader["interv_R"].ToString();
                        itemF.Ondate = Convert.ToDateTime(objDB.DataReader["Ondate"].ToString());
                        itemF.title = Int32.Parse(objDB.DataReader["title"].ToString());
                        itemF.jobId = Int32.Parse(objDB.DataReader["jobId"].ToString());
                        ObjFill.Add(itemF);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }

                return ObjFill;
            }
            protected List<HRM.Recruitment.FeedbackDM> fill_Member(string flag, Int32 id)
            {
                List<HRM.Recruitment.FeedbackDM> GetMember = new List<Recruitment.FeedbackDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "C", DbType.String);
                    objDB.AddParameters(1, "id", id, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Interv_Feedbk");
                    HRM.Recruitment.FeedbackDM objMem = null;
                    while (objDB.DataReader.Read())
                    {
                        objMem = new Recruitment.FeedbackDM();
                        objMem.memId = Int32.Parse(objDB.DataReader["memId"].ToString());
                        GetMember.Add(objMem);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return GetMember;
            }
            protected HRM.Recruitment.FeedbackDM get_Detail(string flag, Int32 candId)
            {
                HRM.Recruitment.FeedbackDM MemDetl = null;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "I", DbType.String);
                    objDB.AddParameters(1, "CandId", candId, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Interv_Feedbk");

                    if (objDB.DataReader.Read())
                    {
                        MemDetl = new Recruitment.FeedbackDM();
                        MemDetl.deptID = Int32.Parse(objDB.DataReader["deptID"].ToString());
                        MemDetl.desigID = Int32.Parse(objDB.DataReader["desigID"].ToString());
                        MemDetl.maxPoint = Int32.Parse(objDB.DataReader["maxPoint"].ToString());
                        MemDetl.DepartmentName = objDB.DataReader["DepartmentName"].ToString();
                        MemDetl.interv_R = objDB.DataReader["interv_R"].ToString();
                        MemDetl.dateFrom = Convert.ToDateTime(objDB.DataReader["dateFrom"].ToString());
                        MemDetl.Designation = objDB.DataReader["Designation"].ToString();
                        MemDetl.idR = Int32.Parse(objDB.DataReader["idR"].ToString());
                        MemDetl.intrvStatus = objDB.DataReader["intrvStatus"].ToString();

                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return MemDetl;
            }

            #endregion
            #region Candidate Enrollement Master
            protected string insertselectedcandidate(List<HRM.Recruitment.selctedcandDM> objslctcand)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    foreach (HRM.Recruitment.selctedcandDM objslcnd in objslctcand)
                    {
                        objDB.CreateParameters(13);
                        objDB.AddParameters(0, "id", objslcnd.id, DbType.Int32);
                        objDB.AddParameters(1, "deptid", objslcnd.deptid, DbType.Int32);
                        objDB.AddParameters(2, "desigid", objslcnd.desigid, DbType.Int32);
                        objDB.AddParameters(3, "jobid", objslcnd.jobid, DbType.Int32);
                        objDB.AddParameters(4, "jobtitle", objslcnd.jobtitle, DbType.String);
                        objDB.AddParameters(5, "candid", objslcnd.candid, DbType.Int32);
                        objDB.AddParameters(6, "payscale", objslcnd.payscale, DbType.String);
                        objDB.AddParameters(7, "InstituteID", objslcnd.InstituteID, DbType.Int32);
                        objDB.AddParameters(8, "SessionID", objslcnd.SessionID, DbType.String);
                        objDB.AddParameters(9, "UserID", objslcnd.UserID, DbType.String);
                        objDB.AddParameters(10, "UEDate", DateTime.Today.Date, DbType.DateTime);
                        objDB.AddParameters(11, "flag", objslcnd.flag, DbType.String);
                        objDB.AddParameters(12, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                        objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Hr_SelectedCand");
                        Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    }
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record";
                }
                return retv;
            }
            protected List<HRM.Recruitment.selctedcandDM> fillslcsnd(Int32 catid, Int32 deptid, Int32 desigid, Int32 instituteid)
            {
                var listitem = new List<HRM.Recruitment.selctedcandDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(5);
                    objDB.AddParameters(0, "flag", "S", DbType.String);
                    objDB.AddParameters(1, "catid", catid, DbType.Int32);
                    objDB.AddParameters(2, "deptid", deptid, DbType.Int32);
                    objDB.AddParameters(3, "desigid", desigid, DbType.Int32);
                    objDB.AddParameters(4, "instituteid", instituteid, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Hr_SelectedCand");
                    HRM.Recruitment.selctedcandDM item = null;
                    while (objDB.DataReader.Read())
                    {
                        item = new HRM.Recruitment.selctedcandDM();
                        item.name = objDB.DataReader["name"].ToString();
                        item.candid = Int32.Parse(objDB.DataReader["candid"].ToString());
                        item.payscale = objDB.DataReader["payscale"].ToString();
                        listitem.Add(item);
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return listitem;
            }
            protected HRM.Recruitment.selctedcandDM Get_MSalaryGrade(string flag, Int32 candId)
            {
                HRM.Recruitment.selctedcandDM GradeSal = null;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", "I", DbType.String);
                    objDB.AddParameters(1, "CandId", candId, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Hr_SelectedCand");
                    if (objDB.DataReader.Read())
                    {
                        GradeSal = new Recruitment.selctedcandDM();
                        GradeSal.salFrom = Int32.Parse(objDB.DataReader["salFrom"].ToString());
                    }
                }
                catch { }
                finally { objDB.Command.Parameters.Clear(); }
                return GradeSal;
            }
            #endregion

            protected List<HRM.Recruitment.AddJobVac> FillCandVacancy(string flag, Int32 InstituteID, string SessionID)
            {
                List<HRM.Recruitment.AddJobVac> ObjFill = new List<Recruitment.AddJobVac>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(4);
                    objDB.AddParameters(0, "UEDate", System.DateTime.Now, DbType.DateTime);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.AddParameters(2, "SessionID", SessionID, DbType.String);
                    objDB.AddParameters(3, "flag", flag, DbType.String);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Cand_Recruit");
                    HRM.Recruitment.AddJobVac item;
                    while (objDB.DataReader.Read())
                    {
                        item = new Recruitment.AddJobVac();
                        //Designation, Department.DepartmentName, master_Nature.nature AS title
                        item.jobId = Int32.Parse(objDB.DataReader["jobId"].ToString());
                        item.jobCode = objDB.DataReader["jobCode"].ToString();
                        item.deptId = Int32.Parse(objDB.DataReader["deptId"].ToString());
                        item.desigId = Int32.Parse(objDB.DataReader["desigId"].ToString());
                        // item.payStruct = Convert.ToInt32(objDB.DataReader["sGrade"]);
                        //item.payStruct = Int32.Parse(objDB.DataReader["payStruct"].ToString());
                        // item.minAge = Int32.Parse(objDB.DataReader["minAge"].ToString());
                        item.maxAge = Int32.Parse(objDB.DataReader["maxAge"].ToString());

                        item.tExp = Convert.ToDecimal(objDB.DataReader["tExp"].ToString());
                        item.responsibility = objDB.DataReader["responsibility"].ToString();
                        item.tVacancy = Convert.ToDecimal(objDB.DataReader["tVacancy"].ToString());
                        item.aDate = Convert.ToDateTime(objDB.DataReader["aDate"].ToString());
                        item.lDate = Convert.ToDateTime(objDB.DataReader["lDate"].ToString());
                       // item.percentage = Convert.ToDecimal(objDB.DataReader["percentage"].ToString());
                        item.qualId = objDB.DataReader["qualId"].ToString();

                        item.Designation = objDB.DataReader["Designation"].ToString();
                        item.DepartmentName = objDB.DataReader["DepartmentName"].ToString();

                        item.title1 = objDB.DataReader["title"].ToString();
                        ObjFill.Add(item);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                return ObjFill;
            }

            protected string Save_CandidateResume(HRM.Recruitment.CandRecruitDM objCandRes)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(29);
                    objDB.AddParameters(0, "candid", objCandRes.candid, DbType.Int32);
                    objDB.AddParameters(1, "email", objCandRes.email, DbType.String);
                    objDB.AddParameters(2, "fName", objCandRes.fName, DbType.String);
                    objDB.AddParameters(3, "lName", objCandRes.lName, DbType.String);
                    objDB.AddParameters(4, "ph", objCandRes.ph, DbType.String);
                    objDB.AddParameters(5, "mob", objCandRes.mob, DbType.String);
                    objDB.AddParameters(6, "cLoc", objCandRes.cLoc, DbType.Int32);
                    objDB.AddParameters(7, "pLoc", objCandRes.pLoc, DbType.Int32);
                    objDB.AddParameters(8, "exYear", objCandRes.exYear, DbType.Int32);
                    objDB.AddParameters(9, "exMon", objCandRes.exMon, DbType.Int32);
                    objDB.AddParameters(10, "nation", objCandRes.nation, DbType.String);
                    objDB.AddParameters(11, "gender", objCandRes.gender, DbType.String);
                    objDB.AddParameters(12, "skills", objCandRes.skills, DbType.String);
                    objDB.AddParameters(13, "qualId", objCandRes.qualId, DbType.String);
                    objDB.AddParameters(14, "yPass", objCandRes.yPass, DbType.Int32);
                    objDB.AddParameters(15, "inst", objCandRes.inst, DbType.String);
                    objDB.AddParameters(16, "resumeName", objCandRes.resumeName, DbType.String);
                    objDB.AddParameters(17, "catId", objCandRes.catId, DbType.Int32);
                    objDB.AddParameters(18, "_percent", objCandRes._percent, DbType.Decimal);
                    objDB.AddParameters(19, "ref", objCandRes.refe, DbType.String);
                    objDB.AddParameters(20, "InstituteID", objCandRes.InstituteID, DbType.Int32);
                    objDB.AddParameters(21, "SessionID", objCandRes.SessionID, DbType.String);
                    objDB.AddParameters(22, "UserID", objCandRes.UserID, DbType.String);
                    objDB.AddParameters(23, "UEDate", objCandRes.UEDate, DbType.DateTime);
                    objDB.AddParameters(24, "flag", objCandRes.flag, DbType.String);
                    objDB.AddParameters(25, "ApplyDate", objCandRes.ApplyDate, DbType.DateTime);
                    objDB.AddParameters(26, "CurrEmp", objCandRes.CurrEmp, DbType.String);
                    objDB.AddParameters(27, "Designation", objCandRes.Designation, DbType.String);
                    objDB.AddParameters(28, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Cand_Recruit");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@Retsuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Yours registration is done Successfully ";
                    }
                    if (Retsuccess == "4")
                    {
                        retv = "You are already resgistered.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Unable to save record";

                }
                return retv;

            }

            #region IDisposable Members

            public void Dispose()
            {
                objDB.Dispose();
            }

            #endregion
        }
    }
    namespace Payroll
    {
        public abstract class Paroll_DataLayer : IDisposable
        {           
            protected   NewDAL.DBManager objDB = null;
            private   NewDAL.DBManager OpenDALConnection()
            {
                objDB = new   NewDAL.DBManager();
                //objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
                objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
                objDB.Open();

                return objDB;
            }
            protected string saveSession(HRM.PayRollDM.Sesssion objSeson)
            {
                //  NewDAL.DBManager objDB = new DBManager();
                //objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
                //objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    //objDB.Open();
                    //objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(11);
                    objDB.AddParameters(0, "Id", objSeson.Id, DbType.Int32);
                    objDB.AddParameters(1, "SessionF", objSeson.SessionF, DbType.String);
                    objDB.AddParameters(2, "StartDate", objSeson.StartDate, DbType.DateTime);
                    objDB.AddParameters(3, "EndDate", objSeson.EndDate, DbType.DateTime);
                    objDB.AddParameters(4, "InstituteID", objSeson.InstituteID, DbType.Int32);
                    objDB.AddParameters(5, "Active", objSeson.Active, DbType.String);
                    objDB.AddParameters(6, "UserID", objSeson.UserID, DbType.String);
                    objDB.AddParameters(7, "UEDate", objSeson.UEDate, DbType.DateTime);
                    objDB.AddParameters(8, "SessionID", objSeson.SessionID, DbType.String);
                    objDB.AddParameters(9, "flag", objSeson.flag, DbType.String);
                    objDB.AddParameters(10, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Payroll_Session");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    //objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {

                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }

                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";

                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    //objDB.Transaction.Rollback();
                    retv = "Unable to save record.";

                }
                return retv;
            }

            public string insertMAXDA(HRM.PayRollDM.MAXDA DA)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string RetSuccess = string.Empty;
                    objDB.Command.Parameters.Clear();
                    objDB.CreateParameters(10);
                    objDB.AddParameters(0, "id", DA.id, DbType.String);
                    objDB.AddParameters(1, "wed", DA.wed, DbType.String);
                    objDB.AddParameters(2, "NatureId", DA.NatureId, DbType.String);
                    objDB.AddParameters(3, "InstituteID", DA.InstituteID, DbType.Int32);
                    objDB.AddParameters(4, "SessionID", DA.SessionID, DbType.String);
                    objDB.AddParameters(5, "UserID", DA.UserID, DbType.String);
                    objDB.AddParameters(6, "UEDate", DA.UEDate, DbType.Date);
                    objDB.AddParameters(7, "flag", DA.flag, DbType.String);
                    objDB.AddParameters(8, "MaxDA", DA.MaxDA, DbType.Date);
                    objDB.AddParameters(9, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Payroll_MaxDA]");
                    RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();


                    if (RetSuccess == "4")
                    {
                        objDB.Transaction.Rollback();
                        retv = "MaxDA details not saved.";

                    }
                    else if (RetSuccess == "5")
                    {
                        objDB.Transaction.Rollback();
                        retv = "MaxDA details not update";
                    }

                    else if (RetSuccess == "6")
                    {
                        objDB.Transaction.Rollback();
                        retv = "MaxDA details not Delete";


                    }
                    else if (RetSuccess == "1")
                    {

                        objDB.Transaction.Commit();
                        retv = "MaxDA details Saved Successfully";

                    }
                    else if (RetSuccess == "2")
                    {

                        objDB.Transaction.Commit();
                        retv = "MaxDA details Updated Successfully";
                    }
                    else if (RetSuccess == "3")
                    {

                        objDB.Transaction.Commit();
                        retv = "MaxDA details Deleted Successfully";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();

                }
                return retv;

            }

            public string insertAppraisalReq(HRM.PayRollDM.AppraisalReq AppraisalReq)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string RetSuccess = string.Empty;
                    objDB.Command.Parameters.Clear();
                    objDB.CreateParameters(18);
                    objDB.AddParameters(0, "ARid", AppraisalReq.ARid, DbType.Int32);
                    objDB.AddParameters(1, "Empid", AppraisalReq.Empid, DbType.Int32);
                    objDB.AddParameters(2, "Empcode", AppraisalReq.Empcode, DbType.String);
                    objDB.AddParameters(3, "DeptId", AppraisalReq.DeptId, DbType.Int32);
                    objDB.AddParameters(4, "RepAuthority", AppraisalReq.RepAuthority, DbType.Int32);
                    objDB.AddParameters(5, "TI", AppraisalReq.TI, DbType.Double);
                    objDB.AddParameters(6, "TE1", AppraisalReq.TE1, DbType.Double);
                    objDB.AddParameters(7, "TE2", AppraisalReq.TE2, DbType.Double);
                    objDB.AddParameters(8, "OddSem", AppraisalReq.OddSem, DbType.String);
                    objDB.AddParameters(9, "EvenSem", AppraisalReq.EvenSem, DbType.String);
                    objDB.AddParameters(10, "AR", AppraisalReq.AR, DbType.String);
                    objDB.AddParameters(11, "AppliedDt", AppraisalReq.AppliedDt, DbType.DateTime);
                    objDB.AddParameters(12, "InstituteID", AppraisalReq.InstituteID, DbType.Int32);
                    objDB.AddParameters(13, "SessionID", AppraisalReq.SessionId, DbType.String);
                    objDB.AddParameters(14, "UserID", AppraisalReq.UserID, DbType.String);
                    objDB.AddParameters(15, "UEDate", AppraisalReq.UEDate, DbType.Date);
                    objDB.AddParameters(16, "flag", AppraisalReq.flag, DbType.String);
                    objDB.AddParameters(17, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Payroll_Appraisal_Req]");
                    RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();


                    if (RetSuccess == "4")
                    {
                        objDB.Transaction.Rollback();
                        retv = "Appraisal Request already Exists.";

                    }
                    else if (RetSuccess == "5")
                    {
                        objDB.Transaction.Rollback();
                        retv = "Appraisal Request can not update";
                    }

                    else if (RetSuccess == "6")
                    {
                        objDB.Transaction.Rollback();
                        retv = "Appraisal Request not Delete";


                    }
                    else if (RetSuccess == "1")
                    {

                        objDB.Transaction.Commit();
                        retv = "Appraisal Request Saved Successfully";

                    }
                    else if (RetSuccess == "2")
                    {

                        objDB.Transaction.Commit();
                        retv = "Appraisal Request Updated Successfully";
                    }
                    else if (RetSuccess == "3")
                    {

                        objDB.Transaction.Commit();
                        retv = "Appraisal Request Deleted Successfully";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();

                }
                return retv;

            }


            public string insertAppraisalHOD(HRM.PayRollDM.AppraisalHOD AppraisalHOD)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();
                    objDB.BeginTransaction();
                    string RetSuccess = string.Empty;
                    objDB.Command.Parameters.Clear();
                    objDB.CreateParameters(20);
                    objDB.AddParameters(0, "Id", AppraisalHOD.Id , DbType.Int32);
                    objDB.AddParameters(1, "ArId", AppraisalHOD.ARid , DbType.Int32);
                    objDB.AddParameters(2, "deptId", AppraisalHOD.DeptId, DbType.Int32);
                    objDB.AddParameters(3, "RepAuthority", AppraisalHOD.RepAuthority, DbType.Int32);
                    objDB.AddParameters(4, "AcadPerform", AppraisalHOD.AcadPerform , DbType.Decimal);
                    objDB.AddParameters(5, "MainofSub", AppraisalHOD.MainofSub, DbType.Decimal);
                    objDB.AddParameters(6, "MainofStuRec", AppraisalHOD.MainofStuRec, DbType.Decimal);
                    objDB.AddParameters(7, "Compile", AppraisalHOD.Compile, DbType.Decimal);
                    objDB.AddParameters(8, "PartCollAct", AppraisalHOD.PartCollAct, DbType.Decimal);
                    objDB.AddParameters(9, "TotalPer", AppraisalHOD.TotalPer, DbType.Decimal);
                    objDB.AddParameters(10, "Status", AppraisalHOD.Status, DbType.String);
                    objDB.AddParameters(11, "Approve", AppraisalHOD.Approve, DbType.String);
                    objDB.AddParameters(12, "InstituteID", AppraisalHOD.InstituteID, DbType.Int32);
                    objDB.AddParameters(13, "SessionID", AppraisalHOD.SessionId, DbType.String);
                    objDB.AddParameters(14, "UserID", AppraisalHOD.UserID, DbType.String);
                    objDB.AddParameters(15, "UEDate", AppraisalHOD.UEDate, DbType.Date);
                    objDB.AddParameters(16, "flag", AppraisalHOD.flag, DbType.String);
                    objDB.AddParameters(17, "Retsuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(18, "Remark", AppraisalHOD.flag, DbType.String);
                    objDB.AddParameters(19, "ApprDt",AppraisalHOD.ApprDt , DbType.Date);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Payroll_AppraisalHod");
                    RetSuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();


                    if (RetSuccess == "4")
                    {
                        objDB.Transaction.Rollback();
                        retv = "Appraisal Request already Exists.";

                    }
                    else if (RetSuccess == "5")
                    {
                        objDB.Transaction.Rollback();
                        retv = "Appraisal Request can not update";
                    }

                    else if (RetSuccess == "6")
                    {
                        objDB.Transaction.Rollback();
                        retv = "Appraisal Request not Delete";


                    }
                    else if (RetSuccess == "1")
                    {

                        objDB.Transaction.Commit();
                        retv = "Appraisal Request Forward Successfully";

                    }
                    else if (RetSuccess == "2")
                    {

                        objDB.Transaction.Commit();
                        retv = "Appraisal Request Updated Successfully";
                    }
                    else if (RetSuccess == "3")
                    {

                        objDB.Transaction.Commit();
                        retv = "Appraisal Request Deleted Successfully";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();

                }
                return retv;

            }

            #region IDisposable Members

            public void Dispose()
            {
                objDB.Dispose();
            }

            #endregion
        }
    }
    namespace Attendance
    {
        public abstract class Attendance_DataLayer : IDisposable
        {
            NewDAL.DBManager objDB = null;
            private   NewDAL.DBManager OpenDALConnection()
            {
                objDB = new   NewDAL.DBManager();
                //objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
                objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
                objDB.Open();

                return objDB;
            }

            protected Int32 InsertEmp_Attend_Detatil(List<Emp_Attend_DetatilDM> objPSF)
            {
                objDB = OpenDALConnection();
                objDB.BeginTransaction();
                //string retv = "";
                int f = 0;
                try
                {
                    foreach (Emp_Attend_DetatilDM BDM in objPSF)
                    {
                        objDB.CreateParameters(11);
                        objDB.AddParameters(0, "Id", BDM.Id, DbType.Int32);
                        objDB.AddParameters(1, "EmpId", BDM.EmpId, DbType.String);
                        objDB.AddParameters(2, "Attend_Date", BDM.Attend_Date, DbType.DateTime);
                        objDB.AddParameters(3, "PresentStatus", BDM.PresentStatus, DbType.String);
                        objDB.AddParameters(4, "AttMonth", BDM.AttMonth, DbType.Int32);
                        objDB.AddParameters(5, "AttYear", BDM.AttYear, DbType.Int32);
                        objDB.AddParameters(6, "InstId", BDM.InstId, DbType.Int32);
                        objDB.AddParameters(7, "sessionID", BDM.sessionID, DbType.String);
                        objDB.AddParameters(8, "EmpDesig", BDM.EmpDesig, DbType.Int32);
                        objDB.AddParameters(9, "EmpDept", BDM.EmpDept, DbType.Int32);
                        objDB.AddParameters(10, "flag", BDM.flag, DbType.Int32);
                        objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "Insert_EmpAtt_Detail");
                        f = BDM.flag;
                    }

                    objDB.Transaction.Commit();
                    //if (f == 1)
                    //{
                    //    retv = "Record saved.";
                    //}
                    //else if (f == 2)
                    //{
                    //    retv = "Record Updated Successfully.";
                    //}
                    //else
                    //{
                    //    retv = "Record deleted Successfully.";
                    //}
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    //retv = "Unable to save record :-" + ex.Message.ToString();
                }
                return f;
            }
            

            #region IDisposable Members
            public void Dispose()
            {
                objDB.Dispose();
            }
            #endregion
        }
    }
    namespace Leave
    {
        public abstract class Leave_DataLayer : IDisposable
        {
            protected string ReturnConString()
            {
                return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
            }
            protected   NewDAL.DBManager objDB = null;
            protected   NewDAL.DBManager OpenDALConnection()
            {
                objDB = new   NewDAL.DBManager();
               objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
                objDB.Open();

                return objDB;
            }


            #region EmpLeaveAccount

            protected string Save_EmpLeaveAccount(HRM.LeaveData.EmpLeaveAccount Leave)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();

                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(33);
                    objDB.AddParameters(0, "ID", Leave.ID, DbType.Int32);
                    objDB.AddParameters(1, "EmpId", Leave.EmpID, DbType.Int32);
                    objDB.AddParameters(2, "EmpCode", Leave.EmpCode, DbType.String);
                    objDB.AddParameters(3, "JoinDate", Leave.Joindate, DbType.DateTime);
                    objDB.AddParameters(4, "OpenLeave", Leave.OpenLeave, DbType.Decimal);
                    objDB.AddParameters(5, "TakenLeave", Leave.TakenLeave, DbType.Decimal);
                    objDB.AddParameters(6, "BalLeave", Leave.BalLeave, DbType.Decimal);
                    objDB.AddParameters(7, "TotalLeave", Leave.TotalLeave, DbType.Decimal);
                    objDB.AddParameters(8, "EarnLeave", Leave.EarnLeave, DbType.Decimal);
                    objDB.AddParameters(9, "TakenLeave_EL", Leave.TakenLeave_EL, DbType.Decimal);
                    objDB.AddParameters(10, "BalLeave_EL", Leave.BalLeave_EL, DbType.Decimal);
                    objDB.AddParameters(11, "InstituteID", Leave.InstituteID, DbType.Int32);
                    objDB.AddParameters(12, "SessionID", Leave.SessionID, DbType.String);
                    objDB.AddParameters(13, "UserID", Leave.UserID, DbType.String);
                    objDB.AddParameters(14, "UEDate", Leave.UEDate, DbType.Date);
                    objDB.AddParameters(15, "Status", Leave.Status, DbType.String);
                    objDB.AddParameters(16, "TotalNo_of_EncLeave", Leave.TotalNo_of_EncLeave, DbType.Decimal);
                    objDB.AddParameters(17, "EncLeaveStatus", Leave.EncLeaveStatus, DbType.String);
                    objDB.AddParameters(18, "SessionFromDate", Leave.SessionFromDate, DbType.DateTime);
                    objDB.AddParameters(19, "SessionToDate", Leave.SessionToDate, DbType.DateTime);
                    objDB.AddParameters(20, "AccountFromDate", Leave.AccountFromDate, DbType.DateTime);
                    objDB.AddParameters(21, "AccountToDate", Leave.AccountToDate, DbType.DateTime);
                    objDB.AddParameters(22, "Earn_EncashLeave", Leave.Earn_EncashLeave, DbType.Decimal);
                    objDB.AddParameters(23, "ApplicationNo", Leave.ApplicationNo, DbType.String);
                    objDB.AddParameters(24, "AdjustbleLeaaves", Leave.AdjustbleLeaaves, DbType.Decimal);
                    objDB.AddParameters(25, "TotalLeaveTaken", Leave.TotalLeaveTaken, DbType.Decimal);
                    objDB.AddParameters(26, "Modify", Leave.Modify, DbType.String);
                    objDB.AddParameters(27, "MDays", Leave.MDays, DbType.Decimal);
                    objDB.AddParameters(28, "MedicalLeave", Leave.MedicalLeave, DbType.Decimal);
                    objDB.AddParameters(29, "TakenLeave_ML", Leave.TakenLeave_ML, DbType.Decimal);
                    objDB.AddParameters(30, "BalLeave_ML", Leave.BalLeave_ML, DbType.Decimal);
                    objDB.AddParameters(31, "flag", Leave.flag, DbType.String);
                    objDB.AddParameters(32, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Employee_Salary_Procced_Month]");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record Saved Successfully .";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Record Update Successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Record Deleted Successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Record not saved";
                }
                return retv;
            }
            #endregion

            #region DesigLeaveAssign

            protected string Save_DesigLeaveAssign(HRM.LeaveData.DesigLeaveAssg Leave)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();

                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(13);
                    objDB.AddParameters(0, "ID", Leave.ID, DbType.Int32);
                    objDB.AddParameters(1, "DesigID", Leave.DesigID, DbType.String);
                    objDB.AddParameters(2, "TotalL", Leave.TotalL, DbType.Decimal);
                    objDB.AddParameters(3, "Wef_Date", Leave.WEf_date, DbType.DateTime);
                    objDB.AddParameters(4, "Status", Leave.Status, DbType.String);
                    objDB.AddParameters(5, "InstituteID", Leave.InstituteID, DbType.Int32);
                    objDB.AddParameters(6, "SessionID", Leave.SessionID, DbType.String);
                    objDB.AddParameters(7, "UserID", Leave.UserID, DbType.String);
                    objDB.AddParameters(8, "UEDate", Leave.UEDate, DbType.Date);
                    objDB.AddParameters(9, "flag", Leave.flag, DbType.String);
                    objDB.AddParameters(10, "RetSuccess", 0, DbType.Int32, ParameterDirection.Output);
                    objDB.AddParameters(11, "EncLeave", Leave.EncLeave, DbType.Decimal);
                    objDB.AddParameters(12, "LPM", Leave.LPM, DbType.Decimal);
                    objDB.AddParameters(13, "NatureId", Leave.NatureId, DbType.Decimal);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Desig_Leave_Assign]");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Record saved.";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Update successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Delete successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Record already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Record in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Record is not saved";
                }
                return retv;
            }


            protected void Get_DesigLeaveAssgd(string  flag, Int32 InstituteID, String SessionID, ref   NewDAL.DBManager objDB)
            {

                objDB = OpenDALConnection();

                objDB.CreateParameters(3);
                objDB.AddParameters(0, "flag", flag, DbType.String);
                objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                objDB.AddParameters(2, "SessionID", SessionID, DbType.String);

                objDB.ExecuteReader(CommandType.StoredProcedure, "[SP_Desig_Leave_Assign]");
            }
            #endregion

            #region EmpLeaveRecord

            protected string Save_LeaveReqest(HRM.LeaveData.EmpLeaveRecord LeaveReq)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();

                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(39);
                    objDB.AddParameters(0, "ID", LeaveReq.ID, DbType.Int32);
                    objDB.AddParameters(1, "EmpId", LeaveReq.EmpID, DbType.Int32);
                    objDB.AddParameters(2, "EmpCode", LeaveReq.EmpCode, DbType.String);
                    objDB.AddParameters(3, "LStart_dt", LeaveReq.LStart_dt, DbType.DateTime);
                    objDB.AddParameters(4, "NoofL", LeaveReq.NoofL, DbType.Decimal);
                    objDB.AddParameters(5, "LEnd_Dt", LeaveReq.LEnd_Dt, DbType.DateTime);
                    objDB.AddParameters(6, "Application_No", LeaveReq.Application_No , DbType.String);
                    objDB.AddParameters(7, "Applied_Date", LeaveReq.Applied_Date, DbType.DateTime);
                    objDB.AddParameters(8, "LApprStatus", LeaveReq.LApprStatus, DbType.String);
                    objDB.AddParameters(9, "InstituteID", LeaveReq.InstituteID, DbType.Int32);
                    objDB.AddParameters(10, "SessionID", LeaveReq.SessionID, DbType.String);
                    objDB.AddParameters(11, "UserID", LeaveReq.UserID, DbType.String);
                    objDB.AddParameters(12, "UEDate", LeaveReq.UEDate, DbType.Date);
                    objDB.AddParameters(13, "Status", LeaveReq.Status, DbType.String);
                    objDB.AddParameters(14, "LeaveId", LeaveReq.LeaveId, DbType.String);
                    objDB.AddParameters(15, "ReasonofL", LeaveReq.ReasonofL, DbType.String);
                    objDB.AddParameters(16, "LAuthorityId", LeaveReq.LAuthorityId, DbType.String);
                    objDB.AddParameters(17, "SubstituteId", LeaveReq.SubstituteId, DbType.String);
                    objDB.AddParameters(18, "flag", LeaveReq.flag, DbType.String);
                    objDB.AddParameters(19, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(20, "Doc_Submit",LeaveReq.Doc_Submit , DbType.String);
                    objDB.AddParameters(21, "Leave_Type", LeaveReq.Leave_Type, DbType.String);
                    objDB.AddParameters(22, "Document", LeaveReq.DocumentN, DbType.Byte);
                    objDB.AddParameters(23, "CityId", LeaveReq.CityId, DbType.Int32);
                    objDB.AddParameters(24, "StateId", LeaveReq.StateId, DbType.Int32);
                    objDB.AddParameters(25, "CountryId", LeaveReq.CountryId, DbType.Int32);
                    objDB.AddParameters(26, "DutyAddr", LeaveReq.DutyAddr, DbType.String);
                    objDB.AddParameters(27, "IsCancelled", LeaveReq.IsCancelled, DbType.String);
                    objDB.AddParameters(28, "DeptId", LeaveReq.DeptId, DbType.Int32);                   
                    objDB.AddParameters(29, "ApprFrom", LeaveReq.ApprFrom , DbType.DateTime);
                    objDB.AddParameters(30, "ApprTo", LeaveReq.ApprTo, DbType.DateTime);
                    objDB.AddParameters(31, "ApprDays", LeaveReq.ApprDays, DbType.Decimal);
                    objDB.AddParameters(32, "ApprRejDate", LeaveReq.ApprRejDate, DbType.DateTime);
                    objDB.AddParameters(33, "CancelDate", LeaveReq.CancelDate, DbType.DateTime);
                    objDB.AddParameters(34, "ApprByHod", LeaveReq.ApprByHod , DbType.String);
                    objDB.AddParameters(35, "ApprByP", LeaveReq.ApprByP , DbType.String);
                    objDB.AddParameters(36, "LWP", "-", DbType.String);
                    objDB.AddParameters(37, "HFType",LeaveReq.HFType, DbType.String);
                    objDB.AddParameters(38, "LeaveHead", LeaveReq.LeaveHead, DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Emp_Leave_Record_dtls]");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    //if (Retsuccess == "1")
                    //{
                    //   // retv = "Leave Request Saved Successfully .";
                    //}
                    //if (Retsuccess == "2")
                    //{
                    //   // retv = "Leave Request Update Successfuly.";
                    //}
                    //else if (Retsuccess == "3")
                    //{
                    //   // retv = "Leave Request Deleted Successfully";
                    //}
                    //else if (Retsuccess == "4")
                    //{
                    //   // retv = "Leave Request already exists.";
                    //}
                    //else if (Retsuccess == "5")
                    //{
                    //  //  retv = "Leave Request in  used.";
                    //}
                    retv = Retsuccess;
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Leave Request not saved";
                }
                return retv;
            }

            #endregion

            #region EmpLeaveApprov

            protected string Save_LeaveApprov(HRM.LeaveData.EmpLeaveApprov LeaveReq)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();

                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(20);
                    objDB.AddParameters(0, "Id", LeaveReq.Id, DbType.Int32);
                    objDB.AddParameters(1, "Application_No", LeaveReq.Application_No, DbType.String);
                    objDB.AddParameters(2, "Authority_Id ", LeaveReq.Authority_Id, DbType.String);
                    objDB.AddParameters(3, "Authority_Empcode", LeaveReq.Authority_Empcode, DbType.String);
                    objDB.AddParameters(4, "empcode", LeaveReq.empcode, DbType.String);
                    objDB.AddParameters(5, "empid", LeaveReq.empId, DbType.Int32);
                    objDB.AddParameters(6, "LApprStatus", LeaveReq.LApprStatusByHod, DbType.String);
                    objDB.AddParameters(7, "ApprFrom", LeaveReq.LApprFDatebyHod, DbType.DateTime);
                    objDB.AddParameters(8, "ApprTo", LeaveReq.LApprTdatebyHod, DbType.DateTime);
                    objDB.AddParameters(9, "InstituteID", LeaveReq.InstituteID, DbType.Int32);
                    objDB.AddParameters(10, "SessionID", LeaveReq.SessionID, DbType.String);
                    objDB.AddParameters(11, "UserID", LeaveReq.UserID, DbType.String);
                    objDB.AddParameters(12, "UEDate", LeaveReq.UEDate, DbType.Date);
                    objDB.AddParameters(13, "ApprDays", LeaveReq.LNoofDaysApprHod, DbType.Decimal);
                    objDB.AddParameters(14, "flag", LeaveReq.flag, DbType.String);
                    objDB.AddParameters(15, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(16, "Status", LeaveReq.Status, DbType.String);
                    objDB.AddParameters(17, "DeptId", LeaveReq.DeptId, DbType.Int32);
                    objDB.AddParameters(18, "Reason", LeaveReq.ReasonByHod, DbType.String);
                   
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Emp_Leave_Sanction_dtlsHod]");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Leave Approval Saved Successfully .";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Leave Approval Update Successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Leave Request Deleted Successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Leave Approval already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Leave Approval in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Leave Approval not saved";
                }
                return retv;
            }

            protected string Save_LeaveApprovP(HRM.LeaveData.EmpLeaveApprov LeaveReq)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();

                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(20);
                    objDB.AddParameters(0, "Id", LeaveReq.Id, DbType.Int32);
                    objDB.AddParameters(1, "Application_No", LeaveReq.Application_No, DbType.String);
                    objDB.AddParameters(2, "P_Id ", LeaveReq.Principal_empid, DbType.String);
                    objDB.AddParameters(3, "P_Empcode", LeaveReq.Principal_empcode, DbType.String);
                    objDB.AddParameters(4, "empcode", LeaveReq.empcode, DbType.String);
                    objDB.AddParameters(5, "empid", LeaveReq.empId, DbType.Int32);
                    objDB.AddParameters(6, "LApprStatus", LeaveReq.LApprStatusByP, DbType.String);
                    objDB.AddParameters(7, "ApprFrom", LeaveReq.LApprFDatebyP, DbType.DateTime);
                    objDB.AddParameters(8, "ApprTo", LeaveReq.LApprTdatebyP, DbType.DateTime);
                    objDB.AddParameters(9, "InstituteID", LeaveReq.InstituteID, DbType.Int32);
                    objDB.AddParameters(10, "SessionID", LeaveReq.SessionID, DbType.String);
                    objDB.AddParameters(11, "UserID", LeaveReq.UserID, DbType.String);
                    objDB.AddParameters(12, "UEDate", LeaveReq.UEDate, DbType.Date);
                    objDB.AddParameters(13, "ApprDays", LeaveReq.LNoofDaysApprP, DbType.Decimal);
                    objDB.AddParameters(14, "flag", LeaveReq.flag, DbType.String);
                    objDB.AddParameters(15, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(16, "Status", LeaveReq.Status, DbType.String);
                    objDB.AddParameters(17, "DeptId", LeaveReq.DeptId, DbType.Int32);
                    objDB.AddParameters(18, "Reason", LeaveReq.ReasonByP, DbType.String);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Emp_Leave_Sanction_dtlsP]");
                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Leave Approval Saved Successfully .";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Leave Approval Update Successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Leave Request Deleted Successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Leave Approval already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Leave Approval in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Leave Approval not saved";
                }
                return retv;
            }


            protected string Save_LeaveRecordDtls(HRM.LeaveData.EmpLeaveRecordchld LeaveReq)
            {
                string retv = string.Empty;
                try
                {
                    objDB = OpenDALConnection();

                    objDB.BeginTransaction();
                    string Retsuccess = string.Empty;
                    objDB.CreateParameters(21);
                    objDB.AddParameters(0, "Id", LeaveReq.ID, DbType.Int32);
                    objDB.AddParameters(1, "empid", LeaveReq.EmpID, DbType.Int32);
                    objDB.AddParameters(2, "empcode", LeaveReq.EmpCode, DbType.String);
                    objDB.AddParameters(3, "LeaveDate", LeaveReq.LeaveDate, DbType.DateTime);
                    objDB.AddParameters(4, "Application_No", LeaveReq.Application_No, DbType.String);
                    objDB.AddParameters(5, "Application_Nochld", LeaveReq.Application_Nochld, DbType.String);
                    objDB.AddParameters(6, "LeaveId ", LeaveReq.LeaveId, DbType.String);
                    objDB.AddParameters(7, "Leave_Type", LeaveReq.LeaveType, DbType.String);
                    objDB.AddParameters(8, "AuthorityId", LeaveReq.AuthorityId, DbType.String);
                    objDB.AddParameters(9, "Status", LeaveReq.Status, DbType.String);
                    objDB.AddParameters(10, "InstituteID", LeaveReq.InstituteID, DbType.Int32);
                    objDB.AddParameters(11, "SessionID", LeaveReq.SessionID, DbType.String);
                    objDB.AddParameters(12, "UserID", LeaveReq.UserID, DbType.String);
                    objDB.AddParameters(13, "UEDate", LeaveReq.UEDate, DbType.Date);
                    objDB.AddParameters(14, "DeptId", LeaveReq.DeptId, DbType.Int32);
                    objDB.AddParameters(15, "flag", LeaveReq.flag, DbType.String);
                    objDB.AddParameters(16, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
                    objDB.AddParameters(17, "LWP", LeaveReq.LWP, DbType.String);
                    objDB.AddParameters(18, "Modify", '-', DbType.String);
                    objDB.AddParameters(19, "HFType",LeaveReq.HFType, DbType.String);
                    objDB.AddParameters(20, "LeaveHead", LeaveReq.LeaveHead, DbType.String);
                   
                    if (LeaveReq.LeaveName =="Casual Leave")
                    {
                        objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Emp_Leave_Record_dtlschld]");
                    }
                    else
                    {
                        objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "[SP_Emp_Leave_Record_dtlschldspLeave]");
                    }

                    Retsuccess = ((System.Data.SqlClient.SqlCommand)objDB.Command).Parameters["@RetSuccess"].Value.ToString();
                    objDB.Transaction.Commit();
                    if (Retsuccess == "1")
                    {
                        retv = "Leave Approval Saved Successfully .";
                    }
                    if (Retsuccess == "2")
                    {
                        retv = "Leave Approval Update Successfuly.";
                    }
                    else if (Retsuccess == "3")
                    {
                        retv = "Leave Request Deleted Successfully";
                    }
                    else if (Retsuccess == "4")
                    {
                        retv = "Leave Approval already exists.";
                    }
                    else if (Retsuccess == "5")
                    {
                        retv = "Leave Approval in  used.";
                    }
                }
                catch (Exception ex)
                {
                    objDB.Transaction.Rollback();
                    retv = "Leave Approval not saved";
                }
                return retv;
            }
            #endregion



           

       


            protected void Get_LeaveRequest(Int32 LeaveId,string LeaveName, Int32 empID, Int32 InstituteID, String SessionID, ref   NewDAL.DBManager objDB)
            {

                objDB = OpenDALConnection();

                objDB.CreateParameters(6);
                objDB.AddParameters(0, "empID", empID, DbType.Int32);
                objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                objDB.AddParameters(2, "SessionID", SessionID, DbType.String);

                objDB.AddParameters(3, "LeaveId", LeaveId, DbType.Int32);
                objDB.AddParameters(4, "LeaveName", LeaveName, DbType.String);
                objDB.AddParameters(5, "flag", "S", DbType.String);

                objDB.ExecuteReader(CommandType.StoredProcedure, "[SP_Employee_Leave_Account_Detail]");
            }

            protected void Save_LeaveReqest(HRM.LeaveData.LeaveRequestDM LeaveReq,   NewDAL.DBManager objDB, ref Int32 RegisID)
            {
                //Boolean flag = false;
                try
                {
                    //objDB.BeginTransaction();
                    objDB.CreateParameters(15);
                    objDB.AddParameters(0, "regID", LeaveReq.regID, DbType.Int32);
                    objDB.AddParameters(1, "applID", LeaveReq.applID, DbType.String);
                    objDB.AddParameters(2, "empID", LeaveReq.empID, DbType.Int32);
                    objDB.AddParameters(3, "reason", LeaveReq.reason, DbType.String);
                    objDB.AddParameters(4, "authorID", LeaveReq.authorID, DbType.Int32);
                    objDB.AddParameters(5, "substitute", LeaveReq.substitute, DbType.String);
                    objDB.AddParameters(6, "leavestatus", LeaveReq.leavestatus, DbType.String);
                    objDB.AddParameters(7, "InstituteID", LeaveReq.InstituteID, DbType.Int32);
                    objDB.AddParameters(8, "SessionID", LeaveReq.SessionID, DbType.String);
                    objDB.AddParameters(9, "UserID", LeaveReq.UserID, DbType.String);
                    objDB.AddParameters(10, "UEDate", LeaveReq.UEDate, DbType.Date);
                    objDB.AddParameters(11, "deptID", LeaveReq.deptID, DbType.Int32);
                    objDB.AddParameters(12, "repAuthStatus", LeaveReq.repAuthStatus, DbType.String);
                    objDB.AddParameters(13, "flag", LeaveReq.flag, DbType.String);
                    objDB.AddParameters(14, "registID", 0, DbType.Int32, ParameterDirection.Output);

                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_leave_Requisition");
                    ((SqlCommand)objDB.Command).Parameters["@registID"].Size = 25;
                    RegisID = Int32.Parse(((SqlCommand)objDB.Command).Parameters["@registID"].Value.ToString());

                    //flag = true;
                }
                catch (Exception)
                {
                    objDB.Transaction.Rollback();
                    //flag = false;
                }
                finally
                {
                    objDB.Command.Parameters.Clear();
                }
                //return flag;
            }
            protected void Save_LeaveRequestSub(HRM.LeaveData.LeaveRequestSubDM objReqSub,   NewDAL.DBManager objDB)
            {
                //Boolean flag = false;

                try
                {
                    objDB.CreateParameters(9);
                    objDB.AddParameters(0, "id", objReqSub.ID, DbType.Int32);
                    objDB.AddParameters(1, "regID", objReqSub.regID, DbType.Int32);
                    objDB.AddParameters(2, "leaveID", objReqSub.leaveID, DbType.Int32);
                    objDB.AddParameters(3, "leaveFrom", objReqSub.leaveFrom, DbType.DateTime);
                    objDB.AddParameters(4, "leaveTo", objReqSub.leaveTo, DbType.DateTime);
                    objDB.AddParameters(5, "noODays", objReqSub.noODays, DbType.Decimal);
                    objDB.AddParameters(6, "leaveName", objReqSub.leaveName, DbType.String);
                    objDB.AddParameters(7, "flag", objReqSub.flag, DbType.String);
                    objDB.AddParameters(8, "Details", objReqSub.Details, DbType.String);
                    objDB.ExecuteNonQueryHR(CommandType.StoredProcedure, "SP_Master_leave_Req_Sub");
                    //flag = true;
                }
                catch (Exception)
                {
                    objDB.Transaction.Rollback();
                    //flag = false;
                }
                finally
                {
                }
                //return flag;
            }
            protected List<HRM.Fee.DesigntionDM> fillLeaveApprv(string flag, Int32 InstituteID)
            {
                List<HRM.Fee.DesigntionDM> listDesig = new List<Fee.DesigntionDM>();
                try
                {
                    objDB = OpenDALConnection();
                    objDB.CreateParameters(2);
                    objDB.AddParameters(0, "flag", flag, DbType.String);
                    objDB.AddParameters(1, "InstituteID", InstituteID, DbType.Int32);
                    objDB.ExecuteReader(CommandType.StoredProcedure, "SP_Master_Desig");
                    HRM.Fee.DesigntionDM item;
                    while (objDB.DataReader.Read())
                    {
                        item = new HRM.Fee.DesigntionDM();
                        item.Designation = objDB.DataReader["Designation"].ToString();
                        item.ShortName = objDB.DataReader["ShortName"].ToString();
                        item.validFrom = Convert.ToDateTime(objDB.DataReader["validFrom"].ToString());
                        item.validTo = Convert.ToDateTime(objDB.DataReader["validTo"].ToString());
                        item.DesigId = Int32.Parse(objDB.DataReader["DesigId"].ToString());
                        listDesig.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    objDB.Command.Parameters.Clear();
                }
                finally
                {
                }
                return listDesig;
            }

           
            #region IDisposable Members

            public void Dispose()
            {
                objDB.Dispose();
            }

            #endregion


          
        }
    }
}