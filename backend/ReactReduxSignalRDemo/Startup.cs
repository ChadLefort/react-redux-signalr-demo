using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactReduxSignalRDemo.Hubs;
using ReactReduxSignalRDemo.Interfaces;
using ReactReduxSignalRDemo.Models;
using ReactReduxSignalRDemo.Repositories;
using ReactReduxSignalRDemo.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ReactReduxSignalRDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("ReactReduxSignalRDemoDatabase");
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<KillFeedsContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<OperatorsContext>(options => options.UseSqlServer(connection));
            services.AddSingleton(Configuration);
            services.AddScoped<ISimuateMatchRepository, SimuateMatchRepository>();
            services.AddScoped<ISimuateMatchService, SimuateMatchService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            app.UseSignalR(routes => routes.MapHub<R6StatsHub>("/r6stats"));
            app.UseMvc();
        }
    }
}
