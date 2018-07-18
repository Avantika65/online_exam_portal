﻿using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Services;
using System.Configuration;
using System.Drawing.Design;
/// <summary>
/// Summary description for RCSService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class RCSService1 : System.Web.Services.WebService {

    public RCSService1 () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 

    }
    [WebMethod,ScriptMethod]
    public String ExportExcelfile(String Identifier,String fileurl,String Sheet_Name)
    {
        SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);

        SqlCommand cmd = new SqlCommand();
        
        String IsSuccess = null;
        try
        {
            cnx.Open();
            cmd.CommandText = "[Exportxls]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.CommandTimeout = 0;

            cmd.Parameters.Add("@provider", SqlDbType.NVarChar).Value = "'Microsoft.Jet.OLEDB.4.0'";           

            cmd.Parameters.Add("@fileUri", SqlDbType.NVarChar).Value = "'Excel 8.0;Database=" + fileurl + "'";

            cmd.Parameters.Add("@identifier", SqlDbType.NVarChar).Value = Identifier;
            cmd.ExecuteNonQuery();
            
            IsSuccess = "Contacts Uploaded Successfully";

          
        }
        catch { IsSuccess = "Sorry! Contacts not uploaded"; }
        finally { cmd.Dispose(); cnx.Close(); cnx.Dispose(); }
        
        return IsSuccess;

    }

    [WebMethod, ScriptMethod]
    public void rcs(ArrayList Contact_,string Sender,string Message)
    {
        string Contact = null;
        SqlConnection cnx = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        cnx.Open();
        SqlTransaction sqltran = cnx.BeginTransaction();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnx;
        cmd.Transaction = sqltran;
        //System.Array arr;
        //System.Array ContactArr;

        if (Contact_!=null)
        {
            string Name_=null;
            string ContactNo_=null;
            string Id_=null;
            //arr = Microsoft.VisualBasic.Strings.Split(Contact, ",", -1, 0);
            for (int i = 0; (i < Contact_.Count) && Contact_[i]!=null; i++)
            {
                ContactNo_ = ((object[])(Contact_[i]))[0].ToString().Trim();
                Name_ = ((object[])(Contact_[i]))[1].ToString().Trim();
                Id_ = ((object[])(Contact_[i]))[2].ToString().Trim();

                string Candidate = "Dear " + (Name_ == string.Empty ? "Candidate" : Name_);
                //ContactArr = Microsoft.VisualBasic.Strings.Split(arr.GetValue(i).ToString(),"-",-1,0);
                //string Candidate = "Dear " + (ContactArr.GetValue(1).ToString().Trim() == "&nbsp;" ? "Candidate" : ContactArr.GetValue(1).ToString().Trim());

                /*
                string str = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=admin.ramagroup@gmail.com:792677&senderID='" + Sender.ToString() + "'&receipientno=" + ContactArr.GetValue(0).ToString() + "&msgtxt=" + Candidate.ToString() + " " + Message.ToString() + "&state=4";
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(str);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
                */
                string responseString = "";
                if (responseString.ToString() == "")
                {
                    String Query = "Insert INTO SMSRecord(ContactID,ContactNum,Messages,Status,U_Name,U_Date)" + "Values('" + Id_ + "','" +ContactNo_ + "','" + Message.ToString().Trim() + "','1','" + "-" + "','" + DateTime.Now.Date.ToString() + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Query;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                else
                {
                    String Query = "Insert INTO SMSRecord(ContactID,ContactNum,Messages,Status,U_Name,U_Date)" + "Values('" + Id_ + "','" + ContactNo_ + "','" + Message.ToString().Trim() + "','0','" + "-" + "','" + DateTime.Now.Date.ToString() + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Query;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                 
            }
            sqltran.Commit();
            cnx.Close();
           
        }

    }
   
    
    
}

