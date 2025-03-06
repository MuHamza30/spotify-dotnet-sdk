// <copyright file="CurrentlyPlayingObject.cs" company="APIMatic">
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
    /// CurrentlyPlayingObject.
    /// </summary>
    public class CurrentlyPlayingObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentlyPlayingObject"/> class.
        /// </summary>
        public CurrentlyPlayingObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentlyPlayingObject"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="progressMs">progress_ms.</param>
        /// <param name="isPlaying">is_playing.</param>
        /// <param name="item">item.</param>
        /// <param name="currentlyPlayingType">currently_playing_type.</param>
        /// <param name="actions">actions.</param>
        public CurrentlyPlayingObject(
            Models.ContextObject context = null,
            long? timestamp = null,
            int? progressMs = null,
            bool? isPlaying = null,
            CurrentlyPlayingObjectItem item = null,
            string currentlyPlayingType = null,
            Models.DisallowsObject actions = null)
        {
            this.Context = context;
            this.Timestamp = timestamp;
            this.ProgressMs = progressMs;
            this.IsPlaying = isPlaying;
            this.Item = item;
            this.CurrentlyPlayingType = currentlyPlayingType;
            this.Actions = actions;
        }

        /// <summary>
        /// A Context Object. Can be `null`.
        /// </summary>
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ContextObject Context { get; set; }

        /// <summary>
        /// Unix Millisecond Timestamp when data was fetched
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
        public CurrentlyPlayingObjectItem Item { get; set; }

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
            return $"CurrentlyPlayingObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CurrentlyPlayingObject other &&
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