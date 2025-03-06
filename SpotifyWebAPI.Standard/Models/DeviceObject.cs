// <copyright file="DeviceObject.cs" company="APIMatic">
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
    /// DeviceObject.
    /// </summary>
    public class DeviceObject
    {
        private string id;
        private int? volumePercent;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "id", false },
            { "volume_percent", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceObject"/> class.
        /// </summary>
        public DeviceObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceObject"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="isActive">is_active.</param>
        /// <param name="isPrivateSession">is_private_session.</param>
        /// <param name="isRestricted">is_restricted.</param>
        /// <param name="name">name.</param>
        /// <param name="type">type.</param>
        /// <param name="volumePercent">volume_percent.</param>
        /// <param name="supportsVolume">supports_volume.</param>
        public DeviceObject(
            string id = null,
            bool? isActive = null,
            bool? isPrivateSession = null,
            bool? isRestricted = null,
            string name = null,
            string type = null,
            int? volumePercent = null,
            bool? supportsVolume = null)
        {

            if (id != null)
            {
                this.Id = id;
            }
            this.IsActive = isActive;
            this.IsPrivateSession = isPrivateSession;
            this.IsRestricted = isRestricted;
            this.Name = name;
            this.Type = type;

            if (volumePercent != null)
            {
                this.VolumePercent = volumePercent;
            }
            this.SupportsVolume = supportsVolume;
        }

        /// <summary>
        /// The device ID. This ID is unique and persistent to some extent. However, this is not guaranteed and any cached `device_id` should periodically be cleared out and refetched as necessary.
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.shouldSerialize["id"] = true;
                this.id = value;
            }
        }

        /// <summary>
        /// If this device is the currently active device.
        /// </summary>
        [JsonProperty("is_active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActive { get; set; }

        /// <summary>
        /// If this device is currently in a private session.
        /// </summary>
        [JsonProperty("is_private_session", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivateSession { get; set; }

        /// <summary>
        /// Whether controlling this device is restricted. At present if this is "true" then no Web API commands will be accepted by this device.
        /// </summary>
        [JsonProperty("is_restricted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRestricted { get; set; }

        /// <summary>
        /// A human-readable name for the device. Some devices have a name that the user can configure (e.g. \"Loudest speaker\") and some devices have a generic name associated with the manufacturer or device model.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Device type, such as "computer", "smartphone" or "speaker".
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// The current volume in percent.
        /// </summary>
        [JsonProperty("volume_percent")]
        public int? VolumePercent
        {
            get
            {
                return this.volumePercent;
            }

            set
            {
                this.shouldSerialize["volume_percent"] = true;
                this.volumePercent = value;
            }
        }

        /// <summary>
        /// If this device can be used to set the volume.
        /// </summary>
        [JsonProperty("supports_volume", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SupportsVolume { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DeviceObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serialized.
        /// </summary>
        public void UnsetId()
        {
            this.shouldSerialize["id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serialized.
        /// </summary>
        public void UnsetVolumePercent()
        {
            this.shouldSerialize["volume_percent"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeId()
        {
            return this.shouldSerialize["id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVolumePercent()
        {
            return this.shouldSerialize["volume_percent"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is DeviceObject other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.IsActive == null && other.IsActive == null ||
                 this.IsActive?.Equals(other.IsActive) == true) &&
                (this.IsPrivateSession == null && other.IsPrivateSession == null ||
                 this.IsPrivateSession?.Equals(other.IsPrivateSession) == true) &&
                (this.IsRestricted == null && other.IsRestricted == null ||
                 this.IsRestricted?.Equals(other.IsRestricted) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.VolumePercent == null && other.VolumePercent == null ||
                 this.VolumePercent?.Equals(other.VolumePercent) == true) &&
                (this.SupportsVolume == null && other.SupportsVolume == null ||
                 this.SupportsVolume?.Equals(other.SupportsVolume) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"IsActive = {(this.IsActive == null ? "null" : this.IsActive.ToString())}");
            toStringOutput.Add($"IsPrivateSession = {(this.IsPrivateSession == null ? "null" : this.IsPrivateSession.ToString())}");
            toStringOutput.Add($"IsRestricted = {(this.IsRestricted == null ? "null" : this.IsRestricted.ToString())}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
            toStringOutput.Add($"VolumePercent = {(this.VolumePercent == null ? "null" : this.VolumePercent.ToString())}");
            toStringOutput.Add($"SupportsVolume = {(this.SupportsVolume == null ? "null" : this.SupportsVolume.ToString())}");
        }
    }
}