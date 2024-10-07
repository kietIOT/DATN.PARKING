using DATN.PARKING.API;
using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.ImplementMethod;
using DATN.PARKING.SERVICE.InterfaceMethod;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace DATN.PARKING.UIUX
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            // Chạy host
            host.Start(); // Có thể dùng Run() nếu bạn muốn host quản lý vòng đời ứng dụng

            // Chạy ứng dụng với form khởi đầu
            var loginForm = ServiceProvider.GetRequiredService<frmLogin>();
            Application.Run(ServiceProvider.GetRequiredService<frmLogin>());

            // Dừng host sau khi ứng dụng kết thúc
            host.StopAsync().Wait();
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddDbContext<ParkingContext>(options =>
                        options.UseSqlServer("Data Source=OBAMA\\SQLEXPRESS; Initial Catalog=DATN.PARKING;TrustServerCertificate=True;Trusted_Connection=TrueData Source=OBAMA\\SQLEXPRESS; Initial Catalog=DATN.PARKING;TrustServerCertificate=True;Trusted_Connection=True"));
                    services.AddHttpClient();
                    services.AddTransient<IUnitOfWork<ParkingContext>, UnitOfWork<ParkingContext>>();
                    services.AddTransient<IServiceParking, ServiceParking>();
                    services.AddTransient<IHardwareService, HardwareService>();
                    services.AddTransient<IHttpUtils, HttpUtils>();
                    services.AddTransient<frmLogin>();
                    services.AddTransient<frmMain>();
                });
        }
    }
}
