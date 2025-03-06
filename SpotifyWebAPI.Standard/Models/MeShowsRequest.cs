// <copyright file="MeShowsRequest.cs" company="APIMatic">
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
    /// MeShowsRequest.
    /// </summary>
    public class MeShowsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeShowsRequest"/> class.
        /// </summary>
        public MeShowsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeShowsRequest"/> class.
        /// </summary>
        /// <param name="ids">ids.</param>
        public MeShowsRequest(
            List<string> ids = null)
        {
            this.Ids = ids;
        }

        /// <summary>
        /// A JSON array of the [Spotify IDs](https://developer.spotify.com/documentation/web-api/#spotify-uris-and-ids).
        /// A maximum of 50 items can be specified in one request. *Note: if the `ids` parameter is present in the query string, any IDs listed here in the body will be ignored.*
        /// </summary>
        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Ids { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"MeShowsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is MeShowsRequest other &&
                (this.Ids == null && other.Ids == null ||
                 this.Ids?.Equals(other.Ids) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Ids = {(this.Ids == null ? "null" : $"[{string.Join(", ", this.Ids)} ]")}");
        }
    }
}