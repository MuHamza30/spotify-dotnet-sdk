// <copyright file="DisallowsObject.cs" company="APIMatic">
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
    /// DisallowsObject.
    /// </summary>
    public class DisallowsObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowsObject"/> class.
        /// </summary>
        public DisallowsObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowsObject"/> class.
        /// </summary>
        /// <param name="interruptingPlayback">interrupting_playback.</param>
        /// <param name="pausing">pausing.</param>
        /// <param name="resuming">resuming.</param>
        /// <param name="seeking">seeking.</param>
        /// <param name="skippingNext">skipping_next.</param>
        /// <param name="skippingPrev">skipping_prev.</param>
        /// <param name="togglingRepeatContext">toggling_repeat_context.</param>
        /// <param name="togglingShuffle">toggling_shuffle.</param>
        /// <param name="togglingRepeatTrack">toggling_repeat_track.</param>
        /// <param name="transferringPlayback">transferring_playback.</param>
        public DisallowsObject(
            bool? interruptingPlayback = null,
            bool? pausing = null,
            bool? resuming = null,
            bool? seeking = null,
            bool? skippingNext = null,
            bool? skippingPrev = null,
            bool? togglingRepeatContext = null,
            bool? togglingShuffle = null,
            bool? togglingRepeatTrack = null,
            bool? transferringPlayback = null)
        {
            this.InterruptingPlayback = interruptingPlayback;
            this.Pausing = pausing;
            this.Resuming = resuming;
            this.Seeking = seeking;
            this.SkippingNext = skippingNext;
            this.SkippingPrev = skippingPrev;
            this.TogglingRepeatContext = togglingRepeatContext;
            this.TogglingShuffle = togglingShuffle;
            this.TogglingRepeatTrack = togglingRepeatTrack;
            this.TransferringPlayback = transferringPlayback;
        }

        /// <summary>
        /// Interrupting playback. Optional field.
        /// </summary>
        [JsonProperty("interrupting_playback", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InterruptingPlayback { get; set; }

        /// <summary>
        /// Pausing. Optional field.
        /// </summary>
        [JsonProperty("pausing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Pausing { get; set; }

        /// <summary>
        /// Resuming. Optional field.
        /// </summary>
        [JsonProperty("resuming", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Resuming { get; set; }

        /// <summary>
        /// Seeking playback location. Optional field.
        /// </summary>
        [JsonProperty("seeking", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Seeking { get; set; }

        /// <summary>
        /// Skipping to the next context. Optional field.
        /// </summary>
        [JsonProperty("skipping_next", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkippingNext { get; set; }

        /// <summary>
        /// Skipping to the previous context. Optional field.
        /// </summary>
        [JsonProperty("skipping_prev", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkippingPrev { get; set; }

        /// <summary>
        /// Toggling repeat context flag. Optional field.
        /// </summary>
        [JsonProperty("toggling_repeat_context", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TogglingRepeatContext { get; set; }

        /// <summary>
        /// Toggling shuffle flag. Optional field.
        /// </summary>
        [JsonProperty("toggling_shuffle", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TogglingShuffle { get; set; }

        /// <summary>
        /// Toggling repeat track flag. Optional field.
        /// </summary>
        [JsonProperty("toggling_repeat_track", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TogglingRepeatTrack { get; set; }

        /// <summary>
        /// Transfering playback between devices. Optional field.
        /// </summary>
        [JsonProperty("transferring_playback", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TransferringPlayback { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DisallowsObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is DisallowsObject other &&
                (this.InterruptingPlayback == null && other.InterruptingPlayback == null ||
                 this.InterruptingPlayback?.Equals(other.InterruptingPlayback) == true) &&
                (this.Pausing == null && other.Pausing == null ||
                 this.Pausing?.Equals(other.Pausing) == true) &&
                (this.Resuming == null && other.Resuming == null ||
                 this.Resuming?.Equals(other.Resuming) == true) &&
                (this.Seeking == null && other.Seeking == null ||
                 this.Seeking?.Equals(other.Seeking) == true) &&
                (this.SkippingNext == null && other.SkippingNext == null ||
                 this.SkippingNext?.Equals(other.SkippingNext) == true) &&
                (this.SkippingPrev == null && other.SkippingPrev == null ||
                 this.SkippingPrev?.Equals(other.SkippingPrev) == true) &&
                (this.TogglingRepeatContext == null && other.TogglingRepeatContext == null ||
                 this.TogglingRepeatContext?.Equals(other.TogglingRepeatContext) == true) &&
                (this.TogglingShuffle == null && other.TogglingShuffle == null ||
                 this.TogglingShuffle?.Equals(other.TogglingShuffle) == true) &&
                (this.TogglingRepeatTrack == null && other.TogglingRepeatTrack == null ||
                 this.TogglingRepeatTrack?.Equals(other.TogglingRepeatTrack) == true) &&
                (this.TransferringPlayback == null && other.TransferringPlayback == null ||
                 this.TransferringPlayback?.Equals(other.TransferringPlayback) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"InterruptingPlayback = {(this.InterruptingPlayback == null ? "null" : this.InterruptingPlayback.ToString())}");
            toStringOutput.Add($"Pausing = {(this.Pausing == null ? "null" : this.Pausing.ToString())}");
            toStringOutput.Add($"Resuming = {(this.Resuming == null ? "null" : this.Resuming.ToString())}");
            toStringOutput.Add($"Seeking = {(this.Seeking == null ? "null" : this.Seeking.ToString())}");
            toStringOutput.Add($"SkippingNext = {(this.SkippingNext == null ? "null" : this.SkippingNext.ToString())}");
            toStringOutput.Add($"SkippingPrev = {(this.SkippingPrev == null ? "null" : this.SkippingPrev.ToString())}");
            toStringOutput.Add($"TogglingRepeatContext = {(this.TogglingRepeatContext == null ? "null" : this.TogglingRepeatContext.ToString())}");
            toStringOutput.Add($"TogglingShuffle = {(this.TogglingShuffle == null ? "null" : this.TogglingShuffle.ToString())}");
            toStringOutput.Add($"TogglingRepeatTrack = {(this.TogglingRepeatTrack == null ? "null" : this.TogglingRepeatTrack.ToString())}");
            toStringOutput.Add($"TransferringPlayback = {(this.TransferringPlayback == null ? "null" : this.TransferringPlayback.ToString())}");
        }
    }
}