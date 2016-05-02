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

using CMS.GlobalHelper;
using CMS.Reporting;
using CMS.SiteProvider;
using CMS.CMSHelper;
using CMS.UIControls;

public partial class CMSModules_Reporting_Tools_SavedReports_SavedReports_List : CMSReportingPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UniGrid.OnAction += new OnActionEventHandler(uniGrid_OnAction);
        UniGrid.WhereCondition = createWhereCondition();
    }


    /// <summary>
    /// Creates where condition for unigrid.
    /// </summary>
    private string createWhereCondition()
    {
        string condition = "";

        int reportId = QueryHelper.GetInteger("reportId", 0);

        if (reportId != 0)
        {
            condition += "SavedReportReportId = " + reportId;
        }

        return condition;
    }


    /// <summary>
    /// Handles the UniGrid's OnAction event.
    /// </summary>
    /// <param name="actionName">Name of item (button) that throws event</param>
    /// <param name="actionArgument">ID (value of Primary key) of corresponding data row</param>
    protected void uniGrid_OnAction(string actionName, object actionArgument)
    {
        if (actionName == "edit")
        {
            URLHelper.Redirect("SavedReport_View.aspx?reportId=" + Convert.ToString(actionArgument));
        }
        else if (actionName == "delete")
        {
            // Check 'Modify' permission
            if (!CMSContext.CurrentUser.IsAuthorizedPerResource("cms.reporting", "Modify"))
            {
                RedirectToAccessDenied("cms.reporting", "Modify");
            }
            // delete ReportInfo object from database
            SavedReportInfoProvider.DeleteSavedReportInfo(Convert.ToInt32(actionArgument));
        }
    }
}
