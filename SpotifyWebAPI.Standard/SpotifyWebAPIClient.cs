// <copyright file="SpotifyWebAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using APIMatic.Core;
using APIMatic.Core.Authentication;
using APIMatic.Core.Utilities.Logger.Configuration;
using SpotifyWebAPI.Standard.Authentication;
using SpotifyWebAPI.Standard.Controllers;
using SpotifyWebAPI.Standard.Http.Client;
using SpotifyWebAPI.Standard.Logging;
using SpotifyWebAPI.Standard.Utilities;

namespace SpotifyWebAPI.Standard
{
    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class SpotifyWebAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://api.spotify.com/v1" },
                    { Server.AuthServer, "https://accounts.spotify.com" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private SdkLoggingConfiguration sdkLoggingConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallback httpCallback;
        private readonly Lazy<AlbumsController> albums;
        private readonly Lazy<ArtistsController> artists;
        private readonly Lazy<AudiobooksController> audiobooks;
        private readonly Lazy<CategoriesController> categories;
        private readonly Lazy<ChaptersController> chapters;
        private readonly Lazy<EpisodesController> episodes;
        private readonly Lazy<GenresController> genres;
        private readonly Lazy<MarketsController> markets;
        private readonly Lazy<PlayerController> player;
        private readonly Lazy<PlaylistsController> playlists;
        private readonly Lazy<SearchController> search;
        private readonly Lazy<ShowsController> shows;
        private readonly Lazy<TracksController> tracks;
        private readonly Lazy<UsersController> users;
        private readonly Lazy<OAuthAuthorizationController> oAuthAuthorization;

        private SpotifyWebAPIClient(
            Environment environment,
            AuthorizationCodeAuthModel authorizationCodeAuthModel,
            HttpCallback httpCallback,
            IHttpClientConfiguration httpClientConfiguration,
            SdkLoggingConfiguration sdkLoggingConfiguration)
        {
            this.Environment = environment;
            this.httpCallback = httpCallback;
            this.HttpClientConfiguration = httpClientConfiguration;
            this.sdkLoggingConfiguration = sdkLoggingConfiguration;
            AuthorizationCodeAuthModel = authorizationCodeAuthModel;
            var authorizationCodeAuthManager = new AuthorizationCodeAuthManager(authorizationCodeAuthModel,
                () => globalConfiguration,
                () => OAuthAuthorizationController);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                    {"oauth_2_0", authorizationCodeAuthManager},
                })
                .ApiCallback(httpCallback)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .LoggingConfig(sdkLoggingConfiguration)
                .UserAgent(userAgent)
                .Build();

            AuthorizationCodeAuth = authorizationCodeAuthManager;

