
# Me Episodes Request

## Structure

`MeEpisodesRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Ids` | `List<string>` | Required | A JSON array of the [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids). <br/>A maximum of 50 items can be specified in one request. _**Note**: if the `ids` parameter is present in the query string, any IDs listed here in the body will be ignored._ |

## Example (as JSON)

```json
{
  "ids": [
    "ids1",
    "ids2",
    "ids3"
  ]
}
```

