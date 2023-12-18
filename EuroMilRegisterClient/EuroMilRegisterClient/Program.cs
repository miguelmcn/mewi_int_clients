using EuroMilRegisterClient;

var builder = Host.CreateApplicationBuilder(args);

var appOptions = builder.Configuration.GetSection("ApplicationOptions").Get<ApplicationOptions>(u => u.BindNonPublicProperties = true);
builder.Services.AddSingleton(appOptions);

builder.Services.AddSingleton<EuroMilRegisterGateway>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
