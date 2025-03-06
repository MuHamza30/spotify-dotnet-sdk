// <copyright file="CategoryObject.cs" company="APIMatic">
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
    /// CategoryObject.
    /// </summary>
    public class CategoryObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryObject"/> class.
        /// </summary>
        public CategoryObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryObject"/> class.
        /// </summary>
        /// <param name="href">href.</param>
        /// <param name="icons">icons.</param>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        public CategoryObject(
            string href,
            List<Models.ImageObject> icons,
            string id,
            string name)
        {
            this.Href = href;
            this.Icons = icons;
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// A link to the Web API endpoint returning full details of the category.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The category icon, in various sizes.
        /// </summary>
        [JsonProperty("icons")]
        public List<Models.ImageObject> Icons { get; set; }

        /// <summary>
        /// The [Spotify category ID](/documentation/web-api/concepts/spotify-uris-ids) of the category.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CategoryObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CategoryObject other &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Icons == null && other.Icons == null ||
                 this.Icons?.Equals(other.Icons) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Icons = {(this.Icons == null ? "null" : $"[{string.Join(", ", this.Icons)} ]")}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
        }
    }
}