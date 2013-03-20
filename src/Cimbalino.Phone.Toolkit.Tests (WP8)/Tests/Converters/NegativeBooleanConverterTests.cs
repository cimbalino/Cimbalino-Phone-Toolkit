using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class NegativeBooleanConverterTests
    {
        public void ConvertWithTrueReturnsFalse()
        {
            var converter = new NegativeBooleanConverter();

            var expected = false;
            var actual = converter.Convert(true, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        public void ConvertWithFalseReturnsTrue()
        {
            var converter = new NegativeBooleanConverter();

            var expected = true;
            var actual = converter.Convert(false, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        public void ConvertBackWithTrueReturnsFalse()
        {
            var converter = new NegativeBooleanConverter();

            var expected = false;
            var actual = converter.ConvertBack(true, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        public void ConvertBackWithFalseReturnsTrue()
        {
            var converter = new NegativeBooleanConverter();

            var expected = true;
            var actual = converter.ConvertBack(false, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }
    }
}