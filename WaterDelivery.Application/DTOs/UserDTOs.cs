namespace WaterDelivery.Application.DTOs;

public record CreateUserRequest(string Email, string Password, int Role);

public record UserResponse(int Id, string Email, int Role);