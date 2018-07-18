<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-sm-12">
            <div class="col-sm-8">
                <asp:Label ID="lblques1" runat="server" ></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ques1" /><asp:RadioButton ID="RadioButton2" runat="server" GroupName="ques1" /><asp:RadioButton ID="RadioButton3" runat="server" GroupName="ques1" /><asp:RadioButton ID="RadioButton4" runat="server" GroupName="ques1"/>
                <br /><br />
                <asp:Label ID="lblques2" runat="server" ></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton5" runat="server" GroupName="ques2" /><asp:RadioButton ID="RadioButton6" runat="server" GroupName="ques2" /><asp:RadioButton ID="RadioButton7" runat="server" GroupName="ques2" /><asp:RadioButton ID="RadioButton8" runat="server" GroupName="ques2" />
                <br /><br />
                <asp:Label ID="lblques3" runat="server" ></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton9" runat="server" GroupName="ques3" /><asp:RadioButton ID="RadioButton10" runat="server" GroupName="ques3" /><asp:RadioButton ID="RadioButton11" runat="server" GroupName="ques3" /><asp:RadioButton ID="RadioButton12" runat="server" GroupName="ques3" />
                <br /><br />
                <asp:Label ID="lblques4" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton13" runat="server" GroupName="ques4" /><asp:RadioButton ID="RadioButton14" runat="server" GroupName="ques4" /><asp:RadioButton ID="RadioButton15" runat="server" GroupName="ques4" /><asp:RadioButton ID="RadioButton16" runat="server" GroupName="ques4" />
                <br /><br />
                <asp:Label ID="lblques5" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton17" runat="server" GroupName="ques5" /><asp:RadioButton ID="RadioButton18" runat="server" GroupName="ques5" /><asp:RadioButton ID="RadioButton19" runat="server" GroupName="ques5" /><asp:RadioButton ID="RadioButton20" runat="server" GroupName="ques5" />
                <br /><br />
                <asp:Label ID="lblques6" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton21" runat="server" GroupName="ques6" /><asp:RadioButton ID="RadioButton22" runat="server" GroupName="ques6" /><asp:RadioButton ID="RadioButton23" runat="server" GroupName="ques6" /><asp:RadioButton ID="RadioButton24" runat="server" GroupName="ques6" />
                <br /><br />
                <asp:Label ID="lblques7" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton25" runat="server" GroupName="ques7" /><asp:RadioButton ID="RadioButton26" runat="server" GroupName="ques7" /><asp:RadioButton ID="RadioButton27" runat="server" GroupName="ques7" /><asp:RadioButton ID="RadioButton28" runat="server" GroupName="ques7" />
                <br /><br />
                <asp:Label ID="lblques8" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton29" runat="server" GroupName="ques8" /><asp:RadioButton ID="RadioButton30" runat="server" GroupName="ques8" /><asp:RadioButton ID="RadioButton31" runat="server" GroupName="ques8" /><asp:RadioButton ID="RadioButton32" runat="server" GroupName="ques8" />
                <br /><br />
                <asp:Label ID="lblques9" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton33" runat="server" GroupName="ques9" /><asp:RadioButton ID="RadioButton34" runat="server" GroupName="ques9" /><asp:RadioButton ID="RadioButton35" runat="server" GroupName="ques9" /><asp:RadioButton ID="RadioButton36" runat="server" GroupName="ques9" />
                <br /><br />
                <asp:Label ID="lblques10" runat="server"></asp:Label>
                <br />
                <asp:RadioButton ID="RadioButton37" runat="server" GroupName="ques10" /><asp:RadioButton ID="RadioButton38" runat="server" GroupName="ques10" /><asp:RadioButton ID="RadioButton39" runat="server" GroupName="ques10" /><asp:RadioButton ID="RadioButton40" runat="server" GroupName="ques10" />
                <br /><br />
                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click" />
            </div>
    </div>
    </form>
</body>
</html>
