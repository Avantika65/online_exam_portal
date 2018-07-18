<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Academic_Schedule.aspx.cs" EnableTheming="true"
    StylesheetTheme="BasicBlue" Theme="BasicBlue" Inherits="GatePass_Gate_Pass_Internal" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CalendarExtenderPlus" namespace="AjaxControlToolkitPlus" tagprefix="CC11" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register Namespace="MSS" TagPrefix="Custom" %> 
<%@ Register assembly="CommonClassLibrary" namespace="CommonClassLibrary" tagprefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" src="../datetimepicker.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.core.js" type="text/javascript"></script>
    <link href="../js/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../js/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-ui-1.8.6.custom.js" type="text/javascript"></script>
    <style type="text/css">
        .toolTip
        {
            border: 1px solid #CCC;
            background-color: #F9F9F9;
            width: 150px;
            position: absolute;
            visibility: hidden;
            overflow: hidden;
            font-family: Geneva, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: normal;
            color: #333;
        }
        #toolTip h1
        {
            display: block;
            font-family: Geneva, Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            background-color: #F1F1F1;
            border-bottom: 1px solid #CCC;
            margin: 0px;
            padding: 0px 2px;
        }
        #toolTip p
        {
            margin: 0px;
            padding: 4px 2px;
        }
        div.MaskedDiv
        {
            position: absolute;
            background-color: #fff;
            filter: alpha(opacity=70);
            mozopacity: 0.7;
            opacity: 0.7;
            padding: 0px;
            margin: 0px;
        }
        h1
        {
            display: block;
            font-family: Geneva, Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            background-color: #F1F1F1;
            border-bottom: 1px solid #CCC;
            margin: 0px;
            padding: 0px 2px;
        }
        div.ModalPopup
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            background-color: #CCCCCC;
            position: absolute; /* set z-index higher than possible */
            z-index: 10000;
            visibility: hidden;
            color: Black;
            border-style: solid;
            border-color: #999999;
            border-width: 1px;
    
            height: auto;
        }
              
    .mGrid { width: 100%; background-color: #fff; margin: 2px 0 1px 0; border: solid 1px #525252;font:arial; border-collapse:collapse;text-align:left;font-size: 0.9em; }
                  
        .style1
        {
            height: 23px;
        }
                  
        .style3
        {
            height: 2px;
        }
                  
    </style>
    <script language="javascript" type="text/javascript" >
        function onTextBoxUpdate1(evt) 
        {
            var textBoxID = evt.source.textBoxID;
            document.getElementById(textBoxID).value = evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdSearch").click();
            evt.preventDefault();
        }
        function onTextBoxUpdate2(evt)
         {
            var textBoxID = evt.source.textBoxID;
            document.getElementById(textBoxID).value = evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdSearch2").click();
            evt.preventDefault();
        }
        function onTextBoxUpdate3(evt)
         {
            var textBoxID = evt.source.textBoxID;
            document.getElementById(textBoxID).value = evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdSearch3").click();
            evt.preventDefault();
        }
        function cleartext1()
         {
             document.getElementById("txtActHead").value = "";
         }
         function cleartext2()
          {
             document.getElementById("txtSubActHD").value = "";
          }
          function cleartext3()
          {
              document.getElementById("txtSubTypHD").value = "";
          }
            function UpperCase(elem)        
              {
                 elem.value = elem.value.toUpperCase();
               } 
         
   
   
    </script>
</head>
<body onload="startclock();">
    <form id="form1" runat="server" method="post" action="">
<input id="hdID" runat="server" type="hidden" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" style="border: 1px solid #006699" >
                <tr>
                    <td colspan="5">
                        <div id="lbltitle" style="width: 100%" class="header" runat="server" height="380px">
                        </div></td>
                </tr>
                
                </tr>
                <tr>
                    <td>
                        Activity Name</td>
                        <td>                        
                            <asp:DropDownList ID="ddlActivity" runat="server" Height="20px" Width="229px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlActivity_SelectedIndexChanged">
                            </asp:DropDownList>                        
                        </td>
                        <td>User Name</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtUsrName" runat="server" Height="18px" Width="126px"></asp:TextBox>
                    </td>
                        
                        </tr>
                <tr>
                    <td>
                        Type Of Activity</td>
                    <td>
                        <asp:DropDownList ID="ddlActivitytype" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlActivitytype_SelectedIndexChanged" Width="230px">
                        </asp:DropDownList>
                    </td>
                        <td>
                            Activity Head</td>
                        <td>
                            <asp:TextBox ID="txtActHead" runat="server" Height="18px" Width="229px" onclick = "cleartext1();" >Search Here</asp:TextBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="Chksub" runat="server" AutoPostBack="True" 
                            oncheckedchanged="Chksub_CheckedChanged" Text="Is any Sub Activity" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSub" runat="server" Text="Sub Activity" Visible="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="ddlSubAct" runat="server" AutoPostBack="True" 
                            Height="19px" onselectedindexchanged="ddlSubAct_SelectedIndexChanged" 
                            Visible="False" Width="230px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblSubActivity" runat="server" Text="Activity Head" 
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubActHD" runat="server" Height="18px" Width="229px" 
                            Visible="False" onclick ="cleartext2()" >Search Here</asp:TextBox>
                    </td>
                    <td>
                        <asp:CheckBox ID="ChksubAct" runat="server" AutoPostBack="True" 
                            oncheckedchanged="ChksubAct_CheckedChanged" Text="Is any Sub Activity" 
                            Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubAct" runat="server" Text="Sub Activity Type" 
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubActType" runat="server" Visible="False" 
                            Width="231px" Height="20px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;<asp:Label ID="lblSubActivityType" runat="server" Text="Activity Head" 
                            Visible="False"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtSubTypHD" runat="server" Height="18px" Width="229px" 
                            Visible="False" onclick = "cleartext3()">Search Here</asp:TextBox>
                    </td>
                </tr>                
                <tr>
                    <td colspan="2">
                        <fieldset>
                        <legend class="rdgrowL">Proposed Date</legend>
                        <table style="width: 96%">
                                <tr>
                                    <td>
                                        From Date                                       
                                    </td>                                         
                                    <td>
                                        <asp:TextBox ID="txtfrmDate" runat="server" Width="137px" Height="20px" AutoPostBack="True" 
                                            ontextchanged="txtfrmDate_TextChanged" ></asp:TextBox> 
                                            <ajax:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfrmDate" Format="dd-MMM-yyyy" runat="server" PopupButtonID="txtfrmDate" >
                                             </ajax:CalendarExtender> 
                                            </td>                                      
                           </tr>
                                <tr>
                                    <td>
                                        To Date</td>
                                    <td>
                                        <asp:TextBox ID="txttoDate" runat="server" Width="137px" Height="20px" 
                                            AutoPostBack="True" ontextchanged="txttoDate_TextChanged"></asp:TextBox>
                                            <ajax:CalendarExtender ID="CalendarExtender2" TargetControlID="txttoDate" Format="dd-MMM-yyyy" runat="server" PopupButtonID="txttoDate">
                                             </ajax:CalendarExtender>                                                                                 
                                    </td>                                   
                                </tr>
                            </table>                       
                        </fieldset></td>                   
                       <td colspan="3">
                        <fieldset>
                    <legend class = "rdgrowL">Proposed Time</legend>
                     <table style="width: 96%">
                                <tr>
                                    <td>
                                        From Time
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromTime" runat="server" Width="127px" Height="20px" onBlur = "UpperCase(this);"></asp:TextBox><span class = "rdgrowL">(00:00 AM/PM)</span>
                                        
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        To Time</td>
                                    <td>
                                        <asp:TextBox ID="txtToTime" runat="server" Width="127px" Height="20px" onBlur = "UpperCase(this);"></asp:TextBox><span class = "rdgrowL">(00:00 AM/PM)</span>                                        
                                    </td>
                                </tr>
                            </table>
                    </fieldset>
                       
                       </td>
                      

                </tr>
                <tr>
                <td align="center" colspan="5">
                    <asp:Button ID="btnActivity" runat="server" Height="23px" 
                        onclick="btnActivity_Click" Text="Save" Width="70px" />
                    <asp:Button ID="btnDelete" runat="server" Height="23px" 
                        onclick="btnDelete_Click" Text="Delete" Width="70px " />
                    <asp:Button ID="btnReset" runat="server" Height="23px" onclick="btnReset_Click" 
                        Text="Reset" Width="70px " />
                    </td>                                
                </tr>
                <tr>
                <td colspan="5">
               <%-- <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="200px" Width="100%">--%>
                 <div id="dvLeft" style="width:1128px; height:220px; overflow: scroll;">            
                    <cc2:GroupedGridView ID="gvActivity" runat="server" AutoGenerateColumns="False" style="width:1500px"
                        CellPadding="0" GroupedDepth="3">
                        <Columns>
                            <asp:BoundField DataField="Activity_Name" HeaderText="Activity Name" />
                            <asp:BoundField DataField="Activity_Type_Name" HeaderText="Type of Activity" />
                            <asp:BoundField DataField="SubActivity" HeaderText="Sub Activity" />
                             <asp:BoundField DataField="SubActivityName" HeaderText="Sub Activity Type" />                          
                          
                            <asp:TemplateField HeaderText="Activity_ID" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AcademicID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AcademicID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fromDate" 
                                HeaderText="From Date" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="ToDate" 
                                HeaderText="To Date" DataFormatString="{0:dd-MMM-yyyy}" />
                            <asp:BoundField DataField="FromTime" HeaderText="From Time" />
                            <asp:BoundField DataField="ToTime" HeaderText="To Time" />
                            <asp:BoundField DataField="ActivityHead" HeaderText="Activity  Head" />
                            <asp:BoundField DataField="ActivityTypeHead" HeaderText="Sub Activity Head" />
                            <asp:BoundField DataField="SubActivityHead" HeaderText="Activity Head" />
                            <asp:TemplateField HeaderText="">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkEdit" runat="server" onclick="LinkEdit_Click" 
                                        Height="17px" Width="35px">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </cc2:GroupedGridView>
                     <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="popupwindow" TargetControlID="popup" CancelControlID="btnYes">
                                      </asp:ModalPopupExtender>
                                    <asp:Button ID="popup" runat="server" style="display:none"/>
                                     <asp:DragPanelExtender ID="DragPanelExtender1" runat="server" TargetControlID="popupwindow"> 
                                   </asp:DragPanelExtender>     
                                  <asp:Panel ID="popupwindow" runat="server" style="display:none" >                         
                              <table width="100%">
                          <tr>
                          <td>
                         </td>
                       <td align ="center" valign="top">
                     <table class="rdgrow" style="border: 2px solid  #df5015;" width="600px">                
                 <tr>
                 <td>
                 <div class="header1" align ="center">CONFIRMATION BOX</div>
                 </td>
                 </tr> 
                 <tr>
                 <td>
                     &nbsp;</td>
                 </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                                     Font-Underline="False" ForeColor="Black" 
                                     Text="This Date Already Alloted to other Activity, Do you want to Allot this date to other Activity also...!!!"></asp:Label>
                             </td>
                         </tr>
                          <tr>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td>
                                 &nbsp;</td>
                         </tr>
                        
                 <tr>
                 <td align="center">
                     <asp:Button ID="btnYes" runat="server" Text="Yes" Height="26px" Width="70px" 
                         BackColor="#FF3300"/>
                     <asp:Button ID="btnNo" runat="server" Text="No" Height="26px" Width="70px" 
                         onclick="btnNo_Click" BackColor="#FF3300"/>
                 </td>
                 </tr>           
                </table>
               
                </td>
                <td>
                </td>
                </tr>                
                </table>
            </asp:Panel>                  
                </td>
                </tr>
                <tr><td>
                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="popupWindow_Confirm" TargetControlID="btnwindow" CancelControlID="btnyess">
                                      </asp:ModalPopupExtender>
                                    <asp:Button ID="btnwindow" runat="server" style="display:none"/>
                                    <asp:DragPanelExtender ID="DragPanelExtender2" runat="server" TargetControlID="popupWindow_Confirm"> 
                                   </asp:DragPanelExtender>    
                                  <asp:Panel ID="popupWindow_Confirm" runat="server"  style="display:none"   >                         
                              <table width="100%">
                          <tr>
                          <td>
                         </td>
                       <td align ="center" valign="top">
                     <table class="rdgrow" style="border: 2px solid  #df5015;" width="600px">                
                 <tr>
                 <td>
                 <div class="header1" align ="center">Confirmation Box</div>
                 </td>
                 </tr>
                   <tr>
                 <td>
                     &nbsp;</td>
                 </tr> 
                 <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" ForeColor="Black" 
                         Text="This Date Already Alloted to other Activity, Do you want to Allot this date to other Activity also...!!!" 
                         Font-Bold="True" Font-Size="Large" Font-Underline="False"></asp:Label>
                     </td>
                 </tr>
                  <tr>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td>
                                 &nbsp;</td>
                         </tr>
                 <tr>
                 <td align="center">
                     <asp:Button ID="btnyess" runat="server" Text="Yes" Height="26px" Width="70px" BackColor="#FF3300"/>
                     <asp:Button ID="Button2" runat="server" Text="No" onclick="Button2_Click1"  
                         Height="26px" Width="70px" BackColor="#FF3300"/>
                          
                 </td>
                 </tr>           
                </table>
               
                </td>
                <td>
                </td>
                </tr>                
                </table>
            </asp:Panel>   </td></tr>        
               

            </table>          
            
             <asp:HiddenField ID="HDActivity" runat="server" />
                    <Custom:AutoSuggestMenu ID="txtempname" runat="server" KeyPressDelay="10" 
                        MaxSuggestChars="100" MinSuggestChars="4" 
                        OnClientTextBoxUpdate="onTextBoxUpdate1" OnGetSuggestions="GetSuggestions" 
                        PageSize="20" TargetControlID="txtActHead" UpdateTextBoxOnUpDown="False" 
                        UsePageMethods="True" />
                    <asp:Button ID="cmdSearch" runat="server" BackColor="White" BorderColor="White" 
                        BorderStyle="None" CausesValidation="False" 
                        Width="16px" Visible="False" />
                    <Custom:AutoSuggestMenu ID="txtEmpname2" runat="server" KeyPressDelay="10" 
                        MaxSuggestChars="100" MinSuggestChars="4" 
                        OnClientTextBoxUpdate="onTextBoxUpdate2" OnGetSuggestions="GetSuggestions1" 
                        PageSize="20" TargetControlID="txtSubActHD" UpdateTextBoxOnUpDown="False" 
                        UsePageMethods="True" MenuItemCssClass="asmMenuItem" />
                    <asp:Button ID="cmdSearch2" runat="server" BackColor="White" 
                        BorderColor="White" BorderStyle="None" CausesValidation="False" 
                        Width="16px" Visible="False" />
                    <Custom:AutoSuggestMenu ID="txtEmpname3" runat="server" KeyPressDelay="10" 
                        MaxSuggestChars="100" MenuItemCssClass="asmMenuItem" MinSuggestChars="4" 
                        OnClientTextBoxUpdate="onTextBoxUpdate3" OnGetSuggestions="GetSuggestions2" 
                        PageSize="20" TargetControlID="txtSubTypHD" UpdateTextBoxOnUpDown="False" 
                        UsePageMethods="True" />
                    <asp:Button ID="cmdSearch3" runat="server" BackColor="White" 
                        BorderColor="White" BorderStyle="None" CausesValidation="False" 
                        Width="16px" Visible="False" />         
     </ContentTemplate>  
             <%--<Triggers>
             <asp:PostBackTrigger ControlID="txtfrmDate" />
             </Triggers>--%>
    </asp:UpdatePanel>     
   </form>
       </body>
</html>
