using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WebJobNews.Data;
using WebJobNews.Models;

namespace WebJobNews.Repositories
{
    public class RepositoryRss
    {
        private WebJobContext context;

        public RepositoryRss(WebJobContext context)
        {
            this.context = context;
        }

        public List<NewsRss> GetNewsRss()
        {
            String url = "https://e00-elmundo.uecdn.es/elmundo/rss/espana.xml";
            XDocument docxml = XDocument.Load(url);
            var query = from data in docxml.Descendants("item")
                        select new NewsRss 
                        { 
                            Title = data.Element("title").Value,
                            Description = data.Element("description").Value,
                            Link = data.Element("link").Value
                        };
            return query.ToList();
        }

        public void SaveNewsBDD()
        {
            List<NewsRss> news = this.GetNewsRss();
            int maxId = this.GetMaxId() + 1;
            foreach (NewsRss n in news)
            {
                NewsBdd newBdd = new NewsBdd();
                newBdd.Id = maxId;
                newBdd.Title = n.Title;
                newBdd.Description = n.Description;
                newBdd.Link = n.Link;
                newBdd.Date = DateTime.Now;
                maxId++;
                this.context.News.Add(newBdd);
            }

            this.context.SaveChanges();
        }

        private int GetMaxId()
        {
            if (this.context.News.Count() == 0)
                return 0;
            else
                return this.context.News.Max(x => x.Id);
        }
    }
}
