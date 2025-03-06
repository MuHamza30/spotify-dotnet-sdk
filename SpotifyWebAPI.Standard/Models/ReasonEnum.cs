// <copyright file="ReasonEnum.cs" company="APIMatic">
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
    /// ReasonEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReasonEnum
    {
        /// <summary>
        /// Market.
        /// </summary>
        [EnumMember(Value = "market")]
        Market,

        /// <summary>
        /// Product.
        /// </summary>
        [EnumMember(Value = "product")]
        Product,

        /// <summary>
        /// Explicit.
        /// </summary>
        [EnumMember(Value = "explicit")]
        Explicit
    }
}