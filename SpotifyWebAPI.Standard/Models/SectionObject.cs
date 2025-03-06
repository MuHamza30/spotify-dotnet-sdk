// <copyright file="SectionObject.cs" company="APIMatic">
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
    /// SectionObject.
    /// </summary>
    public class SectionObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionObject"/> class.
        /// </summary>
        public SectionObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionObject"/> class.
        /// </summary>
        /// <param name="start">start.</param>
        /// <param name="duration">duration.</param>
        /// <param name="confidence">confidence.</param>
        /// <param name="loudness">loudness.</param>
        /// <param name="tempo">tempo.</param>
        /// <param name="tempoConfidence">tempo_confidence.</param>
        /// <param name="key">key.</param>
        /// <param name="keyConfidence">key_confidence.</param>
        /// <param name="mode">mode.</param>
        /// <param name="modeConfidence">mode_confidence.</param>
        /// <param name="timeSignature">time_signature.</param>
        /// <param name="timeSignatureConfidence">time_signature_confidence.</param>
        public SectionObject(
            double? start = null,
            double? duration = null,
            double? confidence = null,
            double? loudness = null,
            double? tempo = null,
            double? tempoConfidence = null,
            int? key = null,
            double? keyConfidence = null,
            Models.ModeEnum? mode = null,
            double? modeConfidence = null,
            int? timeSignature = null,
            double? timeSignatureConfidence = null)
        {
            this.Start = start;
            this.Duration = duration;
            this.Confidence = confidence;
            this.Loudness = loudness;
            this.Tempo = tempo;
            this.TempoConfidence = tempoConfidence;
            this.Key = key;
            this.KeyConfidence = keyConfidence;
            this.Mode = mode;
            this.ModeConfidence = modeConfidence;
            this.TimeSignature = timeSignature;
            this.TimeSignatureConfidence = timeSignatureConfidence;
        }

        /// <summary>
        /// The starting point (in seconds) of the section.
        /// </summary>
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public double? Start { get; set; }

        /// <summary>
        /// The duration (in seconds) of the section.
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the section's "designation".
        /// </summary>
        [JsonProperty("confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Confidence { get; set; }

        /// <summary>
        /// The overall loudness of the section in decibels (dB). Loudness values are useful for comparing relative loudness of sections within tracks.
        /// </summary>
        [JsonProperty("loudness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Loudness { get; set; }

        /// <summary>
        /// The overall estimated tempo of the section in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration.
        /// </summary>
        [JsonProperty("tempo", NullValueHandling = NullValueHandling.Ignore)]
        public double? Tempo { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the tempo. Some tracks contain tempo changes or sounds which don't contain tempo (like pure speech) which would correspond to a low value in this field.
        /// </summary>
        [JsonProperty("tempo_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? TempoConfidence { get; set; }

        /// <summary>
        /// The estimated overall key of the section. The values in this field ranging from 0 to 11 mapping to pitches using standard Pitch Class notation (E.g. 0 = C, 1 = C♯/D♭, 2 = D, and so on). If no key was detected, the value is -1.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public int? Key { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the key. Songs with many key changes may correspond to low values in this field.
        /// </summary>
        [JsonProperty("key_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? KeyConfidence { get; set; }

        /// <summary>
        /// Indicates the modality (major or minor) of a section, the type of scale from which its melodic content is derived. This field will contain a 0 for "minor", a 1 for "major", or a -1 for no result. Note that the major key (e.g. C major) could more likely be confused with the minor key at 3 semitones lower (e.g. A minor) as both keys carry the same pitches.
        /// </summary>
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ModeEnum? Mode { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the `mode`.
        /// </summary>
        [JsonProperty("mode_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? ModeConfidence { get; set; }

        /// <summary>
        /// An estimated time signature. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure). The time signature ranges from 3 to 7 indicating time signatures of "3/4", to "7/4".
        /// </summary>
        [JsonProperty("time_signature", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeSignature { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the `time_signature`. Sections with time signature changes may correspond to low values in this field.
        /// </summary>
        [JsonProperty("time_signature_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? TimeSignatureConfidence { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SectionObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SectionObject other &&
                (this.Start == null && other.Start == null ||
                 this.Start?.Equals(other.Start) == true) &&
                (this.Duration == null && other.Duration == null ||
                 this.Duration?.Equals(other.Duration) == true) &&
                (this.Confidence == null && other.Confidence == null ||
                 this.Confidence?.Equals(other.Confidence) == true) &&
                (this.Loudness == null && other.Loudness == null ||
                 this.Loudness?.Equals(other.Loudness) == true) &&
                (this.Tempo == null && other.Tempo == null ||
                 this.Tempo?.Equals(other.Tempo) == true) &&
                (this.TempoConfidence == null && other.TempoConfidence == null ||
                 this.TempoConfidence?.Equals(other.TempoConfidence) == true) &&
                (this.Key == null && other.Key == null ||
                 this.Key?.Equals(other.Key) == true) &&
                (this.KeyConfidence == null && other.KeyConfidence == null ||
                 this.KeyConfidence?.Equals(other.KeyConfidence) == true) &&
                (this.Mode == null && other.Mode == null ||
                 this.Mode?.Equals(other.Mode) == true) &&
                (this.ModeConfidence == null && other.ModeConfidence == null ||
                 this.ModeConfidence?.Equals(other.ModeConfidence) == true) &&
                (this.TimeSignature == null && other.TimeSignature == null ||
                 this.TimeSignature?.Equals(other.TimeSignature) == true) &&
                (this.TimeSignatureConfidence == null && other.TimeSignatureConfidence == null ||
                 this.TimeSignatureConfidence?.Equals(other.TimeSignatureConfidence) == true);
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
            toStringOutput.Add($"Loudness = {(this.Loudness == null ? "null" : this.Loudness.ToString())}");
            toStringOutput.Add($"Tempo = {(this.Tempo == null ? "null" : this.Tempo.ToString())}");
            toStringOutput.Add($"TempoConfidence = {(this.TempoConfidence == null ? "null" : this.TempoConfidence.ToString())}");
            toStringOutput.Add($"Key = {(this.Key == null ? "null" : this.Key.ToString())}");
            toStringOutput.Add($"KeyConfidence = {(this.KeyConfidence == null ? "null" : this.KeyConfidence.ToString())}");
            toStringOutput.Add($"Mode = {(this.Mode == null ? "null" : this.Mode.ToString())}");
            toStringOutput.Add($"ModeConfidence = {(this.ModeConfidence == null ? "null" : this.ModeConfidence.ToString())}");
            toStringOutput.Add($"TimeSignature = {(this.TimeSignature == null ? "null" : this.TimeSignature.ToString())}");
            toStringOutput.Add($"TimeSignatureConfidence = {(this.TimeSignatureConfidence == null ? "null" : this.TimeSignatureConfidence.ToString())}");
        }
    }
}