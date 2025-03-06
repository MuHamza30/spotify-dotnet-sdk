
# Me Episodes Request 1

## Structure

`MeEpisodesRequest1`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Ids` | `List<string>` | Optional | A JSON array of the [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids). <br/>A maximum of 50 items can be specified in one request. _**Note**: if the `ids` parameter is present in the query string, any IDs listed here in the body will be ignored._ |

## Example (as JSON)

```json
{
  "ids": [
    "ids3"
  ]
}
```

