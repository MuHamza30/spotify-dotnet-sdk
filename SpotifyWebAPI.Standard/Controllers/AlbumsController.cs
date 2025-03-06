// <copyright file="AlbumsController.cs" company="APIMatic">
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
    /// AlbumsController.
    /// </summary>
    public class AlbumsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        internal AlbumsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.AlbumObject response from the API call.</returns>
        public ApiResponse<Models.AlbumObject> GetAnAlbum(
                string id,
                string market = null)
            => CoreHelper.RunTask(GetAnAlbumAsync(id, market));

        /// <summary>
        /// Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.AlbumObject response from the API call.</returns>
        public async Task<ApiResponse<Models.AlbumObject>> GetAnAlbumAsync(
                string id,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AlbumObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/albums/{id}")
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
        /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManyAlbums response from the API call.</returns>
        public ApiResponse<Models.ManyAlbums> GetMultipleAlbums(
                string ids,
                string market = null)
            => CoreHelper.RunTask(GetMultipleAlbumsAsync(ids, market));

        /// <summary>
        /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyAlbums response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyAlbums>> GetMultipleAlbumsAsync(
                string ids,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyAlbums>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/albums")
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
        /// Get Spotify catalog information about an album’s tracks.
        /// Optional parameters can be used to limit the number of tracks returned.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSimplifiedTrackObject response from the API call.</returns>
        public ApiResponse<Models.PagingSimplifiedTrackObject> GetAnAlbumsTracks(
                string id,
                string market = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetAnAlbumsTracksAsync(id, market, limit, offset));

        /// <summary>
        /// Get Spotify catalog information about an album’s tracks.
        /// Optional parameters can be used to limit the number of tracks returned.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSimplifiedTrackObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSimplifiedTrackObject>> GetAnAlbumsTracksAsync(
                string id,
                string market = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSimplifiedTrackObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/albums/{id}/tracks")
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
        /// Get a list of the albums saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedAlbumObject response from the API call.</returns>
        public ApiResponse<Models.PagingSavedAlbumObject> GetUsersSavedAlbums(
                int? limit = 20,
                int? offset = 0,
                string market = null)
            => CoreHelper.RunTask(GetUsersSavedAlbumsAsync(limit, offset, market));

        /// <summary>
        /// Get a list of the albums saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedAlbumObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSavedAlbumObject>> GetUsersSavedAlbumsAsync(
                int? limit = 20,
                int? offset = 0,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSavedAlbumObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/albums")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))
                      .Query(_query => _query.Setup("market", market))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Save one or more albums to the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void SaveAlbumsUser(
                string ids,
                Models.MeAlbumsRequest body = null)
            => CoreHelper.RunVoidTask(SaveAlbumsUserAsync(ids, body));

        /// <summary>
        /// Save one or more albums to the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SaveAlbumsUserAsync(
                string ids,
                Models.MeAlbumsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/albums")
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
        /// Remove one or more albums from the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void RemoveAlbumsUser(
                string ids,
                Models.MeAlbumsRequest body = null)
            => CoreHelper.RunVoidTask(RemoveAlbumsUserAsync(ids, body));

        /// <summary>
        /// Remove one or more albums from the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task RemoveAlbumsUserAsync(
                string ids,
                Models.MeAlbumsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/me/albums")
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
        /// Check if one or more albums is already saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckUsersSavedAlbums(
                string ids)
            => CoreHelper.RunTask(CheckUsersSavedAlbumsAsync(ids));

        /// <summary>
        /// Check if one or more albums is already saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckUsersSavedAlbumsAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/albums/contains")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagedAlbums response from the API call.</returns>
        public ApiResponse<Models.PagedAlbums> GetNewReleases(
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetNewReleasesAsync(limit, offset));

        /// <summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagedAlbums response from the API call.</returns>
        public async Task<ApiResponse<Models.PagedAlbums>> GetNewReleasesAsync(
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagedAlbums>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/browse/new-releases")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}