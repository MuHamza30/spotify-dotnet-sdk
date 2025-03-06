
# Paging Playlist Track Object

## Structure

`PagingPlaylistTrackObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Href` | `string` | Required | A link to the Web API endpoint returning the full result of the request |
| `Limit` | `int` | Required | The maximum number of items in the response (as set in the query or by default). |
| `Next` | `string` | Required | URL to the next page of items. ( `null` if none) |
| `Offset` | `int` | Required | The offset of the items returned (as set in the query or by default) |
| `Previous` | `string` | Required | URL to the previous page of items. ( `null` if none) |
| `Total` | `int` | Required | The total number of items available to return. |
| `Items` | [`List<PlaylistTrackObject>`](../../doc/models/playlist-track-object.md) | Required | - |

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
  ]
}
```

