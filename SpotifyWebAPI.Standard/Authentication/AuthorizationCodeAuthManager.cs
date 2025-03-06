// <copyright file="AuthorizationCodeAuthManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpotifyWebAPI.Standard.Controllers;
using SpotifyWebAPI.Standard.Http.Response;using SpotifyWebAPI.Standard.Utilities;
using SpotifyWebAPI.Standard.Exceptions;
using SpotifyWebAPI.Standard.Models;
using APIMatic.Core.Authentication;
using APIMatic.Core;
using System.Net.Http;

namespace SpotifyWebAPI.Standard.Authentication
{
    /// <summary>
    /// AuthorizationCodeAuthManager Class.
    /// </summary>
    public class AuthorizationCodeAuthManager : AuthManager, IAuthorizationCodeAuth
    {
        private readonly Func<GlobalConfiguration> getGlobalConfiguration;
        private readonly Func<OAuthAuthorizationController> getOAuthController;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationCodeAuthManager"/> class.
        /// </summary>
        /// <param name="authorizationCodeAuth"> OAuth 2 Authorization Code Model.</param>
        /// <param name="getGlobalConfiguration">A function that provides an instance of <see cref="GlobalConfiguration"/>.</param>
        /// <param name="getOAuthController">A function that provides an instance of <see cref="OAuthAuthorizationController"/>.</param>
        internal AuthorizationCodeAuthManager(AuthorizationCodeAuthModel authorizationCodeAuth,
            Func<GlobalConfiguration> getGlobalConfiguration, Func<OAuthAuthorizationController> getOAuthController)
        {
            OAuthClientId = authorizationCodeAuth?.OAuthClientId;
            OAuthClientSecret = authorizationCodeAuth?.OAuthClientSecret;
            OAuthRedirectUri = authorizationCodeAuth?.OAuthRedirectUri;
            OAuthToken = authorizationCodeAuth?.OAuthToken;
            OAuthScopes = authorizationCodeAuth?.OAuthScopes;
            this.getGlobalConfiguration = getGlobalConfiguration;
            this.getOAuthController = getOAuthController;
            Parameters(authParameter => authParameter
                .Header(headerParameter => headerParameter
                    .Setup("Authorization",
                        OAuthToken?.AccessToken == null ? null : $"Bearer {OAuthToken?.AccessToken}"
                    ).Required()));
        }

        /// <summary>
        /// Gets string value for oAuthClientId.
        /// </summary>
        public string OAuthClientId { get; }

        /// <summary>
        /// Gets string value for oAuthClientSecret.
        /// </summary>
        public string OAuthClientSecret { get; }

        /// <summary>
        /// Gets string value for oAuthRedirectUri.
        /// </summary>
        public string OAuthRedirectUri { get; }

        /// <summary>
        /// Gets Models.OAuthToken value for oAuthToken.
        /// </summary>
        public Models.OAuthToken OAuthToken { get; }

