<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CultivoEstadoFenologico.ascx.cs" Inherits="CMSEjemplosFer_CultivoEstadoFenologico" %>
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
    Width="419px" DataKeyNames="EstadoFenologicoID,CultivoEstadoFenologicoID" 
    Height="166px" 
    onrowdatabound="GridView1_RowDataBound" >
    <Columns>
        <asp:BoundField DataField="EstadoFenologicoID" Visible="False" 
            HeaderText="EstadoFenologicoID" />
        <asp:BoundField DataField="CultivoEstadoFenologicoID" Visible="False" 
            HeaderText="CultivoEstadoFenologicoID" />
        <asp:BoundField DataField="NombreAbreviado" HeaderText="Estado Fenologico" />
        <asp:TemplateField HeaderText="Duracion (dias)">
            <ItemTemplate>
                <asp:TextBox ID="Duracion" style="text-align:right;" runat="server" Text = <%#Eval("Duracion")%> 
                    Enabled="False" AutoPostBack="False" Height="22px" Width="70px" ></asp:TextBox>
            </ItemTemplate>
            <ControlStyle Width="80px" />
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        No Existen ESTADOS FENOLOGICOS definidos para el CULTIVO seleccionado. Contacte al 
        administrador de la Aplicacion para realizar el registro de los Estados Fenologicos, la cual se 
        realiza en la seccion:<br />
        [TERRITORIO]\[Estados Fenologicos] en el Sitio Web de la Aplicacion SPATS : <a href="http://spats.pe.iica.int/Modulos-en-Implementacion.aspx" target="_blank"> Ir al Sitio Web</a>
    </EmptyDataTemplate>
</asp:GridView>



