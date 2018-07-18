using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;

public partial class SignUP : System.Web.UI.Page
{
    static String passwords;
    DbFunctions objfun = new DbFunctions();
    DbFunctions objFunc = new DbFunctions();
    static Random random = new Random();
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        /*if (Session["UID"] == null)
        {
            Response.Redirect("../error_404_2.html");
            return;
        }
        if (Session["instID"].ToString() == null)
        {
            Response.Redirect("../error_404_2.html");
        }
        if (Session["sesnID"].ToString() == null)
        {
            Response.Redirect("../error_404_2.html");
        }*/
        try
        {

            BranchDivL.Visible = false;
            Course_Label.Visible = false;
            Subject_Label.Visible = false;
            Gender_Label.Visible = false;
            if (!IsPostBack)
            {
                BranchDiv.Visible = false;
                Dcourse.Items.Insert(0, "---Select Course---");
                Dsubject.Items.Insert(0, "---Select Area of intrest---");
                Dbranch.Items.Insert(0, "---Select Specialization---");
                objFunc.FillDropdownlist(Dcourse, "Course", "Id", "SELECT Course,Id FROM (select id,Course,row_number() over(partition by course order by id ) as rn   from inst1_details)t where rn=1 ", "---Select Course---");
                Dcourse.Focus();

            }
            if (IsPostBack)
            {
                
                conn.Open();
                string checkUser = "select count(*) from faculty_detail where email='" + TextBox_EmailId.Text + "'";
                SqlCommand com = new SqlCommand(checkUser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    objfun.MsgBox("Email Id Already exists...", this);
                }
                
            }
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
    protected void SendOTP(String Email)
    {
        try
        {

            SqlCommand cmd = new SqlCommand("SELECT MAX(OTP) FROM OTPT", conn);
            conn.Open();
            String otp = cmd.ExecuteScalar().ToString();
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

    protected void Course_SelectedIndexChanged(object sender, EventArgs e)
    {
       // try
        //{
        if (Dcourse.SelectedItem.ToString() == "B.tech")
        {
            BranchDiv.Visible = true;
            string sql = "SELECT Branch,Id FROM (select id,Branch,row_number() over(partition by Branch order by id ) as rn   from inst1_details)t where rn=1 ";
            objFunc.FillDropdownlist(Dbranch, "Branch", "Id", sql, "---Select Specialization---");
        }
        else
        {
            BranchDiv.Visible = false;
            objFunc.FillDropdownlist(Dsubject, "Subject", "Id", "SELECT Subject,Id FROM inst1_details WHERE Course= '" + Dcourse.SelectedItem + "'", "---Select Area of interest---");
        }
               
        /*}
        catch (Exception ex)
        {
            Response.Redirect("../error_404_2.html");
        }*/
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
            HttpPostedFile ps = FileUpload1.PostedFile;
            Stream stream = ps.InputStream;
            BinaryReader br = new BinaryReader(stream);
            byte[] file = br.ReadBytes((int)stream.Length);
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
                if ((Dcourse.SelectedItem.ToString()).Equals("---Select Course---"))
                {
                    Course_Label.Visible = true;
                }
                else
                    if ((Dcourse.SelectedItem.ToString()).Equals("B.tech") && (Dbranch.SelectedItem.ToString()).Equals("---Select Specialization---"))
                    {
                        BranchDiv.Visible = true;
                    }
                    else
                        if ((Dsubject.SelectedItem.ToString()).Equals("---Select Area of interest---"))
                    {
                        Subject_Label.Visible = true;
                    }
                    else
                        if (!Male_RadioButton.Checked && !Female_RadioButton.Checked && !Other_RadioButton.Checked)
                             Gender_Label.Visible = true;
                             else
                            if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png") || ext.Equals(".gif"))
                            {
                                 if ((TextBox_Password.Text.ToString()).Equals(""))
                                       objfun.MsgBox("Enter Password....", this);
                                       else
                                        {
                                            //passwords = "";
                                            passwords = TextBox_Password.Text.ToString();
                                            SqlCommand cmd1 = new SqlCommand("UPDATE OTPT SET OTP='" + (random.Next(1000, 9999)) + "' WHERE SrNo = 1", conn);
                                            conn.Open();
                                            cmd1.ExecuteNonQuery();
                                            conn.Close();
                                            SendOTP(TextBox_EmailId.Text.ToString());
                                            Label1.Text = "OTP sent to Email Id";
                                            Label1.Visible = true;
                                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                                        }
        /*}
        catch (Exception ex)
        {
            //Response.Redirect("../error_404_2.html");
            throw ex;
        }
        finally
        {
            conn.Close();
        }*/
                            }
                            else
                                objfun.MsgBox("Incorrect image format....", this);
    }
    protected void Button_OTP1_Submit(object sender, EventArgs e)
    {
        //try
        //{
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 OTP FROM OTPT ORDER BY OTP DESC", conn);
            conn.Open();
            String otp = cmd.ExecuteScalar().ToString();
            if (TextBox_OTP1.Text == otp)
            {
                HttpPostedFile ps = FileUpload1.PostedFile;
                Stream stream = ps.InputStream;
                BinaryReader br = new BinaryReader(stream);
                byte[] file = br.ReadBytes((int)stream.Length);
                string filePath = FileUpload1.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                DateTime dt = Convert.ToDateTime(TextBox1.Text);
                DateTime dateOnly = dt.Date;
                int f_id=Convert.ToInt32(TextBox_CollegeId.Text);
                String gender = Male_RadioButton.Checked ? Male_RadioButton.Text.ToString() : (Female_RadioButton.Checked ? Female_RadioButton.Text : Other_RadioButton.Text);
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString))
                {
                    if ((Dbranch.SelectedItem.ToString()).Equals("---Select Specialization---"))
                    {

                        String sql = "INSERT INTO faculty_detail (Course,Subject,f_name,dob,email,f_id,Password,m_no,gender,img) VALUES ('" + Dcourse.SelectedItem + "','" + Dsubject.SelectedItem + "','" + TextBox_FirstName.Text + " " + TextBox_LastName.Text + "','" + dateOnly + "','" + TextBox_EmailId.Text + "','" + TextBox_CollegeId.Text + "','" + passwords + "','" + TextBox_MobileNumber.Text + "','" + gender + "',@asd) ";
                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        cmd1.Parameters.AddWithValue("@asd", file);
                        cmd1.ExecuteNonQuery();
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        String sql = "INSERT INTO faculty_detail (Course,specialization,Subject,f_name,dob,email,f_id,Password,m_no,gender,img) VALUES ('" + Dcourse.SelectedItem + "','" + Dbranch.SelectedItem + "','" + Dsubject.SelectedItem + "','" + TextBox_FirstName.Text + " " + TextBox_LastName.Text + "','" + dateOnly + "','" + TextBox_EmailId.Text + "','" + f_id + "','" + passwords + "','" + TextBox_MobileNumber.Text + "','" + gender + "',@asd) ";
                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        cmd1.Parameters.AddWithValue("@asd", file);
                        cmd1.ExecuteNonQuery();
                        Response.Redirect("Login.aspx");
                    }
                    
                }
            }
            else
            {
                objfun.MsgBox("Wrong OTP....", this);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
       /* }
        catch (Exception ex)
        {
            //Response.Redirect("../error_404_2.html");
            throw ex;
        }
        finally
        {
            conn.Close();
        }*/
    }
    protected void Button_OTP1_Resend(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE OTPT SET OTP='" + (random.Next(1000, 9999)) + "' WHERE SrNo = 1", conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            SendOTP(TextBox_EmailId.Text.ToString());
            Label1.Text = "OTP sent to Email Id";
            Label1.Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }
        catch (Exception ex)
        {
           // Response.Redirect("../error_404_2.html");
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }

   /* protected void Dbranch_SelectedIndexChanged1(object sender, EventArgs e)
    {
        objFunc.FillDropdownlist(Dsubject, "Subject", "Id", "SELECT Subject,Id FROM inst1_details WHERE Course='" + Dbranch.SelectedItem + "'", "---Select Area of interest---");
    }*/
    protected void Dbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        String sql="SELECT Subject,Id FROM inst1_details WHERE Branch= '"+ Dbranch.SelectedItem + "'";
        objFunc.FillDropdownlist(Dsubject, "Subject", "Id", sql, "---Select Area of interest---");
    }
    /*protected void Button6_Click(object sender, EventArgs e)
    {
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        conn.Open();
        String sql = "INSERT INTO faculty_detail values(@asd)";
        SqlCommand com = new SqlCommand(sql, conn);
        com.Parameters.AddWithValue("@asd", file);
        com.ExecuteNonQuery();
        conn.Close();
    }*/
}