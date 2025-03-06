
# Saved Track Object

## Structure

`SavedTrackObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddedAt` | `DateTime?` | Optional | The date and time the track was saved.<br>Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.<br>If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision; see for example, release_date in an album object. |
| `Track` | [`TrackObject`](../../doc/models/track-object.md) | Optional | Information about the track. |

## Example (as JSON)

```json
{
  "added_at": "2016-03-13T12:52:32.123Z",
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
  }
}
```

