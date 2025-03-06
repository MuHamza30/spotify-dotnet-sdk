# Playlists

```csharp
PlaylistsController playlistsController = client.PlaylistsController;
```

## Class Name

`PlaylistsController`

## Methods

* [Get-Playlist](../../doc/controllers/playlists.md#get-playlist)
* [Change-Playlist-Details](../../doc/controllers/playlists.md#change-playlist-details)
* [Get-Playlists-Tracks](../../doc/controllers/playlists.md#get-playlists-tracks)
* [Add-Tracks-to-Playlist](../../doc/controllers/playlists.md#add-tracks-to-playlist)
* [Reorder-or-Replace-Playlists-Tracks](../../doc/controllers/playlists.md#reorder-or-replace-playlists-tracks)
* [Remove-Tracks-Playlist](../../doc/controllers/playlists.md#remove-tracks-playlist)
* [Get-a-List-of-Current-Users-Playlists](../../doc/controllers/playlists.md#get-a-list-of-current-users-playlists)
* [Get-List-Users-Playlists](../../doc/controllers/playlists.md#get-list-users-playlists)
* [Create-Playlist](../../doc/controllers/playlists.md#create-playlist)
* [Get-Featured-Playlists](../../doc/controllers/playlists.md#get-featured-playlists)
* [Get-a-Categories-Playlists](../../doc/controllers/playlists.md#get-a-categories-playlists)
* [Get-Playlist-Cover](../../doc/controllers/playlists.md#get-playlist-cover)
* [Upload-Custom-Playlist-Cover](../../doc/controllers/playlists.md#upload-custom-playlist-cover)


# Get-Playlist

Get a playlist owned by a Spotify user.

```csharp
GetPlaylistAsync(
    string playlistId,
    string market = null,
    string fields = null,
    string additionalTypes = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |
| `fields` | `string` | Query, Optional | - |
| `additionalTypes` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PlaylistObject](../../doc/models/playlist-object.md).

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
string market = "ES";
string fields = "items(added_by.id,track(name,href,album(name,href)))";
try
{
    ApiResponse<PlaylistObject> result = await playlistsController.GetPlaylistAsync(
        playlistId,
        market,
        fields
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


# Change-Playlist-Details

Change a playlist's name and public/private state. (The user must, of
course, own the playlist.)

```csharp
ChangePlaylistDetailsAsync(
    string playlistId,
    Models.PlaylistsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `body` | [`PlaylistsRequest`](../../doc/models/playlists-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

`Task`

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
PlaylistsRequest body = new PlaylistsRequest
{
    Name = "Updated Playlist Name",
    MPublic = false,
    Description = "Updated playlist description",
};

try
{
    await playlistsController.ChangePlaylistDetailsAsync(
        playlistId,
        body
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


# Get-Playlists-Tracks

Get full details of the items of a playlist owned by a Spotify user.

```csharp
GetPlaylistsTracksAsync(
    string playlistId,
    string market = null,
    string fields = null,
    int? limit = 20,
    int? offset = 0,
    string additionalTypes = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |
| `fields` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 100` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |
| `additionalTypes` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`playlist-read-private`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingPlaylistTrackObject](../../doc/models/paging-playlist-track-object.md).

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
string market = "ES";
string fields = "items(added_by.id,track(name,href,album(name,href)))";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingPlaylistTrackObject> result = await playlistsController.GetPlaylistsTracksAsync(
        playlistId,
        market,
        fields,
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


# Add-Tracks-to-Playlist

Add one or more items to a user's playlist.

```csharp
AddTracksToPlaylistAsync(
    string playlistId,
    int? position = null,
    string uris = null,
    Models.PlaylistsTracksRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `position` | `int?` | Query, Optional | - |
| `uris` | `string` | Query, Optional | - |
| `body` | [`PlaylistsTracksRequest`](../../doc/models/playlists-tracks-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PlaylistSnapshotId](../../doc/models/playlist-snapshot-id.md).

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
int? position = 0;
string uris = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh,spotify:track:1301WleyT98MSxVHPZCA6M";
try
{
    ApiResponse<PlaylistSnapshotId> result = await playlistsController.AddTracksToPlaylistAsync(
        playlistId,
        position,
        uris
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


# Reorder-or-Replace-Playlists-Tracks

Either reorder or replace items in a playlist depending on the request's parameters.
To reorder items, include `range_start`, `insert_before`, `range_length` and `snapshot_id` in the request's body.
To replace items, include `uris` as either a query parameter or in the request's body.
Replacing items in a playlist will overwrite its existing items. This operation can be used for replacing or clearing items in a playlist.
<br/>
**Note**: Replace and reorder are mutually exclusive operations which share the same endpoint, but have different parameters.
These operations can't be applied together in a single request.

```csharp
ReorderOrReplacePlaylistsTracksAsync(
    string playlistId,
    string uris = null,
    Models.PlaylistsTracksRequest1 body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `uris` | `string` | Query, Optional | - |
| `body` | [`PlaylistsTracksRequest1`](../../doc/models/playlists-tracks-request-1.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PlaylistSnapshotId](../../doc/models/playlist-snapshot-id.md).

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
PlaylistsTracksRequest1 body = new PlaylistsTracksRequest1
{
    RangeStart = 1,
    InsertBefore = 3,
    RangeLength = 2,
};

try
{
    ApiResponse<PlaylistSnapshotId> result = await playlistsController.ReorderOrReplacePlaylistsTracksAsync(
        playlistId,
        null,
        body
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


# Remove-Tracks-Playlist

Remove one or more items from a user's playlist.

```csharp
RemoveTracksPlaylistAsync(
    string playlistId,
    Models.PlaylistsTracksRequest2 body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `body` | [`PlaylistsTracksRequest2`](../../doc/models/playlists-tracks-request-2.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PlaylistSnapshotId](../../doc/models/playlist-snapshot-id.md).

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
PlaylistsTracksRequest2 body = new PlaylistsTracksRequest2
{
    Tracks = new List<Track1>
    {
        new Track1
        {
        },
    },
};

try
{
    ApiResponse<PlaylistSnapshotId> result = await playlistsController.RemoveTracksPlaylistAsync(
        playlistId,
        body
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


# Get-a-List-of-Current-Users-Playlists

Get a list of the playlists owned or followed by the current Spotify
user.

```csharp
GetAListOfCurrentUsersPlaylistsAsync(
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

`playlist-read-private`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingPlaylistObject](../../doc/models/paging-playlist-object.md).

## Example Usage

```csharp
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingPlaylistObject> result = await playlistsController.GetAListOfCurrentUsersPlaylistsAsync(
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


# Get-List-Users-Playlists

Get a list of the playlists owned or followed by a Spotify user.

```csharp
GetListUsersPlaylistsAsync(
    string userId,
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Requires scope

### oauth_2_0

`playlist-read-collaborative`, `playlist-read-private`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingPlaylistObject](../../doc/models/paging-playlist-object.md).

## Example Usage

```csharp
string userId = "smedjan";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingPlaylistObject> result = await playlistsController.GetListUsersPlaylistsAsync(
        userId,
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


# Create-Playlist

Create a playlist for a Spotify user. (The playlist will be empty until
you [add tracks](/documentation/web-api/reference/add-tracks-to-playlist).)
Each user is generally limited to a maximum of 11000 playlists.

```csharp
CreatePlaylistAsync(
    string userId,
    Models.UsersPlaylistsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | - |
| `body` | [`UsersPlaylistsRequest`](../../doc/models/users-playlists-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PlaylistObject](../../doc/models/playlist-object.md).

## Example Usage

```csharp
string userId = "smedjan";
UsersPlaylistsRequest body = new UsersPlaylistsRequest
{
    Name = "New Playlist",
    MPublic = false,
    Description = "New playlist description",
};

try
{
    ApiResponse<PlaylistObject> result = await playlistsController.CreatePlaylistAsync(
        userId,
        body
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


# Get-Featured-Playlists

Get a list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab).

```csharp
GetFeaturedPlaylistsAsync(
    string locale = null,
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locale` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingFeaturedPlaylistObject](../../doc/models/paging-featured-playlist-object.md).

## Example Usage

```csharp
string locale = "sv_SE";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingFeaturedPlaylistObject> result = await playlistsController.GetFeaturedPlaylistsAsync(
        locale,
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


# Get-a-Categories-Playlists

Get a list of Spotify playlists tagged with a particular category.

```csharp
GetACategoriesPlaylistsAsync(
    string categoryId,
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `categoryId` | `string` | Template, Required | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingFeaturedPlaylistObject](../../doc/models/paging-featured-playlist-object.md).

## Example Usage

```csharp
string categoryId = "dinner";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingFeaturedPlaylistObject> result = await playlistsController.GetACategoriesPlaylistsAsync(
        categoryId,
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


# Get-Playlist-Cover

Get the current image associated with a specific playlist.

```csharp
GetPlaylistCoverAsync(
    string playlistId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [List<Models.ImageObject>](../../doc/models/image-object.md).

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
try
{
    ApiResponse<List<ImageObject>> result = await playlistsController.GetPlaylistCoverAsync(playlistId);
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


# Upload-Custom-Playlist-Cover

Replace the image used to represent a specific playlist.

```csharp
UploadCustomPlaylistCoverAsync(
    string playlistId,
    object body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `body` | `object` | Body, Required | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`, `ugc-image-upload`

## Response Type

`Task`

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
object body = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}");
try
{
    await playlistsController.UploadCustomPlaylistCoverAsync(
        playlistId,
        body
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

