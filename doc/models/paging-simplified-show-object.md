
# Paging Simplified Show Object

## Structure

`PagingSimplifiedShowObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Href` | `string` | Required | A link to the Web API endpoint returning the full result of the request |
| `Limit` | `int` | Required | The maximum number of items in the response (as set in the query or by default). |
| `Next` | `string` | Required | URL to the next page of items. ( `null` if none) |
| `Offset` | `int` | Required | The offset of the items returned (as set in the query or by default) |
| `Previous` | `string` | Required | URL to the previous page of items. ( `null` if none) |
| `Total` | `int` | Required | The total number of items available to return. |
| `Items` | [`List<ShowBase>`](../../doc/models/show-base.md) | Required | - |

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
      "available_markets": [
        "available_markets2"
      ],
      "copyrights": [
        {
          "text": "text2",
          "type": "type2"
        }
      ],
      "description": "description2",
      "html_description": "html_description2",
      "explicit": false,
      "external_urls": {
        "spotify": "spotify6"
      },
      "href": "href0",
      "id": "id8",
      "images": [
        {
          "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
          "height": 300,
          "width": 300
        }
      ],
      "is_externally_hosted": false,
      "languages": [
        "languages5"
      ],
      "media_type": "media_type4",
      "name": "name8",
      "publisher": "publisher4",
      "type": "show",
      "uri": "uri2",
      "total_episodes": 166
    }
  ]
}
```

