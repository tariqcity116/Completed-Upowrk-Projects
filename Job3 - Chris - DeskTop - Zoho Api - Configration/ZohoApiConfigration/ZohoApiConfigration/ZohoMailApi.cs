using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace ZohoApiConfigration
{
    public class ZohoMailAPI : IZohoMailAPI
    {
        private readonly HttpClient _httpClient;
        private string _refreshToken;
        private string _accessToken;
        private string _zoid;

        public ZohoMailAPI()
        {
            _httpClient = new HttpClient();
        }

      

        public async Task GetRefreshToken()
        {
            var httpClient = new HttpClient();

            // Build the URL with the required parameters
            var authUrl = $"{ZohoApiUrls.OAuthUrl}?client_id={ZohoApiConstants.ClientId}&redirect_uri={ZohoApiUrls.RedirectUrl}&scope={ZohoApiConstants.Scope}&response_type={ZohoApiConstants.ResponseType}&access_type=offline";

            // Display the URL in the console and prompt the user to open it in their web browser
            Console.WriteLine($"Please open the following URL in your web browser to grant permission to your application:\n\n{authUrl}\n");
            Console.Write("Enter the authorization code: ");
            var authCode = Console.ReadLine();

            // Build the request body with the required parameters
            var requestBody = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("code", authCode),
            new KeyValuePair<string, string>("client_id", ZohoApiConstants.ClientId),
            new KeyValuePair<string, string>("client_secret", ZohoApiConstants.ClientSecret),
            new KeyValuePair<string, string>("redirect_uri", ZohoApiUrls.RedirectUrl),
            new KeyValuePair<string, string>("grant_type", ZohoApiConstants.GrantType),
        });

            // Make the request and get the access token
            var tokenResponse = await httpClient.PostAsync(ZohoApiUrls.TokenUrl, requestBody);
            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            TokenResponse tokenRes = JsonConvert.DeserializeObject<TokenResponse>(tokenContent);
            Console.WriteLine("Refresh Token:" + tokenRes.refresh_token);
        }


        public async Task Connect(string refreshToken)
        {
            var requestContent = new StringContent($"grant_type=refresh_token&scope={ZohoApiConstants.Scope}&client_id={ZohoApiConstants.ClientId}&client_secret={ZohoApiConstants.ClientSecret}&refresh_token={refreshToken}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await _httpClient.PostAsync(ZohoApiUrls.TokenUrl, requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

            _accessToken = jsonResponse.access_token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var responsezoid = await _httpClient.GetAsync(ZohoApiUrls.OrganizationUrl);
            var content = await responsezoid.Content.ReadAsStringAsync();

            OrgDetail jsonRes = JsonConvert.DeserializeObject<OrgDetail>(content);
            _zoid = jsonRes.data.zoid.ToString();

            Console.WriteLine(" Zoho Id :" + _zoid);
        }

        public async Task<string> GetZoid()
        {
            
            return _zoid;
        }

        public async Task AddEmailAddressToBlacklist(string emailAddress)
        {
           
            var requestContent = new StringContent($"{{\"spamCategory\":\"spamEmail\",\"spamEmail\":[\"{emailAddress}\"]}}", Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.PutAsync($"{ZohoApiUrls.OrganizationUrl}/{_zoid}/{ZohoApiConstants.OrganizationUrlPostPart}", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed to add email address to blacklist: {responseContent}");
            }
        }

        public async Task AddDomainToBlacklist(string domain)
        {
            var requestContent = new StringContent($"{{\"spamCategory\":\"spamDomain\",\"spamDomain\":[\"{domain}\"]}}", Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.PutAsync($"{ZohoApiUrls.OrganizationUrl}/{_zoid}/{ZohoApiConstants.OrganizationUrlPostPart}", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed to add domain to blacklist: {responseContent}");
            }
        }
    }
}










