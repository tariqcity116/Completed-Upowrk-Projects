using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPServicePOC.Model
{
    public class Archivos
    {
        public static string LogNombreArchivo => "SoapService" + DateTime.Today.ToString("yyyyMMdd") + ".txt";

        public static string LogNombreArchivoError => "SoapService_error" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
    }
}