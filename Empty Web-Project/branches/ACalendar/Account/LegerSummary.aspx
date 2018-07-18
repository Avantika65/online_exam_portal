<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LegerSummary.aspx.cs" EnableTheming="true"
    Theme="BasicBlue" StylesheetTheme="BasicBlue" Inherits="Account_LedgerSummary" %>
<%@ Register namespace="MSS" tagprefix="Custom" %>
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
function onTextBoxUpdate3(evt)
        {     
           
        var textBoxID=evt.source.textBoxID;
            
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
             document.getElementById("cmdSearch").click();
            evt.preventDefault();
        }
</script>
   <%-- <script>
   
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
	</script>--%>

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
                        Group Name
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGroup" AutoPostBack="true" runat="server" 
                            Width="430px" onselectedindexchanged="ddlGroup_SelectedIndexChanged">
                        </asp:DropDownList> <Custom:AutoSuggestMenu ID="asmStudent2" runat="server" KeyPressDelay="10" 
                                MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate3" 
                                OnGetSuggestions="GetSuggestions2" ResourcesDir="../asm_includes" 
                                TargetControlID="txtLName" UpdateTextBoxOnUpDown="False" 
                                UsePageMethods="True" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        Ledger Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server"   Width="436px"></asp:TextBox>
                        <asp:Button ID="cmdGet" runat="server" OnClick="cmdGet_Click" 
                            Text="Get Details" Width="91px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        &nbsp;</td>
                    <td>
                       <asp:CheckBox ID="chkSelect" runat="server" 
                                            Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 10%">
                        &nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" 
                                            Text="<%Container.DataItemIndex+1 %>" />
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="LedgerName" HeaderText="Ledger List" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    
                    <td colspan="2"><asp:Button ID="cmdSearch" runat="server" CausesValidation="False" Height="1px" style="background-color:White;border:none"
                                                       Text="Button" UseSubmitBehavior="False" Width="1px" /></td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            
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
     
    
    </form>
</body>
</html>