            this.albums = new Lazy<AlbumsController>(
                () => new AlbumsController(globalConfiguration));
            this.artists = new Lazy<ArtistsController>(
                () => new ArtistsController(globalConfiguration));
            this.audiobooks = new Lazy<AudiobooksController>(
                () => new AudiobooksController(globalConfiguration));
            this.categories = new Lazy<CategoriesController>(
                () => new CategoriesController(globalConfiguration));
            this.chapters = new Lazy<ChaptersController>(
                () => new ChaptersController(globalConfiguration));
            this.episodes = new Lazy<EpisodesController>(
                () => new EpisodesController(globalConfiguration));
            this.genres = new Lazy<GenresController>(
                () => new GenresController(globalConfiguration));
            this.markets = new Lazy<MarketsController>(
                () => new MarketsController(globalConfiguration));
            this.player = new Lazy<PlayerController>(
                () => new PlayerController(globalConfiguration));
            this.playlists = new Lazy<PlaylistsController>(
                () => new PlaylistsController(globalConfiguration));
            this.search = new Lazy<SearchController>(
                () => new SearchController(globalConfiguration));
            this.shows = new Lazy<ShowsController>(
                () => new ShowsController(globalConfiguration));
            this.tracks = new Lazy<TracksController>(
                () => new TracksController(globalConfiguration));
            this.users = new Lazy<UsersController>(
                () => new UsersController(globalConfiguration));
            this.oAuthAuthorization = new Lazy<OAuthAuthorizationController>(
                () => new OAuthAuthorizationController(globalConfiguration));
        }

        /// <summary>
        /// Gets AlbumsController controller.
        /// </summary>
        public AlbumsController AlbumsController => this.albums.Value;

        /// <summary>
        /// Gets ArtistsController controller.
        /// </summary>
        public ArtistsController ArtistsController => this.artists.Value;

        /// <summary>
        /// Gets AudiobooksController controller.
        /// </summary>
        public AudiobooksController AudiobooksController => this.audiobooks.Value;

        /// <summary>
        /// Gets CategoriesController controller.
        /// </summary>
        public CategoriesController CategoriesController => this.categories.Value;

        /// <summary>
        /// Gets ChaptersController controller.
        /// </summary>
        public ChaptersController ChaptersController => this.chapters.Value;

        /// <summary>
        /// Gets EpisodesController controller.
        /// </summary>
        public EpisodesController EpisodesController => this.episodes.Value;

        /// <summary>
        /// Gets GenresController controller.
        /// </summary>
        public GenresController GenresController => this.genres.Value;

        /// <summary>
        /// Gets MarketsController controller.
        /// </summary>
        public MarketsController MarketsController => this.markets.Value;

        /// <summary>
        /// Gets PlayerController controller.
        /// </summary>
        public PlayerController PlayerController => this.player.Value;

        /// <summary>
        /// Gets PlaylistsController controller.
        /// </summary>
        public PlaylistsController PlaylistsController => this.playlists.Value;

        /// <summary>
        /// Gets SearchController controller.
        /// </summary>
        public SearchController SearchController => this.search.Value;

        /// <summary>
        /// Gets ShowsController controller.
        /// </summary>
        public ShowsController ShowsController => this.shows.Value;

        /// <summary>
        /// Gets TracksController controller.
        /// </summary>
        public TracksController TracksController => this.tracks.Value;

        /// <summary>
        /// Gets UsersController controller.
        /// </summary>
        public UsersController UsersController => this.users.Value;

        /// <summary>
        /// Gets OAuthAuthorizationController controller.
        /// </summary>
        public OAuthAuthorizationController OAuthAuthorizationController => this.oAuthAuthorization.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        public HttpCallback HttpCallback => this.httpCallback;

        /// <summary>
        /// Gets the credentials to use with AuthorizationCodeAuth.
        /// </summary>
        public IAuthorizationCodeAuth AuthorizationCodeAuth { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with AuthorizationCodeAuth.
        /// </summary>
        public AuthorizationCodeAuthModel AuthorizationCodeAuthModel { get; private set; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the SpotifyWebAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallback(httpCallback)
                .LoggingConfig(sdkLoggingConfiguration)
                .HttpClientConfig(config => config.Build());

            if (AuthorizationCodeAuthModel != null)
            {
                builder.AuthorizationCodeAuth(AuthorizationCodeAuthModel.ToBuilder().Build());
            }

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> SpotifyWebAPIClient.</returns>
        internal static SpotifyWebAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_STANDARD_ENVIRONMENT");
            string oAuthClientId = System.Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_STANDARD_O_AUTH_CLIENT_ID");
            string oAuthClientSecret = System.Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_STANDARD_O_AUTH_CLIENT_SECRET");
            string oAuthRedirectUri = System.Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_STANDARD_O_AUTH_REDIRECT_URI");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (oAuthClientId != null && oAuthClientSecret != null && oAuthRedirectUri != null)
            {
                builder.AuthorizationCodeAuth(new AuthorizationCodeAuthModel
                .Builder(oAuthClientId, oAuthClientSecret, oAuthRedirectUri)
                .Build());
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = SpotifyWebAPI.Standard.Environment.Production;
            private AuthorizationCodeAuthModel authorizationCodeAuthModel = new AuthorizationCodeAuthModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallback httpCallback;
            private SdkLoggingConfiguration sdkLoggingConfiguration;

            /// <summary>
            /// Sets credentials for AuthorizationCodeAuth.
            /// </summary>
            /// <param name="oAuthClientId">OAuthClientId.</param>
            /// <param name="oAuthClientSecret">OAuthClientSecret.</param>
            /// <param name="oAuthRedirectUri">OAuthRedirectUri.</param>
            /// <returns>Builder.</returns>
            [Obsolete("This method is deprecated. Use AuthorizationCodeAuth(authorizationCodeAuthModel) instead.")]
            public Builder AuthorizationCodeAuth(string oAuthClientId, string oAuthClientSecret, string oAuthRedirectUri)
            {
                authorizationCodeAuthModel = authorizationCodeAuthModel.ToBuilder()
                    .OAuthClientId(oAuthClientId)
                    .OAuthClientSecret(oAuthClientSecret)
                    .OAuthRedirectUri(oAuthRedirectUri)
                    .Build();
                return this;
            }

            /// <summary>
            /// Sets OAuthToken.
            /// </summary>
            /// <param name="oAuthToken">OAuthToken.</param>
            /// <returns>Builder.</returns>
            [Obsolete("This method is deprecated. Use AuthorizationCodeAuth(authorizationCodeAuthModel) instead.")]
            public Builder OAuthToken(Models.OAuthToken oAuthToken)
            {
                authorizationCodeAuthModel = authorizationCodeAuthModel.ToBuilder()
                    .OAuthToken(oAuthToken)
                    .Build();
                return this;
            }

            /// <summary>
            /// Sets OAuthScopes.
            /// </summary>
            /// <param name="oAuthScopes">OAuthScopes.</param>
            /// <returns>Builder.</returns>
            [Obsolete("This method is deprecated. Use AuthorizationCodeAuth(authorizationCodeAuthModel) instead.")]
            public Builder OAuthScopes(List<Models.OAuthScopeEnum> oAuthScopes)
            {
                authorizationCodeAuthModel = authorizationCodeAuthModel.ToBuilder()
                    .OAuthScopes(oAuthScopes)
                    .Build();
                return this;
            }

            /// <summary>
            /// Sets credentials for AuthorizationCodeAuth.
            /// </summary>
            /// <param name="authorizationCodeAuthModel">AuthorizationCodeAuthModel.</param>
            /// <returns>Builder.</returns>
            public Builder AuthorizationCodeAuth(AuthorizationCodeAuthModel authorizationCodeAuthModel)
            {
                if (authorizationCodeAuthModel is null)
                {
                    throw new ArgumentNullException(nameof(authorizationCodeAuthModel));
                }

                this.authorizationCodeAuthModel = authorizationCodeAuthModel;
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

            /// <summary>
            /// Sets the default logging configuration, using the Console logger.
            /// </summary>
            /// <returns>Builder.</returns>
            public Builder LoggingConfig()
            {
                this.sdkLoggingConfiguration = SdkLoggingConfiguration.Console();
                return this;
            }

            /// <summary>
            /// Sets the logging configuration using the provided <paramref name="action"/>.
            /// </summary>
            /// <param name="action">The action to perform on the logging configuration builder.</param>
            /// <returns>Builder.</returns>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="action"/> is null.</exception>
            public Builder LoggingConfig(Action<LogBuilder> action)
            {
                if (action is null) throw new ArgumentNullException(nameof(action));
                var logBuilder =
                    LogBuilder.CreateFromConfig(sdkLoggingConfiguration ?? SdkLoggingConfiguration.Console());
                action(logBuilder);
                this.sdkLoggingConfiguration = logBuilder.Build();
                return this;
            }

            internal Builder LoggingConfig(SdkLoggingConfiguration configuration)
            {
                sdkLoggingConfiguration = configuration;
                return this;
            }



            /// <summary>
            /// Sets the HttpCallback for the Builder.
            /// </summary>
            /// <param name="httpCallback"> http callback. </param>
            /// <returns>Builder.</returns>
            public Builder HttpCallback(HttpCallback httpCallback)
            {
                this.httpCallback = httpCallback;
                return this;
            }

            /// <summary>
            /// Creates an object of the SpotifyWebAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>SpotifyWebAPIClient.</returns>
            public SpotifyWebAPIClient Build()
            {
                if (authorizationCodeAuthModel.OAuthClientId == null || authorizationCodeAuthModel.OAuthClientSecret == null || authorizationCodeAuthModel.OAuthRedirectUri == null)
                {
                    authorizationCodeAuthModel = null;
                }
                return new SpotifyWebAPIClient(
                    environment,
                    authorizationCodeAuthModel,
                    httpCallback,
                    httpClientConfig.Build(),
                    sdkLoggingConfiguration);
            }
        }
    }
}
