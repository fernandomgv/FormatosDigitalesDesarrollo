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


public partial class CMSEjemplosFer_SelectorCultivo : FormEngineUserControl
{
    private object mFormControlParameter = null;

    private string CultivoUser_IDS;
    private Int32 mUserID;
    private Int32 mTerritorioID; //hace referencia al nodoID del territorio
    private Int32 mcultivoID;
    private DataTable mtbcultivos;


    
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
    
    public override Object Value
    {
        get
        {
            return this.dpdCultivo.SelectedValue;
        }
        set
        {
            EnsureItems();
            this.dpdCultivo.SelectedValue = System.Convert.ToString(value);
            mcultivoID = ValidationHelper.GetInteger(value,0);
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
        if ((string)Value != "")
        {
            return true;
        }
        else
        {
            // Set form control validation error message.
            this.ValidationError = "Es necesario que seleccione un cultivo";
            return false;
        }
     }
    

    /// <summary>
    /// Sets up the internal DropDownList control.
    /// </summary>
    protected void EnsureItems(int TerritorioID)
    {     
     
        if (SelectorWidth > 0)
        {
            this.dpdCultivo.Width = SelectorWidth;
        }

        dpdCultivo.Items.Clear();
        if (dpdCultivo.Items.Count == 0)
        {
            dpdCultivo.Items.Add(new ListItem("(selecciona un Cultivo)", ""));

            GeneralConnection cn = ConnectionHelper.GetConnection();
            DataSet DataSetdata = new DataSet();
            QueryDataParameters parameters = new QueryDataParameters();
            parameters.Add("@TerritorioID", TerritorioID);
            DataSetdata = ConnectionHelper.ExecuteQuery("customtable.SPATS_Cultivo.CultivobyTerritorio", parameters);
            if (!DataHelper.DataSourceIsEmpty(DataSetdata))
            {
                // Loop through all documents
                foreach (DataRow documentRow in DataSetdata.Tables[0].Rows)
                {
                    this.dpdCultivo.Items.Add(new ListItem(documentRow["Nombre"].ToString(), documentRow["CultivoID"].ToString()));
                }
            }
            if (this.mcultivoID > 0)
            {
                this.dpdCultivo.SelectedValue = System.Convert.ToString(this.mcultivoID);
            }
        }

    }
    protected void EnsureItems()
    {
        EnsureItems(this.TerritorioID);
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
       // this.Form.OnAfterSave += new EventHandler(Form_OnAfterSave);

       
    }

       protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
        EnsureItems();
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
                string cad = "";
                cad = ValidationHelper.GetString(mFormControlParameter, "");
                this.mcultivoID = 0;
                EnsureItems(ValidationHelper.GetInteger(cad, 0));
            }
         }
        }
    protected void dpdCultivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.mcultivoID = ValidationHelper.GetInteger(this.dpdCultivo.SelectedItem.Value, 0);
        this.actualizardependencias();
    }
    private void actualizardependencias()
    {
       
        string cultivoid = "";
        cultivoid = this.dpdCultivo.SelectedItem.Value;
        FormEngineUserControl drpMatch3 = (FormEngineUserControl)this.Form.FieldControls["PlagaID"];
        if (!(drpMatch3 == null))
        {
            drpMatch3.FormControlParameter = cultivoid; // SiteID
        }

    }
}
