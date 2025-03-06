// <copyright file="ManySimplifiedShows.cs" company="APIMatic">
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
    /// ManySimplifiedShows.
    /// </summary>
    public class ManySimplifiedShows
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManySimplifiedShows"/> class.
        /// </summary>
        public ManySimplifiedShows()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManySimplifiedShows"/> class.
        /// </summary>
        /// <param name="shows">shows.</param>
        public ManySimplifiedShows(
            List<Models.ShowBase> shows)
        {
            this.Shows = shows;
        }

        /// <summary>
        /// Gets or sets Shows.
        /// </summary>
        [JsonProperty("shows")]
        public List<Models.ShowBase> Shows { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManySimplifiedShows : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManySimplifiedShows other &&
                (this.Shows == null && other.Shows == null ||
                 this.Shows?.Equals(other.Shows) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Shows = {(this.Shows == null ? "null" : $"[{string.Join(", ", this.Shows)} ]")}");
        }
    }
}