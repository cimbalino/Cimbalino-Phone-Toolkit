using System.Collections.Generic;
using System.Linq;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Extensions
{
    [TestClass]
    public class IntExtensionsTests
    {
        [TestMethod]
        public void TimesRepeatsAction()
        {
            var times = 5;
            var counter = 0;

            IntExtensions.Times(times, () =>
            {
                counter++;
            });

            Assert.AreEqual(times, counter);
        }

        [TestMethod]
        public void TimesRepeatsActionWithIndex()
        {
            var expected = new[] { 0, 1, 2, 3, 4 };
            var times = 5;
            var items = new List<int>();

            IntExtensions.Times(times, items.Add);

            Assert.AreEqual(times, items.Count);
            CollectionAssert.AreEqual(expected, items);
        }

        [TestMethod]
        public void RangeReturnsEnumerable()
        {
            var expected = new[] { 1, 2, 3, 4, 5 };
            var range = IntExtensions.Range(1, 5).ToArray();

            CollectionAssert.AreEqual(expected, range);
        }

        [TestMethod]
        public void ToReturnsEnumerable()
        {
            var expected = new[] { 2, 3, 4, 5 };
            var range = IntExtensions.To(2, 5).ToArray();

            CollectionAssert.AreEqual(expected, range);
        }
    }
}