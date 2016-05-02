<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectorCultivo.ascx.cs" Inherits="CMSEjemplosFer_SelectorCultivo" %>
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
<asp:DropDownList ID="dpdCultivo" runat="server" 
    onselectedindexchanged="dpdCultivo_SelectedIndexChanged" Width="188px" 
    AutoPostBack="True">
</asp:DropDownList>




