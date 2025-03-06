// <copyright file="SavedShowObject.cs" company="APIMatic">
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
    /// SavedShowObject.
    /// </summary>
    public class SavedShowObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavedShowObject"/> class.
        /// </summary>
        public SavedShowObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedShowObject"/> class.
        /// </summary>
        /// <param name="addedAt">added_at.</param>
        /// <param name="show">show.</param>
        public SavedShowObject(
            DateTime? addedAt = null,
            Models.ShowBase show = null)
        {
            this.AddedAt = addedAt;
            this.Show = show;
        }

        /// <summary>
        /// The date and time the show was saved.
        /// Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
        /// If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision; see for example, release_date in an album object.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("added_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddedAt { get; set; }

        /// <summary>
        /// Information about the show.
        /// </summary>
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShowBase Show { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SavedShowObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SavedShowObject other &&
                (this.AddedAt == null && other.AddedAt == null ||
                 this.AddedAt?.Equals(other.AddedAt) == true) &&
                (this.Show == null && other.Show == null ||
                 this.Show?.Equals(other.Show) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AddedAt = {(this.AddedAt == null ? "null" : this.AddedAt.ToString())}");
            toStringOutput.Add($"Show = {(this.Show == null ? "null" : this.Show.ToString())}");
        }
    }
}