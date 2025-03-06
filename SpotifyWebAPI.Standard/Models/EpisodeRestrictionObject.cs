// <copyright file="EpisodeRestrictionObject.cs" company="APIMatic">
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
    /// EpisodeRestrictionObject.
    /// </summary>
    public class EpisodeRestrictionObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodeRestrictionObject"/> class.
        /// </summary>
        public EpisodeRestrictionObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodeRestrictionObject"/> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        public EpisodeRestrictionObject(
            string reason = null)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// The reason for the restriction. Supported values:
        /// - `market` - The content item is not available in the given market.
        /// - `product` - The content item is not available for the user's subscription type.
        /// - `explicit` - The content item is explicit and the user's account is set to not play explicit content.
        /// Additional reasons may be added in the future.
        /// **Note**: If you use this field, make sure that your application safely handles unknown values.
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"EpisodeRestrictionObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is EpisodeRestrictionObject other &&
                (this.Reason == null && other.Reason == null ||
                 this.Reason?.Equals(other.Reason) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Reason = {this.Reason ?? "null"}");
        }
    }
}