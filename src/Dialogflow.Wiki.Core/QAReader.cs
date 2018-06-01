using System;
using System.Collections.Generic;
using System.Text;

namespace Dialogflow.Wiki.Core
{
    public static class QAReader
    {
        public static List<string> GetQuestions(string fileContent)
        {
            var lines = fileContent.Split('\n');
            var index = 0;
            var result = new List<string>();

            while (index < lines.Length)
            {
                var line = lines[index].Trim();

                if (!string.IsNullOrEmpty(line))
                {
                    result.Add(line);
                    index++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public static List<string> GetAnswers(string fileContent)
        {
            var lines = fileContent.Split('\n');
            var result = new List<string>();
            var skippedQuestions = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();

                if (string.IsNullOrEmpty(line))
                {
                    if (skippedQuestions)
                    {
                        // we finished all answers
                        break;
                    }
                    else
                    {
                        skippedQuestions = true;
                    }
                }
                else if (skippedQuestions)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
