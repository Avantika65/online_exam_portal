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
using System.Data.SqlClient;

/// <summary>
/// Summary description for Shift_Planning
/// </summary>
public class Shift_Planning
{
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
	public Shift_Planning()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region Automated Attendance Generation
    /// <summary>
    /// Generate Auto Attendance Schedule For Employee's
    /// </summary>
    /// <param name="InstId">Institute Id</param>
    /// <param name="SessionId">Institute Session Name</param>
    /// <returns>Boolean:Is Process Success</returns>
    public Boolean Auto_Generate_Emp_Attendance_Schedule()
    {
        SqlCommand com = null;        
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dtCollege = new DataTable();

        Boolean IsSuccess=true;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();

                cnx.Open();
                
                String Query = "Select CollegeID,ShortName,'' as SessionId From College";

                com.Connection = cnx;
                com.CommandText = Query;
                da.SelectCommand = com;

                da.Fill(dtCollege);
                
                

                foreach (DataRow fdr in dtCollege.Rows)
                {
                    com.Parameters.Clear();

                    com.Parameters.AddWithValue("@InstId", fdr["CollegeID"].ToString());
                    com.Parameters.AddWithValue("@SessionId", fdr["SessionId"].ToString());

                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "[SUID_Gen_AutoAtd_Schedule]";

                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                IsSuccess = false;
            }
            finally
            {
                dtCollege.Dispose();
                da.Dispose();
                com.Parameters.Clear();
            }
        }

