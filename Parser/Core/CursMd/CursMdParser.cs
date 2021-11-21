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
            int j = 0;

            //NumberStyles style;
            //CultureInfo provider;
            //style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            //provider = new CultureInfo("en-GB");
            
            var list = new List<string>();
            var decimalList = new List<decimal>();
            var currencies = document.QuerySelectorAll("td").Where(item => item.ClassName != null && item.ClassName.Contains("currency"));
            var rates = document.QuerySelectorAll("td").Where(item => item.ClassName != null && item.ClassName.Contains("rate"));
            var decimals = rates.Select(x => x.TextContent[0..^4])
                .Select(y => decimal.Parse(y));

            for (int i = 0; i < currencies.Count(); i++)
            {
                list.Add(currencies.ElementAt(i).TextContent + " " + rates.ElementAt(i).TextContent);
            }

            foreach (var item in decimals)
            {
                decimalList.Add(item);
                dict.Add(currencies.ElementAt(j).TextContent, item);
                j++;
            }
            return list.ToArray();
        }
    }
}
