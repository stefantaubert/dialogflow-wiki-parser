using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Dialogflow.Wiki.Core.Test
{
    [TestClass]
    public class WikiTests
    {
        [TestMethod]
        public void TestFileDetection()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Wiki.ParseDir(path);

            Assert.AreEqual(2, wiki.Intents.Count);
            Assert.AreEqual("root", wiki.Intents[0].Name);
            Assert.AreEqual("folder.folder", wiki.Intents[1].Name);
        }

        [TestMethod]
        public void TestIntent1()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Wiki.ParseDir(path);
            var intent = wiki.Intents[0];

            Assert.AreEqual("root", intent.Name);
            Assert.AreEqual(2, intent.Questions.Count);
            Assert.AreEqual(1, intent.Answers.Count);
            Assert.AreEqual("Frage1", intent.Questions[0]);
            Assert.AreEqual("Frage2", intent.Questions[1]);
            Assert.AreEqual("Antwort1", intent.Answers[0]);
        }

        [TestMethod]
        public void TestIntent2()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Wiki.ParseDir(path);
            var intent = wiki.Intents[1];

            Assert.AreEqual("folder.folder", intent.Name);
            Assert.AreEqual(0, intent.Questions.Count);
            Assert.AreEqual(0, intent.Answers.Count);
        }
    }
}
