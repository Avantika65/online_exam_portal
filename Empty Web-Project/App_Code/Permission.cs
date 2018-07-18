using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for Permission
/// </summary>
public class Permission
{   //By Jeetendra Prajapati
   
	public Permission()
	{   	
	}
   
    public bool Add_edit_deletemenuPerm(string roleID, string menuID, string permission, string insertOp, string updateOp, string deleteOp, string flag, SqlCommand objCom)
    {
        bool returnFlag = true;

        objCom.CommandText = "menuPermissionSP";
        objCom.CommandType = CommandType.StoredProcedure;
        objCom.Parameters.Add(new SqlParameter("@roleID", SqlDbType.Int));
        objCom.Parameters["@roleID"].Value = roleID;

        objCom.Parameters.Add(new SqlParameter("@menuID", SqlDbType.Int));
        objCom.Parameters["@menuID"].Value = menuID;

        objCom.Parameters.Add(new SqlParameter("@permission", SqlDbType.Int));
        objCom.Parameters["@permission"].Value = permission;

        objCom.Parameters.Add(new SqlParameter("@insertOp", SqlDbType.Int));
        objCom.Parameters["@insertOp"].Value = insertOp;

        objCom.Parameters.Add(new SqlParameter("@updateOp", SqlDbType.Int));
        objCom.Parameters["@updateOp"].Value = updateOp;

        objCom.Parameters.Add(new SqlParameter("@deleteOp", SqlDbType.Int));
        objCom.Parameters["@deleteOp"].Value = deleteOp;

        //objCom.Parameters.Add(new SqlParameter("@masterOp", OleDbType.Integer));
        //objCom.Parameters["@masterOp"].Value = masterOp;

        //objCom.Parameters.Add(new SqlParameter("@slaveOp", OleDbType.Integer));
        //objCom.Parameters["@slaveOp"].Value = slaveOp;

        objCom.Parameters.Add(new SqlParameter("@flag", SqlDbType.NVarChar));
        objCom.Parameters["@flag"].Value = flag;

        //Try
        objCom.ExecuteNonQuery();
        objCom.Parameters.Clear();
        //Catch ex As Exception
        //    returnFlag = False
        //    Dim p As String
        //    p = ex.Message
        //End Try

        return returnFlag;
    }

    public int AssignRole(int id, int roleID, int instId, int sessionId, int deptId, int Prg_Desig_Id, int Yr_Sem_Id, string IndividualId, string flag, SqlCommand ObjCom)
    {
        int RetSuccess = 0;


        ObjCom.CommandType = CommandType.StoredProcedure;
        ObjCom.CommandText = "Insert_AssignRole";
        ObjCom.Parameters.Add("@id_1", SqlDbType.Int).Value = id;
        //ObjCom.Parameters.Add("@MGId_2", SqlDbType.Int).Value = MajorGroupID;
        ObjCom.Parameters.Add("@roleID_3", SqlDbType.Int).Value = roleID;
        ObjCom.Parameters.Add("@instId_4", SqlDbType.Int).Value = instId;
        ObjCom.Parameters.Add("@sessionId_5", SqlDbType.Int).Value = sessionId;
        ObjCom.Parameters.Add("@deptId_6", SqlDbType.Int).Value = deptId;
        ObjCom.Parameters.Add("@Prg_Desig_Id_7", SqlDbType.Int).Value = Prg_Desig_Id;
        ObjCom.Parameters.Add("@Yr_Sem_Id_8", SqlDbType.Int).Value = Yr_Sem_Id;
        ObjCom.Parameters.Add("@IndividualId_9", SqlDbType.VarChar).Value = IndividualId;
        ObjCom.Parameters.Add("@flag_10", SqlDbType.VarChar).Value = flag;
        ObjCom.Parameters.Add("@RetSuccess", SqlDbType.Int).Direction = ParameterDirection.Output;

        try
        {
            ObjCom.ExecuteNonQuery();

            int isSuccess = Int32.Parse(ObjCom.Parameters["@RetSuccess"].Value.ToString());
            RetSuccess = isSuccess;
            if (isSuccess == 1)
            {
                //RetSuccess = true;
            }
            else
            {
                //RetSuccess = false;
            }
        }
        catch (Exception ex)
        {
            string ms = ex.Message.ToString();
            //RetSuccess = false;
        }
        finally { }
        return RetSuccess;
    }
    
}
