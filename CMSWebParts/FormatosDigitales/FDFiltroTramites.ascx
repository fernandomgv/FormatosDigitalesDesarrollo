<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FDFiltroTramites.ascx.cs" Inherits="CMSWebParts_FormatosDigitales_FDFiltroTramites" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 95px;
    }
    .style6
    {
        width: 72px;
    }
    .style7
    {
        width: 336px;
    }
</style>



&nbsp;<asp:Panel ID="PnlFiltro" runat="server" CssClass="FDContenedorFiltro">
<div class="FDFiltro_seccion clearfix">
    <table class="style1">
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" CssClass="FD_Filtro_label" 
                                Text="Proyectos"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlProyectos" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Lbltramite" runat="server" CssClass="FD_Filtro_label" 
                                Text="Tramite"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:DropDownList ID="DdlTramites" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DdlTramites_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="style6">
                            <asp:Label ID="LblEstado" runat="server" CssClass="FD_Filtro_label" 
                                Text="Estado"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlEstados" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="LblFechaIni" runat="server" CssClass="FD_Filtro_label" 
                                Text="FechaIni"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="TxtFechaIni" runat="server" CssClass="date"></asp:TextBox>
                        </td>
                        <td class="style6">
                            <asp:Label ID="LblFechaFin" runat="server" CssClass="FD_Filtro_label" 
                                Text="FechaFin"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtFechaFin" runat="server" CssClass="date"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="BtnFiltrar" runat="server" CssClass="FDFiltroBtn" 
                    onclick="BtnFiltrar_Click" Text="Filtrar" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</div>
</asp:Panel>