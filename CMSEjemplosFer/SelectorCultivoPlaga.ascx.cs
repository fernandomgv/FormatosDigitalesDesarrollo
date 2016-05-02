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


public partial class CMSEjemplosFer_SelectorCultivoPlaga : FormEngineUserControl
{
    private object mFormControlParameter = null;

    private string CultivoUser_IDS;
    private Int32 mUserID;
    private Int32 mCultivoID;
    private Int32 mTerritorioID; //hace referencia al nodoID del territorio
    private DataTable mtbplagas;


    protected DataTable tbplagas
    {
        get
        {
            if (CMS.GlobalHelper.SessionHelper.GetValue("CultivoPlagas") == null)
            {
                mtbplagas = this.Newtbplagas();
            }
            else
            {
                mtbplagas = (DataTable)CMS.GlobalHelper.SessionHelper.GetValue("CultivoPlagas");
            }
            return mtbplagas;
        }
        set
        {
            mtbplagas = value;
            CMS.GlobalHelper.SessionHelper.SetValue("CultivoPlagas", this.mtbplagas);

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
    
    protected int CultivoID
    {
        get 
        {
            if (string.IsNullOrEmpty(this.Form.GetDataValue("ItemID").ToString()))
            {
                this.mCultivoID = 0;
            }
            else
            {
                this.mCultivoID = System.Int32.Parse(this.Form.GetDataValue("ItemID").ToString());
            }
            return mCultivoID; 
        }
        set {
            this.mCultivoID = value;
        }
    }
    public override Object Value
    {
        get
        {
                      
            return 0;

        }
        set
        {
            ;
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
        return true;
        }
    

    /// <summary>
    /// Sets up the internal DropDownList control.
    /// </summary>
    protected void EnsureItems(int CultivoID)
    {
        GeneralConnection cn = ConnectionHelper.GetConnection();
        //dataset con los usuarios a notificar
        DataSet CultivoPlaga = new DataSet();


        QueryDataParameters parameters = new QueryDataParameters();

        parameters.Add("@CultivoID", CultivoID);

        CultivoPlaga = ConnectionHelper.ExecuteQuery("customtable.SPATS_Cultivo_Plaga.CultivoPlagabyCultivoID", parameters);

        this.GridView1.DataSource = CultivoPlaga;
        this.DataBind();
    }
    protected void EnsureItems()
    {
        EnsureItems(this.CultivoID);
        
    }
     

    private DataTable  Newtbplagas()
    {
        var tb = new DataTable();
        tb.Columns.Add("CultivoID", Type.GetType("System.Int32"));
        tb.Columns.Add("PlagaID", Type.GetType("System.Int32"));
        tb.Columns.Add("NombreComun", Type.GetType("System.String"));
        tb.Columns.Add("ItemID", Type.GetType("System.Int32"));
        tb.Columns.Add("Checked", Type.GetType("System.Int32"));
        return tb;
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        //this.Form.OnAfterSave += new EventHandler(Form_OnAfterSave);
        ((CMS.FormControls.CustomTableForm)this.Form.Parent).OnAfterSave += new EventHandler(Form_OnAfterSave);


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            EnsureItems();

            this.tbplagas = this.Newtbplagas();

        }
               
    }
    private void SavePlagas()
    {                //recuperamos el estado actual de la grilla y la guardamos
        this.tbplagas.Rows.Clear();
        foreach (GridViewRow dr in GridView1.Rows)
        {
            if (!(((System.Web.UI.WebControls.WebControl)(((System.Web.UI.WebControls.TableRow)(dr)).Cells[1])).Controls[1] == null))
            {
                var datar = this.tbplagas.NewRow();
                datar[0] = this.GridView1.DataKeys[dr.RowIndex].Values[0];//CultivoID,PlagaID,ItemID
                datar[1] = this.GridView1.DataKeys[dr.RowIndex].Values[1];//CultivoID,PlagaID,ItemID
                datar[3] = this.GridView1.DataKeys[dr.RowIndex].Values[2];//CultivoID,PlagaID,ItemID
                CheckBox chkb = (CheckBox)dr.FindControl("CheckBox1");

                datar[2] = chkb.Text;
                if (chkb.Checked)
                {
                    datar[4] = 1;
                }
                else
                {
                    datar[4] = 0;
                }                
                this.mtbplagas.Rows.Add(datar);
            }
        }
        CMS.GlobalHelper.SessionHelper.SetValue("CultivoPlagas", this.mtbplagas);

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
            this.SavePlagas();
            //ejecutamos la logica para la persistencia de los datos
            foreach (DataRow dr in this.mtbplagas.Rows)
            {
                //tenmos un ItemID            
                int CultivoID = ValidationHelper.GetInteger(dr[0], 0);
                int PlagaID = ValidationHelper.GetInteger(dr[1], 0);
                int ItemID = ValidationHelper.GetInteger(dr[3], 0);
                int chk = ValidationHelper.GetInteger(dr[4], 0);       
               

                if (ItemID > 0)
                {
                    SimpleDataClass cultivoplaga = new SimpleDataClass("customtable.SPATS_Cultivo_Plaga", ItemID);
                    if (chk == 0)
                    {
                        //Este Cultivo, ha sido descarmado
                        //Se procede a eliminar
                        if (!cultivoplaga.IsEmpty())
                        {
                            cultivoplaga.Delete();
                        }
                    }                 

                }
                else
                {//procedemos a insertar una nueva fila
                    if (chk == 1)
                    {
                        string className = "customtable.SPATS_Cultivo_Plaga";
                        CustomTableItem cultivoplaga = null;
                        CustomTableItemProvider provider = new CustomTableItemProvider(CMSContext.CurrentUser);
                        cultivoplaga = new CustomTableItem(className, provider);

                        cultivoplaga.SetValue("CultivoID", this.CultivoID);
                        cultivoplaga.SetValue("PlagaID", PlagaID);                       
                        if (cultivoplaga.OrderEnabled)
                        {
                            cultivoplaga.ItemOrder = provider.GetLastItemOrder(className) + 1;
                        }
                        cultivoplaga.Insert();

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
                     
            
        }

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        this.SavePlagas();
    }
    protected void TextEdad_TextChanged(object sender, EventArgs e)
    {
        this.SavePlagas();
    }
    protected void DrpDwnMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SavePlagas();
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        this.SavePlagas();
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
                EnsureItems(this.CultivoID);
            }
                
            }
        }    
}
