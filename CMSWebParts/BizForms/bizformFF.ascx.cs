using System;
using System.Web;

using CMS.CMSHelper;
using CMS.GlobalHelper;
using CMS.PortalControls;
using CMS.WebAnalytics;
using CMS.TreeEngine;
using CMS.SiteProvider;

using CMS.DatabaseHelper;
using CMS.DataEngine;
using CMS.SettingsProvider;
using System.Data;
using CMS.FormControls;
using CMS.FormEngine;

public partial class CMSWebParts_BizForms_bizformFF: CMSAbstractWebPart
{
    #region "Properties"

    /// <summary>
    /// Gets or sets the form name of BizForm.
    /// </summary>
    public string BizFormName
    {
        get
        {
            return ValidationHelper.GetString(GetValue("BizFormName"), "");
        }
        set
        {
            this.SetValue("BizFormName", value);
        }
    }


    /// <summary>
    /// Gets or sets the alternative form full name (ClassName.AlternativeFormName).
    /// </summary>
    public string AlternativeFormName
    {
        get
        {
            return ValidationHelper.GetString(GetValue("AlternativeFormName"), "");
        }
        set
        {
            this.SetValue("AlternativeFormName", value);
        }
    }


    /// <summary>
    /// Gets or sets the site name.
    /// </summary>
    /// 
    public string SiteName
    {
        get
        {
            return ValidationHelper.GetString(GetValue("SiteName"), "");
        }
        set
        {
            this.SetValue("SiteName", value);
        }
    }

    /// <summary>
    /// Gets or sets the roles for notification.
    /// </summary>
    /// 
    public string RolesNotification
    {
        get
        {
            return ValidationHelper.GetString(GetValue("RolesNotification"), "");
        }
        set
        {
            this.SetValue("RolesNotification", value);
        }
    }


    /// <summary>
    /// Gets or sets the value that indicates whether the WebPart use colon behind label.
    /// </summary>
    public bool UseColonBehindLabel
    {
        get
        {
            return ValidationHelper.GetBoolean(GetValue("UseColonBehindLabel"), true);
        }
        set
        {
            this.SetValue("UseColonBehindLabel", value);
        }
    }


    /// <summary>
    /// Gets or sets the message which is displayed after validation failed.
    /// </summary>
    public string ValidationErrorMessage
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("ValidationErrorMessage"), "");
        }
        set
        {
            this.SetValue("ValidationErrorMessage", value);
        }
    }


    /// <summary>
    /// Gets or sets the conversion track name used after successful registration.
    /// </summary>
    public string TrackConversionName
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("TrackConversionName"), "");
        }
        set
        {
            if (value.Length > 400)
            {
                value = value.Substring(0, 400);
            }
            this.SetValue("TrackConversionName", value);
        }
    }


    /// <summary>
    /// Gets or sets the conversion value used after successful registration.
    /// </summary>
    public double ConversionValue
    {
        get
        {
            return ValidationHelper.GetDouble(this.GetValue("ConversionValue"), 0);
        }
        set
        {
            this.SetValue("ConversionValue", value);
        }
    }

    #endregion


    #region "Methods"

    protected override void OnLoad(EventArgs e)
    {
        viewBiz.OnAfterSave += viewBiz_OnAfterSave;
        base.OnLoad(e);
    }


    /// <summary>
    /// Content loaded event handler.
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Reloads data for partial caching.
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();
        SetupControl();
    }


    /// <summary>
    /// Initializes the control properties.
    /// </summary>
    protected void SetupControl()
    {
        if (this.StopProcessing)
        {
            // Do nothing
            viewBiz.StopProcessing = true;
        }
        else
        {
            // Set BizForm properties
            viewBiz.FormName = this.BizFormName;
            viewBiz.SiteName = this.SiteName;
            //viewBiz.RolesNotification = this.RolesNotification;
            viewBiz.UseColonBehindLabel = this.UseColonBehindLabel;
            viewBiz.AlternativeFormFullName = this.AlternativeFormName;
            viewBiz.ValidationErrorMessage = this.ValidationErrorMessage;

            // Set the live site context
            if (viewBiz.BasicForm != null)
            {
                viewBiz.BasicForm.ControlContext.ContextName = CMS.SiteProvider.ControlContext.LIVE_SITE;
            }
        }
    }


    void viewBiz_OnAfterSave(object sender, EventArgs e)
    {
        if (this.TrackConversionName != String.Empty)
        {
            string siteName = CMSContext.CurrentSiteName;

            if (AnalyticsHelper.AnalyticsEnabled(siteName) && AnalyticsHelper.TrackConversionsEnabled(siteName) && !AnalyticsHelper.IsIPExcluded(siteName, HTTPHelper.UserHostAddress))
            {
                HitLogProvider.LogConversions(CMSContext.CurrentSiteName, CMSContext.PreferredCultureCode, this.TrackConversionName, 0, ConversionValue);
            }
        }
        TreeNode dptactual;
        
        string sValue = this.RolesNotification;

        GeneralConnection cn = ConnectionHelper.GetConnection(); 
        //dataset con los usuarios a notificar
        DataSet usrnotificar = new DataSet();

        
         QueryDataParameters parameters = new QueryDataParameters();
                    
                    parameters.Add("@roles", ";" + sValue + ";");
                    
         
        usrnotificar= ConnectionHelper.ExecuteQuery("cms.user.GetUserbyRoles", parameters);
     foreach( DataRow usr in usrnotificar.Tables[0].Rows)
     {
         BizFormInfo bizFormInfo = BizFormInfoProvider.GetBizFormInfo(this.BizFormName, CMSContext.CurrentSiteID);
         DataClassInfo dataClassInfo = DataClassInfoProvider.GetDataClass(bizFormInfo.FormClassID);
         if (dataClassInfo != null)
            {
             //dataClassInfo.
                string namekey = dataClassInfo.SchemaDataSet.Tables[0].PrimaryKey[0].ColumnName;
                string llaveid = this.viewBiz.BasicForm.GetDataValue(namekey).ToString();
                var   connection = ConnectionHelper.GetConnection();
                var whereCondition = namekey +" = " + llaveid.ToString(); //String.Format( "ContactUsID = '{0}'", 1); // choose a row

                var dataSet = connection.ExecuteQuery(dataClassInfo.ClassName + ".selectall", null, whereCondition);

                if (!DataHelper.DataSourceIsEmpty(dataSet) && dataSet.Tables[0].Rows.Count == 1)
                {
                    DataRow dataRow = dataSet.Tables[0].Rows[0];

                    BizForm bizForm = new BizForm();

                    BizFormItem bizFormItem = new BizFormItem(dataRow, dataClassInfo.ClassName);

                    if ((bizFormItem != null) && (bizFormInfo != null))
                    {
                        BasicForm basicForm = new BasicForm(bizFormItem);
                        basicForm.SiteName = CMSContext.CurrentSiteName;
                        basicForm.EditedObject = bizFormItem;
                        basicForm.FormInformation = CMS.FormEngine.FormHelper.GetFormInfo(dataClassInfo.ClassName, true); // set required FormInfo
                        bizForm.BasicForm = basicForm;
                        bizFormInfo.FormSendToEmail = usr["Email"].ToString();

                        bizForm.SendNotificationEmail(bizFormInfo.FormSendFromEmail, bizFormInfo.FormSendToEmail, bizFormItem, bizFormInfo);
                    }
                }
            }

     }
       //this.viewBiz.SendNotificationEmail(
       // dptactual = CMS.CMSHelper.CMSContext.CurrentDepartment;
    }
 

    #endregion
}