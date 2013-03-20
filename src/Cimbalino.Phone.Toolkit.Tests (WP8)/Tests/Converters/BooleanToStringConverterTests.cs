using System.Globalization;
using Cimbalino.Phone.Toolkit.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Converters
{
    [TestClass]
    public class BooleanToStringConverterTests
    {
        private const string TrueValue = "TrueValue";
        private const string FalseValue = "FalseValue";

        [TestMethod]
        public void ConvertWithTrueReturnsTrueValue()
        {
            var converter = CreateBooleanToStringConverter();

            var expected = TrueValue;
            var actual = converter.Convert(true, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertWithFalseReturnsFalseValue()
        {
            var converter = CreateBooleanToStringConverter();

            var expected = FalseValue;
            var actual = converter.Convert(false, typeof(string), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackWithTrueValueReturnsTrue()
        {
            var converter = CreateBooleanToStringConverter();

            var expected = true;
            var actual = converter.ConvertBack(TrueValue, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ConvertBackWithFalseValueReturnsFalse()
        {
            var converter = CreateBooleanToStringConverter();

            var expected = false;
            var actual = converter.ConvertBack(FalseValue, typeof(bool), null, CultureInfo.CurrentCulture);

            Assert.AreEqual(actual, expected);
        }

        private static BooleanToStringConverter CreateBooleanToStringConverter()
        {
            return new BooleanToStringConverter()
            {
                TrueValue = TrueValue,
                FalseValue = FalseValue
            };
        }
    }
}