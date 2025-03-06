// <copyright file="PlayerController.cs" company="APIMatic">
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
    /// PlayerController.
    /// </summary>
    public class PlayerController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerController"/> class.
        /// </summary>
        internal PlayerController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get information about the user’s current playback state, including track or episode, progress, and active device.
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.CurrentlyPlayingContextObject response from the API call.</returns>
        public ApiResponse<Models.CurrentlyPlayingContextObject> GetInformationAboutTheUsersCurrentPlayback(
                string market = null,
                string additionalTypes = null)
            => CoreHelper.RunTask(GetInformationAboutTheUsersCurrentPlaybackAsync(market, additionalTypes));

        /// <summary>
        /// Get information about the user’s current playback state, including track or episode, progress, and active device.
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.CurrentlyPlayingContextObject response from the API call.</returns>
        public async Task<ApiResponse<Models.CurrentlyPlayingContextObject>> GetInformationAboutTheUsersCurrentPlaybackAsync(
                string market = null,
                string additionalTypes = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CurrentlyPlayingContextObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/player")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("additional_types", additionalTypes))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Transfer playback to a new device and optionally begin playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        public void TransferAUsersPlayback(
                Models.MePlayerRequest body = null)
            => CoreHelper.RunVoidTask(TransferAUsersPlaybackAsync(body));

        /// <summary>
        /// Transfer playback to a new device and optionally begin playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task TransferAUsersPlaybackAsync(
                Models.MePlayerRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get information about a user’s available Spotify Connect devices. Some device models are not supported and will not be listed in the API response.
        /// </summary>
        /// <returns>Returns the ApiResponse of Models.ManyDevices response from the API call.</returns>
        public ApiResponse<Models.ManyDevices> GetAUsersAvailableDevices()
            => CoreHelper.RunTask(GetAUsersAvailableDevicesAsync());

        /// <summary>
        /// Get information about a user’s available Spotify Connect devices. Some device models are not supported and will not be listed in the API response.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyDevices response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyDevices>> GetAUsersAvailableDevicesAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyDevices>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/player/devices")
                  .WithAuth("oauth_2_0"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the object currently being played on the user's Spotify account.
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.CurrentlyPlayingObject response from the API call.</returns>
        public ApiResponse<Models.CurrentlyPlayingObject> GetTheUsersCurrentlyPlayingTrack(
                string market = null,
                string additionalTypes = null)
            => CoreHelper.RunTask(GetTheUsersCurrentlyPlayingTrackAsync(market, additionalTypes));

        /// <summary>
        /// Get the object currently being played on the user's Spotify account.
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="additionalTypes">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.CurrentlyPlayingObject response from the API call.</returns>
        public async Task<ApiResponse<Models.CurrentlyPlayingObject>> GetTheUsersCurrentlyPlayingTrackAsync(
                string market = null,
                string additionalTypes = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CurrentlyPlayingObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/player/currently-playing")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("additional_types", additionalTypes))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Start a new context or resume current playback on the user's active device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void StartAUsersPlayback(
                string deviceId = null,
                Models.MePlayerPlayRequest body = null)
            => CoreHelper.RunVoidTask(StartAUsersPlaybackAsync(deviceId, body));

        /// <summary>
        /// Start a new context or resume current playback on the user's active device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task StartAUsersPlaybackAsync(
                string deviceId = null,
                Models.MePlayerPlayRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player/play")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Pause playback on the user's account. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void PauseAUsersPlayback(
                string deviceId = null)
            => CoreHelper.RunVoidTask(PauseAUsersPlaybackAsync(deviceId));

        /// <summary>
        /// Pause playback on the user's account. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task PauseAUsersPlaybackAsync(
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player/pause")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Skips to next track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void SkipUsersPlaybackToNextTrack(
                string deviceId = null)
            => CoreHelper.RunVoidTask(SkipUsersPlaybackToNextTrackAsync(deviceId));

        /// <summary>
        /// Skips to next track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SkipUsersPlaybackToNextTrackAsync(
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/me/player/next")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Skips to previous track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void SkipUsersPlaybackToPreviousTrack(
                string deviceId = null)
            => CoreHelper.RunVoidTask(SkipUsersPlaybackToPreviousTrackAsync(deviceId));

        /// <summary>
        /// Skips to previous track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SkipUsersPlaybackToPreviousTrackAsync(
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/me/player/previous")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="positionMs">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void SeekToPositionInCurrentlyPlayingTrack(
                int positionMs,
                string deviceId = null)
            => CoreHelper.RunVoidTask(SeekToPositionInCurrentlyPlayingTrackAsync(positionMs, deviceId));

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="positionMs">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SeekToPositionInCurrentlyPlayingTrackAsync(
                int positionMs,
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player/seek")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("position_ms", positionMs))
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Set the repeat mode for the user's playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="state">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void SetRepeatModeOnUsersPlayback(
                string state,
                string deviceId = null)
            => CoreHelper.RunVoidTask(SetRepeatModeOnUsersPlaybackAsync(state, deviceId));

        /// <summary>
        /// Set the repeat mode for the user's playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="state">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SetRepeatModeOnUsersPlaybackAsync(
                string state,
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player/repeat")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("state", state))
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Set the volume for the user’s current playback device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="volumePercent">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void SetVolumeForUsersPlayback(
                int volumePercent,
                string deviceId = null)
            => CoreHelper.RunVoidTask(SetVolumeForUsersPlaybackAsync(volumePercent, deviceId));

        /// <summary>
        /// Set the volume for the user’s current playback device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="volumePercent">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SetVolumeForUsersPlaybackAsync(
                int volumePercent,
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player/volume")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("volume_percent", volumePercent))
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Toggle shuffle on or off for user’s playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="state">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void ToggleShuffleForUsersPlayback(
                bool state,
                string deviceId = null)
            => CoreHelper.RunVoidTask(ToggleShuffleForUsersPlaybackAsync(state, deviceId));

        /// <summary>
        /// Toggle shuffle on or off for user’s playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="state">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ToggleShuffleForUsersPlaybackAsync(
                bool state,
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/player/shuffle")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("state", state))
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get tracks from the current user's recently played tracks.
        /// _**Note**: Currently doesn't support podcast episodes._.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="after">Optional parameter: Example: .</param>
        /// <param name="before">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.CursorPagingPlayHistoryObject response from the API call.</returns>
        public ApiResponse<Models.CursorPagingPlayHistoryObject> GetRecentlyPlayed(
                int? limit = 20,
                long? after = null,
                int? before = null)
            => CoreHelper.RunTask(GetRecentlyPlayedAsync(limit, after, before));

        /// <summary>
        /// Get tracks from the current user's recently played tracks.
        /// _**Note**: Currently doesn't support podcast episodes._.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="after">Optional parameter: Example: .</param>
        /// <param name="before">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.CursorPagingPlayHistoryObject response from the API call.</returns>
        public async Task<ApiResponse<Models.CursorPagingPlayHistoryObject>> GetRecentlyPlayedAsync(
                int? limit = 20,
                long? after = null,
                int? before = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CursorPagingPlayHistoryObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/player/recently-played")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("after", after))
                      .Query(_query => _query.Setup("before", before))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the list of objects that make up the user's queue.
        /// </summary>
        /// <returns>Returns the ApiResponse of Models.QueueObject response from the API call.</returns>
        public ApiResponse<Models.QueueObject> GetQueue()
            => CoreHelper.RunTask(GetQueueAsync());

        /// <summary>
        /// Get the list of objects that make up the user's queue.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.QueueObject response from the API call.</returns>
        public async Task<ApiResponse<Models.QueueObject>> GetQueueAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.QueueObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/player/queue")
                  .WithAuth("oauth_2_0"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Add an item to the end of the user's current playback queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="uri">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        public void AddToQueue(
                string uri,
                string deviceId = null)
            => CoreHelper.RunVoidTask(AddToQueueAsync(uri, deviceId));

        /// <summary>
        /// Add an item to the end of the user's current playback queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        /// </summary>
        /// <param name="uri">Required parameter: Example: .</param>
        /// <param name="deviceId">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task AddToQueueAsync(
                string uri,
                string deviceId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/me/player/queue")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("uri", uri))
                      .Query(_query => _query.Setup("device_id", deviceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}