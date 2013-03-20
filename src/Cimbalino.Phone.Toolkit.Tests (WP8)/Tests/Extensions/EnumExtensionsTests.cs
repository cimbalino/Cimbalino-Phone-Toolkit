using System.Linq;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Extensions
{
    public enum TestEnum
    {
        Name1 = 10,
        Name2 = 20
    }

    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void GetNamesReturnNames()
        {
            var expected = new[]
            {
                "Name1", "Name2"
            };

            var testEnum = TestEnum.Name1;

            var names = EnumExtensions.GetNames(testEnum);

            CollectionAssert.AreEqual(expected, names.ToArray());
        }

        [TestMethod]
        public void GetValuesReturnValues()
        {
            var expected = new[]
            {
                10, 20
            };

            var testEnum = TestEnum.Name1;

            var names = EnumExtensions.GetValues(testEnum);

            CollectionAssert.AreEqual(expected, names.ToArray());
        }
    }
}