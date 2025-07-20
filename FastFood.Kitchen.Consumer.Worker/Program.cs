using FastFood.Kitchen.Consumer.Worker;
using Consumer.Create.Contact.Infrastructure.Messaging;
using Serilog;
using MenuConsumerService.Infrastructure.Persistence;
using MenuConsumerService.Application.Interfaces;
using MenuConsumerService.Infrastructure.Services;

// grava logs em um arquivo no kubernete k8s azure
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("/app/logs/criar-PedidoCozinhas/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureAppConfiguration((context, config) =>
    {
        // Carrega o arquivo appsettings.json
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Carrega as configura��es do RabbitMQ do appsettings.json
        var rabbitMqSettings = context.Configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();

        if (rabbitMqSettings == null)        
            throw new InvalidOperationException("RabbitMQSettings n�o pode ser nulo. Verifique o arquivo appsettings.json.");
        
        services.AddSingleton(rabbitMqSettings);

        // Registrando servi�os e reposit�rios
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IMenuService, MenuService>();

        // Registrando o RabbitMQConsumer como Singleton e o Worker como HostedService
        services.AddSingleton<RabbitMQConsumer>();
        services.AddHostedService<RabbitWorker>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build();

await host.RunAsync();
