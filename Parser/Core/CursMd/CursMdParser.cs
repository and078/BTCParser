using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Core.CursMd
{
    class CursMdParser : IParser<string[]>
    {
        public static Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var currencies = document.QuerySelectorAll("td").Where(item => item.ClassName != null && item.ClassName.Contains("currency"));
            var rates = document.QuerySelectorAll("td").Where(item => item.ClassName != null && item.ClassName.Contains("rate"));

            for (int i = 0; i < currencies.Count(); i++)
            {
                list.Add(currencies.ElementAt(i).TextContent + " " + rates.ElementAt(i).TextContent[0..^4]);
            }

            return list.ToArray();
        }
    }
}
