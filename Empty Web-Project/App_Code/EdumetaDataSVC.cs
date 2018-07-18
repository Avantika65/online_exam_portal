using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using NewDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EdumetaDataSVC" in code, svc and config file together.
//[ServiceContract(Namespace = "")]
//[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class EdumetaDataSVC  
{
    [OperationContract]
    public string InsertEduMetaDataForm(EduMetaDataDM.EduMetaData objEFM, Admin.AdministratorData.AuditDM audit)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        string f = "";
        try
        {
            objDB.CreateParameters(8);
            objDB.AddParameters(0, "EduID", objEFM.EduID, DbType.Int32);
            objDB.AddParameters(1, "Module", objEFM.Module, DbType.Int32);
            objDB.AddParameters(2, "Form", objEFM.Form, DbType.Int32);
            objDB.AddParameters(3, "Type1", objEFM.Type1, DbType.String);
            objDB.AddParameters(4, "CreateName", objEFM.CreateName, DbType.String);
            objDB.AddParameters(5, "Syntax", objEFM.Syntax, DbType.String);
            objDB.AddParameters(6, "DefaultValue", objEFM.DefaultValue, DbType.String);
            objDB.AddParameters(7, "flag", objEFM.Flag, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Edu_MetaData");
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", 0, DbType.Int32);
            objDB.AddParameters(1, "Form_Name", audit.Form_Name, DbType.String);
            objDB.AddParameters(2, "Action", audit.Action, DbType.String);
            objDB.AddParameters(3, "User_ID", audit.User_ID, DbType.String);
            objDB.AddParameters(4, "Entry_Date", audit.Entry_Date, DbType.String);
            objDB.AddParameters(5, "Record_ID", audit.Record_ID, DbType.String);
            objDB.AddParameters(6, "Entry_Time", audit.Entry_Time, DbType.String);
            objDB.AddParameters(7, "InstituteID", audit.InstituteID, DbType.Int32);
            objDB.AddParameters(8, "SessionID", audit.SessionID, DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "Audit_Insert");
            objDB.Transaction.Commit();
            if (objEFM.Flag == "N")
            {
                retv = "Record saved.";
            }
            else if (objEFM.Flag == "U")
            {
                retv = "Record Updated Successfully.";
            }
            else
            {
                retv = "Record deleted Successfully.";
            }
        }
        catch (Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = "Unable to save record :-" + ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }

    public class ModuleName : List<EduMetaDataDM.Module>
    {
    }
    [OperationContract]
    public ModuleName FillModuleType(int Flag)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "Flag", Flag, DbType.Int32);
        
        IDataReader dr = (IDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Module");
        ModuleName listOfTitle = new ModuleName();
        while (dr.Read())
        {
            var item = new EduMetaDataDM.Module();
            item.ID = Education.DataHelper.GetInt(dr, "ID");
            item.Title = Education.DataHelper.GetString(dr, "Title");
            listOfTitle.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        objDB = null;
        return listOfTitle;
    }

    public void DoWork()
    {
    }
}
