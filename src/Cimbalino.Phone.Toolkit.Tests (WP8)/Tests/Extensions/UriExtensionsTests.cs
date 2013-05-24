using System;
using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Extensions
{
    [TestClass]
    public class UriExtensionsTests
    {
        [TestMethod]
        public void GetQueryStringFromRelativeUri()
        {
            var uri = new Uri("/test?a=b&c&d=e", UriKind.Relative);

            var query = UriExtensions.QueryString(uri);

            Assert.IsNotNull(query);
            Assert.AreEqual(query["a"], "b");
            Assert.IsNull(query["c"]);
            Assert.AreEqual(query["d"], "e");
        }

        [TestMethod]
        public void GetQueryStringFromAbsoluteUri()
        {
            var uri = new Uri("http://test.com/test?a=b&c&d=e", UriKind.Absolute);

            var query = UriExtensions.QueryString(uri);

            Assert.IsNotNull(query);
            Assert.AreEqual("b", query["a"]);
            Assert.IsNull(query["c"]);
            Assert.AreEqual("e", query["d"]);
        }
    }
}