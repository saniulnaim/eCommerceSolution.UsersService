using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true, Token = "token"
            };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            //var user = new ApplicationUser
            //{
            //    Email = registerRequest.Email,
            //    PersonName = registerRequest.PersonName,
            //    Password = registerRequest.Password,
            //    Gender = registerRequest.Gender.ToString()
            //};
            var user = _mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? registerUser = await _userRepository.AddUsers(user);
            if(registerUser == null) { 
                return null;
            }

            //return new AuthenticationResponse(registerUser.UserID, registerUser.Email, registerUser.PersonName, registerUser.Gender, "token", Success: true);
            return _mapper.Map<AuthenticationResponse>(registerUser) with
            {
                Success = true,
                Token = "token"
            };
        }
    }
}
