
# OAuth 2 Authorization Code Grant



Documentation for accessing and setting credentials for oauth_2_0.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| OAuthClientId | `string` | OAuth 2 Client ID | `OAuthClientId` | `OAuthClientId` |
| OAuthClientSecret | `string` | OAuth 2 Client Secret | `OAuthClientSecret` | `OAuthClientSecret` |
| OAuthRedirectUri | `string` | OAuth 2 Redirection endpoint or Callback Uri | `OAuthRedirectUri` | `OAuthRedirectUri` |
| OAuthToken | `Models.OAuthToken` | Object for storing information about the OAuth token | `OAuthToken` | `OAuthToken` |
| OAuthScopes | `List<Models.OAuthScopeEnum>` | List of scopes that apply to the OAuth token | `OAuthScopes` | `OAuthScopes` |



**Note:** Auth credentials can be set using `AuthorizationCodeAuth` in the client builder and accessed through `AuthorizationCodeAuth` method in the client instance.

## Usage Example

### 1\. Client Initialization

You must initialize the client with *OAuth 2.0 Authorization Code Grant* credentials as shown in the following code snippet.

```csharp
SpotifyWebAPIClient client = new SpotifyWebAPIClient.Builder()
    .AuthorizationCodeAuth(
        new AuthorizationCodeAuthModel.Builder(
            "OAuthClientId",
            "OAuthClientSecret",
            "OAuthRedirectUri"
        )
        .OAuthScopes(
            new List<OAuthScopeEnum>
            {
                OAuthScopeEnum.AppRemoteControl,
                OAuthScopeEnum.PlaylistReadPrivate,
            })
        .Build())
    .Build();
```



Your application must obtain user authorization before it can execute an endpoint call in case this SDK chooses to use *OAuth 2.0 Authorization Code Grant*. This authorization includes the following steps

### 2\. Obtain user consent

To obtain user's consent, you must redirect the user to the authorization page.The `BuildAuthorizationUrl()` method creates the URL to the authorization page. You must have initialized the client with scopes for which you need permission to access.

```csharp
string authUrl = await client.AuthorizationCodeAuth.BuildAuthorizationUrl();
```

### 3\. Handle the OAuth server response

Once the user responds to the consent request, the OAuth 2.0 server responds to your application's access request by redirecting the user to the redirect URI specified set in `Configuration`.

If the user approves the request, the authorization code will be sent as the `code` query string:

```
https://example.com/oauth/callback?code=XXXXXXXXXXXXXXXXXXXXXXXXX
```

If the user does not approve the request, the response contains an `error` query string:

```
https://example.com/oauth/callback?error=access_denied
```

### 4\. Authorize the client using the code

After the server receives the code, it can exchange this for an *access token*. The access token is an object containing information for authorizing client requests and refreshing the token itself.

```csharp
var authManager = client.AuthorizationCodeAuth;

try
{
    OAuthToken token = authManager.FetchToken(authorizationCode);
    // re-instantiate the client with OAuth token
    client = client.ToBuilder()
        .AuthorizationCodeAuth(
            client.AuthorizationCodeAuthModel.ToBuilder()
                .OAuthToken(token)
                .Build())
        .Build();
}
catch (ApiException e)
{
    // TODO Handle exception
}
```

### Scopes

Scopes enable your application to only request access to the resources it needs while enabling users to control the amount of access they grant to your application. Available scopes are defined in the [`OAuthScopeEnum`](../../doc/models/o-auth-scope-enum.md) enumeration.

| Scope Name | Description |
|  --- | --- |
| `APP-REMOTE-CONTROL` | Communicate with the Spotify app on your device. |
| `PLAYLIST-READ-PRIVATE` | Access your private playlists. |
| `PLAYLIST-READ-COLLABORATIVE` | Access your collaborative playlists. |
| `PLAYLIST-MODIFY-PUBLIC` | Manage your public playlists. |
| `PLAYLIST-MODIFY-PRIVATE` | Manage your private playlists. |
| `USER-LIBRARY-READ` | Access your saved content. |
| `USER-LIBRARY-MODIFY` | Manage your saved content. |
| `USER-READ-PRIVATE` | Access your subscription details. |
| `USER-READ-EMAIL` | Get your real email address. |
| `USER-FOLLOW-READ` | Access your followers and who you are following. |
| `USER-FOLLOW-MODIFY` | Manage your saved content. |
| `USER-TOP-READ` | Read your top artists and content. |
| `USER-READ-PLAYBACK-POSITION` | Read your position in content you have played. |
| `USER-READ-PLAYBACK-STATE` | Read your currently playing content and Spotify Connect devices information. |
| `USER-READ-RECENTLY-PLAYED` | Access your recently played items. |
| `USER-READ-CURRENTLY-PLAYING` | Read your currently playing content. |
| `USER-MODIFY-PLAYBACK-STATE` | Control playback on your Spotify clients and Spotify Connect devices. |
| `UGC-IMAGE-UPLOAD` | Upload images to Spotify on your behalf. |
| `STREAMING` | Play content and control playback on your other devices. |

