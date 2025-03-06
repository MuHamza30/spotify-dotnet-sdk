// <copyright file="TracksController.cs" company="APIMatic">
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
    /// TracksController.
    /// </summary>
    public class TracksController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TracksController"/> class.
        /// </summary>
        internal TracksController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information for a single track identified by its.
        /// unique Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.TrackObject response from the API call.</returns>
        public ApiResponse<Models.TrackObject> GetTrack(
                string id,
                string market = null)
            => CoreHelper.RunTask(GetTrackAsync(id, market));

        /// <summary>
        /// Get Spotify catalog information for a single track identified by its.
        /// unique Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.TrackObject response from the API call.</returns>
        public async Task<ApiResponse<Models.TrackObject>> GetTrackAsync(
                string id,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.TrackObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/tracks/{id}")
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
        /// Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManyTracks response from the API call.</returns>
        public ApiResponse<Models.ManyTracks> GetSeveralTracks(
                string ids,
                string market = null)
            => CoreHelper.RunTask(GetSeveralTracksAsync(ids, market));

        /// <summary>
        /// Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyTracks response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyTracks>> GetSeveralTracksAsync(
                string ids,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyTracks>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/tracks")
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
        /// Get a list of the songs saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedTrackObject response from the API call.</returns>
        public ApiResponse<Models.PagingSavedTrackObject> GetUsersSavedTracks(
                string market = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetUsersSavedTracksAsync(market, limit, offset));

        /// <summary>
        /// Get a list of the songs saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedTrackObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSavedTrackObject>> GetUsersSavedTracksAsync(
                string market = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSavedTrackObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/tracks")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("offset", offset ?? 0))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Save one or more tracks to the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void SaveTracksUser(
                string ids,
                Models.MeTracksRequest body = null)
            => CoreHelper.RunVoidTask(SaveTracksUserAsync(ids, body));

        /// <summary>
        /// Save one or more tracks to the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SaveTracksUserAsync(
                string ids,
                Models.MeTracksRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/tracks")
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
        /// Remove one or more tracks from the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void RemoveTracksUser(
                string ids,
                Models.MeTracksRequest1 body = null)
            => CoreHelper.RunVoidTask(RemoveTracksUserAsync(ids, body));

        /// <summary>
        /// Remove one or more tracks from the current user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task RemoveTracksUserAsync(
                string ids,
                Models.MeTracksRequest1 body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/me/tracks")
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
        /// Check if one or more tracks is already saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckUsersSavedTracks(
                string ids)
            => CoreHelper.RunTask(CheckUsersSavedTracksAsync(ids));

        /// <summary>
        /// Check if one or more tracks is already saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckUsersSavedTracksAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/tracks/contains")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get audio features for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManyAudioFeatures response from the API call.</returns>
        public ApiResponse<Models.ManyAudioFeatures> GetSeveralAudioFeatures(
                string ids)
            => CoreHelper.RunTask(GetSeveralAudioFeaturesAsync(ids));

        /// <summary>
        /// Get audio features for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyAudioFeatures response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyAudioFeatures>> GetSeveralAudioFeaturesAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyAudioFeatures>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/audio-features")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get audio feature information for a single track identified by its unique.
        /// Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.AudioFeaturesObject response from the API call.</returns>
        public ApiResponse<Models.AudioFeaturesObject> GetAudioFeatures(
                string id)
            => CoreHelper.RunTask(GetAudioFeaturesAsync(id));

        /// <summary>
        /// Get audio feature information for a single track identified by its unique.
        /// Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.AudioFeaturesObject response from the API call.</returns>
        public async Task<ApiResponse<Models.AudioFeaturesObject>> GetAudioFeaturesAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AudioFeaturesObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/audio-features/{id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a low-level audio analysis for a track in the Spotify catalog. The audio analysis describes the track’s structure and musical content, including rhythm, pitch, and timbre.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.AudioAnalysisObject response from the API call.</returns>
        public ApiResponse<Models.AudioAnalysisObject> GetAudioAnalysis(
                string id)
            => CoreHelper.RunTask(GetAudioAnalysisAsync(id));

        /// <summary>
        /// Get a low-level audio analysis for a track in the Spotify catalog. The audio analysis describes the track’s structure and musical content, including rhythm, pitch, and timbre.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.AudioAnalysisObject response from the API call.</returns>
        public async Task<ApiResponse<Models.AudioAnalysisObject>> GetAudioAnalysisAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AudioAnalysisObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/audio-analysis/{id}")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Recommendations are generated based on the available information for a given seed entity and matched against similar artists and tracks. If there is sufficient information about the provided seeds, a list of tracks will be returned together with pool size details.
        /// For artists and tracks that are very new or obscure there might not be enough data to generate a list of tracks.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="seedArtists">Optional parameter: Example: .</param>
        /// <param name="seedGenres">Optional parameter: Example: .</param>
        /// <param name="seedTracks">Optional parameter: Example: .</param>
        /// <param name="minAcousticness">Optional parameter: Example: .</param>
        /// <param name="maxAcousticness">Optional parameter: Example: .</param>
        /// <param name="targetAcousticness">Optional parameter: Example: .</param>
        /// <param name="minDanceability">Optional parameter: Example: .</param>
        /// <param name="maxDanceability">Optional parameter: Example: .</param>
        /// <param name="targetDanceability">Optional parameter: Example: .</param>
        /// <param name="minDurationMs">Optional parameter: Example: .</param>
        /// <param name="maxDurationMs">Optional parameter: Example: .</param>
        /// <param name="targetDurationMs">Optional parameter: Example: .</param>
        /// <param name="minEnergy">Optional parameter: Example: .</param>
        /// <param name="maxEnergy">Optional parameter: Example: .</param>
        /// <param name="targetEnergy">Optional parameter: Example: .</param>
        /// <param name="minInstrumentalness">Optional parameter: Example: .</param>
        /// <param name="maxInstrumentalness">Optional parameter: Example: .</param>
        /// <param name="targetInstrumentalness">Optional parameter: Example: .</param>
        /// <param name="minKey">Optional parameter: Example: .</param>
        /// <param name="maxKey">Optional parameter: Example: .</param>
        /// <param name="targetKey">Optional parameter: Example: .</param>
        /// <param name="minLiveness">Optional parameter: Example: .</param>
        /// <param name="maxLiveness">Optional parameter: Example: .</param>
        /// <param name="targetLiveness">Optional parameter: Example: .</param>
        /// <param name="minLoudness">Optional parameter: Example: .</param>
        /// <param name="maxLoudness">Optional parameter: Example: .</param>
        /// <param name="targetLoudness">Optional parameter: Example: .</param>
        /// <param name="minMode">Optional parameter: Example: .</param>
        /// <param name="maxMode">Optional parameter: Example: .</param>
        /// <param name="targetMode">Optional parameter: Example: .</param>
        /// <param name="minPopularity">Optional parameter: Example: .</param>
        /// <param name="maxPopularity">Optional parameter: Example: .</param>
        /// <param name="targetPopularity">Optional parameter: Example: .</param>
        /// <param name="minSpeechiness">Optional parameter: Example: .</param>
        /// <param name="maxSpeechiness">Optional parameter: Example: .</param>
        /// <param name="targetSpeechiness">Optional parameter: Example: .</param>
        /// <param name="minTempo">Optional parameter: Example: .</param>
        /// <param name="maxTempo">Optional parameter: Example: .</param>
        /// <param name="targetTempo">Optional parameter: Example: .</param>
        /// <param name="minTimeSignature">Optional parameter: Example: .</param>
        /// <param name="maxTimeSignature">Optional parameter: Example: .</param>
        /// <param name="targetTimeSignature">Optional parameter: Example: .</param>
        /// <param name="minValence">Optional parameter: Example: .</param>
        /// <param name="maxValence">Optional parameter: Example: .</param>
        /// <param name="targetValence">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.RecommendationsObject response from the API call.</returns>
        public ApiResponse<Models.RecommendationsObject> GetRecommendations(
                int? limit = 20,
                string market = null,
                string seedArtists = null,
                string seedGenres = null,
                string seedTracks = null,
                double? minAcousticness = null,
                double? maxAcousticness = null,
                double? targetAcousticness = null,
                double? minDanceability = null,
                double? maxDanceability = null,
                double? targetDanceability = null,
                int? minDurationMs = null,
                int? maxDurationMs = null,
                int? targetDurationMs = null,
                double? minEnergy = null,
                double? maxEnergy = null,
                double? targetEnergy = null,
                double? minInstrumentalness = null,
                double? maxInstrumentalness = null,
                double? targetInstrumentalness = null,
                int? minKey = null,
                int? maxKey = null,
                int? targetKey = null,
                double? minLiveness = null,
                double? maxLiveness = null,
                double? targetLiveness = null,
                double? minLoudness = null,
                double? maxLoudness = null,
                double? targetLoudness = null,
                int? minMode = null,
                int? maxMode = null,
                int? targetMode = null,
                int? minPopularity = null,
                int? maxPopularity = null,
                int? targetPopularity = null,
                double? minSpeechiness = null,
                double? maxSpeechiness = null,
                double? targetSpeechiness = null,
                double? minTempo = null,
                double? maxTempo = null,
                double? targetTempo = null,
                int? minTimeSignature = null,
                int? maxTimeSignature = null,
                int? targetTimeSignature = null,
                double? minValence = null,
                double? maxValence = null,
                double? targetValence = null)
            => CoreHelper.RunTask(GetRecommendationsAsync(limit, market, seedArtists, seedGenres, seedTracks, minAcousticness, maxAcousticness, targetAcousticness, minDanceability, maxDanceability, targetDanceability, minDurationMs, maxDurationMs, targetDurationMs, minEnergy, maxEnergy, targetEnergy, minInstrumentalness, maxInstrumentalness, targetInstrumentalness, minKey, maxKey, targetKey, minLiveness, maxLiveness, targetLiveness, minLoudness, maxLoudness, targetLoudness, minMode, maxMode, targetMode, minPopularity, maxPopularity, targetPopularity, minSpeechiness, maxSpeechiness, targetSpeechiness, minTempo, maxTempo, targetTempo, minTimeSignature, maxTimeSignature, targetTimeSignature, minValence, maxValence, targetValence));

        /// <summary>
        /// Recommendations are generated based on the available information for a given seed entity and matched against similar artists and tracks. If there is sufficient information about the provided seeds, a list of tracks will be returned together with pool size details.
        /// For artists and tracks that are very new or obscure there might not be enough data to generate a list of tracks.
        /// </summary>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="seedArtists">Optional parameter: Example: .</param>
        /// <param name="seedGenres">Optional parameter: Example: .</param>
        /// <param name="seedTracks">Optional parameter: Example: .</param>
        /// <param name="minAcousticness">Optional parameter: Example: .</param>
        /// <param name="maxAcousticness">Optional parameter: Example: .</param>
        /// <param name="targetAcousticness">Optional parameter: Example: .</param>
        /// <param name="minDanceability">Optional parameter: Example: .</param>
        /// <param name="maxDanceability">Optional parameter: Example: .</param>
        /// <param name="targetDanceability">Optional parameter: Example: .</param>
        /// <param name="minDurationMs">Optional parameter: Example: .</param>
        /// <param name="maxDurationMs">Optional parameter: Example: .</param>
        /// <param name="targetDurationMs">Optional parameter: Example: .</param>
        /// <param name="minEnergy">Optional parameter: Example: .</param>
        /// <param name="maxEnergy">Optional parameter: Example: .</param>
        /// <param name="targetEnergy">Optional parameter: Example: .</param>
        /// <param name="minInstrumentalness">Optional parameter: Example: .</param>
        /// <param name="maxInstrumentalness">Optional parameter: Example: .</param>
        /// <param name="targetInstrumentalness">Optional parameter: Example: .</param>
        /// <param name="minKey">Optional parameter: Example: .</param>
        /// <param name="maxKey">Optional parameter: Example: .</param>
        /// <param name="targetKey">Optional parameter: Example: .</param>
        /// <param name="minLiveness">Optional parameter: Example: .</param>
        /// <param name="maxLiveness">Optional parameter: Example: .</param>
        /// <param name="targetLiveness">Optional parameter: Example: .</param>
        /// <param name="minLoudness">Optional parameter: Example: .</param>
        /// <param name="maxLoudness">Optional parameter: Example: .</param>
        /// <param name="targetLoudness">Optional parameter: Example: .</param>
        /// <param name="minMode">Optional parameter: Example: .</param>
        /// <param name="maxMode">Optional parameter: Example: .</param>
        /// <param name="targetMode">Optional parameter: Example: .</param>
        /// <param name="minPopularity">Optional parameter: Example: .</param>
        /// <param name="maxPopularity">Optional parameter: Example: .</param>
        /// <param name="targetPopularity">Optional parameter: Example: .</param>
        /// <param name="minSpeechiness">Optional parameter: Example: .</param>
        /// <param name="maxSpeechiness">Optional parameter: Example: .</param>
        /// <param name="targetSpeechiness">Optional parameter: Example: .</param>
        /// <param name="minTempo">Optional parameter: Example: .</param>
        /// <param name="maxTempo">Optional parameter: Example: .</param>
        /// <param name="targetTempo">Optional parameter: Example: .</param>
        /// <param name="minTimeSignature">Optional parameter: Example: .</param>
        /// <param name="maxTimeSignature">Optional parameter: Example: .</param>
        /// <param name="targetTimeSignature">Optional parameter: Example: .</param>
        /// <param name="minValence">Optional parameter: Example: .</param>
        /// <param name="maxValence">Optional parameter: Example: .</param>
        /// <param name="targetValence">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.RecommendationsObject response from the API call.</returns>
        public async Task<ApiResponse<Models.RecommendationsObject>> GetRecommendationsAsync(
                int? limit = 20,
                string market = null,
                string seedArtists = null,
                string seedGenres = null,
                string seedTracks = null,
                double? minAcousticness = null,
                double? maxAcousticness = null,
                double? targetAcousticness = null,
                double? minDanceability = null,
                double? maxDanceability = null,
                double? targetDanceability = null,
                int? minDurationMs = null,
                int? maxDurationMs = null,
                int? targetDurationMs = null,
                double? minEnergy = null,
                double? maxEnergy = null,
                double? targetEnergy = null,
                double? minInstrumentalness = null,
                double? maxInstrumentalness = null,
                double? targetInstrumentalness = null,
                int? minKey = null,
                int? maxKey = null,
                int? targetKey = null,
                double? minLiveness = null,
                double? maxLiveness = null,
                double? targetLiveness = null,
                double? minLoudness = null,
                double? maxLoudness = null,
                double? targetLoudness = null,
                int? minMode = null,
                int? maxMode = null,
                int? targetMode = null,
                int? minPopularity = null,
                int? maxPopularity = null,
                int? targetPopularity = null,
                double? minSpeechiness = null,
                double? maxSpeechiness = null,
                double? targetSpeechiness = null,
                double? minTempo = null,
                double? maxTempo = null,
                double? targetTempo = null,
                int? minTimeSignature = null,
                int? maxTimeSignature = null,
                int? targetTimeSignature = null,
                double? minValence = null,
                double? maxValence = null,
                double? targetValence = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RecommendationsObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/recommendations")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit ?? 20))
                      .Query(_query => _query.Setup("market", market))
                      .Query(_query => _query.Setup("seed_artists", seedArtists))
                      .Query(_query => _query.Setup("seed_genres", seedGenres))
                      .Query(_query => _query.Setup("seed_tracks", seedTracks))
                      .Query(_query => _query.Setup("min_acousticness", minAcousticness))
                      .Query(_query => _query.Setup("max_acousticness", maxAcousticness))
                      .Query(_query => _query.Setup("target_acousticness", targetAcousticness))
                      .Query(_query => _query.Setup("min_danceability", minDanceability))
                      .Query(_query => _query.Setup("max_danceability", maxDanceability))
                      .Query(_query => _query.Setup("target_danceability", targetDanceability))
                      .Query(_query => _query.Setup("min_duration_ms", minDurationMs))
                      .Query(_query => _query.Setup("max_duration_ms", maxDurationMs))
                      .Query(_query => _query.Setup("target_duration_ms", targetDurationMs))
                      .Query(_query => _query.Setup("min_energy", minEnergy))
                      .Query(_query => _query.Setup("max_energy", maxEnergy))
                      .Query(_query => _query.Setup("target_energy", targetEnergy))
                      .Query(_query => _query.Setup("min_instrumentalness", minInstrumentalness))
                      .Query(_query => _query.Setup("max_instrumentalness", maxInstrumentalness))
                      .Query(_query => _query.Setup("target_instrumentalness", targetInstrumentalness))
                      .Query(_query => _query.Setup("min_key", minKey))
                      .Query(_query => _query.Setup("max_key", maxKey))
                      .Query(_query => _query.Setup("target_key", targetKey))
                      .Query(_query => _query.Setup("min_liveness", minLiveness))
                      .Query(_query => _query.Setup("max_liveness", maxLiveness))
                      .Query(_query => _query.Setup("target_liveness", targetLiveness))
                      .Query(_query => _query.Setup("min_loudness", minLoudness))
                      .Query(_query => _query.Setup("max_loudness", maxLoudness))
                      .Query(_query => _query.Setup("target_loudness", targetLoudness))
                      .Query(_query => _query.Setup("min_mode", minMode))
                      .Query(_query => _query.Setup("max_mode", maxMode))
                      .Query(_query => _query.Setup("target_mode", targetMode))
                      .Query(_query => _query.Setup("min_popularity", minPopularity))
                      .Query(_query => _query.Setup("max_popularity", maxPopularity))
                      .Query(_query => _query.Setup("target_popularity", targetPopularity))
                      .Query(_query => _query.Setup("min_speechiness", minSpeechiness))
                      .Query(_query => _query.Setup("max_speechiness", maxSpeechiness))
                      .Query(_query => _query.Setup("target_speechiness", targetSpeechiness))
                      .Query(_query => _query.Setup("min_tempo", minTempo))
                      .Query(_query => _query.Setup("max_tempo", maxTempo))
                      .Query(_query => _query.Setup("target_tempo", targetTempo))
                      .Query(_query => _query.Setup("min_time_signature", minTimeSignature))
                      .Query(_query => _query.Setup("max_time_signature", maxTimeSignature))
                      .Query(_query => _query.Setup("target_time_signature", targetTimeSignature))
                      .Query(_query => _query.Setup("min_valence", minValence))
                      .Query(_query => _query.Setup("max_valence", maxValence))
                      .Query(_query => _query.Setup("target_valence", targetValence))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}