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

using CMS.DatabaseHelper;
using CMS.DataEngine;
using CMS.SettingsProvider;


public partial class CMSSPATS_CMSFormControls_TerritorioSelector : FormEngineUserControl
{
    /// <summary>
    /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
    /// </summary>
    public override Object Value
    {
        get
        {
            return drpTerritorio.SelectedValue;
        }
        set
        {
            // Ensure drop down list options
            EnsureItems();
            drpTerritorio.SelectedValue = System.Convert.ToString(value);
            if (this.ShowPais )
            {
                this.SetPaisDepartamento();
            }

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

    public bool ShowPais
    {
        get
        {
            return ValidationHelper.GetBoolean(GetValue("ShowPais"), false);
        }
        set
        {
            SetValue("ShowPais", value);
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
        array[0, 1] = drpTerritorio.SelectedItem.Text;
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
            this.ValidationError = "Es necesario que seleccione un territorio";
            return false;
        }
    }


    /// <summary>
    /// Sets up the internal DropDownList control.
    /// </summary>
    protected void EnsureItems()
    {
   
        if (SelectorWidth > 0)
        {
            drpTerritorio.Width = SelectorWidth;
        }
        if (!ShowPais)
        {
            this.TextBox1.Visible = false;
            this.TextBox2.Visible = false;
        }


        if (drpTerritorio.Items.Count == 0)
        {
            drpTerritorio.Items.Add(new ListItem("(selecciona un Territorio)", ""));            
               
    DataSet DataSetdata = (DataSet) CMS.CMSHelper.TreeHelper.GetDocuments(CMS.CMSHelper.CMSContext.CurrentSiteName
, "/Modulos-en-Implementacion/%", "es-ES", true, "IntranetPortal.Department", "", "", -1, true, -1);

    if (!DataHelper.DataSourceIsEmpty(DataSetdata))
    {
        // Loop through all documents
        foreach (DataRow documentRow in DataSetdata.Tables[0].Rows)
        {
            drpTerritorio.Items.Add(new ListItem(documentRow["DocumentName"].ToString(), documentRow["DocumentId"].ToString()));
        }

    }
           
        }
    }
   

    
    /// <summary>
    /// Handler for the Load event of the control.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ensure drop-down list options
        EnsureItems();
        var cd = CMS.CMSHelper.CMSContext.CurrentDepartment;

        
        if (!(cd == null))
        {
            this.Value = cd.DocumentID;
            
            this.actualizardependencias();
            this.drpTerritorio.Enabled = false;
        }
        var idterritorio = QueryHelper.GetInteger("territorio",0);
        if (idterritorio>0)
        {
            this.Value = idterritorio;
            
            this.actualizardependencias();
            this.drpTerritorio.Enabled = false;
            
        }
    }
    private void SetPaisDepartamento()
    {
        string documentid = "";
        documentid = this.drpTerritorio.SelectedItem.Value;
        this.TextBox1.Text = "";
        this.TextBox2.Text ="";
        if (documentid != "")
        {
            CMS.TreeEngine.TreeNode doc;
            doc = CMS.CMSHelper.TreeHelper.SelectSingleDocument(int.Parse(documentid));
            
                string[] codpais = doc.GetProperty("pais").ToString().Split(';');
                GeneralConnection cn = ConnectionHelper.GetConnection();
                DataSet paisstate = new DataSet();
                QueryDataParameters parameters = new QueryDataParameters();

                parameters.Add("@StateName", codpais[1]);
                parameters.Add("@CountryName", codpais[0]);

                paisstate = ConnectionHelper.ExecuteQuery("IntranetPortal.Department.GetPaisDepartamentobyCode", parameters);

                if (paisstate.Tables[0] != null)
                {
                    this.TextBox1.Text = paisstate.Tables[0].Rows[0]["CountryDisplayName"].ToString();
                    this.TextBox2.Text = paisstate.Tables[0].Rows[0]["StateDisplayName"].ToString();
                }
            

        }
    }
    private void actualizardependencias()
    {
        if (this.ShowPais)
        {
            this.SetPaisDepartamento();
        }
        string documentid = "";
        documentid = this.drpTerritorio.SelectedItem.Value;
        //this.Form.FindControl("");
        FormEngineUserControl drpMatch = (FormEngineUserControl)this.Form.FieldControls["Cultivos"];
        if (!(drpMatch == null))
        {
            drpMatch.FormControlParameter = documentid; // SiteID
        }
        FormEngineUserControl drpMatch3 = (FormEngineUserControl)this.Form.FieldControls["CultivoID"];
        if (!(drpMatch3 == null))
        {
            drpMatch3.FormControlParameter = documentid; // SiteID
        }      

    }
    protected void drpTerritorio_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.actualizardependencias();
    }
}
