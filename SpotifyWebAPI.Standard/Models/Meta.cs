// <copyright file="Meta.cs" company="APIMatic">
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
    /// Meta.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Meta"/> class.
        /// </summary>
        public Meta()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meta"/> class.
        /// </summary>
        /// <param name="analyzerVersion">analyzer_version.</param>
        /// <param name="platform">platform.</param>
        /// <param name="detailedStatus">detailed_status.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="analysisTime">analysis_time.</param>
        /// <param name="inputProcess">input_process.</param>
        public Meta(
            string analyzerVersion = null,
            string platform = null,
            string detailedStatus = null,
            int? statusCode = null,
            long? timestamp = null,
            double? analysisTime = null,
            string inputProcess = null)
        {
            this.AnalyzerVersion = analyzerVersion;
            this.Platform = platform;
            this.DetailedStatus = detailedStatus;
            this.StatusCode = statusCode;
            this.Timestamp = timestamp;
            this.AnalysisTime = analysisTime;
            this.InputProcess = inputProcess;
        }

        /// <summary>
        /// The version of the Analyzer used to analyze this track.
        /// </summary>
        [JsonProperty("analyzer_version", NullValueHandling = NullValueHandling.Ignore)]
        public string AnalyzerVersion { get; set; }

        /// <summary>
        /// The platform used to read the track's audio data.
        /// </summary>
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        /// <summary>
        /// A detailed status code for this track. If analysis data is missing, this code may explain why.
        /// </summary>
        [JsonProperty("detailed_status", NullValueHandling = NullValueHandling.Ignore)]
        public string DetailedStatus { get; set; }

        /// <summary>
        /// The return code of the analyzer process. 0 if successful, 1 if any errors occurred.
        /// </summary>
        [JsonProperty("status_code", NullValueHandling = NullValueHandling.Ignore)]
        public int? StatusCode { get; set; }

        /// <summary>
        /// The Unix timestamp (in seconds) at which this track was analyzed.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        /// <summary>
        /// The amount of time taken to analyze this track.
        /// </summary>
        [JsonProperty("analysis_time", NullValueHandling = NullValueHandling.Ignore)]
        public double? AnalysisTime { get; set; }

        /// <summary>
        /// The method used to read the track's audio data.
        /// </summary>
        [JsonProperty("input_process", NullValueHandling = NullValueHandling.Ignore)]
        public string InputProcess { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Meta : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Meta other &&
                (this.AnalyzerVersion == null && other.AnalyzerVersion == null ||
                 this.AnalyzerVersion?.Equals(other.AnalyzerVersion) == true) &&
                (this.Platform == null && other.Platform == null ||
                 this.Platform?.Equals(other.Platform) == true) &&
                (this.DetailedStatus == null && other.DetailedStatus == null ||
                 this.DetailedStatus?.Equals(other.DetailedStatus) == true) &&
                (this.StatusCode == null && other.StatusCode == null ||
                 this.StatusCode?.Equals(other.StatusCode) == true) &&
                (this.Timestamp == null && other.Timestamp == null ||
                 this.Timestamp?.Equals(other.Timestamp) == true) &&
                (this.AnalysisTime == null && other.AnalysisTime == null ||
                 this.AnalysisTime?.Equals(other.AnalysisTime) == true) &&
                (this.InputProcess == null && other.InputProcess == null ||
                 this.InputProcess?.Equals(other.InputProcess) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AnalyzerVersion = {this.AnalyzerVersion ?? "null"}");
            toStringOutput.Add($"Platform = {this.Platform ?? "null"}");
            toStringOutput.Add($"DetailedStatus = {this.DetailedStatus ?? "null"}");
            toStringOutput.Add($"StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}");
            toStringOutput.Add($"Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp.ToString())}");
            toStringOutput.Add($"AnalysisTime = {(this.AnalysisTime == null ? "null" : this.AnalysisTime.ToString())}");
            toStringOutput.Add($"InputProcess = {this.InputProcess ?? "null"}");
        }
    }
}