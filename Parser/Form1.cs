using Parser.Core;
using Parser.Core.BTC;
using Parser.Core.CursMd;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

//c:\users\andre\source\repos\parser\Parser\Form1.cs
//c:\users\andre\source\repos\parser\Parser\Form1.cs

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
            CheckInternetConnection();
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //sqlConnection = new SqlConnection(connectionString);
            //await sqlConnection.OpenAsync();
            //SqlDataReader sqlDataReader = null;
            //SqlCommand command = new SqlCommand("SELECT * FROM [Pay_1]", sqlConnection);

            //try
            //{
            //    sqlDataReader = await command.ExecuteReaderAsync();
            //    while (await sqlDataReader.ReadAsync())
            //    {
            //        ListTitles.Items.Add(Convert.ToString(sqlDataReader["id"]) + "\t" +
            //            Convert.ToString(sqlDataReader["date"]) + "\t" + 
            //            Convert.ToString(sqlDataReader["Summ"]) + "\t" +
            //            Convert.ToString(sqlDataReader["RestSumm"]) + "\t" +
            //            Convert.ToString(sqlDataReader["Annotation"]));
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    if (sqlDataReader != null)
            //        sqlDataReader.Close();
            //}
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
            CheckInternetConnection();
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

        private void CheckInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                //return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                //return false;
                MessageBox.Show("No Internet connection!\nThe App will be closed!");
                Close();
            }
        }
    }
}
