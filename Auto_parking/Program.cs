using Auto_parking;
using Auto_parking.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

 class Program
{
    [STAThread]
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
           .AddSingleton<IRegonizePlateLicense, RegonizePlateLicense>()  // Đăng ký ApiService vào DI
           .BuildServiceProvider();

        var apiService = serviceProvider.GetRequiredService<IRegonizePlateLicense>();
      
            apiService.StartListening();

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();

    }

    
}