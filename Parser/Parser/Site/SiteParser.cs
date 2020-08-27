using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Parser.Core;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Site
{
    public class SitePage
    {
        
        public SitePost[] Posts { get; }

        public SitePage(SitePost[] posts)
        {
            Posts = posts;
        }
    }

    public class SitePost
    {
        public string Date { get; }
        public string Title { get; }
        public string Description { get; }
        public string DownloadLink { get; }

        public SitePost(string date, string title, string description, string downloadLink)
        {
            Date = date;
            Title = title;
            Description = description;
            DownloadLink = downloadLink;
        }
    }
    
    class SiteParser : IParser<SitePage>
    {
          
        public SitePage Parse(IHtmlDocument document)
        {
            //var timer = new Stopwatch();
            
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName !=null && item.ClassName.Contains("news"));
            var posts = new List<SitePost>();
            string downloadLink = "";
            foreach (var item in items)
            {
                //ссылка для скачивания из html
                var pFrom = item.InnerHtml.ToString().IndexOf("goto=") + 5;
                var pTo = item.InnerHtml.ToString().IndexOf("title=") - 2;
                var date = item.QuerySelector("span.news-date-time")== null ? " " : item.QuerySelector("span.news-date-time").Text().Replace("\n", "");
                var name = item.QuerySelector("a") == null ? " " : item.QuerySelector("a").Text().Replace("\n", "");
                var desc = item.QuerySelector("p") == null ? " ": item.QuerySelector("p").NextSibling.Text().Replace("\n", "");
                //добавляем к ссылке сайт, проверяя, что индексы не отрицательны (на случай, если файла в новости нет)
                if (pTo > pFrom && pTo > 0)
                    downloadLink = "www.tfoms.e-burg.ru" + item.InnerHtml.ToString()[pFrom..pTo].Replace("\n", "");
                else
                    downloadLink = "Файл отсутствует";
                //добавляем в новый пост
                posts.Add(new SitePost(
                    date, //дата поста
                    name,//название
                    desc,//описание, берез следующего потомка после первого
                    downloadLink)); //ссылка
            }

            return new SitePage(posts.ToArray());
        }
    }
}
