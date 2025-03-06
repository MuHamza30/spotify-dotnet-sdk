// <copyright file="PlaylistsTracksRequest2.cs" company="APIMatic">
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
    /// PlaylistsTracksRequest2.
    /// </summary>
    public class PlaylistsTracksRequest2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsTracksRequest2"/> class.
        /// </summary>
        public PlaylistsTracksRequest2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsTracksRequest2"/> class.
        /// </summary>
        /// <param name="tracks">tracks.</param>
        /// <param name="snapshotId">snapshot_id.</param>
        public PlaylistsTracksRequest2(
            List<Models.Track1> tracks,
            string snapshotId = null)
        {
            this.Tracks = tracks;
            this.SnapshotId = snapshotId;
        }

        /// <summary>
        /// An array of objects containing [Spotify URIs](/documentation/web-api/concepts/spotify-uris-ids) of the tracks or episodes to remove.
        /// For example: `{ "tracks": [{ "uri": "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" },{ "uri": "spotify:track:1301WleyT98MSxVHPZCA6M" }] }`. A maximum of 100 objects can be sent at once.
        /// </summary>
        [JsonProperty("tracks")]
        public List<Models.Track1> Tracks { get; set; }

        /// <summary>
        /// The playlist's snapshot ID against which you want to make the changes.
        /// The API will validate that the specified items exist and in the specified positions and make the changes,
        /// even if more recent changes have been made to the playlist.
        /// </summary>
        [JsonProperty("snapshot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SnapshotId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistsTracksRequest2 : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistsTracksRequest2 other &&
                (this.Tracks == null && other.Tracks == null ||
                 this.Tracks?.Equals(other.Tracks) == true) &&
                (this.SnapshotId == null && other.SnapshotId == null ||
                 this.SnapshotId?.Equals(other.SnapshotId) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Tracks = {(this.Tracks == null ? "null" : $"[{string.Join(", ", this.Tracks)} ]")}");
            toStringOutput.Add($"SnapshotId = {this.SnapshotId ?? "null"}");
        }
    }
}