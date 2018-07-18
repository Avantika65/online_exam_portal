<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="Blank_Project_NewFolder1_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="stylepage.css" type="text/css" rel="stylesheet" />  
    <style type="text/css">  
        .auto-style1 {  
            width 100%;  
        }  
    </style>  
</head>
<body>
    <form id="form1" runat="server">
   <div id="Div1">  
    <h1>REGISTER PAGE</h1>  
    </div>  
        <div id ="Div2"></div>  
    <table class="auto-style1">  
        <tr>  
            <td>  
                <aspLabel ID="AspLabel1" runat="server" Text="StudentName"></aspLabel></td>  
            <td>  
                <aspTextBox ID="AspTextBox1" runat="server"></aspTextBox></td>  
        </tr>  
        <tr>  
            <td>  
                <aspLabel ID="AspLabel2" runat="server" Text="Password"></aspLabel></td>  
            <td>  
                <aspTextBox ID="AspTextBox2" runat="server"></aspTextBox></td>  
        </tr>  
        <tr>  
            <td>  
                <aspLabel ID="AspLabel3" runat="server" Text="EmailId"></aspLabel></td>  
            <td>  
                <aspTextBox ID="AspTextBox3" runat="server"></aspTextBox></td>  
        </tr>  
        <tr>  
            <td>  
                <aspLabel ID="AspLabel4" runat="server" Text="Department"></aspLabel></td>  
            <td>  
                <aspTextBox ID="AspTextBox4" runat="server"></aspTextBox></td>  
        </tr>  
        <tr>  
            <td>  
                <aspLabel ID="AspLabel5" runat="server" Text="College"></aspLabel></td>  
            <td>  
                <aspTextBox ID="AspTextBox5" runat="server"></aspTextBox></td>  
        </tr>  
    </table>  
    <div id="Div3">  
        <aspButton ID="AspButton1" runat="server" Text="submit" OnClick="Button1_Click" BackColor="Yellow" />  
    </div>  
        <div id="Div4"></div>  
        <aspSqlDataSource ID="AspSqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStringsRegiConnectionString %>" SelectCommand="SELECT * FROM [RegisterDataBase]"></aspSqlDataSource>  
          
        <div id="Div5">  
            <aspGridView ID="AspGridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">  
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />  
                <Columns>  
                    <aspBoundField DataField="Id" HeaderText="Id" SortExpression="Id" />  
                    <aspBoundField DataField="StudentName" HeaderText="StudentName" SortExpression="StudentName" />  
                    <aspBoundField DataField="Passwords" HeaderText="Passwords" SortExpression="Passwords" />  
                    <aspBoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />  
                    <aspBoundField DataField="Department" HeaderText="Department" SortExpression="Department" />  
                    <aspBoundField DataField="College" HeaderText="College" SortExpression="College" />  
                </Columns>  
                <EditRowStyle BackColor="#999999" />  
                <FooterStyle BackColor="#5D7B9D" -Bold="True" ForeColor="White" />  
                <HeaderStyle BackColor="#5D7B9D" -Bold="True" ForeColor="White" />  
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />  
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />  
                <SelectedRowStyle BackColor="#E2DED6" -Bold="True" ForeColor="#333333" />  
                <SortedAscendingCellStyle BackColor="#E9E7E2" />  
                <SortedAscendingHeaderStyle BackColor="#506C8C" />  
                <SortedDescendingCellStyle BackColor="#FFFDF8" />  
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />  
            </aspGridView>  
        </div>  
              
            <div id="Div6">  
            <h3>Developed by  
                      anonymous</h3>  
        </div>  
    </form>
</body>
</html>
