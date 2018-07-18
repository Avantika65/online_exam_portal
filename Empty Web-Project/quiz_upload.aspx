<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quiz_upload.aspx.cs" Inherits="quiz_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="bootstrap-dist/css/bootstrap.css" />
    
    <link type="text/css" href="bootstrap-dist/css/bootstrap.min.css" />
</head>
<body>
   <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
           
                
                <table class="style1">
                 <div class="row">
                   <div class="col-sm-12">
                     <div>
                             <h2><i class="fa fa-bars"></i>Create Question Paper</h2>
                        </div>
                       
                    </div>
                </div>
                    <div>
                        <asp:HiddenField ID="hdnID" runat="server" />
                    </div>
                           <div class="row">
                                   <div class="col-sm-6">
                                       <asp:Label ID="Label2" runat="server" Text="Area of Intrest"></asp:Label>
                                   </div>
                                   <div class="col-sm-6">
                                   <asp:DropDownList ID="ddl_aoi" runat="server" Width="229px" AutoPostBack="True"></asp:DropDownList>
                                   </div>
                            </div>

                    <div>

                    </div>

                             
                    <div>

                    </div>
               
              
                     <div class="row">
                   <div class="col-sm-12">
                      <asp:Button id="btn_create"  runat ="server" OnClick="btn_create_Click" Text="Create Paper" />
                   </div>
                  
               </div>
                    
             <asp:GridView ID="grd_quiz" runat="server" DataKeyNames="id" Visible="false"  AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="S. No.">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Question">
              
                <ItemTemplate>
                              <asp:Label ID="lbl_ques" runat="server" Text='<%# Bind("Question") %>'></asp:Label>
          
                </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Option A">
         
                 <ItemTemplate>
                <asp:Label ID="lbl_a" runat="server" Text='<%# Bind("opt_a") %>'></asp:Label>
             </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Option B">
                 <ItemTemplate>
       <asp:Label ID="lbl_b" runat="server" Text='<%# Bind("opt_b") %>'></asp:Label>
                       </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Option C">
                <ItemTemplate>
                <asp:Label ID="lbl_c" runat="server" Text='<%# Bind("opt_c") %>'></asp:Label>
           </ItemTemplate>
                
                      </asp:TemplateField>
            <asp:TemplateField HeaderText="Option D">
              
                <ItemTemplate>
       <asp:Label ID="lbl_d" runat="server" Text='<%# Bind("opt_d") %>'></asp:Label>
          
                              </ItemTemplate>
                
             </asp:TemplateField>
                  <asp:TemplateField HeaderText="Correct Answer">
                 
                <ItemTemplate>
       <asp:Label ID="lbl_ans" runat="server" Text='<%# Bind("answer") %>'></asp:Label>
          
                              </ItemTemplate>
                
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Operation">
                 
                <ItemTemplate>
         
                     <asp:LinkButton ID="lb_edit" runat="server" OnClick="lb_edit_Click" Text="Edit"></asp:LinkButton>

                     <asp:LinkButton ID="lb_delete" runat="server" OnClick="lb_delete_Click" Text="Delete"></asp:LinkButton>

                </ItemTemplate>
                 

             </asp:TemplateField>
            
             
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
                   
                      <asp:GridView ID="grd_insert" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="S. No.">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                </ItemTemplate>
                   
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Question">
              
                <ItemTemplate>
                       <asp:TextBox ID="ques" runat="server" Text='<%# Bind("Question") %>'></asp:TextBox>
                </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Option A">
         
                 <ItemTemplate>
                   <asp:TextBox ID="opt_a" runat="server" Text='<%# Bind("[opt_a]") %>'></asp:TextBox>
                  </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Option B">
                 <ItemTemplate>
                <asp:TextBox ID="opt_b" runat="server" Text='<%# Bind("[opt_b]") %>' MaxLength="10"></asp:TextBox>
                   </ItemTemplate>
                
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Option C">
                <ItemTemplate>
                      <asp:TextBox ID="opt_c" runat="server" Text='<%# Bind("opt_c") %>'></asp:TextBox>
                </ItemTemplate>
                
                      </asp:TemplateField>
            <asp:TemplateField HeaderText="Option D">
              
                <ItemTemplate>
                         <asp:TextBox ID="opt_d" runat="server" Text='<%# Bind("[opt_d]") %>'></asp:TextBox>  
                </ItemTemplate>
                
             </asp:TemplateField>
                  <asp:TemplateField HeaderText="Correct Answer">
                 
                <ItemTemplate>
                         <asp:TextBox ID="answer" runat="server" Text='<%# Bind("[answer]") %>'></asp:TextBox>  
                </ItemTemplate>
                
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Operation">
                 
                <ItemTemplate>
         
                    <asp:LinkButton ID="lb_add" runat="server" OnClick="lb_add_Click" Text="Add"></asp:LinkButton>

                </ItemTemplate>
                 

             </asp:TemplateField>
            
             
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
           
            
                    </table>
                </ContentTemplate>
                </asp:UpdatePanel>
   
    <div>
    
    </div>
    </form>
</body>
</html>
