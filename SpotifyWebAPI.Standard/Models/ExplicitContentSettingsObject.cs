// <copyright file="ExplicitContentSettingsObject.cs" company="APIMatic">
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
    /// ExplicitContentSettingsObject.
    /// </summary>
    public class ExplicitContentSettingsObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExplicitContentSettingsObject"/> class.
        /// </summary>
        public ExplicitContentSettingsObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplicitContentSettingsObject"/> class.
        /// </summary>
        /// <param name="filterEnabled">filter_enabled.</param>
        /// <param name="filterLocked">filter_locked.</param>
        public ExplicitContentSettingsObject(
            bool? filterEnabled = null,
            bool? filterLocked = null)
        {
            this.FilterEnabled = filterEnabled;
            this.FilterLocked = filterLocked;
        }

        /// <summary>
        /// When `true`, indicates that explicit content should not be played.
        /// </summary>
        [JsonProperty("filter_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FilterEnabled { get; set; }

        /// <summary>
        /// When `true`, indicates that the explicit content setting is locked and can't be changed by the user.
        /// </summary>
        [JsonProperty("filter_locked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FilterLocked { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ExplicitContentSettingsObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ExplicitContentSettingsObject other &&
                (this.FilterEnabled == null && other.FilterEnabled == null ||
                 this.FilterEnabled?.Equals(other.FilterEnabled) == true) &&
                (this.FilterLocked == null && other.FilterLocked == null ||
                 this.FilterLocked?.Equals(other.FilterLocked) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"FilterEnabled = {(this.FilterEnabled == null ? "null" : this.FilterEnabled.ToString())}");
            toStringOutput.Add($"FilterLocked = {(this.FilterLocked == null ? "null" : this.FilterLocked.ToString())}");
        }
    }
}