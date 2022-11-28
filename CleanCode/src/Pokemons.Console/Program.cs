using System.Text.Json;
using Application;
using Domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddApplication();
var sp = services.BuildServiceProvider();

var mediator = sp.GetRequiredService<IMediator>();
var command = new GetFirst10PokemonsCommand();
var response = await mediator.Send(command);

Console.WriteLine(JsonSerializer.Serialize(response));
