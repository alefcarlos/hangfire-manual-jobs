using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.MissionControl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace hangfire_example
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
            services.AddControllers();

            services.AddHangfire(configuration => configuration
                        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                        .UseSimpleAssemblyNameTypeSerializer()
                        .UseRecommendedSerializerSettings()
                        .UseMemoryStorage()
                        .UseMissionControl(new MissionControlOptions()
                        {
                            RequireConfirmation = false,
                        }, GetType().Assembly)
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                Queues = new string[] { "card-stock" }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHangfireDashboard();
                endpoints.MapControllers();
            });

            RecurringJob.AddOrUpdate<JobTest>(x => x.DoJob(1000), Cron.Never());
        }
    }
}
