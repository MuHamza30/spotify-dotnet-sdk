
# Saved Episode Object

## Structure

`SavedEpisodeObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddedAt` | `DateTime?` | Optional | The date and time the episode was saved.<br>Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. |
| `Episode` | [`EpisodeObject`](../../doc/models/episode-object.md) | Optional | Information about the episode. |

## Example (as JSON)

```json
{
  "added_at": "2016-03-13T12:52:32.123Z",
  "episode": {
    "audio_preview_url": "audio_preview_url8",
    "description": "description2",
    "html_description": "html_description8",
    "duration_ms": 46,
    "explicit": false,
    "external_urls": {
      "spotify": "spotify6"
    },
    "href": "href4",
    "id": "id2",
    "images": [
      {
        "url": "url6",
        "height": 182,
        "width": 222
      },
      {
        "url": "url6",
        "height": 182,
        "width": 222
      },
      {
        "url": "url6",
        "height": 182,
        "width": 222
      }
    ],
    "is_externally_hosted": false,
    "is_playable": false,
    "language": "language4",
    "languages": [
      "languages9",
      "languages0",
      "languages1"
    ],
    "name": "name2",
    "release_date": "release_date0",
    "release_date_precision": "year",
    "resume_point": {
      "fully_played": false,
      "resume_position_ms": 254
    },
    "type": "type8",
    "uri": "uri6",
    "restrictions": {
      "reason": "reason0"
    },
    "show": {
      "available_markets": [
        "available_markets0",
        "available_markets1",
        "available_markets2"
      ],
      "copyrights": [
        {
          "text": "text2",
          "type": "type2"
        },
        {
          "text": "text2",
          "type": "type2"
        },
        {
          "text": "text2",
          "type": "type2"
        }
      ],
      "description": "description4",
      "html_description": "html_description4",
      "explicit": false,
      "external_urls": {
        "spotify": "spotify6"
      },
      "href": "href8",
      "id": "id6",
      "images": [
        {
          "url": "url6",
          "height": 182,
          "width": 222
        },
        {
          "url": "url6",
          "height": 182,
          "width": 222
        },
        {
          "url": "url6",
          "height": 182,
          "width": 222
        }
      ],
      "is_externally_hosted": false,
      "languages": [
        "languages7",
        "languages6",
        "languages5"
      ],
      "media_type": "media_type6",
      "name": "name6",
      "publisher": "publisher6",
      "type": "type4",
      "uri": "uri0",
      "total_episodes": 198
    }
  }
}
```

