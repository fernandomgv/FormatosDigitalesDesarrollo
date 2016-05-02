<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MFSAdminProyectos.ascx.vb" Inherits="CMSWebParts_MFS_MFSAdminProyectos" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<%@ Register src="mensaje.ascx" tagname="mensaje" tagprefix="uc1" %>
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

.Font15 {
text-align:center;
}
.botoncancelar
{
	background:url("/MFS/App_Themes/REC/REC_imagenes/botoncancelar.png") no-repeat scroll 0 0 transparent;
	height:39px;
	padding-top:15px;
	width:227px;
    text-align:center;
	
}
.botongrabar
{
	background:url("/MFS/App_Themes/REC/REC_imagenes/botongrabar.png") no-repeat scroll 0 0 transparent;
	height:39px;
	padding-top:15px;
	width:227px;
    text-align:center;
	
}
.botonnuevo
{
	background:url("/MFS/App_Themes/REC/REC_imagenes/botonnuevo.png") no-repeat scroll 0 0 transparent;
	height:39px;
	padding-top:15px;
	width:227px;
    text-align:center;
	
}
.WhiteButton
{
	background:url("/MFS/App_Themes/REC/REC_imagenes/button-dd.png") no-repeat scroll 0 0 transparent;
	height:39px;
	padding-top:15px;
	width:227px;
    text-align:center;
	
}
    .ventanita
{
    position:fixed;
    top:20%;
    z-index:3;
    border:3px solid #d2b48c;
    padding:20px;
    background-color:#fafad2; 
    display:none;   
}
    .style1
    {
    }
    .style2
    {
        width: 989px;
    }
    .style3
    {
        width: 25px;
    }
    .style4
    {
        width: 806px;
    }
    .style6
    {
        width: 597px;
    }
    .style7
    {
    }
    /*Modal Popup*/
.modalBackground {
	background-color:Gray;
	filter:alpha(opacity=20);
	opacity:0.2;
}

.modalPopup {
	background-color:#ffffdd;
	border-width:3px;
	border-style:solid;
	border-color:Gray;
	padding:3px;
	width:250px;
}

  
.ModalWindow
{
  border: solid1px#c0c0c0;
  background:#f0f0f0;
  padding: 0px10px10px10px;
  position:absolute;
  top:-1000px;
}
    .style8
    {
        width: 132px;
    }
    .style9
    {
        width: 785px;
        font-family: Calibri; font-size: medium;
    }
    .style16
    {
        width: 154px;
        font-family: Calibri;
        font-size: small;
        font-weight: bold;
    }
    .style11
    {
    }
    .style13
    {
        font-family: Calibri; font-size: small; font-weight: bold;
    }
    .style17
    {
        width: 254px;
    }
    .style18
    {
        width: 230px;
    }
    .style19
    {
        width: 131px;
        font-family: Calibri;
        font-size: small;
        font-weight: bold;
    }
    .style20
    {
        width: 8px;
    }
    .style21
    {
        width: 127px;
    }
    .style22
    {
        width: 176px;
    }
p.MsoListParagraph
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:0cm;
	margin-left:36.0pt;
	margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
    .style23
    {
        width: 74px;
    }
    .style24
    {
        width: 11px;
        height: 57px;
    }
    .style25
    {
        width: 785px;
        font-family: Calibri;
        font-size: medium;
        text-align: center;
    }
    
.RadNotification_Default.rnShadows
{
	box-shadow: 2px 2px 3px #b0b0b0;
	-webkit-box-shadow: 2px 2px 3px #b0b0b0;
}

.rnRoundedCorners
{
	border-radius: 5px;
}

.RadNotification
{
	margin: 0;
	padding: 0;
	font-family: "Segoe UI",Arial,Helvetica,sans-serif;
    font-size: 12px;
    word-wrap: break-word;
    z-index: 9001;
}

.RadNotification_Default
{
	border: 1px solid #c4c4c4;
	background-color: #ebebeb;
}

