
# Queue Object

## Structure

`QueueObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CurrentlyPlaying` | [`QueueObjectCurrentlyPlaying`](../../doc/models/containers/queue-object-currently-playing.md) | Optional | This is a container for one-of cases. |
| `Queue` | [`List<QueueObjectQueue>`](../../doc/models/containers/queue-object-queue.md) | Optional | This is List of a container for one-of cases. |

## Example (as JSON)

```json
{
  "currently_playing": {
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
  },
  "queue": [
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
        }
      ],
      "available_markets": [
        "available_markets6",
        "available_markets7"
      ],
      "disc_number": 30,
      "duration_ms": 222
    },
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
        }
      ],
      "available_markets": [
        "available_markets6",
        "available_markets7"
      ],
      "disc_number": 30,
      "duration_ms": 222
    },
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
        }
      ],
      "available_markets": [
        "available_markets6",
        "available_markets7"
      ],
      "disc_number": 30,
      "duration_ms": 222
    }
  ]
}
```

