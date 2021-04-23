using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebJobNews.Data;
using WebJobNews.Repositories;

namespace WebJobNews
{
    class Program
    {
        static void Main(string[] args)
        {
            String sqlCon = "Data Source=sqltajamargnp.database.windows.net;Initial Catalog=azuretajamar;Persist Security Info=True;User ID=admingnp;Password=Admintajamar2020";
            var provider = new ServiceCollection()
                .AddTransient<RepositoryRss>()
                .AddDbContext<WebJobContext>(options =>
                    options.UseSqlServer(sqlCon)).BuildServiceProvider();
            RepositoryRss repo = provider.GetService<RepositoryRss>();

            Console.WriteLine("Alimentando BDD...");
            repo.SaveNewsBDD();
            Console.WriteLine("Proceso terminado");
        }
    }
}
