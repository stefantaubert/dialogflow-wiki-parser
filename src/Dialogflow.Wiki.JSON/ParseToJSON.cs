using Dialogflow.Wiki.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogflow.Wiki.JSON
{
    public class ParseToJSON
    {
        public static string GenerateQuestionJSON(Intent intent)
        {
            var resultList = new List<object>();

            foreach (var q in intent.Questions)
            {
                var obj = new
                {
                    id = Guid.NewGuid(),
                    data = new[]
                    {
                        new
                        {
                            text = q,
                            userDefined = true
                        }
                    },
                    isTemplate = false,
                    count = 0,
                    updated = 1527749568
                };

                resultList.Add(obj);
            }

            return JsonConvert.SerializeObject(resultList);
        }

        public static string GenerateAnswerJSON(Intent intent)
        {
            var answers = string.Empty;

            var obj = new
            {
                id = Guid.NewGuid(),
                name = intent.Name,
                auto = true,
                contexts = new List<object>(),
                responses = new[]
                {
                    new {
                        resetContexts = false,
                        affectedContexts = false,
                        parameters = new List<object>(),
                        messages = new[]
                        {
                            new
                            {
                                type = 0,
                                lang = "de",
                                speech = intent.Answers
                            }
                        },
                        defaultResponsePlatforms = new { },
                        speech = new List<object>()
                    }
                },
                priority = 500000,
                webhookUsed = false,
                webhookForSlotFilling = false,
                lastUpdate = 1527707682,
                fallbackIntent = false,
                events = new List<object>()
            };

            return JsonConvert.SerializeObject(obj);
        }
    }
}
