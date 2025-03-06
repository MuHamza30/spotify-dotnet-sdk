// <copyright file="AlbumGroupEnum.cs" company="APIMatic">
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
    /// AlbumGroupEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlbumGroupEnum
    {
        /// <summary>
        /// Album.
        /// </summary>
        [EnumMember(Value = "album")]
        Album,

        /// <summary>
        /// Single.
        /// </summary>
        [EnumMember(Value = "single")]
        Single,

        /// <summary>
        /// Compilation.
        /// </summary>
        [EnumMember(Value = "compilation")]
        Compilation,

        /// <summary>
        /// AppearsOn.
        /// </summary>
        [EnumMember(Value = "appears_on")]
        AppearsOn
    }
}