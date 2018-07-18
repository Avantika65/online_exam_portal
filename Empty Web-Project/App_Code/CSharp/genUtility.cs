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
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net.Mail;
using NewDAL;

/// <summary>
/// Summary description for genUtility
/// </summary>
public class genUtility
{
    SqlCommand cmd = null;
    SqlConnection cn = null;
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
	public genUtility()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public genUtility(String constring)
    {
        cn = new SqlConnection(constring);
    }
    //public bool InvalidChars(string sInput)
    //{
    //    bool functionReturnValue = false;
    //    //Declare variables
    //    object sBadChars;
    //    int iCounter;
    //    //Set functionReturnValue to False
    //    functionReturnValue = false;
    //    //Create an array of invalid characters and words
    //    sBadChars = array("select", "drop", ";", "--", "insert", "delete", "xp_", "#", "%", "&", "'", "(", ")", "/", "\\", ":", ";", "<", ">", "=","[", "]", "?", "`", "|");
    //    //Loop through array sBadChars using our counter & UBound function
    //    for (iCounter = 0; iCounter <= Information.uBound(sBadChars); iCounter++)
    //    {
    //        //Use Function Instr to check presence of illegal character in our variable
    //        if (Strings.Instr(sInput, sBadChars(iCounter)) > 0)
    //        {
    //            functionReturnValue = true;
    //        }
    //    }
    //    return functionReturnValue;
    //}

