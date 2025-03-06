// <copyright file="ShowsControllerTest.cs" company="APIMatic">
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
    /// ShowsControllerTest.
    /// </summary>
    [TestFixture]
    public class ShowsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ShowsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ShowsController;
        }

        /// <summary>
        /// Get Spotify catalog information for a single show identified by its
        ///unique Spotify ID.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAShow()
        {
            // Parameters for the API call
            string id = "38bS44xjbVVZ3No3ByF1dJ";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.ShowObject> result = null;
            try
            {
                result = await this.controller.GetAShowAsync(id, market);
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
        /// Get Spotify catalog information for several shows based on their Spotify IDs.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetMultipleShows()
        {
            // Parameters for the API call
            string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.ManySimplifiedShows> result = null;
            try
            {
                result = await this.controller.GetMultipleShowsAsync(ids, market);
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
        /// Get Spotify catalog information about an show’s episodes. Optional parameters can be used to limit the number of episodes returned.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAShowsEpisodes()
        {
            // Parameters for the API call
            string id = "38bS44xjbVVZ3No3ByF1dJ";
            string market = "ES";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingSimplifiedEpisodeObject> result = null;
            try
            {
                result = await this.controller.GetAShowsEpisodesAsync(id, market, limit, offset);
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
        /// Get a list of shows saved in the current Spotify user's library. Optional parameters can be used to limit the number of shows returned.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUsersSavedShows()
        {
            // Parameters for the API call
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingSavedShowObject> result = null;
            try
            {
                result = await this.controller.GetUsersSavedShowsAsync(limit, offset);
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
        /// Save one or more shows to current Spotify user's library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSaveShowsUser()
        {
            // Parameters for the API call
            string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
            Standard.Models.MeShowsRequest body = null;

            // Perform API call
            try
            {
                await this.controller.SaveShowsUserAsync(ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Delete one or more shows from current Spotify user's library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRemoveShowsUser()
        {
            // Parameters for the API call
            string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
            string market = "ES";
            Standard.Models.MeShowsRequest body = null;

            // Perform API call
            try
            {
                await this.controller.RemoveShowsUserAsync(ids, market, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Check if one or more shows is already saved in the current Spotify user's library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckUsersSavedShows()
        {
            // Parameters for the API call
            string ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";

            // Perform API call
            ApiResponse<List<bool>> result = null;
            try
            {
                result = await this.controller.CheckUsersSavedShowsAsync(ids);
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
    }
}