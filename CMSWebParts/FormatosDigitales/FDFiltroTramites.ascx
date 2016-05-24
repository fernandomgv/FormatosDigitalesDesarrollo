<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FDFiltroTramites.ascx.cs" Inherits="CMSWebParts_FormatosDigitales_FDFiltroTramites" %>
<asp:Panel ID="PnlFiltro" runat="server">
<div>
    <asp:Label ID="Label1" runat="server" Text="lblProyectos"></asp:Label>
    <asp:DropDownList ID="DdlProyectos" runat="server">
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="Lbltramite" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="DdlTramites" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <asp:Label ID="LblEstado" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="DdlEstados" runat="server">
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="LblFechaIni" runat="server" Text="LblFechaIni"></asp:Label>
    <asp:TextBox ID="TxtFechaIni" runat="server"></asp:TextBox>
    <asp:Label ID="LblFechaFin" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TxtFechaFin" runat="server"></asp:TextBox>
    <asp:Button ID="BtnFiltrar" runat="server" Text="Button" />
</div>
</asp:Panel>
