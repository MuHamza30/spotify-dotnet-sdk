# Episodes

```csharp
EpisodesController episodesController = client.EpisodesController;
```

## Class Name

`EpisodesController`

## Methods

* [Get-an-Episode](../../doc/controllers/episodes.md#get-an-episode)
* [Get-Multiple-Episodes](../../doc/controllers/episodes.md#get-multiple-episodes)
* [Get-Users-Saved-Episodes](../../doc/controllers/episodes.md#get-users-saved-episodes)
* [Save-Episodes-User](../../doc/controllers/episodes.md#save-episodes-user)
* [Remove-Episodes-User](../../doc/controllers/episodes.md#remove-episodes-user)
* [Check-Users-Saved-Episodes](../../doc/controllers/episodes.md#check-users-saved-episodes)


# Get-an-Episode

Get Spotify catalog information for a single episode identified by its
unique Spotify ID.

```csharp
GetAnEpisodeAsync(
    string id,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-read-playback-position`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.EpisodeObject](../../doc/models/episode-object.md).

## Example Usage

```csharp
string id = "512ojhOuo1ktJprKbVcKyQ";
string market = "ES";
try
{
    ApiResponse<EpisodeObject> result = await episodesController.GetAnEpisodeAsync(
        id,
        market
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |


# Get-Multiple-Episodes

Get Spotify catalog information for several episodes based on their Spotify IDs.

```csharp
GetMultipleEpisodesAsync(
    string ids,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `market` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-read-playback-position`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyEpisodes](../../doc/models/many-episodes.md).

## Example Usage

```csharp
string ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";
string market = "ES";
try
{
    ApiResponse<ManyEpisodes> result = await episodesController.GetMultipleEpisodesAsync(
        ids,
        market
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |


# Get-Users-Saved-Episodes

Get a list of the episodes saved in the current Spotify user's library.<br/>
This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).

```csharp
GetUsersSavedEpisodesAsync(
    string market = null,
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `market` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Requires scope

### oauth_2_0

`user-library-read`, `user-read-playback-position`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingSavedEpisodeObject](../../doc/models/paging-saved-episode-object.md).

## Example Usage

```csharp
string market = "ES";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingSavedEpisodeObject> result = await episodesController.GetUsersSavedEpisodesAsync(
        market,
        limit,
        offset
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |


# Save-Episodes-User

Save one or more episodes to the current user's library.<br/>
This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).

```csharp
SaveEpisodesUserAsync(
    string ids,
    Models.MeEpisodesRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeEpisodesRequest`](../../doc/models/me-episodes-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-library-modify`

## Response Type

`Task`

## Example Usage

```csharp
string ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";
try
{
    await episodesController.SaveEpisodesUserAsync(ids);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |


# Remove-Episodes-User

Remove one or more episodes from the current user's library.<br/>
This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).

```csharp
RemoveEpisodesUserAsync(
    string ids,
    Models.MeEpisodesRequest1 body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeEpisodesRequest1`](../../doc/models/me-episodes-request-1.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-library-modify`

## Response Type

`Task`

## Example Usage

```csharp
string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
try
{
    await episodesController.RemoveEpisodesUserAsync(ids);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |


# Check-Users-Saved-Episodes

Check if one or more episodes is already saved in the current Spotify user's 'Your Episodes' library.<br/>
This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer)..

```csharp
CheckUsersSavedEpisodesAsync(
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |

## Requires scope

### oauth_2_0

`user-library-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type List<bool>.

## Example Usage

```csharp
string ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";
try
{
    ApiResponse<List<bool>> result = await episodesController.CheckUsersSavedEpisodesAsync(ids);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response

```
[
  false,
  true
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |

