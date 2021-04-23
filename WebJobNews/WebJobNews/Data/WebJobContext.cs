using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebJobNews.Models;

namespace WebJobNews.Data
{
    public class WebJobContext: DbContext
    {
        public WebJobContext(DbContextOptions<WebJobContext> options) 
            : base(options) { }

        public DbSet<NewsBdd> News { get; set; }
    }
}
