// <copyright file="ExternalIdObject.cs" company="APIMatic">
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
    /// ExternalIdObject.
    /// </summary>
    public class ExternalIdObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalIdObject"/> class.
        /// </summary>
        public ExternalIdObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalIdObject"/> class.
        /// </summary>
        /// <param name="isrc">isrc.</param>
        /// <param name="ean">ean.</param>
        /// <param name="upc">upc.</param>
        public ExternalIdObject(
            string isrc = null,
            string ean = null,
            string upc = null)
        {
            this.Isrc = isrc;
            this.Ean = ean;
            this.Upc = upc;
        }

        /// <summary>
        /// [International Standard Recording Code](http://en.wikipedia.org/wiki/International_Standard_Recording_Code)
        /// </summary>
        [JsonProperty("isrc", NullValueHandling = NullValueHandling.Ignore)]
        public string Isrc { get; set; }

        /// <summary>
        /// [International Article Number](http://en.wikipedia.org/wiki/International_Article_Number_%28EAN%29)
        /// </summary>
        [JsonProperty("ean", NullValueHandling = NullValueHandling.Ignore)]
        public string Ean { get; set; }

        /// <summary>
        /// [Universal Product Code](http://en.wikipedia.org/wiki/Universal_Product_Code)
        /// </summary>
        [JsonProperty("upc", NullValueHandling = NullValueHandling.Ignore)]
        public string Upc { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ExternalIdObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ExternalIdObject other &&
                (this.Isrc == null && other.Isrc == null ||
                 this.Isrc?.Equals(other.Isrc) == true) &&
                (this.Ean == null && other.Ean == null ||
                 this.Ean?.Equals(other.Ean) == true) &&
                (this.Upc == null && other.Upc == null ||
                 this.Upc?.Equals(other.Upc) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Isrc = {this.Isrc ?? "null"}");
            toStringOutput.Add($"Ean = {this.Ean ?? "null"}");
            toStringOutput.Add($"Upc = {this.Upc ?? "null"}");
        }
    }
}