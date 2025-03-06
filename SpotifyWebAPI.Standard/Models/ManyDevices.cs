// <copyright file="ManyDevices.cs" company="APIMatic">
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
    /// ManyDevices.
    /// </summary>
    public class ManyDevices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyDevices"/> class.
        /// </summary>
        public ManyDevices()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManyDevices"/> class.
        /// </summary>
        /// <param name="devices">devices.</param>
        public ManyDevices(
            List<Models.DeviceObject> devices)
        {
            this.Devices = devices;
        }

        /// <summary>
        /// Gets or sets Devices.
        /// </summary>
        [JsonProperty("devices")]
        public List<Models.DeviceObject> Devices { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ManyDevices : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ManyDevices other &&
                (this.Devices == null && other.Devices == null ||
                 this.Devices?.Equals(other.Devices) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Devices = {(this.Devices == null ? "null" : $"[{string.Join(", ", this.Devices)} ]")}");
        }
    }
}