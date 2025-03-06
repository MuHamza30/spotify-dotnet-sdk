// <copyright file="ManyTracks.cs" company="APIMatic">
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
    /// ManyTracks.
    /// </summary>
    public class ManyTracks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyTracks"/> class.
        /// </summary>
        public ManyTracks()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyTracks"/> class.
        /// </summary>
        /// <param name="tracks">tracks.</param>
        public ManyTracks(
            List<Models.TrackObject> tracks)
        {
            this.Tracks = tracks;
        }

        /// <summary>
        /// Gets or sets Tracks.
        /// </summary>
        [JsonProperty("tracks")]
        public List<Models.TrackObject> Tracks { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyTracks : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyTracks other &&
                (this.Tracks == null && other.Tracks == null ||
                 this.Tracks?.Equals(other.Tracks) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Tracks = {(this.Tracks == null ? "null" : $"[{string.Join(", ", this.Tracks)} ]")}");
        }
    }
}