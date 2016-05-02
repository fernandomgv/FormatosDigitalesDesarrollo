<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectorCultivoPlagaMes.ascx.cs" Inherits="CMSEjemplosFer_SelectorCultivoPlagaMes" %>
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


<asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4">
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
</asp:CheckBoxList>




