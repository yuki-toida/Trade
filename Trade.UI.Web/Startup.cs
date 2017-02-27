﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trade.App.Web.Contexts;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.EF;
using Trade.Infra.EF.DataContexts;
using Trade.Infra.JsonNet;
using Trade.UI.Web.Core.Options;

namespace Trade.UI.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // オプションパターンを有効化する、ControllersコンストラクタにDI注入 http://blog.shibayan.jp/entry/20160529/1464456800
            services.AddOptions();

            services.Configure<CommonOption>(Configuration.GetSection("Common"));

            services.AddMvc();

            services.AddLogging();

            // Add DbContext
            services.AddDbContext<TradeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add ApplicationContext
            services.AddScoped<IApplicationContext, ApplicationContext>(serviceProvider =>
            {
                var dbContext = serviceProvider.GetService<TradeDbContext>();
                var dataContext = new DataContexts(dbContext);
                var serializer = new JsonNetSerializer();
                return new ApplicationContext(dataContext, serializer);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Calendar/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Calendar}/{action=Index}/{id?}");
            });
        }
    }
}
