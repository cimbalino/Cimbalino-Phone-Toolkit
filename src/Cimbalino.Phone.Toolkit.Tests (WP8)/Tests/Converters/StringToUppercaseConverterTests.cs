using System;
using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class StringToUppercaseConverterTests
    {
        [TestMethod]
        public void ConvertWithStringReturnsUppercaseString()
        {
            var converter = new StringToUppercaseConverter();

            var expected = "MY STRING!";
            var actual = converter.Convert("My String!", typeof(string), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackIsNotImplemented()
        {
            var converter = new StringToUppercaseConverter();

            Assert.ThrowsException<NotImplementedException>(() => converter.ConvertBack(null, typeof(string), null, CultureInfo.CurrentCulture));
        }
    }
}