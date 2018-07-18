<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditUserWise.aspx.cs" EnableTheming="true" StylesheetTheme="BasicBlue" Theme="BasicBlue" Inherits="Administration_AuditUserWise" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
        <link type="text/css" rel="Stylesheet" href="../Account.css"/>    
    <link rel="stylesheet" type="text/css" href="../css_Admin/cloud-admin.css" />
	<link rel="stylesheet" type="text/css"  href="../css_Admin/themes/default.css"/>
	<link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet"/>
    <script src="../js/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.core.js" type="text/javascript"></script>
    <link href="../js/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../js/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-ui-1.8.6.custom.js" type="text/javascript"></script>
	<!-- DATE RANGE PICKER -->
	<link rel="stylesheet" type="text/css" href="../js_admin/bootstrap-daterangepicker/daterangepicker-bs3.css" />
	<!-- UNIFORM -->
	<link rel="stylesheet" type="text/css" href="../js_admin/uniform/css/uniform.default.min.css" />
	<!-- ANIMATE -->
	<link rel="stylesheet" type="text/css" href="../css_Admin/animatecss/animate.min.css" />
	<!-- FONTS -->
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700' rel='stylesheet' type='text/css'>

        <script src="../datetimepicker.js" type="text/javascript"></script>
        <link type="text/css" rel="Stylesheet" href="../Account.css"/>

        <script language="javascript" src="../datetimepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.core.js" type="text/javascript"></script>
    <link href="../js/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../js/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-ui-1.8.6.custom.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 12%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table" width="100%" style="border: 1px solid #006699">
                   <tr>
                    <td colspan="2">
                        <div id="lbltitle" style="width: 100%; display:none" class="header" runat="server">
                        </div>
             <div class="box border primary">
            <div class="box-title">
            <h4><i class="fa fa-bars"></i>Audit Report</h4>
            </div>           
           </div>
                        </td>
                </tr>
                <tr><td class="style1"><u>I</u>nstitute&nbsp;<span class="mandatoryfields">*</span></td><td style="width:60%">
                    <asp:DropDownList ID="ddlInstitute" runat="server"   Width="300px" AccessKey="I">
                    </asp:DropDownList>
                    </td></tr>
                <tr>
                    <td class="style1">
                        <u>F</u>rom Date&nbsp;<span class="mandatoryfields">*</span></td>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server" Width="100px" AccessKey="F"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <u>T</u>o Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:TextBox ID="txtTo" runat="server" Width="100px" AccessKey="T"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Action Performed</td>
                    <td>
                        <asp:CheckBoxList ID="chkAction" runat="server" CellPadding="0" 
                            AutoPostBack="true"  CellSpacing="0" 
                            RepeatDirection="Horizontal" Width="70%" 
                            onselectedindexchanged="chkAction_SelectedIndexChanged">
                            <asp:ListItem Value="L">Login</asp:ListItem>
                            <asp:ListItem Value="I">Insert</asp:ListItem>
                            <asp:ListItem Value="U">Update</asp:ListItem>
                            <asp:ListItem Value="D">Delete</asp:ListItem>
                            <asp:ListItem Value="All">All</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Report Type</td>
                    <td>
                        <asp:RadioButtonList ID="optType" runat="server" CellPadding="0" 
                            CellSpacing="0" RepeatDirection="Horizontal" Width="70%">
                            <asp:ListItem>Process Wise User Report</asp:ListItem>
                            <asp:ListItem>User Wise Action Report</asp:ListItem>
                            <asp:ListItem>Action Wise User Report</asp:ListItem>
                           
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                     
                        <asp:Button id="cmdSearch" runat="server" name="cmdSearch" 
                               text="Show Report" CssClass="btn btn-primary" onclick="cmdSearch_Click">
                        </asp:Button>
                      
                        <asp:Button ID="cmdSearch0" runat="server" Text="Reset" CssClass="btn btn-inverse" 
                             />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1" valign="top">
                        <asp:CheckBox ID="chkSelectAllACT" runat="server" AutoPostBack="True" 
                            Text="Select All User(s)" />
                    </td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                            GridLines="None" PageSize="25" Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="40px" />
                                    <HeaderStyle Width="40px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Username" HeaderText="User Name" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="cmdSearch" />
        </Triggers>
    </asp:UpdatePanel>
     <script>
     
	 
	 function pageLoad()
	 {
	  $(document).ready(function () {
		$("[id$=txtFrom]").datepicker({

			changeMonth: true,changeYear: true
		});
	   });
	    $(document).ready(function () {
		$("[id$=txtTo]").datepicker({

			changeMonth: true,changeYear: true
		});
	   });
	 }
    </script>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" />
    </form>
     </body>
</html>
