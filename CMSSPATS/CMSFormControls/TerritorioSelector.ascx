<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TerritorioSelector.ascx.cs" Inherits="CMSSPATS_CMSFormControls_TerritorioSelector" %>
<%@ Register src="~/CMSAdminControls/UI/UniSelector/UniSelector.ascx" tagname="UniSelector" tagprefix="cms" %>

<table >
    <tr>
        <td>
            <asp:DropDownList ID="drpTerritorio" runat="server" 
                onselectedindexchanged="drpTerritorio_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
        &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    </table>
