// <copyright file="MePlayerRequest.cs" company="APIMatic">
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
    /// MePlayerRequest.
    /// </summary>
    public class MePlayerRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MePlayerRequest"/> class.
        /// </summary>
        public MePlayerRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MePlayerRequest"/> class.
        /// </summary>
        /// <param name="deviceIds">device_ids.</param>
        /// <param name="play">play.</param>
        public MePlayerRequest(
            List<string> deviceIds,
            bool? play = null)
        {
            this.DeviceIds = deviceIds;
            this.Play = play;
        }

        /// <summary>
        /// A JSON array containing the ID of the device on which playback should be started/transferred.<br/>For example:`{device_ids:["74ASZWbe4lXaubB36ztrGX"]}`<br/>_**Note**: Although an array is accepted, only a single device_id is currently supported. Supplying more than one will return `400 Bad Request`_
        /// </summary>
        [JsonProperty("device_ids")]
        public List<string> DeviceIds { get; set; }

        /// <summary>
        /// **true**: ensure playback happens on new device.<br/>**false** or not provided: keep the current playback state.
        /// </summary>
        [JsonProperty("play", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Play { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"MePlayerRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is MePlayerRequest other &&
                (this.DeviceIds == null && other.DeviceIds == null ||
                 this.DeviceIds?.Equals(other.DeviceIds) == true) &&
                (this.Play == null && other.Play == null ||
                 this.Play?.Equals(other.Play) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DeviceIds = {(this.DeviceIds == null ? "null" : $"[{string.Join(", ", this.DeviceIds)} ]")}");
            toStringOutput.Add($"Play = {(this.Play == null ? "null" : this.Play.ToString())}");
        }
    }
}