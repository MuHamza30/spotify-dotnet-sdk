// <copyright file="AuthorObject.cs" company="APIMatic">
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
    /// AuthorObject.
    /// </summary>
    public class AuthorObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorObject"/> class.
        /// </summary>
        public AuthorObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorObject"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        public AuthorObject(
            string name = null)
        {
            this.Name = name;
        }

        /// <summary>
        /// The name of the author.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AuthorObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is AuthorObject other &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
        }
    }
}