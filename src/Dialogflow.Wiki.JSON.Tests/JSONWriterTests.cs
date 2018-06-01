using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dialogflow.Wiki.JSON.Tests
{
    [TestClass]
    public class JSONWriterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Dialogflow.Wiki.Core.Wiki.ParseDir(path);
            var destDir = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "generated");

            JSONWriter.WriteQuestions(wiki.Intents, destDir);
        }

        [TestMethod]
        public void TestAnswers()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Dialogflow.Wiki.Core.Wiki.ParseDir(path);
            var destDir = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "generated");

            JSONWriter.WriteAnswers(wiki.Intents, destDir);
        }
    }
}
