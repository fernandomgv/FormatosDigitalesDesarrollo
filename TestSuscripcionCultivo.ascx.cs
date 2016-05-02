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


public partial class CMSEjemplosFer_TestSuscripcionCultivo : FormEngineUserControl
{
    private object mFormControlParameter = null;

    private string CultivoUser_IDS;
    private Int32 mUserID;
    private Int32 mTerritorioID; //hace referencia al nodoID del territorio
    private DataTable mtbcultivos;


    protected DataTable tbcultivos
    {
        get
        {
            if (CMS.GlobalHelper.SessionHelper.GetValue("CultivosbyUser") == null)
            {
                mtbcultivos = this.Newtbcultivos();
            }
            else
            {
                mtbcultivos = (DataTable)CMS.GlobalHelper.SessionHelper.GetValue("CultivosbyUser");
            }
            return mtbcultivos;
        }
        set
        {
            mtbcultivos = value;
            CMS.GlobalHelper.SessionHelper.SetValue("CultivosbyUser", this.mtbcultivos);

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
                if (this.IsLiveSite)
                {
                    if (!(this.Form.FindControl("TerritorioId").FindControl("drpTerritorio") == null))
                    {
                        this.mTerritorioID = System.Int32.Parse(((DropDownList)(this.Form.FindControl("TerritorioId").FindControl("drpTerritorio"))).SelectedValue);
                    }
                }
                    else{
                    this.mTerritorioID = 0;
                    }
                
            }
            else
            {
                this.mTerritorioID = System.Int32.Parse(this.Form.GetDataValue("TerritorioId").ToString());
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
    
    public override Object Value
    {
        get
        {
            CultivoUser_IDS = "1|2";
            
            //foreach (DataRow dr in ((DataSet)this.GridView1.DataSource).Tables[0].Rows)
            //{
            //    if (CultivoUser_IDS == "")
            //    { CultivoUser_IDS = dr["Checked"].ToString(); }
            //    else
            //    {
            //        CultivoUser_IDS += "|" +dr["Checked"].ToString();
            //    }

            //}           
            
            return CultivoUser_IDS;// drpTerritorio.SelectedValue;

        }
        set
        {
            // Ensure drop down list options
            CultivoUser_IDS = System.Convert.ToString(value);
            //EnsureItems();
            
            //drpTerritorio.SelectedValue = System.Convert.ToString(value);
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
        foreach (DataRow dr in this.mtbcultivos.Rows)
        {
            //tenmos un ItemID            
            int CultivoID = ValidationHelper.GetInteger(dr[0], 0);
            string nombrecomun = ValidationHelper.GetString(dr[1],"");
            int TipoCultivo = ValidationHelper.GetInteger(dr[2], 0);
            int ItemID = ValidationHelper.GetInteger(dr[3], 0);
            int chk = ValidationHelper.GetInteger(dr[4], 0);
            int EdadPlantacion = ValidationHelper.GetInteger(dr[5], 0);
            int MesSiembra = ValidationHelper.GetInteger(dr[6], 0);
            double extension = ValidationHelper.GetDouble(dr[8], 0);
            double latitud = ValidationHelper.GetDouble(dr[9], 0);
            double longitud = ValidationHelper.GetDouble(dr[10], 0);

            //revisamos unicamente los valores de los cultivos seleccionados y de aquellos campos considerados mandatorios

            if (chk == 1)
            {
                if (TipoCultivo == 2) //peremne
                {
                    if (EdadPlantacion < 0)
                    {
                        valid = false;
                        this.ValidationError = csKeyTab + "La Edad de la Plantacion, no es correcta " + csCrLf;
                    }
                }
                else
                {
                    if (MesSiembra <= 0)
                    {
                        valid = false;
                        this.ValidationError += csKeyTab + "Debe seleccionar el Mes en que realiza la siembra" + csCrLf;
                    }
                }
                if (extension <= 0)
                {
                    valid = false;
                    this.ValidationError += csKeyTab + "El valor proporcionado como Extension no es correcto" + csCrLf;
                }
            }
            if (!valid)
            {
                validall = false;
                this.ValidationError = "[" + nombrecomun + "] : " + csCrLf + this.ValidationError;
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
    protected void EnsureItems(int UserID, int TerritorioID)
    {
        GeneralConnection cn = ConnectionHelper.GetConnection();
        //dataset con los usuarios a notificar
        DataSet CultivoByUser = new DataSet();


        QueryDataParameters parameters = new QueryDataParameters();

        parameters.Add("@ID", UserID);
        parameters.Add("@TerritorioID", TerritorioID);

        CultivoByUser = ConnectionHelper.ExecuteQuery("customtable.SPATS_CultivoUser.CultivoByUser", parameters);

        this.GridView1.DataSource = CultivoByUser;
        this.DataBind();
    }
    protected void EnsureItems()
    {
        EnsureItems(this.UserID, this.TerritorioID);
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
        this.Form.OnAfterSave += new EventHandler(Form_OnAfterSave);

       
    }

    private DataTable  Newtbcultivos()
    {
        var tb = new DataTable();
        tb.Columns.Add("CultivoID", Type.GetType("System.Int32"));
        tb.Columns.Add("NombreComun", Type.GetType("System.String"));
        tb.Columns.Add("TipoCultivo", Type.GetType("System.Int32"));
        tb.Columns.Add("ItemID", Type.GetType("System.Int32"));
        tb.Columns.Add("Checked", Type.GetType("System.Int32"));
        tb.Columns.Add("EdadPlantacion", Type.GetType("System.Int32"));
        tb.Columns.Add("Siembra", Type.GetType("System.Int32"));
        tb.Columns.Add("UserID", Type.GetType("System.Int32"));
        tb.Columns.Add("extension", Type.GetType("System.Double"));
        tb.Columns.Add("latitud", Type.GetType("System.Double"));
        tb.Columns.Add("longitud", Type.GetType("System.Double"));
        
        return tb;
    }
    /// <summary>
    /// Handler for the Load event of the control.
    /// </summary>
    /// 
    protected void onunload(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            EnsureItems();

            this.tbcultivos = this.Newtbcultivos();
            this.Unload += new EventHandler(CMSEjemplosFer_TestSuscripcionCultivo_Unload);       
            if ( !this.IsLiveSite )
            {
                if (this.FindControl("smgr") == null)
                {
                    
                    var smgr = new ScriptManager();
                    smgr.ID = "smgr";
                    this.Controls.Add(smgr);
                }
            }

        }
        else
        {
            //pintar grid
        }

        // Ensure drop-down list options
        
        
        
    }
    private void savecultivos()
    {                //recuperamos el estado actual de la grilla y la guardamos
        this.tbcultivos.Rows.Clear();
        foreach (GridViewRow dr in GridView1.Rows)
        {
            if (!(((System.Web.UI.WebControls.WebControl)(((System.Web.UI.WebControls.TableRow)(dr)).Cells[1])).Controls[1] == null))
            {
                var datar = this.tbcultivos.NewRow();
                datar[0] = this.GridView1.DataKeys[dr.RowIndex].Values[0];//dr.Cells[0].Text;
                CheckBox chkb = (CheckBox)dr.FindControl("CheckBox1");

                datar[1] = chkb.Text;
                datar[2] = this.GridView1.DataKeys[dr.RowIndex].Values[1]; //int.Parse(dr.Cells[2].Text);
                if (string.IsNullOrEmpty(this.GridView1.DataKeys[dr.RowIndex].Values[2].ToString()))
                {
                    datar[3] = DBNull.Value;
                }
                else
                {
                    datar[3] = this.GridView1.DataKeys[dr.RowIndex].Values[2];
                }
                if (chkb.Checked)
                {
                    datar[4] = 1;
                }
                else
                {
                    datar[4] = 0;
                }

                datar[7] = this.GridView1.DataKeys[dr.RowIndex].Values[3]; ;
                
                DropDownList DrpDwnMes = (DropDownList)dr.FindControl("DrpDwnMes");
                datar[6] = ValidationHelper.GetInteger(DrpDwnMes.SelectedValue, 0); 

                TextBox TextEdad = (TextBox)dr.FindControl("TextEdad");
                if( !string.IsNullOrEmpty(TextEdad.Text))
                {
                    datar[5] = ValidationHelper.GetInteger(TextEdad.Text,0);
                }
                TextBox Textextension = (TextBox)dr.FindControl("TextExtension");
                datar[8] = ValidationHelper.GetDouble(Textextension.Text, 0);
                TextBox Textlatitud = (TextBox)dr.FindControl("TxtLatitud");
                datar[9] = ValidationHelper.GetDouble(Textlatitud.Text, 0);
                TextBox Textlongitud = (TextBox)dr.FindControl("TxtLongitud");
                datar[10] = ValidationHelper.GetDouble(Textlongitud.Text, 0);

                this.mtbcultivos.Rows.Add(datar);
            }
        }
        CMS.GlobalHelper.SessionHelper.SetValue("CultivosbyUser", this.mtbcultivos);

}
    void CMSEjemplosFer_TestSuscripcionCultivo_Unload(object sender, EventArgs e)
    {
        this.savecultivos();
    }

    void Form_OnAfterSave(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        //intentariamos guardar la relacion detalle
        //Se comprueba que el evento es llamado desde el formulario
        //padre tras realizar la insersion de un usuario
        if (this.UserID>0)
        {
            //Poblamos a una tabla temporal los datos contenidos en la interface
            this.savecultivos();
            //ejecutamos la logica para la persistencia de los datos
            foreach (DataRow dr in this.mtbcultivos.Rows)
            {
                //tenmos un ItemID            
                int CultivoID = ValidationHelper.GetInteger(dr[0], 0);
                int TipoCultivo = ValidationHelper.GetInteger(dr[2], 0);
                int ItemID = ValidationHelper.GetInteger(dr[3], 0);
                int chk = ValidationHelper.GetInteger(dr[4], 0);
                int EdadPlantacion = ValidationHelper.GetInteger(dr[5], 0);
                int MesSiembra = ValidationHelper.GetInteger(dr[6], 0);
                double extension = ValidationHelper.GetDouble(dr[8], 0);
                double latitud = ValidationHelper.GetDouble(dr[9], 0);
                double longitud = ValidationHelper.GetDouble(dr[10], 0);

                if (ItemID > 0)
                {
                    SimpleDataClass cultivouser = new SimpleDataClass("customtable.SPATS_CultivoUser", ItemID);
                    if (chk == 0)
                    {
                        //Este Cultivo, ha sido descarmado
                        //Se procede a eliminar
                        if (!cultivouser.IsEmpty())
                        {
                            cultivouser.Delete();
                        }
                    }
                    else
                    { //debemos actualizar el registro seleccionado
                        if (!cultivouser.IsEmpty())
                        {
                            if (TipoCultivo == 2) //peremne
                            {
                                cultivouser.SetValue("EdadPlantacion", EdadPlantacion);
                            }
                            else
                            {
                                cultivouser.SetValue("MesSiembra", MesSiembra);
                            }
                            cultivouser.SetValue("extension", extension);
                            cultivouser.SetValue("latitud", latitud);
                            cultivouser.SetValue("longitud", longitud);
                            cultivouser.Update();
                        }

                    }

                }
                else
                {//procedemos a insertar una nueva fila
                    if (chk == 1)
                    {
                        //Este Cultivo, ha sido marcado
                        //Se procede a eliminar
                        
                        //SimpleDataClass cultivouser = new SimpleDataClass("customtable.SPATS_CultivoUser");
                        string className = "customtable.SPATS_CultivoUser"; // cultivouser.ClassName;
                        CustomTableItem cultivouser = null;
                        CustomTableItemProvider provider = new CustomTableItemProvider(CMSContext.CurrentUser);
                        cultivouser = new CustomTableItem(className, provider);

                        cultivouser.SetValue("CultivoID", CultivoID);
                        cultivouser.SetValue("UserID", this.UserID);

                        if (TipoCultivo == 2) //peremne
                        {
                            cultivouser.SetValue("EdadPlantacion", EdadPlantacion);
                        }
                        else
                        {
                            cultivouser.SetValue("MesSiembra", MesSiembra);                           
                        }
                        cultivouser.SetValue("extension", extension);
                        cultivouser.SetValue("latitud", latitud);
                        cultivouser.SetValue("longitud", longitud);

                        if (cultivouser.OrderEnabled)
                        {
                            cultivouser.ItemOrder = provider.GetLastItemOrder(className) + 1;
                        }
                        cultivouser.Insert();

                    }
                }
            }
            
        }
    }

    protected bool inttobol(object value)
    {
        if (value.ToString() == "0")
        { return false; }
        else { return true; }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // habilitar las celdad de valores correctamente dependiendo del
            //tipo de cultivo
            var TipoCultivo = int.Parse(((DataRowView)e.Row.DataItem)[2].ToString());//int.Parse(e.Row.Cells[2].Text);

            if (TipoCultivo == 2) //Peremne
            {
                TextBox TextEdad = (TextBox)e.Row.FindControl("TextEdad");
                TextEdad.Enabled = true;
                TextEdad.Attributes["onchange"] = "javascript: Changed( this,2 );";
            }
            else  //Transitorio
            {
                DropDownList DrpDwnMes = (DropDownList)e.Row.FindControl("DrpDwnMes");
                DrpDwnMes.Enabled = true;
                DrpDwnMes.SelectedValue = ((DataRowView)e.Row.DataItem)[6].ToString(); 
            }
            TextBox txtlong = (TextBox)e.Row.FindControl("TxtLongitud");
            txtlong.Attributes["onchange"] = "javascript: Changed( this,7 );";

            TextBox TxtLatitud = (TextBox)e.Row.FindControl("TxtLatitud");
            TxtLatitud.Attributes["onchange"] = "javascript: Changed( this,7 );";

            TextBox TextExtension = (TextBox)e.Row.FindControl("TextExtension");
            TextExtension.Attributes["onchange"] = "javascript: Changed( this,2 );";

            
            
        }

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        this.savecultivos();
    }
    protected void TextEdad_TextChanged(object sender, EventArgs e)
    {
        this.savecultivos();
    }
    protected void DrpDwnMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.savecultivos();
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        this.savecultivos();
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
                EnsureItems(this.UserID,ValidationHelper.GetInteger(cad,0));
               // Match matchRelatedSQL = RegSQL.Match(this.FieldInfo.Description.ToLower());
                // Get SQL query text
               // string sqlText = matchRelatedSQL.Groups[0].Value.ToLower().Replace("<sql>", "").Replace("</sql>", "");

                //object[,] parameter = new object[1, 3];

                //parameter[0, 0] = "@ID";
                //parameter[0, 1] = ValidationHelper.GetString(mFormControlParameter, "");

                //DataSet ds = null;

                //try
                //{
                //    ds = this.Form.Connection.ExecuteQuery(sqlText, parameter, QueryTypeEnum.SQLQuery, false);
                //}
                //catch { }

                //if (!DataHelper.DataSourceIsEmpty(ds))
                //{
                //    // Show current form control
                //    this.Visible = true;
                //    drpRelated.Enabled = true;
                //    Label lblField = (Label)this.Form.FieldLabels[this.FieldInfo.Name];
                //    lblField.Visible = true;

                //    drpRelated.Items.Clear();
                //    drpRelated.DataSource = ds;
                //    drpRelated.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                //    drpRelated.DataTextField = ds.Tables[0].Columns[1].ColumnName;
                //    drpRelated.SelectedValue = ds.Tables[0].Rows[0][0].ToString();

                //    // Set selected value if possible
                //    if (!string.IsNullOrEmpty(mSelectedValue))
                //    {
                //        bool match = false;

                //        foreach (DataRow item in ds.Tables[0].Rows)
                //        {
                //            if (mSelectedValue.Equals(ValidationHelper.GetString(item[0], "")))
                //            {
                //                match = true;
                //            }
                //        }

                //        if (match)
                //        {
                //            drpRelated.SelectedValue = mSelectedValue;
                //        }
                //    }

                //    drpRelated.DataBind();
                }
                else
                {
                    // Hide current form control
                 //   this.Visible = false;
                 //   Label lblField = (Label)this.Form.FieldLabels[this.FieldInfo.Name];
                 //   lblField.Visible = false;
                  //  this.drpRelated.Items.Clear();
                ;
                }
            }
        }    
}
