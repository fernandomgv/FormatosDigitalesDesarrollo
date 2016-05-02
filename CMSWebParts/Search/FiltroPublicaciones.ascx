<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FiltroPublicaciones.ascx.cs" Inherits="CMSWebParts_Search_FiltroPublicaciones" %>
<asp:Panel ID="pnlbuscar" runat="server" CssClass="pnlbuscar">
    <asp:Label ID="lblpalabraclave" runat="server" Text="Palabra Clave" 
        CssClass="campo "></asp:Label>
    <asp:TextBox ID="txtpalabraclave" runat="server" CssClass="inputtext"></asp:TextBox>
    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="btnbus" 
        onclick="btnbuscar_Click" />
    <asp:Button ID="btnbuscaravanzado" runat="server" Text="Busqueda avanzada" 
        CssClass="botnavz" onclick="btnbuscaravanzado_Click" />
        <div class = "msjresultados">
        <asp:Label ID="Lblmsj" runat="server" Text="Mostrando resultados para..." CssClass="campomsjresultados "></asp:Label>
        </div>
</asp:Panel>
<asp:Panel ID="pnlavanzada" runat="server" CssClass="pnlbuscaravanzado" 
    Visible="False">
<div class="titubusq">BÚSQUEDA AVANZADA</div>
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="lbltitulo" runat="server" Text="Titulo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttitulo" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblpais" runat="server" Text="Pais"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddpais" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>Bolivia</asp:ListItem>
                    <asp:ListItem>Colombia</asp:ListItem>
                    <asp:ListItem>Ecuador</asp:ListItem>
                    <asp:ListItem>Perú</asp:ListItem>
                    <asp:ListItem>Regional</asp:ListItem>
                    <asp:ListItem>Mundo</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lbltipo" runat="server" Text="Tipo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttipo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblautor" runat="server" Text="Autor"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtautor" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Autor"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblanio" runat="server" Text="Anio"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtanio" runat="server" MaxLength="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Button ID="btnbuscaravanzada" runat="server" Text="Buscar" />
            </td>
        </tr>
    </table>

</asp:Panel>
