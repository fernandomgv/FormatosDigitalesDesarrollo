using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CMS.CMSHelper;
using CMS.GlobalHelper;
using CMS.EmailEngine;
//using CMS.EmailProvider;
using CMS.SettingsProvider;
using System.Net.Mail;

using CMS.FileManager;
using CMS.SiteProvider;
using CMS.URLRewritingEngine;
using CMS.PortalEngine;
using CMS.DataEngine;
using CMS.UIControls;
using CMS.EventLog;




/// <summary>
/// Descripción breve de SendEmailUsingTemplateHelper
/// </summary>
public class SendEmailUsingTemplateHelper
{
    public SendEmailUsingTemplateHelper()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public void SendEmailUsingTemplate(string emailTemplateName, string recipientEmail, string[,] replacements, string eventName)
    {
        // Set resolver   
        ContextResolver resolver = CMSContext.CurrentResolver;
        resolver.SourceParameters = replacements;

        // Get the email template   
        var template = EmailTemplateProvider.GetEmailTemplate(emailTemplateName, 0);

        if (template != null)
        {
            // Email message   
            var emailMessage = new EmailMessage
            {
                EmailFormat = EmailFormatEnum.Default,
                Recipients = recipientEmail,
                From = EmailHelper.GetSender(template, SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".CMSNoreplyEmailAddress")),
                CcRecipients = template.TemplateCc,
                BccRecipients = template.TemplateBcc,
                Subject = resolver.ResolveMacros(template.TemplateSubject),
                PlainTextBody = resolver.ResolveMacros(template.TemplatePlainText)
            };

            // Enable macro encoding for body   
            resolver.EncodeResolvedValues = true;

            emailMessage.Body = resolver.ResolveMacros(template.TemplateText);

            // Disable macro encoding for plaintext body and subject   
            resolver.EncodeResolvedValues = false;

            try
            {
                MetaFileInfoProvider.ResolveMetaFileImages(emailMessage, template.TemplateID, EmailObjectType.EMAILTEMPLATE, MetaFileInfoProvider.OBJECT_CATEGORY_TEMPLATE);
                // Send the e-mail immediately  
 
                EmailSender.SendEmail(CMSContext.CurrentSiteName, emailMessage, true);

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "per-dc09.per.local";
                //smtp.Credentials = new System.Net.NetworkCredential("fmogollon", "Verano2011$");
                //smtp.Send("iica.peru@iica.int", emailMessage.Recipients, emailMessage.Subject, emailMessage.Body);        

            }
            catch (Exception ex)
            {
                var eventLogProvider = new EventLogProvider();
                eventLogProvider.LogEvent("E", eventName, ex);

                throw;
            }
        }
    }
    public void SendEmailUsingTemplate(string emailTemplateName, string recipientEmail,string fromEmail, string[,] replacements, string eventName)
    {
        // Set resolver   
        ContextResolver resolver = CMSContext.CurrentResolver;
        resolver.SourceParameters = replacements;

        // Get the email template   
        var template = EmailTemplateProvider.GetEmailTemplate(emailTemplateName, 0);

        if (template != null)
        {
            // Email message   
            var emailMessage = new EmailMessage
            {
                EmailFormat = EmailFormatEnum.Default,
                Recipients = recipientEmail,
                From = EmailHelper.GetSender(template, fromEmail),
                CcRecipients = template.TemplateCc,
                BccRecipients = template.TemplateBcc,
                Subject = resolver.ResolveMacros(template.TemplateSubject),
                PlainTextBody = resolver.ResolveMacros(template.TemplatePlainText)
            };

            // Enable macro encoding for body   
            resolver.EncodeResolvedValues = true;

            emailMessage.Body = resolver.ResolveMacros(template.TemplateText);

            // Disable macro encoding for plaintext body and subject   
            resolver.EncodeResolvedValues = false;

            try
            {
                MetaFileInfoProvider.ResolveMetaFileImages(emailMessage, template.TemplateID, EmailObjectType.EMAILTEMPLATE, MetaFileInfoProvider.OBJECT_CATEGORY_TEMPLATE);
                // Send the e-mail immediately  

                EmailSender.SendEmail(CMSContext.CurrentSiteName, emailMessage, true);

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "per-dc09.per.local";
                //smtp.Credentials = new System.Net.NetworkCredential("fmogollon", "Verano2011$");
                //smtp.Send("iica.peru@iica.int", emailMessage.Recipients, emailMessage.Subject, emailMessage.Body);        

            }
            catch (Exception ex)
            {
                var eventLogProvider = new EventLogProvider();
                eventLogProvider.LogEvent("E", eventName, ex);

                throw;
            }
        }
    }
	
	 public void SendEmailUsingTemplateSubject(string emailTemplateName, string recipientEmail, string fromEmail, string pSubject, string[,] replacements, string eventName)
    {
        // Set resolver   
        ContextResolver resolver = CMSContext.CurrentResolver;
        resolver.SourceParameters = replacements;

        // Get the email template   
        var template = EmailTemplateProvider.GetEmailTemplate(emailTemplateName, 0);

        if (template != null)
        {
            // Email message   
            var emailMessage = new EmailMessage
            {
                EmailFormat = EmailFormatEnum.Default,
                Recipients = recipientEmail,
                From = EmailHelper.GetSender(template, fromEmail),
                CcRecipients = template.TemplateCc,
                BccRecipients = template.TemplateBcc,
                Subject = pSubject, //resolver.ResolveMacros(template.TemplateSubject),
                PlainTextBody = resolver.ResolveMacros(template.TemplatePlainText)
            };

            // Enable macro encoding for body   
            resolver.EncodeResolvedValues = true;

            emailMessage.Body = resolver.ResolveMacros(template.TemplateText);

            // Disable macro encoding for plaintext body and subject   
            resolver.EncodeResolvedValues = false;

            try
            {
                MetaFileInfoProvider.ResolveMetaFileImages(emailMessage, template.TemplateID, EmailObjectType.EMAILTEMPLATE, MetaFileInfoProvider.OBJECT_CATEGORY_TEMPLATE);
                // Send the e-mail immediately  

                EmailSender.SendEmail(CMSContext.CurrentSiteName, emailMessage, true);

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "per-dc09.per.local";
                //smtp.Credentials = new System.Net.NetworkCredential("fmogollon", "Verano2011$");
                //smtp.Send("iica.peru@iica.int", emailMessage.Recipients, emailMessage.Subject, emailMessage.Body);        

            }
            catch (Exception ex)
            {
                var eventLogProvider = new EventLogProvider();
                eventLogProvider.LogEvent("E", eventName, ex);

                throw;
            }
        }
    }
}
