<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Academic_Calendar.aspx.cs" EnableTheming="true"
    StylesheetTheme="BasicBlue" Theme="BasicBlue" Inherits="GatePass_Gate_Pass_Internal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register Namespace="MSS" TagPrefix="Custom" %> 
<%@ Register assembly="CommonClassLibrary" namespace="CommonClassLibrary" tagprefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <link type="text/css" rel="Stylesheet" href="../Account.css"/>
            <link href="../PagingGridView.css" rel="stylesheet" type="text/css"/>
<link rel="stylesheet" type="text/css" href="../css_Admin/cloud-admin.css" >
	<link rel="stylesheet" type="text/css"  href="../css_Admin/themes/default.css">
	<link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet">
	<!-- DATE RANGE PICKER -->
	<link rel="stylesheet" type="text/css" href="../js_admin/bootstrap-daterangepicker/daterangepicker-bs3.css" />
	<!-- UNIFORM -->
	<link rel="stylesheet" type="text/css" href="../js_admin/uniform/css/uniform.default.min.css" />
	<!-- ANIMATE -->
	<link rel="stylesheet" type="text/css" href="../css_Admin/animatecss/animate.min.css" />
	<!-- FONTS -->
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700' rel='stylesheet' type='text/css'>


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
                  
    </style>
    <script language="javascript" type="text/javascript" >
      
    </script>
</head>
<body onload="startclock();">
    <form id="form1" runat="server">
<input id="hdID" runat="server" type="hidden" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="border: 1px solid #cccccc" width="100%">
                <tr>
                    <td colspan="2">
                        <div>
                            <div class="box border primary">
            <div class="box-title">
            <h4><i class="fa fa-bars"></i>Activity Type Master</h4>
            </div>           
           </div>

                        </div></td>
                </tr>
                <caption>
                </caption>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Activity Name"></asp:Label>
                    </td>
                        <td>
                        
                            <asp:DropDownList ID="ddlActivity" runat="server" Height="17px" Width="229px">
                            </asp:DropDownList>
                        
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Type Of Activity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtActivity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnActivity" runat="server" Text="Save"
                        onclick="btnActivity_Click" CssClass="btn btn-primary" Width="100px"/>
                    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                        Text="Delete" CssClass="btn btn-danger" Width="100px"/>
                    <asp:Button ID="btnReset" runat="server"  onclick="btnReset_Click" 
                        Text="Reset" CssClass="btn btn-inverse" Width="100px"/>
                    </td>                
                </tr>
                <tr>
                <td colspan="2">
                    <cc2:GroupedGridView ID="gvActivity" runat="server" AutoGenerateColumns="False" 
                        CellPadding="0" CssClass="mGrid" GroupedDepth="1" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Activity_Name" HeaderText="Activity Name" />
                            <asp:TemplateField HeaderText="Type of Activity">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" 
                                        Text='<%# Bind("Activity_Type_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkActivity" runat="server" onclick="LnkActivity_Click" 
                                        Text='<%# Bind("Activity_Type_Name") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activity_ID" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Activity_ID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Activity_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </cc2:GroupedGridView>
                    </td>
                </tr>
                <tr>
                <td>
                    <asp:HiddenField ID="HDActivity" runat="server" />
                    </td>
                </tr>
            </table>          
     </ContentTemplate>        
    </asp:UpdatePanel>     
   </form>
       </body>
</html>
