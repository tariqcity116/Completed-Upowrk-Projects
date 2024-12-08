using Newtonsoft.Json;

namespace ZohoApiConfigration
{

    public class Data
    {
        public int mailboxCount { get; set; }
        public string URI { get; set; }
        public string encryptedZoid { get; set; }
        public OrgPolicyDetails orgPolicyDetails { get; set; }
        public string loginName { get; set; }
        public SpamVO spamVO { get; set; }
        public string superAdminLoginName { get; set; }
        public string orgImageUrl { get; set; }
        public bool isMailHostingEnabled { get; set; }
        public int licenseCount { get; set; }
        public string superAdminFullName { get; set; }
        public long orgCreationTime { get; set; }
        public string orgName { get; set; }
        public string planType { get; set; }
        public bool isOfferAvailable { get; set; }
        public string primaryDomainName { get; set; }
        public int zoid { get; set; }
        public List<string> domains { get; set; }
        public int usersCount { get; set; }
        public int groupCount { get; set; }
        public string basePlan { get; set; }
        public string zaid { get; set; }
        public int sharedGroupCount { get; set; }
        public bool isDomainMarkingExist { get; set; }
        public string superAdmin { get; set; }
        public bool isEmailConfirmed { get; set; }
    }

    public class OrgPolicyDetails
    {
        [JsonProperty("1082700000239680393")]
        public string _1082700000239680393 { get; set; }
    }

    public class OrgDetail
    {
        public Status status { get; set; }
        public Data data { get; set; }
    }

    public class SpamVO
    {
        public string spamProcessType { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string description { get; set; }
    }
}
