using System.Globalization;
using System.Windows;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class BooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void ConvertWithTrueReturnsVisible()
        {
            var converter = new BooleanToVisibilityConverter();

            var expected = Visibility.Visible;
            var actual = converter.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertWithFalseReturnsCollapsed()
        {
            var converter = new BooleanToVisibilityConverter();

            var expected = Visibility.Collapsed;
            var actual = converter.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackWithVisibleReturnsTrue()
        {
            var converter = new BooleanToVisibilityConverter();

            var expected = true;
            var actual = converter.ConvertBack(Visibility.Visible, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackWithCollapsedReturnsFalse()
        {
            var converter = new BooleanToVisibilityConverter();

            var expected = false;
            var actual = converter.ConvertBack(Visibility.Collapsed, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }
    }
}