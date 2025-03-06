// <copyright file="ControllerTestBase.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpotifyWebAPI.Standard;
using SpotifyWebAPI.Standard.Authentication;
using SpotifyWebAPI.Standard.Exceptions;
using SpotifyWebAPI.Standard.Http.Client;
using SpotifyWebAPI.Standard.Models;
using SpotifyWebAPI.Standard.Models.Containers;

namespace SpotifyWebAPI.Tests
{
    /// <summary>
    /// ControllerTestBase Class.
    /// </summary>
    [TestFixture]
    public class ControllerTestBase
    {
        /// <summary>
        /// Assert precision.
        /// </summary>
        protected const double AssertPrecision = 0.1;

        /// <summary>
        /// Gets HttpCallBackHandler.
        /// </summary>
        internal HttpCallback HttpCallBack { get; private set; } = new HttpCallback();

        /// <summary>
        /// Gets SpotifyWebAPIClient Client.
        /// </summary>
        protected SpotifyWebAPIClient Client { get; private set; }

        /// <summary>
        /// Set up the client.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            SpotifyWebAPIClient config = SpotifyWebAPIClient.CreateFromEnvironment();
            this.Client = config.ToBuilder()
                .HttpCallback(HttpCallBack)
                .Build();

            try
            {
                this.Client = this.Client.ToBuilder().AuthorizationCodeAuth(Client.AuthorizationCodeAuthModel.ToBuilder()
                    .OAuthToken(this.Client.AuthorizationCodeAuth.FetchToken("authorizationCode")).Build())
                    .Build();
            }
            catch (ApiException) 
            {
                // TODO Auto-generated catch block;
            }
        }
    }
}