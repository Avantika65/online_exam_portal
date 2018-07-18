<%@ Page Language="C#" AutoEventWireup="true" Title="Voucher Type Creation" CodeFile="VoucherType.aspx.cs"
    Inherits="VoucherType" %>

<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc2" %>
<%@ Register Namespace="MSS" TagPrefix="Custom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Voucher Type Creation</title>
    <link type="text/css" rel="Stylesheet" href="../Account.css" />

    <script language="javascript" src="../datetimepicker.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
     
             function onTextBoxUpdate1(evt)
        {        
            var textBoxID=evt.source.textBoxID;
        
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdsearch").click();
            evt.preventDefault();
        }       
            function onTextBoxUpdate2(evt)
        {        
            var textBoxID=evt.source.textBoxID;
            debugger;
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdsearch1").click();
            evt.preventDefault();
        }       
          
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Scripts>
            <asp:ScriptReference Path="~/FixFocus.js" />
        </Scripts>
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>
                <table style="border: thin solid #006699;" width="100%">
                    <tr>
                        <td colspan="2" class="header">
                            Voucher Type Creation
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table style="border: 1px solid black; width: 100%">
                                        <tr>
                                            <td align="left" colspan="2" style="text-align: center" class="rdgrow">
                                                <asp:RadioButtonList ID="optSelect" runat="server" AccessKey="C" AutoPostBack="True"
                                                    BorderColor="WhiteSmoke" BorderWidth="0px" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="optSelect_SelectedIndexChanged"
                                                    BackColor="LightGray" RepeatDirection="Horizontal" Width="100%">
                                                    <asp:ListItem>Create</asp:ListItem>
                                                    <asp:ListItem>Display</asp:ListItem>
                                                    <asp:ListItem>Alter</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow" bgcolor="Silver">
                                                <asp:Label ID="lblsearch" runat="server" Text="Search"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtsearch" runat="server" CssClass="rdginputbox" onblur="this.className='blur'"
                                                    onfocus="this.className='focus'" Width="237px"></asp:TextBox>
                                                <Custom:AutoSuggestMenu ID="asmStudent0" runat="server" KeyPressDelay="10" MaxSuggestChars="100"
                                                    OnClientTextBoxUpdate="onTextBoxUpdate1" OnGetSuggestions="GetSuggestions" PageSize="20"
                                                    ResourcesDir="../asm_includes" TargetControlID="txtsearch" UpdateTextBoxOnUpDown="False"
                                                    UsePageMethods="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow">
                                                Name
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtVTname" runat="server" CssClass="rdginputbox" onblur="this.className='blur'"
                                                    onfocus="this.className='focus'" Width="239px"></asp:TextBox>
                                                &nbsp;<span class="mandatoryfields">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow">
                                                Type of Voucher
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtvtype" runat="server" CssClass="rdginputbox" onfocus="this.className='focus'"
                                                    onblur="this.className='blur'" Width="120px"></asp:TextBox>
                                                <span class="mandatoryfields">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow">
                                                Abbr.
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAbbr" runat="server" CssClass="rdginputbox" onfocus="this.className='focus'"
                                                    onblur="this.className='blur'" Width="116px"></asp:TextBox>
                                                <Custom:AutoSuggestMenu ID="asmStudent1" runat="server" KeyPressDelay="10" MaxSuggestChars="100"
                                                    OnClientTextBoxUpdate="onTextBoxUpdate2" OnGetSuggestions="GetSuggestions1" PageSize="20"
                                                    ResourcesDir="../asm_includes" TargetControlID="txtvtype" UpdateTextBoxOnUpDown="False"
                                                    UsePageMethods="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow">
                                                Method of Voucher Numbering
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlvno" runat="server" CssClass="rdgdropdown" Width="120px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlvno_SelectedIndexChanged">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Automatic</asp:ListItem>
                                                    <asp:ListItem>Manual</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow">
                                                Voucher Number Prefix&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtprefix" runat="server" CssClass="rdginputbox" onblur="this.className='blur'"
                                                    onfocus="this.className='focus'" Visible="true" Width="47px"></asp:TextBox>
                                                <asp:Label ID="Label1" runat="server" CssClass="rdgrow" Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtno" runat="server" CssClass="rdginputbox" onblur="this.className='blur'"
                                                    onfocus="this.className='focus'" Visible="False" Width="47px"></asp:TextBox>
                                                <asp:Label ID="Label2" runat="server" CssClass="rdgrow"></asp:Label>
                                                <asp:TextBox ID="txtwidth" runat="server" CssClass="rdginputbox" onblur="this.className='blur'"
                                                    onfocus="this.className='focus'" Visible="False" Width="49px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="rdgrow">
                                            <td align="left">
                                                Use&nbsp;Common Narration for each entry
                                            </td>
                                            <td align="left" class="rdgrow">
                                                <asp:CheckBox ID="chkNarr" runat="server" />
                                            </td>
                                        </tr>
                                        <tr class="rdgrow">
                                            <td align="left">
                                                Print After Saving Voucher
                                            </td>
                                            <td align="left" class="rdgrow">
                                                <asp:CheckBox ID="chkPrint" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="rdgrow">
                                                <asp:Label ID="Label3" runat="server" CssClass="rdgrow" Visible="False"></asp:Label>
                                            </td>
                                            <td align="left" class="rdgrow">
                                                <asp:RadioButtonList ID="optprefill" runat="server" CellPadding="0" CellSpacing="0"
                                                    CssClass="rdgrow" RepeatDirection="Horizontal" Visible="False">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="cmdSubmit" CssClass="buttons" runat="server" Text="Submit" OnClick="cmdSubmit_Click"
                                                                Width="106px" />
                                                            <asp:Button ID="cmdsearch" runat="server" Height="1px" Style="background: white;
                                                                border: none" Width="1px" OnClick="cmdsearch_Click" />
                                                            <asp:Button ID="cmdsearch1" runat="server" Height="1px" Style="background: white;
                                                                border: none" Width="1px" OnClick="cmdsearch1_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="cmdReset" CssClass="buttons" runat="server" Text="Reset" OnClick="cmdReset_Click"
                                                                Width="96px" />
                                                            <input id="hdType" runat="server" type="hidden" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="rdgrow" colspan="2">
                                                <asp:CheckBox ID="chkShow" Text="Show All" runat="server" AutoPostBack="True" OnCheckedChanged="chkShow_CheckedChanged" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="rdgrow" colspan="2">
                                                <asp:GridView ID="gvVouchertype" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CellPadding="0" CssClass="paging_gridview" DataKeyNames="vid" ShowFooter="True">
                                                    <RowStyle CssClass="paging_gridview_itm" />
                                                    <PagerStyle CssClass="paging_gridview_pgr" />
                                                    <HeaderStyle CssClass="paging_gridview_hdr" />
                                                    <AlternatingRowStyle CssClass="paging_gridview_aitm" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:Label ID="gross" runat="server" Text="<%# Container.DataItemIndex+1 %>" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="VN" HeaderText="Voucher Name" />
                                                        <asp:BoundField DataField="Abbr" HeaderText="Abbr." />
                                                        <asp:BoundField DataField="NP" HeaderText="Numbering Prefix" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    </td> </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" EnableViewState="False" AssociatedUpdatePanelID="UpdatePanel1"
        DisplayAfter="1000">
        <ProgressTemplate>
            <div>
                <asp:Image ID="Image1" runat="server" Width="207px" ImageUrl="~/wait.gif" Height="78px">
                </asp:Image>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc2:UpdateProgressOverlayExtender ID="UpdateProgressOverlayExtender1" runat="server"
        CssClass="updateProgress" ControlToOverlayID="UpdatePanel1" TargetControlID="UpdateProgress1">
    </cc2:UpdateProgressOverlayExtender>
    </form>
</body>
</html>
