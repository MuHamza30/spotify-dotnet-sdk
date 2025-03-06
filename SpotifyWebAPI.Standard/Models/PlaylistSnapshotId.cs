// <copyright file="PlaylistSnapshotId.cs" company="APIMatic">
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
    /// PlaylistSnapshotId.
    /// </summary>
    public class PlaylistSnapshotId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistSnapshotId"/> class.
        /// </summary>
        public PlaylistSnapshotId()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistSnapshotId"/> class.
        /// </summary>
        /// <param name="snapshotId">snapshot_id.</param>
        public PlaylistSnapshotId(
            string snapshotId = null)
        {
            this.SnapshotId = snapshotId;
        }

        /// <summary>
        /// Gets or sets SnapshotId.
        /// </summary>
        [JsonProperty("snapshot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SnapshotId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistSnapshotId : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistSnapshotId other &&
                (this.SnapshotId == null && other.SnapshotId == null ||
                 this.SnapshotId?.Equals(other.SnapshotId) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"SnapshotId = {this.SnapshotId ?? "null"}");
        }
    }
}