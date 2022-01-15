using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    internal class BTC_Curr_Calculator
    {
        public Dictionary<string, decimal> GetCurrArray(string[] args)
        {
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
            foreach (var arg in args)
            {
                string[] splitted = arg.Split(' ');
                splitted[1].Replace(",", ".");
                dict.Add(splitted[0], Decimal.Parse(splitted[1]));
            }
            return dict;
        }

        public decimal GetBTCPriceUSD(string price)
        {
            var dec = price.Split(' ')[0].Replace(",", "").Replace(".", ",");
            return Decimal.Parse(dec);
        }

        public string[] BTC_In_Curriences(Dictionary<string, decimal> dict, decimal btcInUSD)
        {
            decimal BTC_In_Lei = dict["USD"] * btcInUSD;
            List<string> list = new List<string>();
            foreach (var item in dict)
            {
                list.Add($"{(BTC_In_Lei / item.Value).ToString("F")} {item.Key}");
            }
            list.Add($"{BTC_In_Lei.ToString("F")} MDL");
            return list.ToArray();
        }
    }
}