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


using CMS.PortalControls;
using CMS.WebAnalytics;


using CMS.DatabaseHelper;
using CMS.DataEngine;
using CMS.SettingsProvider;

using CMS.FormEngine;

using AjaxControlToolkit;

using CMS.UIControls;
using CMS.CMSHelper;
using CMS.SiteProvider;
using CMS.MediaLibrary;
using CMS.IO;


public partial class CMSEjemplosFer_SPATSMediaFile : FormEngineUserControl
{
    private object mFormControlParameter = null;

    private string CultivoUser_IDS;
    private Int32 mlibraryid;
    private Int32 mUserID;
    private Int32 mTerritorioID; //hace referencia al nodoID del territorio
    private Int32 mCultivoId;
    private DataTable mtbEstadoFenologico;

    protected string geturlmedialibrary()
    {
        return "~/CMSModules/MediaLibrary/Tools/Library_Edit_Files.aspx?libraryid=5";
    }

    
    /// <summary>
    /// Gets or sets the value entered into the field, a hexadecimal color code in this case.
    /// </summary>
    /// 

    protected int UserID
    {
        get 
        {
            if (string.IsNullOrEmpty(this.Form.GetDataValue("UserId").ToString()))
            {
                this.mUserID = 0;
            }
            else
            {
                this.mUserID = System.Int32.Parse(this.Form.GetDataValue("UserId").ToString());
            }
            return mUserID; 
        }
        set {
            this.mUserID = value;
        }
    }
    protected int CultivoID
    {
        get
        {
            if (string.IsNullOrEmpty(this.Form.GetDataValue("ItemID").ToString()))
            {
                this.mCultivoId = 0;
            }
            else
            {
                this.mCultivoId = ValidationHelper.GetInteger(this.Form.GetDataValue("ItemID").ToString(), 0);
            }
            return mCultivoId;
        }
        set
        {
            this.mCultivoId = value;
        }
    }
    public override Object Value
    {
        get
        {

            return ValidationHelper.GetInteger(this.HLibararyId.Value,0);

        }
        set
        {
            this.mlibraryid = ValidationHelper.GetInteger(value,0);
            this.HLibararyId.Value = this.mlibraryid.ToString();
        }
    }
    public string CampoNombre
    {
        get
        {
            return ValidationHelper.GetString(GetValue("CampoNombre"), "");
        }
        set
        {
            SetValue("CampoNombre", value);
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
       // array[0, 1] = drpTerritorio.SelectedItem.Text;
        return array;
    }

    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>
    public override bool IsValid()
    {
        return true;
        }
       
    protected void EnsureItems(int libraryid)
    {
        if (libraryid > 0)
        {
            var urllibrary = "http://"+ URLHelper.GetFullDomain()+ URLHelper.ApplicationPath + "/CMSModules/MediaLibrary/Tools/Library_Edit_Files.aspx?libraryid="+libraryid.ToString();
            this.gallery.Attributes.Add("src", urllibrary);
            this.gallery.Visible = true;
        }
        else
        {
            this.gallery.Visible = false;
        }
       
    }
    protected void EnsureItems()
    {
        EnsureItems(this.mlibraryid);
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
        //this.Form.OnAfterSave += new EventHandler(Form_OnAfterSave);
      ((CMS.FormControls.CustomTableForm)this.Form.Parent).OnAfterSave += new EventHandler(Form_OnAfterSave);

       
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            EnsureItems();
            //this.EstadoFenologico = this.NewtbEstadoFenologico();           
        }
    }
  
