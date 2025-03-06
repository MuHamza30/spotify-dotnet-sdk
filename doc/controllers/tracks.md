# Tracks

```csharp
TracksController tracksController = client.TracksController;
```

## Class Name

`TracksController`

## Methods

* [Get-Track](../../doc/controllers/tracks.md#get-track)
* [Get-Several-Tracks](../../doc/controllers/tracks.md#get-several-tracks)
* [Get-Users-Saved-Tracks](../../doc/controllers/tracks.md#get-users-saved-tracks)
* [Save-Tracks-User](../../doc/controllers/tracks.md#save-tracks-user)
* [Remove-Tracks-User](../../doc/controllers/tracks.md#remove-tracks-user)
* [Check-Users-Saved-Tracks](../../doc/controllers/tracks.md#check-users-saved-tracks)
* [Get-Several-Audio-Features](../../doc/controllers/tracks.md#get-several-audio-features)
* [Get-Audio-Features](../../doc/controllers/tracks.md#get-audio-features)
* [Get-Audio-Analysis](../../doc/controllers/tracks.md#get-audio-analysis)
* [Get-Recommendations](../../doc/controllers/tracks.md#get-recommendations)


# Get-Track

Get Spotify catalog information for a single track identified by its
unique Spotify ID.

```csharp
GetTrackAsync(
    string id,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.TrackObject](../../doc/models/track-object.md).

## Example Usage

```csharp
string id = "11dFghVXANMlKmJXsNCbNl";
string market = "ES";
try
{
    ApiResponse<TrackObject> result = await tracksController.GetTrackAsync(
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


# Get-Several-Tracks

Get Spotify catalog information for multiple tracks based on their Spotify IDs.

```csharp
GetSeveralTracksAsync(
    string ids,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyTracks](../../doc/models/many-tracks.md).

## Example Usage

```csharp
string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
string market = "ES";
try
{
    ApiResponse<ManyTracks> result = await tracksController.GetSeveralTracksAsync(
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


# Get-Users-Saved-Tracks

Get a list of the songs saved in the current Spotify user's 'Your Music' library.

```csharp
GetUsersSavedTracksAsync(
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

`user-library-read`

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingSavedTrackObject](../../doc/models/paging-saved-track-object.md).

## Example Usage

```csharp
string market = "ES";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingSavedTrackObject> result = await tracksController.GetUsersSavedTracksAsync(
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


# Save-Tracks-User

Save one or more tracks to the current user's 'Your Music' library.

```csharp
SaveTracksUserAsync(
    string ids,
    Models.MeTracksRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeTracksRequest`](../../doc/models/me-tracks-request.md) | Body, Optional | - |

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
    await tracksController.SaveTracksUserAsync(ids);
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


# Remove-Tracks-User

Remove one or more tracks from the current user's 'Your Music' library.

```csharp
RemoveTracksUserAsync(
    string ids,
    Models.MeTracksRequest1 body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `body` | [`MeTracksRequest1`](../../doc/models/me-tracks-request-1.md) | Body, Optional | - |

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
    await tracksController.RemoveTracksUserAsync(ids);
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


# Check-Users-Saved-Tracks

Check if one or more tracks is already saved in the current Spotify user's 'Your Music' library.

```csharp
CheckUsersSavedTracksAsync(
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
string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
try
{
    ApiResponse<List<bool>> result = await tracksController.CheckUsersSavedTracksAsync(ids);
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


# Get-Several-Audio-Features

Get audio features for multiple tracks based on their Spotify IDs.

```csharp
GetSeveralAudioFeaturesAsync(
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyAudioFeatures](../../doc/models/many-audio-features.md).

## Example Usage

```csharp
string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
try
{
    ApiResponse<ManyAudioFeatures> result = await tracksController.GetSeveralAudioFeaturesAsync(ids);
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


# Get-Audio-Features

Get audio feature information for a single track identified by its unique
Spotify ID.

```csharp
GetAudioFeaturesAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.AudioFeaturesObject](../../doc/models/audio-features-object.md).

## Example Usage

```csharp
string id = "11dFghVXANMlKmJXsNCbNl";
try
{
    ApiResponse<AudioFeaturesObject> result = await tracksController.GetAudioFeaturesAsync(id);
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


# Get-Audio-Analysis

Get a low-level audio analysis for a track in the Spotify catalog. The audio analysis describes the track’s structure and musical content, including rhythm, pitch, and timbre.

```csharp
GetAudioAnalysisAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.AudioAnalysisObject](../../doc/models/audio-analysis-object.md).

## Example Usage

```csharp
string id = "11dFghVXANMlKmJXsNCbNl";
try
{
    ApiResponse<AudioAnalysisObject> result = await tracksController.GetAudioAnalysisAsync(id);
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


# Get-Recommendations

Recommendations are generated based on the available information for a given seed entity and matched against similar artists and tracks. If there is sufficient information about the provided seeds, a list of tracks will be returned together with pool size details.

For artists and tracks that are very new or obscure there might not be enough data to generate a list of tracks.

```csharp
GetRecommendationsAsync(
    int? limit = 20,
    string market = null,
    string seedArtists = null,
    string seedGenres = null,
    string seedTracks = null,
    double? minAcousticness = null,
    double? maxAcousticness = null,
    double? targetAcousticness = null,
    double? minDanceability = null,
    double? maxDanceability = null,
    double? targetDanceability = null,
    int? minDurationMs = null,
    int? maxDurationMs = null,
    int? targetDurationMs = null,
    double? minEnergy = null,
    double? maxEnergy = null,
    double? targetEnergy = null,
    double? minInstrumentalness = null,
    double? maxInstrumentalness = null,
    double? targetInstrumentalness = null,
    int? minKey = null,
    int? maxKey = null,
    int? targetKey = null,
    double? minLiveness = null,
    double? maxLiveness = null,
    double? targetLiveness = null,
    double? minLoudness = null,
    double? maxLoudness = null,
    double? targetLoudness = null,
    int? minMode = null,
    int? maxMode = null,
    int? targetMode = null,
    int? minPopularity = null,
    int? maxPopularity = null,
    int? targetPopularity = null,
    double? minSpeechiness = null,
    double? maxSpeechiness = null,
    double? targetSpeechiness = null,
    double? minTempo = null,
    double? maxTempo = null,
    double? targetTempo = null,
    int? minTimeSignature = null,
    int? maxTimeSignature = null,
    int? targetTimeSignature = null,
    double? minValence = null,
    double? maxValence = null,
    double? targetValence = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 100` |
| `market` | `string` | Query, Optional | - |
| `seedArtists` | `string` | Query, Optional | - |
| `seedGenres` | `string` | Query, Optional | - |
| `seedTracks` | `string` | Query, Optional | - |
| `minAcousticness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxAcousticness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetAcousticness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minDanceability` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxDanceability` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetDanceability` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minDurationMs` | `int?` | Query, Optional | - |
| `maxDurationMs` | `int?` | Query, Optional | - |
| `targetDurationMs` | `int?` | Query, Optional | - |
| `minEnergy` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxEnergy` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetEnergy` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minInstrumentalness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxInstrumentalness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetInstrumentalness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minKey` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 11` |
| `maxKey` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 11` |
| `targetKey` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 11` |
| `minLiveness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxLiveness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetLiveness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minLoudness` | `double?` | Query, Optional | - |
| `maxLoudness` | `double?` | Query, Optional | - |
| `targetLoudness` | `double?` | Query, Optional | - |
| `minMode` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxMode` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetMode` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minPopularity` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 100` |
| `maxPopularity` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 100` |
| `targetPopularity` | `int?` | Query, Optional | **Constraints**: `>= 0`, `<= 100` |
| `minSpeechiness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxSpeechiness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetSpeechiness` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `minTempo` | `double?` | Query, Optional | - |
| `maxTempo` | `double?` | Query, Optional | - |
| `targetTempo` | `double?` | Query, Optional | - |
| `minTimeSignature` | `int?` | Query, Optional | **Constraints**: `<= 11` |
| `maxTimeSignature` | `int?` | Query, Optional | - |
| `targetTimeSignature` | `int?` | Query, Optional | - |
| `minValence` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `maxValence` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |
| `targetValence` | `double?` | Query, Optional | **Constraints**: `>= 0`, `<= 1` |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.RecommendationsObject](../../doc/models/recommendations-object.md).

## Example Usage

```csharp
int? limit = 10;
string market = "ES";
string seedArtists = "4NHQUGzhtTLFvgF5SZesLK";
string seedGenres = "classical,country";
string seedTracks = "0c6xIDDpzE81m2q797ordA";
try
{
    ApiResponse<RecommendationsObject> result = await tracksController.GetRecommendationsAsync(
        limit,
        market,
        seedArtists,
        seedGenres,
        seedTracks
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

