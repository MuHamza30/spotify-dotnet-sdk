
# Play History Object

## Structure

`PlayHistoryObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Track` | [`TrackObject`](../../doc/models/track-object.md) | Optional | The track the user listened to. |
| `PlayedAt` | `DateTime?` | Optional | The date and time the track was played. |
| `Context` | [`ContextObject`](../../doc/models/context-object.md) | Optional | The context the track was played from. |

## Example (as JSON)

```json
{
  "track": {
    "album": {
      "album_type": "single",
      "total_tracks": 170,
      "available_markets": [
        "available_markets2",
        "available_markets3"
      ],
      "external_urls": {
        "spotify": "spotify6"
      },
      "href": "href0",
      "id": "id8",
      "images": [
        {
          "url": "url6",
          "height": 182,
          "width": 222
        }
      ],
      "name": "name8",
      "release_date": "release_date6",
      "release_date_precision": "day",
      "restrictions": {
        "reason": "explicit"
      },
      "type": "type2",
      "uri": "uri2",
      "artists": [
        {
          "external_urls": {
            "spotify": "spotify6"
          },
          "href": "href2",
          "id": "id0",
          "name": "name0",
          "type": "artist"
        },
        {
          "external_urls": {
            "spotify": "spotify6"
          },
          "href": "href2",
          "id": "id0",
          "name": "name0",
          "type": "artist"
        }
      ]
    },
    "artists": [
      {
        "external_urls": {
          "spotify": "spotify6"
        },
        "followers": {
          "href": "href0",
          "total": 82
        },
        "genres": [
          "genres7",
          "genres8"
        ],
        "href": "href2",
        "id": "id0"
      }
    ],
    "available_markets": [
      "available_markets8"
    ],
    "disc_number": 206,
    "duration_ms": 142
  },
  "played_at": "2016-03-13T12:52:32.123Z",
  "context": {
    "type": "type8",
    "href": "href4",
    "external_urls": {
      "spotify": "spotify6"
    },
    "uri": "uri6"
  }
}
```

