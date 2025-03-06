
# Chapter Object

## Structure

`ChapterObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AudioPreviewUrl` | `string` | Required | A URL to a 30 second preview (MP3 format) of the chapter. `null` if not available. |
| `AvailableMarkets` | `List<string>` | Optional | A list of the countries in which the chapter can be played, identified by their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code. |
| `ChapterNumber` | `int` | Required | The number of the chapter |
| `Description` | `string` | Required | A description of the chapter. HTML tags are stripped away from this field, use `html_description` field in case HTML tags are needed. |
| `HtmlDescription` | `string` | Required | A description of the chapter. This field may contain HTML tags. |
| `DurationMs` | `int` | Required | The chapter length in milliseconds. |
| `Explicit` | `bool` | Required | Whether or not the chapter has explicit content (true = yes it does; false = no it does not OR unknown). |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Required | External URLs for this chapter. |
| `Href` | `string` | Required | A link to the Web API endpoint providing full details of the chapter. |
| `Id` | `string` | Required | The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the chapter. |
| `Images` | [`List<ImageObject>`](../../doc/models/image-object.md) | Required | The cover art for the chapter in various sizes, widest first. |
| `IsPlayable` | `bool` | Required | True if the chapter is playable in the given market. Otherwise false. |
| `Languages` | `List<string>` | Required | A list of the languages used in the chapter, identified by their [ISO 639-1](https://en.wikipedia.org/wiki/ISO_639) code. |
| `Name` | `string` | Required | The name of the chapter. |
| `ReleaseDate` | `string` | Required | The date the chapter was first released, for example `"1981-12-15"`. Depending on the precision, it might be shown as `"1981"` or `"1981-12"`. |
| `ReleaseDatePrecision` | [`ReleaseDatePrecisionEnum`](../../doc/models/release-date-precision-enum.md) | Required | The precision with which `release_date` value is known. |
| `ResumePoint` | [`ResumePointObject`](../../doc/models/resume-point-object.md) | Optional | The user's most recent position in the chapter. Set if the supplied access token is a user token and has the scope 'user-read-playback-position'. |
| `Type` | `string` | Required, Constant | The object type.<br>**Value**: `"episode"` |
| `Uri` | `string` | Required | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the chapter. |
| `Restrictions` | [`ChapterRestrictionObject`](../../doc/models/chapter-restriction-object.md) | Optional | Included in the response when a content restriction is applied. |
| `Audiobook` | [`AudiobookBase`](../../doc/models/audiobook-base.md) | Required | The audiobook for which the chapter belongs. |

## Example (as JSON)

```json
{
  "audio_preview_url": "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
  "chapter_number": 1,
  "description": "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
  "html_description": "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
  "duration_ms": 1686230,
  "explicit": false,
  "external_urls": {
    "spotify": "spotify6"
  },
  "href": "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
  "id": "5Xt5DXGzch68nYYamXrNxZ",
  "images": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
      "height": 300,
      "width": 300
    }
  ],
  "is_playable": false,
  "languages": [
    "fr",
    "en"
  ],
  "name": "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
  "release_date": "1981-12-15",
  "release_date_precision": "day",
  "type": "episode",
  "uri": "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
  "audiobook": {
    "authors": [
      {
        "name": "name0"
      }
    ],
    "available_markets": [
      "available_markets2",
      "available_markets3",
      "available_markets4"
    ],
    "copyrights": [
      {
        "text": "text2",
        "type": "type2"
      }
    ],
    "description": "description2",
    "html_description": "html_description2",
    "edition": "Unabridged",
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
    "languages": [
      "languages3",
      "languages4"
    ],
    "media_type": "media_type4",
    "name": "name8",
    "narrators": [
      {
        "name": "name0"
      }
    ],
    "publisher": "publisher4",
    "type": "audiobook",
    "uri": "uri2",
    "total_chapters": 186
  },
  "available_markets": [
    "available_markets4",
    "available_markets5",
    "available_markets6"
  ],
  "resume_point": {
    "fully_played": false,
    "resume_position_ms": 254
  },
  "restrictions": {
    "reason": "reason0"
  }
}
```

