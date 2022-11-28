namespace Integrations.HttpPokeApi;

internal record PaginationResponse<T>
{
    public required int Count { get; init; }
    public required string Next { get; init; }
    public required string Previous { get; init; }
    public required List<T> Results { get; init; }
}
