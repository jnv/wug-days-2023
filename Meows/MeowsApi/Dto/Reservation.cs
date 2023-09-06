namespace MeowsApi.Dto;

public record Reservation
{
    public DateTime StartAt { get; init; }
    public DateTime EndAt { get; init; }
    public IEnumerable<Pet> Guests { get; init; }
}