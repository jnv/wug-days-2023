namespace MeowsApi.Dto;

public record Pet
{
    public string Id { get; init; }
    public string Name { get; init; }
    public PetKind Kind { get; init; }
}