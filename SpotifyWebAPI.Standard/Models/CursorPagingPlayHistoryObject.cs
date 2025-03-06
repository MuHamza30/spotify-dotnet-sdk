// <copyright file="CursorPagingPlayHistoryObject.cs" company="APIMatic">
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
    /// CursorPagingPlayHistoryObject.
    /// </summary>
    public class CursorPagingPlayHistoryObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CursorPagingPlayHistoryObject"/> class.
        /// </summary>
        public CursorPagingPlayHistoryObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorPagingPlayHistoryObject"/> class.
        /// </summary>
        /// <param name="href">href.</param>
        /// <param name="limit">limit.</param>
        /// <param name="next">next.</param>
        /// <param name="cursors">cursors.</param>
        /// <param name="total">total.</param>
        /// <param name="items">items.</param>
        public CursorPagingPlayHistoryObject(
            string href = null,
            int? limit = null,
            string next = null,
            Models.CursorObject cursors = null,
            int? total = null,
            List<Models.PlayHistoryObject> items = null)
        {
            this.Href = href;
            this.Limit = limit;
            this.Next = next;
            this.Cursors = cursors;
            this.Total = total;
            this.Items = items;
        }

        /// <summary>
        /// A link to the Web API endpoint returning the full result of the request.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// The maximum number of items in the response (as set in the query or by default).
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        /// <summary>
        /// URL to the next page of items. ( `null` if none)
        /// </summary>
        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public string Next { get; set; }

        /// <summary>
        /// The cursors used to find the next set of items.
        /// </summary>
        [JsonProperty("cursors", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CursorObject Cursors { get; set; }

        /// <summary>
        /// The total number of items available to return.
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PlayHistoryObject> Items { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CursorPagingPlayHistoryObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CursorPagingPlayHistoryObject other &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Limit == null && other.Limit == null ||
                 this.Limit?.Equals(other.Limit) == true) &&
                (this.Next == null && other.Next == null ||
                 this.Next?.Equals(other.Next) == true) &&
                (this.Cursors == null && other.Cursors == null ||
                 this.Cursors?.Equals(other.Cursors) == true) &&
                (this.Total == null && other.Total == null ||
                 this.Total?.Equals(other.Total) == true) &&
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
            toStringOutput.Add($"Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"Next = {this.Next ?? "null"}");
            toStringOutput.Add($"Cursors = {(this.Cursors == null ? "null" : this.Cursors.ToString())}");
            toStringOutput.Add($"Total = {(this.Total == null ? "null" : this.Total.ToString())}");
            toStringOutput.Add($"Items = {(this.Items == null ? "null" : $"[{string.Join(", ", this.Items)} ]")}");
        }
    }
}