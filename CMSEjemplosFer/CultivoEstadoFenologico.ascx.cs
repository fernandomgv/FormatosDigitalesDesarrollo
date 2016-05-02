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

using CMS.FormControls;
using CMS.GlobalHelper;
using CMS.SiteProvider;
using CMS.TreeEngine;
using CMS.CMSHelper;


using CMS.PortalControls;
using CMS.WebAnalytics;


using CMS.DatabaseHelper;
using CMS.DataEngine;
using CMS.SettingsProvider;

using CMS.FormEngine;

using AjaxControlToolkit;


public partial class CMSEjemplosFer_CultivoEstadoFenologico : FormEngineUserControl
{
    private object mFormControlParameter = null;

    private string CultivoUser_IDS;
    private Int32 mUserID;
    private Int32 mTerritorioID; //hace referencia al nodoID del territorio
    private Int32 mCultivoId;
    private DataTable mtbEstadoFenologico;


    protected DataTable EstadoFenologico
    {
        get
        {
            if (CMS.GlobalHelper.SessionHelper.GetValue("EstadoFenologico") == null)
            {
                mtbEstadoFenologico = this.NewtbEstadoFenologico();
            }
            else
            {
                mtbEstadoFenologico = (DataTable)CMS.GlobalHelper.SessionHelper.GetValue("EstadoFenologico");
            }
            return mtbEstadoFenologico;
        }
        set
        {
            mtbEstadoFenologico = value;
            CMS.GlobalHelper.SessionHelper.SetValue("EstadoFenologico", this.mtbEstadoFenologico);

        }
    }
    /// <summary>
    /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
    /// </summary>
    /// 
    protected int TerritorioID
    {
        get
        {
            if ((this.Form.GetDataValue("TerritorioId") == null))
            {
                //if (this.IsLiveSite)
                //{
                    if (!(this.Form.FindControl("TerritorioId").FindControl("drpTerritorio") == null))
                    {
                        this.mTerritorioID = ValidationHelper.GetInteger( ((DropDownList)(this.Form.FindControl("TerritorioId").FindControl("drpTerritorio"))).SelectedValue,0);
                    }
                    else
                    {
                        this.mTerritorioID = 0;
                    }
                //}
                   
                
            }
            else
            {
                this.mTerritorioID = ValidationHelper.GetInteger(this.Form.GetDataValue("TerritorioId").ToString(),0);
            }
            return this.mTerritorioID;
        }
        set
        {
            this.mTerritorioID = value;
        }
    }
    protected int UserID
    {
        get 
        {
            if (string.IsNullOrEmpty(this.Form.GetDataValue("UserId").ToString()))
            {
                this.mUserID = 0;
            }
            else
            {
                this.mUserID = System.Int32.Parse(this.Form.GetDataValue("UserId").ToString());
            }
            return mUserID; 
        }
        set {
            this.mUserID = value;
        }
    }
    protected int CultivoID
    {
        get
        {
            if (string.IsNullOrEmpty(this.Form.GetDataValue("ItemID").ToString()))
            {
                this.mCultivoId = 0;
            }
            else
            {
                this.mCultivoId = ValidationHelper.GetInteger(this.Form.GetDataValue("ItemID").ToString(), 0);
            }
            return mCultivoId;
        }
        set
        {
            this.mCultivoId = value;
        }
    }
    public override Object Value
    {
        get
        {
            CultivoUser_IDS = "1|2";
            return CultivoUser_IDS;

        }
        set
        {
            CultivoUser_IDS = System.Convert.ToString(value);
        }
    }

    /// <summary>
    /// Property used to access the Width parameter of the form control.
    /// </summary>
    public int SelectorWidth
    {
        get
        {
            return ValidationHelper.GetInteger(GetValue("SelectorWidth"), 0);
        }
        set
        {
            SetValue("SelectorWidth", value);
        }
    }

    /// <summary>
    /// Returns an array of values of any other fields returned by the control.
    /// </summary>
    /// <returns>It returns an array where the first dimension is the attribute name and the second is its value.</returns>
    public override object[,] GetOtherValues()
    {
        object[,] array = new object[1, 2];
        array[0, 0] = "ProductColor";
       // array[0, 1] = drpTerritorio.SelectedItem.Text;
        return array;
    }

    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>
    public override bool IsValid()
    {
        this.savecultivos();
        bool valid = true;
        bool validall = true;
        this.ValidationError = "";
        string csCrLf = "\r\n";
        string csKeyTab = "\t";
        //ejecutamos la logica para la persistencia de los datos
        foreach (DataRow dr in this.mtbEstadoFenologico.Rows)
        {
            //tenmos un ItemID            
            int EstadoFenologicoID = ValidationHelper.GetInteger(dr[0], 0);
            int CultivoEstadoFenologicoID = ValidationHelper.GetInteger(dr[1], 0);
            string NombreAbreviado = ValidationHelper.GetString(dr[2], "");
            int Duracion = ValidationHelper.GetInteger(dr[3], 0);
            //revisamos unicamente los valores de los cultivos seleccionados y de aquellos campos considerados mandatorios
               if (Duracion <= 0)
                {
                    valid = false;
                    this.ValidationError += csKeyTab + "El valor proporcionado como Duracion no es correcto" + csCrLf;
                }
           
            if (!valid)
            {
                validall = false;
                this.ValidationError = "[" + NombreAbreviado + "] : " + csCrLf + this.ValidationError;
            }
            valid=true;
        }

            if (validall)
            {
                return true;
            }
            else
            {
                // Set form control validation error message.
                //this.ValidationError = "Pasamos por la verificacion";
                return false;
                
            }
        }
    