### Refreshing the token

An access token may expire after sometime. To extend its lifetime, you must refresh the token.

```csharp
if (authManager.IsTokenExpired())
{
    try
    {
        OAuthToken token = authManager.RefreshToken();
        // re-instantiate the client with OAuth token
        client = client.ToBuilder()
            .AuthorizationCodeAuth(
                client.AuthorizationCodeAuthModel.ToBuilder()
                    .OAuthToken(token)
                    .Build())
            .Build();
    }
    catch (ApiException e)
    {
        // TODO Handle exception
    }
}
```

If a token expires, an exception will be thrown before the next endpoint call requiring authentication.

### Storing an access token for reuse

It is recommended that you store the access token for reuse.

```csharp
// store token
SaveTokenToDatabase(client.AuthorizationCodeAuth.OAuthToken);
```

### Creating a client from a stored token

To authorize a client using a stored access token, just set the access token in Configuration along with the other configuration parameters before creating the client:

```csharp
// load token later
OAuthToken token = LoadTokenFromDatabase();

// re-instantiate the client with OAuth token
SpotifyWebAPIClient client = client.ToBuilder()
    .AuthorizationCodeAuth(
        client.AuthorizationCodeAuthModel.ToBuilder()
            .OAuthToken(token)
            .Build())
    .Build();
```

### Complete example



```csharp
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Models;
using SpotifyWebAPI.Standard.Exceptions;
using SpotifyWebAPI.Standard.Authentication;
using System.Collections.Generic;
namespace OAuthTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SpotifyWebAPIClient client = new SpotifyWebAPIClient.Builder()
                .AuthorizationCodeAuth(
                    new AuthorizationCodeAuthModel.Builder(
                        "OAuthClientId",
                        "OAuthClientSecret",
                        "OAuthRedirectUri"
                    )
                    .OAuthScopes(
                        new List<OAuthScopeEnum>
                        {
                            OAuthScopeEnum.AppRemoteControl,
                            OAuthScopeEnum.PlaylistReadPrivate,
                        })
                    .Build())
                .Environment(SpotifyWebAPI.Standard.Environment.Production)
                .LoggingConfig(config => config
                    .LogLevel(LogLevel.Information)
                    .RequestConfig(reqConfig => reqConfig.Body(true))
                    .ResponseConfig(respConfig => respConfig.Headers(true))
                )
                .Build();
            try
            {
                OAuthToken token = LoadTokenFromDatabase();

                // Set the token if it is not set before
                if (token == null)
                {
                    var authManager = client.AuthorizationCodeAuth;
                    string authUrl = await authManager.BuildAuthorizationUrl();
                    string authorizationCode = GetAuthorizationCode(authUrl);
                    token = authManager.FetchToken(authorizationCode);
                }

                SaveTokenToDatabase(token);
                // re-instantiate the client with OAuth token
                client = client.ToBuilder()
                    .AuthorizationCodeAuth(
                        client.AuthorizationCodeAuthModel.ToBuilder()
                            .OAuthToken(token)
                            .Build())
                    .Build();
            }
            catch (OAuthProviderException e)
            {
                // TODO Handle exception
            }
        }

        private static string GetAuthorizationCode(string authUrl)
        {
            // TODO Open the given auth URL, give access and return authorization code from redirect URL
            return string.Empty;
        }

        private static void SaveTokenToDatabase(OAuthToken token)
        {
            //Save token here
        }

        private static OAuthToken LoadTokenFromDatabase()
        {
            OAuthToken token = null;
            //token = Get token here
            return token;
        }
    }
}

// the client is now authorized and you can use controllers to make endpoint calls
```


