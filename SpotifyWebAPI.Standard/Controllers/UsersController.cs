// <copyright file="UsersController.cs" company="APIMatic">
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
    /// UsersController.
    /// </summary>
    public class UsersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        internal UsersController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get detailed profile information about the current user (including the.
        /// current user's username).
        /// </summary>
        /// <returns>Returns the ApiResponse of Models.PrivateUserObject response from the API call.</returns>
        public ApiResponse<Models.PrivateUserObject> GetCurrentUsersProfile()
            => CoreHelper.RunTask(GetCurrentUsersProfileAsync());

        /// <summary>
        /// Get detailed profile information about the current user (including the.
        /// current user's username).
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PrivateUserObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PrivateUserObject>> GetCurrentUsersProfileAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PrivateUserObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me")
                  .WithAuth("oauth_2_0"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get public profile information about a Spotify user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.PublicUserObject response from the API call.</returns>
        public ApiResponse<Models.PublicUserObject> GetUsersProfile(
                string userId)
            => CoreHelper.RunTask(GetUsersProfileAsync(userId));

        /// <summary>
        /// Get public profile information about a Spotify user.
        /// </summary>
        /// <param name="userId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PublicUserObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PublicUserObject>> GetUsersProfileAsync(
                string userId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PublicUserObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/users/{user_id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("user_id", userId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Add the current user as a follower of a playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void FollowPlaylist(
                string playlistId,
                Models.PlaylistsFollowersRequest body = null)
            => CoreHelper.RunVoidTask(FollowPlaylistAsync(playlistId, body));

        /// <summary>
        /// Add the current user as a follower of a playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task FollowPlaylistAsync(
                string playlistId,
                Models.PlaylistsFollowersRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/playlists/{playlist_id}/followers")
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
        /// Remove the current user as a follower of a playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        public void UnfollowPlaylist(
                string playlistId)
            => CoreHelper.RunVoidTask(UnfollowPlaylistAsync(playlistId));

        /// <summary>
        /// Remove the current user as a follower of a playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UnfollowPlaylistAsync(
                string playlistId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/playlists/{playlist_id}/followers")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("playlist_id", playlistId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the current user's followed artists.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="after">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <returns>Returns the ApiResponse of Models.CursorPagedArtists response from the API call.</returns>
        public ApiResponse<Models.CursorPagedArtists> GetFollowed(
                Models.ItemType1Enum type,
                string after = null,
                int? limit = 20)
            => CoreHelper.RunTask(GetFollowedAsync(type, after, limit));

        /// <summary>
        /// Get the current user's followed artists.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="after">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.CursorPagedArtists response from the API call.</returns>
        public async Task<ApiResponse<Models.CursorPagedArtists>> GetFollowedAsync(
                Models.ItemType1Enum type,
                string after = null,
                int? limit = 20,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CursorPagedArtists>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/following")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("type", ApiHelper.JsonSerialize(type).Trim('\"')))
                      .Query(_query => _query.Setup("after", after))
                      .Query(_query => _query.Setup("limit", limit ?? 20))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void FollowArtistsUsers(
                Models.ItemType2Enum type,
                string ids,
                Models.MeFollowingRequest body = null)
            => CoreHelper.RunVoidTask(FollowArtistsUsersAsync(type, ids, body));

        /// <summary>
        /// Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task FollowArtistsUsersAsync(
                Models.ItemType2Enum type,
                string ids,
                Models.MeFollowingRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/following")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Query(_query => _query.Setup("type", ApiHelper.JsonSerialize(type).Trim('\"')))
                      .Query(_query => _query.Setup("ids", ids))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void UnfollowArtistsUsers(
                Models.ItemType3Enum type,
                string ids,
                Models.MeFollowingRequest1 body = null)
            => CoreHelper.RunVoidTask(UnfollowArtistsUsersAsync(type, ids, body));

        /// <summary>
        /// Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UnfollowArtistsUsersAsync(
                Models.ItemType3Enum type,
                string ids,
                Models.MeFollowingRequest1 body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/me/following")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Query(_query => _query.Setup("type", ApiHelper.JsonSerialize(type).Trim('\"')))
                      .Query(_query => _query.Setup("ids", ids))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check to see if the current user is following one or more artists or other Spotify users.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckCurrentUserFollows(
                Models.ItemType3Enum type,
                string ids)
            => CoreHelper.RunTask(CheckCurrentUserFollowsAsync(type, ids));

        /// <summary>
        /// Check to see if the current user is following one or more artists or other Spotify users.
        /// </summary>
        /// <param name="type">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckCurrentUserFollowsAsync(
                Models.ItemType3Enum type,
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/following/contains")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("type", ApiHelper.JsonSerialize(type).Trim('\"')))
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckIfUserFollowsPlaylist(
                string playlistId,
                string ids)
            => CoreHelper.RunTask(CheckIfUserFollowsPlaylistAsync(playlistId, ids));

        /// <summary>
        /// Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="playlistId">Required parameter: Example: .</param>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckIfUserFollowsPlaylistAsync(
                string playlistId,
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/playlists/{playlist_id}/followers/contains")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("playlist_id", playlistId))
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the current user's top artists based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Optional parameter: Example: medium_term.</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingArtistObject response from the API call.</returns>
        public ApiResponse<Models.PagingArtistObject> GetUsersTopArtists(
                string timeRange = "medium_term",
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetUsersTopArtistsAsync(timeRange, limit, offset));

        /// <summary>
        /// Get the current user's top artists based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Optional parameter: Example: medium_term.</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingArtistObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingArtistObject>> GetUsersTopArtistsAsync(
                string timeRange = "medium_term",
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingArtistObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/top/artists")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("time_range", timeRange ?? "medium_term"))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the current user's top tracks based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Optional parameter: Example: medium_term.</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingTrackObject response from the API call.</returns>
        public ApiResponse<Models.PagingTrackObject> GetUsersTopTracks(
                string timeRange = "medium_term",
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetUsersTopTracksAsync(timeRange, limit, offset));

        /// <summary>
        /// Get the current user's top tracks based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Optional parameter: Example: medium_term.</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingTrackObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingTrackObject>> GetUsersTopTracksAsync(
                string timeRange = "medium_term",
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingTrackObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/top/tracks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("time_range", timeRange ?? "medium_term"))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}