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

public partial class CMSWebParts_FormatosDigitales_FDFiltroTramites : CMSAbstractWebPart
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

    protected int UserIDSMI
    {
        get
        {
            DataSet FDuserSMI = new DataSet();
            QueryDataParameters parameters1 = new QueryDataParameters();
            parameters1.Add("@UserID", this.UserID);
            FDuserSMI = ConnectionHelper.ExecuteQuery("FD.FDIntegracionSMI.GetUserIDSMI", parameters1);
            if (!DataHelper.DataSourceIsEmpty(FDuserSMI))
            {
                foreach (DataRow user in FDuserSMI.Tables[0].Rows)
                {
                    
                    return ValidationHelper.GetInteger( user["IdUsuario"],0);
                    
                }
            }
            return 0;
        }
        set
        {
            ;
        }
    }

    protected void GetProyectoSMI ()
    {
            DataSet Proyectos = new DataSet();
            QueryDataParameters parameters1 = new QueryDataParameters();
            parameters1.Add("@IdUsuario", this.UserIDSMI);
            Proyectos = ConnectionHelper.ExecuteQuery("FD.FDIntegracionSMI.GetProyectoSMIbyUser", parameters1);
           
            ListItem todos = new ListItem();
            todos.Value = "0";
            todos.Text = "Todos";
            this.DdlProyectos.Items.Add(todos);         
    
        if (!DataHelper.DataSourceIsEmpty(Proyectos))
            {
                           

                foreach (DataRow p in Proyectos.Tables[0].Rows)
                {
                    ListItem proyecto = new ListItem();
                    proyecto.Value = ValidationHelper.GetString(p["Idproyecto"].ToString(), "");
                    proyecto.Text = ValidationHelper.GetString(p["nombre"].ToString(), "");
                    this.DdlProyectos.Items.Add(proyecto);                    
                }
            }
 }


    protected void GetListadoTipoFormato()
    {
        DataSet Proyectos = new DataSet();
        QueryDataParameters parameters1 = new QueryDataParameters();
        parameters1.Add("@IdUsuario", this.UserIDSMI);
        Proyectos = ConnectionHelper.ExecuteQuery("FD.FormatoDigital.ListadoTipoFormato", parameters1);

        ListItem todos = new ListItem();
        todos.Value = "0";
        todos.Text = "Todos";
        this.DdlProyectos.Items.Add(todos);

        if (!DataHelper.DataSourceIsEmpty(Proyectos))
        {


            foreach (DataRow p in Proyectos.Tables[0].Rows)
            {
                ListItem proyecto = new ListItem();
                proyecto.Value = ValidationHelper.GetString(p["ItemId"].ToString(), "");
                proyecto.Text = ValidationHelper.GetString(p["Nombre"].ToString(), "");
                this.DdlProyectos.Items.Add(proyecto);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            GetProyectoSMI();
        } 
    }
}
