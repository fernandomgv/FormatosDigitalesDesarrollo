using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using CMS.PortalControls;
using CMS.GlobalHelper;
using CMS.SiteProvider;
using CMS.DatabaseHelper;
using CMS.DataEngine;
using CMS.SettingsProvider;
using CMS.FormEngine;
using CMS.CMSHelper;

public partial class CMSWebParts_FormatosDigitales_FDGrillaTramite : CMSAbstractWebPart
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (CMS.CMSHelper.CMSContext.CurrentUser.IsInRole("LamasSupervisorAlertas", CMS.CMSHelper.CMSContext.CurrentSiteName))

        //this.SqlDataSource3.DataBind();
        //this.JQGrid1.DataSource = this.SqlDataSource3;
        //this.JQGrid1.DataBind();
        this.GetData();

        //if (CMS.CMSHelper.CMSContext.CurrentUser.IsInRole((string)this.GetValue("RolesEscritura"), CMS.CMSHelper.CMSContext.CurrentSiteName))
        //{
        //    this.BtnIngresar.Enabled = true;
        //}
        //else
        //{
        //    this.BtnIngresar.Enabled = false;
        //}
    }
    protected void JQGrid1_Searching(object sender, Trirand.Web.UI.WebControls.JQGridSearchEventArgs e)
    {
        if (e.SearchString == "[All]")
            e.Cancel = true;
    }


   

    private void GetData()
    {
        GeneralConnection cn = ConnectionHelper.GetConnection();
        //dataset con los usuarios a notificar
        DataSet CultivoByUser = new DataSet();
        QueryDataParameters parameters = new QueryDataParameters();

        //parameters.Add("@TerritorioID", this.TerritorioID);
        //parameters.Add("@BaseConocimientoID", this.BaseConocimientoID);

        CultivoByUser = ConnectionHelper.ExecuteQuery("FD.FormatoDigital.TestJQGrid", null);

        this.JQGrid1.DataSource = CultivoByUser;
        this.JQGrid1.DataBind();
        ;
    }
}
