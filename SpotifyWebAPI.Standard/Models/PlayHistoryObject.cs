// <copyright file="PlayHistoryObject.cs" company="APIMatic">
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
    /// PlayHistoryObject.
    /// </summary>
    public class PlayHistoryObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayHistoryObject"/> class.
        /// </summary>
        public PlayHistoryObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayHistoryObject"/> class.
        /// </summary>
        /// <param name="track">track.</param>
        /// <param name="playedAt">played_at.</param>
        /// <param name="context">context.</param>
        public PlayHistoryObject(
            Models.TrackObject track = null,
            DateTime? playedAt = null,
            Models.ContextObject context = null)
        {
            this.Track = track;
            this.PlayedAt = playedAt;
            this.Context = context;
        }

        /// <summary>
        /// The track the user listened to.
        /// </summary>
        [JsonProperty("track", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TrackObject Track { get; set; }

        /// <summary>
        /// The date and time the track was played.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("played_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PlayedAt { get; set; }

        /// <summary>
        /// The context the track was played from.
        /// </summary>
        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ContextObject Context { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PlayHistoryObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PlayHistoryObject other &&
                (this.Track == null && other.Track == null ||
                 this.Track?.Equals(other.Track) == true) &&
                (this.PlayedAt == null && other.PlayedAt == null ||
                 this.PlayedAt?.Equals(other.PlayedAt) == true) &&
                (this.Context == null && other.Context == null ||
                 this.Context?.Equals(other.Context) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Track = {(this.Track == null ? "null" : this.Track.ToString())}");
            toStringOutput.Add($"PlayedAt = {(this.PlayedAt == null ? "null" : this.PlayedAt.ToString())}");
            toStringOutput.Add($"Context = {(this.Context == null ? "null" : this.Context.ToString())}");
        }
    }
}