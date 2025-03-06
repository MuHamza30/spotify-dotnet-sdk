// <copyright file="SavedAlbumObject.cs" company="APIMatic">
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
    /// SavedAlbumObject.
    /// </summary>
    public class SavedAlbumObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavedAlbumObject"/> class.
        /// </summary>
        public SavedAlbumObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedAlbumObject"/> class.
        /// </summary>
        /// <param name="addedAt">added_at.</param>
        /// <param name="album">album.</param>
        public SavedAlbumObject(
            DateTime? addedAt = null,
            Models.AlbumObject album = null)
        {
            this.AddedAt = addedAt;
            this.Album = album;
        }

        /// <summary>
        /// The date and time the album was saved
        /// Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
        /// If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision; see for example, release_date in an album object.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("added_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? AddedAt { get; set; }

        /// <summary>
        /// Information about the album.
        /// </summary>
        [JsonProperty("album", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AlbumObject Album { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SavedAlbumObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SavedAlbumObject other &&
                (this.AddedAt == null && other.AddedAt == null ||
                 this.AddedAt?.Equals(other.AddedAt) == true) &&
                (this.Album == null && other.Album == null ||
                 this.Album?.Equals(other.Album) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AddedAt = {(this.AddedAt == null ? "null" : this.AddedAt.ToString())}");
            toStringOutput.Add($"Album = {(this.Album == null ? "null" : this.Album.ToString())}");
        }
    }
}