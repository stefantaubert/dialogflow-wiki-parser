using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Dialogflow.Wiki.Core.Tests
{
    [TestClass]
    public class EntryNameConverterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var root = @"C:\abc\test";
            var file = @"C:\abc\test\ulf.md";

            Assert.AreEqual("ulf", IntentNameConverter.GetEntryName(file, root));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var root = @"C:\abc\test";
            var file = @"C:\abc\test\ulf\ab.md";

            Assert.AreEqual("ulf.ab", IntentNameConverter.GetEntryName(file, root));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var root = @"C:\abc\test";
            var file = @"C:\abc\test\ulf\ab\ulf\ab.md";

            Assert.AreEqual("ulf.ab.ulf.ab", IntentNameConverter.GetEntryName(file, root));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestExceptionWrongExtention()
        {
            var root = @"C:\abc\test";
            var file = @"C:\abc\test\ulf\ab.text";

            Assert.AreEqual("ulf.ab", IntentNameConverter.GetEntryName(file, root));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestExceptionNonExtention()
        {
            var root = @"C:\abc\test";
            var file = @"C:\abc\test\ulf\ab";

            Assert.AreEqual("ulf.ab", IntentNameConverter.GetEntryName(file, root));
        }
    }
}
