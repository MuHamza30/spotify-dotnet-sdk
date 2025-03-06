// <copyright file="FollowersObject.cs" company="APIMatic">
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
    /// FollowersObject.
    /// </summary>
    public class FollowersObject
    {
        private string href;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "href", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FollowersObject"/> class.
        /// </summary>
        public FollowersObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FollowersObject"/> class.
        /// </summary>
        /// <param name="href">href.</param>
        /// <param name="total">total.</param>
        public FollowersObject(
            string href = null,
            int? total = null)
        {

            if (href != null)
            {
                this.Href = href;
            }
            this.Total = total;
        }

        /// <summary>
        /// This will always be set to null, as the Web API does not support it at the moment.
        /// </summary>
        [JsonProperty("href")]
        public string Href
        {
            get
            {
                return this.href;
            }

            set
            {
                this.shouldSerialize["href"] = true;
                this.href = value;
            }
        }

        /// <summary>
        /// The total number of followers.
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"FollowersObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serialized.
        /// </summary>
        public void UnsetHref()
        {
            this.shouldSerialize["href"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeHref()
        {
            return this.shouldSerialize["href"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is FollowersObject other &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Total == null && other.Total == null ||
                 this.Total?.Equals(other.Total) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Total = {(this.Total == null ? "null" : this.Total.ToString())}");
        }
    }
}