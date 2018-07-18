﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result2.aspx.cs" Inherits="NewFolder1_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 254px; width: 892px">
    <form id="form1" runat="server">
    <div>
       <div class="fluid-container">
          <h1 align="center" style="background-color:black;width:100%; color: #FFFFFF;">  QUIZ RESULT </h1>
       </div>
    </div>
        
<div>
  <asp:GridView ID="GridView2" runat="server" Height="141px" Width="886px" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" 
        OnSelectedIndexChanged="GridView2_SelectedIndexChanged" 
        style="margin-left: 3px" BorderColor="Lime">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                
               
                <asp:TemplateField HeaderText="S.No.">
                    <ItemTemplate>
                         <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
               
                 <asp:BoundField DataField="a" HeaderText="PaperId" ReadOnly="True" />
                 <asp:BoundField DataField="b" HeaderText="Date" ReadOnly="True" />
                 <asp:BoundField DataField="d" HeaderText="No. of Correct" ReadOnly="True" />
                 <asp:BoundField DataField="e" HeaderText="No. of InCorrect" ReadOnly="True" />
                 <asp:BoundField DataField="f" HeaderText="Percentage" ReadOnly="True" />
                 <asp:BoundField  HeaderText="View" HeaderStyle-CssClass="text-align:right" ReadOnly="True" />
                
                <asp:ButtonField Text="View" />
                
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#FF3300" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" VerticalAlign="Middle" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
          <br />
          
		
     </div>
    </form>
</body>
</html>
