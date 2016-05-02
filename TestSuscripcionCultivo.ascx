<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TestSuscripcionCultivo.ascx.cs" Inherits="CMSEjemplosFer_TestSuscripcionCultivo" %>
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajaxToolkit:ToolkitScriptManager>--%>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
<script type="text/javascript" language="javascript">
function Changed( mytxt,dcm)
{
   //alert( mytxt.value);
  // alert (mytxt.id);
  // mytxt.value= mytxt.value + '.00'
   var numval = Number( mytxt.value)
   if ( isNaN(numval))
   {
   mytxt.style.border = '1px solid red';;
   alert('revise el valor ingresado, se espera un numero');
   }
   else
   {
   if ( isNaN(dcm))
   {
    dcm=2;
   }
   mytxt.value=numval.toFixed(dcm);
   mytxt.style.border = '';
   };
  // alert ( numval.toString());
};
</script>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    Width="419px" DataKeyNames="CultivoID,TipoCultivo,ItemID,UserID,MesSiembra" 
    Height="166px" 
    onrowdatabound="GridView1_RowDataBound" onprerender="GridView1_PreRender">
    <Columns>
        <asp:BoundField DataField="CultivoID" Visible="False" />
        <asp:TemplateField HeaderText="Cultivo">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" 
                    Checked= <%# inttobol( Eval("Checked"))%> Text = <%#Eval("NombreComun")%> 
                    AutoPostBack="False"    />
            </ItemTemplate>
            <ControlStyle Width="100px" />
        </asp:TemplateField>
        <asp:BoundField DataField="TipoCultivo" Visible="False" />
        <asp:BoundField DataField="ItemID" Visible="False" />
        <asp:TemplateField HeaderText="Edad Plantacion">
            <ItemTemplate>
                <asp:TextBox ID="TextEdad" style="text-align:right;" runat="server" Text = <%#Eval("EdadPlantacion")%> 
                    Enabled="False" AutoPostBack="False" Height="22px" Width="70px" ></asp:TextBox>
            </ItemTemplate>
            <ControlStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Mes de Siembra">
            <ItemTemplate>
                <asp:DropDownList ID="DrpDwnMes" runat="server" Enabled="False"  
                    AutoPostBack="False" >
                    <asp:ListItem Value="0">Seleccionar Mes</asp:ListItem>
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
            
        </asp:TemplateField>
        <asp:BoundField DataField="UserID" Visible="False" />
        <asp:TemplateField HeaderText="Extension">
            <ItemTemplate>
                <asp:TextBox ID="TextExtension" Text=<%#Eval("extension")%> runat="server"  Width="70px" style="text-align:right;"> </asp:TextBox>
            </ItemTemplate>
            <ControlStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ubicacion">
            <ItemTemplate>
                <table style="width:100%;">
                    <tr>
                        <td align="center">
                            <asp:TextBox ID="TxtLatitud" Text=<%#Eval("latitud")%> style="text-align:right;" runat="server" Width="70px"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="TxtLongitud" Text=<%#Eval("longitud")%> style="text-align:right;" runat="server" Width="70px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <HeaderTemplate>
                <table style="width:100%;">
                    <tr>
                        <td align="center">
                            Latitud</td>
                        <td align="center">
                            Longitud</td>
                    </tr>
                </table>
            </HeaderTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        No Existen CULTIVOS definidos para el TERRITORIO seleccionado. Contacte al 
        administrador de la Aplicacion para realizar el registro de Cultivos, la cual se 
        realiza en la seccion:<br />
        [TERRITORIO]\[CULTIVOS] en el Sitio Web de la Aplicacion SPATS : <a href="http://spats.pe.iica.int/Modulos-en-Implementacion.aspx" target="_blank"> Ir al Sitio Web</a>
    </EmptyDataTemplate>
</asp:GridView>



