using System.Globalization;
using System.Windows.Media;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class ColorToBrushConverterTests
    {
        [UITestMethod]
        public void ConvertWithColorReturnsBrush()
        {
            var converter = new ColorToBrushConverter();

            var expected = Colors.Blue;

            var actual = converter.Convert(Colors.Blue, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.IsInstanceOfType(actual, typeof(SolidColorBrush));
            Assert.AreEqual(((SolidColorBrush)actual).Color, expected);
        }

        [TestMethod]
        public void ConvertWithNullReturnsNull()
        {
            var converter = new ColorToBrushConverter();

            var value = converter.Convert(null, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.IsNull(value);
        }

        [UITestMethod]
        public void ConvertBackWithBrushReturnsColor()
        {
            var converter = new ColorToBrushConverter();

            var expected = Colors.Blue;
            var actual = converter.ConvertBack(new SolidColorBrush(Colors.Blue), typeof(string), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackWithNullReturnsNull()
        {
            var converter = new ColorToBrushConverter();

            var value = converter.ConvertBack(null, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.IsNull(value);
        }
    }
}