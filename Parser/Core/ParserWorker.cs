using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using Parser;

namespace Parser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        bool isActive;

        HtmlLoader loader;

        #region Properties
        public IParser<T> Parser
        {
            get 
            {
                return parser;    
            }
            set 
            {
                parser = value;
            }
        }
        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;
        public ParserWorker(IParser<T> parser)
        {
            this.Parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.Settings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            string source;
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                try
                {
                    source = await loader.GetSourseByPageId(i);
                }
                catch
                {
                    return;
                }

                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);
                var result = parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
