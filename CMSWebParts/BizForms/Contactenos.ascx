<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Contactenos.ascx.vb" Inherits="CMSWebParts_MFS_Contactenos" %>
<table style="width:100%;">
    <tr>
        <td>
            Nombres y Apellidos</td>
        <td>
            <asp:TextBox ID="txtapellido" runat="server" Width="280px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtapellido" ErrorMessage="Ingrese un nombre" 
                ValidationGroup="enviar"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Asunto</td>
        <td>
            <asp:TextBox ID="txtasunto" runat="server" Width="280px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtasunto" ErrorMessage="Ingrese un asunto" 
                ValidationGroup="enviar"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Email</td>
        <td>
            <asp:TextBox ID="txtmail" runat="server" Width="280px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtmail" ErrorMessage="Ingrese un Email" 
                ValidationGroup="enviar"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtmail" ErrorMessage="Ingrese un Email valido" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            País de Contacto</td>
        <td>
            <asp:DropDownList ID="ddpais" runat="server" Width="150px">
                <asp:ListItem>Regional</asp:ListItem>
                <asp:ListItem>Bolivia</asp:ListItem>
                <asp:ListItem>Colombia</asp:ListItem>
                <asp:ListItem>Ecuador</asp:ListItem>
                <asp:ListItem>Peru</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Consulta</td>
        <td>
            <asp:TextBox ID="txtconsulta" runat="server" Height="200px" 
                TextMode="MultiLine" Width="280px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="txtconsulta" ErrorMessage="Ingrese su Consulta" 
                ValidationGroup="enviar"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            </td>
        <td>
        <asp:Button ID="btnborrar" runat="server" Text="BORRAR" CssClass="btnborrar"  />
            <asp:Button ID="btnenviar" runat="server" Text="ENVIAR" CssClass="btnenviar" 
                ValidationGroup="enviar" />
        </td>
    </tr>
</table>
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