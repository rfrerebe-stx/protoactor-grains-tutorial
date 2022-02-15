﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProtoClusterTutorial;
using SmartBulbSimulatorApp;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddActorSystem(hostContext.Configuration);
        services.AddHostedService<ClusterClientHostedService>();
        services.AddHostedService<SmartBulbSimulator>();
    })
    .Build();

var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
Proto.Log.SetLoggerFactory(loggerFactory);

await host.RunAsync();