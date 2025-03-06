// <copyright file="CategoriesController.cs" company="APIMatic">
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
    /// CategoriesController.
    /// </summary>
    public class CategoriesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        internal CategoriesController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="locale">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagedCategories response from the API call.</returns>
        public ApiResponse<Models.PagedCategories> GetCategories(
                string locale = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetCategoriesAsync(locale, limit, offset));

        /// <summary>
        /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="locale">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagedCategories response from the API call.</returns>
        public async Task<ApiResponse<Models.PagedCategories>> GetCategoriesAsync(
                string locale = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagedCategories>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/browse/categories")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("locale", locale))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="categoryId">Required parameter: Example: .</param>
        /// <param name="locale">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.CategoryObject response from the API call.</returns>
        public ApiResponse<Models.CategoryObject> GetACategory(
                string categoryId,
                string locale = null)
            => CoreHelper.RunTask(GetACategoryAsync(categoryId, locale));

        /// <summary>
        /// Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="categoryId">Required parameter: Example: .</param>
        /// <param name="locale">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.CategoryObject response from the API call.</returns>
        public async Task<ApiResponse<Models.CategoryObject>> GetACategoryAsync(
                string categoryId,
                string locale = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CategoryObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/browse/categories/{category_id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("category_id", categoryId))
                      .Query(_query => _query.Setup("locale", locale))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}