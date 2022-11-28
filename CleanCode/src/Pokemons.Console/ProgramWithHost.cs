//using System.Text.Json;

//using Application;

//using Domain.Queries;

//using MediatR;

//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//await Host
//    .CreateDefaultBuilder(args)
//    .ConfigureServices((host, services) => services
//        .AddApplication()
//        .AddHostedService<ConsoleHost>())
//    .RunConsoleAsync();


//public class ConsoleHost : IHostedService
//{
//    private readonly IMediator mediator;

//    public ConsoleHost(IMediator mediator)
//    {
//        this.mediator = mediator;
//    }

//    public async Task StartAsync(CancellationToken cancellationToken)
//    {
//        var command = new GetFirst10PokemonsCommand();
//        var response = await mediator.Send(command);
//        Console.WriteLine(JsonSerializer.Serialize(response));
//    }

//    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
//}