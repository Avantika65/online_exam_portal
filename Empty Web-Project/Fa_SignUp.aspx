<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fa_SignUp.aspx.cs" Inherits="SignUP" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title></title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
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
           background: url(asd.jpg) no-repeat center center fixed #000;
           -webkit-background-size: cover;
           -moz-background-size: cover;
           -o-background-size: cover;
           background-size: cover;
       }
        .di {
            margin-top:4%;
            margin-left:10%;
            margin-right:8%;
        }
        .al {
            text-align:right;
        }
    .fo{
	margin-left:3%;
	font-size:1.2vw;
}
        @media (max-width:767px) {
            .fo {
                margin-left: 3%;
                font-size: 1.8vw;
            }
            .al {
                text-align:left;

            }
            .di {
                margin-top: 4%;
                margin-left: 15%;
            }
        }
       @media (max-width:400px) {
           .fo{
	margin-left:3%;
	font-size:2.5vw;
}
           .al {
                text-align:left;

            }
           .di {
            margin-top:4%;
            margin-left:10%;
        }
       }
    </style>
</head>
<body class="bo">
    <form id="form1" runat="server">
       <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                    data-toggle="modal" data-target="#myModal1">
                    Launch modal
                </button>
        <!--Modal for OTP-->
        <div id="ForOTP">
         <div class="container">
  <!-- Modal -->
  <div class="modal fade"  id="myModal1" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content" style="margin-top:25%;background-color:rgba(223,202,203,1)">
        <div class="modal-header">
          <button style="margin-left:100%;margin-top:3%;color:red" type="button" class="close" ></button>
          <h4>Enter OTP</h4>
        </div>
        <div class="modal-body">
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4"><asp:Label ID="Label4" runat="server" Text="OTP"></asp:Label></div>
            <div class="col-lg-6 col-md-6 col-sm-6"><asp:TextBox ID="TextBox_OTP1" runat="server" placeholder="Enter OTP"></asp:TextBox><asp:Button ID="Button_Resend" runat="server" AutoPostBack="true" Text="Resend" OnClick="Button_OTP1_Resend"/></div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#FF3300"></asp:Label>
            <asp:Button ID="Button4" runat="server" AutoPostBack="true" Text="Submit" OnClick="Button_OTP1_Submit" />
            <asp:Button ID="Button5" runat="server" data-dismiss="modal" Text="Cancel" />
        </div>
    </div>
  </div>
</div>
</div>
</div>
        <div style="background-color: rgba(223,202,203,0.4)" id="MainDiv" runat="server">
        <div style="margin-top:6%">
            <h2 style="text-align:center;font-family:'Times New Roman'">Faculty Registration Form</h2>
        </div>
