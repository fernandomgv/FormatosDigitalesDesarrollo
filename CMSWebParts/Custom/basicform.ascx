<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/CMSWebParts/Custom/basicform.ascx.cs" Inherits="CMSWebParts_Custom_cmsform" %>
<asp:Label runat="server" ID="lblInfo" />
<br />
<div>
    <cms:BasicForm runat="server" ID="form" />
    <br />
</div>
<asp:Panel runat="server" ID="pnlTables" Visible="false" CssClass="EditingFormCategoryTable">
    <div class="EditingFormCategoryRow">
        <asp:Label runat="server" ID="lblClassTable" Text="Class table:" />
    </div>
    <br />
    <cms:QueryDataGrid runat="server" ID="repClass" DataBindByDefault="false"/>
</asp:Panel>
<asp:Panel runat="server" ID="pnlDataRow" Visible="false" CssClass="EditingFormCategoryTable">
    <div class="EditingFormCategoryRow">
        <asp:Label runat="server" ID="lblDataRow" Text="DataRow:"/>
    </div>
    <br />
    <cms:QueryDataGrid runat="server" ID="repDataRow" DataBindByDefault="false"/>
</asp:Panel>

