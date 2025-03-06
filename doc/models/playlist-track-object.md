
# Playlist Track Object

## Structure

`PlaylistTrackObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddedAt` | `DateTime?` | Optional | The date and time the track or episode was added. _**Note**: some very old playlists may return `null` in this field._ |
| `AddedBy` | [`PlaylistUserObject`](../../doc/models/playlist-user-object.md) | Optional | The Spotify user who added the track or episode. _**Note**: some very old playlists may return `null` in this field._ |
| `IsLocal` | `bool?` | Optional | Whether this track or episode is a [local file](/documentation/web-api/concepts/playlists/#local-files) or not. |
| `Track` | [`PlaylistTrackObjectTrack`](../../doc/models/containers/playlist-track-object-track.md) | Optional | This is a container for one-of cases. |

## Example (as JSON)

```json
{
  "added_at": "2016-03-13T12:52:32.123Z",
  "added_by": {
    "external_urls": {
      "spotify": "spotify6"
    },
    "followers": {
      "href": "href0",
      "total": 82
    },
    "href": "href6",
    "id": "id4",
    "type": "user"
  },
  "is_local": false,
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
      },
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
      "available_markets6",
      "available_markets7"
    ],
    "disc_number": 30,
    "duration_ms": 222
  }
}
```

