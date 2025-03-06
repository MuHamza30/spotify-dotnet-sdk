// <copyright file="ManyChapters.cs" company="APIMatic">
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
    /// ManyChapters.
    /// </summary>
    public class ManyChapters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyChapters"/> class.
        /// </summary>
        public ManyChapters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyChapters"/> class.
        /// </summary>
        /// <param name="chapters">chapters.</param>
        public ManyChapters(
            List<Models.ChapterObject> chapters)
        {
            this.Chapters = chapters;
        }

        /// <summary>
        /// Gets or sets Chapters.
        /// </summary>
        [JsonProperty("chapters")]
        public List<Models.ChapterObject> Chapters { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyChapters : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyChapters other &&
                (this.Chapters == null && other.Chapters == null ||
                 this.Chapters?.Equals(other.Chapters) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Chapters = {(this.Chapters == null ? "null" : $"[{string.Join(", ", this.Chapters)} ]")}");
        }
    }
}