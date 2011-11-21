// ****************************************************************************
// ****************************************************************************
// <copyright file="Tuple.cs" company="Pedro Lamas">
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

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents a tuple with one item.
    /// </summary>
    /// <typeparam name="T1">The value of the first component of the tuple.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
        Justification = "I can't find a valid reason to move this in another file.")]
    public class Tuple<T1>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the first item.
        /// </summary>
        public T1 Item1 { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple&lt;T1&gt;"/> class.
        /// </summary>
        /// <param name="item1">The first item.</param>
        public Tuple(T1 item1)
        {
            Item1 = item1;
        }
    }

    /// <summary>
    /// Represents a tuple with two items.
    /// </summary>
    /// <typeparam name="T1">The value of the first component of the tuple.</typeparam>
    /// <typeparam name="T2">The value of the second component of the tuple.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
        Justification = "I can't find a valid reason to move this in another file.")]
    public class Tuple<T1, T2>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the first item.
        /// </summary>
        public T1 Item1 { get; private set; }

        /// <summary>
        /// Gets or Sets the second item.
        /// </summary>
        public T2 Item2 { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple&lt;T1,T2&gt;"/> class.
        /// </summary>
        /// <param name="item1">The first item.</param>
        /// <param name="item2">The second item.</param>
        public Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    /// <summary>
    /// Represents a tuple with three items.
    /// </summary>
    /// <typeparam name="T1">The value of the first component of the tuple.</typeparam>
    /// <typeparam name="T2">The value of the second component of the tuple.</typeparam>
    /// <typeparam name="T3">The value of the third component of the tuple.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
        Justification = "I can't find a valid reason to move this in another file.")]
    public class Tuple<T1, T2, T3>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the first item.
        /// </summary>
        public T1 Item1 { get; private set; }

        /// <summary>
        /// Gets or Sets the second item.
        /// </summary>
        public T2 Item2 { get; private set; }

        /// <summary>
        /// Gets or Sets the third item.
        /// </summary>
        public T3 Item3 { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple&lt;T1,T2,T3&gt;"/> class.
        /// </summary>
        /// <param name="item1">The first item.</param>
        /// <param name="item2">The second item.</param>
        /// <param name="item3">The third item.</param>
        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }

    /// <summary>
    /// Represents a tuple with four items.
    /// </summary>
    /// <typeparam name="T1">The value of the first component of the tuple.</typeparam>
    /// <typeparam name="T2">The value of the second component of the tuple.</typeparam>
    /// <typeparam name="T3">The value of the third component of the tuple.</typeparam>
    /// <typeparam name="T4">The value of the fourth component of the tuple.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
        Justification = "I can't find a valid reason to move this in another file.")]
    public class Tuple<T1, T2, T3, T4>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the first item.
        /// </summary>
        public T1 Item1 { get; private set; }

        /// <summary>
        /// Gets or Sets the second item.
        /// </summary>
        public T2 Item2 { get; private set; }

        /// <summary>
        /// Gets or Sets the third item.
        /// </summary>
        public T3 Item3 { get; private set; }

        /// <summary>
        /// Gets or Sets the fourth item.
        /// </summary>
        public T4 Item4 { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple&lt;T1,T2,T3,T4&gt;"/> class.
        /// </summary>
        /// <param name="item1">The first item.</param>
        /// <param name="item2">The second item.</param>
        /// <param name="item3">The third item.</param>
        /// <param name="item4">The fourth item.</param>
        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }
    }
}