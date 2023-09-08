using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace MeowsApi.Dto;

[SwaggerSchema(
    Description = "Represents a reservation",
    Required = new[] { "Id", "StartAt", "EndAt", "GuestsId" }
)]
public record Reservation
{
    [SwaggerSchema("The reservation identifier", ReadOnly = true)]
    public string Id { get; init; }

    [Required]
    [SwaggerSchema("Start time of reservation")]
    public DateTime StartAt { get; init; }

    [Required]
    [SwaggerSchema("End time of reservation")]
    public DateTime EndAt { get; init; }

    [Required]
    [MinLength(1)]
    [SwaggerSchema("List of guests")]
    public IEnumerable<string> GuestsIds { get; init; }
}