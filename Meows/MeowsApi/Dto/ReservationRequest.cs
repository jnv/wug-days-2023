namespace MeowsApi.Dto;

public record ReservationRequest
{
    public DateTime StartAt { get; init; }
    public DateTime EndAt { get; init; }
    public IEnumerable<string> GuestsIds { get; init; }
}