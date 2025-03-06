// <copyright file="ManyAlbums.cs" company="APIMatic">
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
    /// ManyAlbums.
    /// </summary>
    public class ManyAlbums
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyAlbums"/> class.
        /// </summary>
        public ManyAlbums()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyAlbums"/> class.
        /// </summary>
        /// <param name="albums">albums.</param>
        public ManyAlbums(
            List<Models.AlbumObject> albums)
        {
            this.Albums = albums;
        }

        /// <summary>
        /// Gets or sets Albums.
        /// </summary>
        [JsonProperty("albums")]
        public List<Models.AlbumObject> Albums { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyAlbums : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyAlbums other &&
                (this.Albums == null && other.Albums == null ||
                 this.Albums?.Equals(other.Albums) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Albums = {(this.Albums == null ? "null" : $"[{string.Join(", ", this.Albums)} ]")}");
        }
    }
}