<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quiz_upload_form.aspx.cs" Inherits="quiz_upload_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                 <div class="row">
                   <div class="col-sm-12">
                      <div class="box border primary" >
                            <div class="box-title">
                                <caption>
                                    <h4><i class="fa fa-bars"></i>Create Question Paper</h4>
                                </caption>
                            </div>           
                       </div>
                    </div>
                </div>
                 <div class="row">
                               <div class="col-sm-6">
                                   <asp:Label ID="lbl_aoi" runat="server" Text="Area of Intrest"></asp:Label>
                               </div>
                               <div class="col-sm-6">
                                     <asp:DropDownList ID="ddl_aoi" runat="server" Width="229px" 
                                       onselectedindexchanged="ddl_aoi_SelectedIndexChanged" 
                                       AutoPostBack="True"></asp:DropDownList>
                               </div>
                           </div>
                 <div class="row">
                   <div class="col-sm-6">
                       <asp:Label ID="lbl_pi" runat="server" Text="Paper ID"></asp:Label>
                   </div>
                   <div class="col-sm-6">
                            <asp:TextBox ID="txt_pID" runat="server"></asp:TextBox>
                   </div>
               </div>
                 <div class="row">
                   <div class="col-sm-6">
                       <asp:Label ID="lbl_correct" runat="server" Text="Marks Per Correct Answer"></asp:Label>
                   </div>
                   <div class="col-sm-6">
                       <asp:TextBox ID="txt_correct" runat="server"></asp:TextBox>
                   </div>
                 </div>
                 <div class="row">
                   <div class="col-sm-6">
                       <asp:Label ID="lbl_wrong" runat="server" Text="Marks Per Wrong Answer"></asp:Label>
                   </div>
                   <div class="col-sm-6">
                            <asp:TextBox ID="txt_wrong" runat="server"></asp:TextBox>
                   </div>
               </div>
                 <div class="row">
                   <div class="col-sm-12">
                      <asp:Button id="btn_create" style="text-align:center"  runat ="server" OnClick="btn_create_Click" Text="Create Paper" />
                   </div>
               </div>
                    
                 <div id="grid_ques" class="row">
                   <div class="col-sm-12">
                       <asp:GridView ID="grd_quiz" Width="100%" Visible="false" runat="server" AutoGenerateColumns="False">
                             <Columns>
                                <asp:TemplateField HeaderText="Question">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Font-Bold="True" />
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option A">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option B">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" ></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Font-Bold="True" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option C">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" ></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Font-Bold="True" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option D">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" ></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Font-Bold="True" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correct Option">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" ></asp:Label>
                                </ItemTemplate>
                                <ControlStyle Font-Bold="True" />
                            </asp:TemplateField>
                             </Columns>
                       </asp:GridView>
                   </div>
                </div>
                 <div class="row">
                   <div class="col-sm-12">
                      <asp:Button id="btn_submit" style="text-align:center"  runat ="server" OnClick="btn_submit_Click" Text="Submit" />
                   </div>

                 </div>   
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