.RadNotification_Default .rnTitleBar
{
	border-bottom: 1px solid transparent;
}

.RadNotification_Default .rnTitleBar
{
	background-image: url('http://localhost:2797/MFS/App_Themes/REC/REC_imagenes/notificacion.png');
}

.rnTitleBar
{
	height: 24px;
	background-repeat: repeat-x;
	background-position: 0 0;
	margin: 0;
	padding: 0 4px;
	border-radius: 5px 5px 0 0;
}

.rnTitleBarIcon
{
	display: block;
	float: left;
	width: 16px;
	height: 16px;
	margin: 4px 4px 0 0;
	overflow: hidden;
}

.rnTitleBarTitle
{
	display: block;
	float: left;
	width: 70%;
	height: 24px;
	line-height: 24px;
	overflow: hidden;
	font-weight: bold;
}

.RadNotification_Default .rnContentWrapper
{
	border-top: 1px solid transparent;
}

.rnContentWrapper
{
	padding: 5px 5px 5px 5px;
	border: 0;
}

.rnContentIconClipIn
{
	position: relative;
	float: left;
	margin: -2px 0 -34px 15px;
	width: 32px;
	height: 32px;
}

.rnContentIconClipIn .rnCustomIcon
{
	clip: auto;
	margin-top: 12px;
}

.rnContentIconClip
{
	position: absolute;
	top: -1px;
	clip: rect(16px 32px 48px 0);
}


.rnContent
{
	padding: 12px 20px 20px 67px;
}

    .style26
    {
        height: 57px;
    }
    </style>
<script>
    function LanzarVentanita(id) {
        var ventana = document.getElementById(id);
        ventana.style.display = 'block';
        ventana.style.left = ((document.body.clientWidth - ventana.clientWidth) / 2) + "px"
        document.getElementById('fondo').style.display = 'block';
        return false;
    }
    function CerrarVentanita(id) {
        //Sacamos la venatana
        var ventana = document.getElementById(id);
        ventana.style.display = 'none';
        document.getElementById('fondo').style.display = 'none';
        return false;
    }
</script>

&nbsp;<asp:Panel ID="Pnlmensajeaceso" runat="server" Visible="False">
    &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
        ForeColor="#993300" 
        Text="Su usuario no tiene acceso a esta pagina, por favor ingrese un usuario valido.  "></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MFS/MFSLogin.aspx">Iniciar 
    Sesión</asp:HyperLink>
