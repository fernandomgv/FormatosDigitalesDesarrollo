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

public partial class CMSFormControls_ColorSelector : FormEngineUserControl  
{
    /// <summary>
    /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
    /// </summary>
    public override Object Value
    {
        get
        {
            return drpColor.SelectedValue;
        }
        set
        {
            // Ensure drop down list options
            EnsureItems();
            drpColor.SelectedValue = System.Convert.ToString(value);
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
        array[0, 1] = drpColor.SelectedItem.Text;
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
            this.ValidationError = "Please choose a color.";
            return false;
        }
    }


    /// <summary>
    /// Sets up the internal DropDownList control.
    /// </summary>
    protected void EnsureItems()
    {
        // Applies the width specified through the parameter of the form control if it is valid.
        if (SelectorWidth > 0)
        {
            drpColor.Width = SelectorWidth;
        }

        if (drpColor.Items.Count == 0)
        {
            drpColor.Items.Add(new ListItem("(select color)", ""));
            drpColor.Items.Add(new ListItem("Red", "#FF0000"));
            drpColor.Items.Add(new ListItem("Green", "#00FF00"));
            drpColor.Items.Add(new ListItem("Blue", "#0000FF"));
        }
    }

    /// <summary>
    /// Handler for the Load event of the control.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ensure drop-down list options
        EnsureItems();
    }
}
