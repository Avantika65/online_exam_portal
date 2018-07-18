<%@ Page Language="C#" AutoEventWireup="true" Title="Ledger" CodeFile="Ledger.aspx.cs" EnableTheming="true" EnableSessionState="True"  Inherits="Account_Ledger" %>
<%@ Register TagPrefix="FH1" TagName="TopImageControl"  Src="~/UserControls/FormHeader.ascx" %>
<%@ Register namespace="MSS" tagprefix="Custom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ledger</title>
            <link type="text/css" rel="Stylesheet" href="../Account.css"/>


    <script language ="javascript">
    function CopyName()
    {
     if (document.getElementById("txtLname").value !="")
        {
        document.getElementById("txtName").value =document.getElementById("txtLname").value;
        }
    }
       function CopyName1()
    {
     if (document.getElementById("txtMname").value !="")
        {
        document.getElementById("txtName").value =document.getElementById("txtMname").value;
        }
    }
    function onTextBoxUpdate2(evt)
        {        
            var textBoxID=evt.source.textBoxID;
            debugger;
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdSearch").click();
            evt.preventDefault();
        } 
         function onTextBoxUpdate3(evt)
        {     
           
        var textBoxID=evt.source.textBoxID;
            
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
             document.getElementById("cmdSearch").click();
            evt.preventDefault();
        }
             function onTextBoxUpdate1(evt)
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
    <form id="form1" runat="server" style="width:100%">
                                         
   <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    <Scripts><asp:ScriptReference Path="~/FixFocus.js" /></Scripts>
    </asp:ScriptManager>
     
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <table style="border: 1px solid black; width: 100%" cellpadding="1" cellspacing="1"    >
                        <tr>
                            <td colspan="2"  class="header"> Ledger Creation</td>
                        </tr>
                        <tr>
                            <td align="center" class="rdgrow" colspan="2">
                                <asp:RadioButtonList ID="optSelect" runat="server" AccessKey="C" 
                                    AutoPostBack="True" BackColor="LightGray" BorderColor="#999999" 
                                    BorderWidth="0px" CellPadding="0" CellSpacing="0" 
                                    onselectedindexchanged="optSelect_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal" Width="100%">
                                    <asp:ListItem>Create</asp:ListItem>
                                    <asp:ListItem>Display</asp:ListItem>
                                    <asp:ListItem>Alter</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                
                              <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>  </td>
                            <td align="left" class="rdgrow">
                                 <asp:TextBox ID="txtSearch" runat="server" CssClass="rdginputbox" 
                                     onblur="this.className='blur'" onfocus="this.className='focus'" Width="279px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp; Create Ledger from</td>
                            <td align="left" class="rdgrow">
                                <asp:RadioButtonList ID="RdbStEmp" runat="server" AccessKey="C" 
                                    AutoPostBack="True" BorderColor="WhiteSmoke" CellPadding="0" CellSpacing="0" 
                                    onselectedindexchanged="RdbStEmp_SelectedIndexChanged" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="S">Student Detail</asp:ListItem>
                                    <asp:ListItem Value="E">Employee Detail</asp:ListItem>
                                    <asp:ListItem Value="I">Institutes</asp:ListItem>
                                    <asp:ListItem Value="M">Manual</asp:ListItem>
                                </asp:RadioButtonList> </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp; Name<span class="mandetory">*</span></td>
                            <td align="left">
                                <table >
                                    <tr>
                                        <td>
                                               <asp:TextBox ID="txtLname" runat="server" CssClass="rdginputbox" 
                                                onblur="this.className='blur';CopyName()" onfocus="this.className='focus'" Width="239px"></asp:TextBox>
                                            <asp:TextBox ID="txtMname" CssClass="rdginputbox" onfocus="this.className='focus'"  onblur="this.className='blur';CopyName1()" Width="239px" runat="server"></asp:TextBox> 
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                 &nbsp; Abbr.</td>
                            <td align="left">
                                 <asp:TextBox ID="txtAbr" runat="server" CssClass="rdginputbox"   
                                     Width="113px" onfocus="this.className='focus'" onblur="this.className='blur'"  ></asp:TextBox>
                            <Custom:AutoSuggestMenu ID="asmStudent2" runat="server" KeyPressDelay="10" 
                                MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate3" 
                                OnGetSuggestions="GetSuggestions2" ResourcesDir="../asm_includes" 
                                TargetControlID="txtLName" UpdateTextBoxOnUpDown="False" 
                                UsePageMethods="True" />
                                 </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                 &nbsp; Under<span class="mandetory">*</span></td>
                            <td align="left" class="rdgrow">
                                 <asp:TextBox onfocus="this.className='focus'" onblur="this.className='blur'" ID="txtUnder" runat="server" CssClass="rdginputbox"   
                                     Width="239px"  ></asp:TextBox>
                                 <asp:Label ID="lblGrpNature" runat="server" ></asp:Label>
                                 <asp:RequiredFieldValidator ID="rvUnder" runat="server" 
                                     ControlToValidate="txtUnder" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                 </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                 &nbsp; Opening Balance (01-Apr-2010)</td>
                            <td align="left">
                                 <table class="style3" border="0" cellpadding="0" cellspacing="0">
                                     <tr>
                                         <td class="style5">
                                 <asp:TextBox ID="txtOpBal" onfocus="this.className='focusR'" onblur="this.className='blurR'" runat="server" CssClass="rdginputboxR"   
                                     Width="138px"  >0.00</asp:TextBox>
                                         </td>
                                         <td>
                                 <asp:RadioButtonList ID="optCr" runat="server" CellPadding="0" 
                                     CellSpacing="0" RepeatDirection="Horizontal" CssClass="rdgrow">
                                     <asp:ListItem>Cr</asp:ListItem>
                                     <asp:ListItem Selected="True">Dr</asp:ListItem>
                                 </asp:RadioButtonList>
                                         </td>
                                     </tr>
                                 </table>
                                 </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrowL" colspan="2" valign="top">
                                <img src="../license.gif" alt="" style="height: 18px" /> Mailing  Related Details</td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp; Name</td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" CssClass="rdginputbox" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" Width="259px"></asp:TextBox>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp;Address&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="txtAdd" runat="server" CssClass="rdginputbox" Height="40px" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" 
                                    TextMode="MultiLine" Width="261px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp;State</td>
                            <td align="left">
                                <asp:TextBox ID="txtState" runat="server" CssClass="rdginputbox" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" Width="259px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp;Pincode</td>
                            <td align="left">
                                <asp:TextBox ID="txtPinCode" runat="server" CssClass="rdginputbox" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" Width="113px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp;Income Tax No&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="txtITN" runat="server" CssClass="rdginputbox" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" Width="113px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp;Sales Tax No.&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="txtSTN" runat="server" CssClass="rdginputbox"  
                                    onblur="this.className='blur'" onfocus="this.className='focus'" Width="113px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                &nbsp;Account No&nbsp;</td>
                            <td align="left">
                                <asp:TextBox ID="txtAccNo" runat="server" CssClass="rdginputbox" 
                                    onblur="this.className='blur'" onfocus="this.className='focus'" Width="113px"></asp:TextBox>
                            </td>
                        </tr>
                         
                        <tr>
                            <td align="center" class="rdgrow" colspan="2">
                                 <center>
                                     
                                     <table cellpadding="2" cellspacing="2"  >
                                         <tr>
                                             <td >
                                                 <asp:Button ID="cmdSubmit" CssClass="buttons" runat="server" Text="Submit" 
                                                     onclick="cmdSubmit_Click"   Width="81px" /></td>
                                             <td>
                                                <asp:Button ID="cmdReset" CssClass="buttons" runat="server" Text="Reset" 
                                                     onclick="cmdReset_Click"   Width="75px" />
                                                 <asp:Button ID="cmdSearch" runat="server" CausesValidation="False" Height="1px" style="background-color:White;border:none"
                                                     onclick="cmdsearch_Click" Text="Button" UseSubmitBehavior="False" Width="1px" />
                                             </td>
                                         </tr>
                                     </table>
                                 </center></td>
                        </tr>
                    </table>
                </td>
            </tr>
        <tr  >
                <td>
                                                 <Custom:AutoSuggestMenu ID="asmStudent1" runat="server" KeyPressDelay="10" 
                                                     MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate2" 
                                                     OnGetSuggestions="GetSuggestions1" PageSize="20" ResourcesDir="../asm_includes" 
                                                     TargetControlID="txtSearch" UpdateTextBoxOnUpDown="False" 
                                                     UsePageMethods="True" />
                                                 </td>
                 <td style="margin-left: 40px"  > 
                                                 <asp:Button ID="cmdsearch1" runat="server" Height="1px" style="background-color:White;border:none"
                                                      Width="1px" onclick="cmdsearch1_Click" CausesValidation="False" />
                                 <span class="mandetory"> 
                                 <Custom:AutoSuggestMenu id="asmStudent0" 
                                     runat="server" KeyPressDelay="10" 
                                MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate1" 
                                OnGetSuggestions="GetSuggestions" ResourcesDir="../asm_includes" 
                                TargetControlID="txtUnder" UpdateTextBoxOnUpDown="False" 
                                UsePageMethods="True" PageSize="20"></Custom:AutoSuggestMenu>
                                 </span> <input id="hdType" runat="server"  type="hidden" />    <input id="hdLedger_id" runat="server" 
        type="hidden" />
    <input id="hduid" type="hidden" runat="server"/>
                            
                            <input id="hdcontp" type="hidden" runat="server" />
                                             </td>
                                             </ContentTemplate>
                    </asp:UpdatePanel>
    </form>
</body>
</html>
