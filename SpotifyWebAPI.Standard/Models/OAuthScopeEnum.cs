// <copyright file="OAuthScopeEnum.cs" company="APIMatic">
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
using System.Reflection;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// OAuthScopeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OAuthScopeEnum
    {
        /// <summary>
        ///Communicate with the Spotify app on your device.
        /// AppRemoteControl.
        /// </summary>
        [EnumMember(Value = "app-remote-control")]
        AppRemoteControl,

        /// <summary>
        ///Access your private playlists.
        /// PlaylistReadPrivate.
        /// </summary>
        [EnumMember(Value = "playlist-read-private")]
        PlaylistReadPrivate,

        /// <summary>
        ///Access your collaborative playlists.
        /// PlaylistReadCollaborative.
        /// </summary>
        [EnumMember(Value = "playlist-read-collaborative")]
        PlaylistReadCollaborative,

        /// <summary>
        ///Manage your public playlists.
        /// PlaylistModifyPublic.
        /// </summary>
        [EnumMember(Value = "playlist-modify-public")]
        PlaylistModifyPublic,

        /// <summary>
        ///Manage your private playlists.
        /// PlaylistModifyPrivate.
        /// </summary>
        [EnumMember(Value = "playlist-modify-private")]
        PlaylistModifyPrivate,

        /// <summary>
        ///Access your saved content.
        /// UserLibraryRead.
        /// </summary>
        [EnumMember(Value = "user-library-read")]
        UserLibraryRead,

        /// <summary>
        ///Manage your saved content.
        /// UserLibraryModify.
        /// </summary>
        [EnumMember(Value = "user-library-modify")]
        UserLibraryModify,

        /// <summary>
        ///Access your subscription details.
        /// UserReadPrivate.
        /// </summary>
        [EnumMember(Value = "user-read-private")]
        UserReadPrivate,

        /// <summary>
        ///Get your real email address.
        /// UserReadEmail.
        /// </summary>
        [EnumMember(Value = "user-read-email")]
        UserReadEmail,

        /// <summary>
        ///Access your followers and who you are following.
        /// UserFollowRead.
        /// </summary>
        [EnumMember(Value = "user-follow-read")]
        UserFollowRead,

        /// <summary>
        ///Manage your saved content.
        /// UserFollowModify.
        /// </summary>
        [EnumMember(Value = "user-follow-modify")]
        UserFollowModify,

        /// <summary>
        ///Read your top artists and content.
        /// UserTopRead.
        /// </summary>
        [EnumMember(Value = "user-top-read")]
        UserTopRead,

        /// <summary>
        ///Read your position in content you have played.
        /// UserReadPlaybackPosition.
        /// </summary>
        [EnumMember(Value = "user-read-playback-position")]
        UserReadPlaybackPosition,

        /// <summary>
        ///Read your currently playing content and Spotify Connect devices information.
        /// UserReadPlaybackState.
        /// </summary>
        [EnumMember(Value = "user-read-playback-state")]
        UserReadPlaybackState,

        /// <summary>
        ///Access your recently played items.
        /// UserReadRecentlyPlayed.
        /// </summary>
        [EnumMember(Value = "user-read-recently-played")]
        UserReadRecentlyPlayed,

        /// <summary>
        ///Read your currently playing content.
        /// UserReadCurrentlyPlaying.
        /// </summary>
        [EnumMember(Value = "user-read-currently-playing")]
        UserReadCurrentlyPlaying,

        /// <summary>
        ///Control playback on your Spotify clients and Spotify Connect devices.
        /// UserModifyPlaybackState.
        /// </summary>
        [EnumMember(Value = "user-modify-playback-state")]
        UserModifyPlaybackState,

        /// <summary>
        ///Upload images to Spotify on your behalf.
        /// UgcImageUpload.
        /// </summary>
        [EnumMember(Value = "ugc-image-upload")]
        UgcImageUpload,

        /// <summary>
        ///Play content and control playback on your other devices.
        /// Streaming.
        /// </summary>
        [EnumMember(Value = "streaming")]
        Streaming
    }

    static class OAuthScopeEnumExtention
    {
        internal static string GetValues(this IEnumerable<OAuthScopeEnum> values)
        {
            return values != null ? string.Join(" ", values.Select(s => s.GetValue()).Where(s => !string.IsNullOrEmpty(s)).ToArray()) : null;
        }

        private static string GetValue(this Enum value)
        {
            return value.GetType()
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}