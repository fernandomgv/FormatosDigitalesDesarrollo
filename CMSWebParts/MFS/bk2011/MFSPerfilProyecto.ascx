<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MFSPerfilProyecto.ascx.vb" Inherits="CMSWebParts_MFS_MFSPerfilProyecto" %>
<style type="text/css">
    
    .RadNotification_Default
{
	border: 1px solid #c4c4c4;
	background-color: #ebebeb;
}

.RadNotification_Default.rnShadows
{
	box-shadow: 2px 2px 3px #b0b0b0;
	-webkit-box-shadow: 2px 2px 3px #b0b0b0;
}

.RadNotification_Default .rnTitleBar,
.RadNotification_Default .rnCommands a
{
	background-image: url('http://localhost:2797/MFS/App_Themes/REC/REC_imagenes/notificacion.png');
}

.RadNotification_Default .rnTitleBar
{
	border-bottom: 1px solid transparent;
}

.RadNotification_Default .rnContentWrapper
{
	border-top: 1px solid transparent;
}

    
    .WhiteButton
{
	background:url("/MFS/App_Themes/REC/REC_imagenes/button-dd.png") no-repeat scroll 0 0 transparent;
	height:39px;
	padding-top:15px;
	width:227px;
    text-align:center;
	
}
.botonirbandeja
{
	background:url("/MFS/App_Themes/REC/REC_imagenes/botonirbandeja.png") no-repeat scroll 0 0 transparent;
	height:39px;
	padding-top:15px;
	width:227px;
    text-align:center;
    vertical-align:middle;	
}
.stylofuente
{
    font-size:small;
        font-family: Tahoma;
    }
    .style4l
    {
        width: 915px;
    }
    .style5l
    {
        height: 6px;
        width: 10px;
    }
    .style6l
    {
    }
    .style2l2l
    {
        width: 143px;
    }
    .style2l3l
    {
        width: 135px;
    }
    .style2l4l
    {
    }
    .style2l5l
    {
    }
    .style1l
    {
    }
    .style2l
    {
    }
    .style3l
    {        text-align: center;
        font-size: small;
    }
    .style7
    {
        font-size: small;
        text-align: center;
    }
        .style15
        {
            font-family: Tahoma;
        }
        .style17
    {
        font-size: small;
    }
    .style18
    {
        font-size: x-small;
        font-family: Tahoma;
    }
    .style19
    {
        font-size: small;
        font-family: Tahoma;
        font-style: italic;
    }
    .style20
    {
        color: #FF0000;
    }
    </style>

