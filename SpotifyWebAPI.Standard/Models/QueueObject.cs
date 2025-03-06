// <copyright file="QueueObject.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Models.Containers;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// QueueObject.
    /// </summary>
    public class QueueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueObject"/> class.
        /// </summary>
        public QueueObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueObject"/> class.
        /// </summary>
        /// <param name="currentlyPlaying">currently_playing.</param>
        /// <param name="queue">queue.</param>
        public QueueObject(
            QueueObjectCurrentlyPlaying currentlyPlaying = null,
            List<QueueObjectQueue> queue = null)
        {
            this.CurrentlyPlaying = currentlyPlaying;
            this.Queue = queue;
        }

        /// <summary>
        /// The currently playing track or episode. Can be `null`.
        /// </summary>
        [JsonProperty("currently_playing", NullValueHandling = NullValueHandling.Ignore)]
        public QueueObjectCurrentlyPlaying CurrentlyPlaying { get; set; }

        /// <summary>
        /// The tracks or episodes in the queue. Can be empty.
        /// </summary>
        [JsonProperty("queue", NullValueHandling = NullValueHandling.Ignore)]
        public List<QueueObjectQueue> Queue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"QueueObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is QueueObject other &&
                (this.CurrentlyPlaying == null && other.CurrentlyPlaying == null ||
                 this.CurrentlyPlaying?.Equals(other.CurrentlyPlaying) == true) &&
                (this.Queue == null && other.Queue == null ||
                 this.Queue?.Equals(other.Queue) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CurrentlyPlaying = {(this.CurrentlyPlaying == null ? "null" : this.CurrentlyPlaying.ToString())}");
            toStringOutput.Add($"Queue = {(this.Queue == null ? "null" : this.Queue.ToString())}");
        }
    }
}