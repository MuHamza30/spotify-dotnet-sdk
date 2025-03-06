// <copyright file="Type5Enum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// Type5Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type5Enum
    {
        /// <summary>
        /// AudioFeatures.
        /// </summary>
        [EnumMember(Value = "audio_features")]
        AudioFeatures
    }
}