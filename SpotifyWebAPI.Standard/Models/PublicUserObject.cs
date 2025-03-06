// <copyright file="PublicUserObject.cs" company="APIMatic">
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
    /// PublicUserObject.
    /// </summary>
    public class PublicUserObject
    {
        private string displayName;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "display_name", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicUserObject"/> class.
        /// </summary>
        public PublicUserObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicUserObject"/> class.
        /// </summary>
        /// <param name="displayName">display_name.</param>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="followers">followers.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="images">images.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        public PublicUserObject(
            string displayName = null,
            Models.ExternalUrlObject externalUrls = null,
            Models.FollowersObject followers = null,
            string href = null,
            string id = null,
            List<Models.ImageObject> images = null,
            Models.Type3Enum? type = null,
            string uri = null)
        {

            if (displayName != null)
            {
                this.DisplayName = displayName;
            }
            this.ExternalUrls = externalUrls;
            this.Followers = followers;
            this.Href = href;
            this.Id = id;
            this.Images = images;
            this.Type = type;
            this.Uri = uri;
        }

        /// <summary>
        /// The name displayed on the user's profile. `null` if not available.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            set
            {
                this.shouldSerialize["display_name"] = true;
                this.displayName = value;
            }
        }

        /// <summary>
        /// Known public external URLs for this user.
        /// </summary>
        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// Information about the followers of this user.
        /// </summary>
        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FollowersObject Followers { get; set; }

        /// <summary>
        /// A link to the Web API endpoint for this user.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for this user.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// The user's profile image.
        /// </summary>
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ImageObject> Images { get; set; }

        /// <summary>
        /// The object type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Type3Enum? Type { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for this user.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PublicUserObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serialized.
        /// </summary>
        public void UnsetDisplayName()
        {
            this.shouldSerialize["display_name"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDisplayName()
        {
            return this.shouldSerialize["display_name"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PublicUserObject other &&
                (this.DisplayName == null && other.DisplayName == null ||
                 this.DisplayName?.Equals(other.DisplayName) == true) &&
                (this.ExternalUrls == null && other.ExternalUrls == null ||
                 this.ExternalUrls?.Equals(other.ExternalUrls) == true) &&
                (this.Followers == null && other.Followers == null ||
                 this.Followers?.Equals(other.Followers) == true) &&
                (this.Href == null && other.Href == null ||
                 this.Href?.Equals(other.Href) == true) &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Images == null && other.Images == null ||
                 this.Images?.Equals(other.Images) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Uri == null && other.Uri == null ||
                 this.Uri?.Equals(other.Uri) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DisplayName = {this.DisplayName ?? "null"}");
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Followers = {(this.Followers == null ? "null" : this.Followers.ToString())}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Images = {(this.Images == null ? "null" : $"[{string.Join(", ", this.Images)} ]")}");
            toStringOutput.Add($"Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
        }
    }
}