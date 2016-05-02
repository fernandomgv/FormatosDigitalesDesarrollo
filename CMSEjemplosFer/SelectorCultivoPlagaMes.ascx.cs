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


public partial class CMSEjemplosFer_SelectorCultivoPlagaMes : FormEngineUserControl
{
    private object mFormControlParameter = null;

    private string CultivoUser_IDS;
    private Int32 mUserID;
    private Int32 mCultivoID;
    private Int32 mPlagaID; 
    private DataTable mtcultivoplagaestadofenologico;


    protected DataTable tbcultivoplagaestadofenologico
    {
        get
        {
            if (CMS.GlobalHelper.SessionHelper.GetValue("cultivoplagaestadofenologico") == null)
            {
                mtcultivoplagaestadofenologico = this.NewtbcultivosplagaestadoF();
            }
            else
            {
                mtcultivoplagaestadofenologico = (DataTable)CMS.GlobalHelper.SessionHelper.GetValue("cultivoplagaestadofenologico");
            }
            return mtcultivoplagaestadofenologico;
        }
        set
        {
            mtcultivoplagaestadofenologico = value;
            CMS.GlobalHelper.SessionHelper.SetValue("cultivoplagaestadofenologico", this.mtcultivoplagaestadofenologico);

        }
    }
    /// <summary>
    /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
    /// </summary>
    /// 
    protected int CultivoID
    {
        get
        {
            //if ((this.Form.GetDataValue("CultivoID") == null))
            //{
                
                if (!(this.Form.FindControl("CultivoID").FindControl("dpdCultivo") == null))
                    {
                        this.mCultivoID = ValidationHelper.GetInteger(((DropDownList)(this.Form.FindControl("CultivoID").FindControl("dpdCultivo"))).SelectedValue, 0);
                    }
                    else
                    {
                        this.mCultivoID = 0;
                    }
                //}
                   
                
            //}
            //else
            //{
            //    this.mCultivoID = ValidationHelper.GetInteger(this.Form.GetDataValue("CultivoID").ToString(), 0);
            //}
            return this.mCultivoID;
        }
        set
        {
            this.mCultivoID = value;
        }
    }

