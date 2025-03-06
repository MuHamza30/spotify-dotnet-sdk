// <copyright file="PlaylistsTracksRequest1.cs" company="APIMatic">
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
    /// PlaylistsTracksRequest1.
    /// </summary>
    public class PlaylistsTracksRequest1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsTracksRequest1"/> class.
        /// </summary>
        public PlaylistsTracksRequest1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsTracksRequest1"/> class.
        /// </summary>
        /// <param name="uris">uris.</param>
        /// <param name="rangeStart">range_start.</param>
        /// <param name="insertBefore">insert_before.</param>
        /// <param name="rangeLength">range_length.</param>
        /// <param name="snapshotId">snapshot_id.</param>
        public PlaylistsTracksRequest1(
            List<string> uris = null,
            int? rangeStart = null,
            int? insertBefore = null,
            int? rangeLength = null,
            string snapshotId = null)
        {
            this.Uris = uris;
            this.RangeStart = rangeStart;
            this.InsertBefore = insertBefore;
            this.RangeLength = rangeLength;
            this.SnapshotId = snapshotId;
        }

        /// <summary>
        /// Gets or sets Uris.
        /// </summary>
        [JsonProperty("uris", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Uris { get; set; }

        /// <summary>
        /// The position of the first item to be reordered.
        /// </summary>
        [JsonProperty("range_start", NullValueHandling = NullValueHandling.Ignore)]
        public int? RangeStart { get; set; }

        /// <summary>
        /// The position where the items should be inserted.<br/>To reorder the items to the end of the playlist, simply set _insert_before_ to the position after the last item.<br/>Examples:<br/>To reorder the first item to the last position in a playlist with 10 items, set _range_start_ to 0, and _insert_before_ to 10.<br/>To reorder the last item in a playlist with 10 items to the start of the playlist, set _range_start_ to 9, and _insert_before_ to 0.
        /// </summary>
        [JsonProperty("insert_before", NullValueHandling = NullValueHandling.Ignore)]
        public int? InsertBefore { get; set; }

        /// <summary>
        /// The amount of items to be reordered. Defaults to 1 if not set.<br/>The range of items to be reordered begins from the _range_start_ position, and includes the _range_length_ subsequent items.<br/>Example:<br/>To move the items at index 9-10 to the start of the playlist, _range_start_ is set to 9, and _range_length_ is set to 2.
        /// </summary>
        [JsonProperty("range_length", NullValueHandling = NullValueHandling.Ignore)]
        public int? RangeLength { get; set; }

        /// <summary>
        /// The playlist's snapshot ID against which you want to make the changes.
        /// </summary>
        [JsonProperty("snapshot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SnapshotId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistsTracksRequest1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistsTracksRequest1 other &&
                (this.Uris == null && other.Uris == null ||
                 this.Uris?.Equals(other.Uris) == true) &&
                (this.RangeStart == null && other.RangeStart == null ||
                 this.RangeStart?.Equals(other.RangeStart) == true) &&
                (this.InsertBefore == null && other.InsertBefore == null ||
                 this.InsertBefore?.Equals(other.InsertBefore) == true) &&
                (this.RangeLength == null && other.RangeLength == null ||
                 this.RangeLength?.Equals(other.RangeLength) == true) &&
                (this.SnapshotId == null && other.SnapshotId == null ||
                 this.SnapshotId?.Equals(other.SnapshotId) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uris = {(this.Uris == null ? "null" : $"[{string.Join(", ", this.Uris)} ]")}");
            toStringOutput.Add($"RangeStart = {(this.RangeStart == null ? "null" : this.RangeStart.ToString())}");
            toStringOutput.Add($"InsertBefore = {(this.InsertBefore == null ? "null" : this.InsertBefore.ToString())}");
            toStringOutput.Add($"RangeLength = {(this.RangeLength == null ? "null" : this.RangeLength.ToString())}");
            toStringOutput.Add($"SnapshotId = {this.SnapshotId ?? "null"}");
        }
    }
}