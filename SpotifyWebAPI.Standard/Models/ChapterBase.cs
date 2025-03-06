// <copyright file="ChapterBase.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// ChapterBase.
    /// </summary>
    public class ChapterBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChapterBase"/> class.
        /// </summary>
        public ChapterBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChapterBase"/> class.
        /// </summary>
        /// <param name="chapterNumber">chapter_number.</param>
        /// <param name="description">description.</param>
        /// <param name="htmlDescription">html_description.</param>
        /// <param name="durationMs">duration_ms.</param>
        /// <param name="mExplicit">explicit.</param>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="images">images.</param>
        /// <param name="isPlayable">is_playable.</param>
        /// <param name="languages">languages.</param>
        /// <param name="name">name.</param>
        /// <param name="releaseDate">release_date.</param>
        /// <param name="releaseDatePrecision">release_date_precision.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        /// <param name="audioPreviewUrl">audio_preview_url.</param>
        /// <param name="availableMarkets">available_markets.</param>
        /// <param name="resumePoint">resume_point.</param>
        /// <param name="restrictions">restrictions.</param>
        public ChapterBase(
            int chapterNumber,
            string description,
            string htmlDescription,
            int durationMs,
            bool mExplicit,
            Models.ExternalUrlObject externalUrls,
            string href,
            string id,
            List<Models.ImageObject> images,
            bool isPlayable,
            List<string> languages,
            string name,
            string releaseDate,
            Models.ReleaseDatePrecisionEnum releaseDatePrecision,
            string type,
            string uri,
            string audioPreviewUrl = null,
            List<string> availableMarkets = null,
            Models.ResumePointObject resumePoint = null,
            Models.ChapterRestrictionObject restrictions = null)
        {
            this.AudioPreviewUrl = audioPreviewUrl;
            this.AvailableMarkets = availableMarkets;
            this.ChapterNumber = chapterNumber;
            this.Description = description;
            this.HtmlDescription = htmlDescription;
            this.DurationMs = durationMs;
            this.MExplicit = mExplicit;
            this.ExternalUrls = externalUrls;
            this.Href = href;
            this.Id = id;
            this.Images = images;
            this.IsPlayable = isPlayable;
            this.Languages = languages;
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.ReleaseDatePrecision = releaseDatePrecision;
            this.ResumePoint = resumePoint;
            this.Type = type;
            this.Uri = uri;
            this.Restrictions = restrictions;
        }

        /// <summary>
        /// A URL to a 30 second preview (MP3 format) of the chapter. `null` if not available.
        /// </summary>
        [JsonProperty("audio_preview_url", NullValueHandling = NullValueHandling.Include)]
        public string AudioPreviewUrl { get; set; }

        /// <summary>
        /// A list of the countries in which the chapter can be played, identified by their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code.
        /// </summary>
        [JsonProperty("available_markets", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The number of the chapter
        /// </summary>
        [JsonProperty("chapter_number")]
        public int ChapterNumber { get; set; }

        /// <summary>
        /// A description of the chapter. HTML tags are stripped away from this field, use `html_description` field in case HTML tags are needed.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A description of the chapter. This field may contain HTML tags.
        /// </summary>
        [JsonProperty("html_description")]
        public string HtmlDescription { get; set; }

        /// <summary>
        /// The chapter length in milliseconds.
        /// </summary>
        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        /// <summary>
        /// Whether or not the chapter has explicit content (true = yes it does; false = no it does not OR unknown).
        /// </summary>
        [JsonProperty("explicit")]
        public bool MExplicit { get; set; }

        /// <summary>
        /// External URLs for this chapter.
        /// </summary>
        [JsonProperty("external_urls")]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the chapter.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the chapter.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The cover art for the chapter in various sizes, widest first.
        /// </summary>
        [JsonProperty("images")]
        public List<Models.ImageObject> Images { get; set; }

        /// <summary>
        /// True if the chapter is playable in the given market. Otherwise false.
        /// </summary>
        [JsonProperty("is_playable")]
        public bool IsPlayable { get; set; }

        /// <summary>
        /// A list of the languages used in the chapter, identified by their [ISO 639-1](https://en.wikipedia.org/wiki/ISO_639) code.
        /// </summary>
        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        /// <summary>
        /// The name of the chapter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The date the chapter was first released, for example `"1981-12-15"`. Depending on the precision, it might be shown as `"1981"` or `"1981-12"`.
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which `release_date` value is known.
        /// </summary>
        [JsonProperty("release_date_precision")]
        public Models.ReleaseDatePrecisionEnum ReleaseDatePrecision { get; set; }

        /// <summary>
        /// The user's most recent position in the chapter. Set if the supplied access token is a user token and has the scope 'user-read-playback-position'.
        /// </summary>
        [JsonProperty("resume_point", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ResumePointObject ResumePoint { get; set; }

        /// <summary>
        /// The object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the chapter.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Included in the response when a content restriction is applied.
        /// </summary>
        [JsonProperty("restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ChapterRestrictionObject Restrictions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ChapterBase : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ChapterBase other &&
                (this.AudioPreviewUrl == null && other.AudioPreviewUrl == null ||
                 this.AudioPreviewUrl?.Equals(other.AudioPreviewUrl) == true) &&
                (this.AvailableMarkets == null && other.AvailableMarkets == null ||
                 this.AvailableMarkets?.Equals(other.AvailableMarkets) == true) &&
                (this.ChapterNumber.Equals(other.ChapterNumber)) &&
                (this.Description == null && other.Description == null ||
                 this.Description?.Equals(other.Description) == true) &&
                (this.HtmlDescription == null && other.HtmlDescription == null ||
                 this.HtmlDescription?.Equals(other.HtmlDescription) == true) &&
                (this.DurationMs.Equals(other.DurationMs)) &&
                (this.MExplicit.Equals(other.MExplicit)) &&
                (this.ExternalUrls == null && other.ExternalUrls == null ||
                 this.ExternalUrls?.Equals(other.ExternalUrls) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Images == null && other.Images == null ||
                 this.Images?.Equals(other.Images) == true) &&
                (this.IsPlayable.Equals(other.IsPlayable)) &&
                (this.Languages == null && other.Languages == null ||
                 this.Languages?.Equals(other.Languages) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.ReleaseDate == null && other.ReleaseDate == null ||
                 this.ReleaseDate?.Equals(other.ReleaseDate) == true) &&
                (this.ReleaseDatePrecision.Equals(other.ReleaseDatePrecision)) &&
                (this.ResumePoint == null && other.ResumePoint == null ||
                 this.ResumePoint?.Equals(other.ResumePoint) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true) &&
                (this.Restrictions == null && other.Restrictions == null ||
                 this.Restrictions?.Equals(other.Restrictions) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AudioPreviewUrl = {this.AudioPreviewUrl ?? "null"}");
            toStringOutput.Add($"AvailableMarkets = {(this.AvailableMarkets == null ? "null" : $"[{string.Join(", ", this.AvailableMarkets)} ]")}");
            toStringOutput.Add($"ChapterNumber = {this.ChapterNumber}");
            toStringOutput.Add($"Description = {this.Description ?? "null"}");
            toStringOutput.Add($"HtmlDescription = {this.HtmlDescription ?? "null"}");
            toStringOutput.Add($"DurationMs = {this.DurationMs}");
            toStringOutput.Add($"MExplicit = {this.MExplicit}");
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Images = {(this.Images == null ? "null" : $"[{string.Join(", ", this.Images)} ]")}");
            toStringOutput.Add($"IsPlayable = {this.IsPlayable}");
            toStringOutput.Add($"Languages = {(this.Languages == null ? "null" : $"[{string.Join(", ", this.Languages)} ]")}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"ReleaseDate = {this.ReleaseDate ?? "null"}");
            toStringOutput.Add($"ReleaseDatePrecision = {this.ReleaseDatePrecision}");
            toStringOutput.Add($"ResumePoint = {(this.ResumePoint == null ? "null" : this.ResumePoint.ToString())}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
            toStringOutput.Add($"Restrictions = {(this.Restrictions == null ? "null" : this.Restrictions.ToString())}");
        }
    }
}