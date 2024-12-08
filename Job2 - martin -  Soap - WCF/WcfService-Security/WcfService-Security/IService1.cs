using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [FaultContract(typeof(SecurityFault))]
        string GetData(string value);

    }

    [DataContract]
    public class SecurityFault
    {
        [DataMember]
        public string FaultCode { get; set; }

        [DataMember]
        public string FaultMessage { get; set; }
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/ws/2005/05/addressing/none")]
    public class SecurityHeader
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }



}
