<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   <style>
       a:link {
    color: red;
    background-color: transparent;
    text-decoration: none;
}
a:visited {
    color: rgb(163,0,99);
    background-color: transparent;
    text-decoration: none;
}
a:hover {
    color: blue;
    background-color: transparent;
    text-decoration: underline;
}
a:active {
    color: red;
    background-color: transparent;
    text-decoration: underline;
}
       .bo {
           background: url(images/sign.jpg) no-repeat center center fixed #000;
           -webkit-background-size: cover;
           -moz-background-size: cover;
           -o-background-size: cover;
           background-size: cover;
       }
    .fo{
	margin-left:3%;
	font-size:1.2vw;
}
       @media (max-width:610px) {
           .fo{
	margin-left:3%;
	font-size:1.8vw;
}
       }
       @media (max-width:400px) {
           .fo{
	margin-left:3%;
	font-size:2.5vw;
}
       }
    </style>
</head>
<body class="bo">
    <form id="form1" runat="server">
        <div style="margin-top:8%">
            <h1 style="text-align:center">Student Registration Form</h1>
        </div>
    <div style="margin-left:23%;margin-top:5%; overflow-x:auto;">
    <table style="width:100%;">
            <tr>
                <td style="width:150px"   >Please Select :</td>
                <td >
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown" Height="25px" Width="159px">
                        <asp:ListItem>Select College</asp:ListItem>
                    </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="159px">
                        <asp:ListItem>Select Branch</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="159px">
                        <asp:ListItem>Select Subject</asp:ListItem>
                    </asp:DropDownList>
             </td>
            </tr>
            <tr>
                <td class="auto-style1" >First Name :</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
                    (Maximum 30 characters a-z and A-Z)
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Last Name :</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
                    (Maximum 30 characters a-z and A-Z)</td>
            </tr>
            <tr>
                <td class="auto-style1">

                    Date Birth :</td>
                <td>

                    <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="101px">
                        <asp:ListItem>Day</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="108px">
                        <asp:ListItem>Month</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="101px">
                        <asp:ListItem>Year</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    Gender :</td>
                <td>

                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" />
&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" />
&nbsp;&nbsp;&nbsp;

                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    Email ID :</td>
                <td>

                    <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    Mobile Number :</td>
                <td>

                    <asp:TextBox ID="TextBox4" runat="server" Width="184px"></asp:TextBox>
                    (Maximum 10 digit numbers)</td>
            </tr>

            <tr>
                <td class="auto-style1">

                    College ID :</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="181px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    Password :</td>
                <td>

                    <asp:TextBox ID="TextBox6" runat="server" Width="178px"></asp:TextBox>
                    (Should contain 1 capital alphabet,1 number and 1 special symbol)</td>
            </tr>
            <tr>
            <td class="auto-style1">

                    Confirm

                    Password :</td>
                <td>

                    <asp:TextBox ID="TextBox7" runat="server" Width="178px"></asp:TextBox>
                    (Should contain 1 capital alphabet,1 number and 1 special symbol)</td>
            </tr>
        </table>
    </div>
        <div style="margin-left:46%;margin-top:1.5%">

            <asp:Button ID="Button1" runat="server" Text="Submit" Height="36px" Width="72px" /> <a tittle="Sign in" href="Home.aspx" class="fo">Already a user?</a>

        </div>
    </form>
</body>
</html>
