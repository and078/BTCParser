using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.BTC
{
    class BTCParserSettings : IParserSettings
    {
        public BTCParserSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://www.coindesk.com/price";
        public string Prefix { get; set; } = "bitcoin/";
        public int StartPoint { get ; set ; }
        public int EndPoint { get ; set ; }
    }
}
