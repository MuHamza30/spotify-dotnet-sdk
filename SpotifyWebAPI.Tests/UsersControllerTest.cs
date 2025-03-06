// <copyright file="UsersControllerTest.cs" company="APIMatic">
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
    /// UsersControllerTest.
    /// </summary>
    [TestFixture]
    public class UsersControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private UsersController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.UsersController;
        }

        /// <summary>
        /// Get detailed profile information about the current user (including the
        ///current user's username).
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetCurrentUsersProfile()
        {
            // Perform API call
            ApiResponse<Standard.Models.PrivateUserObject> result = null;
            try
            {
                result = await this.controller.GetCurrentUsersProfileAsync();
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
        /// Get public profile information about a Spotify user.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUsersProfile()
        {
            // Parameters for the API call
            string userId = "smedjan";

            // Perform API call
            ApiResponse<Standard.Models.PublicUserObject> result = null;
            try
            {
                result = await this.controller.GetUsersProfileAsync(userId);
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
        /// Add the current user as a follower of a playlist.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFollowPlaylist()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            Standard.Models.PlaylistsFollowersRequest body = null;

            // Perform API call
            try
            {
                await this.controller.FollowPlaylistAsync(playlistId, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Remove the current user as a follower of a playlist.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestUnfollowPlaylist()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";

            // Perform API call
            try
            {
                await this.controller.UnfollowPlaylistAsync(playlistId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Get the current user's followed artists.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetFollowed()
        {
            // Parameters for the API call
            Standard.Models.ItemType1Enum type = ApiHelper.JsonDeserialize<Standard.Models.ItemType1Enum>("\"artist\"");
            string after = "0I2XqVXqHScXjHhk6AYYRe";
            int? limit = 20;

            // Perform API call
            ApiResponse<Standard.Models.CursorPagedArtists> result = null;
            try
            {
                result = await this.controller.GetFollowedAsync(type, after, limit);
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
        /// Add the current user as a follower of one or more artists or other Spotify users.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFollowArtistsUsers()
        {
            // Parameters for the API call
            Standard.Models.ItemType2Enum type = ApiHelper.JsonDeserialize<Standard.Models.ItemType2Enum>("\"artist\"");
            string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
            Standard.Models.MeFollowingRequest body = null;

            // Perform API call
            try
            {
                await this.controller.FollowArtistsUsersAsync(type, ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Remove the current user as a follower of one or more artists or other Spotify users.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestUnfollowArtistsUsers()
        {
            // Parameters for the API call
            Standard.Models.ItemType3Enum type = ApiHelper.JsonDeserialize<Standard.Models.ItemType3Enum>("\"artist\"");
            string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";
            Standard.Models.MeFollowingRequest1 body = null;

            // Perform API call
            try
            {
                await this.controller.UnfollowArtistsUsersAsync(type, ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Check to see if the current user is following one or more artists or other Spotify users.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckCurrentUserFollows()
        {
            // Parameters for the API call
            Standard.Models.ItemType3Enum type = ApiHelper.JsonDeserialize<Standard.Models.ItemType3Enum>("\"artist\"");
            string ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";

            // Perform API call
            ApiResponse<List<bool>> result = null;
            try
            {
                result = await this.controller.CheckCurrentUserFollowsAsync(type, ids);
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
        /// Check to see if one or more Spotify users are following a specified playlist.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckIfUserFollowsPlaylist()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            string ids = "jmperezperez,thelinmichael,wizzler";

            // Perform API call
            ApiResponse<List<bool>> result = null;
            try
            {
                result = await this.controller.CheckIfUserFollowsPlaylistAsync(playlistId, ids);
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
        /// Get the current user's top artists based on calculated affinity.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUsersTopArtists()
        {
            // Parameters for the API call
            string timeRange = "medium_term";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingArtistObject> result = null;
            try
            {
                result = await this.controller.GetUsersTopArtistsAsync(timeRange, limit, offset);
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
        /// Get the current user's top tracks based on calculated affinity.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUsersTopTracks()
        {
            // Parameters for the API call
            string timeRange = "medium_term";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingTrackObject> result = null;
            try
            {
                result = await this.controller.GetUsersTopTracksAsync(timeRange, limit, offset);
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