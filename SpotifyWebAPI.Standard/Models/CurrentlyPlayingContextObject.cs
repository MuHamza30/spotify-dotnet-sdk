// <copyright file="CurrentlyPlayingContextObject.cs" company="APIMatic">
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
using SpotifyWebAPI.Standard.Models.Containers;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// CurrentlyPlayingContextObject.
    /// </summary>
    public class CurrentlyPlayingContextObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentlyPlayingContextObject"/> class.
        /// </summary>
        public CurrentlyPlayingContextObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentlyPlayingContextObject"/> class.
        /// </summary>
        /// <param name="device">device.</param>
        /// <param name="repeatState">repeat_state.</param>
        /// <param name="shuffleState">shuffle_state.</param>
        /// <param name="context">context.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="progressMs">progress_ms.</param>
        /// <param name="isPlaying">is_playing.</param>
        /// <param name="item">item.</param>
        /// <param name="currentlyPlayingType">currently_playing_type.</param>
        /// <param name="actions">actions.</param>
        public CurrentlyPlayingContextObject(
            Models.DeviceObject device = null,
            string repeatState = null,
            bool? shuffleState = null,
            Models.ContextObject context = null,
            long? timestamp = null,
            int? progressMs = null,
            bool? isPlaying = null,
            CurrentlyPlayingContextObjectItem item = null,
            string currentlyPlayingType = null,
            Models.DisallowsObject actions = null)
        {
            this.Device = device;
            this.RepeatState = repeatState;
            this.ShuffleState = shuffleState;
            this.Context = context;
            this.Timestamp = timestamp;
            this.ProgressMs = progressMs;
            this.IsPlaying = isPlaying;
            this.Item = item;
            this.CurrentlyPlayingType = currentlyPlayingType;
            this.Actions = actions;
        }

        /// <summary>
        /// The device that is currently active.
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceObject Device { get; set; }

        /// <summary>
        /// off, track, context
        /// </summary>
        [JsonProperty("repeat_state", NullValueHandling = NullValueHandling.Ignore)]
        public string RepeatState { get; set; }

        /// <summary>
        /// If shuffle is on or off.
        /// </summary>
        [JsonProperty("shuffle_state", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShuffleState { get; set; }

        /// <summary>
        /// A Context Object. Can be `null`.
        /// </summary>
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ContextObject Context { get; set; }

        /// <summary>
        /// Unix Millisecond Timestamp when data was fetched.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        /// <summary>
        /// Progress into the currently playing track or episode. Can be `null`.
        /// </summary>
        [JsonProperty("progress_ms", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProgressMs { get; set; }

        /// <summary>
        /// If something is currently playing, return `true`.
        /// </summary>
        [JsonProperty("is_playing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPlaying { get; set; }

        /// <summary>
        /// The currently playing track or episode. Can be `null`.
        /// </summary>
        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentlyPlayingContextObjectItem Item { get; set; }

        /// <summary>
        /// The object type of the currently playing item. Can be one of `track`, `episode`, `ad` or `unknown`.
        /// </summary>
        [JsonProperty("currently_playing_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentlyPlayingType { get; set; }

        /// <summary>
        /// Allows to update the user interface based on which playback actions are available within the current context.
        /// </summary>
        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisallowsObject Actions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CurrentlyPlayingContextObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CurrentlyPlayingContextObject other &&
                (this.Device == null && other.Device == null ||
                 this.Device?.Equals(other.Device) == true) &&
                (this.RepeatState == null && other.RepeatState == null ||
                 this.RepeatState?.Equals(other.RepeatState) == true) &&
                (this.ShuffleState == null && other.ShuffleState == null ||
                 this.ShuffleState?.Equals(other.ShuffleState) == true) &&
                (this.Context == null && other.Context == null ||
                 this.Context?.Equals(other.Context) == true) &&
                (this.Timestamp == null && other.Timestamp == null ||
                 this.Timestamp?.Equals(other.Timestamp) == true) &&
                (this.ProgressMs == null && other.ProgressMs == null ||
                 this.ProgressMs?.Equals(other.ProgressMs) == true) &&
                (this.IsPlaying == null && other.IsPlaying == null ||
                 this.IsPlaying?.Equals(other.IsPlaying) == true) &&
                (this.Item == null && other.Item == null ||
                 this.Item?.Equals(other.Item) == true) &&
                (this.CurrentlyPlayingType == null && other.CurrentlyPlayingType == null ||
                 this.CurrentlyPlayingType?.Equals(other.CurrentlyPlayingType) == true) &&
                (this.Actions == null && other.Actions == null ||
                 this.Actions?.Equals(other.Actions) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Device = {(this.Device == null ? "null" : this.Device.ToString())}");
            toStringOutput.Add($"RepeatState = {this.RepeatState ?? "null"}");
            toStringOutput.Add($"ShuffleState = {(this.ShuffleState == null ? "null" : this.ShuffleState.ToString())}");
            toStringOutput.Add($"Context = {(this.Context == null ? "null" : this.Context.ToString())}");
            toStringOutput.Add($"Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp.ToString())}");
            toStringOutput.Add($"ProgressMs = {(this.ProgressMs == null ? "null" : this.ProgressMs.ToString())}");
            toStringOutput.Add($"IsPlaying = {(this.IsPlaying == null ? "null" : this.IsPlaying.ToString())}");
            toStringOutput.Add($"Item = {(this.Item == null ? "null" : this.Item.ToString())}");
            toStringOutput.Add($"CurrentlyPlayingType = {this.CurrentlyPlayingType ?? "null"}");
            toStringOutput.Add($"Actions = {(this.Actions == null ? "null" : this.Actions.ToString())}");
        }
    }
}