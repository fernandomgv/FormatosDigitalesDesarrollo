<%@ Page Language="C#" Theme="Default" AutoEventWireup="true"
    Inherits="CMSFormControls_LiveSelectors_InsertYouTubeVideo_Footer" EnableEventValidation="false"
    MasterPageFile="~/CMSMasterPages/LiveSite/EmptyPage.master" Title="Insert youtube video - footer" CodeFile="Footer.aspx.cs" %>

<%@ Register Src="~/CMSModules/Content/Controls/Dialogs/General/DialogFooter.ascx"
    TagName="Footer" TagPrefix="cms" %>
<asp:Content ID="cntBody" ContentPlaceHolderID="plcContent" runat="Server">
    <div class="LiveSiteDialog">
        <div class="PageFooterLine">
            <cms:Footer ID="footerElem" runat="server" IsYouTubeDialog="true" />
        </div>
    </div>
</asp:Content>
