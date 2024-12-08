using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            3
                301OperationContext.Current.IncomingMessageHeaders.GetHeader<SecurityHeader>("SecurityHeader", "http://schemas.microsoft.com/ws/2005/05/addressing/none");
            if (securityHeader == null || !ValidateSecurityHeader(securityHeader))
            {
                throw new FaultException<SecurityFault>(new SecurityFault { FaultCode = "InvalidCredentials", FaultMessage = "Invalid username or password." });
            }


            return string.Format("You entered: {0}", value);
        }
        private bool ValidateSecurityHeader(SecurityHeader securityHeader)
        {
            // perform validation logic here, e.g. verify the username and password against a database
            return false;
        }


    }
}
