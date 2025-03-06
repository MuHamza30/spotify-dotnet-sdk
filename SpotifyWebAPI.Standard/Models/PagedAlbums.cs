// <copyright file="PagedAlbums.cs" company="APIMatic">
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
    /// PagedAlbums.
    /// </summary>
    public class PagedAlbums
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedAlbums"/> class.
        /// </summary>
        public PagedAlbums()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedAlbums"/> class.
        /// </summary>
        /// <param name="albums">albums.</param>
        public PagedAlbums(
            Models.PagingSimplifiedAlbumObject albums)
        {
            this.Albums = albums;
        }

        /// <summary>
        /// Gets or sets Albums.
        /// </summary>
        [JsonProperty("albums")]
        public Models.PagingSimplifiedAlbumObject Albums { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PagedAlbums : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PagedAlbums other &&
                (this.Albums == null && other.Albums == null ||
                 this.Albums?.Equals(other.Albums) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Albums = {(this.Albums == null ? "null" : this.Albums.ToString())}");
        }
    }
}