<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DayBook.aspx.cs" EnableTheming="true"
    Theme="BasicBlue" StylesheetTheme="BasicBlue" Inherits="Account_DayBook" %>

<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="CommonClassLibrary" Namespace="CommonClassLibrary" TagPrefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DayBook</title>

    <script src="../js/jquery-1.4.4.js" type="text/javascript"></script>

    <link href="../js/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../js/jquery.ui.all.css" rel="stylesheet" type="text/css" />

    <script>
   
	$(document).ready(function() {
		$("[id$=txtFrom]").datepicker({

			changeMonth: true,changeYear: true
		});
	});
	$(document).ready(function() {
		$("[id$=txtTo]").datepicker({

			changeMonth: true,changeYear: true
		});
	});
	</script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" LoadScriptsBeforeUI="true"
        runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/js/jquery-1.4.4.min.js" />
            <asp:ScriptReference Path="~/js/jquery.ui.datepicker.js" />
            <asp:ScriptReference Path="~/js/jquery.ui.core.js" />
            <asp:ScriptReference Path="~/js/jquery.ui.core.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table" width="100%" style="border: 1px solid #006699">
                <tr>
                    <td colspan="2">
                        <div id="lbltitle" style="width: 100%" class="header" runat="server">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        Financial Year
                    </td>
                    <td>
                        <asp:TextBox ID="txtFYear" ReadOnly="true" runat="server" Width="79px"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label><span style="position: relative;
                            float: right"><%=Session["instName"]%></span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server" Width="79px"></asp:TextBox>
                        &nbsp;To&nbsp;<asp:TextBox ID="txtTo" Width="79px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        Show
                    </td>
                    <td>
                        <table width="60%">
                            <tr>
                                <td>
                                    <fieldset>
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellPadding="0" CellSpacing="0"
                                            RepeatDirection="Horizontal" Width="100%">
                                            <asp:ListItem>Narration</asp:ListItem>
                                            <asp:ListItem>Cheque No</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </fieldset>
                                </td>
                                <td>
                                    <fieldset>
                                        <asp:RadioButtonList ID="optcrdr" runat="server" CellPadding="0" CellSpacing="0"
                                            RepeatDirection="Horizontal" Width="100%">
                                            <asp:ListItem>Debit</asp:ListItem>
                                            <asp:ListItem>Credit</asp:ListItem>
                                            <asp:ListItem>Both</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="cmdGet" runat="server" Text="Get Details" Width="91px" OnClick="cmdGet_Click" />
                        <span style="position: relative; float: right; top: 0px;width:80px">
                            <asp:LinkButton ID="lnkPrint"  runat="server" onclick="lnkPrint_Click">Print DayBook</asp:LinkButton>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <cc1:GroupedGridView ID="gvVoucherlist" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" Width="100%" PageSize="15" GridLines="None" GroupedDepth="4">
                            <Columns>
                                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}">
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vtype" HeaderText="Type">
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vno" HeaderText="Voucher No"></asp:BoundField>
                                <asp:BoundField DataField="RefNo" HeaderText="Reference No">
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Particulars" HeaderText="Particulars" />
                                <asp:TemplateField HeaderText="Debit">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDr" SkinID="R" Enabled="false" Width="79px" runat="server" Text='<%# Bind("Debit") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Credit">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCr" runat="server" Enabled="false" Width="79px" Text='<%# Bind("Credit") %>'
                                            SkinID="R"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </cc1:GroupedGridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkPrint" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="0">
        <ProgressTemplate>
            <div class="ProgressMsg">
                <img src="../images/wait.gif" alt="Wait" style="height: 84px; width: 228px" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:UpdateProgressOverlayExtender ID="UpdateProgressOverlayExtender3" runat="server"
        CssClass="updateProgress" TargetControlID="UpdateProgress3" OverlayType="Browser" />
    </div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" />
    </form>
</body>
</html>
