using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dialogflow.Wiki.JSON.Tests
{
    [TestClass]
    public class ParseToJSONTests
    {
        [TestMethod]
        public void TestQuestions()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Dialogflow.Wiki.Core.Wiki.ParseDir(path);
            var json = ParseToJSON.GenerateQuestionJSON(wiki.Intents[0]);
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }

        [TestMethod]
        public void TestAnswers()
        {
            var path = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "testdir");
            var wiki = Dialogflow.Wiki.Core.Wiki.ParseDir(path);
            var json = ParseToJSON.GenerateAnswerJSON(wiki.Intents[0]);
            Assert.IsFalse(string.IsNullOrEmpty(json));
        }
    }
}
