// <copyright file="PlaylistsFollowersRequest.cs" company="APIMatic">
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
    /// PlaylistsFollowersRequest.
    /// </summary>
    public class PlaylistsFollowersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsFollowersRequest"/> class.
        /// </summary>
        public PlaylistsFollowersRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsFollowersRequest"/> class.
        /// </summary>
        /// <param name="mPublic">public.</param>
        public PlaylistsFollowersRequest(
            bool? mPublic = null)
        {
            this.MPublic = mPublic;
        }

        /// <summary>
        /// Defaults to `true`. If `true` the playlist will be included in user's public playlists, if `false` it will remain private.
        /// </summary>
        [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MPublic { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlaylistsFollowersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlaylistsFollowersRequest other &&
                (this.MPublic == null && other.MPublic == null ||
                 this.MPublic?.Equals(other.MPublic) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"MPublic = {(this.MPublic == null ? "null" : this.MPublic.ToString())}");
        }
    }
}