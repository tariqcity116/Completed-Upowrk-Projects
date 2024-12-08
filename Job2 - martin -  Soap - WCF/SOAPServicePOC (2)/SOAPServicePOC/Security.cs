using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace SOAPServicePOC
{

    [XmlRoot(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public class Security:SoapHeader
    {
        public UsernameToken UsernameToken { get; set; }

        [SoapAttribute]
        [XmlAttribute]
        public new string MustUnderstand { get; set; } = "1";

        //public new bool DidUnderstand { get; set; } = true;

        //[DefaultValue("1")]
        //[SoapAttribute("mustUnderstand")]
        //[XmlAttribute("mustUnderstand")]
        //public string EncodedMustUnderstand { get; set; } = "1";

        //public Security()
        //{
        //    MustUnderstand = true;
        //    EncodedMustUnderstand = "1";
        //    DidUnderstand = true;
        //    //EncodedMustUnderstand12 = "1";
        //}
    }


    public class UsernameToken
    {
        #region Varaibles
        public string Username { get; set; }
        public string Password { get; set; }

        #endregion
        public bool IsValid()
        {
            return this.Username == ConfigurationManager.AppSettings["username"].ToString() && this.Password == ConfigurationManager.AppSettings["password"].ToString();
        }
    }
}