
# Paging Simplified Episode Object

## Structure

`PagingSimplifiedEpisodeObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Href` | `string` | Required | A link to the Web API endpoint returning the full result of the request |
| `Limit` | `int` | Required | The maximum number of items in the response (as set in the query or by default). |
| `Next` | `string` | Required | URL to the next page of items. ( `null` if none) |
| `Offset` | `int` | Required | The offset of the items returned (as set in the query or by default) |
| `Previous` | `string` | Required | URL to the previous page of items. ( `null` if none) |
| `Total` | `int` | Required | The total number of items available to return. |
| `Items` | [`List<EpisodeBase>`](../../doc/models/episode-base.md) | Required | - |

## Example (as JSON)

```json
{
  "href": "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
  "limit": 20,
  "next": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
  "offset": 0,
  "previous": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
  "total": 4,
  "items": [
    {
      "audio_preview_url": "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
      "description": "A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.\n",
      "html_description": "<p>A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.</p>\n",
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
      "is_externally_hosted": false,
      "is_playable": false,
      "language": "en",
      "languages": [
        "fr",
        "en"
      ],
      "name": "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
      "release_date": "1981-12-15",
      "release_date_precision": "day",
      "type": "episode",
      "uri": "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
      "resume_point": {
        "fully_played": false,
        "resume_position_ms": 254
      },
      "restrictions": {
        "reason": "reason0"
      }
    }
  ]
}
```