        /// <summary>
        /// Gets List of Models.OAuthScopeEnum value for oAuthScopes.
        /// </summary>
        public List<Models.OAuthScopeEnum> OAuthScopes { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="oAuthClientId"> The string value for credentials.</param>
        /// <param name="oAuthClientSecret"> The string value for credentials.</param>
        /// <param name="oAuthRedirectUri"> The string value for credentials.</param>
        /// <param name="oAuthToken"> The Models.OAuthToken value for credentials.</param>
        /// <param name="oAuthScopes"> The List of Models.OAuthScopeEnum value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string oAuthClientId, string oAuthClientSecret, string oAuthRedirectUri, Models.OAuthToken oAuthToken, List<Models.OAuthScopeEnum> oAuthScopes)
        {
            return oAuthClientId.Equals(this.OAuthClientId)
                    && oAuthClientSecret.Equals(this.OAuthClientSecret)
                    && oAuthRedirectUri.Equals(this.OAuthRedirectUri)
                    && ((oAuthToken == null && this.OAuthToken == null) || (oAuthToken != null && this.OAuthToken != null && oAuthToken.Equals(this.OAuthToken)))
                    && ((oAuthScopes == null && this.OAuthScopes == null) || (oAuthScopes != null && this.OAuthScopes != null && oAuthScopes.Equals(this.OAuthScopes)));
        }

        /// <summary>
        /// Fetch the OAuth token.
        /// </summary>
        /// <param name="authorizationCode">Authorization code returned by the OAuth provider.</param>
        /// <param name="additionalParameters">Dictionary of additional parameters.</param>
        /// <returns>Models.OAuthToken.</returns>
        public Models.OAuthToken FetchToken(string authorizationCode, Dictionary<string, object> additionalParameters = null)
            => ApiHelper.RunTask(FetchTokenAsync(authorizationCode, additionalParameters));

        /// <summary>
        /// Fetch the OAuth token asynchronously.
        /// </summary>
        /// <param name="authorizationCode">Authorization code returned by the OAuth provider.</param>
        /// <param name="additionalParameters">Dictionary of additional parameters.</param>
        /// <returns>Models.OAuthToken.</returns>
        public async Task<Models.OAuthToken> FetchTokenAsync(string authorizationCode, Dictionary<string, object> additionalParameters = null)
        {
            var token = await getOAuthController().RequestTokenAsync(BuildBasicAuthHeader(), authorizationCode, OAuthRedirectUri, additionalParameters).ConfigureAwait(false);

            if (token.Data.ExpiresIn != null && token.Data.ExpiresIn != 0)
            {
                token.Data.Expiry = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds + token.Data.ExpiresIn;
            }

            return token.Data;
        }
        
        /// <summary>
        /// Checks if token is expired.
        /// </summary>
        /// <returns> Returns true if token is expired.</returns>
        public bool IsTokenExpired()
        {
           if (this.OAuthToken == null)
           {
               throw new InvalidOperationException("OAuth token is missing.");
           }
        
           return this.OAuthToken.Expiry != null
               && this.OAuthToken.Expiry < (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        /// Refresh the OAuth token asynchronously.
        /// </summary>
        /// <param name="additionalParameters">Dictionary of additional parameters.</param>
        /// <returns>Models.OAuthToken.</returns>
        public async Task<Models.OAuthToken> RefreshTokenAsync(Dictionary<string, object> additionalParameters = null)
        {
            var token = await getOAuthController().RefreshTokenAsync(BuildBasicAuthHeader(), this.OAuthToken.RefreshToken, this.OAuthScopes.GetValues(), additionalParameters).ConfigureAwait(false);
            return token.Data;
        }

        /// <summary>
        /// Refresh the OAuth token.
        /// </summary>
        /// <param name="additionalParameters">Dictionary of additional parameters.</param>
        /// <returns>Models.OAuthToken.</returns>
        public Models.OAuthToken RefreshToken(Dictionary<string, object> additionalParameters = null)
            => ApiHelper.RunTask(RefreshTokenAsync(additionalParameters));
        

        /// <summary>
        /// Builds the authorization url for making authorized calls.
        /// </summary>
        /// <param name="state">State</param>        
        /// <param name="additionalParameters">Additional parameters to be appended</param>        
        public async Task<string> BuildAuthorizationUrl(string state = null, Dictionary<string, object> additionalParameters = null)
        {
            var request = await getGlobalConfiguration().GlobalRequestBuilder(Server.AuthServer)
              .Setup(HttpMethod.Get, "/authorize")
              .Parameters(parameter => parameter
                .Query(queryParameter => queryParameter.Setup("response_type", "code"))
                .Query(queryParameter => queryParameter.Setup("client_id", OAuthClientId))
                .Query(queryParameter => queryParameter.Setup("redirect_uri", OAuthRedirectUri))
                .Query(queryParameter => queryParameter.Setup("scope", OAuthScopes.GetValues()))
                .Query(queryParameter => queryParameter.Setup("state", state))
                .AdditionalQueries(additionalQuery => additionalQuery.Setup(additionalParameters)))
              .Build().ConfigureAwait(false);
            return request.QueryUrl;
        }

        /// <summary>
        /// Validates the authentication parameters for the HTTP Request.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (OAuthToken == null)
            {
                throw new ApiException(
                        "Client is not authorized.An OAuth token is needed to make API calls.");
            }

            if (IsTokenExpired())
            {
                throw new ApiException(
                        "OAuth token is expired. A valid token is needed to make API calls.");
            }
        }


        /// <summary>
        /// Build basic auth header.
        /// </summary>
        /// <returns> string. </returns>
        private string BuildBasicAuthHeader()
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(this.OAuthClientId + ':' + this.OAuthClientSecret);
            return "Basic " + Convert.ToBase64String(plainTextBytes);
        }
    }

