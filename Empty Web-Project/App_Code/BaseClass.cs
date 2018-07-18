﻿using System;
using System.Data;
using NewDAL;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BaseClass
/// </summary>


public class BaseClass : System.Web.UI.Page
{
    protected static string perm = null;
	public BaseClass()
	{
        Page.Theme = "Blue";
        //Page.Theme = "BlueBasic";
        Page.MaintainScrollPositionOnPostBack = true;
 	}
    public static string chkvalidity()
    {
        return ""; 
    }
    protected NewDAL.DBManager ReturnDALConString()
    {
        NewDAL.DBManager objDB = new NewDAL.DBManager();
        objDB.ConnectionString = ReturnConString();
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        return objDB;
    }
    protected bool CheckAuthontication()
    {
        bool IsAuthorized = false;
        if (Context.Session["U_Name"] != null)
        {
            if (!string.IsNullOrEmpty(Context.Session["U_Name"].ToString()))
            {
                IsAuthorized = true;
            }
        }
        else
        {
            IsAuthorized = false;
        }
        return IsAuthorized;
    }
    protected string ReturnConString()
    {
        return ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
    }
    protected void controlPerm(Button cmdI, Button cmdU, Button cmdD, string perm)
    {
        if (perm != null)
        {
            char[] separator = new char[] { '|' };
            string[] arr = perm.Split(separator);
            if (cmdI.Text.ToLower() != "update")
            {
                cmdI.Enabled = (arr[0].ToString() == "1" ? true : false);
            }
            else
            {
                cmdI.Enabled = (arr[1].ToString() == "1" ? true : false);
            }
            cmdD.Enabled = (arr[2].ToString() == "1" ? true : false);
            arr = null;
        }
    }
    protected DataSet Get_Form_Field_Perm(Int32 Inst_Id, Int32 Form_Id, Int32 User_Id, Int32 Role_Id)
    {
        SqlDataAdapter ad = null;
        DataSet ds = null;
        DbFunctions objDB = new DbFunctions();
        using (SqlConnection cn = new SqlConnection(ReturnConString()))
        {
            try
            {
                String Perm_Query = "Select MFS.FieldId,TableName,FieldName,ValueField ,FieldDataId,Individualid " +
                                    "from MenuFieldStruct as MFS,MenuFieldPerm as MFP, AssignRoles as AR,AssignRoleChild as ARC " +
                                    "where MFP.FieldId=MFS.FieldId and MenuId='" + Form_Id + "'and  Permission=1 and MFS.FieldId=ARC.FieldId and " +
                                    "AR.RoleId='" + Role_Id + "' and AR.instid=ARC.instid and ARC.instid='" + Inst_Id + "' and AR.id=ARC.assignroleId  and AR.Individualid='" + User_Id + "'";

                ad = new SqlDataAdapter(Perm_Query, cn);
                ds = new DataSet();
                ad.Fill(ds, "Table_List");

                foreach (DataRow dr in ds.Tables["Table_List"].Rows)
                {
                    Perm_Query = "Select Distinct [" + dr["FieldName"].ToString() + "],[" + dr["ValueField"].ToString() + "] From [" + dr["TableName"].ToString() + "] Where [" + dr["ValueField"].ToString() + "] in (" + dr["FieldDataId"].ToString() + ")";

                    ad = new SqlDataAdapter(Perm_Query, cn);
                    ad.Fill(ds, dr["TableName"].ToString());
                }
            }
            catch { }
            finally { ad.Dispose(); }
        }

        return ds;
    }
}
