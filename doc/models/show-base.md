
# Show Base

## Structure

`ShowBase`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AvailableMarkets` | `List<string>` | Required | A list of the countries in which the show can be played, identified by their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code. |
| `Copyrights` | [`List<CopyrightObject>`](../../doc/models/copyright-object.md) | Required | The copyright statements of the show. |
| `Description` | `string` | Required | A description of the show. HTML tags are stripped away from this field, use `html_description` field in case HTML tags are needed. |
| `HtmlDescription` | `string` | Required | A description of the show. This field may contain HTML tags. |
| `Explicit` | `bool` | Required | Whether or not the show has explicit content (true = yes it does; false = no it does not OR unknown). |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Required | External URLs for this show. |
| `Href` | `string` | Required | A link to the Web API endpoint providing full details of the show. |
| `Id` | `string` | Required | The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the show. |
| `Images` | [`List<ImageObject>`](../../doc/models/image-object.md) | Required | The cover art for the show in various sizes, widest first. |
| `IsExternallyHosted` | `bool` | Required | True if all of the shows episodes are hosted outside of Spotify's CDN. This field might be `null` in some cases. |
| `Languages` | `List<string>` | Required | A list of the languages used in the show, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639) code. |
| `MediaType` | `string` | Required | The media type of the show. |
| `Name` | `string` | Required | The name of the episode. |
| `Publisher` | `string` | Required | The publisher of the show. |
| `Type` | `string` | Required, Constant | The object type.<br>**Value**: `"show"` |
| `Uri` | `string` | Required | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the show. |
| `TotalEpisodes` | `int` | Required | The total number of episodes in the show. |

## Example (as JSON)

```json
{
  "available_markets": [
    "available_markets2"
  ],
  "copyrights": [
    {
      "text": "text2",
      "type": "type2"
    }
  ],
  "description": "description8",
  "html_description": "html_description8",
  "explicit": false,
  "external_urls": {
    "spotify": "spotify6"
  },
  "href": "href0",
  "id": "id8",
  "images": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
      "height": 300,
      "width": 300
    }
  ],
  "is_externally_hosted": false,
  "languages": [
    "languages5"
  ],
  "media_type": "media_type4",
  "name": "name8",
  "publisher": "publisher6",
  "type": "show",
  "uri": "uri2",
  "total_episodes": 88
}
```

