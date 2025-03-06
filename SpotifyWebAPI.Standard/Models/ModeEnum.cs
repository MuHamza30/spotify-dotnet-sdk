// <copyright file="ModeEnum.cs" company="APIMatic">
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
    /// ModeEnum.
    /// </summary>

    [JsonConverter(typeof(NumberEnumConverter))]
    public enum ModeEnum
    {
        /// <summary>
        /// EnumMinus1.
        /// </summary>
        EnumMinus1 = -1,

        /// <summary>
        /// Enum0.
        /// </summary>
        Enum0 = 0,

        /// <summary>
        /// Enum1.
        /// </summary>
        Enum1 = 1
    }
}