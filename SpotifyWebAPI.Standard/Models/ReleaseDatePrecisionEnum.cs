// <copyright file="ReleaseDatePrecisionEnum.cs" company="APIMatic">
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
    /// ReleaseDatePrecisionEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReleaseDatePrecisionEnum
    {
        /// <summary>
        /// Year.
        /// </summary>
        [EnumMember(Value = "year")]
        Year,

        /// <summary>
        /// Month.
        /// </summary>
        [EnumMember(Value = "month")]
        Month,

        /// <summary>
        /// Day.
        /// </summary>
        [EnumMember(Value = "day")]
        Day
    }
}