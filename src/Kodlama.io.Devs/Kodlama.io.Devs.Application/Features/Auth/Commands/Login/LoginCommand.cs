using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Auth.Dtos;
using Kodlama.io.Devs.Application.Features.Auth.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Auth.Commands.Login
{
    public class LoginCommand:IRequest<LoginedDto>
    {
        public UserForLoginDto? UserForLoginDto { get; set; }
        public string? IpAddress { get; set; }

        public class LoginCommandHanlder : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            

            public LoginCommandHanlder(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
              
               User user= await _authBusinessRules.IsEmailOrPasswordRegistered(request.UserForLoginDto);
                AccessToken accessToken = await _authService.CreateAccessToken(user);
                RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

                return new LoginedDto
                {
                    AccessToken = accessToken,
                    RefreshToken = addedRefreshToken
                };

            }
        }
    }
}
