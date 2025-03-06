# Shows

```csharp
ShowsController showsController = client.ShowsController;
```

## Class Name

`ShowsController`

## Methods

* [Get-a-Show](../../doc/controllers/shows.md#get-a-show)
* [Get-Multiple-Shows](../../doc/controllers/shows.md#get-multiple-shows)
* [Get-a-Shows-Episodes](../../doc/controllers/shows.md#get-a-shows-episodes)
* [Get-Users-Saved-Shows](../../doc/controllers/shows.md#get-users-saved-shows)
* [Save-Shows-User](../../doc/controllers/shows.md#save-shows-user)
* [Remove-Shows-User](../../doc/controllers/shows.md#remove-shows-user)
* [Check-Users-Saved-Shows](../../doc/controllers/shows.md#check-users-saved-shows)


# Get-a-Show

Get Spotify catalog information for a single show identified by its
unique Spotify ID.

```csharp
GetAShowAsync(
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

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ShowObject](../../doc/models/show-object.md).

## Example Usage

```csharp
string id = "38bS44xjbVVZ3No3ByF1dJ";
string market = "ES";
try
{
    ApiResponse<ShowObject> result = await showsController.GetAShowAsync(
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


# Get-Multiple-Shows

Get Spotify catalog information for several shows based on their Spotify IDs.

```csharp
GetMultipleShowsAsync(
    string ids,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManySimplifiedShows](../../doc/models/many-simplified-shows.md).

## Example Usage

```csharp
string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
string market = "ES";
try
{
    ApiResponse<ManySimplifiedShows> result = await showsController.GetMultipleShowsAsync(
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


# Get-a-Shows-Episodes

Get Spotify catalog information about an show’s episodes. Optional parameters can be used to limit the number of episodes returned.

```csharp
GetAShowsEpisodesAsync(
    string id,
    string market = null,
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Requires scope

### oauth_2_0

`user-read-playback-position`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingSimplifiedEpisodeObject](../../doc/models/paging-simplified-episode-object.md).

## Example Usage

```csharp
string id = "38bS44xjbVVZ3No3ByF1dJ";
string market = "ES";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingSimplifiedEpisodeObject> result = await showsController.GetAShowsEpisodesAsync(
        id,
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


# Get-Users-Saved-Shows

Get a list of shows saved in the current Spotify user's library. Optional parameters can be used to limit the number of shows returned.

```csharp
GetUsersSavedShowsAsync(
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Requires scope

### oauth_2_0

`user-library-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingSavedShowObject](../../doc/models/paging-saved-show-object.md).

## Example Usage

```csharp
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingSavedShowObject> result = await showsController.GetUsersSavedShowsAsync(
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


# Save-Shows-User

Save one or more shows to current Spotify user's library.

```csharp
SaveShowsUserAsync(
    string ids,
    Models.MeShowsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeShowsRequest`](../../doc/models/me-shows-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-library-modify`

## Response Type

`Task`

## Example Usage

```csharp
string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
try
{
    await showsController.SaveShowsUserAsync(ids);
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


# Remove-Shows-User

Delete one or more shows from current Spotify user's library.

```csharp
RemoveShowsUserAsync(
    string ids,
    string market = null,
    Models.MeShowsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `market` | `string` | Query, Optional | - |
| `body` | [`MeShowsRequest`](../../doc/models/me-shows-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-library-modify`

## Response Type

`Task`

## Example Usage

```csharp
string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
string market = "ES";
try
{
    await showsController.RemoveShowsUserAsync(
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


# Check-Users-Saved-Shows

Check if one or more shows is already saved in the current Spotify user's library.

```csharp
CheckUsersSavedShowsAsync(
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
string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
try
{
    ApiResponse<List<bool>> result = await showsController.CheckUsersSavedShowsAsync(ids);
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

