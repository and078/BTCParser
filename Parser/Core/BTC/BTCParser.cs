using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Core.BTC
{
    class BTCParser : IParser<string[]>
    {

        public string[] Parse(IHtmlDocument document)
        {

            var list = new List<string>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("fxKbKc"));

            foreach (var item in items)
            {
                list.Add(item.TextContent + " USD");
            }
            return list.ToArray();
        }
    }
}