    protected int PlagaID
    {
        get
        {
            //if ((this.Form.GetDataValue("PlagaID") == null))
            //{
                
                if (!(this.Form.FindControl("PlagaID").FindControl("dpdPlaga") == null))
                {
                    this.mPlagaID = ValidationHelper.GetInteger(((DropDownList)(this.Form.FindControl("PlagaID").FindControl("dpdPlaga"))).SelectedValue, 0);
                }
                else
                {
                    this.mPlagaID = 0;
                }
                //}


            //}
            //else
            //{
            //    this.mPlagaID = ValidationHelper.GetInteger(this.Form.GetDataValue("PlagaID").ToString(), 0);
            //}
            return this.mPlagaID;
        }
        set
        {
            this.mCultivoID = value;
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
             return true;
            
        }
    

    /// <summary>
    /// Sets up the internal DropDownList control.
    /// </summary>
    protected void EnsureItems(int CultivoID, int PlagaID)
    {
        GeneralConnection cn = ConnectionHelper.GetConnection();
        //dataset con los usuarios a notificar
        DataSet CultivoByUser = new DataSet();


        QueryDataParameters parameters = new QueryDataParameters();

        parameters.Add("@CultivoID", this.CultivoID);
        parameters.Add("@PlagaID", this.PlagaID);

        CultivoByUser = ConnectionHelper.ExecuteQuery("customtable.SPATS_Cultivo_Plaga_EstadoFenologico.EstadoFenologicobyCultivoPlaga", parameters);

        this.GridView1.DataSource = CultivoByUser;
        this.DataBind();
    }
    protected void EnsureItems()
    {
        EnsureItems(this.CultivoID, this.PlagaID);
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
       // this.Form.OnAfterSave += new EventHandler(Form_OnAfterSave);
        ((CMS.FormControls.CustomTableForm)this.Form.Parent).OnAfterSave += new EventHandler(Form_OnAfterSave);

       
    }

    private DataTable  NewtbcultivosplagaestadoF()
    {
        var tb = new DataTable();
        tb.Columns.Add("ItemID", Type.GetType("System.Int32"));
        tb.Columns.Add("Checked", Type.GetType("System.Int32"));
        tb.Columns.Add("EstadoFenologicoID", Type.GetType("System.Int32"));          
        return tb;
    }
 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            EnsureItems();

            this.tbcultivoplagaestadofenologico = this.NewtbcultivosplagaestadoF();
        }

    }
    private void savecultivoplagaEF()
    {                //recuperamos el estado actual de la grilla y la guardamos
        this.tbcultivoplagaestadofenologico.Rows.Clear();
        foreach (GridViewRow dr in GridView1.Rows)
        {
            if (!(((System.Web.UI.WebControls.WebControl)(((System.Web.UI.WebControls.TableRow)(dr)).Cells[1])).Controls[1] == null))
            {
                var datar = this.tbcultivoplagaestadofenologico.NewRow();
                datar[0] = this.GridView1.DataKeys[dr.RowIndex].Values[0];
                CheckBox chkb = (CheckBox)dr.FindControl("CheckBox1");
                if (chkb.Checked)
                {
                    datar[1] = 1;
                }
                else
                {
                    datar[1] = 0;
                }               
                datar[2] = this.GridView1.DataKeys[dr.RowIndex].Values[1]; 
                this.mtcultivoplagaestadofenologico.Rows.Add(datar);
            }
        }
        CMS.GlobalHelper.SessionHelper.SetValue("cultivoplagaestadofenologico", this.mtcultivoplagaestadofenologico);
   }   

    void Form_OnAfterSave(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        //intentariamos guardar la relacion detalle
        //Se comprueba que el evento es llamado desde el formulario
        //padre tras realizar la insersion de un usuario
        if ((this.CultivoID>0) & (this.PlagaID>0))
        {
            //Poblamos a una tabla temporal los datos contenidos en la interface
            this.savecultivoplagaEF();
            //ejecutamos la logica para la persistencia de los datos
            foreach (DataRow dr in this.mtcultivoplagaestadofenologico.Rows)
            {
                //tenmos un ItemID            
                
                int ItemID = ValidationHelper.GetInteger(dr[0], 0);
                int chk = ValidationHelper.GetInteger(dr[1], 0);
                int EstadoFenologicoID = ValidationHelper.GetInteger(dr[2], 0);
                

                if (ItemID > 0)
                {
                    SimpleDataClass cultivoplagaEF = new SimpleDataClass("customtable.SPATS_Cultivo_Plaga_EstadoFenologico", ItemID);
                    if (chk == 0)
                    {
                        //Este Cultivo, ha sido descarmado
                        //Se procede a eliminar
                        if (!cultivoplagaEF.IsEmpty())
                        {
                            cultivoplagaEF.Delete();
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
                        string className = "customtable.SPATS_Cultivo_Plaga_EstadoFenologico"; // cultivouser.ClassName;
                        CustomTableItem cultivoplagaEF = null;
                        CustomTableItemProvider provider = new CustomTableItemProvider(CMSContext.CurrentUser);
                        cultivoplagaEF = new CustomTableItem(className, provider);

                        cultivoplagaEF.SetValue("CultivoID", this.CultivoID);
                        cultivoplagaEF.SetValue("PlagaID", this.PlagaID);
                        cultivoplagaEF.SetValue("EstadoFenologicoID", EstadoFenologicoID);
                        if (cultivoplagaEF.OrderEnabled)
                        {
                            cultivoplagaEF.ItemOrder = provider.GetLastItemOrder(className) + 1;
                        }
                        cultivoplagaEF.Insert();

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
                EnsureItems(this.CultivoID,ValidationHelper.GetInteger(cad,0));

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
