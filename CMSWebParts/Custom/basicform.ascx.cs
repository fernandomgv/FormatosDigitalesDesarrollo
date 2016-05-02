using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CMS.PortalControls;
using CMS.Controls;
using CMS.GlobalHelper;
using CMS.TreeEngine;
using CMS.CMSHelper;
using CMS.ExtendedControls;
using CMS.SettingsProvider;
using CMS.DataEngine;
using CMS.FormEngine;
using CMS.IDataConnectionLibrary;

public partial class CMSWebParts_Custom_cmsform : CMSAbstractWebPart
{
    /// <summary>
    /// Content loaded event handler
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Initializes the control properties
    /// </summary>
    protected void SetupControl()
    {
        if (this.StopProcessing)
        {
            // Do not process
        }
        else
        {
            string className = "cms.user";// QueryHelper.GetString("cms.user", ""); // cms.user, bizform.contactus, cms.faq
            string alternativeForm = "cms.user.DisplayProfileIntranet";//"EditProfileIntranet";// QueryHelper.GetString("affn", "");

            if (!string.IsNullOrEmpty(className))
            {
                DataClassInfo dci = DataClassInfoProvider.GetDataClass(className);
                if (dci != null)
                {
                    IDataClass formItem = DataClassFactory.NewDataClass(className);//, this.form.Connection);

                    string formLayout = null;
                    string formDefinition = null;
 
                    if (!String.IsNullOrEmpty(alternativeForm))
                    {
                        // Get alternative form info if preset
                        AlternativeFormInfo afi = AlternativeFormInfoProvider.GetAlternativeFormInfo(alternativeForm);
                        if (afi != null)
                        {
                            // Merge class and alternative form definitions
                            formDefinition = FormHelper.MergeFormDefinitions(dci.ClassFormDefinition, afi.FormDefinition);
                            // Get alternative form layout
                            formLayout = afi.FormLayout;
                        }
                        else
                        {
                            formLayout = dci.ClassFormLayout;
                            formDefinition = dci.ClassFormDefinition;
                        }
                    }
                    else
                    {
                        formLayout = dci.ClassFormLayout;
                        formDefinition = dci.ClassFormDefinition;
                    }

                    // -----
                    this.form.Data = formItem; //.GetDataSet().Tables[0].Rows[0]; // formItem
                    this.form.FormXML = formDefinition;
                    this.form.FormLayout = formLayout;
                    // -----

                    // -- Advanced settings --
                    this.form.AllowMacroEditing = false;
                    this.form.DefaultFormLayout = FormLayoutEnum.Tables;
                    this.form.UseColonBehindLabel = false;
                    this.form.RenderCategoryList = true;
                    this.form.SubmitButton.Visible = true;
                    this.form.MarkRequiredFields = true;
                    // -----------------
                    //Esto debemos descomentar
                    this.form.OnAfterSave += new EventHandler(form_OnAfterSave);

                    GeneralConnection gc = ConnectionHelper.GetConnection();
                    DataSet ds = null;

                    try
                    {
                        string queryName = className + ".selectall";
                        ds = gc.ExecuteQuery(queryName, null, null);
                    }
                    catch { }

                    if (!DataHelper.DataSourceIsEmpty(ds))
                    {
                        // Display class data table
                        this.pnlTables.Visible = true;
                        this.repClass.DataSource = ds;
                        this.repClass.DataBind();
                    }
                }
                else
                {
                    lblInfo.Text = "ClassName does not exist!";
                    this.form.StopProcessing = true;
                    this.form.Visible = false;
                }
            }
            else
            {
                this.form.StopProcessing = true;
                this.form.Visible = false;  
            }
        }
    }

    void form_OnAfterSave(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    void form_OnAfterSave()
    {
        this.lblInfo.Text = "DataRow was saved :)";
        this.repClass.Visible = true;

        // Display DataRow
        this.pnlDataRow.Visible = true;
        this.repDataRow.DataSource = this.form.DataRow.Table;
        this.repDataRow.DataBind();
     }


    /// <summary>
    /// Reloads the control data
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();
        SetupControl();
    }
}



