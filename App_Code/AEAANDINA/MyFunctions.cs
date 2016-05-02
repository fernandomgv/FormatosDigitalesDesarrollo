using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CMS.GlobalHelper;
using CMS.CMSHelper ;

using CMS.DatabaseHelper;
using CMS.DataEngine;
using CMS.SettingsProvider;

/// <summary>
/// Summary description for MyFunctions
/// </summary>
public static class MyFunctions
{

 public static string getsliderpage(object txtValue, string order)
    {
        if (txtValue == null | txtValue == DBNull.Value)
        {
            return "";
        }
        else
        {
            string htmlicon = "";
            if (order == "1")
            {
                htmlicon = "<span class=\"jFlowControlnoti pag" + order + " jFlowSelectednoti\"></span>";
            }
            else
            {
                htmlicon = "<span class=\"jFlowControlnoti pag" + order + " \"></span>";
            }
            return htmlicon;
        }
    }

    public static string getsliderfoto(object txtValue,string urlimagen, string leyenda, string credito)
    {
        if (txtValue == null | txtValue == DBNull.Value)
        {
            return "";
        }
        else
        {
            string htmlicon = "";
            //css += Environment.NewLine + "#alt2{" + posorden + "}";
            htmlicon = "<div class=\"lisnoticiasf jFlowSlideContainer\">";
            htmlicon += Environment.NewLine + "<div class=\"foto\">";
            htmlicon += Environment.NewLine + "<img src=\"" + urlimagen + "\" width=\"210\" height=\"150\" />";
            htmlicon += Environment.NewLine + "</div>";
            htmlicon += Environment.NewLine + "<div class=\"descr\">" + leyenda + "<br />";
            if (credito != "")
            {
                htmlicon += Environment.NewLine + "Foto: " + credito;
            }
            htmlicon += Environment.NewLine + "</div>	";
            htmlicon += Environment.NewLine + "</div>	";
            return htmlicon;
        }
    }
	
    public static string haveacces(object txtValue)
    {
        if (txtValue == null | txtValue == DBNull.Value)
        {
            
            return "";
        }
        else
        {
            string txt = (string)txtValue;
            if (CMS.CMSHelper.CMSContext.CurrentUser.IsInRole(txt, CMS.CMSHelper.CMSContext.CurrentSite.SiteName))
            {
                //the current user is member of the CMSEditor role'
                return "ok";
            }
            else
            {
               return "";
            }
 /*
            if (CMSContext.CurrentUser.IsInRole(txt, "MFSANDINANew"))
            { return "ok"; }
            else {return "";}
           */
        }
    }

 public static string geticonfortema1(object txtValue)
    {
        if (txtValue == null | txtValue == DBNull.Value)
        {
            return "";
        }
        else
        {
            string txt = (string)txtValue;
            string htmlicon = "",pos="";
            int x, y;

            x = 0;
            y = 0;


            if (txt.Contains("RSA"))
            {
                htmlicon = "<a href=\"#\" onmouseover=\"malt(1,'')\" onmouseout=\"oalt(1)\" class=\"icono1\"> </a>";
                x = 60;
                y = 0;
            }
            if (txt.Contains("ALIANZA"))
            {
                
                pos = y.ToString() + "px 0 0 " + x.ToString() + "px";
                htmlicon = htmlicon + " " +  "<a href=\"#\" onmouseover=\"malt(2,'"+pos+"')\" onmouseout=\"oalt(2)\" class=\"icono2\"> </a>";
                x = x + 80;
		if (y == -40)
                { y = 60; }
                else { y = 0; }
            }
            if (txt.Contains("VALOR"))
            {
                
                pos = y.ToString() + "px 0 0 " + x.ToString() + "px";
                htmlicon = htmlicon + " " + "<a href=\"#\" onmouseover=\"malt(3,'"+pos+"')\" onmouseout=\"oalt(3)\" class=\"icono3\"> </a>";
                 x = x + 107;
		if (y == -40)
                { y = 60; }
                else { y = 0; }
            }
            if (txt.Contains("MFC"))
            {
                
                pos = y.ToString() + "px 0 0 " + x.ToString() + "px";
                htmlicon = htmlicon + " " + "<a href=\"#\" onmouseover=\"malt(4,'" + pos + "')\" onmouseout=\"oalt(4)\" class=\"icono4\"> </a>";
		x = x + 107;
            }
            return htmlicon;
        }
    }   

