
# Audiobook Base

## Structure

`AudiobookBase`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Authors` | [`List<AuthorObject>`](../../doc/models/author-object.md) | Required | The author(s) for the audiobook. |
| `AvailableMarkets` | `List<string>` | Required | A list of the countries in which the audiobook can be played, identified by their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code. |
| `Copyrights` | [`List<CopyrightObject>`](../../doc/models/copyright-object.md) | Required | The copyright statements of the audiobook. |
| `Description` | `string` | Required | A description of the audiobook. HTML tags are stripped away from this field, use `html_description` field in case HTML tags are needed. |
| `HtmlDescription` | `string` | Required | A description of the audiobook. This field may contain HTML tags. |
| `Edition` | `string` | Optional | The edition of the audiobook. |
| `Explicit` | `bool` | Required | Whether or not the audiobook has explicit content (true = yes it does; false = no it does not OR unknown). |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Required | External URLs for this audiobook. |
| `Href` | `string` | Required | A link to the Web API endpoint providing full details of the audiobook. |
| `Id` | `string` | Required | The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the audiobook. |
| `Images` | [`List<ImageObject>`](../../doc/models/image-object.md) | Required | The cover art for the audiobook in various sizes, widest first. |
| `Languages` | `List<string>` | Required | A list of the languages used in the audiobook, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639) code. |
| `MediaType` | `string` | Required | The media type of the audiobook. |
| `Name` | `string` | Required | The name of the audiobook. |
| `Narrators` | [`List<NarratorObject>`](../../doc/models/narrator-object.md) | Required | The narrator(s) for the audiobook. |
| `Publisher` | `string` | Required | The publisher of the audiobook. |
| `Type` | `string` | Required, Constant | The object type.<br>**Value**: `"audiobook"` |
| `Uri` | `string` | Required | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the audiobook. |
| `TotalChapters` | `int` | Required | The number of chapters in this audiobook. |

## Example (as JSON)

```json
{
  "authors": [
    {
      "name": "name0"
    }
  ],
  "available_markets": [
    "available_markets8",
    "available_markets9",
    "available_markets0"
  ],
  "copyrights": [
    {
      "text": "text2",
      "type": "type2"
    }
  ],
  "description": "description4",
  "html_description": "html_description4",
  "edition": "Unabridged",
  "explicit": false,
  "external_urls": {
    "spotify": "spotify6"
  },
  "href": "href6",
  "id": "id4",
  "images": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
      "height": 300,
      "width": 300
    }
  ],
  "languages": [
    "languages1",
    "languages2",
    "languages3"
  ],
  "media_type": "media_type2",
  "name": "name4",
  "narrators": [
    {
      "name": "name0"
    }
  ],
  "publisher": "publisher2",
  "type": "audiobook",
  "uri": "uri8",
  "total_chapters": 240
}
```

