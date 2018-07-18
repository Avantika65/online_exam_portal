using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Masters
/// </summary>
namespace HRM
{
    namespace Masters
    {
        public class BLayer : Masters_DataLayer
        {
            public BLayer()
            {

            }
            #region Department
            public new string Save_Department(HRM.Fee.DepartmentDM objDept)
            {
                return base.Save_Department(objDept);
            }
            public new List<HRM.Fee.DepartmentDM> fillDepartment(string flag, int InstituteID)
            {
                return base.fillDepartment(flag, InstituteID);
            }
            #endregion
            #region Designation
            public new string Save_Designation(HRM.Fee.DesigntionDM objdesg)
            {
                return base.Save_Designation(objdesg);
            }
            public new List<HRM.Fee.DesigntionDM> fillDesignation(string flag, Int32 InstituteID)
            {
                return base.fillDesignation(flag, InstituteID);
            }
	        #endregion
            #region Employee
            public new Boolean Save_Employee_Detail(String Flag, Int32 InstID, String SessionID, String UserID, Int32 EmpId, Int32 candID, String empCode, String empName, String empType, String empCat, Int32 barID, String Gender, DateTime DOB, String CompanyName, Int32 DeptID, Int32 DesigID, String MarkOIdent, String MaritalStatus, String ModeAppl, String ReferedBy, String Religion, String Nationality, String NatureID, String WorkingExp, String SpouseName, String FatherName, String PermAdd, Int32 City, Int32 State, Int32 Country, String ZipCode, String PhoneNo, String EMail, String Mobile, String LocalAddress, Int32 LocalCity, Int32 LocalState, Int32 LocalCountry, String LocalZipCode, String LocalPhoneNo, String LocalEMail, String LocalMobile, DateTime JoiningDate, String BloodGroup, String BonusApplied, String OTApplied, String ODayApplied, String OffDay, Int32 ProfEdu, byte[] EmployeeImge, byte[] EmployeeSign, String LastName, Int32 RAuthority, String EmployeeTitle, Int32 ExpertID,   NewDAL.DBManager objDB, ref Int32 EmployeeID)
            {
                return base.Save_Employee_Detail(Flag, InstID, SessionID, UserID, EmpId, candID, empCode, empName, empType, empCat, barID, Gender, DOB, CompanyName, DeptID, DesigID, MarkOIdent, MaritalStatus, ModeAppl, ReferedBy, Religion, Nationality, NatureID, WorkingExp, SpouseName, FatherName, PermAdd, City, State, Country, ZipCode, PhoneNo, EMail, Mobile, LocalAddress, LocalCity, LocalState, LocalCountry, LocalZipCode, LocalPhoneNo, LocalEMail, LocalMobile, JoiningDate, BloodGroup, BonusApplied, OTApplied, ODayApplied, OffDay, ProfEdu, EmployeeImge, EmployeeSign, LastName, RAuthority, EmployeeTitle, ExpertID, objDB, ref  EmployeeID);
            }
            public new Boolean Save_Employee_Detail(HRM.Fee.EmployeeDetail EmpDetail,   NewDAL.DBManager objDB, ref Int32 EmployeeID)
            {
                return base.Save_Employee_Detail(EmpDetail, objDB, ref  EmployeeID);
            }
            public new void Save_Employee_Basic_Salary(Int32 RowId, Int32 Employee_id, DateTime WithEffectDate, Int32 DeptID, Int32 DesigID, String PayPeriod, Decimal BasicSalary, Int32 OverTimeHour, Int32 OverTimeMinute, Int32 HalfDayHour, Int32 HalfDayMinute, Int32 SalaryGrade, Int32 LateHour, Int32 LateMin,   NewDAL.DBManager objDB)
            {
                base.Save_Employee_Basic_Salary(RowId, Employee_id, WithEffectDate, DeptID, DesigID, PayPeriod, BasicSalary, OverTimeHour, OverTimeMinute, HalfDayHour, HalfDayMinute, SalaryGrade, LateHour, LateMin, objDB);
            }
            public new void Save_Employee_Basic_Salary(HRM.Fee.BasicSalDetail BasicDetail,   NewDAL.DBManager objDB)
            {
                base.Save_Employee_Basic_Salary(BasicDetail, objDB);
            }
            public new void Save_Employee_wages(Int32 FBasic, String wageID, String wValue, String Status,   NewDAL.DBManager objDB, ref String RetSuccess)
            {
                base.Save_Employee_wages(FBasic, wageID, wValue, Status, objDB, ref RetSuccess);
            }
            public new void Save_Employee_wages(HRM.Fee.WageDetails wageDetails,   NewDAL.DBManager objDB, ref String RetSuccess)
            {
                base.Save_Employee_wages(wageDetails, objDB, ref RetSuccess);
            }
            public new void Save_Employee_Services(Int32 EmployeeId, Int32 ServiceID, String Status, DateTime WED,   NewDAL.DBManager objDB, ref String Retsuccess)
            {
                base.Save_Employee_Services(EmployeeId, ServiceID, Status, WED, objDB, ref Retsuccess);
            }
            public new HRM.Fee.EmployeeDetail Get_Employee_Detail(Int32 EmployeeId)
            {
                return base.Get_Employee_Detail(EmployeeId);
            }
            public new List<HRM.Fee.EmployeeService> Get_Employee_Services(Int32 EmployeeId)
            {
                return base.Get_Employee_Services(EmployeeId);
            } 
            #endregion
            public new string Save_WorkDays(List<HRM.Fee.WorkDayDM> objWorkDay)
            {
                return base.Save_WorkDays(objWorkDay);
            }
            public new List<HRM.PayRollDM.WorkDay> FillWorkDay(Int32 InstituteID)
            {
                return base.FillWorkDay(InstituteID);
            }
            public new void Save_Employee_Timing_Details(HRM.Fee.EmployeeDetail EmployeeDetail, NewDAL.DBManager objDB)
            {
                base.Save_Employee_Timing_Details(EmployeeDetail, objDB);
            }

