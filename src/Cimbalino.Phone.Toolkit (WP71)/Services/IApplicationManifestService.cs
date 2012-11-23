// ****************************************************************************
// <copyright file="IApplicationManifestService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>07-02-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of reading from the application manifest.
    /// </summary>
    public interface IApplicationManifestService
    {
        /// <summary>
        /// Gets the application author's name.
        /// </summary>
        /// <value>The application author's name.</value>
        string Author { get; }

        /// <summary>
        /// Gets the application bit depth.
        /// </summary>
        /// <value>The application bit depth.</value>
        int BitsPerPixel { get; }

        /// <summary>
        /// Gets the description of the application.
        /// </summary>
        /// <value>The description of the application.</value>
        string Description { get; }

        /// <summary>
        /// Gets the application genre.
        /// </summary>
        /// <value>The application genre.</value>
        string Genre { get; }

        /// <summary>
        /// Gets a value indicating whether the application supports settings.
        /// </summary>
        /// <value>true if the application supports settings; otherwise, false.</value>
        bool HasSettings { get; }

        /// <summary>
        /// Gets a value indicating whether the application is a beta application.
        /// </summary>
        /// <value>true if the application is a beta application; otherwise, false.</value>
        bool IsBeta { get; }

        /// <summary>
        /// Gets the application product ID.
        /// </summary>
        /// <value>The application product ID.</value>
        Guid ProductID { get; }

        /// <summary>
        /// Gets the publisher of the application.
        /// </summary>
        /// <value>The publisher of the application.</value>
        string Publisher { get; }

        /// <summary>
        /// Gets the application runtime type.
        /// </summary>
        /// <value>The application runtime type.</value>
        string RuntimeType { get; }

        /// <summary>
        /// Gets a value indicating whether the application has a single instance host.
        /// </summary>
        /// <value>true if the application has a single instance host; otherwise, false.</value>
        bool SingleInstanceHost { get; }

        /// <summary>
        /// Gets the title of the application that appears in the application list or Games Hub.
        /// </summary>
        /// <value>The title of the application that appears in the application list or Games Hub.</value>
        string Title { get; }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>The application version.</value>
        Version Version { get; }

        /// <summary>
        /// Gets the value for the specified attribute over the App element in the application manifest.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The specified attribute value.</returns>
        string GetAttribute(string attributeName);
    }
}