</asp:Panel>
<asp:Panel ID="Pnlinfoproponente" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style24">
                </td>
            <td class="style26">
                <div class="WhiteButton" onclick="javascript:__doPostBack('<%=btnInfoentidad.UniqueID %>', '');">
                    <asp:LinkButton ID="btnInfoentidad" runat="server" CausesValidation="False" 
                        CssClass="Font15">[-] Ocultar Informacion de Entidad Proponente</asp:LinkButton>
                </div>
            </td>
            <td class="style26">
                </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Panel ID="pnlRegInstitucion" runat="server" 
                    CssClass="RadNotification RadNotification_Default rnRoundedCorners rnShadows">
                    <table style="width:100%;">
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td align="center" class="style9">
                                <asp:Label ID="lbltituloreginstitucion" runat="server" 
                                    Text="Ficha de Registro de Entidad Proponente"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style9">
                                <asp:Label ID="lblmensajeproponente" runat="server" Font-Bold="True" 
                                    ForeColor="#990000" Visible="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style25">
                                Bienvenido a nuestro Sistema en L<span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:ES;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">í</span>nea.<br />
                                <br />
                                &nbsp;Por favor completar el siguiente formulario de registro, llenando todo los 
                                campos.<br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style9">
                                Datos Generales</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style9">
                                <table frame="border" style="border: 1px solid #000000; width: 100%;">
                                    <tr>
                                        <td class="style16">
                                            Nombre de la Entidad</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="nombre_entidad" runat="server" Width="528px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="nombre_entidad" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese el Nombre de la Entidad</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            Acr<span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:ES;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">ó</span>nimo</td>
                                        <td class="style11" colspan="3">
                                            <asp:TextBox ID="acronimo" runat="server" Width="528px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="acronimo" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese en Acrónimo de la Entidad</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            Nº de Registro (RUC/NIT)</td>
                                        <td class="style11" colspan="3">
                                            <asp:TextBox ID="num_registro" runat="server" Width="245px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="num_registro" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese el Número de Registro de la Entidad</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            Pa<span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:ES;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">í</span>s</td>
                                        <td class="style18">
                                            <asp:DropDownList ID="paisentidad" runat="server" AutoPostBack="True" 
                                                DataSourceID="sqlpaisentidad" DataTextField="Pais" DataValueField="CodPais">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="sqlpaisentidad" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                                SelectCommand="SELECT * FROM [PER_PAIS]"></asp:SqlDataSource>
                                        </td>
                                        <td class="style13">
                                            Region</td>
                                        <td>
                                            <asp:DropDownList ID="regionEndtidad" runat="server" 
                                                DataSourceID="sqlregionentidad" DataTextField="Region" 
                                                DataValueField="CodRegion" Width="251px">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="sqlregionentidad" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                                SelectCommand="SELECT * FROM [PER_REGION] WHERE ([CodPais] = @CodPais)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="paisentidad" Name="CodPais" 
                                                        PropertyName="SelectedValue" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            Direcci<span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:ES;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">ó</span>n para correspondencia</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="direccion" runat="server" Width="528px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="direccion" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese la Dirección a usarse para el envio de 
                                            correspondencia</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            Correo electrónico</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="email" runat="server" Enabled="False" Width="525px"></asp:TextBox>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            Teléfono</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="telefono" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="telefono" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese un número de Telefono</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style9" style="font-family: Calibri; font-size: medium">
                                Representación Legal</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style9">
                                <table style="border: 1px solid #000000; width: 100%;">
                                    <tr>
                                        <td class="style13" 
                                            style="font-family: Calibri; font-size: small; font-weight: bold">
                                            Nombres</td>
                                        <td class="style14" colspan="3">
                                            <asp:TextBox ID="nom_legal" runat="server" Width="591px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                ControlToValidate="nom_legal" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese el Nombre del Representante Legal</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style13" 
                                            style="font-family: Calibri; font-size: small; font-weight: bold">
                                            Apellidos</td>
                                        <td class="style14" colspan="3">
                                            <asp:TextBox ID="app_legal" runat="server" Width="591px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                ControlToValidate="app_legal" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese los Apellidos del Representante Legal</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Tipo Documento</td>
                                        <td class="style17">
                                            <asp:DropDownList ID="tipo_doc_legal" runat="server">
                                                <asp:ListItem Value="1">DOCUMENTO NACIONAL DE IDENTIDAD (DNI)</asp:ListItem>
                                                <asp:ListItem Value="2">CARNET DE EXTRANJERIA</asp:ListItem>
                                                <asp:ListItem Value="3">PASAPORTE</asp:ListItem>
                                                <asp:ListItem Value="4">CÉDULA DIPLOMÁTICA DE IDENTIDAD</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            Nº de Documento</td>
                                        <td>
                                            <asp:TextBox ID="num_doc_legal" runat="server" Width="112px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            &nbsp;</td>
                                        <td class="style14" colspan="3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                ControlToValidate="num_doc_legal" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese el Número de Documento de Identidad 
                                            del Representante Legal</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Correo electrónico</td>
                                        <td class="style14" colspan="3">
                                            <asp:TextBox ID="email_legal" runat="server" Width="590px"></asp:TextBox>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                ControlToValidate="email_legal" ErrorMessage="RegularExpressionValidator" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                ValidationGroup="infoentidad">Ingrese una cuenta de correo valida para el 
                                            Representante Legal</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style13">
                                            Teléfono</td>
                                        <td class="style14" colspan="3">
                                            <asp:TextBox ID="telefono_legal" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                ControlToValidate="telefono_legal" ErrorMessage="RequiredFieldValidator" 
                                                ValidationGroup="infoentidad">Ingrese un número de Telefono para el 
                                            Representante Legal</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td class="style9">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;</td>
                            <td align="center" class="style9">
                                <asp:Button ID="btngrabarentidad" runat="server" Text="Grabar" 
                                    ValidationGroup="infoentidad" />
                                &nbsp;
                                <asp:Button ID="btncancelarentidad" runat="server" CausesValidation="False" 
                                    onclientclick="if( !confirm('Los datos que no fueron grabados se perderan')){return false;}" 
                                    Text="Cancelar" />
                                &nbsp;
                                <asp:Button ID="Button3" runat="server" CausesValidation="False" 
                                    Text="Historial" Visible="False" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="PnlBandejaProyecto" CssClass="RadNotification RadNotification_Default rnRoundedCorners rnShadows" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1" colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:SqlDataSource ID="SqlDataSourceProyecto" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                    SelectCommand="SELECT * FROM [VWProyectos] WHERE ([UserID] = @UserID)">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="UserID" SessionField="UserId" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Panel ID="Panel3" runat="server" 
                    CssClass="RadNotification RadNotification_Default rnRoundedCorners rnShadows">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButton7" runat="server" 
                                    ImageUrl="~/App_Themes/CorporateSite/Images/delete.gif" 
                                    ToolTip="Ocultar Ayuda" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" class="style23">
                                                <asp:ImageButton ID="ImageButton4" runat="server" Height="20px" 
                                                    ImageUrl="~/App_Themes/CorporateSite/Images/MediaLibrary/Menu/modelist.gif" 
                                                    Width="20px" />
                                            </td>
                                            <td>
                                                &nbsp;Esta opción le permitirá Administrar todo el&nbsp; ciclo de vida de su&nbsp;Proyecto, 
                                                Presentación del Perfil, la Propuesta y seguimiento del mismo.
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style23">
                                                <asp:ImageButton ID="ImageButton5" runat="server" Height="20px" 
                                                    ImageUrl="~/App_Themes/CorporateSite/Images/edit.gif" Width="20px" />
                                            </td>
                                            <td>
                                                Esta opción le permitirá Editar la información que usted proporciono para el 
                                                registro de su Proyecto, solo algunos campos podrán ser editados.</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style23">
                                                <asp:ImageButton ID="ImageButton6" runat="server" Height="20px" 
                                                    ImageUrl="~/App_Themes/CorporateSite/Images/delete.gif" Width="20px" />
                                            </td>
                                            <td>
                                                Esta opción le permitirá eliminar un Proyecto registrado, con todas la 
                                                información proporcionada, esta opción no podrá ser revertida.</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="IdProyecto" DataSourceID="SqlDataSourceProyecto" 
                    EmptyDataText="Actualmente no tiene ningun Proyecto Registrado, Para registrar un Proyecto haga clic en el Boton Agregar." 
                    ForeColor="#333333" GridLines="None" Width="100%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:ButtonField ButtonType="Image" CommandName="workflow" 
                            ImageUrl="~/App_Themes/CorporateSite/Images/MediaLibrary/Menu/modelist.gif" 
                            Text="Botón" />
                        <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                            ImageUrl="~/App_Themes/CorporateSite/Images/edit.gif" Text="Botón" />
                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                            ImageUrl="~/App_Themes/CorporateSite/Images/delete.gif" Text="Botón" />
                        <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" 
                            Visible="False" />
                        <asp:BoundField DataField="IdProyecto" HeaderText="IdProyecto" ReadOnly="True" 
                            SortExpression="IdProyecto" Visible="False" />
                        <asp:BoundField DataField="CodProyecto" HeaderText="Código" 
                            ReadOnly="True" SortExpression="CodProyecto" />
                        <asp:BoundField DataField="desconvocatoria" HeaderText="Convocatoria" 
                            SortExpression="desconvocatoria" />
                        <asp:BoundField DataField="NombreProyecto" HeaderText="Proyecto" 
                            ReadOnly="True" SortExpression="NombreProyecto">
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" ReadOnly="True" 
                            SortExpression="Ubicacion">
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EstadoProyecto" HeaderText="EstadoProyecto" 
                            SortExpression="EstadoProyecto" Visible="False" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <div class="botonnuevo" onclick="javascript:__doPostBack('<%=LinkButton1.UniqueID %>', '');">
                    <asp:LinkButton ID="LinkButton1" runat="server">Registrar Proyecto</asp:LinkButton>
                </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="PnlregistroProyecto" runat="server" Visible="False" 
    CssClass="RadNotification RadNotification_Default rnRoundedCorners rnShadows">
    <table style="width:100%;">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                    ContextTypeName="MFSDataContext" TableName="MFSProyecto">
                </asp:LinqDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                <p class="MsoListParagraph" style="margin-left:0cm;text-align:justify">
                    <span lang="ES" style="font-size:12.0pt;mso-ascii-font-family:Calibri;mso-ascii-theme-font:
