# Search

```csharp
SearchController searchController = client.SearchController;
```

## Class Name

`SearchController`


# Search

Get Spotify catalog information about albums, artists, playlists, tracks, shows, episodes or audiobooks
that match a keyword string. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.

```csharp
SearchAsync(
    string q,
    List<Models.ItemTypeEnum> type,
    string market = null,
    int? limit = 20,
    int? offset = 0,
    Models.IncludeExternalEnum? includeExternal = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `q` | `string` | Query, Required | - |
| `type` | [`List<ItemTypeEnum>`](../../doc/models/item-type-enum.md) | Query, Required | - |
| `market` | `string` | Query, Optional | - |
| `limit` | `int?` | Query, Optional | **Default**: `20`<br>**Constraints**: `>= 1`, `<= 50` |
| `offset` | `int?` | Query, Optional | **Default**: `0`<br>**Constraints**: `>= 0`, `<= 1000` |
| `includeExternal` | [`IncludeExternalEnum?`](../../doc/models/include-external-enum.md) | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.SearchItems](../../doc/models/search-items.md).

## Example Usage

```csharp
string q = "remaster%20track:Doxy%20artist:Miles%20Davis";
List<ItemTypeEnum> type = new List<ItemTypeEnum>
{
    ItemTypeEnum.Audiobook,
    ItemTypeEnum.Album,
    ItemTypeEnum.Artist,
};

string market = "ES";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<SearchItems> result = await searchController.SearchAsync(
        q,
        type,
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

