<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FDGrillaTramite.ascx.cs" Inherits="CMSWebParts_FormatosDigitales_FDGrillaTramite" %>
<%@ Register assembly="Trirand.Web" namespace="Trirand.Web.UI.WebControls" tagprefix="cc1" %>
<%@ Register Assembly="Trirand.Web" TagPrefix="trirand" Namespace="Trirand.Web.UI.WebControls" %>



<%--<cc1:JQGrid ID="JQGrid1" runat="server" DataSourceID="SqlDataSource1" 
    Responsive="True" >
    <Columns>
        <cc1:JQGridColumn DataField="UserID" PrimaryKey="True" >
        </cc1:JQGridColumn>
        <cc1:JQGridColumn DataField="FullName" >
        </cc1:JQGridColumn>
    </Columns>
</cc1:JQGrid>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SPATSConnectionString %>" 
    SelectCommand="SELECT [UserID], [FullName] FROM [CMS_User]">
</asp:SqlDataSource>--%>
<asp:Panel ID="Pnlgrid" runat="server" HorizontalAlign="Center" Width="98%">
<trirand:JQGrid runat="server" ID="JQGrid1" Responsive="True"
            Width="100%" Height="260px" onsearching="JQGrid1_Searching" >
<PivotSettings ColTotals="False" FrozenStaticCols="False" GroupSummary="True" GroupSummaryPosition="Header" RowTotals="False" RowTotalsText="Total"></PivotSettings>

<SearchToolBarSettings SearchToolBarAction="SearchOnEnter"></SearchToolBarSettings>

<ExportSettings ExportDataRange="All"></ExportSettings>

<SortSettings InitialSortDirection="Asc" SortAction="ClickOnHeader" SortIconsPosition="Vertical"></SortSettings>
        <Columns>
        <trirand:JQGridColumn DataField="Accion" Width="100">
                    <Formatter>
                        <trirand:CustomFormatter FormatFunction="formatImage" UnFormatFunction="unformatImage" />
                    </Formatter>
                </trirand:JQGridColumn>  
                
            <trirand:JQGridColumn 
                DataField="OrderID" 
                Searchable="true"
                SearchToolBarOperation="IsEqualTo"
                DataType="Int"
                HeaderText="Order ID" 
                PrimaryKey="True" 
                Width="50" />
            <trirand:JQGridColumn
                DataField="CustomerID" 
                DataType="String"
                SearchType="DropDown" 
                SearchControlID="DropDownList1"
                SearchToolBarOperation="IsEqualTo"  />
            <trirand:JQGridColumn 
                DataField="OrderDate" 
                Searchable="true" 
                SearchType="DatePicker"
                SearchControlID="DatePicker1"              
                SearchToolBarOperation="IsEqualTo"
                DataType="DateTime"
                ShowToolTip="false"
                DataFormatString="{0:MMM/d/yyyy}"/>
             <trirand:JQGridColumn 
                DataField="Freight"  
                SearchType="DropDown"
                DataType="Decimal"
                SearchValues="[All]:[All];10:> 10;20:> 20;30:> 30;50:> 50" 
                SearchToolBarOperation="IsGreaterThan" />    
            <trirand:JQGridColumn 
                Searchable="true"
                DataType="String"
                SearchType="AutoComplete"
                SearchControlID="AutoComplete1"
                SearchToolBarOperation="Contains"
                DataField="ShipName" 
                Width="200" />                      
        </Columns> 
                                   
        <ToolBarSettings ShowRefreshButton="True"  ShowSearchToolBar="true" ShowSearchButton="True" ToolBarPosition="TopAndBottom">                
            <CustomButtons>
                <trirand:JQGridToolBarButton
                    Text = "Send Mail"
                    ToolTip = "Send Mail"
                    ButtonIcon = "ui-icon-mail-closed"
                    Position = "Last"
                    OnClick = "customButtonClicked"
                />
                <trirand:JQGridToolBarButton
                   Text = ""
                   ToolTip = "Send Mail"
                   ButtonIcon = "ui-icon-pencil"
                   Position = "Last"
                   OnClick = "customButtonClicked"
                />
            </CustomButtons>
        </ToolBarSettings>          

