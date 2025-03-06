# Artists

```csharp
ArtistsController artistsController = client.ArtistsController;
```

## Class Name

`ArtistsController`

## Methods

* [Get-an-Artist](../../doc/controllers/artists.md#get-an-artist)
* [Get-Multiple-Artists](../../doc/controllers/artists.md#get-multiple-artists)
* [Get-an-Artists-Albums](../../doc/controllers/artists.md#get-an-artists-albums)
* [Get-an-Artists-Top-Tracks](../../doc/controllers/artists.md#get-an-artists-top-tracks)
* [Get-an-Artists-Related-Artists](../../doc/controllers/artists.md#get-an-artists-related-artists)


# Get-an-Artist

Get Spotify catalog information for a single artist identified by their unique Spotify ID.

```csharp
GetAnArtistAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ArtistObject](../../doc/models/artist-object.md).

## Example Usage

```csharp
string id = "0TnOYISbd1XYRBk9myaseg";
try
{
    ApiResponse<ArtistObject> result = await artistsController.GetAnArtistAsync(id);
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


# Get-Multiple-Artists

Get Spotify catalog information for several artists based on their Spotify IDs.

```csharp
GetMultipleArtistsAsync(
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyArtists](../../doc/models/many-artists.md).

## Example Usage

```csharp
string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
try
{
    ApiResponse<ManyArtists> result = await artistsController.GetMultipleArtistsAsync(ids);
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


# Get-an-Artists-Albums

Get Spotify catalog information about an artist's albums.

```csharp
GetAnArtistsAlbumsAsync(
    string id,
    string includeGroups = null,
    string market = null,
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `includeGroups` | `string` | Query, Optional | - |
| `market` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingArtistDiscographyAlbumObject](../../doc/models/paging-artist-discography-album-object.md).

## Example Usage

```csharp
string id = "0TnOYISbd1XYRBk9myaseg";
string includeGroups = "single,appears_on";
string market = "ES";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingArtistDiscographyAlbumObject> result = await artistsController.GetAnArtistsAlbumsAsync(
        id,
        includeGroups,
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


# Get-an-Artists-Top-Tracks

Get Spotify catalog information about an artist's top tracks by country.

```csharp
GetAnArtistsTopTracksAsync(
    string id,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyTracks](../../doc/models/many-tracks.md).

## Example Usage

```csharp
string id = "0TnOYISbd1XYRBk9myaseg";
string market = "ES";
try
{
    ApiResponse<ManyTracks> result = await artistsController.GetAnArtistsTopTracksAsync(
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


# Get-an-Artists-Related-Artists

Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the Spotify community's listening history.

```csharp
GetAnArtistsRelatedArtistsAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyArtists](../../doc/models/many-artists.md).

## Example Usage

```csharp
string id = "0TnOYISbd1XYRBk9myaseg";
try
{
    ApiResponse<ManyArtists> result = await artistsController.GetAnArtistsRelatedArtistsAsync(id);
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

