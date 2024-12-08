using Newtonsoft.Json;
using SOAPServicePOC.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;

namespace SOAPServicePOC
{
    /// <summary>
    /// Summary description for SoapSampleService
    /// </summary>
    [WebService(Namespace = "http://webservices.wialon.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SoapSampleService : WebService
    {
        #region Variables
        public readonly Security security;
        #endregion

        [WebMethod]
        [SoapHeader("security", Required = true, Direction = SoapHeaderDirection.InOut)]
        [ScriptMethod]
        public string storeTelemetryList(StoreTelemetryList telemetryWithDetails)
        {
            //security.MustUnderstand = "1";
            //security.EncodedMustUnderstand = "1";
            if (security != null)
            {
                if (security.UsernameToken.IsValid())
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(StoreTelemetryList));
                    StringWriter textWriter = new StringWriter();
                    xmlSerializer.Serialize(textWriter, telemetryWithDetails);
  

                    //return "Api call sucessfully with authentication";
                    var jsonString = JsonConvert.SerializeObject(telemetryWithDetails);
                    Logger.LogGrabar(jsonString, Archivos.LogNombreArchivo);
                    return "OK";
                }
                else
                    return "Error in authentication";
            }
            else
            {
                return "Error in authentication";
            }
        }
    }
}
