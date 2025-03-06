
# Playlist Object

## Structure

`PlaylistObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Collaborative` | `bool?` | Optional | `true` if the owner allows other users to modify the playlist. |
| `Description` | `string` | Optional | The playlist description. _Only returned for modified, verified playlists, otherwise_ `null`. |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | Known external URLs for this playlist. |
| `Followers` | [`FollowersObject`](../../doc/models/followers-object.md) | Optional | Information about the followers of the playlist. |
| `Href` | `string` | Optional | A link to the Web API endpoint providing full details of the playlist. |
| `Id` | `string` | Optional | The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the playlist. |
| `Images` | [`List<ImageObject>`](../../doc/models/image-object.md) | Optional | Images for the playlist. The array may be empty or contain up to three images. The images are returned by size in descending order. See [Working with Playlists](/documentation/web-api/concepts/playlists). _**Note**: If returned, the source URL for the image (`url`) is temporary and will expire in less than a day._ |
| `Name` | `string` | Optional | The name of the playlist. |
| `Owner` | [`PlaylistOwnerObject`](../../doc/models/playlist-owner-object.md) | Optional | The user who owns the playlist |
| `Public` | `bool?` | Optional | The playlist's public/private status: `true` the playlist is public, `false` the playlist is private, `null` the playlist status is not relevant. For more about public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists) |
| `SnapshotId` | `string` | Optional | The version identifier for the current playlist. Can be supplied in other requests to target a specific playlist version |
| `Tracks` | [`PagingPlaylistTrackObject`](../../doc/models/paging-playlist-track-object.md) | Optional | The tracks of the playlist. |
| `Type` | `string` | Optional | The object type: "playlist" |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the playlist. |

## Example (as JSON)

```json
{
  "collaborative": false,
  "description": "description6",
  "external_urls": {
    "spotify": "spotify6"
  },
  "followers": {
    "href": "href0",
    "total": 82
  },
  "href": "href8"
}
```

