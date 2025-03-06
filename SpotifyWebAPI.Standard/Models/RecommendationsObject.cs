// <copyright file="RecommendationsObject.cs" company="APIMatic">
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
    /// RecommendationsObject.
    /// </summary>
    public class RecommendationsObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendationsObject"/> class.
        /// </summary>
        public RecommendationsObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendationsObject"/> class.
        /// </summary>
        /// <param name="seeds">seeds.</param>
        /// <param name="tracks">tracks.</param>
        public RecommendationsObject(
            List<Models.RecommendationSeedObject> seeds,
            List<Models.TrackObject> tracks)
        {
            this.Seeds = seeds;
            this.Tracks = tracks;
        }

        /// <summary>
        /// An array of recommendation seed objects.
        /// </summary>
        [JsonProperty("seeds")]
        public List<Models.RecommendationSeedObject> Seeds { get; set; }

        /// <summary>
        /// An array of track objects ordered according to the parameters supplied.
        /// </summary>
        [JsonProperty("tracks")]
        public List<Models.TrackObject> Tracks { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RecommendationsObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RecommendationsObject other &&
                (this.Seeds == null && other.Seeds == null ||
                 this.Seeds?.Equals(other.Seeds) == true) &&
                (this.Tracks == null && other.Tracks == null ||
                 this.Tracks?.Equals(other.Tracks) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Seeds = {(this.Seeds == null ? "null" : $"[{string.Join(", ", this.Seeds)} ]")}");
            toStringOutput.Add($"Tracks = {(this.Tracks == null ? "null" : $"[{string.Join(", ", this.Tracks)} ]")}");
        }
    }
}