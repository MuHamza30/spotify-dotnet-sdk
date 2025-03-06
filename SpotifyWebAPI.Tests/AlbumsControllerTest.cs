// <copyright file="AlbumsControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using APIMatic.Core.Utilities;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Controllers;
using SpotifyWebAPI.Standard.Exceptions;
using SpotifyWebAPI.Standard.Http.Client;
using SpotifyWebAPI.Standard.Http.Response;
using SpotifyWebAPI.Standard.Models.Containers;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Tests
{
    /// <summary>
    /// AlbumsControllerTest.
    /// </summary>
    [TestFixture]
    public class AlbumsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private AlbumsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.AlbumsController;
        }

        /// <summary>
        /// Get Spotify catalog information for a single album.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAnAlbum()
        {
            // Parameters for the API call
            string id = "4aawyAB9vmqN3uQ7FjRGTy";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.AlbumObject> result = null;
            try
            {
                result = await this.controller.GetAnAlbumAsync(id, market);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetMultipleAlbums()
        {
            // Parameters for the API call
            string ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.ManyAlbums> result = null;
            try
            {
                result = await this.controller.GetMultipleAlbumsAsync(ids, market);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Get Spotify catalog information about an album’s tracks.
        ///Optional parameters can be used to limit the number of tracks returned.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAnAlbumsTracks()
        {
            // Parameters for the API call
            string id = "4aawyAB9vmqN3uQ7FjRGTy";
            string market = "ES";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingSimplifiedTrackObject> result = null;
            try
            {
                result = await this.controller.GetAnAlbumsTracksAsync(id, market, limit, offset);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Get a list of the albums saved in the current Spotify user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUsersSavedAlbums()
        {
            // Parameters for the API call
            int? limit = 20;
            int? offset = 0;
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.PagingSavedAlbumObject> result = null;
            try
            {
                result = await this.controller.GetUsersSavedAlbumsAsync(limit, offset, market);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Save one or more albums to the current user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSaveAlbumsUser()
        {
            // Parameters for the API call
            string ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc";
            Standard.Models.MeAlbumsRequest body = null;

            // Perform API call
            try
            {
                await this.controller.SaveAlbumsUserAsync(ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Remove one or more albums from the current user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRemoveAlbumsUser()
        {
            // Parameters for the API call
            string ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc";
            Standard.Models.MeAlbumsRequest body = null;

            // Perform API call
            try
            {
                await this.controller.RemoveAlbumsUserAsync(ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Check if one or more albums is already saved in the current Spotify user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckUsersSavedAlbums()
        {
            // Parameters for the API call
            string ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc";

            // Perform API call
            ApiResponse<List<bool>> result = null;
            try
            {
                result = await this.controller.CheckUsersSavedAlbumsAsync(ids);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.AreEqual("[\r\n  false,\r\n  true\r\n]", TestHelper.ConvertStreamToString(HttpCallBack.Response.RawBody), "Response body should match exactly (string literal match)");
        }

        /// <summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetNewReleases()
        {
            // Parameters for the API call
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagedAlbums> result = null;
            try
            {
                result = await this.controller.GetNewReleasesAsync(limit, offset);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }
    }
}