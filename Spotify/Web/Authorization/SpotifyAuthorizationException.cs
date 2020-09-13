﻿using System;
using System.Net;
using System.Net.Http;

namespace Spotify.Web.Authorization
{
    /// <summary>
    /// The exception that is thrown when an error occurrs during authorization with the Spotify Accounts service.
    /// </summary>
    internal class SpotifyAuthorizationException : HttpRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpotifyAuthorizationException"/> class
        /// with the specified <paramref name="error"/> and <paramref name="errorDescription"/>.
        /// </summary>
        /// <param name="error">A <see cref="String"/> representing the error.</param>
        /// <param name="errorDescription">
        /// A <see cref="String"/> representing a description of the error, or <see langword="null"/> if none was provided.
        /// </param>
        /// <param name="inner">The inner <see cref="Exception"/>.</param>
        /// <param name="statusCode">The <see cref="HttpStatusCode"/> of the response.</param>
        internal SpotifyAuthorizationException(String error, String? errorDescription, Exception? inner, HttpStatusCode? statusCode) :
            base($"{error}: {errorDescription ?? "No description"}", inner, statusCode)
        { }
    }
}