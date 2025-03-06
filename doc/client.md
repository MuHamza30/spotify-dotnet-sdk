
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `LogBuilder` | [`LogBuilder`](log-builder.md) | Represents the logging configuration builder for API calls |
| `AuthorizationCodeAuth` | [`AuthorizationCodeAuth`](auth/oauth-2-authorization-code-grant.md) | The Credentials Setter for OAuth 2 Authorization Code Grant |

The API client can be initialized as follows:

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
    .Environment(SpotifyWebAPI.Standard.Environment.Production)
    .LoggingConfig(config => config
        .LogLevel(LogLevel.Information)
        .RequestConfig(reqConfig => reqConfig.Body(true))
        .ResponseConfig(respConfig => respConfig.Headers(true))
    )
    .Build();
```

## Spotify Web APIClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| AlbumsController | Gets AlbumsController controller. |
| ArtistsController | Gets ArtistsController controller. |
| AudiobooksController | Gets AudiobooksController controller. |
| CategoriesController | Gets CategoriesController controller. |
| ChaptersController | Gets ChaptersController controller. |
| EpisodesController | Gets EpisodesController controller. |
| GenresController | Gets GenresController controller. |
| MarketsController | Gets MarketsController controller. |
| PlayerController | Gets PlayerController controller. |
| PlaylistsController | Gets PlaylistsController controller. |
| SearchController | Gets SearchController controller. |
| ShowsController | Gets ShowsController controller. |
| TracksController | Gets TracksController controller. |
| UsersController | Gets UsersController controller. |
| OAuthAuthorizationController | Gets OAuthAuthorizationController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | [`IHttpClientConfiguration`](http-client-configuration.md) |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |
| AuthorizationCodeAuth | Gets the credentials to use with AuthorizationCodeAuth. | [`IAuthorizationCodeAuth`](auth/oauth-2-authorization-code-grant.md) |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Spotify Web APIClient using the values provided for the builder. | `Builder` |

## Spotify Web APIClient Builder Class

Class to build instances of Spotify Web APIClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<`[`HttpClientConfiguration.Builder`](http-client-configuration-builder.md)`> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `AuthorizationCodeAuth(Action<AuthorizationCodeAuthModel.Builder> action)` | Sets credentials for AuthorizationCodeAuth. | `Builder` |

