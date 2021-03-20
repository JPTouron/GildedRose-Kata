using GildedRose.Stock.Application;
using GildedRose.Stock.Domain.Items;
using GildedRose.Stock.Infrastructure.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        private ServiceProvider sp;

        public Program()
        {
            sp = CreateIoCContainer();
            var api = sp.GetService<IStockApi>();

            Items = api.GetAllAvailableItems().ToList();
        }

        public void DisplayItems()
        {
            foreach (var item in Items)
            {
                System.Console.WriteLine($"{item.Name}:");
                System.Console.WriteLine($"\tSellIn:  {item.SellIn}");
                System.Console.WriteLine($"\tQuality: {item.Quality}");
                System.Console.WriteLine($"-------------------------");
                System.Console.WriteLine($"");
            }
        }

        public void UpdateQuality()
        {
            var api = sp.GetService<IStockApi>();

            api.UpdateQualityOfItems(Items as IReadOnlyCollection<Item>);
        }

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program();
            app.DisplayItems();

            System.Console.WriteLine("Press any key to update qualities...");
            System.Console.ReadLine();

            app.UpdateQuality();

            System.Console.WriteLine("Qualities updated");

            app.DisplayItems();

            System.Console.ReadKey();
        }

        private ServiceProvider CreateIoCContainer()
        {
            var c = new Container();
            var sp = c.BuildServiceProvider();
            return sp;
        }
    }
}