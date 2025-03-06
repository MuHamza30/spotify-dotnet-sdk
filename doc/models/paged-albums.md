
# Paged Albums

## Structure

`PagedAlbums`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Albums` | [`PagingSimplifiedAlbumObject`](../../doc/models/paging-simplified-album-object.md) | Required | - |

## Example (as JSON)

```json
{
  "albums": {
    "href": "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
    "limit": 20,
    "next": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
    "offset": 0,
    "previous": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
    "total": 4,
    "items": [
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
        "restrictions": {
          "reason": "explicit"
        }
      }
    ]
  }
}
```

