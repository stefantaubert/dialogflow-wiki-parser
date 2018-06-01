using System;
using System.Collections.Generic;
using System.Text;

namespace Dialogflow.Wiki.Core
{
    public class IntentNameConverter
    {
        public static string GetEntryName(string filePath, string rootPath)
        {
            if (!filePath.EndsWith(Wiki.FileEnding))
            {
                throw new NotSupportedException();
            }

            return filePath.Substring(0, filePath.Length - Wiki.FileEnding.Length).Replace(rootPath.TrimEnd('\\') + '\\', string.Empty).Replace('\\', '.');
        }
    }
}
