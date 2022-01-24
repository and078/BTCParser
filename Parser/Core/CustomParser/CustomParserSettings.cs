using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.CustomParser
{
    class CustomParserSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = String.Empty;
        public string Prefix { get; set; } = String.Empty;
        public string Tag { get; set; } = String.Empty;
        public string ClassName { get; set; } = String.Empty;
        public int StartPoint { get; set; } = 1;
        public int EndPoint { get; set; } = 1;
    }
}