        return IsSuccess;
    }

    #endregion

    #region Shift Group

    public void ShiftGroup_Save(String flag, Int32 InstID, String SessionId, String UserId, Int32 ShiftGroup_Id, String ShiftGroup_Name, String ShiftGroup_ShortName, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                cnx.Open();
                com.Connection = cnx;

                com.Parameters.AddWithValue("@flag", flag);
                com.Parameters.AddWithValue("@RetSuccess", "0").Direction=ParameterDirection.Output;

                com.Parameters.AddWithValue("@fields", null);
                com.Parameters.AddWithValue("@where", null);
                com.Parameters.AddWithValue("@InstID", InstID);

                com.Parameters.AddWithValue("@SessionId", SessionId);
                com.Parameters.AddWithValue("@UserId", UserId);
                com.Parameters.AddWithValue("@UEDate", DateTime.Now.Date.ToShortDateString());

                com.Parameters.AddWithValue("@SG_Id", ShiftGroup_Id);
                com.Parameters.AddWithValue("@SG_Name", ShiftGroup_Name);
                com.Parameters.AddWithValue("@SG_ShortName", ShiftGroup_ShortName);

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[SUID_ShiftGroup]";

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();
            }
            catch { RetSuccess = "0"; }
            finally { com.Dispose();}
        }
    }
    public void ShiftGroup_Delete(String flag, Int32 InstID, Int32 ShiftGroup_Id, ref String RetSuccess)
    {
         SqlCommand com = null;
         using (SqlConnection cnx = new SqlConnection(ReturnConString()))
         {
             try
             {
                 com = new SqlCommand();
                 cnx.Open();
                 com.Connection = cnx;

                 com.Parameters.AddWithValue("@flag", flag);
                 com.Parameters.AddWithValue("@RetSuccess", 0).Direction = ParameterDirection.Output;

                 com.Parameters.AddWithValue("@fields", null);
                 com.Parameters.AddWithValue("@where", null);
                 com.Parameters.AddWithValue("@InstID", InstID);
                 com.Parameters.AddWithValue("@SessionId", null);
                 com.Parameters.AddWithValue("@UserId", null);
                 com.Parameters.AddWithValue("@UEDate", null);
                 com.Parameters.AddWithValue("@SG_Id", ShiftGroup_Id);

                 com.CommandType = CommandType.StoredProcedure;
                 com.CommandText = "[SUID_ShiftGroup]";

                 com.ExecuteNonQuery();

                 RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();

             }
             catch { RetSuccess = "0"; }
             finally { com.Dispose(); }
         }
    }

    #endregion

    #region Shift Master

    public void ShiftMaster_Save(String flag, Int32 InstID, String SessionId, String UserId, Int32 Shift_Id, String Shift_Name, String Shift_ShortName, Int32 Shift_Group_Id, Int32 Dept_Categ_Id, String TimeF, String TimeT, String Shift_Type, String Start_Day, String Day_Patern, String Repeat_Patern, ref string RetSuccess)
    {        
        SqlCommand com = null;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                cnx.Open();
                com.Connection = cnx;

                com.Parameters.AddWithValue("@flag", flag);
                com.Parameters.AddWithValue("@RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("@fields", null);
                com.Parameters.AddWithValue("@where", null);
                com.Parameters.AddWithValue("@InstID", InstID);
                com.Parameters.AddWithValue("@SessionId", SessionId);
                com.Parameters.AddWithValue("@UserId", UserId);
                com.Parameters.AddWithValue("@UEDate", DateTime.Now.Date.ToShortDateString());

                com.Parameters.AddWithValue("@Shift_Id", Shift_Id);

                com.Parameters.AddWithValue("@Shift_Name", Shift_Name);
                com.Parameters.AddWithValue("@Shift_ShortName", Shift_ShortName);

                com.Parameters.AddWithValue("@Shift_Group_Id", Shift_Group_Id);
                com.Parameters.AddWithValue("@Dept_Categ_Id", Dept_Categ_Id);

                com.Parameters.AddWithValue("@TimeF", TimeF);
                com.Parameters.AddWithValue("@TimeT", TimeT);

                com.Parameters.AddWithValue("@Shift_Type", Shift_Type);
                com.Parameters.AddWithValue("@Start_Day", Start_Day);

                com.Parameters.AddWithValue("@Day_Patern", Day_Patern);
                com.Parameters.AddWithValue("@Repeat_Patern", Repeat_Patern);

                com.CommandType=CommandType.StoredProcedure;
                com.CommandText= "[SUID_ShiftMaster]";

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();
            }
            catch { RetSuccess = "0"; }
            finally { com.Dispose(); }
        }
    }
    public void ShiftMaster_Delete(String flag, Int32 InstID, Int32 ShiftMaster_Id, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                cnx.Open();
                com.Connection = cnx;

                com.Parameters.AddWithValue("@flag", flag);
                com.Parameters.AddWithValue("@RetSuccess", 0);
                com.Parameters.AddWithValue("@fields", null);
                com.Parameters.AddWithValue("@where", null);
                com.Parameters.AddWithValue("@InstID", InstID);
                com.Parameters.AddWithValue("@SessionId", null);
                com.Parameters.AddWithValue("@UserId", null);
                com.Parameters.AddWithValue("@UEDate", null);
                com.Parameters.AddWithValue("@Shift_Id", ShiftMaster_Id);

                com.CommandText = "[SUID_ShiftMaster]";
                com.CommandType = CommandType.StoredProcedure;

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();

            }
            catch { RetSuccess = "0"; }
            finally {com.Dispose();}
        }
    }

    #endregion

    #region Shift Allotment
    public void ShiftAllocated_Delete(String flag, Int32 InstID, Int32 Allocated_Id, ref String RetSuccess)
    {
         SqlCommand com = null;
         using (SqlConnection cnx = new SqlConnection(ReturnConString()))
         {
             try
             {
                 com = new SqlCommand();
                 cnx.Open();
                 com.Connection = cnx;

                 com.Parameters.AddWithValue("@flag", flag);
                 com.Parameters.AddWithValue("@RetSuccess", 0).Direction = ParameterDirection.Output;
                 com.Parameters.AddWithValue("@fields", null);
                 com.Parameters.AddWithValue("@where", null);
                 com.Parameters.AddWithValue("@InstID", InstID);
                 com.Parameters.AddWithValue("@SessionId", null);
                 com.Parameters.AddWithValue("@UserId", null);
                 com.Parameters.AddWithValue("@UEDate", null);
                 com.Parameters.AddWithValue("@Id", Allocated_Id);

                 com.CommandType = CommandType.StoredProcedure;
                 com.CommandText = "[Valid_Shift_Allot_New]";

                 com.ExecuteNonQuery();

                 RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();

             }
             catch { RetSuccess = "0"; }
             finally
             {
                 com.Dispose();
             }
         }
    }
    public void ShiftAllotment_Save(String flag, Int32 InstID, String SessionId, String UserId, Int64 Allot_Id, Int32 EmpId, Int32 ShiftId, DateTime DateFrom, DateTime DateTo, String RepeatedShift, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection cnx = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                cnx.Open();
                com.Connection = cnx;

                com.Parameters.AddWithValue("@flag", flag);
                com.Parameters.AddWithValue("@RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("@fields", null);
                com.Parameters.AddWithValue("@where", null);
                com.Parameters.AddWithValue("@InstID", InstID);
                com.Parameters.AddWithValue("@SessionId", SessionId);
                com.Parameters.AddWithValue("@UserId", UserId);
                com.Parameters.AddWithValue("@UEDate", DateTime.Now.Date.ToShortDateString());

                com.Parameters.AddWithValue("@Id", Allot_Id);
                com.Parameters.AddWithValue("@EmpId", EmpId);
                com.Parameters.AddWithValue("@ShiftId", ShiftId);
                com.Parameters.AddWithValue("@DateF", DateFrom);
                com.Parameters.AddWithValue("@DateT", DateTo);
                com.Parameters.AddWithValue("@RepeatShift", RepeatedShift);

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[Valid_Shift_Allot_New]";

                com.ExecuteNonQuery();                

                RetSuccess = com.Parameters["@RetSuccess"].Value.ToString();

            }
            catch { RetSuccess = "0"; }
            finally
            {
                com.Dispose();
            }
        }
    }
    #endregion
}
