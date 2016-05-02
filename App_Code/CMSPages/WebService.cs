// Aplicando http://www.mcbeev.com/Blog/August-2010/How-To-Call-the-Kentico-CMS-WebService-from-a-Java 

using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services; //agregado


/// <summary>
/// Empty web service template.
/// </summary>
[WebService(Namespace = "CMS.WebService")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class WebServiceFM : System.Web.Services.WebService
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WebServiceFM()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    /// <summary>
    /// Returns the data from DB.
    /// </summary>
    /// <param name="parameter">String parameter for sql command</param>
    [WebMethod]
	[System.Web.Script.Services.ScriptMethod]
    public DataSet GetDataSet(string parameter)
    {
        // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING DATASET

        return null;
    }


    [System.Web.Services.WebMethod(MessageName = "GetCompletionList")]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING STRING ARRAY
        
        return null;
    }


    [System.Web.Services.WebMethod(MessageName = "GetCompletionListContext")]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetCompletionList(string prefixText, int count, string contextKey) 
    {
        // INSERT YOUR WEB SERVICE CODE AND RETURN THE RESULTING STRING ARRAY

        return null;
    }

	[System.Web.Services.WebMethod] 
	[ScriptMethod] // agregado
		public JsonResponse ActualizarHoraServerFM() 
		{ 
			var jsonResponse = new JsonResponse {Success = false};
				try
				{
					jsonResponse.Data = new { hora = DateTime.Now.ToString("HH:mm:ss")}; 
					jsonResponse.Success = true;
				}
				catch (Exception ex)
				{
					jsonResponse.Message = ex.Message; 
					 
				}

				return jsonResponse;
		}
}