    /// <summary>
    /// Sets up the internal DropDownList control.
    /// </summary>
    protected void EnsureItems(int CultivoID)
    {
        GeneralConnection cn = ConnectionHelper.GetConnection();
        //dataset con los usuarios a notificar
        DataSet CultivoEstadoFenologico = new DataSet();

        QueryDataParameters parameters = new QueryDataParameters();

        parameters.Add("@CultivoID", CultivoID);

        CultivoEstadoFenologico = ConnectionHelper.ExecuteQuery("customtable.SPATS_Cultivo_Estado_Fenologico.EstadoFenologicobyCultivo", parameters);

        this.GridView1.DataSource = CultivoEstadoFenologico;
        this.DataBind();
    }
    protected void EnsureItems()
    {
        EnsureItems(this.CultivoID);
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
        //this.Form.OnAfterSave += new EventHandler(Form_OnAfterSave);
        ((CMS.FormControls.CustomTableForm)this.Form.Parent).OnAfterSave += new EventHandler(Form_OnAfterSave);

       
    }

    private DataTable NewtbEstadoFenologico()
    {
        var tb = new DataTable();
        tb.Columns.Add("EstadoFenologicoID", Type.GetType("System.Int32"));
        tb.Columns.Add("CultivoEstadoFenologicoID", Type.GetType("System.Int32"));
        tb.Columns.Add("NombreAbreviado", Type.GetType("System.String"));
        tb.Columns.Add("Duracion", Type.GetType("System.Int32"));     
        return tb;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            EnsureItems();

            this.EstadoFenologico = this.NewtbEstadoFenologico();
        }
    }
    private void savecultivos()
    {                //recuperamos el estado actual de la grilla y la guardamos
        this.mtbEstadoFenologico = this.NewtbEstadoFenologico();
        this.mtbEstadoFenologico.Rows.Clear();
        foreach (GridViewRow dr in GridView1.Rows)
        {
                var datar = this.mtbEstadoFenologico.NewRow();
                datar[0] = this.GridView1.DataKeys[dr.RowIndex].Values[0];//dr.Cells[0].Text;
                datar[1] = this.GridView1.DataKeys[dr.RowIndex].Values[1]; //int.Parse(dr.Cells[2].Text);
                datar[2] = "";             
                TextBox TextDuracion = (TextBox)dr.FindControl("Duracion");
                if( !string.IsNullOrEmpty(TextDuracion.Text))
                {
                    datar[3] = ValidationHelper.GetInteger(TextDuracion.Text,0);
                }
                this.mtbEstadoFenologico.Rows.Add(datar);
            
        }
        CMS.GlobalHelper.SessionHelper.SetValue("EstadoFenologico", this.mtbEstadoFenologico);

}
    void Form_OnAfterSave(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        //intentariamos guardar la relacion detalle
        //Se comprueba que el evento es llamado desde el formulario
        //padre tras realizar la insersion de un usuario
        if (this.CultivoID>0)
        {
            //Poblamos a una tabla temporal los datos contenidos en la interface
            this.savecultivos();
            //ejecutamos la logica para la persistencia de los datos
            foreach (DataRow dr in this.mtbEstadoFenologico.Rows)
            {
                //tenmos un ItemID            
                int EstadoFenologicoID = ValidationHelper.GetInteger(dr[0], 0);
                int CultivoEstadoFenologicoID = ValidationHelper.GetInteger(dr[1], 0);
                string NombreAbreviado = ValidationHelper.GetString(dr[2], "");
                int Duracion = ValidationHelper.GetInteger(dr[3], 0);

                if (CultivoEstadoFenologicoID > 0)
                {
                    SimpleDataClass cultivoestadofenologico = new SimpleDataClass("customtable.SPATS_Cultivo_Estado_Fenologico", CultivoEstadoFenologicoID);
                    if (!cultivoestadofenologico.IsEmpty())
                     {
                            cultivoestadofenologico.SetValue("Duracion", Duracion);
                            cultivoestadofenologico.Update();
                        }
                    }
                else
                {//procedemos a insertar una nueva fila
                    string className = "customtable.SPATS_Cultivo_Estado_Fenologico"; // cultivouser.ClassName;
                    CustomTableItem cultivoestadofenologico = null;
                        CustomTableItemProvider provider = new CustomTableItemProvider(CMSContext.CurrentUser);
                        cultivoestadofenologico = new CustomTableItem(className, provider);
                        cultivoestadofenologico.SetValue("CultivoID", CultivoID);
                        cultivoestadofenologico.SetValue("EstadoFenologicoID", EstadoFenologicoID);
                        cultivoestadofenologico.SetValue("Duracion", Duracion);

                        if (cultivoestadofenologico.OrderEnabled)
                        {
                            cultivoestadofenologico.ItemOrder = provider.GetLastItemOrder(className) + 1;
                        }
                        cultivoestadofenologico.Insert();

                    
                }
            }
            
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
                TextBox TextEdad = (TextBox)e.Row.FindControl("Duracion");
                TextEdad.Enabled = true;
                TextEdad.Attributes["onchange"] = "javascript: Changed( this,0 );";                            
        }

    }
  
    /// <summary>
    /// Helper parameter - ID of selected item of parent control 
    /// </summary>
    public override object FormControlParameter
    {
        get
        {
            return mFormControlParameter;
        }
        set
        {
            mFormControlParameter = value;

            if (mFormControlParameter != null)
            {
                string cad ="";
                cad=ValidationHelper.GetString(mFormControlParameter, "");
                EnsureItems(ValidationHelper.GetInteger(cad,0));
               
                }
                else
                {
                ;
                }
            }
        }
}
