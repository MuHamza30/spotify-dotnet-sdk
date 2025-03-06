// <copyright file="ManyArtists.cs" company="APIMatic">
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
    /// ManyArtists.
    /// </summary>
    public class ManyArtists
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyArtists"/> class.
        /// </summary>
        public ManyArtists()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyArtists"/> class.
        /// </summary>
        /// <param name="artists">artists.</param>
        public ManyArtists(
            List<Models.ArtistObject> artists)
        {
            this.Artists = artists;
        }

        /// <summary>
        /// Gets or sets Artists.
        /// </summary>
        [JsonProperty("artists")]
        public List<Models.ArtistObject> Artists { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyArtists : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyArtists other &&
                (this.Artists == null && other.Artists == null ||
                 this.Artists?.Equals(other.Artists) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Artists = {(this.Artists == null ? "null" : $"[{string.Join(", ", this.Artists)} ]")}");
        }
    }
}