    private string base64Encode(string sData)
    {
        try
        {
            byte[] encData_byte = new byte[sData.Length];

            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

            string encodedData = Convert.ToBase64String(encData_byte);

            return encodedData;

        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
    private string base64Decode(string sData)
    {

        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

        System.Text.Decoder utf8Decode = encoder.GetDecoder();

        byte[] todecode_byte = Convert.FromBase64String(sData);

        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

        char[] decoded_char = new char[charCount];

        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

        string result = new String(decoded_char);

        return result;

    }
    //-------------------------------------------------------------
    /// <summary>
    /// For Query string Encryption
    /// </summary>
    /// <param name="strText">Text to encrypt</param>
    /// <returns></returns>
    public string EncryptText(string Text)
    {
        return base64Encode(Text);
    }
    /// <summary>
    /// For QueryString Decryption
    /// </summary>
    /// <param name="strText">Text to decrypt</param>
    /// <returns></returns>
    public string DecryptText(string Text)
    {

        return base64Decode(Text);
        // return decrypt(Text, "&%#@?,:*");
    }

    /// <summary>
    /// For Text Encryption
    /// </summary>
    /// <param name="Text">Text To Encrypt</param>
    /// <param name="Key">Key Used For Encryption</param>
    /// <returns>Returns Encrypted String</returns>
    public string encrypt(string Text, byte[] Key)
    {
        byte[] KEY_64 = null;
        KEY_64 = Key;
        byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        if (Text != string.Empty)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(Text);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        }
        else
        {
            return "";

        }
    }

    /// <summary>
    ///  For Text Decryption
    /// </summary>
    /// <param name="Text">Text To Decrypt</param>
    /// <param name="Key">Key Used For Decryption</param>
    /// <returns>Returns Decrypted String</returns>
    public string decrypt(string Text, string Key)
    {
        byte[] KEY_64 = Convert.FromBase64String(Key);
        byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };

        if (Text != string.Empty)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            byte[] buffer = Convert.FromBase64String(Text);
            MemoryStream ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        else
        {
            return "";
        }
    }
    public byte[] CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return buff;
    }

    public void RetMailSettings(Int32 InstID, ref SqlDataReader reader)
    {
        //SmtpClient smtpClient = new SmtpClient();
        //MailMessage mailMsg = new MailMessage();
        SqlCommand com = null;
        try
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", "S");
                com.Parameters.AddWithValue("InstID", InstID);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Proxy_Dtls";
                reader = com.ExecuteReader();

                //if (reader.Read())
                //{
                //    AdminEmail = reader["ProxyUser"].ToString();
                //    AdminEMailPWD = decrypt(reader["ProxyPwd"].ToString(), reader["Salt"].ToString());
                //    host = reader["ProxyAddress"].ToString();
                //    //if (host != string.Empty)
                //    //{
                //    //    smtpClient.Host = host.Split(':').GetValue(0).ToString();
                //    //    smtpClient.Port = Convert.ToInt32(host.Split(':').GetValue(1).ToString());
                //    //}
                //    reader.Close();
                //}
                con.Close();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            com.Dispose();
        }
    }
    #region Move Items In ListBox

    public void AddRemoveAll(ListBox aSource, ListBox aTarget)
    {
        foreach (ListItem item in aSource.Items)
        {
            aTarget.Items.Add(item);
        }

        aSource.Items.Clear();
    }
    public void AddRemoveItem(ListBox aSource, ListBox aTarget)
    {
        ListItemCollection licCollection = default(ListItemCollection);
        try
        {
            licCollection = new ListItemCollection();
            int intCount = 0;
            while (intCount < aSource.Items.Count)
            {
                if (aSource.Items[intCount].Selected == true)
                {
                    licCollection.Add(aSource.Items[intCount]);
                }
                System.Math.Min(System.Threading.Interlocked.Increment(ref intCount), intCount - 1);
            }
            int intCount1 = 0;
            while (intCount1 < licCollection.Count)
            {
                aSource.Items.Remove(licCollection[intCount1]);
                aTarget.Items.Add(licCollection[intCount1]);
                System.Math.Min(System.Threading.Interlocked.Increment(ref intCount1), intCount1 - 1);
            }
        }
        catch (Exception ex)
        {
            //lblmsg.Visible = true;
            //lblmsg.Text = ex.Message;
        }
        finally
        {
            licCollection = null;
        }
    }
    public void moveup(ListBox LstBox)
    {
        int iIndex = 0;
        int iCount = 0;
        int iOffset = 0;
        int iInsertAt = 0;
        int iIndexSelectedMarker = -1;
        string lItemData = null;
        string lItemval = null;

        iCount = LstBox.Items.Count;
        iIndex = 0;
        iOffset = -1;
        while (iIndex < iCount)
        {
            if (LstBox.SelectedIndex > 0)
            {
                lItemval = LstBox.SelectedItem.Value.ToString();
                lItemData = LstBox.SelectedItem.Text.ToString();
                iIndexSelectedMarker = LstBox.SelectedIndex;
                if (!(-1 == iIndexSelectedMarker))
                {
                    int iIndex2 = 0;
                    while (iIndex2 < iCount)
                    {
                        if (lItemval == LstBox.Items[iIndex2].Value.ToString())
                        {
                            LstBox.Items.RemoveAt(iIndex2);
                            iInsertAt = ((iIndex2 + iOffset) < 0 ? 0 : iIndex2 + iOffset);
                            ListItem li = new ListItem(lItemData, lItemval);
                            LstBox.Items.Insert(iInsertAt, li);
                        }
                        System.Threading.Interlocked.Increment(ref iIndex2);
                    }
                }
            }
            else
            {
                if (-1 == iIndexSelectedMarker)
                {
                    iIndexSelectedMarker = iIndex;
                }
            }
            iIndex = iIndex + 1;
        }
        if (iIndexSelectedMarker == 0)
        {
            LstBox.SelectedIndex = iIndexSelectedMarker;
        }
        else
        {
            LstBox.SelectedIndex = iIndexSelectedMarker - 1;
        }

    }
    public void movedown(ListBox LstBox)
    {

        int iIndex = 0;
        int iCount = 0;
        int iOffset = 0;
        int iInsertAt = 0;
        int iIndexSelectedMarker = -1;
        string lItemData = null;
        string lItemval = null;
        iCount = LstBox.Items.Count;
        iIndex = iCount - 1;
        iOffset = 1;
        while (iIndex >= 0)
        {
            if (LstBox.SelectedIndex >= 0)
            {
                lItemData = LstBox.SelectedItem.Text.ToString();
                lItemval = LstBox.SelectedItem.Value.ToString();
                iIndexSelectedMarker = LstBox.SelectedIndex;
                if (!(-1 == iIndexSelectedMarker))
                {
                    int iIndex2 = 0;
                    while (iIndex2 < iCount - 1)
                    {
                        if (lItemval == LstBox.Items[iIndex2].Value.ToString())
                        {
                            LstBox.Items.RemoveAt(iIndex2);
                            iInsertAt = ((iIndex2 + iOffset) < 0 ? 0 : (iIndex2 + iOffset));
                            ListItem li = new ListItem(lItemData, lItemval);
                            LstBox.Items.Insert(iInsertAt, li);
                            break; // TODO: might not be correct. Was : Exit While
                        }
                        System.Threading.Interlocked.Increment(ref iIndex2);
                    }
                }
            }
            iIndex = iIndex - 1;
        }
        if (iIndexSelectedMarker == LstBox.Items.Count - 1)
        {
            LstBox.SelectedIndex = iIndexSelectedMarker;
        }
        else
        {
            LstBox.SelectedIndex = iIndexSelectedMarker + 1;
        }

    }

    #endregion
}
