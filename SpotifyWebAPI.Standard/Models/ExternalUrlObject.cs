// <copyright file="ExternalUrlObject.cs" company="APIMatic">
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
    /// ExternalUrlObject.
    /// </summary>
    public class ExternalUrlObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalUrlObject"/> class.
        /// </summary>
        public ExternalUrlObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalUrlObject"/> class.
        /// </summary>
        /// <param name="spotify">spotify.</param>
        public ExternalUrlObject(
            string spotify = null)
        {
            this.Spotify = spotify;
        }

        /// <summary>
        /// The [Spotify URL](/documentation/web-api/concepts/spotify-uris-ids) for the object.
        /// </summary>
        [JsonProperty("spotify", NullValueHandling = NullValueHandling.Ignore)]
        public string Spotify { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ExternalUrlObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ExternalUrlObject other &&
                (this.Spotify == null && other.Spotify == null ||
                 this.Spotify?.Equals(other.Spotify) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Spotify = {this.Spotify ?? "null"}");
        }
    }
}