using System;
using System.Threading;
using Hangfire.MissionControl;
using Microsoft.Extensions.Configuration;

namespace hangfire_example
{
    [MissionLauncher(CategoryName = "CardStock")]
    public class CreateStock
    {
        public CreateStock(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly IConfiguration configuration;

        [Mission(Name = "Create card stock",
            Description = "create country stock",
            Queue = "card-stock")]
        public void Create(int countryId)
        {
            Console.WriteLine(configuration.GetSection("Name").Value);
            Console.WriteLine(countryId);

            Thread.Sleep(1000);
        }
    }
}