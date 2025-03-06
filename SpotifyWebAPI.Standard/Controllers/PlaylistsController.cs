// <copyright file="PlaylistsController.cs" company="APIMatic">
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
    /// PlaylistsController.
    /// </summary>
    public class PlaylistsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsController"/> class.
        /// </summary>
        internal PlaylistsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="fields">Optional parameter: Example: .</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PlaylistObject response from the API call.</returns>
        public ApiResponse<Models.PlaylistObject> GetPlaylist(
                string playlistId,
                string market = null,
                string fields = null,
                string additionalTypes = null)
            => CoreHelper.RunTask(GetPlaylistAsync(playlistId, market, fields, additionalTypes));

        /// <summary>
        /// Get a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="fields">Optional parameter: Example: .</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PlaylistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PlaylistObject>> GetPlaylistAsync(
                string playlistId,
                string market = null,
                string fields = null,
                string additionalTypes = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PlaylistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/playlists/{playlist_id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("fields", fields))
                      .Query(_query => _query.Setup("additional_types", additionalTypes))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Change a playlist's name and public/private state. (The user must, of.
        /// course, own the playlist.).
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void ChangePlaylistDetails(
                string playlistId,
                Models.PlaylistsRequest body = null)
            => CoreHelper.RunVoidTask(ChangePlaylistDetailsAsync(playlistId, body));

        /// <summary>
        /// Change a playlist's name and public/private state. (The user must, of.
        /// course, own the playlist.).
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ChangePlaylistDetailsAsync(
                string playlistId,
                Models.PlaylistsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/playlists/{playlist_id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get full details of the items of a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="fields">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PagingPlaylistTrackObject response from the API call.</returns>
        public ApiResponse<Models.PagingPlaylistTrackObject> GetPlaylistsTracks(
                string playlistId,
                string market = null,
                string fields = null,
                int? limit = 20,
                int? offset = 0,
                string additionalTypes = null)
            => CoreHelper.RunTask(GetPlaylistsTracksAsync(playlistId, market, fields, limit, offset, additionalTypes));

        /// <summary>
        /// Get full details of the items of a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="fields">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingPlaylistTrackObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingPlaylistTrackObject>> GetPlaylistsTracksAsync(
                string playlistId,
                string market = null,
                string fields = null,
                int? limit = 20,
                int? offset = 0,
                string additionalTypes = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingPlaylistTrackObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/playlists/{playlist_id}/tracks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("fields", fields))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))
                      .Query(_query => _query.Setup("additional_types", additionalTypes))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Add one or more items to a user's playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="position">Optional parameter: Example: .</param>
        /// <param name="uris">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PlaylistSnapshotId response from the API call.</returns>
        public ApiResponse<Models.PlaylistSnapshotId> AddTracksToPlaylist(
                string playlistId,
                int? position = null,
                string uris = null,
                Models.PlaylistsTracksRequest body = null)
            => CoreHelper.RunTask(AddTracksToPlaylistAsync(playlistId, position, uris, body));

        /// <summary>
        /// Add one or more items to a user's playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="position">Optional parameter: Example: .</param>
        /// <param name="uris">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PlaylistSnapshotId response from the API call.</returns>
        public async Task<ApiResponse<Models.PlaylistSnapshotId>> AddTracksToPlaylistAsync(
                string playlistId,
                int? position = null,
                string uris = null,
                Models.PlaylistsTracksRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PlaylistSnapshotId>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/playlists/{playlist_id}/tracks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("position", position))
                      .Query(_query => _query.Setup("uris", uris))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Either reorder or replace items in a playlist depending on the request's parameters.
        /// To reorder items, include `range_start`, `insert_before`, `range_length` and `snapshot_id` in the request's body.
        /// To replace items, include `uris` as either a query parameter or in the request's body.
        /// Replacing items in a playlist will overwrite its existing items. This operation can be used for replacing or clearing items in a playlist.
        /// <br/>.
        /// **Note**: Replace and reorder are mutually exclusive operations which share the same endpoint, but have different parameters.
        /// These operations can't be applied together in a single request.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="uris">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PlaylistSnapshotId response from the API call.</returns>
        public ApiResponse<Models.PlaylistSnapshotId> ReorderOrReplacePlaylistsTracks(
                string playlistId,
                string uris = null,
                Models.PlaylistsTracksRequest1 body = null)
            => CoreHelper.RunTask(ReorderOrReplacePlaylistsTracksAsync(playlistId, uris, body));

        /// <summary>
        /// Either reorder or replace items in a playlist depending on the request's parameters.
        /// To reorder items, include `range_start`, `insert_before`, `range_length` and `snapshot_id` in the request's body.
        /// To replace items, include `uris` as either a query parameter or in the request's body.
        /// Replacing items in a playlist will overwrite its existing items. This operation can be used for replacing or clearing items in a playlist.
        /// <br/>.
        /// **Note**: Replace and reorder are mutually exclusive operations which share the same endpoint, but have different parameters.
        /// These operations can't be applied together in a single request.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="uris">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PlaylistSnapshotId response from the API call.</returns>
        public async Task<ApiResponse<Models.PlaylistSnapshotId>> ReorderOrReplacePlaylistsTracksAsync(
                string playlistId,
                string uris = null,
                Models.PlaylistsTracksRequest1 body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PlaylistSnapshotId>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/playlists/{playlist_id}/tracks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("uris", uris))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Remove one or more items from a user's playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PlaylistSnapshotId response from the API call.</returns>
        public ApiResponse<Models.PlaylistSnapshotId> RemoveTracksPlaylist(
                string playlistId,
                Models.PlaylistsTracksRequest2 body = null)
            => CoreHelper.RunTask(RemoveTracksPlaylistAsync(playlistId, body));

        /// <summary>
        /// Remove one or more items from a user's playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PlaylistSnapshotId response from the API call.</returns>
        public async Task<ApiResponse<Models.PlaylistSnapshotId>> RemoveTracksPlaylistAsync(
                string playlistId,
                Models.PlaylistsTracksRequest2 body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PlaylistSnapshotId>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/playlists/{playlist_id}/tracks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a list of the playlists owned or followed by the current Spotify.
        /// user.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingPlaylistObject response from the API call.</returns>
        public ApiResponse<Models.PagingPlaylistObject> GetAListOfCurrentUsersPlaylists(
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetAListOfCurrentUsersPlaylistsAsync(limit, offset));

        /// <summary>
        /// Get a list of the playlists owned or followed by the current Spotify.
        /// user.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingPlaylistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingPlaylistObject>> GetAListOfCurrentUsersPlaylistsAsync(
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingPlaylistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/playlists")
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
        /// Get a list of the playlists owned or followed by a Spotify user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingPlaylistObject response from the API call.</returns>
        public ApiResponse<Models.PagingPlaylistObject> GetListUsersPlaylists(
                string userId,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetListUsersPlaylistsAsync(userId, limit, offset));

        /// <summary>
        /// Get a list of the playlists owned or followed by a Spotify user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingPlaylistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingPlaylistObject>> GetListUsersPlaylistsAsync(
                string userId,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingPlaylistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/users/{user_id}/playlists")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create a playlist for a Spotify user. (The playlist will be empty until.
        /// you [add tracks](/documentation/web-api/reference/add-tracks-to-playlist).).
        /// Each user is generally limited to a maximum of 11000 playlists.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PlaylistObject response from the API call.</returns>
        public ApiResponse<Models.PlaylistObject> CreatePlaylist(
                string userId,
                Models.UsersPlaylistsRequest body = null)
            => CoreHelper.RunTask(CreatePlaylistAsync(userId, body));

        /// <summary>
        /// Create a playlist for a Spotify user. (The playlist will be empty until.
        /// you [add tracks](/documentation/web-api/reference/add-tracks-to-playlist).).
        /// Each user is generally limited to a maximum of 11000 playlists.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PlaylistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PlaylistObject>> CreatePlaylistAsync(
                string userId,
                Models.UsersPlaylistsRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PlaylistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/users/{user_id}/playlists")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("user_id", userId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab).
        /// </summary>
        /// <param name="locale">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingFeaturedPlaylistObject response from the API call.</returns>
        public ApiResponse<Models.PagingFeaturedPlaylistObject> GetFeaturedPlaylists(
                string locale = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetFeaturedPlaylistsAsync(locale, limit, offset));

        /// <summary>
        /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab).
        /// </summary>
        /// <param name="locale">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingFeaturedPlaylistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingFeaturedPlaylistObject>> GetFeaturedPlaylistsAsync(
                string locale = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingFeaturedPlaylistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/browse/featured-playlists")
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
        /// Get a list of Spotify playlists tagged with a particular category.
        /// </summary>
        /// <param name="categoryId">Required parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingFeaturedPlaylistObject response from the API call.</returns>
        public ApiResponse<Models.PagingFeaturedPlaylistObject> GetACategoriesPlaylists(
                string categoryId,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetACategoriesPlaylistsAsync(categoryId, limit, offset));

        /// <summary>
        /// Get a list of Spotify playlists tagged with a particular category.
        /// </summary>
        /// <param name="categoryId">Required parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingFeaturedPlaylistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingFeaturedPlaylistObject>> GetACategoriesPlaylistsAsync(
                string categoryId,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingFeaturedPlaylistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/browse/categories/{category_id}/playlists")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("category_id", categoryId))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the current image associated with a specific playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;Models.ImageObject&gt; response from the API call.</returns>
        public ApiResponse<List<Models.ImageObject>> GetPlaylistCover(
                string playlistId)
            => CoreHelper.RunTask(GetPlaylistCoverAsync(playlistId));

        /// <summary>
        /// Get the current image associated with a specific playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;Models.ImageObject&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<Models.ImageObject>>> GetPlaylistCoverAsync(
                string playlistId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.ImageObject>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/playlists/{playlist_id}/images")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("playlist_id", playlistId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Replace the image used to represent a specific playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        public void UploadCustomPlaylistCover(
                string playlistId,
                object body)
            => CoreHelper.RunVoidTask(UploadCustomPlaylistCoverAsync(playlistId, body));

        /// <summary>
        /// Replace the image used to represent a specific playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UploadCustomPlaylistCoverAsync(
                string playlistId,
                object body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/playlists/{playlist_id}/images")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("playlist_id", playlistId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}