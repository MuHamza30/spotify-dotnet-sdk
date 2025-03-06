// <copyright file="ChaptersController.cs" company="APIMatic">
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
    /// ChaptersController.
    /// </summary>
    public class ChaptersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChaptersController"/> class.
        /// </summary>
        internal ChaptersController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get Spotify catalog information for a single audiobook chapter. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ChapterObject response from the API call.</returns>
        public ApiResponse<Models.ChapterObject> GetAChapter(
                string id,
                string market = null)
            => CoreHelper.RunTask(GetAChapterAsync(id, market));

        /// <summary>
        /// Get Spotify catalog information for a single audiobook chapter. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="id">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ChapterObject response from the API call.</returns>
        public async Task<ApiResponse<Models.ChapterObject>> GetAChapterAsync(
                string id,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ChapterObject>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/chapters/{id}")
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
        /// Get Spotify catalog information for several audiobook chapters identified by their Spotify IDs. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <returns>Returns the ApiResponse of Models.ManyChapters response from the API call.</returns>
        public ApiResponse<Models.ManyChapters> GetSeveralChapters(
                string ids,
                string market = null)
            => CoreHelper.RunTask(GetSeveralChaptersAsync(ids, market));

        /// <summary>
        /// Get Spotify catalog information for several audiobook chapters identified by their Spotify IDs. Chapters are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
        /// </summary>
        /// <param name="ids">Required parameter: Example: .</param>
        /// <param name="market">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the ApiResponse of Models.ManyChapters response from the API call.</returns>
        public async Task<ApiResponse<Models.ManyChapters>> GetSeveralChaptersAsync(
                string ids,
                string market = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ManyChapters>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/chapters")
                  .WithAuth("oauth_2_0")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("ids", ids))
                      .Query(_query => _query.Setup("market", market))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Bad or expired token. This can happen if the user revoked a token or\nthe access token has expired. You should re-authenticate the user.\n", (_reason, _context) => new UnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Bad OAuth request (wrong consumer key, bad nonce, expired\ntimestamp...). Unfortunately, re-authenticating the user won't help here.\n", (_reason, _context) => new ForbiddenException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("The app has exceeded its rate limits.\n", (_reason, _context) => new TooManyRequestsException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}