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
using NewDAL;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for Invent_Data

/// Inventory DAL Inherited By Inventory 
/// </summary>
public abstract class Invent_Data 
{
     protected NewDAL.DBManager ObjDb = null;
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
    protected NewDAL.DBManager ReturnDALConString()
    {
        ObjDb = new DBManager();
        ObjDb.ConnectionString = ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        //NewDAL.DBManager objDB = new NewDAL.DBManager(DataAccessLayer.DataProvider.SqlServer, ReturnConString());
        ObjDb.DBManager(DataAccessLayer.DataProvider.SqlServer, ObjDb.ConnectionString);
        ObjDb.Open();
        return ObjDb;
    }   
	public Invent_Data()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region Country Master
    public void CountrySave(String flag, Int32 CountryID, String CountryName, String UName, DateTime UEntDt, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
           
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("CountryId", CountryID);
                com.Parameters.AddWithValue("CountryName", CountryName);
                com.Parameters.AddWithValue("UName", UName);
                com.Parameters.AddWithValue("UEntDt", UEntDt);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_Country";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();
        }
    }
    public void CountryGrdFill(String Query, ref DataTable dt, DBManager ObjDAL)
    {
        dt = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    //-------------Fill Country Grid----------------------------------
    protected void CountryGrdFill_(String flag, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(1);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Country");
    }
    //----------------------------------------------------------------
    public void CountryDelete(String flag, Int32 CountrtyID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        { 
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("CountryID", CountrtyID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Country";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void CountrySelect(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Country");
    }
    #endregion

    #region City Master
    public void CitySave(String flag, Int32 CityId, String CityName, Int32 StateId, String UName, DateTime UEntDt, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("CityId", CityId);
            com.Parameters.AddWithValue("CityName", CityName);
            com.Parameters.AddWithValue("StateId", StateId);
            com.Parameters.AddWithValue("UName", UName);
            com.Parameters.AddWithValue("UEntDt", UEntDt);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_City";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void CityDelete_(String flag, Int32 cityid, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("CityId", cityid);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_City";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void CityGrdFill(String Query, ref DataTable dtCity, DBManager ObjDAL)
    {
        dtCity = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    //-----------------Fill City Grid---------------------
    protected void CityGrdFill_(String flag, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(1);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_City");
    }
    //----------------------------------------------------
    public void CitySelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_City");
    }
    #endregion

    #region StateMaster
    public void StateSave_(String flag, Int32 StateId, Int32 CountryID, String StateName, String UName, DateTime UEntDt, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("StateId", StateId);
            com.Parameters.AddWithValue("CountryId", CountryID);
            com.Parameters.AddWithValue("StateName", StateName);
            com.Parameters.AddWithValue("UName", UName);
            com.Parameters.AddWithValue("UEntDt", UEntDt);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_State";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void StateDelete_(String flag, Int32 stateID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("StateID", stateID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_State";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void StateGrdFill_(String Query, ref DataTable dtState, DBManager ObjDAL)
    {
        dtState = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    //-----------Fill State Grid--------------------------------------
    protected void StateGrdFill_(String flag, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(1);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_State");
    }
    //----------------------------------------------------------------
    public void StateSelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_State");
    }
    #endregion

    #region Product Type Master
    public void ProdTypeSave_(String flag, Int32 ID, String Name, String Short_Name, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Name", Name);
            com.Parameters.AddWithValue("Short_Name", Short_Name);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Product_Type";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdTypeDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
          
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Product_Type";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdTypeGrdFill_(String Query, ref DataTable dtType, DBManager ObjDAL)
    {
        dtType = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    public void ProdTypeSelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Product_Type");
    }
    #endregion

    #region Product Category Master
    public void ProdCatSave_(String flag, Int32 ID, Int32 Prod_Type, String Name, String Short_Name, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Prod_Type", Prod_Type);
            com.Parameters.AddWithValue("Name", Name);
            com.Parameters.AddWithValue("Short_Name", Short_Name);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Product_CAT";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdCatDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Product_CAT";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdCatGrdFill_(String Condition, ref DataTable dtProdCat, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", "FG", DbType.String);        
        ObjDAL.AddParameters(1, "where", Condition, DbType.String);
        dtProdCat = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Product_CAT");
        
    }
    public void ProdCatSelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Product_CAT");
    }
    #endregion

    #region Product Composition Master
    public void ProdCompSave_(String flag, Int32 ID, Int32 Prod_Type, Int32 Prod_Cat, String Composition, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Prod_Type", Prod_Type);
            com.Parameters.AddWithValue("Prod_Cat", Prod_Cat);
            com.Parameters.AddWithValue("Composition", Composition);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prod_Composition";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdComDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prod_Composition";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void IssueLimitDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_IssueLimit";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdCompGrdFill_(String Condition, ref DataTable dtProdComp, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", "FG", DbType.String);
        ObjDAL.AddParameters(1, "Where", Condition, DbType.String);
        dtProdComp = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Prod_Composition");
    }
    public void ProdCompSelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Prod_Composition");
    }
    #endregion

    #region Warehouse Master
    public void WarehouseSave_(String flag, Int32 ID, String Name, String Short_Name, String Address, String BuildingName, String BuildShName, Int32 InstId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Name", Name);
            com.Parameters.AddWithValue("Short_Name", Short_Name);
            com.Parameters.AddWithValue("Address", Address);
            com.Parameters.AddWithValue("BuildingName", BuildingName);
            com.Parameters.AddWithValue("BuildShName", BuildShName);
            com.Parameters.AddWithValue("InstId", InstId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Warehouse";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void WarehouseDelete_(Int32 ID, Int32 InstId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "D");
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Warehouse";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void WarehouseSelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Warehouse");
        ObjDAL.Command.Parameters.Clear();
    }
    public void WarehouseGrdFill_(String Query, ref DataTable dtWarehouse, DBManager ObjDAL)
    {
        dtWarehouse = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    //---------------Fill Warehouse Grid---------------------------
    protected void WarehouseGrdFill_(String flag, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Warehouse");
        ObjDAL.Command.Parameters.Clear();
    }
    //-------------------------------------------------------------
    #endregion

    #region Store Location Master
    public void StoreLocSave_(String flag, Int32 ID, String Build_S_Name, String Floor, String Room_No, String Almirah_No, Int32 InstID, Int32 WarehouseID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Build_S_Name", Build_S_Name);
            com.Parameters.AddWithValue("Floor", Floor);
            com.Parameters.AddWithValue("Room_No", Room_No);
            com.Parameters.AddWithValue("Almirah_No", Almirah_No);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("WarehouseID", WarehouseID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Store_Loc";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void StoreLocDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Store_Loc";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void StoreLocGrdFill_(String Flag, Int32 InstID, ref DataTable dtStoreLoc, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", Flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        dtStoreLoc = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Store_Loc");
        ObjDAL.Command.Parameters.Clear();
    }
    public void StoreLocSelect_(String flag, Int32 ID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "ID", ID, DbType.String);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Store_Loc");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region Currency Master
    public void CurrencySave_(String flag, Int32 InstID, Int32 CurrencyCode, String CurrencyName, String ShortName, Decimal GocRate, Decimal BankRate, DateTime EffectiveDate, Boolean SetDefault, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("CurrencyCode", CurrencyCode);
            com.Parameters.AddWithValue("CurrencyName", CurrencyName);
            com.Parameters.AddWithValue("ShortName", ShortName);
            com.Parameters.AddWithValue("GocRate", GocRate);
            com.Parameters.AddWithValue("BankRate", BankRate);
            com.Parameters.AddWithValue("EffectiveDate", EffectiveDate);
            com.Parameters.AddWithValue("SetDefault", SetDefault);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_CurrencyMaster";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();   
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void CurrencyDelete_(String flag, Int32 currencycode, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("currencycode", currencycode);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_CurrencyMaster";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();        
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //--------------Select Currency Details---------------------
    protected void Select_Currency_(String flag, Int32 InstId, Int32 CurncyID, ref DBManager ObjDal)
    {
        ObjDal.CreateParameters(3);
        ObjDal.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDal.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDal.AddParameters(2, "CurrencyCode", CurncyID, DbType.Int32, ParameterDirection.Input);
        ObjDal.DataReader = ObjDal.ExecuteReader(CommandType.StoredProcedure, "SUID_CurrencyMaster");
    }
    //----------------------------------------------------------
    #endregion

    #region Tax Master
    public void TaxSave_(String flag, Int32 ID, Decimal VAT, Decimal SAT, Boolean IS_VAT, Boolean IS_SAT, DateTime Start_Date, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("VAT", VAT);
            com.Parameters.AddWithValue("SAT", SAT);
            com.Parameters.AddWithValue("IS_VAT", IS_VAT);
            com.Parameters.AddWithValue("IS_SAT", IS_SAT);
            com.Parameters.AddWithValue("Start_Date", Start_Date);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Tax_MST";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();          
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void TaxDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Tax_MST";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //-------------Fill Tax master Grid----------------------------------
    protected void TaxGrdFill_(String flag, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Tax_MST");
    }
    //----------------------------------------------------------------
    #endregion

    #region Supplier Master Vendor, Manufacturer and Company
    public void VendorSave_(String flag, Int32 id_vendor, String vendor_code, String vendor_name, String house_no, String mailingAdd, String city, String state, String pincode, String country, String contact_no, String fax, String email, String web_address, Int32 InstId, String SessionID, String UserID, DateTime UEDate, String Notes, byte[] image, String AddRelation, String country_mailing, String state_mailing, String city_mailing, String pincode_mailing, String PAN_No, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("id_vendor", id_vendor);
            com.Parameters.AddWithValue("vendor_code", vendor_code);
            com.Parameters.AddWithValue("vendor_name", vendor_name);
            com.Parameters.AddWithValue("house_no", house_no);
            com.Parameters.AddWithValue("mailingAdd", mailingAdd);
            com.Parameters.AddWithValue("city", city);
            com.Parameters.AddWithValue("state", state);
            com.Parameters.AddWithValue("pincode", pincode);
            com.Parameters.AddWithValue("country", country);
            com.Parameters.AddWithValue("contact_no", contact_no);
            com.Parameters.AddWithValue("fax", fax);
            com.Parameters.AddWithValue("email", email);
            com.Parameters.AddWithValue("web_address", web_address);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("UEDate", UEDate);
            com.Parameters.AddWithValue("Notes", Notes);
            com.Parameters.AddWithValue("ImageRel", image);
            com.Parameters.AddWithValue("AddRelation", AddRelation);
            com.Parameters.AddWithValue("Country_Mailing", country_mailing);
            com.Parameters.AddWithValue("State_Mailing", state_mailing);
            com.Parameters.AddWithValue("City_Mailing", city_mailing);
            com.Parameters.AddWithValue("Pincode_Mailing", pincode_mailing);
            com.Parameters.AddWithValue("PAN_No", PAN_No);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Vendors";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void VendorDelete_(String flag, Int32 InstID, Int32 id_vendor, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstID);
            com.Parameters.AddWithValue("id_vendor", id_vendor);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Vendors";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    protected void Select_Supplr_(String flag, Int32 InstId, Int32 SupplrID, ref DBManager ObjDal)
    {
        ObjDal.CreateParameters(3);
        ObjDal.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDal.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDal.AddParameters(2, "id_vendor", SupplrID, DbType.Int32, ParameterDirection.Input);
        ObjDal.DataReader = ObjDal.ExecuteReader(CommandType.StoredProcedure, "SUID_Vendors");
    }
    #endregion
    #region Supplier Master Vendor
    public int retDeptId(string uid)
    {
         SqlCommand com = null;
         using (SqlConnection con = new SqlConnection(ReturnConString()))
         {
             com = new SqlCommand("select deptid from iemployeeusers_vw where userid=" + uid);
             con.Open();
             com.Connection = con;
             object retdid = com.ExecuteScalar();
             int rval = retdid != null ? int.Parse(retdid.ToString()) : 0;
             return rval;
         }
    }
    #endregion
    #region Product Manager
    public void ProdSave_(String flag, Int32 ID, String Prod_Code, String Prod_Name, String Short_Name, Int32 Prod_Type, Int32 Prod_Cat, Int32 Composition, Decimal List_Price, Decimal Cost_Price, Int32 Stock_Bal, String Prod_Desc, String Pur_Ord_Desc, Decimal Tax_Invoice, Decimal Tax_Pur_Ord, Boolean Non_Stock, Int32 Store_Loc, Int32 Sales_Pr_Opt, Decimal Sales_Pr_Val, Decimal Min_Qty, Decimal Max_Qty, Decimal Target_Qty, Boolean Is_Vat, Boolean Is_Sat, Int32 Unit_Id, Boolean Is_Batch, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Prod_Code", Prod_Code);
            com.Parameters.AddWithValue("Prod_Name", Prod_Name);
            com.Parameters.AddWithValue("Short_Name", Short_Name);
            com.Parameters.AddWithValue("Prod_Type", Prod_Type);
            com.Parameters.AddWithValue("Prod_Cat", Prod_Cat);
            com.Parameters.AddWithValue("Composition", Composition);
            com.Parameters.AddWithValue("List_Price", List_Price);
            com.Parameters.AddWithValue("Cost_Price", Cost_Price);
            com.Parameters.AddWithValue("Stock_Bal", Stock_Bal);
            com.Parameters.AddWithValue("Prod_Desc", Prod_Desc);
            com.Parameters.AddWithValue("Pur_Ord_Desc", Pur_Ord_Desc);
            com.Parameters.AddWithValue("Tax_Invoice", Tax_Invoice);
            com.Parameters.AddWithValue("Tax_Pur_Ord", Tax_Pur_Ord);
            com.Parameters.AddWithValue("Non_Stock", Non_Stock);
            com.Parameters.AddWithValue("Store_Loc", Store_Loc);
            com.Parameters.AddWithValue("Sales_Pr_Opt", Sales_Pr_Opt);
            com.Parameters.AddWithValue("Sales_Pr_Val", Sales_Pr_Val);
            com.Parameters.AddWithValue("Min_Qty", Min_Qty);
            com.Parameters.AddWithValue("Max_Qty", Max_Qty);
            com.Parameters.AddWithValue("Target_Qty", Target_Qty);
            com.Parameters.AddWithValue("Is_Vat", Is_Vat);
            com.Parameters.AddWithValue("Is_Sat", Is_Sat);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.Parameters.AddWithValue("Is_Batch", Is_Batch);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prod_Name";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdSave_(String flag, Int32 ID, String Prod_Code, String Prod_Name, String Short_Name, Int32 Prod_Type, Int32 Prod_Cat, Int32 Composition, Decimal List_Price, Decimal Cost_Price, Int32 Stock_Bal, String Prod_Desc, String Pur_Ord_Desc, Decimal Tax_Invoice, Decimal Tax_Pur_Ord, Boolean Non_Stock, Int32 Store_Loc, Int32 Sales_Pr_Opt, Decimal Sales_Pr_Val, Decimal Min_Qty, Decimal Max_Qty, Decimal Target_Qty, Boolean Is_Vat, Boolean Is_Sat, Int32 Unit_Id, Boolean Is_Batch, Boolean Is_Barcode, String StorageLoc, Int32 InstID, Int32 CtrlIDUP, String Weight, Int32 Medi_id, ref int Ctrl_Id, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Fields", null);
        com.Parameters.AddWithValue("where", null);
        com.Parameters.AddWithValue("ID", ID);
        com.Parameters.AddWithValue("Prod_Code", Prod_Code);
        com.Parameters.AddWithValue("Prod_Name", Prod_Name);
        com.Parameters.AddWithValue("Short_Name", Short_Name);
        com.Parameters.AddWithValue("Prod_Type", Prod_Type);
        com.Parameters.AddWithValue("Prod_Cat", Prod_Cat);
        com.Parameters.AddWithValue("Composition", Composition);
        com.Parameters.AddWithValue("List_Price", List_Price);
        com.Parameters.AddWithValue("Cost_Price", Cost_Price);
        com.Parameters.AddWithValue("Stock_Bal", Stock_Bal);
        com.Parameters.AddWithValue("Prod_Desc", Prod_Desc);
        com.Parameters.AddWithValue("Pur_Ord_Desc", Pur_Ord_Desc);
        com.Parameters.AddWithValue("Tax_Invoice", Tax_Invoice);
        com.Parameters.AddWithValue("Tax_Pur_Ord", Tax_Pur_Ord);
        com.Parameters.AddWithValue("Non_Stock", Non_Stock);
        com.Parameters.AddWithValue("Store_Loc", Store_Loc);
        com.Parameters.AddWithValue("Sales_Pr_Opt", Sales_Pr_Opt);
        com.Parameters.AddWithValue("Sales_Pr_Val", Sales_Pr_Val);
        com.Parameters.AddWithValue("Min_Qty", Min_Qty);
        com.Parameters.AddWithValue("Max_Qty", Max_Qty);
        com.Parameters.AddWithValue("Target_Qty", Target_Qty);
        com.Parameters.AddWithValue("Is_Vat", Is_Vat);
        com.Parameters.AddWithValue("Is_Sat", Is_Sat);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Is_Batch", Is_Batch);
        com.Parameters.AddWithValue("CtrlIDUP", CtrlIDUP);
        com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Is_Barcode", Is_Barcode);
        com.Parameters.AddWithValue("StorageLoc", StorageLoc);
        com.Parameters.AddWithValue("Weight", Weight);
        com.Parameters.AddWithValue("Medi_id", Medi_id);       
        com.Parameters.AddWithValue("InstID", InstID);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Prod_Name";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        Ctrl_Id = Int32.Parse(com.Parameters["Ctrl_Id"].Value.ToString());
        com.Parameters.Clear();
    }
    //--------------------------------------------------------------------------------------
    public void ProdSave_(String flag, Int32 ID, String Prod_Code, String Prod_Name, String Short_Name, Int32 Prod_Type, Int32 Prod_Cat, Int32 Composition, Decimal List_Price, Decimal Cost_Price, Int32 Stock_Bal, String Prod_Desc, String Pur_Ord_Desc, Decimal Tax_Invoice, Decimal Tax_Pur_Ord, Boolean Non_Stock, Int32 Store_Loc, Int32 Sales_Pr_Opt, Decimal Sales_Pr_Val, Decimal Min_Qty, Decimal Max_Qty, Decimal Target_Qty, Boolean Is_Vat, Boolean Is_Sat, Int32 Unit_Id, Boolean Is_Batch, Boolean Is_Barcode, String StorageLoc, Int32 InstID, Int32 CtrlIDUP, String Weight, Int32 Medi_id, Boolean IsNonConsumable, ref int Ctrl_Id, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Fields", null);
        com.Parameters.AddWithValue("where", null);
        com.Parameters.AddWithValue("ID", ID);
        com.Parameters.AddWithValue("Prod_Code", Prod_Code);
        com.Parameters.AddWithValue("Prod_Name", Prod_Name);
        com.Parameters.AddWithValue("Short_Name", Short_Name);
        com.Parameters.AddWithValue("Prod_Type", Prod_Type);
        com.Parameters.AddWithValue("Prod_Cat", Prod_Cat);
        com.Parameters.AddWithValue("Composition", Composition);
        com.Parameters.AddWithValue("List_Price", List_Price);
        com.Parameters.AddWithValue("Cost_Price", Cost_Price);
        com.Parameters.AddWithValue("Stock_Bal", Stock_Bal);
        com.Parameters.AddWithValue("Prod_Desc", Prod_Desc);
        com.Parameters.AddWithValue("Pur_Ord_Desc", Pur_Ord_Desc);
        com.Parameters.AddWithValue("Tax_Invoice", Tax_Invoice);
        com.Parameters.AddWithValue("Tax_Pur_Ord", Tax_Pur_Ord);
        com.Parameters.AddWithValue("Non_Stock", Non_Stock);
        com.Parameters.AddWithValue("Store_Loc", Store_Loc);
        com.Parameters.AddWithValue("Sales_Pr_Opt", Sales_Pr_Opt);
        com.Parameters.AddWithValue("Sales_Pr_Val", Sales_Pr_Val);
        com.Parameters.AddWithValue("Min_Qty", Min_Qty);
        com.Parameters.AddWithValue("Max_Qty", Max_Qty);
        com.Parameters.AddWithValue("Target_Qty", Target_Qty);
        com.Parameters.AddWithValue("Is_Vat", Is_Vat);
        com.Parameters.AddWithValue("Is_Sat", Is_Sat);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Is_Batch", Is_Batch);
        com.Parameters.AddWithValue("CtrlIDUP", CtrlIDUP);
        com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Is_Barcode", Is_Barcode);
        com.Parameters.AddWithValue("StorageLoc", StorageLoc);
        com.Parameters.AddWithValue("Weight", Weight);
        com.Parameters.AddWithValue("Medi_id", Medi_id);
        com.Parameters.AddWithValue("IsNonConsumable", IsNonConsumable);
        com.Parameters.AddWithValue("InstID", InstID);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Prod_Name";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        Ctrl_Id = Int32.Parse(com.Parameters["Ctrl_Id"].Value.ToString());
        com.Parameters.Clear();
    }
    //--------------------------------------------------------------------------------------
    public void ProdDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("Ctrl_Id", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prod_Name";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdNameSelect_(Int32 Ctrl_Id, Int32 InstID, ref DBManager Objdal)
    {
        Objdal.CreateParameters(3);
        Objdal.AddParameters(0, "flag", "S", DbType.String);
        Objdal.AddParameters(1, "Ctrl_Id", Ctrl_Id, DbType.Int32);
        Objdal.AddParameters(2, "InstID", InstID, DbType.Int32);
        Objdal.DataReader = Objdal.ExecuteReader(CommandType.StoredProcedure, "SP_Prod_Name");
        Objdal.Command.Parameters.Clear();
    }
    public void ProdNameUpdate_(String flag, Decimal Max_Qty, Decimal Min_Qty, Decimal Target_Qty, Int32 UnitID, Int32 Ctrl_Id, Int32 Store_Loc, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("Max_Qty", Max_Qty);
            com.Parameters.AddWithValue("Min_Qty", Min_Qty);
            com.Parameters.AddWithValue("Target_Qty", Target_Qty);
            com.Parameters.AddWithValue("Unit_Id", UnitID);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Store_Loc", Store_Loc);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prod_Name";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ProdNameQtySelect_(String flag, Int32 Ctrl_Id, Int32 Store_Loc, Int32 InstID, ref DBManager ObjDal)
    {
        ObjDal.CreateParameters(4);
        ObjDal.AddParameters(0, "flag", flag, DbType.String);
        ObjDal.AddParameters(1, "Ctrl_Id", Ctrl_Id, DbType.Int32);
        ObjDal.AddParameters(2, "Store_Loc", Store_Loc, DbType.Int32);
        ObjDal.AddParameters(3, "InstID", InstID, DbType.Int32);
        ObjDal.DataReader = ObjDal.ExecuteReader(CommandType.StoredProcedure, "SP_Prod_Name");
        ObjDal.Command.Parameters.Clear();
    }
    //-------------Get Storage Location for a particular product--------------
    protected void Get_ProdLoc_(Int32 Ctrl_Id, Int32 InstID, ref DataTable dtLoc)
    {
         SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "V");
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prod_Name";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtLoc);       
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Unit of Measurement
    public void UnitSave_(String flag, Int32 InstId, Int32 Id, String UOM_Name, String Short_Name, Int32 Primary_Unit, Decimal ConvrsionFactor, Int32 DecimalPlaces, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("UOM_Name", UOM_Name);
            com.Parameters.AddWithValue("Short_Name", Short_Name);
            com.Parameters.AddWithValue("Primary_Unit", Primary_Unit);
            com.Parameters.AddWithValue("ConvrsionFactor", ConvrsionFactor);
            com.Parameters.AddWithValue("DecimalPlaces", DecimalPlaces);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_UOM_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void UnitDelete_(Int32 InstId, Int32 Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "D");
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_UOM_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void UnitValidate_(Int32 InstId, Int32 Id, Int32 Primary_Unit, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "V");
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Primary_Unit", Primary_Unit);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_UOM_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void QtyConversion_(Int32 InstId, Int32 FromUnit, Int32 ToUnit, ref string Qty)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "Q");
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("FromUnit", FromUnit);
            com.Parameters.AddWithValue("ToUnit", ToUnit);
            com.Parameters.AddWithValue("Qty", Qty);//.Direction = ParameterDirection.Output;
            com.Parameters["Qty"].Size = 1000;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_UOM_Mst";
            Qty = com.ExecuteScalar().ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region For Budget
    public void BudgetSave_(String flag, Int32 InstId, Int32 Budget_Id, String Budget_name, Int32 Ledger_Id, DateTime Applied_date, Decimal Applied_Amt, String Applied_Doc_Name, String Applied_Doc_Id, String Budget_For, Int32 Budget_For_Id, String Session, Boolean IsScheduled, Int32 User_id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Budget_Id", Budget_Id);
            com.Parameters.AddWithValue("Budget_name", Budget_name);
            com.Parameters.AddWithValue("Ledger_Id", Ledger_Id);
            com.Parameters.AddWithValue("Applied_date", Applied_date);
            com.Parameters.AddWithValue("Applied_Amt", Applied_Amt);
            com.Parameters.AddWithValue("Applied_Doc_Name", Applied_Doc_Name);
            com.Parameters.AddWithValue("Applied_Doc_Id", Applied_Doc_Id);
            com.Parameters.AddWithValue("Budget_For", Budget_For);
            com.Parameters.AddWithValue("Budget_For_Id", Budget_For_Id);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("IsScheduled", IsScheduled);
            com.Parameters.AddWithValue("User_id", User_id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Budget";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void BudgetDelete_(string flag, int InstId, int Budget_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Budget_Id", Budget_Id);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Budget";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString(); 
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void BudgetAllocaSave_(String flag, Int32 InstId, Int32 Budget_Id, Int32 Ledger_Id, Decimal Allocated_Amt, Int32 Budget_For_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Budget_Id", Budget_Id);
            com.Parameters.AddWithValue("Ledger_Id", Ledger_Id);
            com.Parameters.AddWithValue("Allocated_Amt", Allocated_Amt);
            com.Parameters.AddWithValue("Budget_For_Id", Budget_For_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Budget";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void BudgetSanctionSave_(String flag, Int32 InstId, Int32 Budget_Id, Int32 Ledger_Id, String Sanction_Number, DateTime Sanction_Date, Decimal Sanction_Amt, Int32 Fund_Source_Id, String Sanctioned_Doc_Name, String Sanctioned_Doc_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Budget_Id", Budget_Id);
            com.Parameters.AddWithValue("Ledger_Id", Ledger_Id);
            com.Parameters.AddWithValue("Sanction_Number", Sanction_Number);
            com.Parameters.AddWithValue("Sanction_Date", Sanction_Date);
            com.Parameters.AddWithValue("Sanction_Amt", Sanction_Amt);
            com.Parameters.AddWithValue("Fund_Source_Id", Fund_Source_Id);
            com.Parameters.AddWithValue("Sanctioned_Doc_Name", Sanctioned_Doc_Name);
            com.Parameters.AddWithValue("Sanctioned_Doc_Id", Sanctioned_Doc_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Budget";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close(); 
            con.Dispose();
        }
    }
    public void BudgetReleaseSave_(String flag, Int32 InstId, Int32 Release_Id, Int32 Budget_Id, String Doc_No, DateTime Doc_Date, Decimal Release_Amt, String Release_Mode, String Cheq_DD_No, String Cheq_DD_Date, String Bank, String Deposited_In, Int32 UserId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Release_Id", Release_Id);
            com.Parameters.AddWithValue("Budget_Id", Budget_Id);
            com.Parameters.AddWithValue("Doc_No", Doc_No);
            com.Parameters.AddWithValue("Doc_Date", Doc_Date);
            com.Parameters.AddWithValue("Release_Amt", Release_Amt);
            com.Parameters.AddWithValue("Release_Mode", Release_Mode);
            com.Parameters.AddWithValue("Cheq_DD_No", Cheq_DD_No);
            com.Parameters.AddWithValue("Cheq_DD_Date", Cheq_DD_Date);
            com.Parameters.AddWithValue("Bank", Bank);
            com.Parameters.AddWithValue("Deposited_In", Deposited_In);
            com.Parameters.AddWithValue("UserId", UserId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Budget_Release";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString(); 
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void DeptBudgetReleaseSave_(String flag, Int32 InstId, Int32 Id, Int32 DeptId, String Doc_No, Decimal Release_Amt, DateTime Release_Date, String Release_Mode, String Cheq_DD_No, String Cheq_DD_Date, String Bank, String Deposited_In, Int32 UserId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("DeptId", DeptId);
            com.Parameters.AddWithValue("Doc_No", Doc_No);
            com.Parameters.AddWithValue("Release_Amt", Release_Amt);
            com.Parameters.AddWithValue("Release_Date", Release_Date);
            com.Parameters.AddWithValue("Release_Mode", Release_Mode);
            com.Parameters.AddWithValue("Cheq_DD_No", Cheq_DD_No);
            com.Parameters.AddWithValue("Cheq_DD_Date", Cheq_DD_Date);
            com.Parameters.AddWithValue("Bank", Bank);
            com.Parameters.AddWithValue("Deposited_In", Deposited_In);
            com.Parameters.AddWithValue("UserId", UserId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Dept_Budget";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void DeptBudgetDelete_(int InstId, int Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "D");
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Dept_Budget";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Client Management
    public void ClientRegSave_(String flag, Int32 InstId, Int32 Id, String Client_Id, String first_name, String middle_name, String last_name, String Bill_house_no, String Bill_city, String Bill_state, String Bill_pincode, String Bill_country, String Ship_house_no, String Ship_city, String Ship_state, String Ship_pincode, String Ship_country, String phone1, String phone2, String email1, String email2, Int32 department, String Release_No, String Account_No, String Credit_Limit, Decimal Current_Balance, String status, String remarks, byte[] image, Int32 PurchaseGrp, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Client_Id", Client_Id);
            com.Parameters.AddWithValue("first_name", first_name);
            com.Parameters.AddWithValue("middle_name", middle_name);
            com.Parameters.AddWithValue("last_name", last_name);
            com.Parameters.AddWithValue("Bill_house_no", Bill_house_no);
            com.Parameters.AddWithValue("Bill_city", Bill_city);
            com.Parameters.AddWithValue("Bill_state", Bill_state);
            com.Parameters.AddWithValue("Bill_pincode", Bill_pincode);
            com.Parameters.AddWithValue("Bill_country", Bill_country);
            com.Parameters.AddWithValue("Ship_house_no", Ship_house_no);
            com.Parameters.AddWithValue("Ship_city", Ship_city);
            com.Parameters.AddWithValue("Ship_state", Ship_state);
            com.Parameters.AddWithValue("Ship_pincode", Ship_pincode);
            com.Parameters.AddWithValue("Ship_country", Ship_country);
            com.Parameters.AddWithValue("phone1", phone1);
            com.Parameters.AddWithValue("phone2", phone2);
            com.Parameters.AddWithValue("email1", email1);
            com.Parameters.AddWithValue("email2", email2);
            com.Parameters.AddWithValue("department", department);
            com.Parameters.AddWithValue("Release_No", Release_No);
            com.Parameters.AddWithValue("Account_No", Account_No);
            com.Parameters.AddWithValue("Credit_Limit", Credit_Limit);
            com.Parameters.AddWithValue("Current_Balance", Current_Balance);
            com.Parameters.AddWithValue("status", status);
            com.Parameters.AddWithValue("remarks", remarks);
            com.Parameters.AddWithValue("image", image);
            com.Parameters.AddWithValue("PurchaseGrp", PurchaseGrp);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Client_Regs";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void UpdateClientID_(String flag, int InstId, String Old_Client_Id, String New_Client_Id, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", InstId);
            com.Parameters.AddWithValue("Old_Client_Id", Old_Client_Id);
            com.Parameters.AddWithValue("New_Client_Id", New_Client_Id);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Update_ClientId";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //-----------------Select Client Detail--------------------
    protected void ClientRegs_Select_(String flag,Int32 InstId,Int32 Id, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32);
        ObjDAL.AddParameters(2, "Id", Id, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Client_Regs");
    }
    //-----------------Select Client for Id Updation--------------------
    protected void ClientId_Srch_(String flag, Int32 InstId, String Client_Id, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32);
        ObjDAL.AddParameters(2, "Client_Id", Client_Id, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Client_Regs");
    }
    //----------------------------------------------------
    #endregion

    #region Indent Management
    public void GenIndentCODE_(int InstId, ref string IndentCode)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "IndentCode");
            com.Parameters.AddWithValue("IndentCode", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_IndentCode";
            IndentCode = com.ExecuteScalar().ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ScrapDeptSave_(string flag, int InstId, int ID, DateTime EntryDate, string ScrapCode, int Ctrl_Id, Decimal Qty, Int32 UserId, Int32 DeptId, Int32 Unit_Id, string Remark, string Status1, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("EntryDate", EntryDate);
            com.Parameters.AddWithValue("ScrapCode", ScrapCode);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("UserId", UserId);
            com.Parameters.AddWithValue("DeptId", DeptId);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.Parameters.AddWithValue("Remark", Remark);
            com.Parameters.AddWithValue("Status1", Status1);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_ScrapMaterial";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void ScrapDeptDelete_(String flag, Int32 ID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_ScrapMaterial";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void IssueLimitSave_(string flag, int InstId, int ID, DateTime EntryDate, DateTime ToDate, int Ctrl_Id, Decimal Limit_Qty, Int32 UserId, Int32 DeptId, Int32 Unit_Id, string Remark, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("EntryDate", EntryDate);
            com.Parameters.AddWithValue("ToDate", ToDate);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Limit_Qty", Limit_Qty);
            com.Parameters.AddWithValue("UserId", UserId);
            com.Parameters.AddWithValue("DeptId", DeptId);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);           
            com.Parameters.AddWithValue("Remark", Remark);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_IssueLimit";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void IndentSave_(string flag, int InstId, int ID, int IndentId, String Indent_Code, int Ctrl_Id, Decimal Qty, String Warehouse, DateTime ExpectedDate, Int32 UserID, Int32 Dept, Int32 Unit_Id, string SessionID, Int32 Site_Mst_Id, string purpose, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("IndentId", IndentId);
            com.Parameters.AddWithValue("Indent_Code", Indent_Code);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Warehouse", Warehouse);
            com.Parameters.AddWithValue("ExpectedDate", ExpectedDate);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("Dept", Dept);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("Site_Mst_Id", Site_Mst_Id);
            com.Parameters.AddWithValue("purpose", purpose);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void IndentUpdate_(int InstId, int ID, Decimal Qty, Int32 Unit_Id, Boolean ApprovalStatus, String IndentStatus, String Indent_Transfer, String IndentNote, String Req_Note, String Warehouse, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "A");
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.Parameters.AddWithValue("ApprovalStatus", ApprovalStatus);
            com.Parameters.AddWithValue("IndentStatus", IndentStatus);
            com.Parameters.AddWithValue("Indent_Transfer", Indent_Transfer);
            com.Parameters.AddWithValue("IndentNote", IndentNote);
            com.Parameters.AddWithValue("Req_Note", Req_Note);
            com.Parameters.AddWithValue("Warehouse", Warehouse);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void IndentFillLOC_(int InstId, int Ctrl_Id, GridView GrdLoc)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "L");
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                GrdLoc.DataSource = dr;
                GrdLoc.DataBind();
            }
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    #endregion

    #region Purchase Requisition
    public void PurchaseReqSave_(string flag, Int32 ID, Int32 IndentID, String PRNo, DateTime CurrentDate, Int32 UID, String Session, Int32 InstID, String IndentType, ref Int32 Ret_ID_, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("IndentID", IndentID);
            com.Parameters.AddWithValue("PRNo", PRNo);
            com.Parameters.AddWithValue("CurrentDate", CurrentDate);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("IndentType", IndentType);
            com.Parameters.AddWithValue("Ret_ID", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_Req";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            Ret_ID_ = Int32.Parse(com.Parameters["Ret_ID"].Value.ToString());            
            com.Dispose();
            con.Close();
            con.Dispose(); 
        }
    }
    public void PurReqChildSave_(String flag_, Int32 PR_Mst_Id, Int32 IndentID, Int32 Ctrl_Id, Decimal Qty, DateTime DeliveryDate, Int32 Requester, Int32 Dept, Int32 Warehouse, Int32 Store, Boolean Is_Approved, Int32 InstID, Int32 ID, String IndentType, Int32 Unit_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag_);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("PR_Mst_Id", PR_Mst_Id);
            com.Parameters.AddWithValue("IndentID", IndentID);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("DeliveryDate", DeliveryDate);
            com.Parameters.AddWithValue("Requester", Requester);
            com.Parameters.AddWithValue("Dept", Dept);
            com.Parameters.AddWithValue("Warehouse", Warehouse);
            com.Parameters.AddWithValue("Store", Store);
            com.Parameters.AddWithValue("Is_Approved", Is_Approved);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("IndentType", IndentType);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_Req_Ch";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void FillProdDetails_(String flag, Int32 IndentID, Int32 InstID, ref DataTable dtProd, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "IndentId", IndentID, DbType.Int32);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        dtProd = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Pur_Req");
    }
    public void FillProdDetails_(String flag, Int32 IndentID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "IndentId", IndentID, DbType.Int32);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Pur_Req");
    }
    public void FetchDtlsIndentID_(String flag, Int32 Ctrl_ID, Int32 IndentID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(4);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "CtrlID", Ctrl_ID, DbType.Int32);
        ObjDAL.AddParameters(2, "IndentID", IndentID, DbType.Int32);
        ObjDAL.AddParameters(3, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Pur_Req");
    }
    #endregion

    #region Request For Quotations
    public void RFQMasterSave_(String flag, Int32 ID, DateTime RFQDate, DateTime RFQDeadline, DateTime DeliveryDate, String RFQNo, DateTime PODeadline, Int32 UID, String Session, String TermsCondition, Int32 InstID, ref Int32 RFQMstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("RFQDate", RFQDate);
            com.Parameters.AddWithValue("RFQDeadline", RFQDeadline);
            com.Parameters.AddWithValue("DeliveryDate", DeliveryDate);
            com.Parameters.AddWithValue("RFQNo", RFQNo);
            com.Parameters.AddWithValue("PODeadline", PODeadline);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("TermsCondition", TermsCondition);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetRFQID", RFQMstID).Direction = ParameterDirection.Output; 
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_RFQ";
            com.ExecuteNonQuery();
            RFQMstID = Int32.Parse(com.Parameters["RetRFQID"].Value.ToString());
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString(); 
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void RFQMasterSave_(String flag, Int32 ID, DateTime RFQDate, DateTime RFQDeadline, DateTime DeliveryDate, String RFQNo, DateTime PODeadline, Int32 UID, String Session, String TermsCondition, Int32 InstID, ref Int32 RFQMstID, ref string RetSuccess, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(15);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
        ObjDAL.AddParameters(2, "fields", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "where", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(4, "ID", ID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(5, "RFQDate", RFQDate, DbType.DateTime, ParameterDirection.Input);
        ObjDAL.AddParameters(6, "RFQDeadline", RFQDeadline, DbType.DateTime, ParameterDirection.Input);
        ObjDAL.AddParameters(7, "DeliveryDate", DeliveryDate, DbType.DateTime, ParameterDirection.Input);
        ObjDAL.AddParameters(8, "RFQNo", RFQNo, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(9, "PODeadline", PODeadline, DbType.DateTime, ParameterDirection.Input);
        ObjDAL.AddParameters(10, "UID", UID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(11, "Session", Session, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(12, "TermsCondition", TermsCondition, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(13, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(14, "RetRFQID", RFQMstID, DbType.Int32, ParameterDirection.Output);
        ObjDAL.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Pur_RFQ");
        RFQMstID = Int32.Parse(((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["RetRFQID"].Value.ToString());
        RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["RetSuccess"].Value.ToString();
        ObjDAL.Command.Parameters.Clear();
     }
    public void RFQChildSave_(String flag, Int32 RFQId, Int32 PRId, Decimal Qty, Int32 SupplierID, Decimal Tax, Decimal Discount, Decimal Price, Decimal Excise_Duty, Decimal Frieght, Decimal Insurance, String PaymentTerms, String DeliveryTerms, String Other, Int32 UID, String Session, Int32 InstID, Int32 Unit_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("RFQId", RFQId);
            com.Parameters.AddWithValue("PRId", PRId);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("SupplierID", SupplierID);
            com.Parameters.AddWithValue("Tax", Tax);
            com.Parameters.AddWithValue("Discount", Discount);
            com.Parameters.AddWithValue("Price", Price);
            com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
            com.Parameters.AddWithValue("Frieght", Frieght);
            com.Parameters.AddWithValue("Insurance", Insurance);
            com.Parameters.AddWithValue("PaymentTerms", PaymentTerms);
            com.Parameters.AddWithValue("DeliveryTerms", DeliveryTerms);
            com.Parameters.AddWithValue("Other", Other);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_RFQ";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
        //---------------------Generating RFQ No-----------------------//
    public void GenRFQNo_(Int32 InstID, String prefixtag, ref string RFQNo)
    {

        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("prefixtag", prefixtag);
            com.Parameters.AddWithValue("RFQNo", RFQNo).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_RFQNo";
            RFQNo = com.ExecuteScalar().ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void GenRFQNo_(Int32 InstID, String prefixtag, ref string RFQNo, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "prefixtag", prefixtag, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "RFQNo", RFQNo, DbType.Int32, ParameterDirection.Output);
        ObjDAL.ExecuteScalar(CommandType.StoredProcedure, "Gen_RFQNo");
        RFQNo = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["RFQNo"].Value.ToString();
        ObjDAL.Command.Parameters.Clear();
    }

    //-------------------------------------------------------------//

    //--------------------Saving RFQ Files--------------------------//
    public void RFQFileSave_(Int32 RFQNo, Int32 SupplierID, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "N");
            com.Parameters.AddWithValue("RFQNo", RFQNo);
            com.Parameters.AddWithValue("SupplierID", SupplierID);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_File_Save";
            com.ExecuteNonQuery();            
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //--------------------------------------------------------------//

    //---------------------RFQ Arrival and Sorting------------------//
    public void RFQSorting_(Int32 RFQId, Int32 SupplierID, Int32 PRId, Decimal Tax, Decimal Price, Decimal Excise_Duty, Decimal Frieght, Decimal Insurance, String PaymentTerms, String DeliveryTerms, String Other, Decimal Discount, DateTime Delivery_Date, String DelMode, Int32 InstID, Decimal CstVat, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "U");
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("RFQId", RFQId);
            com.Parameters.AddWithValue("SupplierID", SupplierID);
            com.Parameters.AddWithValue("PRId", PRId);
            com.Parameters.AddWithValue("Tax", Tax);
            com.Parameters.AddWithValue("Price", Price);
            com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
            com.Parameters.AddWithValue("Frieght", Frieght);
            com.Parameters.AddWithValue("Insurance", Insurance);
            com.Parameters.AddWithValue("PaymentTerms", PaymentTerms);
            com.Parameters.AddWithValue("DeliveryTerms", DeliveryTerms);
            com.Parameters.AddWithValue("Other", Other);
            com.Parameters.AddWithValue("Discount", Discount);
            com.Parameters.AddWithValue("Delivery_Date", Delivery_Date);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("DeliveryMode", DelMode);
            com.Parameters.AddWithValue("CstVat", CstVat);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_RFQ";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void RFQSorting_(Int32 RFQId, Int32 SupplierID, Int32 PRId, String Remark, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "P");
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("RFQId", RFQId);
            com.Parameters.AddWithValue("SupplierID", SupplierID);
            com.Parameters.AddWithValue("PRId", PRId);
            com.Parameters.AddWithValue("Remark", Remark);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_RFQ";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //--------------------------------------------------------------------------
    public void RFQ_Sorting_(String flag, Int32 RFQId, Int32 SupplierID, String Remark, Int32 InstID, ref string RetSuccess, NewDAL.DBManager ObjDb)
    {
        ObjDb.CreateParameters(6);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "RFQId", RFQId, DbType.Int32);
        ObjDb.AddParameters(2, "SupplierID", SupplierID, DbType.Int32);
        ObjDb.AddParameters(3, "Remark", Remark, DbType.String);
        ObjDb.AddParameters(4, "InstId", InstID, DbType.Int32);
        ObjDb.AddParameters(5, "RetSuccess", "0", DbType.String, ParameterDirection.Output);

        //ObjDb.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Pur_RFQ");
        //RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDb.Command).Parameters["@RetSuccess"].Value.ToString();
        //ObjDb.Command.Parameters.Clear();
        SqlDataReader dr = (SqlDataReader)ObjDb.ExecuteReader(CommandType.StoredProcedure, "SP_Pur_RFQ");
        while (dr.Read())
        {
            RetSuccess = dr.GetString(0).ToString();
        }
        dr.Dispose();
        dr.Close();
        ObjDb.Command.Parameters.Clear();
    }

    //--------------------------------------------------------------------------
    public void FillSupplier_(int InstId, int RFQId, int PRID, String SortedBy, String TextField, String ValueField, CheckBoxList ChkSupplier)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("RFQId", RFQId);
            com.Parameters.AddWithValue("PRID", PRID);
            com.Parameters.AddWithValue("SortedBy", SortedBy);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_SortSuppliers";
            SqlDataReader dr = null;
            dr = com.ExecuteReader();
            ChkSupplier.Items.Clear();
            if (dr.HasRows)
            {
                ChkSupplier.DataSource = dr;
                ChkSupplier.DataTextField = TextField;
                ChkSupplier.DataValueField = ValueField;
                ChkSupplier.DataBind();
            }
            com.Dispose();
            con.Close(); 
            con.Dispose();
        }
    }
    //--------------------------------------------------------------//

    //----------------------RFQ BOX---------------------------------//
    public void RFQBox_(ref DataTable dtRFQBox)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "R");
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_RFQ_Box";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtRFQBox);           
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    //--------------------------------------------------------------//

    //---------------------Supplier Details in RFQ Box--------------//
    public void RFQSupplierDetails_(Int32 RFQId, Int32 InstID, ref DataTable DTSuppRFQ)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "S");
            com.Parameters.AddWithValue("RFQId", RFQId);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_RFQ_Mail";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(DTSuppRFQ);           
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    //--------------------------------------------------------------//
    #endregion

    #region Purchase Order
    public void GenPOCode_(int InstId, ref string Order_No)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "POrder");
            com.Parameters.AddWithValue("Order_No", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_POredr_No";
            Order_No = com.ExecuteScalar().ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void PurOrderSave_(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, ref Int32 PId, ref string RetSuccess, Decimal Excise_Duty, String Type_C_V, Decimal CstVat, Int32 SiteID, SqlCommand com)
    {
        //SqlCommand com = null;
        //using (SqlConnection con = new SqlConnection(ReturnConString()))
        //{
        //    com = new SqlCommand();
        //    con.Open();
        //    com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("POId", POId);
            com.Parameters.AddWithValue("POCode", POCode);
            com.Parameters.AddWithValue("PODate", PODate);
            com.Parameters.AddWithValue("PO_Ref", PO_Ref);
            com.Parameters.AddWithValue("Com_Manu_Ven_Id", Com_Manu_Ven_Id);
            com.Parameters.AddWithValue("Ship_Via", Ship_Via);
            com.Parameters.AddWithValue("PMT_Type", PMT_Type);
            com.Parameters.AddWithValue("Reference", Reference);
            com.Parameters.AddWithValue("PO_SubTotal", PO_SubTotal);
            com.Parameters.AddWithValue("Discount_Perc", Discount_Perc);
            com.Parameters.AddWithValue("Shipping_Amt", Shipping_Amt);
            com.Parameters.AddWithValue("Tax_Type", Tax_Type);
            com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
            com.Parameters.AddWithValue("Tot_Payable_Amt", Tot_Payable_Amt);
            com.Parameters.AddWithValue("Balance_Amt", Balance_Amt);
            com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
            com.Parameters.AddWithValue("IsPaid", IsPaid);
            com.Parameters.AddWithValue("Status", Status);
            com.Parameters.AddWithValue("IsArrived", IsArrived);
            com.Parameters.AddWithValue("Comment", Comment);
            com.Parameters.AddWithValue("Note", Note);
            com.Parameters.AddWithValue("CurrencyId", CurrencyId);
            com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
            com.Parameters.AddWithValue("Type_C_V", Type_C_V);
            com.Parameters.AddWithValue("CstVat", CstVat);
            com.Parameters.AddWithValue("SiteID", @SiteID);
            com.Parameters.AddWithValue("PId", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            PId = Int32.Parse(com.Parameters["PId"].Value.ToString());
            com.Parameters.Clear();
            //com.Dispose();
            //con.Close();
            //con.Dispose();
        //}
    }
    //----------------------------------------------------------------------------------------
    public void PurOrderSave_(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, ref Int32 PId, ref string RetSuccess, Decimal Excise_Duty, String Type_C_V, Decimal CstVat, Int32 SiteID,Int32 UserId, String TermsCondition, Int32 UID, String Session, SqlCommand com)
    {
       
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("POId", POId);
            com.Parameters.AddWithValue("POCode", POCode);
            com.Parameters.AddWithValue("PODate", PODate);
            com.Parameters.AddWithValue("PO_Ref", PO_Ref);
            com.Parameters.AddWithValue("Com_Manu_Ven_Id", Com_Manu_Ven_Id);
            com.Parameters.AddWithValue("Ship_Via", Ship_Via);
            com.Parameters.AddWithValue("PMT_Type", PMT_Type);
            com.Parameters.AddWithValue("Reference", Reference);
            com.Parameters.AddWithValue("PO_SubTotal", PO_SubTotal);
            com.Parameters.AddWithValue("Discount_Perc", Discount_Perc);
            com.Parameters.AddWithValue("Shipping_Amt", Shipping_Amt);
            com.Parameters.AddWithValue("Tax_Type", Tax_Type);
            com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
            com.Parameters.AddWithValue("Tot_Payable_Amt", Tot_Payable_Amt);
            com.Parameters.AddWithValue("Balance_Amt", Balance_Amt);
            com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
            com.Parameters.AddWithValue("IsPaid", IsPaid);
            com.Parameters.AddWithValue("Status", Status);
            com.Parameters.AddWithValue("IsArrived", IsArrived);
            com.Parameters.AddWithValue("Comment", Comment);
            com.Parameters.AddWithValue("Note", Note);
            com.Parameters.AddWithValue("CurrencyId", CurrencyId);
            com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
            com.Parameters.AddWithValue("Type_C_V", Type_C_V);
            com.Parameters.AddWithValue("CstVat", CstVat);
            com.Parameters.AddWithValue("SiteID", @SiteID);
            com.Parameters.AddWithValue("PId", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("UserId", @UserId);
            com.Parameters.AddWithValue("TermsCondition", TermsCondition);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("Session", Session);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            PId = Int32.Parse(com.Parameters["PId"].Value.ToString());
            com.Parameters.Clear();           
            com.Dispose();
    }    
    //----------------------------------------------------------------------------------------
    public void PurOrderChildSave_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, ref string RetSuccess, SqlCommand com)
    {
        //SqlCommand com = null;
        //using (SqlConnection con = new SqlConnection(ReturnConString()))
        //{
        //        com = new SqlCommand();
        //        con.Open();
        //        com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("InstId", InstId);
                com.Parameters.AddWithValue("POId", POId);
                com.Parameters.AddWithValue("RFQChild_Id", RFQChild_Id);
                com.Parameters.AddWithValue("Quantity", Quantity);
                com.Parameters.AddWithValue("Price_Per_Unit", Price_Per_Unit);
                com.Parameters.AddWithValue("Price_Total", Price_Total);
                com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
                com.Parameters.AddWithValue("Discount", Discount);
                com.Parameters.AddWithValue("Frieght", Frieght);
                com.Parameters.AddWithValue("Insurance", Insurance);
                com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
                com.Parameters.AddWithValue("Price_Tax_Total", Price_Tax_Total);
                com.Parameters.AddWithValue("Unit_Id", Unit_Id);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SUID_POrder";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();   
        //        com.Dispose();
        //        con.Close();
        //        con.Dispose();            
        //}
    }
    #endregion

    #region Challan Entry

    //---------------Generating Receipt No------------------------------------//
    public void GenReceiptNo_(Int32 InstID, String prefixtag, ref string Ref_No)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("prefixtag", prefixtag);
            com.Parameters.AddWithValue("Ref_No", Ref_No).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_ReceiptNo";
            Ref_No = com.ExecuteScalar().ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void GenReceiptNo_(Int32 InstID, String prefixtag, ref string Ref_No, SqlCommand com)
    {
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("prefixtag", prefixtag);
        com.Parameters.AddWithValue("Ref_No", Ref_No).Direction = ParameterDirection.Output;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "Gen_ReceiptNo";
        Ref_No = com.ExecuteScalar().ToString();
        com.Parameters.Clear();
    }
    //------------------------------------------------------------------------//

    //-----------------------Saving Record in Challan Master and Child------------//
    public void ChallanMasterSave_(String flag, Int32 ID, String Challan_NO, Decimal Tax_Per, Decimal Disc_Per, Decimal Subtotal, Decimal TaxAmt, Decimal DiscAmt, Decimal Shipping, Decimal Total_Payable, Decimal PaidAmt, Decimal BalanceAmt, DateTime ChallanDate, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, String ReceiptNo, Int32 InstID, ref Int32 ChallanIDRet, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Challan_NO", Challan_NO);
            com.Parameters.AddWithValue("Tax_Per", Tax_Per);
            com.Parameters.AddWithValue("Disc_Per", Disc_Per);
            com.Parameters.AddWithValue("Subtotal", Subtotal);
            com.Parameters.AddWithValue("TaxAmt", TaxAmt);
            com.Parameters.AddWithValue("DiscAmt", DiscAmt);
            com.Parameters.AddWithValue("Shipping", Shipping);
            com.Parameters.AddWithValue("Total_Payable", Total_Payable);
            com.Parameters.AddWithValue("PaidAmt", PaidAmt);
            com.Parameters.AddWithValue("BalanceAmt", BalanceAmt);
            com.Parameters.AddWithValue("ChallanDate", ChallanDate);
            com.Parameters.AddWithValue("Currency", Currency);
            com.Parameters.AddWithValue("EX_Rate", EX_Rate);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("ReceiptNo", ReceiptNo);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("ChallanIDRet", ChallanIDRet).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("AddRel_ID", 0);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Challan_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            ChallanIDRet = Int32.Parse(com.Parameters["ChallanIDRet"].Value.ToString());
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //-----------------------------------------------------------------------------------------//
    public void ChallanMasterSave_(String flag, Int32 ID, String Challan_NO, Decimal Tax_Per, Decimal Disc_Per, Decimal Subtotal, Decimal TaxAmt, Decimal DiscAmt, Decimal Shipping, Decimal Total_Payable, Decimal PaidAmt, Decimal BalanceAmt, DateTime ChallanDate, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, String ReceiptNo, Int32 InstID, ref Int32 ChallanIDRet, ref string RetSuccess, String VehicleType, String VehicleNo, string invoice, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("ID", ID);
        com.Parameters.AddWithValue("Challan_NO", Challan_NO);
        com.Parameters.AddWithValue("Tax_Per", Tax_Per);
        com.Parameters.AddWithValue("Disc_Per", Disc_Per);
        com.Parameters.AddWithValue("Subtotal", Subtotal);
        com.Parameters.AddWithValue("TaxAmt", TaxAmt);
        com.Parameters.AddWithValue("DiscAmt", DiscAmt);
        com.Parameters.AddWithValue("Shipping", Shipping);
        com.Parameters.AddWithValue("Total_Payable", Total_Payable);
        com.Parameters.AddWithValue("PaidAmt", PaidAmt);
        com.Parameters.AddWithValue("BalanceAmt", BalanceAmt);
        com.Parameters.AddWithValue("ChallanDate", ChallanDate);
        com.Parameters.AddWithValue("Currency", Currency);
        com.Parameters.AddWithValue("EX_Rate", EX_Rate);
        com.Parameters.AddWithValue("Session", Session);
        com.Parameters.AddWithValue("UID", UID);
        com.Parameters.AddWithValue("ReceiptNo", ReceiptNo);
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("ChallanIDRet", ChallanIDRet).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("AddRel_ID", 0);
        com.Parameters.AddWithValue("VehicleType", VehicleType);
        com.Parameters.AddWithValue("VehicleNo", VehicleNo);
        com.Parameters.AddWithValue("invoice", invoice);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Challan_Mst";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        ChallanIDRet = Int32.Parse(com.Parameters["ChallanIDRet"].Value.ToString());
        com.Parameters.Clear();
    }
    public void ChallanChildSave_(String flag, Int32 ID, Int32 ChallanID, Int32 POId, Int32 Ctrl_Id, Decimal Qty, Decimal Price_Per_Qty, Decimal Amt, String Session, Int32 UID, Int32 InstID, Int32 PO_ChildID, Int32 Unit_Id, Boolean IsDamaged, Decimal DamagedQty, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("ChallanID", ChallanID);
            com.Parameters.AddWithValue("POId", POId);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Price_Per_Qty", Price_Per_Qty);
            com.Parameters.AddWithValue("Amt", Amt);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("PO_ChildID", PO_ChildID);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);

            com.Parameters.AddWithValue("Is_Damaged", IsDamaged);
            com.Parameters.AddWithValue("DamagedQty", DamagedQty);

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Challan_Chld";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    //---------------------------------------------------------------------------------
    public void ChallanChildSave_(String flag, Int32 ID, Int32 ChallanID, Int32 POId, Int32 Ctrl_Id, Decimal Qty, Decimal Price_Per_Qty, Decimal Amt, String Session, Int32 UID, Int32 InstID, Int32 PO_ChildID, Int32 Unit_Id, Boolean IsDamaged, Decimal DamagedQty, ref string RetSuccess, Decimal TotalAmt, Boolean Is_Returnable, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("ID", ID);
        com.Parameters.AddWithValue("ChallanID", ChallanID);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
        com.Parameters.AddWithValue("Qty", Qty);
        com.Parameters.AddWithValue("Price_Per_Qty", Price_Per_Qty);
        com.Parameters.AddWithValue("Amt", Amt);
        com.Parameters.AddWithValue("Session", Session);
        com.Parameters.AddWithValue("UID", UID);
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("PO_ChildID", PO_ChildID);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);

        com.Parameters.AddWithValue("Is_Damaged", IsDamaged);
        com.Parameters.AddWithValue("DamagedQty", DamagedQty);
        com.Parameters.AddWithValue("Total_Amt", TotalAmt);
        com.Parameters.AddWithValue("Is_Returnable", Is_Returnable);
        
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Challan_Chld";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    //-----------------------------------------------------------------------------//

    public void Challan_File_Save_(String flag, Int32 ChallanID, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ChallanID);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Challan_Mst";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public void Fill_Challan_Grid_(String flag, Int32 ChallanID, Int32 InstID, ref DataTable dt, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "ID", ChallanID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        dt = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Challan_Mst");
        ObjDAL.Command.Parameters.Clear();
    }

    public void View_PO_Details_(String flag, Int32 POID, Int32 InstID, ref DataTable DT, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "POID", POID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        DT = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Challan_Mst");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region Product Receving OR Invoice Entry
    public void ReceiveMasterSave_(String flag, Int32 ID, String Pmt_Type, String Invoice_No, String Receipt_No, Decimal Discount_Perc, Decimal Discount_Amt, DateTime Recv_Date, Decimal Tax_Percent, Decimal Subtotal, Decimal Shipping_Chrgs, Decimal Tax_Amount, Decimal Total_Payable, Decimal Paid_Amt, Decimal Bal_Amt, String Notes, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, Int32 InstID, ref Int32 _ID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("PO_ID", 0);
            com.Parameters.AddWithValue("Pmt_Type", Pmt_Type);
            com.Parameters.AddWithValue("Invoice_No", Invoice_No);
            com.Parameters.AddWithValue("Receipt_No", Receipt_No);
            com.Parameters.AddWithValue("Recv_Date", Recv_Date);
            com.Parameters.AddWithValue("Discount_Perc", Discount_Perc);
            com.Parameters.AddWithValue("Discount_Amt", Discount_Amt);
            com.Parameters.AddWithValue("Tax_Percent", Tax_Percent);
            com.Parameters.AddWithValue("Subtotal", Subtotal);
            com.Parameters.AddWithValue("Shipping_Chrgs", Shipping_Chrgs);
            com.Parameters.AddWithValue("Tax_Amount", Tax_Amount);
            com.Parameters.AddWithValue("Total_Payable", Total_Payable);
            com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
            com.Parameters.AddWithValue("Bal_Amt", Bal_Amt);
            com.Parameters.AddWithValue("Notes", Notes);
            com.Parameters.AddWithValue("Currency", Currency);
            com.Parameters.AddWithValue("EX_Rate", EX_Rate);
            com.Parameters.AddWithValue("Recev_MST", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            _ID = Int32.Parse(com.Parameters["Recev_MST"].Value.ToString());           
            com.Dispose();
            con.Close();
            con.Dispose();
            com.Parameters.Clear();
        }
    }
    public void ReceiveMasterSave_(String flag, Int32 ID, Int32 POId, String Pmt_Type, String Invoice_No, String Receipt_No, Decimal Discount_Perc, Decimal Discount_Amt, DateTime Recv_Date, Decimal Tax_Percent, Decimal Subtotal, Decimal Shipping_Chrgs, Decimal Tax_Amount, Decimal Total_Payable, Decimal Paid_Amt, Decimal Bal_Amt, String Notes, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, Int32 InstID, ref Int32 _ID, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.Clear();
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("ID", ID);
        com.Parameters.AddWithValue("PO_ID", POId);
        com.Parameters.AddWithValue("Pmt_Type", Pmt_Type);
        com.Parameters.AddWithValue("Invoice_No", Invoice_No);
        com.Parameters.AddWithValue("Receipt_No", Receipt_No);
        com.Parameters.AddWithValue("Recv_Date", Recv_Date);
        com.Parameters.AddWithValue("Discount_Perc", Discount_Perc);
        com.Parameters.AddWithValue("Discount_Amt", Discount_Amt);
        com.Parameters.AddWithValue("Tax_Percent", Tax_Percent);
        com.Parameters.AddWithValue("Subtotal", Subtotal);
        com.Parameters.AddWithValue("Shipping_Chrgs", Shipping_Chrgs);
        com.Parameters.AddWithValue("Tax_Amount", Tax_Amount);
        com.Parameters.AddWithValue("Total_Payable", Total_Payable);
        com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
        com.Parameters.AddWithValue("Bal_Amt", Bal_Amt);
        com.Parameters.AddWithValue("Notes", Notes);
        com.Parameters.AddWithValue("Currency", Currency);
        com.Parameters.AddWithValue("EX_Rate", EX_Rate);
        com.Parameters.AddWithValue("Recev_MST", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Session", Session);
        com.Parameters.AddWithValue("UID", UID);
        com.Parameters.AddWithValue("InstID", InstID);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Recev_Mst";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        _ID = Int32.Parse(com.Parameters["Recev_MST"].Value.ToString());
        com.Parameters.Clear();
    }
    public void ReceiveMasterSave_(String flag, Int32 ID, Int32 POId, String Pmt_Type, String Invoice_No, String Receipt_No, Decimal Discount_Perc, Decimal Discount_Amt, DateTime Recv_Date, Decimal Tax_Percent, Decimal Subtotal, Decimal Shipping_Chrgs, Decimal Tax_Amount, Decimal Total_Payable, Decimal Paid_Amt, Decimal Bal_Amt, String Notes, Int32 Currency, Decimal EX_Rate, String Session, Int32 UID, Int32 InstID, ref Int32 _ID, Boolean Is_Paid, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.Clear();
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("ID", ID);
        com.Parameters.AddWithValue("PO_ID", POId);
        com.Parameters.AddWithValue("Pmt_Type", Pmt_Type);
        com.Parameters.AddWithValue("Invoice_No", Invoice_No);
        com.Parameters.AddWithValue("Receipt_No", Receipt_No);
        com.Parameters.AddWithValue("Recv_Date", Recv_Date);
        com.Parameters.AddWithValue("Discount_Perc", Discount_Perc);
        com.Parameters.AddWithValue("Discount_Amt", Discount_Amt);
        com.Parameters.AddWithValue("Tax_Percent", Tax_Percent);
        com.Parameters.AddWithValue("Subtotal", Subtotal);
        com.Parameters.AddWithValue("Shipping_Chrgs", Shipping_Chrgs);
        com.Parameters.AddWithValue("Tax_Amount", Tax_Amount);
        com.Parameters.AddWithValue("Total_Payable", Total_Payable);
        com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
        com.Parameters.AddWithValue("Bal_Amt", Bal_Amt);
        com.Parameters.AddWithValue("Notes", Notes);
        com.Parameters.AddWithValue("Currency", Currency);
        com.Parameters.AddWithValue("EX_Rate", EX_Rate);
        com.Parameters.AddWithValue("Recev_MST", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("Session", Session);
        com.Parameters.AddWithValue("UID", UID);
        com.Parameters.AddWithValue("IsPAID", Is_Paid);
        com.Parameters.AddWithValue("InstID", InstID);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Recev_Mst";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        _ID = Int32.Parse(com.Parameters["Recev_MST"].Value.ToString());
        com.Parameters.Clear();
    }
    public void ReceiveChildSave_(Int32 Recev_Mst_Id, Int32 PO_ID, Int32 ChallanID, Int32 Product_ID, Decimal Quantity, Decimal Prc_Per_Qty, Decimal Tot_Price, Int32 Location, Int32 InstID, Int32 ChallanChildID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "N");
            com.Parameters.AddWithValue("Rec_Mst_ID", Recev_Mst_Id);
            com.Parameters.AddWithValue("PO_ID", PO_ID);
            com.Parameters.AddWithValue("ChallanID", ChallanID);
            com.Parameters.AddWithValue("ProductID", Product_ID);
            com.Parameters.AddWithValue("Quantity", Quantity);
            com.Parameters.AddWithValue("Prc_Per_Qty", Prc_Per_Qty);
            com.Parameters.AddWithValue("Tot_Price", Tot_Price);
            com.Parameters.AddWithValue("Location", Location);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("ChallanChildID", ChallanChildID);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recv_Chld";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
            com.Parameters.Clear();
        }
    }
    public void ReceiveChildSave_(Int32 Recev_Mst_Id, Int32 PO_ID, Int32 ChallanID, Int32 Ctrl_Id, Decimal Quantity, Decimal Prc_Per_Qty, Decimal Tot_Price, Int32 Location, Int32 InstID, Int32 ChallanChildID, Int32 Unit_Id, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", "N");    
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;     
        com.Parameters.AddWithValue("Rec_Mst_ID", Recev_Mst_Id);
        com.Parameters.AddWithValue("PO_ID", PO_ID);
        com.Parameters.AddWithValue("ChallanID", ChallanID);
        com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Prc_Per_Qty", Prc_Per_Qty);
        com.Parameters.AddWithValue("Tot_Price", Tot_Price);
        com.Parameters.AddWithValue("Location", Location);
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("ChallanChildID", ChallanChildID);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);  
           
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Recv_Chld";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    public void FetchCatalogue_(String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", "F", DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Catalog");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Receive_Invoice_Up_(String flag, Int32 ID, Int32 InstID, String Invoice_No, ref String RetSuccess, SqlCommand Com)
    {
        Com.Parameters.AddWithValue("flag", flag);
        Com.Parameters.AddWithValue("ID", ID);
        Com.Parameters.AddWithValue("InstID", InstID);
        Com.Parameters.AddWithValue("Invoice_No", Invoice_No);
        Com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        Com.CommandType = CommandType.StoredProcedure;
        Com.CommandText = "SP_Recev_Mst";
        Com.ExecuteNonQuery();
        RetSuccess = Com.Parameters["RetSuccess"].Value.ToString();
        Com.Parameters.Clear();
    }
    #endregion

    #region Payment Process
    public void GenDocNo_(int InstId, ref string Doc_No)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "DocNo");
            com.Parameters.AddWithValue("Doc_No", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_Doc_No";
            Doc_No = com.ExecuteScalar().ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void BillToAccount_(string flag, int InstId, int Id, string Receipt_No, string Order_No, string Inv_Relation, int Inv_Relation_Id, DateTime Pmt_Date, string Doc_No, string Pmt_Type, Decimal InvoiceAmt, Decimal Dmgd_Qty_Amt, Decimal PayableAmt, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Receipt_No", Receipt_No);
            com.Parameters.AddWithValue("Order_No", Order_No);
            com.Parameters.AddWithValue("Inv_Relation", Inv_Relation);
            com.Parameters.AddWithValue("Inv_Relation_Id", Inv_Relation_Id);
            com.Parameters.AddWithValue("Pmt_Date", Pmt_Date);
            com.Parameters.AddWithValue("Doc_No", Doc_No);
            com.Parameters.AddWithValue("Pmt_Type", Pmt_Type);

            com.Parameters.AddWithValue("InvoiceAmt", InvoiceAmt);
            com.Parameters.AddWithValue("Dmgd_Qty_Amt", Dmgd_Qty_Amt);
            com.Parameters.AddWithValue("PayableAmt", PayableAmt);

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Payment";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    public void PmtStatus_(string flag, int InstId, int Id, int Invoice_Id, string Pmt_Status, string Pmt_Type, string Draft_Chq_No, string Draft_Chq_Date, DateTime Pmt_Date, Decimal Pay_Amt, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Invoice_Id", Invoice_Id);
            com.Parameters.AddWithValue("Pmt_Status", Pmt_Status);
            com.Parameters.AddWithValue("Pmt_Type", Pmt_Type);
            com.Parameters.AddWithValue("Draft_Chq_No", Draft_Chq_No);

            com.Parameters.AddWithValue("Draft_Chq_Date", Draft_Chq_Date);
            com.Parameters.AddWithValue("Pmt_Date", Pmt_Date);
            com.Parameters.AddWithValue("Pay_Amt", Pay_Amt);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Payment";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void Payment_(string flag, int InstId, int Id, int Invoice_Id, string Draft_Chq_No, string Draft_Chq_Date, DateTime Pmt_Date, decimal Pay_Amt, string Pay_Bank, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Invoice_Id", Invoice_Id);
            com.Parameters.AddWithValue("Draft_Chq_No", Draft_Chq_No);
            com.Parameters.AddWithValue("Draft_Chq_Date", Draft_Chq_Date);
            com.Parameters.AddWithValue("Pmt_Date", Pmt_Date);
            com.Parameters.AddWithValue("Pay_Amt", Pay_Amt);
            com.Parameters.AddWithValue("Pay_Bank", Pay_Bank);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Payment";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }

    //-------------------------Modified By Mohd Danish Ansari On 22-Feb-2011----------------------//
    public void SelectPOBasis_(String flag, Int32 InstID, Int32 POID, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        ObjDAL.AddParameters(2, "POId", POID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_FillPayment");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Select_RPT_RECS_(String flag, Int32 InstID, Int32 RecvID, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        ObjDAL.AddParameters(2, "RecvId", RecvID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_FillPayment");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Select_RPT_RECS(String flag, Int32 InstID, Int32 RecvID, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        ObjDAL.AddParameters(2, "RecvId", RecvID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_FillPayment");
        ObjDAL.Command.Parameters.Clear();
    }
    public void FillItemGrid_(String flag, Int32 InstID, Int32 RecvID, ref DataTable DtItmGrd, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        ObjDAL.AddParameters(2, "RecvId", RecvID, DbType.Int32);
        DtItmGrd = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "sp_FillPayment");
        ObjDAL.DataReader.Close();
        ObjDAL.Command.Parameters.Clear();
    }
    public void Save_Item_Wise_AMT_(String flag, Int32 PaymentID, Int32 InvoiceID, Decimal PayableAmt, Decimal PaidAmt, String BillNo, String Pmt_Type, String Draft_Chq_No, String Draft_Chq_Date, Boolean Is_Dmgd_Adj, Decimal Dmgd_Amt, Int32 UserID, Int32 InstID, Int32 SupplierID, Int32 POID, Boolean Clearence, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("PaymentID", PaymentID);
            com.Parameters.AddWithValue("InvoiceID", InvoiceID);
            com.Parameters.AddWithValue("PayableAmt", PayableAmt);
            com.Parameters.AddWithValue("PaidAmt", PaidAmt);
            com.Parameters.AddWithValue("BillNo", BillNo);
            com.Parameters.AddWithValue("Pmt_Type", Pmt_Type);
            com.Parameters.AddWithValue("Draft_Chq_No", Draft_Chq_No);
            com.Parameters.AddWithValue("Draft_Chq_Date", Draft_Chq_Date);
            com.Parameters.AddWithValue("Is_Dmgd_Adj", Is_Dmgd_Adj);
            com.Parameters.AddWithValue("Dmgd_Amt", Dmgd_Amt);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("SupplierID", SupplierID);
            com.Parameters.AddWithValue("POID", POID);
            com.Parameters.AddWithValue("Clearing", Clearence);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Inv_Amt";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void GenBillNo_(Int32 InstID, String prefixtag, ref String BillNo)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstID);
            com.Parameters.AddWithValue("prefixtag", prefixtag);
            com.Parameters.AddWithValue("Bill_No", BillNo);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_Bill_No";
            BillNo = com.ExecuteScalar().ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //--------------------------------------------------------------------------------------------//
    #endregion

    #region Cataloguing
    public void CatalogueSave_(String flag, Int32 ID, Int32 PO_ID, Int32 Rec_Mst_ID, Int32 Ctrl_Id, String Batch_No, String Serial_No, Int32 Location, String Var_Year, String Short_Name, Int32 InstID, Decimal Quantity, Int32 Unit_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
           
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;

            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);

            com.Parameters.AddWithValue("PO_ID", PO_ID);

            com.Parameters.AddWithValue("Rec_Mst_ID", Rec_Mst_ID);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);

            com.Parameters.AddWithValue("Batch_No", Batch_No);
            com.Parameters.AddWithValue("Serial_No", Serial_No);

            com.Parameters.AddWithValue("Location", Location);
            com.Parameters.AddWithValue("Var_Year", Var_Year);

            com.Parameters.AddWithValue("Short_Name", Short_Name);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Quantity", Quantity);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Catalog";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void CatalogueSave_(String flag, Int32 ID, Int32 PO_ID, Int32 Rec_Mst_ID, Int32 Ctrl_Id, String Batch_No, String Serial_No, Int32 Location, String Var_Year, String Short_Name, Int32 InstID, Decimal Quantity, Int32 Unit_Id, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;

        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("where", null);
        com.Parameters.AddWithValue("ID", ID);

        com.Parameters.AddWithValue("PO_ID", PO_ID);

        com.Parameters.AddWithValue("Rec_Mst_ID", Rec_Mst_ID);
        com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);

        com.Parameters.AddWithValue("Batch_No", Batch_No);
        com.Parameters.AddWithValue("Serial_No", Serial_No);

        com.Parameters.AddWithValue("Location", Location);
        com.Parameters.AddWithValue("Var_Year", Var_Year);

        com.Parameters.AddWithValue("Short_Name", Short_Name);
        com.Parameters.AddWithValue("InstID", InstID);

        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);

        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Catalog";
        com.ExecuteNonQuery();

        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    #endregion

    #region Direct Purchase Order
    public void DirectPOSave_(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, String PO_Ref, Int32 Com_Manu_Ven_Id, String Ship_Via, String PMT_Type, String Reference, Decimal PO_SubTotal, Decimal Discount_Perc, Decimal Shipping_Amt, String Tax_Type, Decimal Tax_Amt, Decimal Tot_Payable_Amt, Decimal Balance_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, DateTime POExpctDate, ref Int32 PId, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("POCode", POCode);
        com.Parameters.AddWithValue("PODate", PODate);
        com.Parameters.AddWithValue("PO_Ref", PO_Ref);
        com.Parameters.AddWithValue("Com_Manu_Ven_Id", Com_Manu_Ven_Id);

        com.Parameters.AddWithValue("Ship_Via", Ship_Via);
        com.Parameters.AddWithValue("PMT_Type", PMT_Type);
        com.Parameters.AddWithValue("Reference", Reference);
        com.Parameters.AddWithValue("PO_SubTotal", PO_SubTotal);
        com.Parameters.AddWithValue("Discount_Perc", Discount_Perc);

        com.Parameters.AddWithValue("Shipping_Amt", Shipping_Amt);
        com.Parameters.AddWithValue("Tax_Type", Tax_Type);

        com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
        com.Parameters.AddWithValue("Tot_Payable_Amt", Tot_Payable_Amt);
        com.Parameters.AddWithValue("Balance_Amt", Balance_Amt);
        com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
        com.Parameters.AddWithValue("IsPaid", IsPaid);

        com.Parameters.AddWithValue("Status", Status);
        com.Parameters.AddWithValue("IsArrived", IsArrived);
        com.Parameters.AddWithValue("Comment", Comment);
        com.Parameters.AddWithValue("Note", Note);
        com.Parameters.AddWithValue("CurrencyId", CurrencyId);
        com.Parameters.AddWithValue("POExpctDate", POExpctDate);

        com.Parameters.AddWithValue("PId", 0).Direction = ParameterDirection.Output;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        PId = Int32.Parse(com.Parameters["PId"].Value.ToString());
        com.Parameters.Clear();
    }
    public void GenPONo_(int InstId, ref string Order_No, SqlCommand com)
    {
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("prefixtag", "POrder");
        com.Parameters.AddWithValue("Order_No", 0).Direction = ParameterDirection.Output;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "Gen_POredr_No";
        Order_No = com.ExecuteScalar().ToString();
        com.Parameters.Clear();
    }
    public void POChildSave_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("RFQChild_Id", RFQChild_Id);
        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Price_Per_Unit", Price_Per_Unit);
        com.Parameters.AddWithValue("Price_Total", Price_Total);
        com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
        com.Parameters.AddWithValue("Discount", Discount);
        com.Parameters.AddWithValue("Frieght", Frieght);
        com.Parameters.AddWithValue("Insurance", Insurance);
        com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
        com.Parameters.AddWithValue("Price_Tax_Total", Price_Tax_Total);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Deliv_Terms", Deliv_Terms);
        com.Parameters.AddWithValue("Pmt_Terms", Pmt_Terms);
        com.Parameters.AddWithValue("Other_Levies", Other_Levies);
        com.Parameters.AddWithValue("CtrlID", CtrlID);

        com.Parameters.AddWithValue("DeliveryMode", DelMode);
        com.Parameters.AddWithValue("DeliveryDate", DelDate);

        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    //-------------------------------------------
    public void POChildSave_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("RFQChild_Id", RFQChild_Id);
        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Price_Per_Unit", Price_Per_Unit);
        com.Parameters.AddWithValue("Price_Total", Price_Total);
        com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
        com.Parameters.AddWithValue("Discount", Discount);
        com.Parameters.AddWithValue("Frieght", Frieght);
        com.Parameters.AddWithValue("Insurance", Insurance);
        com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
        com.Parameters.AddWithValue("Price_Tax_Total", Price_Tax_Total);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Deliv_Terms", Deliv_Terms);
        com.Parameters.AddWithValue("Pmt_Terms", Pmt_Terms);
        com.Parameters.AddWithValue("Other_Levies", Other_Levies);
        com.Parameters.AddWithValue("CtrlID", CtrlID);

        com.Parameters.AddWithValue("DeliveryMode", DelMode);
        com.Parameters.AddWithValue("DeliveryDate", DelDate);
        com.Parameters.AddWithValue("Bal_Qty", BalQty);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    //----------------------------------------------------------------
    public void POChildSave_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess,Int32 UserId, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("RFQChild_Id", RFQChild_Id);
        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Price_Per_Unit", Price_Per_Unit);
        com.Parameters.AddWithValue("Price_Total", Price_Total);
        com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
        com.Parameters.AddWithValue("Discount", Discount);
        com.Parameters.AddWithValue("Frieght", Frieght);
        com.Parameters.AddWithValue("Insurance", Insurance);
        com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
        com.Parameters.AddWithValue("Price_Tax_Total", Price_Tax_Total);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Deliv_Terms", Deliv_Terms);
        com.Parameters.AddWithValue("Pmt_Terms", Pmt_Terms);
        com.Parameters.AddWithValue("Other_Levies", Other_Levies);
        com.Parameters.AddWithValue("CtrlID", CtrlID);

        com.Parameters.AddWithValue("DeliveryMode", DelMode);
        com.Parameters.AddWithValue("DeliveryDate", DelDate);
        com.Parameters.AddWithValue("Bal_Qty", BalQty);
        com.Parameters.AddWithValue("UserId", UserId);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }

    //-----------------New PO Child Save Function(Add Discount Conditions)-----------------------------------------------
    public void POChildSavenaveen_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, Int32 UserId, Boolean IsDisc_Perc, String Maker, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("RFQChild_Id", RFQChild_Id);
        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Price_Per_Unit", Price_Per_Unit);
        com.Parameters.AddWithValue("Price_Total", Price_Total);
        com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
        com.Parameters.AddWithValue("Discount", Discount);
        com.Parameters.AddWithValue("Frieght", Frieght);
        com.Parameters.AddWithValue("Insurance", Insurance);
        com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
        com.Parameters.AddWithValue("Price_Tax_Total", Price_Tax_Total);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Deliv_Terms", Deliv_Terms);
        com.Parameters.AddWithValue("Pmt_Terms", Pmt_Terms);
        com.Parameters.AddWithValue("Other_Levies", Other_Levies);
        com.Parameters.AddWithValue("CtrlID", CtrlID);
        com.Parameters.AddWithValue("Maker", Maker);
        com.Parameters.AddWithValue("DeliveryMode", DelMode);
        com.Parameters.AddWithValue("DeliveryDate", DelDate);
        com.Parameters.AddWithValue("Bal_Qty", BalQty);
        com.Parameters.AddWithValue("UserId", UserId);
        com.Parameters.AddWithValue("IsDisc_Perc", IsDisc_Perc);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    public void POChildSave_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, Int32 UserId, Boolean IsDisc_Perc, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("fields", null);
        com.Parameters.AddWithValue("Where", null);
        com.Parameters.AddWithValue("InstId", InstId);
        com.Parameters.AddWithValue("POId", POId);
        com.Parameters.AddWithValue("RFQChild_Id", RFQChild_Id);
        com.Parameters.AddWithValue("Quantity", Quantity);
        com.Parameters.AddWithValue("Price_Per_Unit", Price_Per_Unit);
        com.Parameters.AddWithValue("Price_Total", Price_Total);
        com.Parameters.AddWithValue("Tax_Amt", Tax_Amt);
        com.Parameters.AddWithValue("Discount", Discount);
        com.Parameters.AddWithValue("Frieght", Frieght);
        com.Parameters.AddWithValue("Insurance", Insurance);
        com.Parameters.AddWithValue("Excise_Duty", Excise_Duty);
        com.Parameters.AddWithValue("Price_Tax_Total", Price_Tax_Total);
        com.Parameters.AddWithValue("Unit_Id", Unit_Id);
        com.Parameters.AddWithValue("Deliv_Terms", Deliv_Terms);
        com.Parameters.AddWithValue("Pmt_Terms", Pmt_Terms);
        com.Parameters.AddWithValue("Other_Levies", Other_Levies);
        com.Parameters.AddWithValue("CtrlID", CtrlID);
       
        com.Parameters.AddWithValue("DeliveryMode", DelMode);
        com.Parameters.AddWithValue("DeliveryDate", DelDate);
        com.Parameters.AddWithValue("Bal_Qty", BalQty);
        com.Parameters.AddWithValue("UserId", UserId);
        com.Parameters.AddWithValue("IsDisc_Perc", IsDisc_Perc);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
       
    }
    //-----------------------------------------------------------------------
    public void DirectPO_Select_(String flag, Int32 POID, Int32 InstID, DBManager ObjDAL, ref DataTable dtDirectPO)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "POID", POID, DbType.Int32);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        dtDirectPO = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SUID_POrder");
        ObjDAL.Command.Parameters.Clear();
    }
    public void DirectPO_Select_(String flag, Int32 POID, Int32 CtrlID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(4);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "POID", POID, DbType.Int32);
        ObjDAL.AddParameters(2, "CtrlID", CtrlID, DbType.Int32);
        ObjDAL.AddParameters(3, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_POrder");
        ObjDAL.Command.Parameters.Clear();
    }
    //--------------Get Unit,File Name incase of Direct PO-------------------
    protected void Get_DPOInfo_(String flag, Int32 POID, Int32 InstID,ref String Result)
    {
        ObjDb = new DBManager();
        ObjDb = ReturnDALConString();
        ObjDb.CreateParameters(3);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "POID", POID, DbType.Int32);
        ObjDb.AddParameters(2, "InstID", InstID, DbType.Int32);
        Result = ObjDb.ExecuteScalar(CommandType.StoredProcedure, "sp_Fill_POProduct").ToString();
        ObjDb.Command.Parameters.Clear();
        ObjDb.Close();
        ObjDb.Dispose();
    }
    //--------------Get Unit,Previous Rate incase of Direct PO-------------------
    protected void Get_DPOUnitRate_(String flag, Int32 POID, Int32 InstID, ref String UnitId,ref String Rate)
    {
        ObjDb = new DBManager();
        ObjDb = ReturnDALConString();
        ObjDb.CreateParameters(3);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "POID", POID, DbType.Int32);
        ObjDb.AddParameters(2, "InstID", InstID, DbType.Int32);
        ObjDb.ExecuteReader(CommandType.StoredProcedure, "sp_Fill_POProduct");
        if (ObjDb.DataReader.Read())
        {
            UnitId = ObjDb.DataReader["Unit_Id"].ToString();
            Rate = ObjDb.DataReader["PVRate"].ToString();
        }
        //Result = ObjDb.ExecuteScalar(CommandType.StoredProcedure, "sp_Fill_POProduct").ToString();
        ObjDb.Command.Parameters.Clear();
        ObjDb.DataReader.Close();
        ObjDb.Close();
        ObjDb.Dispose();
    }
    #endregion

    #region Setting Decimal Precision
    public void Set_Dec_Places_(String flag, ref Decimal Value, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetResult", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "GET_DEC_PLACES";
            Value = Decimal.Parse(Value.ToString("N" + Int32.Parse(com.ExecuteScalar().ToString())));
            com.Parameters.Clear();            
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void Set_Dec_Places_(String flag, ref Decimal Value, Int32 InstID, String Type)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetResult", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "GET_DEC_PLACES";
            if (Type == "Q")
            {
                Value = Decimal.Parse(Value.ToString("N" + Int32.Parse(com.ExecuteScalar().ToString())));
            }
            else
            {
                Value = Int32.Parse(com.ExecuteScalar().ToString()); 
            }
            com.Parameters.Clear();
        }
    }
    public void Set_Dec_Places_(String flag, ref Int32 RetResult, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetResult", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "GET_DEC_PLACES";
            RetResult = Int32.Parse(com.ExecuteScalar().ToString()); //Int32.Parse(com.Parameters["RetResult"].Value.ToString());
            com.Parameters.Clear();           
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    #endregion

    #region Store Suppliers Detail
    public void Get_SplrDetails_(Int32 InstID, int SupplierId, ref DataTable dtSupplier)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "F");
            com.Parameters.AddWithValue("InstId", InstID);
            com.Parameters.AddWithValue("SupplierId", SupplierId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Stor_Vnd";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtSupplier);           
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region User Creation
    public void UserCreation_Save_(String flag, Int32 InstId, Int32 UserId, String UserName, String Password, String Salt, Int32 InstituteID, Boolean Active, String UName, DateTime UEntDt, Int32 Emp_id, String User_Type, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("Fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("UserId", UserId);
            com.Parameters.AddWithValue("UserName", UserName);
            com.Parameters.AddWithValue("Password", Password);
            com.Parameters.AddWithValue("Salt", Salt);
            com.Parameters.AddWithValue("InstituteID", InstituteID);
            com.Parameters.AddWithValue("Active", Active);
            com.Parameters.AddWithValue("UName", UName);
            com.Parameters.AddWithValue("UEntDt", UEntDt);
            com.Parameters.AddWithValue("Emp_id", Emp_id);
            com.Parameters.AddWithValue("User_Type", User_Type);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_UserCreation";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void UserCreation_Delete_(Int32 UserId, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "D");
            com.Parameters.AddWithValue("UserId", UserId);
            com.Parameters.AddWithValue("InstId", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_UserCreation";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region PrefixID
    public void PrefixSave_(String flag, Int32 ID, String prefixtag, String prefixsting, Int32 maxid, Boolean Is_Active, Int32 InstId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("prefixtag", prefixtag);
            com.Parameters.AddWithValue("prefixsting", prefixsting);
            com.Parameters.AddWithValue("maxid", maxid);
            com.Parameters.AddWithValue("Is_Active", Is_Active);
            com.Parameters.AddWithValue("InstId", InstId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Prefix";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void PrefixSelect_(String fields, String where, DBManager ObjDAL, ref DataTable dtPrefix)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", "S", DbType.String);
        ObjDAL.AddParameters(1, "fields", fields, DbType.String);
        ObjDAL.AddParameters(2, "where", where, DbType.String);
        dtPrefix = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Prefix");
        ObjDAL.Command.Parameters.Clear();
    }
    public void PrefixSelect_(String fields, String where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", "S", DbType.String);
        ObjDAL.AddParameters(1, "fields", fields, DbType.String);
        ObjDAL.AddParameters(2, "where", where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Prefix");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region Fill ListBox using stored procedure incase of RFQ Creation
    public void FillCheckboxlist(CheckBoxList chk, string TextFieldName, string ValueFieldName,string flag,Int32 VndrDtlsID)
    {
        SqlCommand com = null;
        SqlDataReader dr;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            chk.Items.Clear();
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("@VendDtlsId", VndrDtlsID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "get_Vendors";
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                chk.DataSource = dr;
                chk.DataTextField = TextFieldName;
                chk.DataValueField = ValueFieldName;
                chk.DataBind();
            }
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Get Unit
    public void GetUnit_(int InstId, int UnitId, String TextField, String ValueField, DropDownList DDLID)
    {
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            SqlCommand com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("UOM_ID", UnitId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Get_UOM";
            SqlDataReader dr = null;
            dr = com.ExecuteReader();
            DDLID.Items.Clear();
            if (dr.HasRows)
            {
                DDLID.DataSource = dr;
                DDLID.DataTextField = TextField;
                DDLID.DataValueField = ValueField;
                DDLID.DataBind();
            }                
            com.Dispose();
            con.Close();
            con.Dispose();                
        }
    }
    #endregion

    #region Generating CtrlID
    public void GenCtrlID_(String ProdCode, Int32 InstID, ref int CtrlID, SqlCommand com)
    {
        com.Parameters.AddWithValue("Prod_Code", ProdCode);
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("CtrlID", 0).Direction = ParameterDirection.Output;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "Gen_CtrlID";
        CtrlID = Int32.Parse(com.ExecuteScalar().ToString());
        com.Parameters.Clear();
    }
    #endregion

    #region Inventory Settings
    public void InvntSet_Save_(String flag, Int32 ID, Int32 IndntPndDays, Int32 IssWtDays, Int32 ResWtDays, String BdgtAlloctWise, Int32 PmtDecPlaces, Int32 PrcDPlaces, Int32 QtyDPlaces, Int32 InstID,String POPerm_Users, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("IndntPndDays", IndntPndDays);
            com.Parameters.AddWithValue("IssWtDays", IssWtDays);
            com.Parameters.AddWithValue("ResWtDays", ResWtDays);
            com.Parameters.AddWithValue("BdgtAlloctWise", BdgtAlloctWise);
            com.Parameters.AddWithValue("PmtDecPlaces", PmtDecPlaces);
            com.Parameters.AddWithValue("PrcDPlaces", PrcDPlaces);
            com.Parameters.AddWithValue("QtyDPlaces", QtyDPlaces);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("POPerm_Users", POPerm_Users);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Inv_Set";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void InvntSet_Save_(String flag, Int32 ID, Int32 IndntPndDays, Int32 IssWtDays, Int32 ResWtDays, String BdgtAlloctWise, Int32 PmtDecPlaces, Int32 PrcDPlaces, Int32 QtyDPlaces, Int32 InstID, ref string RetSuccess, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(13);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "RetSuccess", 0, DbType.String, ParameterDirection.Output);
        ObjDAL.AddParameters(2, "fields", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "where", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(4, "ID", ID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(5, "IndntPndDays", IndntPndDays, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(6, "IssWtDays", IssWtDays, DbType.Int32, ParameterDirection.Input);

        ObjDAL.AddParameters(7, "ResWtDays", ResWtDays, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(8, "BdgtAlloctWise", BdgtAlloctWise, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(9, "PmtDecPlaces", PmtDecPlaces, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(10, "PrcDPlaces", PrcDPlaces, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(11, "QtyDPlaces", QtyDPlaces, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(12, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Inv_Set");
        RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["@RetSuccess"].Value.ToString();
        ObjDAL.Command.Parameters.Clear();            
    }
    protected void InvntSet_Select_(String fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", "S", DbType.String);
        ObjDAL.AddParameters(1, "fields", fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Inv_Set");
        ObjDAL.Command.Parameters.Clear();
    }
    //------------Fill Users In CheckBoxList-----------------------
    protected void InvntSet_FillUsers_(String flag,Int32 InstID, Int32 RoleId, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32);
        ObjDAL.AddParameters(2, "RoleId", RoleId, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Inv_Set");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region MultiProduct Indent
    public void Get_ProdDetailScrap_(Int32 InstID, int CtrlID, ref DataTable dtProdDtls)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "P");
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Ctrl_Id", CtrlID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_ScrapMaterial";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtProdDtls);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Get_ProdDetailScrapDept_(Int32 InstID, int ID, ref DataTable dtProdDtls)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "F");
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Id", ID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_ScrapMaterial";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtProdDtls);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Get_ProdDetailIssue_(Int32 InstID, int CtrlID, ref DataTable dtProdDtls)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "P");
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Ctrl_Id", CtrlID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_IssueLimit";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtProdDtls);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Get_ProdDetails_(Int32 InstID, int CtrlID, ref DataTable dtProdDtls)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "P");
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Ctrl_Id", CtrlID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtProdDtls);            
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        } 
    }
    public void Fill_Indent_(Int32 InstID, ref DataTable dtIndent_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "G");
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtIndent_);            
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose(); 
        }
    }
    public void Get_IndentDetail_(Int32 InstID, Int32 Id, ref DataTable dtIndentDtl_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "F");
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Id", Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtIndentDtl_);           
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose(); 
        } 
    }
    public void Get_IssueLimitDetail_(Int32 InstID, Int32 Id, ref DataTable dtIndentDtl_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "F");
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("Id", Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_IssueLimit";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtIndentDtl_);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Filling Location On Receving
    public void Fill_Loc_Recev_(Int32 CtrlID, Int32 InstID, ref DataTable dtLoc_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "L");
            com.Parameters.AddWithValue("CtrlID", CtrlID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtLoc_);
            com.Parameters.Clear();           
            com.Dispose();
            con.Close();
            con.Dispose();  
        }
    }
    #endregion

    #region Vendor Code,Manufacturer Code, Company Code
    public void Gen_VndrCode_(int InstId, ref string VndrCode)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "VndrCode");
            com.Parameters.AddWithValue("VndrCode", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_VndrCode";
            VndrCode = com.ExecuteScalar().ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
            
    }
    public void Gen_ManuCode_(int InstId, ref string ManuCode)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "ManuCode");
            com.Parameters.AddWithValue("ManuCode", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_ManuCode";
            ManuCode = com.ExecuteScalar().ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void Gen_CompCode_(int InstId, ref string CompCode)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "CompCode");
            com.Parameters.AddWithValue("CompCode", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_CompCode";
            CompCode = com.ExecuteScalar().ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    #endregion

    #region Create Client Login
    public void Create_ClientLogin_(int InstId, Int32 Id, String Pwd, String Salt, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "L");
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("pwd", Pwd);
            com.Parameters.AddWithValue("saltvc", Salt);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Client_Regs";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    #endregion

    #region Storing Vendor Details
    public void Vendor_Dtls_Save_(String flag, Int32 ID, Int32 PRId, Int32 Ctrl_Id, String SupplierId, Int32 IndentID, Int32 UID, String SessionID, Int32 InstID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("PRId", PRId);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("SupplierId", SupplierId);
            com.Parameters.AddWithValue("IndentID", IndentID);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Stor_Vnd";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Material Issue
    public void Gen_MatIssueNo_(int InstId, ref string Issue_No)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("prefixtag", "IssueNo");
            com.Parameters.AddWithValue("Issue_No", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_MatIssueNo";
            Issue_No = com.ExecuteScalar().ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void MatIssue_Save_(string flag, int InstId, int Id, String Issue_No, DateTime Issue_Date, DateTime Due_Date, String IssueStoreLoc, String RecvStoreLoc, String IssuedTo, String IssuedBy, Int32 IndentId, String Issue_Type, int Ctrl_Id, Decimal Issue_Qty, Boolean IsReturnable, Int32 UOM, String Description, String Contractor, String Supervisor, ref Int32 IssueId, Int32 SiteID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Issue_No", Issue_No);
            com.Parameters.AddWithValue("Issue_Date", Issue_Date);
            com.Parameters.AddWithValue("Due_Date", Due_Date);
            com.Parameters.AddWithValue("IssueStoreLoc", IssueStoreLoc);
            com.Parameters.AddWithValue("RecvStoreLoc", RecvStoreLoc);
            com.Parameters.AddWithValue("IssuedTo", IssuedTo);

            com.Parameters.AddWithValue("IssuedBy", IssuedBy);
            com.Parameters.AddWithValue("IndentId", IndentId);
            com.Parameters.AddWithValue("Issue_Type", Issue_Type);

            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Issue_Qty", Issue_Qty);
            com.Parameters.AddWithValue("IsReturnable", IsReturnable);
            com.Parameters.AddWithValue("UOM", UOM);
            com.Parameters.AddWithValue("Description", Description);
            com.Parameters.AddWithValue("Contractor", Contractor);
            com.Parameters.AddWithValue("Supervisor", Supervisor);
            com.Parameters.AddWithValue("IssueId", IssueId).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("SiteID", SiteID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            IssueId = Int32.Parse(com.Parameters["IssueId"].Value.ToString() == string.Empty ? "0" : com.Parameters["IssueId"].Value.ToString());
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void MatIssueChild_Save_(int InstId, int Id, Int32 IssueId, Int32 Store_Loc, String Loc_Type, Decimal Qty, Int32 Unit_Id, String Issue_Type, Int32 Ctrl_Id, Int32 IndentId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", "C");
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("IssueId", IssueId);
            com.Parameters.AddWithValue("Store_Loc", Store_Loc);
            com.Parameters.AddWithValue("Loc_Type", Loc_Type);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.Parameters.AddWithValue("Issue_Type", Issue_Type);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("IndentId", IndentId);

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    public void MatIssue_QtyCheck_(int InstId, int Id, Decimal IQty, Int32 IUnit, String Issue_Type, ref String IndntQty, ref string IndntUOM, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", "I");
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;

            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("IQty", IQty);
            com.Parameters.AddWithValue("IUnit", IUnit);
            com.Parameters.AddWithValue("Issue_Type", Issue_Type);
            com.Parameters.AddWithValue("IndntQty", IndntQty).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("IndntUOM", IndntUOM).Direction = ParameterDirection.Output;
            com.Parameters["IndntQty"].Size = 100;
            com.Parameters["IndntUOM"].Size = 15;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";

            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            IndntQty = com.Parameters["IndntQty"].Value.ToString();
            IndntUOM = com.Parameters["IndntUOM"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();        
        }
    }
    public void Check_StockBal_(String flag, int InstId, int Ctrl_Id, Int32 Issue_Loc, Decimal Qty, Int32 Unit, ref String Stock_Bal, ref string StockUnit, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Issue_Loc", Issue_Loc);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Unit", Unit);
            com.Parameters.AddWithValue("Stock_Bal", Stock_Bal).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("StockUnit", StockUnit).Direction = ParameterDirection.Output;
            com.Parameters["Stock_Bal"].Size = 1000;
            com.Parameters["StockUnit"].Size = 15;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Check_StockBal";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            Stock_Bal = com.Parameters["Stock_Bal"].Value.ToString();
            StockUnit = com.Parameters["StockUnit"].Value.ToString();           
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    //---------------Get Issuable Items-------------------------------------------
    protected void Get_IssuableItems_(String flag, Int32 InstID, Int32 UserId, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "UserId", UserId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Mat_Issue");
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Generating PR No
    public void Gen_PR_No_(Int32 InstID, String prefixtag, ref string PRNo)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("prefixtag", prefixtag);
            com.Parameters.AddWithValue("PRNo", PRNo).Direction = ParameterDirection.Output;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_PRNo";
            PRNo = com.ExecuteScalar().ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    #endregion

    #region Material Return
    public void Mat_Return_(int InstId, int Id, Int32 Ctrl_Id, Decimal ReturnQty, String RecvStoreLoc, String ReturnedBy, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", "R");
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("ReturnQty", ReturnQty);
            com.Parameters.AddWithValue("RecvStoreLoc", RecvStoreLoc);
            com.Parameters.AddWithValue("ReturnedBy", ReturnedBy);

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";

            com.ExecuteNonQuery();

            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    public void MatChild_Return_(int InstId, Int32 IssueId, Int32 Ctrl_Id, Decimal Qty, Int32 RecvStoreLoc, Int32 Unit_Id, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", "A");
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", 0);
            com.Parameters.AddWithValue("IssueId", IssueId);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Store_Loc", RecvStoreLoc);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);


            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";

            com.ExecuteNonQuery();

            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();            
        }
    }
    #endregion

    #region Receive Location
    public void Recv_Loc_(int InstId, int IssueId, ref DataTable dtLocRecv_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Issue_Id", IssueId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Get_RecvLoc";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtLocRecv_);            
            com.Dispose();
            con.Close();
            con.Dispose();
        }  
    }
    #endregion

    #region Material Reservation
    public void Mat_Reservation_(string flag, int InstId, int Id, int Client_Id, int Ctrl_Id, Decimal Qty, String ReservedBy, Int32 Unit_Id, ref int RetSuccess, ref Boolean ISReserve)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("Client_Id", Client_Id);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("ReservedBy", ReservedBy);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Reserve";
            com.ExecuteNonQuery();
            RetSuccess = Int32.Parse(com.Parameters["RetSuccess"].Value.ToString());
            if (RetSuccess == 0)
            {
                ISReserve = false;
            }
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Reset_RsrvPriority_(int InstId, int Client_Id, int ProductId, ref int ResClientId, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", "R");
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("InstID", InstId);
            com.Parameters.AddWithValue("Client_Id", Client_Id);
            com.Parameters.AddWithValue("ProductId", ProductId);
            com.Parameters.AddWithValue("ResClientId", ResClientId).Direction = ParameterDirection.Output;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Chk_MatReservation";

            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            ResClientId = Int32.Parse(com.Parameters["ResClientId"].Value.ToString());
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Fill Suppliers incase of updation
    public void Fill_Supp(String flag,int InstId, int PRID,int Ctrl_Id,int IndentID, ref DataTable dtSupp_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("PRID", PRID);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("IndentID", IndentID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Stor_Vnd";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtSupp_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Supp(String flag, int InstId, int PRID, int Ctrl_Id, ref DataTable dtSupp_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("PRID", PRID);
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Stor_Vnd";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtSupp_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Institute
    public void Institute_Save_(String flag, Int32 id_inst, String INSTITUTE_NAME, String SHORT_NAME, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("id_inst", id_inst);
            com.Parameters.AddWithValue("INSTITUTE_NAME", INSTITUTE_NAME);
            com.Parameters.AddWithValue("SHORT_NAME", SHORT_NAME);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("UEDate", UEDate);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Institute";

            com.ExecuteNonQuery();

            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    public void Organisation_Delete_(String flag, Int32 id_inst, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("id_inst", id_inst);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Institute";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Dispose();
            con.Close();
            con.Dispose();           
        }
    }
    //-------------Fill Organization Grid----------------------------------
    protected void OrgGrdFill_(String flag, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(1);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Institute");
    }
    //----------------------------------------------------------------
    #endregion

    #region Update PR 
    //-----------------------Fill Indent Products incase of updation-----------------------
    public void Fill_PRDtls_(String flag, int InstId, int PR_Mst_Id, ref DataTable dtPR_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("PR_Mst_Id", PR_Mst_Id);            
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_Req_Ch";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPR_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    //-----------------------Delete PRdetails from child incase of updation-----------------------
    public void PR_Del_(String flag, int InstId, int PR_Mst_Id, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("PR_Mst_Id", PR_Mst_Id);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_Req_Ch";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region RFQ Search and Update
    public void Fill_RFQDtls_(String flag, int InstId, int RFQId, ref DataTable dtRFQ_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("RFQId", RFQId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Fill_RFQ";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtRFQ_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_RFQDtls_(String flag, int InstId, int RFQId, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "RFQId", RFQId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "Fill_RFQ");
        ObjDAL.Command.Parameters.Clear();
    }
    //----------------------Fill RFQ Detail for sorting-------------------------------
    public void Fill_SortRFQDtls_(String flag, int InstId, int RFQId,String SortedBy, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(4);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "RFQId", RFQId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "SortedBy", SortedBy, DbType.String, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "Fill_RFQ");
        ObjDAL.Command.Parameters.Clear();
    }
    //------------------------RFQ Arrival Update----------------
    public void RFQArrvl_Update_(String flag, Int32 RFQID,Int32 PRID,Int32 InstId, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RFQID", RFQID);
            com.Parameters.AddWithValue("PRID", PRID);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Pur_RFQ";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //--------------------------------------------------------------------------------------
    protected void RFQArrvl_Update_(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, ref String RetSuccess, NewDAL.DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(5);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32);
        ObjDAL.AddParameters(2, "RFQID", RFQID, DbType.Int32);
        ObjDAL.AddParameters(3, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
        ObjDAL.AddParameters(4, "SupplierID", SupplierID, DbType.Int32);

        ObjDAL.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Pur_RFQ");
        RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["@RetSuccess"].Value.ToString();
        ObjDAL.Command.Parameters.Clear();
    }
    //--------------------------------------------------------------------------------------
    public void GetOthSuppDtls_(String flag,Int32 InstId, Int32 RFQID, Int32 SupplierID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(4);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "RFQID", RFQID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "SupplierID", SupplierID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "Fill_RFQ");
        ObjDAL.Command.Parameters.Clear();
    }
    public void GetOthSuppDtls_(String flag, Int32 RFQID, Int32 SupplierID, ref DataTable dt, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "RFQID", RFQID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "SupplierID", SupplierID, DbType.Int32, ParameterDirection.Input);
        dt = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "Fill_RFQ");
        ObjDAL.Command.Parameters.Clear();
    }
    //------------------Get Items Details of a RFQ--------------------------
    public void GetItmDtls_(String flag,Int32 InstId, Int32 RFQID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input); 
        ObjDAL.AddParameters(2, "RFQID", RFQID, DbType.Int32, ParameterDirection.Input);       
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "Fill_RFQ");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region Damaged Goods Management
    public void FillProdDetailsGrid_(String flag, Int32 ID, ref DataTable dtProd_, DBManager ObjDAL, Int32 InstID)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "ID", ID, DbType.Int32);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        dtProd_ = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SP_Damgd_Goods");
        ObjDAL.Command.Parameters.Clear();
    }

    public void Damaged_Qty_Amt_(String flag, Int32 RecvMstID, Int32 InstID, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "RecvId", RecvMstID, DbType.Int32);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_FillPayment");
        //ObjDAL.DataReader.Close();
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region Search & Update Purchase Order
    public void Fill_PODtls_(String flag, int InstId, int POID, ref DataTable dtPO_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("POID", POID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Fill_POProduct";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPO_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Search & Update Challan Entry
    public void Fill_ChallanDtls_(String flag, int InstId, int ID, ref DataTable dtChallan_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("ID", ID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtChallan_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Search & Fill Cataloguing Detail
    public void Fill_CatlgDtls_(String flag, int InstId, int ID,int Ctrl_Id,int Location, ref DataTable dtCatlg_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("CtrlId", Ctrl_Id);
            com.Parameters.AddWithValue("Location", Location);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtCatlg_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Check Budget Balance of a Institute
    public void Fill_BgtBal_(String flag, int InstId, ref DataTable dtBgt_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstId);            
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtBgt_);
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Department Master
    public void DeptMstSave_(String flag, Int32 Table_Id, Int32 DepartmentID, String DepartmentName, String Shortname, String Mark_Del, Int32 InstituteID, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", "0").Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("Where", null);
            com.Parameters.AddWithValue("Table_Id", Table_Id);
            com.Parameters.AddWithValue("DepartmentID", DepartmentID);
            com.Parameters.AddWithValue("DepartmentName", DepartmentName);
            com.Parameters.AddWithValue("Shortname", Shortname);
            com.Parameters.AddWithValue("Mark_Del", Mark_Del);
            com.Parameters.AddWithValue("InstituteID", InstituteID);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("UEDate", UEDate);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[sp_Department_Mst]";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //-------------------------------Fill Department Grid------------------------
    protected void FillDeptGrid_(String flag, Int32 InstituteID, ref DataTable dtDept)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstituteID", InstituteID);           
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[sp_Department_Mst]";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtDept);           
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    //---------------------------------------------------------------------------
    public void DeptMstDelete_(String flag, Int32 DepartmentId, Int32 InstituteID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("DepartmentId", DepartmentId);
            com.Parameters.AddWithValue("InstituteID", InstituteID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Department_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Saving Records in PO Creation Table
    public void PO_Create_Save(String flag, Int32 POID, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POId", POID);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstId", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Grid_File_PO_(String flag, Int32 POID, Int32 InstID, ref DataTable dtFile)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POId", POID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtFile);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Stock Detail Report
    public void Fill_Stock_Dtls_(String Query, ref DataTable dt)
    {
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(Query, con);
            adp.Fill(dt);
            adp.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Getting College Details For Reports
    public void Get_Collg_Dtls_(Int32 InstID, ref DBManager ObjDAL)
    {
        String Query = "Select CollegeName,Phone1,Phone2,Fax,EmailID1,Location, TinNo from College Where CollegeId = '" + InstID + "' ";
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.Text, Query);
    }
    #endregion

    #region Direct PO Through Indent
    public void FillProdDetails_PO_(String flag, Int32 IndentID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "IndentID", IndentID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_POrder");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion

    #region Site Master
    public void Site_Master_Save_(String flag, Int32 ID, String SiteName, String Address, String ContactPerson, String ContactNo, Int32 InstID, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("SiteName", SiteName);
            com.Parameters.AddWithValue("Address", Address);            
            com.Parameters.AddWithValue("ContactPerson", ContactPerson);
            com.Parameters.AddWithValue("ContactNo", ContactNo);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Site_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void FillGrid(String flag, Int32 InstID, ref DataTable dt)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Site_Mst";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dt);
            com.Parameters.Clear();
            adp.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Site_Delete_(String flag, Int32 ID, Int32 InstID, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Site_Mst";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Saving Records in Mat_Issue_File Table
    public void MatIssueFile_Save_(String flag, String Issue_No, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("Issue_No", Issue_No);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstId", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Grid_File_Issue_(String flag, String Issue_No, Int32 InstID, ref DataTable dtFile)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("Issue_No", Issue_No);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_Mat_Issue";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtFile);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Saving Records in Indent_Files Table
    public void IndentFile_Save_(String flag, Int32 IndentId, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("IndentId", IndentId);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstId", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Grid_File_Indent_(String flag, Int32 IndentId, Int32 InstID, ref DataTable dtFile)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("IndentId", IndentId);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtFile);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Fill Product details of same indent

    public void FillIndentProd_(String flag, Int32 Id, Int32 InstID, ref DataTable dtProd)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", Id);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtProd);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Saving Records in Indent_Files Table
    public void MatRecvFile_Save_(String flag, Int32 Id, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", Id);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstId", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Grid_File_MatRecv_(String flag, Int32 Id, Int32 InstID, ref DataTable dtFile)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", Id);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtFile);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Direct PO Updating
    public void Direc_PO_Select_(String flag, Int32 POID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "POID", POID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "InstId", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_Fill_POProduct");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Direct_PO_Update_(String flag, Int32 POID, Int32 InstID, Decimal ShippingAmt, String Comment, Decimal ExciseDuty, String Type_C_V, Decimal CstVat, Int32 SiteID, Boolean Status, ref String RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("POID", POID);
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("Shipping_Amt", ShippingAmt);
        com.Parameters.AddWithValue("Comment", Comment);
        com.Parameters.AddWithValue("Excise_Duty", ExciseDuty);
        com.Parameters.AddWithValue("Type_C_V", Type_C_V);
        com.Parameters.AddWithValue("CstVat", CstVat);
        com.Parameters.AddWithValue("SiteID", SiteID);
        com.Parameters.AddWithValue("Status", Status);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();
    }
    //----------------------------------------------------------------------
    public void Direct_PO_Update_(String flag, Int32 POID, Int32 InstID, Decimal ShippingAmt, String Comment, Decimal ExciseDuty, String Type_C_V, Decimal CstVat, Int32 SiteID, Boolean Status, ref String RetSuccess, Int32 UserId, String TermsCondition, Decimal Tot_Payable_Amt, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("POID", POID);
        com.Parameters.AddWithValue("InstID", InstID);
        com.Parameters.AddWithValue("Shipping_Amt", ShippingAmt);
        com.Parameters.AddWithValue("Comment", Comment);
        com.Parameters.AddWithValue("Excise_Duty", ExciseDuty);
        com.Parameters.AddWithValue("Type_C_V", Type_C_V);
        com.Parameters.AddWithValue("CstVat", CstVat);
        com.Parameters.AddWithValue("SiteID", SiteID);
        com.Parameters.AddWithValue("Status", Status);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.Parameters.AddWithValue("UserId", UserId);
        com.Parameters.AddWithValue("TermsCondition", TermsCondition);
        com.Parameters.AddWithValue("Tot_Payable_Amt", Tot_Payable_Amt);
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();       
    }
    #endregion

    #region Check PO is approved or not
    public void POChk_Apprv_(String flag, Int32 POId, Int32 InstID, ref DataTable dtPO)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POID", POId);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPO);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Search PO
    public void SearchPO_(String flag, String Condition, ref DataTable dtPO)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("Condition", Condition);
            
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Fill_POProduct";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPO);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public void FillPOItem_Detail_(String flag, Int32 POId,Int32 InstId, ref DataTable dtPO)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POId", POId);
            com.Parameters.AddWithValue("InstId", InstId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_Fill_POProduct";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPO);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region PO Write Off Searching
    public void POWriteOffSearch_(String flag, String Condition, ref DataTable dt, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "Condition", Condition, DbType.String, ParameterDirection.Input);
        dt = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "SUID_POrder");
        ObjDAL.Command.Parameters.Clear();
    }

    public void FillPO_Detail_(String flag, Int32 POCId, Int32 InstId, ref DataTable dtPO)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POId", POCId);
            com.Parameters.AddWithValue("InstId", InstId);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPO);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void POUpdate_(String flag, Int32 POID, Int32 InstID, Boolean WriteOFF, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POID", POID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("WriteOFF", WriteOFF);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SUID_POrder";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Update Budget & Client Balance
    //----------------------------------------------------------------------
    public void Update_Bal_(String flag, Int32 POID, Int32 InstID, Int32 UserId, ref String RetSuccess, SqlCommand com)
    {
        com.Parameters.AddWithValue("flag", flag);
        com.Parameters.AddWithValue("POID", POID);
        com.Parameters.AddWithValue("InstID", InstID);      
        com.Parameters.AddWithValue("UserId", UserId);
        com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SUID_POrder";
        com.ExecuteNonQuery();
        RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
        com.Parameters.Clear();       
        com.Parameters.Clear();
    }
    #endregion

    #region Generate Member Id
    //----------------------------------------------------------------------
    public void Gen_MemId_(Int32 InstId, ref String MemberId)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("Member_ID", "0").Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_MemberId";
            //com.ExecuteNonQuery();
            MemberId = com.ExecuteScalar().ToString(); //com.Parameters["Member_ID"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Cash Purchase File Save
    public void Cash_Pur_File_Save_(Int32 POID, Int32 Recev_Mst_ID, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            
            com.Parameters.AddWithValue("flag", "CP");
            com.Parameters.AddWithValue("PO_ID", POID);
            com.Parameters.AddWithValue("Recev_Mst_ID", Recev_Mst_ID);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Grid_CP_File_(Int32 POID, Int32 Recev_Mst_ID, Int32 InstID, ref DataTable dt)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "FCP");
            com.Parameters.AddWithValue("PO_ID", POID);
            com.Parameters.AddWithValue("Recev_Mst_ID", Recev_Mst_ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Recev_Mst";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dt);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Purchase Group
    public void PurchaseGrSave_(String flag, Int32 ID, String Mem_Gr_Name, String Mem_Sh_Name, Boolean IsTimeLimit, DateTime FrmDate, DateTime ToDate, Decimal SPOAmt, Decimal MPOAmt, Decimal CSPOAmt, Decimal CMPOAmt, Int32 UID, String Session, Int32 InstID, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("Mem_Gr_Name", Mem_Gr_Name);
            com.Parameters.AddWithValue("Mem_Sh_Name", Mem_Sh_Name);
            com.Parameters.AddWithValue("IsTimeLimit", IsTimeLimit);
            com.Parameters.AddWithValue("FrmDate", FrmDate);
            com.Parameters.AddWithValue("ToDate", ToDate);
            com.Parameters.AddWithValue("SPOAmt", SPOAmt);
            com.Parameters.AddWithValue("MPOAmt", MPOAmt);
            com.Parameters.AddWithValue("CSPOAmt", CSPOAmt);
            com.Parameters.AddWithValue("CMPOAmt", CMPOAmt);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Purchase_Gr";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public void PurchaseGrSelect_(String flag,Int32 InstID, String fields, String Where, ref DataTable dtPGrp)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("fields", fields);
            com.Parameters.AddWithValue("Where", Where);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Purchase_Gr";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtPGrp);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public void PurchaseGrDel_(String flag, Int32 ID, Int32 InstID,  ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ID", ID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Purchase_Gr";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();            
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Check Purchasing Group Limitations
    public void PurchaseGrLimit_(String flag,String POType, Int32 UserId, Int32 InstId, DateTime PODate, Decimal TotalPOAmt,Int32 POID, ref String IsSuccess, ref String ValidRange)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("POType", POType);
            com.Parameters.AddWithValue("UserId", UserId);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("PODate", PODate);
            com.Parameters.AddWithValue("TotalPOAmt", TotalPOAmt);
            com.Parameters.AddWithValue("POID", POID); 
            com.Parameters.AddWithValue("IsSuccess", IsSuccess).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("ValidRange", ValidRange).Direction = ParameterDirection.Output;
            com.Parameters["ValidRange"].Size = 1000;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Check_PurchGrLimit";
            com.ExecuteNonQuery();
            IsSuccess = com.Parameters["IsSuccess"].Value.ToString();
            ValidRange = com.Parameters["ValidRange"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Check Indent Issue Limitations
    public void IndentIssueLimit_(String flag, Int32 Ctrl_Id, Int32 DeptId, Int32 InstId, DateTime IndentDate, Decimal Qty, Int32 Unit_Id, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "S");
            com.Parameters.AddWithValue("Ctrl_Id", Ctrl_Id);
            com.Parameters.AddWithValue("DeptId", DeptId);
            com.Parameters.AddWithValue("InstId", InstId);
            com.Parameters.AddWithValue("IndentDate", IndentDate);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("Unit_Id", Unit_Id);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Check_ValidIndent";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            //ValidRange = com.Parameters["ValidRange"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Item Return
    public void Item_Return_Save_(String flag, Int32 ChallanID, Int32 ChallanChldID, Int32 Ctrl_ID, Decimal Qty, Int32 UnitID, DateTime ReturnDate, String MRC, Int32 UID, String Session, Int32 InstID, Int32 StoreID, String Note, String VehicleNo, String VehicleType, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ChallanID", ChallanID);
            com.Parameters.AddWithValue("ChallanChldID", ChallanChldID);
            com.Parameters.AddWithValue("Ctrl_ID", Ctrl_ID);
            com.Parameters.AddWithValue("Qty", Qty);
            com.Parameters.AddWithValue("UnitID", UnitID);
            com.Parameters.AddWithValue("ReturnDate", ReturnDate);
            com.Parameters.AddWithValue("MRC", MRC);
            com.Parameters.AddWithValue("StoreID", StoreID);
            com.Parameters.AddWithValue("Note", Note);
            com.Parameters.AddWithValue("UID", UID);
            com.Parameters.AddWithValue("Session", Session);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("VehicleNo", VehicleNo);
            com.Parameters.AddWithValue("VehicleType", VehicleType);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Itm_Return";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Returnable_Itm_(String flag, Int32 ChallanID, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "ChallanID", ChallanID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Itm_Return");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Gen_MRC(Int32 InstID, String prefixtag, ref string MRC)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("prefixtag", prefixtag);
            com.Parameters.AddWithValue("MRC", MRC).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Gen_MRC";
            MRC = com.ExecuteScalar().ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Fill_Location_(Int32 CtrlID, Int32 InstID, ref DataTable dtLoc_)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "L");
            com.Parameters.AddWithValue("Ctrl_ID", CtrlID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Itm_Return";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtLoc_);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void MatRetFile_Save_(String flag, String MRC, String FileName, String FileType, Int32 InstID)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("MRC", MRC);
            com.Parameters.AddWithValue("FileName", FileName);
            com.Parameters.AddWithValue("FileType", FileType);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Itm_Return";
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void FillGrid_FileItmRet_(String flag, String MRC, Int32 InstID, ref DataTable dtFile)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("MRC", MRC);
            com.Parameters.AddWithValue("InstID", InstID);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Itm_Return";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dtFile);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region GateEntry
    public void GetMrcDtls(String flag, String MRC, Int32 InstID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "MRC", MRC, DbType.String);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Itm_Return");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Gate_Entry_Save_(String flag, String ItemsID, Int32 InstID, ref String RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("ItemsID", ItemsID);
            com.Parameters.AddWithValue("InstID", InstID);
            com.Parameters.AddWithValue("RetSuccess", RetSuccess).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Itm_Return";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Checking PO Permission To User
    public void ChkPoPerm(Int32 UserID, String PageName, ref String RetResult, SqlConnection con)
    {
        con.Open();
        using (SqlCommand com = new SqlCommand())
        {
            com.Connection = con;
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("PageName", PageName);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "chkPOPerm";
            RetResult = com.ExecuteScalar().ToString();
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Getting Pending PO Details    
    public void Get_Pending_PO_(Int32 UserID, Int32 InstID, ref List<DataMember.PendingPO> GetPendingPO)
    {
        NewDAL.DBManager ObjDAL = ReturnDALConString();
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", "S", DbType.String);
        ObjDAL.AddParameters(1, "UID", UserID, DbType.Int32);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "GtPOPending");
        while (ObjDAL.DataReader.Read())
        {
            var Items = new DataMember.PendingPO();
            Items.POCode = ObjDAL.DataReader["POCode"].ToString();
            Items.DeliveryDate = Convert.ToDateTime(ObjDAL.DataReader["DeliveryDate"].ToString());
            Items.Supplier = ObjDAL.DataReader["vendor_name"].ToString();
            Items.FileName = ObjDAL.DataReader["FileName"].ToString();
            Items.FileType = ObjDAL.DataReader["FileType"].ToString();
            GetPendingPO.Add(Items);
        }
        ObjDAL.Command.Parameters.Clear();
        ObjDAL.Close();
        ObjDAL.Dispose();
    }
    #endregion

    #region Get Dept Indent Regs
    public void DeptIndent_Regs_(String flag, Int32 InstID,String Condition, ref DataTable dt)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            con.Open();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("InstId", InstID);
            com.Parameters.AddWithValue("Condition", Condition);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Get_DeptIndentRegs";
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dt);
            com.Parameters.Clear();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region Drug_Store
    public void Drug_StoreSave_(String flag, String DrugSt_ID, String DrugSt_Name, String DrugSt_Short_Name, Int32 Floor, String Address, String BuildingName, String BuildShName, Int32 St_Type, String Mrk_Del, String Owner, String License_No, Int32 InstituteID, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);

            com.Parameters.AddWithValue("DrugSt_ID", DrugSt_ID);
            com.Parameters.AddWithValue("DrugSt_Name", DrugSt_Name);
            com.Parameters.AddWithValue("DrugSt_Short_Name", DrugSt_Short_Name);
            com.Parameters.AddWithValue("Floor", Floor);
            com.Parameters.AddWithValue("Address", Address);
            com.Parameters.AddWithValue("BuildingName", BuildingName);
            com.Parameters.AddWithValue("BuildShName", BuildShName);
            com.Parameters.AddWithValue("St_Type", St_Type);
            com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
            com.Parameters.AddWithValue("Owner", Owner);
            com.Parameters.AddWithValue("License_No", License_No);
            com.Parameters.AddWithValue("InstituteID", InstituteID);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("UEDate", UEDate);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Hsp_Drug_Store";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    public void Drug_StoreChldSave_(String flag, String DrugSt_ID, String Mrk_Del, String User, String User_Nm, int Bill_Chrg_Id, Int32 InstituteID, String SessionID, String UserID, DateTime UEDate, int St_Type, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", flag);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.Parameters.AddWithValue("fields", null);
            com.Parameters.AddWithValue("where", null);

            com.Parameters.AddWithValue("DrugSt_ID", DrugSt_ID);

            com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
            com.Parameters.AddWithValue("User", User);
            com.Parameters.AddWithValue("User_Nm", User_Nm);
            com.Parameters.AddWithValue("Bill_Chrg_Id", Bill_Chrg_Id);
            com.Parameters.AddWithValue("InstituteID", InstituteID);
            com.Parameters.AddWithValue("SessionID", SessionID);
            com.Parameters.AddWithValue("UserID", UserID);
            com.Parameters.AddWithValue("UEDate", UEDate);
            com.Parameters.AddWithValue("St_Type", St_Type);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Hsp_Drug_Store";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Drug_StoreDelete_(Int32 DrugSt_ID, Int32 InstituteID, ref string RetSuccess)
    {
        SqlCommand com = null;
        using (SqlConnection con = new SqlConnection(ReturnConString()))
        {
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", "D");
            com.Parameters.AddWithValue("DrugSt_ID", DrugSt_ID);
            com.Parameters.AddWithValue("InstituteID", InstituteID);
            com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Hsp_Drug_Store";
            com.ExecuteNonQuery();
            RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
            com.Dispose();
            con.Close();
            con.Dispose();
        }
    }
    public void Drug_StoreSelect_(String flag, String Fields, String Where, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String);
        ObjDAL.AddParameters(1, "fields", Fields, DbType.String);
        ObjDAL.AddParameters(2, "where", Where, DbType.String);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SP_Hsp_Drug_Store");
        ObjDAL.Command.Parameters.Clear();
    }
    public void Drug_StoreGrdFill_(String Query, ref DataTable Drug_Store, DBManager ObjDAL)
    {
        Drug_Store = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }

    public void Drug_Store_FeeSelect(ref DBManager ObjDAL, string Query)
    {

        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.Text, Query);
    }
    #endregion

    #region Drug Sell Detail

    public void Pt_DtlGrid(DBManager ObjDAL, ref DataTable dt, String Query)
    {
        dt = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    public void Details_(ref DBManager ObjDAL, string Query)
    {

        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.Text, Query);
    }

    public void DrugSell_Save(String flag, int ID, String Drug_St_Id, int Prod_Id, String Prod_Code, String Reg_Id, String Patient_Id, String Customer_Id, decimal Qty, decimal Price, String Bill_Id, String Mrk_Del, int instituteId, String SessionID, String UserID, DateTime UEDate, decimal Stoc_Bal, int Refund, String Old_Bl_No, decimal Unit_Price, decimal Ref_Amt, int St_Typ, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("ID", ID);
                com.Parameters.AddWithValue("Drug_St_Id", Drug_St_Id);
                com.Parameters.AddWithValue("Prod_Id", Prod_Id);
                com.Parameters.AddWithValue("Prod_Code", Prod_Code);
                com.Parameters.AddWithValue("Reg_Id", Reg_Id);
                com.Parameters.AddWithValue("Patient_Id", Patient_Id);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);
                com.Parameters.AddWithValue("Qty", Qty);
                com.Parameters.AddWithValue("Price", Price);
                com.Parameters.AddWithValue("Bill_Id", Bill_Id);
                com.Parameters.AddWithValue("Mrk_Del", "C");
                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.Parameters.AddWithValue("Stoc_Bal", Stoc_Bal);
                com.Parameters.AddWithValue("Refund", Refund);
                com.Parameters.AddWithValue("Old_Bl_No", Old_Bl_No);
                com.Parameters.AddWithValue("Unit_Price", Unit_Price);
                com.Parameters.AddWithValue("Ref_Amt", Ref_Amt);
                com.Parameters.AddWithValue("St_Typ", St_Typ);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Hsp_Drug_Str_Bill";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }
    public void Pt_Med_UPD(String flag, String Bill_Id, decimal Adj_Amt, String Is_Clear, int instituteId, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);

                com.Parameters.AddWithValue("Bill_Id", Bill_Id);
                com.Parameters.AddWithValue("Adj_Amt", Adj_Amt);
                com.Parameters.AddWithValue("Is_Clear", Is_Clear);

                com.Parameters.AddWithValue("InstituteID", instituteId);


                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Hsp_Drug_Str_Bill";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }

    public void DrugSell_Dtl_Oth_Save(String flag, int Id, String F_Name, String M_Name, String L_Name, String Customer_Id, String FF_Name, String FL_Name, String Gender, String Age, DateTime DOB, int Country, int State, int City, String S_no, String Telephone, String District, int instituteId, String SessionID, String UserID, DateTime UEDate, String Mrk_Del, String Bill_Id, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("Id", Id);
                com.Parameters.AddWithValue("F_Name", F_Name);
                com.Parameters.AddWithValue("M_Name", M_Name);
                com.Parameters.AddWithValue("L_Name", L_Name);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);
                com.Parameters.AddWithValue("FF_Name", FF_Name);
                com.Parameters.AddWithValue("FL_Name", FL_Name);
                com.Parameters.AddWithValue("Gender", Gender);
                com.Parameters.AddWithValue("Age", Age);
                com.Parameters.AddWithValue("DOB", DOB);

                com.Parameters.AddWithValue("Country", Country);
                com.Parameters.AddWithValue("State", State);
                com.Parameters.AddWithValue("City", City);
                com.Parameters.AddWithValue("S_no", S_no);
                com.Parameters.AddWithValue("Telephone", Telephone);

                com.Parameters.AddWithValue("District", District);
                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
                com.Parameters.AddWithValue("Bill_Id", Bill_Id);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Hsp_Drug_Str_Bill";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }


    public void Pt_Med_Bll_Save(String flag, int ID, String Bill_Id, String Reg_Id, String Patient_Id, String Customer_Id, int Is_Pt, decimal Bill_Amt, DateTime Bl_Dt_Tm, decimal Tax, decimal Service_chrg, int instituteId, String SessionID, String UserID, DateTime UEDate, decimal Paid_Amt, int Rt_Id, int Cp, String Drug_St_Id, int St_Typ, String Orig_Bill_No, decimal Tot_Ref_Amt, int Refund, int Pay_Mode, int Cr_Room, decimal Bal_Amt, String Mrk_Del, String Is_Clear, decimal Return_Amt, decimal Tot_Bill_Amt, decimal Tot_Bill_Paid, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("ID", ID);
                com.Parameters.AddWithValue("Bill_Id", Bill_Id);
                com.Parameters.AddWithValue("Reg_Id", Reg_Id);
                com.Parameters.AddWithValue("Patient_Id", Patient_Id);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);
                com.Parameters.AddWithValue("Is_Pt", Is_Pt);
                com.Parameters.AddWithValue("Bill_Amt", Bill_Amt);
                com.Parameters.AddWithValue("Bl_Dt_Tm", Bl_Dt_Tm);
                com.Parameters.AddWithValue("Tax", Tax);
                com.Parameters.AddWithValue("Service_chrg", Service_chrg);

                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
                com.Parameters.AddWithValue("Rt_Id", Rt_Id);
                com.Parameters.AddWithValue("Cp", Cp);
                com.Parameters.AddWithValue("Drug_St_Id", Drug_St_Id);
                com.Parameters.AddWithValue("St_Typ", St_Typ);
                com.Parameters.AddWithValue("Orig_Bill_No", Orig_Bill_No);
                com.Parameters.AddWithValue("Tot_Ref_Amt", Tot_Ref_Amt);
                com.Parameters.AddWithValue("Refund", Refund);
                com.Parameters.AddWithValue("Pay_Mode", Pay_Mode);
                com.Parameters.AddWithValue("Cr_Room", Cr_Room);
                com.Parameters.AddWithValue("Bal_Amt", Bal_Amt);
                com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
                com.Parameters.AddWithValue("Is_Clear", Is_Clear);
                com.Parameters.AddWithValue("Return_Amt", Return_Amt);
                com.Parameters.AddWithValue("Tot_Bill_Amt", Tot_Bill_Amt);
                com.Parameters.AddWithValue("Tot_Bill_Paid", Tot_Bill_Paid);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Hsp_Drug_Str_Bill";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }




    }

    public void Pay_Rec_Save(String flag, int PayR_ID, String Rpt_No, DateTime Pay_D, String Pay_T, int Pay_M, decimal Amt_P, String Reg_Id, String Patient_Id, String Customer_Id, String Amt_Flag, String Mrk_Del, int instituteId, String SessionID, String UserID, DateTime UEDate, int Rt_Id, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("PayR_ID", PayR_ID);
                com.Parameters.AddWithValue("Rpt_No", Rpt_No);
                com.Parameters.AddWithValue("Pay_D", Pay_D);
                com.Parameters.AddWithValue("Pay_T", Pay_T);
                com.Parameters.AddWithValue("Pay_M", Pay_M);
                com.Parameters.AddWithValue("Amt_P", Amt_P);
                com.Parameters.AddWithValue("Reg_Id", Reg_Id);
                com.Parameters.AddWithValue("Patient_Id", Patient_Id);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);
                com.Parameters.AddWithValue("Amt_Flag", Amt_Flag);
                com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.Parameters.AddWithValue("Rt_Id", Rt_Id);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_Hsp_PayRec_New";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }


    public void Drug_Bill_Status_Save(String flag, int ID, String Drug_St_Id, int St_Typ, String Reg_Id, String Patient_Id, String Customer_Id, int Rt_Id, String Bill_Id, decimal Bill_Amt, decimal Paid_Amt, decimal Bal_Amt, String Bill_Status, decimal Ref_Amt, String Old_Bl_No, int Is_Pt, int Refund, String Mrk_Del, int instituteId, String SessionID, String UserID, DateTime UEDate, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("ID", ID);
                com.Parameters.AddWithValue("Drug_St_Id", Drug_St_Id);
                com.Parameters.AddWithValue("St_Typ", St_Typ);
                com.Parameters.AddWithValue("Reg_Id", Reg_Id);
                com.Parameters.AddWithValue("Patient_Id", Patient_Id);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);
                com.Parameters.AddWithValue("Rt_Id", Rt_Id);
                com.Parameters.AddWithValue("Bill_Id", Bill_Id);
                com.Parameters.AddWithValue("Bill_Amt", Bill_Amt);
                com.Parameters.AddWithValue("Paid_Amt", Paid_Amt);
                com.Parameters.AddWithValue("Bal_Amt", Bal_Amt);
                com.Parameters.AddWithValue("Bill_Status", Bill_Status);
                com.Parameters.AddWithValue("ReF_Amt", Ref_Amt);
                com.Parameters.AddWithValue("Old_Bl_No", Old_Bl_No);
                com.Parameters.AddWithValue("Is_Pt", Is_Pt);
                com.Parameters.AddWithValue("Refund", Refund);
                com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Hsp_Drug_Str_Bill";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }
    }
    #endregion

    #region DrugMst
    public void DrugMst_Save(string flag, Int32 Drug_Id, string Drug_Nm, string Drug_Desc, Int32 InstituteID, string SessionID, string UserID, ref string RetSuccess)
    {

        //DrugMst_Save(flag, Drug_Id, Drug_Nm, Drug_Desc, InstituteID, SessionID, UserID, ref RetSuccess);

        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("Drug_id", Drug_Id);
                com.Parameters.AddWithValue("Drug_name", Drug_Nm);
                com.Parameters.AddWithValue("Drug_descrip", Drug_Desc);
                com.Parameters.AddWithValue("Mrk_Del", "C");
                com.Parameters.AddWithValue("InstituteID", InstituteID);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_Hsp_Drug_Mst";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }

    public void Drug_MstSelect(String Query, ref DBManager ObjDAL)
    {
        ObjDAL.ExecuteReader(CommandType.Text, Query);
    }

    #endregion

    #region Refund_Medi
    public void Reg_MstSelect(String Query, ref DBManager objDAL)
    {
        objDAL.ExecuteReader(CommandType.Text, Query);
    }
    public void grd_Mst_FillGrd(String Query, ref DataSet dtType, DBManager ObjDAL)
    {
        dtType = ObjDAL.ExecuteDataSet(CommandType.Text, Query);
    }
    public void grd_Mst_Filldt(String Query, ref DataTable dtType, DBManager ObjDAL)
    {
        dtType = ObjDAL.ExecuteTable(CommandType.Text, Query);
    }
    public void Ref_AdjDtl(String flag, int Table_Id, int Adj_Id, String Reg_Id, String Patient_Id, String Customer_Id, String Adjed_Bl_Id, String Adjing_Bl_Id, decimal Adj_Amt, int instituteId, String SessionID, String UserID, DateTime UEDate, decimal Return_Amt, int Is_Pt, String Drug_St_Id, int St_Typ, int Refund, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("Table_Id", Table_Id);
                com.Parameters.AddWithValue("Adj_Id", Adj_Id);
                com.Parameters.AddWithValue("Reg_Id", Reg_Id);
                com.Parameters.AddWithValue("Patient_Id", Patient_Id);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);
                com.Parameters.AddWithValue("Adjed_Bl_Id", Adjed_Bl_Id);
                com.Parameters.AddWithValue("Adjing_Bl_Id", Adjing_Bl_Id);
                com.Parameters.AddWithValue("Adj_Amt", Adj_Amt);
                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.Parameters.AddWithValue("Return_Amt", Return_Amt);
                com.Parameters.AddWithValue("Is_Pt", Is_Pt);
                com.Parameters.AddWithValue("Drug_St_Id", Drug_St_Id);
                com.Parameters.AddWithValue("St_Typ", St_Typ);
                com.Parameters.AddWithValue("Refund", Refund);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_Hsp_Ref_Adj_Dtl";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }
    }
    public void Drg_NoDues(String flag, String Reg_Id, String Patient_Id, String Customer_Id, int instituteId, String SessionID, String UserID, DateTime UEDate, String Drug_St_Id, int St_Typ, int Rt_Id, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);

                com.Parameters.AddWithValue("Reg_Id", Reg_Id);
                com.Parameters.AddWithValue("Patient_Id", Patient_Id);
                com.Parameters.AddWithValue("Customer_Id", Customer_Id);

                com.Parameters.AddWithValue("InstituteID", instituteId);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);

                com.Parameters.AddWithValue("Drug_St_Id", Drug_St_Id);
                com.Parameters.AddWithValue("St_Typ", St_Typ);
                com.Parameters.AddWithValue("Rt_Id", Rt_Id);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SP_Hsp_Drug_Str_Bill";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }
    }

    #endregion

    #region CompMst
    public void CompMst_Save(string flag, Int32 comp_id, string comp_name, string drugs, Int32 comp_detail_id, Int32 InstituteID, string SessionID, string UserID, ref string RetSuccess)
    {

        //DrugMst_Save(flag, Drug_Id, Drug_Nm, Drug_Desc, InstituteID, SessionID, UserID, ref RetSuccess);

        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("comp_id", comp_id);
                com.Parameters.AddWithValue("comp_name", comp_name);
                com.Parameters.AddWithValue("drugs", drugs);
                com.Parameters.AddWithValue("comp_detail_id", comp_detail_id);
                com.Parameters.AddWithValue("InstituteID", InstituteID);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_Hsp_Composition_New";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }

    public void Comp_MstDup(String Query, ref DBManager ObjDAL)
    {
        ObjDAL.ExecuteReader(CommandType.Text, Query);
    }
    public void Comp_MstSelect(String Query, ref DBManager objDAL)
    {
        objDAL.ExecuteReader(CommandType.Text, Query);
    }
    #endregion

    #region Prod_Mst
    public void ProdMst_Save(string flag, Int32 Medi_Id, string Medi_Nm, string Medi_Comp, string Mrk_Del, Int32 InstituteID, string SessionID, string UserID, Int32 Prod_Typ_Id, Int32 Prod_Cat_Id, Int32 Table_id, ref string RetSuccess)
    {
        using (SqlCommand com = new SqlCommand())
        {
            using (SqlConnection con = new SqlConnection(ReturnConString()))
            {

                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("flag", flag);
                com.Parameters.AddWithValue("RetSuccess", 0).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("Fields", null);
                com.Parameters.AddWithValue("Where", null);
                com.Parameters.AddWithValue("Medi_Id", Medi_Id);
                com.Parameters.AddWithValue("Medi_Nm", Medi_Nm);
                com.Parameters.AddWithValue("Medi_Comp", Medi_Comp);
                com.Parameters.AddWithValue("Mrk_Del", Mrk_Del);
                com.Parameters.AddWithValue("InstituteID", InstituteID);
                com.Parameters.AddWithValue("SessionID", SessionID);
                com.Parameters.AddWithValue("UserID", UserID);
                com.Parameters.AddWithValue("UEDate", DateTime.Today.Date);
                com.Parameters.AddWithValue("Prod_Typ_Id", Prod_Typ_Id);
                com.Parameters.AddWithValue("Prod_Cat_Id", Prod_Cat_Id);
                com.Parameters.AddWithValue("Table_id", Table_id);

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_Hsp_Product_Mst_New";
                com.ExecuteNonQuery();
                RetSuccess = com.Parameters["RetSuccess"].Value.ToString();
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
                con.Dispose();

            }
        }

    }
    public void Prod_MstSelect(String Query, ref DBManager objDAL)
    {
        objDAL.ExecuteReader(CommandType.Text, Query);
    }

    #endregion

    #region IMT
    protected NewDAL.DBManager IMT_FillGrid(String flag,Int32 Store_Loc,Int32 InstId)
    {
       ObjDb=ReturnDALConString();
        ObjDb.CreateParameters(3);
        ObjDb.AddParameters(0,"flag",flag,DbType.String);
        ObjDb.AddParameters(1,"FromStore",Store_Loc,DbType.Int32);
        ObjDb.AddParameters(2,"InstId",InstId,DbType.Int32);

        ObjDb.ExecuteReader(CommandType.StoredProcedure,"SP_IMT");

        ObjDb.Command.Parameters.Clear();
        return ObjDb;
    }
    protected String Gen_IMT_No_(Int32 InstId, String IMT_No, NewDAL.DBManager ObjDb)
    {
        ObjDb.CreateParameters(3);
              
        ObjDb.AddParameters(0, "InstId", InstId, DbType.Int32);
        ObjDb.AddParameters(1, "prefixtag", "IMT", DbType.String);
        ObjDb.AddParameters(2, "IMT_No", IMT_No, DbType.String);
        IMT_No = ObjDb.ExecuteScalar(CommandType.StoredProcedure, "Gen_IMTNo").ToString();
        ObjDb.Command.Parameters.Clear();
        return IMT_No;
    }
    protected void IMT_Save_Mst_(String flag,Int32 Id,Int32 InstId,String IMT_No,DateTime IMT_Date,Int32 FromOrg,Int32 ToOrg,Int32 FromStore,Int32 ToStore,Int32 UserId,ref Int32 IMT_Mst_Id,ref String RetSuccess, NewDAL.DBManager ObjDb)
    {
        //ObjDb = ReturnDALConString();
        ObjDb.CreateParameters(12);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "Id", Id, DbType.Int32);
        ObjDb.AddParameters(2, "InstId", InstId, DbType.Int32);
        ObjDb.AddParameters(3, "RetSuccess", "0", DbType.String,ParameterDirection.Output);
        ObjDb.AddParameters(4, "IMT_No", IMT_No, DbType.String);
        ObjDb.AddParameters(5, "IMT_Date", IMT_Date, DbType.DateTime);
        ObjDb.AddParameters(6, "FromOrg", FromOrg, DbType.Int32);
        ObjDb.AddParameters(7, "ToOrg", ToOrg, DbType.String);
        ObjDb.AddParameters(8, "FromStore", FromStore, DbType.Int32);
        ObjDb.AddParameters(9, "ToStore", ToStore, DbType.Int32);
        ObjDb.AddParameters(10, "UserId", UserId, DbType.Int32);
        ObjDb.AddParameters(11, "IMT_Mst_Id", IMT_Mst_Id, DbType.Int32, ParameterDirection.Output);
        ObjDb.ExecuteNonQuery(CommandType.StoredProcedure, "SP_IMT");
        RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDb.Command).Parameters["@RetSuccess"].Value.ToString();
        IMT_Mst_Id = Int32.Parse(((System.Data.SqlClient.SqlCommand)ObjDb.Command).Parameters["@IMT_Mst_Id"].Value.ToString() == string.Empty ? "0" : ((System.Data.SqlClient.SqlCommand)ObjDb.Command).Parameters["@IMT_Mst_Id"].Value.ToString());
        ObjDb.Command.Parameters.Clear();
    }

    protected void IMT_Save_Child_(String flag, Int32 Id, Int32 InstId,  Int32 Ctrl_Id, Decimal IMT_Qty, Int32 UnitId, Int32 FromOrg, Int32 ToOrg, Int32 FromStore, Int32 ToStore, ref String RetSuccess, NewDAL.DBManager ObjDb)
    {
        //ObjDb = ReturnDALConString();Int32 InstId,
        ObjDb.CreateParameters(11);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "Id", Id, DbType.Int32);
        ObjDb.AddParameters(2, "InstId", InstId, DbType.Int32);
        ObjDb.AddParameters(3, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
        ObjDb.AddParameters(4, "Ctrl_Id", Ctrl_Id, DbType.Int32);
        ObjDb.AddParameters(5, "IMT_Qty", IMT_Qty, DbType.Decimal);
        ObjDb.AddParameters(6, "UnitId", UnitId, DbType.Int32);
        ObjDb.AddParameters(7, "FromOrg", FromOrg, DbType.Int32);
        ObjDb.AddParameters(8, "ToOrg", ToOrg, DbType.Int32);
        ObjDb.AddParameters(9, "FromStore", FromStore, DbType.Int32);
        ObjDb.AddParameters(10, "ToStore", ToStore, DbType.Int32);
        ObjDb.ExecuteNonQuery(CommandType.StoredProcedure, "SP_IMT");
        RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDb.Command).Parameters["@RetSuccess"].Value.ToString();
        ObjDb.Command.Parameters.Clear();
    }
    #endregion

    #region RFQ Report
    public void GetRfqDtls_(Int32 RFQId, Int32 InstID, Int32 SupplierID, DBManager ObjDAL, ref DataTable DT)
    {
        ObjDAL.CreateParameters(4);
        ObjDAL.AddParameters(0, "flag", "RFQ", DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "RFQId", RFQId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "SupplierID", SupplierID, DbType.Int32, ParameterDirection.Input);
        DT = ObjDAL.ExecuteTable(CommandType.StoredProcedure, "Set_Logo");
        ObjDAL.Command.Parameters.Clear();        
    }
    #endregion

    #region RFQ Arrival Entry
    //-----------------Save Items Detail-------------------------
    protected void RFQArvl_ItemSave_(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, Int32 PRID, Decimal Price, Decimal Tax, Decimal Discount, Decimal Insurance, Boolean IsDisc_Perc, ref String RetSuccess, NewDAL.DBManager ObjDb)
    {
        ObjDb.CreateParameters(11);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "InstId", InstId, DbType.Int32);
        ObjDb.AddParameters(2, "RFQID", RFQID, DbType.Int32);
        ObjDb.AddParameters(3, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
        ObjDb.AddParameters(4, "SupplierID", SupplierID, DbType.Int32);
        ObjDb.AddParameters(5, "PRID", PRID, DbType.Int32);
        ObjDb.AddParameters(6, "Price", Price, DbType.Decimal);
        ObjDb.AddParameters(7, "Tax", Tax, DbType.Decimal);
        ObjDb.AddParameters(8, "Discount", Discount, DbType.Decimal);
        ObjDb.AddParameters(9, "Insurance", Insurance, DbType.Decimal);
        ObjDb.AddParameters(10, "IsDisc_Perc", IsDisc_Perc, DbType.Boolean);
        SqlDataReader dr = (SqlDataReader)ObjDb.ExecuteReader(CommandType.StoredProcedure, "SP_Pur_RFQ");
        while (dr.Read())
        {
            RetSuccess = dr.GetString(0).ToString();
        }
        dr.Dispose();
        dr.Close();
        ObjDb.Command.Parameters.Clear();
    }
    //-----------------Save Suppliers Detail-------------------------
    protected void RFQArvl_SuppSave_(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, String DeliveryMode, DateTime Delivery_Date, Decimal Excise_Duty, Decimal CstVat, Decimal Frieght, String DeliveryTerms, String PaymentTerms, String Other, ref String RetSuccess, NewDAL.DBManager ObjDb)
    {

        ObjDb.CreateParameters(13);
        ObjDb.AddParameters(0, "flag", flag, DbType.String);
        ObjDb.AddParameters(1, "InstId", InstId, DbType.Int32);
        ObjDb.AddParameters(2, "RFQID", RFQID, DbType.Int32);
        ObjDb.AddParameters(3, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
        ObjDb.AddParameters(4, "SupplierID", SupplierID, DbType.Int32);
        ObjDb.AddParameters(5, "DeliveryMode", DeliveryMode, DbType.String);
        ObjDb.AddParameters(6, "Delivery_Date", Delivery_Date, DbType.DateTime);
        ObjDb.AddParameters(7, "Excise_Duty", Excise_Duty, DbType.Decimal);
        ObjDb.AddParameters(8, "CstVat", CstVat, DbType.Decimal);
        ObjDb.AddParameters(9, "Frieght", Frieght, DbType.Decimal);
        ObjDb.AddParameters(10, "DeliveryTerms", DeliveryTerms, DbType.String);
        ObjDb.AddParameters(11, "PaymentTerms", PaymentTerms, DbType.String);
        ObjDb.AddParameters(12, "Other", Other, DbType.String);
        SqlDataReader dr = (SqlDataReader)ObjDb.ExecuteReader(CommandType.StoredProcedure, "SP_Pur_RFQ");
        while (dr.Read())
        {
            RetSuccess = dr.GetString(0).ToString();
        }
        dr.Dispose();
        dr.Close();
        //RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDb.Command).Parameters["@RetSuccess"].Value.ToString();
        ObjDb.Command.Parameters.Clear();
    }

    #endregion

    #region Get All Arrived Suppliers
    protected void Get_ArvdSupp_(String flag, Int32 InstId, String Condition, ref NewDAL.DBManager ObjDb)
    {
        ObjDb.CreateParameters(3);
        ObjDb.AddParameters(0,"flag",flag,DbType.String);
        ObjDb.AddParameters(1, "InstId", InstId, DbType.Int32);
        ObjDb.AddParameters(2, "Condition", Condition, DbType.String);

        ObjDb.ExecuteReader(CommandType.StoredProcedure,"Fill_RFQ");
    }
    #endregion

    #region PO Through RFQ
    //------------------Get Items Details of a RFQ for PO--------------------------
    protected void GetItmDtls_PO_(String flag, Int32 InstId, Int32 RFQID, Int32 SupplierID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(4);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "RFQID", RFQID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "SupplierID", SupplierID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_Fill_POProduct");
        ObjDAL.Command.Parameters.Clear();
    }
    //------------------Get Items Details on PO Search--------------------------
    protected void GetDtls_POSrch_(String flag, Int32 InstId, Int32 POID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "POID", POID, DbType.Int32, ParameterDirection.Input);       
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "sp_Fill_POProduct");
        ObjDAL.Command.Parameters.Clear();
    }
    //---------------------RFQ PO Master Save-------------------------------------------------------------------
    protected void RFQ_POSave_(String flag, Int32 InstId, Int32 POId, String POCode, DateTime PODate, Decimal Shipping_Amt, Decimal Tot_Payable_Amt, Decimal Paid_Amt, Boolean IsPaid, Boolean Status, Boolean IsArrived, String Comment, String Note, Int32 CurrencyId, ref Int32 PId, ref string RetSuccess, Decimal Excise_Duty, String Type_C_V, Decimal CstVat, Int32 SiteID, Int32 UserId, String TermsCondition, String Session,Int32 SupplierID, NewDAL.DBManager ObjDAL)
    {
        DataSet ds = new DataSet();
        ObjDAL.CreateParameters(25);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        //ObjDAL.AddParameters(1,"RetSuccess","0", DbType.String, ParameterDirection.Output);
        ObjDAL.AddParameters(1, "fields", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "Where", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(4, "POId", POId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(5, "POCode", POCode, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(6, "PODate", PODate, DbType.DateTime, ParameterDirection.Input);       
        ObjDAL.AddParameters(7, "Shipping_Amt", Shipping_Amt, DbType.Decimal, ParameterDirection.Input);       
        ObjDAL.AddParameters(8, "Tot_Payable_Amt", Tot_Payable_Amt, DbType.Decimal, ParameterDirection.Input);        
        ObjDAL.AddParameters(9, "Paid_Amt", Paid_Amt, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(10, "IsPaid", IsPaid, DbType.Boolean, ParameterDirection.Input);
        ObjDAL.AddParameters(11, "Status", Status, DbType.Boolean, ParameterDirection.Input);
        ObjDAL.AddParameters(12, "IsArrived", IsArrived, DbType.Boolean, ParameterDirection.Input);
        ObjDAL.AddParameters(13, "Comment", Comment, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(14, "Note", Note, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(15, "CurrencyId", CurrencyId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(16, "Excise_Duty", Excise_Duty, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(17, "Type_C_V", Type_C_V, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(18, "CstVat", CstVat, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(19, "SiteID", SiteID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(20, "PId", 0, DbType.Int32, ParameterDirection.Output);
        ObjDAL.AddParameters(21, "UserId", UserId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(22, "TermsCondition", TermsCondition, DbType.String, ParameterDirection.Input);        
        ObjDAL.AddParameters(23, "Session", Session, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(24, "Com_Manu_Ven_Id", SupplierID, DbType.Int32, ParameterDirection.Input);
        //ObjDAL.ExecuteNonQuery(CommandType.StoredProcedure, "SUID_POrder");
        //RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["@RetSuccess"].Value.ToString();
        
        //PId = Int32.Parse(((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["@PId"].Value.ToString());
        //ObjDAL.Command.Parameters.Clear();

        ds = (DataSet)ObjDAL.ExecuteDataSet(CommandType.StoredProcedure, "SUID_POrder");

        RetSuccess = ds.Tables[1].Rows[0]["ret"].ToString();
        PId = Convert.ToInt32(ds.Tables[0].Rows[0]["pid"].ToString());
        ObjDAL.Command.Parameters.Clear();

      
    }
    //---------------------RFQ PO Child Save-------------------------------------------------------------------
    protected void RFQ_POChildSave_(String flag, Int32 InstId, Int32 POId, Int32 RFQChild_Id, Decimal Quantity, Decimal Price_Per_Unit, Decimal Price_Total, Decimal Tax_Amt, Decimal Discount, Decimal Frieght, Decimal Insurance, Decimal Excise_Duty, Decimal Price_Tax_Total, Int32 Unit_Id, String Deliv_Terms, String Pmt_Terms, String Other_Levies, Int32 CtrlID, String DelMode, DateTime DelDate, Decimal BalQty, ref string RetSuccess, Int32 UserId,Boolean IsDisc_Perc, NewDAL.DBManager ObjDAL)
    {

        DataSet ds = new DataSet();
        ObjDAL.CreateParameters(25);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        //ObjDAL.AddParameters(1, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
        ObjDAL.AddParameters(1, "fields", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "Where", null, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "InstId", InstId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(4, "POId", POId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(5, "RFQChild_Id", RFQChild_Id, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(6, "Quantity", Quantity, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(7, "Price_Per_Unit", Price_Per_Unit, DbType.Decimal, ParameterDirection.Input);
        
        ObjDAL.AddParameters(8, "Price_Total", Price_Total, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(9, "Tax_Amt", Tax_Amt, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(10, "Discount", Discount, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(11, "Frieght", Frieght, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(12, "Insurance", Insurance, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(13, "Excise_Duty", Excise_Duty, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(14, "Price_Tax_Total", Price_Tax_Total, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(15, "Unit_Id", Unit_Id, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(16, "Deliv_Terms", Deliv_Terms, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(17, "Pmt_Terms", Pmt_Terms, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(18, "Other_Levies", Other_Levies, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(19, "CtrlID", CtrlID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(20, "DeliveryMode", DelMode, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(21, "DeliveryDate", DelDate, DbType.DateTime, ParameterDirection.Input);
        ObjDAL.AddParameters(22, "Bal_Qty", BalQty, DbType.Decimal, ParameterDirection.Input);
        ObjDAL.AddParameters(23, "UserId", UserId, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(24, "IsDisc_Perc", IsDisc_Perc, DbType.Int32, ParameterDirection.Input);
        //ObjDAL.ExecuteNonQuery(CommandType.StoredProcedure, "SUID_POrder");
        //RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["@RetSuccess"].Value.ToString();
        //ObjDAL.Command.Parameters.Clear();

        ds = (DataSet)ObjDAL.ExecuteDataSet(CommandType.StoredProcedure, "SUID_POrder");

        RetSuccess = ds.Tables[1].Rows[0]["ret"].ToString();
        //PId = Convert.ToInt32(ds.Tables[0].Rows[0]["pid"].ToString());
        ObjDAL.Command.Parameters.Clear();

    }
    //------------------Fill PO Grid--------------------------
    protected void Fill_POFileGrid_(String flag, Int32 InstID, Int32 POID, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "POID", POID, DbType.Int32, ParameterDirection.Input);       
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_POrder");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion
    #region Update Client Status
    protected void Update_ClientStatus_(String flag, Int32 InstID, String Status,String Condition,ref String RetSuccess, DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(5);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "status", Status, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(3, "Condition", Condition, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(4, "RetSuccess", "0", DbType.String, ParameterDirection.Output);
        ObjDAL.ExecuteNonQuery(CommandType.StoredProcedure, "SUID_Client_Regs");
        RetSuccess = ((System.Data.SqlClient.SqlCommand)ObjDAL.Command).Parameters["@RetSuccess"].Value.ToString();
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion
    #region Select Allocated Budget
    protected void BdgtAllc_Select_(String flag, Int32 InstID, Int32 Budget_Id, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "Budget_Id", Budget_Id, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Budget");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion   

    #region Fill Grid
    protected void Fill_Grid_(String SP_Name, String flag, Int32 InstID, String Condition, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(2);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstID, DbType.Int32, ParameterDirection.Input);
       // ObjDAL.AddParameters(2, "Condition", Condition, DbType.String, ParameterDirection.Input);        
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, SP_Name);
        ObjDAL.Command.Parameters.Clear();

        //((SqlDataReader)ObjDAL.DataReader).OfType<
    }
    #endregion  
 
    #region Budget Release Select Process
    protected void BdgtRls_Select_(String flag, Int32 InstID, Int32 Budget_Id, ref DBManager ObjDAL)
    {
        ObjDAL.CreateParameters(3);
        ObjDAL.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDAL.AddParameters(1, "InstId", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDAL.AddParameters(2, "Budget_Id", Budget_Id, DbType.Int32, ParameterDirection.Input);
        ObjDAL.DataReader = ObjDAL.ExecuteReader(CommandType.StoredProcedure, "SUID_Budget_Release");
        ObjDAL.Command.Parameters.Clear();
    }
    #endregion   

    #region Stock Detail Report
    protected void Get_StockDtlRpt_(String flag, Int32 InstID, String Fields, String Condition, ref DBManager ObjDal)
    {
        ObjDal.CreateParameters(4);
        ObjDal.AddParameters(0, "flag", flag, DbType.String, ParameterDirection.Input);
        ObjDal.AddParameters(1, "InstID", InstID, DbType.Int32, ParameterDirection.Input);
        ObjDal.AddParameters(2, "Fields", Fields, DbType.String, ParameterDirection.Input);
        ObjDal.AddParameters(3, "Condition", Condition, DbType.String, ParameterDirection.Input);
        ObjDal.DataReader = ObjDal.ExecuteReader(CommandType.StoredProcedure, "Set_Logo");
    }
    #endregion
}
