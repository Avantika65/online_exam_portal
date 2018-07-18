using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.ComponentModel;
using System.Configuration;
using System.Net.Mail;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSS;
using System.Data;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for EducationService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class EducationService : System.Web.Services.WebService {

    public EducationService () {

        //Uncomment the following line if using designed components 
       // InitializeComponent(); 
    }
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
    #region AutoSuggestMenu
    [WebMethod(EnableSession = true), ScriptMethod]//For Flexible and Dynamic Query
    public string GetDBFlexSuggestions_Direct(string keyword, bool usePaging, int pageIndex, int pageSize, bool useFlexibleQuery, string TableName, string TableTextField, string TableValueField, string TableCondition)
    {

        string distinctvar = string.Empty;

        List<AutoSuggestMenuItem> menuItems;

        SqlConnection cn = new SqlConnection(ReturnConString());
        string sqlFromAndWhere = string.Empty;
        //May need to repeat the following 3 times
        //Instead just save it to variable
        if (TableCondition != string.Empty)
        {
            sqlFromAndWhere = " From " + TableName + " where " + TableTextField + " LIKE '" + keyword.Replace("'", "''").Trim() + "%' and InstituteId='" + Session["InstId"].ToString() + "' and " + TableCondition;
        }
        else
        {
            sqlFromAndWhere = " From " + TableName + " where " + TableTextField + " LIKE '" + keyword.Replace("'", "''").Trim() + "%' and InstituteId='" + Session["InstId"].ToString() + "'";
        }
        string sql;
        if (usePaging)
        {
            //Select only menu items up to specified page
            //In Sql Server use ROW_NUMBER to only get the values for current page
            int numItems = (pageIndex + 1) * pageSize;
            sql = "SELECT distinct TOP " + numItems + " " + TableTextField + ", " + TableValueField +
                        sqlFromAndWhere +
                        " ORDER BY " + TableTextField;
        }
        else
        {
            sql = " SELECT distinct " + TableTextField + ", " + TableValueField + " " + sqlFromAndWhere + " ORDER BY " + TableTextField;
        }


        SqlCommand cmd = new SqlCommand(sql, cn);
        cn.Open();

        //I use datareader because it is usually much faster then dataSet
        //But cached DataSet may also work
        SqlDataReader reader = cmd.ExecuteReader();

        menuItems = GetMenuItemsFromDataReader(reader, usePaging, pageIndex, pageSize);

        reader.Close();


        //When using paging need to get totalResults
        int totalResults = -1;
        if (usePaging && (pageIndex == 0))
        {
            //Only do it when page index is 0
            sql = "SELECT COUNT(*)" +
                        sqlFromAndWhere;

            cmd = new SqlCommand(sql, cn);
            totalResults = (int)cmd.ExecuteScalar();
        }


        cn.Close();
        cmd.Dispose();
        return AutoSuggestMenu.ConvertMenuItemsToJSON(menuItems, totalResults);
    }
    
    private static System.Collections.Generic.List<AutoSuggestMenuItem> GetMenuItemsFromDataReader(SqlDataReader reader, bool usePaging, int pageIndex, int pageSize)
    {
        System.Collections.Generic.List<AutoSuggestMenuItem> menuItems = new System.Collections.Generic.List<AutoSuggestMenuItem>();
        string city = null;
        string cityCode = null;
        string label = null;
        AutoSuggestMenuItem menuItem = default(AutoSuggestMenuItem);
        int rowIndex = 0;
        //Handle paging 
        int startRowIndex = 0;
        int endRowIndex = 0;
        if (usePaging)
        {
            startRowIndex = pageIndex * pageSize;
            endRowIndex = startRowIndex + pageSize;
        }
        while (reader.Read())
        {
            if (usePaging)
            {
                if (rowIndex < startRowIndex)
                {
                    rowIndex = rowIndex + 1;
                    continue;
                    if (rowIndex >= endRowIndex)
                    {
                        break; // TODO: might not be correct. Was : Exit While 
                    }
                }
            }
            city = reader.GetValue(0).ToString();
            cityCode = reader.GetValue(1).ToString();
            label = city;
            menuItem = new AutoSuggestMenuItem();
            menuItem.Label = label;
            menuItem.Value = cityCode;
            menuItems.Add(menuItem);
            rowIndex = rowIndex + 1;
        }
        return menuItems;
    }
    #endregion

}
