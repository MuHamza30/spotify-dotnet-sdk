// <copyright file="ItemTypeEnum.cs" company="APIMatic">
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
    /// ItemTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemTypeEnum
    {
        /// <summary>
        /// Album.
        /// </summary>
        [EnumMember(Value = "album")]
        Album,

        /// <summary>
        /// Artist.
        /// </summary>
        [EnumMember(Value = "artist")]
        Artist,

        /// <summary>
        /// Playlist.
        /// </summary>
        [EnumMember(Value = "playlist")]
        Playlist,

        /// <summary>
        /// Track.
        /// </summary>
        [EnumMember(Value = "track")]
        Track,

        /// <summary>
        /// Show.
        /// </summary>
        [EnumMember(Value = "show")]
        Show,

        /// <summary>
        /// Episode.
        /// </summary>
        [EnumMember(Value = "episode")]
        Episode,

        /// <summary>
        /// Audiobook.
        /// </summary>
        [EnumMember(Value = "audiobook")]
        Audiobook
    }
}