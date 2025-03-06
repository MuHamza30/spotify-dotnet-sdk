
# Context Object

## Structure

`ContextObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Optional | The object type, e.g. "artist", "playlist", "album", "show". |
| `Href` | `string` | Optional | A link to the Web API endpoint providing full details of the track. |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | External URLs for this context. |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the context. |

## Example (as JSON)

```json
{
  "type": "type6",
  "href": "href6",
  "external_urls": {
    "spotify": "spotify6"
  },
  "uri": "uri8"
}
```

