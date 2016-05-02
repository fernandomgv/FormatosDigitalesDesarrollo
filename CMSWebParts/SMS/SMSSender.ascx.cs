using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CMS.PortalControls;
using CMS.GlobalHelper;
using SMSNotification;
using CMS.SettingsProvider;
using CMS.CMSHelper;

public partial class CMSWebParts_SMS_SMSSender : CMSAbstractWebPart
{
    #region "Properties"

    /// <summary>
    /// Gets or sets default sender into sender textbox.
    /// </summary>
    public string DefaultSender
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("DefaultSender"), "");
        }
        set
        {
            this.SetValue("DefaultSender", value);
        }
    }


    /// <summary>
    /// Login for Clicatell.com account.
    /// </summary>
    public string Login
    {
        get
        {
            string login = ValidationHelper.GetString(this.GetValue("Login"), "");
            if (String.IsNullOrEmpty(login))
            {
                login = SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".SMSLogin");
                this.SetValue("Login", login);
            }
            return login;
        }
        set
        {
            this.SetValue("Login", value);
        }
    }


    /// <summary>
    /// Password for Clicatell.com account.
    /// </summary>
    public string Password
    {
        get
        {
            string password = ValidationHelper.GetString(this.GetValue("Password"), "");
            if (String.IsNullOrEmpty(password))
            {
                password = SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".SMSPassword");
                this.SetValue("Password", password);
            }
            return password;
        }
        set
        {
            this.SetValue("Password", value);
        }
    }


    /// <summary>
    /// ApiID for Clicatell.com account.
    /// </summary>
    public string ApiID
    {
        get
        {
            string apiId = ValidationHelper.GetString(this.GetValue("ApiID"), "");
            if (String.IsNullOrEmpty(apiId))
            {
                apiId = SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".SMSApiID");
                this.SetValue("ApiID", apiId);
            }
            return apiId;
        }
        set
        {
            this.SetValue("ApiID", value);
        }
    }


    /// <summary>
    /// Indicates if user is allowed to change from field.
    /// </summary>
    public bool AllowChangeFrom
    {
        get
        {
            return ValidationHelper.GetBoolean(this.GetValue("AllowChangeFrom"), false);
        }
        set
        {
            this.SetValue("AllowChangeFrom", value);
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!RequestHelper.IsPostBack())
        {
            if (!String.IsNullOrEmpty(DefaultSender))
            {
                txtFrom.Text = DefaultSender;
            }
            txtFrom.Enabled = AllowChangeFrom;
        }
    }


    protected void btnSend_Click(object sender, EventArgs e)
    {
        string from = txtFrom.Text.Trim().Replace(" ", "");
        string to = txtTo.Text.Trim().Replace(" ", "");
        string message = txtMessage.Text.Trim();

        SMSMessage smsMessage = new SMSMessage();
        smsMessage.From = from;
        smsMessage.To = to;
        smsMessage.Text = message;

        SMSProvider provider = new SMSProvider();
        provider.Authenticate(Login, Password, ApiID);
        if (provider.Authenticated)
        {
            provider.SendSMS(smsMessage);
            if (!provider.MessageSended)
            {
                lblError.Text = "Error occured during sending message.<br/>Original error: " + provider.MessageSendError;
                lblError.Visible = true;
            }
        }
        else
        {
            lblError.Text = "Error occured during authentication.<br/>Original error: " + provider.AthentificationError;
            lblError.Visible = true;
        }
    }
}
