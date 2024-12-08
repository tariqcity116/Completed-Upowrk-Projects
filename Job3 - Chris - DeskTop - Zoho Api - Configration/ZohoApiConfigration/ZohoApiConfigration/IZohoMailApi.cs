namespace ZohoApiConfigration
{
    public interface IZohoMailAPI
    {
        Task GetRefreshToken();
        Task Connect(string refreshToken);
        Task<string> GetZoid();
        Task AddEmailAddressToBlacklist(string emailAddress);
        Task AddDomainToBlacklist(string domain);
    }
}
