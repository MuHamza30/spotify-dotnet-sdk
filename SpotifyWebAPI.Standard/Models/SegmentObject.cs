// <copyright file="SegmentObject.cs" company="APIMatic">
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
    /// SegmentObject.
    /// </summary>
    public class SegmentObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentObject"/> class.
        /// </summary>
        public SegmentObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentObject"/> class.
        /// </summary>
        /// <param name="start">start.</param>
        /// <param name="duration">duration.</param>
        /// <param name="confidence">confidence.</param>
        /// <param name="loudnessStart">loudness_start.</param>
        /// <param name="loudnessMax">loudness_max.</param>
        /// <param name="loudnessMaxTime">loudness_max_time.</param>
        /// <param name="loudnessEnd">loudness_end.</param>
        /// <param name="pitches">pitches.</param>
        /// <param name="timbre">timbre.</param>
        public SegmentObject(
            double? start = null,
            double? duration = null,
            double? confidence = null,
            double? loudnessStart = null,
            double? loudnessMax = null,
            double? loudnessMaxTime = null,
            double? loudnessEnd = null,
            List<double> pitches = null,
            List<double> timbre = null)
        {
            this.Start = start;
            this.Duration = duration;
            this.Confidence = confidence;
            this.LoudnessStart = loudnessStart;
            this.LoudnessMax = loudnessMax;
            this.LoudnessMaxTime = loudnessMaxTime;
            this.LoudnessEnd = loudnessEnd;
            this.Pitches = pitches;
            this.Timbre = timbre;
        }

        /// <summary>
        /// The starting point (in seconds) of the segment.
        /// </summary>
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public double? Start { get; set; }

        /// <summary>
        /// The duration (in seconds) of the segment.
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the segmentation. Segments of the song which are difficult to logically segment (e.g: noise) may correspond to low values in this field.
        /// </summary>
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Confidence { get; set; }

        /// <summary>
        /// The onset loudness of the segment in decibels (dB). Combined with `loudness_max` and `loudness_max_time`, these components can be used to describe the "attack" of the segment.
        /// </summary>
        [JsonProperty("loudness_start", NullValueHandling = NullValueHandling.Ignore)]
        public double? LoudnessStart { get; set; }

        /// <summary>
        /// The peak loudness of the segment in decibels (dB). Combined with `loudness_start` and `loudness_max_time`, these components can be used to describe the "attack" of the segment.
        /// </summary>
        [JsonProperty("loudness_max", NullValueHandling = NullValueHandling.Ignore)]
        public double? LoudnessMax { get; set; }

        /// <summary>
        /// The segment-relative offset of the segment peak loudness in seconds. Combined with `loudness_start` and `loudness_max`, these components can be used to desctibe the "attack" of the segment.
        /// </summary>
        [JsonProperty("loudness_max_time", NullValueHandling = NullValueHandling.Ignore)]
        public double? LoudnessMaxTime { get; set; }

        /// <summary>
        /// The offset loudness of the segment in decibels (dB). This value should be equivalent to the loudness_start of the following segment.
        /// </summary>
        [JsonProperty("loudness_end", NullValueHandling = NullValueHandling.Ignore)]
        public double? LoudnessEnd { get; set; }

        /// <summary>
        /// Pitch content is given by a “chroma” vector, corresponding to the 12 pitch classes C, C#, D to B, with values ranging from 0 to 1 that describe the relative dominance of every pitch in the chromatic scale. For example a C Major chord would likely be represented by large values of C, E and G (i.e. classes 0, 4, and 7).
        /// Vectors are normalized to 1 by their strongest dimension, therefore noisy sounds are likely represented by values that are all close to 1, while pure tones are described by one value at 1 (the pitch) and others near 0.
        /// As can be seen below, the 12 vector indices are a combination of low-power spectrum values at their respective pitch frequencies.
        /// ![pitch vector](https://developer.spotify.com/assets/audio/Pitch_vector.png)
        /// </summary>
        [JsonProperty("pitches", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Pitches { get; set; }

        /// <summary>
        /// Timbre is the quality of a musical note or sound that distinguishes different types of musical instruments, or voices. It is a complex notion also referred to as sound color, texture, or tone quality, and is derived from the shape of a segment’s spectro-temporal surface, independently of pitch and loudness. The timbre feature is a vector that includes 12 unbounded values roughly centered around 0. Those values are high level abstractions of the spectral surface, ordered by degree of importance.
        /// For completeness however, the first dimension represents the average loudness of the segment; second emphasizes brightness; third is more closely correlated to the flatness of a sound; fourth to sounds with a stronger attack; etc. See an image below representing the 12 basis functions (i.e. template segments).
        /// ![timbre basis functions](https://developer.spotify.com/assets/audio/Timbre_basis_functions.png)
        /// The actual timbre of the segment is best described as a linear combination of these 12 basis functions weighted by the coefficient values: timbre = c1 x b1 + c2 x b2 + ... + c12 x b12, where c1 to c12 represent the 12 coefficients and b1 to b12 the 12 basis functions as displayed below. Timbre vectors are best used in comparison with each other.
        /// </summary>
        [JsonProperty("timbre", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Timbre { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SegmentObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SegmentObject other &&
                (this.Start == null && other.Start == null ||
                 this.Start?.Equals(other.Start) == true) &&
                (this.Duration == null && other.Duration == null ||
                 this.Duration?.Equals(other.Duration) == true) &&
                (this.Confidence == null && other.Confidence == null ||
                 this.Confidence?.Equals(other.Confidence) == true) &&
                (this.LoudnessStart == null && other.LoudnessStart == null ||
                 this.LoudnessStart?.Equals(other.LoudnessStart) == true) &&
                (this.LoudnessMax == null && other.LoudnessMax == null ||
                 this.LoudnessMax?.Equals(other.LoudnessMax) == true) &&
                (this.LoudnessMaxTime == null && other.LoudnessMaxTime == null ||
                 this.LoudnessMaxTime?.Equals(other.LoudnessMaxTime) == true) &&
                (this.LoudnessEnd == null && other.LoudnessEnd == null ||
                 this.LoudnessEnd?.Equals(other.LoudnessEnd) == true) &&
                (this.Pitches == null && other.Pitches == null ||
                 this.Pitches?.Equals(other.Pitches) == true) &&
                (this.Timbre == null && other.Timbre == null ||
                 this.Timbre?.Equals(other.Timbre) == true);
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
            toStringOutput.Add($"LoudnessStart = {(this.LoudnessStart == null ? "null" : this.LoudnessStart.ToString())}");
            toStringOutput.Add($"LoudnessMax = {(this.LoudnessMax == null ? "null" : this.LoudnessMax.ToString())}");
            toStringOutput.Add($"LoudnessMaxTime = {(this.LoudnessMaxTime == null ? "null" : this.LoudnessMaxTime.ToString())}");
            toStringOutput.Add($"LoudnessEnd = {(this.LoudnessEnd == null ? "null" : this.LoudnessEnd.ToString())}");
            toStringOutput.Add($"Pitches = {(this.Pitches == null ? "null" : $"[{string.Join(", ", this.Pitches)} ]")}");
            toStringOutput.Add($"Timbre = {(this.Timbre == null ? "null" : $"[{string.Join(", ", this.Timbre)} ]")}");
        }
    }
}