<div class="di">
  <div class="row">
              <div class="col-sm-4 col-md-4 col-lg-4"><p style="font-family:Times New Roman;"><b>Please Select :</b></p></div>
                  <div class="col-sm-2 col-md-2 col-lg-2"><asp:DropDownList ID="Dcourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Course_SelectedIndexChanged">
                  </asp:DropDownList></div>
                  <div id="BranchDiv" runat="server" class="col-sm-2 col-md-2 col-lg-2"><asp:DropDownList ID="Dbranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Dbranch_SelectedIndexChanged" >
                  </asp:DropDownList></div>
                  <div class="col-sm-2 col-md-2 col-lg-2"><asp:DropDownList ID="Dsubject" runat="server">
                  </asp:DropDownList></div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4 col-lg-4"></div>
                  <div class="col-sm-2 col-md-2 col-lg-2">
                      <asp:Label ID="Course_Label" runat="server" Text="*Please Select Course" ForeColor="#FF3300"></asp:Label>
              </div>
              <div id="BranchDivL" runat="server" class="col-sm-2 col-md-2 col-lg-2">
                  <asp:Label ID="Branch_Label" runat="server" Text="*Please select Specialization" ForeColor="#FF3300"></asp:Label></div>
                  <div class="col-sm-2 col-md-2 col-lg-2">
                      <asp:Label ID="Subject_Label" runat="server" Text="*Please Select Area of interest" ForeColor="#FF3300"></asp:Label>
              </div>
            </div>
     <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>First Name :</b></p></div>
              <div class="col-sm-3 col-md-3">
                  <asp:TextBox ID="TextBox_FirstName" runat="server" Width="80%"></asp:TextBox>
              </div>
                  <div class="col-sm-3 col-md-3">
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Mandatory to fill First Name" ControlToValidate="TextBox_FirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div>
         <div class="col-sm-2 col-md-2">
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter a valid First Name" ControlToValidate="TextBox_FirstName" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                      
              </div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Last Name :</b></p></div>     
                  <div class="col-sm-3 col-md-3">
                  <asp:TextBox ID="TextBox_LastName" runat="server" Width="80%"></asp:TextBox></div>
                  <div class="col-sm-3 col-md-3">
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Mandatory to fill Last Name" ControlToValidate="TextBox_LastName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div>
         <div class="col-sm-2 col-md-2">
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a valid Last Name" ControlToValidate="TextBox_LastName" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                      
              </div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Date of birth :</b></p></div>
              <div class="col-sm-5 col-md-5"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Gender :</b></p></div>
              <div class="col-sm-1 col-md-1">
                  <asp:RadioButton ID="Male_RadioButton" runat="server" GroupName="Gender" Text="Male" /></div>
                  <div class="col-sm-1 col-md-1">
                  <asp:RadioButton ID="Female_RadioButton" runat="server" GroupName="Gender" Text="Female" /></div>
                  <div class="col-sm-1 col-md-1">
                  <asp:RadioButton ID="Other_RadioButton" runat="server" GroupName="Gender" Text="Other" /></div>
                  <div class="col-sm-3 col-md-3">
                      <asp:Label ID="Gender_Label" runat="server" Text="*Please Choose Gender" ForeColor="#FF3300"></asp:Label>
                  </div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Email ID :</b></p></div>
              <div class="col-sm-5 col-md-5">
                  <asp:TextBox ID="TextBox_EmailId" runat="server" Width="70%"  AutoPostBack="true"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox_EmailId" ErrorMessage="*Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div>
        <div class="col-sm-3 col-md-3">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter a Valid Email" ControlToValidate="TextBox_EmailId" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
        </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Mobile Number :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_MobileNumber" runat="server" Width="60%" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox_MobileNumber" ErrorMessage="*Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
              <div class="col-sm-4 col-md-4">
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter a Valid Mobile Number" ControlToValidate="TextBox_MobileNumber" ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></div>
        </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>College ID :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_CollegeId" runat="server" Width="60%"></asp:TextBox></div>
              </div>
     <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Upload Profile Picture :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:FileUpload ID="FileUpload1" runat="server" /></div>
              <div class="col-sm-4 col-md-4">
                  <asp:Label ID="Label_ImgInfo" runat="server" Text="Only jpg , jpeg , gif and png" ForeColor="#FF3300"></asp:Label></div>
              </div>
     <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Password :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_Password" runat="server" Width="60%" TextMode="Password"></asp:TextBox>
              </div>
              <div class="col-sm-4 col-md-4">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Alphanumeric password with minimum length 6 " ForeColor="#FF3300" ControlToValidate="TextBox_Password" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9@!#%&amp;/'&quot;;:,&gt;&lt;]{6,10})$"></asp:RegularExpressionValidator></div>
        </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Confirm Password :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_ConfirmPassword" runat="server" Width="60%" TextMode="Password"></asp:TextBox></div>
              <div class="col-sm-4 col-md-4">
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both password must be same" ControlToCompare="TextBox_Password" ControlToValidate="TextBox_ConfirmPassword" ForeColor="#FF3300"></asp:CompareValidator></div>
        </div>
          </div>
        <div style="margin-left:46%;margin-top:1.5%">
            <asp:Button ID="Button1" runat="server" title="Register" Text="Submit" Height="36px" Width="72px" AutoPostBack="true" OnClick="Button1_Click" /> <a title="Sign in" href="Login.aspx" class="fo">Already a user?</a>
            </div>
        </div>
        
        </form>
</body>
</html>
