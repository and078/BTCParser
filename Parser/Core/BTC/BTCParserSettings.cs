namespace Parser.Core.BTC
{
    class BTCParserSettings : IParserSettings
    {
        public BTCParserSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://www.google.com/finance/quote";
        public string Prefix { get; set; } = "BTC-USD";
        public int StartPoint { get ; set ; }
        public int EndPoint { get ; set ; }
    }
}
