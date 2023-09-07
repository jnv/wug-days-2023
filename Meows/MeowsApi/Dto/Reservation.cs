﻿namespace MeowsApi.Dto;

public record Reservation
{
    public string Id { get; init; }
    public DateTime StartAt { get; init; }
    public DateTime EndAt { get; init; }
    public IEnumerable<string> GuestsIds { get; init; }
}