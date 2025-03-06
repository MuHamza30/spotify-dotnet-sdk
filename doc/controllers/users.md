# Users

```csharp
UsersController usersController = client.UsersController;
```

## Class Name

`UsersController`

## Methods

* [Get-Current-Users-Profile](../../doc/controllers/users.md#get-current-users-profile)
* [Get-Users-Profile](../../doc/controllers/users.md#get-users-profile)
* [Follow-Playlist](../../doc/controllers/users.md#follow-playlist)
* [Unfollow-Playlist](../../doc/controllers/users.md#unfollow-playlist)
* [Get-Followed](../../doc/controllers/users.md#get-followed)
* [Follow-Artists-Users](../../doc/controllers/users.md#follow-artists-users)
* [Unfollow-Artists-Users](../../doc/controllers/users.md#unfollow-artists-users)
* [Check-Current-User-Follows](../../doc/controllers/users.md#check-current-user-follows)
* [Check-If-User-Follows-Playlist](../../doc/controllers/users.md#check-if-user-follows-playlist)
* [Get-Users-Top-Artists](../../doc/controllers/users.md#get-users-top-artists)
* [Get-Users-Top-Tracks](../../doc/controllers/users.md#get-users-top-tracks)


# Get-Current-Users-Profile

Get detailed profile information about the current user (including the
current user's username).

```csharp
GetCurrentUsersProfileAsync()
```

## Requires scope

### oauth_2_0

`user-read-email`, `user-read-private`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PrivateUserObject](../../doc/models/private-user-object.md).

## Example Usage

```csharp
try
{
    ApiResponse<PrivateUserObject> result = await usersController.GetCurrentUsersProfileAsync();
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


# Get-Users-Profile

Get public profile information about a Spotify user.

```csharp
GetUsersProfileAsync(
    string userId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `userId` | `string` | Template, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PublicUserObject](../../doc/models/public-user-object.md).

## Example Usage

```csharp
string userId = "smedjan";
try
{
    ApiResponse<PublicUserObject> result = await usersController.GetUsersProfileAsync(userId);
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


# Follow-Playlist

Add the current user as a follower of a playlist.

```csharp
FollowPlaylistAsync(
    string playlistId,
    Models.PlaylistsFollowersRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `body` | [`PlaylistsFollowersRequest`](../../doc/models/playlists-followers-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

`Task`

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
PlaylistsFollowersRequest body = new PlaylistsFollowersRequest
{
    MPublic = false,
};

try
{
    await usersController.FollowPlaylistAsync(
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


# Unfollow-Playlist

Remove the current user as a follower of a playlist.

```csharp
UnfollowPlaylistAsync(
    string playlistId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |

## Requires scope

### oauth_2_0

`playlist-modify-private`, `playlist-modify-public`

## Response Type

`Task`

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
try
{
    await usersController.UnfollowPlaylistAsync(playlistId);
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


# Get-Followed

Get the current user's followed artists.

```csharp
GetFollowedAsync(
    Models.ItemType1Enum type,
    string after = null,
    int? limit = 20)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `type` | [`ItemType1Enum`](../../doc/models/item-type-1-enum.md) | Query, Required | - |
| `after` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |

## Requires scope

### oauth_2_0

`user-follow-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.CursorPagedArtists](../../doc/models/cursor-paged-artists.md).

## Example Usage

```csharp
ItemType1Enum type = ItemType1Enum.Artist;
string after = "0I2XqVXqHScXjHhk6AYYRe";
int? limit = 10;
try
{
    ApiResponse<CursorPagedArtists> result = await usersController.GetFollowedAsync(
        type,
        after,
        limit
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


# Follow-Artists-Users

Add the current user as a follower of one or more artists or other Spotify users.

```csharp
FollowArtistsUsersAsync(
    Models.ItemType2Enum type,
    string ids,
    Models.MeFollowingRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `type` | [`ItemType2Enum`](../../doc/models/item-type-2-enum.md) | Query, Required | - |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeFollowingRequest`](../../doc/models/me-following-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-follow-modify`

## Response Type

`Task`

## Example Usage

```csharp
ItemType2Enum type = ItemType2Enum.Artist;
string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
try
{
    await usersController.FollowArtistsUsersAsync(
        type,
        ids
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


# Unfollow-Artists-Users

Remove the current user as a follower of one or more artists or other Spotify users.

```csharp
UnfollowArtistsUsersAsync(
    Models.ItemType3Enum type,
    string ids,
    Models.MeFollowingRequest1 body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `type` | [`ItemType3Enum`](../../doc/models/item-type-3-enum.md) | Query, Required | - |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeFollowingRequest1`](../../doc/models/me-following-request-1.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-follow-modify`

## Response Type

`Task`

## Example Usage

```csharp
ItemType3Enum type = ItemType3Enum.Artist;
string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
try
{
    await usersController.UnfollowArtistsUsersAsync(
        type,
        ids
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


# Check-Current-User-Follows

Check to see if the current user is following one or more artists or other Spotify users.

```csharp
CheckCurrentUserFollowsAsync(
    Models.ItemType3Enum type,
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `type` | [`ItemType3Enum`](../../doc/models/item-type-3-enum.md) | Query, Required | - |
| `ids` | `string` | Query, Required | - |

## Requires scope

### oauth_2_0

`user-follow-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type List<bool>.

## Example Usage

```csharp
ItemType3Enum type = ItemType3Enum.Artist;
string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
try
{
    ApiResponse<List<bool>> result = await usersController.CheckCurrentUserFollowsAsync(
        type,
        ids
    );
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


# Check-If-User-Follows-Playlist

Check to see if one or more Spotify users are following a specified playlist.

```csharp
CheckIfUserFollowsPlaylistAsync(
    string playlistId,
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `playlistId` | `string` | Template, Required | - |
| `ids` | `string` | Query, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type List<bool>.

## Example Usage

```csharp
string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
string ids = "jmperezperez,thelinmichael,wizzler";
try
{
    ApiResponse<List<bool>> result = await usersController.CheckIfUserFollowsPlaylistAsync(
        playlistId,
        ids
    );
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


# Get-Users-Top-Artists

Get the current user's top artists based on calculated affinity.

```csharp
GetUsersTopArtistsAsync(
    string timeRange = "medium_term",
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `timeRange` | `string` | Query, Optional | **Default**: `"medium_term"` |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Requires scope

### oauth_2_0

`user-top-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingArtistObject](../../doc/models/paging-artist-object.md).

## Example Usage

```csharp
string timeRange = "medium_term";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingArtistObject> result = await usersController.GetUsersTopArtistsAsync(
        timeRange,
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


# Get-Users-Top-Tracks

Get the current user's top tracks based on calculated affinity.

```csharp
GetUsersTopTracksAsync(
    string timeRange = "medium_term",
    int? limit = 20,
    int? offset = 0)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `timeRange` | `string` | Query, Optional | **Default**: `"medium_term"` |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0` |

## Requires scope

### oauth_2_0

`user-top-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingTrackObject](../../doc/models/paging-track-object.md).

## Example Usage

```csharp
string timeRange = "medium_term";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingTrackObject> result = await usersController.GetUsersTopTracksAsync(
        timeRange,
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