            #region Country
            public new string Save_Country(HRM.Fee.CountryDM country)
            {
                return base.Save_Country(country);
            }
            public new List<HRM.Fee.CountryDM> FillGrid(string flag)
            {
                return base.FillGrid(flag);
            } 
            #endregion

            #region State
            public new string Save_State(HRM.Fee.StateDM State)
            {
                return base.Save_State(State);
            }
            public new List<HRM.Fee.StateDM> fillState(string flag)
            {
                return base.fillState(flag);
            } 
            #endregion
           
            #region City
		    public new string Save_City(HRM.Fee.CityDM InsrtCity)
           {
               return base.Save_City(InsrtCity);
           }
            public new List<HRM.Fee.CityDM> filCity(string flag)
           {
               return base.FillCity(flag);
           }
 
	       #endregion  

            #region Profile
           public new string Save_EducProfile(HRM.Fee.EprofDM insrtEprof)
           {
               return base.Save_EducProfile(insrtEprof);
           }
           public new List<HRM.Fee.EprofDM> fillEduProfile(string flag, Int32 InstituteID)
           {
               return base.fillEduProfile(flag, InstituteID);
           } 
           #endregion

            #region Offday
           public new string Save_Offday(HRM.Fee.offdayDM insrtOffday)
           {
               return base.Save_Offday(insrtOffday);
           }
           public new List<HRM.Fee.offdayDM> fillOffday(string flag, Int32 InstituteID)
           {
               return base.fillOffday(flag, InstituteID);
           } 
           #endregion

            #region Expertise 
           public new string Save_Expertise(HRM.Fee.ExpertisDM insrtExprt)
           {
               return base.Save_Expertise(insrtExprt);
           }
           public new List<HRM.Fee.ExpertisDM> fillExpert(string flag, Int32 InstituteID)
           {
               return base.fillExpert(flag, InstituteID);
           } 
           #endregion

            #region Services
           public new string Save_Services(HRM.Fee.ServiceDM InsrtServ)
           {
               return base.Save_Services(InsrtServ);
           }
           public new string Save_Services_Details(HRM.Fee.ServiceDM InsrtServ)
           {
               return base.Save_Services_Details(InsrtServ);
           }
           public new List<HRM.Fee.ServiceDM> fillServices(string flag, Int32 InstituteID)
           {
               return base.fillServices(flag, InstituteID);
           } 
           #endregion

            #region Employee Nature
           public new string Save_EmpNAture(HRM.Fee.EmpNatureDM InsrtEmpNature)
           {
               return base.Save_EmpNAture(InsrtEmpNature);
           }
           public new List<HRM.Fee.EmpNatureDM> FillEmpNature(string flag, Int32 InstituteID)
           {
               return base.FillEmpNature(flag, InstituteID);
           } 
           #endregion
        }   
       
      
    }
    namespace Recruit
    {
        public class BLayer : Recruit_DataLayer
        {
            public BLayer()
            {
            }
            public new string Save_Vacancy(HRM.Recruitment.AddJobVac objAddVac)
            {
                return base.Save_Vacancy(objAddVac);
            }
            public new string Save_IntrvRound(HRM.Recruitment.IntrRoundDM insrtIntrvRnd)
            {
                return base.Save_IntrvRound(insrtIntrvRnd);
            }
            public new string Save_PanelMemb(HRM.Recruitment.PannelMemb objPanelMem)
            {
                return base.Save_PanelMemb(objPanelMem);
            }

