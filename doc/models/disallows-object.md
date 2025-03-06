
# Disallows Object

## Structure

`DisallowsObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `InterruptingPlayback` | `bool?` | Optional | Interrupting playback. Optional field. |
| `Pausing` | `bool?` | Optional | Pausing. Optional field. |
| `Resuming` | `bool?` | Optional | Resuming. Optional field. |
| `Seeking` | `bool?` | Optional | Seeking playback location. Optional field. |
| `SkippingNext` | `bool?` | Optional | Skipping to the next context. Optional field. |
| `SkippingPrev` | `bool?` | Optional | Skipping to the previous context. Optional field. |
| `TogglingRepeatContext` | `bool?` | Optional | Toggling repeat context flag. Optional field. |
| `TogglingShuffle` | `bool?` | Optional | Toggling shuffle flag. Optional field. |
| `TogglingRepeatTrack` | `bool?` | Optional | Toggling repeat track flag. Optional field. |
| `TransferringPlayback` | `bool?` | Optional | Transfering playback between devices. Optional field. |

## Example (as JSON)

```json
{
  "interrupting_playback": false,
  "pausing": false,
  "resuming": false,
  "seeking": false,
  "skipping_next": false
}
```

