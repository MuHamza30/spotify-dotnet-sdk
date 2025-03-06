
# Meta

## Structure

`Meta`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AnalyzerVersion` | `string` | Optional | The version of the Analyzer used to analyze this track. |
| `Platform` | `string` | Optional | The platform used to read the track's audio data. |
| `DetailedStatus` | `string` | Optional | A detailed status code for this track. If analysis data is missing, this code may explain why. |
| `StatusCode` | `int?` | Optional | The return code of the analyzer process. 0 if successful, 1 if any errors occurred. |
| `Timestamp` | `long?` | Optional | The Unix timestamp (in seconds) at which this track was analyzed. |
| `AnalysisTime` | `double?` | Optional | The amount of time taken to analyze this track. |
| `InputProcess` | `string` | Optional | The method used to read the track's audio data. |

## Example (as JSON)

```json
{
  "analyzer_version": "4.0.0",
  "platform": "Linux",
  "detailed_status": "OK",
  "status_code": 0,
  "timestamp": 1495193577,
  "analysis_time": 6.93906,
  "input_process": "libvorbisfile L+R 44100->22050"
}
```

