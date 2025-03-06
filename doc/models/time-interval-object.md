
# Time Interval Object

## Structure

`TimeIntervalObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Start` | `double?` | Optional | The starting point (in seconds) of the time interval. |
| `Duration` | `double?` | Optional | The duration (in seconds) of the time interval. |
| `Confidence` | `double?` | Optional | The confidence, from 0.0 to 1.0, of the reliability of the interval.<br>**Constraints**: `>= 0`, `<= 1` |

## Example (as JSON)

```json
{
  "start": 0.49567,
  "duration": 2.18749,
  "confidence": 0.925
}
```

