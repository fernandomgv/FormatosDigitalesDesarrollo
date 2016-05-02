<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdministrarUsuarios.ascx.cs" Inherits="CMSWebParts_SPATS_AdministrarUsuarios" %>
<%@ Register src="~/CMSAdminControls/UI/UniGrid/UniGrid.ascx" tagname="UniGrid" tagprefix="cms" %>

<%@ Register Src="~/CMSModules/Membership/Controls/Users/UserFilter.ascx" TagName="UserFilter"
    TagPrefix="cms" %>
    <cms:UserFilter ID="userFilterElem" runat="server" />
    <br />
    <asp:Label runat="server" ID="lblError" CssClass="ErrorLabel" EnableViewState="false"
        Visible="false" />
    <cms:UniGrid ID="gridElem" runat="server" GridName="User_List.xml" OrderBy="UserName"
        Columns="UserID, UserName, FullName, Email, UserNickName, UserCreated, UserEnabled, (CASE WHEN UserPassword IS NULL OR UserPassword = '' THEN 0 ELSE 1 END) AS UserHasPassword, UserIsGlobalAdministrator, UserIsExternal"
        IsLiveSite="false" />
