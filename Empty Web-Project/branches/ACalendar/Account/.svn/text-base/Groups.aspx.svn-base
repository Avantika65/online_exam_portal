<%@ Page Language="C#" Title="Group reation" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Account_Groups" %>
<%@ Register TagPrefix="FH1" TagName="TopImageControl"  Src="~/UserControls/FormHeader.ascx" %>
<%@ Register namespace="MSS" tagprefix="Custom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group reation</title>
        <link type="text/css" rel="Stylesheet" href="../Account.css"/>
         
<script language ="javascript">
    
             function onTextBoxUpdate1(evt)
        {        
            var textBoxID=evt.source.textBoxID;
            debugger;
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdSearch").click();
            evt.preventDefault();
        }       
            function onTextBoxUpdate2(evt)
        {        
            var textBoxID=evt.source.textBoxID;
            debugger;
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdSearch1").click();
            evt.preventDefault();
        }       
          
        </script>
    <style type="text/css">

        .style4
        {
            text-align: left;
            height: 20px;
            color: #0a3c72;
            font-size: 12px;
            font-family: Arial;
            width: 88px;
            border-bottom: 1px solid #ffffff;
            background-color: #ffffff;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
                      <input id="hdType" runat="server"  type="hidden" />
                     <input id="hdGID" runat="server"  type="hidden" />
   <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server">
    <Scripts><asp:ScriptReference Path="~/FixFocus.js" /></Scripts>
    </asp:ScriptManager>
         <table style="width: 100%">
        <tr  >
                <td colspan="2"  class="header"> Group Creation</td>
            </tr>
        <tr  >
                <td colspan="2" align="center"  > 
                    <table style="border: 1px solid black; width: 100%" cellpadding="0" 
                        cellspacing="2"   >
                        <tr>
                            <td align="center" bgcolor="WhiteSmoke" class="rdgrow" colspan="2">
                                <asp:RadioButtonList ID="optSelect" runat="server" AccessKey="C" BackColor="LightGray" 
                                    BorderColor="WhiteSmoke" BorderWidth="0px" CellPadding="0" CellSpacing="0" 
                                    RepeatDirection="Horizontal" Width="100%" AutoPostBack="True" 
                                    onselectedindexchanged="optSelect_SelectedIndexChanged">
                                    <asp:ListItem>Create</asp:ListItem>
                                    <asp:ListItem>Display</asp:ListItem>
                                    <asp:ListItem>Alter</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrowH">
                                <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label>
                            </td>
                            <td align="left"  >
                                 <asp:TextBox ID="txtSearch" runat="server" CssClass="rdginputbox" 
                                     onblur="this.className='blur'" onfocus="this.className='focus'" 
                                     Width="279px"></asp:TextBox>
                                 <Custom:AutoSuggestMenu ID="asmStudent1" runat="server" KeyPressDelay="10" 
                                     MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate2" 
                                     OnGetSuggestions="GetSuggestions" PageSize="20" ResourcesDir="../asm_includes" 
                                     TargetControlID="txtSearch" UpdateTextBoxOnUpDown="False" 
                                     UsePageMethods="True" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                Name</td>
                            <td align="left">
                                <asp:TextBox ID="txtGrName" runat="server" CssClass="rdginputbox" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" 
                                    Width="239px"></asp:TextBox>
                                &nbsp;<span class="mandetory">*</span></td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                 Abbr.</td>
                            <td align="left">
                                 <asp:TextBox ID="txtAbr" runat="server" CssClass="rdginputbox"   
                                     Width="113px" onfocus="this.className='focus'" 
                                     onblur="this.className='blur'" ></asp:TextBox>
                                 </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                 Under</td>
                            <td align="left">
                                 <asp:TextBox ID="txtUnder" runat="server" CssClass="rdginputbox"   
                                     Width="239px" onfocus="this.className='focus'" 
                                     onblur="this.className='blur'" ></asp:TextBox>
                                 &nbsp;<span class="mandetory">*</span><Custom:AutoSuggestMenu id="asmStudent0" 
                                     runat="server" KeyPressDelay="10" 
                                MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate1" 
                                OnGetSuggestions="GetSuggestions" ResourcesDir="../asm_includes" 
                                TargetControlID="txtUnder" UpdateTextBoxOnUpDown="False" 
                                UsePageMethods="True" PageSize="20"></Custom:AutoSuggestMenu>
                                 </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                <asp:Label ID="Label1" runat="server"   Text="Nature of Group" ></asp:Label>
                             </td>
                            <td align="left" class="rdgrow">
                                 <asp:DropDownList ID="ddlNature" runat="server" CssClass="rdgdropdown" 
                                     Width="80px">
                                     <asp:ListItem>Assets</asp:ListItem>
                                     <asp:ListItem>Expenses</asp:ListItem>
                                     <asp:ListItem>Income</asp:ListItem>
                                     <asp:ListItem>Liabilities</asp:ListItem>
                                     <asp:ListItem Selected="True" Value="0">---Select---</asp:ListItem>
                                 </asp:DropDownList>
                                 <span class="mandetory">&nbsp;* </span>(Mandatory in case of Primary)</td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow" colspan="2">
                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" class="rdgrow" colspan="2">
                                 <center>
                                     
                                     <table  >
                                         <tr>
                                             <td class="style4">
                                                 <asp:Button ID="cmdSubmit" CssClass="buttons" runat="server" Text="Submit" 
                                                     onclick="cmdSubmit_Click"   Width="85px" /></td>
                                             <td>
                                                <asp:Button ID="cmdReset" CssClass="buttons" runat="server" Text="Reset" 
                                                     onclick="cmdReset_Click"  Width="61px" /></td>
                                         </tr>
                                     </table>
                                 </center></td>
                        </tr>
                    </table>
                </td>
            </tr>
        <tr  >
                <td  > 
                    <asp:Button ID="cmdSearch" runat="server" Text="Button" Width="1" Height="1" style="background-color:White;border:none" 
                        onclick="cmdSearch_Click" />
                </td>
                <td  > 
                    <asp:Button ID="cmdSearch1" runat="server" Text="Button" Width="1" Height="1" style="background-color:White;border:none" 
                        onclick="cmdSearch1_Click" />
                </td>
                 <td  > 
                     &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
