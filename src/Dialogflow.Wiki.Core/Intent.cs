using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dialogflow.Wiki.Core
{
    public class Intent
    {
        private readonly Wiki wiki;

        internal Intent(Wiki wiki, string filePath)
        {
            this.FilePath = filePath;
            this.wiki = wiki;
            this.Name = IntentNameConverter.GetEntryName(this.FilePath, this.wiki.Root);

            var content = File.ReadAllText(filePath);

            this.Questions = QAReader.GetQuestions(content);
            this.Answers = QAReader.GetAnswers(content);
        }

        public string FilePath
        {
            get;
        }

        public string Name
        {
            get;
        }

        public List<string> Questions
        {
            get;
        }

        public List<string> Answers
        {
            get;
        }
    }
}
