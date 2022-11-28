using System.Net;
using System.Threading.Tasks;

using Domain.Queries;

using MediatR;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Pokemons.Functions;

public class GetFirst10PokemonsFunction
{
    private readonly ILogger<GetFirst10PokemonsFunction> _logger;
    private readonly IMediator _mediator;

    public GetFirst10PokemonsFunction(ILogger<GetFirst10PokemonsFunction> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [Function("GetFirst10Pokemons")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        var first10Pokemons = await _mediator.Send(new GetFirst10PokemonsCommand());

        var response = req.CreateResponse(HttpStatusCode.OK);

        await response.WriteAsJsonAsync(first10Pokemons);

        return response;
    }
}
