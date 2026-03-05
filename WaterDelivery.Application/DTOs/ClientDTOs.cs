namespace WaterDelivery.Application.DTOs;

public record ClientRequest(int UserId, string Name, string Phone);

public record ClientResponse(int Id, int UserId, string Name, string Phone);