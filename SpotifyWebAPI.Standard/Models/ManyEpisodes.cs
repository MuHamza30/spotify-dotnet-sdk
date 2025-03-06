// <copyright file="ManyEpisodes.cs" company="APIMatic">
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
    /// ManyEpisodes.
    /// </summary>
    public class ManyEpisodes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyEpisodes"/> class.
        /// </summary>
        public ManyEpisodes()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyEpisodes"/> class.
        /// </summary>
        /// <param name="episodes">episodes.</param>
        public ManyEpisodes(
            List<Models.EpisodeObject> episodes)
        {
            this.Episodes = episodes;
        }

        /// <summary>
        /// Gets or sets Episodes.
        /// </summary>
        [JsonProperty("episodes")]
        public List<Models.EpisodeObject> Episodes { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyEpisodes : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyEpisodes other &&
                (this.Episodes == null && other.Episodes == null ||
                 this.Episodes?.Equals(other.Episodes) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Episodes = {(this.Episodes == null ? "null" : $"[{string.Join(", ", this.Episodes)} ]")}");
        }
    }
}