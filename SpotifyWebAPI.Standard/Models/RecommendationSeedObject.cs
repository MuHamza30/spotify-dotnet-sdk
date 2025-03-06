// <copyright file="RecommendationSeedObject.cs" company="APIMatic">
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
    /// RecommendationSeedObject.
    /// </summary>
    public class RecommendationSeedObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendationSeedObject"/> class.
        /// </summary>
        public RecommendationSeedObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendationSeedObject"/> class.
        /// </summary>
        /// <param name="afterFilteringSize">afterFilteringSize.</param>
        /// <param name="afterRelinkingSize">afterRelinkingSize.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="initialPoolSize">initialPoolSize.</param>
        /// <param name="type">type.</param>
        public RecommendationSeedObject(
            int? afterFilteringSize = null,
            int? afterRelinkingSize = null,
            string href = null,
            string id = null,
            int? initialPoolSize = null,
            string type = null)
        {
            this.AfterFilteringSize = afterFilteringSize;
            this.AfterRelinkingSize = afterRelinkingSize;
            this.Href = href;
            this.Id = id;
            this.InitialPoolSize = initialPoolSize;
            this.Type = type;
        }

        /// <summary>
        /// The number of tracks available after min\_\* and max\_\* filters have been applied.
        /// </summary>
        [JsonProperty("afterFilteringSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? AfterFilteringSize { get; set; }

        /// <summary>
        /// The number of tracks available after relinking for regional availability.
        /// </summary>
        [JsonProperty("afterRelinkingSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? AfterRelinkingSize { get; set; }

        /// <summary>
        /// A link to the full track or artist data for this seed. For tracks this will be a link to a Track Object. For artists a link to an Artist Object. For genre seeds, this value will be `null`.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// The id used to select this seed. This will be the same as the string used in the `seed_artists`, `seed_tracks` or `seed_genres` parameter.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// The number of recommended tracks available for this seed.
        /// </summary>
        [JsonProperty("initialPoolSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? InitialPoolSize { get; set; }

        /// <summary>
        /// The entity type of this seed. One of `artist`, `track` or `genre`.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RecommendationSeedObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RecommendationSeedObject other &&
                (this.AfterFilteringSize == null && other.AfterFilteringSize == null ||
                 this.AfterFilteringSize?.Equals(other.AfterFilteringSize) == true) &&
                (this.AfterRelinkingSize == null && other.AfterRelinkingSize == null ||
                 this.AfterRelinkingSize?.Equals(other.AfterRelinkingSize) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.InitialPoolSize == null && other.InitialPoolSize == null ||
                 this.InitialPoolSize?.Equals(other.InitialPoolSize) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AfterFilteringSize = {(this.AfterFilteringSize == null ? "null" : this.AfterFilteringSize.ToString())}");
            toStringOutput.Add($"AfterRelinkingSize = {(this.AfterRelinkingSize == null ? "null" : this.AfterRelinkingSize.ToString())}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"InitialPoolSize = {(this.InitialPoolSize == null ? "null" : this.InitialPoolSize.ToString())}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
        }
    }
}