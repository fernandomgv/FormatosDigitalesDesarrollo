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

using CMS.CMSHelper;
using CMS.SiteProvider;
using CMS.SettingsProvider;
using CMS.GlobalHelper;
using CMS.UIControls;

public partial class CMSPages_Dialogs_UserRegistration : CMSPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string defaultAliasPath = SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".CMSDefaultAliasPath");
        string defaultUrl = CMSContext.GetUrl(defaultAliasPath);
        //Seteamos esta direccion
        defaultUrl = "~/sconvocatoria/registro.aspx";

        if (!String.IsNullOrEmpty(defaultUrl))
        {
            defaultUrl = ResolveUrl(defaultUrl);
        }

        //RegistrationApproval.SuccessfulApprovalText = GetString("membership.userconfirmed") + " " + "<a href=\"" + defaultUrl + "\" title=\"" + ResHelper.GetString("General.ClickHereToContinue") + "\" >" + ResHelper.GetString("General.ClickHereToContinue") + "</a>";
        //Seteamos el mensaje a mostrar
        RegistrationApproval.SuccessfulApprovalText = "Gracias por completar el proceso de Registro en la 3era Convocatoria del Programa AEA Region Andina, Ya puedes iniciar sesion con el email y contraseña que proporcionaste durante tu registro, " + " " + "<a href=\"" + defaultUrl + "\" title=\"" + "Clic aqui para continuar" + "\" >" + "Clic aqui para continuar" + "</a>";

        RegistrationApproval.SuccessfulApprovalText = "<div style=\" width: 650px; margin: auto;\"><table width=\"95%\"><tbody><tr><td align=\"left\" style=\" margin: 0px;\"><img style=\"width: 600px; height: 83px;\" src=\"http://energiayambienteandina.net/App_Themes/REC/REC_imagenes/logoconfirmacion.png\" /></td></tr></tbody></table><table width=\"645\" height=\"164\" cellpadding=\"30\"><tbody><tr><td align=\"left\" style=\" margin: 0px;\"><div align=\"justify\">Gracias por completar el proceso de Registro en la 3era Convocatoria del Programa AEA Region Andina, ya puedes iniciar sesion con el email y contraseña que proporcionaste durante tu registro.</div><br /><a title=\"Clic aqui para continuar\" href=\"" + defaultUrl + "\" style=\"color: rgb(17, 85, 204);\">Comienza aquí</a>.<br /><br />- El equipo AEA</td></tr></tbody></table><table style=\"width: 630px;\"><tbody><tr><td style=\" margin: 0px; font-size: 9px; color: rgb(144, 144, 144); padding-left: 45px;\"></td><td align=\"right\" style=\" margin: 0px;\"><img style=\"width: 20px; height: 19px;\" src=\"http://energiayambienteandina.net/App_Themes/REC/REC_imagenes/logo-simbolo-min-bn.png\" /><span style=\" font-size: 11px; color: rgb(136, 136, 136);\">&copy;&nbsp;2014 AEA</span></td></tr></tbody></table></div>";
        RegistrationApproval.WaitingForApprovalText = GetString("mem.reg.SuccessfulApprovalWaitingForAdministratorApproval");

        // Set administrator e-mail
        RegistrationApproval.AdministratorEmail = SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".CMSAdminEmailAddress");
        RegistrationApproval.FromAddress = SettingsKeyProvider.GetStringValue(CMSContext.CurrentSiteName + ".CMSNoreplyEmailAddress");
    }
}
