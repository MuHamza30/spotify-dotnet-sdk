// <copyright file="TracksControllerTest.cs" company="APIMatic">
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
    /// TracksControllerTest.
    /// </summary>
    [TestFixture]
    public class TracksControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private TracksController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.TracksController;
        }

        /// <summary>
        /// Get Spotify catalog information for a single track identified by its
        ///unique Spotify ID.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetTrack()
        {
            // Parameters for the API call
            string id = "11dFghVXANMlKmJXsNCbNl";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.TrackObject> result = null;
            try
            {
                result = await this.controller.GetTrackAsync(id, market);
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
        /// Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetSeveralTracks()
        {
            // Parameters for the API call
            string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
            string market = "ES";

            // Perform API call
            ApiResponse<Standard.Models.ManyTracks> result = null;
            try
            {
                result = await this.controller.GetSeveralTracksAsync(ids, market);
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
        /// Get a list of the songs saved in the current Spotify user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetUsersSavedTracks()
        {
            // Parameters for the API call
            string market = "ES";
            int? limit = 20;
            int? offset = 0;

            // Perform API call
            ApiResponse<Standard.Models.PagingSavedTrackObject> result = null;
            try
            {
                result = await this.controller.GetUsersSavedTracksAsync(market, limit, offset);
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
        /// Save one or more tracks to the current user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSaveTracksUser()
        {
            // Parameters for the API call
            string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
            Standard.Models.MeTracksRequest body = null;

            // Perform API call
            try
            {
                await this.controller.SaveTracksUserAsync(ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Remove one or more tracks from the current user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRemoveTracksUser()
        {
            // Parameters for the API call
            string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";
            Standard.Models.MeTracksRequest1 body = null;

            // Perform API call
            try
            {
                await this.controller.RemoveTracksUserAsync(ids, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Check if one or more tracks is already saved in the current Spotify user's 'Your Music' library.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCheckUsersSavedTracks()
        {
            // Parameters for the API call
            string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";

            // Perform API call
            ApiResponse<List<bool>> result = null;
            try
            {
                result = await this.controller.CheckUsersSavedTracksAsync(ids);
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
        /// Get audio features for multiple tracks based on their Spotify IDs.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetSeveralAudioFeatures()
        {
            // Parameters for the API call
            string ids = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";

            // Perform API call
            ApiResponse<Standard.Models.ManyAudioFeatures> result = null;
            try
            {
                result = await this.controller.GetSeveralAudioFeaturesAsync(ids);
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
        /// Get audio feature information for a single track identified by its unique
        ///Spotify ID.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAudioFeatures()
        {
            // Parameters for the API call
            string id = "11dFghVXANMlKmJXsNCbNl";

            // Perform API call
            ApiResponse<Standard.Models.AudioFeaturesObject> result = null;
            try
            {
                result = await this.controller.GetAudioFeaturesAsync(id);
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
        /// Get a low-level audio analysis for a track in the Spotify catalog. The audio analysis describes the track’s structure and musical content, including rhythm, pitch, and timbre.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetAudioAnalysis()
        {
            // Parameters for the API call
            string id = "11dFghVXANMlKmJXsNCbNl";

            // Perform API call
            ApiResponse<Standard.Models.AudioAnalysisObject> result = null;
            try
            {
                result = await this.controller.GetAudioAnalysisAsync(id);
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
        /// Recommendations are generated based on the available information for a given seed entity and matched against similar artists and tracks. If there is sufficient information about the provided seeds, a list of tracks will be returned together with pool size details.
        ///
        ///For artists and tracks that are very new or obscure there might not be enough data to generate a list of tracks.
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetRecommendations()
        {
            // Parameters for the API call
            int? limit = 20;
            string market = "ES";
            string seedArtists = "4NHQUGzhtTLFvgF5SZesLK";
            string seedGenres = "classical,country";
            string seedTracks = "0c6xIDDpzE81m2q797ordA";
            double? minAcousticness = null;
            double? maxAcousticness = null;
            double? targetAcousticness = null;
            double? minDanceability = null;
            double? maxDanceability = null;
            double? targetDanceability = null;
            int? minDurationMs = null;
            int? maxDurationMs = null;
            int? targetDurationMs = null;
            double? minEnergy = null;
            double? maxEnergy = null;
            double? targetEnergy = null;
            double? minInstrumentalness = null;
            double? maxInstrumentalness = null;
            double? targetInstrumentalness = null;
            int? minKey = null;
            int? maxKey = null;
            int? targetKey = null;
            double? minLiveness = null;
            double? maxLiveness = null;
            double? targetLiveness = null;
            double? minLoudness = null;
            double? maxLoudness = null;
            double? targetLoudness = null;
            int? minMode = null;
            int? maxMode = null;
            int? targetMode = null;
            int? minPopularity = null;
            int? maxPopularity = null;
            int? targetPopularity = null;
            double? minSpeechiness = null;
            double? maxSpeechiness = null;
            double? targetSpeechiness = null;
            double? minTempo = null;
            double? maxTempo = null;
            double? targetTempo = null;
            int? minTimeSignature = null;
            int? maxTimeSignature = null;
            int? targetTimeSignature = null;
            double? minValence = null;
            double? maxValence = null;
            double? targetValence = null;

            // Perform API call
            ApiResponse<Standard.Models.RecommendationsObject> result = null;
            try
            {
                result = await this.controller.GetRecommendationsAsync(limit, market, seedArtists, seedGenres, seedTracks, minAcousticness, maxAcousticness, targetAcousticness, minDanceability, maxDanceability, targetDanceability, minDurationMs, maxDurationMs, targetDurationMs, minEnergy, maxEnergy, targetEnergy, minInstrumentalness, maxInstrumentalness, targetInstrumentalness, minKey, maxKey, targetKey, minLiveness, maxLiveness, targetLiveness, minLoudness, maxLoudness, targetLoudness, minMode, maxMode, targetMode, minPopularity, maxPopularity, targetPopularity, minSpeechiness, maxSpeechiness, targetSpeechiness, minTempo, maxTempo, targetTempo, minTimeSignature, maxTimeSignature, targetTimeSignature, minValence, maxValence, targetValence);
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