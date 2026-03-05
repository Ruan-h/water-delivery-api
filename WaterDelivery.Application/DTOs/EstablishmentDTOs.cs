namespace WaterDelivery.Application.DTOs;

public record EstablishmentRequest(
    string Name
);

public record EstablishmentResponse(
    int Id,
    string Name,
    bool IsOpen
);