<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridView.aspx.cs" Inherits="Try_GridView" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    <script src="jquery-1.4.1.min.js" type="text/javascript"></script>
    <meta charset="utf-8"/>
      <style>
          .dropdown1
          {
              width:180px;
              border:5px solid black;
          }
          .dropdown 
          {
              width:20px;
              border:5px solid black;
               display: none;
                position: absolute;
                background-color: #f6f6f6;
                overflow: auto;
                border: 1px solid #ddd;
                z-index: 3;
          }
      </style>
      <script src="jquery.min.js"></script>
      <link rel="stylesheet" href="bootstrap.min.css"/>
      <script src="excel-bootstrap-table-filter-bundle.js"></script>
      <script src="/dist/jquery.min.js"></script>

      <link rel="stylesheet" href="excel-bootstrap-table-filter-style.css"/>
       <script src="excel-bootstrap-table-filter-bundle.js"></script>
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" />
      <link rel="stylesheet" href="excel-bootstrap-table-filter-style.css" />
  
    <script src="Table-Sorter.js"></script>
    <link href="bootstrap.css" rel="stylesheet" type="text/css" /> 
    <link href="bootstrap.min.css" rel="stylesheet" type="text/css" /> 

    <script src="Table-Pager.js"></script>
    <script src="Table-Filter.js" type="text/javascript"></script>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="jquery.tablesorter.pager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tablesorter {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">     

 </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="updatepanel1" runat="server"> 
       <ContentTemplate>              
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" cssClass="tablesorter"  Width="50%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"> 
            <AlternatingRowStyle BackColor="#CCCCCC" />
          <Columns>
              <asp:TemplateField>
                  <HeaderTemplate>
                              <asp:TextBox ID="searchbox" runat="server" Placeholder="Search Employee Here" OnTextChanged="searchbox_TextChanged" CssClass="dropdown1" AutoPostBack="true"></asp:TextBox>
                              <asp:DropDownCheckBoxes ID="ddlname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlname_SelectedIndexChanged" CssClass="dropdown"  AppendDataBoundItems="true"></asp:DropDownCheckBoxes>
                </HeaderTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label1" CssClass="filter" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField HeaderText="EmpCode" DataField="empCode" />
              <asp:BoundField HeaderText="Type" DataField="empType" />
              <asp:BoundField HeaderText="DOb" DataField="dob" />

          </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
          
    </div>
           </ContentTemplate>
           </asp:UpdatePanel>
           
    </form>
     <script>
         // Use the plugin once the DOM has been loaded.
         $(function () {
             // Apply the plugin 
             $('#GridView1').excelTableFilter();
            
         });
  </script>
</body>
</html>
