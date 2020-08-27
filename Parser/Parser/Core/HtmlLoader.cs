using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Parser.Core
{
    /// <summary>
    /// Класс отвечающий за загрузку Html
    /// </summary>
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}";
        }

        public async Task<string> GetSourceByPageID(int id)
        {
            //используем Encoding из System.Text + пакеты System.Text.Encoding && System.Text.Encoding.CodePages
            //чтобы корректно обрабатывались разные charset'ы на страницах, т.к. без RegisterProvider
            //будет вылетать исключение, если мы попытаемся спарсить страницу с windows-1251, например
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //заменяем в ссылке регулярку на id
            var currentUrl = url.Replace("{CurrentID}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;
            //проверяем ответ (на некоторых сайтах StatusCode может быть None, тогда парсер работать не будет
            if (response!=null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