    public static string geticonfortemadesc(object txtValue)
    {
        if (txtValue == null | txtValue == DBNull.Value)
        {
            return "";
        }
        else
        {
            string txt = (string)txtValue;
            string htmlicon="", posorden = "", css="";
            int x, y ; 

            x = 0;
            y = 0;

            if (txt.Contains("RSA"))
            {
                htmlicon = "<div class=\"alticono\" id=\"alt1\">Retribuci&oacute;n por servicios<br />ambientales (RSA)</div>";
                x = 51;
                y = 130;
                css = "#alt1{}";
            }
            if (txt.Contains("ALIANZA"))
            {          
                x = x + 70;                
                posorden = " style=\"" +y.ToString() +"px 0 0 "+x.ToString()+"px;\" ";
                htmlicon = htmlicon + " <div class=\"alticono\" id=\"alt2\">Alianzas multiactores</div>";
                css += Environment.NewLine + "#alt2{" + posorden + "}"; 
                 
                if(y == 0)
                {y = 130;} 
                else { y = 0;}
            }
            if (txt.Contains("VALOR"))
            {
                x = x + 97;
                posorden = " style=\"" + y.ToString() + "px 0 0 " + x.ToString() + "px;\" ";
                htmlicon = htmlicon + " <div class=\"alticono\" id=\"alt3\">Valor agregado en<br />productos forestales</div>";
                css += Environment.NewLine + "#alt3{" + posorden + "}"; 
if(y == 0)
                {y = 130;} 
                else { y = 0;}
            }
            if (txt.Contains("MFC"))
            {
                x = x + 93;
                posorden = " style=\"" + y.ToString() + "px 0 0 " + x.ToString() + "px;\" ";
                htmlicon = htmlicon + " <div class=\"alticono\" id=\"alt4\">Manejo forestal comunitario<br />(MFC)</div>";
                css += Environment.NewLine + "#alt4{" + posorden + "}"; 
            }

            css = "<head><style type=\"text/css\">" + Environment.NewLine + css + "</style></head>";

            return  htmlicon;
        }
    }
    
    public static string geticonfortema(object txtValue)
    {
        if (txtValue == null | txtValue == DBNull.Value)
        {
            return "";
        }
        else
        {
            string txt = (string)txtValue;
            string htmlicon = "";

            if (txt.Contains("RSA"))
            {
                htmlicon = "<a href=\"#\" onmouseover=\"malt(1)\" onmouseout=\"oalt(1)\" class=\"icono1\"> </a>";
            }
            if (txt.Contains("ALIANZA"))
            {
                htmlicon = htmlicon + " " +  "<a href=\"#\" onmouseover=\"malt(2)\" onmouseout=\"oalt(2)\" class=\"icono2\"> </a>";
            }
            if (txt.Contains("VALOR"))
            {
                htmlicon = htmlicon + " " + "<a href=\"#\" onmouseover=\"malt(3)\" onmouseout=\"oalt(3)\" class=\"icono3\"> </a>";
            }
            if (txt.Contains("MFC"))
            {
                htmlicon = htmlicon + " " + "<a href=\"#\" onmouseover=\"malt(4)\" onmouseout=\"oalt(4)\" class=\"icono4\"> </a>";
            }
            return htmlicon;
        }
    }   
        public static string TrimText(object txtValue, int leftChars)
        {
            if (txtValue == null | txtValue == DBNull.Value)
            {
                return "";
            }
            else
            {
                string txt = (string) txtValue;
                if (txt.Length <= leftChars)
                {
                    return txt;
                }
                else
                {
                    return txt.Substring(0, leftChars) + "...";
                }
            }
        }   

public static string traduce(object txtValueES, object txtValueEN)
        {
            if (CMS.CMSHelper.CMSContext.CurrentDocumentCulture.CultureCode == "es-ES")
            {
                return (string) txtValueES;
            }
            else
            {               
                    return (string) txtValueEN;             
            }
        }   

