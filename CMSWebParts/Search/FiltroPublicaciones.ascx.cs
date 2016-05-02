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

using CMS.CMSHelper;
using CMS.GlobalHelper;
using CMS.PortalControls;
using CMS.EventLog;
using CMS.SiteProvider;

public partial class CMSWebParts_Search_FiltroPublicaciones : CMSAbstractWebPart
{
    protected void btnbuscaravanzado_Click(object sender, EventArgs e)
    {
       /* this.pnlavanzada.Visible = true;*/
        
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        string url = "";
        url = CMS.GlobalHelper.URLHelper.CurrentURL;
        url = CMS.GlobalHelper.URLHelper.RemoveQuery(url);
        if (this.txtpalabraclave.Text.Trim() != "")
        {            
            url=url + "?key=" + this.txtpalabraclave.Text.Trim();
        }
        this.Page.Response.Redirect(url );

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = CMS.GlobalHelper.URLHelper.GetQueryValue(CMS.GlobalHelper.URLHelper.CurrentURL,"key");
        if (!string.IsNullOrEmpty(key))
        {
            this.Lblmsj.Text = "Mostrando resultados filtrados para [" + key + "]";
        }
        else { this.Lblmsj.Text = ""; }
    }
}