            public new List<HRM.Recruitment.PannelMemb> fillPanelMem(string flag, Int32 InstituteID)
            {
                return base.fillPanelMem(flag, InstituteID);
            }

            public new List<HRM.Recruitment.IntrRoundDM> Fill_IntrvRnd(string flag, string SessionID, Int32 InstituteID)
            {
                return base.Fill_IntrvRnd(flag, SessionID, InstituteID);
            }
           
            public new string Save_JobProfile(HRM.Recruitment.JobProfileDM InsrtJobProf)
            {
                return base.Save_JobProfile(InsrtJobProf);
            }
            public new List<HRM.Recruitment.JobProfileDM> fillJobProfile(string flag, Int32 InstituteID)
            {
                return base.fillJobProfile(flag, InstituteID);
            }
            #region Feed Back
            public new string Save_Feedback(HRM.Recruitment.FeedbackDM InsrtFdbk)
            {
                return base.Save_Feedback(InsrtFdbk);
            }
            public new List<HRM.Recruitment.FeedbackDM> Fill_FeedBK(string flag)
            {
                return base.Fill_FeedBK(flag);
            }
            public new List<HRM.Recruitment.FeedbackDM> fill_Member(string flag, Int32 id)
            {
                return base.fill_Member(flag, id);
            }
            public new HRM.Recruitment.FeedbackDM get_Detail(string flag, Int32 candId)
            {
                return base.get_Detail(flag, candId);
            }
            #endregion
            #region Candidate Enrollement
            public new List<HRM.Recruitment.selctedcandDM> fillslcsnd(Int32 catid, Int32 deptid, Int32 desigid, Int32 instituteid)
            {
                return base.fillslcsnd(catid, deptid, desigid, instituteid);
            }
            public new string insertselectedcandidate(List<HRM.Recruitment.selctedcandDM> objslctcand)
            {
                return base.insertselectedcandidate(objslctcand);
            }
            public new HRM.Recruitment.selctedcandDM Get_MSalaryGrade(string flag, Int32 candId)
            {
                return base.Get_MSalaryGrade(flag, candId);
            }
            #endregion
            public new string Save_CandidateResume(HRM.Recruitment.CandRecruitDM objCandRes)
            {
                return base.Save_CandidateResume(objCandRes);

            }
            public new List<HRM.Recruitment.AddJobVac> FillCandVacancy(string flag, Int32 InstituteID, string SessionID)
            {
                return base.FillCandVacancy( flag, InstituteID ,SessionID);
            }
        }
    }
    namespace Payroll
    {
        public class BLayer:Paroll_DataLayer
        {
            public BLayer()
            {
            }
            public new string saveSession(HRM.PayRollDM.Sesssion objSeson)
            {
                return base.saveSession(objSeson);
            }
            public new string insertMAXDA(HRM.PayRollDM.MAXDA MaxSeson)
            {
                return base.insertMAXDA(MaxSeson);
            }
            public new string insertAppraisalReq(HRM.PayRollDM.AppraisalReq AppraisalReq)
            {
                return base.insertAppraisalReq(AppraisalReq);
            }
            public new string insertAppraisalHOD(HRM.PayRollDM.AppraisalHOD AppraisalHOD)
            {
                return base.insertAppraisalHOD(AppraisalHOD);
            }
        }
    }
    namespace Attendance
    {
        public class EmpAttendance : Attendance_DataLayer
        {
            private String Message = null;
            public new String  InsertEmp_Attend_Detatil(List<Emp_Attend_DetatilDM> objPSF)
            {
                
                Int32 Flag = base.InsertEmp_Attend_Detatil(objPSF);
                if(Flag==0)
                {
                    Message = "Unable to save record ";
                }
                else if (Flag == 1)
                {
                    Message = "Record saved.";
                }
                else if (Flag == 2)
                {
                    Message = "Record Updated Successfully.";
                }
                else
                {
                    Message = "Record deleted Successfully.";
                }
                return Message;
            }
        }
    
    }
    namespace Leave
    {
        public class LeaveMGT : HRM.Leave.Leave_DataLayer
        {
            private string msg = string.Empty;
            public LeaveMGT()
                : base()
            { }

            public new string   Save_DesigLeaveAssign(HRM.LeaveData.DesigLeaveAssg objLeave)
            {
              
             return  base.Save_DesigLeaveAssign(objLeave);
           
            
            }

