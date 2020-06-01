using System;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace hangfire_example
{
    public class JobTest
    {
        public JobTest(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly IConfiguration configuration;

        public void DoJob(int sleep)
        {
            Console.WriteLine(configuration.GetSection("Name").Value);

            Thread.Sleep(sleep);
        }
    }
}