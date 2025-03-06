// <copyright file="CursorObject.cs" company="APIMatic">
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
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard.Models
{
    /// <summary>
    /// CursorObject.
    /// </summary>
    public class CursorObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CursorObject"/> class.
        /// </summary>
        public CursorObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorObject"/> class.
        /// </summary>
        /// <param name="after">after.</param>
        /// <param name="before">before.</param>
        public CursorObject(
            string after = null,
            string before = null)
        {
            this.After = after;
            this.Before = before;
        }

        /// <summary>
        /// The cursor to use as key to find the next page of items.
        /// </summary>
        [JsonProperty("after", NullValueHandling = NullValueHandling.Ignore)]
        public string After { get; set; }

        /// <summary>
        /// The cursor to use as key to find the previous page of items.
        /// </summary>
        [JsonProperty("before", NullValueHandling = NullValueHandling.Ignore)]
        public string Before { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CursorObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CursorObject other &&
                (this.After == null && other.After == null ||
                 this.After?.Equals(other.After) == true) &&
                (this.Before == null && other.Before == null ||
                 this.Before?.Equals(other.Before) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"After = {this.After ?? "null"}");
            toStringOutput.Add($"Before = {this.Before ?? "null"}");
        }
    }
}