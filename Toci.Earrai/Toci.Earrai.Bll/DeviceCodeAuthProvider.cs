using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll {
    public class DeviceCodeAuthProvider : IAuthenticationProvider
    {
        private IPublicClientApplication _msalClient;
        private string[] _scopes;
        private IAccount _userAccount;

        public DeviceCodeAuthProvider(string appId, string[] scopes)
        {
            _scopes = scopes;

            _msalClient = PublicClientApplicationBuilder
                .Create(appId)
                .WithAuthority(AadAuthorityAudience.AzureAdMyOrg, true)
                .WithTenantId("e9d3c2b0-cc05-41fa-9f46-7b9377d1a294")
                .Build();

        }

        public async Task<string> GetAccessToken()
        {
            // If there is no saved user account, the user must sign-in
            if (_userAccount == null)
            {
                try
                {
                    // Invoke device code flow so user can sign-in with a browser
                    System.Security.SecureString pass = new System.Security.SecureString();
                    pass.AppendChar('B');
                    pass.AppendChar('e');
                    pass.AppendChar('a');
                    pass.AppendChar('t');
                    pass.AppendChar('k');
                    pass.AppendChar('a');
                    pass.AppendChar('9');
                    pass.AppendChar('1');
                    pass.AppendChar('1');

                    AuthenticationResult result = await _msalClient.AcquireTokenByUsernamePassword(_scopes, "bzapart@tocizapart.onmicrosoft.com", pass).ExecuteAsync();
                    
                    //     callback => {
                    //    Console.WriteLine(callback.Message);
                    //    return Task.FromResult(0);
                    // }).ExecuteAsync();

                    _userAccount = result.Account;
                    return result.AccessToken;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error getting access token: {exception.Message}");
                    return null;
                }
            }
            else
            {
                // If there is an account, call AcquireTokenSilent
                // By doing this, MSAL will refresh the token automatically if
                // it is expired. Otherwise it returns the cached token.

                var result = await _msalClient
                    .AcquireTokenSilent(_scopes, _userAccount)
                    .ExecuteAsync();

                return result.AccessToken;
            }
        }

        // This is the required function to implement IAuthenticationProvider
        // The Graph SDK will call this function each time it makes a Graph
        // call.
        public async Task AuthenticateRequestAsync(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("bearer", await GetAccessToken());
        }
    }
}