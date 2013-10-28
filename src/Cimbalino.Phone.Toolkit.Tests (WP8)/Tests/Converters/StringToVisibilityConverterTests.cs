using System;
using System.Globalization;
using System.Windows;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class StringToVisibilityConverterTests
    {
        private const string EmptyTestString = "";
        private const string NonEmptyTestString = "My String!";

        [TestMethod]
        public void ConvertWithNullReturnsCollapsed()
        {
            var converter = new StringToVisibilityConverter();

            var value = converter.Convert(null, typeof(Visibility), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(value, Visibility.Collapsed);
        }

        [TestMethod]
        public void ConvertWithEmptyStringReturnsCollapsed()
        {
            var converter = new StringToVisibilityConverter();

            var value = converter.Convert(EmptyTestString, typeof(Visibility), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(value, Visibility.Collapsed);
        }

        [TestMethod]
        public void ConvertWithNonEmptyStringReturnsVisible()
        {
            var converter = new StringToVisibilityConverter();

            var value = converter.Convert(NonEmptyTestString, typeof(Visibility), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(value, Visibility.Visible);
        }

        [TestMethod]
        public void ConvertBackIsNotImplemented()
        {
            var converter = new StringToVisibilityConverter();

            Assert.ThrowsException<NotSupportedException>(() => converter.ConvertBack(Visibility.Visible, typeof(string), null, CultureInfo.CurrentCulture));
        }
    }
}