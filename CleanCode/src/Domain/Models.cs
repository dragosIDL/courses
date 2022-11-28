namespace Domain.Models;

public record Pokemon
{
    public required int Id { get; init; }
    public required string Name { get;init; }
    public required List<Ability> Abilities { get; init;}
}

public record Ability 
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}