
# Many Albums

## Structure

`ManyAlbums`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Albums` | [`List<AlbumObject>`](../../doc/models/album-object.md) | Required | - |

## Example (as JSON)

```json
{
  "albums": [
    {
      "album_type": "compilation",
      "total_tracks": 9,
      "available_markets": [
        "CA",
        "BR",
        "IT"
      ],
      "external_urls": {
        "spotify": "spotify6"
      },
      "href": "href0",
      "id": "2up3OPMp9Tb4dAKM2erWXQ",
      "images": [
        {
          "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
          "height": 300,
          "width": 300
        }
      ],
      "name": "name8",
      "release_date": "1981-12",
      "release_date_precision": "year",
      "type": "album",
      "uri": "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
      "artists": [
        {
          "external_urls": {
            "spotify": "spotify6"
          },
          "href": "href2",
          "id": "id0",
          "name": "name0",
          "type": "artist"
        }
      ],
      "tracks": {
        "href": "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
        "limit": 20,
        "next": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
        "offset": 0,
        "previous": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
        "total": 4,
        "items": [
          {
            "artists": [
              {
                "external_urls": {
                  "spotify": "spotify6"
                },
                "href": "href2",
                "id": "id0",
                "name": "name0",
                "type": "artist"
              }
            ],
            "available_markets": [
              "available_markets2"
            ],
            "disc_number": 244,
            "duration_ms": 52,
            "explicit": false
          }
        ]
      },
      "copyrights": [
        {
          "text": "text2",
          "type": "type2"
        }
      ],
      "external_ids": {
        "isrc": "isrc8",
        "ean": "ean8",
        "upc": "upc2"
      },
      "genres": [
        "Egg punk",
        "Noise rock"
      ],
      "label": "label8",
      "popularity": 66,
      "restrictions": {
        "reason": "explicit"
      }
    }
  ]
}
```

