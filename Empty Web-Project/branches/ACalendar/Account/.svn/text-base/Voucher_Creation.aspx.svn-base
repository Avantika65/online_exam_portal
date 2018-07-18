<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Voucher_Creation.aspx.cs" Inherits="Account_Voucher_Creation" %>
<%@ Register TagPrefix="FH1" TagName="TopImageControl"  Src="~/UserControls/FormHeader.ascx" %>
<%@ Register namespace="MSS" tagprefix="Custom" %>
<%@ OutputCache NoStore="true" Duration="1" VaryByParam="none"  %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voucher Creation</title>
    <link type="text/css" rel="Stylesheet" href="../Account.css"/>
    <link type="text/css" rel="Stylesheet" href="../asm_includes/AutoSuggestBox.css"/>
    <link type="text/css" rel="Stylesheet" href="../asm_includes/AutoSuggestMenu.css"/>
    <script language="javascript" src="../datetimepicker.js" type="text/javascript"></script>
        
         <script language ="javascript">
     
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
          
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdsearch1").click();
            evt.preventDefault();
        }   
         function onTextBoxUpdate4(evt)
        {        
            var textBoxID=evt.source.textBoxID;
           
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdsearch2").click();
            evt.preventDefault();
        }   
         function onTextBoxUpdate3(evt)
        {        
            var textBoxID=evt.source.textBoxID;
           
            document.getElementById(textBoxID).value=evt.selMenuItem.label; // + " (modified by onTextboxUpdate)";
            document.getElementById("cmdsearch3").click();
            evt.preventDefault();
        }   
         function openPopup(part)
    {
      var checkType;
     checkType=document.getElementById('hdvoutype').value;
     if(checkType=="0"){ return;}
  
      var checkParent;
     checkParent=document.getElementById('hdParent').value;
     if(checkParent!="4" && checkParent!="29" && checkParent!="30" ){ return;}
    
     //hdParticular
     var Particular;
     Particular=document.getElementById('hdParticular').value;//
 var par;
 par=document.getElementById('txtpart').value;
 var am;
 am=document.getElementById('txtamt').value;
    var strReturn;
    var strArr;
		var opStr;
		var opVal;
		var oList;
		var PID="";
		var SID="";
		var i;
		var op;
		debugger;
          strReturn=  window.showModalDialog("BillwiseDetails.aspx?N="+par +"&am="+ am+"&ParID="+ Particular+"&vid="+document.getElementById('txtNo').value, "Info", "status:1; dialogWidth:700px; dialogHeight:400px; top:100px; left:100px;");
          debugger;
          if ((strReturn=="")||(strReturn==null))
          {
			//alert("Not selected !");
			return 0;
	      }
	      alert(strReturn);
	      document.getElementById("btnadd").click();
	    //  debugger;
//	      strArr = strReturn.split(";");
//	      var S=strArr[0].split(":");
//	      for (i=0;i<=S.length-1;i++)
//	            {
//	        if (i%2==0)
//              {
//	           if ((SID=="")&& (SID !="undefined"))
//                  { 
//                    SID=S[i];
//                  }
//               else{
//                    SID=SID +"," + S[i];
//                   }
//                }  
//	         }
//		  opStr = strArr[0].split(":");
//          opVal = strArr[1].split(":");
//        
//          for(i=0;i<opVal.length;i++)
//          {
//            if ((PID=="")&& (PID !="undefined"))
//               { 
//               PID=opVal[i];
//               }
//           else
//                {
//                PID=PID +"," + opVal[i];
//               }
//           }
//            GetCustomer(PID,SID);
    }
        </script>
       
    <style type="text/css">
        .style1
        {
            TEXT-ALIGN: left;
            COLOR: coral;
            background-color: whitesmoke;
            FONT-SIZE: 10px;
            font-family: arial;
            font-weight: normal;
            width: 540px;
        }
        .style2
        {
        }
        .style3
        {
            TEXT-ALIGN: left;
            COLOR: coral;
            background-color: whitesmoke;
            FONT-SIZE: 10px;
            font-family: arial;
            font-weight: normal;
            width: 103px;
        }
        .style4
        {
            width: 103px;
        }
    </style>
       
