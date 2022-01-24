using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Browser;
using Parser.Core;
using Parser.Core.CustomParser;

namespace Parser
{
    public partial class Form2 : Form
    {
        ParserWorker<string[]> customParserWorker;
        CustomParser customParser;
        CustomParserSettings customParserSettings;
        Form1 _form1;
        public Form2(Form1 f)
        {
            _form1 = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                customParserSettings = new CustomParserSettings();
                customParserSettings.BaseUrl = URLtextBox.Text;
                customParserSettings.Prefix = PrefixtextBox2.Text;
                customParserSettings.Tag = TagtextBox3.Text;
                customParserSettings.ClassName = ClassNametextBox4.Text;
                customParser = new CustomParser(customParserSettings);
                customParserWorker = new ParserWorker<string[]>(customParser, customParserSettings);
                customParserWorker.OnNewData += CustomParserWorker_OnNewData;
                customParserWorker.OnCompleted += CustomParserWorker_OnCompleted;
                customParserWorker.Start();
            }).Start();
        }

        private void CustomParserWorker_OnCompleted(object obj)
        {
            
        }

        private void CustomParserWorker_OnNewData(object arg1, string[] arg2)
        {
            _form1.ListTitles.Items.Clear();
            _form1.ListTitles.Items.AddRange(arg2);

            //_form1.RunCustomParesrFromAnotherForm(arg2);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
