
# Public User Object

## Structure

`PublicUserObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DisplayName` | `string` | Optional | The name displayed on the user's profile. `null` if not available. |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | Known public external URLs for this user. |
| `Followers` | [`FollowersObject`](../../doc/models/followers-object.md) | Optional | Information about the followers of this user. |
| `Href` | `string` | Optional | A link to the Web API endpoint for this user. |
| `Id` | `string` | Optional | The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for this user. |
| `Images` | [`List<ImageObject>`](../../doc/models/image-object.md) | Optional | The user's profile image. |
| `Type` | [`Type3Enum?`](../../doc/models/type-3-enum.md) | Optional | The object type. |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for this user. |

## Example (as JSON)

```json
{
  "display_name": "display_name6",
  "external_urls": {
    "spotify": "spotify6"
  },
  "followers": {
    "href": "href0",
    "total": 82
  },
  "href": "href8",
  "id": "id6"
}
```

