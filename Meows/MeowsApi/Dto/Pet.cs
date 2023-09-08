using System.ComponentModel.DataAnnotations;

namespace MeowsApi.Dto;

public record Pet
{
    /// <summary>
    /// Pet's unique ID
    /// </summary>
    /// <example>123123</example>
    [Required]
    public string Id { get; init; }

    /// <summary>
    /// Pet's name
    /// </summary>
    /// <example>Lassie</example>
    [Required]
    public string Name { get; init; }

    /// <summary>
    /// Pets' kind
    /// </summary>
    /// <remarks>What animal the pet is</remarks>
    [Required]
    public PetKind Kind { get; init; }

    /// <summary>
    /// Pet's owner's email address
    /// </summary>
    /// <example>joe.carraclough@example.cz</example>
    public string OwnerEmail { get; init; }
}