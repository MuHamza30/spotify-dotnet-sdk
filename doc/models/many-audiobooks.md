
# Many Audiobooks

## Structure

`ManyAudiobooks`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Audiobooks` | [`List<AudiobookObject>`](../../doc/models/audiobook-object.md) | Required | - |

## Example (as JSON)

```json
{
  "audiobooks": [
    {
      "authors": [
        {
          "name": "name0"
        }
      ],
      "available_markets": [
        "available_markets8"
      ],
      "copyrights": [
        {
          "text": "text2",
          "type": "type2"
        }
      ],
      "description": "description4",
      "html_description": "html_description6",
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
        "languages1"
      ],
      "media_type": "media_type8",
      "name": "name4",
      "narrators": [
        {
          "name": "name0"
        }
      ],
      "publisher": "publisher8",
      "type": "audiobook",
      "uri": "uri8",
      "total_chapters": 186,
      "chapters": {
        "href": "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
        "limit": 20,
        "next": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
        "offset": 0,
        "previous": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
        "total": 4,
        "items": [
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
            "available_markets": [
              "available_markets2"
            ],
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
    }
  ]
}
```

