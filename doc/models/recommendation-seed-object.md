
# Recommendation Seed Object

## Structure

`RecommendationSeedObject`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AfterFilteringSize` | `int?` | Optional | The number of tracks available after min\_\* and max\_\* filters have been applied. |
| `AfterRelinkingSize` | `int?` | Optional | The number of tracks available after relinking for regional availability. |
| `Href` | `string` | Optional | A link to the full track or artist data for this seed. For tracks this will be a link to a Track Object. For artists a link to an Artist Object. For genre seeds, this value will be `null`. |
| `Id` | `string` | Optional | The id used to select this seed. This will be the same as the string used in the `seed_artists`, `seed_tracks` or `seed_genres` parameter. |
| `InitialPoolSize` | `int?` | Optional | The number of recommended tracks available for this seed. |
| `Type` | `string` | Optional | The entity type of this seed. One of `artist`, `track` or `genre`. |

## Example (as JSON)

```json
{
  "afterFilteringSize": 208,
  "afterRelinkingSize": 228,
  "href": "href4",
  "id": "id2",
  "initialPoolSize": 214
}
```

