// <copyright file="EpisodesController.cs" company="APIMatic">
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
    /// EpisodesController.
    /// </summary>
    public class EpisodesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodesController"/> class.
        /// </summary>
        internal EpisodesController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information for a single episode identified by its.
        /// unique Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.EpisodeObject response from the API call.</returns>
        public ApiResponse<Models.EpisodeObject> GetAnEpisode(
                string id,
                string market = null)
            => CoreHelper.RunTask(GetAnEpisodeAsync(id, market));

        /// <summary>
        /// Get Spotify catalog information for a single episode identified by its.
        /// unique Spotify ID.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.EpisodeObject response from the API call.</returns>
        public async Task<ApiResponse<Models.EpisodeObject>> GetAnEpisodeAsync(
                string id,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.EpisodeObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/episodes/{id}")
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
        /// Get Spotify catalog information for several episodes based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManyEpisodes response from the API call.</returns>
        public ApiResponse<Models.ManyEpisodes> GetMultipleEpisodes(
                string ids,
                string market = null)
            => CoreHelper.RunTask(GetMultipleEpisodesAsync(ids, market));

        /// <summary>
        /// Get Spotify catalog information for several episodes based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyEpisodes response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyEpisodes>> GetMultipleEpisodesAsync(
                string ids,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyEpisodes>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/episodes")
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
        /// Get a list of the episodes saved in the current Spotify user's library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedEpisodeObject response from the API call.</returns>
        public ApiResponse<Models.PagingSavedEpisodeObject> GetUsersSavedEpisodes(
                string market = null,
                int? limit = 20,
                int? offset = 0)
            => CoreHelper.RunTask(GetUsersSavedEpisodesAsync(market, limit, offset));

        /// <summary>
        /// Get a list of the episodes saved in the current Spotify user's library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: 20.</param>
        /// <param name="offset">Optional parameter: Example: 0.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.PagingSavedEpisodeObject response from the API call.</returns>
        public async Task<ApiResponse<Models.PagingSavedEpisodeObject>> GetUsersSavedEpisodesAsync(
                string market = null,
                int? limit = 20,
                int? offset = 0,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PagingSavedEpisodeObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/episodes")
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
        /// Save one or more episodes to the current user's library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void SaveEpisodesUser(
                string ids,
                Models.MeEpisodesRequest body = null)
            => CoreHelper.RunVoidTask(SaveEpisodesUserAsync(ids, body));

        /// <summary>
        /// Save one or more episodes to the current user's library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task SaveEpisodesUserAsync(
                string ids,
                Models.MeEpisodesRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/me/episodes")
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
        /// Remove one or more episodes from the current user's library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        public void RemoveEpisodesUser(
                string ids,
                Models.MeEpisodesRequest1 body = null)
            => CoreHelper.RunVoidTask(RemoveEpisodesUserAsync(ids, body));

        /// <summary>
        /// Remove one or more episodes from the current user's library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task RemoveEpisodesUserAsync(
                string ids,
                Models.MeEpisodesRequest1 body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/me/episodes")
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
        /// Check if one or more episodes is already saved in the current Spotify user's 'Your Episodes' library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public ApiResponse<List<bool>> CheckUsersSavedEpisodes(
                string ids)
            => CoreHelper.RunTask(CheckUsersSavedEpisodesAsync(ids));

        /// <summary>
        /// Check if one or more episodes is already saved in the current Spotify user's 'Your Episodes' library.<br/>.
        /// This API endpoint is in __beta__ and could change without warning. Please share any feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of List&lt;bool&gt; response from the API call.</returns>
        public async Task<ApiResponse<List<bool>>> CheckUsersSavedEpisodesAsync(
                string ids,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<bool>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/me/episodes/contains")
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