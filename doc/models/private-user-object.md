
# Private User Object

## Structure

`PrivateUserObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Country` | `string` | Optional | The country of the user, as set in the user's account profile. An [ISO 3166-1 alpha-2 country code](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _This field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._ |
| `DisplayName` | `string` | Optional | The name displayed on the user's profile. `null` if not available. |
| `Email` | `string` | Optional | The user's email address, as entered by the user when creating their account. _**Important!** This email address is unverified; there is no proof that it actually belongs to the user._ _This field is only available when the current user has granted access to the [user-read-email](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._ |
| `ExplicitContent` | [`ExplicitContentSettingsObject`](../../doc/models/explicit-content-settings-object.md) | Optional | The user's explicit content settings. _This field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._ |
| `ExternalUrls` | [`ExternalUrlObject`](../../doc/models/external-url-object.md) | Optional | Known external URLs for this user. |
| `Followers` | [`FollowersObject`](../../doc/models/followers-object.md) | Optional | Information about the followers of the user. |
| `Href` | `string` | Optional | A link to the Web API endpoint for this user. |
| `Id` | `string` | Optional | The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for the user. |
| `Images` | [`List<ImageObject>`](../../doc/models/image-object.md) | Optional | The user's profile image. |
| `Product` | `string` | Optional | The user's Spotify subscription level: "premium", "free", etc. (The subscription level "open" can be considered the same as "free".) _This field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._ |
| `Type` | `string` | Optional | The object type: "user" |
| `Uri` | `string` | Optional | The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the user. |

## Example (as JSON)

```json
{
  "country": "country2",
  "display_name": "display_name8",
  "email": "email8",
  "explicit_content": {
    "filter_enabled": false,
    "filter_locked": false
  },
  "external_urls": {
    "spotify": "spotify6"
  }
}
```

