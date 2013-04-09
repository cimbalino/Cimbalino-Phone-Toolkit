using System.Linq;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Extensions
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        [TestMethod]
        public void BatchReturnsProperBatches()
        {
            var expected = new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 },
                new[] { 5 }
            };

            var actual = IEnumerableExtensions.Batch(new[] { 1, 2, 3, 4, 5 }, 2);

            Assert.IsNotNull(actual);

            var actualArray = actual.Select(x => x.ToArray()).ToArray();

            Assert.AreEqual(expected.Length, actualArray.Length);
            CollectionAssert.AreEqual(expected, actualArray);
        }
    }
}