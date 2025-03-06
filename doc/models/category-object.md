
# Category Object

## Structure

`CategoryObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Href` | `string` | Required | A link to the Web API endpoint returning full details of the category. |
| `Icons` | [`List<ImageObject>`](../../doc/models/image-object.md) | Required | The category icon, in various sizes. |
| `Id` | `string` | Required | The [Spotify category ID](/documentation/web-api/concepts/spotify-uris-ids) of the category. |
| `Name` | `string` | Required | The name of the category. |

## Example (as JSON)

```json
{
  "href": "href0",
  "icons": [
    {
      "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
      "height": 300,
      "width": 300
    }
  ],
  "id": "equal",
  "name": "EQUAL"
}
```

