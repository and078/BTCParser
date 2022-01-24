using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.CursMd
{
    class CursMdSettings : IParserSettings
    {
        public CursMdSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://www.curs.md/ru";
        public string Prefix { get; set; } = "";
        public int StartPoint { get ; set ; }
        public int EndPoint { get ; set ; }
    }
}
