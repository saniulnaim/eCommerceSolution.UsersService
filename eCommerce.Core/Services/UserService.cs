using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
  internal class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
      ApplicationUser? user = await _userRepository.GetUserBYEmailAndPassword(loginRequest.Email, loginRequest.Password);

      if (user == null)
      {
        return null;
      }

      //return new AuthenticationResponse(user.UserId, user.Email, user.PersonName,  user.Gender,  "token", Success: true );
      return _mapper.Map<AuthenticationResponse>(user) with
      {
        Success = true, Token = "token"
      };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
      // Create a new ApplicationUser object from RegisterRequest
      ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
      ApplicationUser? registeredUser = await _userRepository.AddUser(user);
      if (registeredUser == null)
      {
        return null;
      }

      //Return success response
      //return new AuthenticationResponse(registeredUser.UserId, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token", Success: true);
      return _mapper.Map<AuthenticationResponse>(registeredUser) with
      {
        Success = true,
        Token = "token"
      };
    }
  }
}
