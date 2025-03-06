// <copyright file="ImageObject.cs" company="APIMatic">
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
    /// ImageObject.
    /// </summary>
    public class ImageObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageObject"/> class.
        /// </summary>
        public ImageObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageObject"/> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="height">height.</param>
        /// <param name="width">width.</param>
        public ImageObject(
            string url,
            int? height = null,
            int? width = null)
        {
            this.Url = url;
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// The source URL of the image.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The image height in pixels.
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Include)]
        public int? Height { get; set; }

        /// <summary>
        /// The image width in pixels.
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Include)]
        public int? Width { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ImageObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ImageObject other &&
                (this.Url == null && other.Url == null ||
                 this.Url?.Equals(other.Url) == true) &&
                (this.Height == null && other.Height == null ||
                 this.Height?.Equals(other.Height) == true) &&
                (this.Width == null && other.Width == null ||
                 this.Width?.Equals(other.Width) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Url = {this.Url ?? "null"}");
            toStringOutput.Add($"Height = {(this.Height == null ? "null" : this.Height.ToString())}");
            toStringOutput.Add($"Width = {(this.Width == null ? "null" : this.Width.ToString())}");
        }
    }
}