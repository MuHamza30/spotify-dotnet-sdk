// <copyright file="ShowsController.cs" company="APIMatic">
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
    /// ShowsController.
    /// </summary>
    public class ShowsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowsController"/> class.
        /// </summary>
        internal ShowsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information for a single show identified by its.
        /// unique Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ShowObject response from the API call.</returns>
        public ApiResponse<Models.ShowObject> GetAShow(
                string id,
                string market = null)
            => CoreHelper.RunTask(GetAShowAsync(id, market));

        /// <summary>
        /// Get Spotify catalog information for a single show identified by its.
        /// unique Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ShowObject response from the API call.</returns>
        public async Task<ApiResponse<Models.ShowObject>> GetAShowAsync(
                string id,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ShowObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/shows/{id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))
                      .Query(_query => _query.Setup("market", market))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Spotify catalog information for several shows based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManySimplifiedShows response from the API call.</returns>
        public ApiResponse<Models.ManySimplifiedShows> GetMultipleShows(
                string ids,
                string market = null)
            => CoreHelper.RunTask(GetMultipleShowsAsync(ids, market));

        /// <summary>
        /// Get Spotify catalog information for several shows based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManySimplifiedShows response from the API call.</returns>
        public async Task<ApiResponse<Models.ManySimplifiedShows>> GetMultipleShowsAsync(
                string ids,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManySimplifiedShows>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/shows")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))
                      .Query(_query => _query.Setup("market", market))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Spotify catalog information about an show’s episodes. Optional parameters can be used to limit the number of episodes returned.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSimplifiedEpisodeObject response from the API call.</returns>
        public ApiResponse<Models.PagingSimplifiedEpisodeObject> GetAShowsEpisodes(
                string id,
                string market = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetAShowsEpisodesAsync(id, market, limit, offset));

        /// <summary>
        /// Get Spotify catalog information about an show’s episodes. Optional parameters can be used to limit the number of episodes returned.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSimplifiedEpisodeObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSimplifiedEpisodeObject>> GetAShowsEpisodesAsync(
                string id,
                string market = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSimplifiedEpisodeObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/shows/{id}/episodes")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a list of shows saved in the current Spotify user's library. Optional parameters can be used to limit the number of shows returned.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedShowObject response from the API call.</returns>
        public ApiResponse<Models.PagingSavedShowObject> GetUsersSavedShows(
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetUsersSavedShowsAsync(limit, offset));

        /// <summary>
        /// Get a list of shows saved in the current Spotify user's library. Optional parameters can be used to limit the number of shows returned.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedShowObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSavedShowObject>> GetUsersSavedShowsAsync(
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSavedShowObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/shows")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Save one or more shows to current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void SaveShowsUser(
                string ids,
                Models.MeShowsRequest body = null)
            => CoreHelper.RunVoidTask(SaveShowsUserAsync(ids, body));

        /// <summary>
        /// Save one or more shows to current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SaveShowsUserAsync(
                string ids,
                Models.MeShowsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/shows")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Query(_query => _query.Setup("ids", ids))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Delete one or more shows from current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void RemoveShowsUser(
                string ids,
                string market = null,
                Models.MeShowsRequest body = null)
            => CoreHelper.RunVoidTask(RemoveShowsUserAsync(ids, market, body));

        /// <summary>
        /// Delete one or more shows from current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task RemoveShowsUserAsync(
                string ids,
                string market = null,
                Models.MeShowsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/me/shows")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Query(_query => _query.Setup("ids", ids))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("market", market))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check if one or more shows is already saved in the current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckUsersSavedShows(
                string ids)
            => CoreHelper.RunTask(CheckUsersSavedShowsAsync(ids));

        /// <summary>
        /// Check if one or more shows is already saved in the current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckUsersSavedShowsAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/shows/contains")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}