using System;
using System.Collections.Generic;
using System.IO;

namespace Dialogflow.Wiki.Core
{
    public class Wiki
    {
        public const string FileEnding = ".md"; 

        private Wiki(string dir)
        {
            this.Root = dir;
            this.Intents = new List<Intent>();

            foreach (var item in Directory.GetFiles(dir, "*" + FileEnding, SearchOption.AllDirectories))
            {
                this.Intents.Add(new Intent(this, item));
            }
        }

        public string Root { get; }

        public List<Intent> Intents { get; set; }

        public static Wiki ParseDir(string dir)
        {
            return new Wiki(dir);
        }
    }
}
