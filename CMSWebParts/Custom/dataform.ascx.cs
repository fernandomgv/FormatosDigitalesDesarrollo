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

public partial class CMSWebParts_Custom_dataform : CMSAbstractWebPart
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
            form.ItemID = QueryHelper.GetInteger("itemid", 0);
            form.AlternativeFormFullName = QueryHelper.GetString("affn", "");

            string formMode = QueryHelper.GetString("formmode", "insert").ToLower();

            if (formMode.Equals("insert"))
            {
                form.FormMode = FormModeEnum.Insert;
            }
            else if (formMode.Equals("update"))
            {
                form.FormMode = FormModeEnum.Update;
            }

            form.ClassName = QueryHelper.GetString("classname", "");

            if (string.IsNullOrEmpty(form.ClassName))
            {
                form.StopProcessing = true;
                form.Visible = false;
            }
            else
            {
                form.OnAfterSave += new CMS.FormControls.DataForm.OnAfterSaveEventHandler(form_OnAfterSave);
                // CMS.User system table example
                // form.BasicForm.HideSystemFields = true;
                // form.ClearAfterSave = true;
            }
        }
    }


    void form_OnAfterSave()
    {
        lblInfo.Text = "Changes were saved.";
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



