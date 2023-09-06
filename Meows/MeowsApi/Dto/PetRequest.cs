namespace MeowsApi.Dto;

public record PetRequest
{
    public string Name { get; init; }
    public PetKind Kind { get; init; }
};