<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SMSSender.ascx.cs" Inherits="CMSWebParts_SMS_SMSSender" %>
<div>
    <cms:LocalizedLabel ID="lblFrom" runat="server" EnableViewState="false" Text="From:" /><br />
    <asp:TextBox ID="txtFrom" runat="server" style="width:180px;" /><br />
    <cms:LocalizedLabel ID="lblTo" runat="server" EnableViewState="false" Text="To:" /><br />
    <asp:TextBox ID="txtTo" runat="server" style="width:180px;" /><br />
    <cms:LocalizedLabel ID="lblMessage" runat="server" EnableViewState="false" Text="Message:" /><br />
    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" style="width:180px; height:50px;" /><br />
    <cms:LocalizedButton ID="btnSend" runat="server" Text="Send" 
        onclick="btnSend_Click" />
</div>
<asp:Label ID="lblError" runat="server" EnableViewState="false" Visible="false" CssClass="ErrorLabel" />