// <copyright file="Track1.cs" company="APIMatic">
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
    /// Track1.
    /// </summary>
    public class Track1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Track1"/> class.
        /// </summary>
        public Track1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Track1"/> class.
        /// </summary>
        /// <param name="uri">uri.</param>
        public Track1(
            string uri = null)
        {
            this.Uri = uri;
        }

        /// <summary>
        /// Spotify URI
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Track1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Track1 other &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
        }
    }
}