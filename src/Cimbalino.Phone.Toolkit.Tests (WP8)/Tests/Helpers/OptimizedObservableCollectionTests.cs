using System.Collections.Generic;
using System.Collections.Specialized;
using Cimbalino.Phone.Toolkit.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Helpers
{
    [TestClass]
    public class OptimizedObservableCollectionTests
    {
        private static readonly object[] testObjects = { new object(), new object(), new object() };

        [TestMethod]
        public void SwitchToLessItems()
        {
            var mocker = new OptimizedObservableCollectionMocker(testObjects);

            mocker.OptimizedObservableCollection.SwitchTo(new[] { new object(), new object() });

            Assert.AreEqual(mocker.OptimizedObservableCollection.Count, 2);
            Assert.AreEqual(0, mocker.ItemsAddedCount);
            Assert.AreEqual(1, mocker.ItemsRemovedCount);
            Assert.AreEqual(2, mocker.ItemsReplacedCount);
            Assert.AreEqual(0, mocker.ItemsResetCount);
        }

        [TestMethod]
        public void SwitchToMoreItems()
        {
            var mocker = new OptimizedObservableCollectionMocker(testObjects);

            mocker.OptimizedObservableCollection.SwitchTo(new[] { new object(), new object(), new object(), new object() });

            Assert.AreEqual(mocker.OptimizedObservableCollection.Count, 4);
            Assert.AreEqual(1, mocker.ItemsAddedCount);
            Assert.AreEqual(0, mocker.ItemsRemovedCount);
            Assert.AreEqual(3, mocker.ItemsReplacedCount);
            Assert.AreEqual(0, mocker.ItemsResetCount);
        }

        [TestMethod]
        public void SwitchToSameItems()
        {
            var mocker = new OptimizedObservableCollectionMocker(testObjects);

            mocker.OptimizedObservableCollection.SwitchTo(testObjects);

            Assert.AreEqual(mocker.OptimizedObservableCollection.Count, 3);
            Assert.AreEqual(0, mocker.ItemsAddedCount);
            Assert.AreEqual(0, mocker.ItemsRemovedCount);
            Assert.AreEqual(0, mocker.ItemsReplacedCount);
            Assert.AreEqual(0, mocker.ItemsResetCount);
        }

        [TestMethod]
        public void ReplaceWithRaisesSingleResetEvent()
        {
            var mocker = new OptimizedObservableCollectionMocker(testObjects);

            mocker.OptimizedObservableCollection.ReplaceWith(testObjects);

            Assert.AreEqual(mocker.OptimizedObservableCollection.Count, 3);
            Assert.AreEqual(0, mocker.ItemsAddedCount);
            Assert.AreEqual(0, mocker.ItemsRemovedCount);
            Assert.AreEqual(0, mocker.ItemsReplacedCount);
            Assert.AreEqual(1, mocker.ItemsResetCount);
        }

        private class OptimizedObservableCollectionMocker
        {
            public int ItemsAddedCount { get; private set; }

            public int ItemsRemovedCount { get; private set; }

            public int ItemsReplacedCount { get; private set; }

            public int ItemsResetCount { get; private set; }

            public OptimizedObservableCollection<object> OptimizedObservableCollection { get; private set; }

            public OptimizedObservableCollectionMocker(IEnumerable<object> items)
            {
                OptimizedObservableCollection = new OptimizedObservableCollection<object>(items);
                OptimizedObservableCollection.CollectionChanged += (s, e) =>
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            ItemsAddedCount++;
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            ItemsRemovedCount++;
                            break;
                        case NotifyCollectionChangedAction.Replace:
                            ItemsReplacedCount++;
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            ItemsResetCount++;
                            break;
                    }
                };
            }
        }
    }
}