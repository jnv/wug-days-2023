using System.ComponentModel.DataAnnotations;

namespace MeowsApi.Dto;

public record ReservationRequest
{
    [Required]
    public DateTime StartAt { get; init; }

    [Required]
    public DateTime EndAt { get; init; }

    [Required]
    [MinLength(1)]
    public IEnumerable<string> GuestsIds { get; init; }
}