using System.ComponentModel.DataAnnotations;

namespace MeowsApi.Dto;

public record Reservation
{
    [Required]
    public string Id { get; init; }

    [Required]
    public DateTime StartAt { get; init; }

    [Required]
    public DateTime EndAt { get; init; }

    [Required]
    public IEnumerable<string> GuestsIds { get; init; }
}