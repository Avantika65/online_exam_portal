Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration.ConfigurationManager
Imports System.Security.Cryptography
Imports MSSGlobal
Imports System.Globalization
Imports System.Web.Services
Imports System.IO
Imports GeneralFunction
Imports ObjectVariables
Imports System.Web
Imports System.Web.HttpUtility
Imports NewDAL
Imports System
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient

Public Class CampClass
    Dim objgeneral As New MSSGlobal.GeneralUtilities
    ''' <summary>
    ''' To Get Single Value Based On SQL Query.
    ''' </summary>
    ''' <param name="str">SQL Query</param>
    ''' <param name="ret_value">Return Value</param>
    ''' <param name="page">Page</param>
    ''' <remarks></remarks>
    Public Sub Get_Detail(ByVal str As String, ByRef ret_value As String, ByVal page As Page)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()

        Try
            Dim Ad As New OleDbDataAdapter(str, con)
            Dim Ds As New DataSet
            Ad.Fill(Ds)
            If Ds.Tables(0).Rows.Count > 0 Then
                ret_value = Ds.Tables(0).Rows(0).Item(0)
            Else
                ret_value = ""
            End If
            Ds.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            objgeneral.NewMsgBox(ex.Message, page)
        End Try
    End Sub
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
    Public Function retCon1() As NewDAL.DBManager
        Dim obj2 As New NewDAL.DBManager
        Dim objEnum As New EnumHelper
        obj2.ConnectionString = ConnectionStrings("FeesManagementConn").ConnectionString()
        obj2.DBManager(DataAccessLayer.DataProvider.OleDb, obj2.ConnectionString)
        obj2.Open()
        Return obj2
    End Function
    Public Sub FillGrid(ByVal grd As GridView, ByVal st As String, ByVal obj As NewDAL.DBManager)
        Dim dt As New DataTable
        dt = obj.ExecuteTable(CommandType.Text, st)
        grd.DataSource = dt
        grd.DataBind()
    End Sub
    Public Sub Get_Detail(ByVal str As String, ByRef ret_value As String)
        Dim con As New SqlConnection(ConnectionStrings("FeesManagementConn").ConnectionString)
        con.Open()
        Try
            Dim Ad As New SqlClient.SqlDataAdapter(str, con)
            Dim Ds As New DataSet
            Ad.Fill(Ds)
            If Ds.Tables(0).Rows.Count > 0 Then
                ret_value = Ds.Tables(0).Rows(0).Item(0)
            Else
                ret_value = ""
            End If
            Ds.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            ' objgeneral.NewMsgBox(ex.Message, page)
        End Try
    End Sub
    ''' <summary>
    ''' To columns details reterival method
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="ret_value"></param>
    ''' <remarks></remarks>
    Public Sub Get_Detail_TwoColumn(ByVal str As String, ByRef ret_value As String, ByRef ret_value1 As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        Try
            Dim Ad As New OleDbDataAdapter(str, con)
            Dim Ds As New DataSet
            Ad.Fill(Ds)
            Dim i As Integer
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(0).Item(0)
                    ret_value1 = Ds.Tables(0).Rows(0).Item(1)
                Else
                    'If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                    ret_value = ret_value & "," & Ds.Tables(0).Rows(i).Item(0)
                    ret_value1 = ret_value1 & "," & Ds.Tables(0).Rows(i).Item(1)
                    'End If
                End If
            Next
            Ds.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            ' objgeneral.NewMsgBox(ex.Message, page)
        End Try
    End Sub
    Public Sub Get_Detail_TwoColumnAr(ByVal str As String, ByVal arr As String, ByRef ret_value As String, ByRef ret_value1 As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        Dim Ds As New DataSet
        Try
            Dim i As Integer
            Dim j As Integer
            Dim ar As System.Array
            ar = Strings.Split(arr, ",", -1, 0)
            For j = 0 To ar.Length - 1
                Dim str1 As String = str & "Fee_id=" & ar.GetValue(j)
                Dim Ad As New OleDbDataAdapter(str, con)
                Ad.Fill(Ds)
                For i = 0 To Ds.Tables(0).Rows.Count - 1
                    If ret_value = "" Then
                        ret_value = Ds.Tables(0).Rows(0).Item(0)
                        ret_value1 = Ds.Tables(0).Rows(0).Item(1)
                    Else
                        If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                            ret_value = ret_value & "," & Ds.Tables(0).Rows(i).Item(0)
                            ret_value1 = ret_value1 & "," & Ds.Tables(0).Rows(i).Item(1)
                        End If
                    End If
                Next
            Next

            Ds.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            ' objgeneral.NewMsgBox(ex.Message, page)
        End Try
    End Sub
    Public Function Find_Replace(ByVal ID As String, ByVal ID2 As String, ByVal dt As DataTable) As DataTable
        Dim arr As System.Array
        arr = Strings.Split(ID, ",", -1, 0)
        Dim arr1 As System.Array
        arr1 = Strings.Split(ID2, ",", -1, 0)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To arr.Length - 1
            For j = 0 To dt.Rows.Count - 1
                If dt.Rows(j).Item(0).ToString.Contains(arr.GetValue(i)) Then
                    Dim dr As DataRow = dt.Rows(j)
                    dt.Rows.Remove(dr)
                    dr = dt.NewRow
                    dr(0) = arr.GetValue(i).ToString
                    dr(1) = arr1.GetValue(i).ToString
                    dt.Rows.Add(dr)
                End If
            Next
        Next
        dt = RemoveDuplicateRows(dt, "Trans_Id")
        arr = Nothing
        arr1 = Nothing
        Return dt
    End Function
    Public Sub Reset_Grid(ByVal grd As GridView)
        grd.DataSource = New DataTable()
        grd.DataBind()
        grd.Dispose()
    End Sub
    Public Sub Reset_Opt(ByVal grd As RadioButtonList)
        grd.DataSource = New DataTable()
        grd.DataBind()
        grd.Dispose()
    End Sub
    Public Sub Grid_Pagging(ByVal str As String, ByVal sortAttribute As String, ByVal grd As GridView, ByVal e As GridViewPageEventArgs, ByVal obj As NewDAL.DBManager)
        Dim dt As New DataTable
        dt = obj.ExecuteTable(CommandType.Text, str)
        Dim dv As New DataView(dt)
        grd.PageIndex = e.NewPageIndex
        dv.Sort = grd.Attributes(sortAttribute)
        grd.DataSource = dv
        grd.DataBind()
    End Sub
    Public Sub Grid_Sorting(ByVal str As String, ByVal sortAttribute As String, ByVal grd As GridView, ByVal e As GridViewSortEventArgs, ByVal obj As NewDAL.DBManager)
        grd.Attributes(sortAttribute) = e.SortExpression
        Dim dt As New DataTable
        Dim dv As New DataView(dt)
        dt = obj.ExecuteTable(CommandType.Text, str)
        dv.Sort = grd.Attributes(sortAttribute)
        grd.DataSource = dv
        grd.DataBind()
    End Sub
    Public Function RemoveDuplicateRows(ByVal dTable As DataTable, ByVal colName As String) As DataTable
        Dim hTable As New Hashtable()
        Dim duplicateList As New ArrayList()
        For Each drow__1 As DataRow In dTable.Rows
            If hTable.Contains(drow__1(colName)) Then
                duplicateList.Add(drow__1)
            Else
                hTable.Add(drow__1(colName), String.Empty)
            End If
        Next
        For Each dRow__2 As DataRow In duplicateList
            dTable.Rows.Remove(dRow__2)
        Next
        Return (dTable)
    End Function


    Public Function Find_dt(ByVal ID As String, ByVal ID2 As String, ByVal dt As DataTable) As DataTable
        Dim arr As System.Array
        arr = Strings.Split(ID, ",", -1, 0)
        Dim arr1 As System.Array
        arr1 = Strings.Split(ID2, ",", -1, 0)
        Dim dr As DataRow
        Dim i As Integer
        For i = 0 To arr.Length - 1
            dr = dt.NewRow
            dr(0) = arr.GetValue(i).ToString
            dr(1) = arr1.GetValue(i).ToString
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function
    ''' <summary>
    ''' To Change Cell Color Of GridView .
    ''' </summary>
    ''' <param name="condition">Required Condition on which Color Should Be Change.</param>
    ''' <param name="grd">GridView ID</param>
    ''' <param name="align">Cell Align.</param>
    ''' <param name="nextCell">Boolean Which Defines wheather Next Cell Color May Change Or Not.</param>
    ''' <param name="color">Color Required.</param>
    ''' <param name="bold">Bold Required.</param>
    ''' <remarks></remarks>
    Public Sub change_color(ByVal condition As String, ByVal grd As GridView, ByVal align As Align, ByVal nextCell As NextCell, ByVal color As Color, ByVal bold As Bold)
        Dim i1 As Integer
        Dim i2 As Integer
        For i1 = 0 To grd.Rows.Count - 1
            For i2 = 0 To grd.Columns.Count - 1
                If grd.Rows(i1).Cells(i2).Text = condition Then
                    If color = ObjectVariables.Color.Yes Then
                        grd.Rows(i1).Cells(i2).ForeColor = Drawing.Color.Blue
                    End If
                    If bold = ObjectVariables.Bold.Yes Then
                        grd.Rows(i1).Cells(i2).Font.Bold = True
                        grd.Rows(i1).Cells(i2 + 1).Font.Bold = True
                    End If
                    If align = ObjectVariables.Align.Right Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Right
                    ElseIf align = ObjectVariables.Align.left Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Left
                    ElseIf align = ObjectVariables.Align.Center Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Center
                    End If
                    If nextCell = ObjectVariables.NextCell.Yes Then
                        grd.Rows(i1).Cells(i2 + 1).ForeColor = Drawing.Color.Blue
                    End If
                End If
            Next
        Next
    End Sub
    ''' <summary>
    ''' To Group Related Rows GridView.
    ''' </summary>
    ''' <param name="grd">Gridview ID</param>
    ''' <param name="column">Column Number To Be Matched For Grouping.</param>
    ''' <remarks></remarks>
    Public Sub group_color(ByVal grd As GridView, ByVal column As Field)
        Dim i1 As Integer
        Dim a As String = ""
        For i1 = 0 To grd.Rows.Count - 1
            If a = "" Then
                a = grd.Rows(i1).Cells(column).Text
            Else
                If Not a.Contains(grd.Rows(i1).Cells(column).Text) Then
                    a = a & "," & grd.Rows(i1).Cells(column).Text
                End If
            End If
        Next
        Dim arr As System.Array
        arr = Strings.Split(a, ",", -1, 0)
        Dim kk As Integer
        For kk = 0 To arr.Length - 1
            For i1 = 0 To grd.Rows.Count - 1
                If grd.Rows(i1).Cells(1).Text.Contains(arr.GetValue(kk)) Then
                    If kk Mod 2 = 0 Then
                        grd.Rows(i1).BackColor = Drawing.Color.AliceBlue
                    Else
                        grd.Rows(i1).BackColor = Drawing.Color.White
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub group(ByVal grd As GridView, ByVal column As Field)
        'Dim i1 As Integer
        'Dim a As String = ""
        'For i1 = 0 To grd.Rows.Count - 1
        '    If a = "" Then
        '        a = grd.Rows(i1).Cells(column).Text
        '    Else
        '        If Not a.Contains(grd.Rows(i1).Cells(column).Text) Then
        '            a = a & "," & grd.Rows(i1).Cells(column).Text
        '        End If
        '    End If
        'Next
        'Dim arr As System.Array
        'arr = Strings.Split(a, ",", -1, 0)
        'Dim kk As Integer
        'Dim count As Integer = 1
        'For kk = 0 To arr.Length - 1
        '    For i1 = 0 To grd.Rows.Count - 1
        '        If grd.Rows(i1).Cells(1).Text.Contains(arr.GetValue(kk)) Then
        '            If count = 1 Then
        '                grd.Rows(i1).Cells(1).Text = ""
        '            End If

        '        Else
        '            count += 1
        '        End If
        '    Next
        'Next
    End Sub
    Public Sub change_Text(ByVal condition As String, ByVal ValueTowrite As String, ByVal grd As GridView, ByVal align As Align, ByVal nextCell As NextCell, ByVal color As Color, ByVal bold As Bold)
        Dim i1 As Integer
        Dim i2 As Integer
        For i1 = 0 To grd.Rows.Count - 1
            For i2 = 0 To grd.Columns.Count - 1
                If grd.Rows(i1).Cells(i2).Text = condition Then
                    If color = ObjectVariables.Color.Yes Then
                        grd.Rows(i1).Cells(i2).ForeColor = Drawing.Color.Blue
                    End If
                    If bold = ObjectVariables.Bold.Yes Then
                        grd.Rows(i1).Cells(i2).Font.Bold = True
                        If nextCell = ObjectVariables.NextCell.Yes Then
                            grd.Rows(i1).Cells(i2 + 1).Font.Bold = True
                        End If
                    End If
                    If align = ObjectVariables.Align.Right Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Right
                    ElseIf align = ObjectVariables.Align.left Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Left
                    ElseIf align = ObjectVariables.Align.Center Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Center
                    End If
                    If nextCell = ObjectVariables.NextCell.Yes Then
                        grd.Rows(i1).Cells(i2 + 1).ForeColor = Drawing.Color.Blue
                    End If
                    grd.Rows(i1).Cells(i2).Text = ValueTowrite
                End If
            Next
        Next
    End Sub
    ''' <summary>
    ''' To Get Row Values(single Column) Seperated by Comma.
    ''' </summary>
    ''' <param name="str">Query String</param>
    ''' <param name="ret_value">Return value</param>
    ''' <remarks></remarks>
    Public Sub Get_DetailAll(ByVal str As String, ByRef ret_value As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(i).Item(0).ToString()
                Else
                    If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                        ret_value = ret_value & "," & Ds.Tables(0).Rows(i).Item(0)
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub Get_DetailAll_Suffix(ByVal str As String, ByRef ret_value As String, ByVal suffix As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = "[" & Ds.Tables(0).Rows(i).Item(0) & suffix
                Else
                    If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                        ret_value = ret_value & "," & "[" & Ds.Tables(0).Rows(i).Item(0) & suffix
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub Get_DetailAll_SuffixN(ByVal str As String, ByRef ret_value As String, ByVal suffix As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(i).Item(0) & suffix
                Else
                    If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                        ret_value = ret_value & "," & Ds.Tables(0).Rows(i).Item(0) & suffix
                    End If
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' To Get Row Values(single Column) Seperated by Desired Seperator.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="ret_value"></param>
    ''' <param name="Seperator"></param>
    ''' <remarks></remarks>
    Public Sub Get_DetailAll(ByVal str As String, ByRef ret_value As String, ByVal Seperator As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(i).Item(0)
                Else
                    If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                        ret_value = ret_value & Seperator & Ds.Tables(0).Rows(i).Item(0)
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub Get_DetailAll_D(ByVal str As String, ByRef ret_value As String, ByVal Seperator As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(i).Item(0)
                Else
                    ret_value = ret_value & Seperator & Ds.Tables(0).Rows(i).Item(0)
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' To Get Distinct  Row Values(single Column) Seperated by Comma.
    ''' </summary>
    ''' <param name="str">Query String</param>
    ''' <param name="ret_value">Return value</param>
    ''' <remarks></remarks>
    Public Sub Get_Distinct(ByVal str As String, ByRef ret_value As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(i).Item(0)
                Else
                    '  If Not ret_value.Contains(Ds.Tables(0).Rows(i).Item(0)) Then
                    ret_value = ret_value & "," & Ds.Tables(0).Rows(i).Item(0)
                    'End If
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' To Get Distinct  Row Values(single Column) Seperated by Desired Seperator.
    ''' </summary>
    ''' <param name="str">Query String</param>
    ''' <param name="ret_value">Return value</param>
    ''' <param name="Seperator">Seperator</param>
    ''' <remarks></remarks>
    Public Sub Get_Distinct(ByVal str As String, ByRef ret_value As String, ByVal Seperator As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        ret_value = ""
        Dim Ad As New OleDbDataAdapter(str, con)
        Dim Ds As New DataSet
        Ad.Fill(Ds)
        Dim i As Integer
        If Ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To Ds.Tables(0).Rows.Count - 1
                If ret_value = "" Then
                    ret_value = Ds.Tables(0).Rows(i).Item(0)
                Else
                    ret_value = ret_value & Seperator & Ds.Tables(0).Rows(i).Item(0)
                End If
            Next
        End If
    End Sub
    ''' <summary>
    '''  To Fill Array
    ''' </summary>
    ''' <param name="st">String To Be Split Seperated By Special Character.</param>
    ''' <param name="DefaultSep">No Seperator Is Required If Yes Else Define Seperator.</param>
    ''' <param name="seperator">Special Character.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Fill_Array(ByVal st As String, ByVal DefaultSep As ObjectVariables.DefaultSeperator, Optional ByVal seperator As String = ",") As System.Array
        Dim arr As System.Array
        If st <> "" Then
            If DefaultSep = DefaultSeperator.Yes Then
                arr = Strings.Split(st, ",", -1, 0)
            Else
                arr = Strings.Split(st, seperator, -1, 0)
            End If
            Return arr
        End If
    End Function
    ''' <summary>
    ''' To replace Particular Character From Given String.
    ''' </summary>
    ''' <param name="str">String</param>
    ''' <param name="oldChar">Old Character</param>
    ''' <param name="newChar">New Character</param>
    ''' <param name="ReturnValue">Return Value</param>
    ''' <remarks></remarks>
    Public Sub Replace(ByVal str As String, ByVal oldChar As String, ByVal newChar As String, ByRef ReturnValue As String)
        If str.Contains(oldChar) Then
            ReturnValue = str.Replace(oldChar, newChar)
        Else
            ReturnValue = ""
        End If
    End Sub
    ''' <summary>
    ''' To Make Proper Case Of Any Given String.
    ''' </summary>
    ''' <param name="str">String Which Is To Be Converted To Proper Case.</param>
    ''' <returns>Proper Cased String.</returns>
    ''' <remarks></remarks>
    Public Function ProperCase(ByVal str As String) As String
        If str = "" Then
            Return ""
            Exit Function
        Else
            Return StrConv(str, VbStrConv.ProperCase)
        End If
    End Function
    ''' <summary>
    ''' Function to check if a value is numeric. 
    ''' </summary>
    ''' <param name="value">Value to check</param>
    ''' <returns>True/False</returns>
    ''' <remarks>
    '''</remarks>
    Public Function IsNumeric(ByVal value As String) As Boolean
        If Not value = String.Empty Then
            For Each character As Char In value
                If Not Integer.TryParse(character, New Integer) Then
                    Return False
                Else
                    Return True
                End If
            Next
        Else
            Return False
        End If
    End Function
    Public Sub Change_Value(ByVal condition As String, ByVal grd As GridView, ByVal align As Align, ByVal nextCell As NextCell, ByVal color As Color, ByVal bold As Bold, ByVal newval As String, ByVal txt As String)
        Dim i1 As Integer
        Dim i2 As Integer
        For i1 = 0 To grd.Rows.Count - 1
            For i2 = 0 To grd.Columns.Count - 2
                If grd.Rows(i1).Cells(i2).Text = condition Then
                    grd.Rows(i1).Cells(i2).Text = newval
                    If color = ObjectVariables.Color.Yes Then
                        grd.Rows(i1).Cells(i2).ForeColor = Drawing.Color.Coral
                    End If
                    If bold = ObjectVariables.Bold.Yes Then
                        grd.Rows(i1).Cells(i2).Font.Bold = True
                        grd.Rows(i1).Cells(i2 + 1).Font.Bold = True
                    End If
                    If align = ObjectVariables.Align.Right Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Right
                    ElseIf align = ObjectVariables.Align.left Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Left
                    ElseIf align = ObjectVariables.Align.Center Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Center
                    End If
                    If nextCell = ObjectVariables.NextCell.Yes Then
                        Dim txt1 As TextBox
                        txt1 = CType(grd.Rows(i1).Cells(i2 + 1).FindControl(txt), TextBox)
                        ' grd.Rows(i1).Cells(i2 + 1).Text = "Paid.."
                        txt1.Enabled = False
                        txt1.BorderColor = Drawing.Color.Red
                        ' grd.Rows(i1).Cells(i2 + 1).ForeColor = Drawing.Color.Coral
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub Change_Value1(ByVal condition As String, ByVal grd As GridView, ByVal align As Align, ByVal nextCell As NextCell, ByVal color As Color, ByVal bold As Bold, ByVal newval As String, ByVal txt As String)
        Dim i1 As Integer
        Dim i2 As Integer
        For i1 = 0 To grd.Rows.Count - 1
            For i2 = 0 To grd.Columns.Count - 2
                If grd.Rows(i1).Cells(i2).Text = condition Then
                    grd.Rows(i1).Cells(i2).Text = newval
                    If color = ObjectVariables.Color.Yes Then
                        grd.Rows(i1).Cells(i2).ForeColor = Drawing.Color.Coral
                    End If
                    If bold = ObjectVariables.Bold.Yes Then
                        grd.Rows(i1).Cells(i2).Font.Bold = True
                        grd.Rows(i1).Cells(i2 + 1).Font.Bold = True
                    End If
                    If align = ObjectVariables.Align.Right Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Right
                    ElseIf align = ObjectVariables.Align.left Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Left
                    ElseIf align = ObjectVariables.Align.Center Then
                        grd.Rows(i1).Cells(i2).HorizontalAlign = HorizontalAlign.Center
                    End If
                    If nextCell = ObjectVariables.NextCell.Yes Then
                        Dim txt1 As TextBox
                        txt1 = CType(grd.Rows(i1).Cells(i2 + 1).FindControl(txt), TextBox)
                        grd.Rows(i1).Cells(i2 + 1).Text = "Paid.."
                        txt1.Visible = False
                        grd.Rows(i1).Cells(i2 + 1).ForeColor = Drawing.Color.Coral
                    End If
                ElseIf grd.Rows(i1).Cells(i2).Text = "Paid.." Then
                    If nextCell = ObjectVariables.NextCell.Yes Then
                        Dim txt1 As TextBox
                        txt1 = CType(grd.Rows(i1).Cells(i2).FindControl(txt), TextBox)
                        If grd.Rows(i1).Cells(i2).Text = "Paid.." Then
                            If Not txt1 Is Nothing Then
                                grd.Rows(i1).Cells(i2).Text = "Paid.."
                                txt1.Visible = False
                                grd.Rows(i1).Cells(i2).ForeColor = Drawing.Color.Coral
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Sub


    Public Function Inset_Map_Table(ByVal flag As String, ByVal objCom As OleDbCommand, ByVal Session As String, Optional ByVal Reg_ID As Integer = 0, Optional ByVal Reg_GID As String = "-", Optional ByVal Student_ID As String = "-" _
    , Optional ByVal UEN As String = "-", Optional ByVal TUEN As String = "-", Optional ByVal Scholar_ID As Integer = 0, Optional ByVal Scholar_Code As String = "-", Optional ByVal Roll_No As String = "-", Optional ByVal New_ID As Integer = 0) As Boolean
        Dim returnFlag As Boolean = True
        '        @Reg_ID,
        '	  @Reg_GID,
        '  @Student_ID,
        '  @UEN,
        '@TUEN,@Scholar_ID,@Scholar_Code,@Roll_No,@Session)
        objCom.Parameters.Clear()
        objCom.CommandType = CommandType.StoredProcedure
        objCom.CommandText = "Sp_MapTable"

        '  objCom.Parameters.Add(New OleDbParameter("@id", OleDbType.Integer))
        ' objCom.Parameters("@id").Value = id

        objCom.Parameters.Add(New OleDbParameter("@reg_id", OleDbType.Integer))
        objCom.Parameters("@reg_id").Value = Reg_ID

        objCom.Parameters.Add(New OleDbParameter("@reg_Gid", OleDbType.VarWChar))
        objCom.Parameters("@reg_Gid").Value = Reg_GID

        objCom.Parameters.Add(New OleDbParameter("@Student_ID", OleDbType.VarWChar))
        objCom.Parameters("@Student_ID").Value = Student_ID

        objCom.Parameters.Add(New OleDbParameter("@UEN", OleDbType.VarWChar))
        objCom.Parameters("@UEN").Value = UEN

        objCom.Parameters.Add(New OleDbParameter("@TUEN", OleDbType.VarWChar))
        objCom.Parameters("@TUEN").Value = TUEN

        objCom.Parameters.Add(New OleDbParameter("@Scholar_ID", OleDbType.Integer))
        objCom.Parameters("@Scholar_ID").Value = Scholar_ID

        objCom.Parameters.Add(New OleDbParameter("@Schlor_Code", OleDbType.VarWChar))
        objCom.Parameters("@Schlor_Code").Value = Scholar_Code

        objCom.Parameters.Add(New OleDbParameter("@Roll_No", OleDbType.VarWChar))
        objCom.Parameters("@Roll_No").Value = Roll_No

        objCom.Parameters.Add(New OleDbParameter("@Session", OleDbType.VarWChar))
        objCom.Parameters("@Session").Value = Session

        objCom.Parameters.Add(New OleDbParameter("@New_ID", OleDbType.Integer))
        objCom.Parameters("@New_ID").Value = New_ID

        objCom.Parameters.Add(New OleDbParameter("@flag", OleDbType.VarWChar))
        objCom.Parameters("@flag").Value = flag

        Try
            objCom.ExecuteNonQuery()
        Catch ex As Exception
            returnFlag = False
            Dim p As String
            p = ex.Message
            objCom.Parameters.Clear()
        End Try
        objCom.Parameters.Clear()
        Return returnFlag
    End Function
    Public Enum Condition
        Admission
        Student
        Existing
        None
        Others
        NewExist
    End Enum

    Public Function Update_Map_Table(ByVal flag As String, ByVal objCom As OleDbCommand, ByVal cond As Condition, ByVal Session As String, Optional ByVal Reg_ID As Integer = 0, Optional ByVal Reg_GID As String = "-", Optional ByVal Student_ID As String = "-" _
   , Optional ByVal UEN As String = "-", Optional ByVal TUEN As String = "-", Optional ByVal Scholar_ID As Integer = 0, Optional ByVal Scholar_Code As String = "-", Optional ByVal Roll_No As String = "-", Optional ByVal New_ID As Integer = 0) As Boolean
        Dim returnFlag As Boolean = True
        objCom.Parameters.Clear()
        objCom.CommandType = CommandType.StoredProcedure
        objCom.CommandText = "Sp_UMapTable"
        objCom.Parameters.Add(New OleDbParameter("@reg_id", OleDbType.Integer))
        objCom.Parameters("@reg_id").Value = Reg_ID
        objCom.Parameters.Add(New OleDbParameter("@reg_Gid", OleDbType.VarWChar))
        objCom.Parameters("@reg_Gid").Value = Reg_GID
        objCom.Parameters.Add(New OleDbParameter("@Student_ID", OleDbType.VarWChar))
        objCom.Parameters("@Student_ID").Value = Student_ID
        objCom.Parameters.Add(New OleDbParameter("@UEN", OleDbType.VarWChar))
        If UEN = "" Then
            objCom.Parameters("@UEN").Value = "-"
        Else
            objCom.Parameters("@UEN").Value = UEN
        End If
        objCom.Parameters.Add(New OleDbParameter("@TUEN", OleDbType.VarWChar))
        If TUEN = "" Then
            objCom.Parameters("@TUEN").Value = "-"
        Else
            objCom.Parameters("@TUEN").Value = TUEN
        End If
        objCom.Parameters.Add(New OleDbParameter("@Scholar_ID", OleDbType.Integer))
        objCom.Parameters("@Scholar_ID").Value = Scholar_ID

        objCom.Parameters.Add(New OleDbParameter("@Schlor_Code", OleDbType.VarWChar))
        objCom.Parameters("@Schlor_Code").Value = Scholar_Code

        objCom.Parameters.Add(New OleDbParameter("@Roll_No", OleDbType.VarWChar))
        objCom.Parameters("@Roll_No").Value = Roll_No

        objCom.Parameters.Add(New OleDbParameter("@Session", OleDbType.VarWChar))
        objCom.Parameters("@Session").Value = Session

        objCom.Parameters.Add(New OleDbParameter("@New_ID", OleDbType.Integer))
        objCom.Parameters("@New_ID").Value = New_ID

        objCom.Parameters.Add(New OleDbParameter("@flag", OleDbType.VarWChar))
        objCom.Parameters("@flag").Value = flag

        objCom.Parameters.Add(New OleDbParameter("@Condition", OleDbType.VarWChar))
        objCom.Parameters("@Condition").Value = cond

        Try
            objCom.ExecuteNonQuery()
        Catch ex As Exception
            returnFlag = False
            Dim p As String
            p = ex.Message
            objCom.Parameters.Clear()
        End Try
        objCom.Parameters.Clear()
        Return returnFlag
    End Function
    Public Sub PopulateSEM(ByVal ctrlID As DropDownList, ByVal qryString As Integer, ByVal strsetSelect As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("Select class_name,class_id from semester where prg_id='" & qryString & "'", con)
        da.Fill(ds, "Items")
        ctrlID.Items.Clear()
        If ds.Tables("Items").Rows.Count > 0 Then
            ctrlID.DataSource = ds.Tables("Items")
            ctrlID.DataTextField = "class_name"
            ctrlID.DataValueField = "class_id"
            ctrlID.DataBind()
        End If
        If Trim(strsetSelect) <> String.Empty Then
            ctrlID.Items.Insert(0, strsetSelect)
        End If
        ctrlID.SelectedIndex = 0
        da.Dispose()
        ds.Dispose()
    End Sub
    Public Sub PopulateCity(ByVal ctrlID As DropDownList, ByVal qryString As Integer, ByVal strsetSelect As String)
        Dim con As New OleDbConnection(ConnectionStrings("ConnectionString").ConnectionString)
        con.Open()
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter("Select city_id,city_name from city where state_id=" & qryString & " order by city_name", con)
        da.Fill(ds, "Items")
        ctrlID.Items.Clear()
        If ds.Tables("Items").Rows.Count > 0 Then
            ctrlID.DataSource = ds.Tables("Items")
            ctrlID.DataTextField = "city_name"
            ctrlID.DataValueField = "city_id"
            ctrlID.DataBind()
        End If
        If Trim(strsetSelect) <> String.Empty Then
            ctrlID.Items.Insert(0, strsetSelect)
        End If
        ctrlID.SelectedIndex = 0
        da.Dispose()
        ds.Dispose()
    End Sub
    Public Sub FillRadioList(ByVal ctrlID As RadioButtonList, ByVal qryString As String, ByVal TextField As String, ByVal ValueField As String, ByVal cn As OleDbConnection)
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter(qryString, cn)
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ctrlID.DataSource = ds.Tables(0)
            ctrlID.DataTextField = TextField
            ctrlID.DataValueField = ValueField
            ctrlID.DataBind()
        Else
            ctrlID.Items.Clear()
        End If
        ctrlID.SelectedIndex = ctrlID.Items.Count - 1
    End Sub
    Public Enum ValueType
        PS = 0     'program Semester 
        PST = 1  'Program & Student
        PSST = 2 'program semester student
        PC = 3 'programe category
        PSC = 4 'Program semester category
        PG = 5 'program gender
        PSG = 6 'program semester gender
        PSSTC = 7 'program semester student category
        PSSTG = 8 ''program semester student gender
        PSSTCG = 9 'program semester student category gender
        ID = 13
        Reg_ID = 14
        RegCode = 15
        RollNo = 16
        ScholarCode = 17
        Scholar_ID = 18
        Session = 19
        StudentID = 20
        UEN = 21
        TUEN = 22
        Enrollment = 10
        ProgramID = 11
        SemesterID = 12
        None
    End Enum
    Public Enum BValueType
        Trans_ID
        Cheque_No
        Ch_Date
        CreditCard_No
        Receipt_No
    End Enum
    Public Enum Current
        Yes
        No
    End Enum
    
   
    Public Sub Student_SubjectMap(ByVal str As String, ByRef arrstudent As System.Array)
        Dim obj1 As New NewDAL.DBManager
        obj1.ConnectionString = ConnectionStrings("ConnectionString").ConnectionString()
        obj1.DBManager(DataAccessLayer.DataProvider.OleDb, obj1.ConnectionString)
        obj1.Open()

    End Sub
    Public Function Assesment_ProgramMap(ByVal AssID As Integer, ByVal ExamID As Integer, ByVal sess As String, ByVal inst As String) As DataTable
        Dim obj1 As New NewDAL.DBManager
        obj1.ConnectionString = ConnectionStrings("ConnectionString").ConnectionString()
        obj1.DBManager(DataAccessLayer.DataProvider.OleDb, obj1.ConnectionString)
        obj1.Open()
        Dim dt As New DataTable
        dt = obj1.ExecuteTable(CommandType.Text, "Select  DISTINCT Assesment_M.Ass_ID, Assesment_M.Exam_ID, programme_course.prg_id, programme_course.Prg_C, Assesment_M.Inst_ID, Assesment_M.Session FROM programme_course INNER JOIN Assesment_C ON programme_course.prg_id = Assesment_C.Prog_ID INNER JOIN Assesment_M ON Assesment_C.ID = Assesment_M.ID where Assesment_M.Ass_ID=" & AssID & " and Assesment_M.Exam_ID=" & ExamID & " and  Assesment_M.Inst_ID=" & inst & " and Assesment_M.Session=" & sess)
        obj1.Connection.Close()
        Return dt
    End Function
    Public Function Student_Detail(ByVal ConditionType As ValueType, ByVal cond As System.Array, Optional ByVal Session As String = "", Optional ByVal Current As String = "") As Fee_Class
        Dim ds As New DataSet
        Dim obj As New Fee_Class
        Dim str As String = ""
        Dim sess As String = ""
        Dim Cur As String = ""
        If Session = "" Then
            sess = ""
        Else
            sess = "and Session='" & Session & "'"
        End If
        If Current = "" Then
            Cur = ""
        Else
            Cur = " and Session='" & Current & "'"
        End If
        Select Case ConditionType
            Case ValueType.Enrollment
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where enrollment_id='" & cond(0) & "'" & sess & Cur
            Case ValueType.ScholarCode
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where Scholar_ID=" & cond(0) & sess & Cur
            Case ValueType.ProgramID
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id=" & cond(0) & sess & Cur
            Case ValueType.StudentID
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where Student_ID=" & cond(0) & sess & Cur
            Case ValueType.SemesterID
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where ClassYS_id=" & cond(0) & sess & Cur
            Case ValueType.Reg_ID
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where Reg_ID= " & cond(0) & sess & Cur
            Case ValueType.PST
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and enrollment_id='" & cond(1) & "'" & sess & Cur
            Case ValueType.PS
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and enrollment_id=''" & sess & Cur
            Case ValueType.PC
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and category_id=" & cond(1) & " and enrollment_id=''" & sess & Cur
            Case ValueType.PG
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and Gender='" & cond(1) & "'" & " and enrollment_id=''" & sess & Cur
            Case ValueType.PSST
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and enrollment_id='" & cond(2) & "'" & sess & Cur
            Case ValueType.PSC
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and category_id=" & cond(2) & " and enrollment_id=''" & sess & Cur
            Case ValueType.PSG
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and Gender='" & cond(2) & "'" & " and enrollment_id=''" & sess & Cur
            Case ValueType.PSSTC
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and enrollment_id='" & cond(2) & "'" & " and category_id=" & cond(3) & sess & Cur
            Case ValueType.PSSTG
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and enrollment_id='" & cond(2) & "' and Gender='" & cond(3) & "'" & sess & Cur
            Case ValueType.PSSTCG
                str = "Select feeheadtransaction_id,fee_id from feeheadtransaction where prg_id= " & cond(0) & " and class_id=" & cond(1) & " and enrollment_id='" & cond(2) & "' and category_id=" & cond(3) & " and Gender='" & cond(4) & "'" & sess & Cur
        End Select



        Dim obj1 As New NewDAL.DBManager
        obj1.ConnectionString = ConnectionStrings("ConnectionString").ConnectionString()
        obj1.DBManager(DataAccessLayer.DataProvider.OleDb, obj1.ConnectionString)
        obj1.Open()
        Dim drR As OleDbDataReader
        drR = obj1.ExecuteReader(CommandType.Text, str)
        Dim FID As String = ""
        Dim Finalstring As String = ""
        ' Dim AFID As System.Array
        Dim FHTID As String = ""
        '  Dim AHTID As System.Array
        If drR.HasRows Then
            Dim i As Integer = 0
            While drR.Read
                If FID = String.Empty Then
                    FID = drR.Item(1)
                    FHTID = drR.Item(0)
                Else
                    FID = FID & "," & drR.Item(1)
                    FHTID = FHTID & "," & drR.Item(0)
                End If
                i += 1
            End While
            obj.FeeID = FID
            obj.FeeTransID = FHTID
            'If Finalstring = "" Then
            '    Finalstring = ConditionType & "(" & FID & "\" & FHTID & ")"
            'Else
            '    Finalstring = Finalstring & "^" & ConditionType & "(" & FID & "\" & FHTID & ")"
            'End If

        End If
        drR.Close()
        obj1.Close()
        obj1.Dispose()
        Return obj
    End Function
    Public Function AddDate(ByVal dt As Date, ByVal Addday As Integer) As Date
        Return Format(CDate(dt.AddDays(Addday * 365)), "dd-MMM-yyyy")
    End Function
    Public Function NoOfDays(ByVal dt As DateTime, ByVal dt1 As Date) As Integer
        Dim date1 As New DateTime()
        date1 = dt1
        Dim date2 As New DateTime()
        date2 = dt
        Dim timespan As TimeSpan = date1.Subtract(date2)
        Return timespan.Days / 365
    End Function
    Public Function Map_Bounce(ByVal condition As String, ByVal ConditionType As BValueType, Optional ByVal Session As String = "") As Cheque
        Dim ds As New DataSet
        Dim obj As New Cheque
        Dim str As String = ""
        Dim sess As String = ""
        If Session = "" Then
            sess = ""
        Else
            sess = "and Session='" & Session & "'"
        End If
        Select Case ConditionType
            Case BValueType.Trans_ID
                str = "Select * from Fee_Paydetail_C where Trans_ID=" & condition & sess
            Case BValueType.Cheque_No
                str = "Select * from Fee_Paydetail_C where Cheque_No='" & condition & "'" & sess
            Case BValueType.CreditCard_No
                str = "Select * from Fee_Paydetail_C where CreditCard_No='" & condition & "'" & sess
            Case BValueType.Ch_Date
                str = "Select * from Fee_Paydetail_C where Ch_Date='" & condition & "'" & sess
            Case BValueType.Receipt_No
                Dim retval As String = ""
                Get_Detail("select Trans_ID from Fee_Trans_M where Receipt_No='" & condition & "'" & sess, retval)
                str = "Select * from Fee_Paydetail_C where Trans_ID='" & retval & "'" & sess
        End Select
        Dim obj1 As New NewDAL.DBManager
        obj1.ConnectionString = ConnectionStrings("ConnectionString").ConnectionString()
        obj1.DBManager(DataAccessLayer.DataProvider.OleDb, obj1.ConnectionString)
        obj1.Open()
        Dim drR As OleDbDataReader
        drR = obj1.ExecuteReader(CommandType.Text, str)
        If drR.HasRows Then
            While drR.Read
                obj.Trans_ID = drR.Item(0)
                obj.P_through = drR.Item(1)
                obj.P_Mode = drR.Item(2)
                obj.Slip_No = drR.Item(3)
                obj.Cheque_No = drR.Item(4)
                obj.CreditCard_No = drR.Item(5)
                obj.Ch_Date = drR.Item(6)
                obj.Bank_Name = drR.Item(7)
                obj.Amount = drR.Item(8)
                obj.Status = drR.Item(9)
            End While
        End If
        drR.Close()
        obj1.Close()
        obj1.Dispose()
        Return obj
    End Function
    Public Function Fill_Combo(ByVal str As String, ByVal cbo As DropDownList, ByVal text As String, ByVal valueF As String)
        Dim objBG As New NewDAL.DBManager
        objBG.ConnectionString = ConnectionStrings("ConnectionString").ConnectionString()
        objBG.DBManager(DataAccessLayer.DataProvider.OleDb, objBG.ConnectionString)
        objBG.Open()
        Dim dr As OleDbDataReader
        dr = objBG.ExecuteReader(CommandType.Text, str)
        If dr.Read Then
            cbo.DataSource = dr
            cbo.DataTextField = dr.Item("account_name")
            cbo.DataValueField = dr.Item("account_id")
            cbo.DataBind()
        Else
            cbo.Items.Insert(0, "---Select---")
            cbo.SelectedIndex = 0
        End If
        dr.Close()
        objBG.Close()
        objBG.Dispose()
    End Function
    Public Function Fill_Combo(ByVal str As String, ByVal cbo As DropDownList, ByVal text As String, ByVal valueF As String, ByVal obj As NewDAL.DBManager)
        cbo.Items.Clear()
        obj.DataReader = obj.ExecuteReader(CommandType.Text, str)
        If obj.DataReader.Read Then
            cbo.DataSource = obj.DataReader
            cbo.DataTextField = text
            cbo.DataValueField = valueF
            cbo.DataBind()
        Else
            cbo.Items.Insert(0, "---Select---")
            cbo.SelectedIndex = 0
        End If

       
        obj.DataReader.Close()

    End Function
    Public Function Date_dif(ByVal FromD As String, ByVal ToD As String, ByVal Mon As Integer) As Integer
        Dim diffmon As Integer
        Dim dt1 As Date
        dt1 = Convert.ToDateTime(FromD)
        diffmon = DateDiff(DateInterval.Month, dt1, Convert.ToDateTime(ToD))
        diffmon += 1
        Mon = diffmon
        Return Mon
    End Function
    Public Sub PopulateDropDownList(ByVal ctrlID As DropDownList, ByVal ctrlID2 As DropDownList, ByVal ctrlID3 As DropDownList, ByVal ctrlID4 As DropDownList, ByVal ctrlID5 As DropDownList, ByVal strTextField As String, ByVal strValueField As String, ByVal qryString As String, ByVal strsetSelect As String, ByVal objCom As OleDbCommand)
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
            ctrlID2.DataSource = ds.Tables("Items")
            ctrlID2.DataTextField = strTextField
            ctrlID2.DataValueField = strValueField
            ctrlID2.DataBind()
            ctrlID3.DataSource = ds.Tables("Items")
            ctrlID3.DataTextField = strTextField
            ctrlID3.DataValueField = strValueField
            ctrlID3.DataBind()
            ctrlID4.DataSource = ds.Tables("Items")
            ctrlID4.DataTextField = strTextField
            ctrlID4.DataValueField = strValueField
            ctrlID4.DataBind()
            ctrlID5.DataSource = ds.Tables("Items")
            ctrlID5.DataTextField = strTextField
            ctrlID5.DataValueField = strValueField
            ctrlID5.DataBind()


        End If
        If Trim(strsetSelect) <> String.Empty Then
            ctrlID.Items.Insert(0, strsetSelect)
            ctrlID2.Items.Insert(0, strsetSelect)
            ctrlID3.Items.Insert(0, strsetSelect)
            ctrlID4.Items.Insert(0, strsetSelect)
            ctrlID5.Items.Insert(0, strsetSelect)

        End If
        ctrlID.SelectedIndex = 0
        ctrlID2.SelectedIndex = 0
        ctrlID3.SelectedIndex = 0
        ctrlID4.SelectedIndex = 0
        ctrlID5.SelectedIndex = 0
        da.Dispose()
        ds.Dispose()
    End Sub
    Public Function chked_Amt(ByVal amt As Integer, ByVal j1 As Integer) As Array
        Dim Amonnt As Integer
        Dim Amonnt1(j1 - 1) As Decimal
        Dim temp As Decimal
        Amonnt = Val(amt) / j1
        Dim k As Integer
        For k = 0 To j1 - 1
            Amonnt1(k) = Amonnt
        Next
        For k = 0 To Amonnt1.Length - 1
            temp += Amonnt1(k)
        Next
        Dim fillv As Integer = 0
        If Not temp = Val(amt) Then
            temp = Val(amt) - temp
            Amonnt1(Amonnt1.Length - 1) = Amonnt + temp
        End If
        Return Amonnt1
    End Function
End Class

Public Structure Cheque
    Private TID As Integer
    Private P_t As String
    Private P_M As String
    Private S_N As String
    Private C_No As String
    Private CC_No As String
    Private C_Date As Date
    Private B_Name As String
    Private Amt As Integer
    Private Statu As String
    Private Re_No As String
    Public Property Trans_ID() As Integer
        Get
            Return TID
        End Get
        Set(ByVal Value As Integer)
            TID = Value
        End Set
    End Property
    Public Property P_through() As String
        Get
            Return P_t
        End Get
        Set(ByVal Value As String)
            P_t = Value
        End Set
    End Property
    Public Property P_Mode() As String
        Get
            Return P_M
        End Get
        Set(ByVal Value As String)
            P_M = Value
        End Set
    End Property
    Public Property Slip_No() As String
        Get
            Return S_N
        End Get
        Set(ByVal Value As String)
            S_N = Value
        End Set
    End Property
    Public Property Cheque_No() As String
        Get
            Return C_No
        End Get
        Set(ByVal Value As String)
            C_No = Value
        End Set
    End Property
    Public Property CreditCard_No() As String
        Get
            Return CC_No
        End Get
        Set(ByVal Value As String)
            CC_No = Value
        End Set
    End Property
    Public Property Ch_Date() As Date
        Get
            Return C_Date
        End Get
        Set(ByVal Value As Date)
            C_Date = Value
        End Set
    End Property
    Public Property Bank_Name() As String
        Get
            Return B_Name
        End Get
        Set(ByVal Value As String)
            B_Name = Value
        End Set
    End Property
    Public Property Amount() As Integer
        Get
            Return Amt
        End Get
        Set(ByVal Value As Integer)
            Amt = "-" & Value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return Statu
        End Get
        Set(ByVal Value As String)
            Statu = Value
        End Set
    End Property
    Public Property Receipt_No() As String
        Get
            Return Re_No
        End Get
        Set(ByVal Value As String)
            Re_No = Value
        End Set
    End Property
End Structure
Public Class Fee_Class
    Private _FeeID As String
    Private _FTID As String
    Public Property FeeID() As String
        Get
            Return _FeeID
        End Get
        Set(ByVal Value As String)
            _FeeID = Value
        End Set
    End Property
    Public Property FeeTransID() As String
        Get
            Return _FTID
        End Get
        Set(ByVal Value As String)
            _FTID = Value
        End Set
    End Property

End Class

Public Structure Registered_Student
    Private MID As Integer
    Private EID As String
    Private SCO As String
    Private PID As Integer
    Private STRID As Integer
    Private SID As Integer
    Private SECID As Integer
    Private _N As String
    Private _G As String
    Private _Cat As String
    Public Property ID() As String
        Get
            Return MID
        End Get
        Set(ByVal Value As String)
            MID = Value
        End Set
    End Property
    Public Property Enrollment() As String
        Get
            Return EID
        End Get
        Set(ByVal Value As String)
            EID = Value
        End Set
    End Property
    Public Property ScholarCode() As String
        Get
            Return SCO
        End Get
        Set(ByVal Value As String)
            SCO = Value
        End Set
    End Property
    Public Property ProgramID() As Integer
        Get
            Return PID
        End Get
        Set(ByVal Value As Integer)
            PID = Value
        End Set
    End Property
   
    Public Property StreamID() As Integer
        Get
            Return STRID
        End Get
        Set(ByVal Value As Integer)
            STRID = Value
        End Set
    End Property
    Public Property SemesterID() As Integer
        Get
            Return SID
        End Get
        Set(ByVal Value As Integer)
            SID = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _N
        End Get
        Set(ByVal Value As String)
            _N = Value
        End Set
    End Property
    Public Property Gender() As String
        Get
            Return _G
        End Get
        Set(ByVal Value As String)
            _G = Value
        End Set
    End Property
    Public Property Category() As String
        Get
            Return _Cat
        End Get
        Set(ByVal Value As String)
            _Cat = Value
        End Set
    End Property
End Structure
Public Structure SubjectMap
    Private ER As String
    Private MID As Integer
    Private RID As Integer
    Public Property MapID() As String
        Get
            Return MID
        End Get
        Set(ByVal Value As String)
            MID = Value
        End Set
    End Property
    Public Property Reg_ID() As Integer
        Get
            Return RID
        End Get
        Set(ByVal Value As Integer)
            RID = Value
        End Set
    End Property
    Public Property StudentID() As String
        Get
            Return ER
        End Get
        Set(ByVal Value As String)
            ER = Value
        End Set
    End Property
End Structure
Public Structure _Student
    Private MID As Integer
    Private RID As Integer
    Private ScID As Integer
    Private Roll_no As String
    Private Student_ID As String
    Private U_EN As String
    Private T_UEN As String
    Private Reg_Code As String
    Private Scholar_Code As String
    Private Ses As String
    Public Property ID() As String
        Get
            Return MID
        End Get
        Set(ByVal Value As String)
            MID = Value
        End Set
    End Property
    Public Property Reg_ID() As Integer
        Get
            Return RID
        End Get
        Set(ByVal Value As Integer)
            RID = Value
        End Set
    End Property
    Public Property Scholar_ID() As Integer
        Get
            Return ScID
        End Get
        Set(ByVal Value As Integer)
            ScID = Value
        End Set
    End Property
    Public Property StudentID() As String
        Get
            Return Student_ID
        End Get
        Set(ByVal Value As String)
            Student_ID = Value
        End Set
    End Property
    Public Property Session() As String
        Get
            Return Ses
        End Get
        Set(ByVal Value As String)
            Ses = Value
        End Set
    End Property
    Public Property UEN() As String
        Get
            Return U_EN
        End Get
        Set(ByVal Value As String)
            U_EN = Value
        End Set
    End Property
    Public Property TUEN() As String
        Get
            Return T_UEN
        End Get
        Set(ByVal Value As String)
            T_UEN = Value
        End Set
    End Property
    Public Property RegCode() As String
        Get
            Return Reg_Code
        End Get
        Set(ByVal Value As String)
            Reg_Code = Value
        End Set
    End Property
    Public Property ScholarCode() As String
        Get
            Return Scholar_Code
        End Get
        Set(ByVal Value As String)
            Scholar_Code = Value
        End Set
    End Property
    Public Property RollNo() As String
        Get
            Return Roll_no
        End Get
        Set(ByVal Value As String)
            Roll_no = Value
        End Set
    End Property

End Structure
