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
                    string nombrep = ValidationHelper.GetString(p["Nombre"].ToString(), "");
                    proyecto.Text = (nombrep.Length > 100) ? nombrep.Substring(0, 99) + "..." : nombrep;

                    this.DdlProyectos.Items.Add(proyecto);                    
                }
            }
 }


    protected void GetListadoTipoFormato()
    {
        DataSet Proyectos = new DataSet();
        Proyectos = ConnectionHelper.ExecuteQuery("FD.FormatoDigital.ListadoTipoFormato", null);

        ListItem todos = new ListItem();
        todos.Value = "0";
        todos.Text = "Todos";
        this.DdlTramites.Items.Add(todos);

        if (!DataHelper.DataSourceIsEmpty(Proyectos))
        {


            foreach (DataRow p in Proyectos.Tables[0].Rows)
            {
                ListItem proyecto = new ListItem();
                proyecto.Value = ValidationHelper.GetString(p["ItemId"].ToString(), "");
                proyecto.Text = ValidationHelper.GetString(p["nombre"].ToString(), "");
                this.DdlTramites.Items.Add(proyecto);
            }
        }
    }


    protected void GetListadoEstadoPorFormato(string idFormatoDigitalSeleccionado)
    {
        DataSet Proyectos = new DataSet();
        QueryDataParameters parameters1 = new QueryDataParameters();
        parameters1.Add("@IdFormatoDigitalSeleccionado", idFormatoDigitalSeleccionado);
        Proyectos = ConnectionHelper.ExecuteQuery("FD.FD_EstadoFormatoDigital.GetListadoEstadoPorFormato", parameters1);

        ListItem todos = new ListItem();
        todos.Value = "0";
        todos.Text = "Todos";
        this.DdlEstados.Items.Add(todos);

        if (!DataHelper.DataSourceIsEmpty(Proyectos))
        {
            foreach (DataRow p in Proyectos.Tables[0].Rows)
            {
                ListItem proyecto = new ListItem();
                proyecto.Value = ValidationHelper.GetString(p["ItemId"].ToString(), "");
                proyecto.Text = ValidationHelper.GetString(p["NombreEstado"].ToString(), "");
                this.DdlEstados.Items.Add(proyecto);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string idp = CMS.GlobalHelper.URLHelper.GetQueryValue(CMS.GlobalHelper.URLHelper.CurrentURL, "idp");
        string idt = CMS.GlobalHelper.URLHelper.GetQueryValue(CMS.GlobalHelper.URLHelper.CurrentURL, "idt");
        string  ide = CMS.GlobalHelper.URLHelper.GetQueryValue(CMS.GlobalHelper.URLHelper.CurrentURL, "ide");
        string fi = CMS.GlobalHelper.URLHelper.GetQueryValue(CMS.GlobalHelper.URLHelper.CurrentURL, "fi");
        string ff = CMS.GlobalHelper.URLHelper.GetQueryValue(CMS.GlobalHelper.URLHelper.CurrentURL, "ff");

        if (!string.IsNullOrEmpty(idp))
        {
            this.lblMensaje.Text = "Mostrando resultados filtrados para [" + idp + "]";
        }
        else { this.lblMensaje.Text = ""; }

        

        if (!this.Page.IsPostBack)
        {
            GetProyectoSMI();
            GetListadoTipoFormato();
        } 
    }


    protected void DdlTramites_SelectedIndexChanged(object sender, EventArgs e)
    {

        DdlEstados.Items.Clear();
        if (DdlTramites.SelectedValue != "0")
        {
            DdlEstados.Enabled = true;
            GetListadoEstadoPorFormato(DdlTramites.SelectedValue);
        }
        else
        {
            DdlEstados.Enabled = false;
        }
        
    }

    protected void BtnFiltrar_Click(object sender, EventArgs e)
    {
        string url = "";
        string IDP = "";
        string IDT = "";
        string IDE = "";
        string FI = "";
        string FF = "";
        url = CMS.GlobalHelper.URLHelper.CurrentURL;
        url = CMS.GlobalHelper.URLHelper.RemoveQuery(url);

        if (!string.IsNullOrEmpty(DdlProyectos.SelectedValue))
        {
            if (DdlProyectos.SelectedValue != "0")
            {
                url = CMS.GlobalHelper.URLHelper.AddParameterToUrl(url, "IDP", DdlProyectos.SelectedValue);
            }
        }
            
        if (!string.IsNullOrEmpty(DdlTramites.SelectedValue))
        {
            if (DdlTramites.SelectedValue != "0")
             {
                 url= CMS.GlobalHelper.URLHelper.AddParameterToUrl(url, "IDT", DdlTramites.SelectedValue);
            }
        }
        if (!string.IsNullOrEmpty(DdlEstados.SelectedValue))
        {
            if (DdlEstados.SelectedValue != "0")
            {
                url = CMS.GlobalHelper.URLHelper.AddParameterToUrl(url, "IDE", DdlEstados.SelectedValue);
            }
        }

        if (!string.IsNullOrEmpty(TxtFechaIni.Text))
        {
             url = CMS.GlobalHelper.URLHelper.AddParameterToUrl(url, "FI", TxtFechaIni.Text);          
        }

        if (!string.IsNullOrEmpty(TxtFechaFin.Text))
        {
            url = CMS.GlobalHelper.URLHelper.AddParameterToUrl(url, "FF", TxtFechaFin.Text);           
        }
        
        this.Page.Response.Redirect(url);



        

            
    }
}
