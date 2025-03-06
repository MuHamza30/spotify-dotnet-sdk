// <copyright file="PlayerControllerTest.cs" company="APIMatic">
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
    /// PlayerControllerTest.
    /// </summary>
    [TestFixture]
    public class PlayerControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PlayerController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PlayerController;
        }

        /// <summary>
        /// Get information about the user’s current playback state, including track or episode, progress, and active device.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetInformationAboutTheUsersCurrentPlayback()
        {
            // Parameters for the API call
            string market = "ES";
            string additionalTypes = null;

            // Perform API call
            ApiResponse<Standard.Models.CurrentlyPlayingContextObject> result = null;
            try
            {
                result = await this.controller.GetInformationAboutTheUsersCurrentPlaybackAsync(market, additionalTypes);
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
        /// Get information about the user’s current playback state, including track or episode, progress, and active device.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetInformationAboutTheUsersCurrentPlayback1()
        {
            // Parameters for the API call
            string market = "ES";
            string additionalTypes = null;

            // Perform API call
            ApiResponse<Standard.Models.CurrentlyPlayingContextObject> result = null;
            try
            {
                result = await this.controller.GetInformationAboutTheUsersCurrentPlaybackAsync(market, additionalTypes);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Transfer playback to a new device and optionally begin playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestTransferAUsersPlayback()
        {
            // Parameters for the API call
            Standard.Models.MePlayerRequest body = null;

            // Perform API call
            try
            {
                await this.controller.TransferAUsersPlaybackAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Get information about a user’s available Spotify Connect devices. Some device models are not supported and will not be listed in the API response.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAUsersAvailableDevices()
        {
            // Perform API call
            ApiResponse<Standard.Models.ManyDevices> result = null;
            try
            {
                result = await this.controller.GetAUsersAvailableDevicesAsync();
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
        /// Get the object currently being played on the user's Spotify account.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetTheUsersCurrentlyPlayingTrack()
        {
            // Parameters for the API call
            string market = "ES";
            string additionalTypes = null;

            // Perform API call
            ApiResponse<Standard.Models.CurrentlyPlayingObject> result = null;
            try
            {
                result = await this.controller.GetTheUsersCurrentlyPlayingTrackAsync(market, additionalTypes);
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
        /// Start a new context or resume current playback on the user's active device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestStartAUsersPlayback()
        {
            // Parameters for the API call
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";
            Standard.Models.MePlayerPlayRequest body = null;

            // Perform API call
            try
            {
                await this.controller.StartAUsersPlaybackAsync(deviceId, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Pause playback on the user's account. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestPauseAUsersPlayback()
        {
            // Parameters for the API call
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.PauseAUsersPlaybackAsync(deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Skips to next track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSkipUsersPlaybackToNextTrack()
        {
            // Parameters for the API call
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.SkipUsersPlaybackToNextTrackAsync(deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Skips to previous track in the user’s queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSkipUsersPlaybackToPreviousTrack()
        {
            // Parameters for the API call
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.SkipUsersPlaybackToPreviousTrackAsync(deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Seeks to the given position in the user’s currently playing track. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSeekToPositionInCurrentlyPlayingTrack()
        {
            // Parameters for the API call
            int positionMs = 25000;
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.SeekToPositionInCurrentlyPlayingTrackAsync(positionMs, deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Set the repeat mode for the user's playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSetRepeatModeOnUsersPlayback()
        {
            // Parameters for the API call
            string state = "context";
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.SetRepeatModeOnUsersPlaybackAsync(state, deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Set the volume for the user’s current playback device. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSetVolumeForUsersPlayback()
        {
            // Parameters for the API call
            int volumePercent = 50;
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.SetVolumeForUsersPlaybackAsync(volumePercent, deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Toggle shuffle on or off for user’s playback. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestToggleShuffleForUsersPlayback()
        {
            // Parameters for the API call
            bool state = true;
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.ToggleShuffleForUsersPlaybackAsync(state, deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }

        /// <summary>
        /// Get tracks from the current user's recently played tracks.
        ///_**Note**: Currently doesn't support podcast episodes._
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetRecentlyPlayed()
        {
            // Parameters for the API call
            int? limit = 20;
            long? after = 1484811043508;
            int? before = null;

            // Perform API call
            ApiResponse<Standard.Models.CursorPagingPlayHistoryObject> result = null;
            try
            {
                result = await this.controller.GetRecentlyPlayedAsync(limit, after, before);
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
        /// Get the list of objects that make up the user's queue.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetQueue()
        {
            // Perform API call
            ApiResponse<Standard.Models.QueueObject> result = null;
            try
            {
                result = await this.controller.GetQueueAsync();
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
        /// Add an item to the end of the user's current playback queue. This API only works for users who have Spotify Premium. The order of execution is not guaranteed when you use this API with other Player API endpoints.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestAddToQueue()
        {
            // Parameters for the API call
            string uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh";
            string deviceId = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

            // Perform API call
            try
            {
                await this.controller.AddToQueueAsync(uri, deviceId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }
    }
}