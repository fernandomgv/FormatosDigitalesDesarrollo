<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/CMSWebParts/Custom/formdefinition.ascx.cs" Inherits="CMSWebParts_Custom_formdefinition" %>
<table>
<tr>
    <td colspan="3">
        <asp:Label ID="lblInfo" runat="server" Visible="false" EnableViewState="false" />
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblClassName" runat="server" Text="Class name:" EnableViewState="false" />
    </td>
    <td>    
        <asp:TextBox runat="server" ID="txtClassname" />
        <asp:Button runat="server" ID="btnGetClass" Text="Get class Info" onclick="btnGetClass_Click" />
        <asp:Button runat="server" ID="btnUpdateClass" Text="Update class Info" onclick="btnUpdateClass_Click" />
        <asp:Button runat="server" ID="btnUnlockSystemTable" Text="Unlock table" onclick="btnUnlockSystemTable_Click" />
        <asp:Button runat="server" ID="btnLockSystemTable" Text="Lock table" onclick="btnLockSystemTable_Click" />
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblAddressFieldName" runat="server" Text="Custom address field name:" EnableViewState="false" />
    </td>
    <td> 
        <asp:TextBox runat="server" ID="txtAddressFieldName" />
        <asp:Button runat="server" ID="btnAddressFieldName" Text="Get field type" onclick="btnAddressFieldName_Click"/>
        <asp:Label runat="server" ID="lblFieldType" />
    </td>
</tr>
<tr>
    <td colspan="2">
        <cms:QueryRepeater  DataBindByDefault="false" runat="server" Visible="false" HideControlForZeroRows="false" ZeroRowsText="No data found!" ID="repClass"
        TransformationName="cms.root.class" QueryName="cms.root.class" />
    </td>
</tr>
</table>
