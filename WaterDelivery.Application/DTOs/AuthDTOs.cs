namespace WaterDelivery.Application.DTOs;

public record LoginRequest(string Email, string Password);

public record LoginResponse(string Token, string Email, string Role);

public record RegisterRequest(string Email, string Password, string Name, string Phone);