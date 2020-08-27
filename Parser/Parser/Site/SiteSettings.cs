using Parser.Core;

namespace Parser.Site
{
    class SiteSettings : IParserSettings
    {
        public SiteSettings(int end)
        {
            EndPage = end;
        }

        public string BaseUrl { get; set; } = "http://www.tfoms.e-burg.ru/documents";
        public string Prefix { get; set; } = "/?PAGEN_1={CurrentID}";
        public int EndPage { get; set; } 
    }
}
