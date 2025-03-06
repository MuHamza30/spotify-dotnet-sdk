// <copyright file="AlbumObject.cs" company="APIMatic">
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
    /// AlbumObject.
    /// </summary>
    public class AlbumObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumObject"/> class.
        /// </summary>
        public AlbumObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumObject"/> class.
        /// </summary>
        /// <param name="albumType">album_type.</param>
        /// <param name="totalTracks">total_tracks.</param>
        /// <param name="availableMarkets">available_markets.</param>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="images">images.</param>
        /// <param name="name">name.</param>
        /// <param name="releaseDate">release_date.</param>
        /// <param name="releaseDatePrecision">release_date_precision.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        /// <param name="artists">artists.</param>
        /// <param name="tracks">tracks.</param>
        /// <param name="copyrights">copyrights.</param>
        /// <param name="externalIds">external_ids.</param>
        /// <param name="genres">genres.</param>
        /// <param name="label">label.</param>
        /// <param name="popularity">popularity.</param>
        /// <param name="restrictions">restrictions.</param>
        public AlbumObject(
            Models.AlbumTypeEnum albumType,
            int totalTracks,
            List<string> availableMarkets,
            Models.ExternalUrlObject externalUrls,
            string href,
            string id,
            List<Models.ImageObject> images,
            string name,
            string releaseDate,
            Models.ReleaseDatePrecisionEnum releaseDatePrecision,
            string type,
            string uri,
            List<Models.SimplifiedArtistObject> artists,
            Models.PagingSimplifiedTrackObject tracks,
            List<Models.CopyrightObject> copyrights,
            Models.ExternalIdObject externalIds,
            List<string> genres,
            string label,
            int popularity,
            Models.AlbumRestrictionObject restrictions = null)
        {
            this.AlbumType = albumType;
            this.TotalTracks = totalTracks;
            this.AvailableMarkets = availableMarkets;
            this.ExternalUrls = externalUrls;
            this.Href = href;
            this.Id = id;
            this.Images = images;
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.ReleaseDatePrecision = releaseDatePrecision;
            this.Restrictions = restrictions;
            this.Type = type;
            this.Uri = uri;
            this.Artists = artists;
            this.Tracks = tracks;
            this.Copyrights = copyrights;
            this.ExternalIds = externalIds;
            this.Genres = genres;
            this.Label = label;
            this.Popularity = popularity;
        }

        /// <summary>
        /// The type of the album.
        /// </summary>
        [JsonProperty("album_type")]
        public Models.AlbumTypeEnum AlbumType { get; set; }

        /// <summary>
        /// The number of tracks in the album.
        /// </summary>
        [JsonProperty("total_tracks")]
        public int TotalTracks { get; set; }

        /// <summary>
        /// The markets in which the album is available: [ISO 3166-1 alpha-2 country codes](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _**NOTE**: an album is considered available in a market when at least 1 of its tracks is available in that market._
        /// </summary>
        [JsonProperty("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        /// <summary>
        /// Known external URLs for this album.
        /// </summary>
        [JsonProperty("external_urls")]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the album.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the album.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The cover art for the album in various sizes, widest first.
        /// </summary>
        [JsonProperty("images")]
        public List<Models.ImageObject> Images { get; set; }

        /// <summary>
        /// The name of the album. In case of an album takedown, the value may be an empty string.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The date the album was first released.
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which `release_date` value is known.
        /// </summary>
        [JsonProperty("release_date_precision")]
        public Models.ReleaseDatePrecisionEnum ReleaseDatePrecision { get; set; }

        /// <summary>
        /// Included in the response when a content restriction is applied.
        /// </summary>
        [JsonProperty("restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AlbumRestrictionObject Restrictions { get; set; }

        /// <summary>
        /// The object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the album.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The artists of the album. Each artist object includes a link in `href` to more detailed information about the artist.
        /// </summary>
        [JsonProperty("artists")]
        public List<Models.SimplifiedArtistObject> Artists { get; set; }

        /// <summary>
        /// The tracks of the album.
        /// </summary>
        [JsonProperty("tracks")]
        public Models.PagingSimplifiedTrackObject Tracks { get; set; }

        /// <summary>
        /// The copyright statements of the album.
        /// </summary>
        [JsonProperty("copyrights")]
        public List<Models.CopyrightObject> Copyrights { get; set; }

        /// <summary>
        /// Known external IDs for the album.
        /// </summary>
        [JsonProperty("external_ids")]
        public Models.ExternalIdObject ExternalIds { get; set; }

        /// <summary>
        /// A list of the genres the album is associated with. If not yet classified, the array is empty.
        /// </summary>
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        /// <summary>
        /// The label associated with the album.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The popularity of the album. The value will be between 0 and 100, with 100 being the most popular.
        /// </summary>
        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AlbumObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is AlbumObject other &&
                (this.AlbumType.Equals(other.AlbumType)) &&
                (this.TotalTracks.Equals(other.TotalTracks)) &&
                (this.AvailableMarkets == null && other.AvailableMarkets == null ||
                 this.AvailableMarkets?.Equals(other.AvailableMarkets) == true) &&
                (this.ExternalUrls == null && other.ExternalUrls == null ||
                 this.ExternalUrls?.Equals(other.ExternalUrls) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Images == null && other.Images == null ||
                 this.Images?.Equals(other.Images) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.ReleaseDate == null && other.ReleaseDate == null ||
                 this.ReleaseDate?.Equals(other.ReleaseDate) == true) &&
                (this.ReleaseDatePrecision.Equals(other.ReleaseDatePrecision)) &&
                (this.Restrictions == null && other.Restrictions == null ||
                 this.Restrictions?.Equals(other.Restrictions) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true) &&
                (this.Artists == null && other.Artists == null ||
                 this.Artists?.Equals(other.Artists) == true) &&
                (this.Tracks == null && other.Tracks == null ||
                 this.Tracks?.Equals(other.Tracks) == true) &&
                (this.Copyrights == null && other.Copyrights == null ||
                 this.Copyrights?.Equals(other.Copyrights) == true) &&
                (this.ExternalIds == null && other.ExternalIds == null ||
                 this.ExternalIds?.Equals(other.ExternalIds) == true) &&
                (this.Genres == null && other.Genres == null ||
                 this.Genres?.Equals(other.Genres) == true) &&
                (this.Label == null && other.Label == null ||
                 this.Label?.Equals(other.Label) == true) &&
                (this.Popularity.Equals(other.Popularity));
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AlbumType = {this.AlbumType}");
            toStringOutput.Add($"TotalTracks = {this.TotalTracks}");
            toStringOutput.Add($"AvailableMarkets = {(this.AvailableMarkets == null ? "null" : $"[{string.Join(", ", this.AvailableMarkets)} ]")}");
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Images = {(this.Images == null ? "null" : $"[{string.Join(", ", this.Images)} ]")}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"ReleaseDate = {this.ReleaseDate ?? "null"}");
            toStringOutput.Add($"ReleaseDatePrecision = {this.ReleaseDatePrecision}");
            toStringOutput.Add($"Restrictions = {(this.Restrictions == null ? "null" : this.Restrictions.ToString())}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
            toStringOutput.Add($"Artists = {(this.Artists == null ? "null" : $"[{string.Join(", ", this.Artists)} ]")}");
            toStringOutput.Add($"Tracks = {(this.Tracks == null ? "null" : this.Tracks.ToString())}");
            toStringOutput.Add($"Copyrights = {(this.Copyrights == null ? "null" : $"[{string.Join(", ", this.Copyrights)} ]")}");
            toStringOutput.Add($"ExternalIds = {(this.ExternalIds == null ? "null" : this.ExternalIds.ToString())}");
            toStringOutput.Add($"Genres = {(this.Genres == null ? "null" : $"[{string.Join(", ", this.Genres)} ]")}");
            toStringOutput.Add($"Label = {this.Label ?? "null"}");
            toStringOutput.Add($"Popularity = {this.Popularity}");
        }
    }
}