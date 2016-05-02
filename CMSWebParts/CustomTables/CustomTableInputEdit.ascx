<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomTableInputEdit.ascx.cs" Inherits="CMSWebParts_CustomTables_CustomTableInputEdit" %>
<asp:Label ID="lblError" runat="server" CssClass="ErrorLabel" EnableViewState="false" Visible="false" />
<asp:Literal ID="litMessage" runat="server" />
<cms:CustomTableForm ID="customTableForm" runat="server" />