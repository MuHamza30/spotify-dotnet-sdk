
# Me Following Request

## Structure

`MeFollowingRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Ids` | `List<string>` | Required | A JSON array of the artist or user [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids).<br>For example: `{ids:["74ASZWbe4lXaubB36ztrGX", "08td7MxkoHQkXnWAYD8d6Q"]}`. A maximum of 50 IDs can be sent in one request. _**Note**: if the `ids` parameter is present in the query string, any IDs listed here in the body will be ignored._ |

## Example (as JSON)

```json
{
  "ids": [
    "ids5",
    "ids6"
  ]
}
```

