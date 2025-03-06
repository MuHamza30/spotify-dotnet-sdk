// <copyright file="AudioFeaturesObject.cs" company="APIMatic">
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
    /// AudioFeaturesObject.
    /// </summary>
    public class AudioFeaturesObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioFeaturesObject"/> class.
        /// </summary>
        public AudioFeaturesObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioFeaturesObject"/> class.
        /// </summary>
        /// <param name="acousticness">acousticness.</param>
        /// <param name="analysisUrl">analysis_url.</param>
        /// <param name="danceability">danceability.</param>
        /// <param name="durationMs">duration_ms.</param>
        /// <param name="energy">energy.</param>
        /// <param name="id">id.</param>
        /// <param name="instrumentalness">instrumentalness.</param>
        /// <param name="key">key.</param>
        /// <param name="liveness">liveness.</param>
        /// <param name="loudness">loudness.</param>
        /// <param name="mode">mode.</param>
        /// <param name="speechiness">speechiness.</param>
        /// <param name="tempo">tempo.</param>
        /// <param name="timeSignature">time_signature.</param>
        /// <param name="trackHref">track_href.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        /// <param name="valence">valence.</param>
        public AudioFeaturesObject(
            double? acousticness = null,
            string analysisUrl = null,
            double? danceability = null,
            int? durationMs = null,
            double? energy = null,
            string id = null,
            double? instrumentalness = null,
            int? key = null,
            double? liveness = null,
            double? loudness = null,
            int? mode = null,
            double? speechiness = null,
            double? tempo = null,
            int? timeSignature = null,
            string trackHref = null,
            Models.Type5Enum? type = null,
            string uri = null,
            double? valence = null)
        {
            this.Acousticness = acousticness;
            this.AnalysisUrl = analysisUrl;
            this.Danceability = danceability;
            this.DurationMs = durationMs;
            this.Energy = energy;
            this.Id = id;
            this.Instrumentalness = instrumentalness;
            this.Key = key;
            this.Liveness = liveness;
            this.Loudness = loudness;
            this.Mode = mode;
            this.Speechiness = speechiness;
            this.Tempo = tempo;
            this.TimeSignature = timeSignature;
            this.TrackHref = trackHref;
            this.Type = type;
            this.Uri = uri;
            this.Valence = valence;
        }

        /// <summary>
        /// A confidence measure from 0.0 to 1.0 of whether the track is acoustic. 1.0 represents high confidence the track is acoustic.
        /// </summary>
        [JsonProperty("acousticness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Acousticness { get; set; }

        /// <summary>
        /// A URL to access the full audio analysis of this track. An access token is required to access this data.
        /// </summary>
        [JsonProperty("analysis_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AnalysisUrl { get; set; }

        /// <summary>
        /// Danceability describes how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity. A value of 0.0 is least danceable and 1.0 is most danceable.
        /// </summary>
        [JsonProperty("danceability", NullValueHandling = NullValueHandling.Ignore)]
        public double? Danceability { get; set; }

        /// <summary>
        /// The duration of the track in milliseconds.
        /// </summary>
        [JsonProperty("duration_ms", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationMs { get; set; }

        /// <summary>
        /// Energy is a measure from 0.0 to 1.0 and represents a perceptual measure of intensity and activity. Typically, energetic tracks feel fast, loud, and noisy. For example, death metal has high energy, while a Bach prelude scores low on the scale. Perceptual features contributing to this attribute include dynamic range, perceived loudness, timbre, onset rate, and general entropy.
        /// </summary>
        [JsonProperty("energy", NullValueHandling = NullValueHandling.Ignore)]
        public double? Energy { get; set; }

        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Predicts whether a track contains no vocals. "Ooh" and "aah" sounds are treated as instrumental in this context. Rap or spoken word tracks are clearly "vocal". The closer the instrumentalness value is to 1.0, the greater likelihood the track contains no vocal content. Values above 0.5 are intended to represent instrumental tracks, but confidence is higher as the value approaches 1.0.
        /// </summary>
        [JsonProperty("instrumentalness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Instrumentalness { get; set; }

        /// <summary>
        /// The key the track is in. Integers map to pitches using standard [Pitch Class notation](https://en.wikipedia.org/wiki/Pitch_class). E.g. 0 = C, 1 = C♯/D♭, 2 = D, and so on. If no key was detected, the value is -1.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public int? Key { get; set; }

        /// <summary>
        /// Detects the presence of an audience in the recording. Higher liveness values represent an increased probability that the track was performed live. A value above 0.8 provides strong likelihood that the track is live.
        /// </summary>
        [JsonProperty("liveness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Liveness { get; set; }

        /// <summary>
        /// The overall loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typically range between -60 and 0 db.
        /// </summary>
        [JsonProperty("loudness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Loudness { get; set; }

        /// <summary>
        /// Mode indicates the modality (major or minor) of a track, the type of scale from which its melodic content is derived. Major is represented by 1 and minor is 0.
        /// </summary>
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public int? Mode { get; set; }

        /// <summary>
        /// Speechiness detects the presence of spoken words in a track. The more exclusively speech-like the recording (e.g. talk show, audio book, poetry), the closer to 1.0 the attribute value. Values above 0.66 describe tracks that are probably made entirely of spoken words. Values between 0.33 and 0.66 describe tracks that may contain both music and speech, either in sections or layered, including such cases as rap music. Values below 0.33 most likely represent music and other non-speech-like tracks.
        /// </summary>
        [JsonProperty("speechiness", NullValueHandling = NullValueHandling.Ignore)]
        public double? Speechiness { get; set; }

        /// <summary>
        /// The overall estimated tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration.
        /// </summary>
        [JsonProperty("tempo", NullValueHandling = NullValueHandling.Ignore)]
        public double? Tempo { get; set; }

        /// <summary>
        /// An estimated time signature. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure). The time signature ranges from 3 to 7 indicating time signatures of "3/4", to "7/4".
        /// </summary>
        [JsonProperty("time_signature", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeSignature { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the track.
        /// </summary>
        [JsonProperty("track_href", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackHref { get; set; }

        /// <summary>
        /// The object type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Type5Enum? Type { get; set; }

        /// <summary>
        /// The Spotify URI for the track.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <summary>
        /// A measure from 0.0 to 1.0 describing the musical positiveness conveyed by a track. Tracks with high valence sound more positive (e.g. happy, cheerful, euphoric), while tracks with low valence sound more negative (e.g. sad, depressed, angry).
        /// </summary>
        [JsonProperty("valence", NullValueHandling = NullValueHandling.Ignore)]
        public double? Valence { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AudioFeaturesObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is AudioFeaturesObject other &&
                (this.Acousticness == null && other.Acousticness == null ||
                 this.Acousticness?.Equals(other.Acousticness) == true) &&
                (this.AnalysisUrl == null && other.AnalysisUrl == null ||
                 this.AnalysisUrl?.Equals(other.AnalysisUrl) == true) &&
                (this.Danceability == null && other.Danceability == null ||
                 this.Danceability?.Equals(other.Danceability) == true) &&
                (this.DurationMs == null && other.DurationMs == null ||
                 this.DurationMs?.Equals(other.DurationMs) == true) &&
                (this.Energy == null && other.Energy == null ||
                 this.Energy?.Equals(other.Energy) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Instrumentalness == null && other.Instrumentalness == null ||
                 this.Instrumentalness?.Equals(other.Instrumentalness) == true) &&
                (this.Key == null && other.Key == null ||
                 this.Key?.Equals(other.Key) == true) &&
                (this.Liveness == null && other.Liveness == null ||
                 this.Liveness?.Equals(other.Liveness) == true) &&
                (this.Loudness == null && other.Loudness == null ||
                 this.Loudness?.Equals(other.Loudness) == true) &&
                (this.Mode == null && other.Mode == null ||
                 this.Mode?.Equals(other.Mode) == true) &&
                (this.Speechiness == null && other.Speechiness == null ||
                 this.Speechiness?.Equals(other.Speechiness) == true) &&
                (this.Tempo == null && other.Tempo == null ||
                 this.Tempo?.Equals(other.Tempo) == true) &&
                (this.TimeSignature == null && other.TimeSignature == null ||
                 this.TimeSignature?.Equals(other.TimeSignature) == true) &&
                (this.TrackHref == null && other.TrackHref == null ||
                 this.TrackHref?.Equals(other.TrackHref) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true) &&
                (this.Valence == null && other.Valence == null ||
                 this.Valence?.Equals(other.Valence) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Acousticness = {(this.Acousticness == null ? "null" : this.Acousticness.ToString())}");
            toStringOutput.Add($"AnalysisUrl = {this.AnalysisUrl ?? "null"}");
            toStringOutput.Add($"Danceability = {(this.Danceability == null ? "null" : this.Danceability.ToString())}");
            toStringOutput.Add($"DurationMs = {(this.DurationMs == null ? "null" : this.DurationMs.ToString())}");
            toStringOutput.Add($"Energy = {(this.Energy == null ? "null" : this.Energy.ToString())}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Instrumentalness = {(this.Instrumentalness == null ? "null" : this.Instrumentalness.ToString())}");
            toStringOutput.Add($"Key = {(this.Key == null ? "null" : this.Key.ToString())}");
            toStringOutput.Add($"Liveness = {(this.Liveness == null ? "null" : this.Liveness.ToString())}");
            toStringOutput.Add($"Loudness = {(this.Loudness == null ? "null" : this.Loudness.ToString())}");
            toStringOutput.Add($"Mode = {(this.Mode == null ? "null" : this.Mode.ToString())}");
            toStringOutput.Add($"Speechiness = {(this.Speechiness == null ? "null" : this.Speechiness.ToString())}");
            toStringOutput.Add($"Tempo = {(this.Tempo == null ? "null" : this.Tempo.ToString())}");
            toStringOutput.Add($"TimeSignature = {(this.TimeSignature == null ? "null" : this.TimeSignature.ToString())}");
            toStringOutput.Add($"TrackHref = {this.TrackHref ?? "null"}");
            toStringOutput.Add($"Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
            toStringOutput.Add($"Valence = {(this.Valence == null ? "null" : this.Valence.ToString())}");
        }
    }
}