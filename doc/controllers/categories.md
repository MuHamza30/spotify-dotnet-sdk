# Categories

```csharp
CategoriesController categoriesController = client.CategoriesController;
```

## Class Name

`CategoriesController`

## Methods

* [Get-Categories](../../doc/controllers/categories.md#get-categories)
* [Get-a-Category](../../doc/controllers/categories.md#get-a-category)


# Get-Categories

Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).

```csharp
GetCategoriesAsync(
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

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.PagedCategories](../../doc/models/paged-categories.md).

## Example Usage

```csharp
string locale = "sv_SE";
int? limit = 10;
int? offset = 5;
try
{
    ApiResponse<PagedCategories> result = await categoriesController.GetCategoriesAsync(
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


# Get-a-Category

Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).

```csharp
GetACategoryAsync(
    string categoryId,
    string locale = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `categoryId` | `string` | Template, Required | - |
| `locale` | `string` | Query, Optional | - |

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.CategoryObject](../../doc/models/category-object.md).

## Example Usage

```csharp
string categoryId = "dinner";
string locale = "sv_SE";
try
{
    ApiResponse<CategoryObject> result = await categoriesController.GetACategoryAsync(
        categoryId,
        locale
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

