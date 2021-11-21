namespace Parser.Core.Point
{
    class PointSettings : IParserSettings
    {
        public PointSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://point.md";
        public string Prefix { get; set; } = "ru/curs/";
        public int StartPoint { get; set; }
        public int EndPoint { get ; set ; }
    }
}
