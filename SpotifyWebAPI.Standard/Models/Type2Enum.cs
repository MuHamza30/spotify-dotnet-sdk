// <copyright file="Type2Enum.cs" company="APIMatic">
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
    /// Type2Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type2Enum
    {
        /// <summary>
        /// Track.
        /// </summary>
        [EnumMember(Value = "track")]
        Track
    }
}