# Genres

```csharp
GenresController genresController = client.GenresController;
```

## Class Name

`GenresController`


# Get-Recommendation-Genres

Retrieve a list of available genres seed parameter values for [recommendations](/documentation/web-api/reference/get-recommendations).

```csharp
GetRecommendationGenresAsync()
```

## Response Type

This method returns an [`ApiResponse`](../../doc/api-response.md) instance. The `Data` property of this instance returns the response data which is of type [Models.ManyGenres](../../doc/models/many-genres.md).

## Example Usage

```csharp
try
{
    ApiResponse<ManyGenres> result = await genresController.GetRecommendationGenresAsync();
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

