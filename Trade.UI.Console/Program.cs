using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trade.App.Web.Contexts;
using Trade.Infra.Contract.Contexts.Application;
using Trade.Infra.EF;
using Trade.Infra.EF.DataContexts;
using Trade.Infra.JsonNet;
using Trade.UI.Batch;

namespace Trade.UI.Console
{
    // https://github.com/aspnet/EntityFramework/blob/1.0.0-rc2/src/Microsoft.EntityFrameworkCore.Tools.Core/Design/Internal/StartupInvoker.cs
    // StartupInvoker の仕様をみるに、 $"Startup{environment}", "Startup", "Program", "App" の順番でクラスを探し、
    // 最初に見つかったクラスから、 "ConfigureServices", $"Configure{environment}Services" メソッドを探す。
    // static メソッドなら そのまま呼び出し、 そうでなければ コンストラクタで初期化してからとなる
    // (.net Core の場合は、コンストラクタの引数で IHostingEnvironment が受け取れる)
    public class Program
    {
        static Program()
        {
            // Shift-JIS対応
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ConfigurationStrings = new Dictionary<string, string>()
            {
                {"assembly", "Trade.UI.Batch"},
                {"class", "Trade.UI.Batch.Scraping.YahooPriceIncreaseRateBatch"},
                {"arguments", ""}
            };
        }

        /// <summary>
        /// コマンドライン引数をメモリに格納するための値
        /// </summary>
        private static IReadOnlyDictionary<string, string> ConfigurationStrings { get; }

        /// <summary>
        /// コンフィグ
        /// </summary>
        private static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// エントリポイント
        /// </summary>
        public static void Main(string[] args)
        {
            // Configuration
            Configuration = BuildConfiguration(args);

            // ConfigurationServices
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Build ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Add Logger
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var assemblyName = Configuration["assembly"];
            var fullClassName = Configuration["class"];
            var argument = Configuration["argument"];

            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(fullClassName))
            {
                System.Console.WriteLine("[異常終了] [USAGE] <AssemblyName> <FullClassName>");
                return;
            }

            var className = new Stack<string>(fullClassName.Split('.')).Pop();

            try
            {
                var appContext = serviceProvider.GetService<IApplicationContext>();
                var assembly = Assembly.Load(new AssemblyName(assemblyName));
                var classType = assembly.GetType(fullClassName);
                var constructor = classType.GetConstructor(new[] {typeof(IApplicationContext)});
                var batch = (IBatch) constructor.Invoke(new object[] {appContext});

                // バッチ処理実行
                var result = batch.Execute(argument);

                System.Console.WriteLine(result == BatchResultCode.Success
                    ? $"[正常終了] [{className}]"
                    : $"[異常終了] [{className}] {result}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[異常終了] [{className}] {ex.Message}");
                throw;
            }

        }

        /// <summary>
        /// Config構築
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        /// <returns>Config</returns>
        private static IConfigurationRoot BuildConfiguration(string[] args)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            builder.AddInMemoryCollection(ConfigurationStrings);
            builder.AddCommandLine(args);

            return builder.Build();
        }

        /// <summary>
        /// ConfigにService追加
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServices(IServiceCollection services)
        {
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
    }
}