&nbsp;<asp:Panel ID="PnlInfoProyecto" runat="server" 
    >
    <table style="padding: 1px; margin: 1px; width:100%;">
        <tr>
            <td class="style5l">
                <div class="WhiteButton" 
                    onclick="javascript:__doPostBack('<%=btnpnlproy.UniqueID %>', '');">
                    <asp:LinkButton ID="btnpnlproy" runat="server" CssClass="stylofuente">[-] Ocultar informacion del 
                Proyecto</asp:LinkButton>
                </div>
                </td>
            <td align="right" colspan="2" valign="middle">               
                    <div class="botonirbandeja" >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="/mfs/mfs/mfsAdminProyectos.aspx" 
                    ToolTip="Regresar a la Bandeja de Administracion de Proyectos" 
                            CssClass="stylofuente"> Ir a la Bandeja de 
                        Poyectos</asp:HyperLink>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style6l">
                &nbsp;</td>
            <td class="style4l">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6l" colspan="3">
                <asp:Panel ID="pnlproy" runat="server" 
                    
                    CssClass="RadNotification RadNotification_Default rnRoundedCorners rnShadows">
                    <table style="padding: 1px; margin: auto; border: 0px solid #000000; width:98%; border-spacing: 3px;">
                        <tr style="border-style: none none solid none; border-width: 1px; border-color: #000000;">
                            <td class="style2l2l" 
                                style="font-family: Calibri; font-size: small; font-weight: bold">
                                Código Proyecto</td>
                            <td class="style2l3l" 
                                style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                                <asp:TextBox ID="IdProyecto" runat="server" Enabled="False" ForeColor="#990000">Autogenerado</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2l2l" 
                                style="font-family: Calibri; font-size: small; font-weight: bold">
                                Convocatoria</td>
                            <td class="style2l3l" 
                                style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                                <asp:TextBox ID="convocatoria" runat="server" Enabled="False" ForeColor="White" 
                                    Width="437px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" 
                                style="font-family: Calibri; font-size: small; font-weight: bold">
                                <asp:CheckBox ID="PostulacionAsociada" runat="server" Enabled="False" 
                                    Text="Postula en Sociedad con Otra Institucion" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2l2l" 
                                style="font-family: Calibri; font-size: small; font-weight: bold">
                                Título del Proyecto</td>
                            <td class="style2l3l" 
                                style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                                <asp:TextBox ID="NombreProyecto" runat="server" Enabled="False" Width="589px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2l2l" 
                                style="font-family: Calibri; font-size: small; font-weight: bold">
                                Ámbito geográfico</td>
                            <td class="style2l3l">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" DataKeyNames="IdProyectoUbicacion" ForeColor="#333333" 
                                    GridLines="None" Width="655px" CssClass="stylofuente">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="IdProyectoUbicacion" Visible="False" />
                                        <asp:BoundField DataField="Pais" HeaderText="País">
                                            <ControlStyle Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Region" HeaderText="Región">
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AmbitoRegion" HeaderText="AmbitoRegion" 
                                            Visible="False" />
                                        <asp:BoundField DataField="AmbitoUbicacion" HeaderText="Ubicacion" 
                                            Visible="False" />
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7" colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style6l">
                &nbsp;</td>
            <td class="style4l">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="PnlFlujo" runat="server" CssClass="RadNotification RadNotification_Default rnRoundedCorners rnShadows" 
    >
    <table style="width:100%;">
        <tr>
            <td class="style2l4l">
                &nbsp;</td>
            <td class="style2l5l">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2l4l" colspan="3">
                <asp:Panel ID="pnlupperfil" runat="server" CssClass="stylofuente ">
                    <table style="width:100%;">
                        <tr>
                            <td class="style1l" colspan="3">
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                                    Width="100%" style="font-size: small">
                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>Presentación del  Perfil del  Proyecto</HeaderTemplate><ContentTemplate><br />
                                        <table 
                                        
                                            style="padding: 5px; margin: 10px; border: 1px solid #000000; width:97%; font-size: small;"><tr>
                                                <td class="style3l" align="center" 
                                                    style="border-bottom-style: solid; border-bottom-width: 1px; border-color: #000000">
                                            Para adjuntar el archivo que contiene toda la información solicitada en el perfil  siga los siguientes pasos. Nótese que el archivo debe ser en formato XLS y el tamaño máximo permitido es de 3 MB.
                                            
                                                    <br />
                                            
                                            <br/>
                                                    <span class="style20">Debido a que el tiempo de carga de los archivos puede 
                                                    variar según la conexión de internet utilizada, sugerimos realizar la carga del 
                                                    archivo con buen tiempo de antelación para cumplir con la hora límite de recibo 
                                                    de perfiles. </span>
                                          </td>
                                             
                                             <td valign="middle"><br /><br />
                                                <br /></td></tr><tr>
                                        <td style="font-family: Tahoma; font-size: small; font-style: italic">Paso 1:<br />
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seleccione el archivo con el Perfil del Proyecto en formato XLS</td></tr><tr>
                                                <td 
                                            class="style7"><span class="style17"><span class="style15">
                                                    <br />
                                                    Adjuntar Perfil&nbsp;&nbsp;</span><asp:ImageButton ID="ImageButton3" runat="server" 
                                                        CssClass="style15" ImageAlign="Middle" 
                                                        ImageUrl="~/App_Themes/REC/REC_imagenes/symbol-help32.png" 
                                                        ToolTip="Usted debe adjuntar el archivo en formato XLS, que descargo junto con las bases de la Convocatoria, con los datos solicitados" />
                                                    <span class="style15">&nbsp;&nbsp;&nbsp;&nbsp; </span></span>
                                                    <asp:FileUpload ID="FUperfil" runat="server" CssClass="style18" />
                                                    <span class="style17">
                                                    <br class="style15" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                        ControlToValidate="FUperfil" CssClass="style15" 
                                                        ErrorMessage="Solo se permite adjuntar un archivo con extension xls." 
                                                        ValidationExpression="(.*\.([Xx][Ll][Ss])$)" ValidationGroup="upload"></asp:RegularExpressionValidator>
                                                    <br class="style15" />
                                                    <asp:Label ID="lblperfilerror" runat="server" CssClass="style15" 
                                                        ForeColor="Red" Text="El tamaño maximo de archivo permitido es de 3 MB" 
                                                        Visible="False"></asp:Label>
                                                    </span>
                                        </td></tr><tr><td align="center" class="style3l" valign="middle" 
                                                    style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                                                <br />
                                            <asp:Button ID="btnAdjuntar" runat="server" Text="Adjuntar Perfil" 
                                                    ValidationGroup="upload" />
                                                &nbsp;&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageAlign="Middle" 
                                                ImageUrl="~/App_Themes/REC/REC_imagenes/symbol-help32.png" 
                                                
                                                    ToolTip="Al hacer clic sobre el boton, el archivo seleccionado sera adjuntado como Perfil de su Proyecto actual, podra reemplazar este archivo hasta que usted eliga la opcion de Cerrar su Perfil" />
                                                <br /><br />
                                            </td></tr>
                                            <tr>
                                                <td align="center" style="text-align: left" valign="middle">
                                                    <span class="style19">
                                                    <br />
                                                    Paso 2:</span><i><br class="style18" />
                                                    <br class="style18" />
                                                    </i><span class="style19">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Una vez seleccionado el archivo, para que este sea cargado y entre a formar parte de su Perfil, haga clic en el botón <b>
                                                    &quot;Adjuntar Perfil&quot;<br />
                                                    </b></span>
                                                </td>
                                            </tr>
                                            <tr>
                                    <td class="style3l" 
                                                    style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                                        <asp:Panel ID="pnlFileUploaded" runat="server" style="text-align: center">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="stylofuente" DataKeyNames="IdFileProyecto" 
                                                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                                                Width="654px">
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:BoundField DataField="IdFileProyecto" HeaderText="IdFileProyecto" 
                                                        InsertVisible="False" ReadOnly="True" SortExpression="IdFileProyecto" 
                                                        Visible="False" />
                                                    <asp:BoundField DataField="IdProyecto" HeaderText="IdProyecto" 
                                                        SortExpression="IdProyecto" Visible="False" />
                                                    <asp:BoundField DataField="IdWorkFlow" HeaderText="IdWorkFlow" 
                                                        SortExpression="IdWorkFlow" Visible="False" />
                                                    <asp:BoundField DataField="IdTipo" HeaderText="IdTipo" SortExpression="IdTipo" 
                                                        Visible="False" />
                                                    <asp:BoundField DataField="version" HeaderText="version" 
                                                        SortExpression="version" Visible="False" />
                                                    <asp:BoundField DataField="TituloFile" HeaderText="Archivo" 
                                                        SortExpression="TituloFile" />
                                                    <asp:BoundField DataField="extfile" HeaderText="extfile" 
                                                        SortExpression="extfile" Visible="False" />
                                                    <asp:BoundField DataField="nombrefile" HeaderText="nombrefile" 
                                                        SortExpression="nombrefile" Visible="False" />
                                                    <asp:BoundField DataField="fecupload" HeaderText="Fecha y Hora de Carga" 
                                                        SortExpression="fecupload">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:HyperLinkField Text="Descargar" />
                                                    <asp:BoundField DataField="ipupload" HeaderText="ipupload" 
                                                        SortExpression="ipupload" Visible="False" />
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                                SelectCommand="SELECT * FROM [MFSFileProyecto] WHERE (([IdProyecto] = @IdProyecto) AND ([IdWorkFlow] = @IdWorkFlow))">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="IdProyecto" SessionField="IdProyecto" 
                                                        Type="Int32" />
                                                    <asp:Parameter DefaultValue="1" Name="IdWorkFlow" Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br />
                                        </asp:Panel>
                                    </td></tr>
                                            <tr>
                                                <td align="center" style="text-align: left; font-size: small">
                                                    &nbsp;<span class="style20">Puede repetir los pasos 1 y 2 con la finalidad de 
                                                    actualizar/editar la versión de su archivo con el Formato de Perfil.</span><br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="text-align: left; font-size: x-small">
                                                    <span class="style17"><i>Paso 3:<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cuando ya no desee hacer más modificaciones a su archivo de Perfil y 
                                                    quiera postularse para la Convocatoria haga clic en el botón <b>“Postular 
                                                    Perfil”.</b> Con esta acción asegura su participación en la Convocatoria. 
                                                    Después de hacer la postulación no es posible editar o reemplazar el archivo de 
                                                    Perfil del Proyecto.
                                                    <br />
                                                    </i></span><br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="BtnCerrarPerfil" runat="server" Text="Postular Perfil" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="ImageButton5" runat="server" ImageAlign="Middle" 
                                                        ImageUrl="~/App_Themes/REC/REC_imagenes/symbol-help32.png" 
                                                        ToolTip="Al hacer clic sobre el boton,Usted confirma que el archivo que adjunto como Perfil es la version definitiva y no podra reemplazarlo nuevamente, se le enviara via mail la confirmacion la cual tambien podra ser impresa al hacer clic aqui. " />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="font-size: x-small; text-align: left">
                                                    &nbsp;</td>
                                                <td class="style3l">
                                                    <asp:Panel ID="pnlPerfilCerrado" runat="server">
                                                    </asp:Panel>
                                                </td>
                                                <td class="style3l">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table></ContentTemplate></ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>Presentacion de la Propuesta del Proyecto</HeaderTemplate></ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1l">
                                &nbsp;</td>
                            <td class="style2l" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1l">
                                &nbsp;</td>
                            <td align="center" class="style2l">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1l">
                                &nbsp;</td>
                            <td align="center" class="style2l">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1l">
                                &nbsp;</td>
                            <td align="center" class="style2l">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="Panel1" runat="server" Height="61px" Visible="False" 
    Width="417px">
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
                <asp:Button ID="Button4" runat="server" Text="Aceptar" />
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
<asp:Panel ID="fondo" runat="server">
</asp:Panel>