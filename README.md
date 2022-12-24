# fcs-azure
Library to aquire Azure access token

Sample call
```csharp
using System;
using FCS.Lib.Azure;
using FCS.Lib.Utility;

namespace TestAzure
{
    public class Program
    {
        static void Main(string[] args)
        {
            var settings = new MySettings();

            var authStore = new AzureAuthStore(
                settings.LoginUrl, settings.OAuthEndpoint, settings.LoginScope, settings.GrantType, 
                settings.TenantId, settings.ClientId, settings.ClientSecret);

            var tokenFetcher = new AzureTokenFetcher(authStore);

            // normally called async - but this is only a test
            var token = tokenFetcher.FetchAzureToken().Result;

            var ts1 = Mogrify.CurrentDateTimeToTimeStamp();
            var ts2 = Mogrify.DateTimeToTimeStamp(DateTime.Now.AddHours(+2));

            Console.WriteLine($"AccessToken: {token.AccessToken}");
            Console.WriteLine($"Expires    : {token.Expires}");
            Console.WriteLine($"TokenType  : {token.TokenType}");
            Console.WriteLine($"HasExpired : {DateTime.Now} {token.HasExpired(ts1)}");
            Console.WriteLine($"HasExpired : {DateTime.Now.AddHours(+2)} {token.HasExpired(ts2)}");
            Console.ReadKey();
        }
    }

    internal sealed class MySettings
    {
        public string LoginUrl => "https://login.microsoftonline.com";
        public string OAuthEndpoint => "oauth2/v2.0/token";
        public string GrantType => "client_credentials";
        public string LoginScope => "insert-your-login-scope";
        public string TenantId => "insert-your-tenant-id";
        public string ClientId => "insert-your-client-id";
        public string ClientSecret => "insert-your-client-secret";
    }
}

```
