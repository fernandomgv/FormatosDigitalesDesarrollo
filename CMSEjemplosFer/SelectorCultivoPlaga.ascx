<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectorCultivoPlaga.ascx.cs" Inherits="CMSEjemplosFer_SelectorCultivoPlaga" %>
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
    Width="332px" DataKeyNames="CultivoID,PlagaID,ItemID" 
    Height="166px" 
    onrowdatabound="GridView1_RowDataBound" onprerender="GridView1_PreRender">
    <Columns>
        <asp:BoundField DataField="CultivoID" Visible="False" />
        <asp:TemplateField HeaderText="Plagas">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" 
                    Checked= <%# inttobol( Eval("Checked"))%> Text = <%#Eval("NombreComun")%> 
                    AutoPostBack="False" Width="300px"    />
            </ItemTemplate>
            <ControlStyle Width="300px" />
            <ItemStyle Width="300px" />
        </asp:TemplateField>
        <asp:BoundField DataField="PlagaID" Visible="False" />
        <asp:BoundField DataField="ItemID" Visible="False" />
    </Columns>
    <EmptyDataTemplate>
        No Existen PLAGAS definidos para el TERRITORIO seleccionado. Contacte al 
        administrador de la Aplicacion para realizar el registro de Plagas, la cual se 
        realiza en la seccion:<br />
        [TERRITORIO]\[CULTIVOS] en el Sitio Web de la Aplicacion SPATS : <a href="http://spats.pe.iica.int/Modulos-en-Implementacion.aspx" target="_blank"> Ir al Sitio Web</a>
    </EmptyDataTemplate>
</asp:GridView>



