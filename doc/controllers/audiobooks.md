# Audiobooks

```csharp
AudiobooksController audiobooksController = client.AudiobooksController;
```

## Class Name

`AudiobooksController`

## Methods

* [Get-an-Audiobook](../../doc/controllers/audiobooks.md#get-an-audiobook)
* [Get-Multiple-Audiobooks](../../doc/controllers/audiobooks.md#get-multiple-audiobooks)
* [Get-Audiobook-Chapters](../../doc/controllers/audiobooks.md#get-audiobook-chapters)
* [Get-Users-Saved-Audiobooks](../../doc/controllers/audiobooks.md#get-users-saved-audiobooks)
* [Save-Audiobooks-User](../../doc/controllers/audiobooks.md#save-audiobooks-user)
* [Remove-Audiobooks-User](../../doc/controllers/audiobooks.md#remove-audiobooks-user)
* [Check-Users-Saved-Audiobooks](../../doc/controllers/audiobooks.md#check-users-saved-audiobooks)


# Get-an-Audiobook

Get Spotify catalog information for a single audiobook. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.

```csharp
GetAnAudiobookAsync(
    string id,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.AudiobookObject](../../doc/models/audiobook-object.md).

## Example Usage

```csharp
string id = "7iHfbu1YPACw6oZPAFJtqe";
string market = "ES";
try
{
    ApiResponse<AudiobookObject> result = await audiobooksController.GetAnAudiobookAsync(
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
| 400 | The request contains malformed data in path, query parameters, or body. | [`BadRequestException`](../../doc/models/bad-request-exception.md) |
| 401 | Bad or expired token. This can happen if the user revoked a token or<br>the access token has expired. You should re-authenticate the user. | [`UnauthorizedException`](../../doc/models/unauthorized-exception.md) |
| 403 | Bad OAuth request (wrong consumer key, bad nonce, expired<br>timestamp...). Unfortunately, re-authenticating the user won't help here. | [`ForbiddenException`](../../doc/models/forbidden-exception.md) |
| 404 | The requested resource cannot be found. | [`NotFoundException`](../../doc/models/not-found-exception.md) |
| 429 | The app has exceeded its rate limits. | [`TooManyRequestsException`](../../doc/models/too-many-requests-exception.md) |


# Get-Multiple-Audiobooks

Get Spotify catalog information for several audiobooks identified by their Spotify IDs. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.

```csharp
GetMultipleAudiobooksAsync(
    string ids,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyAudiobooks](../../doc/models/many-audiobooks.md).

## Example Usage

```csharp
string ids = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe";
string market = "ES";
try
{
    ApiResponse<ManyAudiobooks> result = await audiobooksController.GetMultipleAudiobooksAsync(
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


# Get-Audiobook-Chapters

Get Spotify catalog information about an audiobook's chapters. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.

```csharp
GetAudiobookChaptersAsync(
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

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingSimplifiedChapterObject](../../doc/models/paging-simplified-chapter-object.md).

## Example Usage

```csharp
string id = "7iHfbu1YPACw6oZPAFJtqe";
string market = "ES";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingSimplifiedChapterObject> result = await audiobooksController.GetAudiobookChaptersAsync(
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


# Get-Users-Saved-Audiobooks

Get a list of the audiobooks saved in the current Spotify user's 'Your Music' library.

```csharp
GetUsersSavedAudiobooksAsync(
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

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagingSavedAudiobookObject](../../doc/models/paging-saved-audiobook-object.md).

## Example Usage

```csharp
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagingSavedAudiobookObject> result = await audiobooksController.GetUsersSavedAudiobooksAsync(
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


# Save-Audiobooks-User

Save one or more audiobooks to the current Spotify user's library.

```csharp
SaveAudiobooksUserAsync(
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |

## Requires scope

### oauth_2_0

`user-library-modify`

## Response Type

`Task`

## Example Usage

```csharp
string ids = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe";
try
{
    await audiobooksController.SaveAudiobooksUserAsync(ids);
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


# Remove-Audiobooks-User

Remove one or more audiobooks from the Spotify user's library.

```csharp
RemoveAudiobooksUserAsync(
    string ids)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |

## Requires scope

### oauth_2_0

`user-library-modify`

## Response Type

`Task`

## Example Usage

```csharp
string ids = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe";
try
{
    await audiobooksController.RemoveAudiobooksUserAsync(ids);
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


# Check-Users-Saved-Audiobooks

Check if one or more audiobooks are already saved in the current Spotify user's library.

```csharp
CheckUsersSavedAudiobooksAsync(
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
string ids = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe";
try
{
    ApiResponse<List<bool>> result = await audiobooksController.CheckUsersSavedAudiobooksAsync(ids);
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

