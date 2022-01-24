using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace Parser.Core.CustomParser
{
    class CustomParser : IParser<string[]>
    {
        private string tag;
        private string className;
        public CustomParser()
        {

        }
        public CustomParser(CustomParserSettings customParserSettings)
        {
            tag = customParserSettings.Tag;
            className = customParserSettings.ClassName;
        }
        public string[] Parse(IHtmlDocument document)
        {
            IEnumerable<AngleSharp.Dom.IElement> items;
            List<string> list = new List<string>();
            try
            {
                items = document.QuerySelectorAll(tag).Where(item => item.ClassName != null && item.ClassName.Contains(className));
            }
            catch (Exception)
            {
                return new string[0];
            }
            
            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
