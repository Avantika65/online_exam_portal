Imports System.Collections
Imports System.Data.OleDb
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

        'Dim sConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\databases\AutoSuggestBox_Demo.mdb;User Id=admin;Password=;"
        Dim oCn As New OleDb.OleDbConnection(ConnectionStrings("connectionstring").ConnectionString)

        Dim sSql As String
        If Trim(sKeyword) = "" Then
            sKeyword = ""
        Else
            sKeyword = sKeyword.Replace("'", "''")
        End If
        sSql = String.Empty
        If gstr = "txtdocNo" Then
            sSql = "Select distinct top 10 doc_no from  formissuereturn where doc_no LIKE '" + sKeyword.Replace("'", "''") + "%' order by doc_no"
        ElseIf gstr = "txtsupplier" Then
            sSql = "Select distinct top 10 account_id,account_name from  account where account_name LIKE '" + sKeyword.Replace("'", "''") + "%' order by account_name"
        ElseIf gstr = "txtformrecd" Then
            sSql = "Select distinct top 10 cast(doc_no as nvarchar),doc_no from  formrecd where doc_no LIKE '" + sKeyword.Replace("'", "''") + "%' order by doc_no"
        ElseIf gstr = "txtformissue" Then
            sSql = "Select distinct top 10 cast(doc_no as nvarchar),doc_no from  formissuereturn where doc_no LIKE '" + sKeyword.Replace("'", "''") + "%' and issuereturn='I' order by doc_no"
        ElseIf gstr = "txtfee" Then
            sSql = "Select distinct top 10 fee_name , fee_id from fee_head where fee_name LIKE '" + sKeyword.Replace("'", "''") + "%' order by fee_name"
        ElseIf gstr = "txtregid" Then
            sSql = "Select distinct top 10 reg_id,reg_id from registration where reg_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by reg_id"
        ElseIf gstr = "expid" Then
            sSql = "Select distinct top 10 ExpID from EmpExp where ExpID LIKE '" + sKeyword.Replace("'", "''") + "%' order by ExpID"
        ElseIf gstr = "txtSkillid" Then
            sSql = "Select distinct top 10 skill_id from EmployeeSkill where skill_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by skill_id"
        ElseIf gstr = "txtEmpCrrStatusid" Then
            sSql = "Select distinct top 10 Employee_CurStatus_id from Employee_currentStatus where Employee_CurStatus_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Employee_CurStatus_id"
        ElseIf gstr = "txtFamilyid" Then
            sSql = "Select distinct top 10 Family_id from EmpFamily where Family_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Family_id"
        ElseIf gstr = "txtEmployeeID" Then
            sSql = "Select distinct top 10 Emp_id,Emp_id from EmployeePer_detail where Emp_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Emp_id"
        ElseIf gstr = "txtInsuranceid" Then
            sSql = "Select distinct top 10 Insurance_id,Insurance_id from Emp_Insurance where Insurance_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Insurance_id"
        ElseIf gstr = "txtEmpofficialid" Then
            sSql = "Select distinct top 10 Employee_Official_id from EmployeeOfficial where Employee_Official_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Employee_Official_id"
        ElseIf gstr = "txtEmpQualid" Then
            sSql = "Select distinct top 10 Emp_Qua_id,Emp_Qua_id from Employee_Qualification where Emp_Qua_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Emp_Qua_id"
        ElseIf gstr = "txtemployid" Then
            sSql = "Select distinct top 10 Emp_id,Emp_id from Leave_applicable where Emp_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Emp_id"
        ElseIf gstr = "txtEmpexpid" Then
            sSql = "Select distinct top 10 Empexp_id,Empexp_id from Employee_Experience where Empexp_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Empexp_id"
        ElseIf gstr = "txtloantypeID" Then
            sSql = "Select distinct top 10 Loan_id,Loan_id from Loan_Type where Loan_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Loan_id"
        ElseIf gstr = "AsbAppNum" Then
            sSql = "Select distinct top 10 Application_no,Application_no from Leave_Application where Application_no LIKE '" + sKeyword.Replace("'", "''") + "%' order by Application_no"
        ElseIf gstr = "txtofficialid" Then
            sSql = "Select distinct top 10 Employee_Official_id,Employee_Official_id from EmployeeOfficial where Employee_Official_id LIKE '" + sKeyword.Replace("'", "''") + "%' order by Employee_Official_id"

        End If


        Dim oCmd As OleDbCommand = New OleDbCommand(sSql, oCn)
        oCn.Open()
        Dim oReader As OleDbDataReader = oCmd.ExecuteReader()
        Dim sCity As String
        Dim sLabel As String
        Dim oMenuItem As ASBMenuItem
        While oReader.Read()
            sCity = oReader.GetValue(0)
            sLabel = oReader.GetValue(1)
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
            Case "City"
                aMenuItems = LoadCities(msKeyword)
            Case Else
                Throw New Exception("GetAutoSuggestData  Type '" & msDataType & "' is not supported.")
        End Select
        LoadMenuItems = aMenuItems

    End Function

End Class
