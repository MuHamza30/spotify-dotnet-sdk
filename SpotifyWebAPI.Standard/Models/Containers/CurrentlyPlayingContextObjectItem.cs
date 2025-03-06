// <copyright file="CurrentlyPlayingContextObjectItem.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using System;

namespace SpotifyWebAPI.Standard.Models.Containers
{
    /// <summary>
    /// This is a container class for one-of types.
    /// </summary>
    [JsonConverter(
        typeof(UnionTypeConverter<CurrentlyPlayingContextObjectItem>),
        new Type[] {
            typeof(TrackObjectCase),
            typeof(EpisodeObjectCase)
        },
        true
    )]
    public abstract class CurrentlyPlayingContextObjectItem
    {
        /// <summary>
        /// This is TrackObject case.
        /// </summary>
        /// <returns>
        /// The CurrentlyPlayingContextObjectItem instance, wrapping the provided TrackObject value.
        /// </returns>
        public static CurrentlyPlayingContextObjectItem FromTrackObject(TrackObject trackObject)
        {
            return new TrackObjectCase().Set(trackObject);
        }

        /// <summary>
        /// This is EpisodeObject case.
        /// </summary>
        /// <returns>
        /// The CurrentlyPlayingContextObjectItem instance, wrapping the provided EpisodeObject value.
        /// </returns>
        public static CurrentlyPlayingContextObjectItem FromEpisodeObject(EpisodeObject episodeObject)
        {
            return new EpisodeObjectCase().Set(episodeObject);
        }

        /// <summary>
        /// Method to match from the provided one-of cases. Here parameters
        /// represents the callback functions for one-of type cases. All
        /// callback functions must have the same return type T. This typeparam T
        /// represents the type that will be returned after applying the selected
        /// callback function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract T Match<T>(Func<TrackObject, T> trackObject, Func<EpisodeObject, T> episodeObject);

        [JsonConverter(typeof(UnionTypeCaseConverter<TrackObjectCase, TrackObject>))]
        private sealed class TrackObjectCase : CurrentlyPlayingContextObjectItem, ICaseValue<TrackObjectCase, TrackObject>
        {
            public TrackObject _value;

            public override T Match<T>(Func<TrackObject, T> trackObject, Func<EpisodeObject, T> episodeObject)
            {
                return trackObject(_value);
            }

            public TrackObjectCase Set(TrackObject value)
            {
                _value = value;
                return this;
            }

            public TrackObject Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }

            public override bool Equals(object obj)
            {
                if (!(obj is TrackObjectCase other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return _value == null ? other._value == null : _value?.Equals(other._value) == true;
            }
        }

        [JsonConverter(typeof(UnionTypeCaseConverter<EpisodeObjectCase, EpisodeObject>))]
        private sealed class EpisodeObjectCase : CurrentlyPlayingContextObjectItem, ICaseValue<EpisodeObjectCase, EpisodeObject>
        {
            public EpisodeObject _value;

            public override T Match<T>(Func<TrackObject, T> trackObject, Func<EpisodeObject, T> episodeObject)
            {
                return episodeObject(_value);
            }

            public EpisodeObjectCase Set(EpisodeObject value)
            {
                _value = value;
                return this;
            }

            public EpisodeObject Get()
            {
                return _value;
            }

            public override string ToString()
            {
                return _value?.ToString();
            }

            public override bool Equals(object obj)
            {
                if (!(obj is EpisodeObjectCase other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return _value == null ? other._value == null : _value?.Equals(other._value) == true;
            }
        }
    }
}