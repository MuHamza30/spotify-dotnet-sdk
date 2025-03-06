// <copyright file="PlaylistsTracksRequest.cs" company="APIMatic">
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
    /// PlaylistsTracksRequest.
    /// </summary>
    public class PlaylistsTracksRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsTracksRequest"/> class.
        /// </summary>
        public PlaylistsTracksRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsTracksRequest"/> class.
        /// </summary>
        /// <param name="uris">uris.</param>
        /// <param name="position">position.</param>
        public PlaylistsTracksRequest(
            List<string> uris = null,
            int? position = null)
        {
            this.Uris = uris;
            this.Position = position;
        }

        /// <summary>
        /// A JSON array of the [Spotify URIs](/documentation/web-api/concepts/spotify-uris-ids) to add. For example: `{"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh","spotify:track:1301WleyT98MSxVHPZCA6M", "spotify:episode:512ojhOuo1ktJprKbVcKyQ"]}`<br/>A maximum of 100 items can be added in one request. _**Note**: if the `uris` parameter is present in the query string, any URIs listed here in the body will be ignored._
        /// </summary>
        [JsonProperty("uris", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Uris { get; set; }

        /// <summary>
        /// The position to insert the items, a zero-based index. For example, to insert the items in the first position: `position=0` ; to insert the items in the third position: `position=2`. If omitted, the items will be appended to the playlist. Items are added in the order they appear in the uris array. For example: `{"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh","spotify:track:1301WleyT98MSxVHPZCA6M"], "position": 3}`
        /// </summary>
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public int? Position { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistsTracksRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistsTracksRequest other &&
                (this.Uris == null && other.Uris == null ||
                 this.Uris?.Equals(other.Uris) == true) &&
                (this.Position == null && other.Position == null ||
                 this.Position?.Equals(other.Position) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uris = {(this.Uris == null ? "null" : $"[{string.Join(", ", this.Uris)} ]")}");
            toStringOutput.Add($"Position = {(this.Position == null ? "null" : this.Position.ToString())}");
        }
    }
}