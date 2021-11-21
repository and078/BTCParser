using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Core.Point
{
    class PointParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("td")
                .Where(item => item.ClassName == null).Skip(12).Take(4);

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    list[i] = "Покупка: " + list[i];
                }
                else
                {
                    list[i] = "Продажа: " + list[i];
                }
            }
            return list.ToArray();
        }
    }
}