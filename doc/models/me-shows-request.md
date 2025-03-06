
# Me Shows Request

## Structure

`MeShowsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Ids` | `List<string>` | Optional | A JSON array of the [Spotify IDs](https://developer.spotify.com/documentation/web-api/#spotify-uris-and-ids).  <br>A maximum of 50 items can be specified in one request. *Note: if the `ids` parameter is present in the query string, any IDs listed here in the body will be ignored.* |

## Example (as JSON)

```json
{
  "ids": [
    "ids9",
    "ids0",
    "ids1"
  ]
}
```

