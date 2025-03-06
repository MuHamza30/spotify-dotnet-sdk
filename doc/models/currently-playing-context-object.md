
# Currently Playing Context Object

## Structure

`CurrentlyPlayingContextObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Device` | [`DeviceObject`](../../doc/models/device-object.md) | Optional | The device that is currently active. |
| `RepeatState` | `string` | Optional | off, track, context |
| `ShuffleState` | `bool?` | Optional | If shuffle is on or off. |
| `Context` | [`ContextObject`](../../doc/models/context-object.md) | Optional | A Context Object. Can be `null`. |
| `Timestamp` | `long?` | Optional | Unix Millisecond Timestamp when data was fetched. |
| `ProgressMs` | `int?` | Optional | Progress into the currently playing track or episode. Can be `null`. |
| `IsPlaying` | `bool?` | Optional | If something is currently playing, return `true`. |
| `Item` | [`CurrentlyPlayingContextObjectItem`](../../doc/models/containers/currently-playing-context-object-item.md) | Optional | This is a container for one-of cases. |
| `CurrentlyPlayingType` | `string` | Optional | The object type of the currently playing item. Can be one of `track`, `episode`, `ad` or `unknown`. |
| `Actions` | [`DisallowsObject`](../../doc/models/disallows-object.md) | Optional | Allows to update the user interface based on which playback actions are available within the current context. |

## Example (as JSON)

```json
{
  "device": {
    "id": "id6",
    "is_active": false,
    "is_private_session": false,
    "is_restricted": false,
    "name": "name6"
  },
  "repeat_state": "repeat_state6",
  "shuffle_state": false,
  "context": {
    "type": "type8",
    "href": "href4",
    "external_urls": {
      "spotify": "spotify6"
    },
    "uri": "uri6"
  },
  "timestamp": 48
}
```

