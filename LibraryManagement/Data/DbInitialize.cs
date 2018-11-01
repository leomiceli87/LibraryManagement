using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScoper = app.ApplicationServices.CreateScope())
            {
                var context = serviceScoper.ServiceProvider.GetService<LibraryDbContext>();

                //Customers 
                var jutin = new Customer { Name = "Justin Noon" };

                var willie = new Customer { Name = "Willie Parodi" };

                var leona = new Customer { Name = "Leona Gosse" };

                context.Customers.Add(jutin);
                context.Customers.Add(willie);
                context.Customers.Add(leona);

                //Authors
                var authorDeMarco = new Author
                {
                    Name = "M J Demarco",
                    Books = new List<Book>()
                    {
                        new Book{Title="The Milionaire Fastlane"},
                        new Book{Title="Unscripted"}
                    }
                };

                var authorCardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>()
                    {
                        new Book{Title = "The 10X Rules"},
                        new Book{Title = "If You're not First, You're Last"},
                        new Book{Title = "Sell To Survive"}
                    }
                };

                context.Authors.Add(authorDeMarco);
                context.Authors.Add(authorCardone);

                context.SaveChanges();
            }
        }
    }
}
