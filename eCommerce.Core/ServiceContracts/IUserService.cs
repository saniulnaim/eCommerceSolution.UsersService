using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary> 
/// Contract for User service
/// /// </summary>
public interface IUserService
{
  /// <summary>
  /// Method to handle user login
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

  /// <summary>
  /// Method to handle user registration
  /// </summary>
  /// <param name="registerRequest"></param>
  /// <returns></returns>
  Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}

