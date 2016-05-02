<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AEAAdminConsulta.ascx.vb" Inherits="CMSWebParts_MFS_AEAAdminConsulta" %>
<style type="text/css">
    .tdconsulta
    {
        padding-bottom: 5px;
    }
    .style2
    {
        text-align: right;
        font-size: small;
    }
    .style3
    {
        font-size: 13pt;
    }
    .WhiteButton
{
	text-align: center;
display: block;
background: none repeat scroll 0% 0% #87AE2A;
padding: 0px 12px;
text-decoration: none;
color: #FFF !important;
font-family: Oswald;
font-size: 14px;
line-height: 45px;
max-width: 200px;
max-height: 45px;
overflow: hidden;
}
    </style>

<br />
<asp:Panel ID="PnlInfoProyecto" runat="server" Visible="True">
    <table style="padding: 1px; margin: 1px; width:100%;">
        <tr>
            <td align="right" valign="middle">               
                    <div class="botonirbandeja">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/sconvocatoria/AdminProyectos.aspx" 
                    ToolTip="Regresar a la Bandeja de Administracion de Proyectos" 
                            CssClass="stylofuente WhiteButton"> Ir a la Bandeja de 
                        Poyectos</asp:HyperLink>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="WhiteButton">Realizar Consulta</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="padding: 5px 20px 5px 20px">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                    GridLines="None" Width="100%" 
                    EmptyDataText="Usted no tiene consultas realizadas, clic en Realizar cconsulta, para registrar una consulta">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="idconsulta" HeaderText="idconsulta" 
                            InsertVisible="False" ReadOnly="True" SortExpression="idconsulta" 
                            Visible="False" />
                        <asp:BoundField DataField="userid" HeaderText="userid" 
                            SortExpression="userid" Visible="False" />
                        <asp:BoundField DataField="IdConvocatoria" HeaderText="IdConvocatoria" 
                            SortExpression="IdConvocatoria" Visible="False" />
                        <asp:BoundField DataField="referenciabases" HeaderText="Referencia de las Bases" 
                            SortExpression="referenciabases" />
                        <asp:BoundField DataField="antecedente" HeaderText="Antecedente / Sustento" 
                            SortExpression="antecedente" />
                        <asp:BoundField DataField="consulta" HeaderText="Consulta/ Aclaración /Solicitud" 
                            SortExpression="consulta" />
                        <asp:BoundField DataField="idestado" HeaderText="idestado" 
                            SortExpression="idestado" Visible="False" />
                        <asp:BoundField DataField="respuesta" HeaderText="Respuesta" 
                            SortExpression="respuesta" >
                            <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AmbitoPais" HeaderText="AmbitoPais" 
                            SortExpression="AmbitoPais" Visible="False" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:FASERTConnectionString %>" 
                    SelectCommand="SELECT * FROM [AEA_CONSULTA] WHERE ([userid] = @userid)">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="userid" SessionField="userid" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Panel2" runat="server" Visible="False">
    <table style="width:100%;">
        <tr>
            <td valign="middle">
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="~/App_Themes/REC/REC_imagenes/information-messagebox.png" />
            </td>
            <td align="center" valign="middle">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button4" runat="server" Text="Aceptar" style="height: 26px" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="fondo" runat="server" Visible="False">
</asp:Panel>
<asp:Panel ID="pnlconsulta" runat="server"  Width="633px" Visible="False">
     <table style="padding: 1px; margin: auto; border: 0px solid #000000; width:98%; border-spacing: 3px; font-family: Tahoma; font-size: x-small;" >
            <tr style="border-style: none none solid none; border-width: 1px; border-color: #000000;">
                <td style="font-family: Tahoma; font-size: medium; font-weight: bold; border-bottom-style: 0; border-bottom-width: 1px; border-bottom-color: #000000;" 
                    align="center" colspan="2">
                    
                    <span >Ficha de Consultas</span></td>
            </tr>
            <tr>
                <td style="font-family: Tahoma; font-size: small; text-align: right;">
                    Convocatoria</td>
                <td style="border-style: none none solid none; border-width: 1px; 
                    border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: 
                    bold" class="tdconsulta">
                    &nbsp;
                    <asp:DropDownList ID="IdConvocatoria" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="DesConvocatoria" 
                    DataValueField="IdConvocatoria" Height="32px" Width="230px" 
                        style="font-size: x-small; font-family: Tahoma">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:FASERTConnectionString %>" 
                    
                        SelectCommand="SELECT [IdConvocatoria], [DesConvocatoria] FROM [MFSConvocatoria] WHERE (([EstadoConvocatoria] = @EstadoConvocatoria) AND ([idPrograma] = @idPrograma))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="EstadoConvocatoria" Type="Int32" />
                        <asp:Parameter DefaultValue="3" Name="idPrograma" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="font-family: Tahoma; " 
                    class="style2">
                    Pais al que Postula</td>
                <td style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold" 
                    class="tdconsulta">
                    <asp:DropDownList ID="AmbitoPais0" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSourcePais1" DataTextField="Pais" DataValueField="CodPais" 
                    Height="32px" Width="152px" style="font-family: Tahoma; font-size: x-small" 
                        Enabled="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourcePais1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                    SelectCommand="SELECT [CodPais], [Pais] FROM [PER_PAIS]">
                </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="font-family: Tahoma; " 
                    class="style2">
                    Referencia de las Bases.-
                    <br />
                    Numeral(es), Anexo(s), Página(s).</td>
                <td style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold" 
                    class="tdconsulta">
                    <asp:TextBox ID="referenciabases" runat="server" Height="100px" 
                        TextMode="MultiLine" Width="450px" 
                        style="font-family: Tahoma; font-size: x-small"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Ingrese la referencia de las Bases" 
                        ValidationGroup="consulta" ControlToValidate="referenciabases"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="font-family: Tahoma; " 
                    class="style2">
                    Antecedente / Sustento<br />
                    (si es necesario)</td>
                <td style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold" 
                    class="tdconsulta">
                    <asp:TextBox ID="antecedente" runat="server" Height="100px" 
                        TextMode="MultiLine" Width="450px" 
                        style="font-family: Tahoma; font-size: x-small"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="font-family: Tahoma; " 
                    class="style2">
                    Consulta/ Aclaración /Solicitud, según corresponda.</td>
                <td style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold" 
                    class="tdconsulta">
                    <asp:TextBox ID="consulta" runat="server" Height="100px" 
                        TextMode="MultiLine" Width="450px" 
                        style="font-family: Tahoma; font-size: small"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="Ingrese la consulta" ValidationGroup="consulta" 
                        ControlToValidate="consulta"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="font-family: Tahoma; font-size: x-small; font-weight: bold">
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td  colspan="2" align="center">
                     <asp:Button ID="Button5" runat="server" Text="Enviar Consulta" 
                         ValidationGroup="consulta" />
                                &nbsp;
                                <asp:Button ID="Button6" runat="server" Text="Cerrar" />
                </td>
            </tr>
            <tr>
                <td  colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
                    
                   
                </asp:Panel>