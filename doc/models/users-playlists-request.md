
# Users Playlists Request

## Structure

`UsersPlaylistsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Required | The name for the new playlist, for example `"Your Coolest Playlist"`. This name does not need to be unique; a user may have several playlists with the same name. |
| `Public` | `bool?` | Optional | Defaults to `true`. If `true` the playlist will be public, if `false` it will be private. To be able to create private playlists, the user must have granted the `playlist-modify-private` [scope](/documentation/web-api/concepts/scopes/#list-of-scopes) |
| `Collaborative` | `bool?` | Optional | Defaults to `false`. If `true` the playlist will be collaborative. _**Note**: to create a collaborative playlist you must also set `public` to `false`. To create collaborative playlists you must have granted `playlist-modify-private` and `playlist-modify-public` [scopes](/documentation/web-api/concepts/scopes/#list-of-scopes)._ |
| `Description` | `string` | Optional | value for playlist description as displayed in Spotify Clients and in the Web API. |

## Example (as JSON)

```json
{
  "name": "New Playlist",
  "description": "New playlist description",
  "public": false,
  "collaborative": false
}
```

