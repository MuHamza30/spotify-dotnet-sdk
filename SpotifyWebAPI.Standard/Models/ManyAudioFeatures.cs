// <copyright file="ManyAudioFeatures.cs" company="APIMatic">
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
    /// ManyAudioFeatures.
    /// </summary>
    public class ManyAudioFeatures
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyAudioFeatures"/> class.
        /// </summary>
        public ManyAudioFeatures()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyAudioFeatures"/> class.
        /// </summary>
        /// <param name="audioFeatures">audio_features.</param>
        public ManyAudioFeatures(
            List<Models.AudioFeaturesObject> audioFeatures)
        {
            this.AudioFeatures = audioFeatures;
        }

        /// <summary>
        /// Gets or sets AudioFeatures.
        /// </summary>
        [JsonProperty("audio_features")]
        public List<Models.AudioFeaturesObject> AudioFeatures { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyAudioFeatures : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyAudioFeatures other &&
                (this.AudioFeatures == null && other.AudioFeatures == null ||
                 this.AudioFeatures?.Equals(other.AudioFeatures) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AudioFeatures = {(this.AudioFeatures == null ? "null" : $"[{string.Join(", ", this.AudioFeatures)} ]")}");
        }
    }
}