    void Form_OnAfterSave(object sender, EventArgs e)
    {
        
        //Creamos la libreria siempre y cuando esta no exista.
        if (this.mlibraryid==0)
        {
            //Poblamos a una tabla temporal los datos contenidos en la interface
            this.CreateMediaLibrary(); 
           // this.Form.GetDataValue("ItemID")
            if (this.mlibraryid > 0)
            {
                //var nomclass= ((CMS.FormControls.CustomTableForm)this.Form.Parent).na
                //var nomclass = ((CMS.DataEngine.SimpleDataClass)(((CMS.FormControls.CustomTableForm)this.Form.Parent).mBasicForm.Data)).ClassName;
                var nomclass = ((CMS.DataEngine.SimpleDataClass)(((CMS.FormControls.CustomTableForm)this.Form.Parent).BasicForm.Data)).ClassName;
                var itemid = ((CMS.FormControls.CustomTableForm)this.Form.Parent).ItemID;
                //"customtable.SPATS_Cultivo_Estado_Fenologico"
                SimpleDataClass CurrentDataClass = new SimpleDataClass(nomclass, itemid);
                if (!CurrentDataClass.IsEmpty())
                {
                    CurrentDataClass.SetValue(this.FieldInfo.Name, this.mlibraryid);
                    CurrentDataClass.Update();
                }
            }      
        }
    }


   
    private bool CreateMediaLibrary()
    {
        var Lcamponombre = this.CampoNombre;
        string nombrelibrary ="";
        string nombrecodelibrary = "";
        if (!string.IsNullOrEmpty(Lcamponombre))
        {
            nombrelibrary = ValidationHelper.GetString(this.Form.GetDataValue("CampoNombre"), "");
            
        }
        if (string.IsNullOrEmpty(nombrelibrary))
        {
            nombrelibrary = "SPATS Libreria de Medios " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        nombrecodelibrary = nombrelibrary.Replace(" ", "");
        nombrecodelibrary = nombrecodelibrary.Replace("/", "_");
        nombrecodelibrary = nombrecodelibrary.Replace(":", "_");

        // Create new media library object
        MediaLibraryInfo newLibrary = new MediaLibraryInfo();

        // Set the properties
        newLibrary.LibraryDisplayName = nombrelibrary;
        newLibrary.LibraryName = nombrecodelibrary;
        newLibrary.LibraryDescription = "My new library description";
        newLibrary.LibraryFolder = nombrecodelibrary;
        newLibrary.LibrarySiteID = CMSContext.CurrentSiteID;
        newLibrary.LibraryGUID = Guid.NewGuid();
        newLibrary.LibraryLastModified = DateTime.Now;

        // Create the media library
        MediaLibraryInfoProvider.SetMediaLibraryInfo(newLibrary);

        this.mlibraryid = newLibrary.LibraryID;
        this.HLibararyId.Value = this.mlibraryid.ToString();
        this.Value = newLibrary.LibraryID;
        return true;
    }
    private bool CreateMediaFolder()
    {
        // Get media library
        MediaLibraryInfo library = MediaLibraryInfoProvider.GetMediaLibraryInfo("MyNewLibrary", CMSContext.CurrentSiteName);
        if (library != null)
        {
            // Create new media folder object
            MediaLibraryInfoProvider.CreateMediaLibraryFolder(CMS.CMSHelper.CMSContext.CurrentSiteName, library.LibraryID, "MyNewFolder", false);

            return true;
        }

        return false;
    }
    private bool AddRolePermissionToLibrary()
    {
        // Get the media library
        
        MediaLibraryInfo mediaLibrary = MediaLibraryInfoProvider.GetMediaLibraryInfo("MyNewLibrary", CMSContext.CurrentSiteName);

        // Get the role
        RoleInfo libraryRole = RoleInfoProvider.GetRoleInfo("CMSDeskAdmin", CMSContext.CurrentSiteID);

        // Get the permission
        PermissionNameInfo libraryPermission = PermissionNameInfoProvider.GetPermissionNameInfo("FileCreate", "CMS.MediaLibrary", null);

        if ((mediaLibrary != null) && (libraryRole != null) && (libraryPermission != null))
        {
            // Create a new media library role permision info
            MediaLibraryRolePermissionInfo rolePermission = new MediaLibraryRolePermissionInfo();

            // Set the values
            rolePermission.LibraryID = mediaLibrary.LibraryID;
            rolePermission.RoleID = libraryRole.RoleID;
            rolePermission.PermissionID = libraryPermission.PermissionId;

            // Add role permission to media library
            MediaLibraryRolePermissionInfoProvider.SetMediaLibraryRolePermissionInfo(rolePermission);

            return true;
        }

        return false;
    }
}
