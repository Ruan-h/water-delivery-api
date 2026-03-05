using FluentValidation;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Enums;
using WaterDelivery.Domain.Interfaces;

namespace WaterDelivery.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreateUserRequest> _validator;

    public UserService(IUserRepository userRepository, IValidator<CreateUserRequest> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        var user = new User(request.Email, passwordHash, (UserRole)request.Role);
        var savedUser = await _userRepository.CreateAsync(user);

        return new UserResponse(savedUser.Id, savedUser.Email, (int)savedUser.Role);
    }

    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;
        return new UserResponse(user.Id, user.Email, (int)user.Role);
    }

    public async Task<UserResponse?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null) return null;
        return new UserResponse(user.Id, user.Email, (int)user.Role);
    }
}