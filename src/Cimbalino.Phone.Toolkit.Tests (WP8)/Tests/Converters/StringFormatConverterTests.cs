using System;
using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class StringFormatConverterTests
    {
        [TestMethod]
        public void ConvertWithStringReturnsFormattedString()
        {
            var converter = new StringFormatConverter();

            var expected = "The result: My String!";
            var actual = converter.Convert("My String", typeof(string), "The result: {0}!", CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertWithDoubleReturnsFormattedString()
        {
            var converter = new StringFormatConverter();

            var expected = "The result: 12,345.68!";
            var actual = converter.Convert(12345.6789, typeof(string), "The result: {0:N2}!", CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertWithDateTimeReturnsFormattedString()
        {
            var converter = new StringFormatConverter();

            var expected = "The result: 1981-08-20T12:20:05.1230000!";
            var actual = converter.Convert(new DateTime(1981, 8, 20, 12, 20, 5, 123), typeof(string), "The result: {0:o}!", CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackIsNotImplemented()
        {
            var converter = new StringFormatConverter();

            Assert.ThrowsException<NotImplementedException>(() => converter.ConvertBack(null, typeof(string), null, CultureInfo.CurrentCulture));
        }
    }
}