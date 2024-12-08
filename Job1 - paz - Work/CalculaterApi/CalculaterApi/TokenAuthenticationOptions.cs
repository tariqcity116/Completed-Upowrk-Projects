using Microsoft.AspNetCore.Authentication;

public class TokenAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "Token";
    public string Scheme => DefaultScheme;
    public string AuthenticationType = DefaultScheme;

}