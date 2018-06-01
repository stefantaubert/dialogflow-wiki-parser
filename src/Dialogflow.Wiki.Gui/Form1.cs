using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Dialogflow.Wiki.Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wiki = Wiki.Core.Wiki.ParseDir(this.textBox1.Text);
            var intentsPath = Path.Combine(textBox2.Text, "intents");
            JSON.JSONWriter.WriteQuestions(wiki.Intents, intentsPath);
            JSON.JSONWriter.WriteAnswers(wiki.Intents, intentsPath);
            var zip = Path.Combine(Path.GetDirectoryName(textBox2.Text), "bot.zip");
            File.Delete(zip);
            ZipFile.CreateFromDirectory(textBox2.Text, zip, CompressionLevel.Fastest, false);
            MessageBox.Show("Finished.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }
    }
}
