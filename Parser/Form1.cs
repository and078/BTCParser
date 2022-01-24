using Parser.Core;
using Parser.Core.BTC;
using Parser.Core.CursMd;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Parser
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        BTC_Curr_Calculator calculator = new BTC_Curr_Calculator();
        ParserWorker<string[]> onLoadCurriencesParser;
        ParserWorker<string[]> curriencesParser;
        ParserWorker<string[]> bitcoinParser;
        Dictionary<string, decimal> CuriencesDictionary;
        bool isPaginaionEnabled;
        public Form1()
        {
            InitializeComponent();
        }


        private void FormLoadParserOnNewData(object arg1, string[] arg2)
        {
            CuriencesDictionary = calculator.GetCurrencyDictionary(arg2);
        }

        private void FormLoadParserOnCompleted(object obj)
        {
            ListTitles.Items.Add("*******************************");
        }
        private void ParserOnCompletedCurr(object obj)
        {
            ListTitles.Items.Add("*******************************");
        }

        private void ParserOnNewDataCurr(object obj, string[] arg)
        {
            CuriencesDictionary = calculator.GetCurrencyDictionary(arg);
            ListTitles.Items.Add("Curriences in MDL");
            ListTitles.Items.AddRange(arg);
        }

        private void ParserOnCompletedBTC(object obj)
        {
            ListTitles.Items.Add("*******************************");
        }

        private void ParserOnNewDataBTC(object arg1, string[] arg2)
        {
            decimal BTC_In_USD_Price = calculator.GetBTCPriceUSD(arg2[0]);
            ListTitles.Items.Add("Bitcoin price in some curriences");
            ListTitles.Items.AddRange(calculator.CalculateBTC_In_Curriences(CuriencesDictionary, BTC_In_USD_Price));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isPaginaionEnabled = false;
            PaginationAtivator(isPaginaionEnabled);
            CheckInternetConnection();

            new Thread(() =>
            {
                onLoadCurriencesParser = new ParserWorker<string[]>(new CursMdParser());
                onLoadCurriencesParser.OnCompleted += FormLoadParserOnCompleted;
                onLoadCurriencesParser.OnNewData += FormLoadParserOnNewData;
                onLoadCurriencesParser.Settings = new CursMdSettings(1, 1);
                onLoadCurriencesParser.Start();
            }).Start();

            #region SQLConnection(not in use)
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
            #endregion
        }
        public void RunCustomParesrFromAnotherForm(string[] customParserData)
        {
            //ButtonStart_Click(new Form2(), EventArgs.Empty);
            //ListTitles.Items.Clear();
            //ListTitles.Items.AddRange(customParserData);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            ListTitles.Items.Clear();
            CheckInternetConnection();
            ButtonStart.Enabled = false;

            if (radioButtonCurriences.Checked)
            {
                new Thread(() =>
                {
                    curriencesParser = new ParserWorker<string[]>(new CursMdParser());
                    curriencesParser.OnCompleted += ParserOnCompletedCurr;
                    curriencesParser.OnNewData += ParserOnNewDataCurr;
                    curriencesParser.Settings = new CursMdSettings(1, 1);
                    curriencesParser.Start();
                }).Start();
            }

            if (radioButtonBTC.Checked)
            {
                new Thread(() =>
                {
                    bitcoinParser = new ParserWorker<string[]>(new BTCParser());
                    bitcoinParser.OnNewData += ParserOnNewDataBTC;
                    bitcoinParser.OnCompleted += ParserOnCompletedBTC;
                    bitcoinParser.Settings = new BTCParserSettings(1, 1);
                    bitcoinParser.Start();
                }).Start();
            }
            ButtonStart.Enabled = true;
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
                string host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                //return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                //return false;
                MessageBox.Show("Internet connection needed!");
                Form1_Load(this, EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isPaginaionEnabled = !isPaginaionEnabled;
            PaginationAtivator(isPaginaionEnabled);
        }

        private void PaginationAtivator(bool isEnabled)
        {
            StartPoint.Enabled = isEnabled;
            NumericStart.Enabled = isEnabled;
            label2.Enabled = isEnabled;
            NumericEnd.Enabled = isEnabled;
        }
    }
}
