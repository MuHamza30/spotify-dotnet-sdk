
# Getting Started with Spotify Web API

## Introduction

You can use Spotify's Web API to discover music and podcasts, manage your Spotify library, control audio playback, and much more. Browse our available Web API endpoints using the sidebar at left, or via the navigation bar on top of this page on smaller screens.

In order to make successful Web API requests your app will need a valid access token. One can be obtained through <a href="https://developer.spotify.com/documentation/general/guides/authorization-guide/">OAuth 2.0</a>.

The base URI for all Web API requests is `https://api.spotify.com/v1`.

Need help? See our <a href="https://developer.spotify.com/documentation/web-api/guides/">Web API guides</a> for more information, or visit the <a href="https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer">Spotify for Developers community forum</a> to ask questions and connect with other developers.

## Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (SpotifyWebAPI.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

The supported version is **.NET Standard 2.0**. For checking compatibility of your .NET implementation with the generated library, [click here](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions).

## Installation

The following section explains how to use the SpotifyWebAPI.Standard library in a new project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=Spotify%20Web%20API-CSharp&workspaceName=SpotifyWebAPI&projectName=SpotifyWebAPI.Standard&rootNamespace=SpotifyWebAPI.Standard&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=Spotify%20Web%20API-CSharp&workspaceName=SpotifyWebAPI&projectName=SpotifyWebAPI.Standard&rootNamespace=SpotifyWebAPI.Standard&step=createProject)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Spotify%20Web%20API-CSharp&workspaceName=SpotifyWebAPI&projectName=SpotifyWebAPI.Standard&rootNamespace=SpotifyWebAPI.Standard&step=setStartup)

### 3. Add reference of the library project

In order to use the `SpotifyWebAPI.Standard` library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Spotify%20Web%20API-CSharp&workspaceName=SpotifyWebAPI&projectName=SpotifyWebAPI.Standard&rootNamespace=SpotifyWebAPI.Standard&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `SpotifyWebAPI.Standard` and click `OK`. By doing this, we have added a reference of the `SpotifyWebAPI.Standard` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Spotify%20Web%20API-CSharp&workspaceName=SpotifyWebAPI&projectName=SpotifyWebAPI.Standard&rootNamespace=SpotifyWebAPI.Standard&step=createReference)

### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Spotify%20Web%20API-CSharp&workspaceName=SpotifyWebAPI&projectName=SpotifyWebAPI.Standard&rootNamespace=SpotifyWebAPI.Standard&step=addCode)

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `LogBuilder` | [`LogBuilder`](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/log-builder.md) | Represents the logging configuration builder for API calls |
| `AuthorizationCodeAuth` | [`AuthorizationCodeAuth`](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/auth/oauth-2-authorization-code-grant.md) | The Credentials Setter for OAuth 2 Authorization Code Grant |

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

## Authorization

This API uses the following authentication schemes.

* [`oauth_2_0 (OAuth 2 Authorization Code Grant)`](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/auth/oauth-2-authorization-code-grant.md)

## List of APIs

* [Albums](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/albums.md)
* [Artists](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/artists.md)
* [Audiobooks](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/audiobooks.md)
* [Categories](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/categories.md)
* [Chapters](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/chapters.md)
* [Episodes](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/episodes.md)
* [Genres](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/genres.md)
* [Markets](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/markets.md)
* [Player](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/player.md)
* [Playlists](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/playlists.md)
* [Search](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/search.md)
* [Shows](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/shows.md)
* [Tracks](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/tracks.md)
* [Users](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/controllers/users.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/http-request.md)
* [HttpResponse](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/http-string-response.md)
* [HttpContext](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/http-client-configuration-builder.md)
* [ApiException](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/api-exception.md)
* [ApiResponse](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/api-response.md)
* [LogBuilder](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/log-builder.md)
* [LogRequestBuilder](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/log-request-builder.md)
* [LogResponseBuilder](https://www.github.com/MuHamza30/spotify-dotnet-sdk/tree/1.0.1/doc/log-response-builder.md)

