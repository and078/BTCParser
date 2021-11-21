using Parser.Core;
using Parser.Core.BTC;
using Parser.Core.CursMd;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Parser
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        ParserWorker<string[]> curriencesParser;
        ParserWorker<string[]> bitcoinParser;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlDataReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Books]", sqlConnection);

            try
            {
                sqlDataReader = await command.ExecuteReaderAsync();
                while (await sqlDataReader.ReadAsync())
                {
                    ListTitles.Items.Add(Convert.ToString(sqlDataReader["ID"]) + "\t" +
                        Convert.ToString(sqlDataReader["Name"]) + "\t" + 
                        Convert.ToString(sqlDataReader["Author"]) + "\t" +
                        Convert.ToString(sqlDataReader["Price"]));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
            }
        }

        public void RunFromAnotherForm()
        {
            ButtonStart_Click(new Form2(), EventArgs.Empty);
        }

        private void Parser_OnCompleted(object obj)
        {
            ListTitles.Items.AddRange(new string[] { "\n" });
            //MessageBox.Show("All works done!");
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            ListTitles.Items.Clear();
            CursMdParser.dict.Clear();
            ButtonStart.Enabled = false;

            if (radioButtonCurriences.Checked)
            {
                new Thread(() => 
                {
                    curriencesParser = new ParserWorker<string[]>(new CursMdParser());
                    curriencesParser.OnCompleted += Parser_OnCompleted;
                    curriencesParser.OnNewData += Parser_OnNewData;
                    curriencesParser.Settings = new CursMdSettings((int)NumericStart.Value, (int)NumericEnd.Value);
                    curriencesParser.Start();
                }).Start();
            }

            if (radioButtonBTC.Checked)
            {
                new Thread(() => 
                {
                    bitcoinParser = new ParserWorker<string[]>(new BTCParser());
                    bitcoinParser.OnNewData += Parser_OnNewData;
                    bitcoinParser.OnCompleted += Parser_OnCompleted;
                    bitcoinParser.Settings = new BTCParserSettings((int)NumericStart.Value, (int)NumericEnd.Value);
                    bitcoinParser.Start();
                }).Start();
            }
            ButtonStart.Enabled = true;
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            curriencesParser.Abort();
            bitcoinParser.Abort();
            if (sqlConnection != null)
            {
                sqlConnection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
    }
}
