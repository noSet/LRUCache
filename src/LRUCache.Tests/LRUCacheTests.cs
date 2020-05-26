using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LRUCache.Tests
{
    [TestClass]
    public class LRUCacheTests
    {
        [TestMethod]
        public void LRUCacheTest()
        {
            LRUCache cache = new LRUCache(2);

            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(1), 1);
            cache.Put(3, 3);
            Assert.AreEqual(cache.Get(2), -1);
            cache.Put(4, 4);
            Assert.AreEqual(cache.Get(1), -1);
            Assert.AreEqual(cache.Get(3), 3);
            Assert.AreEqual(cache.Get(4), 4);
            Assert.AreEqual(cache.Get(3), 3);
            cache.Put(5, 5);
            Assert.AreEqual(cache.Get(3), 3);
            cache.Put(5, 6);
            Assert.AreEqual(cache.Get(5), 6);
        }
    }
}