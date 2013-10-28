using System;
using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class ResolutionAwareUriConverterTests
    {
        private readonly Uri TestValue = new Uri("/test.png", UriKind.Relative);

        [UIDataTestMethod]
        [DataRow(100, "test.Screen-WVGA.png")]
        [DataRow(150, "test.Screen-720p.png")]
        [DataRow(160, "test.Screen-WXGA.png")]
        public void ConvertFromUriToResolutionAwareUri(int scaleFactor, string expectedValue)
        {
            var converter = new ResolutionAwareUriConverter(scaleFactor);

            var value = converter.Convert(TestValue, typeof(Uri), null, CultureInfo.CurrentCulture);

            Assert.IsNotNull(value);
            Assert.AreEqual(value.ToString(), expectedValue);
        }

        [UITestMethod]
        public void ConvertBackIsNotImplemented()
        {
            var converter = new ResolutionAwareUriConverter();

            Assert.ThrowsException<NotSupportedException>(() => converter.ConvertBack(null, typeof(Uri), null, CultureInfo.CurrentCulture));
        }
    }
}