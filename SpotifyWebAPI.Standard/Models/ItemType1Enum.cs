// <copyright file="ItemType1Enum.cs" company="APIMatic">
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
    /// ItemType1Enum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType1Enum
    {
        /// <summary>
        /// Artist.
        /// </summary>
        [EnumMember(Value = "artist")]
        Artist
    }
}