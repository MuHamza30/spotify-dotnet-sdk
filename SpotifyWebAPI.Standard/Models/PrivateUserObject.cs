// <copyright file="PrivateUserObject.cs" company="APIMatic">
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
    /// PrivateUserObject.
    /// </summary>
    public class PrivateUserObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateUserObject"/> class.
        /// </summary>
        public PrivateUserObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateUserObject"/> class.
        /// </summary>
        /// <param name="country">country.</param>
        /// <param name="displayName">display_name.</param>
        /// <param name="email">email.</param>
        /// <param name="explicitContent">explicit_content.</param>
        /// <param name="externalUrls">external_urls.</param>
        /// <param name="followers">followers.</param>
        /// <param name="href">href.</param>
        /// <param name="id">id.</param>
        /// <param name="images">images.</param>
        /// <param name="product">product.</param>
        /// <param name="type">type.</param>
        /// <param name="uri">uri.</param>
        public PrivateUserObject(
            string country = null,
            string displayName = null,
            string email = null,
            Models.ExplicitContentSettingsObject explicitContent = null,
            Models.ExternalUrlObject externalUrls = null,
            Models.FollowersObject followers = null,
            string href = null,
            string id = null,
            List<Models.ImageObject> images = null,
            string product = null,
            string type = null,
            string uri = null)
        {
            this.Country = country;
            this.DisplayName = displayName;
            this.Email = email;
            this.ExplicitContent = explicitContent;
            this.ExternalUrls = externalUrls;
            this.Followers = followers;
            this.Href = href;
            this.Id = id;
            this.Images = images;
            this.Product = product;
            this.Type = type;
            this.Uri = uri;
        }

        /// <summary>
        /// The country of the user, as set in the user's account profile. An [ISO 3166-1 alpha-2 country code](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _This field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// The name displayed on the user's profile. `null` if not available.
        /// </summary>
        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The user's email address, as entered by the user when creating their account. _**Important!** This email address is unverified; there is no proof that it actually belongs to the user._ _This field is only available when the current user has granted access to the [user-read-email](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// The user's explicit content settings. _This field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._
        /// </summary>
        [JsonProperty("explicit_content", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExplicitContentSettingsObject ExplicitContent { get; set; }

        /// <summary>
        /// Known external URLs for this user.
        /// </summary>
        [JsonProperty("external_urls", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExternalUrlObject ExternalUrls { get; set; }

        /// <summary>
        /// Information about the followers of the user.
        /// </summary>
        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FollowersObject Followers { get; set; }

        /// <summary>
        /// A link to the Web API endpoint for this user.
        /// </summary>
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        /// <summary>
        /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for the user.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// The user's profile image.
        /// </summary>
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ImageObject> Images { get; set; }

        /// <summary>
        /// The user's Spotify subscription level: "premium", "free", etc. (The subscription level "open" can be considered the same as "free".) _This field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes) scope._
        /// </summary>
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; set; }

        /// <summary>
        /// The object type: "user"
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the user.
        /// </summary>
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PrivateUserObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PrivateUserObject other &&
                (this.Country == null && other.Country == null ||
                 this.Country?.Equals(other.Country) == true) &&
                (this.DisplayName == null && other.DisplayName == null ||
                 this.DisplayName?.Equals(other.DisplayName) == true) &&
                (this.Email == null && other.Email == null ||
                 this.Email?.Equals(other.Email) == true) &&
                (this.ExplicitContent == null && other.ExplicitContent == null ||
                 this.ExplicitContent?.Equals(other.ExplicitContent) == true) &&
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
                (this.Product == null && other.Product == null ||
                 this.Product?.Equals(other.Product) == true) &&
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
            toStringOutput.Add($"Country = {this.Country ?? "null"}");
            toStringOutput.Add($"DisplayName = {this.DisplayName ?? "null"}");
            toStringOutput.Add($"Email = {this.Email ?? "null"}");
            toStringOutput.Add($"ExplicitContent = {(this.ExplicitContent == null ? "null" : this.ExplicitContent.ToString())}");
            toStringOutput.Add($"ExternalUrls = {(this.ExternalUrls == null ? "null" : this.ExternalUrls.ToString())}");
            toStringOutput.Add($"Followers = {(this.Followers == null ? "null" : this.Followers.ToString())}");
            toStringOutput.Add($"Href = {this.Href ?? "null"}");
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Images = {(this.Images == null ? "null" : $"[{string.Join(", ", this.Images)} ]")}");
            toStringOutput.Add($"Product = {this.Product ?? "null"}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
            toStringOutput.Add($"Uri = {this.Uri ?? "null"}");
        }
    }
}