minor-latin;mso-fareast-font-family:&quot;Times New Roman&quot;;mso-hansi-font-family:
Calibri;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:Calibri;
mso-bidi-theme-font:minor-latin;mso-ansi-language:ES;mso-fareast-language:ES">Bienvenido a nuestro 
                    proceso de Convocatoria 2011, le agradecemos registrar su proyecto en nuestro 
                    sistema para completar el proceso de concurso.<o:p></o:p></span></p>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                <table style="padding: 1px; margin: 1px; border: 1px solid #000000; width:100%;">
                    <tr style="border-style: none none solid none; border-width: 1px; border-color: #000000;">
                        <td class="style22" 
                            style="font-family: Calibri; font-size: small; font-weight: bold">
                            Código Proyecto</td>
                        <td class="style6" 
                            style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                            <asp:TextBox ID="IdProyecto" runat="server" Enabled="False" ForeColor="#990000">Autogenerado</asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22" 
                            style="font-family: Calibri; font-size: small; font-weight: bold">
                            Convocatoria</td>
                        <td class="style6" 
                            style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                            <asp:DropDownList ID="IdConvocatoria" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="DesConvocatoria" 
                                DataValueField="IdConvocatoria" Height="22px" Width="230px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                SelectCommand="SELECT [IdConvocatoria], [DesConvocatoria] FROM [MFSConvocatoria] WHERE (([EstadoConvocatoria] = @EstadoConvocatoria) AND ([idPrograma] = @idPrograma))">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="EstadoConvocatoria" Type="Int32" />
                                    <asp:Parameter DefaultValue="1" Name="idPrograma" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7" 
                            style="font-family: Calibri; font-size: small; font-weight: bold" 
                            colspan="2">
                            <asp:CheckBox ID="PostulacionAsociada" runat="server" 
                                Text="Postula en Sociedad con Otra Institucion" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22" 
                            style="font-family: Calibri; font-size: small; font-weight: bold" 
                            valign="middle">
                            País de Postulación
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageAlign="Middle" 
                                ImageUrl="~/App_Themes/REC/REC_imagenes/symbol-help32.png" 
                                ToolTip="Selecciones por favor el Pais donde su Perfil de Proyecto debera ser Evaluado" />
                        </td>
                        <td class="style6" 
                            style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                            <asp:DropDownList ID="AmbitoPais0" runat="server" AutoPostBack="True" 
                                DataSourceID="SqlDataSourcePais" DataTextField="Pais" DataValueField="CodPais" 
                                Height="22px" Width="152px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourcePais1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                SelectCommand="SELECT [CodPais], [Pais] FROM [PER_PAIS]">
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22" 
                            style="font-family: Calibri; font-size: small; font-weight: bold">
                            Titulo del Proyecto</td>
                        <td class="style6" 
                            style="border-style: none none solid none; border-width: 1px; border-color: #000000; font-family: Calibri; font-size: x-small; font-weight: bold">
                            <asp:TextBox ID="NombreProyecto" runat="server" Width="589px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                ControlToValidate="NomCoord" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="infoproyecto">Ingrese el Titulo del Proyecto</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style22" 
                            style="font-family: Calibri; font-size: small; font-weight: bold">
                            Ámbito Geografico</td>
                        <td class="style6">
                            <table style="width:100%;">
                                <tr>
                                    <td align="center" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        País</td>
                                    <td align="center" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        Región</td>
                                </tr>
                                <tr>
                                    <td style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        <asp:DropDownList ID="AmbitoPais" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourcePais" DataTextField="Pais" DataValueField="CodPais" 
                                            Height="22px" Width="152px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourcePais" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                            SelectCommand="SELECT [CodPais], [Pais] FROM [PER_PAIS]">
                                        </asp:SqlDataSource>
                                    </td>
                                    <td style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        <asp:DropDownList ID="AmbitoRegion" runat="server" 
                                            DataSourceID="SqlDataSourceRegion" DataTextField="Region" 
                                            DataValueField="CodRegion" Height="22px" Width="333px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceRegion" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                            SelectCommand="SELECT [CodRegion], [Region] FROM [PER_REGION] WHERE ([CodPais] = @CodPais)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="AmbitoPais" DefaultValue="0" Name="CodPais" 
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        Ubicación Especifica</td>
                                </tr>
                                <tr>
                                    <td colspan="2" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        <asp:TextBox ID="AmbitoUbicacion" runat="server" Width="579px" Visible="False"></asp:TextBox>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7" colspan="2">
                            <asp:Panel ID="PnlProyUbicacion" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="BtnUbicacion" runat="server" 
                                                Text="Agregar Ubicación Geografica" />
                                            &nbsp;
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" 
                                                ImageUrl="~/App_Themes/REC/REC_imagenes/symbol-help32.png" 
                                                ToolTip="Podra Usted agregar todas las ubicaciones geograficas donde su proyecto se ejecutara, una a una, seleccionando el Pais y la Region correspondiente y haciendo clic en el boton Agregar Ubicacion Geografica" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblmensaje" runat="server" ForeColor="#990000" 
                                                
                                                
                                                Text="Ninguna ubicación Geografica a sido agregada al Poyecto, para agregar las ubicaciones clic en el boton &quot;Agregar Ubicacion Geografica&quot;"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="center">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" DataKeyNames="IdProyectoUbicacion" ForeColor="#333333" 
                                                GridLines="None" Width="285px">
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="IdProyectoUbicacion" Visible="False" />
                                                    <asp:BoundField DataField="Pais" HeaderText="Pais">
                                                        <ControlStyle Width="50px" />
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Region" HeaderText="Region">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AmbitoRegion" HeaderText="Territorio" 
                                                        Visible="False" />
                                                    <asp:BoundField DataField="AmbitoUbicacion" HeaderText="Ubicacion" 
                                                        Visible="False" />
                                                    <asp:ButtonField ButtonType="Image" CommandName="eliminar" 
                                                        ImageUrl="~/App_Themes/CorporateSite/Images/delete.gif" Text="Botón" />
                                                </Columns>
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4" valign="middle">
                Responsable del Proyecto
                <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="Middle" 
                    ImageUrl="~/App_Themes/REC/REC_imagenes/symbol-help32.png" 
                    ToolTip="Los datos proporcionados en esta Seccion, seran usados como datos de contacto ." />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                <table style="padding: 1px; margin: 1px; border: 1px solid #000000; width: 100%;">
                    <tr>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            Nombres</td>
                        <td>
                            <asp:TextBox ID="NomCoord" runat="server" Width="589px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="NomCoord" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="infoproyecto">Ingrese el (los) Nombre del Coordinador del 
                            Proyecto</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            Apellidos</td>
                        <td>
                            <asp:TextBox ID="AppCoord" runat="server" Width="589px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="AppCoord" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="infoproyecto">Ingrese los Apellidos del Coordinador del 
                            Proyecto</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            Cargo</td>
                        <td>
                            <asp:TextBox ID="CargoCoord" runat="server" Width="589px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="CargoCoord" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="infoproyecto">Ingrese el Cargo del Coordinador del Proyecto</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            Dirección</td>
                        <td>
                            <table style="width:100%;">
                                <tr>
                                    <td align="center" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        Pais</td>
                                    <td align="center" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        Region</td>
                                </tr>
                                <tr>
                                    <td style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        <asp:DropDownList ID="PaisCoord" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourcePais0" DataTextField="Pais" DataValueField="CodPais" 
                                            Height="22px" Width="152px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourcePais0" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                            SelectCommand="SELECT [CodPais], [Pais] FROM [PER_PAIS]">
                                        </asp:SqlDataSource>
                                    </td>
                                    <td style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        <asp:DropDownList ID="RegionCoord" runat="server" 
                                            DataSourceID="SqlDataSourceRegion0" DataTextField="Region" 
                                            DataValueField="CodRegion" Height="22px" Width="333px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceRegion0" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:KenticoCMSConnectionString %>" 
                                            SelectCommand="SELECT [CodRegion], [Region] FROM [PER_REGION] WHERE ([CodPais] = @CodPais)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="PaisCoord" DefaultValue="0" Name="CodPais" 
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        Ubicacion Especifica</td>
                                </tr>
                                <tr>
                                    <td colspan="2" 
                                        style="font-family: Calibri; font-size: x-small; font-weight: bold">
                                        <asp:TextBox ID="DireccionCoord" runat="server" Width="579px"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                            ControlToValidate="DireccionCoord" ErrorMessage="RequiredFieldValidator" 
                                            ValidationGroup="infoproyecto">Ingrese la direccion de envio de 
                                        Correspondencia para el Coordinador del Proyecto</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            Correo Electrónico</td>
                        <td>
                            <asp:TextBox ID="EmailCoord" runat="server" Width="589px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                ControlToValidate="EmailCoord" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="infoproyecto">Ingre el Correo Electrónico del Coordinador 
                            del Proyecto</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            Teléfono</td>
                        <td>
                            <asp:TextBox ID="telefonoCoord" runat="server" Width="589px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                ControlToValidate="telefonoCoord" ErrorMessage="RequiredFieldValidator" 
                                ValidationGroup="infoproyecto">Ingrese el Teléfono del Coordinador del 
                            Proyecto</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td align="center" class="style4">
                <table style="width:100%;">
                    <tr>
                        <td align="center">
                            <div class="botongrabar" onclick="javascript:__doPostBack('<%=btngrabar1.UniqueID %>', '');">
                                <asp:LinkButton ID="btngrabar1" runat="server">Grabar</asp:LinkButton>
                            </div>
                        </td>
                        <td align="center">
                            <div class="botoncancelar" onclick="javascript:__doPostBack('<%=btncancelar2.UniqueID %>', '');">
                                <asp:LinkButton ID="btncancelar2" runat="server" 
                                    onclientclick="Alert('Esta seguro de cancelar la edicion')">Cancelar</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="infoproyecto" 
                    Visible="False" />
&nbsp;
                <asp:Button ID="BtnCancelar" runat="server" 
                    onclientclick="Alert('Esta seguro de cancelar la edicion')" 
                    Text="Cancelar" Visible="False" />
            </td>
            <td>
                &nbsp;</td>
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









