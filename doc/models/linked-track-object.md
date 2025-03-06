
# Linked Track Object

## Structure

`LinkedTrackObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | Known external URLs for this track. |
| `Href` | `string` | Optional | A link to the Web API endpoint providing full details of the track. |
| `Id` | `string` | Optional | The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the track. |
| `Type` | `string` | Optional | The object type: "track". |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the track. |

## Example (as JSON)

```json
{
  "external_urls": {
    "spotify": "spotify6"
  },
  "href": "href0",
  "id": "id8",
  "type": "type2",
  "uri": "uri2"
}
```

