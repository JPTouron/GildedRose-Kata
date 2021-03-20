using GildedRose.Stock.Application;
using GildedRose.Stock.Application.Factory;
using GildedRose.Stock.Application.Ports;
using GildedRose.Stock.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Stock.Infrastructure.IoC
{
    public class Container
    {
        public ServiceProvider BuildServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
           .AddTransient<IItemsRepository, ItemsRepository>()
           .AddTransient<IStockApi, StockApi>()
           .AddTransient<IUpdatableItemsFactory, UpdatableItemsFactory>()

           .BuildServiceProvider();

            return serviceProvider;
        }
    }
}