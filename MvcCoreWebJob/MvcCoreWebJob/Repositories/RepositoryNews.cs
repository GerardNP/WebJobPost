using MvcCoreWebJob.Data;
using MvcCoreWebJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebJob.Repositories
{
    public class RepositoryNews
    {
        private NewsContext context;

        public RepositoryNews(NewsContext context)
        {
            this.context = context;
        }

        public List<News> GetNews()
        {
            return this.context.News.ToList();
        }
    }

}
