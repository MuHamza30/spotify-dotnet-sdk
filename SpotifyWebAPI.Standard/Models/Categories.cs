// <copyright file="Categories.cs" company="APIMatic">
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
    /// Categories.
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Categories"/> class.
        /// </summary>
        public Categories()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Categories"/> class.
        /// </summary>
        /// <param name="href">href.</param>
        /// <param name="limit">limit.</param>
        /// <param name="offset">offset.</param>
        /// <param name="total">total.</param>
        /// <param name="items">items.</param>
        /// <param name="next">next.</param>
        /// <param name="previous">previous.</param>
        public Categories(
            string href,
            int limit,
            int offset,
            int total,
            List<Models.CategoryObject> items,
            string next = null,
            string previous = null)
        {
            this.Href = href;
            this.Limit = limit;
            this.Next = next;
            this.Offset = offset;
            this.Previous = previous;
            this.Total = total;
            this.Items = items;
        }

        /// <summary>
        /// A link to the Web API endpoint returning the full result of the request
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The maximum number of items in the response (as set in the query or by default).
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// URL to the next page of items. ( `null` if none)
        /// </summary>
        [JsonProperty("next", NullValueHandling = NullValueHandling.Include)]
        public string Next { get; set; }

        /// <summary>
        /// The offset of the items returned (as set in the query or by default)
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// URL to the previous page of items. ( `null` if none)
        /// </summary>
        [JsonProperty("previous", NullValueHandling = NullValueHandling.Include)]
        public string Previous { get; set; }

        /// <summary>
        /// The total number of items available to return.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        [JsonProperty("items")]
        public List<Models.CategoryObject> Items { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Categories : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Categories other &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Limit.Equals(other.Limit)) &&
                (this.Next == null && other.Next == null ||
                 this.Next?.Equals(other.Next) == true) &&
                (this.Offset.Equals(other.Offset)) &&
                (this.Previous == null && other.Previous == null ||
                 this.Previous?.Equals(other.Previous) == true) &&
                (this.Total.Equals(other.Total)) &&
                (this.Items == null && other.Items == null ||
                 this.Items?.Equals(other.Items) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Limit = {this.Limit}");
            toStringOutput.Add($"Next = {this.Next ?? "null"}");
            toStringOutput.Add($"Offset = {this.Offset}");
            toStringOutput.Add($"Previous = {this.Previous ?? "null"}");
            toStringOutput.Add($"Total = {this.Total}");
            toStringOutput.Add($"Items = {(this.Items == null ? "null" : $"[{string.Join(", ", this.Items)} ]")}");
        }
    }
}