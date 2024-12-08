using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace WCFSOAPServicePOC
{
    public class MyUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "abc" || password != "abc@1234#")
            {
                throw new FaultException("Invalid username or password.");
            }
        }
    }

}