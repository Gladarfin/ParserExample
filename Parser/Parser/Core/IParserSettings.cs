using AngleSharp.Html;
using Parser.Site;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core
{
    /// <summary>
    /// Интерфейс с настройками
    /// </summary>
    interface IParserSettings
    {

        string BaseUrl { get; set; }

        string Prefix { get; set; }

        int EndPage { get; set; }
    }
}
