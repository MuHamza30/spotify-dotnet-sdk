
# Me Albums Request

## Structure

`MeAlbumsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Ids` | `List<string>` | Optional | A JSON array of the [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids). For example: `["4iV5W9uYEdYUVa79Axb7Rh", "1301WleyT98MSxVHPZCA6M"]`<br/>A maximum of 50 items can be specified in one request. _**Note**: if the `ids` parameter is present in the query string, any IDs listed here in the body will be ignored._ |

## Example (as JSON)

```json
{
  "ids": [
    "ids5"
  ]
}
```

