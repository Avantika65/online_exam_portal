<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="ForLogin.css"/>
    <link rel="stylesheet" type="text/css" href="Forgot.css"/>
    <meta charset="utf-8"/>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
    <script type="text/javascript">
        function ShowPopup1() {
            $("#btnShowPopup1").click();
        }
    </script>
    <title></title>
</head>
<body class="bo">
    <form id="form1" runat="server">
    <div>
         <div class="container">

              <!-- Modal -->
              <div class="modal fade" id="myModal" role="dialog">
                 <div class="modal-dialog">
    
                     <!-- Modal content-->
                     <div class="modal-content" style="margin-top:25%;background-color:rgba(223,202,203,1)">
                        <div class="modal-header">
                            <button style="margin-left:100%;margin-top:3%;color:red" type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Forgot Password</h4>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem>---SELECT---</asp:ListItem>
                                <asp:ListItem>faculty</asp:ListItem>
                                <asp:ListItem>student</asp:ListItem></asp:DropDownList>
                        </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4"><asp:Label ID="Label5" runat="server" Text="Email Id"></asp:Label>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6"><asp:TextBox ID="TextBox_EmailId_Fo" runat="server" placeholder="Enter Email Id" AutoPostBack="false"></asp:TextBox>
                                    </div>
                                    </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4"><asp:Label ID="Label1" runat="server" Text="OTP"></asp:Label>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-5"><asp:TextBox ID="TextBox_OTP_Fo" runat="server" placeholder="Enter OTP"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-2">
                                        <asp:Button ID="Resend_Button" runat="server" Text="Send" OnClick="Button_OTP_Send_Fo"/>
                                    </div>
                                 </div>
                                 <div class="row">
                                     <div class="col-lg-4 col-md-4 col-sm-4"><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-6"><asp:TextBox ID="TextBox_Password_Fo" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                     </div>
                                 </div>
                                 <div class="row">
                                     <div class="col-lg-4 col-md-4 col-sm-4"><asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-6"><asp:TextBox ID="TextBox_CPassword_Fo" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                     </div>
                                 </div>
                            </div>
                         <div class="modal-footer">
                             <asp:Label ID="Label8" runat="server" Text="Wrong OTP" ForeColor="Red"></asp:Label>
                             <asp:Label ID="Label7" runat="server" Text="OTP Sent..." ForeColor="Red"></asp:Label>
                             <asp:Label ID="Label6" runat="server" Text="Email Id Doesn't exists..." ForeColor="Red"></asp:Label>
                            <asp:Button ID="Button_Submit_Fo" runat="server" Text="Submit" OnClick="Button_OTP_Submit_Fo"/>
                            <asp:Button ID="Button3" runat="server" data-dismiss="modal" Text="Cancel" />
                         </div>
                     </div>
                </div>
          </div>
    </div>
</div>
        

        <div  class="di" id="MainDiv" runat="server">
        <div  class="subordinate">
            <br />
            <div style="margin-left:40%;margin-top:8%;"><asp:DropDownList  ID="DropDownList1" runat="server" Height="28px" Width="189px">
                <asp:ListItem>---SELECT---</asp:ListItem>
                <asp:ListItem>faculty</asp:ListItem>
                <asp:ListItem>student</asp:ListItem>
                </asp:DropDownList></div>
            <br />
        <br/>
        <p class="fon" style ="font-family: 'Arial'; font-weight: bold;">Login :
        <asp:TextBox class="textfield" title="Enter Email" ID="log" runat="server"></asp:TextBox>
        </p>
        <p class="fon" style="font-family: Arial; font-weight: bold;">Password :
        <asp:TextBox title="Enter Password" class="textfield1" type="Password" ID="Pass" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <asp:CheckBox Style="margin-left:37%;" ID="CheckBox1" runat="server" Text="Remember me" />
        <div class="buttonField">
            <asp:Button ID="btnShow" runat="server" style="width:150px;height:40px;" title="Login"  Text="Login" Font-Bold="True" Font-Overline="False" Font-Size="Medium"  OnClick="Button1_Click1" CssClass="btn-primary" />
           <div><a style="float:right;width:auto;" id="btnShowPopup1" runat="server" data-toggle="modal" data-target="#myModal" title="Reset Password" class="fo"  href="#">forgot password?</a></div> </div>     <br/>
            <a  title="Sign Up" class="ne" href="St_SignUp.aspx">New Student??</a>
             <a  title="Sign Up" class="ne" href="Fa_SignUp.aspx">New Faculty??</a>
            </div>
 </div>
        <!--<button type="button" style="display: none;" id="btnShowPopup1" class="btn btn-primary btn-lg"
                    data-toggle="modal" data-target="#myModal">
                    Launch modal
                </button>-->
    </form>

</body>
</html>

