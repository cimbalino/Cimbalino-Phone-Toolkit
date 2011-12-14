// ****************************************************************************
// <copyright file="ObjectExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

namespace Cimbalino.Phone.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="object"/> instances.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Searches for the public property with the specified name and gets its value.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The requested property value</returns>
        /// <typeparam name="TObject">The object type.</typeparam>
        public static TObject GetPropertyValue<TObject>(this object obj, string propertyName)
        {
            var t = obj.GetType();

            return (TObject)t.GetProperty(propertyName).GetValue(obj, null);
        }

        /// <summary>
        /// Searches for the public property with the specified name and sets its value.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The requested property value to set.</param>
        /// <typeparam name="TObject">The object type.</typeparam>
        public static void SetPropertyValue<TObject>(this object obj, string propertyName, TObject value)
        {
            var t = obj.GetType();

            t.GetProperty(propertyName).SetValue(obj, value, null);
        }

        /// <summary>
        /// Searches for the public method with the specified name and invokes it using the specified parameters.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="args">An argument list for the invoked method or constructor.</param>
        public static void InvokeMethod(this object obj, string methodName, params object[] args)
        {
            obj.GetType().GetMethod(methodName).Invoke(obj, args);
        }

        /// <summary>
        /// Searches for the public method with the specified name and invokes it using the specified parameters, returning the result.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="args">An argument list for the invoked method or constructor.</param>
        /// <returns>The value returned from invoking the method.</returns>
        /// <typeparam name="TObject">The object type.</typeparam>
        public static TObject InvokeMethod<TObject>(this object obj, string methodName, params object[] args)
        {
            return (TObject)obj.GetType().GetMethod(methodName).Invoke(obj, args);
        }
    }
}