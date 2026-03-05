using FluentValidation;
using WaterDelivery.Application.DTOs;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Enums;
using WaterDelivery.Domain.Interfaces;

namespace WaterDelivery.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ITokenService _tokenService;
    private readonly IValidator<RegisterRequest> _validator;

    public AuthService(
        IUserRepository userRepository, 
        IClientRepository clientRepository, 
        ITokenService tokenService,
        IValidator<RegisterRequest> validator)
    {
        _userRepository = userRepository;
        _clientRepository = clientRepository;
        _tokenService = tokenService;
        _validator = validator;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null) throw new UnauthorizedAccessException("E-mail ou senha inválidos.");

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid) throw new UnauthorizedAccessException("E-mail ou senha inválidos.");

        var token = _tokenService.GenerateToken(user);

        return new LoginResponse(token, user.Email, user.Role.ToString());
    }

    public async Task<UserResponse> RegisterAsync(RegisterRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        var user = new User(request.Email, passwordHash, UserRole.Client);
        var savedUser = await _userRepository.CreateAsync(user);

        var client = new Client(savedUser.Id, request.Name, request.Phone);
        await _clientRepository.CreateAsync(client);

        return new UserResponse(savedUser.Id, savedUser.Email, (int)savedUser.Role);
    }
}