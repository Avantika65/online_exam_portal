<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sreport.aspx.cs" Inherits="sreport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="ForLogin.css"/>
    <link rel="stylesheet" type="text/css" href="Forgot.css"/>
    <meta charset="utf-8"/>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <title></title>
</head>
<body class="bo">
    <p  align="center "style=" margin-top: 1%;font-family: 'Times New Roman', Times, serif; font-size: xx-large; color: #FF0000; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase; text-decoration: underline;">Student Report Card</p>
    <form id="form1" runat="server">
    
                 <div> &nbsp;&nbsp;
             </div> <br/>  <div>  <p class="fon" style=" font-family: 'Palatino Linotype';">Student Name:<asp:TextBox ID="TextBox1" runat="server" class="textfield" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />Roll No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="TextBox2" runat="server" class="textfield"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> No of Attempt:<asp:TextBox ID="TextBox3" runat="server" class="textfield"></asp:TextBox>
             <br />       Father's Name:<asp:TextBox ID="TextBox4" runat="server" class="textfield"></asp:TextBox>
                    </p>
                  </div>
        <div id="mainContainer" class="container">  
            <div class="shadowBox">  
                <div class="page-container">  
                    <div class="container">  
                      <div class="row">  
                            <div class="col-lg-12 ">  
                                <div class="table-responsive">  
                     <asp:GridView ID="GridView1" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" EmptyDataText="There are no data records to display." runat="server" BackColor="Aqua" BorderColor="#003366" BorderStyle="Ridge" BorderWidth="1px" CellPadding="3" DataKeyNames="id" DataSourceID="SqlDataSource1" EnableModelValidation="True" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                <asp:BoundField DataField="student_id" HeaderText="STUDENT ID" SortExpression="student_id" />
                                <asp:BoundField DataField="faculty_id" HeaderText="FACULTY ID" SortExpression="faculty_id" />
                                <asp:BoundField DataField="ques_attempt" HeaderText="QUESTION ATTEMPT" SortExpression="ques_attempt" />
                                <asp:BoundField DataField="ques_correct" HeaderText="CORRECT QUESTION" SortExpression="ques_correct" />
                                <asp:BoundField DataField="ques_wrong" HeaderText="WRONG QUESTION" SortExpression="ques_wrong" />
                                </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                                     
                            </div>  
                        </div>  
                    </div>  
                </div>  
            </div>  
        </div>  
            </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FeesManagementConn %> " SelectCommand="SELECT * FROM [quiz_result]" ></asp:SqlDataSource>
                  
                <div class="fon" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Print" BackColor="#E6C8D7" onClientClick="javascript:window.print();"/>
                  </div>
          
    </form>
</body>
</html>





