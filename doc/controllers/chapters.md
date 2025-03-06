# Chapters

```csharp
ChaptersController chaptersController = client.ChaptersController;
```

## Class Name

`ChaptersController`

## Methods

* [Get-a-Chapter](../../doc/controllers/chapters.md#get-a-chapter)
* [Get-Several-Chapters](../../doc/controllers/chapters.md#get-several-chapters)


# Get-a-Chapter

Get Spotify catalog information for a single audiobook chapter. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.

```csharp
GetAChapterAsync(
    string id,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ChapterObject](../../doc/models/chapter-object.md).

## Example Usage

```csharp
string id = "0D5wENdkdwbqlrHoaJ9g29";
string market = "ES";
try
{
    ApiResponse<ChapterObject> result = await chaptersController.GetAChapterAsync(
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


# Get-Several-Chapters

Get Spotify catalog information for several audiobook chapters identified by their Spotify IDs. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.

```csharp
GetSeveralChaptersAsync(
    string ids,
    string market = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | - |
| `market` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyChapters](../../doc/models/many-chapters.md).

## Example Usage

```csharp
string ids = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29";
string market = "ES";
try
{
    ApiResponse<ManyChapters> result = await chaptersController.GetSeveralChaptersAsync(
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

