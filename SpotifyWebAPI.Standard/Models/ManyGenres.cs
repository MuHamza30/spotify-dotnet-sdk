// <copyright file="ManyGenres.cs" company="APIMatic">
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
    /// ManyGenres.
    /// </summary>
    public class ManyGenres
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyGenres"/> class.
        /// </summary>
        public ManyGenres()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyGenres"/> class.
        /// </summary>
        /// <param name="genres">genres.</param>
        public ManyGenres(
            List<string> genres)
        {
            this.Genres = genres;
        }

        /// <summary>
        /// Gets or sets Genres.
        /// </summary>
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyGenres : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyGenres other &&
                (this.Genres == null && other.Genres == null ||
                 this.Genres?.Equals(other.Genres) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Genres = {(this.Genres == null ? "null" : $"[{string.Join(", ", this.Genres)} ]")}");
        }
    }
}