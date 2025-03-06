// <copyright file="CopyrightObject.cs" company="APIMatic">
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
    /// CopyrightObject.
    /// </summary>
    public class CopyrightObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CopyrightObject"/> class.
        /// </summary>
        public CopyrightObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyrightObject"/> class.
        /// </summary>
        /// <param name="text">text.</param>
        /// <param name="type">type.</param>
        public CopyrightObject(
            string text = null,
            string type = null)
        {
            this.Text = text;
            this.Type = type;
        }

        /// <summary>
        /// The copyright text for this content.
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// The type of copyright: `C` = the copyright, `P` = the sound recording (performance) copyright.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CopyrightObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CopyrightObject other &&
                (this.Text == null && other.Text == null ||
                 this.Text?.Equals(other.Text) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Text = {this.Text ?? "null"}");
            toStringOutput.Add($"Type = {this.Type ?? "null"}");
        }
    }
}