// <copyright file="PlaylistsRequest.cs" company="APIMatic">
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
    /// PlaylistsRequest.
    /// </summary>
    public class PlaylistsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsRequest"/> class.
        /// </summary>
        public PlaylistsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsRequest"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="mPublic">public.</param>
        /// <param name="collaborative">collaborative.</param>
        /// <param name="description">description.</param>
        public PlaylistsRequest(
            string name = null,
            bool? mPublic = null,
            bool? collaborative = null,
            string description = null)
        {
            this.Name = name;
            this.MPublic = mPublic;
            this.Collaborative = collaborative;
            this.Description = description;
        }

        /// <summary>
        /// The new name for the playlist, for example `"My New Playlist Title"`
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// If `true` the playlist will be public, if `false` it will be private.
        /// </summary>
        [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MPublic { get; set; }

        /// <summary>
        /// If `true`, the playlist will become collaborative and other users will be able to modify the playlist in their Spotify client. <br/>
        /// _**Note**: You can only set `collaborative` to `true` on non-public playlists._
        /// </summary>
        [JsonProperty("collaborative", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Collaborative { get; set; }

        /// <summary>
        /// Value for playlist description as displayed in Spotify Clients and in the Web API.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistsRequest other &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.MPublic == null && other.MPublic == null ||
                 this.MPublic?.Equals(other.MPublic) == true) &&
                (this.Collaborative == null && other.Collaborative == null ||
                 this.Collaborative?.Equals(other.Collaborative) == true) &&
                (this.Description == null && other.Description == null ||
                 this.Description?.Equals(other.Description) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"MPublic = {(this.MPublic == null ? "null" : this.MPublic.ToString())}");
            toStringOutput.Add($"Collaborative = {(this.Collaborative == null ? "null" : this.Collaborative.ToString())}");
            toStringOutput.Add($"Description = {this.Description ?? "null"}");
        }
    }
}