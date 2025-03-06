# Player

```csharp
PlayerController playerController = client.PlayerController;
```

## Class Name

`PlayerController`

## Methods

* [Get-Information-About-the-Users-Current-Playback](../../doc/controllers/player.md#get-information-about-the-users-current-playback)
* [Transfer-a-Users-Playback](../../doc/controllers/player.md#transfer-a-users-playback)
* [Get-a-Users-Available-Devices](../../doc/controllers/player.md#get-a-users-available-devices)
* [Get-the-Users-Currently-Playing-Track](../../doc/controllers/player.md#get-the-users-currently-playing-track)
* [Start-a-Users-Playback](../../doc/controllers/player.md#start-a-users-playback)
* [Pause-a-Users-Playback](../../doc/controllers/player.md#pause-a-users-playback)
* [Skip-Users-Playback-to-Next-Track](../../doc/controllers/player.md#skip-users-playback-to-next-track)
* [Skip-Users-Playback-to-Previous-Track](../../doc/controllers/player.md#skip-users-playback-to-previous-track)
* [Seek-to-Position-in-Currently-Playing-Track](../../doc/controllers/player.md#seek-to-position-in-currently-playing-track)
* [Set-Repeat-Mode-on-Users-Playback](../../doc/controllers/player.md#set-repeat-mode-on-users-playback)
* [Set-Volume-for-Users-Playback](../../doc/controllers/player.md#set-volume-for-users-playback)
* [Toggle-Shuffle-for-Users-Playback](../../doc/controllers/player.md#toggle-shuffle-for-users-playback)
* [Get-Recently-Played](../../doc/controllers/player.md#get-recently-played)
* [Get-Queue](../../doc/controllers/player.md#get-queue)
* [Add-to-Queue](../../doc/controllers/player.md#add-to-queue)


# Get-Information-About-the-Users-Current-Playback

Get information about the user’s current playback state, including track or episode, progress, and active device.

```csharp
GetInformationAboutTheUsersCurrentPlaybackAsync(
    string market = null,
    string additionalTypes = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `market` | `string` | Query, Optional | - |
| `additionalTypes` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-read-playback-state`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.CurrentlyPlayingContextObject](../../doc/models/currently-playing-context-object.md).

## Example Usage

```csharp
string market = "ES";
try
{
    ApiResponse<CurrentlyPlayingContextObject> result = await playerController.GetInformationAboutTheUsersCurrentPlaybackAsync(market);
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


# Transfer-a-Users-Playback

Transfer playback to a new device and optionally begin playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
TransferAUsersPlaybackAsync(
    Models.MePlayerRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`MePlayerRequest`](../../doc/models/me-player-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
MePlayerRequest body = new MePlayerRequest
{
    DeviceIds = new List<string>
    {
        "74ASZWbe4lXaubB36ztrGX",
    },
};

try
{
    await playerController.TransferAUsersPlaybackAsync(body);
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


# Get-a-Users-Available-Devices

Get information about a user’s available Spotify Connect devices. Some device models are not supported and will not be listed in the API response.

```csharp
GetAUsersAvailableDevicesAsync()
```

## Requires scope

### oauth_2_0

`user-read-playback-state`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyDevices](../../doc/models/many-devices.md).

## Example Usage

```csharp
try
{
    ApiResponse<ManyDevices> result = await playerController.GetAUsersAvailableDevicesAsync();
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


# Get-the-Users-Currently-Playing-Track

Get the object currently being played on the user's Spotify account.

```csharp
GetTheUsersCurrentlyPlayingTrackAsync(
    string market = null,
    string additionalTypes = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `market` | `string` | Query, Optional | - |
| `additionalTypes` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-read-currently-playing`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.CurrentlyPlayingObject](../../doc/models/currently-playing-object.md).

## Example Usage

```csharp
string market = "ES";
try
{
    ApiResponse<CurrentlyPlayingObject> result = await playerController.GetTheUsersCurrentlyPlayingTrackAsync(market);
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


# Start-a-Users-Playback

Start a new context or resume current playback on the user's active device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
StartAUsersPlaybackAsync(
    string deviceId = null,
    Models.MePlayerPlayRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `deviceId` | `string` | Query, Optional | - |
| `body` | [`MePlayerPlayRequest`](../../doc/models/me-player-play-request.md) | Body, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
MePlayerPlayRequest body = new MePlayerPlayRequest
{
    ContextUri = "spotify:album:5ht7ItJgpBH7W6vJ5BqpPr",
    Offset = ApiHelper.JsonDeserialize<object>("{\"position\":5}"),
    PositionMs = 0,
};

try
{
    await playerController.StartAUsersPlaybackAsync(
        deviceId,
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


# Pause-a-Users-Playback

Pause playback on the user's account. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
PauseAUsersPlaybackAsync(
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.PauseAUsersPlaybackAsync(deviceId);
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


# Skip-Users-Playback-to-Next-Track

Skips to next track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
SkipUsersPlaybackToNextTrackAsync(
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.SkipUsersPlaybackToNextTrackAsync(deviceId);
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


# Skip-Users-Playback-to-Previous-Track

Skips to previous track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
SkipUsersPlaybackToPreviousTrackAsync(
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.SkipUsersPlaybackToPreviousTrackAsync(deviceId);
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


# Seek-to-Position-in-Currently-Playing-Track

Seeks to the given position in the user’s currently playing track. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
SeekToPositionInCurrentlyPlayingTrackAsync(
    int positionMs,
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `positionMs` | `int` | Query, Required | - |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
int positionMs = 25000;
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.SeekToPositionInCurrentlyPlayingTrackAsync(
        positionMs,
        deviceId
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


# Set-Repeat-Mode-on-Users-Playback

Set the repeat mode for the user's playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
SetRepeatModeOnUsersPlaybackAsync(
    string state,
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `state` | `string` | Query, Required | - |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
string state = "context";
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.SetRepeatModeOnUsersPlaybackAsync(
        state,
        deviceId
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


# Set-Volume-for-Users-Playback

Set the volume for the user’s current playback device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
SetVolumeForUsersPlaybackAsync(
    int volumePercent,
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `volumePercent` | `int` | Query, Required | - |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
int volumePercent = 50;
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.SetVolumeForUsersPlaybackAsync(
        volumePercent,
        deviceId
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


# Toggle-Shuffle-for-Users-Playback

Toggle shuffle on or off for user’s playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
ToggleShuffleForUsersPlaybackAsync(
    bool state,
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `state` | `bool` | Query, Required | - |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
bool state = true;
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.ToggleShuffleForUsersPlaybackAsync(
        state,
        deviceId
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


# Get-Recently-Played

Get tracks from the current user's recently played tracks.
_**Note**: Currently doesn't support podcast episodes._

```csharp
GetRecentlyPlayedAsync(
    int? limit = 20,
    long? after = null,
    int? before = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `after` | `long?` | Query, Optional | - |
| `before` | `int?` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-read-recently-played`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.CursorPagingPlayHistoryObject](../../doc/models/cursor-paging-play-history-object.md).

## Example Usage

```csharp
int? limit = 10;
long? after = 1484811043508L;
try
{
    ApiResponse<CursorPagingPlayHistoryObject> result = await playerController.GetRecentlyPlayedAsync(
        limit,
        after
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


# Get-Queue

Get the list of objects that make up the user's queue.

```csharp
GetQueueAsync()
```

## Requires scope

### oauth_2_0

`user-read-currently-playing`, `user-read-playback-state`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.QueueObject](../../doc/models/queue-object.md).

## Example Usage

```csharp
try
{
    ApiResponse<QueueObject> result = await playerController.GetQueueAsync();
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


# Add-to-Queue

Add an item to the end of the user's current playback queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.

```csharp
AddToQueueAsync(
    string uri,
    string deviceId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `uri` | `string` | Query, Required | - |
| `deviceId` | `string` | Query, Optional | - |

## Requires scope

### oauth_2_0

`user-modify-playback-state`

## Response Type

`Task`

## Example Usage

```csharp
string uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh";
string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
try
{
    await playerController.AddToQueueAsync(
        uri,
        deviceId
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

