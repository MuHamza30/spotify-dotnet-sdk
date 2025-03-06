// <copyright file="BaseController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using APIMatic.Core;
using APIMatic.Core.Http.Configuration;
using APIMatic.Core.Response;
using SpotifyWebAPI.Standard.Exceptions;
using SpotifyWebAPI.Standard.Http.Client;
using SpotifyWebAPI.Standard.Http.Request;
using SpotifyWebAPI.Standard.Http.Response;
using SpotifyWebAPI.Standard.Utilities;
using System;

namespace SpotifyWebAPI.Standard.Controllers
{
    /// <summary>
    /// The base class for all controller classes.
    /// </summary>
    public class BaseController
    {
        private readonly GlobalConfiguration globalConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        internal BaseController(GlobalConfiguration config) => globalConfiguration = config;

        protected static ErrorCase<HttpRequest, HttpResponse, HttpContext, ApiException> CreateErrorCase(string reason, Func<string, HttpContext, ApiException> error, bool isErrorTemplate = false)
            => new ErrorCase<HttpRequest, HttpResponse, HttpContext, ApiException>(reason, error, isErrorTemplate);

        protected ApiCall<HttpRequest, HttpResponse, HttpContext, ApiException, ApiResponse<T>, T> CreateApiCall<T>(ArraySerialization arraySerialization = ArraySerialization.CSV)
            => new ApiCall<HttpRequest, HttpResponse, HttpContext, ApiException, ApiResponse<T>, T>(
                globalConfiguration,
                compatibilityFactory,
                serialization: arraySerialization,
                returnTypeCreator: (response, result) => new ApiResponse<T>(response.StatusCode, response.Headers, result)
            );

        private static readonly CompatibilityFactory compatibilityFactory = new CompatibilityFactory();
    }
}