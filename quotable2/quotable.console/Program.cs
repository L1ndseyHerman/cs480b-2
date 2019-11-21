using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using quotable.core;
using quotable.core.data;
using System;
using System.Threading.Tasks;

namespace quotable.console
{
    /// <summary>
    ///     This program prints quotes to the console 2 ways: 
    ///         1: Takes in a long from the user and prints the quotes from the SimpleRandomQuoteProvider class, then
    ///         2: Takes the quotes in this method and prints them out in the DefaultRandomQuoteGenerator class.
    ///     Also, the excessive comments are more to remind myself what I was doing than for someone who knows C#.
    /// </summary>
    class Program
    {
        /*
        //  For DefaultRandomQuoteGenerator, it seems stuff above the main method needs to say "static", same as Java
        private static string[] theQuotes = new string[3] {"Fear of a name only increases fear of the thing itself. — Hermione Granger",
            "It is our choices, Harry, that show what we truly are, far more than our abilities. — Albus Dumbledore",
        "I solemnly swear I am up to no good. - Harry Potter"};


        static void Main(string[] args)
        {
            SimpleRandomQuoteProvider threeQuotes = new SimpleRandomQuoteProvider();
            Console.WriteLine("Enter a number of quotes to show.");
            Console.WriteLine();
            //  Quickly googled how to cast string to long, it will crash if the input isn't a number though.
            long N = long.Parse(Console.ReadLine());
            threeQuotes.showQuotes(N);


            //  Now time for DefaultRandomQuoteGenerator:
            Console.WriteLine("     Now using DefaultRandomQuoteGenerator, printing all 3 quotes:");
            Console.WriteLine();
            DefaultRandomQuoteGenerator someName = new DefaultRandomQuoteGenerator(theQuotes);
            Console.ReadLine();

        }*/

        // [miko]
        // entering the world of async
        // see the stackoverflow entry below if your visual studio 
        // is complaining about not finding a main method.
        // https://stackoverflow.com/a/44254451/167160
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // [miko]
            // even in a plain console application, we can use the dependency injection functionality
            // provided by microsoft...it is not limited to only aspnet.core applications.
            var container = new ServiceCollection();

            // setup to use a sqlite database
            container.AddDbContext<QuotableContext>(options => options.UseSqlite("Data Source=quotable.db"), ServiceLifetime.Transient);
            // [miko]
            // getting a context that has already been disposed.
            // yup.
            // AddDbContext is implicitly scoped.
            // explicitly set the service lifetime
            // https://github.com/aspnet/EntityFrameworkCore/issues/4988

            var provider = container.BuildServiceProvider();

            using (var context = provider.GetService<QuotableContext>())
            {
                // [miko]
                // good for testing
                // bad for production...
                await context.Database.EnsureDeletedAsync();

                // [miko]
                // if the database doesn't exist it will be created
                // this should ideally only be run once in an application lifetime
                // this only ensure existence, this does not perform migrations.
                var dbDidntExist = await context.Database.EnsureCreatedAsync();

                if (dbDidntExist)
                {
                    await PopulateDatabase(context);
                }
            }

            using (var context = provider.GetService<QuotableContext>())
            {
                var quotes = context.QuoteTable
                                        .Include(d => d.QuotesAndAuthorsTable)
                                        .ThenInclude(x => x.Author);

                foreach (var quote in quotes)
                {
                    Console.WriteLine($"quote.id = {quote.Id}");
                    Console.WriteLine($"document.quote = {quote.Quote}");

                    foreach (var author in quote.Authors)
                    {
                        Console.WriteLine($"document.author.id = {author.Id}");
                        Console.WriteLine($"document.author.firstname = {author.FirstName}");
                        Console.WriteLine($"document.author.firstname = {author.LastName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

        private static async Task PopulateDatabase(QuotableContext context)
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

            await context.SaveChangesAsync();
        }
    }
}
