// <copyright file="ShowObject.cs" company="APIMatic">
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
    /// ShowObject.
    /// </summary>
    public class ShowObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowObject"/> class.
        /// </summary>
        public ShowObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowObject"/> class.
        /// </summary>
        /// <param name="availableMarkets">available_markets.</param>
        /// <param name="copyrights">copyrights.</param>
        /// <param name="description">description.</param>
        /// <param name="htmlDescription">html_description.</param>
        /// <param name="mExplicit">explicit.</param>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="images">images.</param>
        /// <param name="isExternallyHosted">is_externally_hosted.</param>
        /// <param name="languages">languages.</param>
        /// <param name="mediaType">media_type.</param>
        /// <param name="name">name.</param>
        /// <param name="publisher">publisher.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        /// <param name="totalEpisodes">total_episodes.</param>
        /// <param name="episodes">episodes.</param>
        public ShowObject(
            List<string> availableMarkets,
            List<Models.CopyrightObject> copyrights,
            string description,
            string htmlDescription,
            bool mExplicit,
            Models.ExternalUrlObject externalUrls,
            string href,
            string id,
            List<Models.ImageObject> images,
            bool isExternallyHosted,
            List<string> languages,
            string mediaType,
            string name,
            string publisher,
            string type,
            string uri,
            int totalEpisodes,
            Models.PagingSimplifiedEpisodeObject episodes)
        {
            this.AvailableMarkets = availableMarkets;
            this.Copyrights = copyrights;
            this.Description = description;
            this.HtmlDescription = htmlDescription;
            this.MExplicit = mExplicit;
            this.ExternalUrls = externalUrls;
            this.Href = href;
            this.Id = id;
            this.Images = images;
            this.IsExternallyHosted = isExternallyHosted;
            this.Languages = languages;
            this.MediaType = mediaType;
            this.Name = name;
            this.Publisher = publisher;
            this.Type = type;
            this.Uri = uri;
            this.TotalEpisodes = totalEpisodes;
            this.Episodes = episodes;
        }

        /// <summary>
        /// A list of the countries in which the show can be played, identified by their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code.
        /// </summary>
        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The copyright statements of the show.
        /// </summary>
        [JsonProperty("copyrights")]
        public List<Models.CopyrightObject> Copyrights { get; set; }

        /// <summary>
        /// A description of the show. HTML tags are stripped away from this field, use `html_description` field in case HTML tags are needed.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A description of the show. This field may contain HTML tags.
        /// </summary>
        [JsonProperty("html_description")]
        public string HtmlDescription { get; set; }

        /// <summary>
        /// Whether or not the show has explicit content (true = yes it does; false = no it does not OR unknown).
        /// </summary>
        [JsonProperty("explicit")]
        public bool MExplicit { get; set; }

        /// <summary>
        /// External URLs for this show.
        /// </summary>
        [JsonProperty("external_urls")]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the show.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the show.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The cover art for the show in various sizes, widest first.
        /// </summary>
        [JsonProperty("images")]
        public List<Models.ImageObject> Images { get; set; }

        /// <summary>
        /// True if all of the shows episodes are hosted outside of Spotify's CDN. This field might be `null` in some cases.
        /// </summary>
        [JsonProperty("is_externally_hosted")]
        public bool IsExternallyHosted { get; set; }

        /// <summary>
        /// A list of the languages used in the show, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639) code.
        /// </summary>
        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        /// <summary>
        /// The media type of the show.
        /// </summary>
        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        /// <summary>
        /// The name of the episode.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The publisher of the show.
        /// </summary>
        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// The object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the show.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The total number of episodes in the show.
        /// </summary>
        [JsonProperty("total_episodes")]
        public int TotalEpisodes { get; set; }

        /// <summary>
        /// The episodes of the show.
        /// </summary>
        [JsonProperty("episodes")]
        public Models.PagingSimplifiedEpisodeObject Episodes { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ShowObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ShowObject other &&
                (this.AvailableMarkets == null && other.AvailableMarkets == null ||
                 this.AvailableMarkets?.Equals(other.AvailableMarkets) == true) &&
                (this.Copyrights == null && other.Copyrights == null ||
                 this.Copyrights?.Equals(other.Copyrights) == true) &&
                (this.Description == null && other.Description == null ||
                 this.Description?.Equals(other.Description) == true) &&
                (this.HtmlDescription == null && other.HtmlDescription == null ||
                 this.HtmlDescription?.Equals(other.HtmlDescription) == true) &&
                (this.MExplicit.Equals(other.MExplicit)) &&
                (this.ExternalUrls == null && other.ExternalUrls == null ||
                 this.ExternalUrls?.Equals(other.ExternalUrls) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Images == null && other.Images == null ||
                 this.Images?.Equals(other.Images) == true) &&
                (this.IsExternallyHosted.Equals(other.IsExternallyHosted)) &&
                (this.Languages == null && other.Languages == null ||
                 this.Languages?.Equals(other.Languages) == true) &&
                (this.MediaType == null && other.MediaType == null ||
                 this.MediaType?.Equals(other.MediaType) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.Publisher == null && other.Publisher == null ||
                 this.Publisher?.Equals(other.Publisher) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true) &&
                (this.TotalEpisodes.Equals(other.TotalEpisodes)) &&
                (this.Episodes == null && other.Episodes == null ||
                 this.Episodes?.Equals(other.Episodes) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AvailableMarkets = {(this.AvailableMarkets == null ? "null" : $"[{string.Join(", ", this.AvailableMarkets)} ]")}");
            toStringOutput.Add($"Copyrights = {(this.Copyrights == null ? "null" : $"[{string.Join(", ", this.Copyrights)} ]")}");
            toStringOutput.Add($"Description = {this.Description ?? "null"}");
            toStringOutput.Add($"HtmlDescription = {this.HtmlDescription ?? "null"}");
            toStringOutput.Add($"MExplicit = {this.MExplicit}");
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Images = {(this.Images == null ? "null" : $"[{string.Join(", ", this.Images)} ]")}");
            toStringOutput.Add($"IsExternallyHosted = {this.IsExternallyHosted}");
            toStringOutput.Add($"Languages = {(this.Languages == null ? "null" : $"[{string.Join(", ", this.Languages)} ]")}");
            toStringOutput.Add($"MediaType = {this.MediaType ?? "null"}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"Publisher = {this.Publisher ?? "null"}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
            toStringOutput.Add($"TotalEpisodes = {this.TotalEpisodes}");
            toStringOutput.Add($"Episodes = {(this.Episodes == null ? "null" : this.Episodes.ToString())}");
        }
    }
}