    public sealed class AuthorizationCodeAuthModel
    {
        internal AuthorizationCodeAuthModel()
        {
        }

        internal string OAuthClientId { get; set; }

        internal string OAuthClientSecret { get; set; }

        internal string OAuthRedirectUri { get; set; }

        internal Models.OAuthToken OAuthToken { get; set; }

        internal List<Models.OAuthScopeEnum> OAuthScopes { get; set; }

        /// <summary>
        /// Creates an object of the AuthorizationCodeAuthModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(OAuthClientId, OAuthClientSecret, OAuthRedirectUri)
                .OAuthToken(OAuthToken)
                .OAuthScopes(OAuthScopes);
        }

        /// <summary>
        /// Builder class for AuthorizationCodeAuthModel.
        /// </summary>
        public class Builder
        {
            private string oAuthClientId;
            private string oAuthClientSecret;
            private string oAuthRedirectUri;
            private Models.OAuthToken oAuthToken;
            private List<Models.OAuthScopeEnum> oAuthScopes;

            public Builder(string oAuthClientId, string oAuthClientSecret, string oAuthRedirectUri)
            {
                this.oAuthClientId = oAuthClientId ?? throw new ArgumentNullException(nameof(oAuthClientId));
                this.oAuthClientSecret = oAuthClientSecret ?? throw new ArgumentNullException(nameof(oAuthClientSecret));
                this.oAuthRedirectUri = oAuthRedirectUri ?? throw new ArgumentNullException(nameof(oAuthRedirectUri));
            }

            /// <summary>
            /// Sets OAuthClientId.
            /// </summary>
            /// <param name="oAuthClientId">OAuthClientId.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthClientId(string oAuthClientId)
            {
                this.oAuthClientId = oAuthClientId ?? throw new ArgumentNullException(nameof(oAuthClientId));
                return this;
            }


            /// <summary>
            /// Sets OAuthClientSecret.
            /// </summary>
            /// <param name="oAuthClientSecret">OAuthClientSecret.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthClientSecret(string oAuthClientSecret)
            {
                this.oAuthClientSecret = oAuthClientSecret ?? throw new ArgumentNullException(nameof(oAuthClientSecret));
                return this;
            }


            /// <summary>
            /// Sets OAuthRedirectUri.
            /// </summary>
            /// <param name="oAuthRedirectUri">OAuthRedirectUri.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthRedirectUri(string oAuthRedirectUri)
            {
                this.oAuthRedirectUri = oAuthRedirectUri ?? throw new ArgumentNullException(nameof(oAuthRedirectUri));
                return this;
            }


            /// <summary>
            /// Sets OAuthToken.
            /// </summary>
            /// <param name="oAuthToken">OAuthToken.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthToken(Models.OAuthToken oAuthToken)
            {
                this.oAuthToken = oAuthToken;
                return this;
            }


            /// <summary>
            /// Sets OAuthScopes.
            /// </summary>
            /// <param name="oAuthScopes">OAuthScopes.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthScopes(List<Models.OAuthScopeEnum> oAuthScopes)
            {
                this.oAuthScopes = oAuthScopes;
                return this;
            }


            /// <summary>
            /// Creates an object of the AuthorizationCodeAuthModel using the values provided for the builder.
            /// </summary>
            /// <returns>AuthorizationCodeAuthModel.</returns>
            public AuthorizationCodeAuthModel Build()
            {
                return new AuthorizationCodeAuthModel()
                {
                    OAuthClientId = this.oAuthClientId,
                    OAuthClientSecret = this.oAuthClientSecret,
                    OAuthRedirectUri = this.oAuthRedirectUri,
                    OAuthToken = this.oAuthToken,
                    OAuthScopes = this.oAuthScopes
                };
            }
        }
    }
}