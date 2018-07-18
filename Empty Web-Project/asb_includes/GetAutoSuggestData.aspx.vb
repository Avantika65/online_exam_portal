Imports System.Collections
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports ASB


Partial Class GetAutoSuggestData
    Inherits System.Web.UI.Page
    Private msTextBoxID As String
    Private msMenuDivID As String
    Private msDataType As String
    Private mnNumMenuItems As Int32
    Private mbIncludeMoreMenuItem As Boolean
    Private msMoreMenuItemLabel As String
    Private msMenuItemCSSClass As String
    Private msKeyword As String
    'Dim LibObj As New Library.libGeneralFunctions
    Dim gstr As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Turn off cache
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        msTextBoxID = Request.QueryString("TextBoxID")
        msMenuDivID = Request.QueryString("MenuDivID")
        msDataType = Request.QueryString("DataType")
        mnNumMenuItems = Convert.ToInt32(Request.QueryString("NumMenuItems"))
        mbIncludeMoreMenuItem = Convert.ToBoolean(Request.QueryString("IncludeMoreMenuItem"))
        msMoreMenuItemLabel = Request.QueryString("MoreMenuItemLabel")
        msMenuItemCSSClass = Request.QueryString("MenuItemCSSClass")
        msKeyword = Request.QueryString("Keyword")
        gstr = msTextBoxID
        'Get menu item labels and values
        Dim aMenuItems As ArrayList = LoadMenuItems()
        'Generate html and write it to the page
        Dim sHtml As String
        sHtml = AutoSuggestBox.GenMenuItemsHtml(aMenuItems, _
                                                msTextBoxID, _
                                                mnNumMenuItems, _
                                                mbIncludeMoreMenuItem, _
                                                msMoreMenuItemLabel, _
                                                msMenuItemCSSClass)
        Response.Write(sHtml)
    End Sub

    Private Function LoadCities(ByVal sKeyword As String) As ArrayList
        Dim aOut As ArrayList = New ArrayList
        Dim oCn As New SqlConnection(ConnectionStrings("FeesManagementConn").ConnectionString)
        Dim len As Integer = gstr.Length
        Dim i As Integer
        For i = 0 To len - 1
            If gstr.Chars(i) = "_" Then
                Dim arr() As String
                arr = gstr.Split("_")
                gstr = arr(2)
                Exit For
            End If
        Next
        If Session("instID") Is Nothing Then
            Response.Redirect("~/LogIn_Home.aspx")
        End If
        Dim sSql As String = Nothing
        If gstr = "Student" Then
            If sKeyword.Trim <> "" Then
                'If Session("tfiltCC") Is Nothing Then
                sSql = "SELECT Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName + '(' + Course.ShortName + ')' + '(' + Student_Registration.RollNo + ')' AS Name,StudentID FROM Course INNER JOIN Student_Registration ON Course.CourseId = Student_Registration.CourseCode where LTrim(rtrim(Student_Registration.StudentName)) + ' ' + LTrim(rtrim(Student_Registration.MName)) + ' ' + LTrim(rtrim(Student_Registration.LName)) LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and Student_Registration.InstituteID='" + Session("instID").ToString() + "' and Student_Registration.Status ='C' and Student_Registration.SessionID='" + Session("SesnID").ToString() + "' order by Name"
                'sSql = "select StudentName+' '+Mname+' '+Lname as Name,StudentID from Student_Registration where StudentName LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and InstituteID='" + Session("instID").ToString() + "'   order by StudentName"
                'Else
                '    sSql = "select StudentName+' '+Mname+' '+Lname as Name,StudentID from Student_Registration where StudentName LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and InstituteID='" + Session("instID").ToString() + "' and CourseCode='" + Session("tfiltCC").ToString() + "' order by StudentName"
                'End If
            Else
                'If Session("tfiltCC") Is Nothing Then
                sSql = "SELECT Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName + '(' + Course.ShortName + ')' + '(' + Student_Registration.RollNo + ')' AS Name,StudentID FROM Course INNER JOIN Student_Registration ON Course.CourseId = Student_Registration.CourseCode where Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName LIKE '%' and Student_Registration.InstituteID='" + Session("instID").ToString() + "' and Student_Registration.Status ='C' and Student_Registration.SessionID='" + Session("SesnID").ToString() + "' order by Name"
                '    Else
                '    sSql = "select StudentName+' '+Mname+' '+Lname as Name,StudentID from Student_Registration where StudentName LIKE '%' and InstituteID='" + Session("instID").ToString() + "' and CourseCode='" + Session("tfiltCC").ToString() + "' order by StudentName"
                'End If
            End If
        ElseIf gstr = "HostelStudent" Then
            If sKeyword.Trim <> "" Then
                sSql = "select Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName + '(' + Course.ShortName + ')' + '(' + Student_Registration.RollNo + ')' AS Name,StudentID FROM Course INNER JOIN Student_Registration ON Course.CourseId = Student_Registration.CourseCode where StudentID not  in(select student_emp_id from Room_Quarter_Allotment_Entry ) and LTrim(rtrim(Student_Registration.StudentName)) + ' ' + LTrim(rtrim(Student_Registration.MName)) + ' ' + LTrim(rtrim(Student_Registration.LName)) LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and Student_Registration.InstituteID='" + Session("instID").ToString() + "' and Student_Registration.Status ='C' and Student_Registration.SessionID='" + Session("SesnID").ToString() + "' order by StudentName"
                'sSql = "select StudentName+' '+Mname+' '+Lname as Name,StudentID from Student_Registration where StudentID not  in(select student_emp_id from Room_Quarter_Allotment_Entry ) and StudentName LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and InstituteID='" + Session("instID").ToString() + "'   order by StudentName"
            Else
                sSql = "select Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName + '(' + Course.ShortName + ')' + '(' + Student_Registration.RollNo + ')' AS Name,StudentID FROM Course INNER JOIN Student_Registration ON Course.CourseId = Student_Registration.CourseCode where StudentID not  in(select student_emp_id from Room_Quarter_Allotment_Entry ) and LTrim(rtrim(Student_Registration.StudentName)) + ' ' + LTrim(rtrim(Student_Registration.MName)) + ' ' + LTrim(rtrim(Student_Registration.LName)) LIKE '%' and Student_Registration.InstituteID='" + Session("instID").ToString() + "' and Student_Registration.Status ='C' and Student_Registration.SessionID='" + Session("SesnID").ToString() + "' order by StudentName"
            End If
        ElseIf gstr = "Schedule" Then
        If sKeyword.Trim <> "" Then
            sSql = "SELECT Schedule,MessSchID FROM Master_Mess_Schedule_Details E where Schedule LIKE '" + sKeyword.Replace("'", "''").Trim() + "%'and  MessSchID='" + Session("MessSchID").ToString() + "' and E.InstituteID='" + Session("instID").ToString() + "'   order by Schedule"
        Else
            sSql = "SELECT Schedule,MessSchID FROM Master_Mess_Schedule_Details E where Schedule LIKE '%' and  MessSchID='" + Session("MessSchID").ToString() + "' and E.InstituteID='" + Session("instID").ToString() + "'   order by Schedule"
        End If

        ElseIf gstr = "ReqStudent" Then
            If sKeyword.Trim <> "" Then
                sSql = "SELECT S.StudentName + ' ' + S.MName + ' ' + S.LName + '(' + Course.ShortName + ')' + '(' + S.RollNo + ')' AS StudentName, S.StudentID FROM Room_Quarter_Allotment_Entry AS E INNER JOIN Student_Registration AS S ON E.Student_Emp_ID = S.StudentID INNER JOIN Course ON S.CourseCode = Course.CourseId Where LTrim(rtrim(S.StudentName)) + ' ' + LTrim(rtrim(S.MName)) + ' ' + LTrim(rtrim(S.LName)) LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and E.InstituteID='" + Session("instID").ToString() + "' order by StudentName"
                'sSql = "SELECT StudentName ,StudentID FROM Room_Quarter_Allotment_Entry E,student_registration S where  s.Studentid=E.Student_Emp_id and s.StudentName LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and E.InstituteID='" + Session("instID").ToString() + "'   order by StudentName"
            Else
                sSql = "SELECT S.StudentName + ' ' + S.MName + ' ' + S.LName + '(' + Course.ShortName + ')' + '(' + S.RollNo + ')' AS StudentName, S.StudentID FROM Room_Quarter_Allotment_Entry AS E INNER JOIN Student_Registration AS S ON E.Student_Emp_ID = S.StudentID INNER JOIN Course ON S.CourseCode = Course.CourseId Where  LTrim(rtrim(S.StudentName)) + ' ' + LTrim(rtrim(S.MName)) + ' ' + LTrim(rtrim(S.LName)) LIKE '%' and E.InstituteID='" + Session("instID").ToString() + "' order by StudentName"
            End If
        ElseIf gstr = "SerReqEntry" Then
            If sKeyword.Trim <> "" Then
                sSql = "SELECT Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName + '(' + Course.ShortName + ')' + '(' + Student_Registration.RollNo + ')' AS StudentName, Room_Quarter_Allotment_Entry.AllotmentID FROM Student_Registration INNER JOIN Room_Quarter_Allotment_Entry ON Student_Registration.StudentID = Room_Quarter_Allotment_Entry.Student_Emp_ID INNER JOIN Course ON Student_Registration.CourseCode = Course.CourseId WHERE Room_Quarter_Allotment_Entry.RoomQtrID ='" + Session("RoomQtrID").ToString() + "' and LTrim(rtrim(Student_Registration.StudentName)) + ' ' + LTrim(rtrim(Student_Registration.MName)) + ' ' + LTrim(rtrim(Student_Registration.LName)) LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and Room_Quarter_Allotment_Entry.InstituteID='" + Session("instID").ToString() + "' order by StudentName"
                'sSql = "SELECT Student_Registration.StudentName, Room_Quarter_Allotment_Entry.AllotmentID FROM Student_Registration INNER JOIN Room_Quarter_Allotment_Entry ON Student_Registration.StudentID = Room_Quarter_Allotment_Entry.Student_Emp_ID WHERE Room_Quarter_Allotment_Entry.RoomQtrID ='" + Session("RoomQtrID").ToString() + "' and Student_Registration.StudentName LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and Room_Quarter_Allotment_Entry.InstituteID='" + Session("instID").ToString() + "'order by StudentName"
            Else
                sSql = "SELECT Student_Registration.StudentName + ' ' + Student_Registration.MName + ' ' + Student_Registration.LName + '(' + Course.ShortName + ')' + '(' + Student_Registration.RollNo + ')' AS StudentName, Room_Quarter_Allotment_Entry.AllotmentID FROM Student_Registration INNER JOIN Room_Quarter_Allotment_Entry ON Student_Registration.StudentID = Room_Quarter_Allotment_Entry.Student_Emp_ID INNER JOIN Course ON Student_Registration.CourseCode = Course.CourseId WHERE Room_Quarter_Allotment_Entry.RoomQtrID ='" + Session("RoomQtrID").ToString() + "' and Student_Registration.StudentName LIKE '%' and Room_Quarter_Allotment_Entry.InstituteID='" + Session("instID").ToString() + "'order by StudentName"
            End If

        ElseIf gstr = "RequisitionNo" Then
        If sKeyword.Trim <> "" Then
            sSql = "SELECT RequisitionNo,RoomReqChangeID FROM Room_Change_Req_Entry  where Approval='Approved' and  RequisitionNo LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and InstituteID='" + Session("instID").ToString() + "'   order by RequisitionNo"
        Else
            sSql = "SELECT RequisitionNo,RoomReqChangeID FROM Room_Change_Req_Entry  where Approval='Approved' and   RequisitionNo LIKE '%' and InstituteID='" + Session("instID").ToString() + "'   order by RequisitionNo"
        End If

        ElseIf gstr = "SerReqNo" Then
        If sKeyword.Trim <> "" Then
            sSql = "SELECT RoomServiceReqCode,RoomServiceReqID FROM Room_Service_Req_Entry  where   RoomServiceReqCode LIKE '" + sKeyword.Replace("'", "''").Trim() + "%'and  Approval='Not Approved' and InstituteID='" + Session("instID").ToString() + "'   order by RoomServiceReqCode"
        Else
            sSql = "SELECT RoomServiceReqCode,RoomServiceReqID FROM Room_Service_Req_Entry  where   RoomServiceReqCode LIKE '%' and Approval='Not Approved' and InstituteID='" + Session("instID").ToString() + "'   order by RoomServiceReqCode"
        End If

        ElseIf gstr = "txtNameStudent" Then
        If sKeyword.Trim <> "" Then
            If Session("tfiltCC1") Is Nothing Then
                    sSql = "select StudentName+' '+Mname+' '+Lname + '(' + ID_Student + ')' as Name,StudentID from Student_Registration where LTrim(rtrim(StudentName))+' '+LTrim(rtrim(Mname))+' '+LTrim(rtrim(Lname)) LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and InstituteID='" + Session("instID").ToString() + "' and SessionID='" + Session("sesnID").ToString() + "' order by StudentName"
            Else
                    sSql = "select StudentName+' '+Mname+' '+Lname + '(' + ID_Student + ')' as Name,StudentID from Student_Registration where LTrim(rtrim(StudentName))+' '+LTrim(rtrim(Mname))+' '+LTrim(rtrim(Lname)) LIKE '" + sKeyword.Replace("'", "''").Trim() + "%' and InstituteID='" + Session("instID").ToString() + "' and CourseCode='" + Session("tfiltCC1").ToString() + "' and SessionID='" + Session("sesnID").ToString() + "' order by StudentName"
            End If
        Else
            If Session("tfiltCC1") Is Nothing Then
                    sSql = "select StudentName+' '+Mname+' '+Lname + '(' + ID_Student + ')' as Name,StudentID from Student_Registration where StudentName LIKE '%' and InstituteID='" + Session("instID").ToString() + "' and SessionID='" + Session("SesnID").ToString() + "' order by StudentName"
            Else
                    sSql = "select StudentName+' '+Mname+' '+Lname + '(' + ID_Student + ')' as Name,StudentID from Student_Registration where StudentName LIKE '%' and InstituteID='" + Session("instID").ToString() + "' and CourseCode='" + Session("tfiltCC1").ToString() + "' and SessionID='" + Session("SesnID").ToString() + "' order by StudentName"
            End If
        End If
        ElseIf gstr = "vendor" Then
        If sKeyword.Trim <> "" Then
            sSql = "select distinct vendor_name,id_vendor from Vendor where Vendor_name LIKE '" + sKeyword.Replace("'", "''").Trim + "%'  order by Vendor_name"
        Else
            sSql = "select distinct vendor_name,id_vendor from Vendor where Vendor_name LIKE '%'  order by Vendor_name"
        End If
        'ElseIf gstr = "txtCmbMemid1" Then
        '    If sKeyword.Trim <> "" Then
        '        sSql = "Select distinct top 10 userid,userid as userid1 from  circusermanagement where userid LIKE N'" + sKeyword.Replace("'", "''").Trim + "%' order by userid"
        '    Else
        '        sSql = "Select distinct top 10 userid,userid as userid1 from  circusermanagement where userid LIKE N'%' order by userid"
        '    End If
        ElseIf gstr = "StudentID" Then
        If sKeyword.Trim <> "" Then
            sSql = "select ID_Student,StudentID as ID from Student_Registration where StudentID LIKE '" + sKeyword.Replace("'", "''").Trim + "%'  order by StudentID"
        Else
            sSql = "select ID_Student,StudentID as ID from Student_Registration where StudentID LIKE '%'  order by StudentID"
        End If

        End If
        Dim oCmd As SqlCommand = New SqlCommand(sSql, oCn)         'N'%" + sKeyword.Replace("'", "''") + "%'
        oCmd.Parameters.AddWithValue("@title", "%" + sKeyword + "%")
        oCn.Open()
        Dim oReader As SqlDataReader = oCmd.ExecuteReader()
        Dim sCity As String
        Dim sLabel As String
        Dim oMenuItem As ASBMenuItem
        While oReader.Read()
            sCity = oReader.GetValue(1).ToString()
            sLabel = oReader.GetValue(0).ToString()
            oMenuItem = New ASBMenuItem
            oMenuItem.Label = sLabel
            oMenuItem.Value = sCity
            aOut.Add(oMenuItem)
        End While
        oReader.Close()
        oCn.Close()
        Return aOut
    End Function
    Function LoadMenuItems() As ArrayList
        Dim aMenuItems As ArrayList
        Select Case (msDataType)
            Case "Student"
                aMenuItems = LoadCities(msKeyword)
            Case "StudentID"
                aMenuItems = LoadCities(msKeyword)
            Case Else
                Throw New Exception("GetAutoSuggestData  Type '" & msDataType & "' is not supported.")
        End Select
        LoadMenuItems = aMenuItems
    End Function
End Class
