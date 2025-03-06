// <copyright file="Track.cs" company="APIMatic">
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
    /// Track.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Track"/> class.
        /// </summary>
        public Track()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Track"/> class.
        /// </summary>
        /// <param name="numSamples">num_samples.</param>
        /// <param name="duration">duration.</param>
        /// <param name="sampleMd5">sample_md5.</param>
        /// <param name="offsetSeconds">offset_seconds.</param>
        /// <param name="windowSeconds">window_seconds.</param>
        /// <param name="analysisSampleRate">analysis_sample_rate.</param>
        /// <param name="analysisChannels">analysis_channels.</param>
        /// <param name="endOfFadeIn">end_of_fade_in.</param>
        /// <param name="startOfFadeOut">start_of_fade_out.</param>
        /// <param name="loudness">loudness.</param>
        /// <param name="tempo">tempo.</param>
        /// <param name="tempoConfidence">tempo_confidence.</param>
        /// <param name="timeSignature">time_signature.</param>
        /// <param name="timeSignatureConfidence">time_signature_confidence.</param>
        /// <param name="key">key.</param>
        /// <param name="keyConfidence">key_confidence.</param>
        /// <param name="mode">mode.</param>
        /// <param name="modeConfidence">mode_confidence.</param>
        /// <param name="codestring">codestring.</param>
        /// <param name="codeVersion">code_version.</param>
        /// <param name="echoprintstring">echoprintstring.</param>
        /// <param name="echoprintVersion">echoprint_version.</param>
        /// <param name="synchstring">synchstring.</param>
        /// <param name="synchVersion">synch_version.</param>
        /// <param name="rhythmstring">rhythmstring.</param>
        /// <param name="rhythmVersion">rhythm_version.</param>
        public Track(
            int? numSamples = null,
            double? duration = null,
            string sampleMd5 = null,
            int? offsetSeconds = null,
            int? windowSeconds = null,
            int? analysisSampleRate = null,
            int? analysisChannels = null,
            double? endOfFadeIn = null,
            double? startOfFadeOut = null,
            double? loudness = null,
            double? tempo = null,
            double? tempoConfidence = null,
            int? timeSignature = null,
            double? timeSignatureConfidence = null,
            int? key = null,
            double? keyConfidence = null,
            int? mode = null,
            double? modeConfidence = null,
            string codestring = null,
            double? codeVersion = null,
            string echoprintstring = null,
            double? echoprintVersion = null,
            string synchstring = null,
            double? synchVersion = null,
            string rhythmstring = null,
            double? rhythmVersion = null)
        {
            this.NumSamples = numSamples;
            this.Duration = duration;
            this.SampleMd5 = sampleMd5;
            this.OffsetSeconds = offsetSeconds;
            this.WindowSeconds = windowSeconds;
            this.AnalysisSampleRate = analysisSampleRate;
            this.AnalysisChannels = analysisChannels;
            this.EndOfFadeIn = endOfFadeIn;
            this.StartOfFadeOut = startOfFadeOut;
            this.Loudness = loudness;
            this.Tempo = tempo;
            this.TempoConfidence = tempoConfidence;
            this.TimeSignature = timeSignature;
            this.TimeSignatureConfidence = timeSignatureConfidence;
            this.Key = key;
            this.KeyConfidence = keyConfidence;
            this.Mode = mode;
            this.ModeConfidence = modeConfidence;
            this.Codestring = codestring;
            this.CodeVersion = codeVersion;
            this.Echoprintstring = echoprintstring;
            this.EchoprintVersion = echoprintVersion;
            this.Synchstring = synchstring;
            this.SynchVersion = synchVersion;
            this.Rhythmstring = rhythmstring;
            this.RhythmVersion = rhythmVersion;
        }

        /// <summary>
        /// The exact number of audio samples analyzed from this track. See also `analysis_sample_rate`.
        /// </summary>
        [JsonProperty("num_samples", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumSamples { get; set; }

        /// <summary>
        /// Length of the track in seconds.
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration { get; set; }

        /// <summary>
        /// This field will always contain the empty string.
        /// </summary>
        [JsonProperty("sample_md5", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleMd5 { get; set; }

        /// <summary>
        /// An offset to the start of the region of the track that was analyzed. (As the entire track is analyzed, this should always be 0.)
        /// </summary>
        [JsonProperty("offset_seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? OffsetSeconds { get; set; }

        /// <summary>
        /// The length of the region of the track was analyzed, if a subset of the track was analyzed. (As the entire track is analyzed, this should always be 0.)
        /// </summary>
        [JsonProperty("window_seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? WindowSeconds { get; set; }

        /// <summary>
        /// The sample rate used to decode and analyze this track. May differ from the actual sample rate of this track available on Spotify.
        /// </summary>
        [JsonProperty("analysis_sample_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int? AnalysisSampleRate { get; set; }

        /// <summary>
        /// The number of channels used for analysis. If 1, all channels are summed together to mono before analysis.
        /// </summary>
        [JsonProperty("analysis_channels", NullValueHandling = NullValueHandling.Ignore)]
        public int? AnalysisChannels { get; set; }

        /// <summary>
        /// The time, in seconds, at which the track's fade-in period ends. If the track has no fade-in, this will be 0.0.
        /// </summary>
        [JsonProperty("end_of_fade_in", NullValueHandling = NullValueHandling.Ignore)]
        public double? EndOfFadeIn { get; set; }

        /// <summary>
        /// The time, in seconds, at which the track's fade-out period starts. If the track has no fade-out, this should match the track's length.
        /// </summary>
        [JsonProperty("start_of_fade_out", NullValueHandling = NullValueHandling.Ignore)]
        public double? StartOfFadeOut { get; set; }

        /// <summary>
        /// The overall loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typically range between -60 and 0 db.
        /// </summary>
        [JsonProperty("loudness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Loudness { get; set; }

        /// <summary>
        /// The overall estimated tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration.
        /// </summary>
        [JsonProperty("tempo", NullValueHandling = NullValueHandling.Ignore)]
        public double? Tempo { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the `tempo`.
        /// </summary>
        [JsonProperty("tempo_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? TempoConfidence { get; set; }

        /// <summary>
        /// An estimated time signature. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure). The time signature ranges from 3 to 7 indicating time signatures of "3/4", to "7/4".
        /// </summary>
        [JsonProperty("time_signature", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeSignature { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the `time_signature`.
        /// </summary>
        [JsonProperty("time_signature_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? TimeSignatureConfidence { get; set; }

        /// <summary>
        /// The key the track is in. Integers map to pitches using standard [Pitch Class notation](https://en.wikipedia.org/wiki/Pitch_class). E.g. 0 = C, 1 = C♯/D♭, 2 = D, and so on. If no key was detected, the value is -1.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public int? Key { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the `key`.
        /// </summary>
        [JsonProperty("key_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? KeyConfidence { get; set; }

        /// <summary>
        /// Mode indicates the modality (major or minor) of a track, the type of scale from which its melodic content is derived. Major is represented by 1 and minor is 0.
        /// </summary>
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public int? Mode { get; set; }

        /// <summary>
        /// The confidence, from 0.0 to 1.0, of the reliability of the `mode`.
        /// </summary>
        [JsonProperty("mode_confidence", NullValueHandling = NullValueHandling.Ignore)]
        public double? ModeConfidence { get; set; }

        /// <summary>
        /// An [Echo Nest Musical Fingerprint (ENMFP)](https://academiccommons.columbia.edu/doi/10.7916/D8Q248M4) codestring for this track.
        /// </summary>
        [JsonProperty("codestring", NullValueHandling = NullValueHandling.Ignore)]
        public string Codestring { get; set; }

        /// <summary>
        /// A version number for the Echo Nest Musical Fingerprint format used in the codestring field.
        /// </summary>
        [JsonProperty("code_version", NullValueHandling = NullValueHandling.Ignore)]
        public double? CodeVersion { get; set; }

        /// <summary>
        /// An [EchoPrint](https://github.com/spotify/echoprint-codegen) codestring for this track.
        /// </summary>
        [JsonProperty("echoprintstring", NullValueHandling = NullValueHandling.Ignore)]
        public string Echoprintstring { get; set; }

        /// <summary>
        /// A version number for the EchoPrint format used in the echoprintstring field.
        /// </summary>
        [JsonProperty("echoprint_version", NullValueHandling = NullValueHandling.Ignore)]
        public double? EchoprintVersion { get; set; }

        /// <summary>
        /// A [Synchstring](https://github.com/echonest/synchdata) for this track.
        /// </summary>
        [JsonProperty("synchstring", NullValueHandling = NullValueHandling.Ignore)]
        public string Synchstring { get; set; }

        /// <summary>
        /// A version number for the Synchstring used in the synchstring field.
        /// </summary>
        [JsonProperty("synch_version", NullValueHandling = NullValueHandling.Ignore)]
        public double? SynchVersion { get; set; }

        /// <summary>
        /// A Rhythmstring for this track. The format of this string is similar to the Synchstring.
        /// </summary>
        [JsonProperty("rhythmstring", NullValueHandling = NullValueHandling.Ignore)]
        public string Rhythmstring { get; set; }

        /// <summary>
        /// A version number for the Rhythmstring used in the rhythmstring field.
        /// </summary>
        [JsonProperty("rhythm_version", NullValueHandling = NullValueHandling.Ignore)]
        public double? RhythmVersion { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Track : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Track other &&
                (this.NumSamples == null && other.NumSamples == null ||
                 this.NumSamples?.Equals(other.NumSamples) == true) &&
                (this.Duration == null && other.Duration == null ||
                 this.Duration?.Equals(other.Duration) == true) &&
                (this.SampleMd5 == null && other.SampleMd5 == null ||
                 this.SampleMd5?.Equals(other.SampleMd5) == true) &&
                (this.OffsetSeconds == null && other.OffsetSeconds == null ||
                 this.OffsetSeconds?.Equals(other.OffsetSeconds) == true) &&
                (this.WindowSeconds == null && other.WindowSeconds == null ||
                 this.WindowSeconds?.Equals(other.WindowSeconds) == true) &&
                (this.AnalysisSampleRate == null && other.AnalysisSampleRate == null ||
                 this.AnalysisSampleRate?.Equals(other.AnalysisSampleRate) == true) &&
                (this.AnalysisChannels == null && other.AnalysisChannels == null ||
                 this.AnalysisChannels?.Equals(other.AnalysisChannels) == true) &&
                (this.EndOfFadeIn == null && other.EndOfFadeIn == null ||
                 this.EndOfFadeIn?.Equals(other.EndOfFadeIn) == true) &&
                (this.StartOfFadeOut == null && other.StartOfFadeOut == null ||
                 this.StartOfFadeOut?.Equals(other.StartOfFadeOut) == true) &&
                (this.Loudness == null && other.Loudness == null ||
                 this.Loudness?.Equals(other.Loudness) == true) &&
                (this.Tempo == null && other.Tempo == null ||
                 this.Tempo?.Equals(other.Tempo) == true) &&
                (this.TempoConfidence == null && other.TempoConfidence == null ||
                 this.TempoConfidence?.Equals(other.TempoConfidence) == true) &&
                (this.TimeSignature == null && other.TimeSignature == null ||
                 this.TimeSignature?.Equals(other.TimeSignature) == true) &&
                (this.TimeSignatureConfidence == null && other.TimeSignatureConfidence == null ||
                 this.TimeSignatureConfidence?.Equals(other.TimeSignatureConfidence) == true) &&
                (this.Key == null && other.Key == null ||
                 this.Key?.Equals(other.Key) == true) &&
                (this.KeyConfidence == null && other.KeyConfidence == null ||
                 this.KeyConfidence?.Equals(other.KeyConfidence) == true) &&
                (this.Mode == null && other.Mode == null ||
                 this.Mode?.Equals(other.Mode) == true) &&
                (this.ModeConfidence == null && other.ModeConfidence == null ||
                 this.ModeConfidence?.Equals(other.ModeConfidence) == true) &&
                (this.Codestring == null && other.Codestring == null ||
                 this.Codestring?.Equals(other.Codestring) == true) &&
                (this.CodeVersion == null && other.CodeVersion == null ||
                 this.CodeVersion?.Equals(other.CodeVersion) == true) &&
                (this.Echoprintstring == null && other.Echoprintstring == null ||
                 this.Echoprintstring?.Equals(other.Echoprintstring) == true) &&
                (this.EchoprintVersion == null && other.EchoprintVersion == null ||
                 this.EchoprintVersion?.Equals(other.EchoprintVersion) == true) &&
                (this.Synchstring == null && other.Synchstring == null ||
                 this.Synchstring?.Equals(other.Synchstring) == true) &&
                (this.SynchVersion == null && other.SynchVersion == null ||
                 this.SynchVersion?.Equals(other.SynchVersion) == true) &&
                (this.Rhythmstring == null && other.Rhythmstring == null ||
                 this.Rhythmstring?.Equals(other.Rhythmstring) == true) &&
                (this.RhythmVersion == null && other.RhythmVersion == null ||
                 this.RhythmVersion?.Equals(other.RhythmVersion) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"NumSamples = {(this.NumSamples == null ? "null" : this.NumSamples.ToString())}");
            toStringOutput.Add($"Duration = {(this.Duration == null ? "null" : this.Duration.ToString())}");
            toStringOutput.Add($"SampleMd5 = {this.SampleMd5 ?? "null"}");
            toStringOutput.Add($"OffsetSeconds = {(this.OffsetSeconds == null ? "null" : this.OffsetSeconds.ToString())}");
            toStringOutput.Add($"WindowSeconds = {(this.WindowSeconds == null ? "null" : this.WindowSeconds.ToString())}");
            toStringOutput.Add($"AnalysisSampleRate = {(this.AnalysisSampleRate == null ? "null" : this.AnalysisSampleRate.ToString())}");
            toStringOutput.Add($"AnalysisChannels = {(this.AnalysisChannels == null ? "null" : this.AnalysisChannels.ToString())}");
            toStringOutput.Add($"EndOfFadeIn = {(this.EndOfFadeIn == null ? "null" : this.EndOfFadeIn.ToString())}");
            toStringOutput.Add($"StartOfFadeOut = {(this.StartOfFadeOut == null ? "null" : this.StartOfFadeOut.ToString())}");
            toStringOutput.Add($"Loudness = {(this.Loudness == null ? "null" : this.Loudness.ToString())}");
            toStringOutput.Add($"Tempo = {(this.Tempo == null ? "null" : this.Tempo.ToString())}");
            toStringOutput.Add($"TempoConfidence = {(this.TempoConfidence == null ? "null" : this.TempoConfidence.ToString())}");
            toStringOutput.Add($"TimeSignature = {(this.TimeSignature == null ? "null" : this.TimeSignature.ToString())}");
            toStringOutput.Add($"TimeSignatureConfidence = {(this.TimeSignatureConfidence == null ? "null" : this.TimeSignatureConfidence.ToString())}");
            toStringOutput.Add($"Key = {(this.Key == null ? "null" : this.Key.ToString())}");
            toStringOutput.Add($"KeyConfidence = {(this.KeyConfidence == null ? "null" : this.KeyConfidence.ToString())}");
            toStringOutput.Add($"Mode = {(this.Mode == null ? "null" : this.Mode.ToString())}");
            toStringOutput.Add($"ModeConfidence = {(this.ModeConfidence == null ? "null" : this.ModeConfidence.ToString())}");
            toStringOutput.Add($"Codestring = {this.Codestring ?? "null"}");
            toStringOutput.Add($"CodeVersion = {(this.CodeVersion == null ? "null" : this.CodeVersion.ToString())}");
            toStringOutput.Add($"Echoprintstring = {this.Echoprintstring ?? "null"}");
            toStringOutput.Add($"EchoprintVersion = {(this.EchoprintVersion == null ? "null" : this.EchoprintVersion.ToString())}");
            toStringOutput.Add($"Synchstring = {this.Synchstring ?? "null"}");
            toStringOutput.Add($"SynchVersion = {(this.SynchVersion == null ? "null" : this.SynchVersion.ToString())}");
            toStringOutput.Add($"Rhythmstring = {this.Rhythmstring ?? "null"}");
            toStringOutput.Add($"RhythmVersion = {(this.RhythmVersion == null ? "null" : this.RhythmVersion.ToString())}");
        }
    }
}