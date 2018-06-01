using Dialogflow.Wiki.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogflow.Wiki.JSON
{
    public class JSONWriter
    {
        public static void WriteQuestions(List<Intent> intents, string destDir)
        {
            foreach (var intent in intents)
            {
                var fileName = string.Format("{0}_usersays_de.json", intent.Name);
                var filePath = Path.Combine(destDir, fileName);
                var content = ParseToJSON.GenerateQuestionJSON(intent);

                File.WriteAllText(filePath, content);
            }
        }

        public static void WriteAnswers(List<Intent> intents, string destDir)
        {
            foreach (var intent in intents)
            {
                var fileName = string.Format("{0}.json", intent.Name);
                var filePath = Path.Combine(destDir, fileName);
                var content = ParseToJSON.GenerateAnswerJSON(intent);

                File.WriteAllText(filePath, content);
            }
        }
    }
}
