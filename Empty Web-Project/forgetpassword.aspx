<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgetpassword.aspx.cs" Inherits="forgetpassword" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    <link href="materialize.min.css" rel="stylesheet" />
    <link href="materialize.css" rel="stylesheet" />
    <style>
        .row {
            margin-top:20%;
        }
        .p
        {
             border:1px solid black;
           border-radius:5px;
           text-align:center;
           background-color:white;
           opacity:0.9;
        }
    </style>
</head>
<body style="background-color:black">
    <form id="form1" runat="server">
          <div class="container">
              <div class="row">
                  <div class="col s2"></div>
                  <div class="col s8 p"><br />
                      <div class="inner" style="font:bold; "> 
                         <h4>Enter Registered Email-ID</h4><br />
                         <div class="input-field"><asp:TextBox ID="txtmail" placeholder="E-mail" runat="server"></asp:TextBox></div><br />
                         <div><asp:Button ID="btnsbmt" Text="Submit" runat="server" OnClick="btnsbmt_Click" CssClass="btn"/></div><br />
                      </div>
                  </div>
                  <div class="col s2"></div>
              </div>
             
         </div>
    </form>
</body>
</html>
