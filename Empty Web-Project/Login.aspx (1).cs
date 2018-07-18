using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

using System.Net;
using System.Net.Mail;
using System.IO;
using System.Collections.Specialized;

public partial class Login : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
    static Random random = new Random();
    DbFunctions objfunc = new DbFunctions();
    static int hr, min;

    //static String EmailId;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Label6.Visible = false;
        Label7.Visible = false;
        Label8.Visible = false;
        Label9.Visible = false;
        Label10.Visible = false;
    }
    
    protected void SendOTP(String Email)
    {
        try
        {
           
            SqlCommand cmd = new SqlCommand("SELECT MAX(OTP) FROM OTPT", conn);
            conn.Open();
            String otp = cmd.ExecuteScalar().ToString();
            conn.Close();
            //string to = log.Text; //To address    
            string from = "avneetvishnoi414@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, Email);
            string mailbody = "Your required OTP is " + otp;
            message.Subject = "This is the OTP required for this session of Login";
            message.Body = mailbody;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("avneetvishnoi414@gmail.com", "lallolal03");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
            
        }
        catch (Exception ex)
        { 
            //Response.Redirect("../error_404_2.html"); 
            throw ex;
        }
            finally
        {
            conn.Close();
        }


    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //try
        //{
        String tableName = DropDownList1.SelectedItem + "_detail";
            if (log.Text.ToString().Trim() == "")
            {
                objfunc.MsgBox("Please Enter User Name.", this);
            }
            else
                if (Pass.Text.ToString().Trim() == "")
                {
                    objfunc.MsgBox("Please Enter Password.", this);
                }
                else
                    if(tableName.Equals("---SELECT---_detail"))
                        objfunc.MsgBox("Please Select student or faculty", this);
                else
                {
                    conn.Open();
                    string checkUser = "select count(*) from "+tableName+" where email='" + log.Text + "'";
                    SqlCommand com = new SqlCommand(checkUser, conn);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                    conn.Close();
                    if (temp == 1)
                    {

                        string checkPassword = "select Password from " + tableName + " where email='" + log.Text + "'";
                        SqlCommand cmd = new SqlCommand(checkPassword, conn);
                        conn.Open();
                        string passw = cmd.ExecuteScalar().ToString();
                        conn.Close();

                        //Response.Write(checkPassword);
                        if (passw == Pass.Text)
                        {
                            
                            SqlCommand cmd1 = new SqlCommand("UPDATE OTPT SET OTP='" + (random.Next(1000, 9999)) + "' WHERE SrNo = 1", conn);
                            SqlCommand cmd2 = new SqlCommand("SELECT m_no FROM " + tableName + " where email='" + log.Text + "'", conn);
                            conn.Open();
                            //Response.Write(checkPassword);
                            String number = cmd2.ExecuteScalar().ToString();
                            cmd1.ExecuteNonQuery();
                            conn.Close();
                            
                                SendOTP(log.Text.ToString());
                                Label10.Text = "OTP Sent to Email Id";
                                Label10.Visible = true;
                            
                            
                            
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                            //Boolean a = (TextBox_OTP1.Text.ToString()).Equals(OTP);
                        }
                        else
                            objfunc.MsgBox("Invalid Password....", this);

                    }
                    else
                        objfunc.MsgBox("No such Email Id....", this);

                }
        /*}
        catch (Exception ex)
        {
            Response.Redirect("../error_404_2.html");
            //throw ex;
        }
        finally
        {
            conn.Close();
        }*/

    }
    protected void Button_OTP1_Submit(object sender, EventArgs e)
    {
       // try
       // {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 OTP FROM OTPT ORDER BY OTP DESC", con);
            con.Open();
            String otp = cmd.ExecuteScalar().ToString();
            con.Close();
            //SqlCommand cmd1 = new SqlCommand("DELETE * FROM OTP", conn);
            
            if (TextBox_OTP1.Text == otp)
                Response.Redirect("Default3.aspx?id=" + log.Text.ToString() + "");
            else
            {
                Label9.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        /*}
        catch (Exception ex)
        {
            Response.Redirect("../error_404_2.html");
            //throw ex;
        }*/


    }
    protected void Button_OTP1_Resend(object sender, EventArgs e)
    {
       // try
       // {
        String tableName = DropDownList1.SelectedItem + "_detail";
            SqlCommand cmd1 = new SqlCommand("UPDATE OTPT SET OTP='" + (random.Next(1000, 9999)) + "' WHERE SrNo = 1", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT m_no FROM "+tableName+" where email='" + log.Text + "'", conn);
            conn.Open();
            String number = cmd2.ExecuteScalar().ToString();
            cmd1.ExecuteNonQuery();
            conn.Close();


            
                SendOTP(log.Text.ToString());
                Label10.Text = "OTP Sent to Email Id";
                Label10.Visible = true;
            
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
       /* }
        catch (Exception ex)
        {
           Response.Redirect("../error_404_2.html");
           // throw ex;
        }
        finally
        {
            conn.Close();
        }*/

    }
    protected void Button_OTP_Send_Fo(object sender, EventArgs e)
    {
       // try
        //{
        String tableName = DropDownList2.SelectedItem + "_detail";
        if (tableName.Equals("---SELECT---_detail"))
        {
            objfunc.MsgBox("Please Select student or faculty", this);
        }
        else
        {
            conn.Open();
            string checkUser = "select count(*) from faculty_detail where email='" + TextBox_EmailId_Fo.Text + "'";
            SqlCommand cmd2 = new SqlCommand("SELECT m_no FROM " + tableName + " where email='" + TextBox_EmailId_Fo.Text + "'", conn);
            SqlCommand com = new SqlCommand(checkUser, conn);
            //String number = cmd2.ExecuteScalar().ToString();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                SqlCommand cmd5 = new SqlCommand("UPDATE OTPT SET OTP='" + (random.Next(1000, 9999)) + "' WHERE SrNo = 1", conn);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);

                cmd5.ExecuteNonQuery();
                conn.Close();
                
                    SendOTP(TextBox_EmailId_Fo.Text.ToString());
                    Label7.Text = "OTP Sent to Email Id";
                    Label7.Visible = true;
                
                

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
                Label6.Visible = true;
            }
            /*}
            catch (Exception ex)
            {
                Response.Redirect("../error_404_2.html");
                //throw ex;
            }
            finally
            {
                conn.Close();
            }*/

        } 
    }
    protected void Button_OTP_Submit_Fo(object sender, EventArgs e)
    {
        //try
        //{
        String tableName = DropDownList2.SelectedItem + "_detail";
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 OTP FROM OTPT ORDER BY OTP DESC", conn);
            conn.Open();
            String otp = cmd.ExecuteScalar().ToString();
            conn.Close();
            if (TextBox_OTP_Fo.Text == otp)
            {
                if (TextBox_Password_Fo.Text != TextBox_CPassword_Fo.Text)
                {
                    objfunc.MsgBox("Both Passwords must be same....", this);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE "+tableName+" SET Password='" + TextBox_Password_Fo.Text + "' WHERE email='" + TextBox_EmailId_Fo.Text + "'", conn);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect(Request.RawUrl.ToString()); // redirect on itself
                    //objfunc.MsgBox("Password Successfully reset....", this);
                }
            }

            else
            {
                Label8.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
            }
        /*}
        catch (Exception ex)
        {
            Response.Redirect("../error_404_2.html");
            //throw ex;
        }
        finally
        {
            conn.Close();
        }*/

    }
}