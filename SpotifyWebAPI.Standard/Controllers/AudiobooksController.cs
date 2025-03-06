// <copyright file="AudiobooksController.cs" company="APIMatic">
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
    /// AudiobooksController.
    /// </summary>
    public class AudiobooksController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudiobooksController"/> class.
        /// </summary>
        internal AudiobooksController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information for a single audiobook. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.AudiobookObject response from the API call.</returns>
        public ApiResponse<Models.AudiobookObject> GetAnAudiobook(
                string id,
                string market = null)
            => CoreHelper.RunTask(GetAnAudiobookAsync(id, market));

        /// <summary>
        /// Get Spotify catalog information for a single audiobook. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.AudiobookObject response from the API call.</returns>
        public async Task<ApiResponse<Models.AudiobookObject>> GetAnAudiobookAsync(
                string id,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AudiobookObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/audiobooks/{id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))
                      .Query(_query => _query.Setup("market", market))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("The request contains malformed data in path, query parameters, or body.\n", (_reason, _context) => new BadRequestException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("The requested resource cannot be found.\n", (_reason, _context) => new NotFoundException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get Spotify catalog information for several audiobooks identified by their Spotify IDs. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManyAudiobooks response from the API call.</returns>
        public ApiResponse<Models.ManyAudiobooks> GetMultipleAudiobooks(
                string ids,
                string market = null)
            => CoreHelper.RunTask(GetMultipleAudiobooksAsync(ids, market));

        /// <summary>
        /// Get Spotify catalog information for several audiobooks identified by their Spotify IDs. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyAudiobooks response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyAudiobooks>> GetMultipleAudiobooksAsync(
                string ids,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyAudiobooks>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/audiobooks")
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
        /// Get Spotify catalog information about an audiobook's chapters. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSimplifiedChapterObject response from the API call.</returns>
        public ApiResponse<Models.PagingSimplifiedChapterObject> GetAudiobookChapters(
                string id,
                string market = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetAudiobookChaptersAsync(id, market, limit, offset));

        /// <summary>
        /// Get Spotify catalog information about an audiobook's chapters. Audiobooks are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSimplifiedChapterObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSimplifiedChapterObject>> GetAudiobookChaptersAsync(
                string id,
                string market = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSimplifiedChapterObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/audiobooks/{id}/chapters")
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
        /// Get a list of the audiobooks saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedAudiobookObject response from the API call.</returns>
        public ApiResponse<Models.PagingSavedAudiobookObject> GetUsersSavedAudiobooks(
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetUsersSavedAudiobooksAsync(limit, offset));

        /// <summary>
        /// Get a list of the audiobooks saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedAudiobookObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSavedAudiobookObject>> GetUsersSavedAudiobooksAsync(
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSavedAudiobookObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/audiobooks")
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
        /// Save one or more audiobooks to the current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        public void SaveAudiobooksUser(
                string ids)
            => CoreHelper.RunVoidTask(SaveAudiobooksUserAsync(ids));

        /// <summary>
        /// Save one or more audiobooks to the current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SaveAudiobooksUserAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/audiobooks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Remove one or more audiobooks from the Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        public void RemoveAudiobooksUser(
                string ids)
            => CoreHelper.RunVoidTask(RemoveAudiobooksUserAsync(ids));

        /// <summary>
        /// Remove one or more audiobooks from the Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task RemoveAudiobooksUserAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/me/audiobooks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check if one or more audiobooks are already saved in the current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckUsersSavedAudiobooks(
                string ids)
            => CoreHelper.RunTask(CheckUsersSavedAudiobooksAsync(ids));

        /// <summary>
        /// Check if one or more audiobooks are already saved in the current Spotify user's library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckUsersSavedAudiobooksAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/audiobooks/contains")
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