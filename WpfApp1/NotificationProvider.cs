using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WpfApp1
{
    public  class Notification
    {

        public string Name { get; set; }

        public string Url { get; set; }

        public string Date { get; set; }

        public Notification(string name, string url, string date)
        {
            Name = name;
            Url = url;
            Date = date;
        }

        public override string ToString()
        {
            //return $"[{Date}]{Name}";
            return string.Format("[{0}]{1}", Name, Date);
        }

        public static explicit operator Notification(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class NotificationProvider
    {

        private readonly HtmlWeb web = new HtmlWeb();

        public IEnumerable<Notification> DownloadAllNotifications(string url)
        {
            var doc = web.Load(url);
            return FindAllNotifications(doc);
        }

        public IEnumerable<Notification> FindAllNotifications(HtmlDocument document)
        {
            HtmlNode node = document.DocumentNode.SelectSingleNode("//div[@class='list_main_content']");
            foreach (var i in node.SelectNodes("./div"))
            {
                string name = null, url = null, date = null;
                var namenode = i.SelectSingleNode("./a");
                name = namenode.GetAttributeValue("title", "");
                var urlnode = i.SelectSingleNode("./a");
                url = urlnode.GetAttributeValue("href", "");
                var datenode = i.SelectSingleNode("./span");
                date = datenode.InnerText;
                yield return new Notification(name, url, date);
            }

        }
    }
}
