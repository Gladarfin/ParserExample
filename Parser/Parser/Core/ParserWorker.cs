using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core
{
    class ParserWorker<T> where T : class
    {
        HtmlLoader loader;
        readonly IParser<T> parser;
        IParserSettings parserSettings;
        bool isActive;

        #region public Properties

        public IParser<T> Parser { get; set; }

        public IParserSettings ParserSettings
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

        public bool IsActive { get { return isActive; } }

        #endregion

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings):this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void StartParser()
        {
            isActive = true;
            Worker();
        }

        public void AbortParser()
        {
            isActive = false;
        }

        public event Action<object, T> OnNewData;

        public event Action<object> OnComplete;

        private async void Worker()
        {
            for (int i = 1; i<=parserSettings.EndPage;i++)
            {
                if (!isActive)
                {
                    OnComplete?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageID(i);
                var angleParser = new HtmlParser();
                //иногда все страницы норм парсит, иногда выбрасывает NullReferenceException рандомно на 100+, фиг знает из-за чего
                var document = await angleParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }

            OnComplete?.Invoke(this);
            isActive = false;
        }
    }
}
