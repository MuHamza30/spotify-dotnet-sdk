// <copyright file="PagingFeaturedPlaylistObject.cs" company="APIMatic">
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
    /// PagingFeaturedPlaylistObject.
    /// </summary>
    public class PagingFeaturedPlaylistObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagingFeaturedPlaylistObject"/> class.
        /// </summary>
        public PagingFeaturedPlaylistObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingFeaturedPlaylistObject"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="playlists">playlists.</param>
        public PagingFeaturedPlaylistObject(
            string message = null,
            Models.PagingPlaylistObject playlists = null)
        {
            this.Message = message;
            this.Playlists = playlists;
        }

        /// <summary>
        /// The localized message of a playlist.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Playlists.
        /// </summary>
        [JsonProperty("playlists", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PagingPlaylistObject Playlists { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PagingFeaturedPlaylistObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PagingFeaturedPlaylistObject other &&
                (this.Message == null && other.Message == null ||
                 this.Message?.Equals(other.Message) == true) &&
                (this.Playlists == null && other.Playlists == null ||
                 this.Playlists?.Equals(other.Playlists) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Message = {this.Message ?? "null"}");
            toStringOutput.Add($"Playlists = {(this.Playlists == null ? "null" : this.Playlists.ToString())}");
        }
    }
}