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
using System.Data.Common;


/// <summary>
/// Summary description for Administrator
/// </summary>
public class Administrator
{
     protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
	public Administrator()
	{
        //objCon = new DataAccLayer.DbConnection();
	}
    public void Admin_AppSettings_Save1(string flag, int CollegeID, string CollegeName, string ShortName, string Location, string Phone1, string Phone2, string Phone3, string Fax, string Mobile, string EmailID1, string EmailID2, string WebSite, string Description, byte[] InstLogo, string Acd_Session, string LibName, string TinNo, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                con.Open();
                com.Connection = con;

                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("CollegeID", CollegeID);
                com.Parameters.AddWithValue("CollegeName", CollegeName);
                com.Parameters.AddWithValue("ShortName", ShortName);
                com.Parameters.AddWithValue("Location", Location);
                com.Parameters.AddWithValue("Phone1", Phone1);
                com.Parameters.AddWithValue("Phone2", Phone2);

                com.Parameters.AddWithValue("Phone3", Phone3);
                com.Parameters.AddWithValue("Fax", Fax);
                com.Parameters.AddWithValue("Mobile", Mobile);
                com.Parameters.AddWithValue("EmailID1", EmailID1);
                com.Parameters.AddWithValue("EmailID2", EmailID2);

                com.Parameters.AddWithValue("WebSite", WebSite);
                com.Parameters.AddWithValue("Description", Description);
                com.Parameters.AddWithValue("InstLogo", InstLogo);
                com.Parameters.AddWithValue("Acd_Session", Acd_Session);
                com.Parameters.AddWithValue("LibName", LibName);
                com.Parameters.AddWithValue("TinNo", TinNo);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_College";

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            }
            catch (Exception ex)
            {
                RetSuccess = "0";
            }
            finally
            {
                com.Dispose();
            }
        }
    }
    public void Admin_AppSettings_Save(string flag, int CollegeID, string CollegeName, string ShortName, string Location, string Phone1, string Phone2, string Phone3, string Fax, string Mobile, string EmailID1, string EmailID2, string WebSite, string Description, byte[] IDCardLogo, ref string RetSuccess)
    {
		SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                con.Open();
                com.Connection = con;

                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("CollegeID", CollegeID);
                com.Parameters.AddWithValue("CollegeName", CollegeName);
                com.Parameters.AddWithValue("ShortName", ShortName);
                com.Parameters.AddWithValue("Location", Location);
                com.Parameters.AddWithValue("Phone1", Phone1);
                com.Parameters.AddWithValue("Phone2", Phone2);

                com.Parameters.AddWithValue("Phone3", Phone3);
                com.Parameters.AddWithValue("Fax", Fax);
                com.Parameters.AddWithValue("Mobile", Mobile);
                com.Parameters.AddWithValue("EmailID1", EmailID1);
                com.Parameters.AddWithValue("EmailID2", EmailID2);

                com.Parameters.AddWithValue("WebSite", WebSite);
                com.Parameters.AddWithValue("Description", Description);
                
                com.Parameters.AddWithValue("Isgroup", "N");
                com.Parameters.AddWithValue("IDCardLogo", IDCardLogo);
				
				
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_College";

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            }
            catch (Exception ex)
            {
                RetSuccess = "0";
            }
            finally
            {
                com.Dispose();
            }
        }      
    }

    //public void Set_Active_Session(int id_session, ref string RetSuccess)
    //{ 
    //    SqlCommand com = null;
    //    using (SqlConnection con = new SqlConnection(ReturnConString()))
    //    {
    //        try
    //        {
    //            com = new SqlCommand();
    //            con.Open();
    //            com.Connection = con;
    //            //com.Parameters.AddWithValue("flag", flag);
    //            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
    //            com.Parameters.AddWithValue("fields", null);
    //            com.Parameters.AddWithValue("where", null);
    //            com.Parameters.AddWithValue("id_session", id_session);
                  
    //            com.CommandType = CommandType.StoredProcedure;
    //            com.CommandText = "SUID_acd_session";
    //            com.ExecuteNonQuery();
    //            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            RetSuccess = "0";
    //        }
    //        finally
    //        {
    //            com.Dispose();
    //        }
    //    }        
    //}

    //....................................Proxy Setting......................................................

    //public void Proxy_Save(string flag, int CollegeID, string ProxyAddress, string ProxyUser, string ProxyPwd, string Salt, Boolean IsMailActive, ref string RetSuccess)
    //{
    //    SqlCommand com = null;
    //    using (SqlConnection con = new SqlConnection(ReturnConString()))
    //    {
    //        try
    //        {
    //            com = new SqlCommand();
    //            con.Open();
    //            com.Connection = con;

    //            com.Parameters.AddWithValue("flag", flag);
    //            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;              
    //            com.Parameters.AddWithValue("CollegeID", CollegeID);
    //            com.Parameters.AddWithValue("ProxyAddress", ProxyAddress);
    //            com.Parameters.AddWithValue("ProxyUser", ProxyUser);
    //            com.Parameters.AddWithValue("ProxyPwd", ProxyPwd);
    //            com.Parameters.AddWithValue("Salt", Salt);
    //            com.Parameters.AddWithValue("IsMailActive", IsMailActive);
               				
    //            com.CommandType = CommandType.StoredProcedure;
    //            com.CommandText = "SUID_College";

    //            com.ExecuteNonQuery();

    //            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            RetSuccess = "0";
    //        }
    //        finally
    //        {
    //            com.Dispose();
    //        }
    //    }     
    //}

    //public void App_Settings_Save(int CollegeID, Int32 IndntPndng_Days, Int32 IssueWaitDays, Int32 RsrvtionWaitDays, ref string RetSuccess)
    //{
    //    SqlCommand com = null;
    //    using (SqlConnection con = new SqlConnection(ReturnConString()))
    //    {
    //        try
    //        {
    //            com = new SqlCommand();
    //            con.Open();
    //            com.Connection = con;

    //            com.Parameters.AddWithValue("flag", "A");
    //            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
    //            com.Parameters.AddWithValue("CollegeID", CollegeID);
    //            com.Parameters.AddWithValue("IndntPndng_Days", IndntPndng_Days);
    //            com.Parameters.AddWithValue("IssueWaitDays", IssueWaitDays);
    //            com.Parameters.AddWithValue("RsrvtionWaitDays", RsrvtionWaitDays);   

    //            com.CommandType = CommandType.StoredProcedure;
    //            com.CommandText = "SUID_College";

    //            com.ExecuteNonQuery();

    //            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            RetSuccess = "0";
    //        }
    //        finally
    //        {
    //            com.Dispose();
    //        }
    //    }     
    //}

    //public Boolean IsAuto_Member_ID(Int32 InstId, DBManager Objdal)
    //{
    //    Boolean IsAuto = false;
    //    object IsAutoGen_MemId = null;
    //    string Query = "Select isnull(IsAutoGen_MemId,'false') from College Where CollegeId='" + InstId + "'";
    //    IsAutoGen_MemId = Objdal.ExecuteScalar(CommandType.Text, Query);
    //    Objdal.Command.Parameters.Clear();
    //    if (IsAutoGen_MemId.ToString() == "True")
    //        IsAuto = true;

    //    return IsAuto;
    //}
    public void Set_Active_Session(int id_session, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                //com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("fields", null);
                com.Parameters.AddWithValue("where", null);
                com.Parameters.AddWithValue("id_session", id_session);

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_acd_session";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            }
            catch (Exception ex)
            {
                RetSuccess = "0";
            }
            finally
            {
                com.Dispose();
            }
        }
    }

    //....................................Proxy Setting......................................................

    public void Proxy_Save(string flag, int CollegeID, string ProxyAddress, string ProxyUser, string ProxyPwd, string Salt, Boolean IsMailActive, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                con.Open();
                com.Connection = con;

                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("CollegeID", CollegeID);
                com.Parameters.AddWithValue("ProxyAddress", ProxyAddress);
                com.Parameters.AddWithValue("ProxyUser", ProxyUser);
                com.Parameters.AddWithValue("ProxyPwd", ProxyPwd);
                com.Parameters.AddWithValue("Salt", Salt);
                com.Parameters.AddWithValue("IsMailActive", IsMailActive);

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_College";

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            }
            catch (Exception ex)
            {
                RetSuccess = "0";
            }
            finally
            {
                com.Dispose();
            }
        }
    }

    public void App_Settings_Save(int CollegeID, Int32 IndntPndng_Days, Int32 IssueWaitDays, Int32 RsrvtionWaitDays, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            try
            {
                com = new SqlCommand();
                con.Open();
                com.Connection = con;

                com.Parameters.AddWithValue("flag", "A");
                com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("CollegeID", CollegeID);
                com.Parameters.AddWithValue("IndntPndng_Days", IndntPndng_Days);
                com.Parameters.AddWithValue("IssueWaitDays", IssueWaitDays);
                com.Parameters.AddWithValue("RsrvtionWaitDays", RsrvtionWaitDays);

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_College";

                com.ExecuteNonQuery();

                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            }
            catch (Exception ex)
            {
                RetSuccess = "0";
            }
            finally
            {
                com.Dispose();
            }
        }
    }

}
