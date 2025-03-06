// <copyright file="Markets.cs" company="APIMatic">
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
    /// Markets.
    /// </summary>
    public class Markets
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Markets"/> class.
        /// </summary>
        public Markets()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Markets"/> class.
        /// </summary>
        /// <param name="marketsProp">markets.</param>
        public Markets(
            List<string> marketsProp = null)
        {
            this.MarketsProp = marketsProp;
        }

        /// <summary>
        /// Gets or sets MarketsProp.
        /// </summary>
        [JsonProperty("markets", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MarketsProp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Markets : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Markets other &&
                (this.MarketsProp == null && other.MarketsProp == null ||
                 this.MarketsProp?.Equals(other.MarketsProp) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"MarketsProp = {(this.MarketsProp == null ? "null" : $"[{string.Join(", ", this.MarketsProp)} ]")}");
        }
    }
}