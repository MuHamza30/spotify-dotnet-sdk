// <copyright file="ContextObject.cs" company="APIMatic">
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
    /// ContextObject.
    /// </summary>
    public class ContextObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextObject"/> class.
        /// </summary>
        public ContextObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextObject"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="href">href.</param>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="uri">uri.</param>
        public ContextObject(
            string type = null,
            string href = null,
            Models.ExternalUrlObject externalUrls = null,
            string uri = null)
        {
            this.Type = type;
            this.Href = href;
            this.ExternalUrls = externalUrls;
            this.Uri = uri;
        }

        /// <summary>
        /// The object type, e.g. "artist", "playlist", "album", "show".
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the track.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// External URLs for this context.
        /// </summary>
        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the context.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ContextObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ContextObject other &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.ExternalUrls == null && other.ExternalUrls == null ||
                 this.ExternalUrls?.Equals(other.ExternalUrls) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
        }
    }
}