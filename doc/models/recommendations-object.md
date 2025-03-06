
# Recommendations Object

## Structure

`RecommendationsObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Seeds` | [`List<RecommendationSeedObject>`](../../doc/models/recommendation-seed-object.md) | Required | An array of recommendation seed objects. |
| `Tracks` | [`List<TrackObject>`](../../doc/models/track-object.md) | Required | An array of track objects ordered according to the parameters supplied. |

## Example (as JSON)

```json
{
  "seeds": [
    {
      "afterFilteringSize": 36,
      "afterRelinkingSize": 144,
      "href": "href4",
      "id": "id2",
      "initialPoolSize": 42
    }
  ],
  "tracks": [
    {
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
        "available_markets8",
        "available_markets9"
      ],
      "disc_number": 168,
      "duration_ms": 232
    }
  ]
}
```

