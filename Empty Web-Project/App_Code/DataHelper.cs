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
/// Summary description for DataHelper
/// </summary>
namespace Education
{
    public class DataHelper
    {
        public DataHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Methods
        /// <summary>
        /// Gets a boolean value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A boolean value</returns>
        public static bool GetBoolean(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }

        /// <summary>
        /// Gets a byte array of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A byte array</returns>
        public static byte[] GetBytes(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        /// <summary>
        /// Gets a datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetDateTime(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a nullable datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableDateTime(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a decimal value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A decimal value</returns>
        public static decimal GetDecimal(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        /// <summary>
        /// Gets a double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A double value</returns>
        public static double GetDouble(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a GUID value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A GUID value</returns>
        public static Guid GetGuid(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static int GetInt(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (int)rdr[index];
        }

        /// <summary>
        /// Gets a nullable integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable integer value</returns>
        public static int? GetNullableInt(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A string value</returns>
        public static string GetString(SqlDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a boolean value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A boolean value</returns>
        public static bool GetBoolean(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }

        /// <summary>
        /// Gets a byte array of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A byte array</returns>
        public static byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        /// <summary>
        /// Gets a datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a nullable datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a decimal value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A decimal value</returns>
        public static decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        /// <summary>
        /// Gets a double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A double value</returns>
        public static double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a GUID value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A GUID value</returns>
        public static Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            //return (int)rdr[index];
            return Int32.Parse(rdr[index].ToString());
        }

        /// <summary>
        /// Gets a nullable integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable integer value</returns>
        public static int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A string value</returns>
        public static string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index].ToString();
        }
        #endregion
        #region Move Items In ListBox
        public static void AddRemoveAll(ListBox aSource, ListBox aTarget)
        {
            foreach (ListItem item in aSource.Items)
            {
                aTarget.Items.Add(item);
            }

            aSource.Items.Clear();
        }
        public static void AddRemoveItem(ListBox aSource, ListBox aTarget)
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
        public static void moveup(ListBox LstBox)
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
        public static void movedown(ListBox LstBox)
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
}
