
# Playlist User Object

## Structure

`PlaylistUserObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | Known public external URLs for this user. |
| `Followers` | [`FollowersObject`](../../doc/models/followers-object.md) | Optional | Information about the followers of this user. |
| `Href` | `string` | Optional | A link to the Web API endpoint for this user. |
| `Id` | `string` | Optional | The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for this user. |
| `Type` | [`Type3Enum?`](../../doc/models/type-3-enum.md) | Optional | The object type. |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for this user. |

## Example (as JSON)

```json
{
  "external_urls": {
    "spotify": "spotify6"
  },
  "followers": {
    "href": "href0",
    "total": 82
  },
  "href": "href8",
  "id": "id6",
  "type": "user"
}
```