            public new string Save_EmpLeaveAccount(HRM.LeaveData.EmpLeaveAccount objLeave)
            {

                return base.Save_EmpLeaveAccount(objLeave);


            }


            public void Get_DesigLeaveAssgd(string flag, Int32 InstituteID, String SessionID, ref List<HRM.LeaveData.DesigLeaveAssg> APL)
            {
                base.Get_DesigLeaveAssgd(flag, InstituteID, SessionID, ref objDB);

                while (objDB.DataReader.Read())
                {
                    var APLS = new HRM.LeaveData.DesigLeaveAssg();
                    APLS.ID=Int32.Parse(objDB.DataReader["ID"].ToString());
                    APLS.DesigID= Convert.ToInt32(objDB.DataReader["DesigID"].ToString());
                    APLS.Status=objDB.DataReader["Status"].ToString();
                    APLS.TotalL = Convert.ToDecimal(objDB.DataReader["TotalL"].ToString());
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(objDB.DataReader["WEF_Date"].ToString());
                    APLS.WEf_date =Convert.ToDateTime(dt.ToString("dd-MMM-yyyy"));
                    APLS.Designation = objDB.DataReader["Designation"].ToString();
                    APLS.Nature = objDB.DataReader["Nature"].ToString();
                    APLS.NatureId =Int32.Parse(objDB.DataReader["NatureId"].ToString());
                    APLS.EncLeave = Convert.ToDecimal(objDB.DataReader["EncLeave"].ToString());
                    APLS.LPM = Convert.ToDecimal(objDB.DataReader["LPM"].ToString());
                    APL.Add(APLS);
                }
               
            }

            public void Get_LeaveRequest(Int32 LeaveId, string LeaveName, Int32 empID, Int32 InstituteID, String SessionID, ref List<HRM.LeaveData.EmpLeaveAccount> APL, ref List<HRM.LeaveData.CancelLeave> CAL)
            {
                base.Get_LeaveRequest(LeaveId, LeaveName, empID, InstituteID, SessionID, ref objDB);
                var APLS = new HRM.LeaveData.EmpLeaveAccount();
                if (empID != 0)
                {
                    while (objDB.DataReader.Read())
                    {

                        APLS.EmpID = Int32.Parse(objDB.DataReader["empId"].ToString());
                        APLS.EmpCode = objDB.DataReader["empcode"].ToString();
                        APLS.TotalLeave = Convert.ToDecimal(objDB.DataReader["TotalLeave"].ToString());
                        APLS.EarnLeave = Convert.ToDecimal(objDB.DataReader["BalLeave_EL"].ToString());
                        APLS.OpenLeave = Convert.ToDecimal(objDB.DataReader["BalLeave"].ToString());
                        APLS.TakenLeave = Convert.ToDecimal(objDB.DataReader["TotalLeaveTaken"].ToString());
                        APLS.BalLeave = Convert.ToDecimal(objDB.DataReader["BalLeave"].ToString());
                        APLS.MedicalLeave = Convert.ToDecimal(objDB.DataReader["BalLeave_ML"].ToString());
                        APLS.Leave = LeaveName;
                        APLS.LeaveId = LeaveId;
                        APL.Add(APLS);
                    }


                }
                else
                {
                    APLS.Leave = LeaveName;
                    APLS.LeaveId = LeaveId;
                    APL.Add(APLS);
                }

            }           
            public new string Save_LeaveReqest(HRM.LeaveData.EmpLeaveRecord objLeaveReq)
            {

                return base.Save_LeaveReqest(objLeaveReq);


            }
            public new string Save_LeaveApprov(HRM.LeaveData.EmpLeaveApprov objLeaveReq)
            {

                return base.Save_LeaveApprov(objLeaveReq);


            }
            public new string Save_LeaveApprovP(HRM.LeaveData.EmpLeaveApprov objLeaveReq)
            {

                return base.Save_LeaveApprovP(objLeaveReq);


            }
            public new string Save_LeaveRecordDtls(HRM.LeaveData.EmpLeaveRecordchld objLeaveReq)
            {

                return base.Save_LeaveRecordDtls(objLeaveReq);


            }
                
            public new void Save_LeaveRequestSub(HRM.LeaveData.LeaveRequestSubDM objReqSub,   NewDAL.DBManager objDB)
            {
                //Boolean flag = 
                base.Save_LeaveRequestSub(objReqSub, objDB);
                //if (flag == true)
                //{
                //    return "Record saved.";
                //}
                //else
                //{
                //    return "Unable to save record ";
                //}
            }
          
        }
    }
}