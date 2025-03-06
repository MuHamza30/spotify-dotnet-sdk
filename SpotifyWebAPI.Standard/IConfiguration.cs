// <copyright file="IConfiguration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Net;
using SpotifyWebAPI.Standard.Authentication;
using SpotifyWebAPI.Standard.Models;

namespace SpotifyWebAPI.Standard
{
    /// <summary>
    /// IConfiguration.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets Current API environment.
        /// </summary>
        Environment Environment { get; }

        /// <summary>
        /// Gets the credentials to use with AuthorizationCodeAuth.
        /// </summary>
        IAuthorizationCodeAuth AuthorizationCodeAuth { get; }

        /// <summary>
        /// Gets the credentials model to use with AuthorizationCodeAuth.
        /// </summary>
        AuthorizationCodeAuthModel AuthorizationCodeAuthModel { get; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        string GetBaseUri(Server alias = Server.Default);
    }
}