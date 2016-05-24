using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class CMSWebParts_FormatosDigitales_FDBotoneraOpciones : CMSAbstractWebPart
{
    protected int UserID
    {
        get
        {

            return CMSContext.CurrentUser.UserID;
        }
        set
        {
            ;
        }
    }

    private void GetOpciones()
    {
       // GeneralConnection cn = ConnectionHelper.GetConnection();
        DataSet FDOpciones = new DataSet();
        QueryDataParameters parameters = new QueryDataParameters();
        parameters.Add("@UserID", this.UserID);
        FDOpciones = ConnectionHelper.ExecuteQuery("FD.FormatoDigital.GetBotoneraFD", parameters);
        if (!DataHelper.DataSourceIsEmpty(FDOpciones))
        {
            // Loop through all documents
            foreach (DataRow Opcion in FDOpciones.Tables[0].Rows)
            {
                ListItem Itemopcion = new ListItem();
                Itemopcion.Text=    Opcion["ElementDisplayName"].ToString();
                
                Itemopcion.Attributes["title"] = Opcion["ElementCaption"].ToString();
                Itemopcion.Enabled = true;
                if (Opcion["habilitado"].ToString() == "0")
                {
                   // Itemopcion.Enabled = false;
                    Itemopcion.Attributes["title"] += " [Su usuario no cuenta con acceso]";
                    Itemopcion.Attributes["class"] = "disable";
                    Itemopcion.Value = "#";
                }
                else
                {
                    Itemopcion.Value = Opcion["ElementTargetURL"].ToString();
                }

                Itemopcion.Enabled = Opcion["habilitado"].ToString() == "1" ? true : false;
               
                this.FDOpciones.Items.Add(Itemopcion);
            }
        }

      
        
    }

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            GetOpciones();
        } 
    }
}
