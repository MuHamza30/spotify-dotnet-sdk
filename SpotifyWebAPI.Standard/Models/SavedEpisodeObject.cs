// <copyright file="SavedEpisodeObject.cs" company="APIMatic">
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
    /// SavedEpisodeObject.
    /// </summary>
    public class SavedEpisodeObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavedEpisodeObject"/> class.
        /// </summary>
        public SavedEpisodeObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedEpisodeObject"/> class.
        /// </summary>
        /// <param name="addedAt">added_at.</param>
        /// <param name="episode">episode.</param>
        public SavedEpisodeObject(
            DateTime? addedAt = null,
            Models.EpisodeObject episode = null)
        {
            this.AddedAt = addedAt;
            this.Episode = episode;
        }

        /// <summary>
        /// The date and time the episode was saved.
        /// Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("added_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddedAt { get; set; }

        /// <summary>
        /// Information about the episode.
        /// </summary>
        [JsonProperty("episode", NullValueHandling = NullValueHandling.Ignore)]
        public Models.EpisodeObject Episode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SavedEpisodeObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SavedEpisodeObject other &&
                (this.AddedAt == null && other.AddedAt == null ||
                 this.AddedAt?.Equals(other.AddedAt) == true) &&
                (this.Episode == null && other.Episode == null ||
                 this.Episode?.Equals(other.Episode) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AddedAt = {(this.AddedAt == null ? "null" : this.AddedAt.ToString())}");
            toStringOutput.Add($"Episode = {(this.Episode == null ? "null" : this.Episode.ToString())}");
        }
    }
}