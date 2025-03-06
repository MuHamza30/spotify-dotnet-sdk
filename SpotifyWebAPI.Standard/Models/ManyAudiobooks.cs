// <copyright file="ManyAudiobooks.cs" company="APIMatic">
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
    /// ManyAudiobooks.
    /// </summary>
    public class ManyAudiobooks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyAudiobooks"/> class.
        /// </summary>
        public ManyAudiobooks()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyAudiobooks"/> class.
        /// </summary>
        /// <param name="audiobooks">audiobooks.</param>
        public ManyAudiobooks(
            List<Models.AudiobookObject> audiobooks)
        {
            this.Audiobooks = audiobooks;
        }

        /// <summary>
        /// Gets or sets Audiobooks.
        /// </summary>
        [JsonProperty("audiobooks")]
        public List<Models.AudiobookObject> Audiobooks { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyAudiobooks : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyAudiobooks other &&
                (this.Audiobooks == null && other.Audiobooks == null ||
                 this.Audiobooks?.Equals(other.Audiobooks) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Audiobooks = {(this.Audiobooks == null ? "null" : $"[{string.Join(", ", this.Audiobooks)} ]")}");
        }
    }
}