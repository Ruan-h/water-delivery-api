namespace WaterDelivery.Application.DTOs;


public record ItemRequest(
    string Name, 
    string Description, 
    decimal Price, 
    int Stock, 
    string ImageUrl);


public record ItemResponse(
    int Id, 
    string Name, 
    string Description, 
    decimal Price, 
    int Stock, 
    string ImageUrl);
