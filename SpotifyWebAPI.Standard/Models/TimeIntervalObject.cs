// <copyright file="TimeIntervalObject.cs" company="APIMatic">
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
    /// TimeIntervalObject.
    /// </summary>
    public class TimeIntervalObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeIntervalObject"/> class.
        /// </summary>
        public TimeIntervalObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeIntervalObject"/> class.
        /// </summary>
        /// <param name="start">start.</param>
        /// <param name="duration">duration.</param>
        /// <param name="confidence">confidence.</param>
        public TimeIntervalObject(
            double? start = null,
            double? duration = null,
            double? confidence = null)
        {
            this.Start = start;
            this.Duration = duration;
            this.Confidence = confidence;
        }

        /// <summary>
        /// The starting point (in seconds) of the time interval.
        /// </summary>
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public double? Start { get; set; }

        /// <summary>
        /// The duration (in seconds) of the time interval.
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the interval.
        /// </summary>
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Confidence { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"TimeIntervalObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is TimeIntervalObject other &&
                (this.Start == null && other.Start == null ||
                 this.Start?.Equals(other.Start) == true) &&
                (this.Duration == null && other.Duration == null ||
                 this.Duration?.Equals(other.Duration) == true) &&
                (this.Confidence == null && other.Confidence == null ||
                 this.Confidence?.Equals(other.Confidence) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Start = {(this.Start == null ? "null" : this.Start.ToString())}");
            toStringOutput.Add($"Duration = {(this.Duration == null ? "null" : this.Duration.ToString())}");
            toStringOutput.Add($"Confidence = {(this.Confidence == null ? "null" : this.Confidence.ToString())}");
        }
    }
}