<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FDFiltroTramites.ascx.cs" Inherits="CMSWebParts_FormatosDigitales_FDFiltroTramites" %>
<asp:Panel ID="PnlFiltro" runat="server">
<div>
    <asp:Label ID="Label1" runat="server" Text="Proyectos"></asp:Label>
    <asp:DropDownList ID="DdlProyectos" runat="server">
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="Lbltramite" runat="server" Text="Tramite"></asp:Label>
    <asp:DropDownList ID="DdlTramites" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DdlTramites_SelectedIndexChanged" style="height: 22px">
    </asp:DropDownList>
    <asp:Label ID="LblEstado" runat="server" Text="Estado"></asp:Label>
    <asp:DropDownList ID="DdlEstados" runat="server" Enabled="False">
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="LblFechaIni" runat="server" Text="FechaIni"></asp:Label>
    <asp:TextBox ID="TxtFechaIni" runat="server"></asp:TextBox>
    <asp:Label ID="LblFechaFin" runat="server" Text="FechaFIn"></asp:Label>
    <asp:TextBox ID="TxtFechaFin" runat="server"></asp:TextBox>
    <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" 
        onclick="BtnFiltrar_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
</div>
</asp:Panel>
