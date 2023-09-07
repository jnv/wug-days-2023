using System.ComponentModel.DataAnnotations;

namespace MeowsApi.Dto;

public record Pet
{
    [Required]
    public string Id { get; init; }

    [Required]
    public string Name { get; init; }

    [Required]
    public PetKind Kind { get; init; }

    public string OwnerEmail { get; init; }
}