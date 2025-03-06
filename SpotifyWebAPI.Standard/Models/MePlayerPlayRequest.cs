// <copyright file="MePlayerPlayRequest.cs" company="APIMatic">
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
    /// MePlayerPlayRequest.
    /// </summary>
    public class MePlayerPlayRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MePlayerPlayRequest"/> class.
        /// </summary>
        public MePlayerPlayRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MePlayerPlayRequest"/> class.
        /// </summary>
        /// <param name="contextUri">context_uri.</param>
        /// <param name="uris">uris.</param>
        /// <param name="offset">offset.</param>
        /// <param name="positionMs">position_ms.</param>
        public MePlayerPlayRequest(
            string contextUri = null,
            List<string> uris = null,
            object offset = null,
            int? positionMs = null)
        {
            this.ContextUri = contextUri;
            this.Uris = uris;
            this.Offset = offset;
            this.PositionMs = positionMs;
        }

        /// <summary>
        /// <![CDATA[
        /// Optional. Spotify URI of the context to play.
        /// Valid contexts are albums, artists & playlists.
        /// `{context_uri:"spotify:album:1Je1IMUlBXcx1Fz0WE7oPT"}`
        /// ]]>
        /// </summary>
        [JsonProperty("context_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string ContextUri { get; set; }

        /// <summary>
        /// Optional. A JSON array of the Spotify track URIs to play.
        /// For example: `{"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh", "spotify:track:1301WleyT98MSxVHPZCA6M"]}`
        /// </summary>
        [JsonProperty("uris", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Uris { get; set; }

        /// <summary>
        /// Optional. Indicates from where in the context playback should start. Only available when context_uri corresponds to an album or playlist object
        /// "position" is zero based and can’t be negative. Example: `"offset": {"position": 5}`
        /// "uri" is a string representing the uri of the item to start at. Example: `"offset": {"uri": "spotify:track:1301WleyT98MSxVHPZCA6M"}`
        /// </summary>
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public object Offset { get; set; }

        /// <summary>
        /// Indicates from what position to start playback. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song.
        /// </summary>
        [JsonProperty("position_ms", NullValueHandling = NullValueHandling.Ignore)]
        public int? PositionMs { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"MePlayerPlayRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is MePlayerPlayRequest other &&
                (this.ContextUri == null && other.ContextUri == null ||
                 this.ContextUri?.Equals(other.ContextUri) == true) &&
                (this.Uris == null && other.Uris == null ||
                 this.Uris?.Equals(other.Uris) == true) &&
                (this.Offset == null && other.Offset == null ||
                 this.Offset?.Equals(other.Offset) == true) &&
                (this.PositionMs == null && other.PositionMs == null ||
                 this.PositionMs?.Equals(other.PositionMs) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ContextUri = {this.ContextUri ?? "null"}");
            toStringOutput.Add($"Uris = {(this.Uris == null ? "null" : $"[{string.Join(", ", this.Uris)} ]")}");
            toStringOutput.Add($"Offset = {(this.Offset == null ? "null" : this.Offset.ToString())}");
            toStringOutput.Add($"PositionMs = {(this.PositionMs == null ? "null" : this.PositionMs.ToString())}");
        }
    }
}