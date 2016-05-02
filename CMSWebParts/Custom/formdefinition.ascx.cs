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

public partial class CMSWebParts_Custom_formdefinition : CMSAbstractWebPart
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
        }
    }


    /// <summary>
    /// Reloads the control data
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();
        SetupControl();
    }


    protected void btnGetClass_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txtClassname.Text.Trim()))
        {
            repClass.Visible = true;
            repClass.WhereCondition = "ClassName LIKE '" + this.txtClassname.Text.Trim().Replace("'", "''") + "'";
            repClass.ReloadData(true);
        }
    }


    protected void btnUpdateClass_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txtClassname.Text.Trim()))
        {
            DataClassInfo dci = DataClassInfoProvider.GetDataClass(this.txtClassname.Text.Trim());

            if (dci != null)
            {
                // Generate XMLSchema
                dci.ClassXmlSchema = TableManager.GetXmlSchema(dci.ClassTableName);
                // Get FormDefinition from XMLSchema
                dci.ClassFormDefinition = FormHelper.GetXmlFormDefinitionFromXmlSchema(dci.ClassXmlSchema, false);
                // Save DataClass
                DataClassInfoProvider.SetDataClass(dci);
                // Generate queries
                SqlGenerator.GenerateDefaultQueries(dci, true, false);
            }
        }
    }


    protected void btnAddressFieldName_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txtAddressFieldName.Text.Trim()))
        {
            DataClassInfo dci = DataClassInfoProvider.GetDataClass("ecommerce.address");
            if (dci != null)
            {
                FormInfo fi = new FormInfo(dci.ClassFormDefinition);
                FormFieldInfo ffi = fi.GetFormField(this.txtAddressFieldName.Text.Trim());
                if (ffi != null)
                {
                    lblFieldType.Text = ffi.FieldType.ToString();
                }
                else
                {
                    lblFieldType.Text = "<span style=\"color:red;\">Error: FormFieldInfo is empty (Field was not found)! </span>";
                }
            }
        }
    }


    protected void btnUnlockSystemTable_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(this.txtClassname.Text.Trim()))
        {
            GeneralConnection gc = ConnectionHelper.GetConnection();
            
            object[,] parameters = new object[1, 3];
            parameters[0, 0] = "@ClassName";
            parameters[0, 1] = this.txtClassname.Text.Trim();

            try
            {
                gc.ExecuteQuery("UPDATE CMS_Class SET ClassShowAsSystemTable = 1 WHERE ClassName = @ClassName", parameters, QueryTypeEnum.SQLQuery, false);
                lblInfo.Visible = true;
                lblInfo.Text = "Done!";
            }
            catch (Exception ex)
            {
                lblInfo.Visible = true;
                lblInfo.Text = ex.Message.ToString();
            }
        }
    }


    protected void btnLockSystemTable_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(this.txtClassname.Text.Trim()))
        {
            GeneralConnection gc = ConnectionHelper.GetConnection();
            
            object[,] parameters = new object[1, 3];
            parameters[0, 0] = "@ClassName";
            parameters[0, 1] = this.txtClassname.Text.Trim();

            try
            {
                gc.ExecuteQuery("UPDATE CMS_Class SET ClassShowAsSystemTable = 0 WHERE ClassName = @ClassName", parameters, QueryTypeEnum.SQLQuery, false);
                lblInfo.Visible = true;
                lblInfo.Text = "Done!";
            }
            catch(Exception ex)
            {
                lblInfo.Visible = true;
                lblInfo.Text = ex.Message.ToString();
            }
        }
    }
}



