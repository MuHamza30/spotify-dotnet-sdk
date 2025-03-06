// <copyright file="ArtistObject.cs" company="APIMatic">
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
    /// ArtistObject.
    /// </summary>
    public class ArtistObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistObject"/> class.
        /// </summary>
        public ArtistObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistObject"/> class.
        /// </summary>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="followers">followers.</param>
        /// <param name="genres">genres.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="images">images.</param>
        /// <param name="name">name.</param>
        /// <param name="popularity">popularity.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        public ArtistObject(
            Models.ExternalUrlObject externalUrls = null,
            Models.FollowersObject followers = null,
            List<string> genres = null,
            string href = null,
            string id = null,
            List<Models.ImageObject> images = null,
            string name = null,
            int? popularity = null,
            Models.TypeEnum? type = null,
            string uri = null)
        {
            this.ExternalUrls = externalUrls;
            this.Followers = followers;
            this.Genres = genres;
            this.Href = href;
            this.Id = id;
            this.Images = images;
            this.Name = name;
            this.Popularity = popularity;
            this.Type = type;
            this.Uri = uri;
        }

        /// <summary>
        /// Known external URLs for this artist.
        /// </summary>
        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// Information about the followers of the artist.
        /// </summary>
        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FollowersObject Followers { get; set; }

        /// <summary>
        /// A list of the genres the artist is associated with. If not yet classified, the array is empty.
        /// </summary>
        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Genres { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the artist.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the artist.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Images of the artist in various sizes, widest first.
        /// </summary>
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ImageObject> Images { get; set; }

        /// <summary>
        /// The name of the artist.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The popularity of the artist. The value will be between 0 and 100, with 100 being the most popular. The artist's popularity is calculated from the popularity of all the artist's tracks.
        /// </summary>
        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Popularity { get; set; }

        /// <summary>
        /// The object type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TypeEnum? Type { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the artist.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ArtistObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ArtistObject other &&
                (this.ExternalUrls == null && other.ExternalUrls == null ||
                 this.ExternalUrls?.Equals(other.ExternalUrls) == true) &&
                (this.Followers == null && other.Followers == null ||
                 this.Followers?.Equals(other.Followers) == true) &&
                (this.Genres == null && other.Genres == null ||
                 this.Genres?.Equals(other.Genres) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Images == null && other.Images == null ||
                 this.Images?.Equals(other.Images) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.Popularity == null && other.Popularity == null ||
                 this.Popularity?.Equals(other.Popularity) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Followers = {(this.Followers == null ? "null" : this.Followers.ToString())}");
            toStringOutput.Add($"Genres = {(this.Genres == null ? "null" : $"[{string.Join(", ", this.Genres)} ]")}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Images = {(this.Images == null ? "null" : $"[{string.Join(", ", this.Images)} ]")}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"Popularity = {(this.Popularity == null ? "null" : this.Popularity.ToString())}");
            toStringOutput.Add($"Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
        }
    }
}