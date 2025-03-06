// <copyright file="PlaylistsControllerTest.cs" company="APIMatic">
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
    /// PlaylistsControllerTest.
    /// </summary>
    [TestFixture]
    public class PlaylistsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PlaylistsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PlaylistsController;
        }

        /// <summary>
        /// Get a playlist owned by a Spotify user.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetPlaylist()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            string market = "ES";
            string fields = "items(added_by.id,track(name,href,album(name,href)))";
            string additionalTypes = null;

            // Perform API call
            ApiResponse<Standard.Models.PlaylistObject> result = null;
            try
            {
                result = await this.controller.GetPlaylistAsync(playlistId, market, fields, additionalTypes);
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
        /// Change a playlist's name and public/private state. (The user must, of
        ///course, own the playlist.)
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestChangePlaylistDetails()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            Standard.Models.PlaylistsRequest body = null;

            // Perform API call
            try
            {
                await this.controller.ChangePlaylistDetailsAsync(playlistId, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Get full details of the items of a playlist owned by a Spotify user.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetPlaylistsTracks()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            string market = "ES";
            string fields = "items(added_by.id,track(name,href,album(name,href)))";
            int? limit = 20;
            int? offset = 0;
            string additionalTypes = null;

            // Perform API call
            ApiResponse<Standard.Models.PagingPlaylistTrackObject> result = null;
            try
            {
                result = await this.controller.GetPlaylistsTracksAsync(playlistId, market, fields, limit, offset, additionalTypes);
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
        /// Add one or more items to a user's playlist.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestAddTracksToPlaylist()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            int? position = 0;
            string uris = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh,spotify:track:1301WleyT98MSxVHPZCA6M";
            Standard.Models.PlaylistsTracksRequest body = null;

            // Perform API call
            ApiResponse<Standard.Models.PlaylistSnapshotId> result = null;
            try
            {
                result = await this.controller.AddTracksToPlaylistAsync(playlistId, position, uris, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, HttpCallBack.Response.StatusCode, "Status should be 201");

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
        /// Either reorder or replace items in a playlist depending on the request's parameters.
        ///To reorder items, include `range_start`, `insert_before`, `range_length` and `snapshot_id` in the request's body.
        ///To replace items, include `uris` as either a query parameter or in the request's body.
        ///Replacing items in a playlist will overwrite its existing items. This operation can be used for replacing or clearing items in a playlist.
        ///<br/>
        ///**Note**: Replace and reorder are mutually exclusive operations which share the same endpoint, but have different parameters.
        ///These operations can't be applied together in a single request.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestReorderOrReplacePlaylistsTracks()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            string uris = null;
            Standard.Models.PlaylistsTracksRequest1 body = null;

            // Perform API call
            ApiResponse<Standard.Models.PlaylistSnapshotId> result = null;
            try
            {
                result = await this.controller.ReorderOrReplacePlaylistsTracksAsync(playlistId, uris, body);
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
        /// Remove one or more items from a user's playlist.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRemoveTracksPlaylist()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";
            Standard.Models.PlaylistsTracksRequest2 body = null;

            // Perform API call
            ApiResponse<Standard.Models.PlaylistSnapshotId> result = null;
            try
            {
                result = await this.controller.RemoveTracksPlaylistAsync(playlistId, body);
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
        /// Get a list of the playlists owned or followed by the current Spotify
        ///user.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAListOfCurrentUsersPlaylists()
        {
            // Parameters for the API call
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingPlaylistObject> result = null;
            try
            {
                result = await this.controller.GetAListOfCurrentUsersPlaylistsAsync(limit, offset);
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
        /// Get a list of the playlists owned or followed by a Spotify user.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetListUsersPlaylists()
        {
            // Parameters for the API call
            string userId = "smedjan";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingPlaylistObject> result = null;
            try
            {
                result = await this.controller.GetListUsersPlaylistsAsync(userId, limit, offset);
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
        /// Create a playlist for a Spotify user. (The playlist will be empty until
        ///you [add tracks](/documentation/web-api/reference/add-tracks-to-playlist).)
        ///Each user is generally limited to a maximum of 11000 playlists.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreatePlaylist()
        {
            // Parameters for the API call
            string userId = "smedjan";
            Standard.Models.UsersPlaylistsRequest body = null;

            // Perform API call
            ApiResponse<Standard.Models.PlaylistObject> result = null;
            try
            {
                result = await this.controller.CreatePlaylistAsync(userId, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(201, HttpCallBack.Response.StatusCode, "Status should be 201");

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
        /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player's 'Browse' tab).
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetFeaturedPlaylists()
        {
            // Parameters for the API call
            string locale = "sv_SE";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingFeaturedPlaylistObject> result = null;
            try
            {
                result = await this.controller.GetFeaturedPlaylistsAsync(locale, limit, offset);
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
        /// Get a list of Spotify playlists tagged with a particular category.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetACategoriesPlaylists()
        {
            // Parameters for the API call
            string categoryId = "dinner";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingFeaturedPlaylistObject> result = null;
            try
            {
                result = await this.controller.GetACategoriesPlaylistsAsync(categoryId, limit, offset);
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
        /// Get the current image associated with a specific playlist.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetPlaylistCover()
        {
            // Parameters for the API call
            string playlistId = "3cEYpjA9oz9GiPac4AsH4n";

            // Perform API call
            ApiResponse<List<Standard.Models.ImageObject>> result = null;
            try
            {
                result = await this.controller.GetPlaylistCoverAsync(playlistId);
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