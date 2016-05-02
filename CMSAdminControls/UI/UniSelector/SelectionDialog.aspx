<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="CMSAdminControls_UI_UniSelector_SelectionDialog" Title="Selection dialog"
    ValidateRequest="false" Theme="default" MasterPageFile="~/CMSMasterPages/UI/Dialogs/ModalDialogPage.master" CodeFile="SelectionDialog.aspx.cs" %>

<%@ Register Src="Controls/SelectionDialog.ascx" TagName="SelectionDialog" TagPrefix="cms" %>
<asp:Content ID="cntContent" ContentPlaceHolderID="plcContent" runat="Server">
    <cms:SelectionDialog runat="server" ID="selectionDialog" IsLiveSite="false" />
</asp:Content>
<asp:Content ID="cntFooter" ContentPlaceHolderID="plcFooter" runat="server">
    <div class="FloatRight">
        <cms:LocalizedButton ID="btnOk" runat="server" CssClass="SubmitButton" Visible="false"
            EnableViewState="False" /><cms:LocalizedButton ID="btnCancel" runat="server" CssClass="SubmitButton"
                EnableViewState="False" />
    </div>
</asp:Content>
