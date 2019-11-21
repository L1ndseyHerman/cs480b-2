using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using quotable.core;
using quotable.core.data;

namespace quotable.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            //  Trying to connect to code from hw1:
            //services.AddSingleton<RandomQuoteProvider, SimpleRandomQuoteProvider>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<QuotableContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<QuotableContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                PopulateDatabase(context);
            }
        }

        private static void PopulateDatabase(QuotableContext context)
        {
            var author1 = new AuthorObject()
            {
                FirstName = "Hermione",
                LastName = "Granger"
            };
            var author2 = new AuthorObject()
            {
                FirstName = "Albus",
                LastName = "Dumbledore"
            };
            var author3 = new AuthorObject()
            {
                FirstName = "Harry",
                LastName = "Potter"
            };

            var quote1 = new QuoteObject();
            quote1.Quote = "Fear of a name only increases fear of the thing itself.";

            var quote2 = new QuoteObject();
            quote2.Quote = "It is our choices, Harry, that show what we truly are, far more than our abilities.";

            var quote3 = new QuoteObject();
            quote3.Quote = "I solemnly swear I am up to no good.";

            var qa1 = new QuotesAndAuthorsObject() { Quote = quote1, Author = author1 };
            var qa2 = new QuotesAndAuthorsObject() { Quote = quote2, Author = author2 };
            var qa3 = new QuotesAndAuthorsObject() { Quote = quote3, Author = author3 };

            context.AddRange(qa1, qa2, qa3);

            context.SaveChanges();
        }
    }
}
