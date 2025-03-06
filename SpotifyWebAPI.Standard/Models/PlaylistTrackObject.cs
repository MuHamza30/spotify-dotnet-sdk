// <copyright file="PlaylistTrackObject.cs" company="APIMatic">
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
using SpotifyWebAPI.Standard.Models.Containers;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// PlaylistTrackObject.
    /// </summary>
    public class PlaylistTrackObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistTrackObject"/> class.
        /// </summary>
        public PlaylistTrackObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistTrackObject"/> class.
        /// </summary>
        /// <param name="addedAt">added_at.</param>
        /// <param name="addedBy">added_by.</param>
        /// <param name="isLocal">is_local.</param>
        /// <param name="track">track.</param>
        public PlaylistTrackObject(
            DateTime? addedAt = null,
            Models.PlaylistUserObject addedBy = null,
            bool? isLocal = null,
            PlaylistTrackObjectTrack track = null)
        {
            this.AddedAt = addedAt;
            this.AddedBy = addedBy;
            this.IsLocal = isLocal;
            this.Track = track;
        }

        /// <summary>
        /// The date and time the track or episode was added. _**Note**: some very old playlists may return `null` in this field._
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("added_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddedAt { get; set; }

        /// <summary>
        /// The Spotify user who added the track or episode. _**Note**: some very old playlists may return `null` in this field._
        /// </summary>
        [JsonProperty("added_by", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PlaylistUserObject AddedBy { get; set; }

        /// <summary>
        /// Whether this track or episode is a [local file](/documentation/web-api/concepts/playlists/#local-files) or not.
        /// </summary>
        [JsonProperty("is_local", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLocal { get; set; }

        /// <summary>
        /// Information about the track or episode.
        /// </summary>
        [JsonProperty("track", NullValueHandling = NullValueHandling.Ignore)]
        public PlaylistTrackObjectTrack Track { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistTrackObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistTrackObject other &&
                (this.AddedAt == null && other.AddedAt == null ||
                 this.AddedAt?.Equals(other.AddedAt) == true) &&
                (this.AddedBy == null && other.AddedBy == null ||
                 this.AddedBy?.Equals(other.AddedBy) == true) &&
                (this.IsLocal == null && other.IsLocal == null ||
                 this.IsLocal?.Equals(other.IsLocal) == true) &&
                (this.Track == null && other.Track == null ||
                 this.Track?.Equals(other.Track) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AddedAt = {(this.AddedAt == null ? "null" : this.AddedAt.ToString())}");
            toStringOutput.Add($"AddedBy = {(this.AddedBy == null ? "null" : this.AddedBy.ToString())}");
            toStringOutput.Add($"IsLocal = {(this.IsLocal == null ? "null" : this.IsLocal.ToString())}");
            toStringOutput.Add($"Track = {(this.Track == null ? "null" : this.Track.ToString())}");
        }
    }
}