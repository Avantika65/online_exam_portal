<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resultpublish.aspx.cs" Inherits="Try_resultpublish" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CommonClassLibrary" namespace="CommonClassLibrary" tagprefix="cc2" %>
<%@ Register Assembly="Flan.Controls" Namespace="Flan.Controls" TagPrefix="cc1" %>

<%@ Register assembly="CalendarExtenderPlus" namespace="AjaxControlToolkitPlus" tagprefix="CC11" %>
<%@ Register namespace="MSS" tagprefix="Custom" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../assets/stylesheets/bootstrap/bootstrap.css" media="all" rel="stylesheet" type="text/css" />
    <link href='../assets/images/meta_icons/favicon.ico' rel='shortcut icon' type='image/x-icon' />
    <link href='../assets/images/meta_icons/apple-touch-icon.png' rel='apple-touch-icon-precomposed' />
    <link href='../assets/images/meta_icons/apple-touch-icon-57x57.png' rel='apple-touch-icon-precomposed' sizes='57x57' />
    <link href='../assets/images/meta_icons/apple-touch-icon-72x72.png' rel='apple-touch-icon-precomposed' sizes='72x72' />
    <link href='../assets/images/meta_icons/apple-touch-icon-114x114.png' rel='apple-touch-icon-precomposed' sizes='114x114' />
    <link href='../assets/images/meta_icons/apple-touch-icon-144x144.png' rel='apple-touch-icon-precomposed' sizes='144x144' />
    <link href="../assets/stylesheets/bootstrap/bootstrap.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/light-theme.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/theme-colors.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/demo.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/plugins/select2/select2.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/plugins/bootstrap_colorpicker/bootstrap-colorpicker.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/plugins/bootstrap_daterangepicker/bootstrap-daterangepicker.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/plugins/bootstrap_datetimepicker/bootstrap-datetimepicker.min.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/plugins/bootstrap_switch/bootstrap-switch.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/plugins/common/bootstrap-wysihtml5.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/light-theme.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../assets/stylesheets/theme-colors.css" media="all" rel="stylesheet" type="text/css" />
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="../assets/javascripts/ie/html5shiv.js" type="text/javascript"></script>
    <script src="../assets/javascripts/ie/respond.min.js" type="text/javascript"></script>
    <script src="../js/JScript.js" type="text/javascript"></script>
    <script src="../Scripts/Global.js" type="text/javascript"></script>
    <script language="javascript" src="../datetimepicker.js" type="text/javascript"></script>
   <%-- <link href="../materialize.css" rel="stylesheet" />
    <link href="../materialize.min.css" rel="stylesheet" /> --%>
    <style type="text/css" >
        .center,.center-align{text-align:center}
        .left { text-align:left;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <section id=''>
                    <div class=''>
                        <div id='row'>
                            <div class='col-sm-4 col-lg-4'>
                                <div class='box'>
                                     <div class='box-header blue-background'>
                                        <div class='title'>
                                                <i class="fa fa-bars"></i>
                                                <div id="lbltitle" runat="server" style="display: inline-block;">
                                                    <h4>Result-Publish</h4>
                                                </div>
                                        </div>
                                       </div>
                                     <div class='box-content'>
                                      
                                            <div class='form-group'>
                                                  <asp:Label ID="lblCourse" runat="server" CssClass="FormLable" Text="Course"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                 <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" class="form-control" DataTextField="Course" DataValueField="Course">
                                                  </asp:DropDownList>
                                            </div>
                                            <div class='form-group'>
                                                  <asp:Label ID="lblspl" runat="server" CssClass="FormLable" Text="Specialization"></asp:Label>
                                            </div> 
                                            <div class='form-group'>
                                                 <asp:DropDownList ID="ddlspl" runat="server" AutoPostBack="True" class="form-control">
                                                  </asp:DropDownList>
                                            </div>
                                            <div class='form-group'>
                                                 <asp:Label ID="lbltremester" runat="server" CssClass="FormLable" Text="Tremester"></asp:Label>
                                            </div>
                                            <div class='form-group'>
                                                     <asp:DropDownList ID="ddltremester" OnSelectedIndexChanged="ddltremester_SelectedIndexChanged" runat="server" AutoPostBack="True" class="form-control">
                                                  </asp:DropDownList>
                                            </div>  
                                            <div class="row">
                                        <div class='col-sm-6 col-md-6 col-lg-6 center'>
                                            <div class='form-group'>
                                                  <asp:Button ID="btnSubmit" runat="server" AccessKey="s" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click"  />
                                              </div>
                                            </div>
                                          <div class='col-sm-6 col-md-6 col-lg-6 center'>
                                            <div class='form-group'>
                                                 <asp:Button ID="btnreset" runat="server" AccessKey="r" OnClick="btnreset_Click" CssClass="btn btn-inverse right" Text="Reset"  />
                                              </div>
                                            </div>
                                        </div>       
                                   </div>
                                 </div>
                                </div>
                            <div class="col-sm-8 col-lg-8">
                                 <div class=''>
                                     <div class="center">
                                <asp:Image ID="imgnodata" CssClass="img-responsive" ImageUrl="~/images/no_data.png" runat="server" />
                                <asp:GridView ID="Gvresult" runat="server" AutoGenerateColumns="False" DataKeyNames="SubjectId" 
                                      Width="100%" ForeColor="#333333" GridLines="None"> 
                                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                  <Columns>
                                        <asp:TemplateField  HeaderText="Sr.No." >
                                            <ItemTemplate>
                                                 <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <asp:BoundField HeaderText="Subject" HeaderStyle-CssClass="left"  ItemStyle-CssClass="left" DataField="Subject" />
                                      <asp:TemplateField HeaderText="Result Publish" > 
                                          <ItemTemplate>
                                              <asp:CheckBox ID="ChkResult" runat="server" Checked="true" />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                  </Columns>
                                     <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D"  ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" />
                                     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>   
                                         <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
                                 </div>    
                            </div>
                            </div>
                       </div>

                      
                     </div>
                     </section>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