 public static string ReturnUrlSrc(string nodeGuidParam)
   {
      try
      {
   

  if (nodeGuidParam != null && nodeGuidParam.Trim() != "")
         {
            string nodeGuidStr = ValidationHelper.GetString(nodeGuidParam, "");
            Guid nodeGUID = new Guid(nodeGuidStr);
            if (nodeGUID != null)
            {
               int nodeId = CMS.TreeEngine.TreePathUtils.GetNodeIdByNodeGUID(nodeGUID, CMS.CMSHelper.CMSContext.CurrentSiteName);

               if (nodeId != null)
               {
                  CMS.TreeEngine.TreeProvider tp = new CMS.TreeEngine.TreeProvider(CMS.CMSHelper.CMSContext.CurrentUser);
                  CMS.TreeEngine.TreeNode node = tp.SelectSingleNode(nodeId);
                  
		return CMS.TreeEngine.AttachmentManager.GetAttachmentUrl(nodeGuidStr , node.NodeAliasPath);    
                 // return CMS.CMSHelper.CMSContext.GetUrl(node.NodeAliasPath, node.DocumentUrlPath, CMSContext.CurrentSiteName);
		
}
}
}

return "";
}
catch
{
return "";
}
}

 public static string convertirInIds(object relacionados, string Columna)
 {
    string ids = (string)relacionados;
       ids =(string)ids.Replace("|", ",");
	 if (ids.Length > 0)
	 {
	   return Columna + " in (" + ids + ")";
	 }
	 return "";
 }
 
  public static string GetGuidImgFromTable(string tabla, object id1, string columnaimg)
 {
 string id = (string)id1;
  if ( (tabla.Length>0) &&  ( id.Length>0) && (columnaimg.Length>0) )
  {
     GeneralConnection cn = ConnectionHelper.GetConnection();
     DataSet ds = new DataSet();
     string txtquery = "Select " + columnaimg + " from " + tabla + " where " + " ItemId = " + id;
     ds = ConnectionHelper.ExecuteQuery(txtquery, null, QueryTypeEnum.SQLQuery, false);
     if (ds != null)
     {
         if (ds.Tables != null)
         {
             string imgguid = ds.Tables[0].Rows[0][0].ToString();
             
             if (imgguid.Length>0)
             {
                 
             return imgguid;
             }
             
         }
     }
	 }
    return "";

 }
 
  public static string GetImgFromTable(string tabla, object id, string columnaimg)
 {
     GeneralConnection cn = ConnectionHelper.GetConnection();
     DataSet ds = new DataSet();
     string txtquery = "Select " + columnaimg + " from " + tabla + " where " + " ItemId = " + (string)id;
     ds = ConnectionHelper.ExecuteQuery(txtquery, null, QueryTypeEnum.SQLQuery, false);
     if (ds != null)
     {
         if (ds.Tables != null)
         {
             string imgguid = ds.Tables[0].Rows[0][0].ToString();
             
             if (imgguid.Length>0)
             {
                 string Tagimg = "";

            Tagimg = " <img alt= \"Imagen " + columnaimg + " \"  src='<%# ResolveUrl(\"~/CMSPages/GetFile.aspx?guid=" + imgguid + " \") %>' /> ";
             return Tagimg;
             }
             
         }
     }
    return "Sin Imagen";

 }
 
}