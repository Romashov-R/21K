using ECommerce.Data;
using ECommerce.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace ECommerce;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        // Внедрение зависимостей
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
                services.AddTransient<CategoryRepository>();
                services.AddTransient<ProductRepository>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startupView = AppHost.Services.GetRequiredService<MainWindow>();
        startupView.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}