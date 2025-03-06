// <copyright file="SearchController.cs" company="APIMatic">
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
    /// SearchController.
    /// </summary>
    public class SearchController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        internal SearchController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information about albums, artists, playlists, tracks, shows, episodes or audiobooks.
        /// that match a keyword string. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="q">Required parameter: Example: .</param>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="includeExternal">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.SearchItems response from the API call.</returns>
        public ApiResponse<Models.SearchItems> Search(
                string q,
                List<Models.ItemTypeEnum> type,
                string market = null,
                int? limit = 20,
                int? offset = 0,
                Models.IncludeExternalEnum? includeExternal = null)
            => CoreHelper.RunTask(SearchAsync(q, type, market, limit, offset, includeExternal));

        /// <summary>
        /// Get Spotify catalog information about albums, artists, playlists, tracks, shows, episodes or audiobooks.
        /// that match a keyword string. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="q">Required parameter: Example: .</param>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="includeExternal">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.SearchItems response from the API call.</returns>
        public async Task<ApiResponse<Models.SearchItems>> SearchAsync(
                string q,
                List<Models.ItemTypeEnum> type,
                string market = null,
                int? limit = 20,
                int? offset = 0,
                Models.IncludeExternalEnum? includeExternal = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchItems>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/search")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("q", q))
                      .Query(_query => _query.Setup("type", type?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))
                      .Query(_query => _query.Setup("include_external", (includeExternal.HasValue) ? ApiHelper.JsonSerialize(includeExternal.Value).Trim('\"') : null))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}