using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace TMS.Api
{
    /// <summary>
    /// Program  类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 主函数  入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);//产生一个IHostBuilder实例hostBuilder，创建通用主机
            IHost host = hostBuilder.Build();//Build()运行给定操作以初始化主机。这只能调用一次
            host.Run();//运行应用程序并阻止调用线程，直至主机关机。

            // CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//依赖注入
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                //使用NLog
                .UseNLog();


    }
}
