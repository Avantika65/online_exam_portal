<%@ Page Language="C#" MasterPageFile="~/Setup/Setup.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Setup_Default" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphMain">
    <div id="divStepWellcome" runat="server" visible="false">
        <div class="block">
            <span class="title">
                <%=Language.Setup["Wellcome"]%></span>
        </div>
        <div class="block">
            <%=Language.Setup["GuideDescription"]%>
        </div>
        <div class="block">
            <asp:LinkButton runat="server" ID="btnStart" CssClass="linkbutton" 
                onclick="btnStart_Click"><%=Language.Setup["Start"] %></asp:LinkButton>
        </div>
    </div>
    <div id="divStepPermissionControl" runat="server" visible="false">
        <div class="block">
            <span class="steptitle">
                <%=Language.Setup["BeforeSetup"] %></span>
        </div>
        <div class="errorblock">
            <span class="errortitle" style="display: block;">
                <%=Language.Setup["PermissionError"]%>
            </span><span>
                <%=Language.Setup["CheckFilePermission"] %></span>
            <ul runat="server" id="ulFileFolder" style="line-height: 24px;">
            </ul>
        </div>
        <div class="block">
            <asp:LinkButton ID="btnPermissionCheckAgain" runat="server" 
                CssClass="linkbutton" onclick="btnPermissionCheckAgain_Click1"><%=Language.Setup["AgainCheck"] %></asp:LinkButton>
            <asp:LinkButton ID="btnPermissionContinue" runat="server" CssClass="linkbutton" 
                OnClick="btnPermissionContinue_Click"><%=Language.Setup["Continue"] %></asp:LinkButton>
        </div>
    </div>
    <div id="divStepInstallType" runat="server" visible="false">
        <div class="block">
            <span class="steptitle">
                <%=Language.Setup["PleaseSelectInstallType"]%></span>
        </div>
        <div class="block">
            <%=Language.Setup["Suggestions"]%>
        </div>
        <div class="block">
            <a href="Mssql.aspx" class="linkbutton"><%=Language.Setup["Mssql2005"] %></a>
            <a href="Access.aspx" class="linkbutton"><%=Language.Setup["Access"]%></a>
            <asp:LinkButton ID="btnInstallTypeCancel" runat="server" OnClick="Cancel_Click" CssClass="linkbutton"><%=Language.Setup["Cancel"] %></asp:LinkButton>
        </div>
    </div>
    <div id="divStepCompleate" runat="server" visible="false">
        <div class="block">
            <div class="title compleatetitle">
                <%=Language.Setup["Congratulations"]%></div>
            <%=Language.Setup["Compleate"] %>
        </div>
        <div class="block">
            <div class="title">
                <%=Language.Setup["WhatDoYouWantNow"] %></div>
            <a href="../Default.aspx" class="linkbutton"><%=Language.Setup["GoWebsite"] %></a> <a href="../Admin/"
                class="bsbutton blue"><%=Language.Setup["GoAdminPanel"] %></a>
        </div>
    </div>
    <div id="divStepBeforeInstalled" runat="server" visible="false">
        <div class="block" style="left: 0px; top: 0px">
            <%=Language.Setup["Setupped"] %>
        </div>
        <div class="block">
            <div class="title">
                <%=Language.Setup["WhatDoYouWantNow"] %></div>
            <a href="../Default.aspx" class="linkbutton"><%=Language.Setup["GoWebsite"] %></a> <a href="../Admin/"
                class="bsbutton blue"><span> <%=Language.Setup["GoAdminPanel"] %></span></a>
        </div>
    </div>
</asp:Content>
