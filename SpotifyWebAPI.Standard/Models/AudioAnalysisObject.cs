// <copyright file="AudioAnalysisObject.cs" company="APIMatic">
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
    /// AudioAnalysisObject.
    /// </summary>
    public class AudioAnalysisObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioAnalysisObject"/> class.
        /// </summary>
        public AudioAnalysisObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioAnalysisObject"/> class.
        /// </summary>
        /// <param name="meta">meta.</param>
        /// <param name="track">track.</param>
        /// <param name="bars">bars.</param>
        /// <param name="beats">beats.</param>
        /// <param name="sections">sections.</param>
        /// <param name="segments">segments.</param>
        /// <param name="tatums">tatums.</param>
        public AudioAnalysisObject(
            Models.Meta meta = null,
            Models.Track track = null,
            List<Models.TimeIntervalObject> bars = null,
            List<Models.TimeIntervalObject> beats = null,
            List<Models.SectionObject> sections = null,
            List<Models.SegmentObject> segments = null,
            List<Models.TimeIntervalObject> tatums = null)
        {
            this.Meta = meta;
            this.Track = track;
            this.Bars = bars;
            this.Beats = beats;
            this.Sections = sections;
            this.Segments = segments;
            this.Tatums = tatums;
        }

        /// <summary>
        /// Gets or sets Meta.
        /// </summary>
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets Track.
        /// </summary>
        [JsonProperty("track", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Track Track { get; set; }

        /// <summary>
        /// The time intervals of the bars throughout the track. A bar (or measure) is a segment of time defined as a given number of beats.
        /// </summary>
        [JsonProperty("bars", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TimeIntervalObject> Bars { get; set; }

        /// <summary>
        /// The time intervals of beats throughout the track. A beat is the basic time unit of a piece of music; for example, each tick of a metronome. Beats are typically multiples of tatums.
        /// </summary>
        [JsonProperty("beats", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TimeIntervalObject> Beats { get; set; }

        /// <summary>
        /// Sections are defined by large variations in rhythm or timbre, e.g. chorus, verse, bridge, guitar solo, etc. Each section contains its own descriptions of tempo, key, mode, time_signature, and loudness.
        /// </summary>
        [JsonProperty("sections", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.SectionObject> Sections { get; set; }

        /// <summary>
        /// Each segment contains a roughly conisistent sound throughout its duration.
        /// </summary>
        [JsonProperty("segments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.SegmentObject> Segments { get; set; }

        /// <summary>
        /// A tatum represents the lowest regular pulse train that a listener intuitively infers from the timing of perceived musical events (segments).
        /// </summary>
        [JsonProperty("tatums", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.TimeIntervalObject> Tatums { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AudioAnalysisObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is AudioAnalysisObject other &&
                (this.Meta == null && other.Meta == null ||
                 this.Meta?.Equals(other.Meta) == true) &&
                (this.Track == null && other.Track == null ||
                 this.Track?.Equals(other.Track) == true) &&
                (this.Bars == null && other.Bars == null ||
                 this.Bars?.Equals(other.Bars) == true) &&
                (this.Beats == null && other.Beats == null ||
                 this.Beats?.Equals(other.Beats) == true) &&
                (this.Sections == null && other.Sections == null ||
                 this.Sections?.Equals(other.Sections) == true) &&
                (this.Segments == null && other.Segments == null ||
                 this.Segments?.Equals(other.Segments) == true) &&
                (this.Tatums == null && other.Tatums == null ||
                 this.Tatums?.Equals(other.Tatums) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Meta = {(this.Meta == null ? "null" : this.Meta.ToString())}");
            toStringOutput.Add($"Track = {(this.Track == null ? "null" : this.Track.ToString())}");
            toStringOutput.Add($"Bars = {(this.Bars == null ? "null" : $"[{string.Join(", ", this.Bars)} ]")}");
            toStringOutput.Add($"Beats = {(this.Beats == null ? "null" : $"[{string.Join(", ", this.Beats)} ]")}");
            toStringOutput.Add($"Sections = {(this.Sections == null ? "null" : $"[{string.Join(", ", this.Sections)} ]")}");
            toStringOutput.Add($"Segments = {(this.Segments == null ? "null" : $"[{string.Join(", ", this.Segments)} ]")}");
            toStringOutput.Add($"Tatums = {(this.Tatums == null ? "null" : $"[{string.Join(", ", this.Tatums)} ]")}");
        }
    }
}