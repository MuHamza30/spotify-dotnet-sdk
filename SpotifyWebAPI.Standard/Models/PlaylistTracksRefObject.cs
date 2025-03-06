// <copyright file="PlaylistTracksRefObject.cs" company="APIMatic">
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
    /// PlaylistTracksRefObject.
    /// </summary>
    public class PlaylistTracksRefObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistTracksRefObject"/> class.
        /// </summary>
        public PlaylistTracksRefObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistTracksRefObject"/> class.
        /// </summary>
        /// <param name="href">href.</param>
        /// <param name="total">total.</param>
        public PlaylistTracksRefObject(
            string href = null,
            int? total = null)
        {
            this.Href = href;
            this.Total = total;
        }

        /// <summary>
        /// A link to the Web API endpoint where full details of the playlist's tracks can be retrieved.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// Number of tracks in the playlist.
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistTracksRefObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistTracksRefObject other &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Total == null && other.Total == null ||
                 this.Total?.Equals(other.Total) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Total = {(this.Total == null ? "null" : this.Total.ToString())}");
        }
    }
}