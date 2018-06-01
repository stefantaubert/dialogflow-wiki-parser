using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Dialogflow.Wiki.Core.Tests
{
    [TestClass]
    public class QAReaderTests
    {
        [TestMethod]
        public void TestQuestionsWithAnswers()
        {
            var content = "frage1\r\nfrage2\r\n\nantwort1\r\n\r\ntest";
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(2, q.Count);
            Assert.AreEqual("frage1", q[0]);
            Assert.AreEqual("frage2", q[1]);
        }

        [TestMethod]
        public void TestQuestionsNoAnswers()
        {
            var content = "frage1\r\nfrage2\r\n\r\n";
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(2, q.Count);
            Assert.AreEqual("frage1", q[0]);
            Assert.AreEqual("frage2", q[1]);
        }

        [TestMethod]
        public void TestQuestionsNoSecondRN()
        {
            var content = "frage1\r\nfrage2\r\n";
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(2, q.Count);
            Assert.AreEqual("frage1", q[0]);
            Assert.AreEqual("frage2", q[1]);
        }

        [TestMethod]
        public void TestQuestionsNoRN()
        {
            var content = "frage1\r\nfrage2";
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(2, q.Count);
            Assert.AreEqual("frage1", q[0]);
            Assert.AreEqual("frage2", q[1]);
        }

        [TestMethod]
        public void TestQuestionsRN()
        {
            var content = "\r\n";
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void TestQuestionsRNRN()
        {
            var content = "\r\n\r\n";
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void TestQuestionsEmpty()
        {
            var content = string.Empty;
            var q = QAReader.GetQuestions(content);

            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void TestAnswersWithComment()
        {
            var content = "frage1\r\nfrage2\r\n\nantwort1\r\n\r\ntest";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(1, a.Count);
            Assert.AreEqual("antwort1", a[0]);
        }

        [TestMethod]
        public void TestAnswersWithoutQuestions()
        {
            var content = "\r\nantwort1";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(1, a.Count);
            Assert.AreEqual("antwort1", a[0]);
        }

        [TestMethod]
        public void TestAnswersOnlyQuestion()
        {
            var content = "antwort1";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(0, a.Count);
        }

        [TestMethod]
        public void TestAnswersOnlyQuestionRNRN()
        {
            var content = "antwort1\r\n\r\n";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(0, a.Count);
        }

        [TestMethod]
        public void TestAnswersOnlyQuestionRNRNRN()
        {
            var content = "antwort1\r\n\r\n\r\n";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(0, a.Count);
        }

        [TestMethod]
        public void TestAnswersRNRNRN()
        {
            var content = "\r\n\r\n\r\n";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(0, a.Count);
        }

        [TestMethod]
        public void TestAnswersNoQuestionsMultipleAnswers()
        {
            var content = "\r\nantwort1\r\nantwort2\n";
            var a = QAReader.GetAnswers(content);

            Assert.AreEqual(2, a.Count);
            Assert.AreEqual("antwort1", a[0]);
            Assert.AreEqual("antwort2", a[1]);
        }
    }
}
