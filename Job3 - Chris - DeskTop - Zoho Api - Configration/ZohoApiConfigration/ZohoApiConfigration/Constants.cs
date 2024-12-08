namespace ZohoApiConfigration
{
    public class ZohoApiConstants
    {
        public const string ClientId = "1000.JM2PQKCWOR34RASL7NVR1257LHK0YN";
        public const string ClientSecret = "d93870250388265bfa266c793cf2d157bfcd4e9270";
        public const string Scope = "ZohoMail.accounts.UPDATE,ZohoMail.accounts.READ,ZohoMail.organization.spam.READ,ZohoMail.partner.organization.READ,ZohoMail.organization.accounts.UPDATE,ZohoMail.organization.spam.UPDATE";
                                     
        public const string ResponseType = "code";
        public const string GrantType = "authorization_code";
        public const string OrganizationUrlPostPart = "antispam/data";
    }

    public class ZohoApiUrls
    {
        public const string OAuthUrl = "https://accounts.zoho.com/oauth/v2/auth";
        public const string TokenUrl = "https://accounts.zoho.com/oauth/v2/token";
        public const string RedirectUrl = "https://www.google.com";
        public const string OrganizationUrl = "https://mail.zoho.com/api/organization";
    }
}
