<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_dashboard.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="materialize.css" rel="stylesheet" />
    <link href="materialize.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div class="col s12">
           <div class="col s3">
               <asp:Image ID="imgstudent" runat="server" CssClass="circle responsive-img" />
               <asp:Button ID="btneditimage" runat="server" OnClick="btneditimage_Click" />

           </div> 
           <div class="col s9">
               <asp:Label ID="lblname" runat="server" ></asp:Label>
               <asp:Label ID="lblrollno" runat="server" ></asp:Label>
               <asp:Label ID="lblcourse" runat="server" ></asp:Label>
               <asp:Label ID="lblspecialisation" runat="server" ></asp:Label>
               <asp:Label ID="lblinterest" runat="server" ></asp:Label>
               <asp:Button ID="btneditdetail" runat="server" OnClick="btneditdetail_Click"/>
           </div>
       </div>
    </div>
    </form>
</body>
</html>