</head>
<body  >
    <form id="form1" runat="server" style="width:100%" >
    <input id="hdLedger_id" runat="server" type="hidden" />
   <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server">
  
    </asp:ScriptManager>
   
    <table  width="100%">
            <tr><td> <table  width="100%">
        <tr  >
                <td align="center"  > 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate> 
                    <table style=" width: 100%"  cellpadding="0" cellspacing="0"   >
                    <tr><td class="header" colspan="4"> Voucher Creation</td></tr>
                        <tr>
                            <td align="left" class="rdgrow">
                                 <table style="border: 1px solid black;width:100%" cellpadding="0" cellspacing="0">
                                     <tr>
                                         <td class="style5" colspan="3">
                                             <table  width="100%">
                                                 <tr>
                                                     <td class="rdgrow" colspan="4">
                                                         <asp:RadioButtonList ID="optSelect" runat="server" AccessKey="C" 
                                                             AutoPostBack="True" bgcolor="WhiteSmoke" BorderColor="#999999" 
                                                             BorderWidth="0px" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" 
                                                             Width="100%" BackColor="LightGray" 
                                                             onselectedindexchanged="optSelect_SelectedIndexChanged">
                                                             <asp:ListItem Value="0">Contra</asp:ListItem>
                                                             <asp:ListItem Value="1">Payment</asp:ListItem>
                                                             <asp:ListItem Value="2">Receipt</asp:ListItem>
                                                             <asp:ListItem Value="3">Journal</asp:ListItem>
                                                             <asp:ListItem Value="4">Credit Note</asp:ListItem>
                                                             <asp:ListItem Value="5">Debit Note</asp:ListItem>
                                                         </asp:RadioButtonList>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td class="style17" >
                                                         Voucher Type<span class="mandatoryfields">*</span></td>
                                                     <td class="style11">
                                                         <asp:TextBox ID="txtvtype" onfocus="this.className='focus'" onblur="this.className='blur'" runat="server" CssClass="rdginputbox" 
                                                             Width="200px" ></asp:TextBox>
                                                     </td>
                                                     <td class="style23">
                                                         Voucher No<span class="mandatoryfields">*</span></td>
                                                     <td>
                                                         <asp:TextBox ID="txtNo" runat="server" CssClass="rdginputbox" 
                                                             onfocus="this.className='focus'" onblur="this.className='blur'"
                                                             Width="105px"></asp:TextBox>
                                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                         <asp:Label ID="Label6" runat="server" Text="Date"></asp:Label><span class="mandatoryfields">*</span>
                                                         &nbsp;
                                                         <asp:TextBox ID="txtDate" runat="server" CssClass="rdginputbox" 
                                                             onblur="checkdate1(this,'en-US','dd/MMM/yyyy');this.className='blur'" onfocus="this.className='focus'"  Width="80px"></asp:TextBox>
                                                         &nbsp;<img alt="" 
                                                             onclick="window.open('CalendarPopUp.aspx?textbox=txtDate','cal','width=250,height=225,left=270,top=180')" 
                                                            style="height:14px" src="../images/SmallCalendar.gif" /></td>
                                                 </tr>
                                                 <tr>
                                                     <td  >
                                                         <asp:Label ID="lblacc" runat="server" Text="Account"></asp:Label><span class="mandatoryfields">*</span>
                                                         <asp:Label ID="lblref" runat="server" Text="Ref"></asp:Label>
                                                     </td>
                                                     <td class="style11">
                                                         <asp:TextBox ID="txtacc" runat="server" CssClass="rdginputbox" onfocus="this.className='focus'" onblur="this.className='blur'"
                                                             Width="200px" ></asp:TextBox>
                                                         <asp:DropDownList ID="ddlTtype" runat="server" CssClass="rdgdropdown" 
                                                             Width="66px">
                                                             <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                             <asp:ListItem Value="CR">CR</asp:ListItem>
                                                             <asp:ListItem Value="DR">DR</asp:ListItem>
                                                         </asp:DropDownList><span class="mandatoryfields">*</span>
                                                         <br />
                                                         <asp:Label ID="lblcbal" runat="server" Text="Curr Bal"></asp:Label>
                                                         <asp:Label ID="lblcurrbal" runat="server"></asp:Label>
                                                         <asp:Label ID="lblCr" runat="server"></asp:Label>
                                                     </td>
                                                     <td valign="top" >
                                                         &nbsp;</td>
                                                     <td>
                                                         <asp:TextBox ID="txtref" runat="server" CssClass="rdginputbox" 
                                                             onblur="this.className='blur'" onfocus="this.className='focus'" Width="80px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                             </table>
                                         </td>
                                     </tr>
                                     <tr align="left">
                                         <td colspan="3" height="1">
                                             <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                 <table width="100%" cellpadding="0" cellspacing="1">
                                                     <tr>
                                                         <td align="left" class="style3"  >
                                                             S.No</td>
                                                         <td align="left" class="style1"  >
                                                             Particulars</td>
                                                         <td align="left" class="rdgrowL" >
                                                             Amount</td>
                                                         <td  >
                                                             &nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="style4">
                                                             <asp:Label ID="lblsno" runat="server"></asp:Label>
                                                         </td>
                                                         <td align="left"   >
                                                             <asp:TextBox ID="txtpart" runat="server" CssClass="rdginputbox" onfocus="this.className='focus'" onblur="this.className='blur'"
                                                                 Width="200px"></asp:TextBox>
                                                             <asp:DropDownList ID="ddlTtype0" runat="server" CssClass="rdgdropdown" 
                                                                 Width="66px">
                                                                 <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                                 <asp:ListItem Value="CR">CR</asp:ListItem>
                                                                 <asp:ListItem Value="DR">DR</asp:ListItem>
                                                             </asp:DropDownList><span class="mandatoryfields">*</span>
                                                         </td>
                                                         <td align="left">
                                                             <asp:TextBox ID="txtamt" runat="server" CssClass="rdginputboxR" onkeypress="decimalNumber(this)" onfocus="this.className='focusR'" onblur="this.className='blurR';openPopup('<%=rdbl%>');"></asp:TextBox><span class="mandatoryfields">*</span>
                                                         </td>
                                                         <td align="left">
                                                             <asp:Button ID="btnadd" runat="server" CssClass="buttons" Enabled="False" 
                                                                 Text="Add" Width="59px" onclick="btnadd_Click"  />
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="style4">
                                                             &nbsp;</td>
                                                         <td align="left" class="style2">
                                                             Curr Bal &nbsp;&nbsp;
                                                             <asp:Label ID="lblCurrblnc" runat="server"></asp:Label>
                                                             <asp:Label ID="lblCrDr" runat="server"></asp:Label>
                                                         </td>
                                                         <td>
                                                             &nbsp;</td>
                                                         <td>
                                                             &nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td   colspan="4">
                                                             <asp:GridView ID="grdcon" runat="server" AutoGenerateColumns="False" 
                                                                  Width="100%" 
                                                                 CellPadding="0"    
                                                                 onrowcreated="grdcon_RowCreated" onrowdatabound="grdcon_RowDataBound" 
                                                                CssClass="paging_gridview"   DataKeyNames="Pid,raccount" ShowFooter="True">
                                                                <RowStyle CssClass="paging_gridview_itm" />
                                                                <PagerStyle CssClass="paging_gridview_pgr" />
                                        <HeaderStyle CssClass="paging_gridview_hdr" />
                                        <AlternatingRowStyle CssClass="paging_gridview_aitm" />
                                                                 <Columns>
                                                                 
                                                                     <asp:TemplateField HeaderText=" S.No">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lblsno" runat="server" Text='<%# Bind("Sno") %>' 
                                                                                 Width="20px" CssClass="rdgrow"></asp:Label>
                                                                         </ItemTemplate>
                                                                         <ItemStyle VerticalAlign="Top" />
                                                                     </asp:TemplateField>
                                                                  
                                                                     
                                                                     <asp:TemplateField HeaderText="Pid" Visible="False">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lblpid" runat="server" Text='<%# Bind("Pid") %>' CssClass="rdgrow"></asp:Label>
                                                                         </ItemTemplate>
                                                                         <EditItemTemplate>
                                                                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pid") %>'></asp:TextBox>
                                                                         </EditItemTemplate>
                                                                         <ItemStyle VerticalAlign="Top" />
                                                                     </asp:TemplateField>
                                                                  
                                                                     
                                                                     <asp:TemplateField HeaderText="Particulars">
                                                                         <EditItemTemplate>
                                                                             <asp:TextBox ID="txtName" runat="server" CssClass="rdginputbox"  
                                                                                 Text='<%# bind("LedgerName") %>'></asp:TextBox>
                                                                         </EditItemTemplate>
                                                                         <ItemTemplate>
                                                                             <asp:LinkButton ID="lnkpart" Font-Names="Verdana" Font-Size="7pt" runat="server" CommandName="Select" CssClass="rdgrow"
                                                                                 Text='<%# bind("Part") %>'></asp:LinkButton>&nbsp;&nbsp; <asp:Label ID="Label1" runat="server"  CssClass="rdgrow" ForeColor="Black"
                                                                                 Text='Curr Bal'></asp:Label>&nbsp;
                                                                            
                                                                             <asp:Label ID="lblpamt" runat="server"  CssClass="rdgrow" ForeColor="Black"
                                                                                 Text='<%# bind("PAmt") %>'></asp:Label>
                                                                             &nbsp;<asp:Label ID="lbldrcr" runat="server" CssClass="rdgrow"  Text='<%# bind("DrCr") %>'></asp:Label>
                                                                             <asp:GridView AutoGenerateColumns="False"  ID="GridView1" runat="server"  DataKeyNames="ParticularID"
                                                                                 CellPadding="0" CssClass="mGrid1" ShowHeader="False" Width="100%">
                                                                                 <Columns>
                                                                                     <asp:BoundField DataField="RefType" />
                                                                                     <asp:BoundField DataField="Amount" />
                                                                                     <asp:BoundField DataField="CRDR" />
                                                                                 </Columns>
                                                                             </asp:GridView>
                                                                         </ItemTemplate>
                                                                         <ItemStyle VerticalAlign="Top" />
                                                                     </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Debit Amount">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lblgamt" runat="server" CssClass="rdgrow" Text='<%# bind("GAmt") %>'></asp:Label>
                                                                         </ItemTemplate>
                                                                         <FooterTemplate>
                                                                             
                                                                             <asp:TextBox ID="txtTotalDR" Enabled="false" CssClass="rdginputbox" runat="server" Width="71px"></asp:TextBox>
                                                                             
                                                                         </FooterTemplate>
                                                                         <ItemStyle VerticalAlign="Top" />
                                                                     </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Credit Amount">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lblCamt" runat="server" CssClass="rdgrow" Text='<%# bind("Cr") %>'></asp:Label>
                                                                         </ItemTemplate>
                                                                         <FooterTemplate>
                                                                             
                                                                             <asp:TextBox ID="txtTotalCR" Enabled="false" runat="server" CssClass="rdginputbox" Width="71px"></asp:TextBox>
                                                                             
                                                                         </FooterTemplate>
                                                                         <ItemStyle VerticalAlign="Top" />
                                                                     </asp:TemplateField>
                                                                    <asp:CommandField ButtonType="Link"  
                                     HeaderText="Edit" ShowEditButton="True" 
                                      >
                                                                        <ItemStyle VerticalAlign="Top" />
                                                                     </asp:CommandField>
                                                                 </Columns>
                                                             </asp:GridView>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td valign="top" class="style4" >
                                                             <asp:Label ID="Label5" runat="server" Text="Narration"></asp:Label>
                                                         </td>
                                                         <td align="left" class="style2" colspan="3">
                                                             <asp:TextBox ID="txtnarr" onfocus="this.className='focus'" 
                                                                 onblur="this.className='blur'" runat="server" CssClass="rdginputbox" Height="21px" 
                                                                 Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                         </td>
                                                     </tr>
                                                 </table>
                                             </asp:Panel>
                                         </td>
                                     </tr>
                                     <tr align="right">
                                         <td colspan="3" height="1">
                                             <asp:Panel ID="Panel2" runat="server" Visible="False">
                                                 <table width="100%" cellpadding="0" cellspacing="1">
                                                     <tr>
                                                         <td align="left" class="rdgrowH">
                                                             S.No.</td>
                                                         <td align="left" class="rdgrowH">
                                                             Transaction Type</td>
                                                         <td align="left" class="rdgrowH">
                                                             Particulars</td>
                                                         <td align="left" class="rdgrowH">
                                                             Debit</td>
                                                         <td align="left" class="rdgrowH">
                                                             Credit</td>
                                                         <td align="left">
                                                             </td>
                                                     </tr>
                                                    
                                                     <tr>
                                                         <td align="left" class="style16">
                                                             <asp:Label ID="lbljsno" runat="server"></asp:Label>
                                                            </td>
                                                         <td align="left" class="style16">
                                                             <asp:RadioButtonList ID="rdblto" runat="server" RepeatDirection="Horizontal" 
                                                                 AutoPostBack="True" onselectedindexchanged="rdblto_SelectedIndexChanged">
                                                                 <asp:ListItem>By</asp:ListItem>
                                                                 <asp:ListItem>To</asp:ListItem>
                                                             </asp:RadioButtonList>
                                                         </td>
                                                         <td align="left">
                                                             <asp:TextBox ID="txtjpart" runat="server" CssClass="rdginputbox" onfocus="this.className='focus'" onblur="this.className='blur'" 
                                                                 Width="200px"></asp:TextBox>
                                                             </td>
                                                         <td align="left" >
                                                             <asp:TextBox ID="txtdr" runat="server" onfocus="this.className='focusR'" onblur="this.className='blurR'" CssClass="rdginputboxR"></asp:TextBox>
                                                         </td>
                                                         <td align="left">
                                                             <asp:TextBox ID="txtcr" runat="server" onfocus="this.className='focusR'" onblur="this.className='blurR'" CssClass="rdginputboxR"></asp:TextBox>
                                                         </td>
                                                         <td align="left">
                                                             <asp:Button ID="btnjadd" runat="server" CssClass="buttons" Enabled="False" 
                                                                 Text="Add" Width="50px" onclick="btnjadd_Click"  />
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td align="left" class="style16">
                                                         </td>
                                                         <td align="left" class="style16">
                                                             &nbsp;</td>
                                                         <td align="left">
                                                             Curr. Blnc
                                                             <asp:Label ID="lbljCurrblnc" runat="server"></asp:Label>
                                                             &nbsp;<asp:Label ID="lbljCrDr" runat="server"></asp:Label>
                                                         </td>
                                                         <td>
                                                             &nbsp;</td>
                                                         <td>
                                                             &nbsp;</td>
                                                         <td>
                                                             &nbsp;</td>
                                                     </tr> 
                                                     <tr>
                                                         <td align="left"   colspan="6">
                                                             <asp:GridView ID="grdjour" runat="server" AutoGenerateColumns="False" 
                                                                 CssClass="paging_gridview" Width="100%" ShowFooter="True">
                                                                 <RowStyle CssClass="paging_gridview_itm" />
                                                                <PagerStyle CssClass="paging_gridview_pgr" />
                                        <HeaderStyle CssClass="paging_gridview_hdr" />
                                        <AlternatingRowStyle CssClass="paging_gridview_aitm" />
                                                                 <Columns>
                                                                     <asp:TemplateField HeaderText="S.No">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="Label2" runat="server" Text="<%# Container.DataItemIndex+1 %>" 
                                                                                 Width="20px"></asp:Label>
                                                                         </ItemTemplate>
                                                                     </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Pid" Visible="False">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lbljpid" runat="server" Text='<%# Bind("Pid") %>'></asp:Label>
                                                                         </ItemTemplate>
                                                                         <EditItemTemplate>
                                                                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pid") %>'></asp:TextBox>
                                                                         </EditItemTemplate>
                                                                     </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Particulars">
                                                                         <ItemTemplate>
                                                                             <asp:LinkButton ID="lnkpart" runat="server" 
                                                                                 Text='<%# Bind("Part") %>'></asp:LinkButton>
                                                                             &nbsp;
                                                                             <asp:Label ID="lbljamt" runat="server" Text='<%# bind("PAmt") %>'></asp:Label>
                                                                             &nbsp;<asp:Label ID="lbljdrcr" runat="server" Text='<%# bind("DrCr") %>'></asp:Label>
                                                                         </ItemTemplate>
                                                                     </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Debit">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lbldr" runat="server" Text='<%# Bind("Debit") %>' Width="80px"></asp:Label>
                                                                         </ItemTemplate>
                                                                         <EditItemTemplate>
                                                                             <asp:Label ID="lbldr" runat="server" Text='<%# Bind("Debit") %>' Width="80px"></asp:Label>
                                                                         </EditItemTemplate>
                                                                         <FooterTemplate>
                                                                             <asp:Label ID="lbldrsum" runat="server" Width="80px"></asp:Label>
                                                                         </FooterTemplate>
                                                                     </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Credit">
                                                                         <ItemTemplate>
                                                                             <asp:Label ID="lblcr" runat="server" Text='<%# bind("Credit") %>' Width="80px"></asp:Label>
                                                                         </ItemTemplate>
                                                                         <EditItemTemplate>
                                                                             <asp:Label ID="lblcr" runat="server" Text='<%# bind("Credit") %>' Width="80px"></asp:Label>
                                                                         </EditItemTemplate>
                                                                         <FooterTemplate>
                                                                             <asp:Label ID="lblcrsum" runat="server"></asp:Label>
                                                                         </FooterTemplate>
                                                                     </asp:TemplateField>
                                                                    <asp:CommandField ButtonType="Link"  
                                     HeaderText="Edit" ShowEditButton="True" 
                                    />
                                                                 </Columns>
                                                             </asp:GridView>
                                                         </td>
                                                     </tr>
                                                 </table>
                                             </asp:Panel>
                                         </td>
                                     </tr>
                                     <tr align="right">
                                         <td bgcolor="Black" class="style18">
                                         </td>
                                         <td bgcolor="Black" class="style21">
                                         </td>
                                         <td bgcolor="Black" class="style19">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="center"    colspan="3">
                                             <asp:Button ID="Button1" runat="server" Height="1px" onclick="Button1_Click" 
                                                 style="background-color:White;border:none" Text="Button" Width="1px" />
                                                 <table width="40%"><tr><td><asp:Button ID="cmdSubmit" runat="server" CssClass="buttons" Height="20px" 
                                                 onclick="cmdSubmit_Click" Text="Submit"   />
                                                     <input id="hdPrint" runat="server"  type="hidden" />
                                                     <input id="hdNarreach" runat="server"  type="hidden" />
                                                     </td> <td><asp:Button ID="cmdReset" runat="server" CausesValidation="False" 
                                                 CssClass="buttons" onclick="cmdReset_Click" Text="Reset"   /><td>
                                                             <asp:Button ID="cmdPrint" runat="server" CausesValidation="False" 
                                                                 CssClass="buttons" onclick="cmdPrint_Click" Text="Print" />
                                                         </td></tr></table>
                                             
                                            
                                             <Custom:AutoSuggestMenu ID="asmStudent0" runat="server" KeyPressDelay="10" 
                                                 MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate1" 
                                                 OnGetSuggestions="GetSuggestions" PageSize="20" ResourcesDir="../asm_includes" 
                                                 TargetControlID="txtvtype" UpdateTextBoxOnUpDown="False" 
                                                 UsePageMethods="True" />
                                             <Custom:AutoSuggestMenu ID="asmStudent1" runat="server" KeyPressDelay="10" 
                                                 MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate2" 
                                                 OnGetSuggestions="GetSuggestions1" PageSize="20" ResourcesDir="../asm_includes" 
                                                 TargetControlID="txtacc" UpdateTextBoxOnUpDown="False" UsePageMethods="True" />
                                             <Custom:AutoSuggestMenu ID="asmStudent2" runat="server" KeyPressDelay="10" 
                                                 MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate4" 
                                                 OnGetSuggestions="GetSuggestions3" PageSize="20" ResourcesDir="../asm_includes" 
                                                 TargetControlID="txtpart" UpdateTextBoxOnUpDown="False" UsePageMethods="True" />
                                             <Custom:AutoSuggestMenu ID="asmStudent3" runat="server" KeyPressDelay="10" 
                                                 MaxSuggestChars="100" OnClientTextBoxUpdate="onTextBoxUpdate3" 
                                                 OnGetSuggestions="GetSuggestions1" PageSize="20" ResourcesDir="../asm_includes" 
                                                 TargetControlID="txtjpart" UpdateTextBoxOnUpDown="False" 
                                                 UsePageMethods="True" />
                                             <asp:Button ID="cmdsearch" runat="server" Height="1px" style="background-color:White;border:none"
                                                 onclick="cmdsearch_Click" Width="1px" />
                                             <asp:Button ID="cmdsearch1" runat="server" Height="1px"  style="background-color:White;border:none"
                                                 onclick="cmdsearch1_Click" Width="1px" />
                                             <asp:Button ID="cmdsearch2" runat="server" Height="1px" style="background-color:White;border:none" 
                                                 onclick="cmdsearch2_Click" Width="1px" />
                                             <asp:Button ID="cmdsearch3" runat="server" Height="1px"  style="background-color:White;border:none"
                                                 onclick="cmdsearch3_Click" Width="1px" />
                                         </td>
                                     </tr>
                                 </table>
                            </td>
                        </tr>
                    </table>
                        <input id="hdvoutype" runat="server"  type="hidden" />
                        <input id="hdParent" runat="server"  type="hidden" />
                         <input id="hdParticular" runat="server"  type="hidden" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="cmdsearch2" />
                        <asp:PostBackTrigger ControlID="cmdPrint" />
                    </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table></td></tr>
        </table>
        
         
        
        
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" />
        
         
        
        
    </form>
</body>
</html>
