using ZohoApiConfigration;

ZohoMailAPI zohoMailApi = new ZohoMailAPI();

//first we have to execute  GetRefreshToken method to get refresh token

  await zohoMailApi.GetRefreshToken();

//  When we get the refresh token then we can connect and send different api request like AddEmailAddresstoblacklist etc
// When you get the refresh token please uncomment  the below three lines and comment the refresh token line.
//  Refresh Token = 1000.65d195f157ad9ab186c5312f51340c00.a7159fc4e3aaad303d1933783015929a


//await zohoMailApi.Connect("1000.65d195f157ad9ab186c5312f51340c00.a7159fc4e3aaad303d1933783015929a");
//await zohoMailApi.AddEmailAddressToBlacklist("tariq.city@yahoo.com");
//await zohoMailApi.AddDomainToBlacklist("www.google.com");