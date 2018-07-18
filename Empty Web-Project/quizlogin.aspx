<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quizlogin.aspx.cs" Inherits="StudentLogin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssStudent/StudentP.css" rel="stylesheet" type="text/css" />
    <title>Quiz Login</title>
</head>
<body style="background: url(CssStudent/c3.jpg)" class="ltr" >
    <form id="form" runat="server">
        <div class="row" style="border:1px solid black; border-radius:5px;">
            <div class="col-sm-4">
                 <img src="images/avi.jpg" alt="" class="circle responsive-img"/> 
            </div>
            <div class="col-sm-8">
                Course:<asp:Label ID="lblCourse" runat="server" ></asp:Label><br/>
                Branch:<asp:Label ID="lblBranch" runat="server"></asp:Label><br/>
                Tremester:<asp:Label ID="lblTremester" runat="server"></asp:Label><br/>
                Specialisation:<asp:Label ID="lblSpecialisation" runat="server"></asp:Label><br/>
                Area of Interest:<asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Java</asp:ListItem>
                                    <asp:ListItem>C++</asp:ListItem>
                                    <asp:ListItem>C#</asp:ListItem>
                                    <asp:ListItem>.NET</asp:ListItem>
                                    <asp:ListItem>DBMS</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Sr.No.">
                  <ItemTemplate>
                      <%#Container.DataItemIndex+1 %>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="typeofquiz" HeaderText="Quiz Name" />
                <asp:BoundField DataField="marks" HeaderText="Marks" />
            </Columns>
        </asp:GridView>
     </form>
</body>
</html>
