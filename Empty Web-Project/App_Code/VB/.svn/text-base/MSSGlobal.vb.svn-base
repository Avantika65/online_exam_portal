Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.IO
Imports System.Configuration.ConfigurationManager
Imports System.Globalization
Imports MSS
Imports System.Web.Services
Imports System
Imports System.Web.UI.WebControls
Imports System.Web.UI

Namespace MSSGlobal
    Public Class GeneralUtilities

        Public Function DataSetBind(ByVal ds As DataSet, ByVal objCon As OleDbConnection) As DataSet
            Dim cnt As Int16 = 0
            Dim dSet As New DataSet

            For cnt = 0 To ds.Tables(0).Rows.Count - 1
                Dim sqlFHTID As String = "select * from feeheadtransactionchild where feeheadtransaction_id=" & ds.Tables(0).Rows(cnt).Item("feeheadtransaction_id")
                Dim da As New OleDbDataAdapter(sqlFHTID, objCon)
                Dim ds1 As New DataSet
                da.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Dim cnt1 As Int16 = 0
                    For cnt1 = 0 To ds1.Tables(0).Rows.Count - 1

                    Next
                End If


            Next

        End Function
        Public Function SearchValue(ByVal requiredField As String, ByVal tablename As String, ByVal condition As String, ByVal chkCon As OleDbConnection) As String
            Dim result As String
            'Dim chkCon As New OleDb.OleDbConnection(connectString)
            'chkCon.Open()
            Dim chkda As New OleDbDataAdapter("select " & requiredField & " from " & tablename & " where " & condition, chkCon)
            Dim chkds As New DataSet
            chkda.Fill(chkds, "result")
            If chkds.Tables(0).Rows.Count > 0 Then
                result = chkds.Tables(0).Rows(0).Item(0)
            Else
                result = String.Empty
            End If
            chkda.Dispose()
            chkds.Dispose()
            Return result
            'chkCon.Close()
            'chkCon.Dispose()

        End Function
        Sub GenearteID(ByVal idfield As String, ByVal table As String, ByVal txtcode As System.Web.UI.HtmlControls.HtmlInputHidden, ByVal txtb As TextBox, ByVal session As String, ByVal codefield As String)

            Dim con As New OleDb.OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
            Dim com As New OleDb.OleDbCommand
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select coalesce(max(convert(int," + idfield + ")),'0',max(convert(int," + idfield + " ))) from" + " " + table
            Dim tmpstr As String
            tmpstr = com.ExecuteScalar
            txtcode.Value = IIf(Val(tmpstr) = 0, 1, Val(tmpstr) + 1)
            com.Dispose()
            Dim maxno As Integer
            Dim da As New OleDb.OleDbDataAdapter("select distinct    " + codefield + " from " + "  " + table, con)
            Dim ds As New DataSet
            da.Fill(ds, "TmpIndent")
            Dim s As String
            If ds.Tables(0).Rows.Count > 0 Then
                s = ds.Tables(0).Rows(0).Item(0)
                Dim i As Integer
                Dim arr As System.Array
                maxno = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    arr = Split(ds.Tables(0).Rows(i).Item(0), "-")
                    If maxno < Val(arr(2)) Then
                        maxno = Val(arr(2))
                    End If
                Next
            Else
                maxno = 0
            End If
            txtb.Text = "Cir" & "-" & session & "-" & maxno + 1
            con.Close()
            con.Dispose()
        End Sub
        Sub GenearteID(ByVal idfield As String, ByVal table As String, ByVal MessagePrefix As String, ByVal txtcode As System.Web.UI.HtmlControls.HtmlInputHidden, ByVal txtb As TextBox, ByVal session As String, ByVal codefield As String)

            Dim con As New OleDb.OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
            Dim com As New OleDb.OleDbCommand
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            com.Connection = con
            com.CommandType = CommandType.Text
            com.CommandText = "select coalesce(max(convert(int," + idfield + ")),'0',max(convert(int," + idfield + " ))) from" + " " + table
            Dim tmpstr As String
            tmpstr = com.ExecuteScalar
            txtcode.Value = IIf(Val(tmpstr) = 0, 1, Val(tmpstr) + 1)
            com.Dispose()
            Dim maxno As Integer
            Dim da As New OleDb.OleDbDataAdapter("select distinct    " + codefield + " from " + "  " + table, con)
            Dim ds As New DataSet
            da.Fill(ds, "TmpIndent")
            Dim s As String
            If ds.Tables(0).Rows.Count > 0 Then
                s = ds.Tables(0).Rows(0).Item(0)
                Dim i As Integer
                Dim arr As System.Array
                maxno = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    arr = Split(ds.Tables(0).Rows(i).Item(0), "-")
                    If maxno < Val(arr(2)) Then
                        maxno = Val(arr(2))
                    End If
                Next
            Else
                maxno = 0
            End If
            txtb.Text = MessagePrefix & "-" & session & "-" & maxno + 1
            con.Close()
            con.Dispose()
        End Sub
        Sub PopulateRadioBoxList(ByVal ctrlID As RadioButtonList, ByVal TextField As String, ByVal ValueField As String, ByVal qryString As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()

            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = TextField
                ctrlID.DataValueField = ValueField
                ctrlID.DataBind()
                '  ctrlID.Items.Insert(0, "ALL")

            End If
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateCheckBoxListbyDAL(ByVal ctrlID As CheckBoxList, ByVal TextField As String, ByVal ValueField As String, ByVal qryString As String, ByVal obj As NewDAL.DBManager)

            Dim ds As New DataSet
            ds = obj.ExecuteDataSet(CommandType.Text, qryString)
            ctrlID.Items.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                ctrlID.DataSource = ds
                ctrlID.DataTextField = TextField
                ctrlID.DataValueField = ValueField
                ctrlID.DataBind()
            End If
            ds.Dispose()
        End Sub
        Sub PopulateRadioBoxListbyDAL(ByVal ctrlID As RadioButtonList, ByVal TextField As String, ByVal ValueField As String, ByVal qryString As String, ByVal obj As NewDAL.DBManager)
            
            Dim ds As New DataSet
            ds = obj.ExecuteDataSet(CommandType.Text, qryString)
            ctrlID.Items.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                ctrlID.DataSource = ds
                ctrlID.DataTextField = TextField
                ctrlID.DataValueField = ValueField
                ctrlID.DataBind()
            End If
            ds.Dispose()
        End Sub
        Public Function returnString(ByVal ds As DataSet, ByVal objCon As OleDbConnection) As String
            Dim cnt As Int16 = 0
            Dim retStr As String = Nothing

            For cnt = 0 To ds.Tables(0).Rows.Count - 1
                If String.IsNullOrEmpty(retStr) Then
                    retStr = ds.Tables(0).Rows(cnt).Item("feeheadtransaction_id")
                Else
                    retStr = retStr & "," & ds.Tables(0).Rows(cnt).Item("feeheadtransaction_id")
                End If
            Next
            Return retStr
        End Function

       
        Public Function decrypt(ByVal val As String, ByVal seed As String) As String
            Dim KEY_64() As Byte = Convert.FromBase64String(seed)
            Dim IV_64() As Byte = {55, 103, 246, 79, 36, 99, 167, 3}
            If val <> String.Empty Then
                Dim cryptoProvider As New DESCryptoServiceProvider
                Dim buffer() As Byte = Convert.FromBase64String(val)
                Dim ms As New MemoryStream(buffer)
                Dim cs As New CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read)
                Dim sr As New StreamReader(cs)
                Return sr.ReadToEnd()
            Else
                Return ""
            End If
        End Function
        Public Function CreateSalt(ByVal size As Integer) As Byte()
            '// Generate a cryptographic random number using the cryptographic service provider
            Dim rng As New RNGCryptoServiceProvider
            Dim buff(size - 1) As Byte
            rng.GetBytes(buff)
            '// Return a Base64 string representation of the random number
            Return buff
        End Function
        Public Function encrypt(ByVal val As String, ByVal seed() As Byte) As String
            Dim KEY_64() As Byte
            KEY_64 = seed
            Dim IV_64() As Byte = {55, 103, 246, 79, 36, 99, 167, 3}
            If val <> String.Empty Then
                Dim cryptoProvider As New DESCryptoServiceProvider
                Dim ms As New MemoryStream
                Dim cs As New CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write)
                Dim sw As New StreamWriter(cs)
                sw.Write(val)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()
                Return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length))
            Else
                Return ""
            End If

        End Function
        Public Sub SetFocus(ByVal ControlName As String, ByVal aPage As System.Web.UI.Page)
            ' character 34 = "
            Dim script As String = _
              "<script language=" + Chr(34) + "javascript" + Chr(34) _
                                  + ">" + _
              "  var control = document.getElementById(" + Chr(34) + _
              ControlName + Chr(34) + ");" + _
              "  if( control != null ){control.focus();}" + _
              "</script>"
            aPage.RegisterStartupScript("Focus", script)
        End Sub

        Public Function checkChildExistancewc(ByVal idFld As String, ByVal tablename As String, ByVal condition As String, ByVal myConnection As OleDbConnection) As Boolean
            Dim result As Boolean
            Dim chkda As New OleDbDataAdapter("select " & idFld & " from " & tablename & " where " & condition, myConnection)
            Dim chkds As New DataSet
            chkda.Fill(chkds, "result")
            If chkds.Tables(0).Rows.Count > 0 Then
                result = True '  child exists
            Else
                result = False
            End If
            Return result
            chkda.Dispose()
            chkds.Dispose()
        End Function

        Public Sub NewMsgBox(ByVal msg As String, ByVal refP As Page)
            Dim lbl As New Label()
            Dim lb As String = "window.alert('" + msg + "')"
            lbl.Text = "<script language='javascript'>" & Environment.NewLine & "window.alert('" + msg + "')</script>"
            ScriptManager.RegisterClientScriptBlock(refP, refP.GetType, "UniqueKey", lb, True)
            refP.Controls.Add(lbl)
        End Sub
        Public Sub MsgBox(ByVal msg As String, ByVal refP As Page)
            Dim lbl As New Label()
            lbl.Text = "<script language='javascript'>" & Environment.NewLine & "window.alert('" + msg + "')</script>"
            refP.Controls.Add(lbl)
        End Sub

        Public Sub MsgBox1(ByVal msg As String, ByVal refP As Page, ByVal lbl As Label)
            '    Dim lbl As New Label()
            lbl.Text = "<script language='javascript'>" & Environment.NewLine & "window.alert('" + msg + "')</script>"
            '   refP.Controls.Add(lbl)
        End Sub

        Public Sub MsgLabel(ByVal msg As String, ByVal lbl As Label)
            lbl.Visible = True
            lbl.Text = msg
        End Sub

        Public Function GenerateID(ByVal strTablename As String, ByVal strFldname As String, ByVal objCom As OleDbCommand, ByVal objCon As OleDbConnection) As String
            Dim strID As String = String.Empty
            objCom.CommandText = "select coalesce(max(" & strFldname & "),'0',max(" & strFldname & ")) from " & strTablename
            strID = objCom.ExecuteScalar
            strID = IIf(Val(strID) = 0, 1, Val(strID) + 1)
            Return strID
        End Function
        Public Function GetID(ByVal strTablename As String, ByVal strFldname As String, ByVal strcheckCondition As String, ByVal objCom As OleDbCommand, ByVal objCon As OleDbConnection) As Integer
            Dim strResult As String = String.Empty
            Dim IntResult As Integer
            objCom.CommandText = "select " & strFldname & " from " & strTablename & " Where " & strcheckCondition
            strResult = objCom.ExecuteScalar
            If strResult = String.Empty Then
                IntResult = 0
            Else
                IntResult = CType(strResult, Integer)
            End If
            Return IntResult
        End Function
        Public Function CheckExistance(ByVal strTablename As String, ByVal strFldname As String, ByVal strcheckCondition As String, ByVal objCom As OleDbCommand, ByVal objCon As OleDbConnection) As Boolean
            Dim bolReturnValue As Boolean = False
            Dim strResult As String
            objCom.CommandText = "select " & strFldname & " from " & strTablename & " Where " & strcheckCondition
            strResult = objCom.ExecuteScalar
            If strResult <> Nothing Then
                bolReturnValue = True
            End If
            Return bolReturnValue
        End Function

        Public Function CheckExistance1(ByVal strTablename As String, ByVal strFldname As String, ByVal strcheckCondition As String, ByVal objCom As OleDbCommand) As Boolean
            Dim bolReturnValue As Boolean = False
            Dim strResult As String
            objCom.CommandText = "select " & strFldname & " from " & strTablename & " Where " & strcheckCondition
            strResult = IIf(objCom.ExecuteScalar Is DBNull.Value, Nothing, objCom.ExecuteScalar)
            objCom.Parameters.Clear()
            If strResult <> Nothing Then
                bolReturnValue = True
            End If
            Return bolReturnValue
        End Function
        Public Function getcurrency(ByVal id As Integer, ByVal objcon As OleDbConnection) As String

            Dim strResult As String

            'objcmd.CommandType = CommandType.Text
            'objcmd.CommandTimeout = 180
            'objcmd.CommandText = "Select Currency_ShortName from InstitutionInformation where Institution_ID=" & id & ""
            'strResult = objcmd.ExecuteScalar
            'If IsDBNull(strResult) Then
            '    strResult = String.Empty
            'End If
            'Return strResult

            Dim da As New OleDbDataAdapter("Select Currency_ShortName from InstitutionInformation where Institution_ID=" & id & "", objcon)
            Dim ds As New DataSet
            da.Fill(ds, "result")
            If ds.Tables(0).Rows.Count > 0 Then
                strResult = ds.Tables(0).Rows(0).Item(0)
            Else
                strResult = "Rs."
            End If
            Return strResult
        End Function
        'The following subroutine will be used to
        Public Function filllabel(ByVal strTablename As String, ByVal strFldname As String, ByVal strcheckCondition As String, ByVal objCom As OleDbCommand, ByVal objCon As OleDbConnection) As String
            'Dim bolReturnValue As Boolean = False
            Dim strResult As String
            objCom.CommandText = "select " & strFldname & " from " & strTablename & " Where " & strcheckCondition
            strResult = objCom.ExecuteScalar
            If strResult <> Nothing Then
                Return strResult
            Else
                Return ""
            End If

        End Function
        Sub PopulateDropDownList(ByVal ctrlID As DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()


            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()

            End If
            If Trim(strsetSelect) <> String.Empty Then
                ctrlID.Items.Insert(0, strsetSelect)
            End If
            ctrlID.SelectedIndex = 0
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateDDL(ByVal ctrlID As DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()


            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()

            End If
            ctrlID.SelectedIndex = 0
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateDropDownList5(ByVal ctrlID As DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()


            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()

            End If
            If Trim(strsetSelect) = String.Empty Then
                ctrlID.Items.Insert(0, strsetSelect)
            End If
            ctrlID.SelectedIndex = 0
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateDropDownList(ByVal ctrlID As System.Web.UI.HtmlControls.HtmlSelect, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()
            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()
            End If
            If Trim(strsetSelect) <> String.Empty Then
                ctrlID.Items.Insert(0, strsetSelect)
            End If
            ctrlID.SelectedIndex = 0
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateDropDownList1(ByVal ctrlID As System.Web.UI.WebControls.DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()
            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()
            End If
            If Trim(strsetSelect) <> String.Empty Then
                ctrlID.Items.Insert(0, strsetSelect)
            End If
            ctrlID.SelectedIndex = 0
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateDropDownListByDAL(ByVal ctrlID As System.Web.UI.WebControls.DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal obj As NewDAL.DBManager)
            Dim ds As New DataSet
            ds = obj.ExecuteDataSet(CommandType.Text, qryString)
            ctrlID.Items.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables(0)
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()
            End If
            If Trim(strsetSelect) <> String.Empty Then
                ctrlID.Items.Insert(0, strsetSelect)
            End If
            ctrlID.SelectedIndex = 0
            ds.Dispose()
        End Sub
        Sub PopulateDropDownListByDT(ByVal ctrlID As System.Web.UI.WebControls.DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal dt As DataTable, ByVal strsetSelect As String)

            If dt.Rows.Count > 0 Then
                ctrlID.DataSource = dt
                ctrlID.DataTextField = strTextField
                ctrlID.DataValueField = strValueField
                ctrlID.DataBind()
            End If
            If Trim(strsetSelect) <> String.Empty Then
                ctrlID.Items.Insert(0, strsetSelect)
            End If
            ctrlID.SelectedIndex = 0
            dt.Dispose()
        End Sub
        Sub PopulateGrid(ByVal ctrlID As GridView, ByVal objCom As OleDbCommand, ByVal strCommandtext As String)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = strCommandtext
            Dim ds As New DataSet                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataBind()
            Else
                Dim dt As New DataTable
                ctrlID.DataSource = dt
                ctrlID.DataBind()
                dt.Dispose()

            End If
            ctrlID.SelectedIndex = -1
            da.Dispose()
            ds.Dispose()
        End Sub
        Sub PopulateCheckBoxList(ByVal ctrlID As CheckBoxList, ByVal TextField As String, ByVal ValueField As String, ByVal qryString As String, ByVal objCom As OleDbCommand)
            objCom.Parameters.Clear()
            objCom.CommandType = CommandType.Text
            objCom.CommandTimeout = 180
            objCom.CommandText = qryString
            Dim ds As New DataSet
            Dim da As New OleDbDataAdapter
            da.SelectCommand = objCom
            da.Fill(ds, "Items")
            ctrlID.Items.Clear()

            If ds.Tables("Items").Rows.Count > 0 Then
                ctrlID.DataSource = ds.Tables("Items")
                ctrlID.DataTextField = TextField
                ctrlID.DataValueField = ValueField
                ctrlID.DataBind()
                '  ctrlID.Items.Insert(0, "ALL")

            End If
            da.Dispose()
            ds.Dispose()
        End Sub

        Sub resetGrid(ByVal grid As GridView)
            Dim dt As New DataTable
            grid.DataSource = dt
            grid.DataBind()
            dt.Dispose()
        End Sub
        Function PopulateDataset(ByVal sqlStr As String, ByVal tableName As String, ByVal myConnection As OleDbConnection) As DataSet
            Dim da As OleDbDataAdapter = Nothing
            Dim ds As DataSet = Nothing
            Try
                da = New OleDbDataAdapter(sqlStr, myConnection)
                ds = New DataSet()
                da.Fill(ds, tableName)
                Return ds
            Catch ex As Exception

            Finally
                da.Dispose()
                ' ds.Dispose()
            End Try
        End Function
    End Class
    Public Class insertLogin
        Public Function insertLoginFunc(ByVal sessionstr1 As String, ByVal tablename As String, ByVal sessionstr2 As String, ByVal txtstring As String, ByVal type As String, ByVal connStr As String)
            Dim chkCon As New OleDb.OleDbConnection(connStr)
            chkCon.Open()
            Dim dt As DateTime

            Dim classcom11 As New OleDbCommand("insert_LoginMaster_1", chkCon)
            classcom11.CommandType = CommandType.StoredProcedure

            classcom11.Parameters.Add(New OleDbParameter("@loginname_1", OleDbType.VarChar))
            classcom11.Parameters("@loginname_1").Value = sessionstr1
            classcom11.Parameters.Add(New OleDbParameter("@logindate_2", OleDbType.Date))
            classcom11.Parameters("@logindate_2").Value = Now.Date

            classcom11.Parameters.Add(New OleDbParameter("@logintime_3", OleDbType.VarChar))
            classcom11.Parameters("@logintime_3").Value = dt.Now.ToString("T")


            classcom11.Parameters.Add(New OleDbParameter("@tablename_4", OleDbType.VarChar))
            classcom11.Parameters("@tablename_4").Value = tablename


            classcom11.Parameters.Add(New OleDbParameter("@useraction_5", OleDbType.VarChar))
            classcom11.Parameters("@useraction_5").Value = type


            classcom11.Parameters.Add(New OleDbParameter("@id_6", OleDbType.VarChar))
            classcom11.Parameters("@id_6").Value = txtstring


            classcom11.Parameters.Add(New OleDbParameter("@sessionyr_7", OleDbType.VarChar))
            classcom11.Parameters("@sessionyr_7").Value = sessionstr2
            classcom11.ExecuteNonQuery()
            chkCon.Close()
            classcom11.Dispose()
        End Function
    End Class
End Namespace
