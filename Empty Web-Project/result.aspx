<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="NewFolder1_result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../bootstrap-dist/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../bootstrap-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../bootstrap-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../bootstrap-dist/css/bootstrap.min.css" rel="stylesheet" />
<title>RESULT LAYOUT </title>
<style>
header{ background:black;color:white} 

   
    </style>
</head>

<body> 


    <form id="form2" runat="server">

<div id="parent">
             <div class="fluid-container">
<h1 align="center" style="background-color:black;width:100%; color: #FFFFFF;">  QUIZ RESULT </h1>
</div>
          <div style="margin-left:5%">
              <div class="row" style="margin-top:4%">
                  <div class="col-sm-4 col-md-3 col-lg-3" style="margin-top:1%">USER ID</div>
                  <div class="col-sm-4 col-md-3 col-lg-3" style="margin-top:1%">
                      <asp:Label ID="lblid" runat="server"></asp:Label>
                  </div>
              </div>
              <div class="row" style="margin-top:1%">
                  <div class="col-sm-4 col-md-3 col-lg-3">USER NAME</div>
                  <div class="col-sm-4 col-md-3 col-lg-3">
                      <asp:Label ID="lblusr" runat="server"></asp:Label>
                  </div>
              </div>
             <div class="row" style="margin-top:1%">
                  <div class="col-sm-4 col-md-3 col-lg-3">FATHER'S NAME</div>
                  <div class="col-sm-4 col-md-3 col-lg-3">
                      <asp:Label ID="lblname" runat="server"></asp:Label>
                  </div>
              </div>
              <div class="row" style="margin-top:1%">
                  <div class="col-sm-4 col-md-3 col-lg-3">Course</div>
                  <div class="col-sm-4 col-md-3 col-lg-3">
                      <asp:Label ID="lblcourse" runat="server"></asp:Label>
                  </div>
              </div>
               <div class ="row" style="margin-top:1%">
                  <div class="col-sm-4 col-md-3 col-lg-3">BRANCH</div>
                  <div class="col-sm-4 col-md-3 col-lg-3">
                      <asp:Label ID="lblbranch" runat="server"></asp:Label>
                  </div>
              </div>
               <div class ="row" style="margin-top:1%">
                  <div class="col-sm-4 col-md-3 col-lg-3">SUBJECT SELECTED</div>
                  <div class="col-sm-4 col-md-3 col-lg-3">
                      <asp:Label ID="lbl8" runat="server"></asp:Label>
                  </div>
              </div>
          </div>
          </div>
           <br />

          &nbsp; &nbsp;
<br />

  &nbsp;
    <input type="submit" name="ONE VIEW RESULT" value="ONE VIEW RESULT"  id="click" align="middle" 
   style="font-family: 'times New Roman', Times, serif;color: #000000; background-color: #FF3300; 
border-width: thin; height: 80%; width: 100%; font-style: italic; font-weight: bold; font-size: medium;" />

<div>
  <asp:GridView ID="GridView2" runat="server" Height="131px" Width="964px" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                
               
                <asp:TemplateField HeaderText="S.no.">
                    <ItemTemplate>
                         <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="question" HeaderText="Question Name" ReadOnly="True" />
                 <asp:BoundField DataField="Correct" HeaderText="No. of Correct" ReadOnly="True" />
                 <asp:BoundField DataField="Incorrect" HeaderText="No. of InCorrect" ReadOnly="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
          <br />
          
		
     </div>       &nbsp;
         
    </form>
  
</body>
</html>

