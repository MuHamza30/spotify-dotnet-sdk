// <copyright file="ArtistsControllerTest.cs" company="APIMatic">
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
    /// ArtistsControllerTest.
    /// </summary>
    [TestFixture]
    public class ArtistsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ArtistsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ArtistsController;
        }

        /// <summary>
        /// Get Spotify catalog information for a single artist identified by their unique Spotify ID.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAnArtist()
        {
            // Parameters for the API call
            string id = "0TnOYISbd1XYRBk9myaseg";

            // Perform API call
            ApiResponse<Standard.Models.ArtistObject> result = null;
            try
            {
                result = await this.controller.GetAnArtistAsync(id);
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
        /// Get Spotify catalog information for several artists based on their Spotify IDs.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetMultipleArtists()
        {
            // Parameters for the API call
            string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";

            // Perform API call
            ApiResponse<Standard.Models.ManyArtists> result = null;
            try
            {
                result = await this.controller.GetMultipleArtistsAsync(ids);
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
        /// Get Spotify catalog information about an artist's albums.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAnArtistsAlbums()
        {
            // Parameters for the API call
            string id = "0TnOYISbd1XYRBk9myaseg";
            string includeGroups = "single,appears_on";
            string market = "ES";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingArtistDiscographyAlbumObject> result = null;
            try
            {
                result = await this.controller.GetAnArtistsAlbumsAsync(id, includeGroups, market, limit, offset);
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
        /// Get Spotify catalog information about an artist's top tracks by country.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAnArtistsTopTracks()
        {
            // Parameters for the API call
            string id = "0TnOYISbd1XYRBk9myaseg";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.ManyTracks> result = null;
            try
            {
                result = await this.controller.GetAnArtistsTopTracksAsync(id, market);
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
        /// Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the Spotify community's listening history.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAnArtistsRelatedArtists()
        {
            // Parameters for the API call
            string id = "0TnOYISbd1XYRBk9myaseg";

            // Perform API call
            ApiResponse<Standard.Models.ManyArtists> result = null;
            try
            {
                result = await this.controller.GetAnArtistsRelatedArtistsAsync(id);
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