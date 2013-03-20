using System;
using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class StringToLowercaseConverterTests
    {
        [TestMethod]
        public void ConvertWithStringReturnsLowercaseString()
        {
            var converter = new StringToLowercaseConverter();

            var expected = "my string!";
            var actual = converter.Convert("My String!", typeof(string), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackIsNotImplemented()
        {
            var converter = new StringToLowercaseConverter();

            Assert.ThrowsException<NotImplementedException>(() => converter.ConvertBack(null, typeof(string), null, CultureInfo.CurrentCulture));
        }
    }
}