// <copyright file="AlbumRestrictionObject.cs" company="APIMatic">
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
    /// AlbumRestrictionObject.
    /// </summary>
    public class AlbumRestrictionObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumRestrictionObject"/> class.
        /// </summary>
        public AlbumRestrictionObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumRestrictionObject"/> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        public AlbumRestrictionObject(
            Models.ReasonEnum? reason = null)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// The reason for the restriction. Albums may be restricted if the content is not available in a given market, to the user's subscription type, or when the user's account is set to not play explicit content.
        /// Additional reasons may be added in the future.
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ReasonEnum? Reason { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AlbumRestrictionObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is AlbumRestrictionObject other &&
                (this.Reason == null && other.Reason == null ||
                 this.Reason?.Equals(other.Reason) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Reason = {(this.Reason == null ? "null" : this.Reason.ToString())}");
        }
    }
}