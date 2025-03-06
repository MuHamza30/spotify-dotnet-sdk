// <copyright file="ErrorObject.cs" company="APIMatic">
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
    /// ErrorObject.
    /// </summary>
    public class ErrorObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorObject"/> class.
        /// </summary>
        public ErrorObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorObject"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="message">message.</param>
        public ErrorObject(
            int status,
            string message)
        {
            this.Status = status;
            this.Message = message;
        }

        /// <summary>
        /// The HTTP status code (also returned in the response header; see [Response Status Codes](/documentation/web-api/concepts/api-calls#response-status-codes) for more information).
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// A short description of the cause of the error.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ErrorObject : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ErrorObject other &&
                (this.Status.Equals(other.Status)) &&
                (this.Message == null && other.Message == null ||
                 this.Message?.Equals(other.Message) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Status = {this.Status}");
            toStringOutput.Add($"Message = {this.Message ?? "null"}");
        }
    }
}