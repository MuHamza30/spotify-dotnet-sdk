// <copyright file="MarketsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Exceptions;
using SpotifyWebAPI.Standard.Http.Client;
using SpotifyWebAPI.Standard.Http.Response;
using SpotifyWebAPI.Standard.Utilities;
using System.Net.Http;

namespace SpotifyWebAPI.Standard.Controllers
{
    /// <summary>
    /// MarketsController.
    /// </summary>
    public class MarketsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketsController"/> class.
        /// </summary>
        internal MarketsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get the list of markets where Spotify is available.
        /// </summary>
        /// <returns>Returns the ApiResponse of Models.Markets response from the API call.</returns>
        public ApiResponse<Models.Markets> GetAvailableMarkets()
            => CoreHelper.RunTask(GetAvailableMarketsAsync());

        /// <summary>
        /// Get the list of markets where Spotify is available.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.Markets response from the API call.</returns>
        public async Task<ApiResponse<Models.Markets>> GetAvailableMarketsAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Markets>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/markets")
                  .WithAuth("oauth_2_0"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}