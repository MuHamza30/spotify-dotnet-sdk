
# Simplified Artist Object

## Structure

`SimplifiedArtistObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | Known external URLs for this artist. |
| `Href` | `string` | Optional | A link to the Web API endpoint providing full details of the artist. |
| `Id` | `string` | Optional | The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the artist. |
| `Name` | `string` | Optional | The name of the artist. |
| `Type` | [`TypeEnum?`](../../doc/models/type-enum.md) | Optional | The object type. |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the artist. |

## Example (as JSON)

```json
{
  "external_urls": {
    "spotify": "spotify6"
  },
  "href": "href6",
  "id": "id4",
  "name": "name4",
  "type": "artist"
}
```