<HierarchySettings HierarchyMode="None"></HierarchySettings>
    </trirand:JQGrid>
    
    <%-- This control will be used as a DatePicker search UI control in the grid toolbar--%>
    <%-- You can use JQDatePicker as a standalone control outside of a grid by setting DisplayMode="Standalone" --%>
    <trirand:JQDatePicker 
        DisplayMode="ControlEditor"
        runat="server" 
        ID="DatePicker1" 
        DateFormat="M/d/yyyy"
        MinDate="2010-01-01" 
        MaxDate="2020-01-01" 
        ShowOn="Focus" />  
        
    <%-- This control will be used as an AutoComplete search UI control in the grid toolbar--%>
    <%-- You can use JQAutoComplete as a standalone control outside of a grid by setting DisplayMode="Standalone" --%>
    <trirand:JQAutoComplete
        DisplayMode="ControlEditor"    
        DataTextField="ShipName"
        DataValueField="ShipName"
        DropDownWidth="200"
        Height="200"
        LoadingImageUrl="loading.gif"
        Filter="StartsWith"
        DataSourceID="SqlDataSource1"
        runat="server"
        ID="AutoComplete1"
    />
    
    <%--This control will be used as a DropDown search UI control in the grid toolbar--%>
    <asp:DropDownList 
        runat="server" 
        ID="DropDownList1" 
        DataSourceID="SqlDataSource2"
        DataTextField="CustomerID"
        DataValueField="CustomerID"
        AppendDataBoundItems="true">
        <asp:ListItem Text="[All]" Value="[All]"></asp:ListItem>
    </asp:DropDownList>
    
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" 
        ConnectionString="<%$ ConnectionStrings:CMSConnectionString %>"        
        SelectCommand="SELECT DISTINCT FullName as ShipName   FROM [cms_user]">
    </asp:SqlDataSource>        
    
     <asp:SqlDataSource runat="server" ID="SqlDataSource2" 
        ConnectionString="<%$ ConnectionStrings:CMSConnectionString %>"                 
        SelectCommand="SELECT DISTINCT UserName as CustomerID FROM [cms_user]">
    </asp:SqlDataSource> 
    
    <br />
    
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CMSConnectionString %>" SelectCommand="select 
UserID  OrderID,
UserName  CustomerID,
isnull(UserCreated,getdate())  OrderDate,
10.0  Freight,
FullName  ShipName
from cms_user"></asp:SqlDataSource>
</asp:Panel>



<script type="text/javascript">         
    
        function customButtonClicked()
        {
            alert("You have clicked a custom button.");
        }       
   // The FormatFunction for CustomFormatter gets three parameters           
           // cellValue - the original value of the cell
           // options - as set of options, e.g
           //   options.rowId - the primary key of the row
           //   options.colModel - colModel of the column
           // rowData - array of cell data for the row, so you can access other cells in the row if needed
           
           function formatImage(cellValue, options, rowObject) {
               //var imageHtml = "<img src='images/" + cellValue + "' originalValue='" + cellValue + "' />";
             //var imageHtml =  "<a href=\"/FormatosDigitales/Modulos-en-Implementacion/Lamas/Administrar-SPATS.aspx\" class=\"CMSBreadCrumbsLink\">Editar </a>" + "<a href=\"/FormatosDigitales/Modulos-en-Implementacion/Lamas/Administrar-SPATS.aspx\" class=\"CMSBreadCrumbsLink\">Cotizar</a>";
             
             var imageHtml =" <a href=\"/FormatosDigitales/Modulos-en-Implementacion/Lamas/Administrar-SPATS.aspx\" class=\"CMSBreadCrumbsLink\"><div class=\"ui-pg-div ui-pg-button ui-corner-all\"><span class=\"ui-icon ui-icon-mail-closed\"></span>Cotizar</div></a>";
					
					
               return imageHtml;
               
           }

           // The FormatFunction for CustomFormatter gets three parameters           
           // cellValue - the original value of the cell
           // options - as set of options, e.g
           //   options.rowId - the primary key of the row
           //   options.colModel - colModel of the column
           // cellObject - the HMTL of the cell (td) holding the actual value
           function unformatImage(cellValue, options, cellObject) {
               return $(cellObject.html()).attr("originalValue");
           }
    </script>    

