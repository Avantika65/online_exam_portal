Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports System.Data.OleDb
Imports System
Public Class Dalclass
    Public Function Add_edit_deleteclass(ByVal classID As Integer, ByVal classcode As String, ByVal classname As String, ByVal compulsoryPaper As Integer, ByVal optionalPaper As Integer, ByVal EntryDate As DateTime, ByVal UID As String, ByVal FinYear As String, ByVal flag As String, ByVal isAuditRequired As String, ByVal inst As Integer, ByVal objCom As OleDbCommand) As Boolean
        Dim returnFlag As Boolean = True
        objCom.CommandType = CommandType.StoredProcedure
        objCom.CommandText = "insert_class_year_semester_1"

        objCom.Parameters.Add(New OleDbParameter("@class_id_1", OleDbType.Integer))
        objCom.Parameters("@class_id_1").Value = classID

        objCom.Parameters.Add(New OleDbParameter("@class_code_2", OleDbType.VarWChar))
        objCom.Parameters("@class_code_2").Value = classcode

        objCom.Parameters.Add(New OleDbParameter("@class_name_3", OleDbType.VarWChar))
        objCom.Parameters("@class_name_3").Value = classname

        objCom.Parameters.Add(New OleDbParameter("@compulsorypaper_4", OleDbType.Integer))
        objCom.Parameters("@compulsorypaper_4").Value = compulsoryPaper

        objCom.Parameters.Add(New OleDbParameter("@optionalpaper_5", OleDbType.Integer))
        objCom.Parameters("@optionalpaper_5").Value = optionalPaper

        objCom.Parameters.Add(New OleDbParameter("@session_year_6", OleDbType.VarWChar))
        objCom.Parameters("@session_year_6").Value = FinYear

        objCom.Parameters.Add(New OleDbParameter("@User_ID_7", OleDbType.VarWChar))
        objCom.Parameters("@User_ID_7").Value = UID

        objCom.Parameters.Add(New OleDbParameter("@inst_ID_8", OleDbType.Integer))
        objCom.Parameters("@inst_ID_8").Value = inst

        objCom.Parameters.Add(New OleDbParameter("@flag_9", OleDbType.VarChar))
        objCom.Parameters("@flag_9").Value = flag

        objCom.Parameters.Add(New OleDbParameter("@isAuditRequired_10", OleDbType.VarWChar))
        objCom.Parameters("@isAuditRequired_10").Value = isAuditRequired

        objCom.Parameters.Add(New OleDbParameter("@Entry_Date_11", OleDbType.Date))
        objCom.Parameters("@Entry_Date_11").Value = EntryDate

        Try
            objCom.ExecuteNonQuery()
        Catch ex As Exception
            returnFlag = False
            Dim p As String
            p = ex.Message
        End Try

        Return returnFlag
    End Function

End Class
