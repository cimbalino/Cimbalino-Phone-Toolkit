// ****************************************************************************
// <copyright file="EnumExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>11-05-2012</date>
// <project>Cimbalino.Phone.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="Enum"/> instances.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieves an array of the names of the constants in a specified enumeration.
        /// </summary>
        /// <param name="enumObj">The enumeration.</param>
        /// <returns>A string array of the names of the constants in <paramref name="enumObj"/>.</returns>
        public static IEnumerable<string> GetNames(this Enum enumObj)
        {
            return enumObj.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.Name);
        }

        /// <summary>
        /// Retrieves an array of the values of the constants in a specified enumeration.
        /// </summary>
        /// <param name="enumObj">The enumeration.</param>
        /// <returns>An array that contains the values of the constants in <paramref name="enumObj"/>.</returns>
        public static IEnumerable<int> GetValues(this Enum enumObj)
        {
            return enumObj.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(x => Convert.ToInt32(x.GetValue(enumObj)));
        }
    }
}